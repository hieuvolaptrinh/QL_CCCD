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
            Dim sql As String = "SELECT sp.maSaiPham, sp.soCCCD, sp.loiSaiPham, sp.ngaySai, " & _
                               "sp.noiSaiPham, sp.mucPhat, sp.trangThai, " & _
                               "cd.hoTen " & _
                               "FROM SaiPham sp " & _
                               "INNER JOIN CongDanCCCD cd ON sp.soCCCD = cd.soCCCD " & _
                               "WHERE (@tenNguoiDung = '' OR cd.hoTen LIKE '%' + @tenNguoiDung + '%') " & _
                               "AND (@trangThai = 'Tất cả trạng thái' OR sp.trangThai = @trangThai)"

            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@tenNguoiDung", If(String.IsNullOrEmpty(tenNguoiDung), "", tenNguoiDung))
                cmd.Parameters.AddWithValue("@trangThai", trangThai)

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
