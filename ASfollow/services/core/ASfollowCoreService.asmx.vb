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
Public Class ASfollowCoreService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function ping() As String
        Return "pong"
    End Function

    <WebMethod()> _
    Public Overloads Function addActionByName(name As String, unitId As Long) As String
        Dim action As action = New ActionBuilder().createAction(name, unitId)

        ActionBO.getInstance().addAction(action)

        Return action.action_id
    End Function

    <WebMethod()> _
    Public Overloads Function getActionByName(name As String) As action
        Dim action As action = Nothing

        For Each actionAux As action In ActionBO.getInstance().getActions()
            If (actionAux.name.ToLower().Equals(name.ToLower())) Then
                action = actionAux
            End If
        Next

        Return action
    End Function

End Class