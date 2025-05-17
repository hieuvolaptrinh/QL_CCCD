Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            Me.MainForm = New ViPham()
        End Sub
    End Class
End Namespace

