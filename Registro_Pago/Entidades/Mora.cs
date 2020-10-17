using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Registro_Pago.DAL;

namespace Registro_Pago.Entidades
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public double Total { get; set; }

        public Moras()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
        }

        [ForeignKey("MoraId")]
        public virtual List<MorasDetalle> Detalle { get; set; } = new List<MorasDetalle>();

    }
}
