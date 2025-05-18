Imports System.Data.SqlClient

Public Class ViPhamDao
    Private connStr As String = "Data Source=HIEUVO;Initial Catalog=QuanLyCCCD;Persist Security Info=True;User ID=sa;Password=sa;TrustServerCertificate=True"
    Private conn As SqlConnection

    Public Sub New()
        conn = New SqlConnection(connStr)
    End Sub

    Public Function GetAllCongDanSaiPham() As List(Of CongDan_SaiPham)
        Dim dsSaiPham As New List(Of CongDan_SaiPham)
        Try
            conn.Open()
            Dim sql As String = "SELECT sp.maSaiPham, sp.soCCCD, sp.loiSaiPham, sp.ngaySai, " & _
                               "sp.noiSaiPham, sp.mucPhat, sp.trangThai, " & _
                               "cd.hoTen " & _
                               "FROM SaiPham sp " & _
                               "INNER JOIN CongDanCCCD cd ON sp.soCCCD = cd.soCCCD"

            Using cmd As New SqlCommand(sql, conn)
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

        Catch ex As Exception
            Throw New Exception("Lỗi khi lấy danh sách sai phạm: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Return dsSaiPham
    End Function

    Public Function GetCongDanSaiPhamByFilter(ByVal tenNguoiDung As String, ByVal trangThai As String) As List(Of CongDan_SaiPham)
        Dim dsSaiPham As New List(Of CongDan_SaiPham)
        Try
            conn.Open()
            Dim sql As String = "SELECT sp.maSaiPham, sp.soCCCD, sp.loiSaiPham, sp.ngaySai, " &
                               "sp.noiSaiPham, sp.mucPhat, sp.trangThai, " &
                               "cd.hoTen " &
                               "FROM SaiPham sp " &
                               "INNER JOIN CongDanCCCD cd ON sp.soCCCD = cd.soCCCD " &
                               "WHERE 1=1 "

            ' Thêm điều kiện tìm kiếm theo tên nếu có
            If Not String.IsNullOrWhiteSpace(tenNguoiDung) Then
                sql &= "AND cd.hoTen LIKE @tenNguoiDung "
            End If

            ' Thêm điều kiện tìm kiếm theo trạng thái nếu không phải "Tất cả trạng thái"
            If trangThai <> "Tất cả trạng thái" Then
                sql &= "AND sp.trangThai = @trangThai "
            End If

            Using cmd As New SqlCommand(sql, conn)
                ' Thêm parameter cho tên người dùng nếu có
                If Not String.IsNullOrWhiteSpace(tenNguoiDung) Then
                    cmd.Parameters.AddWithValue("@tenNguoiDung", "%" & tenNguoiDung & "%")
                End If

                ' Thêm parameter cho trạng thái nếu không phải "Tất cả trạng thái"
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

        Catch ex As Exception
            Throw New Exception("Lỗi khi lọc danh sách sai phạm: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

        Return dsSaiPham
    End Function
End Class
