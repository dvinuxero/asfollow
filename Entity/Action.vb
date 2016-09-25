Public Class Action

    Private mId As Integer
    Private mName As String
    Private mSteps As List(Of [Step])

    Friend Sub New()
    End Sub

    Public ReadOnly Property id() As Integer
        Get
            Return mId
        End Get
    End Property

    Public Property name() As String
        Get
            Return mName
        End Get
        Set(ByVal value As String)
            mName = value
        End Set
    End Property

    Public Property steps() As List(Of [Step])
        Get
            Return mSteps
        End Get
        Set(ByVal value As List(Of [Step]))
            mSteps = value
        End Set
    End Property

    Public Sub setNewId(id As Integer)
        Me.mId = id
    End Sub

End Class
