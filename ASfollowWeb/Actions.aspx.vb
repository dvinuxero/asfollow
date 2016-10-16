Imports Entity
Imports ASfollowWeb.AllServices

Public Class Actions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnSetStepChecked_Click(sender As Object, e As EventArgs)
        AllServices.getInstance().setStepChecked(stepIdHidden.Value)
    End Sub

End Class