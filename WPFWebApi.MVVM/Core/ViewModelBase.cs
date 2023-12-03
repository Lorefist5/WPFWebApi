using WPFWebApi.MVVM.Services.Interface;
using WPFWebApi.MVVM.ViewModel;
using System.Windows.Input;

namespace WPFWebApi.MVVM.Core;

public class ViewModelBase : ObservableObject
{
    public ICommand BackCommand { get; set; }
    
    public ViewModelBase(INavigationService navigationService)
    {
        BackCommand = navigationService.NavigateToCommand<HomeViewModel>();
    }

}
