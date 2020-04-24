using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows;
using System.Threading;

namespace panel_login_register
{
    class HashCheck
    {
        public static bool isValidDLL = false;
        public static void HashChecks()
        {
            // 1st one is NewtonJson Hash, 2nd is AuthGG.dll to get updated hash download hash checker and drag the dll ontop of the unopened app!
            if (CalculateMD5("Newtonsoft.Json.dll") != "a907da945d77abd7d7ad83bbcbd67b68" || CalculateMD5(typeof(AuthGG.Auth).Assembly.Location) != "40182c14facac046a2d4e9141e615c80")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hashcheck has failed!");
                Thread.Sleep(3000);
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                isValidDLL = true;
            }
        }
        private static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}
