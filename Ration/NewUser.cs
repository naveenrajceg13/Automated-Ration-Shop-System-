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
    public partial class NewUser : Form
    {
        SqlConnection con = new SqlConnection(db.conString);
        public NewUser()
        {
            InitializeComponent();
        }

        public static byte[] finger = null;

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = op.FileName;
            }
            else
            {
                MessageBox.Show("Please chose photo");
            }
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            lblCardNo.Text = generateCardNo();
            getRfid();
        }

        private void getRfid()
        {
            try
            {
                SerialPortTerminal.frmTerminal frm = new SerialPortTerminal.frmTerminal();
                frm.ShowDialog();
                lblRfid.Text = "";
                if (File.Exists(Application.StartupPath + "\\RFID Number\\FromRFID.txt"))
                {
                    StreamReader sw1 = new StreamReader(Application.StartupPath + "\\RFID Number\\FromRFID.txt");
                    lblRfid.Text = (sw1.ReadToEnd()).ToString();
                    sw1.Close();
                }
                File.Delete(Application.StartupPath + "\\RFID Number\\FromRFID.txt");
            }
            catch (Exception e)
            {
                MessageBox.Show("problem with RF - ID Scanner");
            }
        }

        private string generateCardNo()
        {


            con.Open();
            SqlCommand cmd = new SqlCommand("select max(CardNo) from Card",con);
            string op = cmd.ExecuteScalar().ToString();
            int cn=0;
            try
            {
                cn = Convert.ToInt32(op.Remove(0, 5));
            }
            catch (Exception e)
            {
            }
            con.Close();

             /* if (cn==0)
            {
                cn=3020;
            }*/
            string cNo = "24/G/"+(cn+1).ToString();
            return cNo;
        }

        private void callFingerPrint(string UserName)
        {
            MainForm mainFrm = new MainForm(UserName);
            mainFrm.ShowDialog();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (pictureBox1.ImageLocation != null)
            {
                try
                {
                    FileStream fs = new FileStream(pictureBox1.ImageLocation, FileMode.Open);
                    byte[] myimage = new byte[fs.Length];
                    fs.Read(myimage, 0, myimage.Length);
                    fs.Close();

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Card values(@CardNo,@CardType,@CardHolder,@FathersName,@Address,@ContactNo,@emailid,@Photo,@RfidNo)", con);
                    cmd.Parameters.AddWithValue("@CardNo", lblCardNo.Text);
                    cmd.Parameters.AddWithValue("@CardType", cmbCardType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CardHolder", txtCardHolder.Text);
                    cmd.Parameters.AddWithValue("@FathersName", txtFather.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
                    cmd.Parameters.AddWithValue("@emailid", txteMail.Text);
                    cmd.Parameters.AddWithValue("@Photo", myimage);
                    cmd.Parameters.AddWithValue("@RfidNo", lblRfid.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e11)
                {
                    MessageBox.Show("something not filled , fill properly ");
                }
            }
            
            groupBox1.Enabled = false;
            groupBox2.Visible = true;
        }

        private void insMembers()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into familyMembers values(@CardNo,@memName,@Dob,@Gender,@Relationship,@mobile,@finger)", con);
                cmd.Parameters.AddWithValue("@CardNo", lblCardNo.Text);
                cmd.Parameters.AddWithValue("@memName", txtName.Text);
                cmd.Parameters.AddWithValue("@Dob", Convert.ToDateTime(txtDob.Text));
                cmd.Parameters.AddWithValue("@Gender", cmbGender.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Relationship", txtRelationship.Text);
                cmd.Parameters.AddWithValue("@mobile", Convert.ToInt64(txtMobile.Text));
                cmd.Parameters.AddWithValue("@finger", finger);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("some detail is not filled correctly please fill again ");
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtDob.Text = monthCalendar1.SelectionRange.Start.ToShortDateString();
            monthCalendar1.Enabled = false;
        }

        private void btnAddMembers_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm(lblCardNo.Text);
            mf.ShowDialog();

            insMembers();
            txtName.Clear();
            txtDob.Clear();
            txtRelationship.Clear();
            txtMobile.Clear();
            monthCalendar1.Enabled = true;
            cmbGender.ResetText();
        }
    }
}
