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

    Public Function getActions() As List(Of action)
        Return DataBase.getInstance().connectionDataModel.action.ToList()
    End Function

End Class
