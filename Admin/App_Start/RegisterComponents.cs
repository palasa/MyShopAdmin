using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Admin.App_Start
{
    public static class RegisterComponents
    {
        public static void Register ()
        {
            // 注册 Autofac ioc 容器
            ContainerBuilder builder = new ContainerBuilder();

            // 注册控制器
            //builder.RegisterControllers(typeof(AdminController).Assembly);

            // Assembly.GetExecutingAssembly() 获取当前项目所在的程序集 Admin
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            var IBLL = Assembly.Load("IBLL");
            var BLL = Assembly.Load("BLL");
            var IDAL = Assembly.Load("IDAL");
            var DAL = Assembly.Load("DAL");

            //根据名称约定（服务层的接口和实现均以BLL结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(IBLL, BLL)
              .Where(t => t.Name.EndsWith("BLL")).PropertiesAutowired()
              .AsImplementedInterfaces();

            //根据名称约定（数据访问层的接口和实现均以DAL结尾），实现数据访问接口和数据访问实现的依赖
            builder.RegisterAssemblyTypes(IDAL, DAL)
              .Where(t => t.Name.EndsWith("DAL")).PropertiesAutowired()
              .AsImplementedInterfaces();

            // 把 ProductBLL 类 注册成为 IProductBLL 接口的实现类
            //builder.RegisterType<ProductBLL>().As<IProductBLL>();
            //builder.RegisterType<ProductTypeBLL>().As<IProductTypeBLL>();

            // 通过 Build() 方法 生成容器对象
            IContainer container = builder.Build();

            // 处理该控制器
            // container.Resolve<AdminController>();


            // 再mvc5中默认的依赖管理器中 注册 Autofac 容器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}