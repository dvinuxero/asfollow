Imports Entity

Public Class ActionDAO

    Private Shared instance As ActionDAO

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As ActionDAO
        If (instance Is Nothing) Then
            instance = New ActionDAO()
        End If

        Return instance
    End Function

    Public Sub addAction(newAction As action)
        newAction.action_id = SequenceService.getInstance().getNextId(GetType(action))
        DataBase.getInstance().connectionDataModel.action.Add(newAction)
        DataBase.getInstance().connectionDataModel.SaveChanges()
    End Sub

    Public Function getActionByName(mName As String) As action
        Try
            Dim resultAction = (From a In DataBase.getInstance().connectionDataModel.action Select a.action_id, a.name, a.unit_id Where name = mName).First()

            If (resultAction IsNot Nothing) Then
                Return New ActionBuilder().createAction(resultAction.name, resultAction.unit_id, resultAction.action_id)
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

    Public Function getActionsByUnitId(unitId As Long) As List(Of action)
        Try
            Dim resultsAction = (From a In DataBase.getInstance().connectionDataModel.action Select a.action_id, a.name, a.unit_id Where unit_id = unitId).ToList()

            If (resultsAction IsNot Nothing) Then
                If (resultsAction.Count > 0) Then
                    Dim listOfActions As List(Of action) = New List(Of action)
                    For Each resultAction In resultsAction
                        listOfActions.Add(New ActionBuilder().createAction(resultAction.name, resultAction.unit_id, resultAction.action_id))
                    Next

                    Return listOfActions
                End If
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

End Class
