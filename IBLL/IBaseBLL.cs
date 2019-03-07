using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IBaseBLL<T> where T : class, new()
    {
        T Add(T t);

        void DeleteById(int id);

        /// <summary>
        /// 根据条件的 lambda表达式 进行删除
        /// </summary>
        /// <param name="deleteWhere"></param>
        void DeleteByCondition(Expression<Func<T, bool>> deleteWhere);

        void Modify(T entity, params string[] propertyNames);

        T GetById(int id);
        int GetCount();
        int GetCount(Expression<Func<T, bool>> whereExpression);
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> whereExpression);
        IQueryable<T> GetByPage<type>(int pageSize, int currentPage, bool isAsc, Expression<Func<T, type>> orderExpression, Expression<Func<T, bool>> whereExpression);
        IQueryable<T> GetByPage(int pageSize, int currentPage, bool isAsc, string orderFieldName, Expression<Func<T, bool>> whereExpression);
    }

    public partial interface IAdminBLL : IBaseBLL<Admin> { }
    public partial interface IMenuBLL : IBaseBLL<Menu> { }
    public partial interface IUserBLL : IBaseBLL<User> { }
    public partial interface IProductBLL : IBaseBLL<Product> { }
    public partial interface IProductTypeBLL : IBaseBLL<ProductType> { }
    public partial interface IProductColorBLL : IBaseBLL<ProductColor> { }
    public partial interface IProductSizeBLL : IBaseBLL<ProductSize> { }
    public partial interface IProductImageBLL : IBaseBLL<ProductImage> { }
}
