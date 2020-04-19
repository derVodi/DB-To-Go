<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropertiesPanel
	Inherits System.Windows.Forms.UserControl

	'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

	'Wird vom Windows Form-Designer benötigt.
	Private components As System.ComponentModel.IContainer

	'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
	'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
	'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.gFileName = New System.Windows.Forms.Label()
		Me.gTags = New System.Windows.Forms.DataGridView()
		Me.gLinkedPath = New System.Windows.Forms.Label()
		Me.gLinkedSize = New System.Windows.Forms.Label()
		Me.gLinkedDate = New System.Windows.Forms.Label()
		CType(Me.gTags, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'gFileName
		'
		Me.gFileName.AutoSize = True
		Me.gFileName.BackColor = System.Drawing.Color.Transparent
		Me.gFileName.Dock = System.Windows.Forms.DockStyle.Top
		Me.gFileName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.gFileName.ForeColor = System.Drawing.Color.Black
		Me.gFileName.Location = New System.Drawing.Point(2, 2)
		Me.gFileName.Margin = New System.Windows.Forms.Padding(0)
		Me.gFileName.Name = "gFileName"
		Me.gFileName.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
		Me.gFileName.Size = New System.Drawing.Size(0, 21)
		Me.gFileName.TabIndex = 2
		Me.gFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'gTags
		'
		Me.gTags.AllowUserToAddRows = False
		Me.gTags.AllowUserToDeleteRows = False
		Me.gTags.AllowUserToResizeColumns = False
		Me.gTags.AllowUserToResizeRows = False
		Me.gTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
		Me.gTags.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.gTags.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.gTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.gTags.ColumnHeadersVisible = False
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer))
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.gTags.DefaultCellStyle = DataGridViewCellStyle1
		Me.gTags.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gTags.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
		Me.gTags.GridColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
		Me.gTags.Location = New System.Drawing.Point(2, 70)
		Me.gTags.MultiSelect = False
		Me.gTags.Name = "gTags"
		Me.gTags.RowHeadersVisible = False
		Me.gTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.gTags.Size = New System.Drawing.Size(146, 78)
		Me.gTags.TabIndex = 3
		'
		'gLinkedPath
		'
		Me.gLinkedPath.AutoSize = True
		Me.gLinkedPath.BackColor = System.Drawing.Color.Transparent
		Me.gLinkedPath.Dock = System.Windows.Forms.DockStyle.Top
		Me.gLinkedPath.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.gLinkedPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
		Me.gLinkedPath.Location = New System.Drawing.Point(2, 23)
		Me.gLinkedPath.Name = "gLinkedPath"
		Me.gLinkedPath.Padding = New System.Windows.Forms.Padding(0, 1, 0, 1)
		Me.gLinkedPath.Size = New System.Drawing.Size(0, 15)
		Me.gLinkedPath.TabIndex = 4
		Me.gLinkedPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'gLinkedSize
		'
		Me.gLinkedSize.AutoSize = True
		Me.gLinkedSize.BackColor = System.Drawing.Color.Transparent
		Me.gLinkedSize.Dock = System.Windows.Forms.DockStyle.Top
		Me.gLinkedSize.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.gLinkedSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
		Me.gLinkedSize.Location = New System.Drawing.Point(2, 38)
		Me.gLinkedSize.Name = "gLinkedSize"
		Me.gLinkedSize.Padding = New System.Windows.Forms.Padding(0, 1, 0, 1)
		Me.gLinkedSize.Size = New System.Drawing.Size(0, 15)
		Me.gLinkedSize.TabIndex = 5
		Me.gLinkedSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'gLinkedDate
		'
		Me.gLinkedDate.AutoSize = True
		Me.gLinkedDate.BackColor = System.Drawing.Color.Transparent
		Me.gLinkedDate.Dock = System.Windows.Forms.DockStyle.Top
		Me.gLinkedDate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.gLinkedDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
		Me.gLinkedDate.Location = New System.Drawing.Point(2, 53)
		Me.gLinkedDate.Name = "gLinkedDate"
		Me.gLinkedDate.Padding = New System.Windows.Forms.Padding(0, 1, 0, 3)
		Me.gLinkedDate.Size = New System.Drawing.Size(0, 17)
		Me.gLinkedDate.TabIndex = 6
		Me.gLinkedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'PropertiesPanel
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.Transparent
		Me.Controls.Add(Me.gTags)
		Me.Controls.Add(Me.gLinkedDate)
		Me.Controls.Add(Me.gLinkedSize)
		Me.Controls.Add(Me.gLinkedPath)
		Me.Controls.Add(Me.gFileName)
		Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Name = "PropertiesPanel"
		Me.Padding = New System.Windows.Forms.Padding(2)
		CType(Me.gTags, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents gFileName As System.Windows.Forms.Label
	Friend WithEvents gTags As DataGridView
	Friend WithEvents gLinkedPath As System.Windows.Forms.Label
	Friend WithEvents gLinkedSize As System.Windows.Forms.Label
	Friend WithEvents gLinkedDate As System.Windows.Forms.Label

End Class
