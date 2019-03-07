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
    public class TestProductType
    {
        private IProductTypeBLL productTypeBLL = new ProductTypeBLL();

        [TestMethod]
        public void GetAllTest()
        {
            var data = productTypeBLL.GetAll().Select(p => new 
            {
                Text = p.Name,
                Value = p.Id.ToString(),
                Selected = p.Id == 8
            });
            foreach (var item in data)
            {
                Console.WriteLine("text:{0} , value:{1} , selected:{2}", item.Text, item.Value, item.Selected);
            }

        }
    }
}
