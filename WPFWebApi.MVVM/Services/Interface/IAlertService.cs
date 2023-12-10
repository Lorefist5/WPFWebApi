using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFWebApi.MVVM.Services.Interface
{
    public interface IAlertService
    {
        void PopUp(string title, string message);
    }
}
