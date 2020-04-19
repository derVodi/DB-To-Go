Partial Public Class DebugHelper

	Public Shared ReadOnly Property SimulationMode As SimulationModeValue
		Get
#If DEBUG Then
			Return SimulationModeValue.None
#End If
			Return SimulationModeValue.None
		End Get
	End Property

	Public Shared ReadOnly Property SlowMotionDelay As Integer = 0

	Public Enum SimulationModeValue
		None
		Updater
		Setup
	End Enum

End Class
