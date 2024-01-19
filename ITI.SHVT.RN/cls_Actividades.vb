Imports ITI.SHVT
Namespace RN_ACTIVIDADES

    Public Class cls_Actividades


#Region "VARIABLES"
        Private vpo_ManejadorActividades As AD.AD_ACTIVIDADES.cls_Actividades
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

        Public Function fgb_RegistrarActividad(ByVal pvs_NombreActividad As String,
                                               ByVal pviCantidadActividad As Integer,
                                               ByVal pvi_Implementacion As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarActividad"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Instancia del objeto de la capa AD
                vpo_ManejadorActividades = New AD.AD_ACTIVIDADES.cls_Actividades

                vlo_Retorno = vpo_ManejadorActividades.fgo_RegistrarActividad(pvs_NombreActividad,
                                                                            pviCantidadActividad,
                                                                            pvi_Implementacion)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Registrar_Actividad, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Registrar_Actividad, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ModificarActividad(ByVal pvi_idActiviad As Integer,
                                             ByVal pvs_NombreActividad As String,
                                             ByVal pvi_EstadoActividad As Integer,
                                             ByVal pvi_Cantidad As Integer,
                                             ByVal pvi_Implementacion As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarCliente"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                Dim vli_UsuarioAprobador As Integer = 0

                'Instancia del objeto de la capa AD
                vpo_ManejadorActividades = New AD.AD_ACTIVIDADES.cls_Actividades

                vlo_Retorno = vpo_ManejadorActividades.fgo_ModificarActividad(pvi_idActiviad,
                                                                              pvs_NombreActividad,
                                                                              pvi_EstadoActividad,
                                                                              pvi_Cantidad,
                                                                              pvi_Implementacion)


                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Modificar_Actividad, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Modificar_Actividad, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
                vpo_ManejadorActividades = New AD.AD_ACTIVIDADES.cls_Actividades

                vlo_Retorno = vpo_ManejadorActividades.fgo_ClasificarActividad(pvi_idFamilia, pvi_idActividad)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Clasificar_Actividad, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Clasificar_Actividad, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
                vpo_ManejadorActividades = New AD.AD_ACTIVIDADES.cls_Actividades
                vlo_Retorno = vpo_ManejadorActividades.fgo_EliminarClasificacionActividad(pvi_idFamilia, pvi_idActividad)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.eliminar_clasificacion_actividad, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.eliminar_clasificacion_actividad, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
            Registrar_Actividad
            Modificar_Actividad
            Clasificar_Actividad
            eliminar_clasificacion_actividad
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region
    End Class

End Namespace
