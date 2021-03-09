using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveAccountsWorker
{
    public partial class Form1 : Form
    {
        //sql connection
        static string testDataSource = "AMCDB04-T";
        static string productionDataSource = "AMCDB03";
        static string testInitialCatalog = "DevelopmentTesting";
        static string productionInitialCatalog = "";
        static string integratedSecurity = "True";
        static string multipleActiveResultSets = "True";
        SqlConnection cnSQL;
        SqlCommand selectCMD, insertCMD, deleteCMD, updateCMD;
        SqlDataReader dr;
        string selectSQL, insertSQL, deleteSQL, updateSQL;

        //sql tables
        string dataTable = "[dbo].[AllWorkers.MoveAccounts_Data]";
        string doneDataTable = "[dbo].[AllWorkers.MoveAccounts_Data]";
        string sqlConnStr = $"Data Source={testDataSource};Initial Catalog={testInitialCatalog};Integrated Security={integratedSecurity};MultipleActiveResultSets={multipleActiveResultSets};";

        Int64 accountID;
        string actionHistoryPerson;
        string actionHistoryTime;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get remaining number of accounts in the workers table
            GetRemainingTotals();
            //populate the form
            PopulateForm();
            //update the account that is populated
            UpdateCurrentAccount(accountID);
        }

        //Fills the form with data from the worker's table
        void PopulateForm()
        {
            selectSQL = $@"SELECT TOP 1 * FROM {dataTable} WHERE (CURRENT_TIMESTAMP > DATEADD(MINUTE, 15, WorkerTimestamp) OR CurrentUser = @CurrentUser)";

            using (cnSQL = new SqlConnection(sqlConnStr))
            {
                cnSQL.Open();
                using (selectCMD = new SqlCommand(selectSQL, cnSQL))
                {
                    selectCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = Environment.UserName.ToString().ToUpper();
                    dr = selectCMD.ExecuteReader();
                    //if there are results
                    if (dr.HasRows)
                    {
                        //keep reading until the end
                        while (dr.Read())
                        {
                            accountID = (long)dr["ID"];
                            txtDebtor.Text = dr["DebtorNumber"].ToString();
                            actionHistoryPerson = dr["ActionHistoryPerson"].ToString();
                            txtActionDate.Text = dr["ActionHistoryDate"].ToString();
                            actionHistoryTime = dr["ActionHistoryTime"].ToString();
                        }
                    }
                    selectCMD.Parameters.Clear();
                }
            }
            cnSQL.Close();
        }

        void GetRemainingTotals()
        {
            selectSQL = $@"SELECT COUNT(*) AS 'COUNT' FROM {dataTable}";

            using (cnSQL = new SqlConnection(sqlConnStr))
            {
                cnSQL.Open();
                using (selectCMD = new SqlCommand(selectSQL, cnSQL))
                {
                    dr = selectCMD.ExecuteReader();
                    //if there are results
                    if (dr.HasRows)
                    {
                        //keep reading until the end
                        while (dr.Read())
                        {
                            lblRemainingTotalCount.Text = dr["COUNT"].ToString();
                        }
                    }
                    selectCMD.Parameters.Clear();
                }
            }
            cnSQL.Close();
        }
        void UpdateCurrentAccount(Int64 id)
        {
            updateSQL = $@"UPDATE {dataTable} 
            SET CurrentUser = @CurrentUser, WorkerTimestamp = @WorkerTimestamp 
            WHERE ID = @ID";

            using (cnSQL = new SqlConnection(sqlConnStr))
            {
                cnSQL.Open();
                using (updateCMD = new SqlCommand(updateSQL, cnSQL))
                {
                    updateCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = Environment.UserName.ToString().ToUpper();
                    updateCMD.Parameters.Add("@WorkerTimestamp", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    updateCMD.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
                    updateCMD.ExecuteNonQuery();
                    updateCMD.Parameters.Clear();
                }
            }
            cnSQL.Close();
        }

        void StoreToDoneTable()
        {
            insertSQL = $@"INSERT INTO {doneDataTable}
            (ActionHistoryDebtorNumber, ActionHistoryPerson, ActionHistoryDate, ActionHistoryTime, WorkerTimestamp, CurrentUser)
            VALUES (@DebtorNumber, @ActionDate, WorkerTimestamp, CurrentUser)";

            using (cnSQL = new SqlConnection(sqlConnStr))
            {
                cnSQL.Open();
                using (insertCMD = new SqlCommand(insertSQL, cnSQL))
                {
                    insertCMD.Parameters.Add("@ActionHistoryDebtorNumber", SqlDbType.VarChar).Value = txtDebtor.Text;
                    insertCMD.Parameters.Add("@ActionHistoryPerson", SqlDbType.VarChar).Value = actionHistoryPerson;
                    insertCMD.Parameters.Add("@ActionHistoryDate", SqlDbType.VarChar).Value = txtActionDate.Text;
                    insertCMD.Parameters.Add("@ActionHistoryTime", SqlDbType.VarChar).Value = actionHistoryTime;
                    insertCMD.Parameters.Add("@WorkerTimestamp", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    insertCMD.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = Environment.UserName.ToString().ToUpper();

                    insertCMD.Parameters.Clear();
                }
            }
            cnSQL.Close();
        }


        public void DeleteAccount(string Table, Int64 id)
        {
            //delete current row ID from the database
            deleteSQL = $"DELETE FROM {Table} WHERE ID = @ID";

            using (cnSQL = new SqlConnection(sqlConnStr))
            {
                cnSQL.Open();
                using (deleteCMD = new SqlCommand(deleteSQL, cnSQL))
                {
                    deleteCMD.Parameters.Add("@ID", SqlDbType.BigInt).Value = id;
                    deleteCMD.ExecuteNonQuery();
                }
            }
            cnSQL.Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            //delete the current account from the database
            DeleteAccount(dataTable, accountID);
            //store account info to done table
            StoreToDoneTable();
            //get remaining number of accounts in the workers table
            GetRemainingTotals();
            //get the next account to be worked
            PopulateForm();
            //update the account that is populated
            UpdateCurrentAccount(accountID);
        }
    }
}
