Public Class cls_Cotizaciones

#Region "VARIABLES"
    Private vpo_ManejadorCotizaciones As AD.AD_COTIZACIONES.cls_Cotizaciones
    Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
    Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region



    Public Function fgb_GenerarCotizacion(ByVal pvi_idEquipo As Integer,
                                                   ByVal pvs_idCliente As String,
                                                   ByVal pvi_idTipoCotizacion As Integer,
                                                   ByVal pvi_Modalidad As Integer,
                                                   ByVal pvs_Contacto As String,
                                                   ByVal pvs_Faena As String,
                                                   ByVal pvs_Precio As Integer,
                                                   ByVal pvi_idVendedor As Integer,
                                                   ByVal pvi_idUsuario As Integer,
                                                   ByVal pvi_CantHoras As Integer,
                                                   ByVal pvs_TextoAlternativo As String,
                                                   ByVal pvi_idZona As Integer,
                                                   ByVal pvi_Condiciones() As Integer,
                                                   ByVal pvi_Implementaciones() As Integer) As Boolean
        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_GenerarCotizacion"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0

            'Verificamos si el usuario a agregar tiene la opcion de sistema de aprobación por area
            'For i = 0 To pvi_OpcionesUsuario.Length - 1
            '    If pvi_OpcionesUsuario(i) = 1 Then
            '        vli_UsuarioAprobador = 1
            '        Exit For
            '    End If
            'Next

            'Instancia del objeto de la capa AD
            vpo_ManejadorCotizaciones = New AD.AD_COTIZACIONES.cls_Cotizaciones

            vlo_Retorno = vpo_ManejadorCotizaciones.fgo_GenerarCotizacion(pvi_idEquipo,
                                                                  pvs_idCliente,
                                                                  pvi_idTipoCotizacion,
                                                                  pvi_Modalidad,
                                                                  pvs_Contacto,
                                                                  pvs_Faena,
                                                                  pvs_Precio,
                                                                  pvi_idVendedor,
                                                                  pvi_idUsuario,
                                                                  pvi_CantHoras,
                                                                  pvs_TextoAlternativo,
                                                                  pvi_idZona)


            'Ahora agregamos las opciones del sistema para el usuario en cuestión
            For i = 0 To pvi_Condiciones.Length - 1
                If pvi_Condiciones(i) <> 0 Then
                    vpo_ManejadorCotizaciones.fgo_AgregarCondicion(vlo_Retorno("valor_agregado"), pvi_Condiciones(i))
                End If
            Next

            'Ahora agregamos las opciones del sistema para el usuario en cuestión
            For i = 0 To pvi_Implementaciones.Length - 1
                If pvi_Implementaciones(i) <> 0 Then
                    vpo_ManejadorCotizaciones.fgo_AgregarImplementacion(vlo_Retorno("valor_agregado"), pvi_Implementaciones(i))
                End If
            Next

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Insertar_Cotizacion, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.Insertar_Cotizacion, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_ActualizarCotizacion(ByVal pvi_idCotizacion As Integer,
                                                    ByVal pvi_idEquipo As Integer,
                                                   ByVal pvs_idCliente As String,
                                                   ByVal pvi_idTipoCotizacion As Integer,
                                                   ByVal pvi_Modalidad As Integer,
                                                   ByVal pvs_Contacto As String,
                                                   ByVal pvs_Faena As String,
                                                   ByVal pvs_Precio As Integer,
                                                   ByVal pvi_idVendedor As Integer,
                                                   ByVal pvi_idUsuario As Integer,
                                                   ByVal pvi_EstadoCoti As Integer,
                                                   ByVal pvi_CantHoras As Integer,
                                                   ByVal pvs_TextoAlternativo As String,
                                                   ByVal pvi_idZona As Integer,
                                                   ByVal pvi_Condiciones() As Integer,
                                                   ByVal pvi_Implementaciones() As Integer) As Boolean
        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarCotizacion"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0

            'Verificamos si el usuario a agregar tiene la opcion de sistema de aprobación por area
            'For i = 0 To pvi_OpcionesUsuario.Length - 1
            '    If pvi_OpcionesUsuario(i) = 1 Then
            '        vli_UsuarioAprobador = 1
            '        Exit For
            '    End If
            'Next

            'Instancia del objeto de la capa AD
            vpo_ManejadorCotizaciones = New AD.AD_COTIZACIONES.cls_Cotizaciones

            vlo_Retorno = vpo_ManejadorCotizaciones.fgo_ActualizarCotizacion(pvi_idCotizacion,
                                                                              pvi_idEquipo,
                                                                              pvs_idCliente,
                                                                              pvi_idTipoCotizacion,
                                                                              pvi_Modalidad,
                                                                              pvs_Contacto,
                                                                              pvs_Faena,
                                                                              pvs_Precio,
                                                                              pvi_idVendedor,
                                                                              pvi_idUsuario,
                                                                              pvi_EstadoCoti,
                                                                              pvi_CantHoras,
                                                                              pvs_TextoAlternativo,
                                                                              pvi_idZona)





            'Ahora agregamos las opciones del sistema para el usuario en cuestión
            'For i = 0 To pvi_Condiciones.Length - 1
            'If pvi_Condiciones(i) <> 0 Then
            vpo_ManejadorCotizaciones.fgo_EliminarCondicion(pvi_idCotizacion)
            'End If
            'Next

            'Ahora agregamos las opciones del sistema para el usuario en cuestión
            'For i = 0 To pvi_Implementaciones.Length - 1
            'If pvi_Implementaciones(i) <> 0 Then
            vpo_ManejadorCotizaciones.fgo_EliminarImplementacion(pvi_idCotizacion)
            'End If
            'Next

            'Ahora agregamos las opciones del sistema para el usuario en cuestión
            For i = 0 To pvi_Condiciones.Length - 1
                If pvi_Condiciones(i) <> 0 Then
                    vpo_ManejadorCotizaciones.fgo_AgregarCondicion(pvi_idCotizacion, pvi_Condiciones(i))
                End If
            Next

            'Ahora agregamos las opciones del sistema para el usuario en cuestión
            For i = 0 To pvi_Implementaciones.Length - 1
                If pvi_Implementaciones(i) <> 0 Then
                    vpo_ManejadorCotizaciones.fgo_AgregarImplementacion(pvi_idCotizacion, pvi_Implementaciones(i))
                End If
            Next

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Insertar_Cotizacion, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.Insertar_Cotizacion, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_ValidarCotizacion(ByVal pvi_idCOTI As Integer) As Boolean
        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_ValidarCotizacion"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            'Instancia del objeto de la capa AD
            vpo_ManejadorCotizaciones = New AD.AD_COTIZACIONES.cls_Cotizaciones
            vlo_Retorno = vpo_ManejadorCotizaciones.fgo_ValidarCotizacion(pvi_idCOTI)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Validar_Cotizacion, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If

            If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                vlb_RetornoFuncion = True
                ' GoTo RetornoFuncion
            End If

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.Validar_Cotizacion, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_ActualizarEstadoCotizacion(ByVal pvi_idCotizacion As Integer,
                                                   ByVal pvi_EstadoCoti As Integer) As Boolean
        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarEstadoCotizacion"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            vpo_ManejadorCotizaciones = New AD.AD_COTIZACIONES.cls_Cotizaciones

            vlo_Retorno = vpo_ManejadorCotizaciones.fgo_ActualizarEstadoCotizacion(pvi_idCotizacion,
                                                                              pvi_EstadoCoti)



            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Actualizar_Estado_Cotizacion, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.Actualizar_Estado_Cotizacion, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function


#Region "ENUMERADORES"
    ''' <summary>
    ''' Enumeradores de validaciones.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum eNm_Validaciones As Short
        parametro_requerido
        no_existen
        ingresa_no_data
    End Enum
    ''' <summary>
    ''' Enumeradores de excepciones.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum eNm_Excepciones As Short
        Insertar_Cotizacion
        Actualizar_Estado_Cotizacion
        Validar_Cotizacion
    End Enum
    Public Enum enm_CapaExcepciones As Short
        acceso_datos
        regla_de_negocio
        interfaz_de_usuarios
    End Enum
#End Region

End Class
