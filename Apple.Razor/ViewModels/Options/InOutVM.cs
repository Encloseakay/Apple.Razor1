using Core;
using Core.UI.SeedWork;

using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UI.Application;

namespace Apple.Razor.ViewModels.Options
{
    public class InOutVM : BaseVM
    {
        private int _indexIn = 0;
        private int _indexOut = 0;
        public int Index
        {
            get => IsInput ? _indexIn : _indexOut;
            set
            {
                Action<int> action = IsInput ? x => _indexIn = x : x => _indexOut = x;
                var inOuts = IsInput ? Inputs : Outputs;
                action(Math.Clamp(value, 0, inOuts.Count - 1));
            }
        }
        public bool IsInput { get; set; } = true;
        public List<IInOut[]> Inputs { get; }
        public List<IInOut[]> Outputs { get; }
        public IInOut[] InOuts => IsInput ? Inputs[Index] : Outputs[Index];
        public InOutVM(List<Machine> machines) : base()
        {
            List<IInOut> inputs = new();
            List<IInOut> outputs = new();
            machines.ForEach(x => inputs.AddRange(x.Inputs));
            machines.ForEach(x => outputs.AddRange(x.Outputs));
            Inputs = inputs.SplitArray(32);
            Outputs = outputs.SplitArray(32);
        }
    }
}
