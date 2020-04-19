Imports System.Reflection

Public Class InteractionBroker

	Private Shared _SubscribersCollected As Boolean

	Private Shared _ListenersWithParameterPerInteractionName As Dictionary(Of String, List(Of Action(Of String)))

	Private Shared _ListenersPerInteractionName As Dictionary(Of String, List(Of Action))

	Private Shared ReadOnly Property ListenersWithParameterPerInteractionName As Dictionary(Of String, List(Of Action(Of String)))
		Get
			If (_ListenersWithParameterPerInteractionName Is Nothing) Then
				_ListenersWithParameterPerInteractionName = New Dictionary(Of String, List(Of Action(Of String)))
			End If
			Return _ListenersWithParameterPerInteractionName
		End Get
	End Property

	Private Shared ReadOnly Property ListenersPerInteractionName As Dictionary(Of String, List(Of Action))
		Get
			If (_ListenersPerInteractionName Is Nothing) Then
				_ListenersPerInteractionName = New Dictionary(Of String, List(Of Action))
			End If
			Return _ListenersPerInteractionName
		End Get
	End Property

	Private Shared Sub CollectSubscribers()
		Dim a = Assembly.GetExecutingAssembly()
		Dim allTypes = a.GetExportedTypes
		For Each loopingType In allTypes
			If (loopingType.IsDefined(GetType(InteractionSubscriberAttribute))) Then
				'Dim createFunction As MethodInfo = loopingType.GetMethod("GetInstance")
				'If (createFunction IsNot Nothing) Then
				'	Dim subscriberInstance = createFunction.Invoke(Nothing, Nothing)
				'	Subscribe(subscriberInstance)
				'End If
				Dim instanceProperty As PropertyInfo = loopingType.GetProperty("Instance", BindingFlags.Static Or BindingFlags.Public)
				If (instanceProperty IsNot Nothing) Then
					Dim subscriberInstance = instanceProperty.GetValue(Nothing, Nothing)
					Subscribe(subscriberInstance)
				End If
			End If
		Next
		_SubscribersCollected = True
	End Sub

	Public Shared Sub Send(interactionName As String, Optional parameter As String = Nothing)

		If (Not _SubscribersCollected) Then
			CollectSubscribers()
		End If

		Dim listenerFunctions As List(Of Action) = Nothing
		ListenersPerInteractionName.TryGetValue(interactionName, listenerFunctions)
		If (listenerFunctions IsNot Nothing) Then
			For Each listenerWithStringFunction In listenerFunctions
				listenerWithStringFunction.Invoke()
			Next
		End If

		Dim listenerWithParameterFunctions As List(Of Action(Of String)) = Nothing
		ListenersWithParameterPerInteractionName.TryGetValue(interactionName, listenerWithParameterFunctions)
		If (listenerWithParameterFunctions IsNot Nothing) Then
			For Each listenerWithStringFunction In listenerWithParameterFunctions
				listenerWithStringFunction.Invoke(parameter)
			Next
		End If

	End Sub

	Public Shared Sub Subscribe(objectWithInteractionListeners As Object)
		objectWithInteractionListeners.GetType().ForEachMethodOfAttribute(Of InteractionListenerAttribute)(
			Function(mi As MethodInfo, attribute As InteractionListenerAttribute)

				If (mi.GetParameters().GetUpperBound(0) < 0) Then

					Dim newListenerFunction = DirectCast(
						[Delegate].CreateDelegate(GetType(Action), objectWithInteractionListeners, mi),
						Action
					)

					Dim listenerFunctions As List(Of Action) = Nothing
					ListenersPerInteractionName.TryGetValue(attribute.InteractionName, listenerFunctions)
					If (listenerFunctions Is Nothing) Then
						listenerFunctions = New List(Of Action)
						ListenersPerInteractionName.Add(attribute.InteractionName, listenerFunctions)
					End If
					listenerFunctions.Add(newListenerFunction)

				Else

					Dim newListenerWithParameterFunction = DirectCast(
						[Delegate].CreateDelegate(GetType(Action(Of String)), objectWithInteractionListeners, mi),
						Action(Of String)
					)

					Dim listenerWithParameterFunctions As List(Of Action(Of String)) = Nothing
					ListenersWithParameterPerInteractionName.TryGetValue(attribute.InteractionName, listenerWithParameterFunctions)
					If (listenerWithParameterFunctions Is Nothing) Then
						listenerWithParameterFunctions = New List(Of Action(Of String))
						ListenersWithParameterPerInteractionName.Add(attribute.InteractionName, listenerWithParameterFunctions)
					End If
					listenerWithParameterFunctions.Add(newListenerWithParameterFunction)
				End If

				Return False
			End Function
		)
	End Sub

End Class
