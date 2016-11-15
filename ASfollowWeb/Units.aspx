<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Units.aspx.vb" Inherits="ASfollowWeb.Units" %>
<%@ Import Namespace="ASfollowWeb" %>

<!DOCTYPE html>

<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASfollow - De la siguiente manera - Agregar unidad</title>
    <!--<link rel="stylesheet" type="text/css" href="/data/css/General.css" />-->
    <link rel="stylesheet" type="text/css" href="/data/css/ASfollowWeb.css" />
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" name="action" value="postUnit" />
        <div class="addUnit">Agregar una nueva unidad</div>

        <div class="centralContent">
            <table>
                <tr>
                    <td>Nombre:</td>
                    <td><input type="text" name="unitName" /></td>
                </tr>
                <tr>
                    <td>Tipo de unidad:</td>
                    <td>
                        <select name="unitType">
                            <%For Each uType As Entity.unit_type In AllServices.getInstance().getUnitTypes()%>
                                <option value="<%=uType.type_id%>"><%=uType.name %></option>
                            <%Next %>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td><input name="addUnit" type="submit" value="Agregar unidad" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
