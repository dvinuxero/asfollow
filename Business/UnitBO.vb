Imports Entity
Imports Data

Public Class UnitBO

    Private Shared instance As UnitBO

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As UnitBO
        If (instance Is Nothing) Then
            instance = New UnitBO()
        End If

        Return instance
    End Function

    Public Sub addUnit(newUnit As unit)
        UnitDAO.getInstance().addUnit(newUnit)
    End Sub

    Public Sub addUnitType(newUnitType As unit_type)
        UnitDAO.getInstance().addUnitType(newUnitType)
    End Sub

    Public Sub updateUnit(updatedUnit As unit)
        UnitDAO.getInstance().updateUnit(updatedUnit)
    End Sub

    Public Sub updateUnitType(updatedUnitType As unit_type)
        UnitDAO.getInstance().updateUnitType(updatedUnitType)
    End Sub

    Public Sub deleteUnit(deletedUnit As unit)
        UnitDAO.getInstance().deleteUnit(deletedUnit)
    End Sub

    Public Sub deleteUnitType(deletedUnitType As unit_type)
        UnitDAO.getInstance().deleteUnitType(deletedUnitType)
    End Sub

    Public Function getUnit(unitId As Long) As unit
        Return UnitDAO.getInstance().getUnit(unitId)
    End Function

    Public Function getUnitByName(name As String) As unit
        Return UnitDAO.getInstance().getUnitByName(name)
    End Function

    Public Function getUnits() As List(Of unit)
        Return UnitDAO.getInstance().getUnits()
    End Function

    Public Function getUnitType(typeId As Long) As unit_type
        Return UnitDAO.getInstance().getUnitType(typeId)
    End Function

    Public Function getUnitTypeByName(name As String) As unit_type
        Return UnitDAO.getInstance().getUnitTypeByName(name)
    End Function

    Public Function getUnitTypes() As List(Of unit_type)
        Return UnitDAO.getInstance().getUnitTypes()
    End Function

    Public Function getTotalAmountByUnitId(unitId As Long) As Integer
        Return UnitDAO.getInstance().getTotalAmountByUnitId(unitId)
    End Function

    Public Function getTotalAmount() As Integer
        Return UnitDAO.getInstance().getTotalAmount()
    End Function

End Class
