using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orus.Logica
{
    public class Lusuario
    {
        public int Id_usuario { get; set; }

        public string Nombres { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public byte[] Icono { get; set; }

        public string Estado { get; set; }
    }
}
