<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainPanel
	Inherits System.Windows.Forms.UserControl

	'UserControl overrides dispose to clean up the component list.
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
    Me.gSearch = New System.Windows.Forms.ComboBox()
    Me.gTopPanel = New System.Windows.Forms.Panel()
    Me.gMenuButton = New System.Windows.Forms.Button()
    Me.gStructure = New System.Windows.Forms.ComboBox()
    Me.gCustomPanel = New DbToGo.CustomPanel()
    Me.gSyncPicture = New System.Windows.Forms.PictureBox()
    Me.gMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.gCompareMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.gAboutMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
    Me.gTreeVsThumbs = New System.Windows.Forms.SplitContainer()
    Me.gNavTree = New DbToGo.NavTree()
    Me.gThumbsVsProperties = New System.Windows.Forms.SplitContainer()
    Me.gThumbsPanel = New DbToGo.ThumbsPanel()
    Me.gProperties = New DbToGo.PropertiesPanel()
    Me.gBackgroundWorker = New System.ComponentModel.BackgroundWorker()
    Me.gTimer = New System.Windows.Forms.Timer(Me.components)
    Me.gTopPanel.SuspendLayout()
    CType(Me.gSyncPicture, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gMenu.SuspendLayout()
    CType(Me.gTreeVsThumbs, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gTreeVsThumbs.Panel1.SuspendLayout()
    Me.gTreeVsThumbs.Panel2.SuspendLayout()
    Me.gTreeVsThumbs.SuspendLayout()
    CType(Me.gThumbsVsProperties, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gThumbsVsProperties.Panel1.SuspendLayout()
    Me.gThumbsVsProperties.Panel2.SuspendLayout()
    Me.gThumbsVsProperties.SuspendLayout()
    Me.SuspendLayout()
    '
    'gSearch
    '
    Me.gSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gSearch.FormattingEnabled = True
    Me.gSearch.Location = New System.Drawing.Point(880, 5)
    Me.gSearch.Name = "gSearch"
    Me.gSearch.Size = New System.Drawing.Size(207, 25)
    Me.gSearch.TabIndex = 1
    '
    'gTopPanel
    '
    Me.gTopPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gTopPanel.BackColor = ColorsByVodi.ToolStrips
    Me.gTopPanel.Controls.Add(Me.gMenuButton)
    Me.gTopPanel.Controls.Add(Me.gStructure)
    Me.gTopPanel.Controls.Add(Me.gCustomPanel)
    Me.gTopPanel.Controls.Add(Me.gSearch)
    Me.gTopPanel.Controls.Add(Me.gSyncPicture)
    Me.gTopPanel.ForeColor = ColorsByVodi.TextForeground
    Me.gTopPanel.Location = New System.Drawing.Point(0, 0)
    Me.gTopPanel.Margin = New System.Windows.Forms.Padding(0)
    Me.gTopPanel.Name = "gTopPanel"
    Me.gTopPanel.Size = New System.Drawing.Size(1154, 36)
    Me.gTopPanel.TabIndex = 1
    '
    'gMenuButton
    '
    Me.gMenuButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gMenuButton.FlatAppearance.BorderSize = 0
    Me.gMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.gMenuButton.Font = New System.Drawing.Font("Segoe UI", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.gMenuButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.gMenuButton.Location = New System.Drawing.Point(1122, 2)
    Me.gMenuButton.Name = "gMenuButton"
    Me.gMenuButton.Size = New System.Drawing.Size(29, 29)
    Me.gMenuButton.TabIndex = 3
    Me.gMenuButton.Text = "☰"
    '
    'gStructure
    '
    Me.gStructure.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.DbToGo.Settings.Default, "StructurePath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.gStructure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.gStructure.FormattingEnabled = True
    Me.gStructure.IntegralHeight = False
    Me.gStructure.ItemHeight = 17
    Me.gStructure.Location = New System.Drawing.Point(7, 5)
    Me.gStructure.Name = "gStructure"
    Me.gStructure.Size = New System.Drawing.Size(152, 25)
    Me.gStructure.TabIndex = 0
    Me.gStructure.Text = Global.DbToGo.Settings.Default.StructurePath
    '
    'gCustomPanel
    '
    Me.gCustomPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gCustomPanel.IniSection = "MainCustomTools"
    Me.gCustomPanel.Location = New System.Drawing.Point(168, 0)
    Me.gCustomPanel.Margin = New System.Windows.Forms.Padding(0)
    Me.gCustomPanel.Name = "gCustomPanel"
    Me.gCustomPanel.PlaceholderResolver = Nothing
    Me.gCustomPanel.Size = New System.Drawing.Size(675, 36)
    Me.gCustomPanel.TabIndex = 2
    '
    'gSyncPicture
    '
    Me.gSyncPicture.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gSyncPicture.Location = New System.Drawing.Point(1096, 9)
    Me.gSyncPicture.Name = "gSyncPicture"
    Me.gSyncPicture.Size = New System.Drawing.Size(19, 20)
    Me.gSyncPicture.TabIndex = 1
    Me.gSyncPicture.TabStop = False
    '
    'gMenu
    '
    Me.gMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
    Me.gMenu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.gMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.gCompareMenuItem, Me.ToolStripSeparator1, Me.gAboutMenuItem, Me.ToolStripMenuItem2})
    Me.gMenu.Name = "gStructureContextMenu"
    Me.gMenu.ShowImageMargin = False
    Me.gMenu.Size = New System.Drawing.Size(243, 76)
    '
    'gCompareMenuItem
    '
    Me.gCompareMenuItem.Name = "gCompareMenuItem"
    Me.gCompareMenuItem.Size = New System.Drawing.Size(242, 22)
    Me.gCompareMenuItem.Tag = "Main.Compare"
    Me.gCompareMenuItem.Text = "≠ Compare Against File Names..."
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(239, 6)
    '
    'gAboutMenuItem
    '
    Me.gAboutMenuItem.Name = "gAboutMenuItem"
    Me.gAboutMenuItem.Size = New System.Drawing.Size(242, 22)
    Me.gAboutMenuItem.Tag = "Main.About"
    Me.gAboutMenuItem.Text = "🛈 About..."
    '
    'ToolStripMenuItem2
    '
    Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
    Me.ToolStripMenuItem2.Size = New System.Drawing.Size(242, 22)
    Me.ToolStripMenuItem2.Tag = "Updater.CheckForUpdate"
    Me.ToolStripMenuItem2.Text = "📡 Update..."
    '
    'gTreeVsThumbs
    '
    Me.gTreeVsThumbs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gTreeVsThumbs.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.gTreeVsThumbs.Location = New System.Drawing.Point(0, 41)
    Me.gTreeVsThumbs.Name = "gTreeVsThumbs"
    '
    'gTreeVsThumbs.Panel1
    '
    Me.gTreeVsThumbs.Panel1.Controls.Add(Me.gNavTree)
    '
    'gTreeVsThumbs.Panel2
    '
    Me.gTreeVsThumbs.Panel2.Controls.Add(Me.gThumbsVsProperties)
    Me.gTreeVsThumbs.Size = New System.Drawing.Size(1150, 810)
    Me.gTreeVsThumbs.SplitterDistance = 130
    Me.gTreeVsThumbs.SplitterWidth = 10
    Me.gTreeVsThumbs.TabIndex = 2
    '
    'gNavTree
    '
    'Me.gNavTree.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.gNavTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.gNavTree.Dock = System.Windows.Forms.DockStyle.Fill
    Me.gNavTree.ForeColor = System.Drawing.Color.Black
    Me.gNavTree.HideSelection = False
    Me.gNavTree.Location = New System.Drawing.Point(0, 0)
    Me.gNavTree.Mode = DbToGo.NavTree.NavTreeMode.Tags
    Me.gNavTree.Name = "gNavTree"
    Me.gNavTree.Size = New System.Drawing.Size(130, 810)
    Me.gNavTree.TabIndex = 1
    '
    'gThumbsVsProperties
    '
    Me.gThumbsVsProperties.Dock = System.Windows.Forms.DockStyle.Fill
    Me.gThumbsVsProperties.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
    Me.gThumbsVsProperties.Location = New System.Drawing.Point(0, 0)
    Me.gThumbsVsProperties.Name = "gThumbsVsProperties"
    '
    'gThumbsVsProperties.Panel1
    '
    Me.gThumbsVsProperties.Panel1.Controls.Add(Me.gThumbsPanel)
    '
    'gThumbsVsProperties.Panel2
    '
    Me.gThumbsVsProperties.Panel2.Controls.Add(Me.gProperties)
    Me.gThumbsVsProperties.Panel2MinSize = 150
    Me.gThumbsVsProperties.Size = New System.Drawing.Size(1010, 810)
    Me.gThumbsVsProperties.SplitterDistance = 788
    Me.gThumbsVsProperties.SplitterWidth = 10
    Me.gThumbsVsProperties.TabIndex = 0
    '
    'gThumbsPanel
    '
    Me.gThumbsPanel.AutoScroll = True
    Me.gThumbsPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.gThumbsPanel.Dock = System.Windows.Forms.DockStyle.Fill
    Me.gThumbsPanel.Location = New System.Drawing.Point(0, 0)
    Me.gThumbsPanel.Name = "gThumbsPanel"
    Me.gThumbsPanel.Size = New System.Drawing.Size(788, 810)
    Me.gThumbsPanel.TabIndex = 0
    Me.gThumbsPanel.TabStop = True
    '
    'gProperties
    '
    Me.gProperties.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.gProperties.Dock = System.Windows.Forms.DockStyle.Fill
    Me.gProperties.FileName = ".jpg"
    Me.gProperties.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.gProperties.Location = New System.Drawing.Point(0, 0)
    Me.gProperties.Name = "gProperties"
    Me.gProperties.Padding = New System.Windows.Forms.Padding(2)
    Me.gProperties.Size = New System.Drawing.Size(212, 810)
    Me.gProperties.TabIndex = 0
    '
    'gBackgroundWorker
    '
    '
    'gTimer
    '
    Me.gTimer.Interval = 750
    '
    'MainPanel
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.gTopPanel)
    Me.Controls.Add(Me.gTreeVsThumbs)
    Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "MainPanel"
    Me.Size = New System.Drawing.Size(1154, 851)
    Me.gTopPanel.ResumeLayout(False)
    CType(Me.gSyncPicture, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gMenu.ResumeLayout(False)
    Me.gTreeVsThumbs.Panel1.ResumeLayout(False)
    Me.gTreeVsThumbs.Panel2.ResumeLayout(False)
    CType(Me.gTreeVsThumbs, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gTreeVsThumbs.ResumeLayout(False)
    Me.gThumbsVsProperties.Panel1.ResumeLayout(False)
    Me.gThumbsVsProperties.Panel2.ResumeLayout(False)
    CType(Me.gThumbsVsProperties, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gThumbsVsProperties.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents gThumbsPanel As ThumbsPanel
	Friend WithEvents gSearch As ComboBox
	Friend WithEvents gTopPanel As Panel
	Friend WithEvents gStructure As ComboBox
	Friend WithEvents gMenu As ContextMenuStrip
	Friend WithEvents gCompareMenuItem As ToolStripMenuItem
	Friend WithEvents gCustomPanel As CustomPanel
	Friend WithEvents gSyncPicture As PictureBox
	Private WithEvents gTreeVsThumbs As SplitContainer
	Friend WithEvents gNavTree As NavTree
	Friend WithEvents gThumbsVsProperties As SplitContainer
	Friend WithEvents gProperties As PropertiesPanel
	Friend WithEvents gBackgroundWorker As System.ComponentModel.BackgroundWorker
	Friend WithEvents gTimer As Timer
	Friend WithEvents gMenuButton As Button
	Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
	Friend WithEvents gAboutMenuItem As ToolStripMenuItem
	Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
End Class
