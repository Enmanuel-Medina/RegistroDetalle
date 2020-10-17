using System;
using System.ComponentModel.DataAnnotations;

namespace Registro_Pago.Entidades
{
    public class Personas
    {
        [Key]


        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public float Balance { get; set; }
    }
}