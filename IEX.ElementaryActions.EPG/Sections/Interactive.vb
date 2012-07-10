Public Class Interactive
    Dim res As IEXGateway.IEXResult
    Dim _iex As IEXGateway._IEX


    Dim _UI As EPG.UI

    Sub New(ByVal IEX As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = IEX
        _UI = pUI
    End Sub

    Overridable Function Navigate() As Boolean
        _iex.LogComment("This UI._Interactive function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyInteractive() As Boolean
        _iex.LogComment("This UI._Interactive function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function ExitInteractive() As Boolean
        _iex.LogComment("This UI._Interactive function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function


   





End Class
