Imports System.Data
Imports System.Data.SqlClient

Public Class HoSoLienQuan
    Private dao As New GiayToDAO()

    ' Hàm chuyển List(Of GiayToLienQuan) thành DataTable
    Private Function ConvertToDataTable(danhSach As List(Of GiayToLienQuan)) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Loại Giấy Tờ", GetType(String))
        dt.Columns.Add("Mã Số", GetType(String))
        dt.Columns.Add("Nơi Cấp", GetType(String))
        dt.Columns.Add("Ngày Cấp", GetType(Date))
        dt.Columns.Add("Ngày Hết Hạn", GetType(Object)) ' Hỗ trợ NULL
        dt.Columns.Add("Thông Tin Chi Tiết", GetType(String))

        For Each giayTo As GiayToLienQuan In danhSach
            Dim row As DataRow = dt.NewRow()
            row("Loại Giấy Tờ") = giayTo.LoaiGiayTo
            row("Mã Số") = giayTo.SoGiayTo
            row("Nơi Cấp") = giayTo.NoiCap
            row("Ngày Cấp") = giayTo.NgayCap
            row("Ngày Hết Hạn") = If(giayTo.NgayHetHan.HasValue, giayTo.NgayHetHan.Value, DBNull.Value)
            row("Thông Tin Chi Tiết") = giayTo.ChiTiet
            dt.Rows.Add(row)
        Next

        Return dt
    End Function

    Private Sub HoSoLienQuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cấu hình DataGridView
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    ' Sự kiện khi nhấn nút Tìm Kiếm
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        ' Dữ liệu đầu vào
        Dim soCCCD As String = txtSoCCCD.Text.Trim()
        Dim soGiayTo As String = txtSoGiayTo.Text.Trim()
        Dim loaiGiayTo As String = ComboBoxLoaiGiayTo.SelectedItem?.ToString()

        ' Kiểm tra xem có ít nhất 1 tiêu chí tìm kiếm không
        If String.IsNullOrEmpty(soCCCD) AndAlso String.IsNullOrEmpty(soGiayTo) AndAlso String.IsNullOrEmpty(loaiGiayTo) Then
            MessageBox.Show("Vui lòng nhập ít nhất một tiêu chí để tìm kiếm (Số CCCD, Số Giấy Tờ, hoặc Loại Giấy Tờ).", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Nếu có nhập Số CCCD, lấy thông tin công dân và hiển thị lên TextBox
        If Not String.IsNullOrEmpty(soCCCD) Then
            Dim congDan As CongDanCCCD = dao.LayThongTinCongDan(soCCCD)
            If congDan IsNot Nothing Then
                txtHoVaTen.Text = congDan.HoTen
                txtNgSinh.Text = congDan.NgaySinh.ToString("dd/MM/yyyy")
                txtQueQuan.Text = congDan.QueQuan
            Else
                ' Nếu không tìm thấy, xóa các TextBox
                txtHoVaTen.Text = ""
                txtNgSinh.Text = ""
                txtQueQuan.Text = ""
                DataGridView1.DataSource = Nothing
                Return
            End If
        Else
            ' Nếu không nhập Số CCCD, xóa thông tin công dân
            txtHoVaTen.Text = ""
            txtNgSinh.Text = ""
            txtQueQuan.Text = ""
        End If

        Dim danhSach As List(Of GiayToLienQuan) = dao.TimKiemGiayTo(soCCCD, soGiayTo, loaiGiayTo)
        Dim dt As DataTable = ConvertToDataTable(danhSach)
        If dt.Rows.Count = 0 Then
            MessageBox.Show("Không tìm thấy giấy tờ phù hợp.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView1.DataSource = Nothing
        Else
            DataGridView1.DataSource = dt
            ' Định dạng hiển thị ngày cho DataGridView
            With DataGridView1.Columns("Ngày Cấp")
                .DefaultCellStyle.Format = "dd/MM/yyyy"
            End With
            With DataGridView1.Columns("Ngày Hết Hạn")
                .DefaultCellStyle.Format = "dd/MM/yyyy"
                .DefaultCellStyle.NullValue = "" ' Hiển thị rỗng thay vì NULL
            End With
        End If
    End Sub

    ' Sự kiện khi nhấn nút Cập nhật
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Không có dữ liệu để cập nhật.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim soCCCD As String = txtSoCCCD.Text.Trim()
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                Dim soGT As String = row.Cells("Mã Số").Value?.ToString()
                Dim loaiGT As String = row.Cells("Loại Giấy Tờ").Value?.ToString()
                Dim noiCap As String = row.Cells("Nơi Cấp").Value?.ToString()
                Dim ngayCapObj As Object = row.Cells("Ngày Cấp").Value
                Dim ngayHetHanObj As Object = row.Cells("Ngày Hết Hạn").Value
                Dim chiTiet As String = row.Cells("Thông Tin Chi Tiết").Value?.ToString()

                If String.IsNullOrEmpty(soGT) OrElse String.IsNullOrEmpty(loaiGT) OrElse ngayCapObj Is Nothing Then
                    MessageBox.Show("Mã Số, Loại Giấy Tờ và Ngày Cấp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim ngayCap As Date
                If Date.TryParse(ngayCapObj.ToString(), ngayCap) Then
                    ngayCap = ngayCap.Date
                Else
                    MessageBox.Show($"Định dạng ngày cấp không hợp lệ: {ngayCapObj?.ToString()}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                Dim ngayHetHan As Date? = Nothing
                If ngayHetHanObj IsNot Nothing AndAlso Not String.IsNullOrEmpty(ngayHetHanObj.ToString()) AndAlso ngayHetHanObj IsNot DBNull.Value Then
                    Dim parsedNgayHetHan As Date
                    If Date.TryParse(ngayHetHanObj.ToString(), parsedNgayHetHan) Then
                        ngayHetHan = parsedNgayHetHan.Date
                    Else
                        MessageBox.Show($"Định dạng ngày hết hạn không hợp lệ: {ngayHetHanObj.ToString()}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End If

                ' Lấy SoCCCD từ cơ sở dữ liệu nếu txtSoCCCD rỗng
                Dim finalSoCCCD As String = soCCCD
                If String.IsNullOrEmpty(soCCCD) Then
                    Dim giayToList As List(Of GiayToLienQuan) = dao.TimKiemGiayTo("", soGT, "")
                    If giayToList.Count > 0 Then
                        finalSoCCCD = giayToList(0).SoCCCD
                    Else
                        MessageBox.Show($"Không tìm thấy giấy tờ với Mã Số: {soGT}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End If

                Dim giayTo As New GiayToLienQuan()
                giayTo.SoGiayTo = soGT
                giayTo.SoCCCD = finalSoCCCD
                giayTo.LoaiGiayTo = loaiGT
                giayTo.NoiCap = If(String.IsNullOrEmpty(noiCap), "", noiCap)
                giayTo.NgayCap = ngayCap
                giayTo.NgayHetHan = ngayHetHan
                giayTo.ChiTiet = If(String.IsNullOrEmpty(chiTiet), "", chiTiet)

                dao.CapNhatGiayTo(giayTo)
            End If
        Next

        ' Làm mới DataGridView
        Dim soGiayToTimKiem As String = txtSoGiayTo.Text.Trim()
        Dim loaiGiayTo As String = ComboBoxLoaiGiayTo.SelectedItem?.ToString()
        Dim danhSach As List(Of GiayToLienQuan) = dao.TimKiemGiayTo(soCCCD, soGiayToTimKiem, loaiGiayTo)
        Dim dt As DataTable = ConvertToDataTable(danhSach)
        DataGridView1.DataSource = dt
        With DataGridView1.Columns("Ngày Cấp")
            .DefaultCellStyle.Format = "dd/MM/yyyy"
        End With
        With DataGridView1.Columns("Ngày Hết Hạn")
            .DefaultCellStyle.Format = "dd/MM/yyyy"
            .DefaultCellStyle.NullValue = ""
        End With
        MessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Sự kiện khi nhấn nút Xóa
    Private Sub Xoa_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn một giấy tờ để xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
        Dim soGiayTo As String = selectedRow.Cells("Mã Số").Value?.ToString()

        If String.IsNullOrEmpty(soGiayTo) Then
            MessageBox.Show("Mã Số giấy tờ không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa giấy tờ '{soGiayTo}' không?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            dao.XoaGiayTo(soGiayTo)

            ' Làm mới DataGridView dựa trên các tiêu chí tìm kiếm hiện tại
            Dim soCCCD As String = txtSoCCCD.Text.Trim()
            Dim soGiayToTimKiem As String = txtSoGiayTo.Text.Trim()
            Dim loaiGiayTo As String = ComboBoxLoaiGiayTo.SelectedItem?.ToString()
            Dim danhSach As List(Of GiayToLienQuan) = dao.TimKiemGiayTo(soCCCD, soGiayToTimKiem, loaiGiayTo)
            Dim dt As DataTable = ConvertToDataTable(danhSach)
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Không tìm thấy giấy tờ phù hợp sau khi xóa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DataGridView1.DataSource = Nothing
            Else
                DataGridView1.DataSource = dt
                With DataGridView1.Columns("Ngày Cấp")
                    .DefaultCellStyle.Format = "dd/MM/yyyy"
                End With
                With DataGridView1.Columns("Ngày Hết Hạn")
                    .DefaultCellStyle.Format = "dd/MM/yyyy"
                    .DefaultCellStyle.NullValue = ""
                End With
            End If
        End If
    End Sub


End Class