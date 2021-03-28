using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Models
{
    public class Reserva
    {

        public int Id { get; set; }
        public DateTime DataReserva { get; set; }


        public Reserva()
        {

        }

        public bool ReservaExiste()
        {
            return true;
        }

        public bool EfetuarReserva()
        {
            return true;
        }


    }
}
