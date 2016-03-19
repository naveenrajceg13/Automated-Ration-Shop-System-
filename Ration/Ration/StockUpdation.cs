using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Ration
{
    public partial class StockUpdation : Form
    {
        SqlConnection con = new SqlConnection(db.conString);
        public StockUpdation()
        {
            InitializeComponent();
            setZero();
        }

        private void setZero()
        {
            txtRice.Text = "0";
            txtSugar.Text = "0";
            txtWheat.Text = "0";
            txtOil.Text = "0";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("insStocks", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@rice", int.Parse(txtRice.Text));
            cmd.Parameters.AddWithValue("@sugar", int.Parse(txtSugar.Text));
            cmd.Parameters.AddWithValue("@wheat", int.Parse(txtWheat.Text));
            cmd.Parameters.AddWithValue("@oil", int.Parse(txtOil.Text));
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.ExecuteNonQuery();

            con.Close();
            setZero();
        }

        private void StockUpdation_Load(object sender, EventArgs e)
        {
            //dataGridView1.Visible = false;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ListViewItem lvi = new ListViewItem();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from AvailableStock", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lvi = listView1.Items.Add(dr["PName"].ToString());
                lvi.SubItems.Add(dr["Quantity"].ToString());
            }
            con.Close();
        }
    }
}
