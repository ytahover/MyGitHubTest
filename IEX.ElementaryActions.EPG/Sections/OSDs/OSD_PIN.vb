Public Class OSD_PIN
    Protected _iex As IEXGateway.IEX
    Protected res As IEXGateway.IEXResult
    Protected Sreturnvalue As String
    Protected _UI As EPG.UI

    Sub New(ByVal IEX As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = IEX
        _UI = pUI
    End Sub

    Overridable Function EnterPin(Optional ByVal PIN As String = "0000") As Boolean
        _UI.Utils.TypeKeys(PIN)
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
