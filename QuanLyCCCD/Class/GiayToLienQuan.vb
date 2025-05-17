Public Class GiayToLienQuan
    Private _soGiayTo As String
    Private _soCCCD As String
    Private _loaiGiayTo As String
    Private _ngayCap As DateTime
    Private _noiCap As String
    Private _ngayHetHan As DateTime?
    Private _chiTiet As String

    Public Property SoGiayTo As String
        Get
            Return _soGiayTo
        End Get
        Set(value As String)
            _soGiayTo = value
        End Set
    End Property

    Public Property SoCCCD As String
        Get
            Return _soCCCD
        End Get
        Set(value As String)
            _soCCCD = value
        End Set
    End Property

    Public Property LoaiGiayTo As String
        Get
            Return _loaiGiayTo
        End Get
        Set(value As String)
            _loaiGiayTo = value
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

    Public Property ChiTiet As String
        Get
            Return _chiTiet
        End Get
        Set(value As String)
            _chiTiet = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(soGiayTo As String, soCCCD As String, loaiGiayTo As String, ngayCap As DateTime, noiCap As String, ngayHetHan As DateTime?, chiTiet As String)
        Me.SoGiayTo = soGiayTo
        Me.SoCCCD = soCCCD
        Me.LoaiGiayTo = loaiGiayTo
        Me.NgayCap = ngayCap
        Me.NoiCap = noiCap
        Me.NgayHetHan = ngayHetHan
        Me.ChiTiet = chiTiet
    End Sub
End Class