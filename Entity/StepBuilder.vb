Public Class StepBuilder

    Private [step] As [Step]

    Public Sub New()
    End Sub

    Public Function createStep() As [Step]
        Me.[step] = New [Step]()

        Return Me.[step]
    End Function

    Public Function createStep(text As String) As [Step]
        Me.[step] = New [Step]()
        Me.[step].text = text

        Return Me.[step]
    End Function

    Public Function addText(text As String) As [Step]
        If (Me.[step] IsNot Nothing) Then
            Me.[step].text = text
        End If

        Return Me.[step]
    End Function

End Class
