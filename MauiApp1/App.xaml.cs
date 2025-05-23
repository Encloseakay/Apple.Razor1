namespace MauiApp1
{
    /// <summary>
    /// 应用程序的主类，继承自Application
    /// 这个类是MAUI应用程序的核心，负责管理应用程序的生命周期
    /// 包括启动、暂停、恢复和终止等状态
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 应用程序构造函数
        /// 在应用程序启动时被调用，负责初始化应用程序的基本设置
        /// </summary>
        public App()
        {
            // 初始化组件
            // 这一步会加载App.xaml中定义的资源和样式
            InitializeComponent();

            // 设置应用程序的主页面
            // MainPage是应用程序启动后显示的第一个页面
            // 这里设置为MainPage实例，它包含了Blazor WebView
            MainPage = new MainPage();
        }
    }
}
