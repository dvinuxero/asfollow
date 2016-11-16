Public Class ABMUnits
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If ("POST".Equals(Request.HttpMethod)) Then
            addUnit()
        End If
    End Sub

    Private Sub addUnit()
        Dim unitName As String = Request.Form("unitName")
        Dim unitType As String = Request.Form("unitType")

        Try
            AllServices.getInstance().addUnit(unitName, Long.Parse(unitType))
        Catch ex As FormatException
        End Try

        Response.Redirect("/Default.aspx")
    End Sub

End Class