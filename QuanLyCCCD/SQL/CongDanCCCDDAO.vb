Imports System.Data.SqlClient

Public Class CongDanCCCDDao
    Private connStr As String = "Data Source=HIEUVO;Initial Catalog=QuanLyCCCD;Persist Security Info=True;User ID=sa;Password=sa;TrustServerCertificate=True"
    Private conn As SqlConnection

    Public Sub New()
        conn = New SqlConnection(connStr)
    End Sub

    ' Lấy tất cả thông tin công dân và CCCD
    Public Function LayDanhSachCongDan() As List(Of CongDanCCCD)
        Dim danhSach As New List(Of CongDanCCCD)()

        Try
            conn.Open()
            Dim query As String = "SELECT SoCCCD, HoTen, NgaySinh, GioiTinh, DanToc, TonGiao, QueQuan, MaQH, NgayCap, NoiCap, NgayHetHan " &
                                 "FROM CongDanCCCD"
            Dim cmd As New SqlCommand(query, conn)
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
                danhSach.Add(congDan)
            End While
        Catch ex As Exception
            MessageBox.Show("Lỗi khi lấy danh sách công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        Return danhSach
    End Function

    ' Tìm kiếm công dân theo 3 tiêu chí (SoCCCD, HoTen, QueQuan)
    Public Function TimKiemCongDan(soCCCD As String, hoTen As String, queQuan As String) As List(Of CongDanCCCD)
        Dim danhSach As New List(Of CongDanCCCD)()
        Dim conditions As New List(Of String)()
        Dim parameters As New List(Of SqlParameter)()

        Try
            conn.Open()
            Dim query As String = "SELECT SoCCCD, HoTen, NgaySinh, GioiTinh, DanToc, TonGiao, QueQuan, MaQH, NgayCap, NoiCap, NgayHetHan " &
                                 "FROM CongDanCCCD"

            ' Thêm điều kiện nếu dữ liệu đầu vào không rỗng
            If Not String.IsNullOrEmpty(soCCCD) Then
                conditions.Add("SoCCCD = @SoCCCD")
                parameters.Add(New SqlParameter("@SoCCCD", soCCCD))
            End If

            If Not String.IsNullOrEmpty(hoTen) Then
                conditions.Add("HoTen LIKE '%' + @HoTen + '%'")
                parameters.Add(New SqlParameter("@HoTen", hoTen))
            End If

            If Not String.IsNullOrEmpty(queQuan) Then
                conditions.Add("QueQuan LIKE '%' + @QueQuan + '%'")
                parameters.Add(New SqlParameter("@QueQuan", queQuan))
            End If

            ' Nếu có ít nhất 1 điều kiện, thêm WHERE vào truy vấn
            If conditions.Count > 0 Then
                query &= " WHERE " & String.Join(" AND ", conditions)
            End If

            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddRange(parameters.ToArray())
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
                danhSach.Add(congDan)
            End While
        Catch ex As Exception
            MessageBox.Show("Lỗi khi tìm kiếm công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        Return danhSach
    End Function

    ' Thêm công dân mới
    Public Sub ThemCongDan(congDan As CongDanCCCD)
        Try
            conn.Open()
            Dim query As String = "INSERT INTO CongDanCCCD (SoCCCD, HoTen, NgaySinh, GioiTinh, DanToc, TonGiao, QueQuan, MaQH, NgayCap, NoiCap, NgayHetHan) " &
                                 "VALUES (@SoCCCD, @HoTen, @NgaySinh, @GioiTinh, @DanToc, @TonGiao, @QueQuan, @MaQH, @NgayCap, @NoiCap, @NgayHetHan)"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@SoCCCD", congDan.SoCCCD)
            cmd.Parameters.AddWithValue("@HoTen", congDan.HoTen)
            cmd.Parameters.AddWithValue("@NgaySinh", congDan.NgaySinh)
            cmd.Parameters.AddWithValue("@GioiTinh", congDan.GioiTinh)
            cmd.Parameters.AddWithValue("@DanToc", If(String.IsNullOrEmpty(congDan.DanToc), DBNull.Value, congDan.DanToc))
            cmd.Parameters.AddWithValue("@TonGiao", If(String.IsNullOrEmpty(congDan.TonGiao), DBNull.Value, congDan.TonGiao))
            cmd.Parameters.AddWithValue("@QueQuan", If(String.IsNullOrEmpty(congDan.QueQuan), DBNull.Value, congDan.QueQuan))
            cmd.Parameters.AddWithValue("@MaQH", If(String.IsNullOrEmpty(congDan.MaQH), DBNull.Value, congDan.MaQH))
            cmd.Parameters.AddWithValue("@NgayCap", congDan.NgayCap)
            cmd.Parameters.AddWithValue("@NoiCap", congDan.NoiCap)
            cmd.Parameters.AddWithValue("@NgayHetHan", If(congDan.NgayHetHan.HasValue, congDan.NgayHetHan, DBNull.Value))

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Thêm công dân thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Không thể thêm công dân.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi thêm công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Sửa thông tin công dân
    Public Sub SuaCongDan(congDan As CongDanCCCD)
        Try
            conn.Open()
            Dim query As String = "UPDATE CongDanCCCD SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, " &
                                 "DanToc = @DanToc, TonGiao = @TonGiao, QueQuan = @QueQuan, MaQH = @MaQH, " &
                                 "NgayCap = @NgayCap, NoiCap = @NoiCap, NgayHetHan = @NgayHetHan " &
                                 "WHERE SoCCCD = @SoCCCD"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@SoCCCD", congDan.SoCCCD)
            cmd.Parameters.AddWithValue("@HoTen", congDan.HoTen)
            cmd.Parameters.AddWithValue("@NgaySinh", congDan.NgaySinh)
            cmd.Parameters.AddWithValue("@GioiTinh", congDan.GioiTinh)
            cmd.Parameters.AddWithValue("@DanToc", If(String.IsNullOrEmpty(congDan.DanToc), DBNull.Value, congDan.DanToc))
            cmd.Parameters.AddWithValue("@TonGiao", If(String.IsNullOrEmpty(congDan.TonGiao), DBNull.Value, congDan.TonGiao))
            cmd.Parameters.AddWithValue("@QueQuan", If(String.IsNullOrEmpty(congDan.QueQuan), DBNull.Value, congDan.QueQuan))
            cmd.Parameters.AddWithValue("@MaQH", If(String.IsNullOrEmpty(congDan.MaQH), DBNull.Value, congDan.MaQH))
            cmd.Parameters.AddWithValue("@NgayCap", congDan.NgayCap)
            cmd.Parameters.AddWithValue("@NoiCap", congDan.NoiCap)
            cmd.Parameters.AddWithValue("@NgayHetHan", If(congDan.NgayHetHan.HasValue, congDan.NgayHetHan, DBNull.Value))

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Sửa thông tin công dân thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Không tìm thấy công dân để sửa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi sửa thông tin công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Xóa công dân
    Public Sub XoaCongDan(soCCCD As String)
        Try
            conn.Open()
            Dim query As String = "DELETE FROM CongDanCCCD WHERE SoCCCD = @SoCCCD"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@SoCCCD", soCCCD)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Xóa công dân thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Không tìm thấy công dân để xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi xóa công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
End Class