using cypos.Class.ForControlsDX;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Threading.Tasks;

namespace cypos.Forms.EmployeeFrms
{
    public partial class FrmEmployeesCRUD : DevExpress.XtraEditors.XtraForm
    {
        public FrmEmployeesCRUD()
        {
            InitializeComponent();
        }

        private int? selectedEmployeeId = null;

        private void FrmEmployeesCRUD_Load(object sender, System.EventArgs e)
        {
            string query = "SELECT * from tbl_JobTitles WHERE isDeleted = 0;";
            DataTable dt = DataAccess.GetDataTable(query);

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string name = row["name"].ToString();
                cmbxJobTitle.Properties.Items.Add(new CMBXEdit(id, name));
            }

            loadDataForGridView();
        }

        private void loadDataForGridView()
        {
            var queryForSelectEmployees = $@"Select e.id, e.name, e.address, e.phone_number, e.jobTitle_id,
                                            j.name [Job title], e.hireDate, e.id_number, e.salary, e.isDeleted
                                            FROM tbl_Employees e
                                            Join tbl_JobTitles j on e.jobTitle_id = j.id 
                                            WHERE e.IsDeleted = 0";
            DataTable dt = DataAccess.GetDataTable(queryForSelectEmployees);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["isDeleted"].Visible = false;
            gridView1.Columns["jobTitle_id"].Visible = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            string phone_number = txtPhoneNum.Text;
            int selectedJobtitleId = cmbxJobTitle.SelectedItem is CMBXEdit selectedListItem ? selectedListItem.Value : 0;
            DateTime hireDate = dtHireDate.DateTime;
            string idNumber = txtIdNum.Text;
            decimal salary = decimal.Parse(spSalary.Value.ToString());

            if (!string.IsNullOrEmpty(name) || selectedJobtitleId <= 0)
            {
                string query;
                if (selectedEmployeeId.HasValue)
                {
                    // Update existing employee
                    query = $@"UPDATE tbl_Employees 
                            SET name = '{name}' ,
                                address = '{address}',
                                phone_number = '{phone_number}',
                                jobTitle_id = {selectedJobtitleId},
                                hireDate = '{hireDate}',
                                id_number = '{idNumber}',
                                salary = {salary}
                            WHERE ID = {selectedEmployeeId.Value}";
                    DataAccess.ExecuteSQL(query);
                    XtraMessageBox.Show("Updated Successfully", "Success");
                }
                else
                {
                    // Insert new employee
                    query = $@"Insert INTO tbl_Employees 
                            (name, address, phone_number, jobTitle_id, hireDate, id_number, salary) 
                            VALUES('{name}', '{address}', '{phone_number}', {selectedJobtitleId}, 
                                   '{hireDate.ToString("dd-MM-yyyy")}', '{idNumber}', {salary})";
                    DataAccess.ExecuteSQL(query);
                    XtraMessageBox.Show("Added Successfully", " Success");
                }

                txtName.Text = string.Empty;
                txtName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtPhoneNum.Text = string.Empty;
                cmbxJobTitle.Reset();
                dtHireDate.Reset();
                txtIdNum.Text = string.Empty;
                spSalary.Value = 0;
                selectedEmployeeId = null;
                loadDataForGridView();
            }
            else
            {
                XtraMessageBox.Show("There are some date Required", "Information");
                txtName.Focus();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var gridView = sender as GridView;
            if (gridView == null) return;

            if (gridView.IsDataRow(e.FocusedRowHandle))
            {
                var row = gridView.GetDataRow(e.FocusedRowHandle);
                if (row != null)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string name = row["NAME"].ToString();
                    string address = row["address"].ToString();
                    string phone_number = row["phone_number"].ToString();
                    int jobTitleId = int.Parse(row["jobTitle_id"].ToString());
                    string jobTitleName = GetJobTitleNameById(jobTitleId);
                    DateTime hireDate = DateTime.Parse(row["hireDate"].ToString());
                    string id_number = row["id_number"].ToString();
                    decimal salary = decimal.Parse(row["salary"].ToString());

                    txtName.EditValue = name;
                    txtAddress.Text = address;
                    txtPhoneNum.Text = phone_number;

                    foreach (var item in cmbxJobTitle.Properties.Items)
                    {
                        var cmbxItem = item as CMBXEdit;
                        if (cmbxItem != null && cmbxItem.Value == jobTitleId)
                        {
                            cmbxJobTitle.SelectedItem = cmbxItem;
                            break;
                        }
                    }

                    dtHireDate.EditValue = hireDate;
                    txtIdNum.Text = id_number;
                    spSalary.Value = salary;
                    selectedEmployeeId = id;
                }
            }
        }

        private string GetJobTitleNameById(int jobTitleId)
        {
            string query = $"SELECT name FROM tbl_JobTitles WHERE id = {jobTitleId} AND isDeleted = 0;";
            DataTable dt = DataAccess.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["name"].ToString();
            }
            return string.Empty;
        }

        private async void FrmEmployeesCRUD_Shown(object sender, EventArgs e)
        {
            loadDataForGridView();
            await Task.Delay(100);
            gridView1.ClearSelection();
        }
    }
}