
Namespace RN_CONTRATOS


    Public Class cls_Contratos

#Region "VARIABLES"
        Private vpo_ManejadorContratos As AD.AD_CONTRATOS.cls_Contratos
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

        Public Function fgb_RegistrarContrato(ByVal pvi_idUsuario As Integer,
                                              ByVal pvs_RutCliente As String,
                                              ByVal pvi_idEmpresa As Integer,
                                              ByVal pvd_FechaContrato As Date,
                                              ByVal pvd_FechaRegistroContrato As Date,
                                              ByVal pvi_EstadoContrato As Integer,
                                              ByVal pvi_idZona As Integer,
                                              ByVal pvi_Afi As Integer,
                                              ByVal pvi_TipoUnidad As Integer,
                                              ByVal pvi_ValorUnitario As Integer,
                                              ByVal pvs_Faena As String,
                                              ByVal pvi_Guia As Integer,
                                              ByVal pvi_idCotizacion As Integer) As Boolean

            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarContrato"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Dim vli_UsuarioAprobador As Integer = 0

                'Instancia del objeto de la capa AD
                vpo_ManejadorContratos = New AD.AD_CONTRATOS.cls_Contratos

                '' Insertar el contrato en la base de datos
                vlo_Retorno = vpo_ManejadorContratos.fgo_RegistrarContrato(pvi_idUsuario,
                                                                           pvs_RutCliente,
                                                                           pvi_idEmpresa,
                                                                           pvd_FechaContrato,
                                                                           pvd_FechaRegistroContrato,
                                                                           pvi_EstadoContrato,
                                                                           pvi_Afi)


                Dim pvi_idContrato As Integer = vlo_Retorno("valor_agregado")
                '' Insertar el detalle del contrato, posterior a esto hacer un for para recorrer mas de un equipo por contrato, de momento queda asi
                If pvi_idContrato <> 0 Then
                    vpo_ManejadorContratos.fgo_RegistrarDetalleContrato(pvi_idContrato,
                                                                        pvi_idZona,
                                                                        pvi_Afi,
                                                                        pvi_ValorUnitario,
                                                                        pvi_TipoUnidad,
                                                                        pvs_Faena,
                                                                        pvi_Guia,
                                                                        pvi_idCotizacion)
                    vlb_RetornoFuncion = True
                Else
                    vlb_RetornoFuncion = False
                End If

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Registrar_Contrato, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                'vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Registrar_Contrato, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarContrato(ByVal pvi_idContrato As Integer,
                                                   ByVal pvi_EstadoContrato As Integer) As Boolean


            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarContrato"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorContratos = New AD.AD_CONTRATOS.cls_Contratos

                vlo_Retorno = vpo_ManejadorContratos.fgo_ActualizarContrato(pvi_idContrato,
                                                                        pvi_EstadoContrato)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.actualizar_contrato, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.actualizar_contrato, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarFechaRecepcion(ByVal pvi_idContrato As Integer,
                                                   ByVal pvd_FechaRecepcion As Date) As Boolean


            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarFechaRecepcion"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorContratos = New AD.AD_CONTRATOS.cls_Contratos

                vlo_Retorno = vpo_ManejadorContratos.fgo_ActualizarFechaRecepcion(pvi_idContrato,
                                                                        pvd_FechaRecepcion)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.actualizar_contrato, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.actualizar_contrato, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_AdjuntarDocumentoContratos(ByVal pvi_idContrato As Integer,
                                                  ByVal pvs_NombreArchivoLimpio As String,
                                                  ByVal pvs_NombreArchivoCompleto As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_AdjuntarDocumento"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorContratos = New AD.AD_CONTRATOS.cls_Contratos

                vlo_Retorno = vpo_ManejadorContratos.fgo_AdjuntarDocumentoContrato(pvi_idContrato,
                                                                      pvs_NombreArchivoLimpio,
                                                                      pvs_NombreArchivoCompleto)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Adjuntar_documento, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Adjuntar_documento, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
            Registrar_Contrato
            buscar_contrato
            actualizar_contrato
            Adjuntar_documento
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region
    End Class
End Namespace
