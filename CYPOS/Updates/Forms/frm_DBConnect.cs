using cypos.Class;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cypos.Updates.Forms
{
    public partial class frm_DBConnect : Form
    {
        public frm_DBConnect()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(combServerName.Text))
            {
                MessageBox.Show("برجاء ادخال البيانات");
                return;
            }
             
            string ServerName = combServerName.Text;
            string DatabaseName = "CYPOSDb";
            string mstrConStr= "Data Source=" + ServerName + ";Initial Catalog=master";
            string conStr = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName;
            if (comboBox1.SelectedIndex == 1)
            {
                conStr += ";User Id=" + txt_name.Text + ";Password=" + txt_password.Text + ";MultipleActiveResultSets=True;TrustServerCertificate=True;";
                mstrConStr += ";User Id=" + txt_name.Text + ";Password=" + txt_password.Text + ";MultipleActiveResultSets=True;TrustServerCertificate=True;";
            }
            else
            {
                conStr += "; Integrated Security = SSPI";
                mstrConStr += "; Integrated Security = SSPI";
            }

            SqlConnection conn = new SqlConnection(mstrConStr);
            //SqlCommand cmd = new SqlCommand("", conn);
            try
            {
                conn.Open();
                conn.Close();
                conn.Dispose();
            }
            catch
            {
                Messages.ExceptionMessage("invalid server.");
                return;
            }

            try
            {
                DataAccess._ConnectionString = mstrConStr;
                var x = DataAccess.ExecuteScalarSQL($"SELECT count(name) FROM master.sys.databases WHERE ('[' + name + ']' = '{DatabaseName}' OR name = '{DatabaseName}')");
                if (x <= 0 || DataAccess.ExecuteScalarSQL($"SELECT COUNT(*) FROM {DatabaseName}.sys.tables") == 0)  // database doesn't exist or has no tables
                {
                    if(x <= 0) 
                    { 
                        string sql = @"CREATE DATABASE " + DatabaseName + "\n";
                        DataAccess.ExecuteSQL(sql);
                    }

                    string sql2 = System.IO.File.ReadAllText("DatabaseScript.sql");
                    DataAccess._ConnectionString = conStr;
                    try
                    {
                        DataAccess.ExecuteSQL(sql2);
                        MessageBox.Show("تم انشاء قاعدة البيانات بنجاح ");
                    }
                    catch(Exception ex)
                    {

                        string Kill = "DECLARE @DatabaseName nvarchar(50) "
                                + "SET @DatabaseName = N'CYPOS' "
                                + "DECLARE @SQL varchar(max) "
                                + "SELECT @SQL = COALESCE(@SQL, '') + 'Kill ' + Convert(varchar, SPId) + ';' "
                                + "FROM MASTER..SysProcesses "
                                + "WHERE DBId = DB_ID(@DatabaseName) AND SPId<> @@SPId ;"
                                + "EXEC(@SQL) ;" 
                                + "DROP DATABASE CYPOS;";


                        SqlConnection con = new SqlConnection(mstrConStr);
                        SqlCommand cmd = new SqlCommand("", con);
                        cmd.CommandText = Kill;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        con.Dispose();

                        Messages.ExceptionMessage("خطأ اثناء انشاء قاعدة البيانات برجاء الرجوع للمورد.");
                        return;
                    }
                }

                Properties.Settings.Default.CYPOSConnectionString = conStr;
                Properties.Settings.Default.Save();
                #region Connection for Xtra Reports
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings.Clear();
                var conStringSetting = new ConnectionStringSettings("Connection", conStr);
                config.ConnectionStrings.ConnectionStrings.Add(conStringSetting);
                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("connectionStrings");
                #endregion
                DataAccess._ConnectionString = conStr;
                var Connection = new SqlConnection(conStr);
                Connection.Open();
                AppSetting setting = new AppSetting();
                setting.SaveConnectionString("Connection", conStr);
                MessageBox.Show("تم حفظ الاتصال");
                Connection.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(combServerName.Text))
            {
                MessageBox.Show("برجاء ادخال البيانات");
                return;
            }

            try
            {
                string ServerName = combServerName.Text;
                string DatabaseName = "CYPOS";
                string Connection = "Data Source=" + ServerName + ";Initial Catalog=master; Integrated Security = True";
                if (comboBox1.SelectedIndex == 1)
                    Connection += ";User Id=" + txt_name.Text + ";Password=" + txt_password.Text;
                SqlConnection conn = new SqlConnection(Connection);
                SqlCommand cmd = new SqlCommand("", conn);
                string sql = @"CREATE DATABASE " + DatabaseName;
                string sql2 = System.IO.File.ReadAllText("DatabaseScript.sql");
                cmd.CommandText = sql;
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Dispose();
                string NewConnection = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + "; Integrated Security = True";

                Properties.Settings.Default.CYPOSConnectionString=NewConnection;
                Properties.Settings.Default.Save();

                conn = new SqlConnection(NewConnection);
                cmd = new SqlCommand("", conn);

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql2;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Dispose();
                MessageBox.Show("تم انشاء قاعدة البيانات بنجاح , برجاء الضغط على زر حفظ بيانات الاتصال.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //var res = MessageBox.Show("Maybe database has been created before... Do you want drop the database ?", "Drop", MessageBoxButtons.YesNo);
                var res = MessageBox.Show("لربما قد تم انشاء قاعدة البيانات من قبل , هل تريد حذفها ؟  ?", "حذف قاعدة البيانات", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    string ServerName = combServerName.Text;
                    string NewConnection = "Data Source=" + ServerName + ";Initial Catalog=master; Integrated Security = True";
                    
                    Properties.Settings.Default.CYPOSConnectionString = NewConnection;
                    Properties.Settings.Default.Save();
                    string Kill = "DECLARE @DatabaseName nvarchar(50) "
                                + "SET @DatabaseName = N'CYPOS' "
                                + "DECLARE @SQL varchar(max) "
                                + "SELECT @SQL = COALESCE(@SQL, '') + 'Kill ' + Convert(varchar, SPId) + ';' "
                                + "FROM MASTER.SysProcesses "
                                + "WHERE DBId = DB_ID(@DatabaseName) AND SPId<> @@SPId ;"
                                + "EXEC(@SQL) ;"
                                + "DROP DATABASE CYPOS;";
                    SqlConnection conn = new SqlConnection(NewConnection);
                    SqlCommand cmd = new SqlCommand("", conn);
                    cmd.CommandText = Kill;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Dispose();

                    MessageBox.Show("تم حذف قاعدة البيانات بنجاح , يمكنك الآن المحاولة مرة أخرى");
                    //MessageBox.Show("Database dropped successfully, Please try creating again");
                } 
            }
        }

        private void LoadServers(ComboBox comboBox) 
        {
            string serverName = Environment.MachineName;
            RegistryView regView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey RegKey= RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, regView))
            {
                RegistryKey instansKey = RegKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instansKey != null)
                {
                    foreach (var instanceName in instansKey.GetValueNames())
                    {
                        comboBox.Items.Add(serverName + "\\" + instanceName);
                    }
                }
            }
        }

        private void frm_DBConnect_Load(object sender, EventArgs e)
        {
            LoadServers(combServerName);
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                txt_name.Enabled = false;
                txt_password.Enabled = false;
            }
            else
            {
                txt_name.Enabled = true;
                txt_password.Enabled = true;
            }
        }
    }
}
