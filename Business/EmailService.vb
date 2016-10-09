Imports System.Net
Imports System.Net.Mail
Imports System.Text

Imports Entity

Public Class EmailService

    Private Shared instance As EmailService

    Private smtpServer As SmtpClient
    Private mail As MailMessage

    Private Sub New()
        Me.smtpServer = New SmtpClient()
        Me.mail = New MailMessage()

        Me.smtpServer.Credentials = New NetworkCredential("asfollow.info@gmail.com", "Ml34318438")
        Me.smtpServer.Port = 587
        Me.smtpServer.Host = "smtp.gmail.com"
        Me.smtpServer.EnableSsl = True
    End Sub

    Public Shared Function getInstance() As EmailService
        If (instance Is Nothing) Then
            instance = New EmailService()
        End If

        Return instance
    End Function

    Public Sub shareInfo()
        Me.mail.From = New MailAddress("asfollow.info@gmail.com")
        Me.mail.To.Add("villanustre@gmail.com")
        Me.mail.Subject = "Share info ASfollow"
        Me.mail.Body = Me.getBody()
        Me.mail.IsBodyHtml = True

        Me.smtpServer.Send(Me.mail)
    End Sub

    Private Function getBody() As String
        Dim body As New StringBuilder("")

        Dim units As List(Of unit) = UnitBO.getInstance().getUnits()
        If (units IsNot Nothing) Then
            body.Append("<ul>")
            For Each unit As unit In units
                Dim actions As List(Of action) = ActionBO.getInstance().getActionsByUnitId(unit.unit_id)
                If (actions IsNot Nothing) Then
                    body.Append("<li>Unit - ").Append("<b>").Append(unit.toString()).Append("</b></li>")
                    body.Append("<ul>")
                    For Each action As action In actions
                        Dim steps As List(Of [step]) = StepBO.getInstance().getStepsShareablesByActionId(action.action_id)
                        If (steps IsNot Nothing) Then
                            body.Append("<li>Action - ").Append("<b>").Append(action.toString()).Append("</b></li>")
                            body.Append("<ul>")
                            For Each [step] As [step] In steps
                                body.Append("<li>").Append([step].toString()).Append("</li>")
                            Next
                            body.Append("</ul>")
                        End If
                    Next
                    body.Append("</ul>")
                End If
            Next
            body.Append("</ul>")
        End If

        Return body.ToString()
    End Function

End Class
