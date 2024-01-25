using DevExpress.Printing.Core.PdfExport.Metafile;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cypos.Forms
{
    public partial class XtraForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private ResourceManager resManager;

        public XtraForm1()
        {
            InitializeComponent();

            resManager = new ResourceManager(typeof(XtraForm1));

            gridControl.DataSource = CustomerGridFill();
            BindingList<Customer> dataSource = CustomerGridFill();
            gridControl.DataSource = dataSource;
            bsiRecordsCount.Caption = "RECORDS : " + dataSource.Count;
            cardView1.Columns["ServiceAmount"].Width = 10;

            //btnNew.AccessibleName = "New";
            //btnNew.Caption = "New";
        }

        public BindingList<Customer> CustomerGridFill()
        {
            try
            {
            string strSQL = "SELECT cs.*,r.RegionName,IsNull(r.ServiceAmount, 0) ServiceAmount FROM tbl_Customer as cs " +
                "left join  tbl_region as r on  r.RegionId = cs.RegionId WHERE cs.IsDeleted = 0 ";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtCustomer = DataAccess.GetDataTable(strSQL);
            var result = dtCustomer.AsEnumerable();

            List<Customer> studentList = new List<Customer>();
            studentList = (from DataRow dr in dtCustomer.Rows
                           select new Customer()
                           {
                               ID = int.Parse(dr["id"].ToString()),
                               Name = dr["name"].ToString(),
                               Email = dr["email"].ToString(),
                               City = dr["city"].ToString(),
                               Address = dr["Address"].ToString(),
                               Phone = dr["phone"].ToString(),
                               RegionName = dr["RegionName"].ToString(),
                               RegionId = int.Parse(dr["RegionId"].ToString()),
                               ServiceAmount = decimal.Parse(dr["ServiceAmount"].ToString())
                           }).ToList();

            var bindingList = new BindingList<Customer>(studentList);

            return bindingList;

            }
            catch (Exception)
            {

                throw;
            }
        }

        void bbiPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowRibbonPrintPreview();
        }
        //public BindingList<Customer> GetDataSource()
        //{
        //    BindingList<Customer> result = new BindingList<Customer>();
        //    result.Add(new Customer()
        //    {
        //        ID = 1,
        //        Name = "ACME",
        //        Address = "2525 E El Segundo Blvd",
        //        City = "El Segundo",
        //        State = "CA",
        //        ZipCode = "90245",
        //        Phone = "(310) 536-0611"
        //    });
        //    result.Add(new Customer()
        //    {
        //        ID = 2,
        //        Name = "Electronics Depot",
        //        Address = "2455 Paces Ferry Road NW",
        //        City = "Atlanta",
        //        State = "GA",
        //        ZipCode = "30339",
        //        Phone = "(800) 595-3232"
        //    });
        //    return result;
        //}
        public class Customer
        {
            [Key, Display(AutoGenerateField = false)]
            public int ID { get; set; }
            [Required]
            public string Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string RegionName { get; set; }
            [Display(AutoGenerateField = false)]
            public int RegionId { get; set; }
            public decimal ServiceAmount { get; set; }
            [Display(AutoGenerateField = false)]
            public bool IsDeleted { get; set; }
            public string Phone { get; set; }
        }
        private bool flag;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            flag = !flag;
            UserInfo.IsArabicLangSelected = !UserInfo.IsArabicLangSelected;
            string cultureCode = UserInfo.IsArabicLangSelected ? "ar-AR" : "en-EN"; 

            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureCode);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureCode);

            XtraForm1 x = new XtraForm1();
            //this.FormClosed += (s, args) => x.ShowDialog();
            this.Hide();
            this.FormClosing += (s, args) => x.ShowDialog();
            this.Close();
            //this.FormClosed += (s, args) => this.Close()
        }

        private void UpdateUIForCulture()
        {
            // Update DevExpress controls
            foreach (Control c in this.Controls)
            {
                UpdateDevExpressControlText(c);
            }

            // Refresh the form to apply changes
            this.Refresh();
        }

        private void UpdateDevExpressControlText(Control control)
        {

            control.Text = resManager.GetString(control.Name, Thread.CurrentThread.CurrentUICulture);

            // Recursively update child controls
            foreach (Control child in control.Controls)
            {
                UpdateDevExpressControlText(child);
            }
        }
    }
}