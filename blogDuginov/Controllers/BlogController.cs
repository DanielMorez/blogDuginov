using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace blogDuginov.Controllers
{
    /// <summary>
    /// Контроллер для работы с индексным файлом
    /// </summary>
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;

        /// <summary>
        /// Констуркторкласса <see cref="HomeController"/>
        /// </summary>
        /// <param name="TempRepository">Репозиторий </param>
        public BlogController(ILogger<HomeController> logger)
        {
            _logger = (ILogger<BlogController>)logger;
        }
    public IActionResult Index()
        {
            return View();
        }
    }
}
