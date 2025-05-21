Imports System.Data.SqlClient

Public Class ViPhamDao
    Public Function GetAllCongDanSaiPham() As List(Of CongDan_SaiPham)
        Dim dsSaiPham As New List(Of CongDan_SaiPham)
        Try
            Dim sql As String = "SELECT sp.maSaiPham, sp.soCCCD, sp.loiSaiPham, sp.ngaySai, " &
                               "sp.noiSaiPham, sp.mucPhat, sp.trangThai, " &
                               "cd.hoTen " &
                               "FROM SaiPham sp " &
                               "INNER JOIN CongDanCCCD cd ON sp.soCCCD = cd.soCCCD"

            Dim reader As SqlDataReader = ExecuteSQL(sql)
            If reader IsNot Nothing Then
                While reader.Read()
                    Dim saiPham As New CongDan_SaiPham With {
                        .MaSaiPham = reader("maSaiPham").ToString(),
                        .SoCCCD = reader("soCCCD").ToString(),
                        .LoiSaiPham = reader("loiSaiPham").ToString(),
                        .NgaySai = Convert.ToDateTime(reader("ngaySai")),
                        .NoiSaiPham = If(reader("noiSaiPham") Is DBNull.Value, "", reader("noiSaiPham").ToString()),
                        .MucPhat = If(reader("mucPhat") Is DBNull.Value, 0, Convert.ToDecimal(reader("mucPhat"))),
                        .TrangThai = reader("trangThai").ToString(),
                        .HoTen = reader("hoTen").ToString()
                    }
                    dsSaiPham.Add(saiPham)
                End While
                reader.Close()
            End If
        Catch ex As Exception
            Throw New Exception("Lỗi khi lấy danh sách sai phạm: " & ex.Message)
        End Try

        Return dsSaiPham
    End Function

    Public Function GetCongDanSaiPhamByFilter(ByVal tenNguoiDung As String, ByVal trangThai As String, cccd As String) As List(Of CongDan_SaiPham)
        Dim dsSaiPham As New List(Of CongDan_SaiPham)
        Try
            Dim sql As String = "SELECT sp.maSaiPham, sp.soCCCD, sp.loiSaiPham, sp.ngaySai, " &
                               "sp.noiSaiPham, sp.mucPhat, sp.trangThai, " &
                               "cd.hoTen " &
                               "FROM SaiPham sp " &
                               "INNER JOIN CongDanCCCD cd ON sp.soCCCD = cd.soCCCD " &
                               "WHERE 1=1 "

            If Not String.IsNullOrWhiteSpace(tenNguoiDung) Then
                sql &= "AND cd.hoTen LIKE N'%' + @tenNguoiDung + '%' "
            End If
            If Not String.IsNullOrWhiteSpace(cccd) Then
                sql &= "AND cd.soCCCD LIKE N'%' + @cccd + '%' "
            End If

            If trangThai <> "Tất cả trạng thái" Then
                sql &= "AND sp.trangThai = @trangThai "
            End If

            Dim conn As SqlConnection = ConnectDatabase()
            Try
                conn.Open()
                Using cmd As New SqlCommand(sql, conn)
                    If Not String.IsNullOrWhiteSpace(tenNguoiDung) Then
                        cmd.Parameters.AddWithValue("@tenNguoiDung", tenNguoiDung)
                    End If
                    If Not String.IsNullOrWhiteSpace(cccd) Then
                        cmd.Parameters.AddWithValue("@cccd", cccd)
                    End If
                    If trangThai <> "Tất cả trạng thái" Then
                        cmd.Parameters.AddWithValue("@trangThai", trangThai)
                    End If

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim saiPham As New CongDan_SaiPham With {
                                .MaSaiPham = reader("maSaiPham").ToString(),
                                .SoCCCD = reader("soCCCD").ToString(),
                                .LoiSaiPham = reader("loiSaiPham").ToString(),
                                .NgaySai = Convert.ToDateTime(reader("ngaySai")),
                                .NoiSaiPham = If(reader("noiSaiPham") Is DBNull.Value, "", reader("noiSaiPham").ToString()),
                                .MucPhat = If(reader("mucPhat") Is DBNull.Value, 0, Convert.ToDecimal(reader("mucPhat"))),
                                .TrangThai = reader("trangThai").ToString(),
                                .HoTen = reader("hoTen").ToString()
                            }
                            dsSaiPham.Add(saiPham)
                        End While
                    End Using
                End Using
            Finally
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End Try
        Catch ex As Exception
            Throw New Exception("Lỗi khi lọc danh sách sai phạm: " & ex.Message)
        End Try

        Return dsSaiPham
    End Function
    Public Function soLuongViPham() As Integer
        Dim soLuong As Integer = 0

        Dim query As String = "SELECT COUNT(*) FROM SaiPham"
            Dim conn As SqlConnection = ConnectDatabase()

            conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    soLuong = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If


        Return soLuong
    End Function


End Class
