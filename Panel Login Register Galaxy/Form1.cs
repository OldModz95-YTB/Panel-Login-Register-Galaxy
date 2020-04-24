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
    public partial class Form1 : Form
    {
        public Form1()
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
			bool login = AuthGG.Auth.Login(username, password, true);
			if (login)
			{
				if (Auth.Response != AuthGG.Initialize.Secret)
				{
					MessageBox.Show("An error occured!", "Projet Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Process.GetCurrentProcess().Kill();
				}
				AuthGG.Log.LogAction("SUCCESS");
				AuthGG.Log.LogAction("Login Successful");
				base.Hide();
				new main().Show();
				this.Hide();
				Console.Read();
			}
		}

		private void registerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Hide();
			new register().Show();
		}
	}
}
