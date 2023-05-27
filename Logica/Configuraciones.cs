using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orus.Logica
{
    public class Configuraciones
    {
        public static void DisenoDgv(ref DataGridView listado)
        {
            listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public static object ValidacionDecimales(TextBox txt, KeyPressEventArgs e)
        {
            // Para poder ignorar las comas y que funcione el metodo que sigue tuve que setear la CurrentCulture a "en-US".
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            
            // Ignora las comas para evitar conflictos en los decimales, haciendo que se transformen en puntos.
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                e.KeyChar = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            }

            // Solo permite presionar '.' o ',' o tecla de control como la de borrar.
            // No permite dos '.', tampoco permite letras.
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.' && ((~txt.Text.IndexOf(".")) != 0))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            return null;
        }
    }
}
