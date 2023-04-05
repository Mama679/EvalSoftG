using Dapper;
using Entities;
using Microsoft.Data.SqlClient;
using Repositories;
using System;

namespace DataAccess
{
    public class SheduleRepository : Repository<Schedules>, ISheduleRepository
    {
        public SheduleRepository(string connectionStrig) : base(connectionStrig)
        {
        }

        public int AddSchedules(int weeknum, DateTime from, DateTime To, bool Active, int routeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@weeknum", weeknum);
            parameters.Add("@from", from);
            parameters.Add("@to", To);
            parameters.Add("@active", Active);
            parameters.Add("@routeid",routeId);

            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Schedules (Week_Num,Start,Ends,Active,Route_Id) " +
                    "output inserted.Id VALUES (@weeknum,@from,@to,@active,@routeid)";
                return conn.QuerySingle<int>(sql, parameters, commandType: System.Data.CommandType.Text);
            }
        }

        public List<Schedules> GetAllShedules()
        {
            var sql = "Select s.*,r.* " +
                 "      from Schedules s" +
                 "      inner join Routes r on r.Id = s.Route_Id";

            using (var conn = new SqlConnection(_connectionString))
            {
                var schedules = conn.Query<Schedules, Routes, Schedules>(sql, (schedule,route) => {
                    schedule.Route = route;
                    return schedule;
                }, commandType: System.Data.CommandType.Text);

                return schedules.ToList();
            }

        }

        public Schedules GetSheduleById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var sql = "Select s.*,r.* " +
                 "     from Schedules s" +
                 "     inner join Routes r on r.Id = s.Route_Id" +
                 "     where s.Id = @Id";

            using (var conn = new SqlConnection(_connectionString))
            {
                var schedule = conn.Query<Schedules, Routes, Schedules>(sql, (schedule, route) => {
                    schedule.Route = route;
                    return schedule;
                }, commandType: System.Data.CommandType.Text).FirstOrDefault();
                return schedule;
            }
        }

        public bool UpdateShedules(int weeknum, DateTime from, DateTime To, bool Active, int routeId, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@weeknum", weeknum);
            parameters.Add("@from", from);
            parameters.Add("@to", To);
            parameters.Add("@active", Active);
            parameters.Add("@routeid", routeId);
            parameters.Add("@id", id);

            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Schedules " +
                    "      set Week_Num = @weeknum," +
                    "      Start = @from," +
                    "      Ends = @to," +
                    "      Route_Id  = @routeid," + 
                    "      Active = @active " +
                    "      WHERE Id = @id";
                int affectedRows = conn.Execute(sql, parameters, commandType: System.Data.CommandType.Text);
                return (affectedRows > 0 ? true : false);
            }
        }
    }
}
