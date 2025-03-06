Imports System.Data.SqlClient


Public Class LogInForm
    Dim connString As String = "Server=LAPTOP-BJPABT2F\SQLEXPRESS;Initial Catalog=HRS_DB; Integrated Security=True;"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtUsername_TextChanged(sender As Object, e As EventArgs) Handles TxtUsername.TextChanged

    End Sub

    Private Sub TxtPassword_TextChanged(sender As Object, e As EventArgs) Handles TxtPassword.TextChanged

    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Using conn As New SqlConnection(connString)
            Try
                ' Check if the username or password fields are empty
                If TxtUsername.Text = "" Or TxtPassword.Text = "" Then
                    MsgBox("Username and Password cannot be blank!", vbExclamation, "Login Failed")
                    Exit Sub
                End If
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If

                conn.Open() ' Open SQL Connection

                ' SQL query to check if there is a user in the table with the matching username and password
                Dim query As String = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password"
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Username", TxtUsername.Text)
                cmd.Parameters.AddWithValue("@Password", TxtPassword.Text)
                Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If result > 0 Then
                    MsgBox("Login Successful!", vbInformation, "Success")
                    Dim mainForm As New MainForm()
                    mainForm.Show()
                    Me.Close()
                Else
                    MsgBox("Invalid Username or Password!", vbExclamation, "Login Failed")
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click
        Dim username As String = TxtUsername.Text
        Dim password As String = TxtPassword.Text

        Using conn As New SqlConnection(connString)
            Try
                ' Check if username and password texts are empty
                If TxtUsername.Text = "" Or TxtPassword.Text = "" Then
                    MsgBox("Username and Password cannot be blank!", vbExclamation, "Registration Failed")
                    Exit Sub
                End If

                ' Check if password length is less than 8 characters
                If TxtPassword.Text.Length > 8 Then
                    MsgBox("Password cannot exceed 8 characters!", vbExclamation, "Registration Failed")
                    Exit Sub
                End If

                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()
                ' Check if user already exists
                Dim checkQuery As String = "SELECT COUNT(*) FROM Users WHERE Username = @Username"
                Dim checkCmd As New SqlCommand(checkQuery, conn)
                checkCmd.Parameters.AddWithValue("@Username", TxtUsername.Text)
                Dim userExists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If userExists > 0 Then
                    MsgBox("Username already exists! Please choose another one.", vbExclamation, "Registration Failed")
                Else
                    ' Get latest UserID and increment it
                    Dim getIdQuery As String = "SELECT ISNULL(MAX(UserID), 1) + 1 FROM Users"
                    Dim getIdCmd As New SqlCommand(getIdQuery, conn)
                    Dim newUserId As Integer = Convert.ToInt32(getIdCmd.ExecuteScalar())

                    ' Insert new user if not exists
                    Dim query As String = "INSERT INTO Users (UserID, Username, Password, Role) VALUES (@UserID, @Username, @Password, 'Guest')"
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@UserID", newUserId)
                    cmd.Parameters.AddWithValue("@Username", TxtUsername.Text)
                    cmd.Parameters.AddWithValue("@Password", TxtPassword.Text)
                    cmd.ExecuteNonQuery()
                    MsgBox("User Registered as Guest! Please Log In!", vbInformation, "Success")
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub
End Class
