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
    Public Overloads Function getUnitByName(name As String) As unit
        Return UnitBO.getInstance().getUnitByName(name)
    End Function

    <WebMethod()> _
    Public Overloads Function getUnits() As List(Of unit)
        Return UnitBO.getInstance().getUnits()
    End Function

    <WebMethod()> _
    Public Overloads Function getUnitTypeByName(name As String) As unit_type
        Return UnitBO.getInstance().getUnitTypeByName(name)
    End Function

    <WebMethod()> _
    Public Overloads Function getUnitTypes() As List(Of unit_type)
        Return UnitBO.getInstance().getUnitTypes()
    End Function

End Class