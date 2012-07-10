Public Class Favorites
    Dim _iex As IEXGateway.IEX
    Dim res As IEXGateway.IEXResult
    Dim Sreturnvalue As String
    Protected _UI As EPG.UI

    Sub New(ByVal IEX As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = IEX
        _UI = pUI
    End Sub

    Overridable Function Naviagte() As Boolean
        _iex.LogComment("This UI._Favorites function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NaviagteToAllChannels() As Boolean
        _iex.LogComment("This UI._Favorites function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NaviagteToFavoritesSetting() As Boolean
        _iex.LogComment("This UI._Favorites function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SelectChannel() As Boolean
        _iex.LogComment("This UI._Favorites function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function TuneToChannel(ByVal Channel As String) As Boolean
        _iex.LogComment("This UI._Favorites function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

   
    Overridable Function AddChannel() As Boolean
        _iex.LogComment("This UI._Favorites function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyChannelSelect(ByVal Channel As String) As Boolean
        _iex.LogComment("This UI._Favorites function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function
End Class
