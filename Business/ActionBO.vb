Imports Entity
Imports Data

Public Class ActionBO

    Private Shared instance As ActionBO

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As ActionBO
        If (instance Is Nothing) Then
            instance = New ActionBO()
        End If

        Return instance
    End Function

    Public Sub addAction(newAction As action)
        ActionDAO.getInstance().addAction(newAction)
    End Sub

    Public Sub updateAction(updatedAction As action)
        ActionDAO.getInstance().updateAction(updatedAction)
    End Sub

    Public Sub deleteAction(deletedAction As action)
        ActionDAO.getInstance().deleteAction(deletedAction)
    End Sub

    Public Function getActionByName(mName As String) As action
        Return ActionDAO.getInstance().getActionByName(mName)
    End Function

    Public Function getActionsByUnitId(unitId As Long) As List(Of action)
        Return ActionDAO.getInstance().getActionsByUnitId(unitId)
    End Function

End Class
