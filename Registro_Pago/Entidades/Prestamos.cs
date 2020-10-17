using System;
using System.ComponentModel.DataAnnotations;

namespace Registro_Pago.Entidades
{

    public class Prestamos
    {

        [Key]
        public int PrestamosId { get; set; }

        public DateTime Fecha { get; set; }
        public int PersonaId { get; set; }
        public string Conceptos { get; set; }
        public float Monto { get; set; }
        public float Balance { get; set; }


    }

}