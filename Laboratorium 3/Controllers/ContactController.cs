using Microsoft.AspNetCore.Mvc;
using Laboratorium_3.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium_3.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        public IActionResult PagedIndex([FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            return View(_contactService.FindPage(page, size));
        }

        [HttpGet]
        public IActionResult Create()
        {
            Contact model = new Contact();
            model.Organizations = _contactService
                .FindAllOrganizations()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateApi()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateApi(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Contact contact = _contactService.FindById(id);
            if (contact == null)
            {
                return NotFound();
            }
            contact.Organizations = _contactService.FindAllOrganizations().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Title,
                Value = eo.Id.ToString(),
            }).ToList();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            model.Organizations = _contactService.FindAllOrganizations().Select(eo => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = eo.Title,
                Value = eo.Id.ToString(),
            }).ToList();

            if (ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Contact contact = _contactService.FindById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Contact contact = _contactService.FindById(id);

            if (contact == null)
            {
                return NotFound();
            }

            var organization = _contactService.FindAllOrganizations()
                .FirstOrDefault(eo => eo.Id == contact.OrganizationId);

            contact.OrganizationName = organization?.Title;

            return View(contact);
        }
    }
}
