using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    /// <summary>
    /// IDAL 层所有接口的 父接口 ， 定义 基础的 crud 操作
    /// IBaseDAL<T> where T : class , new() 代表 T 类型 必须是引用 类型
    /// </summary>
    public interface IBaseDAL<T> where T : class , new()
    {
        T Add(T user);

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(int id);

        /// <summary>
        /// 根据条件的 lambda表达式 进行删除
        /// </summary>
        /// <param name="deleteWhere"></param>
        void DeleteByCondition(Expression<Func<T, bool>> deleteWhere);

        void Modify(T entity, params string[] propertyNames);

        /// <summary>
        /// 获取该表所有数据的方法
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// 获取该表中所有数据的总条数的方法
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// 获取该表中根据条件进行筛选后的数据的条数的方法
        /// </summary>
        /// <param name="whereExpression">筛选条件</param>
        /// <returns></returns>
        int GetCount(Expression<Func<T, bool>> whereExpression);

        T GetById(int id);

        IQueryable<T> GetByCondition( Expression<Func<T, bool>> whereExpression );

        IQueryable<T> GetByPage<type>(int pageSize, int currentPage, bool isAsc, Expression<Func<T, type>> orderExpression, Expression<Func<T, bool>> whereExpression);

        IQueryable<T> GetByPage(int pageSize, int currentPage, bool isAsc, string orderFieldName , Expression<Func<T, bool>> whereExpression);
    }

    public partial interface IAdminDAL : IBaseDAL<Admin> { }
    public partial interface IMenuDAL : IBaseDAL<Menu> { }
    public partial interface IUserDAL : IBaseDAL<User> { }
    public partial interface IProductDAL : IBaseDAL<Product> { }
    public partial interface IProductTypeDAL : IBaseDAL<ProductType> { }
    public partial interface IProductImageDAL : IBaseDAL<ProductImage> { }
    public partial interface IProductSizeDAL : IBaseDAL<ProductSize> { }
    public partial interface IProductColorDAL : IBaseDAL<ProductColor> { }
}
