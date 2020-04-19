Partial Class MainForm
	Inherits System.Windows.Forms.Form

	Private components As System.ComponentModel.IContainer

	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	Private Sub InitializeComponent()
		Me.SuspendLayout()
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = ColorsByVodi.Window
		Me.ForeColor = ColorsByVodi.TextForeground
		Me.ClientSize = New System.Drawing.Size(1066, 677)
		Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.KeyPreview = True
		Me.Name = "MainForm"
		Me.Padding = New System.Windows.Forms.Padding(3)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "db-to-go"
		Me.ResumeLayout(False)

	End Sub

End Class
