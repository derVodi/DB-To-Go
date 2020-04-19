<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagChooser
	Inherits System.Windows.Forms.UserControl

	'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

	'Wird vom Windows Form-Designer benötigt.
	Private components As System.ComponentModel.IContainer

	'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
	'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
	'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.gAssignedAttributes = New System.Windows.Forms.DataGridView()
		Me.gTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
		Me.gTypeNameTextBox = New System.Windows.Forms.TextBox()
		Me.gValueTextBox = New System.Windows.Forms.TextBox()
		Me.gButtonsPanel = New System.Windows.Forms.TableLayoutPanel()
		Me.gAssignButton = New System.Windows.Forms.Button()
		Me.gRemoveButton = New System.Windows.Forms.Button()
		Me.gTypeNames = New DbToGo.ListBoxPimped()
		Me.gOfferedValues = New DbToGo.ListBoxPimped()
		CType(Me.gAssignedAttributes, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.gTableLayoutPanel.SuspendLayout()
		Me.gButtonsPanel.SuspendLayout()
		Me.SuspendLayout()
		'
		'gAttribsOfOneFile
		'
		Me.gAssignedAttributes.AllowUserToAddRows = False
		Me.gAssignedAttributes.AllowUserToResizeColumns = False
		Me.gAssignedAttributes.AllowUserToResizeRows = False
		Me.gAssignedAttributes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
		Me.gAssignedAttributes.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
		Me.gAssignedAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.gAssignedAttributes.ColumnHeadersVisible = False
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.gAssignedAttributes.DefaultCellStyle = DataGridViewCellStyle1
		Me.gAssignedAttributes.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gAssignedAttributes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
		Me.gAssignedAttributes.Location = New System.Drawing.Point(486, 23)
		Me.gAssignedAttributes.Margin = New System.Windows.Forms.Padding(2, 0, 0, 0)
		Me.gAssignedAttributes.Name = "gAttribsOfOneFile"
		Me.gAssignedAttributes.RowHeadersVisible = False
		Me.gAssignedAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.gAssignedAttributes.Size = New System.Drawing.Size(241, 411)
		Me.gAssignedAttributes.TabIndex = 9
		'
		'gTableLayoutPanel
		'
		Me.gTableLayoutPanel.ColumnCount = 3
		Me.gTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
		Me.gTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
		Me.gTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
		Me.gTableLayoutPanel.Controls.Add(Me.gTypeNameTextBox, 0, 0)
		Me.gTableLayoutPanel.Controls.Add(Me.gValueTextBox, 1, 0)
		Me.gTableLayoutPanel.Controls.Add(Me.gButtonsPanel, 2, 0)
		Me.gTableLayoutPanel.Controls.Add(Me.gTypeNames, 0, 1)
		Me.gTableLayoutPanel.Controls.Add(Me.gOfferedValues, 1, 1)
		Me.gTableLayoutPanel.Controls.Add(Me.gAssignedAttributes, 2, 1)
		Me.gTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
		Me.gTableLayoutPanel.Margin = New System.Windows.Forms.Padding(0)
		Me.gTableLayoutPanel.Name = "gTableLayoutPanel"
		Me.gTableLayoutPanel.RowCount = 2
		Me.gTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
		Me.gTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.gTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
		Me.gTableLayoutPanel.Size = New System.Drawing.Size(727, 434)
		Me.gTableLayoutPanel.TabIndex = 1
		'
		'gTypeNameTextBox
		'
		Me.gTypeNameTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
		Me.gTypeNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.gTypeNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gTypeNameTextBox.ForeColor = System.Drawing.Color.White
		Me.gTypeNameTextBox.Location = New System.Drawing.Point(0, 0)
		Me.gTypeNameTextBox.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
		Me.gTypeNameTextBox.Name = "gTypeNameTextBox"
		Me.gTypeNameTextBox.Size = New System.Drawing.Size(240, 21)
		Me.gTypeNameTextBox.TabIndex = 2
		'
		'gValueTextBox
		'
		Me.gValueTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
		Me.gValueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.gValueTextBox.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gValueTextBox.ForeColor = System.Drawing.Color.White
		Me.gValueTextBox.Location = New System.Drawing.Point(244, 0)
		Me.gValueTextBox.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.gValueTextBox.Name = "gValueTextBox"
		Me.gValueTextBox.Size = New System.Drawing.Size(238, 21)
		Me.gValueTextBox.TabIndex = 3
		'
		'gButtonsPanel
		'
		Me.gButtonsPanel.ColumnCount = 2
		Me.gButtonsPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.gButtonsPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.gButtonsPanel.Controls.Add(Me.gAssignButton, 0, 0)
		Me.gButtonsPanel.Controls.Add(Me.gRemoveButton, 1, 0)
		Me.gButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gButtonsPanel.Location = New System.Drawing.Point(484, 0)
		Me.gButtonsPanel.Margin = New System.Windows.Forms.Padding(0)
		Me.gButtonsPanel.Name = "gButtonsPanel"
		Me.gButtonsPanel.RowCount = 1
		Me.gButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.gButtonsPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.gButtonsPanel.Size = New System.Drawing.Size(243, 23)
		Me.gButtonsPanel.TabIndex = 7
		'
		'gAssignButton
		'
		Me.gAssignButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
		Me.gAssignButton.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gAssignButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.gAssignButton.ForeColor = System.Drawing.Color.White
		Me.gAssignButton.Location = New System.Drawing.Point(0, 0)
		Me.gAssignButton.Margin = New System.Windows.Forms.Padding(0)
		Me.gAssignButton.Name = "gAssignButton"
		Me.gAssignButton.Size = New System.Drawing.Size(121, 23)
		Me.gAssignButton.TabIndex = 5
		Me.gAssignButton.Text = "Assign"
		Me.gAssignButton.UseVisualStyleBackColor = False
		'
		'gRemoveButton
		'
		Me.gRemoveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
		Me.gRemoveButton.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gRemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.gRemoveButton.ForeColor = System.Drawing.Color.White
		Me.gRemoveButton.Location = New System.Drawing.Point(121, 0)
		Me.gRemoveButton.Margin = New System.Windows.Forms.Padding(0)
		Me.gRemoveButton.Name = "gRemoveButton"
		Me.gRemoveButton.Size = New System.Drawing.Size(122, 23)
		Me.gRemoveButton.TabIndex = 6
		Me.gRemoveButton.Text = "Remove"
		Me.gRemoveButton.UseVisualStyleBackColor = False
		'
		'gTypeNames
		'
		Me.gTypeNames.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
		Me.gTypeNames.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.gTypeNames.Datasource = Nothing
		Me.gTypeNames.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gTypeNames.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.gTypeNames.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.gTypeNames.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
		Me.gTypeNames.FormattingEnabled = True
		Me.gTypeNames.Location = New System.Drawing.Point(0, 23)
		Me.gTypeNames.Margin = New System.Windows.Forms.Padding(0, 0, 2, 0)
		Me.gTypeNames.Name = "gTypeNames"
		Me.gTypeNames.Size = New System.Drawing.Size(240, 411)
		Me.gTypeNames.TabIndex = 7
		'
		'gValuesOfCurrentType
		'
		Me.gOfferedValues.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
		Me.gOfferedValues.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.gOfferedValues.Datasource = Nothing
		Me.gOfferedValues.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gOfferedValues.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.gOfferedValues.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
		Me.gOfferedValues.FormattingEnabled = True
		Me.gOfferedValues.Location = New System.Drawing.Point(244, 23)
		Me.gOfferedValues.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
		Me.gOfferedValues.Name = "gValuesOfCurrentType"
		Me.gOfferedValues.Size = New System.Drawing.Size(238, 411)
		Me.gOfferedValues.TabIndex = 8
		'
		'TagChooser
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Transparent
		Me.Controls.Add(Me.gTableLayoutPanel)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Margin = New System.Windows.Forms.Padding(0)
		Me.Name = "TagChooser"
		Me.Size = New System.Drawing.Size(727, 434)
		CType(Me.gAssignedAttributes, System.ComponentModel.ISupportInitialize).EndInit()
		Me.gTableLayoutPanel.ResumeLayout(False)
		Me.gTableLayoutPanel.PerformLayout()
		Me.gButtonsPanel.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents gAssignedAttributes As System.Windows.Forms.DataGridView
	Friend WithEvents gTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents gTypeNames As ListBoxPimped
	Friend WithEvents gOfferedValues As DbToGo.ListBoxPimped
	Friend WithEvents gTypeNameTextBox As System.Windows.Forms.TextBox
	Friend WithEvents gValueTextBox As System.Windows.Forms.TextBox
	Friend WithEvents gAssignButton As System.Windows.Forms.Button
	Friend WithEvents gButtonsPanel As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents gRemoveButton As System.Windows.Forms.Button

End Class
