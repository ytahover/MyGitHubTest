Public MustInherit Class PlannerBase
    Dim res As IEXGateway.IEXResult
    Protected _iex As IEXGateway._IEX
    Dim Actual As Short
    Protected _UI As EPG.UI

    Sub New(ByVal iex As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = iex
        _UI = pUI
    End Sub

#Region "Get Functions"

    Overridable Function NumberOfEvents(ByRef eventsNumber As Integer) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetSelectedEventName(ByRef EventName As String) As Boolean
        res = _iex.IAL.GetItem("Planner", "", "EventName", EventName)
        Return res.CommandSucceeded
    End Function

    Overridable Function GetSelectedEventDuration(ByRef EventDuration As Integer) As Boolean
        Dim SDuration As String = ""
        Try
            res = _iex.IAL.GetItem("Planner", "", "EventName", SDuration)
            If res.CommandSucceeded Then
                EventDuration = CInt(SDuration)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Overridable Function GetSelectedEventTime(ByRef eventTime As String) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetSelectedEventStatus(ByRef EventStatus As String) As Boolean
        res = _iex.IAL.GetItem("Planner", "", "EventName", EventStatus)
        Return res.CommandSucceeded
    End Function

    Overridable Function GetSelectedEventNumber(ByRef eventNumber As Integer) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetEventState(ByVal State As String) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetAdultEventName(ByRef EventName As String) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Set Functions"

    Overridable Function SelectEvent(Optional ByVal EventName As String = "") As Boolean
        If EventName = "" Then
            _iex.SendIRCommand("SELECT")
            Return True
        End If
    End Function

    Overridable Function PlayEvent(Optional ByVal FromTheBeginning As Boolean = True, Optional ByVal EnterPIN As Boolean = False) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function playbackFromPoint(ByVal startMinute As Integer) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function StopPlayEvent() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function StopRecordingEvent() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function DeleteEvent(Optional ByVal InReviewBuffer As Boolean = False) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function LockEvent() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function UnLockEvent() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function DeleteAll() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function CancelEvent(Optional ByVal shouldSucceed As Boolean = True) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function CancelAllEvents() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetFiltering(Optional ByVal FilterType As String = "", Optional ByVal Filter As String = "") As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function ResolveAdultEventName() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Verify Functions"
    Public Delegate Function _degIsEventReminder()

    Public degIsEventReminder As _degIsEventReminder


    Overridable Function IsEventReminder() As Boolean
        degIsEventReminder()
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function IsEventKeep() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function isEventSeries() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function isEventCollapse() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function isEventSelected() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyEvent(Optional ByVal EventName As String = "") As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function isEmpty() As Boolean
        Return _iex.IAL.VerifyItem("Archive", "", "isArchiveEmpty", "TRUE", Actual).CommandSucceeded
    End Function

    Overridable Function isEventRecording() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyEventname(ByVal EventName As String) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyEventStatus(ByVal EventStatus As String) As Boolean
        res = _iex.IAL.VerifyItem("Archive", "", "Status", "<" & EventStatus & ">", Actual)

        Return res.CommandSucceeded
    End Function

    Overridable Function isPlanner() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function isArchive() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyPlaybackEnded(ByVal EventDurationInMin As Integer) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Navigation functions"

    Overridable Function FindEvent(ByVal EventName As String) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function Navigate() As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NextEvent(Optional ByVal times As Integer = 1) As Boolean
        For I As Integer = 1 To times
            _iex.SendIRCommand("SELECT_DOWN")
            _iex.Wait(1)
        Next
        Return True
    End Function

    Overridable Function PreviousEvent(Optional ByVal times As Integer = 1) As Boolean
        For I As Integer = 1 To times
            _iex.SendIRCommand("SELECT_DOWN")
            _iex.Wait(1)
        Next
        Return True
    End Function

    Overridable Function NextUpEvent(Optional ByVal times As Integer = 1) As Boolean
        _iex.LogComment("This UI.PlannerBase function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function


    Overridable Function PrevEvent(Optional ByVal times As Integer = 1) As Boolean
        For I As Integer = 1 To times
            _iex.SendIRCommand("SELECT_UP")
        Next
        Return True
    End Function


#End Region


End Class
