using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Model;
using Common;

namespace DAL
{
    public class BaseDAL<T> where T : class, new()
    {
        protected MyShopEntities db = new MyShopEntities();

        public T Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
            return db.Set<T>().Attach(entity);
        }

        public void DeleteByCondition(Expression<Func<T, bool>> deleteWhere)
        {
            db.Set<T>().RemoveRange(db.Set<T>().Where(deleteWhere));
            db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            db.Set<T>().Remove(
                db.Set<T>().Find(id)
            );
            db.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public int GetCount()
        {
            return this.GetAll().Count();
        }

        public int GetCount(Expression<Func<T, bool>> whereExpression)
        {
            return db.Set<T>().Where(whereExpression).Count();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> whereExpression)
        {
            return db.Set<T>().Where(whereExpression);
        }

        /// <summary>
        /// 获取分页完成的数据
        /// </summary>
        /// <typeparam name="TKey">排序的字段的数据类型</typeparam>
        /// <param name="pageSize"></param>
        /// <param name="currentPage"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderExpression"></param>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        public IQueryable<T> GetByPage<TKey>(int pageSize, int currentPage, bool isAsc, Expression<Func<T, TKey>> orderExpression, Expression<Func<T, bool>> whereExpression)
        {
            if (isAsc)
            {
                return db.Set<T>().Where(whereExpression).OrderBy(orderExpression).Skip((currentPage - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return db.Set<T>().Where(whereExpression).OrderByDescending(orderExpression).Skip((currentPage - 1) * pageSize).Take(pageSize);
            }
        }


        public IQueryable<T> GetByPage(int pageSize, int currentPage, bool isAsc, string orderFieldName, Expression<Func<T, bool>> whereExpression)
        {
            return db.Set<T>().Where(whereExpression).OrderBy(orderFieldName, isAsc).Skip((currentPage - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"> 新的实体类对象 </param>
        /// <param name="propertyNames">该类中需要修改的属性的数组</param>
        public void Modify(T entity, params string[] propertyNames)
        {
            // db.Set<T>().Attach(entity);

            // for (int i = 0; i < propertyNames.Length; i++)
            // {
            //     db.Entry(entity).Property(propertyNames[i]).IsModified = true;
            // }

            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }
    }

    public partial class AdminDAL : BaseDAL<Admin>, IAdminDAL { }
    public partial class MenuDAL : BaseDAL<Menu>, IMenuDAL { }
    public partial class UserDAL : BaseDAL<User>, IUserDAL { }
    public partial class ProductDAL : BaseDAL<Product>, IProductDAL { }
    public partial class ProductTypeDAL : BaseDAL<ProductType>, IProductTypeDAL { }

    public partial class ProductImageDAL : BaseDAL<ProductImage>, IProductImageDAL { }
    public partial class ProductSizeDAL : BaseDAL<ProductSize>, IProductSizeDAL { }
    public partial class ProductColorDAL : BaseDAL<ProductColor>, IProductColorDAL { }
}
