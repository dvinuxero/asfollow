Imports Entity

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnGoToActions_Click(sender As Object, e As EventArgs)
        Response.Redirect("Actions.aspx?unit_id=" & unitIdHidden.Value)
    End Sub

    Protected Sub shareInfo_Click(sender As Object, e As EventArgs) Handles btnShareInfo.Click
        AllServices.getInstance().shareInfo(0)
    End Sub

    Protected Sub shareUrgentInfo_Click(sender As Object, e As EventArgs) Handles btnShareUrgentInfo.Click
        AllServices.getInstance().shareInfo(1)
    End Sub

    Protected Sub refreshSteps_Click(sender As Object, e As EventArgs) Handles btnRefreshSteps.Click
        AllServices.getInstance().refreshSteps()
    End Sub

    Protected Sub addNewUnit_Click(sender As Object, e As EventArgs) Handles addNewUnit.Click
        Response.Redirect("/admin/ABMUnits.aspx")
    End Sub
End Class