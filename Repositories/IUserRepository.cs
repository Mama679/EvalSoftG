using Entities;

namespace Repositories
{
    public interface IUserRepository:IRepository<Users>
    {
        Users Authenticate(string user, string password);
    }
}
