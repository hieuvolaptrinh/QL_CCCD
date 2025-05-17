<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HoSoLienQuan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HoSoLienQuan))
        Me.Guna2GradientPanel1 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.Xoa = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.txtSoCCCD = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtHoVaTen = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtNgSinh = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtQueQuan = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtSoGiayTo = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2GroupBox1 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBoxLoaiGiayTo = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2GradientPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2GradientPanel1
        '
        Me.Guna2GradientPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.Guna2GradientPanel1.Controls.Add(Me.Xoa)
        Me.Guna2GradientPanel1.FillColor = System.Drawing.Color.Blue
        Me.Guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2GradientPanel1.Location = New System.Drawing.Point(0, 1)
        Me.Guna2GradientPanel1.Name = "Guna2GradientPanel1"
        Me.Guna2GradientPanel1.Size = New System.Drawing.Size(1442, 83)
        Me.Guna2GradientPanel1.TabIndex = 15
        '
        'Xoa
        '
        Me.Xoa.BackColor = System.Drawing.Color.Red
        Me.Xoa.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Xoa.ForeColor = System.Drawing.Color.White
        Me.Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Xoa.Location = New System.Drawing.Point(849, 20)
        Me.Xoa.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Xoa.Name = "Xoa"
        Me.Xoa.Size = New System.Drawing.Size(180, 48)
        Me.Xoa.TabIndex = 11
        Me.Xoa.Text = "Đăng Xuất"
        Me.Xoa.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AccessibleDescription = resources.GetString("DataGridView1.AccessibleDescription")
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(0, 466)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1413, 283)
        Me.DataGridView1.TabIndex = 18
        '
        'Guna2CirclePictureBox1
        '
        Me.Guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2CirclePictureBox1.FillColor = System.Drawing.Color.Transparent
        Me.Guna2CirclePictureBox1.Image = Global.QuanLyCCCD.My.Resources.Resources.user
        Me.Guna2CirclePictureBox1.ImageRotate = 0!
        Me.Guna2CirclePictureBox1.Location = New System.Drawing.Point(1143, 97)
        Me.Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Me.Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox1.Size = New System.Drawing.Size(210, 157)
        Me.Guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox1.TabIndex = 17
        Me.Guna2CirclePictureBox1.TabStop = False
        Me.Guna2CirclePictureBox1.UseTransparentBackground = True
        '
        'Guna2Button1
        '
        Me.Guna2Button1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button1.BorderRadius = 20
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.Black
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.Black
        Me.Guna2Button1.FillColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Guna2Button1.FocusedColor = System.Drawing.Color.Green
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Guna2Button1.Image = Global.QuanLyCCCD.My.Resources.Resources.find
        Me.Guna2Button1.Location = New System.Drawing.Point(469, 230)
        Me.Guna2Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(171, 50)
        Me.Guna2Button1.TabIndex = 20
        Me.Guna2Button1.Text = "Tìm Kiếm"
        '
        'txtSoCCCD
        '
        Me.txtSoCCCD.BackColor = System.Drawing.Color.Transparent
        Me.txtSoCCCD.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSoCCCD.BorderRadius = 10
        Me.txtSoCCCD.BorderThickness = 2
        Me.txtSoCCCD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSoCCCD.DefaultText = ""
        Me.txtSoCCCD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSoCCCD.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSoCCCD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSoCCCD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSoCCCD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSoCCCD.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSoCCCD.ForeColor = System.Drawing.Color.Black
        Me.txtSoCCCD.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSoCCCD.Location = New System.Drawing.Point(213, 53)
        Me.txtSoCCCD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSoCCCD.Name = "txtSoCCCD"
        Me.txtSoCCCD.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtSoCCCD.PlaceholderText = "Số CCCD"
        Me.txtSoCCCD.SelectedText = ""
        Me.txtSoCCCD.Size = New System.Drawing.Size(311, 38)
        Me.txtSoCCCD.TabIndex = 19
        '
        'txtHoVaTen
        '
        Me.txtHoVaTen.BackColor = System.Drawing.Color.Transparent
        Me.txtHoVaTen.BorderColor = System.Drawing.Color.IndianRed
        Me.txtHoVaTen.BorderRadius = 10
        Me.txtHoVaTen.BorderThickness = 2
        Me.txtHoVaTen.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHoVaTen.DefaultText = ""
        Me.txtHoVaTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtHoVaTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtHoVaTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtHoVaTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtHoVaTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtHoVaTen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHoVaTen.ForeColor = System.Drawing.Color.Black
        Me.txtHoVaTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtHoVaTen.Location = New System.Drawing.Point(1143, 301)
        Me.txtHoVaTen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtHoVaTen.Name = "txtHoVaTen"
        Me.txtHoVaTen.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtHoVaTen.PlaceholderText = "Họ và tên"
        Me.txtHoVaTen.SelectedText = ""
        Me.txtHoVaTen.Size = New System.Drawing.Size(210, 30)
        Me.txtHoVaTen.TabIndex = 21
        '
        'txtNgSinh
        '
        Me.txtNgSinh.BackColor = System.Drawing.Color.Transparent
        Me.txtNgSinh.BorderColor = System.Drawing.Color.IndianRed
        Me.txtNgSinh.BorderRadius = 10
        Me.txtNgSinh.BorderThickness = 2
        Me.txtNgSinh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNgSinh.DefaultText = ""
        Me.txtNgSinh.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtNgSinh.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtNgSinh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNgSinh.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtNgSinh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNgSinh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtNgSinh.ForeColor = System.Drawing.Color.Black
        Me.txtNgSinh.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtNgSinh.Location = New System.Drawing.Point(1143, 349)
        Me.txtNgSinh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNgSinh.Name = "txtNgSinh"
        Me.txtNgSinh.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtNgSinh.PlaceholderText = "Ngày sinh"
        Me.txtNgSinh.SelectedText = ""
        Me.txtNgSinh.Size = New System.Drawing.Size(210, 32)
        Me.txtNgSinh.TabIndex = 21
        '
        'txtQueQuan
        '
        Me.txtQueQuan.BackColor = System.Drawing.Color.Transparent
        Me.txtQueQuan.BorderColor = System.Drawing.Color.IndianRed
        Me.txtQueQuan.BorderRadius = 10
        Me.txtQueQuan.BorderThickness = 2
        Me.txtQueQuan.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQueQuan.DefaultText = ""
        Me.txtQueQuan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtQueQuan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtQueQuan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQueQuan.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtQueQuan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQueQuan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtQueQuan.ForeColor = System.Drawing.Color.Black
        Me.txtQueQuan.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtQueQuan.Location = New System.Drawing.Point(1143, 261)
        Me.txtQueQuan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtQueQuan.Name = "txtQueQuan"
        Me.txtQueQuan.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtQueQuan.PlaceholderText = "Quê quán"
        Me.txtQueQuan.SelectedText = ""
        Me.txtQueQuan.Size = New System.Drawing.Size(210, 32)
        Me.txtQueQuan.TabIndex = 21
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.SteelBlue
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(411, 410)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(180, 48)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Lưu thay đổi "
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Red
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(1233, 410)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(180, 48)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Xóa giấy tờ"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'txtSoGiayTo
        '
        Me.txtSoGiayTo.BackColor = System.Drawing.Color.Transparent
        Me.txtSoGiayTo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSoGiayTo.BorderRadius = 10
        Me.txtSoGiayTo.BorderThickness = 2
        Me.txtSoGiayTo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSoGiayTo.DefaultText = ""
        Me.txtSoGiayTo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSoGiayTo.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSoGiayTo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSoGiayTo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSoGiayTo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSoGiayTo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtSoGiayTo.ForeColor = System.Drawing.Color.Black
        Me.txtSoGiayTo.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSoGiayTo.Location = New System.Drawing.Point(213, 111)
        Me.txtSoGiayTo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSoGiayTo.Name = "txtSoGiayTo"
        Me.txtSoGiayTo.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtSoGiayTo.PlaceholderText = "Số giấy tờ"
        Me.txtSoGiayTo.SelectedText = ""
        Me.txtSoGiayTo.Size = New System.Drawing.Size(311, 38)
        Me.txtSoGiayTo.TabIndex = 19
        '
        'Guna2GroupBox1
        '
        Me.Guna2GroupBox1.BorderColor = System.Drawing.Color.Red
        Me.Guna2GroupBox1.Controls.Add(Me.Label3)
        Me.Guna2GroupBox1.Controls.Add(Me.Label2)
        Me.Guna2GroupBox1.Controls.Add(Me.Label7)
        Me.Guna2GroupBox1.Controls.Add(Me.ComboBoxLoaiGiayTo)
        Me.Guna2GroupBox1.Controls.Add(Me.Guna2Button1)
        Me.Guna2GroupBox1.Controls.Add(Me.txtSoGiayTo)
        Me.Guna2GroupBox1.Controls.Add(Me.txtSoCCCD)
        Me.Guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Fuchsia
        Me.Guna2GroupBox1.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2GroupBox1.ForeColor = System.Drawing.Color.White
        Me.Guna2GroupBox1.Location = New System.Drawing.Point(12, 97)
        Me.Guna2GroupBox1.Name = "Guna2GroupBox1"
        Me.Guna2GroupBox1.Size = New System.Drawing.Size(694, 291)
        Me.Guna2GroupBox1.TabIndex = 23
        Me.Guna2GroupBox1.Text = "Tìm Kiếm Nhanh"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(35, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 31)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Số CCCD"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(35, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 31)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Số giấy tờ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(35, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 31)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Loại giấy tờ"
        '
        'ComboBoxLoaiGiayTo
        '
        Me.ComboBoxLoaiGiayTo.BackColor = System.Drawing.Color.Transparent
        Me.ComboBoxLoaiGiayTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxLoaiGiayTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLoaiGiayTo.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBoxLoaiGiayTo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ComboBoxLoaiGiayTo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.ComboBoxLoaiGiayTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.ComboBoxLoaiGiayTo.ItemHeight = 30
        Me.ComboBoxLoaiGiayTo.Items.AddRange(New Object() {"Bảo Hiểm Y Tế", "Bằng Lái Xe"})
        Me.ComboBoxLoaiGiayTo.Location = New System.Drawing.Point(213, 171)
        Me.ComboBoxLoaiGiayTo.Name = "ComboBoxLoaiGiayTo"
        Me.ComboBoxLoaiGiayTo.Size = New System.Drawing.Size(311, 36)
        Me.ComboBoxLoaiGiayTo.TabIndex = 21
        '
        'HoSoLienQuan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1425, 750)
        Me.Controls.Add(Me.Guna2GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtQueQuan)
        Me.Controls.Add(Me.txtNgSinh)
        Me.Controls.Add(Me.txtHoVaTen)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Guna2CirclePictureBox1)
        Me.Controls.Add(Me.Guna2GradientPanel1)
        Me.Name = "HoSoLienQuan"
        Me.Text = "Hồ Sơ Liên Quan - 9 Võ Nguyễn Đại Hiếu"
        Me.Guna2GradientPanel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2GroupBox1.ResumeLayout(False)
        Me.Guna2GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2GradientPanel1 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents Xoa As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents txtSoCCCD As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtHoVaTen As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtNgSinh As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtQueQuan As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents txtSoGiayTo As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2GroupBox1 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents ComboBoxLoaiGiayTo As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
End Class
