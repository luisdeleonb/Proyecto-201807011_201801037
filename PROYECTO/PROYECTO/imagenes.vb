Public Class imagenes
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox2.Checked = True Then
            MessageBox.Show("Bienvenido")
            Cliente.Show()
            Me.Close()
        Else
            MessageBox.Show("Imagen inconrrecta")
            Form1.Show()
            Form1.Refresh()

            Me.Close()
        End If
    End Sub

    Private Sub imagenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False


    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        CheckBox1.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        CheckBox2.Checked = False
        CheckBox1.Checked = False
        CheckBox4.Checked = False
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox1.Checked = False
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        CheckBox1.Checked = True
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False


    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        CheckBox2.Checked = True
        CheckBox1.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        CheckBox3.Checked = True
        CheckBox2.Checked = False
        CheckBox1.Checked = False
        CheckBox4.Checked = False
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        CheckBox4.Checked = True
        CheckBox2.Checked = False
        CheckBox1.Checked = False
        CheckBox3.Checked = False
    End Sub
End Class