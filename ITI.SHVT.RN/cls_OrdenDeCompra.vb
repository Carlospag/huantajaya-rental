Public Class cls_OrdenDeCompra


    Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
    Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)

    Public Function fgb_RegistrarOC(ByVal pvs_RutProveedor As String,
                                           ByVal pvi_dctoCompra As Integer,
                                           ByVal pvi_MedioPago As Integer,
                                           ByVal pvi_CCGeneral As Integer,
                                           ByVal pvi_CCEspecifico As Integer,
                                           ByVal pvd_Fecha As Date) As Boolean



        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarOC"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_RegistrarOC = New AD.cls_OrdenDeCompra

            vlo_Retorno = vpo_RegistrarOC.fgo_RegistrarOC(pvs_RutProveedor, pvi_dctoCompra, pvi_MedioPago, pvi_CCGeneral, pvi_CCEspecifico, pvd_Fecha)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.RegistrarOC, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.RegistrarOC, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function
    Public Function fgb_RegistrarDetalleOC(ByVal pvi_NumeroOC As Integer,
                                           ByVal pvs_NombreProducto As String,
                                           ByVal pvi_Cantidad As Double,
                                           ByVal pvi_ValorUnitario As Double,
                                           ByVal pvi_Descuento As Double,
                                           ByVal pvi_TipoDescuento As Integer,
                                           ByVal pvi_TotalFila As Double) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarDetalleOC"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_RegistrarOC = New AD.cls_OrdenDeCompra

            vlo_Retorno = vpo_RegistrarOC.fgo_RegistrarDetalleOC(pvi_NumeroOC, pvs_NombreProducto, pvi_Cantidad, pvi_ValorUnitario, pvi_Descuento, pvi_TipoDescuento, pvi_TotalFila)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.RegistrarDetalleOC, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.RegistrarDetalleOC, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_RegistrarFactura(ByVal pvi_idOC As Integer,
                                           ByVal pvi_NumeroFactura As Integer,
                                           ByVal pvd_FechaFactura As Date,
                                         ByVal pvd_FechaPago As String,
                                           ByVal pvi_ValorFactura As Double,
                                           ByVal pvi_Estado As Integer) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarFactura"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_RegistrarOC = New AD.cls_OrdenDeCompra

            vlo_Retorno = vpo_RegistrarOC.fgo_RegistrarFactura(pvi_idOC, pvi_NumeroFactura, pvd_FechaFactura, pvd_FechaPago, pvi_ValorFactura, pvi_Estado)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.RegistrarFactura, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.RegistrarFactura, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_EliminarFacturaOC(ByVal pvi_idOC As Integer) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_EliminarFacturaOC"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_RegistrarOC = New AD.cls_OrdenDeCompra

            vlo_Retorno = vpo_RegistrarOC.fgo_EliminarFacturaOC(pvi_idOC)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.EliminarFacturaOC, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.EliminarFacturaOC, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function
    Public Function fgb_ActualizarEstadoOC(ByVal pvi_NumeroOC As Integer,
                                            ByVal pvi_EstadoOC As Integer,
                                            ByVal USUARIO As Integer) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarEstadoOC"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_ActualizarOC = New AD.cls_OrdenDeCompra

            vlo_Retorno = vpo_ActualizarOC.fgo_ActualizarEstadoOC(pvi_NumeroOC,
                                                                            pvi_EstadoOC, USUARIO)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.ActualizarEstadoOC, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.ActualizarEstadoOC, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_PagarFacturaOC(ByVal pvi_NumeroFactura As Integer,
                                            ByVal pvd_FechaPago As Date) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_PagarFacturaOC"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_OC = New AD.cls_OrdenDeCompra

            vlo_Retorno = vpo_OC.fgo_PagarFacturaOC(pvi_NumeroFactura,
                                                                            pvd_FechaPago)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.PagarFacturaOC, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.PagarFacturaOC, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_ProcesarOC(ByVal pvi_NumeroOC As Integer,
                                            ByVal pvi_EstadoOC As Integer) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_ProcesarOC"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_ActualizarOC = New AD.cls_OrdenDeCompra

            vlo_Retorno = vpo_ActualizarOC.fgo_ProcesarOC(pvi_NumeroOC,
                                                                            pvi_EstadoOC)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.ProcesarOC, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.ProcesarOC, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function
    Public Enum eNm_Validaciones As Short
        parametro_requerido
        no_existen
        ingresa_no_data
    End Enum
    Public Enum eNm_Excepciones As Short
        DatosTrabajadores
        Registrar_OT
        Actualizar_OT
        EliminarActividad
        EliminarTrabajadorOT
        RegistrarDetalleOC
        RegistrarOC
        ActualizarEstadoOC
        RegistrarFactura
        EliminarFacturaOC
        ProcesarOC
        PagarFacturaOC
    End Enum
    Public Enum enm_CapaExcepciones As Short
        acceso_datos
        regla_de_negocio
        interfaz_de_usuarios
    End Enum
End Class
