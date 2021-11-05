Imports System.Data.SqlClient
Imports System.Net
Public Class Form1
    Public conectar
    Public bol As Boolean


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Registro.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Salir.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim acceso As Boolean
        Dim AUsuario As String
        AUsuario = " "


        acceso = False
        If bol = True Then
            Dim command As New SqlCommand("SELECT * FROM USUARIO", conectar)
            Dim dataAdapter As New SqlDataAdapter(command)

            Dim dataset As New DataSet
            dataAdapter.Fill(dataset, "USUARIO")

            'data set es el que sirve

            Dim c As Integer
            c = 0
            While c <= dataset.Tables("USUARIO").Rows.Count - 1
                c = c + 1
                Dim fila As DataRow

                fila = dataset.Tables("USUARIO").Rows(0)

                Dim usuario As String
                Dim pass As String
                usuario = fila("usuario")
                pass = fila("Pass")

                If usuario = TextBox1.Text And pass = TextBox2.Text Then
                    acceso = True
                    c = dataset.Tables("USUARIO").Rows.Count + 1
                    AUsuario = usuario

                    Modulo_Central.usuariosesion = AUsuario

                End If
            End While
            If acceso = True Then
                Dim thisDate As Date
                thisDate = Today
                Dim nPc As String
                Dim eIP As Net.IPHostEntry

                nPc = Dns.GetHostName
                eIP = Dns.GetHostEntry(nPc)
                Dim direccionIP = eIP.AddressList(1)




                Dim command2 As New SqlCommand("INSERT INTO BITACORA  VALUES (@Fecha,@Usuario,@IpU,@Accion)", conectar)
                command2.Parameters.Add("@Fecha", SqlDbType.Date).Value = thisDate
                command2.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = AUsuario
                command2.Parameters.Add("@IpU", SqlDbType.VarChar).Value = direccionIP.ToString
                command2.Parameters.Add("@Accion", SqlDbType.VarChar).Value = "Inicio de Sesión"
                conectar.Open()


                If command2.ExecuteNonQuery() = 1 Then
                    Dim x As Integer  'no tiene funcion alguna

                Else
                    MessageBox.Show("no")
                End If
                conectar.Close()


                TextBox1.Clear()
                TextBox2.Clear()
                Me.Hide()
                imagenes.Show()

            Else
                    MessageBox.Show("Usuario o Password Incorrecto")
                TextBox1.Clear()
                TextBox2.Clear()
            End If




        Else
            MessageBox.Show("base de datos aun no conectada")

        End If


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Try
            conectar = New SqlConnection("Server=LAPTOP-39QE0K1H\SQLEXPRESS;Database=BD_201807011_201801037;Trusted_Connection=True;")
            MessageBox.Show("Base de datos Conectada")
            bol = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bol = False

    End Sub
End Class
