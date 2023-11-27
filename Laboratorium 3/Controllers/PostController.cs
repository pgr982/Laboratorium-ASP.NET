using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Laboratorium_3.Controllers
{
    public class PostController : Controller
    {

        //static readonly Dictionary<int, Post> _posts = new Dictionary<int, Post>();
        //static int index = 1;
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            return View(_postService.FindAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_postService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_postService.FindById(id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _postService.Delete(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}