using WPFWebApi.Data.Model;
using WPFWebApi.Data.Repositories.Interfaces;
using WPFWebApi.MVVM.Core;
using WPFWebApi.MVVM.Services.Interface;
using WPFWebApi.MVVM.ViewModel.Base;
using System.Windows.Input;

namespace WPFWebApi.MVVM.ViewModel;

public class CreateUserViewModel : UserViewModelBase
{


    public ICommand CreateUser { get; private set; }
    public CreateUserViewModel(INavigationService navigationService, IUnitOfWork unitOfWork, IAlertService alertService) : base(navigationService)
    {
        BackCommand = navigationService.NavigateToCommand<UsersViewModel>();
        CreateUser = new RelayCommand(async o =>
        {
            await unitOfWork.UserRepository.Add(this._user);
            unitOfWork.SaveChanges();
            navigationService.NavigateTo<UsersViewModel>();
            alertService.PopUp("Created", $"{_user.Name} was created successfully!");
        }, o =>
        {
            return !string.IsNullOrEmpty(User.Email) && !string.IsNullOrEmpty(User.Name) && !string.IsNullOrEmpty(User.Password);
        }, this);
    }

    
}
