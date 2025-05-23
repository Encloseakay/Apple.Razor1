namespace MauiApp1
{
    /// <summary>
    /// 应用程序的主页面类，继承自ContentPage
    /// 这个类定义了应用程序的主界面，包含了一个Blazor WebView
    /// 用于显示Blazor组件和内容
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// 主页面构造函数
        /// 在页面创建时被调用，负责初始化页面的基本设置
        /// </summary>
        public MainPage()
        {
            // 初始化组件
            // 这一步会加载MainPage.xaml中定义的UI元素和布局
            // 包括Blazor WebView及其配置
            InitializeComponent();
        }
    }
}
