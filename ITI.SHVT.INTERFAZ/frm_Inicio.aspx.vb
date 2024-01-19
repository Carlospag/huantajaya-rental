Public Class frm_Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'Dim dt_MontoFlota As DataTable = CType(sds_MontoFlota.Select(DataSourceSelectArguments.Empty), DataView).Table

        'Dim ValorFormateadoRojo As String = dt_MontoFlota.Rows(0).Item("ST").ToString()
        'Dim ValorFormateadoAmarillo As String = dt_MontoFlota.Rows(0).Item("STOCK").ToString()
        'Dim ValorFormateadoVerde As String = dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()

        'Dim ST As Int32 = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
        'Dim STOCK As Int32 = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
        'Dim ARRIENDO As Int32 = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100


    End Sub

    'Protected Sub obtenerDatos()
    '    Dim dt_MontoFlota As DataTable = CType(sds_MontoFlota.Select(DataSourceSelectArguments.Empty), DataView).Table

    '    Dim ValorFormateadoRojo As String = dt_MontoFlota.Rows(0).Item("ST").ToString()
    '    Dim ValorFormateadoAmarillo As String = dt_MontoFlota.Rows(0).Item("STOCK").ToString()
    '    Dim ValorFormateadoVerde As String = dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()

    '    Dim ST As Int32 = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
    '    Dim STOCK As Int32 = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
    '    Dim ARRIENDO As Int32 = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100

    '    'Dim Datos As DataTable = New DataTable()

    'End Sub
End Class