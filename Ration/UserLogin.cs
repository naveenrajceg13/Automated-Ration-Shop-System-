using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Ration
{
    public partial class UserLogin : Form
    {
        SqlConnection con = new SqlConnection(db.conString);
        public static string member = null;
        public UserLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtCardNo.Text != "" && txtConsumer.Text!= "")
            {
                Purchase pur = new Purchase(txtCardNo.Text,txtConsumer.Text);
                this.Hide();
                pur.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void getRfid()
        {
            string rfid=null;
            SerialPortTerminal.frmTerminal frm = new SerialPortTerminal.frmTerminal();
            frm.ShowDialog();
            if (File.Exists(Application.StartupPath + "\\RFID Number\\FromRFID.txt"))
            {
                StreamReader sw1 = new StreamReader(Application.StartupPath + "\\RFID Number\\FromRFID.txt");
                rfid=(sw1.ReadToEnd()).ToString();
                sw1.Close();
            }
            try
            {
                File.Delete(Application.StartupPath + "\\RFID Number\\FromRFID.txt");
                con.Open();
                SqlCommand cmd = new SqlCommand("select CardNo from Card where RfidNo='" + rfid + "'", con);
                txtCardNo.Text = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("card not registred already or some problem with login try again ");
            }
        }

        private void verifyFingerPrint()
        {
            VerificationForm ver = new VerificationForm(txtCardNo.Text);
            ver.ShowDialog();
        }

        private void btnRfid_Click(object sender, EventArgs e)
        {
            getRfid();
        }

        private void btnFingerPrint_Click(object sender, EventArgs e)
        {
            verifyFingerPrint();
            txtConsumer.Text = member;
                
        }
    }
}
