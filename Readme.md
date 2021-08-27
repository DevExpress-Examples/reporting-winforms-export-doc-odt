<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128600898/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4530)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsFormsApplication1/Form1.cs) (VB: [Form1.vb](./VB/WindowsFormsApplication1/Form1.vb))
* [Program.cs](./CS/WindowsFormsApplication1/Program.cs) (VB: [Program.vb](./VB/WindowsFormsApplication1/Program.vb))
* [XtraReport1.cs](./CS/WindowsFormsApplication1/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/WindowsFormsApplication1/XtraReport1.vb))
<!-- default file list end -->
# How to export an XtraReport document to DOC, DOCX and ODT file formats


<p>While there is no built-in capability to export documents created by XtraReport to *.doc, *.docx or *.odt file formats, you can accomplish this task by means of the <a href="http://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraRichEditRichEditDocumentServertopic"><u>RichEditDocumentServer</u></a> .</p>
<p>The attached sample illustrates how to add custom bar items to the File Export drop down menu and export a report to these file formats using the RichEditDocumentServer.<br><br></p>
<p><strong>P.S. </strong>Starting with version 17.1, export to the <strong>DOCX </strong>format is implemented out of the box. See the <a href="https://documentation.devexpress.com/#XtraReports/DevExpressXtraReportsUIXtraReport_ExportToDocxtopic">XtraReport.ExportToDocx Method</a> help topic for details.</p>

<br/>


