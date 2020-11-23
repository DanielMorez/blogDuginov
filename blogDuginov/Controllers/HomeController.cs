using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using blogDuginov.Models;
using blogDuginov.Domain.DB;
using blogDuginov.ViewModels.Blog;

namespace blogDuginov.Controllers
{
    /// <summary>
    /// Контроллер блога
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogDbContext _blogDbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger, BlogDbContext blogDbContext)
        {
            _logger = logger;
            _blogDbContext = blogDbContext ?? throw new ArgumentNullException(nameof(blogDbContext));
        }

        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            /*return View();*/

            var posts = _blogDbContext.BlogPosts
                .Select(x => new ShowAllPostViewModel
                {
                    Author = x.Owner.FullName,
                    Date = x.Created,
                    Data = x.Data,
                    Title = x.Title
                }).OrderByDescending(x => x.Date);

            return View(posts);
        }

        /// <summary>
        /// Раздел о Конфиденциальности
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Окно при ошибке
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
