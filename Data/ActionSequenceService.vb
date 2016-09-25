Public Class ActionSequenceService

    Private Shared instance As ActionSequenceService

    Private random As Random

    Private Sub New()
        Me.random = New Random()
    End Sub

    Friend Shared Function getInstance() As ActionSequenceService
        If (instance Is Nothing) Then
            instance = New ActionSequenceService()
        End If

        Return instance
    End Function

    Public Function getNewSequenceId() As Integer
        Return instance.random.Next(1000000, 9999999)
    End Function

End Class
