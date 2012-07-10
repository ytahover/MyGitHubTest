Public Class Banner
    Dim _iex As IEXGateway.IEX
    Dim res As IEXGateway.IEXResult
    Dim Sreturnvalue As String
    Protected _Utils As Utils
    Protected _UI As EPG.UI

    Sub New(ByVal iex As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = iex
        _UI = pUI
        _Utils = _UI.Utils
    End Sub

    Enum BannerType
        Live = 1
        PB = 2
        Radio = 3
    End Enum

#Region "Properties"

    Public Overridable Property EPGTime As String
        Get
            _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
            Return ""
        End Get
        Set(ByVal value As String)
            _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        End Set
    End Property

#End Region

#Region "Get Functions"
    Overridable Function GetEPGTime(ByRef time As String) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetEPGTime(ByRef EPGTime As DateTime) As Boolean
        Dim StartTime As String = ""
        Dim Counter As Integer = 0
        Do
            Counter = Counter + 1
            res = _iex.IAL.GetItem("ChannelBanner", "", "EPGTime", StartTime)
            If StartTime.IndexOf(":") < 0 Then
                StartTime = StartTime.Insert(2, ":")
            End If
            'deleting non relevant additions in the end of the time string
            If _UI.Utils._DateTime.IsDateTime(StartTime, EPGTime) Then Return True
            If Counter = 4 Then
                _Utils.LogCommentFail("Can't convert Event Time to Time")
                Return False
            End If
        Loop
    End Function

    Overridable Function GetChannelNumber(ByRef ChannelNumber As String) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetChannelName(ByRef cName As String) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetEventStartTime(ByRef StartTime As String) As Boolean

        If _UI.Utils._DateTime.GetTimeFrom("ChannelBanner", "Start time", StartTime) Then
            Return True
        End If

        Return False
    End Function

    Overridable Function GetEventEndTime(ByRef EndTime As String) As Boolean
        For i As Integer = 1 To 2
            res = _iex.IAL.GetItem("ChannelBanner", "", "End time", Sreturnvalue)
            If _UI.Utils._DateTime.IsDateTime(Sreturnvalue, EndTime) Then
                Return True
            End If
        Next
        Return False
    End Function

    Overridable Function GetEventName(ByRef eName As String) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetBannerType(ByRef Type As BannerType) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetEventTimeLeft(ByRef TimeLeft As Integer) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Set Functions"

    Overridable Function SetReminder() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function CancelReminder() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function PurchaseEvent(ByVal enterParentalControlPin As Boolean, _
                                      ByVal enterPin As Boolean, _
                                      Optional ByVal finishPurchase As Boolean = True, _
                                      Optional ByVal pricePound As String = "", _
                                      Optional ByVal eventName As String = "")

        Return True
    End Function

    Overridable Function PreRecordEvent() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return True
    End Function

    Overridable Function RecordEvent() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return True
    End Function

    Overridable Function RecordEvent(ByVal IsCurrent As Boolean, ByVal IsResuming As Boolean, ByVal IsConflict As Boolean) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function PauseEvent() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function StopRecording() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function CancelBooking() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetEventKeep() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function RemoveEventKeep() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SetSubtitlesLanguage(ByVal Language As String) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function
#End Region

#Region "Verify Functions"

    Overridable Function CheckForBanner(ByVal banner As String, Optional ByVal isPresent As Boolean = True) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function CheckForBanner(Optional ByVal isPresent As Boolean = True) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function IsRecording() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function IsRecording(ByVal _NumOfPresses As Integer) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function IsActionBar() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Public Overridable Function VerifyEventName(ByVal expectedText As String) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyChannelNumber(ByVal Number As String) As Boolean
        Return Me.VerifyChannelNumber("ChannelBanner", "Number", Number)
    End Function

    Overridable Function VerifyChannelNumber(ByVal DVT As String, ByVal Column As String, ByVal Number As String) As Boolean
        res = _iex.IAL.VerifyItem(DVT, "", Column, Number, CShort(90))
        If res.CommandSucceeded Then Return True
        Return False
    End Function

    Overridable Function VerifyEventInfoInBanner(ByVal expectedText As String, Optional ByVal dvt As String = "FirstEventName") As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function CheckBannerType(ByVal Type As BannerType) As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Navigation functions"

    Overridable Overloads Function Navigate() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Overloads Function LaunchChannelBanner(ByVal Screen As String, ByVal DVT As String) As Boolean
        '_IEX.Wait(5)
        _UI.Banner.SendIRLaunchChannelBanner()
        res = _iex.IAL.VerifyCurrentScreenAndDVT(Screen, DVT)
        If res.CommandSucceeded Then
            _iex.BeginCapture(_UI.Utils.IALOffLineFolder, 1)
            _iex.EndCapture()
            Return True
        End If
        For i As Integer = 1 To 3
            _iex.Wait(3)
            _UI.Banner.SendIRLaunchChannelBanner()
            res = _iex.IAL.VerifyCurrentDVT(DVT)
            If res.CommandSucceeded Then
                _iex.BeginCapture(_Utils.IALOffLineFolder, 1)
                _iex.EndCapture()
                Return True
            End If
            _UI.Utils.ExitToLive()
        Next
        Return False
    End Function

    Overridable Function SendIRLaunchChannelBanner() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function PreviousEvent(Optional ByVal repeat As Integer = 1) As Boolean
        For RepeatIR As Integer = 1 To repeat
            _iex.SendIRCommand("Select_Left")
        Next
        Return True
    End Function

    Overridable Function NextEvent(Optional ByVal NumOfPresses As Integer = 1, Optional ByVal Navigate As Boolean = True, Optional ByVal SelectEvent As Boolean = True) As Boolean
        For RepeatIR As Integer = 1 To NumOfPresses
            _iex.SendIRCommand("SELECT_RIGHT")
        Next
        Return True
    End Function

    Overridable Function NextChannel(Optional ByVal repeat As Integer = 1) As Boolean
        For RepeatIR As Integer = 1 To repeat
            _iex.SendIRCommand("Select_UP")
        Next
        Return True
    End Function

    Overridable Function PreviousChannel(Optional ByVal repeat As Integer = 1) As Boolean
        For RepeatIR As Integer = 1 To repeat
            _iex.SendIRCommand("Select_Down")
        Next
        Return True
    End Function

    Overridable Function NavigateToChannelList() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

#Region "Offline Settings Functions"

    Overridable Function BeginOfflineBanner() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function EndOfflineBanner() As Boolean
        _iex.LogComment("UI.Banner function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

End Class

