Imports System.Data.SqlClient
Public Class CRUD_Libros
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Administrador.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = " "
        TextBox2.Text = " "
        TextBox3.Text = " "
        TextBox4.Text = " "
        TextBox5.Text = " "
        TextBox6.Text = " "
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("INSERT INTO LIBRO (ID_EDITORIAL, GENERO, TITULO, AUTOR, CANTIDAD) VALUES (@ID_EDITORIAL, @GENERO, @TITULO, @AUTOR, @CANTIDAD)", connection)
            command.Parameters.Add("@ID_EDITORIAL", SqlDbType.Int).Value = Convert.ToInt32(TextBox4.Text)
            command.Parameters.Add("@GENERO", SqlDbType.Int).Value = Convert.ToInt32(TextBox3.Text)
            command.Parameters.Add("@TITULO", SqlDbType.VarChar).Value = TextBox1.Text
            command.Parameters.Add("@AUTOR", SqlDbType.VarChar).Value = TextBox2.Text
            command.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = Convert.ToInt32(TextBox5.Text)
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Nuevo libro agregado")
            Else
                MessageBox.Show("No se pudo agregar el libro")
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
            Dim command As New SqlCommand("UPDATE LIBRO SET ID_EDITORIAL = @ID_EDITORIAL, GENERO = @GENERO, TITULO = @TITULO, AUTOR = @AUTOR, CANTIDAD = @CANTIDAD WHERE ID_LIBRO = @ID_LIBRO", connection)
            command.Parameters.Add("@ID_LIBRO", SqlDbType.Int).Value = Convert.ToInt32(TextBox6.Text)
            command.Parameters.Add("@ID_EDITORIAL", SqlDbType.Int).Value = Convert.ToInt32(TextBox4.Text)
            command.Parameters.Add("@GENERO", SqlDbType.Int).Value = Convert.ToInt32(TextBox3.Text)
            command.Parameters.Add("@TITULO", SqlDbType.VarChar).Value = TextBox1.Text
            command.Parameters.Add("@AUTOR", SqlDbType.VarChar).Value = TextBox2.Text
            command.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = Convert.ToInt32(TextBox5.Text)
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Libro actualizado")
            Else
                MessageBox.Show("No se pudo actuzalizar el libro")
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
            Dim command As New SqlCommand("DELETE FROM LIBRO WHERE ID_LIBRO = @ID_LIBRO", connection)
            command.Parameters.Add("@ID_LIBRO", SqlDbType.Int).Value = Convert.ToInt32(TextBox6.Text)
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Libro eliminado")
            Else
                MessageBox.Show("No se pudo eliminar el libro")
            End If
            connection.Close()
            Recargar()
        Catch ex As Exception
            MsgBox("REVISE LOS DATOS")

        End Try

    End Sub

    Private Sub CRUD_Libros_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


    Private Sub Recargar()

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

End Class