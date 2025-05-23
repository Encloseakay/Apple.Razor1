using Apple.Razor.ViewModels.Options;
using Apple.Razor.ViewModels.Options.Generals;
using Apple.Razor.Views;
using Apple.Razor.Views.Options;

using Core.UI.ViewSwitch;

using Microsoft.AspNetCore.Components;

using UI.Application;

using ParameterView = Apple.Razor.Views.Options.Generals.ParameterView;

namespace Apple.Razor.ViewModels
{
    public class MainVM : BaseVM
    {
        private LoginVM _loginVM;

        public event EventHandler? Cycle1sHandler;
        public List<Machine> Machines { get; }
        public ViewSwitch<RenderFragment> MainViewSwitch { get; } = new();
        public ViewSwitch<RenderFragment> OptionViewSwitch { get; } = new();
        public ViewSwitch<RenderFragment> GeneralViewSwitch { get; } = new();
        public bool Connected => Machines.All(m => m.Connected);

        public MainVM(List<Machine> machines, LoginVM loginVM)
        {
            _loginVM = loginVM;
            Machines = machines;
            AddView<ChartView>(MainViewSwitch);
            AddView<HomeView>(MainViewSwitch);
            AddView<LoginView>(MainViewSwitch);
            AddView<MessageView>(MainViewSwitch);
            AddView<OptionsView>(MainViewSwitch);
            AddView<VisionView>(MainViewSwitch);
            MainViewSwitch.SwithNowView(nameof(HomeView));
            MainViewSwitch.NowViewChanged += MainViewSwitch_NowViewChanged;

            AddView<AxisView>(OptionViewSwitch);
            AddView<CylinderView>(OptionViewSwitch);
            AddView<GeneralView>(OptionViewSwitch);
            AddView<InOutView>(OptionViewSwitch);
            OptionViewSwitch.SwithNowView(nameof(InOutView));

            AddView<ParameterView>(GeneralViewSwitch);
            GeneralViewSwitch.SwithNowView(nameof(ParameterView));
            Task.Run(Run);
        }
        private void MainViewSwitch_NowViewChanged(object? sender, ViewItem<RenderFragment> e)
        {
            if (MainViewSwitch.NowViewKey != nameof(LoginView)) _loginVM.LoginHandler -= LoginVM_LoginHandler;
            if (MainViewSwitch.NowViewKey != nameof(OptionsView) || _loginVM.IsLogin) return;
            _loginVM.LoginHandler += LoginVM_LoginHandler;
            MainViewSwitch.SwithNowView(nameof(LoginView));
        }
        private void LoginVM_LoginHandler(object? sender, EventArgs e)
        {
            if (!_loginVM.IsLogin) return;
            MainViewSwitch.SwithNowView(nameof(OptionsView));
        }
        public override void Dispose()
        {
            MainViewSwitch.NowViewChanged -= MainViewSwitch_NowViewChanged;
            _loginVM.LoginHandler -= LoginVM_LoginHandler;
            base.Dispose();
        }

        private void Run()
        {
            while (!IsDisposed)
            {
                Thread.Sleep(1000);
                try
                {
                    Cycle1sHandler?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception) { }
            }
        }
        private void AddView<T>(ViewSwitch<RenderFragment> viewSwitch) where T : ComponentBase
        {
            viewSwitch.Add(typeof(T).Name, builder =>
            {
                builder.OpenComponent(0, typeof(T));
                builder.CloseComponent();
            });
        }
    }
}
