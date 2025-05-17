Public Class QuanLy
    Private dao As New CongDanCCCDDao()

    Private Function ConvertToDataTable(danhSach As List(Of CongDanCCCD)) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Họ và Tên", GetType(String))
        dt.Columns.Add("Số CCCD", GetType(String))
        dt.Columns.Add("Ngày sinh", GetType(String))
        dt.Columns.Add("Giới tính", GetType(String))
        dt.Columns.Add("Quê quán", GetType(String))
        dt.Columns.Add("Nơi ở", GetType(String))
        dt.Columns.Add("Ngày cấp", GetType(String))
        dt.Columns.Add("Nơi cấp", GetType(String))

        For Each congDan As CongDanCCCD In danhSach
            Dim row As DataRow = dt.NewRow()
            row("Họ và Tên") = congDan.HoTen
            row("Số CCCD") = congDan.SoCCCD
            row("Ngày sinh") = congDan.NgaySinh.ToString("dd/MM/yyyy")
            row("Giới tính") = congDan.GioiTinh
            row("Quê quán") = If(String.IsNullOrEmpty(congDan.QueQuan), "", congDan.QueQuan)
            row("Nơi ở") = If(String.IsNullOrEmpty(congDan.NoiO), "", congDan.NoiO)
            row("Ngày cấp") = congDan.NgayCap.ToString("dd/MM/yyyy")
            row("Nơi cấp") = congDan.NoiCap
            dt.Rows.Add(row)
        Next

        Return dt
    End Function

    Private Sub QuanLy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
        Dim dt As DataTable = ConvertToDataTable(danhSach)
        DataGridViewCCCD.DataSource = dt

        DataGridViewCCCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCCCD.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub DataGridViewCCCD_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCCCD.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridViewCCCD.Rows(e.RowIndex)
            ten.Text = row.Cells("Họ và Tên").Value.ToString()
            cccd.Text = row.Cells("Số CCCD").Value.ToString()
            que.Text = row.Cells("Quê quán").Value.ToString()
            txtDiaChi.Text = row.Cells("Nơi ở").Value.ToString()
            txtNoiCap.Text = row.Cells("Nơi cấp").Value.ToString()

            Dim ngaySinh As Date
            Dim ngaySinhStr As String = row.Cells("Ngày sinh").Value.ToString()
            If DateTime.TryParse(ngaySinhStr, ngaySinh) Then
                ngsinh.Value = ngaySinh
            ElseIf DateTime.TryParseExact(ngaySinhStr, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, ngaySinh) Then
                ngsinh.Value = ngaySinh
            End If

            Dim ngayCap As Date
            Dim ngayCapStr As String = row.Cells("Ngày cấp").Value.ToString()
            If DateTime.TryParse(ngayCapStr, ngayCap) Then
                ngcap.Value = ngayCap
            ElseIf DateTime.TryParseExact(ngayCapStr, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, ngayCap) Then
                ngcap.Value = ngayCap
            End If

            If row.Cells("Giới tính").Value.ToString() = "Nam" Then
                rdioNam.Checked = True
            Else
                rdioNu.Checked = True
            End If
        End If
    End Sub

    Private Sub Guna2GradientButton6_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton6.Click
        Try
            ' Validate required fields
            If String.IsNullOrWhiteSpace(cccd.Text) OrElse String.IsNullOrWhiteSpace(ten.Text) OrElse String.IsNullOrWhiteSpace(txtNoiCap.Text) Then
                MessageBox.Show("Vui lòng điền các thông tin bắt buộc (Số CCCD, Họ tên, Nơi cấp)!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate CCCD format
            Dim soCCCD As String = cccd.Text.Trim()
            If Not IsNumeric(soCCCD) OrElse soCCCD.Length <> 12 Then
                MessageBox.Show("Số CCCD phải là 12 chữ số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cccd.Focus()
                Return
            End If

            ' Check if CCCD already exists
            Dim existingCongDan = dao.LayThongTinCongDan(soCCCD)
            If existingCongDan IsNot Nothing Then
                MessageBox.Show("Số CCCD đã tồn tại trong hệ thống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cccd.Focus()
                Return
            End If

            ' Validate dates
            Dim ngaySinh As Date = ngsinh.Value
            Dim ngayCap As Date = ngcap.Value

            If ngayCap <= ngaySinh Then
                MessageBox.Show("Ngày cấp phải lớn hơn ngày sinh!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ngcap.Focus()
                Return
            End If

            If ngayCap > DateTime.Now Then
                MessageBox.Show("Ngày cấp không thể lớn hơn ngày hiện tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ngcap.Focus()
                Return
            End If

            ' Create new CongDanCCCD object
            Dim congDan As New CongDanCCCD() With {
                .SoCCCD = soCCCD,
                .HoTen = ten.Text.Trim(),
                .NgaySinh = ngaySinh,
                .GioiTinh = If(rdioNam.Checked, "Nam", "Nữ"),
                .QueQuan = que.Text.Trim(),
                .NoiO = txtDiaChi.Text.Trim(),
                .NgayCap = ngayCap,
                .NoiCap = txtNoiCap.Text.Trim()
            }

            ' Add to database
            dao.ThemCongDan(congDan)

            ' Refresh DataGridView
            Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
            DataGridViewCCCD.DataSource = ConvertToDataTable(danhSach)

            ' Clear form after successful addition
            Guna2GradientButton1_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra khi thêm công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Guna2GradientButton8_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton8.Click
        Try
            ' Check if a row is selected
            If DataGridViewCCCD.SelectedRows.Count = 0 Then
                MessageBox.Show("Vui lòng chọn một công dân để sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate required fields
            If String.IsNullOrWhiteSpace(cccd.Text) OrElse String.IsNullOrWhiteSpace(ten.Text) OrElse String.IsNullOrWhiteSpace(txtNoiCap.Text) Then
                MessageBox.Show("Vui lòng điền các thông tin bắt buộc (Số CCCD, Họ tên, Nơi cấp)!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate CCCD format
            Dim soCCCD As String = cccd.Text.Trim()
            If Not IsNumeric(soCCCD) OrElse soCCCD.Length <> 12 Then
                MessageBox.Show("Số CCCD phải là 12 chữ số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cccd.Focus()
                Return
            End If

            ' Get original CCCD from selected row
            Dim selectedRow As DataGridViewRow = DataGridViewCCCD.SelectedRows(0)
            Dim originalCCCD As String = selectedRow.Cells("Số CCCD").Value.ToString()

            ' If CCCD is changed, check if new CCCD already exists
            If soCCCD <> originalCCCD Then
                Dim existingCongDan = dao.LayThongTinCongDan(soCCCD)
                If existingCongDan IsNot Nothing Then
                    MessageBox.Show("Số CCCD mới đã tồn tại trong hệ thống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cccd.Focus()
                    Return
                End If
            End If

            ' Validate dates
            Dim ngaySinh As Date = ngsinh.Value
            Dim ngayCap As Date = ngcap.Value

            If ngayCap <= ngaySinh Then
                MessageBox.Show("Ngày cấp phải lớn hơn ngày sinh!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ngcap.Focus()
                Return
            End If

            If ngayCap > DateTime.Now Then
                MessageBox.Show("Ngày cấp không thể lớn hơn ngày hiện tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ngcap.Focus()
                Return
            End If

            ' Create CongDanCCCD object with updated information
            Dim congDan As New CongDanCCCD() With {
                .SoCCCD = soCCCD,
                .HoTen = ten.Text.Trim(),
                .NgaySinh = ngaySinh,
                .GioiTinh = If(rdioNam.Checked, "Nam", "Nữ"),
                .QueQuan = que.Text.Trim(),
                .NoiO = txtDiaChi.Text.Trim(),
                .NgayCap = ngayCap,
                .NoiCap = txtNoiCap.Text.Trim()
            }

            ' Confirm update
            Dim result As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin công dân này?",
                                                        "Xác nhận cập nhật",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                ' Update in database
                dao.SuaCongDan(congDan)

                ' Refresh DataGridView
                Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
                DataGridViewCCCD.DataSource = ConvertToDataTable(danhSach)

                ' Clear form after successful update
                Guna2GradientButton1_Click(sender, e)
            End If

        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra khi cập nhật thông tin công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Guna2GradientButton9_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton9.Click
        Try
            ' Check if a row is selected
            If DataGridViewCCCD.SelectedRows.Count = 0 Then
                MessageBox.Show("Vui lòng chọn một công dân để xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get selected citizen information
            Dim selectedRow As DataGridViewRow = DataGridViewCCCD.SelectedRows(0)
            Dim soCCCD As String = selectedRow.Cells("Số CCCD").Value.ToString()
            Dim hoTen As String = selectedRow.Cells("Họ và Tên").Value.ToString()

            ' Confirm deletion with more detailed message
            Dim result As DialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa công dân:" & vbCrLf &
                $"Họ tên: {hoTen}" & vbCrLf &
                $"Số CCCD: {soCCCD}" & vbCrLf & vbCrLf &
                "Thao tác này không thể hoàn tác!",
                "Xác Nhận Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                ' Delete from database
                dao.XoaCongDan(soCCCD)

                ' Refresh DataGridView
                Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
                DataGridViewCCCD.DataSource = ConvertToDataTable(danhSach)

                ' Clear form after successful deletion
                Guna2GradientButton1_Click(sender, e)
            End If

        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra khi xóa công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub timKiem_Click(sender As Object, e As EventArgs) Handles timKiem.Click
        Dim soCCCD As String = cccd.Text.Trim()
        Dim hoTen As String = ten.Text.Trim()
        Dim queQuan As String = que.Text.Trim()
        Dim noiO As String = txtDiaChi.Text.Trim()
        Dim noiCap As String = txtNoiCap.Text.Trim()
        Dim gioiTinh As String = ""
        If rdioNam.Checked Then gioiTinh = "Nam"
        If rdioNu.Checked Then gioiTinh = "Nữ"

        Dim danhSach As List(Of CongDanCCCD) = dao.TimKiemCongDan(soCCCD, hoTen, queQuan, noiO, noiCap, gioiTinh)
        DataGridViewCCCD.DataSource = ConvertToDataTable(danhSach)
    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        ' Xóa nội dung các TextBox
        ten.Clear()
        cccd.Clear()
        que.Clear()
        txtDiaChi.Clear()
        txtNoiCap.Clear()
        ngsinh.Value = DateTime.Now
        ngcap.Value = DateTime.Now

        rdioNam.Checked = True
        rdioNu.Checked = False

        ten.Focus()

        Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
        DataGridViewCCCD.DataSource = ConvertToDataTable(danhSach)
    End Sub
End Class