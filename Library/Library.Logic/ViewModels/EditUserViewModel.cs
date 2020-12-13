using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Library.Logic.ViewModels
{
    public class EditUserViewModel : BaseViewModel, IDataErrorInfo
    {
        public string Error { get; }

        public string this[string columnName] => throw new NotImplementedException();
    }
}
