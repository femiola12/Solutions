Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Category
    Public Sub New()
        Users = New HashSet(Of User)()
    End Sub

    Public Property CategoryID As Integer

    <StringLength(50)>
    Public Property CategoryName As String

    Public Overridable Property Users As ICollection(Of User)
End Class
