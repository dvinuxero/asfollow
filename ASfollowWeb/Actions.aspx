<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Actions.aspx.vb" Inherits="ASfollowWeb.Actions" %>
<%@ Import Namespace="ASfollowWeb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Actions - <%=AllServices.getInstance().getUnitName(Long.Parse(Request.QueryString.Get("unit_id"))) %></title>
    <link rel="stylesheet" type="text/css" href="/data/css/ASfollowWeb.css" />

    <script type="text/ecmascript">
        function setStepChecked(divStepId) {
            if(document.getElementById(divStepId).className.contains("stepChecked")) {
                document.getElementById(divStepId).className = "boxStep stepNotChecked"

            } else {
                document.getElementById(divStepId).className = "boxStep stepChecked"
            }
        }

        function setUnitId() {
            document.getElementById("unitIdHidden").value = '<%=Request.QueryString.Get("unit_id")%>';
        }
    </script>
</head>
<body onload="setUnitId();">
    <a href="/Default.aspx">Volver</a>

    <form id="form1" runat="server">
    <div class="centralContent">

        <asp:Button runat="server" ID="btnSetStepChecked" style="display:none;" OnClick="btnSetStepChecked_Click" CommandArgument="" />
        <asp:Button runat="server" ID="btnAddAction" OnClick="btnAddAction_Click" CommandArgument="" CssClass="generalAction AddActiontPic" ToolTip="Agregar accion" />
        <asp:Button runat="server" ID="btnAddStepFromData" style="display:none;" OnClick="btnAddStepFromData_Click" CommandArgument="" />
        <asp:Button runat="server" ID="btnDeleteStep" style="display:none;" OnClick="btnDeleteStep_Click" CommandArgument="" />
        <asp:HiddenField runat="server" ID="stepIdHidden" value="" />
        <asp:HiddenField runat="server" ID="unitIdHidden" value=""/>
        <asp:HiddenField runat="server" ID="actionIdHidden" value=""/>
        <asp:HiddenField runat="server" ID="actionNameHidden" value=""/>

        <%For Each action As Entity.action In AllServices.getInstance().getActions(Long.Parse(Request.QueryString.Get("unit_id")))%>
            <div class="titleAction"><%= action.name.ToUpper()%>&nbsp;<a href="#" onclick="document.getElementById('unitIdHidden').value='<%=action.unit_id%>';document.getElementById('actionIdHidden').value='<%=action.action_id%>';document.getElementById('actionNameHidden').value='<%=action.name.ToUpper()%>';document.getElementById('<%= btnAddStepFromData.ClientID%>').click();" title="Agregar paso">(+)</a></div>
            <%For Each [step] As Entity.step In AllServices.getInstance().getSteps(action.action_id)%>
                <%If([step].checked is Nothing) %>
                <div id="step_<%=[step].step_id.ToString()%>" class="boxStep stepNotChecked">
                <%else%>
                    <%If([step].checked = "Y") %>
                        <div id="step_<%=[step].step_id.ToString()%>" class="boxStep stepChecked">
                    <%else%>
                        <div id="step_<%=[step].step_id.ToString()%>" class="boxStep stepNotChecked">
                    <%end if%>
                <%end if%>
                    <table>
                        <tr>
                            <td class="textCol"><%=AllServices.getInstance().getStepTextAndAmount([step])%></td>
                            <%If ([step].tag_id <> 0) Then%>
                            <td class="tagCol" style="background-color:<%=AllServices.getInstance().getTagColor([step].tag_id)%>;"></td>
                            <%Else%>
                            <td class="tagCol" style="background-color:#808080"></td>
                            <%end if %>
                            <td class="checkedCol">
                                <%If([step].checked is Nothing) %>
                                <input type="checkbox" onclick="document.getElementById('stepIdHidden').value='<%=[step].step_id.ToString()%>';document.getElementById('<%= btnSetStepChecked.ClientID%>').click();setStepChecked('step_<%=[step].step_id.ToString()%>');"/>
                                <%else%>
                                    <%If([step].checked = "Y") %>
                                        <input type="checkbox" checked="checked" onclick="document.getElementById('stepIdHidden').value='<%=[step].step_id.ToString()%>';document.getElementById('<%= btnSetStepChecked.ClientID%>').click();setStepChecked('step_<%=[step].step_id.ToString()%>');"/>
                                    <%else%>
                                        <input type="checkbox" onclick="document.getElementById('stepIdHidden').value='<%=[step].step_id.ToString()%>';document.getElementById('<%= btnSetStepChecked.ClientID%>').click();setStepChecked('step_<%=[step].step_id.ToString()%>');"/>
                                    <%end if%>
                                <%end if%>
                            </td>
                            <td><a href="#" onclick="document.getElementById('stepIdHidden').value='<%=[step].step_id.ToString()%>';document.getElementById('<%= btnDeleteStep.ClientID%>').click();" title="Borrar paso">Borrar</a></td>
                        </tr>
                        <tr>
                            <td class="descriptionCol" colspan="3"><%=[step].description%></td>
                        </tr>
                    </table>
                </div>
            <%Next%>
        <%Next%>
    </div>
    </form>
</body>
</html>
