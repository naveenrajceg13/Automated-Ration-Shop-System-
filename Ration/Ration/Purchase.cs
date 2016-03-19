using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Collections;

namespace Ration
{
    public partial class Purchase : Form
    {
        private string CardNo, Consumer;
        SqlConnection con = new SqlConnection(db.conString);
        private string CardType = null;
        public Purchase(string rfid, string finger)
        {
            CardNo = rfid;
            Consumer = finger;
            InitializeComponent();
        }

        public Purchase()
        {
            InitializeComponent();
            CardNo = "CardNo";
            Consumer = "a";
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            btnPurchase.Visible = false;
            check_CardType();
            check_Purchase();
        }

        private void check_CardType()
        {
            SqlCommand cmd = new SqlCommand("retValues", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CardNo", CardNo);
            cmd.Parameters.AddWithValue("@memName", Consumer);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            CardType = ds.Tables["Table"].Rows[0]["CardType"].ToString();
            this.Text += " - " + ds.Tables["Table"].Rows[0]["CardType"].ToString();
            lblCardHolder.Text = ds.Tables["Table"].Rows[0]["CardHolder"].ToString();
            lblCardNo.Text = CardNo;
            lblConsumer.Text = Consumer;

            MemoryStream ms = new MemoryStream((byte[])ds.Tables["Table"].Rows[0]["Photo"]);

            pictureBox1.Image = Image.FromStream(ms);
            lblRelation.Text = ds.Tables["Table1"].Columns["Relationship"].ToString();

            lblMaxRice.Text = ds.Tables["Table2"].Rows[0]["Rice"].ToString();
            lblMaxSugar.Text = ds.Tables["Table2"].Rows[0]["Sugar"].ToString();
            lblMaxWheat.Text = ds.Tables["Table2"].Rows[0]["Wheat"].ToString();
            lblMaxOil.Text = ds.Tables["Table2"].Rows[0]["Oil"].ToString();

            switch (ds.Tables["Table"].Rows[0]["CardType"].ToString())
            {
                case "Rice+":
                    txtSugar.Enabled = false;
                    //lblMaxSugar.Text = "NIL";
                    break;
                case "Sugar+":
                    txtRice.Enabled = false;
                    //lblMaxRice.Text = "NIL";
                    break;
            }
        }

        private void check_Purchase()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Purchase where CardNo='"+lblCardNo.Text+"' and month="+DateTime.Now.Month, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (txtRice.Enabled)
                {
                    if (Convert.ToInt32(dr["Rice"]) > 0)
                    {
                        txtRice.Enabled = false;
                    }
                }
                if (txtSugar.Enabled)
                {
                    if (Convert.ToInt32(dr["Sugar"]) > 0)
                    {
                        txtSugar.Enabled = false;
                        txtSugar.Text = "P";
                    }
                }
                if (Convert.ToInt32(dr["Wheat"]) > 0)
                {
                    txtWheat.Enabled = false;
                    txtWheat.Text = "P";
                }
                if (Convert.ToInt32(dr["Oil"]) > 0)
                {
                    txtOil.Enabled = false;
                    txtOil.Text = "P";
                }
            }
            con.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            bool flag = true;
            txtRice.Text = (txtRice.Text == "") ? "0" : txtRice.Text;
            txtSugar.Text = (txtSugar.Text == "") ? "0" : txtSugar.Text;
            txtWheat.Text = (txtWheat.Text == "") ? "0" : txtWheat.Text;
            txtOil.Text = (txtOil.Text == "") ? "0" : txtOil.Text;

            if (!txtRice.Enabled && !txtSugar.Enabled && !txtWheat.Enabled && !txtOil.Enabled)
            {
                flag = false;
                MessageBox.Show("Already Purchased");
            }

            #region Rice
            //Rice
            if (txtRice.Enabled)
            {
                if (Convert.ToInt32(txtRice.Text) <= Convert.ToInt32(lblMaxRice.Text))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Quantity from AvailableStock where PName='Rice' ", con);
                    int readvalue = Convert.ToInt32(cmd.ExecuteScalar());
                    int val = readvalue - Convert.ToInt32(txtRice.Text);
                    if (readvalue < Convert.ToInt32(txtRice.Text) && val >= 10)
                    {
                        MessageBox.Show("Rice-Stock not available");
                        txtRice.Text = "#";
                        txtRice.Enabled = false;
                        flag = false;
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Enter Rice Quantity within range");
                    txtRice.Clear();
                    txtRice.Focus();
                    flag = false;
                }
            }
            #endregion

            #region Sugar
            //sugar
            if (txtSugar.Enabled)
            {
                if (Convert.ToInt32(txtSugar.Text) <= Convert.ToInt32(lblMaxSugar.Text))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Quantity from AvailableStock where PName='Sugar' ", con);
                    int readvalue = Convert.ToInt32(cmd.ExecuteScalar());
                    int val = readvalue - Convert.ToInt32(txtSugar.Text);
                    if (readvalue > Convert.ToInt32(txtSugar.Text) && val >= 10)
                    {
                        //MessageBox.Show("Stock available");
                    }
                    else
                    {
                        MessageBox.Show("Sugar-Stock not available");
                        txtSugar.Text = "#";
                        txtSugar.Enabled = false;
                        flag = false;
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Enter Sugar Quantity within range");
                    txtSugar.Clear();
                    txtSugar.Focus();
                    flag = false;
                }
            } 
            #endregion

