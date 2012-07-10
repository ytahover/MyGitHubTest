Public Class Osd
    Dim _iex As IEXGateway.IEX
    Dim res As IEXGateway.IEXResult
    Dim Sreturnvalue As String
    Dim _UI As EPG.UI

    Sub New(ByVal IEX As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = IEX
        _UI = pUI
    End Sub

    Overridable Function VerifyIsOSD() As Boolean
        _iex.LogComment("This UI._Osd function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyTextOnOSD(ByVal Text As String) As Boolean
        _iex.LogComment("This UI._Osd function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyNumberOSD() As Boolean
        _iex.LogComment("This UI._Osd function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function ConfirmOSD() As Boolean
        _iex.LogComment("This UI._Osd function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function CancelOSD() As Boolean
        _iex.LogComment("This UI._Osd function isn't implemented under the general implementation. Please implement localy in project.")
        Return False

    End Function


    
End Class
