using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFTReconciliation
{
    public partial class DBConnect : Form
    {
        public DBConnect()
        {
            InitializeComponent();
        }
        public List<string> GetDatabaseList(SqlConnection con)
        {
            List<string> list = new List<string>();
            try
            {

                // Open connection to the database


                con.Open();
                MessageBox.Show("Connection Established");
                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(dr[0].ToString());
                        }
                    }
                }
                con.Close();

                return list;

            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return list;
            }
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                String Servername = txtServerName.Text;

                String UserName = txtUserName.Text;
                String Password = txtPassword.Text;
                String connetionString = "Data Source=" + Servername + "; User ID = " + UserName + "; Password = " + Password;
                SqlConnection cnn;
                cnn = new SqlConnection(connetionString);

                // cnn.Open();

                List<string> Dbs = GetDatabaseList(cnn);
                dbCombobox.DataSource = Dbs;
                // cnn.Close();

            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void EditconnetionString(String URL)
        {
            try
            {
                String iniPath = AppDomain.CurrentDomain.BaseDirectory + "connetionString.ini";
                StringBuilder newFile = new StringBuilder();
                newFile.Append(URL);
                File.WriteAllText(@iniPath, newFile.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ( String.IsNullOrEmpty(txtServerName.Text) || String.IsNullOrEmpty(dbCombobox.Text.ToString()))
                {
                    MessageBox.Show("Fill All Required Fields");
                    return;
                }
                String Servername = txtServerName.Text;
                String DatabaseName = dbCombobox.SelectedItem.ToString();
                String UserName = txtUserName.Text;
                String Password = txtPassword.Text;
                String connetionString = "Data Source=" + Servername + ";Initial Catalog = " + DatabaseName + "; User ID = " + UserName + "; Password = " + Password;
                String en = Crypto.Encrypt(connetionString);
           

                EditconnetionString(en);
                MessageBox.Show("Configurations Saved");
                Form1 _f1 = new Form1();
                _f1.Show();
                this.Hide();

            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
