using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogDuginov.Domain.DB;
using blogDuginov.Domain.Model;
using blogDuginov.Security.Extensions;
using blogDuginov.ViewModels.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogDuginov.Controllers
{
    /// <summary>
    /// Контроллер для работы с блогом
    /// </summary>
    public class BlogController : Controller
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext ?? throw new ArgumentNullException(nameof(blogDbContext));
        }


        /// <summary>
        /// Метод открывает страницу с добавлением поста
        /// </summary>
        /// <returns>Возварщает страницу для добавления поста</returns>
        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        /// <summary>
        /// Добавление поста
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Переход на страницу постов пользователя</returns>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(NewPostViewModels model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = this.GetAuthorizedUser();

            var post = new BlogPost
            {
                Created = DateTime.Now,
                Data = model.Data,
                Title = model.Title,
                Owner = user.Employee
            };

            _blogDbContext.BlogPosts.Add(post);

            _blogDbContext.SaveChanges();

            return View();

        }

        /// <summary>
        /// Возвращение представления Blog возвратом Index.cshtml
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {
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
    }
}
