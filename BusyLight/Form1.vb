Imports System.IO.Ports
Imports Microsoft.Win32
Imports System.Management
Imports System.Text.RegularExpressions


Public Class Form1

    'TO DO 
    'add special characters, pacman, etc.
    'MCU Connected yes/no status
    'fix disconnect/reconnect crash


    Private boolOnPhone As Boolean = False

    'Saved Settings
    Private strSetting_Color As String = ""
    Private strSetting_LEDPort As String = ""
    Private strSetting_MCUPort As String = ""
    Private strSetting_Message As String = ""
    Private strSetting_Mode As String = ""
    Private boolStartup As Boolean = False

    'Private WithEvents _serialPort_LED As New SerialPort
    Private _serialPort_LED As New SerialPort
    Private handshake_led As Handshake = Handshake.None
    Private parity_led As Parity = Parity.Even
    Private baudrate_led As Integer = 9600
    Private databits_led As Integer = 7
    Private stopbits_led As Integer = 1

    Private WithEvents _serialPort_MCU As New SerialPort   'read data from microcontroller


    Private handshake_mcu As Handshake = Handshake.None
    Private parity_mcu As Parity = Parity.None
    Private baudrate_mcu As Integer = 9600
    Private databits_mcu As Integer = 8
    Private stopbits_mcu As Integer = 1
    Delegate Sub SetTextCallback(ByVal [text] As String)

    Private str_NULx21 As String = New String(Chr(0), 21)   '21 NUL in a row
    Private str_SOH As String = Chr(1)      'START OF HEADING
    Private str_STX As String = Chr(2)      'START OF TEXT
    Private str_ESC As String = Chr(27)     'ESCAPE
    Private str_EOT As String = Chr(4)      'END OF TRANSMISSION
    Private str_RS As String = Chr(30)      'RECORD SEPARATOR
    Private str_FS As String = Chr(28)      'FILE SEPARATOR
    Private str_SUB As String = Chr(26)     'SUBSTITUTE

    Private boolTrayExit As Boolean = False

    Private dictModes As New Dictionary(Of String, String)
    Private dictColors As New Dictionary(Of String, String)
    Private listPortsMCU As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
    Private listPortsLED As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))


    Private Sub LoadModesDictionary()
        dictModes.Add("Rotate", "a")
        dictModes.Add("Hold", "b")
        dictModes.Add("Flash", "c")
        dictModes.Add("Roll Up", "e")
        dictModes.Add("Roll Down", "f")
        dictModes.Add("Roll Left", "g")
        dictModes.Add("Roll Right", "h")
        dictModes.Add("Wipe Up", "i")
        dictModes.Add("Wipe Down", "j")
        dictModes.Add("Wipe Left", "k")
        dictModes.Add("Wipe Right", "l")
        dictModes.Add("Scroll", "m")
        dictModes.Add("Auto", "o")
        dictModes.Add("Roll In", "p")
        dictModes.Add("Roll Out", "q")
        dictModes.Add("Wipe In", "r")
        dictModes.Add("Wipe Out", "s")
        dictModes.Add("Compressed Rotate", "t")
        dictModes.Add("Twinkle", "n0")
        dictModes.Add("Sparkle", "n1")
        dictModes.Add("Snow", "n2")
        dictModes.Add("Interlock", "n3")
        dictModes.Add("Switch", "n4")
        dictModes.Add("Slide", "n5")
        dictModes.Add("Spray", "n6")
        dictModes.Add("Starbursts", "n7")
        dictModes.Add("Welcome", "n8")
        dictModes.Add("Slot Machine", "n9")
        dictModes.Add("News Flash", "nA")
        dictModes.Add("Trumpet", "nB")
        dictModes.Add("Cycle Colors", "nC")
        dictModes.Add("Thank You", "nS")
        dictModes.Add("No Smoking", "nU")
        dictModes.Add("Don't Drink", "nV")
        dictModes.Add("Fish", "nW")
        dictModes.Add("Fireworks", "nX")
        dictModes.Add("Balloon", "nY")
        dictModes.Add("Cherry Bomb", "nZ")

    End Sub


    Private Sub LoadColorsDictionary()
        dictColors.Add("Red", "1")
        dictColors.Add("Green", "2")
        dictColors.Add("Amber", "3")
        dictColors.Add("Dim Red", "4")
        dictColors.Add("Dim Green", "5")
        dictColors.Add("Brown", "6")
        dictColors.Add("Orange", "7")
        dictColors.Add("Yellow", "8")
        dictColors.Add("Rainbow 1", "9")
        dictColors.Add("Rainbow 2", "A")
        dictColors.Add("Mixed Color", "B")
        dictColors.Add("Auto Color", "C")
    End Sub

    Private Function PortExists(ByVal strPortName As String) As Boolean
        'Dim strQuery As String = "Select * from Win32_PnPSignedDriver Where DeviceClass='PORTS' AND FriendlyName LIKE '%(" & strPortName & ")'"
        Dim strQuery As String = "Select * from Win32_PnPEntity Where Name LIKE '% (" & strPortName & ")'"
        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher(strQuery)
        Dim collection As ManagementObjectCollection = searcher.Get
        If collection.Count = 0 Then
            Return False
        End If
        Return True
        
    End Function

    Private Sub LoadPortsList()

        listPortsLED.Clear()
        listPortsMCU.Clear()

        'Dim strQuery As String = "Select * from Win32_PnPSignedDriver Where DeviceClass='PORTS' AND FriendlyName LIKE '%(COM%)'"
        Dim strQuery As String = "Select * from Win32_PnPEntity Where Name LIKE '% (COM%)'"
        listPortsMCU.Add(New KeyValuePair(Of String, String)("", ""))
        listPortsLED.Add(New KeyValuePair(Of String, String)("", ""))
        Try

            Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher(strQuery)

            Dim collection As ManagementObjectCollection = searcher.Get
            For Each item As ManagementObject In collection

                Dim fn As String = item.Properties("Name").Value

                Dim strPattern As String = "^.*?\((?<portname>COM[\d]+)\)$"
                Dim m As Match
                m = Regex.Match(fn, strPattern)

                If m.Success Then
                    listPortsMCU.Add(New KeyValuePair(Of String, String)(m.Groups("portname").Value, fn))
                    listPortsLED.Add(New KeyValuePair(Of String, String)(m.Groups("portname").Value, fn))
                End If
            Next


        Catch ex As Exception

            For i As Integer = 0 To My.Computer.Ports.SerialPortNames.Count - 1
                listPortsMCU.Add(New KeyValuePair(Of String, String)(My.Computer.Ports.SerialPortNames(i), My.Computer.Ports.SerialPortNames(i)))
                listPortsLED.Add(New KeyValuePair(Of String, String)(My.Computer.Ports.SerialPortNames(i), My.Computer.Ports.SerialPortNames(i)))
            Next
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Application.ProductName
        NotifyIcon1.Text = Application.ProductName
        NotifyIcon1.Icon = My.Resources.busylight_off
        Me.Icon = My.Resources.busylight_off

        ToolStripStatusLabel1.Text = ""

        'LoadRegistrySettings()

        Dim pair As KeyValuePair(Of String, String)


        LoadModesDictionary()
        LoadColorsDictionary()

        'LoadPortsList()

        'Populate Colors
        For Each pair In dictColors
            ComboBoxColor.Items.Add(pair.Key)
        Next


        'Populate Modes
        For Each pair In dictModes
            ComboBoxMode.Items.Add(pair.Key)
        Next

        'If My.Computer.Ports.SerialPortNames.Count < 1 Then
        '    ComboBoxMCUPort.Enabled = False
        'End If
        'If listPortsMCU.Count < 2 Then
        '    ComboBoxMCUPort.Enabled = False
        'End If

        'Fill up LED Serial Port Combobox
        'For i As Integer = 0 To My.Computer.Ports.SerialPortNames.Count - 1
        '    ComboBoxLEDPort.Items.Add(My.Computer.Ports.SerialPortNames(i))
        'Next
        'ComboBoxLEDPort.DataSource = listPortsLED
        'ComboBoxLEDPort.ValueMember = "Key"
        'ComboBoxLEDPort.DisplayMember = "Value"

        'Fill up MCU Serial Port Combobox
        'ComboBoxMCUPort.Items.Add("Not Used")
        'For i As Integer = 0 To My.Computer.Ports.SerialPortNames.Count - 1
        '    ComboBoxMCUPort.Items.Add(My.Computer.Ports.SerialPortNames(i))
        'Next
        'ComboBoxMCUPort.DataSource = listPortsMCU
        'ComboBoxMCUPort.ValueMember = "Key"
        'ComboBoxMCUPort.DisplayMember = "Value"

        RescanPorts()
        LoadRegistrySettings()

        'If strSetting_Color <> "" Then
        '    ComboBoxColor.SelectedItem = strSetting_Color
        'Else
        '    ComboBoxColor.SelectedIndex = 0
        'End If

        'If strSetting_Mode <> "" Then
        '    ComboBoxMode.SelectedItem = strSetting_Mode
        'Else
        '    ComboBoxMode.SelectedIndex = 0
        'End If

        'If strSetting_LEDPort <> "" Then
        '    Try
        '        ComboBoxLEDPort.SelectedValue = strSetting_LEDPort
        '    Catch ex As Exception
        '        ComboBoxLEDPort.SelectedIndex = 0
        '    End Try
        'Else
        '    ComboBoxLEDPort.SelectedIndex = 0
        'End If

        'If strSetting_MCUPort <> "" Then
        '    Try
        '        ComboBoxMCUPort.SelectedValue = strSetting_MCUPort
        '    Catch ex As Exception
        '        ComboBoxMCUPort.SelectedIndex = 0
        '    End Try
        'Else
        '    ComboBoxMCUPort.SelectedIndex = 0
        'End If

        'If strSetting_Message <> "" Then
        '    TextBoxMessage.Text = strSetting_Message
        'End If


    End Sub


    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Text = Application.ProductName

        If Me.WindowState = FormWindowState.Minimized Then Me.Hide()

    End Sub



    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If boolTrayExit = False Then
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
        End If
    End Sub

    Private Sub SendData(ByVal strTextToSend As String)
        If ComboBoxMode.SelectedItem Is Nothing Then Exit Sub

        Dim strFullMessage As String = ""
        ToolStripStatusLabel1.Text = ""

        Dim strAction As String

        strAction = dictModes.Item(ComboBoxMode.SelectedItem.ToString)

        Dim strColor As String
        strColor = dictColors.Item(ComboBoxColor.SelectedItem.ToString)


        If strTextToSend = "" Then
            'Format message to do a Clear
            strFullMessage += str_NULx21
            strFullMessage += str_SOH
            strFullMessage += "Z00"
            strFullMessage += str_STX
            strFullMessage += "AA"
            strFullMessage += str_ESC
            strFullMessage += " "
            strFullMessage += "a" '(action)
            strFullMessage += str_RS
            strFullMessage += "0"   '???? in some modes a "ZERO" is placed there when cleared
            strFullMessage += str_FS
            strFullMessage += "1"
            strFullMessage += str_SUB
            strFullMessage += "5"
            strFullMessage += str_EOT
        Else
            'Format message for text send
            strFullMessage += str_NULx21

            strFullMessage += str_SOH
            strFullMessage += "Z00"
            strFullMessage += str_STX
            strFullMessage += "E$AAU"
            strFullMessage += Strings.Right("0000" & Hex(Len(strTextToSend) + 37).ToString, 4) 'total bytes? length of text in hex + &h25 (37)
            strFullMessage += "FF00"
            strFullMessage += str_EOT

            strFullMessage += str_NULx21
            strFullMessage += str_SOH
            strFullMessage += "Z00"
            strFullMessage += str_STX
            strFullMessage += "AA"
            strFullMessage += str_ESC
            strFullMessage += " "
            strFullMessage += strAction '26 modes...
            strFullMessage += str_RS
            '????????????????????????
            'strFullMessage += "0"
            strFullMessage += " "
            '????????????????????????
            strFullMessage += str_FS
            strFullMessage += strColor   '3 = yellow, 2 = green, 1=red
            strFullMessage += str_SUB
            strFullMessage += "5" 'SUB 5... substitute a 5 for invalid chars???
            strFullMessage += strTextToSend
            strFullMessage += str_EOT
            strFullMessage += str_NULx21
            strFullMessage += str_SOH
            strFullMessage += "Z00"
            strFullMessage += str_STX
            strFullMessage += "E.SLA"
            strFullMessage += str_EOT
        End If

        Dim strPortName_LED As String = ComboBoxLEDPort.SelectedValue.ToString

        If strPortName_LED = "" Then
            'MsgBox("No LED port selected!", MsgBoxStyle.Exclamation)
            ToolStripStatusLabel1.Text = "No LED port selected!"
            Exit Sub
        End If

        _serialPort_LED.BaudRate = baudrate_led
        _serialPort_LED.Parity = parity_led
        _serialPort_LED.Handshake = handshake_led
        _serialPort_LED.DataBits = databits_led
        _serialPort_LED.StopBits = stopbits_led
        _serialPort_LED.PortName = strPortName_LED


        Try
            _serialPort_LED.Open()
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            ToolStripStatusLabel1.Text = ex.Message
            Exit Sub
        End Try


        _serialPort_LED.Write(strFullMessage)
        _serialPort_LED.Close()


    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        ClearMessage()
    End Sub


    Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
        SendData(TextBoxMessage.Text)
    End Sub

    Private Sub ClearMessage()
        SendData("")
    End Sub

    Private Sub DataReceived(
        ByVal sender As Object,
        ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) _
        Handles _serialPort_MCU.DataReceived
        'ToolStripStatusLabel1.Text = ""
        Try
            Dim sp As SerialPort = CType(sender, SerialPort)
            Dim message As String = sp.ReadLine
            Dim intSensor As Integer = Integer.Parse(message)

            If intSensor > 0 Then
                If boolOnPhone = False Then
                    boolOnPhone = True
                    PanelOnPhone.BackColor = Color.Green
                    Me.Icon = My.Resources.busylight_on
                    NotifyIcon1.Icon = My.Resources.busylight_on
                    NotifyIcon1.Text = Application.ProductName & " - ON"
                    NotifyIcon1.ShowBalloonTip(600, Application.ProductName, "On the phone", ToolTipIcon.Info)
                    Dim strMessage As String = "On the phone..."
                    If strSetting_Message <> "" Then strMessage = strSetting_Message
                    SendData(strMessage)
                End If

            Else
                If boolOnPhone = True Then
                    boolOnPhone = False
                    PanelOnPhone.BackColor = Color.Red
                    Me.Icon = My.Resources.busylight_off
                    NotifyIcon1.Icon = My.Resources.busylight_off
                    NotifyIcon1.Text = Application.ProductName & " - OFF"
                    NotifyIcon1.ShowBalloonTip(600, Application.ProductName, "Off the phone", ToolTipIcon.Info)
                    SendData("")
                End If
            End If

            'If TextBox2.InvokeRequired Then
            '    Dim d As New SetTextCallback(AddressOf SetText)
            '    Me.Invoke(d, New Object() {message})
            'End If

        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            ToolStripStatusLabel1.Text = ex.Message
        End Try

    End Sub

    Private Sub SetText(ByVal [text] As String)
        'TextBox2.Text = [text]
    End Sub

    Private Function GetComboBox(ByRef box As ComboBox) As KeyValuePair(Of String, String)
        Dim pair As KeyValuePair(Of String, String) = New KeyValuePair(Of String, String)("", "")
        If Not box.SelectedItem Is Nothing Then
            Dim key As String = DirectCast(box.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(box.SelectedItem, KeyValuePair(Of String, String)).Value
            pair = New KeyValuePair(Of String, String)(key, value)
        End If

        Return pair
    End Function


    Private Sub ComboBoxMCUPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxMCUPort.SelectedIndexChanged

        PanelConnect.BackColor = Color.Red

        Dim PortName_MCU As String = GetComboBox(ComboBoxMCUPort).Key
        Dim PortName_LED As String = GetComboBox(ComboBoxLEDPort).Key

        If PortName_MCU = "" Then Exit Sub

        If Not PortExists(PortName_MCU) Then
            MsgBox("COM Port:  " & PortName_MCU & " invalid." & vbCrLf & vbCrLf & "Please select a new MCU Port.", MsgBoxStyle.Exclamation)
            RescanPorts()
            LoadRegistrySettings()
        End If

        Try
            If _serialPort_MCU.IsOpen Then _serialPort_MCU.Close()
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & "Please re-launch the application.", MsgBoxStyle.Exclamation)
            boolTrayExit = True
            Application.Exit()
            'Try
            '    ComboBoxMCUPort.DataSource = Nothing
            '    LoadPortsList()
            '    ComboBoxMCUPort.DataSource = listPortsMCU
            '    ComboBoxMCUPort.SelectedIndex = 0
            'Catch
            '    'Do nothing
            'End Try

            Exit Sub
        End Try

        If PortName_LED <> "" Then SendData("")

        'Start listening on this port
        Try
            _serialPort_MCU.PortName = PortName_MCU
            _serialPort_MCU.BaudRate = baudrate_mcu
            _serialPort_MCU.Handshake = handshake_mcu
            _serialPort_MCU.DataBits = databits_mcu
            _serialPort_MCU.StopBits = stopbits_mcu
            _serialPort_MCU.Parity = parity_mcu
            '_serialPort_MCU.NewLine = vbCr
            _serialPort_MCU.Open()
            PanelConnect.BackColor = Color.Green

        Catch ex As Exception
            ComboBoxMCUPort.SelectedIndex = 0
            PanelConnect.BackColor = Color.Red
            'MsgBox("Error:  " & ex.Message)
        End Try




    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub


    Private Sub LoadRegistrySettings()

        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

        Dim appRegKey As RegistryKey
        appRegKey = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, True)

        If IsNothing(appRegKey) Then
            'Create the key
            Registry.CurrentUser.CreateSubKey("Software\" & Application.ProductName)
            appRegKey = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, True)
            If IsNothing(appRegKey) Then
                regKey.Close()
                Exit Sub
            End If

            'Ask user if they want it to launch auto...
            If MsgBox("Launch " & Application.ProductName & " at Startup?", _
                            MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
                            Application.ProductName) = MsgBoxResult.Yes Then
                boolStartup = True
            Else
                boolStartup = False
            End If

            SaveRegistrySettings()

        Else
            'Get Current Value and set it in the interface
            boolStartup = appRegKey.GetValue("RunAtStartup", False)

            strSetting_Color = appRegKey.GetValue("Color", "red")
            strSetting_LEDPort = appRegKey.GetValue("LEDPort", "")
            strSetting_MCUPort = appRegKey.GetValue("MCUPort", "")
            strSetting_Message = appRegKey.GetValue("Message", "On the phone..")
            strSetting_Mode = appRegKey.GetValue("Mode", "")

            RunAtStartupToolStripMenuItem.Checked = boolStartup
            RunAtStartupToolStripMenuItemTRAY.Checked = boolStartup

        End If

        regKey.Close()
        appRegKey.Close()


        If strSetting_Color <> "" Then
            ComboBoxColor.SelectedItem = strSetting_Color
        Else
            ComboBoxColor.SelectedIndex = 0
        End If

        If strSetting_Mode <> "" Then
            ComboBoxMode.SelectedItem = strSetting_Mode
        Else
            ComboBoxMode.SelectedIndex = 0
        End If

        If strSetting_LEDPort <> "" Then
            Try
                ComboBoxLEDPort.SelectedValue = strSetting_LEDPort
            Catch ex As Exception
                ComboBoxLEDPort.SelectedIndex = 0
            End Try
        Else
            ComboBoxLEDPort.SelectedIndex = 0
        End If

        If strSetting_MCUPort <> "" Then
            Try
                ComboBoxMCUPort.SelectedValue = strSetting_MCUPort
            Catch ex As Exception
                ComboBoxMCUPort.SelectedIndex = 0
            End Try
        Else
            ComboBoxMCUPort.SelectedIndex = 0
        End If

        If strSetting_Message <> "" Then
            TextBoxMessage.Text = strSetting_Message
        End If

    End Sub

    Private Sub SaveRegistrySettings()

        On Error Resume Next

        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

        Dim appRegKey As RegistryKey
        appRegKey = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, True)

        'Save the response
        appRegKey.SetValue("RunAtStartup", boolStartup, RegistryValueKind.DWord)

        'If boolStartup=true, set to run at startup
        If boolStartup = True Then
            regKey.SetValue(Application.ProductName, Application.ExecutablePath)
        Else
            regKey.DeleteValue(Application.ProductName)
        End If

        strSetting_Color = ComboBoxColor.SelectedItem.ToString
        strSetting_LEDPort = GetComboBox(ComboBoxLEDPort).Key
        strSetting_MCUPort = GetComboBox(ComboBoxMCUPort).Key
        strSetting_Message = TextBoxMessage.Text
        strSetting_Mode = ComboBoxMode.SelectedItem.ToString

        appRegKey.SetValue("Color", strSetting_Color)
        appRegKey.SetValue("LEDPort", strSetting_LEDPort)
        appRegKey.SetValue("MCUPort", strSetting_MCUPort)
        appRegKey.SetValue("Message", strSetting_Message)
        appRegKey.SetValue("Mode", strSetting_Mode)


        regKey.Close()
        appRegKey.Close()

        MsgBox("Settings saved.", MsgBoxStyle.Information)

    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        boolTrayExit = True
        Application.Exit()
    End Sub

    Private Sub SaveSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveSettingsToolStripMenuItem.Click
        SaveRegistrySettings()
    End Sub

    Private Sub RunAtStartupToolStripMenuItemTRAY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunAtStartupToolStripMenuItemTRAY.Click
        boolStartup = RunAtStartupToolStripMenuItemTRAY.Checked
        RunAtStartupToolStripMenuItem.Checked = RunAtStartupToolStripMenuItemTRAY.Checked
        SaveRegistrySettings()
    End Sub
    Private Sub RunAtStartupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunAtStartupToolStripMenuItem.Click
        boolStartup = RunAtStartupToolStripMenuItem.Checked
        RunAtStartupToolStripMenuItemTRAY.Checked = RunAtStartupToolStripMenuItem.Checked
        SaveRegistrySettings()
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.BalloonTipClicked
        ShowMe()
    End Sub

    Private Sub ShowMe()
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        Me.Activate()
        If Me.Location.X < 0 Or Me.Location.Y < 0 Then Me.CenterToScreen()

    End Sub

    Private Sub NotifyIcon1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        If e.Button = MouseButtons.Right Then
            'NotifyIcon1.ContextMenu = ContextMenuIcon
        End If
        If e.Button = MouseButtons.Left Then
            ShowMe()
        End If

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        boolTrayExit = True
        Application.Exit()
    End Sub

    Private Sub Form1_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move

        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.ShowBalloonTip(600, Application.ProductName, "Click to activate", ToolTipIcon.Info)
            Me.ShowInTaskbar = False
            Me.Hide()
        Else
            Me.Show()
        End If
    End Sub

    Private Sub ClearMessageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearMessageToolStripMenuItem.Click
        ClearMessage()
    End Sub

    Private Sub RescanPorts()
        ComboBoxMCUPort.DataSource = Nothing
        ComboBoxLEDPort.DataSource = Nothing

        LoadPortsList()
        ComboBoxMCUPort.DataSource = listPortsMCU
        ComboBoxMCUPort.ValueMember = "Key"
        ComboBoxMCUPort.DisplayMember = "Value"
        ComboBoxMCUPort.SelectedIndex = 0

        ComboBoxLEDPort.DataSource = listPortsLED
        ComboBoxLEDPort.ValueMember = "Key"
        ComboBoxLEDPort.DisplayMember = "Value"
        ComboBoxLEDPort.SelectedIndex = 0
    End Sub

    Private Sub LabelRescan_Click(sender As Object, e As EventArgs) Handles LabelRescan.Click
        RescanPorts()
        LoadRegistrySettings()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim boolConnected As Boolean = False
        Try
            boolConnected = _serialPort_MCU.IsOpen
        Catch ex As Exception
            'Do Nothing
        End Try

        If boolConnected Then
            PanelConnect.BackColor = Color.Green
        Else
            PanelConnect.BackColor = Color.Red
            RescanPorts()
            LoadRegistrySettings()
        End If
    End Sub
End Class
