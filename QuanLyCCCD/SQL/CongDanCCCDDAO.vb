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
            Dim query As String = "SELECT SoCCCD, HoTen, NgaySinh, GioiTinh, QueQuan, NoiO, NgayCap, NoiCap " &
                                 "FROM CongDanCCCD"

            Dim reader As SqlDataReader = ExecuteSQL(query)
            If reader IsNot Nothing Then
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
                reader.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi lấy danh sách công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return danhSach
    End Function

    ' Thêm công dân mới
    Public Sub ThemCongDan(congDan As CongDanCCCD)
        Try
            Dim conn As SqlConnection = ConnectDatabase()
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
                End If
            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        Catch ex As Exception
            MessageBox.Show("Lỗi khi thêm công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub SuaCongDan(congDan As CongDanCCCD)
        Try
            Dim conn As SqlConnection = ConnectDatabase()
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
                End If
            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        Catch ex As Exception
            MessageBox.Show("Lỗi khi sửa thông tin công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub XoaCongDan(soCCCD As String)
        Try
            Dim conn As SqlConnection = ConnectDatabase()
            Try
                conn.Open()
                Dim query As String = "DELETE FROM CongDanCCCD WHERE SoCCCD = @SoCCCD"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@SoCCCD", soCCCD)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        Catch ex As Exception
            MessageBox.Show("Lỗi khi xóa công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Function DemSoLuongCongDan() As Integer
        Dim soLuong As Integer = 0
        Try
            Dim query As String = "SELECT COUNT(*) FROM CongDanCCCD"
            Dim conn As SqlConnection = ConnectDatabase()
            Try
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    soLuong = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        Catch ex As Exception
            MessageBox.Show("Lỗi khi đếm số lượng công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return soLuong
    End Function


End Class