Public Class ABMActions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If ("POST".Equals(Request.HttpMethod)) Then
            addAction(Request.Form.Get("actionName"), Request.Form.Get("unitId"))
        End If
    End Sub

    Private Sub addAction(actionName As String, unitId As String)
        Try
            AllServices.getInstance().addAction(actionName, Long.Parse(unitId))
        Catch ex As FormatException
        End Try

        Response.Redirect("/Actions.aspx?unit_id=" & unitId)
    End Sub

End Class