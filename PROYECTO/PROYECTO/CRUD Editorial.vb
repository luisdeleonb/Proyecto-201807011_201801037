Imports System.Data.SqlClient
Public Class CRUD_Editorial
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Administrador.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = " "
        TextBox2.Text = " "
        TextBox3.Text = " "
        TextBox4.Text = " "
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("INSERT INTO EDITORIAL (NOMBRE, DIRECCION, TELEFONO) VALUES (@NOMBRE, @DIRECCION, @TELEFONO)", connection)
            command.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = TextBox1.Text
            command.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = TextBox2.Text
            command.Parameters.Add("@TELEFONO", SqlDbType.Int).Value = Convert.ToInt32(TextBox3.Text)
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Nuevo Editorial Registrada")
            Else
                MessageBox.Show("No se pudo agregar la Editorial")
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
            Dim command As New SqlCommand("UPDATE EDITORIAL SET NOMBRE = @NOMBRE, DIRECCION = @DIRECCION, TELEFONO = @TELEFONO WHERE ID_EDITORIAL = @ID_EDITORIAL", connection)
            command.Parameters.Add("@ID_EDITORIAL", SqlDbType.Int).Value = Convert.ToInt32(TextBox4.Text)
            command.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = TextBox1.Text
            command.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = TextBox2.Text
            command.Parameters.Add("@TELEFONO", SqlDbType.Int).Value = Convert.ToInt32(TextBox3.Text)
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Editorial Actualizada")
            Else
                MessageBox.Show("No se pudo actuzalizar la Editorial")
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
            Dim command As New SqlCommand("DELETE FROM EDITORIAL WHERE ID_EDITORIAL = @ID_EDITORIAL", connection)
            command.Parameters.Add("@ID_EDITORIAL", SqlDbType.Int).Value = Convert.ToInt32(TextBox4.Text)
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Editorial eliminada")
            Else
                MessageBox.Show("No se pudo eliminar la Editorial")
            End If
            connection.Close()
            Recargar()
        Catch ex As Exception
            MsgBox("REVISE LOS DATOS")

        End Try

    End Sub

    Private Sub CRUD_Editorial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("SELECT * FROM EDITORIAL", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "EDITORIAL")
            Me.DataGridView1.DataSource = dataSet.Tables("EDITORIAL")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub


    Private Sub Recargar()

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("SELECT * FROM EDITORIAL", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dataSet As New DataSet
            dataAdapter.Fill(dataSet, "EDITORIAL")
            Me.DataGridView1.DataSource = dataSet.Tables("EDITORIAL")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

End Class