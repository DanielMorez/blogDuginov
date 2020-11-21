using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blogDuginov.ViewModels.Blog
{
    public class NewPostViewModels
    {

        /// <summary>
        /// Заголовок поста
        /// </summary>
        [Required]
        [Display(Name = "Заголовок поста")]
        public String Title { get; set; }

        /// <summary>
        /// Данные поста
        /// </summary>
        [Required]
        [Display(Name = "Данные поста")]
        public String Data { get; set; }
    }
}
