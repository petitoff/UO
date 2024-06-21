Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq

Public Class Form1
    Dim obrazek_dane As Byte()
    Dim dane_pred As Byte()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenDialog As New OpenFileDialog
        If OpenDialog.ShowDialog() = DialogResult.OK Then
            obrazek_dane = File.ReadAllBytes(OpenDialog.FileName)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Szer = 640
        Dim Wys = 500
        Dim Obraz As New Bitmap(Szer, Wys)
        PictureBox1.Image = Obraz

        For i = 0 To Szer - 1
            For j = 0 To Wys - 1
                Dim pv = obrazek_dane(j * 640 + i)
                Obraz.SetPixel(i, j, Color.FromArgb(pv, pv, pv))
            Next
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dane_pred = Predykcja(obrazek_dane)
        Dim Szer = 640
        Dim Wys = 500
        Dim Obraz As New Bitmap(Szer, Wys)
        PictureBox1.Image = Obraz

        For i = 0 To Szer - 1
            For j = 0 To Wys - 1
                Dim pv = dane_pred(j * 640 + i)
                Obraz.SetPixel(i, j, Color.FromArgb(pv, pv, pv))
            Next
        Next
    End Sub

    Private Function Predykcja(ByVal Dane As Byte()) As Byte()
        Dim DanePred As Byte() = New Byte(Dane.Length - 1) {}
        Dim Aux As Integer
        DanePred(0) = Dane(0)
        For i As Integer = 1 To Dane.Length - 1
            Aux = CInt(Dane(i)) - CInt(Dane(i - 1))
            If Aux < 0 Then
                DanePred(i) = Aux + 256
            Else
                DanePred(i) = Aux
            End If
        Next
        Return DanePred
    End Function

    Private Function Dekoduj(ByVal DanePred As Byte()) As Byte()
        Dim Dane As Byte() = New Byte(DanePred.Length - 1) {}
        Dim Aux As Integer
        Dane(0) = DanePred(0)
        For i As Integer = 1 To DanePred.Length - 1
            Aux = CInt(Dane(i - 1)) + CInt(DanePred(i))
            If Aux > 255 Then
                Dane(i) = Aux - 256
            Else
                Dane(i) = Aux
            End If
        Next
        Return Dane
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dane_dekod As Byte() = Dekoduj(dane_pred)
        Dim Szer = 640
        Dim Wys = 500
        Dim Obraz As New Bitmap(Szer, Wys)
        PictureBox1.Image = Obraz

        For i = 0 To Szer - 1
            For j = 0 To Wys - 1
                Dim pv = dane_dekod(j * 640 + i)
                Obraz.SetPixel(i, j, Color.FromArgb(pv, pv, pv))
            Next
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim saveFileDialog As New SaveFileDialog()
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = saveFileDialog.FileName
            File.WriteAllBytes(filePath, dane_pred)
        End If
    End Sub
End Class
