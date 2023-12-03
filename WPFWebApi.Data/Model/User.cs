using WPFWebApi.Data.Model.Base;
using WPFWebApi.Data.Repositories.Interfaces;

namespace WPFWebApi.Data.Model;

public class User : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;


}
