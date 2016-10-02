Imports Entity

Public Class DataBase

    Private Shared instance As DataBase

    Friend connectionDataModel As ASfollowEntities

    Private Sub New()
        Me.connectionDataModel = New ASfollowEntities()
    End Sub

    Friend Shared Function getInstance() As DataBase
        If (instance Is Nothing) Then
            instance = New DataBase()
        End If

        Return instance
    End Function

End Class
