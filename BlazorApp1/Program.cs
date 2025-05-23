using BlazorApp1.Components;
using Apple.Razor.Helper;

namespace BlazorApp1
{
    /// <summary>
    /// 应用程序的主程序类
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 应用程序的入口点
        /// </summary>
        /// <param name="args">命令行参数</param>
        public static void Main(string[] args)
        {
            // 创建Web应用程序构建器
            var builder = WebApplication.CreateBuilder(args);

            // 配置服务容器
            // 添加Razor组件服务
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            // 添加Apple.Razor自定义组件服务
            builder.Services.AddAppleRazorComponents();
            
            // 构建应用程序
            var app = builder.Build();

            // 配置HTTP请求管道
            if (!app.Environment.IsDevelopment())
            {
                // 在生产环境中使用异常处理中间件
                app.UseExceptionHandler("/Error");
                // 启用HSTS（HTTP严格传输安全）
                // 默认HSTS值为30天，可以根据生产环境需求调整
                app.UseHsts();
            }

            // 启用HTTPS重定向
            app.UseHttpsRedirection();

            // 启用静态文件服务
            app.UseStaticFiles();
            // 启用防伪造令牌验证
            app.UseAntiforgery();

            // 配置Razor组件路由
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            // 启动应用程序
            app.Run();
        }
    }
}
