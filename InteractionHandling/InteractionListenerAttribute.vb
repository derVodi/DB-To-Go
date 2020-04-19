Imports System

<AttributeUsage(AttributeTargets.Method, AllowMultiple:=False, Inherited:=True)>
Public Class InteractionListenerAttribute
	Inherits Attribute

	Private _InteractionName As String

	Public Sub New(interactionName As String)
		_InteractionName = interactionName
	End Sub

	Public ReadOnly Property InteractionName As String
		Get
			Return _InteractionName
		End Get
	End Property

End Class

<AttributeUsage(AttributeTargets.Class, AllowMultiple:=False, Inherited:=True)>
Public Class InteractionSubscriberAttribute
	Inherits Attribute

	Public Sub New()
	End Sub

End Class
