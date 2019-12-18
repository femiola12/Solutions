Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class User
    Public Property UserID As Integer

    <StringLength(50)>
    Public Property UserName As String

    Public Property CategoryID As Integer?

    Public Overridable Property Category As Category
End Class
