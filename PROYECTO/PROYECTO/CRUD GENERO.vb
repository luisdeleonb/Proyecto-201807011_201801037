Imports System.Data.SqlClient
Public Class CRUD_GENERO
    Private Sub CRUD_GENERO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("SELECT * FROM GENERO", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "GENERO")
            Me.DataGridView1.DataSource = dataSet.Tables("GENERO")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Administrador.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = " "
        TextBox4.Text = " "

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("INSERT INTO GENERO (NOMBRE) VALUES (@NOMBRE)", connection)
            command.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = TextBox1.Text
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Nuevo genero rgistrado")
            Else
                MessageBox.Show("No se pudo agregar el genero")
            End If
            connection.Close()
            Recargar()

        Catch ex As Exception
            MsgBox("REVISE LOS DATOS")
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("UPDATE GENERO SET NOMBRE = @NOMBRE WHERE ID_GENERO = @ID_GENERO", connection)
            command.Parameters.Add("@ID_GENERO", SqlDbType.Int).Value = Convert.ToInt32(TextBox4.Text)
            command.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = TextBox1.Text
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Genero Actualizado")
            Else
                MessageBox.Show("No se pudo actuzalizar el genero")
            End If
            connection.Close()
            Recargar()
        Catch ex As Exception
            MsgBox("REVISE LOS DATOS")

        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("DELETE FROM GENERO WHERE ID_GENERO = @ID_GENERO", connection)
            command.Parameters.Add("@ID_GENERO", SqlDbType.Int).Value = Convert.ToInt32(TextBox4.Text)
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Genero eliminado")
            Else
                MessageBox.Show("No se pudo eliminar el genero")
            End If
            connection.Close()
            Recargar()
        Catch ex As Exception
            MsgBox("REVISE LOS DATOS")

        End Try

    End Sub

    Private Sub Recargar()

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("SELECT * FROM GENERO", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "GENERO")
            Me.DataGridView1.DataSource = dataSet.Tables("GENERO")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class