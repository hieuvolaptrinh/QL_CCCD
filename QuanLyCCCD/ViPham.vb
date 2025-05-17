Imports System.Data.SqlClient

Public Class ViPham
    Private viPhamDAO As ViPhamDao
    Private dsSaiPham As List(Of CongDan_SaiPham)

    Public Sub New()
        InitializeComponent()
        InitializeDAO()
    End Sub

    Private Sub InitializeDAO()
        Try
            viPhamDAO = New ViPhamDao()
        Catch ex As Exception
            MessageBox.Show("Lỗi khởi tạo kết nối database: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ViPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize ComboBox items
            cboTrangThai.Items.AddRange({"Đã xử lý", "Chưa xử lý", "Đang xử lý"})
            cboTrangThai.SelectedIndex = 0
            cboTrangThaiTimKiem.SelectedIndex = 0

            ' Load data to DataGridView
            LoadData()

            ' Configure DataGridView columns
            ConfigureDataGridView()
        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải form: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            If viPhamDAO Is Nothing Then
                InitializeDAO()
            End If

            If viPhamDAO IsNot Nothing Then
                dsSaiPham = viPhamDAO.GetAllCongDanSaiPham()
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
            .Columns("TrangThai").HeaderText = "Trạng Thái XL"


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

    Private Sub dgvSaiPham_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSaiPham.CellClick
        If e.RowIndex >= 0 Then
            Dim saiPham As CongDan_SaiPham = DirectCast(dgvSaiPham.Rows(e.RowIndex).DataBoundItem, CongDan_SaiPham)
            txtMaSaiPham.Text = saiPham.MaSaiPham
            txtSoCCCD.Text = saiPham.SoCCCD
            txtLoiSaiPham.Text = saiPham.LoiSaiPham
            dtpNgaySai.Value = saiPham.NgaySai
            txtNoiSaiPham.Text = saiPham.NoiSaiPham
            txtMucPhat.Text = saiPham.MucPhat.ToString()
            cboTrangThai.Text = saiPham.TrangThai
        End If
    End Sub

    Private Sub btnTK_Click(sender As Object, e As EventArgs) Handles btnTK.Click
        Try
            If viPhamDAO Is Nothing Then
                InitializeDAO()
            End If

            If viPhamDAO IsNot Nothing Then
                Dim tenNguoiDung As String = txtTenCongDan.Text.Trim()
                Dim trangThai As String = cboTrangThaiTimKiem.Text

                dsSaiPham = viPhamDAO.GetCongDanSaiPhamByFilter(tenNguoiDung, trangThai)
                dgvSaiPham.DataSource = dsSaiPham
            Else
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Lỗi khi tìm kiếm: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTenCongDan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTenCongDan.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnTK.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub cboTrangThaiTimKiem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTrangThaiTimKiem.SelectedIndexChanged
        btnTK.PerformClick()
    End Sub

    Private Sub xuatReport_Click(sender As Object, e As EventArgs) Handles xuatReport.Click

    End Sub
End Class