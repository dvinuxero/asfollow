Public Class TagBuilder

    Private tag As tag

    Public Sub New()
    End Sub

    Public Function createTag() As tag
        Me.tag = New tag()

        Return Me.tag
    End Function

    Public Function createTag(name As String) As tag
        Me.tag = New tag()
        Me.tag.name = name

        Return Me.tag
    End Function

    Public Function createTag(name As String, color As String) As tag
        Me.tag = New tag()
        Me.tag.name = name
        Me.tag.color = color

        Return Me.tag
    End Function

    Public Function createTag(name As String, color As String, tagId As Long) As tag
        Me.tag = New tag()
        Me.tag.name = name
        Me.tag.color = color
        Me.tag.tag_id = tagId

        Return Me.tag
    End Function

End Class
