Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()

    End Sub

    Function cargarDatos()
        Dim conexion As New SqlConnection(My.Settings.CONEXION)
        Dim consulta As String
        consulta = "Select * from productos"
        Dim query As New SqlCommand(consulta, conexion)
        Dim adapter As New SqlDataAdapter(query)
        Dim datostabla As New DataSet
        adapter.Fill(datostabla, "productos")
        Me.DataGridView1.DataSource = datostabla.Tables("productos")



    End Function

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles Agregar.Click
        Dim producto As New Articulo
        producto.id = CInt(Me.TextBox1.Text)
        producto.precio = CDbl(Me.TextBox3.Text)
        producto.descripcion = Me.TextBox2.Text

        agregarDatos(producto)
        cargarDatos()
    End Sub

    Function agregarDatos(valor As Articulo)
        Dim conexion As New SqlConnection(My.Settings.CONEXION)
        conexion.Open()
        Dim consulta As String
        consulta = "insert into productos (Id,Precio,Descripcion) values (" & valor.id & ",'" & valor.precio & "','" & valor.descripcion & "')"
        Dim query As New SqlCommand(consulta, conexion)
        query.ExecuteNonQuery()
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim producto As New Articulo
        producto.id = CInt(Me.TextBox1.Text)
        producto.precio = CDbl(Me.TextBox3.Text)
        producto.descripcion = Me.TextBox2.Text

        modificarDatos(producto)
        cargarDatos()
    End Sub
    Function modificarDatos(valor As Articulo)
        Dim conexion As New SqlConnection(My.Settings.CONEXION)
        conexion.Open()
        Dim consulta As String
        consulta = "update productos set Id= " & valor.id & ",Precio= " & valor.precio & ",Descripcion= '" & valor.descripcion & "' Where Id= " & valor.id & ""
        Dim query As New SqlCommand(consulta, conexion)
        query.ExecuteNonQuery()
    End Function
    Function eliminarDatos(valor As Articulo)
        Dim conexion As New SqlConnection(My.Settings.CONEXION)
        conexion.Open()
        Dim consulta As String
        consulta = "delete from productos  Where Id= " & valor.id & ""
        Dim query As New SqlCommand(consulta, conexion)
        query.ExecuteNonQuery()
    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim FilaActual As Integer
        FilaActual = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Rows(FilaActual).Cells(0).Value
        TextBox3.Text = DataGridView1.Rows(FilaActual).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(FilaActual).Cells(2).Value




    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim producto As New Articulo
        producto.id = CInt(Me.TextBox1.Text)
        producto.precio = CDbl(Me.TextBox3.Text)
        producto.descripcion = Me.TextBox2.Text

        eliminarDatos(producto)
        cargarDatos()

    End Sub
End Class
