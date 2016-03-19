using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Ration
{
    public partial class VerificationForm : Form
    {
        AppData Data=new AppData();
        string CardNo;
        SqlConnection con = new SqlConnection(db.conString);

        public VerificationForm(string card)
        {            
            InitializeComponent();
            CardNo = card;
		}

        private void ExchangeData(bool read)
        {

        }

        public void OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus Status)
        {
            DPFP.Verification.Verification ver = new DPFP.Verification.Verification();
            DPFP.Verification.Verification.Result res = new DPFP.Verification.Verification.Result();

            try
            {
                string mem = null;
                con.Open();
                SqlCommand cmd = new SqlCommand("select memName,finger from familyMembers where CardNo='" + CardNo + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                DPFP.Template template = new DPFP.Template();
                while (dr.Read())
                {
                    mem = dr["memName"].ToString();
                    byte[] tmp = (byte[])dr["finger"];
                    template.DeSerialize(tmp);

                    if (template != null)
                    {
                        ver.Verify(FeatureSet, template, ref res);
                        Data.IsFeatureSetMatched = res.Verified;
                        Data.FalseAcceptRate = res.FARAchieved;
                        string rate = Data.FalseAcceptRate.ToString() + "00";
                        string sp = rate.Remove(2);
                        label1.Text = sp + " %";
                        if (sp == "00")
                        {
                            label1.Text = "100 %";
                        }

                        if (res.Verified)
                        {
                            MessageBox.Show("Verification Success");
                            con.Close();
                            UserLogin.member = mem;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            //if (!res.Verified)
            //    Status = DPFP.Gui.EventHandlerStatus.Failure;
            //MessageBox.Show("Unauthorized User");
            Data.Update();
        }
        

        private void VerificationForm_Load(object sender, EventArgs e)
        {
           
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
          
        }
	}
}