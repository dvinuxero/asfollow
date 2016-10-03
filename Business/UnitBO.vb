﻿Imports Entity
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

    Public Function getUnitByName(name As String) As unit
        Return UnitDAO.getInstance().getUnitByName(name)
    End Function

    Public Function getUnits() As List(Of unit)
        Return UnitDAO.getInstance().getUnits()
    End Function

    Public Function getUnitTypeByName(name As String) As unit_type
        Return UnitDAO.getInstance().getUnitTypeByName(name)
    End Function

    Public Function getUnitTypes() As List(Of unit_type)
        Return UnitDAO.getInstance().getUnitTypes()
    End Function

End Class