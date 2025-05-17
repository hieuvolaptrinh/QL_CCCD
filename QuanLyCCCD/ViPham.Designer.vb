<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViPham
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtMaSaiPham = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dgvSaiPham = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.txtTimKiem = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnTimKiem = New Guna.UI2.WinForms.Guna2Button()
        Me.lblMaSaiPham = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.pnlSearch = New Guna.UI2.WinForms.Guna2Panel()
        Me.cboTrangThaiTimKiem = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.lblSearchHeader = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2CustomGradientPanel1 = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Xoa = New System.Windows.Forms.Button()
        Me.cboTrangThai = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtMucPhat = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtNoiSaiPham = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dtpNgaySai = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.txtLoiSaiPham = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtSoCCCD = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pnlButtons = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnXoa = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSua = New Guna.UI2.WinForms.Guna2Button()
        Me.btnThem = New Guna.UI2.WinForms.Guna2Button()
        Me.pnlInput = New Guna.UI2.WinForms.Guna2Panel()
        Me.lblTrangThai = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblMucPhat = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblNoiSaiPham = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblNgaySai = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblLoiSaiPham = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblSoCCCD = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.lblHeader = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.txtTenCongDan = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnTK = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.xuatReport = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.Guna2HtmlLabel2 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        CType(Me.dgvSaiPham, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearch.SuspendLayout()
        Me.Guna2CustomGradientPanel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButtons.SuspendLayout()
        Me.pnlInput.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMaSaiPham
        '
        Me.txtMaSaiPham.BorderColor = System.Drawing.Color.Black
        Me.txtMaSaiPham.BorderRadius = 5
        Me.txtMaSaiPham.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMaSaiPham.DefaultText = ""
        Me.txtMaSaiPham.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMaSaiPham.Location = New System.Drawing.Point(170, 104)
        Me.txtMaSaiPham.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMaSaiPham.Name = "txtMaSaiPham"
        Me.txtMaSaiPham.PlaceholderText = ""
        Me.txtMaSaiPham.SelectedText = ""
        Me.txtMaSaiPham.Size = New System.Drawing.Size(243, 30)
        Me.txtMaSaiPham.TabIndex = 1
        '
        'dgvSaiPham
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvSaiPham.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSaiPham.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSaiPham.ColumnHeadersHeight = 40
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSaiPham.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSaiPham.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSaiPham.Location = New System.Drawing.Point(479, 361)
        Me.dgvSaiPham.Name = "dgvSaiPham"
        Me.dgvSaiPham.RowHeadersVisible = False
        Me.dgvSaiPham.RowHeadersWidth = 51
        Me.dgvSaiPham.Size = New System.Drawing.Size(863, 367)
        Me.dgvSaiPham.TabIndex = 3
        Me.dgvSaiPham.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvSaiPham.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvSaiPham.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvSaiPham.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvSaiPham.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvSaiPham.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvSaiPham.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSaiPham.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSaiPham.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvSaiPham.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.dgvSaiPham.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvSaiPham.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSaiPham.ThemeStyle.HeaderStyle.Height = 40
        Me.dgvSaiPham.ThemeStyle.ReadOnly = False
        Me.dgvSaiPham.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvSaiPham.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvSaiPham.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dgvSaiPham.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvSaiPham.ThemeStyle.RowsStyle.Height = 22
        Me.dgvSaiPham.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSaiPham.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'txtTimKiem
        '
        Me.txtTimKiem.BorderRadius = 18
        Me.txtTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTimKiem.DefaultText = ""
        Me.txtTimKiem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTimKiem.Location = New System.Drawing.Point(20, 50)
        Me.txtTimKiem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTimKiem.Name = "txtTimKiem"
        Me.txtTimKiem.PlaceholderText = "Nhập tên hoặc số CCCD để tìm kiếm..."
        Me.txtTimKiem.SelectedText = ""
        Me.txtTimKiem.Size = New System.Drawing.Size(400, 36)
        Me.txtTimKiem.TabIndex = 0
        '
        'btnTimKiem
        '
        Me.btnTimKiem.BorderRadius = 18
        Me.btnTimKiem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTimKiem.ForeColor = System.Drawing.Color.White
        Me.btnTimKiem.Location = New System.Drawing.Point(20, 90)
        Me.btnTimKiem.Name = "btnTimKiem"
        Me.btnTimKiem.Size = New System.Drawing.Size(150, 36)
        Me.btnTimKiem.TabIndex = 2
        Me.btnTimKiem.Text = "Tìm kiếm"
        '
        'lblMaSaiPham
        '
        Me.lblMaSaiPham.BackColor = System.Drawing.Color.Transparent
        Me.lblMaSaiPham.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblMaSaiPham.Location = New System.Drawing.Point(20, 25)
        Me.lblMaSaiPham.Name = "lblMaSaiPham"
        Me.lblMaSaiPham.Size = New System.Drawing.Size(91, 22)
        Me.lblMaSaiPham.TabIndex = 0
        Me.lblMaSaiPham.Text = "Mã sai phạm:"
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.Transparent
        Me.pnlSearch.BorderRadius = 10
        Me.pnlSearch.Controls.Add(Me.Guna2HtmlLabel2)
        Me.pnlSearch.Controls.Add(Me.xuatReport)
        Me.pnlSearch.Controls.Add(Me.btnTK)
        Me.pnlSearch.Controls.Add(Me.cboTrangThaiTimKiem)
        Me.pnlSearch.Controls.Add(Me.lblSearchHeader)
        Me.pnlSearch.Controls.Add(Me.txtTenCongDan)
        Me.pnlSearch.FillColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlSearch.Location = New System.Drawing.Point(477, 113)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.ShadowDecoration.Depth = 5
        Me.pnlSearch.ShadowDecoration.Enabled = True
        Me.pnlSearch.Size = New System.Drawing.Size(865, 242)
        Me.pnlSearch.TabIndex = 2
        '
        'cboTrangThaiTimKiem
        '
        Me.cboTrangThaiTimKiem.BackColor = System.Drawing.Color.Transparent
        Me.cboTrangThaiTimKiem.BorderColor = System.Drawing.Color.Black
        Me.cboTrangThaiTimKiem.BorderRadius = 18
        Me.cboTrangThaiTimKiem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTrangThaiTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrangThaiTimKiem.FocusedColor = System.Drawing.Color.Empty
        Me.cboTrangThaiTimKiem.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboTrangThaiTimKiem.ForeColor = System.Drawing.Color.Black
        Me.cboTrangThaiTimKiem.ItemHeight = 30
        Me.cboTrangThaiTimKiem.Items.AddRange(New Object() {"Tất cả trạng thái", "Đã xử lý", "Chưa xử lý", "Đang xử lý"})
        Me.cboTrangThaiTimKiem.Location = New System.Drawing.Point(33, 93)
        Me.cboTrangThaiTimKiem.Name = "cboTrangThaiTimKiem"
        Me.cboTrangThaiTimKiem.Size = New System.Drawing.Size(200, 36)
        Me.cboTrangThaiTimKiem.StartIndex = 0
        Me.cboTrangThaiTimKiem.TabIndex = 1
        '
        'lblSearchHeader
        '
        Me.lblSearchHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchHeader.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSearchHeader.ForeColor = System.Drawing.Color.Blue
        Me.lblSearchHeader.Location = New System.Drawing.Point(20, 15)
        Me.lblSearchHeader.Name = "lblSearchHeader"
        Me.lblSearchHeader.Size = New System.Drawing.Size(268, 39)
        Me.lblSearchHeader.TabIndex = 0
        Me.lblSearchHeader.Text = "TÌM KIẾM SAI PHẠM"
        '
        'Guna2CustomGradientPanel1
        '
        Me.Guna2CustomGradientPanel1.Controls.Add(Me.PictureBox2)
        Me.Guna2CustomGradientPanel1.Controls.Add(Me.Label1)
        Me.Guna2CustomGradientPanel1.Controls.Add(Me.Xoa)
        Me.Guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Guna2CustomGradientPanel1.Location = New System.Drawing.Point(3, 3)
        Me.Guna2CustomGradientPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Guna2CustomGradientPanel1.Name = "Guna2CustomGradientPanel1"
        Me.Guna2CustomGradientPanel1.Size = New System.Drawing.Size(1346, 104)
        Me.Guna2CustomGradientPanel1.TabIndex = 10
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.QuanLyCCCD.My.Resources.Resources.policeman
        Me.PictureBox2.Location = New System.Drawing.Point(11, 11)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(109, 57)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(366, 92)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Quản Lý" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Căng Cước Công Dân"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Xoa
        '
        Me.Xoa.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Xoa.FlatAppearance.BorderSize = 0
        Me.Xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Xoa.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Xoa.ForeColor = System.Drawing.Color.White
        Me.Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Xoa.Location = New System.Drawing.Point(1119, 34)
        Me.Xoa.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Xoa.Name = "Xoa"
        Me.Xoa.Size = New System.Drawing.Size(180, 48)
        Me.Xoa.TabIndex = 11
        Me.Xoa.Text = "Đăng Xuất"
        Me.Xoa.UseVisualStyleBackColor = False
        '
        'cboTrangThai
        '
        Me.cboTrangThai.BackColor = System.Drawing.Color.Transparent
        Me.cboTrangThai.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboTrangThai.BorderRadius = 5
        Me.cboTrangThai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrangThai.FocusedColor = System.Drawing.Color.Empty
        Me.cboTrangThai.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboTrangThai.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.cboTrangThai.ItemHeight = 30
        Me.cboTrangThai.Location = New System.Drawing.Point(170, 464)
        Me.cboTrangThai.Name = "cboTrangThai"
        Me.cboTrangThai.Size = New System.Drawing.Size(243, 36)
        Me.cboTrangThai.TabIndex = 13
        '
        'txtMucPhat
        '
        Me.txtMucPhat.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtMucPhat.BorderRadius = 5
        Me.txtMucPhat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMucPhat.DefaultText = ""
        Me.txtMucPhat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtMucPhat.Location = New System.Drawing.Point(170, 404)
        Me.txtMucPhat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtMucPhat.Name = "txtMucPhat"
        Me.txtMucPhat.PlaceholderText = ""
        Me.txtMucPhat.SelectedText = ""
        Me.txtMucPhat.Size = New System.Drawing.Size(243, 30)
        Me.txtMucPhat.TabIndex = 11
        '
        'txtNoiSaiPham
        '
        Me.txtNoiSaiPham.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNoiSaiPham.BorderRadius = 5
        Me.txtNoiSaiPham.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNoiSaiPham.DefaultText = ""
        Me.txtNoiSaiPham.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNoiSaiPham.Location = New System.Drawing.Point(170, 344)
        Me.txtNoiSaiPham.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNoiSaiPham.Name = "txtNoiSaiPham"
        Me.txtNoiSaiPham.PlaceholderText = ""
        Me.txtNoiSaiPham.SelectedText = ""
        Me.txtNoiSaiPham.Size = New System.Drawing.Size(243, 30)
        Me.txtNoiSaiPham.TabIndex = 9
        '
        'dtpNgaySai
        '
        Me.dtpNgaySai.Checked = True
        Me.dtpNgaySai.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtpNgaySai.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpNgaySai.Location = New System.Drawing.Point(170, 284)
        Me.dtpNgaySai.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpNgaySai.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpNgaySai.Name = "dtpNgaySai"
        Me.dtpNgaySai.Size = New System.Drawing.Size(243, 30)
        Me.dtpNgaySai.TabIndex = 7
        Me.dtpNgaySai.Value = New Date(2025, 5, 18, 3, 5, 21, 984)
        '
        'txtLoiSaiPham
        '
        Me.txtLoiSaiPham.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtLoiSaiPham.BorderRadius = 5
        Me.txtLoiSaiPham.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLoiSaiPham.DefaultText = ""
        Me.txtLoiSaiPham.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtLoiSaiPham.Location = New System.Drawing.Point(170, 224)
        Me.txtLoiSaiPham.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtLoiSaiPham.Name = "txtLoiSaiPham"
        Me.txtLoiSaiPham.PlaceholderText = ""
        Me.txtLoiSaiPham.SelectedText = ""
        Me.txtLoiSaiPham.Size = New System.Drawing.Size(243, 30)
        Me.txtLoiSaiPham.TabIndex = 5
        '
        'txtSoCCCD
        '
        Me.txtSoCCCD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtSoCCCD.BorderRadius = 5
        Me.txtSoCCCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSoCCCD.DefaultText = ""
        Me.txtSoCCCD.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSoCCCD.Location = New System.Drawing.Point(170, 164)
        Me.txtSoCCCD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSoCCCD.Name = "txtSoCCCD"
        Me.txtSoCCCD.PlaceholderText = ""
        Me.txtSoCCCD.SelectedText = ""
        Me.txtSoCCCD.Size = New System.Drawing.Size(243, 30)
        Me.txtSoCCCD.TabIndex = 3
        '
        'pnlButtons
        '
        Me.pnlButtons.Controls.Add(Me.btnThem)
        Me.pnlButtons.Controls.Add(Me.btnSua)
        Me.pnlButtons.Controls.Add(Me.btnXoa)
        Me.pnlButtons.Location = New System.Drawing.Point(13, 545)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(400, 50)
        Me.pnlButtons.TabIndex = 1
        '
        'btnXoa
        '
        Me.btnXoa.BorderRadius = 18
        Me.btnXoa.FillColor = System.Drawing.Color.Red
        Me.btnXoa.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnXoa.ForeColor = System.Drawing.Color.White
        Me.btnXoa.Location = New System.Drawing.Point(270, 7)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(120, 36)
        Me.btnXoa.TabIndex = 2
        Me.btnXoa.Text = "Xóa"
        '
        'btnSua
        '
        Me.btnSua.BorderRadius = 18
        Me.btnSua.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSua.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSua.ForeColor = System.Drawing.Color.White
        Me.btnSua.Location = New System.Drawing.Point(140, 7)
        Me.btnSua.Name = "btnSua"
        Me.btnSua.Size = New System.Drawing.Size(120, 36)
        Me.btnSua.TabIndex = 1
        Me.btnSua.Text = "Sửa"
        '
        'btnThem
        '
        Me.btnThem.BorderRadius = 18
        Me.btnThem.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnThem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnThem.ForeColor = System.Drawing.Color.White
        Me.btnThem.Location = New System.Drawing.Point(10, 7)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(120, 36)
        Me.btnThem.TabIndex = 0
        Me.btnThem.Text = "Thêm"
        '
        'pnlInput
        '
        Me.pnlInput.BackColor = System.Drawing.Color.Transparent
        Me.pnlInput.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pnlInput.BorderRadius = 10
        Me.pnlInput.Controls.Add(Me.lblHeader)
        Me.pnlInput.Controls.Add(Me.pnlButtons)
        Me.pnlInput.Controls.Add(Me.txtMaSaiPham)
        Me.pnlInput.Controls.Add(Me.Guna2HtmlLabel1)
        Me.pnlInput.Controls.Add(Me.lblSoCCCD)
        Me.pnlInput.Controls.Add(Me.txtSoCCCD)
        Me.pnlInput.Controls.Add(Me.lblLoiSaiPham)
        Me.pnlInput.Controls.Add(Me.txtLoiSaiPham)
        Me.pnlInput.Controls.Add(Me.lblNgaySai)
        Me.pnlInput.Controls.Add(Me.dtpNgaySai)
        Me.pnlInput.Controls.Add(Me.lblNoiSaiPham)
        Me.pnlInput.Controls.Add(Me.txtNoiSaiPham)
        Me.pnlInput.Controls.Add(Me.lblMucPhat)
        Me.pnlInput.Controls.Add(Me.txtMucPhat)
        Me.pnlInput.Controls.Add(Me.lblTrangThai)
        Me.pnlInput.Controls.Add(Me.cboTrangThai)
        Me.pnlInput.FillColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlInput.Location = New System.Drawing.Point(14, 113)
        Me.pnlInput.Name = "pnlInput"
        Me.pnlInput.ShadowDecoration.Depth = 5
        Me.pnlInput.ShadowDecoration.Enabled = True
        Me.pnlInput.Size = New System.Drawing.Size(444, 618)
        Me.pnlInput.TabIndex = 0
        '
        'lblTrangThai
        '
        Me.lblTrangThai.BackColor = System.Drawing.Color.Transparent
        Me.lblTrangThai.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTrangThai.Location = New System.Drawing.Point(29, 469)
        Me.lblTrangThai.Name = "lblTrangThai"
        Me.lblTrangThai.Size = New System.Drawing.Size(91, 25)
        Me.lblTrangThai.TabIndex = 12
        Me.lblTrangThai.Text = "Trạng thái:"
        '
        'lblMucPhat
        '
        Me.lblMucPhat.BackColor = System.Drawing.Color.Transparent
        Me.lblMucPhat.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMucPhat.Location = New System.Drawing.Point(29, 409)
        Me.lblMucPhat.Name = "lblMucPhat"
        Me.lblMucPhat.Size = New System.Drawing.Size(85, 25)
        Me.lblMucPhat.TabIndex = 10
        Me.lblMucPhat.Text = "Mức phạt:"
        '
        'lblNoiSaiPham
        '
        Me.lblNoiSaiPham.BackColor = System.Drawing.Color.Transparent
        Me.lblNoiSaiPham.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoiSaiPham.Location = New System.Drawing.Point(29, 349)
        Me.lblNoiSaiPham.Name = "lblNoiSaiPham"
        Me.lblNoiSaiPham.Size = New System.Drawing.Size(114, 25)
        Me.lblNoiSaiPham.TabIndex = 8
        Me.lblNoiSaiPham.Text = "Nơi sai phạm:"
        '
        'lblNgaySai
        '
        Me.lblNgaySai.BackColor = System.Drawing.Color.Transparent
        Me.lblNgaySai.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNgaySai.Location = New System.Drawing.Point(29, 289)
        Me.lblNgaySai.Name = "lblNgaySai"
        Me.lblNgaySai.Size = New System.Drawing.Size(127, 25)
        Me.lblNgaySai.TabIndex = 6
        Me.lblNgaySai.Text = "Ngày sai phạm:"
        '
        'lblLoiSaiPham
        '
        Me.lblLoiSaiPham.BackColor = System.Drawing.Color.Transparent
        Me.lblLoiSaiPham.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoiSaiPham.Location = New System.Drawing.Point(29, 229)
        Me.lblLoiSaiPham.Name = "lblLoiSaiPham"
        Me.lblLoiSaiPham.Size = New System.Drawing.Size(109, 25)
        Me.lblLoiSaiPham.TabIndex = 4
        Me.lblLoiSaiPham.Text = "Lỗi sai phạm:"
        '
        'lblSoCCCD
        '
        Me.lblSoCCCD.BackColor = System.Drawing.Color.Transparent
        Me.lblSoCCCD.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoCCCD.Location = New System.Drawing.Point(29, 169)
        Me.lblSoCCCD.Name = "lblSoCCCD"
        Me.lblSoCCCD.Size = New System.Drawing.Size(79, 25)
        Me.lblSoCCCD.TabIndex = 2
        Me.lblSoCCCD.Text = "Số CCCD:"
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(29, 104)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(112, 25)
        Me.Guna2HtmlLabel1.TabIndex = 2
        Me.Guna2HtmlLabel1.Text = "Mã Sai Phạm:"
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Transparent
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Blue
        Me.lblHeader.Location = New System.Drawing.Point(66, 30)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(293, 39)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "THÔNG TIN SAI PHẠM"
        Me.lblHeader.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTenCongDan
        '
        Me.txtTenCongDan.BorderColor = System.Drawing.Color.Black
        Me.txtTenCongDan.BorderRadius = 5
        Me.txtTenCongDan.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTenCongDan.DefaultText = ""
        Me.txtTenCongDan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTenCongDan.Location = New System.Drawing.Point(400, 89)
        Me.txtTenCongDan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTenCongDan.Name = "txtTenCongDan"
        Me.txtTenCongDan.PlaceholderText = ""
        Me.txtTenCongDan.SelectedText = ""
        Me.txtTenCongDan.Size = New System.Drawing.Size(222, 45)
        Me.txtTenCongDan.TabIndex = 1
        '
        'btnTK
        '
        Me.btnTK.BorderRadius = 15
        Me.btnTK.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnTK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnTK.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnTK.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnTK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnTK.FillColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnTK.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnTK.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnTK.ForeColor = System.Drawing.Color.White
        Me.btnTK.Location = New System.Drawing.Point(661, 78)
        Me.btnTK.Name = "btnTK"
        Me.btnTK.Size = New System.Drawing.Size(168, 56)
        Me.btnTK.TabIndex = 10
        Me.btnTK.Text = "Tìm Kiếm"
        '
        'xuatReport
        '
        Me.xuatReport.BackColor = System.Drawing.Color.Transparent
        Me.xuatReport.BorderRadius = 15
        Me.xuatReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.xuatReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.xuatReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.xuatReport.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.xuatReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.xuatReport.FillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xuatReport.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xuatReport.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.xuatReport.ForeColor = System.Drawing.Color.White
        Me.xuatReport.Location = New System.Drawing.Point(666, 169)
        Me.xuatReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.xuatReport.Name = "xuatReport"
        Me.xuatReport.Size = New System.Drawing.Size(163, 56)
        Me.xuatReport.TabIndex = 13
        Me.xuatReport.Text = "Xuất Báo Cáo"
        '
        'Guna2HtmlLabel2
        '
        Me.Guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel2.Font = New System.Drawing.Font("Segoe UI", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel2.Location = New System.Drawing.Point(256, 104)
        Me.Guna2HtmlLabel2.Name = "Guna2HtmlLabel2"
        Me.Guna2HtmlLabel2.Size = New System.Drawing.Size(121, 25)
        Me.Guna2HtmlLabel2.TabIndex = 14
        Me.Guna2HtmlLabel2.Text = "Tên Công Dân:"
        '
        'ViPham
        '
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(1351, 740)
        Me.Controls.Add(Me.Guna2CustomGradientPanel1)
        Me.Controls.Add(Me.pnlInput)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.dgvSaiPham)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ViPham"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quản lý Vi Phạm CCCD"
        CType(Me.dgvSaiPham, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.Guna2CustomGradientPanel1.ResumeLayout(False)
        Me.Guna2CustomGradientPanel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlInput.ResumeLayout(False)
        Me.pnlInput.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    'Declare controls
    Friend WithEvents txtMaSaiPham As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dgvSaiPham As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents txtTimKiem As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnTimKiem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlSearch As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblMaSaiPham As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents cboTrangThaiTimKiem As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents lblSearchHeader As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2CustomGradientPanel1 As Guna.UI2.WinForms.Guna2CustomGradientPanel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Xoa As Button
    Friend WithEvents txtTenCongDan As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents cboTrangThai As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txtMucPhat As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtNoiSaiPham As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dtpNgaySai As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents txtLoiSaiPham As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtSoCCCD As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents pnlButtons As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnThem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSua As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnXoa As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents pnlInput As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents lblHeader As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblSoCCCD As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblLoiSaiPham As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblNgaySai As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblNoiSaiPham As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblMucPhat As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents lblTrangThai As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents btnTK As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents Guna2HtmlLabel2 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents xuatReport As Guna.UI2.WinForms.Guna2GradientButton
End Class
