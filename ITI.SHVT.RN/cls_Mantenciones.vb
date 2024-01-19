Imports ITI.SHVT

Namespace RN_MANTENCIONES


    Public Class cls_Mantenciones
#Region "VARIABLES"
        Private vpo_ManejadorMantencion As AD.AD_MANTENCIONES.cls_Mantenciones
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region
        Public Function fgb_RegistrarMantencion(ByVal pvi_idEquipo As Integer,
                                                ByVal pvi_Horometro As Integer,
                                                ByVal pvd_FechaMantencion As Date,
                                                ByVal pvs_Observacion As String,
                                                ByVal pvi_idUsuario As Integer) As Boolean

            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarMantencion"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                Dim vli_UsuarioAprobador As Integer = 0



                'Instancia del objeto de la capa AD
                vpo_ManejadorMantencion = New AD.AD_MANTENCIONES.cls_Mantenciones

                vlo_Retorno = vpo_ManejadorMantencion.fgo_RegistrarMantencion(pvi_idEquipo,
                                                                              pvi_Horometro,
                                                                              pvd_FechaMantencion,
                                                                              pvs_Observacion,
                                                                              pvi_idUsuario)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.registrar_Mantencion, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.registrar_Mantencion, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function


        Public Function fgb_AdjuntarDocumentoMantencion(ByVal pvi_idEquipo As Integer,
                                                        ByVal pvs_NombreArchivoLimpio As String,
                                                        ByVal pvs_NombreArchivoCompleto As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_AdjuntarDocumento"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorMantencion = New AD.AD_MANTENCIONES.cls_Mantenciones

                vlo_Retorno = vpo_ManejadorMantencion.fgo_AdjuntarDocumentoMantencion(pvi_idEquipo,
                                                                                     pvs_NombreArchivoLimpio,
                                                                                     pvs_NombreArchivoCompleto)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Adjuntar_documento_mantencion, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Adjuntar_documento_mantencion, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function


        Public Function fgb_ClasificarActividad(ByVal pvi_idFamilia As Integer,
                                                 ByVal pvi_idActividad As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ClasificarActividad"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorMantencion = New AD.AD_MANTENCIONES.cls_Mantenciones

                vlo_Retorno = vpo_ManejadorMantencion.fgo_ClasificarActividad(pvi_idFamilia, pvi_idActividad)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Clasificar_ActividadMantencion, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Clasificar_ActividadMantencion, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_EliminarClasificacionActividad(ByVal pvi_idFamilia As Integer,
                                                             ByVal pvi_idActividad As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_EliminarClasificacionActividad"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorMantencion = New AD.AD_MANTENCIONES.cls_Mantenciones
                vlo_Retorno = vpo_ManejadorMantencion.fgo_EliminarClasificacionActividad(pvi_idFamilia, pvi_idActividad)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.eliminar_clasificacionActividad_Mantencion, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.eliminar_clasificacionActividad_Mantencion, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ClasificarLubricante(ByVal pvi_idFamilia As Integer,
                                                 ByVal pvi_idLubricante As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ClasificarLubricante"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorMantencion = New AD.AD_MANTENCIONES.cls_Mantenciones

                vlo_Retorno = vpo_ManejadorMantencion.fgo_ClasificarLubricante(pvi_idFamilia, pvi_idLubricante)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Clasificar_Lubricante, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Clasificar_Lubricante, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_EliminarLubricante(ByVal pvi_idFamilia As Integer,
                                                             ByVal pvi_idLubricante As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_EliminarLubricante"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorMantencion = New AD.AD_MANTENCIONES.cls_Mantenciones
                vlo_Retorno = vpo_ManejadorMantencion.fgo_EliminarLubricante(pvi_idFamilia, pvi_idLubricante)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.eliminar_Lubricante, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.eliminar_Lubricante, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ClasificarRepuesto(ByVal pvi_idEquipo As Integer,
                                                 ByVal pvi_idRepuesto As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ClasificarRepuesto"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorMantencion = New AD.AD_MANTENCIONES.cls_Mantenciones

                vlo_Retorno = vpo_ManejadorMantencion.fgo_ClasificarRepuesto(pvi_idEquipo, pvi_idRepuesto)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Clasificar_Repuesto, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Clasificar_Repuesto, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_EliminarClasificacionRepuesto(ByVal pvi_idEquipo As Integer,
                                                          ByVal pvi_idRepuesto As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_EliminarClasidicacionRepuesto"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorMantencion = New AD.AD_MANTENCIONES.cls_Mantenciones
                vlo_Retorno = vpo_ManejadorMantencion.fgo_EliminarClasificacionRepuesto(pvi_idEquipo, pvi_idRepuesto)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.eliminar_clasificacion_repuesto, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.eliminar_clasificacion_repuesto, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_RegistrarRepuesto(ByVal pvs_NombreRepuesto As String,
                                              ByVal pvs_OriginalRepuesto As String,
                                              ByVal pvs_AlternativoUnoRepuesto As String,
                                              ByVal pvs_AlternativoDosRepuesto As String,
                                              ByVal pvi_Cantidad As Integer,
                                              ByVal pvi_PrecioRepuesto As Integer) As Boolean

            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarRepuesto"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection



                'Instancia del objeto de la capa AD
                vpo_ManejadorMantencion = New AD.AD_MANTENCIONES.cls_Mantenciones

                vlo_Retorno = vpo_ManejadorMantencion.fgo_RegistrarRepuesto(pvs_NombreRepuesto,
                                                                              pvs_OriginalRepuesto,
                                                                              pvs_AlternativoUnoRepuesto,
                                                                              pvs_AlternativoDosRepuesto,
                                                                              pvi_Cantidad,
                                                                              pvi_PrecioRepuesto)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.registrar_Repuesto, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.registrar_Repuesto, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_RegistrarLubricante(ByVal pvs_NombreLubricante As String,
                                              ByVal pvs_TipoLubricante As String,
                                              ByVal pvs_CantidadLubricante As String,
                                              ByVal pvi_PrecioLubricante As String) As Boolean

            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarLubricante"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection



                'Instancia del objeto de la capa AD
                vpo_ManejadorMantencion = New AD.AD_MANTENCIONES.cls_Mantenciones

                vlo_Retorno = vpo_ManejadorMantencion.fgo_RegistrarLubricante(pvs_NombreLubricante,
                                                                              pvs_TipoLubricante,
                                                                              pvs_CantidadLubricante,
                                                                              pvi_PrecioLubricante)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.registrar_Lubricante, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.registrar_Lubricante, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_RegistrarActividad(ByVal pvs_NombreActividad As String) As Boolean

            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarActividad"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection



                'Instancia del objeto de la capa AD
                vpo_ManejadorMantencion = New AD.AD_MANTENCIONES.cls_Mantenciones

                vlo_Retorno = vpo_ManejadorMantencion.fgo_RegistrarActividad(pvs_NombreActividad)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.registrar_Actividad, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.registrar_Actividad, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
            registrar_Mantencion
            Adjuntar_documento_mantencion
            Clasificar_ActividadMantencion
            eliminar_clasificacionActividad_Mantencion
            eliminar_Lubricante
            Clasificar_Lubricante
            Clasificar_Repuesto
            eliminar_clasificacion_repuesto
            registrar_Repuesto
            registrar_Lubricante
            registrar_Actividad
            buscar_mantencion
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region
    End Class
End Namespace
