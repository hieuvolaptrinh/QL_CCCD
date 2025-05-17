Public Class QuanHuyen
    Private _maQH As String
    Private _tenQH As String
    Private _maTTP As String

    Public Property MaQH As String
        Get
            Return _maQH
        End Get
        Set(value As String)
            _maQH = value
        End Set
    End Property

    Public Property TenQH As String
        Get
            Return _tenQH
        End Get
        Set(value As String)
            _tenQH = value
        End Set
    End Property

    Public Property MaTTP As String
        Get
            Return _maTTP
        End Get
        Set(value As String)
            _maTTP = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(maQH As String, tenQH As String, maTTP As String)
        Me.MaQH = maQH
        Me.TenQH = tenQH
        Me.MaTTP = maTTP
    End Sub
End Class