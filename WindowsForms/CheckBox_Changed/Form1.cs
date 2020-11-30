using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckBox_Changed
{
    public partial class Form1 : Form
    {
        SfDataGrid sfDataGrid1; 
        public Form1()
        {
            InitializeComponent();
            sfDataGrid1 = new SfDataGrid();
            sfDataGrid1.Dock = DockStyle.Fill;
            this.Controls.Add(sfDataGrid1);
            sfDataGrid1.AllowFiltering = true;
            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "OrderID" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerName" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Country" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ShipCity" });
            sfDataGrid1.Columns.Add(new GridCheckBoxColumn() { MappingName = "IsClosed" , AllowCheckBoxOnHeader=true  });
            sfDataGrid1.Columns.Add(new GridCheckBoxColumn() { MappingName = "IsClosed1", AllowCheckBoxOnHeader = true });
            OrderInfoCollection orderInfoCollection = new OrderInfoCollection();
            sfDataGrid1.DataSource = orderInfoCollection.Orders;
            this.sfDataGrid1.CellCheckBoxClick += sfDataGrid1_CellCheckBoxClick;
            this.sfDataGrid1.CurrentCellActivating += sfDataGrid1_CurrentCellActivating;
        }

        private void sfDataGrid1_CurrentCellActivating(object sender, CurrentCellActivatingEventArgs e)
        {
            if (e.DataColumn.GridColumn.MappingName == "IsClosed1")
                e.Cancel = true;
        }

        private void sfDataGrid1_CellCheckBoxClick(object sender, CellCheckBoxClickEventArgs e)
        {
            if (e.Column.MappingName == "IsClosed1")
                e.Cancel = true;

            if (e.Column.MappingName == "IsClosed" && e.Record != null )
            {
                (e.Record as OrderInfo).IsClosed1 = e.NewValue == CheckState.Checked;
            }
        }
    }
}
