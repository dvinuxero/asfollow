﻿Imports Entity

Public Class TagDAO

    Private Shared instance As TagDAO

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As TagDAO
        If (instance Is Nothing) Then
            instance = New TagDAO()
        End If

        Return instance
    End Function

    Public Sub addTag(newTag As tag)
        newTag.tag_id = SequenceService.getInstance().getNextId(GetType(tag))
        DataBase.getInstance().connectionDataModel.tag.Add(newTag)
        DataBase.getInstance().connectionDataModel.SaveChanges()
    End Sub

    Public Sub updateTag(updatedTag As tag)
        Dim oldTag As tag = DataBase.getInstance().connectionDataModel.tag.Find(updatedTag.tag_id)

        If (oldTag IsNot Nothing) Then
            oldTag.color = updatedTag.color
            oldTag.name = updatedTag.name
            DataBase.getInstance().connectionDataModel.SaveChanges()
        End If
    End Sub

    Public Sub deleteTag(deletedTag As tag)
        Dim oldTag As tag = DataBase.getInstance().connectionDataModel.tag.Find(deletedTag.tag_id)

        If (oldTag IsNot Nothing) Then
            DataBase.getInstance().connectionDataModel.tag.Remove(oldTag)
            DataBase.getInstance().connectionDataModel.SaveChanges()
        End If
    End Sub

    Public Function getTagById(tagId As Long) As tag
        Try
            Dim resultAction = (From t In DataBase.getInstance().connectionDataModel.tag Select t.tag_id, t.name, t.color Where tag_id = tagId).First()

            If (resultAction IsNot Nothing) Then
                Return New TagBuilder().createTag(resultAction.name, resultAction.color, resultAction.tag_id)
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

    Public Function getTagByName(mName As String) As tag
        Try
            Dim resultAction = (From t In DataBase.getInstance().connectionDataModel.tag Select t.tag_id, t.name, t.color Where name = mName).First()

            If (resultAction IsNot Nothing) Then
                Return New TagBuilder().createTag(resultAction.name, resultAction.color, resultAction.tag_id)
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

    Public Function getTags() As List(Of tag)
        Try
            Dim resultsTags = (From t In DataBase.getInstance().connectionDataModel.tag Select t.tag_id, t.name, t.color).ToList()

            If (resultsTags IsNot Nothing) Then
                If (resultsTags.Count > 0) Then
                    Dim listOfTags As List(Of tag) = New List(Of tag)
                    For Each resultTag In resultsTags
                        listOfTags.Add(New TagBuilder().createTag(resultTag.name, resultTag.color, resultTag.tag_id))
                    Next

                    Return listOfTags
                End If
            End If
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

End Class
