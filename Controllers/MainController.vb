Public Class MainController

	Private _CurrentNavTreeNode As TreeNode

	Public Property View As MainPanel

	Public Sub New()
		InteractionBroker.Subscribe(Me)
	End Sub

	Public Sub Run()
		AddHandler Me.View.gStructure.SelectedIndexChanged, AddressOf Structure_SelectedIndexChanged
		AddHandler Me.View.gStructure.Validated, AddressOf Structure_Validated
		AddHandler Me.View.gNavTree.AfterSelect, AddressOf NavTree_AfterSelect
		Me.View.InitializeFocus()
		Me.View.EventsActivated = True
	End Sub

	<InteractionListener(InteractionCatalog.About)>
	Public Sub About_Requested()
		MainForm.ShowModal(
			"Version " + Versioning.Updater.VersionAsString + " (<a href='http://local/VersionHistory.txt'>Version History</a>)<br><br>" +
			Versioning.Constants.License
		)
	End Sub

	<InteractionListener(ModalPanel.Home)>
	Public Sub Home_Requested()
		MainForm.CloseModal()
	End Sub

	<InteractionListener(InteractionCatalog.Compare)>
	Public Sub Compare_Requested()
		ModalForm.PopUp(DiffView.Instance, "Compare")
	End Sub

	<InteractionListener(InteractionCatalog.Sync)>
	Public Sub Sync_Requested()
		View.SyncPictureIsAnimated = True
		View.gThumbsPanel.Clear()
		View.gBackgroundWorker.RunWorkerAsync()
	End Sub

#Region " Structure → NavTree "

	Private Sub Structure_SelectedIndexChanged(sender As Object, e As EventArgs)
		View.gNavTree.BindData(View.gStructure.Text, False)
	End Sub

	Private Sub Structure_Validated(sender As Object, e As EventArgs)
		View.gNavTree.BindData(View.gStructure.Text, False)
	End Sub

#End Region

#Region " NavTree → SearchText, ThumbsPanel "

	Private Sub NavTree_AfterSelect(sender As Object, e As TreeViewEventArgs)
		If (e.Node Is Nothing OrElse e.Node Is _CurrentNavTreeNode) Then
			Exit Sub
		End If

		'Slave 1: Search Field
		View.gSearch.Text = ""

		'Slave 2: Thumbs
		Select Case View.gNavTree.Mode
			Case NavTree.NavTreeMode.Dates
				Dim year, month As Integer
				NavTree.GetYearAndMonth(e.Node, year, month)
				View.gThumbsPanel.PopulateByDates(year, month)
			Case NavTree.NavTreeMode.Tags
				View.gThumbsPanel.PopulateByTags(NavTree.GetCriteria(e.Node))
		End Select

		_CurrentNavTreeNode = e.Node
	End Sub

#End Region

End Class
