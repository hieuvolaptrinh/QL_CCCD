Public Class QuanLyViPham

    Private congDanDAO As CongDanCCCDDao

    Private viPhamDAO As ViPhamDao
    Private dsSaiPham As List(Of CongDan_SaiPham)
    Private Sub QuanLyViPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cboTrangThaiTimKiem.Items.AddRange({"Đã xử lý", "Chưa xử lý", "Đang xử lý"})
        cboTrangThaiTimKiem.SelectedIndex = 0
        cboTrangThaiTimKiem.SelectedIndex = 0
        LoadData()
        ConfigureDataGridView()

        CapNhatThongKe()
    End Sub
    Private Sub CapNhatThongKe()

        Dim soNguoiTichHop As Integer = congDanDAO.DemSoLuongCongDan()
        lbSoNguoiTichHop.Text = soNguoiTichHop.ToString("#,##0")

        Dim soNguoiViPham As Integer = viPhamDAO.soLuongViPham()
        lblSoLoi.Text = soNguoiViPham.ToString("#,##0")

    End Sub
    Public Sub New()
        InitializeComponent()
        InitializeDAO()
    End Sub

    Private Sub InitializeDAO()

        viPhamDAO = New ViPhamDao()

    End Sub


    Private Sub LoadData()
        Try
            If ViPhamDao Is Nothing Then
                InitializeDAO()
            End If

            If ViPhamDao IsNot Nothing Then
                dsSaiPham = ViPhamDao.GetAllCongDanSaiPham()
                dgvSaiPham.DataSource = dsSaiPham
            Else
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải dữ liệu: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigureDataGridView()
        With dgvSaiPham
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells


            .Columns("MaSaiPham").HeaderText = "Mã Vi Phạm"
            .Columns("SoCCCD").HeaderText = "Số CCCD"
            .Columns("HoTen").HeaderText = "Tên Công Dân"
            .Columns("LoiSaiPham").HeaderText = "Lỗi Vi Phạm"
            .Columns("NgaySai").HeaderText = "Ngày Vi Phạm"
            .Columns("NoiSaiPham").HeaderText = "Địa Điểm Vi Phạm"
            .Columns("MucPhat").HeaderText = "Mức Phạt (VNĐ)"
            .Columns("TrangThai").HeaderText = "Trạng Thái"


            .Columns("NgaySai").DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns("MucPhat").DefaultCellStyle.Format = "N0"
            .Columns("MucPhat").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255) ' Màu xanh dương
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White ' Chữ màu trắng
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 40


            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .DefaultCellStyle.Padding = New Padding(2)
            .RowHeadersVisible = False


            .Columns("MaSaiPham").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SoCCCD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NgaySai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("TrangThai").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            For Each col As DataGridViewColumn In .Columns
                col.SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            .Columns("MaSaiPham").FillWeight = 10
            .Columns("SoCCCD").FillWeight = 12
            .Columns("HoTen").FillWeight = 15
            .Columns("LoiSaiPham").FillWeight = 20
            .Columns("NgaySai").FillWeight = 12
            .Columns("NoiSaiPham").FillWeight = 15
            .Columns("MucPhat").FillWeight = 10
            .Columns("TrangThai").FillWeight = 10


            AddHandler .CellFormatting, AddressOf dgvSaiPham_CellFormatting
        End With
    End Sub

    Private Sub dgvSaiPham_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = dgvSaiPham.Columns("TrangThai").Index AndAlso e.Value IsNot Nothing Then
            Select Case e.Value.ToString()
                Case "Đã xử lý"
                    e.CellStyle.ForeColor = Color.Green
                Case "Chưa xử lý"
                    e.CellStyle.ForeColor = Color.Red
                Case "Đang xử lý"
                    e.CellStyle.ForeColor = Color.Orange
            End Select
            e.CellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        End If
    End Sub

    Private Sub btnTK_Click(sender As Object, e As EventArgs) Handles btnTK.Click
        Try
            If ViPhamDao Is Nothing Then
                InitializeDAO()
            End If

            If ViPhamDao IsNot Nothing Then
                Dim tenNguoiDung As String = txtTenCongDan.Text.Trim()
                Dim trangThai As String = cboTrangThaiTimKiem.Text
                Dim cccd As String = txtCCCDTImKiem.Text.Trim()

                dsSaiPham = viPhamDAO.GetCongDanSaiPhamByFilter(tenNguoiDung, trangThai, cccd)
                dgvSaiPham.DataSource = dsSaiPham
            Else
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi tìm kiếm: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTenCongDan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTenCongDan.KeyPress, txtCCCDTImKiem.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnTK.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub cboTrangThaiTimKiem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTrangThaiTimKiem.SelectedIndexChanged
        btnTK.PerformClick()
    End Sub

    Private Sub xuatReport_Click(sender As Object, e As EventArgs) Handles xuatReport.Click
        Try
            If dsSaiPham IsNot Nothing AndAlso dsSaiPham.Count > 0 Then
                'Tạo và hiển thị form report
                Dim frmReport As New FormReportViPham(dsSaiPham)
                frmReport.ShowDialog()
            Else
                MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi xuất báo cáo: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class