using AutoMapper;
using Bounce.DataTransferObject.DTO.Journal;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Helper;
using Bounce_Application.Persistence.Interfaces.Journal;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Journal
{
    public class JournalServices : BaseServices, IJournalServices
    {
        private readonly IMapper _mapper;
        private readonly SessionManager _sessionManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEmalService _EmailService;
        private readonly FileManager _fileManager;
        public JournalServices(BounceDbContext context, IMapper mapper, SessionManager sessionManager, UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment, IEmalService emailService, FileManager fileManager) : base(context)
        {
            _mapper = mapper;
            _sessionManager = sessionManager;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            _EmailService = emailService;
            _fileManager = fileManager;
        }

        public async Task<Response> Create(CreateJournalDto model)
        {
            try
            {

                var journal = new Bounce_Domain.Entity.Journal
                {
                    Title = model.Title,
                    Text = model.Text,
                    CreatedById = _sessionManager.CurrentLogin.Id,
                    CreatedTimeOffset = DateTimeOffset.Now
                };
                await _context.AddAsync(journal);
                if (!await SaveAsync())
                    return FailedSaveResponse(model);
                return SuccessResponse();
            }
            catch(Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> Edit(UpdateJournalDto model)
        {
            try
            {
                var journal = _context.Journals.FirstOrDefault(x => x.Id == model.JournalId);
                if (journal == null)
                    return AuxillaryResponse("record not found", StatusCodes.Status404NotFound);
                
                if(!string.IsNullOrEmpty(model.Text))
                {
                    journal.Title = model.Text;
                }
                if (!string.IsNullOrEmpty(model.Title))
                {
                    journal.Title = model.Title;
                }
                journal.ModifiedTimeOffset = DateTimeOffset.Now;
                
                 _context.Update(journal);
                if (!await SaveAsync())
                    return FailedSaveResponse(model);
                return SuccessResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public async Task<Response> Delete(long id)
        {
            try
            {
                var journal = _context.Journals.FirstOrDefault(x => x.Id == id);
                if (journal == null)
                    return AuxillaryResponse("record not found", StatusCodes.Status404NotFound);

                _context.Journals.Remove(journal);

                if (!await SaveAsync())
                    return FailedSaveResponse(id);
                return SuccessResponse();
            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }
        public Response GetById(long id)
        {
            try
            {
                var journal = _context.Journals.FirstOrDefault(x => x.Id == id);
                if (journal == null)
                    return AuxillaryResponse("record not found", StatusCodes.Status404NotFound);

                var data = new
                {
                    JournalId = journal.Id,
                    Title = journal.Title,
                    Text = journal.Text,
                    CreatedTime = journal.CreatedTimeOffset
                };

                return SuccessResponse(data: data);

            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }

        public Response GetAll()
        {
            try
            {
                var user = _sessionManager.CurrentLogin;

                var data = (from journal in _context.Journals.Where(x => !x.IsDeleted && x.CreatedById == user.Id)
                            select new
                            {
                                JournalId = journal.Id,
                                Title = journal.Title,
                                Text = journal.Text,
                                CreatedTime = journal.DateCreated,
  
                            });


                return SuccessResponse(data: data) ;


            }
            catch (Exception ex)
            {
                return InternalErrorResponse(ex);
            }
        }


    }
}
