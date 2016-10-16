Imports Entity

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnGoToActions_Click(sender As Object, e As EventArgs)
        Response.Redirect("Actions.aspx?unit_id=" & unitIdHidden.Value)
    End Sub

    Protected Sub shareInfo_Click(sender As Object, e As EventArgs) Handles btnShareInfo.Click
        AllServices.getInstance().shareInfo()
    End Sub
End Class