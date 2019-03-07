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
    public class ProductBLL : BaseBLL<Product>, IProductBLL
    {
        IProductDAL productDAL = new ProductDAL();
        IProductImageDAL productImageDAL = new ProductImageDAL();

        public ProductBLL()
        {
            this.SetDal(productDAL);
        }     
        
        public override void DeleteById(int id)
        {
            // 先删除 该商品的所有图片
            productImageDAL.DeleteByCondition(pi => pi.ProductId == id);

            // 再删除 该商品
            productDAL.DeleteById(id);
        } 
    }
}
