Imports System.Data.SqlClient
Public Class Registro
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("INSERT INTO USUARIO (Nombre, Apellido, Usuario, Tipo_Usr, Nacimiento, Pass) VALUES (@Nombre, @Apellido, @Usuario, @Tipo_Usr, @Nacimiento, @Pass)", connection)
            command.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = TextBox1.Text
            command.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = TextBox2.Text
            command.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = TextBox3.Text
            command.Parameters.Add("@Tipo_Usr", SqlDbType.VarChar).Value = TextBox6.Text
            command.Parameters.Add("@Nacimiento", SqlDbType.Date).Value = DateTimePicker1.Value
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = TextBox5.Text
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Nuevo Usuario Registrado")
            Else
                MessageBox.Show("No se pudo agregar al usuario")
            End If
            connection.Close()

        Catch ex As Exception
            MsgBox("REVISE LOS DATOS")
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = " "
        TextBox2.Text = " "
        TextBox3.Text = " "

        TextBox5.Text = " "
        TextBox6.Text = " "
    End Sub

End Class