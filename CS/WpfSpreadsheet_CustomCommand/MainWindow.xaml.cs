using DevExpress.Xpf.Core;
using DevExpress.XtraSpreadsheet.Services;
using System;

namespace WpfSpreadsheet_CustomCommand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void spreadsheetControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => {
                SubstituteService();
            }), System.Windows.Threading.DispatcherPriority.Render);
        }

        private void SubstituteService()
        {
            ISpreadsheetCommandFactoryService service = (ISpreadsheetCommandFactoryService)spreadsheetControl.GetService(typeof(ISpreadsheetCommandFactoryService));
            CustomService customService = new CustomService(service);
            spreadsheetControl.ReplaceService<ISpreadsheetCommandFactoryService>(customService);
            customService.Control = spreadsheetControl;
        }
    }
}
