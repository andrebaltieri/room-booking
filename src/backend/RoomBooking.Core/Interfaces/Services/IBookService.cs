using System;

namespace RoomBooking.Core.Interfaces.Services
{
    public interface IBookService : IDisposable
    {
        /// <summary>
        /// Orquestra a reserva de uma sala
        /// </summary>
        /// <remarks>
        /// Recupera o usuário
        /// Recupera a sala
        /// Tenta efeturar a reserva
        /// Notifica o usuário
        /// </remarks>
        void PlaceBook(DateTime startDate, DateTime endDate, Guid user, Guid room);
    }
}
