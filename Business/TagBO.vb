Imports Entity
Imports Data

Public Class TagBO

    Private Shared instance As TagBO

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As TagBO
        If (instance Is Nothing) Then
            instance = New TagBO()
        End If

        Return instance
    End Function

    Public Sub addTag(newTag As tag)
        TagDAO.getInstance().addTag(newTag)
    End Sub

    Public Function getTags() As List(Of tag)
        Return TagDAO.getInstance().getTags()
    End Function

End Class
