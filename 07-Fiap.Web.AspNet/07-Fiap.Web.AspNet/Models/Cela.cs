using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _07_Fiap.Web.AspNet.Models
{
    public class Cela
    {
        public int CelaId { get; set; }

        [Required, StringLength(55, ErrorMessage = "Máximo de 50")]
        public string Nome { get; set; }

        [Required]
        public float Area { get; set; }

        [Range(1,200)]
        public int QuantidadeMaxima { get; set; }

        public IList<Presidiario> Presidiarios { get; set; }

    }
}
