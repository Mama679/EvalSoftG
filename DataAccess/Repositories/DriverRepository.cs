using DataAccess.DbContext;
using Entities;

namespace DataAccess.Repositories
{
    public class DriverRepository : Repository<Driver>, IDriverRepository
    {
        private readonly TravelContext _db;
        public DriverRepository(TravelContext db) : base(db)
        {
            _db = db;   
        }

        public void Update(Driver driver)
        {
            var objDriver = _db.Drivers.FirstOrDefault(x=> x.Id == driver.Id);
            if (objDriver != null)
            {
                objDriver.First_Name = driver.First_Name;
                objDriver.Last_Name = driver.Last_Name;
                objDriver.Ssn = driver.Ssn; 
                objDriver.Phone = driver.Phone;
                objDriver.DoB = driver.DoB;
                objDriver.Address = driver.Address; 
                objDriver.City = driver.City;
                objDriver.Zip = driver.Zip;
            }       
        }
    }
}
