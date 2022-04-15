Imports MySql.Data.MySqlClient

Public Class Form1

    ' Dim cmd As MySqlCommand("select * from table1",conn)
    ' cmd.Parameters.addwithvalue("@parm1",Textbox1.Text)
    ' Dim my reader as MySqlDataReader = cmd.ExcuteReader
    'If (myreader.Read()) Then
    ' Textbox2.text = myreader("id")
    ' Textbox3.text = myreader("firstname")
    ' Textbox4.text = myreader("lastname")
    'Else
    ' MessageBox.show("No_data_founded)
    'End If

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        Dim Conexioninfo As String = "server=127.0.0.1;database=table1;user id=root;port=3306"
        Dim conn As New MySqlConnection(Conexioninfo)
        Dim command As MySqlCommand
        Try
            conn.Open()
            MsgBox("Connect")
            conn.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conn.Dispose()
        End Try
    End Sub

    Private Sub Guna2HtmlLabel1_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel1.Click

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) 

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2ShadowPanel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2ShadowPanel1.Paint

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Guna2ShadowPanel3_Paint(sender As Object, e As PaintEventArgs) Handles Guna2ShadowPanel3.Paint

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub IconPictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles Guna2DateTimePicker1.ValueChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim Conexioninfo As String = "server=127.0.0.1;database=table1;user id=root;port=3306"
        Dim conn As New MySqlConnection(Conexioninfo)
        Dim command As MySqlCommand
        Dim reader As MySqlDataReader

        Try
            conn.Open()
            Dim Query As String
            Query = "select * from table1.services"
            command = New MySqlCommand(Query, conn)
            reader = command.ExecuteReader
            While reader.Read
                Dim service = reader.GetString("Service")
                ComboBox1.Items.Add(service)
            End While
            conn.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            conn.Dispose()
        End Try

    End Sub
End Class
