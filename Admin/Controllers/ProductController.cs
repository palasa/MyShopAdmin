using BLL;
using Common;
using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Admin.Filters;

namespace Admin.Controllers
{
    [LoginFilter(Order=1)]
    // [LoggerFilter(Order = 2)]
    public class ProductController : Controller
    {

        // a) 构造函数注入
        private IProductBLL productBLL ;

        private IProductTypeBLL productTypeBLL;

        private IProductColorBLL productColorBLL;

        public ProductController(IProductBLL productBLL , IProductTypeBLL productTypeBLL , IProductColorBLL productColorBLL)
        {
            this.productBLL = productBLL;
            this.productTypeBLL = productTypeBLL;
            this.productColorBLL = productColorBLL;
        }

        // b) 属性注入
        // private IProductTypeBLL productTypeBLL { get; set; }


        // private IProductColorBLL productColorBLL = new ProductColorBLL();
        //public IProductColorBLL productColorBLL { get; set; }
        // private IProductSizeBLL productSizeBLL = new ProductSizeBLL();
        public IProductSizeBLL productSizeBLL { get; set;  }

        public IProductImageBLL productImageBLL { get; set; }

        // GET: Product
        [LoginFilter]
        public ActionResult List(int? Page, int? ProductTypeId , string OrderField)
        {
            

            if (Page == null)
            {
                Page = 1;
            }
            if (ProductTypeId == null)
            {
                ProductTypeId = -1;
            }
            if (OrderField == null)
            {
                OrderField = "NewPrice";
            }

            ViewBag.ProductTypeId = ProductTypeId;
            ViewBag.OrderField = OrderField;

            // 是否要进行筛选
            Expression<Func<Product, bool>> whereExpression = p => true;
            if (ProductTypeId != -1)
            {
                whereExpression = p => p.ProductType.Id == ProductTypeId ||         // 二级菜单
                        p.ProductType.ParentProductType.Id== ProductTypeId;         // 一级菜单
            }




            // 获取 商品类别表中的所有数据
            var productTypeViewModels = productTypeBLL
                .GetByCondition(pt => pt.Pid == null)
                .Select(pt => new ProductTypeViewModel {
                    Id = pt.Id ,
                    Name = pt.Name ,
                    Pid = pt.Pid ,
                    ChildProductTypes = pt.ChildProductTypes
            });
            ViewBag.productTypeViewModels = productTypeViewModels;


            
            // 分页
            var pageSize = 3;
            var totalCount = productBLL.GetCount(whereExpression);
            var totalPages = Math.Ceiling(totalCount * 1.0 / pageSize);

            ViewBag.totalPages = totalPages;
            ViewBag.Page = Page;


           
            var data = productBLL.GetByPage(
                pageSize,
                Convert.ToInt32(Page),
                true,
                OrderField,
                whereExpression
            );
           

            return View(data);
        }

        public ActionResult Delete( int id)
        {
            productBLL.DeleteById(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.productTypes = productTypeBLL.GetAll();
            ViewBag.productColors = productColorBLL.GetAll();
            ViewBag.productSizes = productSizeBLL.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]          // 不验证请求中数据是否含有 html 代码
        public ActionResult Create( Product p , IEnumerable<HttpPostedFileBase> Images)
        {
            if (!ModelState.IsValid)
            {
                List<string> sb = new List<string>();
                //获取所有错误的Key
                List<string> Keys = ModelState.Keys.ToList();
                //获取每一个key对应的ModelStateDictionary
                foreach (var key in Keys)
                {
                    var errors = ModelState[key].Errors.ToList();
                    //将错误描述添加到sb中
                    foreach (var error in errors)
                    {
                        sb.Add(error.ErrorMessage);
                    }
                }
                

                ViewBag.productTypes = productTypeBLL.GetAll();
                ViewBag.productColors = productColorBLL.GetAll();
                ViewBag.productSizes = productSizeBLL.GetAll();
                ViewBag.Errors = sb;
                return View(p);
            }

            // return Content("验证通过");
            int productId = productBLL.Add(p).Id;

            // 处理商品图片
            string path = Server.MapPath("~/Images/Product/");
            foreach (HttpPostedFileBase image in Images)
            {
                string imageName = Guid.NewGuid().ToString();
                string extName = Path.GetExtension(image.FileName);

                string realPath = path + imageName + extName;
                image.SaveAs(realPath);                   // 用户上传的原图

                Image bigImage = Image.FromStream(image.InputStream);
                int longSide = 200;         //小图的长边
                int w, h;
                if ( bigImage.Width > bigImage.Height )
                {
                    w = longSide;
                    h = w * bigImage.Height / bigImage.Width;
                }
                else
                {
                    h = longSide;
                    w = h * bigImage.Width / bigImage.Height;
                }
                Image smallImage = new Bitmap(bigImage, new Size(w, h));
                string smallName = Guid.NewGuid().ToString();
                smallImage.Save(path + smallName + extName);            // 生成的缩略图

                // 写入数据库
                productImageBLL.Add(new Model.ProductImage {
                    ProductId = productId ,
                    BigImage = imageName + extName,
                    SmallImage = smallName + extName
                });
            }
            return RedirectToAction("List");
        }

        public ActionResult DeleteMany(int[] id)
        {
            for (int i = 0; i < id.Length; i++)
            {
                productBLL.DeleteById(id[i]);
            }
            
            return RedirectToAction("List");
        }

        public ActionResult Detail( int id)
        {
            return View(productBLL.GetById(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = productBLL.GetById(id);

            ViewBag.ProductTypes = productTypeBLL.GetAll().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString(),
                Selected = p.Id == product.TypeId
            });
            ViewBag.ProductColors = productColorBLL.GetAll().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString(),
                Selected = p.Id == product.ProductColorId
            });
            ViewBag.ProductSizes = productSizeBLL.GetAll().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString(),
                Selected = p.Id == product.ProductSizeId
            });


            return View(product);
        }

        [HttpPost]
        public ActionResult Edit( Product p )
        {
            return View();
        }
    }
}