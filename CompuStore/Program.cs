using CompuStore.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompuStore
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
            Application.Run(new Login_Form());
        }
        static public bool isValidInformation(string informationType, string information)
        {
            bool areNumber()
            {
                string numbers = "0123456789";
                for (int i = 0; i < information.Length; i++)
                {
                    if (!numbers.Contains(information[i]))
                        return false;
                }
                return true;
            }
            switch (informationType)
            {
                case "IDcard":
                    if (information.Length != 9 && information.Length != 12)
                        return false;
                    else return areNumber();
                    break;
                case "phoneNum":
                    if (information[0] != '0' && information.Length != 10)
                        return false;
                    else return areNumber();
                    break;
                case "email":
                    var trimmedEmail = information.Trim();

                    if (trimmedEmail.EndsWith("."))
                    {
                        return false; 
                    }
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(information);
                        return addr.Address == trimmedEmail;
                    }
                    catch
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }
    }
}
