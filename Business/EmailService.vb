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

        Me.smtpServer.Credentials = New NetworkCredential("asfollow.info@gmail.com", "")
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

    Public Sub shareInfoMonthly()
        prepareInfo()
        Me.mail.Subject = "ASfollow - Info monthly"
        Me.mail.Body = Me.getBody(0)
        Me.smtpServer.Send(Me.mail)
    End Sub

    Public Sub shareInfoUrgent()
        prepareInfo()
        Me.mail.Subject = "ASfollow - Info urgents"
        Me.mail.Body = Me.getBody(1)
        Me.smtpServer.Send(Me.mail)
    End Sub

    Private Sub prepareInfo()
        Me.mail.From = New MailAddress("asfollow.info@gmail.com")
        Me.mail.To.Add("mail")
        Me.mail.IsBodyHtml = True
    End Sub

    Private Function getBody(actionShare As Integer) As String
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
                        Dim steps As List(Of [step]) = Nothing
                        Select Case actionShare
                            Case 0
                                steps = StepBO.getInstance().getStepsShareablesByActionId(action.action_id)
                            Case 1
                                steps = StepBO.getInstance().getStepsUrgentsByActionId(action.action_id)
                        End Select
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
