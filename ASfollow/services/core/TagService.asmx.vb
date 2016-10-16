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
Public Class TagService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function ping() As String
        Return "pong"
    End Function

    <WebMethod()> _
    Public Overloads Function addTagByName(name As String) As tag
        Dim tag As tag = New TagBuilder().createTag(name)

        TagBO.getInstance().addTag(tag)

        Return tag
    End Function

    <WebMethod()> _
    Public Overloads Function addTagByNameAndColor(name As String, color As String) As tag
        Dim tag As tag = New TagBuilder().createTag(name, color)

        TagBO.getInstance().addTag(tag)

        Return tag
    End Function

    <WebMethod()> _
    Public Overloads Function updateTag(name As String, color As String, tagId As Long) As Boolean
        Dim updatedTag As tag = New TagBuilder().createTag(name, color, tagId)

        TagBO.getInstance().updateTag(updatedTag)

        Return True
    End Function

    <WebMethod()> _
    Public Overloads Function deleteTag(tagId As Long) As Boolean
        Dim deletedTag As tag = New TagBuilder().createTag()
        deletedTag.tag_id = tagId

        TagBO.getInstance().deleteTag(deletedTag)

        Return True
    End Function

    <WebMethod()> _
    Public Overloads Function getTags() As List(Of tag)
        Return TagBO.getInstance().getTags()
    End Function

    <WebMethod()> _
    Public Overloads Function getTag(tagId As Long) As tag
        Return TagBO.getInstance().getTagById(tagId)
    End Function

End Class