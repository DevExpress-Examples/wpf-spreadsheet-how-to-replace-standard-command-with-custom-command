Imports DevExpress.Xpf.Core
Imports DevExpress.XtraSpreadsheet.Services
Imports System

Namespace WpfSpreadsheet_CustomCommand
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits ThemedWindow

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub spreadsheetControl_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
            Dispatcher.BeginInvoke(New Action(Sub()
                SubstituteService()
            End Sub), System.Windows.Threading.DispatcherPriority.Render)
        End Sub

        Private Sub SubstituteService()
            Dim service As ISpreadsheetCommandFactoryService = DirectCast(spreadsheetControl.GetService(GetType(ISpreadsheetCommandFactoryService)), ISpreadsheetCommandFactoryService)
            Dim customService As New CustomService(service)
            spreadsheetControl.ReplaceService(Of ISpreadsheetCommandFactoryService)(customService)
            customService.Control = spreadsheetControl
        End Sub
    End Class
End Namespace
