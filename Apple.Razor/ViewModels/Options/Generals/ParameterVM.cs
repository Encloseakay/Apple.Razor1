using Core.UI.SeedWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UI.Application;

namespace Apple.Razor.ViewModels.Options.Generals
{
    public class ParameterVM : BaseVM
    {
        // 机器列表
        public List<Machine> Machines { get; }
        // 参数字典，键为参数名称，值为参数对象
        public Dictionary<string, IParameter> ParameterDic { get; set; } = new();
        // 参数列表
        public List<IParameter> Parameters { get; } = new();

        // 构造函数，初始化参数视图模型
        public ParameterVM(List<Machine> machines) : base()
        {
            Machines = machines;
            // 从所有机器收集参数
            Machines.ForEach(x => Parameters.AddRange(x.Parameters));
            // 合并所有机器的参数字典
            Machines.ForEach(x =>
            {
                foreach (var item in x.ParameterDic)
                {
                    if (!ParameterDic.ContainsKey(item.Key))
                        ParameterDic.Add(item.Key, item.Value);
                }
            });
        }

        // 根据参数名称获取参数对象
        public IParameter? GetParameter(string key)
        {
            if (!ParameterDic.ContainsKey(key)) return null;
            ParameterDic.TryGetValue(key, out var parameter);
            return parameter;
        }
    }
}
