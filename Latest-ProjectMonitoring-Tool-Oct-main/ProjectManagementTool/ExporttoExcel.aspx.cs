using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Runtime.InteropServices;

namespace ProjectManagementTool
{
    public partial class ExporttoExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = xlWorkBook.Sheets[1];

            xlWorkSheet.Cells[1, 1] = "http://csharp.net-informations.com";
            xlWorkSheet.Cells[2, 1] = "Adding picture in Excel File";

            xlWorkSheet.Cells[1, 2] = "@C:\\pic.JPG";
            //xlWorkSheet.Shapes.AddPicture(@"C:\pic.JPG", MsoTriState.msoFalse, MsoTriState.msoCTrue, 50, 50, 300, 45);

            xlWorkBook.SaveAs("//csharp.net-informations.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
            xlWorkBook.Close(true);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlApp);
        }
    }
}