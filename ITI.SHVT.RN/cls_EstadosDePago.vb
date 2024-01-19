Namespace RN_ESTADOSDEPAGO


    Public Class cls_EstadosDePago


#Region "VARIABLES"
        Private vpo_ManejadorEP As AD.AD_ESTADOSDEPAGO.cls_EstadosDePago
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

#Region "METODOS Y FUNCIONES"
        Public Function fgb_RegistrarEstadoDePago(ByVal pvi_EstadoComercial As Integer,
                                            ByVal pvi_CorrelativoEP As Integer,
                                            ByVal pvd_FechaInicioEP As Date,
                                            ByVal pvd_FechaFinEP As Date,
                                            ByVal pvi_Contrato As Integer,
                                            ByVal pvi_TipoUnidad As Integer,
                                            ByVal pvi_Tarifa As Integer,
                                            ByVal pvi_DiasFacturar As Integer,
                                            ByVal pvi_ValorNeto As Integer,
                                            ByVal pvi_HorasFacturar As Integer,
                                            ByVal pvs_Observaciones As String,
                                            ByVal pvi_idUsuario As Integer,
                                            ByVal pvi_TipoEstadoPago As Integer,
                                            ByVal pvi_AFI As Integer,
                                            ByVal pvs_Cliente As String,
                                            ByVal pvi_Sucursal As Integer) As Boolean


            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarEstadoDePago"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                Dim vli_UsuarioAprobador As Integer = 0



                'Instancia del objeto de la capa AD
                vpo_ManejadorEP = New AD.AD_ESTADOSDEPAGO.cls_EstadosDePago

                vlo_Retorno = vpo_ManejadorEP.fgo_RegistrarEstadoDePago(pvi_EstadoComercial,
                                                                     pvi_CorrelativoEP,
                                                                     pvd_FechaInicioEP,
                                                                     pvd_FechaFinEP,
                                                                     pvi_Contrato,
                                                                     pvi_TipoUnidad,
                                                                     pvi_Tarifa,
                                                                     pvi_DiasFacturar,
                                                                     pvi_ValorNeto,
                                                                     pvi_HorasFacturar,
                                                                     pvs_Observaciones,
                                                                     pvi_idUsuario,
                                                                     pvi_TipoEstadoPago,
                                                                     pvi_AFI,
                                                                     pvs_Cliente,
                                                                     pvi_Sucursal)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.CREAR_ESTADO_PAGO, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.CREAR_ESTADO_PAGO, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarEstadoDePago(ByVal pvi_idEstadoPago As Integer,
                                                   ByVal pvi_EstadoComercial As Integer,
                                                   ByVal pvi_CorrelativoEP As Integer,
                                                   ByVal pvd_FechaInicioEP As Date,
                                                   ByVal pvd_FechaFinEP As Date,
                                                   ByVal pvi_Contrato As Integer,
                                                   ByVal pvi_TipoUnidad As Integer,
                                                   ByVal pvi_Tarifa As Integer,
                                                   ByVal pvi_DiasFacturar As Integer,
                                                   ByVal pvi_ValorNeto As Integer,
                                                   ByVal pvi_HorasFacturar As Integer,
                                                   ByVal pvs_Observaciones As String,
                                                   ByVal pvi_idUsuario As Integer,
                                                   ByVal pvi_TipoEPago As Integer,
                                                   ByVal pvi_AfiVentaCobro As Integer,
                                                   ByVal pvi_Sucursal As Integer) As Boolean


            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarEstadoDePago"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorEP = New AD.AD_ESTADOSDEPAGO.cls_EstadosDePago

                vlo_Retorno = vpo_ManejadorEP.fgo_ActualizarEstadoDePago(pvi_idEstadoPago,
                                                                        pvi_EstadoComercial,
                                                                         pvi_CorrelativoEP,
                                                                         pvd_FechaInicioEP,
                                                                         pvd_FechaFinEP,
                                                                         pvi_Contrato,
                                                                         pvi_TipoUnidad,
                                                                         pvi_Tarifa,
                                                                         pvi_DiasFacturar,
                                                                         pvi_ValorNeto,
                                                                         pvi_HorasFacturar,
                                                                         pvs_Observaciones,
                                                                         pvi_idUsuario,
                                                                        pvi_TipoEPago,
                                                                        pvi_AfiVentaCobro,
                                                                        pvi_Sucursal)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.ACTUALIZAR_ESTADO_PAGO, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.ACTUALIZAR_ESTADO_PAGO, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarNumeroFactura(ByVal pvi_idEstadoPago As Integer,
                                                   ByVal pvi_NumeroFactura As Integer,
                                                   ByVal pvd_FechaFacturacion As Date, ByVal pvi_SucursalFactura As Integer) As Boolean


            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarNumeroFactura"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorEP = New AD.AD_ESTADOSDEPAGO.cls_EstadosDePago

                vlo_Retorno = vpo_ManejadorEP.fgo_ActualizarNumeroFactura(pvi_idEstadoPago,
                                                                        pvi_NumeroFactura,
                                                                         pvd_FechaFacturacion, pvi_SucursalFactura)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.ActualizarNumeroFactura, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.ActualizarNumeroFactura, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarPagoFactura(ByVal pvi_idEstadoPago As Integer, ByVal FechaPago As Date) As Boolean


            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarPagoFactura"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorEP = New AD.AD_ESTADOSDEPAGO.cls_EstadosDePago

                vlo_Retorno = vpo_ManejadorEP.fgo_ActualizarPagoFactura(pvi_idEstadoPago, FechaPago)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.ActualizarNumeroFactura, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.ActualizarNumeroFactura, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarAbonoFactura(ByVal pvi_idEstadoPago As Integer, ByVal ValorAbono As Integer) As Boolean


            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarAbonoFactura"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorEP = New AD.AD_ESTADOSDEPAGO.cls_EstadosDePago

                vlo_Retorno = vpo_ManejadorEP.fgo_ActualizarAbonoFactura(pvi_idEstadoPago, ValorAbono)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.InsertarAbono, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.InsertarAbono, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarPagoFacturaTodos(ByVal NumeroFactura As Integer, ByVal FechaPagoTodos As Date) As Boolean


            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarPagoFacturaTodos"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorEP = New AD.AD_ESTADOSDEPAGO.cls_EstadosDePago

                vlo_Retorno = vpo_ManejadorEP.fgo_ActualizarPagoFacturaTodos(NumeroFactura, FechaPagoTodos)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.PagarFacturaTodos, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.PagarFacturaTodos, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ConfirmarAnularEP(ByVal pvi_idEstadoPago As Integer,
                                              ByVal pvi_EstadoComercial As Integer) As Boolean

            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ConfirmarAnularEP"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorEP = New AD.AD_ESTADOSDEPAGO.cls_EstadosDePago
                '' Insertar el contrato en la base de datos
                vlo_Retorno = vpo_ManejadorEP.fgo_ConfirmarAnularEP(pvi_idEstadoPago,
                                                                           pvi_EstadoComercial)


                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.AnularConfirmarEP, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.AnularConfirmarEP, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function
        Public Function fgb_ListadoEstadosDePago(ByVal dt_EstadosDePago As DataTable) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ListadoEstadosDePaGO"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Ciclo FOR que recorre todas las tablas
                If dt_EstadosDePago.Rows.Count > 0 Then
                    Dim vpo_EstadosDePago As New AD.AD_ESTADOSDEPAGO.cls_EstadosDePago
                    vlo_Retorno = vpo_EstadosDePago.fgo_ListadoEstadosDePago(dt_EstadosDePago)
                End If
                'si no están mandando una fecha nula o en blanco.
                vlb_RetornoFuncion = True
                ' GoTo RetornoFuncion
            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.ListaEDP, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try

RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function
        Public Function fgb_ListadoFacturacionAgrupada(ByVal dt_FacturacionAgrupado As DataTable) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ListadoFacturacionAgrupada"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Ciclo FOR que recorre todas las tablas
                If dt_FacturacionAgrupado.Rows.Count > 0 Then
                    Dim vpo_EstadosDePago As New AD.AD_ESTADOSDEPAGO.cls_EstadosDePago
                    vlo_Retorno = vpo_EstadosDePago.fgo_ListadoFacturacionAgrupado(dt_FacturacionAgrupado)
                End If
                'si no están mandando una fecha nula o en blanco.
                vlb_RetornoFuncion = True
                ' GoTo RetornoFuncion
            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.ListaEDP, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try

RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        '        Public Function fgb_ListadoEstadosDePago(ByVal dt_EstadosDePago As DataTable) As Boolean
        '            Dim vlb_RetornoFuncion As Boolean = False
        '            Dim vls_NombreFuncionMetodo As String = "fgb_ListadoEstadosDePaGO"
        '            Try
        '                'Variable que recibe el retorno de AD
        '                Dim vlo_Retorno As New Collection

        '                'Ciclo FOR que recorre todas las tablas
        '                For Each tablaDatos As DataRow In dt_EstadosDePago.Rows
        '                    ' Ciclo FOR que recorre cada solicitud efectuada para los dirigentes.

        '                    Dim id_EstadoDePago As String = tablaDatos(0)

        '                    Dim vpo_EstadosDePago As New AD.AD_ESTADOSDEPAGO.cls_EstadosDePago
        '                    vlo_Retorno = vpo_EstadosDePago.fgo_ListadoEstadosDePago(id_EstadoDePago)

        '                    If Not vlo_Retorno.Item("estado") Then
        '                        'Activación de evento de excepción
        '                        RaiseEvent eExcepciones(eNm_Excepciones.ListaEDP, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
        '                        Throw New Exception()
        '                        'GoTo RetornoFuncion
        '                    End If
        '                Next
        '                'si no están mandando una fecha nula o en blanco.
        '                vlb_RetornoFuncion = True
        '                ' GoTo RetornoFuncion
        '            Catch ex As Exception
        '                'Activación de evento de excepción
        '                RaiseEvent eExcepciones(eNm_Excepciones.ListaEDP, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        '            End Try

        'RetornoFuncion:
        '            'Retorno función
        '            Return vlb_RetornoFuncion
        '        End Function
#End Region

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
            CREAR_ESTADO_PAGO
            ACTUALIZAR_ESTADO_PAGO
            AnularConfirmarEP
            ActualizarNumeroFactura
            PagarFacturaTodos
            ListaEDP
            InsertarAbono
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region
    End Class

End Namespace
