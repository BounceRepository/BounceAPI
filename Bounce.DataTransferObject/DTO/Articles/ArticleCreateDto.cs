using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.DataTransferObject.DTO.Auth.Articles
{
    public class ArticleCreateDto
    {

        [Required]

        public string Title { get; set; }
        [Required]

        public string Text { get; set; }
      
        public IFormFile Banner { get; set; }

 

    }
}
