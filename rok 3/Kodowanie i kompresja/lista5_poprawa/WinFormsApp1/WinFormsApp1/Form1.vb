Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Private obrazek_dane As Byte()
    Private dane_pred As Byte()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenDialog As New OpenFileDialog
        If OpenDialog.ShowDialog() = DialogResult.OK Then
            obrazek_dane = File.ReadAllBytes(OpenDialog.FileName)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Szer As Integer = 640
        Dim Wys As Integer = 500
        Dim Obraz As New Bitmap(Szer, Wys)
        PictureBox1.Image = Obraz
        For i = 0 To Szer - 1
            For j = 0 To Wys - 1
                Dim pv As Byte = obrazek_dane(j * 640 + i)
                Obraz.SetPixel(i, j, Color.FromArgb(pv, pv, pv))
            Next
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dane_pred = Predykcja(obrazek_dane)
        Dim Szer As Integer = 640
        Dim Wys As Integer = 500
        Dim Obraz As New Bitmap(Szer, Wys)
        PictureBox1.Image = Obraz
        For i = 0 To Szer - 1
            For j = 0 To Wys - 1
                Dim pv As Byte = dane_pred(j * 640 + i)
                Obraz.SetPixel(i, j, Color.FromArgb(pv, pv, pv))
            Next
        Next
    End Sub

    Private Function Predykcja(ByVal Dane As Byte()) As Byte()
        Dim DanePred As Byte() = New Byte(Dane.Length - 1) {}
        Dim Aux As Integer
        If Dane(0) <> 0 Then
            Aux = CInt(Convert.ToInt32(Dane(0)) - 1)
        End If
        For i As Integer = 1 To DanePred.Length - 1
            Aux = CInt(Convert.ToInt32(Dane(i)) - Convert.ToInt32(Dane(i - 1)))
            If Aux < 0 Then
                DanePred(i) = Aux + 256
            Else
                DanePred(i) = Aux
            End If
        Next
        Return DanePred
    End Function

End Class
