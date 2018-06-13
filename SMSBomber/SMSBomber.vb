Imports System.IO
Imports System.Net
Imports System.Net.Mail '' To send emails thru program
Public Class SMSBomber
    Dim value1 As String ''Raw phone number ie (xxx) xx-xx-xx-x or (xxx) xxx-xxx
    Dim value2 As String '' Cleaned up phone number ie xxxxxxxxxx
    Dim carrier As String '' phone number + carrier ie xxxxxxxxxx@mymetropcs.com
    Dim EmailMessage As New MailMessage




    Private Sub Start_Click(sender As Object, e As EventArgs) Handles Start.Click, Start.Click
        ''Cleans Up phone number to be able to message it
        value1 = PhoneNumber.Text
        value2 = value1.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")
        '' Checks which carrier is selected to use their preset
        If metropcs.Checked = True Then
            carrier = value2 + "@mymetropcs.com"
        ElseIf att.Checked = True Then
            carrier = value2 + "@txt.att.net"
        ElseIf alltel.Checked = True Then
            carrier = value2 + "@message.alltel.com"
        ElseIf sprint.Checked = True Then
            carrier = value2 + "@messaging.sprintpcs.com"
        ElseIf tmobile.Checked + True Then
            carrier = value2 + "@tmomail.net"
        ElseIf verizon.Checked = True Then
            carrier = value2 + "@vtext.com"
        ElseIf bluegrass.Checked = True Then
            carrier = value1 + "sms.bluecell.com"
        ElseIf boost.Checked = True Then
            carrier = value1 + "myboostmobile.com"
        ElseIf cellcom.Checked = True Then
            carrier = value1 + "cellcom.quiktxt.com"
        ElseIf cricket.Checked = True Then
            carrier = value1 + "mms.cricketwireless.net"
        ElseIf rogers.Checked = True Then
            carrier = value1 + "pcs.rogers.com"
        ElseIf virgin.Checked = True Then
            carrier = value1 + "vmbol.com"
        End If
        MsgBox("Sending text to: " + carrier)

        Try
            If multipleText.Checked = False Then '' This makes sure the user only wants to send one text at a click, not multiples
                EmailMessage.From = New MailAddress(emailEmail.Text)    ''Uses email address (Recommended to use burner gmail accs)
                EmailMessage.To.Add(carrier)    '' Shows who to text to ie xxxxxxxxxx@mymetropcs.com
                EmailMessage.Subject = Subject.Text '' Subject line 
                EmailMessage.Body = MessageToBomb.Text ''Message to text
                EmailMessage.Priority = MailPriority.High   ''Urgent to send out
                Dim SimpleSMTP As New SmtpClient("smtp.gmail.com") ''which smtp client to use
                SimpleSMTP.Port = 587 ''Port
                SimpleSMTP.EnableSsl = True ''ssl
                SimpleSMTP.Credentials = New System.Net.NetworkCredential(emailEmail.Text, emailPass.Text) ''This allows the program to connect to which email you are going to use, and to log in. ie [ email: burneracc@gmail.com | pass: password123 ] and logs in 
                SimpleSMTP.Send(EmailMessage) ''sends those delicious pie bombs
            ElseIf multipleText.Checked = True Then '' if you want multiple texts, then this should be clicked
                muliplebombs() ''Pull the lever Kronk
            End If '' If you end this if, what if this if never was ended, imagine the horrors.                 The horrors...                  99% sure I spelt horror wrong....
        Catch ex As Exception '' Catching exceptions like you boutta catch these hands
            MsgBox("You done fucked up now A-Aron") '' Words of encouragment        || >>>> If this message does pop up, then you or the user more than likely imputed a non-applicable number. IE a letter or unknown character in the box
        End Try


    End Sub

    Private Sub muliplebombs() ''This lever Kronk
        Dim i As Integer = 0 '' Still have no clue what this exactly does after using it multiple times... pls explain... halp
        Do Until i = BombTime.Text '' uses integer and equals bombtime, ie how many texts you want to send out
            EmailMessage.From = New MailAddress(emailEmail.Text) ''See diagram above
            EmailMessage.To.Add(carrier) '' why you still lookin
            EmailMessage.Subject = Subject.Text '' look above you beast
            EmailMessage.Body = MessageToBomb.Text '' nothing to see here
            EmailMessage.Priority = MailPriority.High ''so much redbull injested at this moment
            Dim SimpleSMTP As New SmtpClient("smtp.gmail.com") ''contemplating life values
            SimpleSMTP.Port = 587 ''skimming through weed bag to see if i can roll
            SimpleSMTP.EnableSsl = True ''no papers left
            SimpleSMTP.Credentials = New System.Net.NetworkCredential(emailEmail.Text, emailPass.Text) '' pls donate joint papers
            SimpleSMTP.Send(EmailMessage) ''blunts also accepted
            i += 1 ''a vowel equals a number +1 each time it loops, whoda thunk

        Loop '' You make a loop de loop and pull And your shoes are looking cool  

    End Sub ''end all substitutes, or does it mean its ending multiple bomb sub, no body knows




    ''class dismissed
End Class