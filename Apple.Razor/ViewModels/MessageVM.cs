using Apple.Razor.Views;

using Core;
using Core.UI.SeedWork;

using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UI.Application;

namespace Apple.Razor.ViewModels
{
    // 消息视图模型类，继承自BaseVM
    public class MessageVM : BaseVM
    {
        // 存储机器及其消息索引的字典
        private Dictionary<IMachine, int> _machineDic = new();
        // 机器列表
        public List<Machine> Machines { get; }
        // 所有消息列表
        public List<IMessage> Messages { get; set; } = new();
        // 当前显示的消息列表
        public List<IMessage> MessagesNow { get; set; } = new();
        // 历史消息列表
        public List<IMessage> MessageHistory { get; set; } = new();
        // UI状态更新回调
        public Action? StateHasChanged { get; set; }

        // 构造函数：初始化消息视图模型
        public MessageVM(List<Machine> machines) : base()
        {
            Machines = machines;
            // 初始化每个机器的消息
            foreach (var machine in Machines)
            {
                _machineDic.Add(machine, 0);
                Messages.AddRange(machine.Messages);
                machine.SyncVariabled += MessageVM_SyncVariabled;
            }
            // 订阅消息选中状态变化事件
            Messages.ForEach(x => x.IsCheckedChanged += Messages_IsCheckedChanged);
        }

        // 处理机器变量同步事件
        private void MessageVM_SyncVariabled(object? sender, bool e)
        {
            if (sender is not IMachine machine || !_machineDic.ContainsKey(machine)) return;
            // 将消息按100条分组
            var temp = machine.Messages.SplitArray(100);
            var index = _machineDic[machine] >= temp.Count ? 0 : _machineDic[machine];
            // 处理每组消息
            for (var i = 0; i < temp.Count; i++)
            {
                var messages = temp[i].ToList();
                if (i == index)
                    messages.ForEach(x => x.LoadCommand?.Execute(null));
                else
                    messages.ForEach(x => x.UnloadCommand?.Execute(null));
            }
            _machineDic[machine] = index + 1;
        }

        // 处理消息选中状态变化事件
        private void Messages_IsCheckedChanged(object? sender, IMessage e)
        {
            // 如果历史消息超过100条，清空历史
            if (MessageHistory.Count > 100) MessageHistory.Clear();
            if (e.Text is null || e.DateTime is null) return;
            if (e.IsChecked)
            {
                // 添加到当前显示列表
                MessagesNow.Add(e);
            }
            else
            {
                // 从当前显示列表移除，添加到历史列表
                MessagesNow.Remove(e);
                MessageHistory.Add(e);
            }
            // 通知UI更新
            StateHasChanged?.Invoke();
        }

        // 重写Dispose方法，清理事件订阅
        public override void Dispose()
        {
            Machines.ForEach(x => x.SyncVariabled -= MessageVM_SyncVariabled);
            Messages.ForEach(x => x.IsCheckedChanged -= Messages_IsCheckedChanged);
        }
    }
}
