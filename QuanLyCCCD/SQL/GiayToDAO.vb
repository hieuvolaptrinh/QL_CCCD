Imports System.Data.SqlClient

Public Class GiayToDAO
    Private connStr As String = "Data Source=HIEUVO;Initial Catalog=QuanLyCCCD;Persist Security Info=True;User ID=sa;Password=sa;TrustServerCertificate=True"
    Private conn As SqlConnection

    Public Sub New()
        conn = New SqlConnection(connStr)
    End Sub

    ' Tìm kiếm giấy tờ liên quan theo 3 tiêu chí (SoCCCD, SoGiayTo, LoaiGiayTo)
    Public Function TimKiemGiayTo(soCCCD As String, soGiayTo As String, loaiGiayTo As String) As List(Of GiayToLienQuan)
        Dim danhSachGiayTo As New List(Of GiayToLienQuan)()
        Dim conditions As New List(Of String)()
        Dim parameters As New List(Of SqlParameter)()

        Try
            conn.Open()
            Dim query As String = "SELECT SoGiayTo, SoCCCD, LoaiGiayTo, NgayCap, NoiCap, NgayHetHan, ChiTiet " &
                                 "FROM GiayToLienQuan"

            If Not String.IsNullOrEmpty(soCCCD) Then
                conditions.Add("SoCCCD = @SoCCCD")
                parameters.Add(New SqlParameter("@SoCCCD", soCCCD))
            End If

            If Not String.IsNullOrEmpty(soGiayTo) Then
                conditions.Add("SoGiayTo = @SoGiayTo")
                parameters.Add(New SqlParameter("@SoGiayTo", soGiayTo))
            End If

            If Not String.IsNullOrEmpty(loaiGiayTo) Then
                conditions.Add("LoaiGiayTo = @LoaiGiayTo")
                parameters.Add(New SqlParameter("@LoaiGiayTo", loaiGiayTo))
            End If

            If conditions.Count > 0 Then
                query &= " WHERE " & String.Join(" AND ", conditions)
            End If

            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddRange(parameters.ToArray())
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim giayTo As New GiayToLienQuan()
                giayTo.SoGiayTo = reader("SoGiayTo").ToString()
                giayTo.SoCCCD = reader("SoCCCD").ToString()
                giayTo.LoaiGiayTo = reader("LoaiGiayTo").ToString()
                giayTo.NgayCap = Convert.ToDateTime(reader("NgayCap"))
                giayTo.NoiCap = reader("NoiCap").ToString()
                giayTo.NgayHetHan = If(reader("NgayHetHan") Is DBNull.Value, Nothing, Convert.ToDateTime(reader("NgayHetHan")))
                giayTo.ChiTiet = If(reader("ChiTiet") Is DBNull.Value, String.Empty, reader("ChiTiet").ToString())
                danhSachGiayTo.Add(giayTo)
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Lỗi khi tìm kiếm giấy tờ: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        Return danhSachGiayTo
    End Function

    ' Lấy thông tin công dân theo SoCCCD
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

    ' Cập nhật thông tin giấy tờ trong cơ sở dữ liệu
    Public Sub CapNhatGiayTo(giayTo As GiayToLienQuan)
        Try
            ' Kiểm tra các trường bắt buộc
            If String.IsNullOrEmpty(giayTo.SoGiayTo) Then
                MessageBox.Show("Mã Số giấy tờ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            If String.IsNullOrEmpty(giayTo.LoaiGiayTo) Then
                MessageBox.Show("Loại Giấy Tờ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            If String.IsNullOrEmpty(giayTo.SoCCCD) Then
                MessageBox.Show("Số CCCD không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            conn.Open()
            Dim query As String = "UPDATE GiayToLienQuan " &
                                 "SET LoaiGiayTo = @LoaiGiayTo, SoCCCD = @SoCCCD, NoiCap = @NoiCap, NgayCap = @NgayCap, NgayHetHan = @NgayHetHan, ChiTiet = @ChiTiet " &
                                 "WHERE SoGiayTo = @SoGiayTo"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@SoGiayTo", giayTo.SoGiayTo)
            cmd.Parameters.AddWithValue("@SoCCCD", giayTo.SoCCCD)
            cmd.Parameters.AddWithValue("@LoaiGiayTo", giayTo.LoaiGiayTo)
            cmd.Parameters.AddWithValue("@NoiCap", If(String.IsNullOrEmpty(giayTo.NoiCap), "", giayTo.NoiCap))
            cmd.Parameters.AddWithValue("@NgayCap", giayTo.NgayCap.Date)
            cmd.Parameters.AddWithValue("@NgayHetHan", If(giayTo.NgayHetHan.HasValue, giayTo.NgayHetHan.Value.Date, DBNull.Value))
            cmd.Parameters.AddWithValue("@ChiTiet", If(String.IsNullOrEmpty(giayTo.ChiTiet), "", giayTo.ChiTiet))

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Cập nhật giấy tờ thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Không tìm thấy giấy tờ để cập nhật.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi cập nhật giấy tờ: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Xóa giấy tờ khỏi cơ sở dữ liệu
    Public Sub XoaGiayTo(soGiayTo As String)
        Try
            conn.Open()
            Dim query As String = "DELETE FROM GiayToLienQuan WHERE SoGiayTo = @SoGiayTo"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@SoGiayTo", soGiayTo)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Xóa giấy tờ thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Không tìm thấy giấy tờ để xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi xóa giấy tờ: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Thêm giấy phép lái xe (GPLX)
    Public Sub ThemGPLX(giayTo As GiayToLienQuan)
        Try
            conn.Open()
            Dim query As String = "INSERT INTO GiayToLienQuan (SoGiayTo, SoCCCD, LoaiGiayTo, NgayCap, NoiCap, NgayHetHan, ChiTiet) " &
                                 "VALUES (@SoGiayTo, @SoCCCD, @LoaiGiayTo, @NgayCap, @NoiCap, @NgayHetHan, @ChiTiet)"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@SoGiayTo", giayTo.SoGiayTo)
            cmd.Parameters.AddWithValue("@SoCCCD", giayTo.SoCCCD)
            cmd.Parameters.AddWithValue("@LoaiGiayTo", "Giấy Phép Lái Xe")
            cmd.Parameters.AddWithValue("@NgayCap", giayTo.NgayCap.Date)
            cmd.Parameters.AddWithValue("@NoiCap", If(String.IsNullOrEmpty(giayTo.NoiCap), "", giayTo.NoiCap))
            cmd.Parameters.AddWithValue("@NgayHetHan", If(giayTo.NgayHetHan.HasValue, giayTo.NgayHetHan.Value.Date, DBNull.Value))
            cmd.Parameters.AddWithValue("@ChiTiet", If(String.IsNullOrEmpty(giayTo.ChiTiet), "", giayTo.ChiTiet))

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Thêm giấy phép lái xe thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Không thể thêm giấy phép lái xe.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi thêm GPLX: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Thêm bảo hiểm y tế (BHYT)
    Public Sub ThemBHYT(giayTo As GiayToLienQuan)
        Try
            conn.Open()
            Dim query As String = "INSERT INTO GiayToLienQuan (SoGiayTo, SoCCCD, LoaiGiayTo, NgayCap, NoiCap, NgayHetHan, ChiTiet) " &
                                 "VALUES (@SoGiayTo, @SoCCCD, @LoaiGiayTo, @NgayCap, @NoiCap, @NgayHetHan, @ChiTiet)"
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@SoGiayTo", giayTo.SoGiayTo)
            cmd.Parameters.AddWithValue("@SoCCCD", giayTo.SoCCCD)
            cmd.Parameters.AddWithValue("@LoaiGiayTo", "Bảo Hiểm Y Tế")
            cmd.Parameters.AddWithValue("@NgayCap", giayTo.NgayCap.Date)
            cmd.Parameters.AddWithValue("@NoiCap", If(String.IsNullOrEmpty(giayTo.NoiCap), "", giayTo.NoiCap))
            cmd.Parameters.AddWithValue("@NgayHetHan", If(giayTo.NgayHetHan.HasValue, giayTo.NgayHetHan.Value.Date, DBNull.Value))
            cmd.Parameters.AddWithValue("@ChiTiet", If(String.IsNullOrEmpty(giayTo.ChiTiet), "", giayTo.ChiTiet))

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Thêm bảo hiểm y tế thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Không thể thêm bảo hiểm y tế.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi thêm BHYT: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
End Class