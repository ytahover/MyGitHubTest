Public Class _Event
    Dim _iex As IEXGateway.IEX
    Dim res As IEXGateway.IEXResult
    Dim Sreturnvalue As String

    Private _eventName As String
    Private _eventStartTime As String
    Private _eventEndTime As String
    Private _eventChannel As String
    Private _rightPresses As Integer
    Private _eventStatus As String
    Private _eventDuration As Long
    Private _eventDate As String
    Private _eventPlayedDuration As Long
    Private _eventSource As String

    Sub New(ByVal IEX As IEXGateway.IEX)
        _iex = IEX
        _eventPlayedDuration = 0
        _eventDuration = 0
    End Sub

    Overridable Property EventName() As String
        Get
            Return _eventName
        End Get
        Set(ByVal value As String)
            _eventName = value
        End Set
    End Property

    Overridable Property EventStartTime() As String
        Get
            Return _eventStartTime
        End Get
        Set(ByVal value As String)
            _eventStartTime = value
        End Set
    End Property

    Overridable Property EventEndTime() As String
        Get
            Return _eventEndTime
        End Get
        Set(ByVal value As String)
            _eventEndTime = value
        End Set
    End Property

    Overridable Property EventChannel() As String
        Get
            Return _eventChannel
        End Get
        Set(ByVal value As String)
            _eventChannel = value
        End Set
    End Property

    Overridable Property RightPresses() As Integer
        Get
            Return _rightPresses
        End Get
        Set(ByVal value As Integer)
            _rightPresses = value
        End Set
    End Property

    Overridable Property EventStatus() As String
        Get
            Return _eventStatus
        End Get
        Set(ByVal value As String)
            _eventStatus = value
        End Set
    End Property

    Overridable Property EventDuration() As Long
        Get
            Return _eventDuration
        End Get
        Set(ByVal value As Long)
            _eventDuration = value
        End Set
    End Property

    Overridable Property EventPlayedDuration() As Long
        Get
            Return _eventPlayedDuration
        End Get
        Set(ByVal value As Long)
            _eventPlayedDuration = value
        End Set
    End Property

    Overridable Property EventDate() As String
        Get
            Return _eventDate
        End Get
        Set(ByVal value As String)
            _eventDate = value
        End Set
    End Property

    Overridable Property EventSource() As String
        Get
            Return _eventSource
        End Get
        Set(ByVal value As String)
            _eventSource = value
        End Set
    End Property
End Class

