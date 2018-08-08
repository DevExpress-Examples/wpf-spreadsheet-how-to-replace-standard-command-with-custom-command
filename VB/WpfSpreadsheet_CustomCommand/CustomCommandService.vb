Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Spreadsheet
Imports DevExpress.XtraSpreadsheet
Imports DevExpress.XtraSpreadsheet.Commands
Imports DevExpress.XtraSpreadsheet.Services
Imports System
Imports System.Windows

Namespace WpfSpreadsheet_CustomCommand
    Public Class CustomService
        Inherits SpreadsheetCommandFactoryServiceWrapper

        Public Sub New(ByVal service As ISpreadsheetCommandFactoryService)
            MyBase.New(service)
        End Sub
        Public Property Control() As SpreadsheetControl

        Public Overrides Function CreateCommand(ByVal id As SpreadsheetCommandId) As SpreadsheetCommand
            If id Is SpreadsheetCommandId.FormatClearContents OrElse id Is SpreadsheetCommandId.FormatClearContentsContextMenuItem Then
                Return New CustomFormatClearContentsCommand(Control)
            End If
            Return MyBase.CreateCommand(id)
        End Function
    End Class

    Public Class CustomFormatClearContentsCommand
        Inherits DevExpress.XtraSpreadsheet.Commands.FormatClearContentsCommand

        Public Sub New(ByVal control As ISpreadsheetControl)
            MyBase.New(control)
        End Sub

        Protected Overrides Sub ExecuteCore()
            Dim result As MessageBoxResult = DXMessageBox.Show("Do you want to clear the cell content?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning)
            If result = MessageBoxResult.Yes Then
                MyBase.ExecuteCore()
            End If
        End Sub
    End Class
End Namespace
