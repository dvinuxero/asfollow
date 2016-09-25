Imports Entity

Public Class ActionDAO

    Private Shared instance As ActionDAO

    Private actions As List(Of Action)

    Private Sub New()
        actions = New List(Of Action)
    End Sub

    Public Shared Function getInstance() As ActionDAO
        If (instance Is Nothing) Then
            instance = New ActionDAO()
        End If

        Return instance
    End Function

    Public Sub addAction(newAction As Action)
        newAction.setNewId(ActionSequenceService.getInstance().getNewSequenceId())
        actions.Add(newAction)
    End Sub

    Public Function getActions() As List(Of Action)
        Return actions
    End Function

End Class
