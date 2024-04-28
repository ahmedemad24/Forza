using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
namespace cypos
{
    public static class Global
    {
        public static string ERROR_WRITE_PATH = Application.StartupPath + @"\Errors\";
    }

    class OpenedForms
    {
        public static bool Close()
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "frmLogin" & f.Name != "frmMain")
                   f.Close();
            }
       
                return true;
        }
         
        
           

    }

    class ThisForm
    {
        public static bool Close()
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name == "frmKeyboard" || f.Name == "frmNumberboard" || f.Name == "frmCurrencyboard")
                    f.Close();
            }
            return true;
        }
    }

    public static class ReportValue
    {
        public static string StartDate { get; set; }
        public static string EndDate { get; set; }
        public static string emp { get; set; }
        public static string Terminal { get; set; }
    }

    public static class TaxValue
    {
        public static string TaxType
        {
            get
            {
                string strSQL = "SELECT TOP 1 tax_type FROM tbl_Company";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtTaxType = DataAccess.GetDataTable(strSQL);
                string strValue = dtTaxType.Rows[0].ItemArray[0].ToString();
                return strValue;
            }
        }


        public static string Tax1Name
        {
            get
            {
                string strSQL = "SELECT TOP 1 tax1_name FROM tbl_Company";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtTax1 = DataAccess.GetDataTable(strSQL);
                string strValue = dtTax1.Rows[0].ItemArray[0].ToString();
                return strValue;
            }
        }

        public static string Tax1Rate
        {
            get
            {
                string strSQL = "SELECT TOP 1 tax1_rate FROM tbl_Company";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtTax1 = DataAccess.GetDataTable(strSQL);
                string strValue = dtTax1.Rows[0].ItemArray[0].ToString();
                return strValue;
            }
        }

        public static string Tax2Name
        {
            get
            {
                string strSQL = "SELECT TOP 1 tax2_name FROM tbl_Company";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtTax2 = DataAccess.GetDataTable(strSQL);
                string strValue = dtTax2.Rows[0].ItemArray[0].ToString();
                return strValue;
            }
        }

        public static string Tax2Rate
        {
            get
            {
                string strSQL = "SELECT TOP 1 tax2_rate FROM tbl_Company";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtTax2 = DataAccess.GetDataTable(strSQL);
                string strValue = dtTax2.Rows[0].ItemArray[0].ToString();
                return strValue;
            }
        }

        public static int CalMethod
        {
            get
            {
                string strSQL = "SELECT TOP 1 cal_method FROM tbl_Company";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtCalMethod = DataAccess.GetDataTable(strSQL);
                int iValue =int.Parse(dtCalMethod.Rows[0].ItemArray[0].ToString());
                return iValue;
            }
        }

    }


    public static class Settings
    {
        public static int ItemsPerPage
        {
            get
            {
                string strSQL = "SELECT TOP 1 items_per_page FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                int iValue = int.Parse(dtSettings.Rows[0]["items_per_page"].ToString());
                return iValue;
            }
        }

        public static bool show_item_image
        {
            get
            {
                string strSQL = "SELECT TOP 1 show_item_image FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool booleanValue = bool.Parse(dtSettings.Rows[0]["show_item_image"].ToString());
                return booleanValue;
            }
        }

        public static bool AskTable
        {
            get
            {
                string strSQL = "SELECT TOP 1 ask_table FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool bValue = bool.Parse(dtSettings.Rows[0]["ask_table"].ToString());
                return bValue;
            }
        }

        public static bool AskGuestCount
        {
            get
            {
                string strSQL = "SELECT TOP 1 ask_guest_count FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool bValue = bool.Parse(dtSettings.Rows[0]["ask_guest_count"].ToString());
                return bValue;
            }
        }

        public static bool AskWaiter
        {
            get
            {
                string strSQL = "SELECT TOP 1 ask_waiter FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool bValue = bool.Parse(dtSettings.Rows[0]["ask_waiter"].ToString());
                return bValue;
            }
        }

        public static bool AutoHoldId
        {
            get
            {
                string strSQL = "SELECT TOP 1 auto_hold_id FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool bValue = bool.Parse(dtSettings.Rows[0]["auto_hold_id"].ToString());
                return bValue;
            }
        }

        public static int DefaultDiscount
        {
            get
            {
                string strSQL = "SELECT TOP 1 default_discount_rate FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                int iValue = int.Parse(dtSettings.Rows[0]["default_discount_rate"].ToString());
                return iValue;
            }
        }

        public static int DefaultOrderType
        {
            get
            {
                string strSQL = "SELECT TOP 1 default_order_type FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                int iValue = int.Parse(dtSettings.Rows[0]["default_order_type"].ToString());
                return iValue;
            }
        }

        public static string DefualtOrderTypeDesc
        {
            get
            {
                string strSQL = $"SELECT TOP 1 {(UserInfo.IsArabicLangSelected? "LabelAr" : "LabelEn")} FROM tbl_Settings join tbl_OrderTypes t on default_order_type=t.Id and company_type_id={(int)Company.CompanyType}";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                string iValue = dtSettings.Rows[0][$"{(UserInfo.IsArabicLangSelected ? "LabelAr" : "LabelEn")}"].ToString();
                return iValue;
            }
        }

        public static bool EnableServiceCharge
        {
            get
            {
                string strSQL = "SELECT TOP 1 enable_sc FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["enable_sc"].ToString());
                return Value;
            }
        }

        public static double ServiceChargeRate
        {
            get
            {
                string strSQL = "SELECT TOP 1 sc_rate FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                double dblValue = double.Parse(dtSettings.Rows[0]["sc_rate"].ToString());
                return dblValue;
            }
        }

        public static bool CustomerAfterDO
        {
            get
            {
                string strSQL = "SELECT TOP 1 customer_after_do FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["customer_after_do"].ToString());
                return Value;
            }
        }

        public static bool AutoItemNo
        {
            get
            {
                string strSQL = "SELECT TOP 1 auto_item_no FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["auto_item_no"].ToString());
                return Value;
            }
        }

        public static bool CustomerAfterPO
        {
            get
            {
                string strSQL = "SELECT TOP 1 customer_after_po FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["customer_after_po"].ToString());
                return Value;
            }
        }

        public static bool PreviewBeforePrint
        {
            get
            {
                string strSQL = "SELECT TOP 1 preview_before_print FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["preview_before_print"].ToString());
                return Value;
            }
        }

        public static bool ShowOtAfterBill
        {
            get
            {
                string strSQL = "SELECT TOP 1 show_ot_after FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["show_ot_after"].ToString());
                return Value;
            }
        }
        //Invoice No
        public static string InvoiceNoPrefix
        {
            get
            {
                string strSQL = "SELECT TOP 1 invoice_no_prefix FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                string Value = dtSettings.Rows[0]["invoice_no_prefix"].ToString();
                return Value;
            }
        }

        public static bool ShowLeadingZeros
        {
            get
            {
                string strSQL = "SELECT TOP 1 show_leading_zeros FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["show_leading_zeros"].ToString());
                return Value;
            }
        }

        public static int LeadingZerosCount
        {
            get
            {
                string strSQL = "SELECT TOP 1 zeros_count FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["zeros_count"].ToString());
                return Value;
            }
        }

        public static int StartingInvoiceNo
        {
            get
            {
                string strSQL = "SELECT TOP 1 starting_invoice_no FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["starting_invoice_no"].ToString());
                return Value;
            }
        }

        public static int LastInvoiceAutoNo
        {
            get
            {
                string strSQL = "SELECT ISNULL(MAX(auto_id),'0') AS auto_id FROM tbl_InvoiceNo";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["auto_id"].ToString());
                return Value;
            }
        }

        public static string LastInvoiceId
        {
            get
            {
                string strValue = string.Empty;
                string strSQL = $"select top 1 invoice_id from tbl_InvoiceHeader where shift_id={UserInfo.UserShiftCode} order by invoice_id desc"; 
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                if (dtSettings.Rows.Count != 0)
                {
                    strValue = dtSettings.Rows[0]["invoice_id"].ToString();
                }
                return strValue;
            }
        }

        //Kot No

        public static string KotNoPrefix
        {
            get
            {
                string strSQL = "SELECT TOP 1 kot_no_prefix FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                string Value = dtSettings.Rows[0]["kot_no_prefix"].ToString();
                return Value;
            }
        }

        public static bool KotLeadingZeros
        {
            get
            {
                string strSQL = "SELECT TOP 1 kot_leading_zeros FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["kot_leading_zeros"].ToString());
                return Value;
            }
        }

        public static int KotZerosCount
        {
            get
            {
                string strSQL = "SELECT TOP 1 kot_zeros_count FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["kot_zeros_count"].ToString());
                return Value;
            }
        }

        public static int StartingKotNo
        {
            get
            {
                string strSQL = "SELECT TOP 1 kot_starting_no FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["kot_starting_no"].ToString());
                return Value;
            }
        }

        public static int LastKotAutoNo
        {
            get
            {
                string strSQL = "SELECT ISNULL(MAX(auto_id),'0') AS auto_id FROM tbl_KotNo";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["auto_id"].ToString());
                return Value;
            }
        }


        public static int LastHoldAutoNo
        {
            get
            {
                string strSQL = "SELECT ISNULL(MAX(auto_id),'0') AS auto_id FROM tbl_HoldNo";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["auto_id"].ToString());
                return Value;
            }
        }

        public static int LastItemAutoNo
        {
            get
            {
                string strSQL = "SELECT ISNULL(max(id),'0') AS auto_id FROM tbl_Item";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                int Value = int.Parse(dtSettings.Rows[0]["auto_id"].ToString());
                return Value;
            }
        }

        public static string InvoicePrinter
        {
            get
            {
                string strSQL = "SELECT invoice_printer FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                string strValue = dtSettings.Rows[0]["invoice_printer"].ToString();
                return strValue;
            }
        }

        public static string KotPrinter
        {
            get
            {
                string strSQL = "SELECT kot_printer FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                string strValue = dtSettings.Rows[0]["kot_printer"].ToString();
                return strValue;
            }
        }

        public static bool PrintKotAfterHold
        {
            get
            {
                string strSQL = "SELECT TOP 1 print_kot_after_hold FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["print_kot_after_hold"].ToString());
                return Value;
            }
        }

        public static bool ViewKotB4Print
        {
            get
            {
                string strSQL = "SELECT TOP 1 kot_view_before_print FROM tbl_Settings";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                bool Value = bool.Parse(dtSettings.Rows[0]["kot_view_before_print"].ToString());
                return Value;
            }
        }

    }

    public static class Company
    {
        public static string Logo
        {
            get
            {
                string strSQL = "SELECT TOP 1 logo FROM tbl_Company";
                DataAccess.ExecuteSQL(strSQL);
                DataTable dtSettings = DataAccess.GetDataTable(strSQL);
                string strLogo = dtSettings.Rows[0]["logo"].ToString();
                return strLogo;
            }
        }
        public static CompanyTypeEnum CompanyType
        {
            get
            {
                var CompanyType = DataAccess.ExecuteScalarSQL("select isNull(company_type_id ,0) from tbl_Company");
                return (CompanyTypeEnum)CompanyType;
            }
        }

        public static List<OrderType> OrderTypes
        {
            get
            {
                var orderTypes = DataAccess.GetDataTable($"select * from tbl_OrderTypes where company_type_id={(int)CompanyType}");
                return orderTypes.AsEnumerable().Select(a => new OrderType
                {
                    Id = a.Field<int>("id"),
                    Name = a.Field<string>("name"),
                    LabelEn = a.Field<string>("LabelEn"),
                    LabelAr = a.Field<string>("LabelAr"),
                    company_type_id = a.Field<int>("company_type_id"),
                    SVGLogo = a.Field<string>("SVGLogo")
                }).ToList();
            }
        }


    }
    public class OrderType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LabelEn { get; set; }
        public string LabelAr { get; set; }
        public int company_type_id { get; set; }
        public string SVGLogo { get; set; }
    }

    public enum CompanyTypeEnum
    {
        Restaurant = 1,
        MaintenanceCenter,
        Mart
    }

    public static class Miscellaneous
    {
        public static int TableOrderCount(int tableId)
        {
            string strSQL = "SELECT COUNT(id) AS order_count FROM tbl_TempHeader WHERE table_id='" + tableId +"'";
            DataAccess.ExecuteSQL(strSQL);
            DataTable dtSettings = DataAccess.GetDataTable(strSQL);
            int COUNT = int.Parse(dtSettings.Rows[0]["order_count"].ToString());
            return COUNT;
        }
    }

}
