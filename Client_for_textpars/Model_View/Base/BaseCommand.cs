using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Client_for_textpars.Model_View.Base
{
    internal abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) { throw new NotImplementedException(); }

        public virtual void Execute(object parameter) { throw new NotImplementedException(); }
    }
}
