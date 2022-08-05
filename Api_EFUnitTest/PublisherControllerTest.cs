using AutoFixture;
using EF_Api.Controllers;
using EF_Api.DB.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using EF_Api.DB.models;
using System.Text;
using System.Threading.Tasks;

using EF_Api.DB.models.MockModels;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Api_EFUnitTest
{
    [TestClass]
    public class PublisherControllerTest
    {
        private Mock<IUnitOfWork> unitOfWork;
        private Fixture _fixture;
        private PublisherController _controller;
        public PublisherControllerTest()
        {
            unitOfWork = new Mock<IUnitOfWork>();
            _fixture = new Fixture();
        }
        [TestMethod]
        public async Task Get()
        {
            //var publisherList = _fixture.CreateMany<PublisherMock>(2).ToList();

            string json = File.ReadAllText("TestData/Publishers.json");
            var publisherList = JsonConvert.DeserializeObject<List<Publisher>>(json);

            unitOfWork.Setup(repo => repo.Publisher.GetAll()).Returns(publisherList);
            _controller = new PublisherController(null, unitOfWork.Object, null);

            var result = _controller.Get();
            var obj = result.Result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task Post()
        {
            string json = File.ReadAllText("TestData/PublisherPost.json");
            var publisher = JsonConvert.DeserializeObject<Publisher>(json);
            unitOfWork.Setup(repo => repo.Publisher.Add(It.IsAny<Publisher>())).Returns(publisher);

            _controller = new PublisherController(null, unitOfWork.Object, null);
            var result = _controller.Post(publisher);
            var obj = result.Result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
    }
}
