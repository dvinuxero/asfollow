Public Class [Step]

    Private mId As Long
    Private mText As String
    Private mOrder As Integer
    Private mDescription As String

    Friend Sub New()
    End Sub

    Public ReadOnly Property id() As Long
        Get
            Return mId
        End Get
    End Property

    Public Property text() As String
        Get
            Return mText
        End Get
        Set(ByVal value As String)
            mText = value
        End Set
    End Property

    Public Property order() As Integer
        Get
            Return mOrder
        End Get
        Set(ByVal value As Integer)
            mOrder = value
        End Set
    End Property

    Public Property description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal value As String)
            mDescription = value
        End Set
    End Property

End Class
