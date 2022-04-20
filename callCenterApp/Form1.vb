Imports System.Data
Imports MySql.Data.MySqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;")
        Dim dr As MySqlDataReader
        Dim cmd1 As New MySqlCommand("select * from table1.services")
        Dim cmd2 As New MySqlCommand("select * from table1.etats")
        Dim cmd3 As New MySqlCommand("select * from table1.centres")
        '----------------------------------Services---------------------------------------------
        Try
            conn.Open()
            cmd1.Connection = conn
            dr = cmd1.ExecuteReader()
            While dr.Read
                Dim sname = dr.GetString("Service")
                service1.Items.Add(sname)
                service2.Items.Add(sname)
                service3.Items.Add(sname)
            End While
            conn.Close()
        Catch ex As MySqlException
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try
        '------------------------------------Etats--------------------------------------
        Try
            conn.Open()
            cmd2.Connection = conn
            dr = cmd2.ExecuteReader()
            While dr.Read
                Dim ename = dr.GetString("Etat")
                etat.Items.Add(ename)
            End While
            conn.Close()
        Catch ex As MySqlException
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try

        '------------------------------------Centres--------------------------------------
        Try
            conn.Open()
            cmd3.Connection = conn
            dr = cmd3.ExecuteReader()
            While dr.Read
                Dim ename = dr.GetString("Centre")
                centre.Items.Add(ename)
            End While
            conn.Close()
        Catch ex As MySqlException
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles service1.SelectedIndexChanged

    End Sub
End Class
