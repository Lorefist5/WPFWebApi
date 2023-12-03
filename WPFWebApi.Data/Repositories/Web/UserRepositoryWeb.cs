using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WPFWebApi.Data.Model;
using WPFWebApi.Data.Repositories.Interfaces;

namespace WPFWebApi.Data.Repositories.Web;

public class UserRepositoryWeb : GenericRepositoryWeb<User>, IUserRepository
{
    public UserRepositoryWeb(HttpClient httpClient, string apiEndpoint) : base(httpClient, apiEndpoint)
    {
    }
}
