<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/144005916/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830546)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF Spreadsheet - How to replace a standard command with a custom Command

This example demonstrates how to modify the functionality of the existing SpreadsheetControl command used to clear the selected cell content.
All commands in the SpreadsheetControl are created using the command factory service. You can substitute the default command factory service with its descendant to create a custom command in place of the default command.

## Implementation Details

Follow the steps below.

1. Create a custom command class inherited from the command you wish to replace. In this example, it is **DevExpress.XtraSpreadsheet.Commands.FormatClearContentsCommand**. Override the **ExecuteCore** method to specify actions that the command should perform.
2. Create a class inherited from [SpreadsheetCommandFactoryServiceWrapper](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraSpreadsheet.Services.SpreadsheetCommandFactoryServiceWrapper.class) to replace the default command service. In this class, override the [CreateCommand](https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraSpreadsheet.Services.SpreadsheetCommandFactoryServiceWrapper.CreateCommand.method) method to substitute the default **FormatClearContents** and **FormatClearContentsContextMenuItem** commands with the newly created custom command. 
3. Create a custom service instance and use the [SpreadsheetControl.ReplaceService](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Spreadsheet.SpreadsheetControl.ReplaceService~T~.method) method to replace the default service with the custom one. Note that due to WPF Spreadsheet implementation specifics, it is necessary to replace the built-in service **after the control is completely loaded**.

## Files to Review

CS | VB
------------ | -------------
[MainWindow.xaml](./CS/WpfSpreadsheet_CustomCommand/MainWindow.xaml) | [MainWindow.xaml](./VB/WpfSpreadsheet_CustomCommand/MainWindow.xaml)
[MainWindow.xaml.cs](./CS/WpfSpreadsheet_CustomCommand/MainWindow.xaml.cs) | [MainWindow.xaml.vb](./VB/WpfSpreadsheet_CustomCommand/MainWindow.xaml.vb)
[**CustomCommandService.cs**](./CS/WpfSpreadsheet_CustomCommand/CustomCommandService.cs) | [**CustomCommandService.vb**](./VB/WpfSpreadsheet_CustomCommand/CustomCommandService.vb)

## Documentation

* [Commands in Rich Text Editor for WPF](https://docs.devexpress.com/WPF/9108/controls-and-libraries/rich-text-editor/commands)
