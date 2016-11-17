Imports Entity
Imports ASfollowWeb.AllServices

Public Class Actions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnSetStepChecked_Click(sender As Object, e As EventArgs)
        AllServices.getInstance().setStepChecked(Long.Parse(stepIdHidden.Value))
    End Sub

    Protected Sub btnDeleteStep_Click(sender As Object, e As EventArgs)
        AllServices.getInstance().deleteStep(Long.Parse(stepIdHidden.Value))
    End Sub

    Protected Sub btnAddAction_Click(sender As Object, e As EventArgs)
        Response.Redirect("/admin/ABMActions.aspx?unit_id=" & unitIdHidden.Value)
    End Sub

    Protected Sub btnDeleteAction_Click(sender As Object, e As EventArgs)
        AllServices.getInstance().deleteAction(Long.Parse(actionIdHidden.Value))
    End Sub

    Protected Sub btnAddStepFromData_Click(sender As Object, e As EventArgs)
        Response.Redirect("/admin/ABMSteps.aspx?unit_id=" & unitIdHidden.Value & "&action_id=" & actionIdHidden.Value & "&action_name=" & actionNameHidden.Value)
    End Sub

End Class