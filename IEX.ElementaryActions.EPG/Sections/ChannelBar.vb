Public Class ChannelBar
    Dim _iex As IEXGateway.IEX
    Dim res As IEXGateway.IEXResult
    Dim Sreturnvalue As String
    Dim _UI As EPG.UI

    Sub New(ByVal iex As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = iex
        _UI = pUI
    End Sub

    Overridable Function Navigate() As Boolean
        _iex.LogComment("This UI.ChannelBar function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetEventName(ByRef EventName As String) As Boolean
        _iex.LogComment("This UI.ChannelBar function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetChannelNumber(ByRef ChannelNumber As String) As Boolean
        _iex.LogComment("This UI.ChannelBar function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NextEvent(Optional ByVal NumOfPresses As Integer = 1, Optional ByVal Navigate As Boolean = True, Optional ByVal SelectEvent As Boolean = True) As Boolean
        _iex.LogComment("This UI.ChannelBar function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SurfChannelUp(Optional ByVal Type As String = "", Optional ByVal WithSubtitles As Boolean = False) As Boolean
        _iex.LogComment("This UI.ChannelBar function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SurfChannelDown(Optional ByVal Type As String = "", Optional ByVal WithSubtitles As Boolean = False) As Boolean
        _iex.LogComment("This UI.ChannelBar function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifySurfChannel() As Boolean
        _iex.LogComment("This UI.ChannelBar function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifySurfChannelPredicted() As Boolean
        _iex.LogComment("This UI.ChannelBar function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifySurfChannelNotPredicted() As Boolean
        _iex.LogComment("This UI.ChannelBar function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SelectEvent() As Boolean
        _iex.LogComment("This UI.ChannelBar function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function DoTune() As Boolean
        _iex.LogComment("This UI.ChannelBar function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

End Class
