Namespace RN_MODIFICARUSUARIO
    Public Class cls_ModificarUsuario

#Region "VARIABLES"
        Private vpo_ManejadorUsuario As AD.AD_MODIFICARUSUARIO.cls_ModificarUsuario
        Private vpo_IngresarOpcionesUsuario As AD.AD_AGREGARUSUARIO.cls_AgregarUsuarios
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

#Region "MÉTODOS Y FUNCIONES"

        ''' Modificación de todo el formulario del usuario en cuestión.
        Public Function fgb_ModificarUsuario(ByVal pvs_idUsuario As String,
                                            ByVal pvs_NombreUsuario As String,
                                            ByVal pvs_Apaterno As String,
                                            ByVal pvs_Amaterno As String,
                                            ByVal pvs_CorreoUsuario As String,
                                            ByVal pvs_Nombres As String,
                                            ByVal pvi_TipoCargo As Integer,
                                            ByVal pvi_EstadoUsuario As Integer,
                                            ByVal pvi_Telefono As Integer,
                                            ByVal ParamArray pvi_OpcionesUsuario() As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ModificarUsuario"
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
                vpo_ManejadorUsuario = New AD.AD_MODIFICARUSUARIO.cls_ModificarUsuario

                vlo_Retorno = vpo_ManejadorUsuario.fgo_ModificarUsuario(pvs_idUsuario,
                                                                      pvs_NombreUsuario,
                                                                      pvs_Apaterno,
                                                                      pvs_Amaterno,
                                                                      pvs_CorreoUsuario,
                                                                      pvs_Nombres,
                                                                      pvi_TipoCargo,
                                                                      pvi_EstadoUsuario,
                                                                      pvi_Telefono)

                'Primero eliminamos todas las opciones del usuario en el sistema
                vpo_ManejadorUsuario.fgo_EliminarOpcionesUsuario(pvs_idUsuario)

                'Ahora ingresamos las opciones del sistema para el usuario en cuestión
                'Instancia del objeto de la capa AD
                vpo_IngresarOpcionesUsuario = New AD.AD_AGREGARUSUARIO.cls_AgregarUsuarios

                For i = 0 To pvi_OpcionesUsuario.Length - 1
                    If pvi_OpcionesUsuario(i) <> 0 Then
                        vpo_IngresarOpcionesUsuario.fgo_AgregarOpcionUsuario(pvs_idUsuario, pvi_OpcionesUsuario(i))
                    End If
                Next

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.modificar_Usuario, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.modificar_Usuario, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_CambiarContrasena(ByVal pvs_idUsuario As Integer,
                                            ByVal pvs_Contrasena As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_CambiarContrasena"
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
                vpo_ManejadorUsuario = New AD.AD_MODIFICARUSUARIO.cls_ModificarUsuario

                vlo_Retorno = vpo_ManejadorUsuario.fgo_CambiarContrasena(pvs_idUsuario,
                                                                      pvs_Contrasena)



                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.modificar_Usuario, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.modificar_Usuario, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
            modificar_Usuario
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum

#End Region

    End Class
End Namespace