Imports Entity
Imports Data

Public Class StepBO

    Private Shared instance As StepBO

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As StepBO
        If (instance Is Nothing) Then
            instance = New StepBO()
        End If

        Return instance
    End Function

    Public Sub addStep(newStep As [step])
        StepDAO.getInstance().addStep(newStep)
    End Sub

    Public Function getStepByStepId(stepId As Integer) As [step]
        Return StepDAO.getInstance().getStepByStepId(stepId)
    End Function

    Public Function getStepsByActionId(actionId As Integer) As List(Of [step])
        Return StepDAO.getInstance().getStepsByActionId(actionId)
    End Function

    Public Function getStepsByTagId(tagId As Integer) As List(Of [step])
        Return StepDAO.getInstance().getStepsByTagId(tagId)
    End Function

    Public Function getStepsShareablesByActionId(actionId As Long) As List(Of [step])
        Return StepDAO.getInstance().getStepsShareablesByActionId(actionId)
    End Function

End Class
