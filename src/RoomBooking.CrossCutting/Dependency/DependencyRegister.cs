using Microsoft.Practices.Unity;
using RoomBooking.ApplicationService.Account.Handlers;
using RoomBooking.ApplicationService.Account.Services.UserServices;
using RoomBooking.CrossCutting.Events;
using RoomBooking.Domain.Account.Events.UserEvents;
using RoomBooking.Domain.Account.Handlers.Contracts;
using RoomBooking.Domain.Account.Repositories;
using RoomBooking.Domain.Account.Services;
using RoomBooking.Infrastructure.ORM.Contexts;
using RoomBooking.Infrastructure.Repositories.Account;
using RoomBooking.Infrastructure.Transaction;
using RoomBooking.SharedKernel.Events;
using RoomBooking.SharedKernel.Helpers.Contracts;
using RoomBooking.SharedKernel.Repositories.Contracts;

namespace RoomBooking.CrossCutting.Dependency
{
    public static class DependencyRegister
    {
        /// <summary>
        /// TransientLifetimeManager - Cada Resolve gera uma nova instância.
        /// ContainerControlledLifetimeManager - Utiliza Singleton
        /// </summary>
        /// <param name="container"></param>
        public static void Register(UnityContainer container)
        {
            container.RegisterType<RoomBookingDataContext, RoomBookingDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserApplicationService, UserApplicationService>(new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
            container.RegisterType<IHandler<UserRegistered>, UserRegisteredHandler>();
        }
    }
}
