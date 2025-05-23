// 引入UI基础功能命名空间
using Core.UI.SeedWork;

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

// 引入UI应用命名空间
using UI.Application;

// 定义选项视图模型命名空间
namespace Apple.Razor.ViewModels.Options
{
    // 轴视图模型类，继承自BaseVM
    public class AxisVM : BaseVM
    {
        // 当前选中的轴，可为空
        public IAxis? Axis { get; set; }
        // 所有轴的列表
        public List<IAxis> Axes { get; }

        // 构造函数，初始化轴视图模型
        public AxisVM(List<Machine> machines) : base()
        {
            // 初始化轴列表
            Axes = new();
            // 从所有机器收集轴
            machines.ForEach(x => Axes.AddRange(x.Axes));
        }
    }
}
