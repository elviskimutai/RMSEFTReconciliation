using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFTReconciliation
{
    public partial class Form1 : Form
    {
        DataSet xslStataments = null;
        DataTable EFTLogs = null;
        DataTable bankstatements = null;
        DataTable DTNotInBankStatement = new DataTable();
        DataTable DTInBankStatement = new DataTable();
        DataTable DTINotInLogs = new DataTable();
        String connetionString = null;
        String RRN = null;
        String Amount = null;
        String AuthCode = null;
        
        string filename=null;
        string extrn=null;
        public Form1()
        {
            InitializeComponent();
        }
        public Boolean InitConnectionString()
        {
            try
            {
               
                String iniPath = AppDomain.CurrentDomain.BaseDirectory + "connetionString.ini";
                var lines = File.ReadAllLines(iniPath);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    if (i == 0)
                    {
                        connetionString = Crypto.Decrypt(lines[i]);
                    }

                }
                return true;
            }
            catch (Exception ex)
            {

              //  MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        void initializelogsdatatable()
        {
            DTInBankStatement.Clear();
           
            DTInBankStatement.Columns.Add("MaskedPAN");
            DTInBankStatement.Columns.Add("PurchaseAmount");
            DTInBankStatement.Columns.Add("RRN");
            DTInBankStatement.Columns.Add("TransactionDate");
            DTInBankStatement.Columns.Add("TransactionTime");
            DTInBankStatement.Columns.Add("AmountPaid");
            DTInBankStatement.Columns.Add("TerminalID");
            DTInBankStatement.Columns.Add("StoreName");
            DTInBankStatement.Columns.Add("ResponseCode");
            DTInBankStatement.Columns.Add("ResponseText");
            DTInBankStatement.Columns.Add("AuthorizationCode");
            DTInBankStatement.Columns.Add("TransactionNo");
            DTInBankStatement.Columns.Add("cashBackAmount");
          

            DTNotInBankStatement.Clear();
          
            DTNotInBankStatement.Columns.Add("MaskedPAN");
            DTNotInBankStatement.Columns.Add("PurchaseAmount");
            DTNotInBankStatement.Columns.Add("RRN");
            DTNotInBankStatement.Columns.Add("TransactionDate");
            DTNotInBankStatement.Columns.Add("TransactionTime");
            DTNotInBankStatement.Columns.Add("AmountPaid");
            DTNotInBankStatement.Columns.Add("TerminalID");
            DTNotInBankStatement.Columns.Add("StoreName");
            DTNotInBankStatement.Columns.Add("ResponseCode");
            DTNotInBankStatement.Columns.Add("ResponseText");
            DTNotInBankStatement.Columns.Add("AuthorizationCode");
            DTNotInBankStatement.Columns.Add("TransactionNo");
            DTNotInBankStatement.Columns.Add("cashBackAmount");

            

        }
        public void loadcombo(DataTable BankST)
        {
            try
            {
                String[] Headers = new String[BankST.Columns.Count];
                int i = 0;
                DTINotInLogs.Clear();
               

                // Add the sheet name to the string array.
                foreach (DataColumn column in BankST.Columns)
                {
                    Headers[i] = column.ColumnName.ToString();
                    txtAuthCode.Items.Add(column.ColumnName.ToString());
                    txtAmount.Items.Add(column.ColumnName.ToString());
                    txtRRN.Items.Add(column.ColumnName.ToString());
                    DTINotInLogs.Columns.Add(column.ColumnName.ToString());
                    i++;
                }
                    
                    
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
          
            

           
        }
        public void ImportDataFromExcel(string worksheet)
        {
            
                string myexceldataquery = "select * from ["+ worksheet+"]";
                OleDbConnection OledbConn = null;

            try
            {
                OledbConn = InitializeOledbConnection();                         
                OleDbCommand command = new OleDbCommand(myexceldataquery, OledbConn);
                OledbConn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(myexceldataquery, OledbConn);
                xslStataments = new DataSet();
                adapter.Fill(xslStataments, "xslStataments");
                bankstatements = new DataTable();
              
                adapter.Fill(bankstatements);
                chkAuthCode.DataSource = bankstatements;
                loadcombo(bankstatements);
                OledbConn.Close();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
            }
            finally
            {
                // Clean up.
                if (OledbConn != null)
                {
                    OledbConn.Close();
                }
                
            }
        }
         OleDbConnection InitializeOledbConnection()
        {
            OleDbConnection OledbConn = null;
            try
            {
                string connString = "";
                
                if (extrn == ".xls")
                {
                    connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";

                }
                //Connectionstring for excel v8.0    

                else
                    //Connectionstring fo excel v12.0    
                    connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=Excel 12.0;";
                // connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";

                OledbConn = new OleDbConnection(connString);
                return OledbConn;
            }
            catch (Exception)
            {
                return OledbConn;
                
            }
        }
        private String[] GetExcelSheetNames(string excelFile)
        {
           
            System.Data.DataTable dt = null;
            OleDbConnection OledbConn = null;

            try
            {

                OledbConn = InitializeOledbConnection();
                OledbConn.Open();
                // Get the data table containg the schema guid.
                dt = OledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    return null;
                }

                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                // Loop through all of the sheets if you want too...
                //for (int j = 0; j < excelSheets.Length; j++)
                //{
                //    // Query each excel sheet.
                //}

                return excelSheets;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                // Clean up.
                if (OledbConn != null)
                {
                    OledbConn.Close();
                   
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"D:\",
                    Title = "Browse Text Files",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    //DefaultExt = "txt",
                    //Filter = "txt files (*.txt)|*.txt",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = openFileDialog1.FileName;
                    extrn = Path.GetExtension(openFileDialog1.FileName);                    
                    txtFilePath.Text = openFileDialog1.FileName;
                    String[] worksheets = this.GetExcelSheetNames(txtFilePath.Text);
                    cmbworksheet.DataSource = worksheets;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void refreshdata()
        {
            try
            {

           
            SqlConnection con = new SqlConnection(@connetionString);
            SqlCommand cmd = new SqlCommand("select MaskedPAN, PurchaseAmount, RRN , TransactionDate, TransactionTime, AmountPaid, TerminalID, StoreName, ResponseCode, ResponseText , AuthorizationCode, TransactionNo, cashBackAmount from WSL_Logs where SettlementStatus=@SettlementStatus and (ResponseCode=@ResponseCode1 or ResponseCode=@ResponseCode2 or ResponseCode=@ResponseCode3)", con);
            cmd.Parameters.AddWithValue("@SettlementStatus", 0);
            cmd.Parameters.AddWithValue("@ResponseCode1", 0);
            cmd.Parameters.AddWithValue("@ResponseCode2", 00);
            cmd.Parameters.AddWithValue("@ResponseCode3", 000);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
             EFTLogs = new DataTable();
            sda.Fill(EFTLogs);
            con.Close();
            dataGridViewlogs.DataSource = EFTLogs;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnReconcile_Click(object sender, EventArgs e)
        {
            try
            {
             
               ImportDataFromExcel(cmbworksheet.SelectedItem.ToString());
                MessageBox.Show("Data Imported successfully");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (InitConnectionString())
            {
                initializelogsdatatable();
                chkAuthCode.Visible = true;
                dataGridViewlogs.Visible = false;
                refreshdata();
            }
            else
            {
                this.Hide();
                DBConnect _Con = new DBConnect();
                _Con.Show();
            }
            
        }

        private void btn_Statement(object sender, EventArgs e)
        {
            dataGridViewlogs.Visible = false;
            chkAuthCode.Visible = true;
        }

        private void btnlogsClick(object sender, EventArgs e)
        {
            dataGridViewlogs.Visible = true;
            chkAuthCode.Visible = false;
            refreshdata();
        }
        private void UpdatReconcileda(String RRN)
        {
            try
            {
                SqlConnection con = new SqlConnection(@connetionString);
                DateTime dt = DateTime.Now;
                SqlCommand cmd = new SqlCommand("UPDATE WSL_Logs SET SettlementStatus=1,SettlementDate="+ dt+" where RRN=@RRN", con);
                cmd.Parameters.AddWithValue("@RRN", RRN);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
           
        }

        void Reconcile()
        {

            try
            {
                DTInBankStatement.Clear();
                DTNotInBankStatement.Clear();
                DTINotInLogs.Clear();
                if (EFTLogs == null)
                {
                    MessageBox.Show("No EFT Transactions Found", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                    return;
                }
                if (bankstatements == null)
                {
                    MessageBox.Show("No Bank Statements data Found", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                Boolean useAmount = chkAmount.Checked;
                Boolean useAuthCode = chkAuth.Checked;
                if (!useAuthCode && useAmount)
                {
                    foreach (DataRow rowMasterItems in EFTLogs.Rows)
                    {
                        int lintSumOfItems = 0;
                        foreach (DataRow rowItems in bankstatements.Rows)
                        {
                            if (rowMasterItems["PurchaseAmount"].ToString().Trim().Equals(rowItems[Amount].ToString().Trim()) && rowMasterItems["RRN"].ToString().Trim().Equals(rowItems[RRN].ToString().Trim()))
                            {

                                DTInBankStatement.Rows.Add(rowMasterItems.ItemArray);
                                UpdatReconcileda(rowMasterItems["RRN"].ToString());

                            }
                        }
                    }
                    //checked Mising transactuons from logs
                    foreach (DataRow rowMasterItems in EFTLogs.Rows)
                    {
                        Boolean isAvailable = false;
                        foreach (DataRow rowItems in DTInBankStatement.Rows)
                        {
                            if (rowMasterItems["PurchaseAmount"].ToString().Trim() == rowItems["PurchaseAmount"].ToString().Trim() && rowItems["RRN"].ToString().Trim().Equals(rowMasterItems["RRN"].ToString().Trim()))
                            {
                                isAvailable = true;
                                break;
                            }
                        }
                        if (!isAvailable)
                        {
                            DTNotInBankStatement.Rows.Add(rowMasterItems.ItemArray);
                        }
                    }
                    //checked Mising transactuons from statemnts
                    foreach (DataRow rowMasterItems in bankstatements.Rows)
                    {
                        Boolean isAvailable = false;
                        foreach (DataRow rowItems in EFTLogs.Rows)
                        {
                            if (rowItems["PurchaseAmount"].ToString().Equals(rowMasterItems[Amount].ToString()) && rowItems["RRN"].ToString().Trim().Equals(rowMasterItems[RRN].ToString().Trim()))
                            {
                                isAvailable = true;
                                break;
                            }
                        }
                        if (!isAvailable)
                        {
                            String s = rowMasterItems[RRN].ToString();
                            if (rowMasterItems[RRN].ToString().Trim() != "")
                            {
                                DTINotInLogs.Rows.Add(rowMasterItems.ItemArray);
                                //DataRow row;
                                //row = DTINotInLogs.NewRow();
                                //row["RRN"] = rowMasterItems[RRN].ToString();
                                //DTINotInLogs.Rows.Add(row);
                            }
                        }
                    }


                }
                else if (useAuthCode && !useAmount)
                {
                    foreach (DataRow rowMasterItems in EFTLogs.Rows)
                    {
                        int lintSumOfItems = 0;
                        foreach (DataRow rowItems in bankstatements.Rows)
                        {

                            if (rowMasterItems["AuthorizationCode"].ToString().Equals(rowItems[AuthCode].ToString()) && rowMasterItems["RRN"].ToString().Trim().Equals(rowItems[RRN].ToString().Trim()))
                            {

                                DTInBankStatement.Rows.Add(rowMasterItems.ItemArray);
                                UpdatReconcileda(rowMasterItems["RRN"].ToString());

                            }
                        }
                    }
                    //checked Mising transactuons from logs
                    foreach (DataRow rowMasterItems in EFTLogs.Rows)
                    {
                        Boolean isAvailable = false;
                        foreach (DataRow rowItems in DTInBankStatement.Rows)
                        {
                            if (rowMasterItems["AuthorizationCode"].ToString().Trim() == rowItems["AuthorizationCode"].ToString().Trim() && rowItems["RRN"].ToString().Trim().Equals(rowMasterItems["RRN"].ToString().Trim()))
                            {
                                isAvailable = true;
                                break;
                            }
                        }
                        if (!isAvailable)
                        {
                            DTNotInBankStatement.Rows.Add(rowMasterItems.ItemArray);
                        }
                    }
                    //checked Mising transactuons from statemnts
                    foreach (DataRow rowMasterItems in bankstatements.Rows)
                    {
                        Boolean isAvailable = false;
                        foreach (DataRow rowItems in EFTLogs.Rows)
                        {
                            if (rowItems["AuthorizationCode"].ToString().Equals(rowMasterItems[AuthCode].ToString()) && rowItems["RRN"].ToString().Trim().Equals(rowMasterItems[RRN].ToString().Trim()))
                            {
                                isAvailable = true;
                                break;
                            }
                        }
                        if (!isAvailable)
                        {
                            String s = rowMasterItems[RRN].ToString();
                            if (rowMasterItems[RRN].ToString().Trim() != "")
                            {
                                DTINotInLogs.Rows.Add(rowMasterItems.ItemArray);
                                //DataRow row;
                                //row = DTINotInLogs.NewRow();
                                //row["RRN"] = rowMasterItems[RRN].ToString();
                                //DTINotInLogs.Rows.Add(row);
                            }
                        }
                    }

                }
                else if(useAuthCode && useAmount)
                {
                    foreach (DataRow rowMasterItems in EFTLogs.Rows)
                    {
                        int lintSumOfItems = 0;
                        foreach (DataRow rowItems in bankstatements.Rows)
                        {

                            if (rowMasterItems["AuthorizationCode"].ToString().Equals(rowItems[AuthCode].ToString()) && rowMasterItems["PurchaseAmount"].ToString().Equals(rowItems[Amount].ToString()) && rowMasterItems["RRN"].ToString().Equals(rowItems[RRN].ToString()))
                            {

                                DTInBankStatement.Rows.Add(rowMasterItems.ItemArray);
                                UpdatReconcileda(rowMasterItems["RRN"].ToString());

                            }
                        }
                    }
                    //checked Mising transactuons from logs
                    foreach (DataRow rowMasterItems in EFTLogs.Rows)
                    {
                        Boolean isAvailable = false;
                        foreach (DataRow rowItems in DTInBankStatement.Rows)
                        {
                            if (rowMasterItems["AuthorizationCode"].ToString().Trim() == rowItems["AuthorizationCode"].ToString().Trim() && rowMasterItems["PurchaseAmount"].ToString().Trim().Equals(rowItems["PurchaseAmount"].ToString().Trim()) && rowMasterItems["RRN"].ToString().Trim().Equals(rowItems["RRN"].ToString().Trim()))
                            {
                                isAvailable = true;
                                break;
                            }
                        }
                        if (!isAvailable)
                        {
                            DTNotInBankStatement.Rows.Add(rowMasterItems.ItemArray);
                        }
                    }
                    //checked Mising transactuons from statemnts
                    foreach (DataRow rowMasterItems in bankstatements.Rows)
                    {
                        Boolean isAvailable = false;
                        foreach (DataRow rowItems in EFTLogs.Rows)
                        {
                            if (rowItems["AuthorizationCode"].ToString().Trim().Equals(rowMasterItems[AuthCode].ToString().Trim()) && rowItems["PurchaseAmount"].ToString().Trim().Equals(rowMasterItems[Amount].ToString().Trim()) && rowItems["RRN"].ToString().Trim().Equals(rowMasterItems[RRN].ToString().Trim()))
                            {
                                isAvailable = true;
                                break;
                            }
                        }
                        if (!isAvailable)
                        {
                            String s = rowMasterItems[RRN].ToString();
                            if (rowMasterItems[RRN].ToString().Trim() != "")
                            {
                                DTINotInLogs.Rows.Add(rowMasterItems.ItemArray);
                                //DataRow row;
                                //row = DTINotInLogs.NewRow();
                                //row["RRN"] = rowMasterItems[RRN].ToString();
                                //DTINotInLogs.Rows.Add(row);
                            }
                        }
                    }

                }
                else
                {//checked matching transactuons
                foreach (DataRow rowMasterItems in EFTLogs.Rows)
                {
                    int lintSumOfItems = 0;
                    foreach (DataRow rowItems in bankstatements.Rows)
                    {
                                               
                        if (rowMasterItems["RRN"].ToString().Trim().Equals(rowItems[RRN].ToString().Trim()))
                        {
                           
                            DTInBankStatement.Rows.Add(rowMasterItems.ItemArray);
                            UpdatReconcileda(rowMasterItems["RRN"].ToString());

                        }
                    }
                }
                //checked Mising transactuons from logs
                foreach (DataRow rowMasterItems in EFTLogs.Rows)
                {
                    Boolean isAvailable = false;
                    foreach (DataRow rowItems in DTInBankStatement.Rows)
                    {
                        if (rowMasterItems["RRN"].ToString().Trim() == rowItems["RRN"].ToString().Trim())
                        {
                            isAvailable = true;
                            break;                                                       
                        }
                    }
                    if (!isAvailable)
                    {
                        DTNotInBankStatement.Rows.Add(rowMasterItems.ItemArray);
                    }
                }
                //checked Mising transactuons from statemnts
                foreach (DataRow rowMasterItems in bankstatements.Rows)
                {
                    Boolean isAvailable = false;
                    foreach (DataRow rowItems in EFTLogs.Rows)
                    {
                        if (rowItems["RRN"].ToString().Trim().Equals(rowMasterItems[RRN].ToString().Trim()))
                        {
                            isAvailable = true;
                            break;
                        }
                    }
                    if (!isAvailable)
                    {
                        String s = rowMasterItems[RRN].ToString();
                        if (rowMasterItems[RRN].ToString().Trim()!= "")
                        {
                                DTINotInLogs.Rows.Add(rowMasterItems.ItemArray);
                                //DataRow row;
                                //row = DTINotInLogs.NewRow();
                                //row["RRN"] = rowMasterItems[RRN].ToString();
                                //DTINotInLogs.Rows.Add(row);
                            }
                    }
                }
                }


                Constants _Constants = new Constants();
                Constants.DTNotInBankStatement = DTNotInBankStatement;
                MissingTx _MissingTx = new MissingTx();

                _MissingTx.ReconciledlbCount.Text = DTInBankStatement.Rows.Count.ToString();
                _MissingTx.lbCountNotinBS.Text = DTNotInBankStatement.Rows.Count.ToString();
                _MissingTx.lbNotInlogs.Text = DTINotInLogs.Rows.Count.ToString();
                
                _MissingTx.GVNotinBS.DataSource = DTNotInBankStatement;
                _MissingTx.GVReconciled.DataSource = DTInBankStatement;
                 _MissingTx.GVNotInLogs.DataSource = DTINotInLogs;

                _MissingTx.ShowDialog();
                //if (DTNotInBankStatement.Rows.Count > 0)
                //{
                //}
                //else
                //{
                //    MessageBox.Show("No Missing Transactions Found");
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }
        private void btnReconcile_Click_1(object sender, EventArgs e)
        {

            Amount = null;           
            AuthCode = null;
            RRN = null;
                       
            
            Boolean useAmount = chkAmount.Checked;
            Boolean useAuthCode = chkAuth.Checked;
          
                if (txtRRN.Text.Trim() != "")
                {
                    RRN = txtRRN.Text;
                }
                else
                {
                    MessageBox.Show("RRN Column is required", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
           
            
            if (useAmount)
            {
                if (txtAmount.Text.Trim() != "")
                {
                    Amount = txtAmount.Text;
                }
                else
                {
                    MessageBox.Show("Amount Column is required", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
           
            if (useAuthCode)
            {
                if (txtAuthCode.Text.Trim() != "")
                {
                    AuthCode = txtAuthCode.Text;
                }
                else
                {
                    MessageBox.Show("AuthorizationCode Column is required", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
         
            Reconcile();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbworksheet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect _Con = new DBConnect();
                _Con.ShowDialog();
            }
            catch (Exception)
            {

                
            }
        }
    }
}
