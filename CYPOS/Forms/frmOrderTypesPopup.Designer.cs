
namespace cypos.Forms
{
    partial class frmOrderTypesPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderTypesPopup));
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // stackPanel1
            // 
            this.stackPanel1.AutoSize = true;
            this.stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.stackPanel1.Location = new System.Drawing.Point(0, 0);
            this.stackPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.stackPanel1.Name = "stackPanel1";
            this.stackPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.stackPanel1.Size = new System.Drawing.Size(282, 227);
            this.stackPanel1.TabIndex = 0;
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("working-tools-svgrepo-com", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.working-tools-svgrepo-com"))));
            this.svgImageCollection1.Add("wallet-money-finance-cash-business-payment-dollar-svgrepo-com", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.wallet-money-finance-cash-business-payment-dollar-svgrepo-com" +
            ""))));
            this.svgImageCollection1.Add("plastic-cards-svgrepo-com", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.plastic-cards-svgrepo-com"))));
            this.svgImageCollection1.Add("delivery-movement-svgrepo-com", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.delivery-movement-svgrepo-com"))));
            this.svgImageCollection1.Add("shopping-cart-svgrepo-com", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.shopping-cart-svgrepo-com"))));
            this.svgImageCollection1.Add("restaurant", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.restaurant"))));
            this.svgImageCollection1.Add("order-food-svgrepo-com", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.order-food-svgrepo-com"))));
            // 
            // XtraForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(282, 227);
            this.Controls.Add(this.stackPanel1);
            this.Name = "XtraForm2";
            this.Text = "XtraForm2";
            this.Load += new System.EventHandler(this.frmOrderTypesPopup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}