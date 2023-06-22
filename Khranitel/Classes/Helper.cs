using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Khranitel.Models;
using System.Security.Cryptography;

namespace Khranitel.Classes
{
    internal class Helper
    {
        public static KhranitelDbEntities Db = new KhranitelDbEntities();

        public static User AuthUs = null;

        public static Window ReqWin = null;

        public static void Error(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void Info(string message)
        {
            MessageBox.Show(message, "Инфо", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public static string GetHash(string message)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(message));
            return Convert.ToBase64String(hash);

        }
    }
}
