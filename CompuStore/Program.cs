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
            switch (informationType)
            {
                case "IDcard":
                    if (information.Length != 9 || information.Length != 12)
                        return false;
                    else return Regex.Match(information, @"^(\+[0-9]{9})$").Success;
                    break;
                case "phoneNum":
                    if (information[0] != '0' || information.Length != 10)
                        return false;
                    else return Regex.Match(information, @"^(\+[0-9]{9})$").Success;
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
