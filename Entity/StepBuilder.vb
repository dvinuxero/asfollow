Public Class StepBuilder

    Private [step] As [step]

    Public Sub New()
    End Sub

    Public Function createStep() As [step]
        Me.[step] = New [step]()

        Return Me.[step]
    End Function

    Public Function createStep(text As String) As [step]
        Me.[step] = New [step]()
        Me.[step].text = text

        Return Me.[step]
    End Function

    Public Function addText(text As String) As [step]
        If (Me.[step] IsNot Nothing) Then
            Me.[step].text = text
        End If

        Return Me.[step]
    End Function

End Class
