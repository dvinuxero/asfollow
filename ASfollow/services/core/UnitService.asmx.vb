Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Imports Entity
Imports Business

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class UnitService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function ping() As String
        Return "pong"
    End Function

    <WebMethod()> _
    Public Overloads Function addUnitByNameAndTypeId(name As String, typeId As Long) As unit
        Dim unit As unit = New UnitBuilder().createUnit(name, typeId)

        UnitBO.getInstance().addUnit(unit)

        Return unit
    End Function

    <WebMethod()> _
    Public Overloads Function addUnitTypeByName(name As String) As unit_type
        Dim unitType As unit_type = New UnitTypeBuilder().createUnitType(name)

        UnitBO.getInstance().addUnitType(unitType)

        Return unitType
    End Function

    <WebMethod()> _
    Public Overloads Function addUnitTypeByNameAndPictureUrl(name As String, pictureUrl As String) As unit_type
        Dim unitType As unit_type = New UnitTypeBuilder().createUnitType(name, pictureUrl)

        UnitBO.getInstance().addUnitType(unitType)

        Return unitType
    End Function

    <WebMethod()> _
    Public Overloads Function updateUnit(name As String, typeId As Long, unitId As Long) As Boolean
        Dim updatedUnit As unit = New UnitBuilder().createUnit(name, typeId, unitId)

        UnitBO.getInstance().updateUnit(updatedUnit)

        Return True
    End Function

    <WebMethod()> _
    Public Overloads Function updateUnitType(name As String, pictureUrl As String, typeId As Long) As Boolean
        Dim updatedUnitType As unit_type = New UnitTypeBuilder().createUnitType(name, pictureUrl, typeId)

        UnitBO.getInstance().updateUnitType(updatedUnitType)

        Return True
    End Function

    <WebMethod()> _
    Public Overloads Function deleteUnit(unitId As Long) As Boolean
        Dim deletedUnit As unit = New UnitBuilder().createUnit()
        deletedUnit.unit_id = unitId

        UnitBO.getInstance().deleteUnit(deletedUnit)

        Return True
    End Function

    <WebMethod()> _
    Public Overloads Function deleteUnitType(typeId As Long) As Boolean
        Dim deletedUnitType As unit_type = New UnitTypeBuilder().createUnitType()
        deletedUnitType.type_id = typeId

        UnitBO.getInstance().deleteUnitType(deletedUnitType)

        Return True
    End Function

    <WebMethod()> _
    Public Overloads Function getUnit(unitId As Long) As unit
        Return UnitBO.getInstance().getUnit(unitId)
    End Function

    <WebMethod()> _
    Public Overloads Function getUnitByName(name As String) As unit
        Return UnitBO.getInstance().getUnitByName(name)
    End Function

    <WebMethod()> _
    Public Overloads Function getUnits() As List(Of unit)
        Return UnitBO.getInstance().getUnits()
    End Function

    <WebMethod()> _
    Public Overloads Function getUnitType(typeId As Long) As unit_type
        Return UnitBO.getInstance().getUnitType(typeId)
    End Function

    <WebMethod()> _
    Public Overloads Function getUnitTypeByName(name As String) As unit_type
        Return UnitBO.getInstance().getUnitTypeByName(name)
    End Function

    <WebMethod()> _
    Public Overloads Function getUnitTypes() As List(Of unit_type)
        Return UnitBO.getInstance().getUnitTypes()
    End Function

    <WebMethod()> _
    Public Overloads Function getTotalAmountByUnitId(unitId As Long) As Integer
        Return UnitBO.getInstance().getTotalAmountByUnitId(unitId)
    End Function

    <WebMethod()> _
    Public Overloads Function getTotalAmount() As Integer
        Return UnitBO.getInstance().getTotalAmount()
    End Function

End Class