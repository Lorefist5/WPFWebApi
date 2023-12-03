using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WPFWebApi.Data;
using WPFWebApi.Data.Model;
using WPFWebApi.Data.Repositories.Interfaces;
using WPFWebApi.MVVM.Core;
using WPFWebApi.MVVM.Services;
using WPFWebApi.MVVM.Services.Interface;
using WPFWebApi.MVVM.ViewModel;
using WPFWebApi.WPF.Services;
using System.Windows;
using System.Net.Http;
using WPFWebApi.Data.Repositories.ORM;
using WPFWebApi.Data.Repositories.Web;

namespace WPFWebApi.WPF;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;
    public App()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddScoped(provider => new MainWindow()
        {
            DataContext = provider.GetRequiredService<MainViewModel>()
        });


        services.AddSingleton<MainViewModel>();
        services.AddSingleton<HomeViewModel>();
        services.AddTransient<UsersViewModel>(); // We use Transient so that it fetches the users again
        services.AddTransient<CreateUserViewModel>(); // We use Transient so that it clears the input fields
        services.AddTransient<DeleteUserViewModel>();
        
        //Services

        //File system
        services.AddSingleton<IFileSystem, DesktopFileSystem>();
        //Server 
        services.AddSingleton(prov =>
        {
            HttpClient http = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7080")
            };
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return http;
        });
        //EF core
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data source=WPFWebApiDatabase.db"));
        services.AddTransient<IUserRepository, UserRepositoryWeb>(provider =>
        {
            var client = provider.GetRequiredService<HttpClient>();
            UserRepositoryWeb userRepositoryWeb = new UserRepositoryWeb(client, client.BaseAddress.ToString());
            return userRepositoryWeb;
        });

        services.AddTransient<IUnitOfWork, UnitOfWorkORM>();

        //Navigation
        services.AddSingleton<INavigationService, NavigationService>(provider =>
        {
            var navigationService = new NavigationService(provider.GetRequiredService<Func<Type, ViewModelBase>>());
            return navigationService;
        });

        services.AddSingleton<Func<Type, ViewModelBase>>(provider =>
            request => (ViewModelBase)provider.GetRequiredService(request));


        //Models
        services.AddScoped<User>();

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        _serviceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
        mainWindow.Show();
        base.OnStartup(e);
    }
}
