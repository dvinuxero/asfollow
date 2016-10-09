Imports Entity

Public Class UnitDAO

    Private Shared instance As UnitDAO

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As UnitDAO
        If (instance Is Nothing) Then
            instance = New UnitDAO()
        End If

        Return instance
    End Function

    Public Sub addUnit(newUnit As unit)
        newUnit.unit_id = SequenceService.getInstance().getNextId(GetType(unit))
        DataBase.getInstance().connectionDataModel.unit.Add(newUnit)
        DataBase.getInstance().connectionDataModel.SaveChanges()
    End Sub

    Public Sub addUnitType(newUnitType As unit_type)
        newUnitType.type_id = SequenceService.getInstance().getNextId(GetType(unit_type))
        DataBase.getInstance().connectionDataModel.unit_type.Add(newUnitType)
        DataBase.getInstance().connectionDataModel.SaveChanges()
    End Sub

    Public Function getUnitByName(mName As String) As unit
        Try
            Dim resultUnit = (From u In DataBase.getInstance().connectionDataModel.unit Select u.unit_id, u.type_id, u.name Where name = mName).First()

            If (resultUnit IsNot Nothing) Then
                Return New UnitBuilder().createUnit(resultUnit.name, resultUnit.type_id, resultUnit.unit_id)
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

    Public Function getUnits() As List(Of unit)
        Try
            Dim resultsUnits = (From u In DataBase.getInstance().connectionDataModel.unit Select u.unit_id, u.type_id, u.name).ToList()

            If (resultsUnits IsNot Nothing) Then
                If (resultsUnits.Count > 0) Then
                    Dim listOfUnits As List(Of unit) = New List(Of unit)
                    For Each resultUnit In resultsUnits
                        listOfUnits.Add(New UnitBuilder().createUnit(resultUnit.name, resultUnit.type_id, resultUnit.unit_id))
                    Next

                    Return listOfUnits
                End If
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

    Public Function getUnitTypeByName(mName As String) As unit_type
        Try
            Dim resultUnitType = (From ut In DataBase.getInstance().connectionDataModel.unit_type Select ut.type_id, ut.name, ut.picture_url Where name = mName).First()

            If (resultUnitType IsNot Nothing) Then
                Return New UnitTypeBuilder().createUnitType(resultUnitType.name, resultUnitType.picture_url, resultUnitType.type_id)
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

    Public Function getUnitTypes() As List(Of unit_type)
        Try
            Dim resultsUnitTypes = (From ut In DataBase.getInstance().connectionDataModel.unit_type Select ut.type_id, ut.name, ut.picture_url).ToList()

            If (resultsUnitTypes IsNot Nothing) Then
                If (resultsUnitTypes.Count > 0) Then
                    Dim listOfUnitTypes As List(Of unit_type) = New List(Of unit_type)
                    For Each resultUnitType In resultsUnitTypes
                        listOfUnitTypes.Add(New UnitTypeBuilder().createUnitType(resultUnitType.name, resultUnitType.picture_url, resultUnitType.type_id))
                    Next

                    Return listOfUnitTypes
                End If
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

End Class
