using DevExpress.Xpf.Core;
using DevExpress.Xpf.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using DevExpress.XtraSpreadsheet.Commands;
using DevExpress.XtraSpreadsheet.Services;
using System;
using System.Windows;

namespace WpfSpreadsheet_CustomCommand
{
    public class CustomService : SpreadsheetCommandFactoryServiceWrapper
    {
        public CustomService(ISpreadsheetCommandFactoryService service)
            : base(service)
        {
        }
        public SpreadsheetControl Control { get; set; }

        public override SpreadsheetCommand CreateCommand(SpreadsheetCommandId id)
        {
            if (id == SpreadsheetCommandId.FormatClearContents || id == SpreadsheetCommandId.FormatClearContentsContextMenuItem)
                return new CustomFormatClearContentsCommand(Control);
            return base.CreateCommand(id);
        }
    }

    public class CustomFormatClearContentsCommand : DevExpress.XtraSpreadsheet.Commands.FormatClearContentsCommand
    {
        public CustomFormatClearContentsCommand(ISpreadsheetControl control) :
            base(control)
        {
        }

        protected override void ExecuteCore()
        {
            MessageBoxResult result = DXMessageBox.Show("Do you want to clear the cell content?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
                base.ExecuteCore();
        }
    }
}
