using Microsoft.Practices.Unity;
using RoomBooking.Business.Services;
using RoomBooking.Core.Interfaces.Repositories;
using RoomBooking.Core.Interfaces.Services;
using RoomBooking.Infraestructure.Data.DataContexts;
using RoomBooking.Infraestructure.Repositories;

namespace RoomBooking.Common
{
    public static class DependencyInjectionHelper
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<RoomBookingDataContext, RoomBookingDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
        }
    }
}
