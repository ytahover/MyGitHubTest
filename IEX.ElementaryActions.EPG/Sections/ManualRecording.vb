Public Class ManualRecording
    Dim res As IEXGateway.IEXResult
    Dim _iex As IEXGateway._IEX
    Protected _UI As EPG.UI

    Sub New(ByVal IEX As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = IEX
        _UI = pUI
    End Sub


    Overridable Function Navigate() As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateFromPlanner() As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToChannel() As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToStartTime() As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function
    Overridable Function NavigateToEndTime() As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function
    Overridable Function NavigateToDate() As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToFrequency() As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToRecord() As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SaveAndEnd(Optional ByVal IsCurrent As Boolean = False) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifySaveAndEndFinished(ByVal IsFromCurrent As Boolean) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function TypeChannel(ByVal Channel As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetDate(ByVal tDate As String, ByVal DefaultValue As Boolean) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NextChannel(Optional ByVal times As Integer = 1) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NextDate(Optional ByVal times As Integer = 1) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetDay(ByVal Day As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetStartTime(ByVal StartTime As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetEndTime(ByVal EndTime As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetFrequency(ByVal Frequency As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetChannel(ByVal ChannelName As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function TypeStartTime(ByVal StartTime As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function TypeDate(ByVal dateString As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetSelectedChannelName(ByRef ChannelName As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetSelectedDate(ByRef tDate As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetEventDuration(ByRef EventDuration As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return ""
    End Function

    Overridable Function GetEventStartTime(ByRef EventStartTime As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return ""
    End Function

    Overridable Function GetEventEndTime(ByRef EventEndTime As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return ""
    End Function

    Overridable Function GetFrequency(ByRef Frequency As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return ""
    End Function

    Overridable Function VerifyStartTime(ByVal StartTime As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyEndTime(ByVal EndTime As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False

    End Function
    Overridable Function TypeEndTime(ByVal EndTime As String) As Boolean
        _iex.LogComment("This UI.ManualRecording function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

End Class
