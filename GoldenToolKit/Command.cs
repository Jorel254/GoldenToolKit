using System;
using System.Collections.Generic;
using System.Reflection;
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
    public class Command<T> : Command
    {
        public Command(Action<T> execute) : base(o =>
            {
                if (IsValidParameter(o))
                {
                    execute((T)o);
                }
            })
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
        }
        private static bool IsValidParameter(object o)
        {
            if (o != null)
            {
                return o is T;
            }
            Type t = typeof(T);
            if (Nullable.GetUnderlyingType(t) != null)
            {
                return true;
            }
            return !t.GetTypeInfo().IsValueType;
        }
    }
}
