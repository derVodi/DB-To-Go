Imports DbToGo.Data

Public Class NavTree
	Inherits TreeView

	Public Enum NavTreeMode
		Dates
		Tags
	End Enum

	Private _CurrentHierarchy As String

	Public Property Mode As NavTreeMode = NavTreeMode.Tags

	Public Sub BindData(hierarchyOfNames As String, reload As Boolean)

		If (_CurrentHierarchy = hierarchyOfNames AndAlso Not reload) Then
			Exit Sub
		End If

		Me.Nodes.Clear()

		Select Case hierarchyOfNames.ToLower
			Case "#new"
				Me.Mode = NavTreeMode.Dates
				PopulateByDates()
			Case Else
				Me.Mode = NavTreeMode.Tags
				If (Not String.IsNullOrWhiteSpace(hierarchyOfNames)) Then
					Dim hierarchyArray() As String
					hierarchyArray = hierarchyOfNames.Split(" "c)
					Me.PopulateByValues(hierarchyArray, Me.Nodes, 0, Nothing)
				End If
		End Select

		_CurrentHierarchy = hierarchyOfNames
	End Sub

	Public Shared Function GetCriteria(node As TreeNode) As Attrib()
		Dim maxIndex As Integer
		node.ForEachParent(Sub() maxIndex += 1)
		maxIndex -= 1
		Dim criteria(maxIndex) As Attrib
		node.ForEachParent(Sub(i, n) criteria(maxIndex - i) = DirectCast(n.Tag, Attrib))
		Return criteria
	End Function

	Public Shared Sub GetYearAndMonth(node As TreeNode, ByRef year As Integer, ByRef month As Integer)
		month = 0
		year = 0
		If (node.Parent IsNot Nothing) Then
			month = CInt(node.Text)
			year = CInt(node.Parent.Text)
		Else
			year = CInt(node.Text)
		End If
	End Sub

	Private Sub PopulateByDates()

		Dim maxYear As Integer
		Dim minYear As Integer
		Database.GetMinMaxYear(maxYear, minYear)

		For year As Integer = maxYear To minYear Step -1
			Dim yearNode As TreeNode = Me.Nodes.Add(year.ToString)
			For month As Integer = 12 To 1 Step -1
				Dim monthNode As TreeNode = yearNode.Nodes.Add(month.ToString)
			Next
		Next
	End Sub

	Private Sub PopulateByValues(hierarchyOfTypes() As String, parentContainer As TreeNodeCollection, level As Integer, parentNode As TreeNode)

		If (hierarchyOfTypes Is Nothing) Then
			Exit Sub
		End If

		Dim currentType As String = hierarchyOfTypes(level)

		'Baum-Pfad umwandeln in ein Array von Filterkriterien
		Dim matchingAttribs(level) As Attrib
		If (level > 0) Then
			parentNode.ForEachParent(Sub(i, node) matchingAttribs(level - (i + 1)) = DirectCast(node.Tag, Attrib))
		End If

		Dim dummyAttrib As Attrib = New Attrib(currentType, "?")
		matchingAttribs(level) = dummyAttrib
		If (Database.ExistsPictureEntry(matchingAttribs)) Then
			Dim newNode As TreeNode = parentContainer.Add("?")
			newNode.Tag = dummyAttrib
		End If

		'Alle Attribute eines bestimmten Typs durchlaufen, z.B. alle Genres, alle Regisserue, ...
		Database.AttribRepository.ForEachAttribOf(
			currentType,
			Sub(attrib)
				matchingAttribs(level) = attrib
				'Sofern ein einziger Treffer existiert, ist es die Ausprägung "wert", als Knoten dargestellt zu werden
				If (Database.ExistsPictureEntry(matchingAttribs)) Then
					Dim newNode As TreeNode = parentContainer.Add(attrib.Value)
					newNode.Tag = attrib
				End If
			End Sub
		) ' Next

		level += 1
		If (level < hierarchyOfTypes.Length) Then
			For Each n As TreeNode In parentContainer
				PopulateByValues(hierarchyOfTypes, n.Nodes, level, n)
			Next
		End If

	End Sub

	Private Sub InitializeComponent()
		Me.SuspendLayout()
		'
		'NavTree
		'
		Me.LineColor = System.Drawing.Color.Black
		Me.ResumeLayout(False)

	End Sub

End Class
