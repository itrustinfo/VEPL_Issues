﻿<%@ Page Title="" Language="C#" MasterPageFile="~/_master_pages/modal.Master" AutoEventWireup="true" CodeBehind="preview-issue-documents.aspx.cs" Inherits="ProjectManagementTool._modal_pages.preview_issue_documents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="modal_master_head" runat="server">
    <style type="text/css">
        .aclass th {
            background:Green; font-weight:bold; color: white
        }

        .aclass{border: 1px solid black;}
.aclass tr td {background:white; font-weight:bold; color: black}
.aclass
{
    overflow :auto;
}
   .tabpanlecss{
      overflow :scroll;
   }
 .TabStyle .ajax__tab_header
        {
            cursor: pointer;
            background-color: #f1f1f1;
            font-size: 14px;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            height: 36px;
            border-bottom: 1px solid #bebebe;
            width:100%;
        }
  .TabStyle .ajax__tab_active .ajax__tab_tab .ajax__tab_outer
        {
            border: 1px solid;
            border-color: #bebebe #bebebe #e1e1e1 #bebebe;
            background-color: #e1e1e1;
            padding: 10px;
            border-bottom: none;
        }
  .TabStyle .ajax__tab_active .ajax__tab_tab .ajax__tab_outer:hover
        {
            border: 1px solid;
            border-color: #bebebe #bebebe #e1e1e1 #bebebe;
            background-color: #e1e1e1;
            padding: 10px;
            border-bottom: none;
        }
          .TabStyle .ajax__tab_tab
        {
            border: 1px solid;
            border-color: #e1e1e1 #e1e1e1 #bebebe #e1e1e1;
            background-color: #f1f1f1;
            color: #777777;
            cursor: pointer;
            text-decoration: none;
            padding: 10px;
        }
        .TabStyle .ajax__tab_tab:hover
        {
            border: 1px solid;
            border-color: #bebebe #bebebe #e1e1e1 #bebebe;
            background-color: #e1e1e1;
            color: #777777;
            cursor: pointer;
            text-decoration: none;
            padding: 10px;
            border-bottom: none;
        }
        .TabStyle .ajax__tab_active .ajax__tab_tab, .TabStyle .ajax__tab_tab, .TabStyle .ajax__tab_header .ajax__tab_tab
        {
            margin: 0px 0px 0px 0px;
        }
  .TabStyle .ajax__tab_body
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #bebebe;
            border-top: none;
            padding: 5px;
            background-color: #e1e1e1;
            width:100%;
        }

    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="modal_master_body" runat="server">
    <div class="container-fluid" >
        <div class="row">
            <div class="col-sm-12" style="overflow-y:hidden">

                  <form runat="server">
                      
                     <asp:GridView ID="GrdIssueImages" runat="server"  AutoGenerateColumns="False" EmptyDataText="No Data Found" Width="100%" Height="650px" CssClass="table table-bordered" OnRowDataBound="GrdIssueImages_RowDataBound"  AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="1"  >
                         <PagerSettings Mode="NextPrevious" FirstPageText="First" PreviousPageText="&lt;&lt;"
            NextPageText="&gt;&gt;" LastPageText="Last" Position="Top" />
                         <Columns>
                         </Columns>
                     </asp:GridView>
                   
                  </form>
            </div>
        </div>
    </div>
</asp:Content>
