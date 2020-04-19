<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModalPanel
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
		Me.gTopPanel = New System.Windows.Forms.Panel()
		Me.gHomeButton = New System.Windows.Forms.Button()
		Me.gWebBrowser = New System.Windows.Forms.WebBrowser()
		Me.gTopPanel.SuspendLayout()
		Me.SuspendLayout()
		'
		'gTopPanel
		'
		Me.gTopPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(233, Byte), Integer))
		Me.gTopPanel.Controls.Add(Me.gHomeButton)
		Me.gTopPanel.Dock = System.Windows.Forms.DockStyle.Top
		Me.gTopPanel.Location = New System.Drawing.Point(0, 0)
		Me.gTopPanel.Margin = New System.Windows.Forms.Padding(0)
		Me.gTopPanel.Name = "gTopPanel"
		Me.gTopPanel.Size = New System.Drawing.Size(150, 26)
		Me.gTopPanel.TabIndex = 0
		'
		'gHomeButton
		'
		Me.gHomeButton.BackColor = System.Drawing.Color.Black
		Me.gHomeButton.FlatAppearance.BorderColor = System.Drawing.Color.White
		Me.gHomeButton.FlatAppearance.BorderSize = 0
		Me.gHomeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.gHomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.gHomeButton.Font = New System.Drawing.Font("Segoe UI Symbol", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.gHomeButton.ForeColor = System.Drawing.Color.White
		Me.gHomeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.gHomeButton.Location = New System.Drawing.Point(0, 0)
		Me.gHomeButton.Margin = New System.Windows.Forms.Padding(0)
		Me.gHomeButton.Name = "gHomeButton"
		Me.gHomeButton.Size = New System.Drawing.Size(30, 26)
		Me.gHomeButton.TabIndex = 7
		Me.gHomeButton.Text = "⌂"
		Me.gHomeButton.UseVisualStyleBackColor = False
		'
		'gWebBrowser
		'
		Me.gWebBrowser.AllowWebBrowserDrop = False
		Me.gWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill
		Me.gWebBrowser.Location = New System.Drawing.Point(0, 26)
		Me.gWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
		Me.gWebBrowser.Name = "gWebBrowser"
		Me.gWebBrowser.Size = New System.Drawing.Size(150, 124)
		Me.gWebBrowser.TabIndex = 1
		Me.gWebBrowser.WebBrowserShortcutsEnabled = False
		'
		'ModalPanel
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.gWebBrowser)
		Me.Controls.Add(Me.gTopPanel)
		Me.Name = "ModalPanel"
		Me.gTopPanel.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents gTopPanel As Panel
	Friend WithEvents gWebBrowser As WebBrowser
	Friend WithEvents gHomeButton As Button
End Class
