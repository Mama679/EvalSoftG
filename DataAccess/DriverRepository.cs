using Dapper;
using Entities;
using Microsoft.Data.SqlClient;
using Repositories;
using System;

namespace DataAccess
{
    public class DriverRepository : Repository<Drivers>, IDriverRepository
    {
        public DriverRepository(string connectionStrig) : base(connectionStrig)
        {
        }

        public bool delDriver(int id, bool active)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@active", active);
            parameters.Add("@id", id);

            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Drivers " +
                    "      set Active = @active " +
                    "      WHERE Id = @id";
                int affectedRows = conn.Execute(sql, parameters, commandType: System.Data.CommandType.Text);
                return (affectedRows > 0 ? true : false);
            }
        }
    }
}
