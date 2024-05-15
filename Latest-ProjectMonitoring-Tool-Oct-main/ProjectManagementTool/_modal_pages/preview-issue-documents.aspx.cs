using ProjectManager.DAL;
using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;
using System.Web.Configuration;

namespace ProjectManagementTool._modal_pages
{
    public partial class preview_issue_documents : System.Web.UI.Page
    {
        DBGetData getdata = new DBGetData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "CLOSE", "<script language='javascript'>parent.location.href=parent.location.href;</script>");
            }
            else
            {
                Session["issue_status_preview"] = "yes";
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["IssueUID"] != null)
                    {
                        DataSet ds = getdata.GetUploadedIssueImages(Request.QueryString["IssueUID"]);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GrdIssueImages.DataSource = null;
                            GrdIssueImages.DataBind();

                            ImageField img = new ImageField();
                            img.HeaderText = "Issue Attached Images";
                            img.DataImageUrlField = "IssueImage";//Your Column Name Representing the image.
                            
                            GrdIssueImages.Columns.Add(img);

                            GrdIssueImages.DataSource = ds;
                            GrdIssueImages.DataBind();
                            GrdIssueImages.HeaderRow.Visible = false;
                        }
                    }
                    else if(Request.QueryString["ViewAllImages"] != null)
                    {

                        DataSet ds = new DataSet();
                        if (Request.QueryString["UserUID"].ToString() == "All")
                        {
                            ds = getdata.GetAllIssueImages(Guid.NewGuid(), "All");
                        }
                        else
                        {
                            ds = getdata.GetAllIssueImages(new Guid(Request.QueryString["UserUID"].ToString()), "NotAll");
                        }

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            GrdIssueImages.DataSource = null;
                            GrdIssueImages.DataBind();

                            ImageField img = new ImageField();
                            img.HeaderText = "Issue Attached Images";
                            img.DataImageUrlField = "IssueImage";//Your Column Name Representing the image.

                            GrdIssueImages.Columns.Add(img);

                            BoundField itr = new BoundField();
                            itr.HeaderText = "Remarks";
                            itr.DataField = "Remarks";
                            GrdIssueImages.Columns.Add(itr);

                            BoundField sdate = new BoundField();
                            sdate.HeaderText = "Issue Date";
                            sdate.DataField = "IssueDate";
                            GrdIssueImages.Columns.Add(sdate);

                            GrdIssueImages.DataSource = ds;
                            GrdIssueImages.DataBind();
                            GrdIssueImages.HeaderRow.Visible = true;
                        }
                    }
                }
               
            }
        }

        protected void GrdIssueImages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;

            }

                if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GrdIssueImages.HeaderRow.Cells[0].Text ="<b>Uploaded Date</b> : " + Convert.ToDateTime(e.Row.Cells[2].Text).ToString("dd/MM/yyyy hh:mm:ss tt") + " ; <b>Remarks </b>: " +  e.Row.Cells[1].Text;
                Image issue_img = (Image) e.Row.Cells[0].Controls[0];
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                string path = Server.MapPath(issue_img.ImageUrl);

                string Extension = Path.GetExtension(path);

                if (Extension == ".jpg" || Extension == ".png" || Extension == ".jpeg" || Extension == ".bmp")
                {
                    string outPath = path.Replace(Extension, "") + "_download" + Extension;
                    getdata.DecryptFile(path, outPath);
                    FileInfo file = new FileInfo(outPath);

                    string fname = "/Documents/Issues/" + file.Name;

                    issue_img.ImageUrl = fname;

                    issue_img.Attributes.Add("width", "100%");
                    issue_img.Attributes.Add("height", "620");
                    //issue_img.Attributes.Add("class", "img-fluid");
                }
                else
                {
                    issue_img.AlternateText = "Not an image file, it can not be displayed, go to next";
                }
                
            }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdIssueImages.PageIndex = e.NewPageIndex;
            PagechangeEvent();



        }


        private void PagechangeEvent()
        {
            if (Request.QueryString["IssueUID"] != null)
            {
                DataSet ds = getdata.GetUploadedIssueImages(Request.QueryString["IssueUID"]);

                GrdIssueImages.DataSource = ds;
                GrdIssueImages.DataBind();
                GrdIssueImages.HeaderRow.Visible = false;
            }
            else if (Request.QueryString["ViewAllImages"] != null)
            {
                DataSet ds = new DataSet();
                if (Request.QueryString["UserUID"].ToString() == "All")
                {
                    ds = getdata.GetAllIssueImages(Guid.NewGuid(), "All");
                }
                else
                {
                    ds = getdata.GetAllIssueImages(new Guid(Request.QueryString["UserUID"].ToString()), "NotAll");
                }
                GrdIssueImages.DataSource = ds;
                GrdIssueImages.DataBind();
                GrdIssueImages.HeaderRow.Visible = true;
            }
        }
    }
}