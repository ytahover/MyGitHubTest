Imports System.Collections
Public Class FailuresHandler
    Dim _IEX As IEXGateway.IEX
    Dim Stacklog As StackTrace
    Dim Sstack As String
    Sub New(ByVal IEX As IEXGateway.IEX)
        _IEX = IEX
        Stacklog = New StackTrace()
    End Sub

    Function setup(ByVal ErrorMSG As String)
        IEX.ElementaryActions.Manager.Log(Stacklog.ToString())
        _IEX.LogComment(Stacklog.GetFrames(Stacklog.FrameCount - 1).GetMethod.ToString + vbCrLf + Stacklog.GetFrames(Stacklog.FrameCount - 2).GetMethod.ToString)
        Throw New IEX.ElementaryActions.Objects.ExecutionFailure("Setup error:" & ErrorMSG)
        Return 0
    End Function
    Function Navigation(ByVal ErrorMSG As String)
        IEX.ElementaryActions.Manager.Log(Stacklog.ToString())
        _IEX.LogComment(Stacklog.GetFrames(Stacklog.FrameCount - 1).GetMethod.ToString + vbCrLf + Stacklog.GetFrames(Stacklog.FrameCount - 2).GetMethod.ToString)
        Throw New IEX.ElementaryActions.Objects.ExecutionFailure("Navigation error:" & ErrorMSG)
        Return 0
    End Function
    Function action(ByVal ErrorMSG As String)
        IEX.ElementaryActions.Manager.Log(Stacklog.ToString())
        _IEX.LogComment(Stacklog.GetFrames(Stacklog.FrameCount - 1).GetMethod.ToString + vbCrLf + Stacklog.GetFrames(Stacklog.FrameCount - 2).GetMethod.ToString)
        Throw New IEX.ElementaryActions.Objects.ExecutionFailure("action error:" & ErrorMSG)
        Return 0
    End Function

    Function actionTime_out(ByVal ErrorMSG As String)
        IEX.ElementaryActions.Manager.Log(Stacklog.ToString())
        _IEX.LogComment(Stacklog.GetFrames(Stacklog.FrameCount - 1).GetMethod.ToString + vbCrLf + Stacklog.GetFrames(Stacklog.FrameCount - 2).GetMethod.ToString)

        Throw New IEX.ElementaryActions.Objects.ExecutionFailure("actionTime_out error:" & ErrorMSG)
        Return 0
    End Function
    Function verify(ByVal ErrorMSG As String)
        IEX.ElementaryActions.Manager.Log(Stacklog.ToString())
        _IEX.LogComment(Stacklog.GetFrames(Stacklog.FrameCount - 1).GetMethod.ToString + vbCrLf + Stacklog.GetFrames(Stacklog.FrameCount - 2).GetMethod.ToString)

        Throw New IEX.ElementaryActions.Objects.ExecutionFailure("verify error:" & ErrorMSG)
        Return 0
    End Function
    Function checkParameters(ByVal ParamArray Paramtocheck() As Object)
        Dim PerInfo As System.Reflection.ParameterInfo

        For Each oPar As Object In Paramtocheck
            If IsNothing(oPar) Then
                PerInfo = oPar

                NoValidParameters(PerInfo.Name + "is empty")
            End If
            '  If System.Type.GetType("System.String") = oPar.GetType() Then

            ' End If
        Next

        Return 0
    End Function
    Function NoValidParameters(ByVal ErrorMSG As String)
        Throw New IEX.ElementaryActions.Objects.ExecutionFailure("NoValidParameters error:" & ErrorMSG)
        Return 0
    End Function

End Class
