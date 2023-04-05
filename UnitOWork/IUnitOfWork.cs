using Repositories;

namespace UnitOWork
{
    public  interface IUnitOfWork
    {
        IDriverRepository Driver { get; }
        IVehicleRepository Vehicle { get; }
    }
}
