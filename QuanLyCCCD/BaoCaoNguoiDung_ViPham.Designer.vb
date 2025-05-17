<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BaoCaoNguoiDung_ViPham
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TrangChủToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BảngĐiềuKhiểnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuảnLýCôngDânToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HồSơLiênQuanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TíchHợpGiấyTờToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BáoCáoThốngKêToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(-3, 31)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1282, 686)
        Me.ReportViewer1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrangChủToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1279, 28)
        Me.MenuStrip1.TabIndex = 10
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
        'BaoCaoNguoiDung_ViPham
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1279, 715)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "BaoCaoNguoiDung_ViPham"
        Me.Text = "BaoCaoNguoiDung_ViPham"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
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
End Class
