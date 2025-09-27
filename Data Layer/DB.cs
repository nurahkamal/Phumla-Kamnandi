using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Phumla_Kamnandi.Data_Layer
{
    public class DB
    {
        //protected string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\PhumlaKamnandiDB.mdf;Integrated Security=True";
        protected string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=PhumlaKamnandiHotelsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected SqlConnection cnMain;
        protected DataSet dsMain;
        protected SqlDataAdapter daMain;


        public DB()
        {
            try
            {
                cnMain = new SqlConnection(strConn); 
                dsMain = new DataSet();             
                cnMain.Open();                      
                cnMain.Close();                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message);
            }
        }
        public void FillDataSet(string aSQLstring, string aTable)
        {
            try
            {
                daMain = new SqlDataAdapter(aSQLstring, cnMain);
                cnMain.Open();
                dsMain.Clear();
                daMain.Fill(dsMain, aTable);
                cnMain.Close();
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
            }
        }

        public bool UpdateDataSource(string sqlLocal, string table)
        {
            bool success = false;

            try
            {
                cnMain.Open();
                daMain = new SqlDataAdapter(sqlLocal, cnMain);
                SqlCommandBuilder builder = new SqlCommandBuilder(daMain);
                daMain.Update(dsMain, table);
                cnMain.Close();

                FillDataSet(sqlLocal, table);

                success = true;
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
                success = false;
            }

            return success;
        }
    }
}

