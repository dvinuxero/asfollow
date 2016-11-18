Imports System.Xml
Imports System.IO
Imports System.Text

Imports Entity

Public Class ExportXmlService

    Private Shared instance As ExportXmlService

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As ExportXmlService
        If (instance Is Nothing) Then
            instance = New ExportXmlService()
        End If

        Return instance
    End Function

    Public Function exportXml() As String
        ' Create the XmlWriter object and write some content.
        Dim stream As MemoryStream = New MemoryStream()
        Dim xml As XmlTextWriter = New XmlTextWriter(stream, UTF8Encoding.UTF8)

        Dim units As List(Of unit) = UnitBO.getInstance().getUnits()
        If (units IsNot Nothing) Then
            xml.WriteStartDocument(True)
            xml.WriteStartElement("asfollow")
            For Each unit As unit In units
                xml.WriteStartElement("unit")
                xml.WriteAttributeString("id", unit.unit_id.ToString())
                xml.WriteAttributeString("name", unit.name.ToString())
                Dim actions As List(Of action) = ActionBO.getInstance().getActionsByUnitId(unit.unit_id)
                If (actions IsNot Nothing) Then
                    For Each action As action In actions
                        xml.WriteStartElement("action")
                        xml.WriteAttributeString("id", action.action_id.ToString())
                        xml.WriteAttributeString("name", action.name.ToString())

                        Dim stepsShareables As List(Of [step]) = StepBO.getInstance().getStepsShareablesByActionId(action.action_id)
                        Dim stepsUrgents As List(Of [step]) = StepBO.getInstance().getStepsUrgentsByActionId(action.action_id)
                        Dim steps As List(Of [step]) = Nothing

                        If (stepsShareables IsNot Nothing) Then
                            steps = stepsShareables
                        End If

                        If (stepsUrgents IsNot Nothing) Then
                            If (steps Is Nothing) Then
                                steps = stepsUrgents
                            Else
                                steps.AddRange(stepsUrgents)
                            End If
                        End If

                        If (steps IsNot Nothing) Then
                            For Each [step] As [step] In steps
                                xml.WriteStartElement("step")
                                xml.WriteAttributeString("id", [step].step_id.ToString())

                                If ([step].text IsNot Nothing) Then
                                    xml.WriteStartElement("text")
                                    xml.WriteValue([step].text.ToString())
                                    xml.WriteEndElement()
                                End If
                                If ([step].amount IsNot Nothing) Then
                                    xml.WriteStartElement("amount")
                                    xml.WriteValue([step].amount.ToString())
                                    xml.WriteEndElement()
                                End If
                                If ([step].description IsNot Nothing) Then
                                    xml.WriteStartElement("description")
                                    xml.WriteValue([step].description.ToString())
                                    xml.WriteEndElement()
                                End If

                                xml.WriteEndElement()
                            Next
                        End If
                        xml.WriteEndElement()
                    Next
                End If
                xml.WriteEndElement()
            Next
            xml.WriteEndElement()
        End If

        xml.Flush()

        Dim reader As New StreamReader(stream)
        stream.Seek(0, SeekOrigin.Begin)
        Dim existBytes As Boolean = True
        Dim result As New StringBuilder()
        While (Not reader.EndOfStream)
            result.Append(reader.ReadLine())
        End While

        xml.Close()

        Return result.ToString()
    End Function

End Class
