Public Class CongDanCCCD
    Private soCCCDField As String
    Private hoTenField As String
    Private ngaySinhField As DateTime
    Private gioiTinhField As String
    Private queQuanField As String
    Private noiOField As String
    Private ngayCapField As DateTime
    Private noiCapField As String

    Public Property SoCCCD As String
        Get
            Return soCCCDField
        End Get
        Set(value As String)
            soCCCDField = value
        End Set
    End Property

    Public Property HoTen As String
        Get
            Return hoTenField
        End Get
        Set(value As String)
            hoTenField = value
        End Set
    End Property

    Public Property NgaySinh As DateTime
        Get
            Return ngaySinhField
        End Get
        Set(value As DateTime)
            ngaySinhField = value
        End Set
    End Property

    Public Property GioiTinh As String
        Get
            Return gioiTinhField
        End Get
        Set(value As String)
            gioiTinhField = value
        End Set
    End Property

    Public Property QueQuan As String
        Get
            Return queQuanField
        End Get
        Set(value As String)
            queQuanField = value
        End Set
    End Property

    Public Property NoiO As String
        Get
            Return noiOField
        End Get
        Set(value As String)
            noiOField = value
        End Set
    End Property

    Public Property NgayCap As DateTime
        Get
            Return ngayCapField
        End Get
        Set(value As DateTime)
            ngayCapField = value
        End Set
    End Property

    Public Property NoiCap As String
        Get
            Return noiCapField
        End Get
        Set(value As String)
            noiCapField = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(soCCCD As String, hoTen As String, ngaySinh As DateTime, gioiTinh As String, 
                  queQuan As String, noiO As String, ngayCap As DateTime, noiCap As String)
        Me.SoCCCD = soCCCD
        Me.HoTen = hoTen
        Me.NgaySinh = ngaySinh
        Me.GioiTinh = gioiTinh
        Me.QueQuan = queQuan
        Me.NoiO = noiO
        Me.NgayCap = ngayCap
        Me.NoiCap = noiCap
    End Sub
End Class