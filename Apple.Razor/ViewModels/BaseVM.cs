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
    // 视图模型基类，实现IDisposable接口用于资源清理
    public class BaseVM : IDisposable
    {
        // 标记是否已释放资源的属性
        public bool IsDisposed { get; private set; } = false;

        // 实现IDisposable接口的Dispose方法，用于释放资源
        public virtual void Dispose()
        {
            // 设置资源已释放标记
            IsDisposed = true;
        }
    }
}
