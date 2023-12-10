using WPFWebApi.MVVM.Services.Interface;
using WPFWebApi.WPF.Alert;

namespace WPFWebApi.WPF.Services;

public class AlertService : IAlertService
{
    public void PopUp(string title, string message)
    {
        var customDialog = new PopUp(title, message);
        customDialog.ShowDialog();
    }
}
