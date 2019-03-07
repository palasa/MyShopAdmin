using DAL;
using IBLL;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductImageBLL : BaseBLL<ProductImage>, IProductImageBLL
    {
        IProductImageDAL productImageDAL = new ProductImageDAL();

        public ProductImageBLL()
        {
            this.SetDal(productImageDAL);
        }      
    }
}
