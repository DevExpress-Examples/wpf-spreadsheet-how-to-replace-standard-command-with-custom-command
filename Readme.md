# WPF Spreadsheet - How to replace a standard command with a custom one


This example demonstrates how to modify the functionality of the existing SpreadsheetControl command used to clear the selected cell content.
All commands in the SpreadsheetControl are created using the command factory service. You can substitute the default command factory service with its descendant to create a custom command in place of the default command.

Follow the steps below.

1. Create a custom command class inherited from the command you wish to replace. In this example, it is **DevExpress.XtraSpreadsheet.Commands.FormatClearContentsCommand**. Override the **ExecuteCore** method to specify actions that the command should perform.
2. Create a class inherited from [SpreadsheetCommandFactoryServiceWrapper](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraSpreadsheet.Services.SpreadsheetCommandFactoryServiceWrapper.class) to replace the default command service. In this class, override the [CreateCommand](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraSpreadsheet.Services.SpreadsheetCommandFactoryServiceWrapper.CreateCommand.method) method to substitute the default **FormatClearContents** and **FormatClearContentsContextMenuItem** commands with the newly created custom command. 
3. Create a custom service instance and use the [SpreadsheetControl.ReplaceService](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Spreadsheet.SpreadsheetControl.ReplaceService~T~.method) method to replace the default service with the custom one. Note that due to WPF Spreadsheet implementation specifics, it is necessary to replace the built-in service **after the control is completely loaded**.