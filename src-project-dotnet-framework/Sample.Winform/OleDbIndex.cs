using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Sample.Winform
{
    public partial class OleDbIndex : Form
    {
        public OleDbIndex()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var conn = ConfigurationManager.AppSettings["con.oracle"];
            CreateOleDbCommand("TestStoredProcedure", conn);
            var a = 1;
        }
        private void CreateOleDbCommand(
            string proedurename, string connectionString)
        {
            using (OleDbConnection connection = new
                       OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(proedurename, connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = proedurename;

                    command.Parameters.Add(new OleDbParameter("inxml", OleDbType.VarWChar, 4096)).Value = "1";
                    command.Parameters.Add(new OleDbParameter("outxml", OleDbType.VarWChar, 4096)).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "User Id=system; Password=oracle; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)))";
            string ProviderName = "Oracle.DataAccess.Client";
            //DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);

            using (OracleConnection conn = new OracleConnection(constr))
            {
                try
                {
                    conn.ConnectionString = constr;
                    conn.Open();

                    using (var command = new OracleCommand("TestStoredProcedure", conn))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        //command.CommandText = proedurename;
                        command.Parameters.Add(new OracleParameter("input", OracleDbType.Varchar2, 60000));
                        command.Parameters.Add(new OracleParameter("output", OracleDbType.Clob, 60080)).Direction = ParameterDirection.Output;

                        var aa = command.ExecuteNonQuery();

                        var aaa = command.Parameters[1].Value as Oracle.ManagedDataAccess.Types.OracleClob;
                        MessageBox.Show(aaa.Value.Length.ToString());

                        richTextBox1.Text = aaa.Value;
                        //MessageBox.Show(command.Parameters[1].Value.ToString() + command.Parameters[1].Value.ToString().Length);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    //Console.WriteLine(ex.Message);
                    //Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
