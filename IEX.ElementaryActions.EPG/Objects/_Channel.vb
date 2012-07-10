Public Class _Channel
    Public channelNumber As String
    Public channelXMLName As String
    Public channelEPGName As String
    Public channelEPGType As String

    Sub New(ByVal _channelNumber As String)
        Me.New(_channelNumber, "", "", "")
    End Sub
    Sub New(ByVal _channelNumber As String, ByVal _channelXMLName As String)
        Me.New(_channelNumber, _channelXMLName, "", "")
    End Sub
    Sub New(ByVal _channelNumber As String, ByVal _channelXMLName As String, ByVal _ChannelEPGName As String)
        Me.New(_channelNumber, _channelXMLName, _ChannelEPGName, "")
    End Sub
    Sub New(ByVal _channelNumber As String, ByVal _channelXMLName As String, ByVal _channelEPGName As String, ByVal _channelEPGType As String)
        channelNumber = _channelNumber
        channelXMLName = _channelXMLName
        channelEPGName = _channelEPGName
        channelEPGType = _channelEPGType
    End Sub

    Sub New()
        channelNumber = String.Empty
        channelXMLName = String.Empty
        channelEPGName = String.Empty
        channelEPGType = String.Empty
    End Sub


    Public Overrides Function ToString() As String

        Dim s As String
        s = "ChannelNumber= " & channelNumber & vbTab
        If Not String.IsNullOrEmpty(channelXMLName) Then
            s += "; ChannelXMLName= " & channelXMLName & vbTab
        End If
        If Not String.IsNullOrEmpty(channelEPGName) Then
            s += "; ChannelEPGName= " & channelEPGName & vbTab
        End If
        If Not String.IsNullOrEmpty(channelEPGType) Then
            s += "; ChannelEPGType= " & channelEPGType
        End If
        Return s
    End Function

    Public Function IsChannel(ByVal compareToCahnnel As EPG._Channel) As Boolean
        Dim actualChannel As EPG._Channel = Me

        If Not actualChannel.channelNumber = compareToCahnnel.channelNumber Then Return False

        If Not String.IsNullOrEmpty(actualChannel.channelXMLName) Then
            If Not actualChannel.channelXMLName = compareToCahnnel.channelXMLName Then Return False
        End If
        If Not String.IsNullOrEmpty(actualChannel.channelEPGName) Then
            If Not actualChannel.channelEPGName = compareToCahnnel.channelEPGName Then Return False
        End If
        If Not String.IsNullOrEmpty(actualChannel.channelEPGType) Then
            If Not actualChannel.channelEPGType = compareToCahnnel.channelEPGType Then Return False
        End If
        Return True
    End Function

   
End Class
