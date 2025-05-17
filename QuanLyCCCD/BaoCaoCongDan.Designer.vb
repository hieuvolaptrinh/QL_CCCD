<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BaoCaoCongDan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TrangChủToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BảngĐiềuKhiểnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuảnLýCôngDânToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HồSơLiênQuanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TíchHợpGiấyTờToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BáoCáoThốngKêToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Guna2GradientPanel1 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTen = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Xoa = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.Guna2GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyCCCD.ReportDSCCCD.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 179)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1424, 510)
        Me.ReportViewer1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrangChủToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1424, 28)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TrangChủToolStripMenuItem
        '
        Me.TrangChủToolStripMenuItem.Name = "TrangChủToolStripMenuItem"
        Me.TrangChủToolStripMenuItem.Size = New System.Drawing.Size(87, 24)
        Me.TrangChủToolStripMenuItem.Text = "Trang chủ"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BảngĐiềuKhiểnToolStripMenuItem, Me.QuảnLýCôngDânToolStripMenuItem, Me.HồSơLiênQuanToolStripMenuItem, Me.TíchHợpGiấyTờToolStripMenuItem, Me.BáoCáoThốngKêToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(151, 24)
        Me.ToolStripMenuItem1.Text = "Điều Hướng Nhanh"
        '
        'BảngĐiềuKhiểnToolStripMenuItem
        '
        Me.BảngĐiềuKhiểnToolStripMenuItem.Name = "BảngĐiềuKhiểnToolStripMenuItem"
        Me.BảngĐiềuKhiểnToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.BảngĐiềuKhiểnToolStripMenuItem.Text = "Bảng điều khiển"
        '
        'QuảnLýCôngDânToolStripMenuItem
        '
        Me.QuảnLýCôngDânToolStripMenuItem.Name = "QuảnLýCôngDânToolStripMenuItem"
        Me.QuảnLýCôngDânToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.QuảnLýCôngDânToolStripMenuItem.Text = "Quản lý công dân"
        '
        'HồSơLiênQuanToolStripMenuItem
        '
        Me.HồSơLiênQuanToolStripMenuItem.Name = "HồSơLiênQuanToolStripMenuItem"
        Me.HồSơLiênQuanToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.HồSơLiênQuanToolStripMenuItem.Text = "Hồ sơ liên quan"
        '
        'TíchHợpGiấyTờToolStripMenuItem
        '
        Me.TíchHợpGiấyTờToolStripMenuItem.Name = "TíchHợpGiấyTờToolStripMenuItem"
        Me.TíchHợpGiấyTờToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.TíchHợpGiấyTờToolStripMenuItem.Text = "Tích hợp giấy tờ"
        '
        'BáoCáoThốngKêToolStripMenuItem
        '
        Me.BáoCáoThốngKêToolStripMenuItem.Name = "BáoCáoThốngKêToolStripMenuItem"
        Me.BáoCáoThốngKêToolStripMenuItem.Size = New System.Drawing.Size(208, 26)
        Me.BáoCáoThốngKêToolStripMenuItem.Text = "Báo cáo thống kê"
        '
        'Guna2GradientPanel1
        '
        Me.Guna2GradientPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.Guna2GradientPanel1.Controls.Add(Me.Guna2Button1)
        Me.Guna2GradientPanel1.Controls.Add(Me.Label1)
        Me.Guna2GradientPanel1.Controls.Add(Me.txtTen)
        Me.Guna2GradientPanel1.Controls.Add(Me.Xoa)
        Me.Guna2GradientPanel1.FillColor = System.Drawing.Color.Blue
        Me.Guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Guna2GradientPanel1.Location = New System.Drawing.Point(0, 31)
        Me.Guna2GradientPanel1.Name = "Guna2GradientPanel1"
        Me.Guna2GradientPanel1.Size = New System.Drawing.Size(1424, 142)
        Me.Guna2GradientPanel1.TabIndex = 17
        '
        'Guna2Button1
        '
        Me.Guna2Button1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button1.BorderRadius = 20
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.Black
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.Black
        Me.Guna2Button1.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Guna2Button1.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button1.ForeColor = System.Drawing.Color.Black
        Me.Guna2Button1.Location = New System.Drawing.Point(811, 48)
        Me.Guna2Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(181, 45)
        Me.Guna2Button1.TabIndex = 15
        Me.Guna2Button1.Text = "TÌm Kiếm"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label1.Location = New System.Drawing.Point(25, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(303, 76)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Quản Lý" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Căng Cước Công Dân"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTen
        '
        Me.txtTen.BackColor = System.Drawing.Color.Transparent
        Me.txtTen.BorderColor = System.Drawing.Color.IndianRed
        Me.txtTen.BorderRadius = 20
        Me.txtTen.BorderThickness = 2
        Me.txtTen.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTen.DefaultText = ""
        Me.txtTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTen.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtTen.ForeColor = System.Drawing.Color.Black
        Me.txtTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTen.Location = New System.Drawing.Point(418, 45)
        Me.txtTen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTen.Name = "txtTen"
        Me.txtTen.PlaceholderForeColor = System.Drawing.Color.Black
        Me.txtTen.PlaceholderText = "Tìm theo tên............."
        Me.txtTen.SelectedText = ""
        Me.txtTen.Size = New System.Drawing.Size(339, 48)
        Me.txtTen.TabIndex = 13
        '
        'Xoa
        '
        Me.Xoa.BackColor = System.Drawing.Color.Red
        Me.Xoa.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Xoa.ForeColor = System.Drawing.Color.White
        Me.Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Xoa.Location = New System.Drawing.Point(1164, 2)
        Me.Xoa.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Xoa.Name = "Xoa"
        Me.Xoa.Size = New System.Drawing.Size(106, 39)
        Me.Xoa.TabIndex = 11
        Me.Xoa.Text = "Đăng Xuất"
        Me.Xoa.UseVisualStyleBackColor = False
        '
        'BaoCaoCongDan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1424, 689)
        Me.Controls.Add(Me.Guna2GradientPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "BaoCaoCongDan"
        Me.Text = "BaoCaoCongDam"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Guna2GradientPanel1.ResumeLayout(False)
        Me.Guna2GradientPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents TrangChủToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BảngĐiềuKhiểnToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuảnLýCôngDânToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HồSơLiênQuanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TíchHợpGiấyTờToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BáoCáoThốngKêToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Guna2GradientPanel1 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents Xoa As Button
    Friend WithEvents txtTen As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
End Class
