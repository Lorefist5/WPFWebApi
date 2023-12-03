using WPFWebApi.Data.Model;
using WPFWebApi.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFWebApi.Data.Repositories.ORM;

public class UserRepositoryORM : GenericRepositoryORM<User>, IUserRepository
{
    public UserRepositoryORM(ApplicationDbContext db) : base(db)
    {
    }
}
