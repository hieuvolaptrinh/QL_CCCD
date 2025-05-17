Imports System.Data.SqlClient

Public Class CongDan_SaiPham
    Private maSaiPhamField As String
    Private soCCCDField As String
    Private loiSaiPhamField As String
    Private ngaySaiField As Date
    Private noiSaiPhamField As String
    Private mucPhatField As Decimal
    Private trangThaiField As String
    Private hoTenField As String

    Public Property MaSaiPham As String
        Get
            Return maSaiPhamField
        End Get
        Set(value As String)
            maSaiPhamField = value
        End Set
    End Property

    Public Property SoCCCD As String
        Get
            Return soCCCDField
        End Get
        Set(value As String)
            soCCCDField = value
        End Set
    End Property

    Public Property LoiSaiPham As String
        Get
            Return loiSaiPhamField
        End Get
        Set(value As String)
            loiSaiPhamField = value
        End Set
    End Property

    Public Property NgaySai As Date
        Get
            Return ngaySaiField
        End Get
        Set(value As Date)
            ngaySaiField = value
        End Set
    End Property

    Public Property NoiSaiPham As String
        Get
            Return noiSaiPhamField
        End Get
        Set(value As String)
            noiSaiPhamField = value
        End Set
    End Property

    Public Property MucPhat As Decimal?
        Get
            Return mucPhatField
        End Get
        Set(value As Decimal?)
            mucPhatField = value
        End Set
    End Property

    Public Property TrangThai As String
        Get
            Return trangThaiField
        End Get
        Set(value As String)
            trangThaiField = value
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

    Public Sub New()
        ' Khởi tạo giá trị mặc định
        maSaiPhamField = ""
        soCCCDField = ""
        loiSaiPhamField = ""
        ngaySaiField = Date.Now
        noiSaiPhamField = ""
        mucPhatField = 0
        trangThaiField = "Chưa xử lý"
        hoTenField = ""
    End Sub

    Public Sub New(maSaiPham As String, soCCCD As String, loiSaiPham As String, 
                  ngaySai As Date, noiSaiPham As String, mucPhat As Decimal, 
                  trangThai As String, hoTen As String)
        Me.maSaiPhamField = maSaiPham
        Me.soCCCDField = soCCCD
        Me.loiSaiPhamField = loiSaiPham
        Me.ngaySaiField = ngaySai
        Me.noiSaiPhamField = noiSaiPham
        Me.mucPhatField = mucPhat
        Me.trangThaiField = trangThai
        Me.hoTenField = hoTen
    End Sub

    Public Shared Function GetAllCongDan_SP() As List(Of CongDan_SaiPham)
        Dim result As New List(Of CongDan_SaiPham)()

        ' Câu lệnh SQL
        Dim sql As String = "
        SELECT sp.MaSaiPham, sp.SoCCCD, sp.LoiSaiPham, sp.NgaySai, sp.NoiSaiPham, sp.MucPhat, sp.TrangThai,
               cc.HoTen, cc.NgaySinh, cc.GioiTinh, cc.QueQuan, cc.NoiO
        FROM SaiPham sp
        JOIN CongDanCCCD cc ON sp.SoCCCD = cc.SoCCCD"

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


                result.Add(cdsp)
            End While

            reader.Close()
        End If

        Return result
    End Function

End Class