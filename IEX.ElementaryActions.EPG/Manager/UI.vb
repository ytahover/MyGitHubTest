Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)> _
Public MustInherit Class UI
    'Public Class UI
#Region "Public"
    Protected _ArchiveRecordings As ArchiveRecordings
    Protected _Banner As Banner
    Protected _ChannelBar As ChannelBar
    Protected _CurrentRecordings As CurrentRecordings
    Protected _FutureRecordings As FutureRecordings
    Protected _PlannerBase As PlannerBase
    Protected _Guide As Guide
    Protected _Interactive As Interactive
    Protected _ManualRecording As ManualRecording
    Protected _Menu As Menu
    Protected _ParentalRating As ParentalRating
    Protected _Settings As Settings
    Protected _TrickModes As TrickModes
    Protected _Utils As Utils
    Protected _Favorites As Favorites
    Protected _VOD As VOD
    Protected _OSD As Osd
    Protected _OSD_Reminder As OSD_Reminder
    Protected _OSD_PIN As OSD_PIN
    Public ChannelsList As EPG._Channel()
    Public channel As EPG._Channel = New EPG._Channel("")
    Public Events As New Dictionary(Of String, IEX.ElementaryActions.EPG._Event)
#End Region

    Dim _iex As IEXGateway.IEX


#Region "Property"

    ReadOnly Property ArchiveRecordings() As ArchiveRecordings
        Get
            Return _ArchiveRecordings
        End Get
    End Property

    ReadOnly Property PlannerBase() As PlannerBase
        Get
            Return _PlannerBase
        End Get
    End Property

    ReadOnly Property Banner() As Banner
        Get
            Return _Banner
        End Get
    End Property

    ReadOnly Property ChannelBar() As ChannelBar
        Get
            Return _ChannelBar
        End Get
    End Property

    ReadOnly Property CurrentRecordings() As CurrentRecordings
        Get
            Return _CurrentRecordings
        End Get
    End Property

    ReadOnly Property FutureRecordings() As FutureRecordings
        Get
            Return _FutureRecordings
        End Get
    End Property

    ReadOnly Property Guide() As Guide
        Get
            Return _Guide
        End Get
    End Property

    ReadOnly Property Interactive() As Interactive
        Get
            Return _Interactive
        End Get
    End Property

    ReadOnly Property TrickModes() As TrickModes

        Get
            Return _TrickModes
        End Get
    End Property

    ReadOnly Property Vod() As VOD
        Get
            Return _VOD
        End Get

    End Property

    ReadOnly Property OSD() As Osd
        Get
            Return _OSD
        End Get

    End Property

    ReadOnly Property OSD_Reminder() As OSD_Reminder
        Get
            Return _OSD_Reminder
        End Get

    End Property
    ReadOnly Property OSD_PIN() As OSD_PIN
        Get
            Return _OSD_PIN
        End Get

    End Property

    ReadOnly Property ManualRecording() As ManualRecording
        Get
            Return _ManualRecording
        End Get
    End Property

    ReadOnly Property Utils() As Utils
        Get
            Return _Utils
        End Get
    End Property

    ReadOnly Property Menu() As Menu
        Get
            Return _Menu
        End Get
    End Property

    ReadOnly Property Settings() As Settings
        Get
            Return _Settings
        End Get
    End Property

#End Region

    Sub New(ByVal iex As IEXGateway.IEX)

        _Utils = New Utils(iex, Me)
        _ArchiveRecordings = New ArchiveRecordings(iex, Me)
        _Banner = New Banner(iex, Me)
        _ChannelBar = New ChannelBar(iex, Me)
        _CurrentRecordings = New CurrentRecordings(iex, Me)
        _FutureRecordings = New FutureRecordings(iex, Me)
        _Favorites = New Favorites(iex, Me)
        _Guide = New Guide(iex, Me)
        _Interactive = New Interactive(iex, Me)
        _ManualRecording = New ManualRecording(iex, Me)
        _Menu = New Menu(iex, Me)
        _ParentalRating = New ParentalRating(iex, Me)
        _Settings = New Settings(iex, Me)
        _TrickModes = New TrickModes(iex, Me)
        _OSD = New Osd(iex, Me)
        _OSD_Reminder = New OSD_Reminder(iex, Me)
        _OSD_Pin = New OSD_PIN(iex, Me)
        _VOD = New VOD(iex, Me)
        _iex = iex
    End Sub

    'Sub IEX_Exception(ByVal res As IEXGateway._IEXResult)
    '    Throw IEX.ElementaryActions.Objects.StopEA.As_IEXResult(res)
    'End Sub

    'Sub Set_Exception(ByVal ExitCodeValue As Integer, ByVal ExitCodeName As String, ByVal ExitReason As String)
    '    Throw IEX.ElementaryActions.Objects.StopEA.Failed(ExitCodeValue, ExitCodeName, ExitReason)
    'End Sub
End Class
