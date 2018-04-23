Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private popupControl As Control

		Private Sub barButtonItem1_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles barButtonItem1.ItemClick
			Console.WriteLine(e.Link.LinkedObject)
			If e.Link.LinkedObject Is popupMenu1 Then
				MessageBox.Show(String.Format("The context menu was invoked for '{0}'.", popupControl))
			End If
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			AddHandler ribbonControl1.Manager.QueryShowPopupMenu, AddressOf ShowPopupMenuHandler
		End Sub

		Private Sub ShowPopupMenuHandler(ByVal sender As Object, ByVal e As QueryShowPopupMenuEventArgs)
			Console.WriteLine(e.Control)
			popupControl = e.Control
		End Sub

		Private Sub popupMenu1_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles popupMenu1.CloseUp
			popupControl = Nothing
		End Sub
	End Class
End Namespace