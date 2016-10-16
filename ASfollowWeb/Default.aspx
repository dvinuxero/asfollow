<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="ASfollowWeb._Default" %>
<%@ Import Namespace="ASfollowWeb" %>

<!DOCTYPE html>

<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASfollow - De la siguiente manera</title>
    <link rel="stylesheet" type="text/css" href="/data/css/ASfollowWeb.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="centralContent">
        
        <asp:Button runat="server" ID="btnGoToActions" style="display:none;" OnClick="btnGoToActions_Click" CommandArgument="" />
        <asp:HiddenField runat="server" ID="unitIdHidden" value="" />

        <%For Each unit As Entity.unit In AllServices.getInstance().getUnits()%>
            <div class="boxResume" onclick="document.getElementById('unitIdHidden').value='<%=unit.unit_id.ToString()%>';document.getElementById('<%= btnGoToActions.ClientID%>').click()">
                <table>
                    <tr class="boxResume-rowInit">
                        <td><%=unit.name.ToUpper()%></td>
                    </tr>
                    <tr>
                        <td><img class="boxResume-picUrl" src="<%=AllServices.getInstance().getPicUrlByUnitType(unit.type_id) %>" /></td>
                    </tr>
                    <tr class="boxResume-rowEnd">
                        <td>$<%=AllServices.getInstance().getTotalAmountByUnitId(unit.unit_id)%></td>
                    </tr>
                </table>
            </div>
        <%Next%>

        <asp:Button runat="server" ID="btnShareInfo" CssClass="shareInfo" OnClick="shareInfo_Click" Text=""/>
    </div>
    </form>
</body>
</html>
