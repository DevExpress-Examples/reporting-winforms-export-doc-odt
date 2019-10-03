using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraBars;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting.Preview.Native;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using System.IO;
using System.Diagnostics;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }
        XtraReport1 report;
        private void button1_Click(object sender, EventArgs e) {
            report = new XtraReport1();
            using (ReportPrintTool rpt = new ReportPrintTool(report)) {
                report.CreateDocument(false);
                rpt.PreviewForm.Shown += new EventHandler(PreviewForm_Shown);
                rpt.ShowPreviewDialog();
            }
        }

        void PreviewForm_Shown(object sender, EventArgs e) {
            PrintPreviewFormEx form = (PrintPreviewFormEx)sender;
            PrintPreviewBarItem item = (PrintPreviewBarItem)form.PrintBarManager.GetBarItemByCommand(PrintingSystemCommand.ExportFile);
            PopupMenu control = (PopupMenu)((DevExpress.XtraBars.BarButtonItem)(item)).DropDownControl;
            BarButtonItem barItem = new BarButtonItem();
            barItem.ItemClick += new ItemClickEventHandler(barItem_ItemClick);
            barItem.Caption = "DOC File";
            control.AddItem(barItem);

            barItem = new BarButtonItem();
            barItem.ItemClick += new ItemClickEventHandler(barItem_ItemClick3);
            barItem.Caption = "ODT File";
            control.AddItem(barItem);
        }

        void barItem_ItemClick3(object sender, ItemClickEventArgs e) {
            ExportToDOC("odt", DocumentFormat.OpenDocument);
        }

        void barItem_ItemClick(object sender, ItemClickEventArgs e) {
            ExportToDOC("doc", DocumentFormat.Doc);

        }

        private void ExportToDOC(string extension, DocumentFormat df) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = Environment.CurrentDirectory + "\\" + report.ExportOptions.PrintPreview.DefaultFileName + "." + extension;
            sfd.Filter = String.Format("{0} File|*.{0}", extension);
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                using (RichEditDocumentServer docServer = new RichEditDocumentServer())
                using (MemoryStream ms = new MemoryStream()) {
                    report.ExportToRtf(ms, new RtfExportOptions() { ExportMode = RtfExportMode.SingleFile });
                    ms.Position = 0;
                    docServer.LoadDocument(ms, DocumentFormat.Rtf);
                    docServer.SaveDocument(sfd.FileName, df);
                }
                if (MessageBox.Show("Would you like to open file exported file?", extension + " export", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                    Process.Start(sfd.FileName);
                }
            }
        }

    }
}
