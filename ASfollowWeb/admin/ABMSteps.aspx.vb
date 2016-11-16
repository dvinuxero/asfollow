Public Class ABMSteps
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim z = Request.Form("actionId")
        Dim a = Request.Form("stepTagId")
        Dim b = Request.Form("stepPriority")
        Dim c = Request.Form("stepAmount")

        If ("POST".Equals(Request.HttpMethod)) Then
            addStep(Integer.Parse(Request.Form("actionId")),
                    Request.Form("stepText"),
                    Integer.Parse(Request.Form("stepTagId")),
                    Integer.Parse(Request.Form("stepPriority")),
                    Request.Form("stepAmount"),
                    Request.Form("stepCron"),
                    Request.Form("stepDescription"))
        End If
    End Sub

    Public Sub addStep(actionId As Integer, text As String, tagId As Integer, priority As Integer, amount As String, cron As String, description As String)
        Dim intAmount = 0

        Try
            intAmount = Integer.Parse(amount)
        Catch ex As FormatException
        End Try

        AllServices.getInstance().addStep(actionId, text, tagId, priority, intAmount, "N", cron, description)

        Response.Redirect("/Actions.aspx?unit_id=" & Request.Form.Get("unitId"))
    End Sub

End Class