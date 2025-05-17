Imports System.Data.SqlClient

Public Class DiaChiDAO
    Private connStr As String = "Data Source=HIEUVO;Initial Catalog=QuanLyCCCD;Persist Security Info=True;User ID=sa;Password=sa;TrustServerCertificate=True"
    Private conn As SqlConnection

    Public Sub New()
        conn = New SqlConnection(connStr)
    End Sub

    ' Lấy dữ liệu tỉnh thành và quận huyện từ cơ sở dữ liệu
    Public Function GetTinhHuyenData() As Dictionary(Of TinhTP, List(Of QuanHuyen))
        Dim tinhHuyenData As New Dictionary(Of TinhTP, List(Of QuanHuyen))()

        Try
            conn.Open()
            Dim query As String = "SELECT TinhTP.maTTP, TinhTP.tenTTP, QuanHuyen.maQH, QuanHuyen.tenQH, QuanHuyen.maTTP AS QuanHuyen_maTTP " &
                                 "FROM TinhTP " &
                                 "LEFT JOIN QuanHuyen ON TinhTP.maTTP = QuanHuyen.maTTP " &
                                 "ORDER BY TinhTP.tenTTP, QuanHuyen.tenQH"
            Dim cmd As New SqlCommand(query, conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim tinh As New TinhTP()
                tinh.MaTTP = reader("maTTP").ToString()
                tinh.TenTTP = reader("tenTTP").ToString()

                If Not tinhHuyenData.ContainsKey(tinh) Then
                    tinhHuyenData(tinh) = New List(Of QuanHuyen)()
                End If

                If Not reader("maQH") Is DBNull.Value Then
                    Dim huyen As New QuanHuyen()
                    huyen.MaQH = reader("maQH").ToString()
                    huyen.TenQH = reader("tenQH").ToString()
                    huyen.MaTTP = reader("QuanHuyen_maTTP").ToString()
                    tinhHuyenData(tinh).Add(huyen)
                End If
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Lỗi khi lấy dữ liệu tỉnh huyện: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        Return tinhHuyenData
    End Function

    ' Lấy danh sách công dân theo quận huyện (maQH)
    Public Function GetCongDanByQuanHuyen(maQH As String) As List(Of CongDanCCCD)
        Dim danhSachCongDan As New List(Of CongDanCCCD)()

        Try
            conn.Open()
            Dim query As String = "SELECT SoCCCD, HoTen, NgaySinh, GioiTinh, DanToc, TonGiao, QueQuan, MaQH, NgayCap, NoiCap, NgayHetHan " &
                                 "FROM CongDanCCCD WHERE maQH = @maQH"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@maQH", maQH)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim congDan As New CongDanCCCD()
                congDan.SoCCCD = reader("SoCCCD").ToString()
                congDan.HoTen = reader("HoTen").ToString()
                congDan.NgaySinh = Convert.ToDateTime(reader("NgaySinh"))
                congDan.GioiTinh = reader("GioiTinh").ToString()
                congDan.DanToc = If(reader("DanToc") Is DBNull.Value, String.Empty, reader("DanToc").ToString())
                congDan.TonGiao = If(reader("TonGiao") Is DBNull.Value, String.Empty, reader("TonGiao").ToString())
                congDan.QueQuan = If(reader("QueQuan") Is DBNull.Value, String.Empty, reader("QueQuan").ToString())
                congDan.MaQH = If(reader("MaQH") Is DBNull.Value, String.Empty, reader("MaQH").ToString())
                congDan.NgayCap = Convert.ToDateTime(reader("NgayCap"))
                congDan.NoiCap = reader("NoiCap").ToString()
                congDan.NgayHetHan = If(reader("NgayHetHan") Is DBNull.Value, Nothing, Convert.ToDateTime(reader("NgayHetHan")))
                danhSachCongDan.Add(congDan)
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Lỗi khi lấy danh sách công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        Return danhSachCongDan
    End Function

    ' Lấy maQH dựa trên tên quận huyện và tỉnh thành
    Public Function GetMaQH(tinh As String, huyen As String) As String
        Dim maQH As String = ""

        Try
            conn.Open()
            Dim query As String = "SELECT QuanHuyen.maQH " &
                                 "FROM QuanHuyen " &
                                 "JOIN TinhTP ON QuanHuyen.maTTP = TinhTP.maTTP " &
                                 "WHERE TinhTP.tenTTP = @tenTTP AND QuanHuyen.tenQH = @tenQH"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@tenTTP", tinh)
            cmd.Parameters.AddWithValue("@tenQH", huyen)
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                maQH = result.ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi lấy mã quận huyện: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        Return maQH
    End Function
End Class