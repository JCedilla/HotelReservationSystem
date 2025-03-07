Imports System.Data.SqlClient
Imports Microsoft.SqlServer

Public Class MainForm
    Dim connString As String = "Server=LAPTOP-BJPABT2F\SQLEXPRESS;Initial Catalog=HRS_DB; Integrated Security=True;"

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("Role: " & GlobalVariables.LoggedInRole) ' Debug
        AdminOnly.Visible = False ' Reset visibility first


        If GlobalVariables.LoggedInRole.Trim() = "Admin" Then
            MsgBox("Welcome Admin!") ' Another Debug
            AdminOnly.Visible = True
        Else
            AdminOnly.Visible = False
        End If




        'TODO: This line of code loads data into the 'HRS_DBDataSet2.UserInformation' table. You can move, or remove it, as needed.
        Me.UserInformationTableAdapter.Fill(Me.HRS_DBDataSet2.UserInformation)
        Label35.Text = "Welcome to Cozy Hotels! Please review our reservation guidelines:

Check-In/Check-Out:
Check-in: 2:00 PM
Check-out: 12:00 PM

Reservation Guarantee:
All bookings require confirmation with valid guest details.
Walk-in guests are subject to room availability.

Cancellation & Refunds:
Free cancellation up to 24 hours before check-in.
Late cancellations or no-shows will incur one night’s charge.

Payment Methods:
Cash

No smoking inside rooms.
Pets are not allowed unless specified in the booking.

