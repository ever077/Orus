using Orus.Presentacion;
using System;
using System.Windows.Forms;

namespace Orus
{
    internal static class Program
    {
        /*
         * Esta Aplicacion esta hecha por 4E Software - Ever Dario Godoy
         * En el marco del curso de Codigo369 de Udemy
        */

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Asistencia frm = new Asistencia();
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
            Application.Run();
        }

        private static void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
