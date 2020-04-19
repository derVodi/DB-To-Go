<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProgressPanel
	Inherits System.Windows.Forms.UserControl

	'UserControl overrides dispose to clean up the component list.
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

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.gProgressBar = New System.Windows.Forms.ProgressBar()
		Me.gContentPanel = New System.Windows.Forms.FlowLayoutPanel()
		Me.gButtonsPanel = New System.Windows.Forms.FlowLayoutPanel()
		Me.SuspendLayout()
		'
		'gProgressBar
		'
		Me.gProgressBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(233, Byte), Integer))
		Me.gProgressBar.Dock = System.Windows.Forms.DockStyle.Top
		Me.gProgressBar.Location = New System.Drawing.Point(0, 0)
		Me.gProgressBar.Name = "gProgressBar"
		Me.gProgressBar.Size = New System.Drawing.Size(453, 8)
		Me.gProgressBar.TabIndex = 0
		'
		'gContentPanel
		'
		Me.gContentPanel.AutoSize = True
		Me.gContentPanel.BackColor = System.Drawing.Color.White
		Me.gContentPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gContentPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
		Me.gContentPanel.Location = New System.Drawing.Point(0, 8)
		Me.gContentPanel.Name = "gContentPanel"
		Me.gContentPanel.Padding = New System.Windows.Forms.Padding(0, 4, 0, 4)
		Me.gContentPanel.Size = New System.Drawing.Size(453, 185)
		Me.gContentPanel.TabIndex = 1
		'
		'gButtonsPanel
		'
		Me.gButtonsPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(233, Byte), Integer))
		Me.gButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.gButtonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
		Me.gButtonsPanel.Location = New System.Drawing.Point(0, 193)
		Me.gButtonsPanel.Name = "gButtonsPanel"
		Me.gButtonsPanel.Padding = New System.Windows.Forms.Padding(4)
		Me.gButtonsPanel.Size = New System.Drawing.Size(453, 36)
		Me.gButtonsPanel.TabIndex = 0
		'
		'ProgressPanel
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.gContentPanel)
		Me.Controls.Add(Me.gButtonsPanel)
		Me.Controls.Add(Me.gProgressBar)
		Me.Name = "ProgressPanel"
		Me.Size = New System.Drawing.Size(453, 229)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents gProgressBar As ProgressBar
	Friend WithEvents gContentPanel As FlowLayoutPanel
	Friend WithEvents gButtonsPanel As FlowLayoutPanel
End Class
