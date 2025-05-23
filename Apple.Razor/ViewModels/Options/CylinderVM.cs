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
    // 气缸视图模型类，继承自BaseVM
    public class CylinderVM : BaseVM
    {
        // 当前选中的气缸列表
        public List<ICylinder> Cylinders { get; set; } = new();
        // 按类别分组的气缸字典，键为类别名称，值为该类别下的气缸列表
        public Dictionary<string, List<ICylinder>> CylinderDic { get; }

        // 构造函数，初始化气缸视图模型
        public CylinderVM(List<Machine> machines) : base()
        {
            // 初始化气缸字典
            CylinderDic = new();
            // 创建临时气缸列表
            List<ICylinder> cylinders = new();
            // 从所有机器收集气缸
            machines.ForEach(x => cylinders.AddRange(x.Cylinders));
            // 遍历所有气缸，按类别分组
            foreach (var x in cylinders)
            {
                // 获取气缸类别，如果为空则使用空字符串
                var key = x.Category ?? "";
                // 如果字典中不存在该类别，创建新的类别列表
                if (!CylinderDic.ContainsKey(key))
                    CylinderDic.Add(key, new());
                // 将气缸添加到对应类别的列表中
                CylinderDic[key].Add(x);
            }
        }
    }
}
