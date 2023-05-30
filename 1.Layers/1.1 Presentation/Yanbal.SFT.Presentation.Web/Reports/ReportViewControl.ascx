<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="~/Reports/ReportViewControl.ascx" Inherits="Yanbal.SFT.Presentation.Web.Reports.ReportViewControl" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Import Namespace="Yanbal.SFT.Presentation.Web.Source.Models.Report" %>

<% if (Model != null && Model is Yanbal.SFT.Presentation.Web.Source.Models.Report.ReportModel)
   { %>
<form id="FormReport" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" EnablePartialRendering="false"></asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer" runat="server" Width="100%" Height="100%" KeepSessionAlive="true" ProcessingMode="Remote" SizeToReportContent="true" ShowPrintButton="true"
        ShowZoomControl="false" >
    </rsweb:ReportViewer>
</form>

<% } %>
