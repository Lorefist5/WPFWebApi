using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFWebApi.Data.Repositories.Interfaces;

public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; }

    public void SaveChanges();
}
