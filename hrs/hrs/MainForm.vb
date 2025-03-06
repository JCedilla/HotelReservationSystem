Public Class MainForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        SideBar.Visible = False
    End Sub

    Private Sub BtnBook_Click(sender As Object, e As EventArgs) Handles BtnBook.Click
        BookPanel.Visible = True
        SideBar.Visible = False
    End Sub

    Private Sub BtnViewBook_Click(sender As Object, e As EventArgs) Handles BtnViewBook.Click

    End Sub

    Private Sub BtnPolicy_Click(sender As Object, e As EventArgs) Handles BtnPolicy.Click

    End Sub

    Private Sub BtnLogOut_Click(sender As Object, e As EventArgs) Handles BtnLogOut.Click

    End Sub

    Private Sub BtnViewUsers_Click(sender As Object, e As EventArgs) Handles BtnViewUsers.Click

    End Sub

    Private Sub BtnManageBookings_Click(sender As Object, e As EventArgs) Handles BtnManageBookings.Click

    End Sub

    Private Sub BtnReturn_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BookPanel.Visible = False
        ViewUsersPanel.Visible = False
        ManageBookingsPanel.Visible = False
        ViewBookingPanel.Visible = False
        ViewHotelRoomsPanel.Visible = False
        PolicyPanel.Visible = False
        SideBar.Visible = True
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