Namespace RN_AGREGARUSUARIO
    Public Class cls_AgregarUsuarios

#Region "VARIABLES"
        Private vpo_ManejadorUsuario As AD.AD_AGREGARUSUARIO.cls_AgregarUsuarios
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

#Region "MÉTODOS Y FUNCIONES"
        ''' <summary>
        ''' Busca a un usuario en el sistema por su rut para realizar una validación antes de agregar al sistema un nuevo usuario.
        ''' </summary>
        ''' <param name="pvs_RutUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgb_BuscarRutUsuario(ByVal pvs_RutUsuario As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_BuscarRutUsuario"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_AGREGARUSUARIO.cls_AgregarUsuarios
                vlo_Retorno = vpo_ManejadorUsuario.fgo_BuscarRutUsuario(pvs_RutUsuario)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.buscar_RutUsuario, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    ' GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.buscar_RutUsuario, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_BuscarContrasena(ByVal pvi_idUsuario As Integer, ByVal pvs_Contrasena As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_BuscarContrasena"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_AGREGARUSUARIO.cls_AgregarUsuarios
                vlo_Retorno = vpo_ManejadorUsuario.fgo_BuscarContrasena(pvi_idUsuario, pvs_Contrasena)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.buscar_Contrasena, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    ' GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.buscar_Contrasena, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        ''' <summary>
        ''' Busca un usuario en el sistema segun su nombre de usuario para realizar una posterior verificación antes de agregarlo.
        ''' </summary>
        ''' <param name="pvs_Usuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgb_BuscarUsuario(ByVal pvs_Usuario As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_BuscarUsuario"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_AGREGARUSUARIO.cls_AgregarUsuarios
                vlo_Retorno = vpo_ManejadorUsuario.fgo_BuscarUsuario(pvs_Usuario)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.buscar_Usuario, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    ' GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.buscar_Usuario, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        ''' <summary>
        ''' Manejador para realizar un ingreso al sistema de un nuevo usuario en conjunto de todos sus opciones en el sistema
        ''' </summary>
        ''' <param name="pvs_RutUsuario"></param>
        ''' <param name="pvs_Usuario"></param>
        ''' <param name="pvi_OpcionesUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgb_AgregarUsuario(ByVal pvs_RutUsuario As String,
                                           ByVal pvs_NombreUsuario As String,
                                           ByVal pvs_Apaterno As String,
                                           ByVal pvs_Amaterno As String,
                                           ByVal pvs_CorreoUsuario As String,
                                           ByVal pvs_Nombres As String,
                                           ByVal pvi_TipoCargo As Integer,
                                           ByVal pvi_Telefono As Integer,
                                           ByVal ParamArray pvi_OpcionesUsuario() As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_AgregarUsuario"
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
                vpo_ManejadorUsuario = New AD.AD_AGREGARUSUARIO.cls_AgregarUsuarios

                vlo_Retorno = vpo_ManejadorUsuario.fgo_AgregarUsuario(pvs_RutUsuario,
                                                                      pvs_NombreUsuario,
                                                                      pvs_Apaterno,
                                                                      pvs_Amaterno,
                                                                      pvs_CorreoUsuario,
                                                                      pvs_Nombres,
                                                                      pvi_TipoCargo,
                                                                      pvi_Telefono)

                'Ahora agregamos las opciones del sistema para el usuario en cuestión
                For i = 0 To pvi_OpcionesUsuario.Length - 1
                    If pvi_OpcionesUsuario(i) <> 0 Then
                        vpo_ManejadorUsuario.fgo_AgregarOpcionUsuario(vlo_Retorno("valor_agregado"), pvi_OpcionesUsuario(i))
                    End If
                Next

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.agregar_Usuario, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.agregar_Usuario, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
            buscar_Usuario
            buscar_RutUsuario
            agregar_Usuario
            buscar_contrasena
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region

    End Class
End Namespace

