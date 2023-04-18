using Dapper;
using Entities;
using Microsoft.Data.SqlClient;
using Repositories;

namespace DataAccess
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(string connectionStrig) : base(connectionStrig)
        {
        }

        public Users Authenticate(string user, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@user", user);
            parameters.Add("@password", password);
            
            using (var conn = new SqlConnection(_connectionString))
            {
                  return conn.QueryFirstOrDefault<Users>("Select * From Users Where UserLogin = @user And Password = @password",
                       parameters, commandType: System.Data.CommandType.Text);
            }            
        }
    }
}
