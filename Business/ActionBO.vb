Imports Entity
Imports Data

Public Class ActionBO

    Private Shared instance As ActionBO

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As ActionBO
        If (instance Is Nothing) Then
            instance = New ActionBO()
        End If

        Return instance
    End Function

    Public Sub addAction(newAction As action)
        ActionDAO.getInstance().addAction(newAction)
    End Sub

    Public Function getActions() As List(Of action)
        Return ActionDAO.getInstance().getActions()
    End Function

End Class
