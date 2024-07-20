Imports System.IO
Imports System.Text

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Użycie pełnej ścieżki lub Application.StartupPath do ścieżki względnej
        Dim filePath As String = Path.Combine(Application.StartupPath,
                                              "C:\Users\petit\Desktop\repos\uo\rok 3\Kodowanie i kompresja\lista6\Lista6_zadanie2\Lista6_zadanie2\sample.txt")

        ' Sprawdzanie czy plik istnieje
        If Not File.Exists(filePath) Then
            MessageBox.Show("Plik sample.txt nie został znaleziony.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Wczytanie tekstu z pliku
        Dim text As String = File.ReadAllText(filePath)

        ' Obliczanie częstotliwości występowania digramów
        Dim digramFrequencies As Dictionary(Of String, Integer) = CalculateDigramFrequencies(text)

        ' Obliczanie częstotliwości występowania znaków
        Dim characters As Dictionary(Of String, Integer) = CalculateCharacters(text)

        ' Tworzenie finalnego słownika w postaci listy
        Dim finalDictionary As List(Of String) = CreateSummary(digramFrequencies, characters)

        ' Wyświetlanie zakodowanego tekstu
        TextBox1.Text = EncodeTextIn(text, finalDictionary)
        TextBox2.Text = EncodeTextBin(text, finalDictionary)
    End Sub

    ' Oblicza częstotliwość występowania digramów w tekście
    Function CalculateDigramFrequencies(ByVal text As String) As Dictionary(Of String, Integer)
        Dim frequencies As New Dictionary(Of String, Integer)
        For i As Integer = 0 To text.Length - 2
            Dim digram As String = text.Substring(i, 2)
            If Not frequencies.ContainsKey(digram) Then
                frequencies(digram) = 0
            End If
            frequencies(digram) += 1
        Next
        Return frequencies
    End Function

    ' Oblicza częstotliwość występowania znaków w tekście
    Function CalculateCharacters(ByVal text As String) As Dictionary(Of String, Integer)
        Dim characters As New Dictionary(Of String, Integer)
        For i As Integer = 0 To text.Length - 1
            Dim character As String = text(i).ToString()
            If Not characters.ContainsKey(character) Then
                characters(character) = 0
            End If
            characters(character) += 1
        Next
        Return characters
    End Function

    ' Tworzy podsumowanie z częstotliwości digramów i znaków
    Function CreateSummary(ByVal digramFrequencies As Dictionary(Of String, Integer),
                           ByVal characters As Dictionary(Of String, Integer)) As List(Of String)
        Dim summary As New List(Of String)

        ' Sortowanie słownika według wartości malejąco
        Dim sortedDigrams = From kvp In digramFrequencies Order By kvp.Value Descending Select kvp
        Dim keyDigrams = sortedDigrams.Select(Function(kvp) kvp.Key).ToList()

        ' Dodanie znaków do podsumowania
        For Each kvp In characters
            summary.Add(kvp.Key)
        Next

        ' Dodanie digramów do podsumowania
        For Each digram In keyDigrams
            summary.Add(digram)
        Next

        Return summary
    End Function

    ' Koduje tekst przy użyciu kodowania digramowego
    Function EncodeTextIn(ByVal text As String, ByVal finalDictionary As List(Of String)) As String
        Dim encodedText As String = ""
        For i As Integer = 0 To text.Length - 1 Step 2
            Dim digram As String = text.Substring(i, 2)
            Dim index As Integer = finalDictionary.IndexOf(digram)
            If index = - 1 Then
                Dim letter As String = text(i).ToString()
                Dim indexLetter As Integer = finalDictionary.IndexOf(letter)
                encodedText &= " " & indexLetter.ToString()
            Else
                encodedText &= " " & index.ToString()
            End If
        Next
        Return encodedText
    End Function

    ' Koduje tekst do binarnej reprezentacji
    Function EncodeTextBin(ByVal text As String, ByVal finalDictionary As List(Of String)) As String
        Dim encodedTextBinary As String = ""
        For i As Integer = 0 To text.Length - 1 Step 2
            Dim digram As String = text.Substring(i, 2)
            Dim index As Integer = finalDictionary.IndexOf(digram)
            If index = - 1 Then
                Dim letter As String = text(i).ToString()
                Dim indexLetter As Integer = finalDictionary.IndexOf(letter)
                Dim binaryString As String = Convert.ToString(indexLetter, 2).PadLeft(7, "0"c)
                encodedTextBinary &= " " & binaryString
            Else
                Dim binaryString As String = Convert.ToString(index, 2).PadLeft(7, "0"c)
                encodedTextBinary &= binaryString
            End If
        Next
        Return encodedTextBinary
    End Function
End Class
