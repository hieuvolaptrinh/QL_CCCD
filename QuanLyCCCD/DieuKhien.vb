Imports System.Data.SqlClient

Public Class DieuKhien
    Private dao As New DiaChiDAO()
    Private tinhHuyenData As Dictionary(Of TinhTP, List(Of QuanHuyen))

    Private Sub DieuKhien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Lấy dữ liệu tỉnh thành và quận huyện từ cơ sở dữ liệu
        tinhHuyenData = dao.GetTinhHuyenData()

        ' Load vào TreeView
        For Each tinh As TinhTP In tinhHuyenData.Keys
            Dim tinhNode As TreeNode = TreeView1.Nodes.Add(tinh.TenTTP)
            For Each huyen As QuanHuyen In tinhHuyenData(tinh)
                tinhNode.Nodes.Add(huyen.TenQH)
            Next
        Next

        ' Cấu hình ListView hiển thị dạng danh sách
        ListView1.View = View.List
    End Sub

    ' Xử lý khi click vào node huyện
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        ListView1.Items.Clear()

        Dim selectedNode As TreeNode = e.Node
        If selectedNode.Parent IsNot Nothing Then ' Nếu là node cấp 2 (huyện)
            Dim tinhTen As String = selectedNode.Parent.Text
            Dim huyenTen As String = selectedNode.Text

            ' Lấy maQH từ tên tỉnh và huyện
            Dim maQH As String = dao.GetMaQH(tinhTen, huyenTen)
            If maQH <> "" Then
                ' Lấy danh sách công dân từ cơ sở dữ liệu
                Dim danhSachCongDan As List(Of CongDanCCCD) = dao.GetCongDanByQuanHuyen(maQH)
                For Each congDan As CongDanCCCD In danhSachCongDan
                    ListView1.Items.Add(congDan.HoTen)
                Next
            End If
        End If
    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        QuanLy.Show()
        Me.Close()
    End Sub

    Private Sub Guna2GradientButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton2.Click
        Me.Close()
        HoSoLienQuan.Show()
    End Sub

    Private Sub Guna2GradientButton3_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton3.Click
        Me.Close()
        TichHopGiayTo.Show()
    End Sub

    Private Sub Guna2GradientButton4_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton4.Click
        Me.Close()
        ThongKe.Show()
    End Sub

    Private Sub Xoa_Click(sender As Object, e As EventArgs) Handles Xoa.Click
        Me.Close()
        Form1.Show()
    End Sub
End Class