using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomBooking.Core.Enums;
using RoomBooking.Core.Models;
using System;

namespace RoomBooking.Core.Tests
{
    [TestClass]
    public class Dada_uma_nova_reserva
    {
        private Room _room;
        public Dada_uma_nova_reserva()
        {
            var startTime = new DateTime(1900, 01, 01, 8, 0, 0);
            var endTime = new DateTime(1900, 01, 01, 18, 0, 0);
            _room = new Room(startTime, endTime);
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        public void Deve_retornar_em_aberto_quando_consultado_o_status()
        {
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 10, 0, 0);
            var book = new Book(_room, startTime, endTime);
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

            var book = new Book(_room, startTime, endTime);
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_a_reserva_ultrapasse_duas_horas()
        {            
            // Tenta efetuar uma reserva das 08:00 às 12:00
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);

            var book = new Book(_room, startTime, endTime);
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_a_data_da_reserva_seja_no_passado()
        {
            // Tenta efetuar uma reserva das 08:00 às 12:00
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, 8, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, 10, 0, 0);

            var book = new Book(_room, startTime, endTime);
        }

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_o_horario_da_reserva_seja_posterior_ao_fechamento_da_sala()
        {
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 0, 0);

            var book = new Book(_room, startTime, endTime);
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

            var book = new Book(_room, startTime, endTime);
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

            var book = new Book(_room, startTime, endTime);
        }        

        [TestMethod]
        [TestCategory("Dada uma nova reserva")]
        public void Deve_conseguir_efetuar_uma_reserva()
        {
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 10, 0, 0);

            var book = new Book(_room, startTime, endTime);
        }
    }

    [TestClass]
    public class Ao_confirmar_a_reserva
    {
        [TestMethod]
        [TestCategory("Ao confirmar uma reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_o_dia_da_reserva_seja_um_feriado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Ao confirmar uma reserva")]
        [ExpectedException(typeof(Exception))]
        public void Deve_retornar_erro_caso_ja_haja_uma_reserva_neste_dia_e_horario()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Ao confirmar uma reserva")]
        public void Deve_retornar_erro_caso_o_status_seja_cancelado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Ao confirmar uma reserva")]
        public void Deve_retornar_erro_caso_o_status_seja_confirmado()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Ao confirmar uma reserva")]
        public void Deve_conseguir_confirmar_uma_reserva()
        {
            Assert.Fail();
        }
    }

    [TestClass]
    public class Ao_cancelar_uma_reserva
    {
        [TestMethod]
        [TestCategory("Ao cancelar uma reserva")]
        public void Deve_retornar_erro_ao_tentar_cancelar_apos_o_prazo_limite()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Ao cancelar uma reserva")]
        public void Deve_conseguir_efetuar_o_cancelamento_de_uma_reserva()
        {
            Assert.Fail();
        }
    }

    [TestClass]
    public class Ao_marcar_como_em_andamento
    {
        [TestMethod]
        [TestCategory("Ao marcar como Em Andamento uma reserva")]
        public void Deve_conseguir_marcar_uma_reserva_como_em_andamento()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Ao marcar como Em Andamento uma reserva")]
        public void Deve_marcar_o_status_da_sala_reservada_como_em_uso()
        {
            Assert.Fail();
        }
    }

    [TestClass]
    public class Ao_finalizar_uma_reserva
    {
        [TestMethod]
        [TestCategory("Ao finalizar uma reserva")]
        public void Deve_conseguir_finalizar_uma_reserva()
        {
            Assert.Fail();
        }

        [TestMethod]
        [TestCategory("Ao finalizar uma reserva")]
        public void Deve_gerar_um_log_de_horarios()
        {
            Assert.Fail();
        }
    }
}
