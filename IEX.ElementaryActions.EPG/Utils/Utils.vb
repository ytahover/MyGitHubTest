Imports System.IO
Imports IEX.Utilities

Public Class Utils

    Dim _iex As IEXGateway.IEX
    Dim returnValue As String
    Dim ActualPercentage As Short
    Dim OffLinePath As String
    Public iexlogFolder, IALOffLineFolder As String
    Public _DateTime As _DateTime
    Public _Event As _Event
    Public _Channel As EPG._Channel
    Public Warning As String = ""
    Private _StaticParam As New Dictionary(Of String, Object)
    Dim _UI As EPG.UI

    Sub New(ByVal IEX As IEXGateway.IEX, ByVal pUI As EPG.UI)
        _iex = IEX
        _UI = pUI
        _DateTime = New _DateTime(_iex)
    End Sub

    Public Property StaticParam(ByVal Key As String) As Object
        Get
            If _StaticParam.ContainsKey(Key) Then
                'if the Key existing
                Return _StaticParam.Item(Key)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Object)
            Dim Bfound As Boolean = False
            Try
                If _StaticParam.ContainsKey(Key) Then
                    'if the Key existing
                    _StaticParam.Item(Key) = value
                Else
                    _StaticParam.Add(Key, value)
                End If
            Catch ex As Exception

            End Try

        End Set
    End Property

#Region "Log Comments"

    Function LogCommentInfo(ByVal Info As String) As Boolean
        Dim res As IEXGateway.IEXResult

        res = _iex.LogComment(Info, False, False, False, CByte(10), "Blue")
        Try
            'Tracer.Write(IEX.Utilities.'Tracer.TraceLevel.INFO, Info, "EA")
        Catch ex As Exception
        End Try

        Return res.CommandSucceeded

    End Function

    Function LogCommentImportent(ByVal Info As String) As Boolean
        Dim res As IEXGateway.IEXResult

        res = _iex.LogComment(Info, True, False, False, CByte(10), "Purple")

        Try
            'Tracer.Write(IEX.Utilities.'Tracer.TraceLevel.EVENT, Info, "EA")
        Catch ex As Exception
        End Try

        Return res.CommandSucceeded
    End Function

    Function LogCommentWarning(ByVal Info As String) As Boolean
        Dim res As IEXGateway.IEXResult

        _iex.ForceShowFailure()
        res = _iex.LogComment(Info, True, False, False, CByte(10), "Orange")
        Try
            'Tracer.Write(IEX.Utilities.'Tracer.TraceLevel.WARN, Info, "EA")
        Catch ex As Exception
        End Try

        Return res.CommandSucceeded
    End Function

    Function LogCommentFail(ByVal Info As String) As Boolean
        Dim res As IEXGateway.IEXResult

        res = _iex.LogComment(Info, True, False, False, CByte(10), "Red")
        Try
            'Tracer.Write(IEX.Utilities.'Tracer.TraceLevel.ERROR, Info, "EA")
        Catch ex As Exception
        End Try

        Return res.CommandSucceeded
    End Function

    Function LogCommentBlack(ByVal Info As String) As Boolean
        Dim res As IEXGateway.IEXResult

        res = _iex.LogComment(Info, True, False, False, CByte(10), "Black")
        Try
            'Tracer.Write(IEX.Utilities.'Tracer.TraceLevel.INFO, Info, "EA")
        Catch ex As Exception
        End Try

        Return res.CommandSucceeded
    End Function

    Function StartHideFailures(ByVal Info As String) As Boolean
        Dim res As IEXGateway.IEXResult

        res = _iex.StartHideFailures(Info, False, False, False, CByte(10), "Blue")
        Return res.CommandSucceeded
    End Function

