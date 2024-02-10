using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Windows.Forms;

namespace cypos.Forms
{
    public partial class FrmJobTitlesCRUD : DevExpress.XtraEditors.XtraForm
    {
        public FrmJobTitlesCRUD()
        {
            InitializeComponent();
        }

        private int? selectedJobTitleId = null;

        private void loadDataForGridView()
        {
            var query = "Select * FROM tbl_JobTitles WHERE IsDeleted = 0";
            DataTable dt = DataAccess.GetDataTable(query);
            gridControl1.DataSource = dt;
            gridView1.Columns["id"].Visible = false;
            gridView1.Columns["isDeleted"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (!string.IsNullOrEmpty(name))
            {
                string query;
                if (selectedJobTitleId.HasValue)
                {
                    // Update existing job title
                    query = $@"UPDATE tbl_JobTitles SET NAME = '{name}' WHERE ID = {selectedJobTitleId.Value}";
                    DataAccess.ExecuteSQL(query);
                    XtraMessageBox.Show("Updated Successfully", "Success");
                }
                else
                {
                    // Insert new job title
                    query = $@"Insert INTO tbl_JobTitles (NAME) VALUES('{name}')";
                    DataAccess.ExecuteSQL(query);
                    XtraMessageBox.Show("Added Successfully", " Success");
                }

                txtName.Text = string.Empty;
                selectedJobTitleId = null;
                loadDataForGridView();
            }
            else
            {
                XtraMessageBox.Show("Name Is Required", "Information");
                txtName.Focus();
            }
        }

        private void FrmJobTitlesCRUD_Load(object sender, EventArgs e)
        {
            loadDataForGridView();
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
                    var id = Convert.ToInt32(row["id"]);
                    var name = row["NAME"].ToString();
                    txtName.EditValue = name;
                    selectedJobTitleId = id;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedJobTitleId.HasValue)
            {
                // Confirm before marking as deleted
                var confirmResult = XtraMessageBox.Show("Are you sure to delete this job title?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    string query = $@"UPDATE tbl_JobTitles SET IsDeleted = 1 WHERE ID = {selectedJobTitleId.Value}";
                    DataAccess.ExecuteSQL(query);
                    XtraMessageBox.Show("Job Title Deleted Successfully", "Deleted");

                    // Reset selection and refresh the grid
                    selectedJobTitleId = null;
                    loadDataForGridView();
                }
            }
            else
            {
                XtraMessageBox.Show("Please select a job title to delete.", "Information");
            }
        }
    }
}