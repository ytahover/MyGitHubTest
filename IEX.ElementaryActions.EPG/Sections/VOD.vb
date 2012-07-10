Public Class VOD
    Dim _iex As IEXGateway.IEX
    Dim res As IEXGateway.IEXResult
    Dim Sreturnvalue As String
    Protected _Utils As Utils
    Dim _UI As EPG.UI

    Sub New(ByVal iex As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = iex
        _UI = pUI
        _Utils = _UI.Utils
    End Sub
#Region "Download"
    Overridable Function Download() As Boolean

    End Function
#End Region
#Region "Navigate"
    Overridable Function Navigate() As Boolean

    End Function
    Overridable Function NavigateToDownload() As Boolean

    End Function
    Overridable Function NavigateToBooked() As Boolean

    End Function
#End Region

#Region "Play Functions"
    Overridable Function Play() As Boolean

    End Function

    Overridable Function PlayTrailer() As Boolean

    End Function

    Overridable Function ResumePlay() As Boolean

    End Function

#End Region

#Region "Get Functions"
    Overridable Function GetEventName(ByRef EventName As String) As Boolean

    End Function
    Overridable Function GetListName(ByRef ListName As String) As Boolean

    End Function

#End Region

#Region "Set Functions"
    Overridable Function NavigateToEventName(ByVal EventName As String) As Boolean

    End Function
    Overridable Function NaviagteToListName(ByVal ListName As String) As Boolean

    End Function

#End Region

#Region "Verify Functions"
    Overridable Function VerifyEventName(ByVal EventName As String) As Boolean

    End Function
    Overridable Function VerifyListName(ByVal ListName As String) As Boolean

    End Function

    Overridable Function VerifyPlayAsset(Optional ByVal _AssetListName As String = "", Optional ByVal _AssetName As String = "") As Boolean

    End Function

    Overridable Function VerifyPlayTrailer(Optional ByVal _AssetListName As String = "", Optional ByVal _AssetName As String = "") As Boolean

    End Function

    Overridable Function VerifyPlayTrailerEnded() As Boolean

    End Function

    Overridable Function VerifyPlayAssetEnded() As Boolean

    End Function

#End Region


End Class
