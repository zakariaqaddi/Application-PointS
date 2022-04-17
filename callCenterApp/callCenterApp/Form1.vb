Imports System.Data
Imports MySql.Data.MySqlClient
Public Class Form1
    Private conn As New MySqlConnection("server=localhost;user=root;database=callcenter;port=3306;")
    Private cmd As New MySqlCommand("select * from client")
    Private dr As MySqlDataReader
    Private t As New DataTable
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            cmd.Connection = conn
            dr = cmd.ExecuteReader()
            t.Load(dr)
            dr.Close()
            DataGridView1.DataSource = t

        Catch ex As Exception
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try


    End Sub
End Class
