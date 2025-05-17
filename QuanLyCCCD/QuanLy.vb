

Public Class QuanLy
    Private dao As New CongDanCCCDDao()

    Private Function ConvertToDataTable(danhSach As List(Of CongDanCCCD)) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Họ và Tên", GetType(String))
        dt.Columns.Add("Số CCCD", GetType(String))
        dt.Columns.Add("Ngày sinh", GetType(String))
        dt.Columns.Add("Ngày cấp", GetType(String))
        dt.Columns.Add("Nơi cấp", GetType(String))
        dt.Columns.Add("Quê Quán", GetType(String))
        dt.Columns.Add("Giới tính", GetType(String))

        For Each congDan As CongDanCCCD In danhSach
            Dim row As DataRow = dt.NewRow()
            row("Họ và Tên") = congDan.HoTen
            row("Số CCCD") = congDan.SoCCCD
            row("Ngày sinh") = congDan.NgaySinh.ToString("dd/MM/yyyy")
            row("Ngày cấp") = congDan.NgayCap.ToString("dd/MM/yyyy")
            row("Nơi cấp") = congDan.NoiCap
            row("Quê Quán") = congDan.QueQuan
            row("Giới tính") = congDan.GioiTinh
            dt.Rows.Add(row)
        Next

        Return dt
    End Function

    Private Sub QuanLy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Lấy danh sách công dân từ cơ sở dữ liệu
        Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
        Dim dt As DataTable = ConvertToDataTable(danhSach)
        DataGridViewCCCD.DataSource = dt

        ' Tùy chỉnh DataGridView
        DataGridViewCCCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCCCD.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub DataGridViewCCCD_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCCCD.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridViewCCCD.Rows(e.RowIndex)
            ten.Text = row.Cells("Họ và Tên").Value.ToString()
            que.Text = row.Cells("Quê Quán").Value.ToString()
            cccd.Text = row.Cells("Số CCCD").Value.ToString()
            txtNoiCap.Text = row.Cells("Nơi cấp").Value.ToString()

            ' Xử lý Ngày sinh
            Dim ngaySinh As Date
            Dim ngaySinhStr As String = row.Cells("Ngày sinh").Value.ToString()
            If DateTime.TryParse(ngaySinhStr, ngaySinh) Then
                ngsinh.Value = ngaySinh
            ElseIf DateTime.TryParseExact(ngaySinhStr, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, ngaySinh) Then
                ngsinh.Value = ngaySinh
            Else
                MessageBox.Show("Ngày sinh không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Xử lý Ngày cấp
            Dim ngayCap As Date
            Dim ngayCapStr As String = row.Cells("Ngày cấp").Value.ToString()
            If DateTime.TryParse(ngayCapStr, ngayCap) Then
                ngcap.Value = ngayCap
            ElseIf DateTime.TryParseExact(ngayCapStr, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, ngayCap) Then
                ngcap.Value = ngayCap
            Else
                MessageBox.Show("Ngày cấp không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Xử lý Giới tính
            If row.Cells("Giới tính").Value.ToString() = "Nam" Then
                rdioNam.Checked = True
            Else
                rdioNu.Checked = True
            End If
        End If
    End Sub


    Private Sub Guna2GradientButton6_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton6.Click
        ' Nút thêm mới
        Dim soCCCD As String = cccd.Text.Trim()
        Dim hoTen As String = ten.Text.Trim()
        Dim ngayCap As Date = ngcap.Value
        Dim queQuan As String = que.Text.Trim()
        Dim gioiTinh As String = If(rdioNam.Checked, "Nam", "Nữ")
        Dim ngaySinh As Date = ngsinh.Value
        Dim noiCap As String = txtNoiCap.Text.Trim()


        If soCCCD = "" Or hoTen = "" Or queQuan = "" Or noiCap = "" Then
            MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        If Not IsNumeric(soCCCD) OrElse soCCCD.Length <> 12 Then
            MessageBox.Show("Số CCCD phải là 12 chữ số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If


        If ngayCap <= ngaySinh Then
            MessageBox.Show("Ngày cấp phải lớn hơn ngày sinh!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim congDan As New CongDanCCCD()
        congDan.SoCCCD = soCCCD
        congDan.HoTen = hoTen
        congDan.NgaySinh = ngaySinh
        congDan.GioiTinh = gioiTinh
        congDan.QueQuan = queQuan
        congDan.NgayCap = ngayCap
        congDan.NoiCap = noiCap

        dao.ThemCongDan(congDan)


        Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
        DataGridViewCCCD.DataSource = ConvertToDataTable(danhSach)
    End Sub

    Private Sub Guna2GradientButton8_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton8.Click
        ' Nút sửa
        If DataGridViewCCCD.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn một công dân để sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim soCCCD As String = cccd.Text.Trim()
        Dim hoTen As String = ten.Text.Trim()
        Dim ngayCap As Date = ngcap.Value
        Dim queQuan As String = que.Text.Trim()
        Dim gioiTinh As String = If(rdioNam.Checked, "Nam", "Nữ")
        Dim ngaySinh As Date = ngsinh.Value
        Dim noiCap As String = txtNoiCap.Text.Trim()

        If soCCCD = "" Or hoTen = "" Or queQuan = "" Or noiCap = "" Then
            MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not IsNumeric(soCCCD) OrElse soCCCD.Length <> 12 Then
            MessageBox.Show("Số CCCD phải là 12 chữ số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If ngayCap <= ngaySinh Then
            MessageBox.Show("Ngày cấp phải lớn hơn ngày sinh!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim congDan As New CongDanCCCD()
        congDan.SoCCCD = soCCCD
        congDan.HoTen = hoTen
        congDan.NgaySinh = ngaySinh
        congDan.GioiTinh = gioiTinh
        congDan.QueQuan = queQuan
        congDan.NgayCap = ngayCap
        congDan.NoiCap = noiCap

        dao.SuaCongDan(congDan)

        Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
        DataGridViewCCCD.DataSource = ConvertToDataTable(danhSach)
    End Sub

    Private Sub Guna2GradientButton9_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton9.Click
        If DataGridViewCCCD.SelectedRows.Count = 0 Then
            MessageBox.Show("Vui lòng chọn một công dân để xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedRow As DataGridViewRow = DataGridViewCCCD.SelectedRows(0)
        Dim soCCCD As String = selectedRow.Cells("Số CCCD").Value.ToString()
        Dim result As DialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa công dân có Số CCCD '{soCCCD}' không?", "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            dao.XoaCongDan(soCCCD)
            Dim danhSach As List(Of CongDanCCCD) = dao.LayDanhSachCongDan()
            DataGridViewCCCD.DataSource = ConvertToDataTable(danhSach)
        End If
    End Sub
    Private Sub timKiem_Click(sender As Object, e As EventArgs) Handles timKiem.Click
        Dim soCCCD As String = cccd.Text.Trim()
        Dim hoTen As String = ten.Text.Trim()
        Dim ngayCap As Date = ngcap.Value
        Dim queQuan As String = que.Text.Trim()
        Dim gioiTinh As String = If(rdioNam.Checked, "Nam", "Nữ")
        Dim ngaySinh As Date = ngsinh.Value
        Dim noiCap As String = txtNoiCap.Text.Trim()

        ' tìm kiếm trong csdl
    End Sub
End Class