using Autofac;
using AutofacAspNetCore3_0.Controllers;
using AutofacAspNetCore3_0.MiddleLayer;
using AutofacAspNetCore3_0.Services;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace AutofacAspNetCore3_0
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //业务逻辑层所在程序集命名空间
            System.Reflection.Assembly AutofacAspNetCore3_0 = typeof(Program).Assembly;
            System.Reflection.Assembly service = System.Reflection.Assembly.Load("BLL");

            //自动注入
            builder.RegisterAssemblyTypes(service)
                .Where(t => t.Name.EndsWith("BLL"))
                .InstancePerLifetimeScope();


            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(AutofacAspNetCore3_0)
                //.Where(t => !t.Name.EndsWith("Service") && t.Name != "TestController" && t.Name != "events") ///  如果取消注释 必须放属性注册【PropertiesAutowired】的前面
                .InstancePerLifetimeScope();//每一个依赖或调用创建一个单一的共享的实例

            builder.RegisterAssemblyTypes(AutofacAspNetCore3_0)
                .Where(t => t.Name == "TestController" || t.Name == "events")
                    //InstancePerDependency：默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象；
                    //.AsImplementedInterfaces()//表示注册的类型，以接口的方式注册不包括IDisposable接口
                    //.EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy,使用接口的拦截器，在使用特性 [Attribute] 注册时，注册拦截器可注册到接口(Interface)上或其实现类(Implement)上。使用注册到接口上方式，所有的实现类都能应用到拦截器。
                    //.InstancePerLifetimeScope();//即为每一个依赖或调用创建一个单一的共享的实例
                    //.InstancePerRequest()   //单个 Web/HTTP/API 请求的范围内的组件共享一个实例。仅可用于支持每个请求的依赖关系的整合（如MVC，Web API，Web Forms等）。
                    //.SingleInstance()   //每次都是同一个对象。
                    .PropertiesAutowired(); //在控制器中使用属性依赖注入，其中注入属性必须标注为public

            /// 构造函数注入
            builder.RegisterTypes(AutofacAspNetCore3_0.GetTypes()).Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces(); // 接口形式注册

        }
    }
}
