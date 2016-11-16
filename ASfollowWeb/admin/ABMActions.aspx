<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ABMActions.aspx.vb" Inherits="ASfollowWeb.ABMActions" %>
<%@ Import Namespace="ASfollowWeb" %>

<!DOCTYPE html>

<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASfollow - De la siguiente manera - Agregar accion</title>
    <link rel="stylesheet" type="text/css" href="/data/css/General.css" />
</head>
<body>
    <a href="/Actions.aspx?unit_id=<%=Request.QueryString.Get("unit_id") %>">Volver</a>

    <form id="form1" runat="server">
        <input type="hidden" name="action" value="postAction" />
        <input type="hidden" name="unitId" value="<%=Request.QueryString.Get("unit_id")%>" />
        <div class="addAction"><b>Agregar una nueva accion sobre la unidad <%=AllServices.getInstance().getUnitName(Long.Parse(Request.QueryString.Get("unit_id")))%></b></div>

        <div class="centralContent">
            <table>
                <tr>
                    <td>Nombre:</td>
                    <td><input type="text" name="actionName" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><input name="addUnit" type="submit" value="Agregar accion" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
