Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Public Class Form1
    Dim id As Integer = 1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;convert zero datetime=True")
        Dim dr As MySqlDataReader
        Dim cmd1 As New MySqlCommand("select * from services")
        Dim cmd2 As New MySqlCommand("select * from etats")
        Dim cmd3 As New MySqlCommand("select * from centres")
        Dim cmd4 As New MySqlCommand("select * from numero_de_client where id ='" & id & "'")
        Dim cmd5 As New MySqlCommand("select count(*) from numero_de_client")
        Dim cmd6 As New MySqlCommand("select count(Numero) from general_table where etat = 'NRP'")
        Dim cmd7 As New MySqlCommand("select count(Numero) from general_table where DemandeS != ' '")
        Dim cmd8 As New MySqlCommand("select count(*) from general_table")
        '---------------------------------------------------------------------------------------

        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("select * from general_table", conn)
        adapter.Fill(table)
        DataGridView1.DataSource = table

        '----------------------------------Data------------------------------------------------
        Try
            conn.Open()
            cmd8.Connection = conn
            Dim sqlresult = Convert.ToString(cmd8.ExecuteScalar)
            Data.Text = sqlresult
        Catch ex As MySqlException
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try
        '----------------------------------Leads------------------------------------------------
        Try
            conn.Open()
            cmd5.Connection = conn
            Dim sqlresult = Convert.ToString(cmd5.ExecuteScalar)
            Leads.Text = sqlresult
        Catch ex As MySqlException
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try

        ''----------------------------------NRP--------------------------------------------------
        Try
            conn.Open()
            cmd6.Connection = conn
            Dim sqlresult = Convert.ToString(cmd6.ExecuteScalar)
            NRP.Text = sqlresult
        Catch ex As MySqlException
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try
        ''----------------------------------DS---------------------------------------------------
        Try
            conn.Open()
            cmd7.Connection = conn
            Dim sqlresult = Convert.ToString(cmd7.ExecuteScalar)
            DS.Text = sqlresult
        Catch ex As MySqlException
            MsgBox("Error!")
        Finally
            conn.Close()
        End Try



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
                Etat.Items.Add(ename)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Quitter.Click
        Application.Exit()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Envoyer.Click

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


    Private Sub Button3_Click(sender As Object, e As EventArgs)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Left.Click
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Ajouter.Click
        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;")
        Dim sqlInsert As String = "insert into general_table(Numero, Prenom, Nom, Etat, Observation, Service1, Service2, Service3, DemandeS) values (@Numero, @Prenom, @Nom, @Etat, @Observation, @Service1, @Service2, @Service3, @DemandeS)"
        Dim cmd = New MySqlCommand(sqlInsert, conn)
        cmd.Parameters.AddWithValue("@Numero", phoneNb.Text)
        cmd.Parameters.AddWithValue("@Prenom", Prenom.Text)
        cmd.Parameters.AddWithValue("@Nom", Nom.Text)
        cmd.Parameters.AddWithValue("@Etat", Etat.Text)
        cmd.Parameters.AddWithValue("@Observation", Observation.Text)
        cmd.Parameters.AddWithValue("@Service1", service1.Text)
        cmd.Parameters.AddWithValue("@Service2", service2.Text)
        cmd.Parameters.AddWithValue("@Service3", service3.Text)
        cmd.Parameters.AddWithValue("@DemandeS", DemandeS.Text)

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
        Prenom.Text = ""
        Nom.Text = ""
        Etat.Text = ""
        Observation.Text = ""
        service1.Text = ""
        service2.Text = ""
        service3.Text = ""
        DemandeS.Text = ""

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles DS.Click

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Leads.Click

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Right.Click
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

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;convert zero datetime=True")
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("select * from numero_de_client", conn)
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;convert zero datetime=True")
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("select * from general_table where DemandeS != ' '", conn)
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;convert zero datetime=True")
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("select * from general_table where etat = 'NRP'", conn)
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim conn As New MySqlConnection("server=localhost;user=root;database=table1;port=3306;convert zero datetime=True")
        Dim table As New DataTable()
        Dim adapter As New MySqlDataAdapter("select * from general_table", conn)
        adapter.Fill(table)
        DataGridView1.DataSource = table
    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Data.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub
End Class
