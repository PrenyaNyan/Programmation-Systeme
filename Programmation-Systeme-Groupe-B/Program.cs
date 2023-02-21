using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Programmation_Systeme_Groupe_B
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            bool prevInstance;
            _ = new System.Threading.Mutex(true, "Easy Save", out prevInstance);
            if (prevInstance == false)
            {
                MessageBox.Show("There is another instance running");
                return;
            }
            App application = new App();
            application.InitializeComponent();
            application.Run();
        }
    }
}
