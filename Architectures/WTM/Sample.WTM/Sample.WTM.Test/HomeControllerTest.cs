using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Sample.WTM.Controllers;
using Sample.WTM.ViewModels.HomeVMs;

namespace Sample.WTM.Test
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController _controller;
        private string _seed;

        public HomeControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<HomeController>(_seed, "user");
        }

        [TestMethod]
        public void PIndexTest()
        {
            ViewResult rv = (ViewResult)_controller.PIndex();
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void FrontPageTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.FrontPage();
            Assert.IsNotNull(rv);
        }
    }
}
