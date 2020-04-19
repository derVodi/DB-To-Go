<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModalForm
  Inherits System.Windows.Forms.Form

  'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(disposing As Boolean)
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
    Me.SuspendLayout()
    Me.gPanel = New System.Windows.Forms.Panel()
    Me.gOkButton = New System.Windows.Forms.Button()
    Me.gCancelButton = New System.Windows.Forms.Button()
    '
    'gPanel
    '
    Me.gPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gPanel.Location = New System.Drawing.Point(12, 12)
    Me.gPanel.Name = "gPanel"
    Me.gPanel.Size = New System.Drawing.Size(600, 427)
    Me.gPanel.TabIndex = 0
    '
    'gOkButton
    '
    Me.gOkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gOkButton.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.gOkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.gOkButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
    Me.gOkButton.Location = New System.Drawing.Point(456, 445)
    Me.gOkButton.Name = "gOkButton"
    Me.gOkButton.Size = New System.Drawing.Size(75, 23)
    Me.gOkButton.TabIndex = 1
    Me.gOkButton.Text = "&Ok"
    Me.gOkButton.UseVisualStyleBackColor = True
    '
    'gCancelButton
    '
    Me.gCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.gCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.gCancelButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
    Me.gCancelButton.Location = New System.Drawing.Point(537, 445)
    Me.gCancelButton.Name = "gCancelButton"
    Me.gCancelButton.Size = New System.Drawing.Size(75, 23)
    Me.gCancelButton.TabIndex = 2
    Me.gCancelButton.Text = "Cancel"
    Me.gCancelButton.UseVisualStyleBackColor = True
    '
    'ModalForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = ColorsByVodi.Window
    Me.CancelButton = Me.gCancelButton
    Me.ClientSize = New System.Drawing.Size(624, 476)
    Me.Controls.Add(Me.gCancelButton)
    Me.Controls.Add(Me.gOkButton)
    Me.Controls.Add(Me.gPanel)
    Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ForeColor = ColorsByVodi.TextForeground
    Me.Name = "ModalForm"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "<set by code>"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents gPanel As System.Windows.Forms.Panel
  Friend WithEvents gOkButton As System.Windows.Forms.Button
  Friend WithEvents gCancelButton As System.Windows.Forms.Button

End Class
