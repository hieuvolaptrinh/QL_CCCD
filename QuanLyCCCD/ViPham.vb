Imports System.Data.SqlClient

Public Class ViPham
    Private connectionString As String = "Data Source=.\SQLEXPRESS;Initial Catalog=QLCCCD;Integrated Security=True"
    Private connection As SqlConnection
    Private command As SqlCommand
    Private adapter As SqlDataAdapter
    Private dataTable As DataTable

    Private Sub ViPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize database connection
        connection = New SqlConnection(connectionString)

        ' Initialize ComboBox items
        cboTrangThai.Items.AddRange({"Đã xử lý", "Chưa xử lý", "Đang xử lý"})
        cboTrangThai.SelectedIndex = 0

        ' Load data to DataGridView
        LoadData()

        ' Configure DataGridView columns
        ConfigureDataGridView()
    End Sub

    Private Sub LoadData()
        Try
            connection.Open()
            Dim query As String = "SELECT sp.maSaiPham, cd.hoTen, sp.loiSaiPham, sp.ngaySai, " &
                                "sp.noiSaiPham, sp.mucPhat, sp.trangThai, sp.soCCCD " &
                                "FROM SaiPham sp INNER JOIN CongDanCCCD cd ON sp.soCCCD = cd.soCCCD"

            adapter = New SqlDataAdapter(query, connection)
            dataTable = New DataTable()
            adapter.Fill(dataTable)
            dgvSaiPham.DataSource = dataTable

        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải dữ liệu: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub ConfigureDataGridView()
        With dgvSaiPham
            .Columns("maSaiPham").HeaderText = "Mã sai phạm"
            .Columns("hoTen").HeaderText = "Họ tên"
            .Columns("loiSaiPham").HeaderText = "Lỗi sai phạm"
            .Columns("ngaySai").HeaderText = "Ngày sai phạm"
            .Columns("noiSaiPham").HeaderText = "Nơi sai phạm"
            .Columns("mucPhat").HeaderText = "Mức phạt"
            .Columns("trangThai").HeaderText = "Trạng thái"
            .Columns("soCCCD").HeaderText = "Số CCCD"

            For Each col As DataGridViewColumn In .Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Next
        End With
    End Sub

    Private Sub dgvSaiPham_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSaiPham.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvSaiPham.Rows(e.RowIndex)
            txtMaSaiPham.Text = row.Cells("maSaiPham").Value.ToString()
            txtSoCCCD.Text = row.Cells("soCCCD").Value.ToString()
            txtLoiSaiPham.Text = row.Cells("loiSaiPham").Value.ToString()
            dtpNgaySai.Value = CDate(row.Cells("ngaySai").Value)
            txtNoiSaiPham.Text = row.Cells("noiSaiPham").Value.ToString()
            txtMucPhat.Text = row.Cells("mucPhat").Value.ToString()
            cboTrangThai.Text = row.Cells("trangThai").Value.ToString()
        End If
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        If ValidateInput() Then
            Try
                connection.Open()
                command = New SqlCommand("INSERT INTO SaiPham (maSaiPham, soCCCD, loiSaiPham, ngaySai, noiSaiPham, mucPhat, trangThai) " &
                                       "VALUES (@maSaiPham, @soCCCD, @loiSaiPham, @ngaySai, @noiSaiPham, @mucPhat, @trangThai)", connection)

                With command.Parameters
                    .AddWithValue("@maSaiPham", txtMaSaiPham.Text)
                    .AddWithValue("@soCCCD", txtSoCCCD.Text)
                    .AddWithValue("@loiSaiPham", txtLoiSaiPham.Text)
                    .AddWithValue("@ngaySai", dtpNgaySai.Value)
                    .AddWithValue("@noiSaiPham", txtNoiSaiPham.Text)
                    .AddWithValue("@mucPhat", Convert.ToDecimal(txtMucPhat.Text))
                    .AddWithValue("@trangThai", cboTrangThai.Text)
                End With

                command.ExecuteNonQuery()
                MessageBox.Show("Thêm sai phạm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearInputs()

            Catch ex As Exception
                MessageBox.Show("Lỗi khi thêm sai phạm: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                connection.Close()
            End Try
        End If
    End Sub

    Private Sub btnSua_Click(sender As Object, e As EventArgs) Handles btnSua.Click
        If ValidateInput() Then
            Try
                connection.Open()
                command = New SqlCommand("UPDATE SaiPham SET soCCCD = @soCCCD, loiSaiPham = @loiSaiPham, " &
                                       "ngaySai = @ngaySai, noiSaiPham = @noiSaiPham, mucPhat = @mucPhat, " &
                                       "trangThai = @trangThai WHERE maSaiPham = @maSaiPham", connection)

                With command.Parameters
                    .AddWithValue("@maSaiPham", txtMaSaiPham.Text)
                    .AddWithValue("@soCCCD", txtSoCCCD.Text)
                    .AddWithValue("@loiSaiPham", txtLoiSaiPham.Text)
                    .AddWithValue("@ngaySai", dtpNgaySai.Value)
                    .AddWithValue("@noiSaiPham", txtNoiSaiPham.Text)
                    .AddWithValue("@mucPhat", Convert.ToDecimal(txtMucPhat.Text))
                    .AddWithValue("@trangThai", cboTrangThai.Text)
                End With

                command.ExecuteNonQuery()
                MessageBox.Show("Cập nhật sai phạm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearInputs()

            Catch ex As Exception
                MessageBox.Show("Lỗi khi cập nhật sai phạm: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                connection.Close()
            End Try
        End If
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        If String.IsNullOrEmpty(txtMaSaiPham.Text) Then
            MessageBox.Show("Vui lòng chọn sai phạm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("Bạn có chắc chắn muốn xóa sai phạm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                connection.Open()
                command = New SqlCommand("DELETE FROM SaiPham WHERE maSaiPham = @maSaiPham", connection)
                command.Parameters.AddWithValue("@maSaiPham", txtMaSaiPham.Text)
                command.ExecuteNonQuery()

                MessageBox.Show("Xóa sai phạm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadData()
                ClearInputs()

            Catch ex As Exception
                MessageBox.Show("Lỗi khi xóa sai phạm: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                connection.Close()
            End Try
        End If


    Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
        Try
            connection.Open()
            Dim searchText As String = txtTimKiem.Text.Trim()
            Dim trangThai As String = cboTrangThaiTimKiem.Text

            Dim query As String = "SELECT sp.maSaiPham, cd.hoTen, sp.loiSaiPham, sp.ngaySai, " &
                                "sp.noiSaiPham, sp.mucPhat, sp.trangThai, sp.soCCCD " &
                                "FROM SaiPham sp INNER JOIN CongDanCCCD cd ON sp.soCCCD = cd.soCCCD " &
                                "WHERE (cd.hoTen LIKE @search OR sp.soCCCD LIKE @search)"

            If trangThai <> "Tất cả trạng thái" Then
                query &= " AND sp.trangThai = @trangThai"
            End If

            adapter = New SqlDataAdapter(query, connection)
            adapter.SelectCommand.Parameters.AddWithValue("@search", "%" & searchText & "%")

            If trangThai <> "Tất cả trạng thái" Then
                adapter.SelectCommand.Parameters.AddWithValue("@trangThai", trangThai)
            End If

            DataTable = New DataTable()
            adapter.Fill(DataTable)
            dgvSaiPham.DataSource = DataTable

        Catch ex As Exception
            MessageBox.Show("Lỗi khi tìm kiếm: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub txtTimKiem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTimKiem.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnTimKiem.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub cboTrangThaiTimKiem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTrangThaiTimKiem.SelectedIndexChanged
        btnTimKiem.PerformClick()
    End Sub

    Private Sub ViPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize database connection
        connection = New SqlConnection(connectionString)

        ' Initialize ComboBox items
        cboTrangThai.Items.AddRange({"Đã xử lý", "Chưa xử lý", "Đang xử lý"})
        cboTrangThai.SelectedIndex = 0

        cboTrangThaiTimKiem.SelectedIndex = 0

        ' Load data to DataGridView
        LoadData()

        ' Configure DataGridView columns
        ConfigureDataGridView()
    End Sub

    Private Sub ConfigureDataGridView()
        With dgvSaiPham
            .Columns("maSaiPham").HeaderText = "Mã sai phạm"
            .Columns("hoTen").HeaderText = "Họ tên"
            .Columns("loiSaiPham").HeaderText = "Lỗi sai phạm"
            .Columns("ngaySai").HeaderText = "Ngày sai phạm"
            .Columns("noiSaiPham").HeaderText = "Nơi sai phạm"
            .Columns("mucPhat").HeaderText = "Mức phạt"
            .Columns("trangThai").HeaderText = "Trạng thái"
            .Columns("soCCCD").HeaderText = "Số CCCD"

            ' Set column widths
            .Columns("maSaiPham").Width = 100
            .Columns("hoTen").Width = 150
            .Columns("loiSaiPham").Width = 200
            .Columns("ngaySai").Width = 100
            .Columns("noiSaiPham").Width = 150
            .Columns("mucPhat").Width = 100
            .Columns("trangThai").Width = 100
            .Columns("soCCCD").Width = 100

            ' Format date column
            .Columns("ngaySai").DefaultCellStyle.Format = "dd/MM/yyyy"

            ' Format currency column
            .Columns("mucPhat").DefaultCellStyle.Format = "N0"
            .Columns("mucPhat").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Set alternating row colors
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250)
            .DefaultCellStyle.BackColor = Color.White
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(94, 148, 255)
            .DefaultCellStyle.SelectionForeColor = Color.White

            ' Other formatting
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(94, 148, 255)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersHeight = 40
            .RowTemplate.Height = 30

            For Each col As DataGridViewColumn In .Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                col.SortMode = DataGridViewColumnSortMode.Automatic
            Next
        End With
    End Sub

    Private Sub btnTK_Click(sender As Object, e As EventArgs) Handles btnTK.Click
        'tìm kiếm theo người dùng và trạng thái sai phạm
        Dim tenNguoiDung As String = txtTenCongDan.Text.Trim()
        Dim trangThai As String = cboTrangThaiTimKiem.Text
    End Sub
End Class