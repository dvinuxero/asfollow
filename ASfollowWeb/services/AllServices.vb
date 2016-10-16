Imports Entity
Imports ASfollowWeb

Public Class AllServices

    Private Shared instance As AllServices

    Protected asfollowService As ASfollowService.ASfollowServiceSoapClient
    Protected actionService As ActionService.ActionServiceSoapClient
    Protected stepService As StepService.StepServiceSoapClient
    Protected tagService As TagService.TagServiceSoapClient
    Protected unitService As UnitService.UnitServiceSoapClient

    Private Sub New()
        asfollowService = New ASfollowService.ASfollowServiceSoapClient()
        actionService = New ActionService.ActionServiceSoapClient()
        stepService = New StepService.StepServiceSoapClient()
        tagService = New TagService.TagServiceSoapClient()
        unitService = New UnitService.UnitServiceSoapClient()
    End Sub

    Public Shared Function getInstance() As AllServices
        If (instance Is Nothing) Then
            instance = New AllServices()
        End If

        Return instance
    End Function

    Public Function getUnits() As List(Of unit)
        Dim listOfUnits As List(Of unit) = New List(Of unit)
        Dim units As UnitService.ArrayOfUnit = unitService.getUnits()

        If (units IsNot Nothing) Then
            For Each unit In units
                listOfUnits.Add(New UnitBuilder().createUnit(unit.name, unit.type_id, unit.unit_id))
            Next
        End If

        Return listOfUnits
    End Function

    Public Function getPicUrlByUnitType(typeId As Long) As String
        Dim unitType As UnitService.unit_type = unitService.getUnitType(typeId)

        Return unitType.picture_url
    End Function

    Public Function getActions(unitId As Long) As List(Of action)
        Dim listOfActions As List(Of action) = New List(Of action)
        Dim actions As ASfollowWeb.ActionService.ArrayOfAction = actionService.getActionsByUnitId(unitId)

        If (actions IsNot Nothing) Then
            For Each action In actions
                listOfActions.Add(New ActionBuilder().createAction(action.name, action.unit_id, action.action_id))
            Next
        End If

        Return listOfActions
    End Function

    Public Function getSteps(actionId As Long) As List(Of [step])
        Dim listOfSteps As List(Of [step]) = New List(Of [step])
        Dim steps As ASfollowWeb.StepService.ArrayOfStep = stepService.getStepsByActionId(actionId)

        If (steps IsNot Nothing) Then
            For Each [step] In steps
                Dim params As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
                params.Add("step_id", [step].step_id)
                params.Add("tag_id", [step].tag_id)
                params.Add("priority", [step].priority)
                params.Add("cron", [step].cron)
                params.Add("amount", [step].amount)
                params.Add("checked", [step].checked)
                params.Add("description", [step].description)
                listOfSteps.Add(New StepBuilder().createStep([step].action_id, [step].text, params))
            Next
        End If

        Return listOfSteps
    End Function

    Public Function getTagColor(tagId As Long) As String
        Dim tag As ASfollowWeb.TagService.tag = tagService.getTag(tagId)
        Dim rgbArr As String() = tag.color.Split(",")
        Dim r As String = Hex(Integer.Parse(rgbArr(0)))
        Dim g As String = Hex(Integer.Parse(rgbArr(1)))
        Dim b As String = Hex(Integer.Parse(rgbArr(2)))

        If (r.Length < 2) Then
            While (r.Length < 2)
                r = "0" & r
            End While
        End If

        If (g.Length < 2) Then
            While (g.Length < 2)
                g = "0" & g
            End While
        End If

        If (b.Length < 2) Then
            While (b.Length < 2)
                b = "0" & b
            End While
        End If

        Return "#" & r & g & b
    End Function

    Public Function getStepTextAndAmount([step] As [step]) As String
        Dim lineText As String = [step].text

        If ([step].amount <> 0) Then
            lineText = lineText & " ($" & [step].amount.ToString() & ")"
        End If

        Return lineText.ToUpper()
    End Function

    Public Sub setStepChecked(stepId As Long)
        stepService.setStepChecked(stepId)
    End Sub

    Public Function getTotalAmountByUnitId(unitId As Long) As Integer
        Return unitService.getTotalAmountByUnitId(unitId)
    End Function

    Public Function getTotalAmount() As Integer
        Return unitService.getTotalAmount()
    End Function

    Public Sub shareInfo(actionShare As Integer)
        Select Case actionShare
            Case 0
                asfollowService.shareInfoMonthly()
            Case 1
                asfollowService.shareInfoUrgent()
        End Select
    End Sub

    Public Sub refreshSteps()
        stepService.refreshSteps()
    End Sub

    Public Function getUnitName(unitId As Long) As String
        Dim unit As UnitService.unit = unitService.getUnit(unitId)

        Return unit.name.ToUpper()
    End Function

End Class
