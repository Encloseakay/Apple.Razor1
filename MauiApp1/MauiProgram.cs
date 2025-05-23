// 引入Apple.Razor辅助类，用于注册自定义组件服务
using Apple.Razor.Helper;
// 引入日志相关的命名空间，用于应用程序日志记录
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    /// <summary>
    /// MAUI应用程序的配置类
    /// 这个类负责配置和初始化整个MAUI应用程序
    /// 包括服务注册、字体配置、开发工具等
    /// </summary>
    public static class MauiProgram
    {
        /// <summary>
        /// 创建MAUI应用程序实例
        /// 这是应用程序的入口点，负责设置和配置所有必要的服务
        /// </summary>
        /// <returns>返回一个完全配置好的MAUI应用程序实例</returns>
        public static MauiApp CreateMauiApp()
        {
            // 创建MAUI应用程序构建器，这是配置应用程序的第一步
            var builder = MauiApp.CreateBuilder();
            builder
                // 指定App类作为应用程序的入口点
                .UseMauiApp<App>()
                // 配置应用程序使用的字体
                .ConfigureFonts(fonts =>
                {
                    // 添加OpenSans字体，这是应用程序的默认字体
                    // 字体文件位于Resources/Fonts目录下
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // 添加MAUI Blazor WebView服务
            // 这个服务允许在MAUI应用中嵌入Blazor Web内容
            builder.Services.AddMauiBlazorWebView();
            // 添加Apple.Razor自定义组件服务
            // 这些服务包含了应用程序特定的组件和功能
            builder.Services.AddAppleRazorComponents();

#if DEBUG
            // 在调试模式下添加开发工具
            // 这些工具可以帮助调试Blazor WebView中的问题
            builder.Services.AddBlazorWebViewDeveloperTools();
            // 添加调试日志功能
            // 这允许在调试时查看详细的日志信息
    		builder.Logging.AddDebug();
#endif

            // 构建并返回配置好的MAUI应用程序实例
            // 这一步会创建所有注册的服务并准备应用程序运行
            return builder.Build();
        }
    }
}
