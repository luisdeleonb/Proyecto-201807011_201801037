Imports System.Data.SqlClient
Public Class Prestar_Libros
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Cliente.Show()
    End Sub

    Private Sub Prestar_Libros_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("SELECT * FROM LIBRO", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "LIBRO")
            Me.DataGridView1.DataSource = dataSet.Tables("LIBRO")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("SELECT * FROM LIBRO WHERE TITULO = '" & TextBox1.Text & "'", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "LIBRO")
            Me.DataGridView1.DataSource = dataSet.Tables("LIBRO")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")
        Dim agregar_libro As String


        agregar_libro = Modulo_Central.usuariosesion






        Try

            Dim command As New SqlCommand("INSERT INTO PRESTAMO WHERE ID_USUARIO = '" & agregar_libro & "'", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "PRESTAMO")




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class