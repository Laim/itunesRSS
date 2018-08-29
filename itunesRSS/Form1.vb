Option Strict On
Option Explicit On
'//
Imports System
Imports System.IO
Imports System.Xml
Imports System.Net

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '//
        Dim myRandom As New Random
        Dim lb1 As Integer = ListBox1.Items.Count
        Dim lb1val As Integer = myRandom.Next(lb1)
        '//


        lblSongValue.Text = ListBox1.Items.Item(lb1val).ToString
        lblArtistValue.Text = ListBox2.Items.Item(lb1val).ToString
        PictureBox1.ImageLocation = ListBox3.Items.Item(lb1val).ToString
        LinkLabel1.Text = lblArtistValue.Text + " On iTunes"
        lblPaidValue.Text = ListBox4.Items.Item(lb1val).ToString.Replace("Â", "").Replace("-", "")
        ListBox5.Items.Add(lb1val)
        ListBox1.Items.Remove(lb1val)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Width = 369
        Try
            Dim web As New WebClient
            Dim xmlText As String = web.DownloadString(My.Settings.url)
            File.WriteAllText("itunes.xml", xmlText)

            lblUpdatedValue.Text = CStr(Date.Today) + " - " + CStr(TimeOfDay)
            My.Settings.time = CStr(Date.Today) + " - " + CStr(TimeOfDay)
            My.Settings.Save()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        '//

        lblUpdatedValue.Text = My.Settings.time
        Dim xmldoc As New XmlDataDocument()
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim fs As New FileStream("itunes.xml", FileMode.Open, FileAccess.Read)

        '//
        Dim songName As String
        Dim artistName As String
        Dim albumArt As String
        Dim songPrice As String
        '//
        xmldoc.Load(fs)
        xmlnode = xmldoc.GetElementsByTagName("entry")
        For i = 0 To xmlnode.Count - 1
            xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
            songName = xmlnode(i).ChildNodes.Item(3).InnerText.Trim()
            artistName = xmlnode(i).ChildNodes.Item(8).InnerText.Trim()
            albumArt = xmlnode(i).ChildNodes.Item(12).InnerText.Trim()
            songPrice = xmlnode(i).ChildNodes.Item(9).InnerText.Trim()
            '0: <updated>
            '1: <id>
            '2: <title>
            '3: <im:name> - song only
            '8: <im:artist> - artist name only
            '9: <im:price> - price
            '10: <im:image> - 55
            '11: <im:image> - 60
            '12: <im:image> - 170
            '13: <rights> - copyright
            '14: <im:releasedate> - release date
            '15: <im:collection> - includes 'single'
            ListBox1.Items.Add(songName)
            ListBox2.Items.Add(artistName)
            ListBox3.Items.Add(albumArt)
            ListBox4.Items.Add(songPrice)
        Next
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.laimmckenzie.com/twnply/artist.php?artist=" + lblArtistValue.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim web As New WebClient
        Dim youtube As String
        youtube = web.DownloadString("http://www.laimmckenzie.com/twnply/youtubeVideo/get.php?s=" + lblArtistValue.Text + "-" + lblSongValue.Text)
        Process.Start(youtube)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmSettings.Show()
    End Sub
End Class
