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
            Dim query As String = "SELECT SoCCCD, HoTen, NgaySinh, GioiTinh, QueQuan, NoiO, NgayCap, NoiCap " &
                                 "FROM CongDanCCCD"
            Dim cmd As New SqlCommand(query, conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim congDan As New CongDanCCCD()
                congDan.SoCCCD = reader("SoCCCD").ToString()
                congDan.HoTen = reader("HoTen").ToString()
                congDan.NgaySinh = Convert.ToDateTime(reader("NgaySinh"))
                congDan.GioiTinh = reader("GioiTinh").ToString()
                congDan.QueQuan = If(reader("QueQuan") Is DBNull.Value, String.Empty, reader("QueQuan").ToString())
                congDan.NoiO = If(reader("NoiO") Is DBNull.Value, String.Empty, reader("NoiO").ToString())
                congDan.NgayCap = Convert.ToDateTime(reader("NgayCap"))
                congDan.NoiCap = reader("NoiCap").ToString()
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
    Public Function TimKiemCongDan(soCCCD As String, hoTen As String, queQuan As String, 
                                noiO As String, noiCap As String, gioiTinh As String) As List(Of CongDanCCCD)
        Dim danhSach As New List(Of CongDanCCCD)()
        Dim conditions As New List(Of String)()
        Dim parameters As New List(Of SqlParameter)()

        Try
            conn.Open()
            Dim query As String = "SELECT SoCCCD, HoTen, NgaySinh, GioiTinh, QueQuan, NoiO, NgayCap, NoiCap " &
                                 "FROM CongDanCCCD"

            ' Thêm điều kiện tìm kiếm cho từng trường nếu có giá trị
            If Not String.IsNullOrEmpty(soCCCD) Then
                conditions.Add("SoCCCD LIKE @SoCCCD + '%'")
                parameters.Add(New SqlParameter("@SoCCCD", soCCCD))
            End If

            If Not String.IsNullOrEmpty(hoTen) Then
                conditions.Add("HoTen LIKE N'%' + @HoTen + '%'")
                parameters.Add(New SqlParameter("@HoTen", hoTen))
            End If

            If Not String.IsNullOrEmpty(queQuan) Then
                conditions.Add("QueQuan LIKE N'%' + @QueQuan + '%'")
                parameters.Add(New SqlParameter("@QueQuan", queQuan))
            End If

            If Not String.IsNullOrEmpty(noiO) Then
                conditions.Add("NoiO LIKE N'%' + @NoiO + '%'")
                parameters.Add(New SqlParameter("@NoiO", noiO))
            End If

            If Not String.IsNullOrEmpty(noiCap) Then
                conditions.Add("NoiCap LIKE N'%' + @NoiCap + '%'")
                parameters.Add(New SqlParameter("@NoiCap", noiCap))
            End If

            If Not String.IsNullOrEmpty(gioiTinh) Then
                conditions.Add("GioiTinh = @GioiTinh")
                parameters.Add(New SqlParameter("@GioiTinh", gioiTinh))
            End If

            ' Nếu có ít nhất 1 điều kiện, thêm WHERE vào truy vấn
            If conditions.Count > 0 Then
                query &= " WHERE " & String.Join(" AND ", conditions)
            End If

            ' Thêm ORDER BY để sắp xếp kết quả
            query &= " ORDER BY HoTen ASC"

            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddRange(parameters.ToArray())
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim congDan As New CongDanCCCD()
                congDan.SoCCCD = reader("SoCCCD").ToString()
                congDan.HoTen = reader("HoTen").ToString()
                congDan.NgaySinh = Convert.ToDateTime(reader("NgaySinh"))
                congDan.GioiTinh = reader("GioiTinh").ToString()
                congDan.QueQuan = If(reader("QueQuan") Is DBNull.Value, String.Empty, reader("QueQuan").ToString())
                congDan.NoiO = If(reader("NoiO") Is DBNull.Value, String.Empty, reader("NoiO").ToString())
                congDan.NgayCap = Convert.ToDateTime(reader("NgayCap"))
                congDan.NoiCap = reader("NoiCap").ToString()
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
            Dim query As String = "INSERT INTO CongDanCCCD (SoCCCD, HoTen, NgaySinh, GioiTinh, QueQuan, NoiO, NgayCap, NoiCap) " &
                                 "VALUES (@SoCCCD, @HoTen, @NgaySinh, @GioiTinh, @QueQuan, @NoiO, @NgayCap, @NoiCap)"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@SoCCCD", congDan.SoCCCD)
            cmd.Parameters.AddWithValue("@HoTen", congDan.HoTen)
            cmd.Parameters.AddWithValue("@NgaySinh", congDan.NgaySinh)
            cmd.Parameters.AddWithValue("@GioiTinh", congDan.GioiTinh)
            cmd.Parameters.AddWithValue("@QueQuan", If(String.IsNullOrEmpty(congDan.QueQuan), DBNull.Value, congDan.QueQuan))
            cmd.Parameters.AddWithValue("@NoiO", If(String.IsNullOrEmpty(congDan.NoiO), DBNull.Value, congDan.NoiO))
            cmd.Parameters.AddWithValue("@NgayCap", congDan.NgayCap)
            cmd.Parameters.AddWithValue("@NoiCap", congDan.NoiCap)

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
                                 "QueQuan = @QueQuan, NoiO = @NoiO, NgayCap = @NgayCap, NoiCap = @NoiCap " &
                                 "WHERE SoCCCD = @SoCCCD"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@SoCCCD", congDan.SoCCCD)
            cmd.Parameters.AddWithValue("@HoTen", congDan.HoTen)
            cmd.Parameters.AddWithValue("@NgaySinh", congDan.NgaySinh)
            cmd.Parameters.AddWithValue("@GioiTinh", congDan.GioiTinh)
            cmd.Parameters.AddWithValue("@QueQuan", If(String.IsNullOrEmpty(congDan.QueQuan), DBNull.Value, congDan.QueQuan))
            cmd.Parameters.AddWithValue("@NoiO", If(String.IsNullOrEmpty(congDan.NoiO), DBNull.Value, congDan.NoiO))
            cmd.Parameters.AddWithValue("@NgayCap", congDan.NgayCap)
            cmd.Parameters.AddWithValue("@NoiCap", congDan.NoiCap)

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
    Public Function LayTatCaCongDan() As DataTable
        Dim dataTable As New DataTable()
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM CongDanCCCD"
            Using cmd As New SqlCommand(query, conn)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dataTable)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Lỗi khi lấy dữ liệu công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
        Return dataTable
    End Function

    Public Function LayThongTinCongDan(soCCCD As String) As CongDanCCCD
        Dim congDan As New CongDanCCCD()

        Try
            conn.Open()
            Dim query As String = "SELECT SoCCCD, HoTen, NgaySinh, GioiTinh, QueQuan, NoiO, NgayCap, NoiCap " &
                                 "FROM CongDanCCCD WHERE SoCCCD = @SoCCCD"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@SoCCCD", soCCCD)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                congDan.SoCCCD = reader("SoCCCD").ToString()
                congDan.HoTen = reader("HoTen").ToString()
                congDan.NgaySinh = Convert.ToDateTime(reader("NgaySinh"))
                congDan.GioiTinh = reader("GioiTinh").ToString()
                congDan.QueQuan = If(reader("QueQuan") Is DBNull.Value, String.Empty, reader("QueQuan").ToString())
                congDan.NoiO = If(reader("NoiO") Is DBNull.Value, String.Empty, reader("NoiO").ToString())
                congDan.NgayCap = Convert.ToDateTime(reader("NgayCap"))
                congDan.NoiCap = reader("NoiCap").ToString()
            Else
                MessageBox.Show("Không tìm thấy công dân với số CCCD này.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                congDan = Nothing
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Lỗi khi lấy thông tin công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            congDan = Nothing
        Finally
            conn.Close()
        End Try

        Return congDan
    End Function
End Class