using Phumla_Kamnandi.Presentation_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kamnandi
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new ManageGuest());
=======
            Application.Run(new Login_Form());
>>>>>>> 25c79a3d3da6c7ada0f4b11364fcf136940a9d66
        }
    }
}
