using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3.Controllers
{
    public class PostController : Controller
    {
        static readonly Dictionary<int, Post> _posts = new Dictionary<int, Post>();
        static int index = 1;
        public IActionResult Index()
        {
            return View(_posts);
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
                model.Id = index++;
                model.PostDate = DateTime.Now;
                _posts[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_posts[id]);
        }
        [HttpPost]
        public IActionResult Update(Post model)
        {
            if (ModelState.IsValid)
            {
                _posts[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_posts[id]);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_posts.ContainsKey(id))
            {
                _posts.Remove(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}