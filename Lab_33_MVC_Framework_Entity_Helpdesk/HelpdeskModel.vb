Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class HelpdeskModel
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=HelpdeskModel1")
    End Sub

    Public Overridable Property Categories As DbSet(Of Category)
    Public Overridable Property Users As DbSet(Of User)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Category)() _
            .Property(Function(e) e.CategoryName) _
            .IsUnicode(False)

        modelBuilder.Entity(Of User)() _
            .Property(Function(e) e.UserName) _
            .IsUnicode(False)
    End Sub
End Class
