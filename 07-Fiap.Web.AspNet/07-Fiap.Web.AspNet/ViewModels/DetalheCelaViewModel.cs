using _07_Fiap.Web.AspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _07_Fiap.Web.AspNet.ViewModels
{
    public class DetalheCelaViewModel
    {
        public Cela Cela { get; set; }
        public IList<Presidiario> Presidiarios { get; set; }
        public float Ocupacao { get; set; }
        public int QuantidadePresidiarios { get; set; }
    }
}
