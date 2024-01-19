Imports System.Net.Mime.MediaTypeNames

Namespace RN_ADMINISTRARCASO

    Public Class cls_AdministrarCaso

#Region "VARIABLES"
        Private vpo_ManejadorCaso As AD.AD_ADMINISTRARCASO.cls_AdministrarCaso
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

#Region "MÉTODOS Y FUNCIONES"
        ''BUSCAR UN CASO
        Public Function fgb_BuscarCaso(ByVal pvi_id_Caso As Integer) As String
            Dim vlb_RetornoFuncion As String = ""
            Dim vls_NombreFuncionMetodo As String = "fgb_BuscarCaso"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorCaso = New AD.AD_ADMINISTRARCASO.cls_AdministrarCaso
                vlo_Retorno = vpo_ManejadorCaso.fgo_BuscarCaso(pvi_id_Caso)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.buscar_Caso, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("valor_agregado") <> "") Then
                    vlb_RetornoFuncion = vlo_Retorno.Item("valor_agregado")
                    ' GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.buscar_Caso, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        ''ACTUALIZAR UN CASO
        Public Function fgb_ActualizarCaso(ByVal pvi_idCaso As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarCaso"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorCaso = New AD.AD_ADMINISTRARCASO.cls_AdministrarCaso

                vlo_Retorno = vpo_ManejadorCaso.fgo_ActualizarCaso(pvi_idCaso)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        ''ACTUALIZAR EL TIPO DE CASO
        Public Function fgb_ActualizarIdTipoCaso(ByVal pvs_RutColaborador As String,
                                                 ByVal pvi_idTipoCaso As Integer,
                                                 ByVal pvs_id_TipoCausa As String,
                                                 ByVal pvd_FechaCaso As Date,
                                                 ByVal pvi_id_Caso As Integer) As Integer
            Dim vlb_RetornoFuncion As Integer = -1
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarIdTipoCaso"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorCaso = New AD.AD_ADMINISTRARCASO.cls_AdministrarCaso

                vlo_Retorno = vpo_ManejadorCaso.fgb_ActualizarIdTipoCaso(pvs_RutColaborador, pvi_idTipoCaso, pvs_id_TipoCausa, pvd_FechaCaso, pvi_id_Caso)
                If (vlo_Retorno.Item("valor_agregado") >= 0) Then
                    vlb_RetornoFuncion = vlo_Retorno.Item("valor_agregado")
                    GoTo RetornoFuncion
                End If

                ' GoTo RetornoFuncion

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If



            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        ''INSERTAR DOCUEMTNOS AL CASO
        Public Function fgb_InsertarDocumentos(ByVal pvi_idCaso As Integer,
                                               ByVal pvs_NombreDocumento As String,
                                               ByVal pvs_ContentType As Byte,
                                               ByVal pvs_Data As Image) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarCaso"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorCaso = New AD.AD_ADMINISTRARCASO.cls_AdministrarCaso

                vlo_Retorno = vpo_ManejadorCaso.fgo_InsertarDocumentos(pvi_idCaso,
                                                                       pvs_NombreDocumento,
                                                                       pvs_ContentType,
                                                                       pvs_Data)


                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Insertar_Documentos, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Insertar_Documentos, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        ''GENERAR LA CARTA
        Public Function fgb_GeneracionCartas(ByVal dt_Cartas As DataTable) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_GeneracionCartas"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Ciclo FOR que recorre todas las tablas
                For Each tablaDatos As DataRow In dt_Cartas.Rows
                    ' Ciclo FOR que recorre cada solicitud efectuada para los dirigentes.

                    Dim pvi_idCaso As Integer = tablaDatos(0)

                    'Instancia del objeto de la capa AD
                    vpo_ManejadorCaso = New AD.AD_ADMINISTRARCASO.cls_AdministrarCaso

                    vlo_Retorno = vpo_ManejadorCaso.fgo_ActualizarCaso(pvi_idCaso)

                    If Not vlo_Retorno.Item("estado") Then
                        'Activación de evento de excepción
                        RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                        Throw New Exception()
                        'GoTo RetornoFuncion
                    End If
                Next
                'si no están mandando una fecha nula o en blanco.
                vlb_RetornoFuncion = True
                ' GoTo RetornoFuncion
            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try

RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        ''AJUSTAR PARAMETROS DE ABSOLCIÓN
        Public Function fgb_AjusteParametro(ByVal Valor As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_AjusteParametro"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorCaso = New AD.AD_ADMINISTRARCASO.cls_AdministrarCaso

                vlo_Retorno = vpo_ManejadorCaso.fgo_AjusteParametro(Valor)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    Throw New Exception()
                    'GoTo RetornoFuncion
                End If

                'si no están mandando una fecha nula o en blanco.
                vlb_RetornoFuncion = True
                ' GoTo RetornoFuncion
            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try

RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        ''ADJUNTAR DOCUMENTOS
        Public Function fgb_AdjuntarDocumento(ByVal pvi_id_Caso As Integer,
                                              ByVal pvs_NombreArchivoLimpio As String,
                                              ByVal pvs_NombreArchivoCompleto As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_AdjuntarDocumento"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorCaso = New AD.AD_ADMINISTRARCASO.cls_AdministrarCaso

                vlo_Retorno = vpo_ManejadorCaso.fgo_AdjuntarDocumento(pvi_id_Caso,
                                                                      pvs_NombreArchivoLimpio,
                                                                      pvs_NombreArchivoCompleto)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.adjuntar_documento, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.adjuntar_documento, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        ''ELIMINAR DOCUMENTOS
        Public Function fgb_EliminarDocumento(ByVal pvi_id_Documento As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_AdjuntarDocumento"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorCaso = New AD.AD_ADMINISTRARCASO.cls_AdministrarCaso

                vlo_Retorno = vpo_ManejadorCaso.fgo_EliminarDocumento(pvi_id_Documento)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.eliminar_documento, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.eliminar_documento, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        ''ACTUALIZAR MODAL
        Public Function fgb_ActualizarModal(ByVal pvi_idCaso As Integer,
                                            ByVal pvs_nroFolio As String,
                                            ByVal pvi_EstadoCaso As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarModal"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorCaso = New AD.AD_ADMINISTRARCASO.cls_AdministrarCaso

                vlo_Retorno = vpo_ManejadorCaso.fgo_ActualizarModal(pvi_idCaso, pvs_nroFolio, pvi_EstadoCaso)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarTipoCaso(ByVal pvi_TipoCaso As Integer,
                                               ByVal pvd_Desde As Date,
                                               ByVal pvd_Hasta As Date) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarTipoCaso"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorCaso = New AD.AD_ADMINISTRARCASO.cls_AdministrarCaso

                vlo_Retorno = vpo_ManejadorCaso.fgo_ActualizarTipoCaso(pvi_TipoCaso, pvd_Desde, pvd_Hasta)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.actualizar_caso, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function
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
            buscar_Caso
            cambiar_estado_novedad
            modificar_novedad
            agregar_novedad
            actualizar_caso
            Insertar_Documentos
            eliminar_documento
            adjuntar_documento
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region
    End Class

End Namespace