# How to set the GridCheckBoxColumn value based on the value of another GridCheckBoxColumn in WinForms DetailsViewDataGrid (SfDataGrid)?

How to set the GridCheckBoxColumn value based on the value of another GridCheckBoxColumn in WinForms DetailsViewDataGrid (SfDataGrid)?


# About the sample

In SfDataGrid.DetailViewDataGrid, you can set the value for a checkbox in one GridCheckBoxColumn when enable or disabling it in another GridCheckBoxColum using SfDataGrid.CellCheckBoxClick and SfDataGrid.CurrentCellActivating events.

```c#
FirstLevelNestedGrid.CellCheckBoxClick += FirstLevelNestedGrid_CellCheckBoxClick;
FirstLevelNestedGrid.CurrentCellActivating += FirstLevelNestedGrid_CurrentCellActivating;
private void FirstLevelNestedGrid_CurrentCellActivating(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellActivatingEventArgs e)
{
    if (e.DataColumn.GridColumn.MappingName == "IsClosed1")
        e.Cancel = true;
}

private void FirstLevelNestedGrid_CellCheckBoxClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellCheckBoxClickEventArgs e)
{
    var records = ((e.OriginalSender as DetailsViewDataGrid).DataSource) as List<OrderDetails>;
    var grid = e.OriginalSender as DetailsViewDataGrid;
    if (e.Record == null && e.Column.MappingName == "IsClosed")
    {
        if (e.NewValue.ToString() == "Checked")
        {
            (grid.Columns["IsClosed1"] as GridCheckBoxColumn).GetType().GetProperty("HeaderState", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(grid.Columns["IsClosed1"] as GridCheckBoxColumn, CheckState.Checked);
        }
        else
        {
            (grid.Columns["IsClosed1"] as GridCheckBoxColumn).GetType().GetProperty("HeaderState", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(grid.Columns["IsClosed1"] as GridCheckBoxColumn, CheckState.Unchecked);
        }

        for (int i = 0; i < records.Count; i++)
        {
            if (e.NewValue.ToString() == "Checked")
            {
                (records[i] as OrderDetails).IsClosed1 = true;
            }
            else
            {
                (records[i] as OrderDetails).IsClosed1 = false;
            }
        }
    }
    if (e.Column.MappingName == "IsClosed1")
        e.Cancel = true;

    if (e.Column.MappingName == "IsClosed" && e.Record != null)
    {
        (e.Record as OrderDetails).IsClosed1 = e.NewValue == CheckState.Checked;
    }
}
```
## Requirements to run the demo
 Visual Studio 2015 and above versions
