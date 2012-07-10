Public Class Guide
    Dim _iex As IEXGateway.IEX
    Dim res As IEXGateway.IEXResult

    Dim _Utils As Utils
    Protected _UI As EPG.UI
    Dim ReturnValue As String

    Sub New(ByVal IEX As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = IEX
        _UI = pUI
        _Utils = _UI.Utils
    End Sub

    Overridable Function ErrorWaitValue(ByRef seconds As Integer) As Boolean
        seconds = 10
        Return True
    End Function


#Region "Get Functions"
    Overridable Function GetEPGTime(ByRef EPG_Time As DateTime) As Boolean
        Dim StartTime As String = ""
        Dim Counter As Integer = 0
        Do
            Counter = Counter + 1
            res = _iex.IAL.GetItem("GUIDE", "", "EPG Time", StartTime)
            If StartTime.IndexOf(":") < 0 Then
                StartTime = StartTime.Insert(2, ":")
            End If
            'deleting non relevant additions in the end of the time string
            If _UI.Utils._DateTime.IsDateTime(StartTime, EPG_Time) Then Return True
            If Counter = 4 Then
                _Utils.LogCommentFail("Can't convert Event Time to Time")
                Return False
            End If
        Loop
    End Function
    Overridable Function PrevDay() As Boolean
        _iex.SendIRCommand("REW")
        Return True
    End Function


    Overridable Function NextDay() As Boolean
        _iex.SendIRCommand("FF")
        Return True
    End Function

    Overridable Function GetGuideDate(ByRef RDateTime As DateTime) As Boolean

        For I As Integer = 1 To 10
            _iex.IAL.GetItem("GUIDE", "", "Guide_Day", ReturnValue)
            If _UI.Utils._DateTime.IsDateTime(ReturnValue, RDateTime) Then

                Return True
            End If
        Next
        Return False
    End Function

    Overridable Function GetSelectedChannelNumber(ByRef ChannelNumber As String) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetSelectedEventName(ByRef EventName As String) As Boolean
        res = _iex.IAL.GetItem("Guide", "", "EventInfo", EventName)
        If res.CommandSucceeded Then Return True
        Return False
    End Function

    Overridable Function GetSelectedEventTime(ByRef EventTime As String) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetSelectedEventStartTime(ByRef StartTime As String) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetSelectedEventEndTime(ByRef EndTime As String) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetEventTimeLeftToStart(ByRef TimeLeft As String) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetEventStartTime(ByRef StartTime As String) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Set Functions"

    Overridable Function SelectEvent() As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SelectCurrentEvent() As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function RecSelected() As Boolean
        _iex.SendIRCommand("RECORD")
        Return True
    End Function

    Overridable Function PauseBetweenIRs() As Boolean
        _iex.Wait(2)
        Return True
    End Function

    Overridable Function PurchaseEvent() As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function


    Overridable Function RecordEvent() As Boolean
        _iex.SendIRCommand("RECORD")
        _iex.Wait(3)
        Return True
    End Function

    Overridable Function RecordEvent(ByVal IsCurrent As Boolean, ByVal IsConflict As Boolean) As Boolean
        _iex.SendIRCommand("RECORD")
        _iex.Wait(3)
        Return True
    End Function

    Overridable Function SetEventReminder() As Boolean
        _iex.SendIRCommand("SELECT")
        _iex.Wait(3)
        Return True
    End Function

    Overridable Function TypeKeys(ByVal StringtoType As String) As Boolean
        Return _Utils.TypeKeys(StringtoType)
    End Function

    Overridable Function FindEventByName(ByVal EventName As String) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function FindEventByTime(ByVal EventTime As String) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Verify Functions"

    Overridable Function IsGuide() As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function IsSelectedMarkedToRecord() As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function IsSelectedMarkedToRemind() As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function IsDateTime(ByVal StringTime As String, ByRef RDateTime As DateTime) As Boolean
        Return _Utils._DateTime.IsDateTime(StringTime, RDateTime)
    End Function

    Overridable Function VerifyChannelNums(ByVal expectedServiceNums As ArrayList, ByVal isOnly As Boolean) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function CheckEventInfo() As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifySelectedEventChannel(ByVal channelName As String) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function
    ''' <summary>
    ''' Verifying that the selected event on guide is marked to be recorded.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overridable Function VerifySelectedMarkedToRecord() As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function
    ''' <summary>
    ''' Verifying that the selected event on guide is being recording
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Overridable Function VerifySelectedRecording() As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Navigation functions"
    Overridable Function Navigate() As Boolean
        Dim i As Integer = 0
        Do

            i = i + 1
            _iex.SendIRCommand("GUIDE")
            res = _iex.IAL.VerifyCurrentScreenAndDVT("", "Guide", 10)
        Loop Until res.CommandSucceeded Or i > 5
        If res.CommandSucceeded Then
            Return True
        Else 'if not res.CommandSucceeded 
            Return False
        End If
    End Function

    Overridable Function NavigateToChannel(ByVal ChannelNumber As String) As Boolean
        _iex.StartHideFailures("Tuning to channel " & ChannelNumber, False, False, False, CByte(12), "BLUE")
        If TypeKeys(ChannelNumber) Then
            _iex.ForceHideFailure()
            Return True
        End If
        _iex.ForceHideFailure()
        Return False
    End Function

    Overridable Function NextEvent(Optional ByVal repeat As Integer = 1) As Boolean
        For RepeatIR As Integer = 1 To repeat
            _iex.SendIRCommand("Select_Right")
            _iex.Wait(2)
        Next
        Return True
    End Function

    Overridable Function NavigateToRecordEvent(Optional ByVal IsCurrent As Boolean = True) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NextEvent(ByVal CurrentEvent As _Event, ByRef FutureEvent As _Event, Optional ByVal repeat As Integer = 1) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NextEventbyEndTime(ByVal CurrentEvent As EPG._Event, ByRef FutureEvent As EPG._Event, Optional ByVal repeat As Integer = 1) As Boolean
        Dim EndTime As DateTime
        For I As Integer = 1 To 4
            If Not NextEvent(1) Then
                Return False
            End If
            If Not GetSelectedEventEndTime(EndTime) Then
                Return False
            End If
            If EndTime <> CurrentEvent.EventStartTime Then
                Return True
            End If
        Next
        Return False
    End Function

    Overridable Function PreviousEvent(Optional ByVal repeat As Integer = 1) As Boolean
        For RepeatIR As Integer = 1 To repeat
            _iex.SendIRCommand("Select_Left")
        Next
        Return True
    End Function

    Overridable Function MoveChannelUpDown(ByVal IsUp As Boolean) As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SurfChannelUp() As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SurfChannelDown() As Boolean
        _iex.LogComment("This UI.Guide function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function
#End Region

End Class
