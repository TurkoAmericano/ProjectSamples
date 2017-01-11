using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entities.Interfaces
{
    public interface IViewResolver
    {
        bool Show(string formName);
        bool ShowModal(string formName);
        bool ShowModal(string formName, int id);
    }
}
