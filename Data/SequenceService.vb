Imports Entity

Public Class SequenceService

    Private Shared instance As SequenceService

    Private sequences As Dictionary(Of Type, Long)

    Private Sub New()
        sequences = New Dictionary(Of Type, Long)

        sequences.Add(GetType(action), getLastId(GetType(action)))
        sequences.Add(GetType([step]), getLastId(GetType([step])))
    End Sub

    Public Shared Function getInstance() As SequenceService
        If (instance Is Nothing) Then
            instance = New SequenceService()
        End If

        Return instance
    End Function

    Public Function getNextId(type As Type) As Long
        Dim nextId As Long = sequences(type) + 1

        setLastId(type, nextId)

        Return nextId
    End Function

    Private Sub setLastId(type As Type, lastId As Long)
        sequences(type) = lastId
    End Sub

    Private Function getLastId(type As Type) As Long
        Dim lastId As Long = 0

        Try
            Select Case type
                Case GetType(action)
                    lastId = (From a In DataBase.getInstance().connectionDataModel.action.ToList() Select a.action_id).Max()

                Case GetType([step])
                    lastId = (From s In DataBase.getInstance().connectionDataModel.step.ToList() Select s.action_id).Max()
                Case Else

            End Select
        Catch ex As InvalidOperationException
            lastId = -1
        End Try

        If (lastId < 0) Then
            lastId = 0
        End If

        Return lastId
    End Function

End Class
