Imports System.Threading

Public Class ProgressPanel

	Private _StepTextOriginals As List(Of String)

	Private ReadOnly Property StepTextOriginals As List(Of String)
		Get
			If (_StepTextOriginals Is Nothing) Then
				_StepTextOriginals = New List(Of String)
			End If
			Return _StepTextOriginals
		End Get
	End Property

	Public Sub AddStep(text As String)
		StepTextOriginals.Add(text)
		Dim label As Control
		label = New Label With {.Text = "· " + text, .AutoSize = True, .Padding = New Padding(2), .ForeColor = Color.Gray}
		gContentPanel.Controls.Add(label)
	End Sub

	Public Sub AddButton(text As String, enabled As Boolean, clickAction As Action)
		Dim b As New Button With {.Text = text, .AutoSize = True, .Enabled = enabled, .BackColor = Color.LightGray, .FlatStyle = FlatStyle.Flat}
		AddHandler b.Click, Sub(sender As Object, e As EventArgs) clickAction.Invoke()
		gButtonsPanel.Controls.Add(b)
	End Sub

	Public Property EnableStateOfButton(index As Integer) As Boolean
		Get
			Return gButtonsPanel.Controls(index).Enabled
		End Get
		Set(value As Boolean)
			gButtonsPanel.Controls(index).Enabled = value
		End Set
	End Property

	Public Sub FocusOnButton(index As Integer)
		gButtonsPanel.Controls(index).Focus()
	End Sub

	Private _ActiveStepIndex As Integer = -1

	Public Sub StepForward()

		Value = 0

		If (_ActiveStepIndex >= 0) Then
			SetLabelTextForActiveStep(StepStateValue.Succeeded)
		End If
		_ActiveStepIndex += 1
		If (_ActiveStepIndex >= _StepTextOriginals.Count) Then
			Exit Sub
		End If

		Debug.WriteLine("StepForward: " + gContentPanel.Controls(_ActiveStepIndex).Text)

		SetLabelTextForActiveStep(StepStateValue.Processing)

		If (DebugHelper.SlowMotionDelay > 0) Then
			Thread.Sleep(DebugHelper.SlowMotionDelay)
		End If

	End Sub

	Private Sub SetLabelTextForActiveStep(state As StepStateValue, Optional description As String = Nothing)
		Dim suffix As String = Nothing
		Dim color As Color
		Select Case state
			Case StepStateValue.Processing
				suffix = " ←" + description
				color = Color.Black
			Case StepStateValue.Succeeded
				suffix = " ✔" + description

			Case StepStateValue.Failed
				suffix = " 🅧" + description '⮿
				color = Color.Red
		End Select
		gContentPanel.Controls(_ActiveStepIndex).ForeColor = color
		gContentPanel.Controls(_ActiveStepIndex).Text = "· " + StepTextOriginals(_ActiveStepIndex) + suffix
		Application.DoEvents()
	End Sub

	Public Enum StepStateValue As Integer
		None
		Processing
		Succeeded
		Failed
	End Enum

	Public Sub SetErrorTextForActiveStep(text As String)
		SetLabelTextForActiveStep(StepStateValue.Failed, Environment.NewLine + "ERROR: " + text)
	End Sub

	Public Property Maximum As Integer
		Get
			Return gProgressBar.Maximum
		End Get
		Set(value As Integer)
			gProgressBar.Maximum = value
			Me.Value = 0
		End Set
	End Property

	Public Property Value As Integer
		Get
			Return gProgressBar.Maximum
		End Get
		Set(value As Integer)
			gProgressBar.Value = value
		End Set
	End Property

	Private Sub G1Button_Click(sender As Object, e As EventArgs)

	End Sub

	Private Sub G2Button_Click(sender As Object, e As EventArgs)

	End Sub

End Class
