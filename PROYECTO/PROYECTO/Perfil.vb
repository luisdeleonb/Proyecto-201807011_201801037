Imports System.Data.SqlClient
Public Class Perfil
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Cliente.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = " "
        TextBox2.Text = " "
        TextBox3.Text = " "

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Dim actualizar_usuario As String
        actualizar_usuario = Modulo_Central.usuariosesion


        Try
            Dim command As New SqlCommand("UPDATE USUARIO SET Nombre = @Nombre, Apellido = @Apellido, Usuario = @Usuario, Nacimiento = @Nacimiento WHERE Usuario = '" & actualizar_usuario & "'", connection)
            command.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = TextBox1.Text
            command.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = TextBox2.Text
            command.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = TextBox3.Text
            command.Parameters.Add("@Nacimiento", SqlDbType.Date).Value = DateTimePicker1.Value
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Pefil Actualizado")
            Else
                MessageBox.Show("No se pudo actuzalizar el perfil")
            End If
            connection.Close()

        Catch ex As Exception
            MsgBox("REVISE LOS DATOS")

        End Try


    End Sub

    Private Sub Perfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        Label6.Text = Modulo_Central.usuariosesion


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim connection As New SqlConnection("Data Source=LAPTOP-39QE0K1H\SQLEXPRESS;Initial Catalog=BD_201807011_201801037;Integrated Security=True")

        Try
            Dim command As New SqlCommand("DELETE FROM USUARIO WHERE Usuario = '" & Label6.Text & "'", connection)
            connection.Open()

            If command.ExecuteNonQuery() = 1 Then
                MessageBox.Show("Usuario eliminado")
                Me.Close()
                Form1.Show()
            Else
                MessageBox.Show("No se pudo eliminar el usuario")
            End If
            connection.Close()

        Catch ex As Exception
            MsgBox("REVISE LOS DATOS")

        End Try

    End Sub
End Class