#End Region

    Overridable Function STBReady() As Boolean
        Return False
    End Function

    Overridable Function TypeKeys(ByVal StringToType As String) As Boolean
        Dim cmdSeq As String = ""
        Dim res As IEXGateway.IEXResult

        Dim digits As Char() = StringToType.ToCharArray
        For i As Integer = 0 To digits.Length - 1
            cmdSeq += "KEY_" & digits(i) + ","
        Next

        cmdSeq = cmdSeq.Remove(cmdSeq.Length - 1, 1)

        res = _iex.IR.SendIrSequence(cmdSeq, msBetweenSending:=1000)
        If Not res.CommandSucceeded Then
            LogCommentFail("Failed Sending Digits To RCU")
            Return False
        End If

        Return True
    End Function

    Overridable Function TypeManualRecordingKeys(ByVal StringToType As String) As Boolean

        StartHideFailures("Typing Manual Recording Keys " + StringToType.ToString)

        Dim Pass As Boolean = TypeKeys(StringToType)

        _iex.ForceHideFailure()

        Return Pass
    End Function

    Overridable Function ResolveClash(ByVal ResolveAction As String) As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function ExitToLive() As Boolean
        Return SendIR("BACK_UP")
    End Function

    Overridable Function GetEPGTime(ByRef EPG_Time As String) As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function GetEPGDate(ByRef EPG_Date As String) As Boolean
       _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function CheckScreenOffLine(ByVal SecToCheck As Integer, ByVal SecPoll As Integer, ByVal Screen As String, ByVal DVT As String) As Boolean
        Dim StartTime As DateTime = Now
        Dim res As IEXGateway.IEXResult = Nothing
        Dim pathOffLine As String

        _iex.Wait(5)
        'Warning Appears in Live
        'create new folder
        Dim i As Integer = 1
        Do
            pathOffLine = _iex.LogFileName.Remove(_iex.LogFileName.LastIndexOf("\")) + "\" + Screen + DVT + i.ToString()
            If Directory.Exists(pathOffLine) Then
                i = i + 1
            Else
                Directory.CreateDirectory(pathOffLine)
                Exit Do
            End If
            If i > 200 Then Exit Do
        Loop
        Do
            _iex.BeginCapture(pathOffLine, 1, 1)
            _iex.EndCapture()
            _iex.Wait(SecPoll)
        Loop While SecToCheck > Now.Subtract(StartTime).TotalSeconds
        Dim OffLine As String() = Directory.GetFiles(pathOffLine)
        For Each fileOff As String In OffLine
            _iex.IAL.SetOfflineScreenCapture(fileOff)

            res = _iex.IAL.VerifyCurrentScreenAndDVT(Screen, DVT, 1)
            If res.CommandSucceeded Then
                _iex.IAL.SetOfflineScreenCapture("")
                Try
                    Directory.Delete(pathOffLine, True)
                Catch ex As Exception
                    _UI.Utils.LogCommentFail(ex.Message)
                End Try

                Exit For
            End If
        Next
        _iex.IAL.SetOfflineScreenCapture("")
        If Not res.CommandSucceeded Then
            Return False
        End If
        Return True
    End Function

    Overridable Function ReloadDB() As Boolean
        Dim res As IEXGateway.IEXResult
        Dim IEXServerNum As String = _iex.Connections.Split(":")(1)
        Dim inifile As New AMS.Profile.Ini("c:\program files\IEX\IEX_" & IEXServerNum & "\IEX.ini")
        'geting the IAL DB path from the IEX ini file
        Dim IALDBPath As String = inifile.GetValue("IAL_DB", "DB_NAME")
        'geting the debu com port number from the IEX ini file
        'Loading the latest IAL DB
        Dim my_ial As IEXGateway._IAL = _iex.IAL
        _iex.StartHideFailures("Loading the latest IAL DB", False, False, False, CByte(10), "BLUE")
        res = my_ial.ReloadDB()
        _iex.ForceHideFailure()
        If res.CommandSucceeded Then
            Try
                Dim _FileInfo As New System.IO.FileInfo(IALDBPath)
                _iex.LogComment("The IAL DB is updated to " & CStr(_FileInfo.LastWriteTime), True, False, False, CByte(12), "green")
            Catch ex As Exception
            End Try
        Else 'if the reload DB action was failed
            _iex.LogComment("Failed to reload the latest IAL DB (the IEX will use the one was loaded when the server was launched) ", True, False, False, CByte(12), "orange")
        End If
        Return True
    End Function

    Overridable Function GetItem(ByVal Template As String, ByVal Criteria As String, ByVal Column As String, ByRef ReturnGetItemVlaue As String, ByVal NumberOfMatches As Integer, ByVal NumberOfretries As Integer) As Boolean
        Dim Lasts As New Dictionary(Of String, Integer) 'dictonary for results
        Dim res As IEXGateway.IEXResult
        Dim foundMatch As Boolean = False

        For i As Integer = 1 To NumberOfretries
            res = _iex.IAL.GetItem(Template, Criteria, Column, returnValue)
            If res.CommandSucceeded Then 'check if the command success
                For Each S As String In Lasts.Keys 'get over all the last result
                    If S = returnValue Then
                        Lasts.Item(S) = Lasts.Item(S) + 1
                        foundMatch = True
                        If Lasts.Item(S) = NumberOfMatches Then 'found  
                            ReturnGetItemVlaue = returnValue
                            Return True
                        End If
                        Exit For
                    End If
                Next
                If Not foundMatch Then
                    Lasts.Add(returnValue, 1)
                Else
                    foundMatch = False
                End If
            End If
        Next
        Return False
    End Function

    Overridable Function IsVideo(Optional ByVal Coordinates As String = "") As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function EnterPin() As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#Region "Tunning To Channel"

    Overridable Function TuningToChannel(ByVal ChannelNumber As String, Optional ByVal Type As String = "", Optional ByVal WithSubtitles As Boolean = False) As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyTuneToChannel() As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyTuneToChannelPredicted() As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyTuneToChannelNotPredicted() As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyTuneToChannelSubtitles() As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#End Region

    Public Overridable Function IsLive() As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function Standby(ByVal IsOn As Boolean) As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function IsSTBCrash() As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function ReturnToLiveViewing(Optional ByVal CheckForVideo As Boolean = False) As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SendIR(ByVal IRKey As String, Optional ByVal WaitAfterIR As Integer = 2000) As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function SendChannelAsIRSequence(ByVal ChannelNumber As String, Optional ByVal MsBetweenSending As Integer = 500) As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function VerifyChannelNumber(ByVal ChannelNumber As String) As Boolean
        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

    Overridable Function InsertEventToCollection(ByVal EventKeyName As String, ByVal EventName As String, ByVal EventSource As String, ByVal StartTime As String, _
                                                 ByVal EndTime As String, ByVal Channel As String, ByVal Duration As Long, ByVal tDate As String, ByVal Frequency As String) As Boolean

        _iex.LogComment("This UI.Utils function isn't implemented under the general implementation. Please implement localy in project.")
        Return False
    End Function

#Region "Hex2Dec"
    ''' <summary>
    ''' The EA converts Hex string to Decimal.
    ''' </summary>
    ''' <param name="hex">Hex string to be converted</param>
    ''' <param name="Dec">conversion of the given arguments</param>
    ''' <returns>Decimal representation  of the hex arguments</returns>
    ''' <remarks></remarks>
    Public Function Hex2Dec(ByVal hex As String, ByRef Dec As String) As Boolean
        Dim ResEA As New IEX.ElementaryActions.Result

        Try
            Dec = Integer.Parse(hex, System.Globalization.NumberStyles.HexNumber).ToString()
        Catch ex As Exception
            Dec = ""
            Return False
        End Try

        Return True

    End Function
#End Region

#Region "Dec2Hex"
    ''' <summary>
    ''' Convert Decimal number to Hex
    ''' </summary>
    ''' <param name="Dec">Decimal number to convert</param>
    ''' <param name="hex">ByRef param, Hex number to return</param>
    ''' <returns>IEXResult</returns>
    ''' <remarks></remarks>
    Public Function Dec2Hex(ByVal Dec As String, ByRef hex As String) As Boolean
        Dim ResEA As New IEX.ElementaryActions.Result
        Try
            hex = System.Convert.ToString(System.Convert.ToInt32(Dec), 16)
        Catch ex As Exception
            hex = ""
            Return False
        End Try
        Return True
    End Function
#End Region

#Region "IncreasTimeByParam"
    ''' <summary>
    ''' Increases a given string represents time with the given factor
    ''' </summary>
    ''' <param name="baseTime">Should be in format "XX:YY"</param>
    ''' <param name="field">Can be either: "h" - for hours, or "n" - for minutes</param>
    ''' <param name="factor">baseTime + factor * field = newTime</param>
    ''' <param name="result">new timw according to the calculation above</param>
    ''' <returns>result in the format "XX:YY"</returns>
    ''' <remarks></remarks>
    Public Function IncreasTimeByParam(ByVal baseTime As String, ByVal field As String, _
                                       ByVal factor As Integer, ByRef result As String) As Boolean
        _iex.StartHideFailures("Increasing Time by Params: Field = " & field & " factor = " & factor.ToString())
        If String.IsNullOrEmpty(baseTime) Then
            _iex.ForceHideFailure()
            _UI.Utils.LogCommentFail("Ilegal arguments!!!")
            Return False
        End If
        baseTime = baseTime.Replace(" ", Nothing)
        If Not System.Text.RegularExpressions.Regex.IsMatch(baseTime, "^([0-1]?\d|2[0-3]):[0-5]\d$") Then
            _iex.ForceHideFailure()
            _UI.Utils.LogCommentFail("Ilegal arguments!!!")
            Return False
        End If
        If String.IsNullOrEmpty(field) Then
            _iex.ForceHideFailure()
            _UI.Utils.LogCommentFail("Ilegal arguments!!!")
            Return False
        End If

        If factor <= 0 Then
            _iex.ForceHideFailure()
            _UI.Utils.LogCommentFail("Ilegal arguments!!!")
            Return False
        End If
        Select Case field   ' Must be a primitive data type
            Case "h", "n"
            Case Else
                _iex.ForceHideFailure()
                _UI.Utils.LogCommentFail("Ilegal arguments!!!")
                Return False
        End Select


        Dim t2 As System.TimeSpan = New System.TimeSpan(Integer.Parse(baseTime.Substring(0, 2)), Integer.Parse(baseTime.Substring(3, 2)), 0)
        Dim t3 As System.TimeSpan
        Select Case field   ' Must be a primitive data type
            Case "h"
                t3 = New System.TimeSpan(factor, 0, 0)
            Case "n"
                t3 = New System.TimeSpan(0, factor, 0)
            Case Else
                t3 = New System.TimeSpan(0, 0, 0)
        End Select
        Dim MyHours As String = t2.Add(t3).Hours
        Dim MyMinutes As String = t2.Add(t3).Minutes

        If String.IsNullOrEmpty(MyHours) Or String.IsNullOrEmpty(MyMinutes) Then
            _iex.ForceHideFailure()
            _UI.Utils.LogCommentFail("Encountered a failur while traying to convert time")
            Return False
        Else
            If MyHours.Length = 1 Then MyHours = "0" & MyHours
            If MyMinutes.Length = 1 Then MyMinutes = "0" & MyMinutes
            result = New String(MyHours & ":" & MyMinutes)
        End If
        _iex.ForceHideFailure()
        Return True
    End Function
#End Region


End Class

'-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

'Function GetLastOffLine(ByVal NumberOfPictures As Integer, ByRef ReturnPath As String()) As Boolean
'    Dim DirInfo As New DirectoryInfo(IALOffLineFolder)
'    Dim FilesInfo As FileInfo() = DirInfo.GetFiles("*.bmp")

'    Array.Resize(ReturnPath, NumberOfPictures)
'    For I As Integer = 1 To NumberOfPictures
'        Try
'            ReturnPath(I - 1) = FilesInfo(FilesInfo.Length - I).FullName
'        Catch ex As Exception
'            _iex.LogComment("Error acured while setting pictures array.")
'            If (FilesInfo.Length - I < 0) Then
'                _iex.LogComment("Requested number of pictures (" & NumberOfPictures & " higher then actual number (" & (I - 1) & ").")
'            End If
'            Return False
'        End Try
'    Next
'    Return True
'End Function

'Overridable Function TypeTuneToChannelKeys(ByVal StringToType As String) As Boolean
'    Dim cmdSeq As String = ""
'    Dim res As IEXGateway.IEXResult

'    Dim digits As Char() = StringToType.ToCharArray
'    For i As Integer = 0 To digits.Length - 1
'        cmdSeq += "KEY_" & digits(i) + ","
'    Next

'    cmdSeq = cmdSeq.Remove(cmdSeq.Length - 1, 1)

'    res = _iex.IR.SendIrSequence(cmdSeq, msBetweenSending:=1500)
'    If Not res.CommandSucceeded Then
'        LogCommentFail("Failed Sending Digits To RCU")
'        Return False
'    End If

'    Return True
'End Function

'Overridable Function resolveClash(ByVal resolveAction As String) As Boolean
'    Select Case resolveAction.ToLower()
'        Case "cancel"
'            _iex.SendIRCommand("SELECT")
'            Return True
'    End Select
'    Return False
'End Function

'Overridable Function ExitToLive() As Boolean
'    Return SendIR("BACK_UP")
'End Function

'Overridable Function GetEPGTime(ByRef EPG_Time As String) As Boolean
'    Dim StartTime As String = ""
'    Dim Counter As Integer = 0
'    Dim res As IEXGateway.IEXResult

'    Do
'        Counter = Counter + 1
'        res = _iex.IAL.GetItem("EPGTime", "", "Time", StartTime)
'        If StartTime.IndexOf(":") < 0 Then
'            StartTime = StartTime.Insert(2, ":")
'        End If
'        'deleting non relevant additions in the end of the time string
'        If _DateTime.IsDateTime(StartTime, EPG_Time) Then
'            ExitToLive()
'            Return True
'        End If

'        If Counter = 4 Then
'            _UI.Utils.LogCommentFail("Can't Convert Event Time To Time")
'            Return False
'        End If
'    Loop
'End Function

'Overridable Function GetEPGDate(ByRef EPG_Date As String) As Boolean
'    Dim EpgDate As String = ""
'    Dim res As IEXGateway.IEXResult

'    res = _iex.IAL.GetItem("EPG", "", "Date", EpgDate)
'    If Not res.CommandSucceeded Then
'        _UI.Utils.LogCommentFail("GetEPGDate : Failed To Get EPG Date")
'        Return False
'    End If

'    If EpgDate <> "" Then
'        EPG_Date = EpgDate
'        _UI.Utils.LogCommentImportent("GetEPGDate : EPG Date Is " + EpgDate)
'        Return True
'    Else
'        _UI.Utils.LogCommentFail("GetEPGDate : Failed To Get EPG Time")
'        Return False
'    End If

'End Function

'Overridable Function RandomKey(ByVal Key As String) As Boolean
'    If Key = "ON_OFF" Then
'        _iex.SendIRCommand("ON_OFF")
'        _iex.Wait(10)
'        _iex.SendIRCommand("ON_OFF")
'        Return False
'    End If
'    Return True
'End Function

'Overridable Function IsVideo(Optional ByVal coordinates As String = "10 10 400 400") As Boolean
'    If String.IsNullOrEmpty(coordinates) Then coordinates = "10 10 400 400"
'    Return _iex.CheckForVideo(coordinates, True, 10).CommandSucceeded
'End Function

'Sub UploadChannelsList(ByRef ChannelsList As EPG._Channel())
'    If Not ChannelsList Is Nothing Then
'        _iex.LogComment("Failed uploading channels list from XML. List already exists.", False, False, False, CByte(10), "red")
'    End If
'    _iex.StartHideFailures("Uploading Channels List from XML.", False, False, False, CByte(10), "purple")

'    Dim size As Integer = 0
'    Dim successCounter = 0
'    Try
'        Dim xmlFileName As String = "c:\Program Files\IEX\Tests\TestsINI\" + Environment.MachineName + ".xml"
'        Dim XMLDoc As System.Xml.XmlDocument
'        XMLDoc = New System.Xml.XmlDocument()

'        Dim fs As New System.IO.FileStream(xmlFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read)
'        Dim sr As New System.IO.StreamReader(fs)
'        Dim tempDirectory As String = Environment.CurrentDirectory
'        Try
'            Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(xmlFileName)
'            XMLDoc.Load(sr)
'        Catch
'        End Try
'        sr.Close()
'        fs.Close()

'        Environment.CurrentDirectory = tempDirectory

'        Dim IExNumber As String = ""
'        Dim activeStream As String = ""
'        If _iex.IsConnected Then
'            IExNumber = _iex.Connections.Substring(_iex.Connections.Length - 1)
'        End If

'        Dim Node2 As System.Xml.XmlNodeList = XMLDoc.SelectNodes(".//IEX" + IExNumber)

'        If Node2.Count > 0 Then
'            For Each TempNode As System.Xml.XmlNode In Node2(0).ChildNodes
'                Dim tempVal As String = TempNode.InnerText
'                Dim tempName As String = TempNode.Name
'                If tempName = "ActiveStream" Then
'                    activeStream = tempVal
'                End If
'            Next
'        End If

'        Dim Node1 As System.Xml.XmlNodeList = XMLDoc.SelectNodes(".//Streams/StreamInfo[@Name='" + activeStream + "']")
'        Dim channel As EPG._Channel

'        If Node1.Count > 0 Then
'            For Each TempNode As System.Xml.XmlNode In Node1
'                Try
'                    Node2 = TempNode.SelectNodes(".//Channel")

'                    If Node2.Count > 0 Then
'                        ChannelsList = Array.CreateInstance(_UI.channel.GetType(), Node2.Count)
'                        For Each TempNode2 As System.Xml.XmlNode In Node2
'                            Try
'                                channel = New EPG._Channel(TempNode2.ChildNodes(0).InnerText, TempNode2.Attributes("Channel_Name").Value)
'                                ChannelsList(size) = channel
'                                size += 1
'                                successCounter += 1
'                            Catch ex As Exception
'                                size += 1
'                            End Try


'                        Next
'                    End If
'                Catch
'                    'failed uploading channels. comment is given at the end of function
'                End Try
'            Next
'        End If
'        _iex.ForceHideFailure()

'    Catch ex As Exception

'    End Try

'    If successCounter = size Then
'        WriteCahnnelsToLog(ChannelsList)
'    Else
'        If successCounter > 0 Then
'            _UI.Utils.LogCommentFail("Failed uploading all channels list from XML. Please compare log to XML data.")
'            WriteCahnnelsToLog(ChannelsList)
'        Else
'            _UI.Utils.LogCommentFail("Failed uploading channels list from XML.")
'        End If
'    End If

'End Sub

'Private Sub WriteCahnnelsToLog(ByRef channelslist As EPG._Channel())
'    Dim channel As EPG._Channel
'    _iex.StartHideFailures("XML Channels List", False, False, False, CByte(10), "purple")
'    For Each channel In channelslist
'        Try
'            _UI.Utils.LogCommentInfo(channel.ToString())
'        Catch ex As Exception
'            'not all channels were uploaded
'        End Try

'    Next
'    _iex.ForceHideFailure()
'End Sub

'Public Function GetChannelXMLName(ByVal _channelNumber As String) As EPG._Channel

'    Dim channel As New EPG._Channel(_channelNumber)

'    Return Array.Find(_UI.ChannelsList, AddressOf channel.IsChannel)

'End Function

'''' <summary>
''''   Accept Pin
'''' </summary>
'''' <returns>true if successeded typing requierd IR</returns>
'''' <remarks></remarks>
'Overridable Function AcceptPin() As Boolean

'    If Not SendIR("SELECT") Then
'        LogCommentFail("Failed Sending SELECT To RCU")
'        Return False
'    End If

'    Return True
'End Function