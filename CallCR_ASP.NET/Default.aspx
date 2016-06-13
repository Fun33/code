<%@ Page Title="首頁" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="CR" %>
 

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.CrystalReports.Engine" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Shared" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.ReportSource" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        歡迎使用 ASP.NET!
    </h2>
    <p>
        若要進一步了解 ASP.NET，請造訪 <a href="http://www.asp.net" title="ASP.NET 網站">www.asp.net</a>。
    </p>
    <p>
        &nbsp;</p>
    <p>
        您也可以尋找 <a href="http://go.microsoft.com/fwlink/?LinkID=152368"
            title="MSDN ASP.NET 文件">MSDN 上有關 ASP.NET 的文件</a>。
    </p>
      <table class="style1">
        <tr>
            <td>
                Enter Product ID :
            </td>
            <td>
                <asp:TextBox ID="txtProductID" runat="server">
                A00001
                </asp:TextBox>
                </td>
            <td>
                <asp:Button ID="btnReport" runat="server" 
                            Text="Show Report" 
                            onclick="btnReport_Click" 
                            Width="108px" />
                </td>
        </tr>
    </table>
  <div>
  <CR:crystalreportviewer ID="CrystalReportViewer1" 
                          runat="server" AutoDataBind="True"
                          Height="1039px" 
                          ReportSourceID=""                            
                          Width="901px" />
                    
    
    </div>
</asp:Content>
