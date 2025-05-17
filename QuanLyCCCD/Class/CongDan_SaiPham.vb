Imports System.Data.SqlClient

Public Class CongDan_SaiPham
    Private _MaSaiPham As String
    Private _SoCCCD As String
    Private _LoiSaiPham As String
    Private _NgaySai As Date
    Private _NoiSaiPham As String
    Private _MucPhat As Decimal
    Private _TrangThai As String
    Private _HoTen As String
    Private _NgaySinh As Date
    Private _GioiTinh As String
    Private _DanToc As String
    Private _TonGiao As String
    Private _QueQuan As String
    Private _QuanHuyen As String

    Public Property MaSaiPham As String
        Get
            Return _MaSaiPham
        End Get
        Set(value As String)
            _MaSaiPham = value
        End Set
    End Property

    Public Property SoCCCD As String
        Get
            Return _SoCCCD
        End Get
        Set(value As String)
            _SoCCCD = value
        End Set
    End Property

    Public Property LoiSaiPham As String
        Get
            Return _LoiSaiPham
        End Get
        Set(value As String)
            _LoiSaiPham = value
        End Set
    End Property

    Public Property NgaySai As Date
        Get
            Return _NgaySai
        End Get
        Set(value As Date)
            _NgaySai = value
        End Set
    End Property

    Public Property NoiSaiPham As String
        Get
            Return _NoiSaiPham
        End Get
        Set(value As String)
            _NoiSaiPham = value
        End Set
    End Property

    Public Property MucPhat As Decimal?
        Get
            Return _MucPhat
        End Get
        Set(value As Decimal?)
            _MucPhat = value
        End Set
    End Property

    Public Property TrangThai As String
        Get
            Return _TrangThai
        End Get
        Set(value As String)
            _TrangThai = value
        End Set
    End Property

    Public Property HoTen As String
        Get
            Return _HoTen
        End Get
        Set(value As String)
            _HoTen = value
        End Set
    End Property

    Public Property NgaySinh As Date
        Get
            Return _NgaySinh
        End Get
        Set(value As Date)
            _NgaySinh = value
        End Set
    End Property

    Public Property GioiTinh As String
        Get
            Return _GioiTinh
        End Get
        Set(value As String)
            _GioiTinh = value
        End Set
    End Property

    Public Property DanToc As String
        Get
            Return _DanToc
        End Get
        Set(value As String)
            _DanToc = value
        End Set
    End Property

    Public Property TonGiao As String
        Get
            Return _TonGiao
        End Get
        Set(value As String)
            _TonGiao = value
        End Set
    End Property

    Public Property QueQuan As String
        Get
            Return _QueQuan
        End Get
        Set(value As String)
            _QueQuan = value
        End Set
    End Property

    Public Property QH As String
        Get
            Return _QuanHuyen
        End Get
        Set(value As String)
            _QuanHuyen = value
        End Set
    End Property

    Public Shared Function GetAllCongDan_SP() As List(Of CongDan_SaiPham)
        Dim result As New List(Of CongDan_SaiPham)()

        ' Câu lệnh SQL
        Dim sql As String = "
        SELECT sp.MaSaiPham, sp.SoCCCD, sp.LoiSaiPham, sp.NgaySai, sp.NoiSaiPham, sp.MucPhat, sp.TrangThai,
               cc.HoTen, cc.NgaySinh, cc.GioiTinh, cc.DanToc, cc.TonGiao, cc.QueQuan,
               qh.TenQH
        FROM SaiPham sp
        JOIN CongDanCCCD cc ON sp.SoCCCD = cc.SoCCCD
        JOIN QuanHuyen qh ON qh.MaQH = cc.MaQH
    "

        ' Thực thi SQL
        Dim reader As SqlDataReader = ExecuteSQL(sql)

        If reader IsNot Nothing Then
            While reader.Read()
                Dim cdsp As New CongDan_SaiPham()

                cdsp.MaSaiPham = reader("MaSaiPham").ToString()
                cdsp.SoCCCD = reader("SoCCCD").ToString()
                cdsp.LoiSaiPham = reader("LoiSaiPham").ToString()
                cdsp.NgaySai = Convert.ToDateTime(reader("NgaySai"))
                cdsp.NoiSaiPham = reader("NoiSaiPham").ToString()
                cdsp.MucPhat = If(IsDBNull(reader("MucPhat")), CType(Nothing, Decimal?), Convert.ToDecimal(reader("MucPhat")))
                cdsp.TrangThai = reader("TrangThai").ToString()

                cdsp.HoTen = reader("HoTen").ToString()
                cdsp.NgaySinh = Convert.ToDateTime(reader("NgaySinh"))
                cdsp.GioiTinh = reader("GioiTinh").ToString()
                cdsp.DanToc = reader("DanToc").ToString()
                cdsp.TonGiao = reader("TonGiao").ToString()
                cdsp.QueQuan = reader("QueQuan").ToString()
                cdsp.QH = reader("TenQH").ToString()

                result.Add(cdsp)
            End While

            reader.Close()
        End If

        Return result
    End Function

End Class