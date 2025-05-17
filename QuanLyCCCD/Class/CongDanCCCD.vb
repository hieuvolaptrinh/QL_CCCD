Public Class CongDanCCCD
    Private _soCCCD As String
    Private _hoTen As String
    Private _ngaySinh As DateTime
    Private _gioiTinh As String
    Private _danToc As String
    Private _tonGiao As String
    Private _queQuan As String
    Private _maQH As String
    Private _ngayCap As DateTime
    Private _noiCap As String
    Private _ngayHetHan As DateTime?

    Public Property SoCCCD As String
        Get
            Return _soCCCD
        End Get
        Set(value As String)
            _soCCCD = value
        End Set
    End Property

    Public Property HoTen As String
        Get
            Return _hoTen
        End Get
        Set(value As String)
            _hoTen = value
        End Set
    End Property

    Public Property NgaySinh As DateTime
        Get
            Return _ngaySinh
        End Get
        Set(value As DateTime)
            _ngaySinh = value
        End Set
    End Property

    Public Property GioiTinh As String
        Get
            Return _gioiTinh
        End Get
        Set(value As String)
            _gioiTinh = value
        End Set
    End Property

    Public Property DanToc As String
        Get
            Return _danToc
        End Get
        Set(value As String)
            _danToc = value
        End Set
    End Property

    Public Property TonGiao As String
        Get
            Return _tonGiao
        End Get
        Set(value As String)
            _tonGiao = value
        End Set
    End Property

    Public Property QueQuan As String
        Get
            Return _queQuan
        End Get
        Set(value As String)
            _queQuan = value
        End Set
    End Property

    Public Property MaQH As String
        Get
            Return _maQH
        End Get
        Set(value As String)
            _maQH = value
        End Set
    End Property

    Public Property NgayCap As DateTime
        Get
            Return _ngayCap
        End Get
        Set(value As DateTime)
            _ngayCap = value
        End Set
    End Property

    Public Property NoiCap As String
        Get
            Return _noiCap
        End Get
        Set(value As String)
            _noiCap = value
        End Set
    End Property

    Public Property NgayHetHan As DateTime?
        Get
            Return _ngayHetHan
        End Get
        Set(value As DateTime?)
            _ngayHetHan = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(soCCCD As String, hoTen As String, ngaySinh As DateTime, gioiTinh As String, danToc As String, tonGiao As String, queQuan As String, maQH As String, ngayCap As DateTime, noiCap As String, ngayHetHan As DateTime?)
        Me.SoCCCD = soCCCD
        Me.HoTen = hoTen
        Me.NgaySinh = ngaySinh
        Me.GioiTinh = gioiTinh
        Me.DanToc = danToc
        Me.TonGiao = tonGiao
        Me.QueQuan = queQuan
        Me.MaQH = maQH
        Me.NgayCap = ngayCap
        Me.NoiCap = noiCap
        Me.NgayHetHan = ngayHetHan
    End Sub
End Class