Public Class StepBuilder

    Private [step] As [step]

    Public Sub New()
    End Sub

    Public Function createStep() As [step]
        Me.[step] = New [step]()

        Return Me.[step]
    End Function

    Public Function createStep(actionId As Integer, text As String, Optional params As Object = Nothing) As [step]
        Me.step = New [step]()
        Me.step.action_id = actionId
        Me.step.text = text

        If (params IsNot Nothing) Then
            If (TypeOf params Is Dictionary(Of String, Object)) Then
                params = CType(params, Dictionary(Of String, Object))
            Else
                params = getDictionaryOfParams(params)
            End If

            If (params.ContainsKey("step_id")) Then
                If (params("step_id") <> 0 And params("step_id") IsNot Nothing) Then
                    Me.step.step_id = CType(params("step_id"), Long)
                End If
            End If

            If (params.ContainsKey("tag_id")) Then
                If (params("tag_id") <> 0 And params("tag_id") IsNot Nothing) Then
                    Me.step.tag_id = CType(params("tag_id"), Long)
                End If
            End If

            If (params.ContainsKey("priority")) Then
                If (params("priority") <> 0 And params("priority") IsNot Nothing) Then
                    Me.step.priority = CType(params("priority"), Integer)
                End If
            End If

            If (params.ContainsKey("cron")) Then
                If (params("cron") <> "" And params("cron") IsNot Nothing) Then
                    Me.step.cron = CType(params("cron"), String)
                End If
            End If

            If (params.ContainsKey("amount")) Then
                If (params("amount") <> 0 And params("amount") IsNot Nothing) Then
                    Me.step.amount = CType(params("amount"), Integer)
                End If
            End If

            If (params.ContainsKey("checked")) Then
                If (params("checked") <> "" And params("checked") IsNot Nothing) Then
                    Me.step.checked = CType(params("checked"), String)
                End If
            End If

            If (params.ContainsKey("description")) Then
                If (params("description") <> "" And params("description") IsNot Nothing) Then
                    Me.step.description = CType(params("description"), String)
                End If
            End If
        End If

        Return Me.step
    End Function

    Private Function getDictionaryOfParams(params As Object) As Dictionary(Of String, Object)
        Dim dicOfParams As Dictionary(Of String, Object) = New Dictionary(Of String, Object)

        dicOfParams.Add("step_id", params.step_id)
        dicOfParams.Add("tag_id", params.tag_id)
        dicOfParams.Add("priority", params.priority)
        dicOfParams.Add("cron", params.cron)
        dicOfParams.Add("amount", params.amount)
        dicOfParams.Add("checked", params.checked)
        dicOfParams.Add("description", params.description)

        Return dicOfParams
    End Function

End Class
