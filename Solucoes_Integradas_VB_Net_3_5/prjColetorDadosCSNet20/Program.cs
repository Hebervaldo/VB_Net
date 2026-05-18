using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace prjColetorDadosCSNet20
{
    static class Program
    {
        public static frmPrincipal objPrincipal = new frmPrincipal();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(objPrincipal);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
        }
    }
}
