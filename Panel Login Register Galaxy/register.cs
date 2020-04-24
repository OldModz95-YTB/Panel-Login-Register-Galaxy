using AuthGG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using panel_login_register;

namespace Panel_Login_Register_Galaxy
{
	public partial class register : Form
	{
		public register()
		{
			InitializeComponent();
		}

		private void login_Click(object sender, EventArgs e)
		{
			HashCheck.HashChecks();
			if (HashCheck.isValidDLL)
			{

				AuthGG.Initialize.AID = "";
				AuthGG.Initialize.ProgramSecret = "";
				AuthGG.Initialize.Version = "1.0";
				AuthGG.Initialize.Secret = "";
				AuthGG.Initialize.Init();
			}
			else
			{
				Thread.Sleep(3000);
				Process.GetCurrentProcess().Kill();
			}

			string username = name.Text;
			string password = pass.Text;
			string email = mail.Text;
			string license = licences.Text;
			bool register = AuthGG.Auth.Register(username, password, email, license, true);
			if (register)
			{
				if (Auth.Response != AuthGG.Initialize.Secret)
				{
					MessageBox.Show("An error occured!", "Register Panel", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Process.GetCurrentProcess().Kill();
				}
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Successfully registered! Go to panel Login");
				Console.ForegroundColor = ConsoleColor.White;
				Console.Read();
				base.Hide();
				new Form1().Show();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Failed to register! Contact OldModz95");
				Console.Read();
			}
		}
	}
}
