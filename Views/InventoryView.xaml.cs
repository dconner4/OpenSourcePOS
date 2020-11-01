using System.Windows.Controls;

namespace Views
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
        }

        private void DataGrid_OnRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            int x = 0;
        }
    }
}
