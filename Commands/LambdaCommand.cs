using AutoRuScrapper.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRuScrapper.Commands
{
    public class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _Canexecute;
        public LambdaCommand(Action<object> Execute, Func<object, bool> Canexecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _Canexecute = Canexecute;
        }

        public override bool CanExecute(object? parameter) => _Canexecute?.Invoke(parameter) ?? true;
        

        public override void Execute(object? parameter) => _Execute(parameter);
        
    }
}
