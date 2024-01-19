''' <summary>
'''  Módulo general.
''' </summary>
''' <remarks>Marcelo Woloszyn - 29/04/2013</remarks>
Module mdl_General

#Region "VARIABLES"

#End Region

#Region "MÉTODOS Y FUNCIONES"
    ''' <summary>
    ''' Entrega "Collection" de retorno general de funciones.
    ''' </summary>
    ''' <param name="pvb_Estado">Estado: True = sin error False = error</param>
    ''' <param name="pveNm_Operacion">Tipo de operación realizada</param>
    ''' <param name="pvo_Datos">Datos obtenidos de la consulta</param>
    ''' <param name="pvi_FilasAfectadas">Cantidad de filas afectadas</param>
    ''' <param name="pvo_Excepcion">Excepción</param>
    ''' <returns>
    ''' Collection:
    ''' estado: True = sin error False = error
    ''' operacion: tipo de operación realizada
    ''' datos: datos obtenidos de la consulta
    ''' filas_afectadas: cantidad de filas afectadas
    ''' valor_agregado: resultado de funciones de valor agregado SQL
    ''' nro_excepcion: número de excepción (Solo cuando ocurre una excepción)
    ''' mensaje_excepcion: mensaje de excepción (Solo cuando ocurre una excepción)
    ''' capa_excepcion: capa de excepción (Solo cuando ocurre una excepción)
    ''' clase_excepcion: clase de excepción
    ''' funcion_metodo_excepcion: función/método de excepción
    ''' </returns>
    ''' <remarks>Marcelo Woloszyn - 29/04/2013</remarks>
    Public Function fgo_RetornoFuncionGeneral(ByVal pvb_Estado As Boolean, ByVal pveNm_Operacion As SERV.enm_OperacionAccesoDatos, Optional ByVal pvo_Datos As DataSet = Nothing, Optional ByVal pvo_ValorAgregado As Object = Nothing, Optional ByVal pvi_FilasAfectadas As Integer = 0, Optional ByVal pvo_Excepcion As Exception = Nothing, Optional ByVal pvs_ClaseException As String = "", Optional ByVal pvs_FuncionMetodoException As String = "") As Collection
        Dim vlo_Retorno As New Collection

        'Estado: True = sin error False = error
        vlo_Retorno.Add(pvb_Estado, "estado")
        'Tipo de operación realizada
        vlo_Retorno.Add(pveNm_Operacion, "operacion")
        'Datos obtenidos de la consulta
        vlo_Retorno.Add(pvo_Datos, "datos")
        'Cantidad de filas afectadas
        vlo_Retorno.Add(pvi_FilasAfectadas, "filas_afectadas")
        'Resultado de funciones de valor agregado SQL
        vlo_Retorno.Add(pvo_ValorAgregado, "valor_agregado")
        'Excepción
        If Not pvb_Estado Then
            'Número de excepción
            vlo_Retorno.Add(System.Runtime.InteropServices.Marshal.GetHRForException(pvo_Excepcion), "nro_excepcion")
            'Mensaje de excepción
            vlo_Retorno.Add(pvo_Excepcion.Message, "mensaje_excepcion")
            'Capa de excepción
            vlo_Retorno.Add(SERV.enm_CapaExcepciones.acceso_datos, "capa_excepcion")
            'Clase de excepción
            vlo_Retorno.Add(pvs_ClaseException, "clase_excepcion")
            'Función/Método de excepción
            vlo_Retorno.Add(pvs_FuncionMetodoException, "funcion_metodo_excepcion")
        End If

        'Retorno de función
        Return vlo_Retorno

    End Function
#End Region

End Module
