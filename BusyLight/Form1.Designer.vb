<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LabelLEDPort = New System.Windows.Forms.Label()
        Me.ComboBoxLEDPort = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxMessage = New System.Windows.Forms.TextBox()
        Me.ComboBoxColor = New System.Windows.Forms.ComboBox()
        Me.LabelColor = New System.Windows.Forms.Label()
        Me.ButtonSend = New System.Windows.Forms.Button()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.ComboBoxMode = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxMCUPort = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStripTRAY = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RunAtStartupToolStripMenuItemTRAY = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearMessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunAtStartupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelConnect = New System.Windows.Forms.Panel()
        Me.LabelConnected = New System.Windows.Forms.Label()
        Me.LabelPhone = New System.Windows.Forms.Label()
        Me.PanelOnPhone = New System.Windows.Forms.Panel()
        Me.LabelRescan = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStripTRAY.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelLEDPort
        '
        Me.LabelLEDPort.AutoSize = True
        Me.LabelLEDPort.Location = New System.Drawing.Point(3, 37)
        Me.LabelLEDPort.Name = "LabelLEDPort"
        Me.LabelLEDPort.Size = New System.Drawing.Size(53, 13)
        Me.LabelLEDPort.TabIndex = 0
        Me.LabelLEDPort.Text = "&LED Port:"
        '
        'ComboBoxLEDPort
        '
        Me.ComboBoxLEDPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxLEDPort.FormattingEnabled = True
        Me.ComboBoxLEDPort.Location = New System.Drawing.Point(6, 53)
        Me.ComboBoxLEDPort.Name = "ComboBoxLEDPort"
        Me.ComboBoxLEDPort.Size = New System.Drawing.Size(293, 21)
        Me.ComboBoxLEDPort.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 190)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "&Text to Send:"
        '
        'TextBoxMessage
        '
        Me.TextBoxMessage.Location = New System.Drawing.Point(6, 206)
        Me.TextBoxMessage.Name = "TextBoxMessage"
        Me.TextBoxMessage.Size = New System.Drawing.Size(416, 20)
        Me.TextBoxMessage.TabIndex = 9
        '
        'ComboBoxColor
        '
        Me.ComboBoxColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxColor.FormattingEnabled = True
        Me.ComboBoxColor.Location = New System.Drawing.Point(6, 156)
        Me.ComboBoxColor.Name = "ComboBoxColor"
        Me.ComboBoxColor.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxColor.TabIndex = 5
        '
        'LabelColor
        '
        Me.LabelColor.AutoSize = True
        Me.LabelColor.Location = New System.Drawing.Point(3, 140)
        Me.LabelColor.Name = "LabelColor"
        Me.LabelColor.Size = New System.Drawing.Size(34, 13)
        Me.LabelColor.TabIndex = 4
        Me.LabelColor.Text = "C&olor:"
        '
        'ButtonSend
        '
        Me.ButtonSend.Location = New System.Drawing.Point(6, 244)
        Me.ButtonSend.Name = "ButtonSend"
        Me.ButtonSend.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSend.TabIndex = 11
        Me.ButtonSend.Text = "&Send"
        Me.ButtonSend.UseVisualStyleBackColor = True
        '
        'ButtonClear
        '
        Me.ButtonClear.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonClear.Location = New System.Drawing.Point(87, 244)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClear.TabIndex = 12
        Me.ButtonClear.Text = "&Clear"
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'ComboBoxMode
        '
        Me.ComboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMode.FormattingEnabled = True
        Me.ComboBoxMode.Location = New System.Drawing.Point(144, 156)
        Me.ComboBoxMode.Name = "ComboBoxMode"
        Me.ComboBoxMode.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxMode.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "&Mode:"
        '
        'ComboBoxMCUPort
        '
        Me.ComboBoxMCUPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMCUPort.FormattingEnabled = True
        Me.ComboBoxMCUPort.Location = New System.Drawing.Point(6, 101)
        Me.ComboBoxMCUPort.Name = "ComboBoxMCUPort"
        Me.ComboBoxMCUPort.Size = New System.Drawing.Size(293, 21)
        Me.ComboBoxMCUPort.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "&MCU Port:"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.ShowImageMargin = False
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(83, 26)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(82, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStripTRAY
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStripTRAY
        '
        Me.ContextMenuStripTRAY.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunAtStartupToolStripMenuItemTRAY, Me.ClearMessageToolStripMenuItem, Me.ExitToolStripMenuItem1})
        Me.ContextMenuStripTRAY.Name = "ContextMenuStripTRAY"
        Me.ContextMenuStripTRAY.Size = New System.Drawing.Size(151, 70)
        '
        'RunAtStartupToolStripMenuItemTRAY
        '
        Me.RunAtStartupToolStripMenuItemTRAY.CheckOnClick = True
        Me.RunAtStartupToolStripMenuItemTRAY.Name = "RunAtStartupToolStripMenuItemTRAY"
        Me.RunAtStartupToolStripMenuItemTRAY.Size = New System.Drawing.Size(150, 22)
        Me.RunAtStartupToolStripMenuItemTRAY.Text = "&Run at Startup"
        '
        'ClearMessageToolStripMenuItem
        '
        Me.ClearMessageToolStripMenuItem.Name = "ClearMessageToolStripMenuItem"
        Me.ClearMessageToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ClearMessageToolStripMenuItem.Text = "&Clear Message"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.ExitToolStripMenuItem1.Text = "&Exit"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(437, 24)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveSettingsToolStripMenuItem, Me.RunAtStartupToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'SaveSettingsToolStripMenuItem
        '
        Me.SaveSettingsToolStripMenuItem.Name = "SaveSettingsToolStripMenuItem"
        Me.SaveSettingsToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveSettingsToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SaveSettingsToolStripMenuItem.Text = "&Save Settings"
        '
        'RunAtStartupToolStripMenuItem
        '
        Me.RunAtStartupToolStripMenuItem.CheckOnClick = True
        Me.RunAtStartupToolStripMenuItem.Name = "RunAtStartupToolStripMenuItem"
        Me.RunAtStartupToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.RunAtStartupToolStripMenuItem.Text = "&Run at Startup"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem1.Text = "&About"
        '
        'PanelConnect
        '
        Me.PanelConnect.BackColor = System.Drawing.Color.Red
        Me.PanelConnect.Location = New System.Drawing.Point(328, 53)
        Me.PanelConnect.Name = "PanelConnect"
        Me.PanelConnect.Size = New System.Drawing.Size(36, 21)
        Me.PanelConnect.TabIndex = 18
        '
        'LabelConnected
        '
        Me.LabelConnected.AutoSize = True
        Me.LabelConnected.Location = New System.Drawing.Point(325, 37)
        Me.LabelConnected.Name = "LabelConnected"
        Me.LabelConnected.Size = New System.Drawing.Size(50, 13)
        Me.LabelConnected.TabIndex = 19
        Me.LabelConnected.Text = "Connect:"
        '
        'LabelPhone
        '
        Me.LabelPhone.AutoSize = True
        Me.LabelPhone.Location = New System.Drawing.Point(383, 37)
        Me.LabelPhone.Name = "LabelPhone"
        Me.LabelPhone.Size = New System.Drawing.Size(41, 13)
        Me.LabelPhone.TabIndex = 21
        Me.LabelPhone.Text = "Phone:"
        '
        'PanelOnPhone
        '
        Me.PanelOnPhone.BackColor = System.Drawing.Color.Red
        Me.PanelOnPhone.Location = New System.Drawing.Point(386, 53)
        Me.PanelOnPhone.Name = "PanelOnPhone"
        Me.PanelOnPhone.Size = New System.Drawing.Size(36, 21)
        Me.PanelOnPhone.TabIndex = 20
        '
        'LabelRescan
        '
        Me.LabelRescan.AutoSize = True
        Me.LabelRescan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelRescan.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.LabelRescan.Location = New System.Drawing.Point(305, 104)
        Me.LabelRescan.Name = "LabelRescan"
        Me.LabelRescan.Size = New System.Drawing.Size(44, 13)
        Me.LabelRescan.TabIndex = 22
        Me.LabelRescan.Text = "&Rescan"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'Form1
        '
        Me.AcceptButton = Me.ButtonSend
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonClear
        Me.ClientSize = New System.Drawing.Size(437, 287)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Controls.Add(Me.LabelRescan)
        Me.Controls.Add(Me.LabelPhone)
        Me.Controls.Add(Me.PanelOnPhone)
        Me.Controls.Add(Me.LabelConnected)
        Me.Controls.Add(Me.PanelConnect)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ComboBoxMCUPort)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBoxMode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.ButtonSend)
        Me.Controls.Add(Me.ComboBoxColor)
        Me.Controls.Add(Me.LabelColor)
        Me.Controls.Add(Me.TextBoxMessage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxLEDPort)
        Me.Controls.Add(Me.LabelLEDPort)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(453, 325)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStripTRAY.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelLEDPort As System.Windows.Forms.Label
    Friend WithEvents ComboBoxLEDPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxMessage As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxColor As System.Windows.Forms.ComboBox
    Friend WithEvents LabelColor As System.Windows.Forms.Label
    Friend WithEvents ButtonSend As System.Windows.Forms.Button
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents ComboBoxMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMCUPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunAtStartupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripTRAY As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RunAtStartupToolStripMenuItemTRAY As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelConnect As System.Windows.Forms.Panel
    Friend WithEvents LabelConnected As System.Windows.Forms.Label
    Friend WithEvents LabelPhone As System.Windows.Forms.Label
    Friend WithEvents PanelOnPhone As System.Windows.Forms.Panel
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearMessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelRescan As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
