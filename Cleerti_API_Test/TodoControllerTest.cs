using Cleerti_API_Test.Fake;
using Clevert.Domain;
using Cleverti_API;
using Cleverti_API.Controllers;
using Cleverti_API.Service.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cleerti_API_Test
{
    public class TodoControllerTest
    {
        TodoController _controller;
        ITodoService _service;
        public TodoControllerTest()
        {
            _service = new TodoServiceFake();
            _controller = new TodoController(_service);
        }

        #region Get
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {            
            var okResult = _controller.Get();            
            Assert.IsType<OkObjectResult>(okResult.Result.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {            
            var okResult = _controller.Get().Result.Result as OkObjectResult;            
            var items = Assert.IsType<List<TodoVO>>(okResult.Value);
            Assert.Equal(5, items.Count);
        }
        #endregion

        #region GetById
        [Fact]
        public void GetById_InvalidGuidPassed_ReturnsNotFoundResult()
        {            
            var notFoundResult = _controller.GetById(Guid.NewGuid());            
            Assert.IsType<NotFoundResult>(notFoundResult.Result.Result);
        }
        [Fact]
        public void GetById_ValidGuid_ReturnsOkResult()
        {            
            var testGuid = new Guid("6da0e0a9-143e-466e-b594-4ddb3d0fb5d3");            
            var okResult = _controller.GetById(testGuid);            
            Assert.IsType<OkObjectResult>(okResult.Result.Result);
        }
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {            
            var testGuid = new Guid("6da0e0a9-143e-466e-b594-4ddb3d0fb5d3");            
            var okResult = _controller.GetById(testGuid).Result.Result as OkObjectResult;            
            Assert.IsType<TodoVO>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as TodoVO).Id);
        }
        #endregion

        #region Insert
        [Fact]
        public void Insert_InvalidObjectPassed_ReturnsBadRequest()
        {            
            var nameMissingItem = new TodoVO() { Id = Guid.Parse("6da0e0a9-143e-466e-b594-4ddb3d0fb5d3"), TaskName = "Dentist" };
            _controller.ModelState.AddModelError("Category", "Required");            
            var badResponse = _controller.Insert(nameMissingItem).Result;            
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Insert_ValidObjectPassed_ReturnsCreatedResponse()
        {            
            TodoVO item = new TodoVO()
            {
                Id = Guid.Parse("6da0e0a9-143e-466e-b594-4ddb3d0fb5d3"),
                Category = "Personal Appointment",
                CreatedDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2).AddHours(2),
                StartDate = DateTime.Now.AddDays(2).AddHours(1),
                TaskName = "Dentist"
            };            
            var createdResponse = _controller.Insert(item).Result;            
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Insert_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {            
            var testItem = new TodoVO()
            {
                Category = "Personal"
            };           
            var createdResponse = _controller.Insert(testItem).Result as CreatedAtActionResult;
            var item = createdResponse.Value as TodoVO;            
            Assert.IsType<TodoVO>(item);
            Assert.Equal("Personal", item.Category);
        }
        #endregion

        #region Delete
        [Fact]
        public void Delete_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {            
            var invalidGuid = Guid.NewGuid();            
            var badResponse = _controller.Delete(invalidGuid).Result;            
            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void Delete_ExistingGuidPassed_ReturnsOkResult()
        {            
            var validGuid = new Guid("6da0e0a9-143e-466e-b594-4ddb3d0fb5d3");
            var okResponse = _controller.Delete(validGuid).Result;
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void Delete_ExistingGuidPassed_DeletesOneItem()
        {            
            var validGuid = new Guid("6da0e0a9-143e-466e-b594-4ddb3d0fb5d3");            
            var okResponse = _controller.Delete(validGuid).Result;            
            Assert.Equal(4, _service.Get().Result.Count);
        }
        #endregion

        #region Update
        [Fact]
        public void Update_InvalidObjectPassed_ReturnsBadRequest()
        {
            var nameMissingItem = new TodoVO() { Id = Guid.Parse("6da0e0a9-143e-466e-b594-4ddb3d0fb5d3"), TaskName = "Dentist" };
            _controller.ModelState.AddModelError("Category", "Required");
            var badResponse = _controller.Update(nameMissingItem).Result;
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Update_ValidObjectPassed_ReturnsCreatedResponse()
        {
            TodoVO item = new TodoVO()
            {
                Id = Guid.Parse("6da0e0a9-143e-466e-b594-4ddb3d0fb5d3"),
                Category = "Personal Appointment",
                CreatedDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2).AddHours(2),
                StartDate = DateTime.Now.AddDays(2).AddHours(1),
                TaskName = "Dentist"
            };
            var createdResponse = _controller.Update(item).Result;
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Update_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            var testItem = new TodoVO()
            {
                Id = Guid.Parse("6da0e0a9-143e-466e-b594-4ddb3d0fb5d3"),
                Category = "Personal Appointment",
                CreatedDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2).AddHours(2),
                StartDate = DateTime.Now.AddDays(2).AddHours(1),
                TaskName = "Dentist"
            };
            var createdResponse = _controller.Update(testItem).Result as CreatedAtActionResult;
            var item = createdResponse.Value as TodoVO;
            Assert.IsType<TodoVO>(item);
            Assert.Equal("Personal Appointment", item.Category);
        }
        #endregion
    }
}