            #region Wheat
            //Wheat
            if (txtWheat.Enabled)
            {

                if (Convert.ToInt32(txtWheat.Text) <= Convert.ToInt32(lblMaxWheat.Text))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Quantity from AvailableStock where PName='wheat' ", con);
                    int readvalue = Convert.ToInt32(cmd.ExecuteScalar());
                    int val = readvalue - Convert.ToInt32(txtWheat.Text);
                    if (readvalue > Convert.ToInt32(txtWheat.Text) && val >= 10)
                    {
                        //MessageBox.Show("Stock available");
                    }
                    else
                    {
                        MessageBox.Show("Wheat-Stock not available");
                        txtWheat.Text = "#";
                        txtWheat.Enabled = false;
                        flag = false;
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Enter wheat Quantity within range");
                    txtWheat.Clear();
                    txtWheat.Focus();
                    flag = false;
                }
            }
            
            #endregion

            #region Oil
            //Oil

            if (txtOil.Enabled)
            {
                if (Convert.ToInt32(txtOil.Text) <= Convert.ToInt32(lblMaxOil.Text))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select Quantity from AvailableStock where PName='oil' ", con);
                    int readvalue = Convert.ToInt32(cmd.ExecuteScalar());
                    int val = readvalue - Convert.ToInt32(txtOil.Text);
                    if (readvalue > Convert.ToInt32(txtOil.Text) && val >= 10)
                    {
                        //MessageBox.Show("Stock available");
                    }
                    else
                    {
                        MessageBox.Show("Oil-Stock not available");
                        txtOil.Text = "#";
                        txtOil.Enabled = false;
                        flag = false;
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Enter oil Quantity within range");
                    txtOil.Clear();
                    txtOil.Focus();
                    flag = false;
                }
            } 
            #endregion

            if (flag)
            {
                btnPurchase.Visible = true;
            }

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            string msg = "You("+lblCardNo.Text+") Purchased.";
            int Rice=0,Sugar=0,wheat=0,oil=0;

            if (!txtRice.Enabled || txtRice.Text == "#")
            {
                Rice = 0;
            }
            else
            {
                Rice = Convert.ToInt32(txtRice.Text);
                msg += "\n Rice=" + txtRice.Text;
            }
            if (!txtSugar.Enabled || txtSugar.Text == "#")
            {
                Sugar = 0;
            }
            else
            {
                Sugar = Convert.ToInt32(txtSugar.Text);
                msg += "\n Sugar="+txtSugar.Text;
            }
            if (!txtWheat.Enabled || txtWheat.Text == "#")
            {
                wheat = 0;
            }
            else
            {
                wheat = Convert.ToInt32(txtWheat.Text);
                msg += "\n Wheat =" + txtWheat.Text;
            }
            if (!txtOil.Enabled || txtOil.Text == "#")
            {
                oil = 0;
            }
            else
            {
                oil = Convert.ToInt32(txtOil.Text);
                msg += "\n Oil ="+txtOil.Text;
            }
            
            con.Open();
            SqlCommand cmdPurchase = new SqlCommand("insPurchase", con);
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.AddWithValue("@date",DateTime.Now.ToShortDateString());
            cmdPurchase.Parameters.AddWithValue("@CardNo",lblCardNo.Text);
            cmdPurchase.Parameters.AddWithValue("@month", DateTime.Now.Month);
            cmdPurchase.Parameters.AddWithValue("@Rice",Rice);
            cmdPurchase.Parameters.AddWithValue("@Sugar",Sugar);
            cmdPurchase.Parameters.AddWithValue("@wheat",wheat);
            cmdPurchase.Parameters.AddWithValue("@oil",oil);
            cmdPurchase.ExecuteNonQuery();
            con.Close();
            msg += "\n on "+DateTime.Now.ToString();

            btnCheck.Visible = false;
            btnPurchase.Visible = false;
            lblPurchase.Text = msg;

            getMobileNo(msg);
        }

        private void getMobileNo(string msg)
        {
            ArrayList alMobile = new ArrayList();
            con.Open();
            SqlCommand cmd = new SqlCommand("select mobile from familyMembers where CardNo='"+lblCardNo.Text+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                alMobile.Add(Convert.ToInt64(dr[0]));
            }
            con.Close();
            
            foreach (var mNo in alMobile)
            {
                sendMessage(mNo.ToString(),msg);
            }
        }
        private void sendMessage(string mobileNo,string msg)
        {
            //ATMMessageService.ATMMessageSend send = new ATMMessageService.ATMMessageSend();
            // send.SendAccInfo(mobileNo, msg);
            MessageBox.Show(msg, mobileNo.ToString());
        }

    }
}