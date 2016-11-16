<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ABMSteps.aspx.vb" Inherits="ASfollowWeb.ABMSteps" %>

<%@ Import Namespace="ASfollowWeb" %>

<!DOCTYPE html>

<script runat="server">
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASfollow - De la siguiente manera - Agregar paso</title>
    <link rel="stylesheet" type="text/css" href="/data/css/General.css" />
</head>
<body>
    <a href="/Actions.aspx?unit_id=<%=Request.QueryString.Get("unit_id") %>">Volver</a>

    <form id="form1" runat="server">
        <input type="hidden" name="action" value="postStep" />
        <input type="hidden" name="actionId" value="<%=Request.QueryString.Get("action_id")%>" />
        <input type="hidden" name="unitId" value="<%=Request.QueryString.Get("unit_id")%>" />
        <div class="addStep"><b>Agregar un nuevo paso para la accion <%=Request.QueryString.Get("action_name")%></b></div>

        <div class="centralContent">
            <table>
                <tr>
                    <td>Titulo:</td>
                    <td><input type="text" name="stepText" /></td>
                </tr>
                <tr>
                    <td>Tag:</td>
                    <td>
                        <select name="stepTagId">
                            <%For Each mTag As Entity.tag In AllServices.getInstance().getTags()%>
                                <option value="<%=mTag.tag_id%>"><%=mTag.name%></option>
                            <%Next %>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Prioridad:</td>
                    <td>
                        <select name="stepPriority">
                            <%For i As Integer = 1 to 5%>
                                <option value="<%=i%>"><%=Str(i)%></option>
                            <%Next %>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Se repite todo los meses:</td>
                    <td>
                        <select name="stepCron">
                            <option value="Y">Si</option>
                            <option value="N">No</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>Total (opcional): $</td>
                    <td>
                        <input type="text" name="stepAmount" />
                    </td>
                </tr>
                <tr>
                    <td>Descripcion:</td>
                    <td>
                        <textarea name="stepDescription"></textarea>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><input name="addStep" type="submit" value="Agregar paso" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
