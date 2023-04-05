using Azure;
using Dapper;
using Dapper.Contrib.Extensions;
using Entities;
using Microsoft.Data.SqlClient;
using Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess
{
    public class RouteRepository : Repository<Routes>, IRouteRepository
    {
        public RouteRepository(string connectionStrig) : base(connectionStrig)
        {
        }

        public int AddRoute(string description, int driverId, int vehicleId, bool active)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@description", description);
            parameters.Add("@driver", driverId);
            parameters.Add("@vehicle", vehicleId);
            parameters.Add("@active", active);

            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Routes (Description,Driver_Id,Vehicle_Id,Active) " +
                    "output inserted.Id VALUES (@description,@driver,@vehicle,@active)";
                return conn.QuerySingle<int>(sql,parameters,commandType:System.Data.CommandType.Text);
            }
        }

        public List<Routes> GetAllRoutes()
        {
            var sql = "Select r.*,d.*,v.* " +
                "      from Routes r" +
                "      inner join Drivers d on d.Id = r.Driver_Id" +
                "      inner join Vehicles v on v.Id = r.Vehicle_Id";

            using (var conn = new SqlConnection(_connectionString))
            {
                 var routes = conn.Query<Routes, Drivers, Vehicles,Routes>(sql, (route,driver,vehicle) => {
                     route.Drive = driver;
                     route.Vehicle = vehicle;
                     return route;
                 },  commandType:System.Data.CommandType.Text);


                return routes.ToList();
                
            }
        }

        public Routes GetRouteById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var sql = "Select r.*,d.*,v.* " +
                "      from Routes r" +
                "      inner join Drivers d on d.Id = r.Driver_Id" +
                "      inner join Vehicles v on v.Id = r.Vehicle_Id" +
                "      Where r.Id = @Id";

            using (var conn = new SqlConnection(_connectionString))
            {
                var route = conn.Query<Routes, Drivers, Vehicles, Routes>(sql, (route, driver, vehicle) => {
                    route.Drive = driver;
                    route.Vehicle = vehicle;
                    return route;
                }, parameters, commandType: System.Data.CommandType.Text).FirstOrDefault();

                return route;
            }
        }

        public bool UpdateRoute(string description, int driverId, int vehicleId, bool active, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@description", description);
            parameters.Add("@driver", driverId);
            parameters.Add("@vehicle", vehicleId);
            parameters.Add("@active", active);
            parameters.Add("@id", id);

            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Routes " +
                    "      set Description = @description," +
                    "      Driver_Id = @driver," +
                    "      Vehicle_Id = @vehicle," +
                    "      Active = @active " +
                    "      WHERE Id = @id";
                int affectedRows = conn.Execute(sql, parameters,commandType:System.Data.CommandType.Text);
                return (affectedRows > 0 ? true : false);
            }
        }
    }
}
