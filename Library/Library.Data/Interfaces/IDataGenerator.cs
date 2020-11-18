using System;
using System.Collections.Generic;
using System.Text;
using Library.Data.Models;

namespace Library.Data.Interfaces
{
    public interface IDataGenerator
    {
        DataContext GenerateData();
    }
}
