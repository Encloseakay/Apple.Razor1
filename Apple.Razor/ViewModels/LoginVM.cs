// 引入Blazor组件命名空间
using Microsoft.AspNetCore.Components;

// 引入系统基础命名空间
using System;
// 引入集合相关的命名空间
using System.Collections.Generic;
// 引入LINQ查询相关的命名空间
using System.Linq;
// 引入文本处理相关的命名空间
using System.Text;
// 引入异步编程相关的命名空间
using System.Threading.Tasks;

// 定义视图模型命名空间
namespace Apple.Razor.ViewModels
{
    // 登录视图模型类，继承自BaseVM
    public class LoginVM : BaseVM
    {
        // 登录事件，用于通知登录状态变化
        public event EventHandler? LoginHandler;
        // 密码属性，用于存储用户输入的密码
        public string? Password { get; set; }
        // 登录状态属性，表示用户是否已登录
        public bool IsLogin { get; private set; }
        // 管理员状态属性，表示用户是否为管理员
        public bool IsAdmin { get; private set; }
        // 操作员状态属性，表示用户是否为操作员
        public bool IsOp { get; private set; }

        // 构造函数，初始化登录视图模型
        public LoginVM() : base()
        {
        }

        // 操作员登录方法
        public void LoginOp()
        {
            // 设置非管理员状态
            IsAdmin = false;
            // 检查密码是否为"111"，设置操作员状态
            IsOp = Password == "111";
            // 设置登录状态
            IsLogin = IsOp;
            // 清空密码
            Password = "";
            // 触发登录事件
            LoginHandler?.Invoke(this, EventArgs.Empty);
        }

        // 管理员登录方法
        public void LoginAdmin()
        {
            // 设置非操作员状态
            IsOp = false;
            // 检查密码是否为"333"，设置管理员状态
            IsAdmin = Password == "333";
            // 设置登录状态
            IsLogin = IsAdmin;
            // 清空密码
            Password = "";
            // 触发登录事件
            LoginHandler?.Invoke(this, EventArgs.Empty);
        }

        // 重写Dispose方法，清理资源
        public override void Dispose()
        {
            // 调用基类的Dispose方法
            base.Dispose();
        }
    }
}
