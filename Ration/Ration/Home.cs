using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ration
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void llblAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminLogin alog = new AdminLogin();
            alog.ShowDialog();

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            UserLogin ul = new UserLogin();
            ul.ShowDialog();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            NewUser nuser = new NewUser();
            nuser.ShowDialog();
        }
    }
}
