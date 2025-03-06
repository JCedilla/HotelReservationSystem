Imports System.Data.SqlClient

Public Class MainForm
    Dim connString As String = "Server=LAPTOP-BJPABT2F\SQLEXPRESS;Initial Catalog=HRS_DB; Integrated Security=True;"

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HRS_DBDataSet1.Users' table. You can move, or remove it, as needed.
        Me.UsersTableAdapter.Fill(Me.HRS_DBDataSet1.Users)
        ' INVISIBLE ELEMENTS UPON LOAD
        MainPanel.Visible = True
        ViewUsersPanel.Visible = False
        ManageBookingsPanel.Visible = False
        ViewBookingPanel.Visible = False
        ViewHotelRoomsPanel.Visible = False
        PolicyPanel.Visible = False
        BookPanel.Visible = False
        SingleInformation.Visible = False
        SinglePicture.Visible = False
        SingleBtn.Checked = False
        DoubleInformation.Visible = False
        DoublePicture.Visible = False
        PremiumInformation.Visible = False
        PremiumPicture.Visible = False
        ExquisiteInformation.Visible = False
        ExquisitePicture.Visible = False
        GrandInformation.Visible = False
        GrandPicture.Visible = False
    End Sub

    Private Sub BtnHotelPictures_Click(sender As Object, e As EventArgs) Handles BtnHotelPictures.Click
        ViewHotelRoomsPanel.Visible = True
        MainPanel.Visible = False
    End Sub

    Private Sub BtnBook_Click(sender As Object, e As EventArgs) Handles BtnBook.Click
        BookPanel.Visible = True
        MainPanel.Visible = False
    End Sub

    Private Sub BtnViewBook_Click(sender As Object, e As EventArgs) Handles BtnViewBook.Click

    End Sub

    Private Sub BtnPolicy_Click(sender As Object, e As EventArgs) Handles BtnPolicy.Click

    End Sub

    Private Sub BtnLogOut_Click(sender As Object, e As EventArgs) Handles BtnLogOut.Click

    End Sub

    Private Sub BtnViewUsers_Click(sender As Object, e As EventArgs) Handles BtnViewUsers.Click
        ViewUsersPanel.Visible = True
        MainPanel.Visible = False
    End Sub

    ' This method will load the Users table into the DataGridView
    Private Sub LoadUsers()
        Try
            Using conn As New SqlConnection("Data Source=LAPTOP-BJPABT2F\SQLEXPRESS;Initial Catalog=HRS_DB; Integrated Security=True;")
                Dim adapter As New SqlDataAdapter("SELECT * FROM Users", conn) ' Fetch all users
                Dim table As New DataTable()
                adapter.Fill(table) ' Fill DataTable with results
                DataGridView1.DataSource = table ' Set DataGridView source
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnDeleteUser_Click(sender As Object, e As EventArgs) Handles BtnDeleteUser.Click
        If TxtUserIDDelete.Text = "" Then
            MsgBox("Please enter a UserID to delete.", vbExclamation)
            Exit Sub
        End If

        Dim userID As Integer

        If Not Integer.TryParse(TxtUserIDDelete.Text, userID) Then
            MsgBox("Invalid UserID! Please enter a number.", vbExclamation)
            Exit Sub
        End If

        If userID = 1 Then
            MsgBox("Admin user cannot be deleted!", vbExclamation)
            Exit Sub
        End If

        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to delete UserID: " & userID & "?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirm = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection("Data Source=LAPTOP-BJPABT2F\SQLEXPRESS;Initial Catalog=HRS_DB; Integrated Security=True;")
                    conn.Open()
                    Dim query As String = "DELETE FROM Users WHERE UserID = @UserID"
                    Dim cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@UserID", userID)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MsgBox("User deleted successfully!", vbInformation)
                        LoadUsers() ' Refresh the DataGridView
                        TxtUserIDDelete.Clear()
                    Else
                        MsgBox("UserID not found.", vbExclamation)
                    End If
                End Using
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnManageBookings_Click(sender As Object, e As EventArgs) Handles BtnManageBookings.Click

    End Sub

    Private Sub BtnReturn_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click
        BookPanel.Visible = False
        ViewUsersPanel.Visible = False
        ManageBookingsPanel.Visible = False
        ViewBookingPanel.Visible = False
        ViewHotelRoomsPanel.Visible = False
        PolicyPanel.Visible = False
        SideBar.Visible = True
        MainPanel.Visible = True
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub SingleBtn_CheckedChanged(sender As Object, e As EventArgs) Handles SingleBtn.CheckedChanged
        If (SingleBtn.Checked = True) Then
            SingleInformation.Visible = True
            SinglePicture.Visible = True
        Else
            SingleInformation.Visible = False
            SinglePicture.Visible = False
        End If
    End Sub

    Private Sub BtnDouble_CheckedChanged(sender As Object, e As EventArgs) Handles BtnDouble.CheckedChanged
        If (BtnDouble.Checked = True) Then
            DoubleInformation.Visible = True
            DoublePicture.Visible = True
        Else
            DoubleInformation.Visible = False
            DoublePicture.Visible = False
        End If
    End Sub

    Private Sub BtnPremium_CheckedChanged(sender As Object, e As EventArgs) Handles BtnPremium.CheckedChanged
        If (BtnPremium.Checked = True) Then
            PremiumInformation.Visible = True
            PremiumPicture.Visible = True
        Else
            PremiumInformation.Visible = False
            PremiumPicture.Visible = False
        End If
    End Sub

    Private Sub BtnExquisite_CheckedChanged(sender As Object, e As EventArgs) Handles BtnExquisite.CheckedChanged
        If (BtnExquisite.Checked = True) Then
            ExquisiteInformation.Visible = True
            ExquisitePicture.Visible = True
        Else
            ExquisiteInformation.Visible = False
            ExquisitePicture.Visible = False
        End If
    End Sub

    Private Sub BtnGrand_CheckedChanged(sender As Object, e As EventArgs) Handles BtnGrand.CheckedChanged
        If (BtnGrand.Checked = True) Then
            GrandInformation.Visible = True
            GrandPicture.Visible = True
        Else
            GrandInformation.Visible = False
            GrandPicture.Visible = False
        End If
    End Sub


End Class