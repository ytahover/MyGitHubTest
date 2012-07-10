Public Class OSD_Reminder
    Dim _iex As IEXGateway.IEX
    Dim res As IEXGateway.IEXResult
    Dim Sreturnvalue As String
    Dim _UI As EPG.UI

    Sub New(ByVal IEX As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = IEX
        _UI = pUI
    End Sub

    Overridable Function IsReminder() As Boolean
        _iex.LogComment("This UI._Osd function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyEventName(ByVal EventName As String) As Boolean
        _iex.LogComment("This UI._Osd function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function AcceptReminder() As Boolean
        _iex.LogComment("This UI._Osd function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function RejectReminder() As Boolean
        _iex.LogComment("This UI._Osd function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyIsOSD() As Boolean
        Return _UI.OSD.VerifyIsOSD
    End Function

    Overridable Function VerifyTextOnOSD(ByVal Text As String) As Boolean
        Return _UI.OSD.VerifyTextOnOSD(Text)
    End Function

    Overridable Function VerifyNumberOSD() As Boolean
        Return _UI.OSD.VerifyNumberOSD
    End Function

    Overridable Function ConfirmOSD() As Boolean
        Return _UI.OSD.ConfirmOSD
    End Function

    Overridable Function CancelOSD() As Boolean
        Return _UI.OSD.CancelOSD

    End Function
End Class
