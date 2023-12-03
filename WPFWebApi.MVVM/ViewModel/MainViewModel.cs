using WPFWebApi.MVVM.Core;
using WPFWebApi.MVVM.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFWebApi.MVVM.ViewModel;

public class MainViewModel : ViewModelBase
{
    private INavigationService _navigationService = default!;
    public INavigationService Navigation
    {
        get { return _navigationService; }
        set
        {
            _navigationService = value;
            OnPropertyChanged();
        }
    }

    public ICommand NavigateToUsers { get; private set; }
    public MainViewModel(INavigationService navigationService) : base(navigationService)
    {
        Navigation = navigationService;

        Navigation.NavigateTo<HomeViewModel>();


        NavigateToUsers = navigationService.NavigateToCommand<UsersViewModel>();




    }
}
