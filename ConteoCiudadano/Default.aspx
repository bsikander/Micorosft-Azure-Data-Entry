<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ConteoCiudadano._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 32px;
            height: 33px;
        }
        .style2
        {
            width: 33px;
            height: 33px;
        }
        .style3
        {
            width: 32px;
            height: 31px;
        }
        .style4
        {
            width: 40px;
            height: 32px;
        }
        .style5
        {
            width: 30px;
            height: 32px;
        }
        .style6
        {
            width: 53px;
            height: 27px;
        }
        .style7
        {
            width: 75px;
            height: 25px;
        }
        .style8
        {
            width: 49px;
            height: 27px;
        }
        .style9
        {
            width: 52px;
            height: 26px;
        }
        .style10
        {
            height: 26px;
        }
        .style11
        {
            width: 77px;
            height: 25px;
        }
        .style12
        {
            width: 67px;
            height: 19px;
        }
        .style13
        {
            width: 73px;
            height: 26px;
        }
    </style>
    <style type="text/css">

.magnifyarea{ /* CSS to add shadow to magnified image. Optional */
box-shadow: 5px 5px 7px #818181;
-webkit-box-shadow: 5px 5px 7px #818181;
-moz-box-shadow: 5px 5px 7px #818181;
filter: progid:DXImageTransform.Microsoft.dropShadow(color=#818181, offX=5, offY=5, positive=true);
background: white;
}

</style>

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.4/jquery.min.js"></script>

<script type="text/javascript" src="featuredimagezoomer.js">

    /***********************************************
    * Featured Image Zoomer (w/ adjustable power)- By Dynamic Drive DHTML code library (www.dynamicdrive.com)
    * This notice MUST stay intact for legal use
    * Visit Dynamic Drive at http://www.dynamicdrive.com/ for this script and 100s more
    ***********************************************/

</script>
<script src="Scripts/featuredimagezoomer.js" type="text/javascript"></script>
<script type="text/javascript">

    jQuery(document).ready(function ($) {

        var largeimage1 = document.getElementById('<%= Image1.ClientID %>').src;
        $('#<%= Image1.ClientID %>').addimagezoom({
            zoomrange: [10, 10],
            magnifiersize: [600, 500],
            magnifierpos: 'right',
            cursorshade: true,
            cursorshadecolor: 'pink',
            cursorshadeopacity: 0.3,
            cursorshadeborder: '1px solid red',
            largeimage: largeimage1 //<-- No comma after last option
        })





    })

</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <%--<asp:Label ID ="lbltest" runat="server" Text="test"></asp:Label>--%>
    <h2>
        BIENVENIDO
    </h2>
    <table>
    <tr>
    <td rowspan = 15 valign="top">
        <asp:Image ID="Image1" runat="server"  Width="15%" />
      
        </td>
    <td>
        <img alt="" class="style1" src="Images/Partidos/PAN.JPG" /></td><td>
        <asp:TextBox ID="txtPAN" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style2" src="Images/Partidos/PRI.JPG" /></td><td>
        <asp:TextBox ID="txtPRI" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style2" src="Images/Partidos/PRD.JPG" /></td><td>
        <asp:TextBox ID="txtPRD" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style3" src="Images/Partidos/Verde.JPG" /></td><td>
        <asp:TextBox ID="txtVerde" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style2" src="Images/Partidos/PT.JPG" /></td><td>
        <asp:TextBox ID="txtPT" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style4" src="Images/Partidos/MC.JPG" /></td><td>
        <asp:TextBox ID="txtMC" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style5" src="Images/Partidos/NA.JPG" /></td><td>
        <asp:TextBox ID="txtNA" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style6" src="Images/Partidos/PRI_VERDE.JPG" /></td><td>
        <asp:TextBox ID="txtPRI_Verde" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style7" src="Images/Partidos/PRD_PT_MC.JPG" /></td><td>
        <asp:TextBox ID="txtPRD_PT_MC" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style8" src="Images/Partidos/PRD_PT.JPG" /></td><td>
        <asp:TextBox ID="txtPRD_PT" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style9" src="Images/Partidos/PRD_MC.JPG" /></td><td>
        <asp:TextBox ID="txtPRD_MC" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td class="style10">
            <img class="style9" src="Images/Partidos/PT_MC.JPG" /></td><td class="style10">
        <asp:TextBox ID="txtPT_MC" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style11" src="Images/Partidos/NR.JPG" /></td><td>
        <asp:TextBox ID="txtNR" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style12" src="Images/Partidos/VN.JPG" /></td><td>
        <asp:TextBox ID="txtVN" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
        <tr><td>
            <img class="style13" src="Images/Partidos/TOTAL.JPG" /></td><td>
        <asp:TextBox ID="txtTotal" runat="server" Width="26px">0</asp:TextBox>
        </td></tr>
    
    </table>
    <asp:Button ID="btnSubmit" runat="server" Text="Procesar" 
    onclick="btnSubmit_Click" />
&nbsp;<p>
        &nbsp;</p>
        
</asp:Content>
