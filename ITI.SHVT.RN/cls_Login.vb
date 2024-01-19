Namespace RN_LOGIN

    Public Class cls_Login
#Region "VARIABLES"
        Private vpo_ManejadorUsuario As AD.AD_LOGIN.cls_Login
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

#Region "MÉTODOS Y FUNCIONES"

        ''' <summary>
        ''' Comprobar existencia de usuario y retorna url
        ''' </summary>
        ''' <param name="pvs_Usuario"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' 
        ''' 
        ''' </remarks>
        Public Function fgb_VerificarUsuario(ByVal pvs_Usuario As String,
                                             ByVal pvs_Contrasena As String) As String
            Dim vlb_RetornoFuncion As String = ""
            Dim vls_NombreFuncionMetodo As String = "fgb_VerificarUsuario"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_LOGIN.cls_Login
                vlo_Retorno = vpo_ManejadorUsuario.fgo_VerificarUsuario(pvs_Usuario, pvs_Contrasena)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.buscar_Usuario, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("valor_agregado") <> "") Then
                    vlb_RetornoFuncion = vlo_Retorno.Item("valor_agregado")
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.buscar_Usuario, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_VerificarOpcionSistema(ByVal pvi_id_Usuario As Integer,
                                                   ByVal pvs_Url As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_VerificarOpcionSistema"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_LOGIN.cls_Login
                vlo_Retorno = vpo_ManejadorUsuario.fgo_VerificarOpcionSistema(pvi_id_Usuario,
                                                                              pvs_Url)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.verificar_url, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.verificar_url, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
            verificar_url
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region
    End Class

End Namespace