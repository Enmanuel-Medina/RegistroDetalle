using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Registro_Pago.Entidades
{
    public class MorasDetalle
    {
        private object moraId;
        private int v1;
        private DateTime displayDate;
        private float v2;

        [Key]

        public int Id { get; set; }
        public int MoraId { get; set; }
        public int PrestamosId { get; set; }
        public double Valor { get; set; }
        public DateTime FEcha { get; set; }

        public MorasDetalle()
        {
            Id = 0;
            MoraId = 0;
            PrestamosId = 0;
            FEcha = DateTime.Now;
            Valor = 0;
        }

        public MorasDetalle(int Id, int MoraId, int PrestamosId, DateTime FEcha, float Valor)
        {
            Id = 0;
            MoraId = MoraId;
            PrestamosId = PrestamosId;
            FEcha = FEcha;
            Valor = Valor;

        }

        public MorasDetalle(object moraId, int v1, DateTime displayDate, float v2)
        {
            this.moraId = moraId;
            this.v1 = v1;
            this.displayDate = displayDate;
            this.v2 = v2;
        }
    }
}
