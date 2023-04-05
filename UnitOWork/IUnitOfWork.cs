using Repositories;

namespace UnitOWork
{
    public  interface IUnitOfWork
    {
        IDriverRepository Driver { get; }
        IVehicleRepository Vehicle { get; }
        IRouteRepository Route { get; }
        ISheduleRepository Shedule { get; }
        IUserRepository User { get; }
    }
}
