Public Class TrickModes
    Dim res As IEXGateway.IEXResult
    Dim _iex As IEXGateway.IEX
    Dim _UI As EPG.UI

    Sub New(ByVal IEX As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = IEX
        _UI = pUI
    End Sub

    Overridable Function RaiseTrickMode() As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function IsTrickMode() As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function Navigate(ByVal Speed As Double, ByVal IsSkip As Boolean) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetSpeed(ByVal Speed As Double) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetSkip(ByVal NumOfSkipPoints As Integer, ByVal IsForward As Boolean) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function PlayEvent(ByVal ev As _Event) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function StopPlayEvent(ByVal IsReviewBuffer As Boolean) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetPlaybackTime(ByVal Time As String) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetBookmark() As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetCurrentplayBackTime(ByRef pbTime As String) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetCurrentPlayBackDuration(ByRef pbDurationSec As Integer) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyPlayback(ByVal ev As _Event, ByVal channel As _Channel, ByVal duration As Integer, ByVal hasVideo As Boolean) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyStartOfPlayBack() As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyEndOfPlayBack() As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyEOFBOF(ByVal Duration As Long, ByVal Speed As Double, ByVal IsReviewBuffer As Boolean, ByVal IsReviewBufferFull As Boolean, ByVal EOF As Boolean) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetCurrentPosition(ByRef Position As String) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetStreamPosition(ByRef Position As Integer) As Boolean
        _iex.LogComment("This UI.TrickModes function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function
End Class
