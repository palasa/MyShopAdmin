using BLL;
using IBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Tests.BLLTest
{

    [TestClass]
    public class TestProductBLL
    {

        private IProductBLL productBLL = new ProductBLL();


        [TestMethod]
        public void GetByIdTest()
        {
            Assert.AreEqual(8, productBLL.GetById(6).ProductType.Id);
        }

    }
}
