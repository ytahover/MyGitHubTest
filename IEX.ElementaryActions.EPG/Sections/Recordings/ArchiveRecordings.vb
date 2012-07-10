Public Class ArchiveRecordings
    Dim res As IEXGateway.IEXResult
    Protected _iex As IEXGateway._IEX
    Dim Actual As Short
    Protected _UI As EPG.UI

    Sub New(ByVal iex As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = iex
        _UI = pUI
    End Sub


#Region "Get Functions"

    Overridable Function NumberOfEvents(ByRef EventsNumber As Integer) As Boolean
        Return _UI.PlannerBase.NumberOfEvents(EventsNumber)
    End Function

    Overridable Function GetSelectedEventName(ByRef EventName As String) As Boolean
        Return _UI.PlannerBase.GetSelectedEventName(EventName)
    End Function

    Overridable Function GetSelectedEventDuration(ByRef EventDuration As Integer) As Boolean
        Return _UI.PlannerBase.GetSelectedEventDuration(EventDuration)
    End Function

    Overridable Function GetSelectedEventTime(ByRef EventTime As String) As Boolean
        Return _UI.PlannerBase.GetSelectedEventTime(EventTime)
    End Function

    Overridable Function GetSelectedEventStatus(ByRef EventStatus As String) As Boolean
        Return _UI.PlannerBase.GetSelectedEventStatus(EventStatus)
    End Function

    Overridable Function GetSelectedEventNumber(ByRef EventNumber As Integer) As Boolean
        Return _UI.PlannerBase.GetSelectedEventNumber(EventNumber)
    End Function

    Overridable Function GetEventState(ByVal State As String) As Boolean
        Return _UI.PlannerBase.GetEventState(State)
    End Function

    Overridable Function GetAdultEventName(ByRef EventName As String) As Boolean
        Return _UI.PlannerBase.GetAdultEventName(EventName)
    End Function

#End Region

#Region "Set Functions"

    Overridable Function SelectEvent(Optional ByVal EventName As String = "") As Boolean
        Return _UI.PlannerBase.SelectEvent(EventName)
    End Function

    Overridable Function PlayEvent(Optional ByVal FromTheBeginning As Boolean = True, Optional ByVal EnterPIN As Boolean = False) As Boolean
        Return _UI.PlannerBase.PlayEvent(FromTheBeginning, EnterPIN)
    End Function

    Overridable Function PlaybackFromPoint(ByVal StartMinute As Integer) As Boolean
        Return _UI.PlannerBase.playbackFromPoint(StartMinute)
    End Function

    Overridable Function StopPlayEvent() As Boolean
        Return _UI.PlannerBase.StopPlayEvent()
    End Function

    Overridable Function StopRecordingEvent() As Boolean
        Return _UI.PlannerBase.StopRecordingEvent()
    End Function

    Overridable Function DeleteEvent(Optional ByVal InReviewBuffer As Boolean = False) As Boolean
        Return _UI.PlannerBase.DeleteEvent(InReviewBuffer)
    End Function

    Overridable Function LockEvent() As Boolean
        Return _UI.PlannerBase.LockEvent()
    End Function

    Overridable Function UnLockEvent() As Boolean
        Return _UI.PlannerBase.UnLockEvent()
    End Function

    Overridable Function DeleteAll() As Boolean
        Return _UI.PlannerBase.DeleteAll()
    End Function

    Overridable Function CancelEvent(Optional ByVal ShouldSucceed As Boolean = True) As Boolean
        Return _UI.PlannerBase.CancelEvent(ShouldSucceed)
    End Function

    Overridable Function CancelAllEvents() As Boolean
        Return _UI.PlannerBase.CancelAllEvents()
    End Function

    Overridable Function SetFiltering(Optional ByVal FilterType As String = "", Optional ByVal Filter As String = "") As Boolean
        Return _UI.PlannerBase.SetFiltering(FilterType, Filter)
    End Function

    Overridable Function ResolveAdultEventName() As Boolean
        Return _UI.PlannerBase.ResolveAdultEventName()
    End Function

#End Region

#Region "Verify Functions"

    Overridable Function IsEventReminder() As Boolean
        Return _UI.PlannerBase.IsEventReminder()
    End Function

    Overridable Function IsEventKeep() As Boolean
        Return _UI.PlannerBase.IsEventKeep()
    End Function

    Overridable Function IsEventSeries() As Boolean
        Return _UI.PlannerBase.isEventSeries()
    End Function

    Overridable Function isEventCollapse() As Boolean
        Return _UI.PlannerBase.isEventCollapse()
    End Function

    Overridable Function isEventSelected() As Boolean
        Return _UI.PlannerBase.isEventSelected()
    End Function

    Overridable Function VerifyEvent(Optional ByVal EventName As String = "") As Boolean
        Return _UI.PlannerBase.VerifyEvent(EventName)
    End Function

    Overridable Function isEmpty() As Boolean
        Return _UI.PlannerBase.isEmpty()
    End Function

    Overridable Function isEventRecording() As Boolean
        Return _UI.PlannerBase.isEventRecording()
    End Function

    Overridable Function VerifyEventname(ByVal EventName As String) As Boolean
        Return _UI.PlannerBase.VerifyEventname(EventName)
    End Function

    Overridable Function VerifyEventStatus(ByVal EventStatus As String) As Boolean
        Return _UI.PlannerBase.VerifyEventStatus(EventStatus)
    End Function

    Overridable Function isPlanner() As Boolean
        Return _UI.PlannerBase.isPlanner()
    End Function

    Overridable Function isArchive() As Boolean
        Return _UI.PlannerBase.isArchive()
    End Function

    Overridable Function VerifyPlaybackEnded(ByVal EventDurationInMin As Integer) As Boolean
        Return _UI.PlannerBase.VerifyPlaybackEnded(EventDurationInMin)
    End Function

#End Region

#Region "Navigation functions"

    Overridable Function FindEvent(ByVal EventName As String) As Boolean
        Return _UI.PlannerBase.FindEvent(EventName)
    End Function

    Overridable Function Navigate() As Boolean
        Return _UI.PlannerBase.Navigate()
    End Function

    Overridable Function NextEvent(Optional ByVal Times As Integer = 1) As Boolean
        Return _UI.PlannerBase.NextEvent(Times)
    End Function

    Overridable Function PreviousEvent(Optional ByVal Times As Integer = 1) As Boolean
        Return _UI.PlannerBase.PreviousEvent(Times)
    End Function

    Overridable Function NextUpEvent(Optional ByVal Times As Integer = 1) As Boolean
        Return _UI.PlannerBase.NextUpEvent(Times)
    End Function

    Overridable Function PrevEvent(Optional ByVal Times As Integer = 1) As Boolean
        Return _UI.PlannerBase.PrevEvent(Times)
    End Function

#End Region
End Class
