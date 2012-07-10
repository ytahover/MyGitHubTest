Public Class _RecInformation
    Public EventName As String
    Public EventSTBTime As String
    Public LogTime As String
    Public EventChannel, EventChannelName As String
    Public Status As String
    Public EventDuration As Integer
    Public IsPlayed As Boolean


    Public Sub New(ByVal _eventName As String, ByVal _eventChannel As String, ByVal _eventStbTime As String, ByVal _logTime As String, Optional ByVal _eventChannelName As String = "", Optional ByVal _eventDuration As Integer = 0, Optional ByVal _status As String = "", Optional ByVal _isPlayed As Boolean = False)
        Me.EventName = _eventName
        Me.EventChannel = _eventChannel
        Me.EventChannelName = _eventChannelName
        Me.EventSTBTime = _eventStbTime
        Me.LogTime = _logTime
        Me.EventDuration = _eventDuration
        Me.Status = _status
        Me.IsPlayed = False
    End Sub
    Public Sub New()
        Me.EventDuration = 0
    End Sub



    Public Overrides Function ToString() As String
        Dim returnValue = " The event: " & Me.EventName & _
               " in channel " & Me.EventChannel & _
               " on " & Me.EventSTBTime & " STB Time , " _
                      & Me.LogTime & " Log time."
        If EventDuration > 0 Then
            returnValue += " Event duration is: " & EventDuration & " . "
        End If
        If Not String.IsNullOrEmpty(Me.Status) Then
            returnValue += " Recording Status : " & Me.Status & " . "
        End If

        Return returnValue

    End Function

End Class