using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomBooking.Core.Enums;
using RoomBooking.Core.Models;
using System;
using System.Collections.Generic;

namespace RoomBooking.Core.Tests
{
    [TestClass]
    public class Dada_uma_nova_reserva
    {
        private Room _room;
        private User _user;
        public Dada_uma_nova_reserva()
        {
            var startTime = new DateTime(1900, 01, 01, 8, 0, 0);
            var endTime = new DateTime(1900, 01, 01, 18, 0, 0);
            _room = new Room(startTime, endTime);
            _user = new User("André Baltieri", "andrebaltieri@hotmail.com");
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        public void Deve_retornar_em_aberto_quando_consultado_o_status()
        {
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 10, 0, 0);
            var book = new Book(_room, startTime, endTime, _user);
            Assert.AreEqual(EBookStatus.InProgress, book.Status);
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_o_horario_da_reserva_seja_anterior_a_abertura_da_sala()
        {
            // A sala abre as 08:00
            // Tenta efetuar uma reserva das 06:00 às 09:00
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);

            var book = new Book(_room, startTime, endTime, _user);
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_a_reserva_ultrapasse_duas_horas()
        {
            // Tenta efetuar uma reserva das 08:00 às 12:00
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            var book = new Book(_room, startTime, endTime, _user);
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_a_data_da_reserva_seja_no_passado()
        {
            // Tenta efetuar uma reserva das 08:00 às 12:00
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, 8, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, 10, 0, 0);

            var book = new Book(_room, startTime, endTime, _user);
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_o_horario_da_reserva_seja_posterior_ao_fechamento_da_sala()
        {
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 0, 0);

            var book = new Book(_room, startTime, endTime, _user);
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_o_dia_da_reserva_seja_um_sabado()
        {
            DateTime weekend = DateTime.Now;
            while (weekend.DayOfWeek != DayOfWeek.Saturday)
                weekend = weekend.AddDays(1);

            var startTime = new DateTime(weekend.Year, weekend.Month, weekend.Day, 10, 0, 0);
            var endTime = new DateTime(weekend.Year, weekend.Month, weekend.Day, 12, 0, 0);

            var book = new Book(_room, startTime, endTime, _user);
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_o_dia_da_reserva_seja_um_domingo()
        {
            DateTime weekend = DateTime.Now;
            while (weekend.DayOfWeek != DayOfWeek.Sunday)
                weekend = weekend.AddDays(1);

            var startTime = new DateTime(weekend.Year, weekend.Month, weekend.Day, 10, 0, 0);
            var endTime = new DateTime(weekend.Year, weekend.Month, weekend.Day, 12, 0, 0);

            var book = new Book(_room, startTime, endTime, _user);
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        public void Deve_conseguir_efetuar_uma_reserva()
        {
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 10, 0, 0);

            var book = new Book(_room, startTime, endTime, _user);
        }
    }

    [TestClass]
    public class Ao_confirmar_a_reserva
    {
        private Book _book;
        private User _user;
        private IList<DateTime> _holidays;
        private IList<DateTime> _books;

        public Ao_confirmar_a_reserva()
        {
            var roomStartTime = new DateTime(1900, 01, 01, 8, 0, 0);
            var roomEndTime = new DateTime(1900, 01, 01, 18, 0, 0);

            var bookStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0);
            var bookEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 10, 0, 0);

            var room = new Room(roomStartTime, roomEndTime);
            _user = new User("André Baltieri", "andrebaltieri@hotmail.com");
            _book = new Book(room, bookStartTime, bookEndTime, _user);

            _holidays = new List<DateTime>
            {
                DateTime.Now.AddDays(2)
            };

            _books = new List<DateTime>
            {
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(2).Day, 8, 0, 0)
            };
        }

