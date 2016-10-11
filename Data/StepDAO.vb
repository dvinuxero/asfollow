Imports Entity

Public Class StepDAO

    Private Shared instance As StepDAO

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As StepDAO
        If (instance Is Nothing) Then
            instance = New StepDAO()
        End If

        Return instance
    End Function

    Public Sub addStep(newStep As [step])
        newStep.step_id = SequenceService.getInstance().getNextId(GetType([step]))
        DataBase.getInstance().connectionDataModel.step.Add(newStep)
        DataBase.getInstance().connectionDataModel.SaveChanges()
    End Sub

    Public Sub updateStep(updatedStep As [step])
        Dim oldStep As [step] = DataBase.getInstance().connectionDataModel.step.Find(updatedStep.step_id)

        If (oldStep IsNot Nothing) Then
            oldStep.amount = updatedStep.amount
            oldStep.action_id = updatedStep.action_id
            oldStep.checked = updatedStep.checked
            oldStep.cron = updatedStep.cron
            oldStep.description = updatedStep.description
            oldStep.priority = updatedStep.priority
            oldStep.tag_id = updatedStep.tag_id
            oldStep.text = updatedStep.text
            DataBase.getInstance().connectionDataModel.SaveChanges()
        End If
    End Sub

    Public Sub deleteStep(deletedStep As [step])
        Dim oldStep As [step] = DataBase.getInstance().connectionDataModel.step.Find(deletedStep.step_id)

        If (oldStep IsNot Nothing) Then
            DataBase.getInstance().connectionDataModel.step.Remove(oldStep)
            DataBase.getInstance().connectionDataModel.SaveChanges()
        End If
    End Sub

    Public Function getStepByStepId(stepId As Integer) As [step]
        Try
            Dim resultStep = (From s In DataBase.getInstance().connectionDataModel.step Select s.step_id, s.action_id, s.tag_id, s.amount, s.checked, s.cron, s.description, s.priority, s.text Where step_id = stepId).First()

            If (resultStep IsNot Nothing) Then
                Return New StepBuilder().createStep(resultStep.action_id, resultStep.text, resultStep)
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

    Public Function getStepsByActionId(actionId As Integer) As List(Of [step])
        Try
            Dim resultsStep = (From s In DataBase.getInstance().connectionDataModel.step Select s.step_id, s.action_id, s.tag_id, s.amount, s.checked, s.cron, s.description, s.priority, s.text Where action_id = actionId).ToList()

            If (resultsStep IsNot Nothing) Then
                If (resultsStep.Count > 0) Then
                    Dim listOfSteps As List(Of [step]) = New List(Of [step])
                    For Each resultStep In resultsStep
                        listOfSteps.Add(New StepBuilder().createStep(resultStep.action_id, resultStep.text, resultStep))
                    Next

                    Return listOfSteps
                End If
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

    Public Function getStepsByTagId(tagId As Integer) As List(Of [step])
        Try
            Dim resultsStep = (From s In DataBase.getInstance().connectionDataModel.step Select s.step_id, s.action_id, s.tag_id, s.amount, s.checked, s.cron, s.description, s.priority, s.text Where tag_id = tagId).ToList()

            If (resultsStep IsNot Nothing) Then
                If (resultsStep.Count > 0) Then
                    Dim listOfSteps As List(Of [step]) = New List(Of [step])
                    For Each resultStep In resultsStep
                        listOfSteps.Add(New StepBuilder().createStep(resultStep.action_id, resultStep.text, resultStep))
                    Next

                    Return listOfSteps
                End If
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

    Public Function getStepsShareablesByActionId(actionId As Long) As List(Of [step])
        Try
            Dim resultsStep = (From s In DataBase.getInstance().connectionDataModel.step Select s.step_id, s.action_id, s.tag_id, s.amount, s.checked, s.cron, s.description, s.priority, s.text Where action_id = actionId And cron = "Y" And checked = "N").ToList()

            If (resultsStep IsNot Nothing) Then
                If (resultsStep.Count > 0) Then
                    Dim listOfSteps As List(Of [step]) = New List(Of [step])
                    For Each resultStep In resultsStep
                        listOfSteps.Add(New StepBuilder().createStep(resultStep.action_id, resultStep.text, resultStep))
                    Next

                    Return listOfSteps
                End If
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

End Class
