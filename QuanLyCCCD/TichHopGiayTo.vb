Public Class TichHopGiayTo
    Private dao As New GiayToDAO()

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        Me.Close()
        DieuKhien.Show()
    End Sub

    Private Sub Guna2GradientButton7_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton7.Click
        ' Nút đăng ký GPLX
        Dim soCCCD As String = cccd.Text.Trim()
        Dim soGiayPhep As String = soGPLX.Text.Trim()
        Dim hangGiayPhep As String = cbbHang.Text.Trim()
        Dim ngayCap As Date = ngayCapGPLX.Value
        Dim noiCap As String = noiCapGPLX.Text.Trim()

        If soCCCD = "" Or soGiayPhep = "" Or hangGiayPhep = "" Or noiCap = "" Then
            MessageBox.Show("Vui lòng điền đầy đủ thông tin GPLX!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim giayTo As New GiayToLienQuan()
        giayTo.SoGiayTo = soGiayPhep
        giayTo.SoCCCD = soCCCD
        giayTo.NgayCap = ngayCap.Date
        giayTo.NoiCap = noiCap
        giayTo.ChiTiet = "Hạng " & hangGiayPhep

        dao.ThemGPLX(giayTo)
    End Sub

    Private Sub Guna2GradientButton8_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton8.Click
        ' Nút đăng ký BHYT
        Dim soCCCD As String = cccd.Text.Trim()
        Dim maBHYT As String = soBHYT.Text.Trim()
        Dim ngayCap As Date = dateStart.Value
        Dim ngayHetHan As Date = dateEnd.Value
        Dim noiCap As String = noicapBHYT.Text.Trim()
        Dim noiDKKCB As String = noiDKi.Text.Trim()

        If soCCCD = "" Or maBHYT = "" Or noiDKKCB = "" Then
            MessageBox.Show("Vui lòng điền đầy đủ thông tin BHYT!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim giayTo As New GiayToLienQuan()
        giayTo.SoGiayTo = maBHYT
        giayTo.SoCCCD = soCCCD
        giayTo.NgayCap = ngayCap.Date
        giayTo.NoiCap = noiCap
        giayTo.NgayHetHan = ngayHetHan.Date
        giayTo.ChiTiet = "Nơi ĐK KCB: " & noiDKKCB

        dao.ThemBHYT(giayTo)
    End Sub

    Private Sub Guna2GradientButton6_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton6.Click
        Me.Close()
        QuanLy.Show()
    End Sub

    Private Sub Guna2GradientButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton2.Click
        Me.Close()
        HoSoLienQuan.Show()
    End Sub

    Private Sub Guna2GradientButton4_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton4.Click
        Me.Close()
        ThongKe.Show()
    End Sub

    Private Sub Xoa_Click(sender As Object, e As EventArgs) Handles Xoa.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub TrangChủToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Me.Close()
        Home.Show()
    End Sub

    Private Sub BảngĐiềuKhiểnToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Me.Close()
        Home.Show()
    End Sub

    Private Sub QuảnLýCôngDânToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Me.Close()
        QuanLy.Show()
    End Sub

    Private Sub HồSơLiênQuanToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Me.Close()
        HoSoLienQuan.Show()
    End Sub

    Private Sub TíchHợpGiấyTờToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        ' Đã ở form Tích Hợp Giấy Tờ, không cần làm gì
    End Sub

    Private Sub BáoCáoThốngKêToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Me.Close()
        ThongKe.Show()
    End Sub
End Class