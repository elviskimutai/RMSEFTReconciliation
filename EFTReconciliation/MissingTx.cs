using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFTReconciliation
{
    public partial class MissingTx : Form
    {
        public MissingTx()
        {
            InitializeComponent();
        }

        private void MissingTx_Load(object sender, EventArgs e)
        {
           
           
        }
        private void copyAlltoClipboard()
        {
            GVNotinBS.SelectAll();
            DataObject dataObj = GVNotinBS.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;
                xlWorkSheet.Cells[1, 1] = "MaskedPAN";
                xlWorkSheet.Cells[1, 2] = "PurchaseAmount";
                xlWorkSheet.Cells[1, 3] = "RRN";
                xlWorkSheet.Cells[1, 4] = "TransactionDate";
                xlWorkSheet.Cells[1, 5] = "TransactionTime";
                xlWorkSheet.Cells[1, 6] = "AmountPaid";
                xlWorkSheet.Cells[1, 7] = "TerminalID";
                xlWorkSheet.Cells[1, 8] = "StoreName";
                xlWorkSheet.Cells[1,9] = "ResponseCode";
                xlWorkSheet.Cells[1,10] = "ResponseText";
                xlWorkSheet.Cells[1,11] = "AuthorizationCode";
                xlWorkSheet.Cells[1,12] = "TransactionNo";
                xlWorkSheet.Cells[1,13] = "cashBackAmount";
                for (i = 0; i <= GVNotinBS.RowCount - 1; i++)
                {
                    for (j = 0; j <= GVNotinBS.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = GVNotinBS[j, i];
                        xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                    }
                }

                xlWorkBook.SaveAs("NotinBankStatement.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel file created NotinBankStatement.xls");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnNotInLogs_Paint(object sender, PaintEventArgs e)
        {

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;
                xlWorkSheet.Cells[1, 1] = "MaskedPAN";
                xlWorkSheet.Cells[1, 2] = "PurchaseAmount";
                xlWorkSheet.Cells[1, 3] = "RRN";
                xlWorkSheet.Cells[1, 4] = "TransactionDate";
                xlWorkSheet.Cells[1, 5] = "TransactionTime";
                xlWorkSheet.Cells[1, 6] = "AmountPaid";
                xlWorkSheet.Cells[1, 7] = "TerminalID";
                xlWorkSheet.Cells[1, 8] = "StoreName";
                xlWorkSheet.Cells[1, 9] = "ResponseCode";
                xlWorkSheet.Cells[1, 10] = "ResponseText";
                xlWorkSheet.Cells[1, 11] = "AuthorizationCode";
                xlWorkSheet.Cells[1, 12] = "TransactionNo";
                xlWorkSheet.Cells[1, 13] = "cashBackAmount";
                for (i = 0; i <= GVReconciled.RowCount - 1; i++)
                {
                    for (j = 0; j <= GVReconciled.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = GVReconciled[j, i];
                        xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                    }
                }

                xlWorkBook.SaveAs("Reconciled.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel file created NotinBankStatement.xls");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Microsoft.Office.Interop.Excel.Worksheet  AddColumnsheader(Microsoft.Office.Interop.Excel.Workbook xlWorkBook,DataTable dt)
        {
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 1;
            foreach (DataColumn column in dt.Columns)
            {
                xlWorkSheet.Cells[1, i] = column.ColumnName.ToString();              
                i++;
            }
           
          
            return xlWorkSheet;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                //Adding the Columns.
                foreach (DataGridViewColumn column in GVNotInLogs.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                Microsoft.Office.Interop.Excel.Application xlApp;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
             //   Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = AddColumnsheader(xlWorkBook,dt);
                int i = 0;
                int j = 0;
              
                for (i = 0; i <= GVNotInLogs.RowCount - 1; i++)
                {
                    for (j = 0; j <= GVNotInLogs.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = GVNotInLogs[j, i];
                        xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                    }
                }
                xlWorkBook.SaveAs("NotInLogs.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel file created NotInLogs.xls");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
