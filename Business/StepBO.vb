﻿Imports Entity
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

    Public Sub updateStep(updatedStep As [step])
        StepDAO.getInstance().updateStep(updatedStep)
    End Sub

    Public Sub setStepChecked(stepId As Long)
        StepDAO.getInstance().setStepChecked(stepId)
    End Sub

    Public Sub deleteStep(deletedStep As [step])
        StepDAO.getInstance().deleteStep(deletedStep)
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

    Public Function getStepsUrgentsByActionId(actionId As Long) As List(Of [step])
        Return StepDAO.getInstance().getStepsUrgentsByActionId(actionId)
    End Function

    Public Sub refreshSteps()
        StepDAO.getInstance().refreshSteps()
    End Sub

End Class
