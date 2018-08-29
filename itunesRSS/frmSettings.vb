Public Class frmSettings

    Dim genre As String
    Dim country As String
    Dim swearing As String
    Dim limit As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Select Case ComboBox1.Text
            '// A
            Case "All"
                genre = ""
            Case "Alternative"
                genre = "20"
            Case "Anime"
                genre = "29"
                '// B
            Case "Blues"
                genre = "2"
            Case "Brazilian"
                genre = "1122"
                '// C
            Case "Children's Music"
                genre = "4"
            Case "Chinese"
                genre = "1232"
            Case "Classical"
                genre = "5"
            Case "Comedy"
                genre = "3"
            Case "Country"
                genre = "6"
                '// D
            Case "Dance"
                genre = "17"
            Case "Disney"
                genre = "50000063"
                '// E
            Case "Easy Listening"
                genre = "25"
            Case "Electronic"
                genre = "7"
            Case "Enka"
                genre = "28"
                '// F
            Case "Fitness & Workout"
                genre = "50"
            Case "French Pop"
                genre = "50000064"
                '// G
            Case "German Folk"
                genre = "50000068"
            Case "German Pop"
                genre = "50000066"
                '// H
            Case "Hip-Hop/Rap"
                genre = "18"
            Case "Holiday"
                genre = "8"
                '// I
            Case "Indian"
                genre = "1262"
            Case "Instrumental"
                genre = "53"
                '// J
            Case "J-Pop"
                genre = "27"
            Case "Jazz"
                genre = "11"
                '// K
            Case "K-Pop"
                genre = "51"
            Case "Karaoke"
                genre = "52"
            Case "Kayokyoku"
                genre = "30"
            Case "Korean"
                genre = "1243"
                '// L
            Case "Latino"
                genre = "12"
                '// N
            Case "New Age"
                genre = "13"
                '// O
            Case "Opera"
                genre = "9"
                '// p
            Case "Pop"
                genre = "14"
                '//R
            Case "R&B/Soul"
                genre = "15"
            Case "Reggae"
                genre = "24"
            Case "Religious"
                genre = "22"
            Case "Rock"
                genre = "21"
                '// S
            Case "Singer/Songwriter"
                genre = "10"
            Case "Soundtrack"
                genre = "16"
            Case "Spoken Word"
                genre = "50000061"
                '// V
            Case "Vocal"
                genre = "23"
                '// W
            Case "World"
                genre = "19"
            Case Else
                genre = "" '//blank
        End Select

        Select Case ComboBox2.Text
            Case "United Kingdom"
                country = "gb"
            Case "United States"
                country = "us"
            Case Else
                country = "gb"
        End Select

        Select Case ComboBox3.Text
            Case "10"
                limit = "10"
            Case "25"
                limit = "25"
            Case "50"
                limit = "50"
            Case "100"
                limit = "100"
        End Select

        Select Case ComboBox4.Text
            Case "Yes"
                swearing = "true"
            Case "No"
                swearing = "false"
        End Select
        If swearing = "" Or country = "" Or limit = "" Or genre = "" Then
            MsgBox("One of your items are empty")
        Else
            My.Settings.url = "https://itunes.apple.com/" + country + "/rss/topsongs/limit=" + limit + "/genre=" + genre + "/explicit=" + swearing + "/xml"
            My.Settings.Save()
            MsgBox("Restarting")
            Application.Restart()
        End If
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class