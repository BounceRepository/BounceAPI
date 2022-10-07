using Bounce.DataTransferObject.DTO.Auth.Articles;
using Bounce.DataTransferObject.Helpers.BaseResponse;
using Bounce_Application.Persistence.Interfaces.Context;
using Bounce_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce_Application.Persistence.Interfaces.Articles
{
    public interface IArticleServices : IRepository<Article>
    {
        Task<Response> CreateArticle(ArticleCreateDto model);
        Task<Response> GetArticles();
    }
}
