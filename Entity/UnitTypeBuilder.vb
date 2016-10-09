Public Class UnitTypeBuilder

    Private unitType As unit_type

    Public Sub New()
    End Sub

    Public Function createUnitType() As unit_type
        Me.unitType = New unit_type()

        Return Me.unitType
    End Function

    Public Function createUnitType(name As String) As unit_type
        Me.unitType = New unit_type()
        Me.unitType.name = name

        Return Me.unitType
    End Function

    Public Function createUnitType(name As String, pictureUrl As String) As unit_type
        Me.unitType = New unit_type()
        Me.unitType.name = name
        Me.unitType.picture_url = pictureUrl

        Return Me.unitType
    End Function

    Public Function createUnitType(name As String, pictureUrl As String, typeId As Long) As unit_type
        Me.unitType = New unit_type()
        Me.unitType.name = name
        Me.unitType.picture_url = pictureUrl
        Me.unitType.type_id = typeId

        Return Me.unitType
    End Function

End Class
