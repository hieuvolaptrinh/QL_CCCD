Public Class TinhTP
    Private _maTTP As String
    Private _tenTTP As String

    Public Property MaTTP As String
        Get
            Return _maTTP
        End Get
        Set(value As String)
            _maTTP = value
        End Set
    End Property

    Public Property TenTTP As String
        Get
            Return _tenTTP
        End Get
        Set(value As String)
            _tenTTP = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(maTTP As String, tenTTP As String)
        Me.MaTTP = maTTP
        Me.TenTTP = tenTTP
    End Sub
End Class