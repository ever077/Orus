using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orus.Logica
{
    public class Lcargo
    {
        private int id_cargo;
        private string cargo;
        private double sueldoPorHora;

        public int Id_cargo { get => id_cargo; set => id_cargo = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public double SueldoPorHora { get => sueldoPorHora; set => sueldoPorHora = value; }
    }
}
