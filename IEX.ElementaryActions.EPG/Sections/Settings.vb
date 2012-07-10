Public Class Settings
    Dim _iex As IEXGateway.IEX
    Dim res As IEXGateway.IEXResult
    Dim _Utils As Utils
    Protected _UI As EPG.UI

    Sub New(ByVal IEX As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = IEX
        _UI = pUI
        _Utils = _UI.Utils
    End Sub

    Overridable Function Navigate() As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToSetting(ByVal Setting As String) As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetSetting(ByVal Setting As String) As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetConfirmation(ByVal Setting As String) As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifySetting(ByVal Setting As String) As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToBannerDisplay() As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToStartGuardTime() As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToEndGuardTime() As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToParentalControlAgeLimit() As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToParentalControlLockUnlock() As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToChannel(ByVal ChannelName As String) As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetReminderNotifications(ByVal IsOn As Boolean) As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetSubtitles(ByVal IsOn As Boolean, ByVal LanguageToSet As String) As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SelectRestrictedSetting(ByVal Setting As String) As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function NavigateToSkipInterval(ByVal IsForward As Boolean) As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetSettingsValueFromDictinary(ByVal DictionaryKey As String, ByVal EnumValue As String) As String
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return ""
    End Function

    Overridable Function LockChannel() As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function UnLockChannel() As Boolean
        _iex.LogComment("UI.Settings function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

End Class
