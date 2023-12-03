using WPFWebApi.Data.Model;
using WPFWebApi.Data.Repositories.Interfaces;
using WPFWebApi.MVVM.Core;
using WPFWebApi.MVVM.Services.Interface;
using WPFWebApi.MVVM.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFWebApi.MVVM.ViewModel;

public class DeleteUserViewModel : UserViewModelBase
{

    public ICommand DeleteUser { get; private set; }
    public DeleteUserViewModel(INavigationService navigationService, IUnitOfWork unitOfWork, User user) : base(navigationService)
    {
        User = user;
        BackCommand = navigationService.NavigateToCommand<UsersViewModel>();

        DeleteUser = new RelayCommand(async o =>
        {
            await unitOfWork.UserRepository.Delete(_user);

            navigationService.NavigateTo<UsersViewModel>();
        }, o => true);
    }
}
