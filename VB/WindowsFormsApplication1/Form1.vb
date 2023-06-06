Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraBars
Imports DevExpress.XtraPrinting.Preview
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraRichEdit
Imports System.IO
Imports System.Diagnostics

Namespace WindowsFormsApplication1

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private report As XtraReport1

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            report = New XtraReport1()
            Using rpt As ReportPrintTool = New ReportPrintTool(report)
                report.CreateDocument(False)
                AddHandler rpt.PreviewForm.Shown, New EventHandler(AddressOf PreviewForm_Shown)
                rpt.ShowPreviewDialog()
            End Using
        End Sub

        Private Sub PreviewForm_Shown(ByVal sender As Object, ByVal e As EventArgs)
            Dim form As PrintPreviewFormEx = CType(sender, PrintPreviewFormEx)
            Dim item As PrintPreviewBarItem = CType(form.PrintBarManager.GetBarItemByCommand(PrintingSystemCommand.ExportFile), PrintPreviewBarItem)
            Dim control As PopupMenu = CType(CType(item, BarButtonItem).DropDownControl, PopupMenu)
            Dim barItem As BarButtonItem = New BarButtonItem()
            AddHandler barItem.ItemClick, New ItemClickEventHandler(AddressOf barItem_ItemClick)
            barItem.Caption = "DOC File"
            control.AddItem(barItem)
            barItem = New BarButtonItem()
            AddHandler barItem.ItemClick, New ItemClickEventHandler(AddressOf barItem_ItemClick3)
            barItem.Caption = "ODT File"
            control.AddItem(barItem)
        End Sub

        Private Sub barItem_ItemClick3(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            ExportToDOC("odt", DocumentFormat.OpenDocument)
        End Sub

        Private Sub barItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            ExportToDOC("doc", DocumentFormat.Doc)
        End Sub

        Private Sub ExportToDOC(ByVal extension As String, ByVal df As DocumentFormat)
            Dim sfd As SaveFileDialog = New SaveFileDialog()
            sfd.FileName = Environment.CurrentDirectory & "\" & report.ExportOptions.PrintPreview.DefaultFileName & "." & extension
            sfd.Filter = String.Format("{0} File|*.{0}", extension)
            If sfd.ShowDialog() = DialogResult.OK Then
                Using docServer As RichEditDocumentServer = New RichEditDocumentServer()
                    Using ms As MemoryStream = New MemoryStream()
                        report.ExportToRtf(ms, New RtfExportOptions() With {.ExportMode = RtfExportMode.SingleFile})
                        ms.Position = 0
                        docServer.LoadDocument(ms, DocumentFormat.Rtf)
                        docServer.SaveDocument(sfd.FileName, df)
                    End Using
                End Using

                If MessageBox.Show("Would you like to open file exported file?", extension & " export", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Call Process.Start(sfd.FileName)
                End If
            End If
        End Sub
    End Class
End Namespace
