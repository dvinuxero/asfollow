Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Imports Entity
Imports Business

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class ActionService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function ping() As String
        Return "pong"
    End Function

    <WebMethod()> _
    Public Overloads Function addActionByNameAndUnitId(name As String, unitId As Long) As action
        Dim action As action = New ActionBuilder().createAction(name, unitId)

        ActionBO.getInstance().addAction(action)

        Return action
    End Function

    <WebMethod()> _
    Public Overloads Function updateAction(name As String, unitId As Long, actionId As Long) As Boolean
        Dim updatedAction As action = New ActionBuilder().createAction(name, unitId, actionId)

        ActionBO.getInstance().updateAction(updatedAction)

        Return True
    End Function

    <WebMethod()> _
    Public Overloads Function deleteAction(actionId As Long) As Boolean
        Dim deletedAction As action = New ActionBuilder().createAction()
        deletedAction.action_id = actionId

        ActionBO.getInstance().deleteAction(deletedAction)

        Return True
    End Function

    <WebMethod()> _
    Public Overloads Function getActionByName(name As String) As action
        Return ActionBO.getInstance().getActionByName(name)
    End Function

    <WebMethod()> _
    Public Overloads Function getActionsByUnitId(unitId As Long) As List(Of action)
        Return ActionBO.getInstance().getActionsByUnitId(unitId)
    End Function

End Class