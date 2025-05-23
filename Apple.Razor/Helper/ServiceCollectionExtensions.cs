using Apple.Razor.ViewModels;
using Apple.Razor.ViewModels.Options;
using Apple.Razor.ViewModels.Options.Generals;

using Core.UI.Razor.Helper;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UI.Application;
using UI.Application.ViewModels;

namespace Apple.Razor.Helper
{
    /// <summary>
    /// 服务集合扩展类，用于注册Apple.Razor相关的服务
    /// 这个类提供了依赖注入的扩展方法，用于注册所有必要的服务
    /// 包括视图模型、数据服务、UI组件等
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加Apple.Razor组件相关的服务
        /// 这个方法注册了所有应用程序需要的服务和组件
        /// 包括各种视图模型和核心功能
        /// </summary>
        /// <param name="services">服务集合，用于注册服务</param>
        /// <returns>返回配置后的服务集合，支持链式调用</returns>
        public static IServiceCollection AddAppleRazorComponents(this IServiceCollection services)
        {
            // 注册各种视图模型为作用域服务
            // 作用域服务意味着每个请求都会创建一个新的实例
            services.AddScoped<ChartVM>();        // 图表视图模型，用于数据可视化
            services.AddScoped<HomeVM>();         // 主页视图模型，处理主页面的逻辑
            services.AddScoped<LoginVM>();        // 登录视图模型，处理用户认证
            services.AddScoped<MainVM>();         // 主视图模型，处理主要业务逻辑
            services.AddScoped<MessageVM>();      // 消息视图模型，处理系统消息
            services.AddScoped<OptionsVM>();      // 选项视图模型，处理系统设置
            services.AddScoped<VisionVM>();       // 视觉视图模型，处理视觉相关功能
            services.AddScoped<AxisVM>();         // 轴视图模型，处理运动控制
            services.AddScoped<CylinderVM>();     // 气缸视图模型，处理气缸控制
            services.AddScoped<GeneralVM>();      // 通用视图模型，处理通用功能
            services.AddScoped<InOutVM>();        // 输入输出视图模型，处理IO控制
            services.AddScoped<ParameterVM>();    // 参数视图模型，处理参数配置

            // 注册机器列表为单例服务
            // 单例服务意味着整个应用程序共享同一个实例
            // 这里创建了一个OPC UA类型的机器实例
            services.AddSingleton<List<Machine>>([new(MachineType.OPC_UA_1)]);

            // 添加核心UI Razor组件服务
            // 这些服务提供了基础的UI功能支持
            services.AddCoreUIRazorComponents();

            return services;
        }
    }
}