        [TestMethod]
        [TestCategory("Ao confirmar uma reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_o_dia_da_reserva_seja_um_feriado()
        {
            // Adiciona hoje como feriado
            var holidays = new List<DateTime>
            {
                DateTime.Now.AddDays(1)
            };

            _book.Confirm(holidays, null);
        }

        [TestMethod]
        [TestCategory("Ao confirmar uma reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_ja_haja_uma_reserva_neste_dia_e_horario()
        {
            // Adiciona hoje como feriado
            var books = new List<DateTime>
            {
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0)
            };

            _book.Confirm(null, books);
        }

        [TestMethod]
        [TestCategory("Ao confirmar uma reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_o_status_seja_cancelado()
        {
            _book.Cancel();
            _book.Confirm(_holidays, _books);
        }

        [TestMethod]
        [TestCategory("Ao confirmar uma reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_o_status_seja_confirmado()
        {
            _book.Confirm(_holidays, _books);
            _book.Confirm(_holidays, _books);
        }

        [TestMethod]
        [TestCategory("Ao confirmar uma reserva")]
        public void Deve_conseguir_confirmar_uma_reserva()
        {
            _book.Confirm(_holidays, _books);
        }
    }

    [TestClass]
    public class Ao_cancelar_uma_reserva
    {
        private Book _book;
        private Room _room;
        private User _user;

        public Ao_cancelar_uma_reserva()
        {
            var roomStartTime = new DateTime(1900, 01, 01, 8, 0, 0);
            var roomEndTime = new DateTime(1900, 01, 01, 18, 0, 0);

            var bookStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0);
            var bookEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 10, 0, 0);

            _room = new Room(roomStartTime, roomEndTime);
            _user = new User("André Baltieri", "andrebaltieri@hotmail.com");
            _book = new Book(_room, bookStartTime, bookEndTime, _user);
        }

        [TestMethod]
        [TestCategory("Ao cancelar uma reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_ao_tentar_cancelar_apos_o_prazo_limite()
        {
            var bookStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(1).Hour, 0, 0);
            var bookEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(3).Hour, 0, 0);
            
            var book = new Book(_room, bookStartTime, bookEndTime, _user);
            book.Cancel();
        }

        [TestMethod]
        [TestCategory("Ao cancelar uma reserva")]
        public void Deve_conseguir_efetuar_o_cancelamento_de_uma_reserva()
        {
            _book.Cancel();
        }
    }

    [TestClass]
    public class Ao_marcar_como_em_andamento
    {
        private Book _book;
        private Room _room;
        private User _user;

        public Ao_marcar_como_em_andamento()
        {
            var roomStartTime = new DateTime(1900, 01, 01, 8, 0, 0);
            var roomEndTime = new DateTime(1900, 01, 01, 18, 0, 0);

            var bookStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0);
            var bookEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 10, 0, 0);

            _room = new Room(roomStartTime, roomEndTime);
            _user = new User("André Baltieri", "andrebaltieri@hotmail.com");
            _book = new Book(_room, bookStartTime, bookEndTime, _user);
        }

        [TestMethod]
        [TestCategory("Ao marcar como Em Andamento uma reserva")]
        public void Deve_conseguir_marcar_uma_reserva_como_em_andamento()
        {
            _book.MarkAsInProgress();
        }

        [TestMethod]
        [TestCategory("Ao marcar como Em Andamento uma reserva")]
        public void Deve_marcar_o_status_da_sala_reservada_como_em_uso()
        {
            _book.MarkAsInProgress();
            Assert.AreEqual(ERoomStatus.InUse, _book.Room.Status);
        }
    }

    [TestClass]
    public class Ao_finalizar_uma_reserva
    {
        private Book _book;
        private Room _room;
        private User _user;

        public Ao_finalizar_uma_reserva()
        {
            var roomStartTime = new DateTime(1900, 01, 01, 8, 0, 0);
            var roomEndTime = new DateTime(1900, 01, 01, 18, 0, 0);

            var bookStartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0);
            var bookEndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 10, 0, 0);

            _room = new Room(roomStartTime, roomEndTime);
            _user = new User("André Baltieri", "andrebaltieri@hotmail.com");
            _book = new Book(_room, bookStartTime, bookEndTime, _user);
        }

        [TestMethod]
        [TestCategory("Ao finalizar uma reserva")]
        public void Deve_conseguir_finalizar_uma_reserva()
        {
            _book.MarkAsCompleted();
        }
    }
}
