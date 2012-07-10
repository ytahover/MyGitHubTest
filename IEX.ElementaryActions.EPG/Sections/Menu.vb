Public Class Menu
    Dim _iex As IEXGateway.IEX
    Dim res As IEXGateway.IEXResult
    Dim _UI As EPG.UI

    Sub New(ByVal IEX As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = IEX
        _UI = pUI
    End Sub

#Region "Menu"

    Public Overridable Function GetMenuAction(ByRef Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function GetMenuChannelName(ByRef ChannelName As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function GetChannelNumber(ByRef ChannelNumber As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function IsMenu() As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function Navigate() As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SetMenuAction(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SetMenuSubAction(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SelectToConflict() As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Settings Menu"


    Public Overridable Function SetPlannerMenuAction(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SetSettingsMenuAction(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SetSettingsConfirmationAction(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SetSettingsSeconds(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "ActionBar Menu"

    Public Overridable Function GetActionBarAction(ByRef Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SetActionBarAction(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SetActionBarSubAction(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Library Menu"

    Public Overridable Function IsLibraryNoContent() As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function MoveUPInLibrary() As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SetLibraryNoContent(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetLibraryMenuAction(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Guide View Menu"

    Public Overridable Function SetGuideViewMenuAction(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "ManualRecording Menu"

    Public Overridable Function SetManualRecordingMenu(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SetManualRecordingAction(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SetManualRecordingChannel(ByVal Channel As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function SetManualRecordingDate(ByVal tDate As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Conflict Menu"

    Overridable Function SetConflictAction(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Language Menu"
    Overridable Function SetLanguage(ByVal Language As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function
#End Region

#Region "Confirmation Menu"
    Public Overridable Function SetConfirmationMenu(ByVal Action As String) As Boolean
        _iex.LogComment("UI.Menu function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function
#End Region

End Class
