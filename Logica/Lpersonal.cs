using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orus.Logica
{
    public class Lpersonal
    {
        private int id_personal;
        private string nombres;
        private string identificacion;
        private string pais;
        private int id_cargo;
        private double sueldoPorHora;
        private string estado;
        private string codigo;

        public int Id_personal { get => id_personal; set => id_personal = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Pais { get => pais; set => pais = value; }
        public int Id_cargo { get => id_cargo; set => id_cargo = value; }
        public double SueldoPorHora { get => sueldoPorHora; set => sueldoPorHora = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Codigo { get => codigo; set => codigo = value; }
    }
}
