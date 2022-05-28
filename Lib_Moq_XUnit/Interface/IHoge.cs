using System;
using System.Collections.Generic;
using System.Text;

namespace Lib_Moq_XUnit.Interface
{
    public interface IHoge
    {
        string Name { get; set; }

        bool DoSomething(string value);

        string DoSomething2(string value);
    }
}
