using AutoMapper;
using Bounce.DataTransferObject.DTO.Auth.Articles;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce.Services.Implementation.Repositorires;
using Bounce_Application.Persistence.Interfaces.Articles;
using Bounce_Application.Persistence.Interfaces.Context;
using Bounce_Application.SeriLog;
using Bounce_Application.Utilies;
using Bounce_DbOps.EF;
using Bounce_Domain.Entity;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.Implementation.Services.Articles
{
    public class ArticleServices : Repository<Article>, IArticleServices
    {
        private readonly IMapper _mapper;
        private readonly SessionManager _sessionManager;
        private readonly FileManager _fileManager;
        private readonly AdminLogger _adminLogger;
        public ArticleServices(BounceDbContext context, IMapper mapper, SessionManager sessionManager, FileManager fileManager, AdminLogger adminLogger) : base(context)
        {
            _mapper = mapper;
            _sessionManager = sessionManager;
            _fileManager = fileManager;
            _adminLogger = adminLogger;
        }

        public async Task<Response> CreateArticle(ArticleCreateDto model)
        {
            try
            {
                var currentUser = _sessionManager.CurrentLogin;
               var entity =  _mapper.Map<Article>(model);
                entity.CreatedById = currentUser.Id;
                entity.EditedById = currentUser.Id;
                entity.BannerFilePath = _fileManager.FileUpload(model.Banner, "Article");
                entity.LastModifiedBy = currentUser.Email;
               
                _context.Add(entity);
                if (await SaveAsync())
                    return new Response { StatusCode = StatusCodes.Status200OK, Message = "Article Created" };

                return new Response
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Sorry we can not complete your request at this time, please try again later"
                };


            }
            catch (Exception ex)
            {

                _adminLogger.LogRequest($"{"internal server error }"}{ex}{" - "}{JsonConvert.SerializeObject(model)}{" - "}{DateTime.Now}", true);

                return new Response
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Internal server error occured"
                };
            }
        }
        public async Task<Response> GetArticles()
        {
            try
            {

                var articles = _context.Articles.Select(x => new { Titel = x.Title, Text = x.Text, Banner = _fileManager.GetHost() + x.BannerFilePath }).ToList();
      
                 return new Response { Data = articles, StatusCode = StatusCodes.Status200OK };

            }
            catch (Exception ex)
            {

                _adminLogger.LogRequest($"{"internal server error }"}{ex}{" - "}{" - "}{DateTime.Now}", true);

                return new Response
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Internal server error occured"
                };
            }
        }
        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;
    }
}
