using Laboratorium_3.Controllers;
using Laboratorium_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Laboratorium_9___Test
{
    public class ContactControllerTest
    {
        private ContactController _controller;
        private IContactService _service;

        public ContactControllerTest()
        {
            _service = new MemoryContactService(new CurrentDateTimeProvider());
            _service.Add(new Contact() { Id = 1 });
            _service.Add(new Contact() { Id=2 });
            _controller = new ContactController(_service);
        }

        [Fact]
        public void IndexTest()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            var model = view.Model as List<Contact>;
            Assert.Equal(2, view.Model);
        }

        //Napisz test metody Detail dla id = 1
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [Fact]
        public void DetailsTestForExistingContatcs(int id)
        {
            var result = _controller.Details(1);
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            var model = view.Model as Contact;
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public void DetailsTwstForNonExistingContact()
        {
            var result = _controller.Details(3);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}