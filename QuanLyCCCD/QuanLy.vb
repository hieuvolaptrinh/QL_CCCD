Public Class QuanLy
    Private dao As New CongDanCCCDDao()
    Private viPhamDao As New ViPhamDao
    Private Sub QuanLy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
        Dim dt As DataTable = ConvertToDataTable(danhSach)
        DataGridViewCCCD.DataSource = dt

        DataGridViewCCCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCCCD.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        CapNhatThongKe()
    End Sub
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

    Private Sub CapNhatThongKe()
        Try
            Dim soNguoiTichHop As Integer = dao.DemSoLuongCongDan()
            lbSoNguoiTichHop.Text = soNguoiTichHop.ToString("#,##0")
            Dim soNguoiViPham As Integer = viPhamDao.soLuongViPham()
            lblSoNguoiVIPham.Text = soNguoiViPham.ToString("#,##0")
        Catch ex As Exception
            MessageBox.Show("Có lỗi khi cập nhật thống kê: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub themCCCD_Click(sender As Object, e As EventArgs) Handles themCCCD.Click
        Try
            If String.IsNullOrWhiteSpace(cccd.Text) OrElse String.IsNullOrWhiteSpace(ten.Text) OrElse String.IsNullOrWhiteSpace(txtNoiCap.Text) Then
                MessageBox.Show("Vui lòng điền các thông tin bắt buộc (Số CCCD, Họ tên, Nơi cấp)!", "Thông Báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim soCCCD As String = cccd.Text.Trim()
            If Not IsNumeric(soCCCD) OrElse soCCCD.Length <> 12 Then
                MessageBox.Show("Số CCCD phải là 12 chữ số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cccd.Focus()
                Return
            End If
            Dim ngaySinh As Date = ngsinh.Value
            Dim ngayCap As Date = ngcap.Value
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

            dao.ThemCongDan(congDan)
            Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
            DataGridViewCCCD.DataSource = ConvertToDataTable(danhSach)
            Guna2GradientButton1_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra khi thêm công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        CapNhatThongKe()
    End Sub
    Private Sub CapNhat_Click(sender As Object, e As EventArgs) Handles CapNhat.Click
        Try
            Dim soCCCD As String = cccd.Text.Trim()
            Dim selectedRow As DataGridViewRow = DataGridViewCCCD.SelectedRows(0)
            Dim originalCCCD As String = selectedRow.Cells("Số CCCD").Value.ToString()
            Dim ngaySinh As Date = ngsinh.Value
            Dim ngayCap As Date = ngcap.Value
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

            Dim result As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin công dân này?",
                                                        "Xác nhận cập nhật",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                dao.SuaCongDan(congDan)

                Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
                DataGridViewCCCD.DataSource = ConvertToDataTable(danhSach)

                Guna2GradientButton1_Click(sender, e)
            End If

        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra khi cập nhật thông tin công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        CapNhatThongKe()
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
    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Try
            If DataGridViewCCCD.SelectedRows.Count = 0 Then
                MessageBox.Show("Vui lòng chọn một công dân để xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Dim selectedRow As DataGridViewRow = DataGridViewCCCD.SelectedRows(0)
            Dim soCCCD As String = selectedRow.Cells("Số CCCD").Value.ToString()
            Dim hoTen As String = selectedRow.Cells("Họ và Tên").Value.ToString()
            Dim result As DialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa công dân:" & vbCrLf &
                $"Họ tên: {hoTen}" & vbCrLf &
                $"Số CCCD: {soCCCD}" & vbCrLf & vbCrLf &
                "Thao tác này không thể hoàn tác!",
                "Xác Nhận Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then

                dao.XoaCongDan(soCCCD)
                Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
                DataGridViewCCCD.DataSource = ConvertToDataTable(danhSach)
                Guna2GradientButton1_Click(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra khi xóa công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        CapNhatThongKe()
    End Sub


    'refresh
    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
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



    Private Sub BáoCáoViPhạmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BáoCáoViPhạmToolStripMenuItem.Click
        Dim frm As New QuanLyViPham()
        frm.Show()
        Me.Hide()
    End Sub

End Class