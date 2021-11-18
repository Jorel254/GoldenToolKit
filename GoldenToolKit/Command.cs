using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoldenToolKit
{
    public class Command : ICommand
    {
        Action<object> executeMethod;
        public Command(Action<object> executeMethod)
        {
            this.executeMethod = executeMethod;
           
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }
        public event EventHandler CanExecuteChanged;
    }
}
