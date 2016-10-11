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
Public Class StepService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function ping() As String
        Return "pong"
    End Function

    <WebMethod()> _
    Public Overloads Function addStep(actionId As Integer, text As String, tagId As Integer, priority As Integer, cron As String, amount As Integer, checked As String, description As String) As [step]
        Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        params.Add("tag_id", tagId)
        params.Add("priority", priority)
        params.Add("cron", cron)
        params.Add("amount", amount)
        params.Add("checked", checked)
        params.Add("description", description)

        Dim [step] As [step] = New StepBuilder().createStep(actionId, text, params)

        StepBO.getInstance().addStep([step])

        Return [step]
    End Function

    <WebMethod()> _
    Public Overloads Function addStepByActionIdAndText(actionId As Integer, text As String) As [step]
        Dim [step] As [step] = New StepBuilder().createStep(actionId, text)

        StepBO.getInstance().addStep([step])

        Return [step]
    End Function

    <WebMethod()> _
    Public Overloads Function updateStep(stepId As Long, actionId As Integer, text As String, tagId As Integer, priority As Integer, cron As String, amount As Integer, checked As String, description As String) As Boolean
        Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        params.Add("step_id", stepId)
        params.Add("tag_id", tagId)
        params.Add("priority", priority)
        params.Add("cron", cron)
        params.Add("amount", amount)
        params.Add("checked", checked)
        params.Add("description", description)

        Dim updatedStep As [step] = New StepBuilder().createStep(actionId, text, params)

        StepBO.getInstance().updateStep(updatedStep)

        Return True
    End Function

    <WebMethod()> _
    Public Overloads Function deleteStep(stepId As Long) As Boolean
        Dim deletedStep As [step] = New StepBuilder().createStep()
        deletedStep.step_id = stepId

        StepBO.getInstance().deleteStep(deletedStep)

        Return True
    End Function

    <WebMethod()> _
    Public Overloads Function getStepByStepId(stepId As Integer) As [step]
        Return StepBO.getInstance().getStepByStepId(stepId)
    End Function

    <WebMethod()> _
    Public Overloads Function getStepsByActionId(actionId As Integer) As List(Of [step])
        Return StepBO.getInstance().getStepsByActionId(actionId)
    End Function

    <WebMethod()> _
    Public Function getStepsByTagId(tagId As Integer) As List(Of [step])
        Return StepBO.getInstance().getStepsByTagId(tagId)
    End Function

End Class