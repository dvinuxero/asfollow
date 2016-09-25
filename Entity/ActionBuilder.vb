Public Class ActionBuilder

    Private action As Action

    Public Sub New()
    End Sub

    Public Function createAction() As Action
        Me.action = New Action()

        Return Me.action
    End Function

    Public Function createAction(name As String) As Action
        Me.action = New Action()
        Me.action.name = name

        Return Me.action
    End Function

    Public Function createAction(name As String, steps As List(Of [Step])) As Action
        Me.action = New Action()
        Me.action.name = name
        Me.action.steps = steps

        Return Me.action
    End Function

    Public Function addName(name As String) As Action
        If (Me.action IsNot Nothing) Then
            Me.action.name = name
        End If

        Return Me.action
    End Function

    Public Function addSteps(steps As List(Of [Step])) As Action
        If (Me.action IsNot Nothing) Then
            Me.action.steps = steps
        End If

        Return Me.action
    End Function

    Public Function addStep([step] As [Step]) As Action
        If (Me.action IsNot Nothing) Then
            If (Me.action.steps IsNot Nothing) Then
                Me.action.steps = New List(Of [Step])
            End If

            Me.action.steps.Add([step])
        End If

        Return Me.action
    End Function

End Class
