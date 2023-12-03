using WPFWebApi.MVVM.Core;
using WPFWebApi.MVVM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFWebApi.MVVM.ViewModel;

public class HomeViewModel : ViewModelBase
{
    public ICommand NavigateToUsers { get; private set; }

    public HomeViewModel(INavigationService navigationService): base(navigationService)
    {
        NavigateToUsers = navigationService.NavigateToCommand<UsersViewModel>();
    }
}
