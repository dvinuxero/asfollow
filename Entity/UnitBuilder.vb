Public Class UnitBuilder

    Private unit As unit

    Public Sub New()
    End Sub

    Public Function createUnit() As unit
        Me.unit = New unit()

        Return Me.unit
    End Function

    Public Function createUnit(name As String, typeId As Long) As unit
        Me.unit = New unit()
        Me.unit.name = name
        Me.unit.type_id = typeId

        Return Me.unit
    End Function

    Public Function createUnit(name As String, typeId As Long, unitId As Long) As unit
        Me.unit = New unit()
        Me.unit.name = name
        Me.unit.type_id = typeId
        Me.unit.unit_id = unitId

        Return Me.unit
    End Function

End Class
