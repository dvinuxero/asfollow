Public Class ActionBuilder

    Private action As action

    Public Sub New()
    End Sub

    Public Function createAction() As action
        Me.action = New action()

        Return Me.action
    End Function

    Public Function createAction(name As String, unitId As Long) As action
        Me.action = New action()
        Me.action.name = name
        Me.action.unit_id = unitId

        Return Me.action
    End Function

    Public Function addName(name As String) As action
        If (Me.action IsNot Nothing) Then
            Me.action.name = name
        End If

        Return Me.action
    End Function

End Class
