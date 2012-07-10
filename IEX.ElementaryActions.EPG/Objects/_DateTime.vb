Public Class _DateTime
    Dim _iex As IEXGateway.IEX
    Dim res As IEXGateway.IEXResult
    Dim Sreturnvalue As String

    Sub New(ByVal IEX As IEXGateway.IEX)
        _iex = IEX
    End Sub

    Overridable Function IsDateTime(ByVal StringTime As String, ByRef RDateTime As String) As Boolean
        Try
            Dim Counter As Integer = 0

            'deleting non relevant additions in the end of the time string
            If StringTime.IndexOf(vbLf) > 0 Then
                StringTime = StringTime.Remove(0, StringTime.IndexOf(vbLf) - 1)
            End If
            StringTime = StringTime.Trim
            StringTime = StringTime.Replace(".", "").Replace(" ", "")
            Do While StringTime.Length > 5
                StringTime = Mid(StringTime, 1, StringTime.Length - 1)
            Loop
            If StringTime.IndexOf(":") < 0 Then
                StringTime = StringTime.Insert(2, ":")
            End If

            _iex.LogComment("The time is: " & StringTime, False, False, False, CByte(8), "GREEN")
            If StringTime.Length < 4 Then
                Return False
            End If
            Try
                RDateTime = StringTime

                Return True 'found the time
            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Overridable Function Subtract(ByVal pNewer As DateTime, ByVal Laster As DateTime) As Integer

        Dim iSubtract As Integer

        Dim Newer = New DateTime(Today.Year, Today.Month, Today.Day, pNewer.TimeOfDay.Hours, pNewer.TimeOfDay.Minutes, 0)

        Laster = New DateTime(Today.Year, Today.Month, Today.Day, Laster.TimeOfDay.Hours, Laster.TimeOfDay.Minutes, 0)

        iSubtract = Newer.Subtract(Laster).TotalMinutes()

        'if midnight based on 4 hurs buffer asuming there are no events from previous of 8:00pm that are ending after 4:00am

        If (pNewer.TimeOfDay.TotalMinutes() >= New Date(2000, 1, 1, 0, 0, 0).TimeOfDay.TotalMinutes) And (pNewer.TimeOfDay.TotalMinutes < New Date(2000, 1, 1, 4, 0, 0).TimeOfDay.TotalMinutes) Then

            If (Laster.TimeOfDay.TotalMinutes <= New Date(2000, 1, 1, 23, 59, 59).TimeOfDay.TotalMinutes) And (Laster.TimeOfDay.TotalMinutes > New Date(2000, 1, 1, 20, 0, 0).TimeOfDay.TotalMinutes) Then

                iSubtract = 24 * 60 + iSubtract

            End If

        End If

        If (Laster.TimeOfDay.TotalMinutes >= New Date(2000, 1, 1, 0, 0, 0).TimeOfDay.TotalMinutes) And (Laster.TimeOfDay.TotalMinutes < New Date(2000, 1, 1, 4, 0, 0).TimeOfDay.TotalMinutes) Then

            If (pNewer.TimeOfDay.TotalMinutes <= New Date(2000, 1, 1, 23, 59, 59).TimeOfDay.TotalMinutes) And (pNewer.TimeOfDay.TotalMinutes > New Date(2000, 1, 1, 20, 0, 0).TimeOfDay.TotalMinutes) Then

                iSubtract = iSubtract - (24 * 60)

            End If

        End If


        Return iSubtract

    End Function

    Overridable Function SubtractInSec(ByVal pNewer As DateTime, ByVal Laster As DateTime) As Integer

        Dim iSubtract As Integer
        Dim Newer = New DateTime(Today.Year, Today.Month, Today.Day, pNewer.TimeOfDay.Hours, pNewer.TimeOfDay.Minutes, pNewer.TimeOfDay.Seconds)

        Laster = New DateTime(Today.Year, Today.Month, Today.Day, Laster.TimeOfDay.Hours, Laster.TimeOfDay.Minutes, Laster.TimeOfDay.Seconds)
        iSubtract = Newer.Subtract(Laster).TotalSeconds()

        'if midnight based on 4 hurs buffer asuming there are no events from previous of 8:00pm that are ending after 4:00am

        If (pNewer.TimeOfDay.TotalSeconds() >= New Date(2000, 1, 1, 0, 0, 0).TimeOfDay.TotalSeconds) And (pNewer.TimeOfDay.TotalSeconds < New Date(2000, 1, 1, 4, 0, 0).TimeOfDay.TotalSeconds) Then
            If (Laster.TimeOfDay.TotalSeconds <= New Date(2000, 1, 1, 23, 59, 59).TimeOfDay.TotalSeconds) And (Laster.TimeOfDay.TotalSeconds > New Date(2000, 1, 1, 20, 0, 0).TimeOfDay.TotalSeconds) Then
                iSubtract = 24 * 60 * 60 + iSubtract
            End If
        End If

        If (Laster.TimeOfDay.TotalSeconds >= New Date(2000, 1, 1, 0, 0, 0).TimeOfDay.TotalSeconds) And (Laster.TimeOfDay.TotalSeconds < New Date(2000, 1, 1, 4, 0, 0).TimeOfDay.TotalSeconds) Then
            If (pNewer.TimeOfDay.TotalSeconds <= New Date(2000, 1, 1, 23, 59, 59).TimeOfDay.TotalSeconds) And (pNewer.TimeOfDay.TotalSeconds > New Date(2000, 1, 1, 20, 0, 0).TimeOfDay.TotalSeconds) Then
                iSubtract = iSubtract - (24 * 60 * 60)
            End If
        End If


        Return iSubtract

    End Function

    Overridable Function GetTimeFrom(ByVal Template As String, ByVal column As String, ByRef TheTime As String) As Boolean
        Dim StringTime As String = ""
        Dim Counter As Integer = 0
        Do
            Counter = Counter + 1
            res = _iex.IAL.GetItem(Template, "", column, StringTime)
            'deleting non relevant additions in the end of the time string
            If Me.IsDateTime(StringTime, TheTime) Then Return True
            If Counter = 4 Then
                Return False
            End If
        Loop
    End Function

    Overridable Function FixTime(ByRef timeValue As String) As Boolean

        If String.IsNullOrEmpty(timeValue) Then Return False
        timeValue = timeValue.Trim().Replace(" ", "").Replace(".", ":").Replace("9m", "pm")
        If timeValue.Length < 5 Then Return False
        If Not timeValue.Contains(":") Then
            timeValue = Strings.Left(timeValue, timeValue.Length - 4) & ":" & Strings.Right(timeValue, 4)
        End If
        Return True

    End Function

    Public Overridable Function Subtract(ByVal newTime As String, ByVal oldTime As String) As Integer

        Dim intNew As Integer
        Dim intOld As Integer
        Dim newHour As Integer
        Dim oldHour As Integer
        Dim newMin As Integer
        Dim oldMin As Integer
        Dim intHour As Integer
        Dim intMin As Integer

        'cleaning sgins in time string
        newTime = CleanTimeString(newTime)
        oldTime = CleanTimeString(oldTime)

        'changing all time templates to 24 hours time template
        newTime = SetTimeTemplate(newTime)
        oldTime = SetTimeTemplate(oldTime)

        'Convert to int
        intNew = Int(newTime)
        intOld = Int(oldTime)

        'seperate time and hour from integeres values
        newHour = Math.Floor(intNew / 100)
        newMin = intNew - (newHour * 100)
        oldHour = Math.Floor(intOld / 100)
        oldMin = intOld - (oldHour * 100)

        'in case we are between 20:00 and 5:00  also new value is smaller time is hanelled in positive values
        If intNew < 500 And intOld > 2000 Then
            intHour = 24 - oldHour + newHour
            If oldMin > newMin Then
                intHour = intHour - 1
                intMin = 60 - (oldMin - newMin)
            Else
                intMin = newMin - oldMin
            End If
            'otherwise will get negetive value for new time that is smaller then compared time
        Else
            intHour = newHour - oldHour
            If oldMin > newMin Then
                intHour = intHour - 1
                intMin = 60 - (oldMin - newMin)
            Else
                intMin = newMin - oldMin
            End If
        End If

        Return (intHour * 60) + intMin
    End Function

    Public Function CleanTimeString(ByVal s As String) As String
        s = s.Replace(" ", "").Replace(".", "").Replace(":", "").Replace(";", "").Replace("-", "").Replace("_", "").Replace("|", "")
        Return s
    End Function

    Public Function SetTimeTemplate(ByVal s As String) As String
        Dim isPM As Boolean = False
        Dim isAMPMTemplate As Boolean = False
        Dim length = s.Length
        Dim returnValue
        Dim hours As String = ""
        Dim minutes As String = ""

        'check if time is am\pm
        Try
            If s.ToLower.Substring(s.Length - 3).Contains("pm") Or s.ToLower.Substring(s.Length - 2).Contains("p") Then
                isPM = True
                isAMPMTemplate = True
            Else
                If s.ToLower.Substring(s.Length - 3).Contains("am") Or s.ToLower.Substring(s.Length - 2).Contains("a") Then
                    isAMPMTemplate = True
                End If
            End If

            'remove am\pm from string
            returnValue = s.ToLower.Replace("a", "").Replace("m", "").Replace("p", "")

            If returnValue.Length = 3 Then
                returnValue = "0" & s
            End If

            hours = returnValue.Substring(0, 2)
            minutes = returnValue.Substring(2, 2)

            'check for 12am to become 00:00
            If isAMPMTemplate = True And isPM = False And Int(hours) = 12 Then
                hours = "00"
            End If

            If isPM = True And (Not hours = "12") Then
                hours = Int(hours) + 12
            End If

            If Int(hours) > 23 Or Int(minutes) > 59 Then Throw New Exception("String is not a known recognized time: " & s)
        Catch ex As Exception

        End Try

        Return hours & minutes
    End Function
End Class


