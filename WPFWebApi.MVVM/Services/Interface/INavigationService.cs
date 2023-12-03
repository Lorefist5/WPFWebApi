using WPFWebApi.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFWebApi.MVVM.Services.Interface;

public interface INavigationService
{
    ViewModelBase CurrentViewModel { get; }
    public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
    public void Navigate(ViewModelBase viewModel);
    public ICommand NavigateToCommand<TViewModel>() where TViewModel : ViewModelBase;
    public ICommand NavigateCommand(ViewModelBase viewModel);
}
