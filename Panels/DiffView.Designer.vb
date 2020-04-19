<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DiffView
  Inherits System.Windows.Forms.UserControl

  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  Private components As System.ComponentModel.IContainer

  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.gListView = New System.Windows.Forms.ListView()
    Me.gFileColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.gDatabaseColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.gPathColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.gTypeColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
    Me.gPathButton = New System.Windows.Forms.Button()
    Me.gReloadButton = New System.Windows.Forms.Button()
    Me.gFilterChooser = New System.Windows.Forms.ComboBox()
    Me.gFilterLabel = New System.Windows.Forms.Label()
    Me.gPathLabel = New System.Windows.Forms.Label()
    Me.gTypesLabel = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.gCustomPanel = New DbToGo.CustomPanel()
    Me.gIgnorePrefix = New System.Windows.Forms.TextBox()
    Me.gTypes = New System.Windows.Forms.TextBox()
    Me.gPath = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'gListView
    '
    Me.gListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.gFileColumn, Me.gDatabaseColumn, Me.gPathColumn, Me.gTypeColumn})
    Me.gListView.ForeColor = System.Drawing.Color.Black
    Me.gListView.FullRowSelect = True
    Me.gListView.GridLines = True
    Me.gListView.HideSelection = False
    Me.gListView.Location = New System.Drawing.Point(0, 82)
    Me.gListView.MultiSelect = False
    Me.gListView.Name = "gListView"
    Me.gListView.ShowGroups = False
    Me.gListView.Size = New System.Drawing.Size(444, 202)
    Me.gListView.Sorting = System.Windows.Forms.SortOrder.Ascending
    Me.gListView.TabIndex = 1
    Me.gListView.UseCompatibleStateImageBehavior = False
    Me.gListView.View = System.Windows.Forms.View.Details
    '
    'gFileColumn
    '
    Me.gFileColumn.Text = "File"
    Me.gFileColumn.Width = 193
    '
    'gDatabaseColumn
    '
    Me.gDatabaseColumn.Text = "Database"
    Me.gDatabaseColumn.Width = 202
    '
    'gPathColumn
    '
    Me.gPathColumn.Text = "Path"
    '
    'gTypeColumn
    '
    Me.gTypeColumn.Text = "Type"
    '
    'gPathButton
    '
    Me.gPathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gPathButton.Location = New System.Drawing.Point(414, 0)
    Me.gPathButton.Margin = New System.Windows.Forms.Padding(0)
    Me.gPathButton.Name = "gPathButton"
    Me.gPathButton.Size = New System.Drawing.Size(30, 23)
    Me.gPathButton.TabIndex = 4
    Me.gPathButton.Text = "..."
    '
    'gReloadButton
    '
    Me.gReloadButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gReloadButton.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.gReloadButton.Location = New System.Drawing.Point(384, 0)
    Me.gReloadButton.Margin = New System.Windows.Forms.Padding(0)
    Me.gReloadButton.Name = "gReloadButton"
    Me.gReloadButton.Size = New System.Drawing.Size(30, 23)
    Me.gReloadButton.TabIndex = 5
    Me.gReloadButton.Text = "↺"
    'gFilterChooser
    '
    Me.gFilterChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.gFilterChooser.FormattingEnabled = True
    Me.gFilterChooser.Location = New System.Drawing.Point(36, 25)
    Me.gFilterChooser.Name = "gFilterChooser"
    Me.gFilterChooser.Size = New System.Drawing.Size(121, 21)
    Me.gFilterChooser.TabIndex = 6
    '
    'gFilterLabel
    '
    Me.gFilterLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
    Me.gFilterLabel.Location = New System.Drawing.Point(0, 26)
    Me.gFilterLabel.Name = "gFilterLabel"
    Me.gFilterLabel.Size = New System.Drawing.Size(30, 13)
    Me.gFilterLabel.TabIndex = 7
    Me.gFilterLabel.Text = "View"
    '
    'gPathLabel
    '
    Me.gPathLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
    Me.gPathLabel.Location = New System.Drawing.Point(0, 3)
    Me.gPathLabel.Name = "gPathLabel"
    Me.gPathLabel.Size = New System.Drawing.Size(30, 13)
    Me.gPathLabel.TabIndex = 7
    Me.gPathLabel.Text = "Files"
    '
    'gTypesLabel
    '
    Me.gTypesLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.gTypesLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
    Me.gTypesLabel.Location = New System.Drawing.Point(0, 290)
    Me.gTypesLabel.Margin = New System.Windows.Forms.Padding(0)
    Me.gTypesLabel.Name = "gTypesLabel"
    Me.gTypesLabel.Size = New System.Drawing.Size(42, 13)
    Me.gTypesLabel.TabIndex = 7
    Me.gTypesLabel.Text = "Types"
    '
    'Label1
    '
    Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
    Me.Label1.Location = New System.Drawing.Point(363, 290)
    Me.Label1.Margin = New System.Windows.Forms.Padding(0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(42, 13)
    Me.Label1.TabIndex = 7
    Me.Label1.Text = "Ignore"
    '
    'gCustomPanel
    '
    Me.gCustomPanel.IniSection = "CompareCustomTools"
    Me.gCustomPanel.Location = New System.Drawing.Point(0, 49)
    Me.gCustomPanel.Name = "gCustomPanel"
    Me.gCustomPanel.PlaceholderResolver = Nothing
    Me.gCustomPanel.Size = New System.Drawing.Size(400, 28)
    Me.gCustomPanel.TabIndex = 2
    '
    'gIgnorePrefix
    '
    Me.gIgnorePrefix.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gIgnorePrefix.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.DbToGo.Settings.Default, "IgnorePrefix", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.gIgnorePrefix.HideSelection = False
    Me.gIgnorePrefix.Location = New System.Drawing.Point(414, 287)
    Me.gIgnorePrefix.Margin = New System.Windows.Forms.Padding(0)
    Me.gIgnorePrefix.Name = "gIgnorePrefix"
    Me.gIgnorePrefix.Size = New System.Drawing.Size(30, 21)
    Me.gIgnorePrefix.TabIndex = 3
    Me.gIgnorePrefix.Text = Global.DbToGo.Settings.Default.IgnorePrefix
    Me.gIgnorePrefix.WordWrap = False
    '
    'gTypes
    '
    Me.gTypes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gTypes.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.DbToGo.Settings.Default, "ReferenceTypes", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.gTypes.HideSelection = False
    Me.gTypes.Location = New System.Drawing.Point(48, 287)
    Me.gTypes.Margin = New System.Windows.Forms.Padding(0)
    Me.gTypes.Name = "gTypes"
    Me.gTypes.Size = New System.Drawing.Size(305, 21)
    Me.gTypes.TabIndex = 3
    Me.gTypes.Text = Global.DbToGo.Settings.Default.ReferenceTypes
    Me.gTypes.WordWrap = False
    '
    'gPath
    '
    Me.gPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gPath.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.DbToGo.Settings.Default, "ReferencePath", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.gPath.HideSelection = False
    Me.gPath.Location = New System.Drawing.Point(36, 0)
    Me.gPath.Margin = New System.Windows.Forms.Padding(0)
    Me.gPath.Name = "gPath"
    Me.gPath.Size = New System.Drawing.Size(348, 21)
    Me.gPath.TabIndex = 3
    Me.gPath.Text = Global.DbToGo.Settings.Default.ReferencePath
    Me.gPath.WordWrap = False
    '
    'DiffView
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(16, Byte), Integer))
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.gTypesLabel)
    Me.Controls.Add(Me.gPathLabel)
    Me.Controls.Add(Me.gFilterLabel)
    Me.Controls.Add(Me.gFilterChooser)
    Me.Controls.Add(Me.gReloadButton)
    Me.Controls.Add(Me.gPathButton)
    Me.Controls.Add(Me.gIgnorePrefix)
    Me.Controls.Add(Me.gTypes)
    Me.Controls.Add(Me.gPath)
    Me.Controls.Add(Me.gCustomPanel)
    Me.Controls.Add(Me.gListView)
    Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "DiffView"
    Me.Size = New System.Drawing.Size(444, 308)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents gListView As System.Windows.Forms.ListView
  Friend WithEvents gCustomPanel As DbToGo.CustomPanel
  Friend WithEvents gPath As System.Windows.Forms.TextBox
  Friend WithEvents gPathButton As System.Windows.Forms.Button
  Friend WithEvents gReloadButton As System.Windows.Forms.Button
  Friend WithEvents gFileColumn As System.Windows.Forms.ColumnHeader
  Friend WithEvents gDatabaseColumn As System.Windows.Forms.ColumnHeader
  Friend WithEvents gFilterChooser As System.Windows.Forms.ComboBox
  Friend WithEvents gFilterLabel As System.Windows.Forms.Label
  Friend WithEvents gTypes As System.Windows.Forms.TextBox
  Friend WithEvents gPathLabel As System.Windows.Forms.Label
  Friend WithEvents gTypesLabel As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents gIgnorePrefix As System.Windows.Forms.TextBox
  Friend WithEvents gPathColumn As System.Windows.Forms.ColumnHeader
  Friend WithEvents gTypeColumn As System.Windows.Forms.ColumnHeader

End Class
