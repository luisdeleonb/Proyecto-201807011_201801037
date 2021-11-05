Imports System.Data.SqlClient
Public Class PrestarL
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Cliente.Show()
    End Sub

    Private Sub PrestarL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")
        Dim libro_usuario As String

        libro_usuario = Modulo_Central.usuariosesion


        Try
            Dim command As New SqlCommand("SELECT * FROM PRESTAMO", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "PRESTAMO")
            Me.DataGridView1.DataSource = dataSet.Tables("PRESTAMO")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub
End Class