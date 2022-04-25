Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Public Class Form1
    Dim id As Integer = 1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;")
        Dim dr As MySqlDataReader
        Dim cmd1 As New MySqlCommand("select * from table1.services")
        Dim cmd2 As New MySqlCommand("select * from table1.etats")
        Dim cmd3 As New MySqlCommand("select * from table1.centres")
        Dim cmd4 As New MySqlCommand("select * from table1.numero_de_client where id ='" & id & "'")
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
        '------------------------------------PhoneNb-------------------------------------
        Try
            conn.Open()
            cmd4.Connection = conn
            dr = cmd4.ExecuteReader()
            While dr.Read
                Dim pname = dr.GetString("Numero")
                phoneNb.Text = pname
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;")
        Dim dr As MySqlDataReader
        Dim cmd As New MySqlCommand("select * from table1.centres where centre ='" & centre.Text & "'")
        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage

        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential("zakariaqaddi@outlook.com", "Ziko@12345")
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.office365.com"

        Try
            conn.Open()
            cmd.Connection = conn
            dr = cmd.ExecuteReader()
            While dr.Read
                Try
                    Dim mail = dr.GetString("Email_du_centre")
                    e_mail.From = New MailAddress("zakariaqaddi@outlook.com")
                    e_mail.To.Add("marketing@imperial-pneu.ma")
                    e_mail.Subject = "Rendez-vous"
                    e_mail.IsBodyHtml = False
                    e_mail.Body = "fin a sat"
                    Smtp_Server.Send(e_mail)
                    MsgBox("mail sended,thank you : ")
                    'envoyer un mail de rendez-vous à e_mail
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End While
            conn.Close()
        Catch ex As MySqlException
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;")
        Dim dr As MySqlDataReader
        id = id + 1
        Dim cmd4 As New MySqlCommand("select * from table1.numero_de_client where id ='" & id & "'")
        Try
            conn.Open()
            cmd4.Connection = conn
            dr = cmd4.ExecuteReader()
            While dr.Read
                Dim pname = dr.GetString("Numero")
                phoneNb.Text = pname
            End While
            conn.Close()
        Catch ex As MySqlException
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub phoneNb_Click(sender As Object, e As EventArgs) Handles phoneNb.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;")
        Dim dr As MySqlDataReader
        id = id - 1
        Dim cmd4 As New MySqlCommand("select * from table1.numero_de_client where id ='" & id & "'")
        Try
            conn.Open()
            cmd4.Connection = conn
            dr = cmd4.ExecuteReader()
            While dr.Read
                Dim pname = dr.GetString("Numero")
                phoneNb.Text = pname
            End While
            conn.Close()
        Catch ex As MySqlException
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;")
        Dim sqlInsert As String = "insert into general_table(Numero, Prenom, Nom, Etat, Observation, Service1, Service2, Service3) values (@Numero, @Prenom, @Nom, @Etat, @Observation, @Service1, @Service2, @Service3)"
        Dim cmd = New MySqlCommand(sqlInsert, conn)
        cmd.Parameters.AddWithValue("@Numero", phoneNb.Text)
        cmd.Parameters.AddWithValue("@Prenom", TextBox2.Text)
        cmd.Parameters.AddWithValue("@Nom", TextBox1.Text)
        cmd.Parameters.AddWithValue("@Etat", etat.Text)
        cmd.Parameters.AddWithValue("@Observation", RichTextBox1.Text)
        cmd.Parameters.AddWithValue("@Service1", service1.Text)
        cmd.Parameters.AddWithValue("@Service2", service2.Text)
        cmd.Parameters.AddWithValue("@Service3", service3.Text)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try
        'Button3_Click(sender, e)
        'phoneNb.Text = ""
        TextBox2.Text = ""
        TextBox1.Text = ""
        etat.Text = ""
        RichTextBox1.Text = ""
        service1.Text = ""
        service2.Text = ""
        service3.Text = ""

    End Sub
End Class