Thank you for choosing Cozy Hotels — your home away from home!"


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
        BtnRoomType.Visible = False
        RoomTypePanel.Visible = False
        GrandInfo2.Visible = False
        GrandPic2.Visible = False
        ExquisiteInfo.Visible = False
        ExquisitePic2.Visible = False
        PremiumPic2.Visible = False
        PremiumInfo.Visible = False
        DoubleInfo.Visible = False
        DoublePic2.Visible = False
        SingleInfo.Visible = False
        SinglePic2.Visible = False
        Button9.Visible = False

        TxtContact.MaxLength = 11
    End Sub

    Private Sub BtnHotelPictures_Click(sender As Object, e As EventArgs) Handles BtnHotelPictures.Click
        ViewHotelRoomsPanel.Visible = True
        MainPanel.Visible = False
    End Sub

    Private Sub BtnBook_Click(sender As Object, e As EventArgs)
        BookPanel.Visible = True
        MainPanel.Visible = False
    End Sub

    Private Sub BtnViewBook_Click(sender As Object, e As EventArgs) Handles BtnViewBook.Click
        ViewBookingPanel.Visible = True
        MainPanel.Visible = False
    End Sub

    Private Sub BtnPolicy_Click(sender As Object, e As EventArgs) Handles BtnPolicy.Click
        MainPanel.Visible = False
        PolicyPanel.Visible = True
    End Sub

    Private Sub BtnLogOut_Click(sender As Object, e As EventArgs) Handles BtnLogOut.Click
        Dim form1 As New LogInForm()
        form1.Show()
        Me.Close()

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
        ManageBookingsPanel.Visible = True
        MainPanel.Visible = False
    End Sub

    Private Sub BtnReturn_Click(sender As Object, e As EventArgs) Handles Button4.Click, Button3.Click, Button2.Click, Button1.Click, Button10.Click, Button11.Click
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

    Private Sub Label35_Click(sender As Object, e As EventArgs) Handles Label35.Click

    End Sub

    Private Sub BookBtn_Click(sender As Object, e As EventArgs) Handles Button8.Click, Button7.Click, Button6.Click, Button5.Click, BtnBook.Click, BookBtn.Click
        MainPanel.Visible = False
        ViewUsersPanel.Visible = False
        ManageBookingsPanel.Visible = False
        ViewBookingPanel.Visible = False
        ViewHotelRoomsPanel.Visible = False
        PolicyPanel.Visible = False
        BookPanel.Visible = True
    End Sub

    Private Sub InformationList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InformationList.SelectedIndexChanged

    End Sub

    Private Sub TxtFullName_TextChanged(sender As Object, e As EventArgs) Handles TxtFullName.TextChanged

    End Sub

    Private Sub TxtAge_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAge.KeyPress
        ' Allow only numeric input (0-9)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Ignore the input if it's not a digit or control key
        End If
    End Sub

    Private Sub TxtAge_TextChanged(sender As Object, e As EventArgs) Handles TxtAge.TextChanged
        ' Remove any non-numeric characters from the TextBox
        Dim numericText As String = New String(TxtAge.Text.Where(Function(c) Char.IsDigit(c)).ToArray())
        TxtAge.Text = numericText
        TxtAge.SelectionStart = TxtAge.Text.Length ' Move cursor to the end
    End Sub

    Private Sub TxtContact_TextChanged(sender As Object, e As EventArgs) Handles TxtContact.TextChanged

    End Sub

    Private Sub TxtContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtContact.KeyPress
        ' Allow only numeric input (0-9)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Ignore the input if it's not a digit or control key (e.g., Backspace)
        End If
    End Sub

    Private Sub TxtEmail_TextChanged(sender As Object, e As EventArgs) Handles TxtEmail.TextChanged

    End Sub

    Private Sub BtnClearInformation_Click(sender As Object, e As EventArgs) Handles BtnClearInformation.Click
        InformationList.Items.Clear()
        TxtFullName.Text = ""
        TxtAge.Text = ""
        TxtContact.Text = ""
        TxtEmail.Text = ""
        TxtGender.Text = ""
    End Sub

    Private Sub BtnSubmitInformation_Click_1(sender As Object, e As EventArgs) Handles BtnSubmitInformation.Click
        ' Validation checks
        If TxtFullName.Text = "" Or TxtAge.Text = "" Or TxtContact.Text = "" Or TxtEmail.Text = "" Or TxtGender.Text = "" Then
            MsgBox("All fields must be filled out!", vbExclamation, "Missing Information")
            Exit Sub
        End If


        ' Contact number validation (must be exactly 11 digits)
        If TxtContact.Text.Length <> 11 Or Not IsNumeric(TxtContact.Text) Then
            MsgBox("Invalid Contact Number.", vbExclamation, "Invalid Contact Number")
            Exit Sub
        End If

        ' Display information in the ListBox before confirmation
        InformationList.Items.Clear() ' Clear previous items if any
        InformationList.Items.Add("Full Name: " & TxtFullName.Text)
        InformationList.Items.Add("Age: " & TxtAge.Text)
        InformationList.Items.Add("Contact: " & TxtContact.Text)
        InformationList.Items.Add("Email: " & TxtEmail.Text)
        InformationList.Items.Add("Gender: " & TxtGender.Text)


        ' Confirmation MessageBox
        Dim confirm As DialogResult
        confirm = MessageBox.Show("Is the information you submitted accurate?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            ' Disable Submit Button
            BtnClearInformation.Enabled = False
            BtnSubmitInformation.Enabled = False
            BtnRoomType.Visible = True
            MsgBox("Information Confirmed!", vbInformation, "Success")
        Else
            MsgBox("Please review your information.", vbExclamation, "Review")
        End If
    End Sub

    Private Sub BtnRoomType_Click(sender As Object, e As EventArgs) Handles BtnRoomType.Click
        RoomTypePanel.Visible = True
        BtnRoomType.Visible = False
    End Sub

    Private Sub SingleBtn2_CheckedChanged(sender As Object, e As EventArgs) Handles SingleBtn2.CheckedChanged
        If (SingleBtn2.Checked = True) Then

            SingleInfo.Visible = True
            SinglePic2.Visible = True
        Else

            SingleInfo.Visible = False
            SinglePic2.Visible = False
        End If
    End Sub

    Private Sub DoubleButton2_CheckedChanged(sender As Object, e As EventArgs) Handles DoubleButton2.CheckedChanged
        If (DoubleButton2.Checked = True) Then

            DoubleInfo.Visible = True
            DoublePic2.Visible = True
        Else

            DoubleInfo.Visible = False
            DoublePic2.Visible = False
        End If
    End Sub

    Private Sub PremiumBtn2_CheckedChanged(sender As Object, e As EventArgs) Handles PremiumBtn2.CheckedChanged
        If (PremiumBtn2.Checked = True) Then

            PremiumInfo.Visible = True
            PremiumPic2.Visible = True
        Else

            PremiumInfo.Visible = False
            PremiumPic2.Visible = False
        End If
    End Sub

    Private Sub ExquisitBtn2_CheckedChanged(sender As Object, e As EventArgs) Handles ExquisitBtn2.CheckedChanged
        If (ExquisitBtn2.Checked = True) Then

            ExquisiteInfo.Visible = True
            ExquisitePic2.Visible = True
        Else

            ExquisiteInfo.Visible = False
            ExquisitePic2.Visible = False
        End If
    End Sub

    Private Sub GrandBtn2_CheckedChanged(sender As Object, e As EventArgs) Handles GrandBtn2.CheckedChanged
        If (GrandBtn2.Checked = True) Then

            GrandInfo2.Visible = True
            GrandPic2.Visible = True
        Else

            GrandInfo2.Visible = False
            GrandPic2.Visible = False
        End If
    End Sub

    Private Sub DtpCheckIn_ValueChanged(sender As Object, e As EventArgs) Handles DtpCheckIn.ValueChanged

    End Sub

    Private Sub DtpCheckOut_ValueChanged(sender As Object, e As EventArgs) Handles DtpCheckOut.ValueChanged

    End Sub

    Private Sub Label73_Click(sender As Object, e As EventArgs) Handles Label73.Click

    End Sub

    Private Sub TxtCost_TextChanged(sender As Object, e As EventArgs) Handles TxtCost.TextChanged

    End Sub

    Private Sub BtnCost_Click(sender As Object, e As EventArgs) Handles BtnCost.Click
        InformationList2.Items.Clear()
        If DtpCheckIn.Value >= DtpCheckOut.Value Then
            MsgBox("Check-Out date must be later than Check-In date.", vbExclamation, "Invalid Dates")
            Exit Sub
        End If

        Dim nights As Integer = (DtpCheckOut.Value - DtpCheckIn.Value).Days + 1
        Dim costPerNight As Integer = 0

        ' Determine the room type price
        If SingleBtn2.Checked Then
            costPerNight = 3000
        ElseIf DoubleButton2.Checked Then
            costPerNight = 6000
        ElseIf PremiumBtn2.Checked Then
            costPerNight = 8000
        ElseIf ExquisitBtn2.Checked Then
            costPerNight = 12000
        ElseIf GrandBtn2.Checked Then
            costPerNight = 15000
        Else
            MsgBox("Please select a room type.", vbExclamation, "Error")
            Exit Sub
        End If

        ' Calculate the total cost
        Dim totalCost As Integer = nights * costPerNight

        ' Display the result in ListBox
        InformationList2.Items.Add("Number of Nights: " & nights)
        InformationList2.Items.Add("Room Price Per Night: ₱" & costPerNight)
        InformationList2.Items.Add("Total Cost: ₱" & totalCost)
        MsgBox("Cost Calculation Completed!", vbInformation, "Success")
        TxtCost.Text = totalCost
        ' Disable the button to avoid duplicate calculations

    End Sub

    Private Sub BtnReserveNow_Click(sender As Object, e As EventArgs) Handles BtnReserveNow.Click


        Dim roomType As String = ""

        If TxtCost.Text = "" Or TxtCost.Text = "0" Then
            MsgBox("Cost Must Not Be Zero!", vbExclamation, "Failed")
        End If

        ' Check which radio button is selected and assign the room type
        If SingleBtn2.Checked Then
            roomType = "Single"
        ElseIf DoubleButton2.Checked Then
            roomType = "Double"
        ElseIf PremiumBtn2.Checked Then
            roomType = "Premium"
        ElseIf ExquisitBtn2.Checked Then
            roomType = "Exquisite"
        ElseIf GrandBtn2.Checked Then
            roomType = "Grand"
        Else
            MsgBox("Please select a room type.", vbExclamation, "Error")
            Exit Sub
        End If

        Try
            Using con As New SqlConnection(connString)
                con.Open()
                Dim query As String = "INSERT INTO UserInformation (Fullname, Age, Contact, Email, Gender, RoomType, CheckInDate, CheckOutDate, TotalCost) VALUES (@fullname, @age, @contact, @email, @gender, @roomType, @checkInDate, @checkOutDate, @totalCost)"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@fullname", TxtFullName.Text)
                    cmd.Parameters.AddWithValue("@age", TxtAge.Text)
                    cmd.Parameters.AddWithValue("@contact", TxtContact.Text)
                    cmd.Parameters.AddWithValue("@email", TxtEmail.Text)
                    cmd.Parameters.AddWithValue("@gender", TxtGender.Text)
                    cmd.Parameters.AddWithValue("@roomType", roomType)
                    cmd.Parameters.AddWithValue("@checkInDate", DtpCheckIn.Value)
                    cmd.Parameters.AddWithValue("@checkOutDate", DtpCheckOut.Value)
                    cmd.Parameters.AddWithValue("@totalCost", TxtCost.Text)

                    cmd.ExecuteNonQuery()
                    MsgBox("Reservation Successful!", vbInformation, "Success")
                    Button9.Visible = True
                    BtnReserveNow.Enabled = False
                    BtnCost.Enabled = False
                End Using
            End Using
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, vbExclamation, "Error")
        End Try

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs)
        RoomTypePanel.Visible = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ViewBookingPanel.Visible = True
        BookPanel.Visible = False
        ViewUsersPanel.Visible = False
        ManageBookingsPanel.Visible = False
        ViewBookingPanel.Visible = False
        ViewHotelRoomsPanel.Visible = False
        PolicyPanel.Visible = False
        SideBar.Visible = False
        MainPanel.Visible = False
    End Sub

    Private Sub ReceiptBtn_Click(sender As Object, e As EventArgs) Handles ReceiptBtn.Click
        If TxtFullName.Text = "" Or TxtContact.Text = "" Or TxtEmail.Text = "" Or TxtCost.Text = "" Then
            MsgBox("Reservation is incomplete. Please make sure all information is submitted.", vbExclamation, "Incomplete Reservation")
            Exit Sub
        End If

        ' Generate the receipt message
        Dim receiptMessage As String = "=== Cozy Hotels Reservation Receipt ===" & vbCrLf & vbCrLf &
                                        "Guest Name: " & TxtFullName.Text & vbCrLf &
                                        "Contact Number: " & TxtContact.Text & vbCrLf &
                                        "Email: " & TxtEmail.Text & vbCrLf &
                                        "Total Cost: ₱" & TxtCost.Text & vbCrLf & vbCrLf &
                                        "Please present this receipt to the reception to proceed with payment." & vbCrLf &
                                        "If the guest does not show up, the reservation will be automatically cancelled."

        MsgBox(receiptMessage, vbInformation, "Reservation Receipt")
    End Sub

    Private Sub DeleteUserName_Click(sender As Object, e As EventArgs) Handles DeleteUserName.Click
        Dim fullname As String = TxtDeleteName.Text

        If fullname = "" Then
            MsgBox("Please enter the full name to delete.", vbExclamation, "Input Required")
            Exit Sub
        End If

        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to delete '" & fullname & "'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection(connString)
                    conn.Open()
                    Dim query As String = "DELETE FROM UserInformation WHERE Fullname = @fullname"
                    Using cmd As New SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@fullname", fullname)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MsgBox("User deleted successfully!", vbInformation, "Success")
                            LoadUsers() ' Refresh DataGridView
                        Else
                            MsgBox("User not found.", vbExclamation, "Error")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MsgBox("An error occurred: " & ex.Message, vbCritical, "Error")
            End Try
        End If
    End Sub
End Class