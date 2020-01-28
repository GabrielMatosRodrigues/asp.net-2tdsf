using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _07_Fiap.Web.AspNet.Models
{
    public class Presidiario
    {
        public int PresidiarioId { get; set; }

        [Required, StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataEntrada { get; set; }

        public DateTime DataSaida { get; set; }

        public NivelEscolaridade NivelEscolaridade { get; set; }

        public bool SaidaTemporaria { get; set; }

        public Cela Cela { get; set; }

        [Required]
        public int CelaId { get; set; }
    }
}
