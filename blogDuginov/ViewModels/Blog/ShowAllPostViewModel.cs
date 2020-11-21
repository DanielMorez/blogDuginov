using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blogDuginov.ViewModels.Blog
{
    public class ShowAllPostViewModel
    {
        /// <summary>
        /// Автор поста
        /// </summary>
        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        /// <summary>
        /// Дата поста
        /// </summary>
        [Required]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Заголовок поста
        /// </summary>
        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        /// <summary>
        /// Данные поста
        /// </summary>
        [Required]
        [Display(Name = "Данные")]
        public string Data { get; set; }
    }
}