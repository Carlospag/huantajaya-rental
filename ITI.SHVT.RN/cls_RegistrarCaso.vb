Namespace RN_REGISTRARCASO
    Public Class cls_RegistrarCaso

#Region "VARIABLES"
        Private vpo_ManejadorUsuario As AD.AD_REGISTRARCASO.cls_RegistrarCaso
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

#Region "METODOS Y FUNCIONES"
        ''' <summary>
        ''' Registrar caso
        ''' </summary>
        ''' <param name="pvi_TipoCaso"></param>
        ''' <param name="pvi_idUsuario"></param>
        ''' <param name="pvi_TipoCausa"></param>
        ''' <param name="pvs_RutColaborador"></param>
        ''' <param name="pvd_FechaCaso"></param>
        ''' <param name="pvi_TurnoCaso"></param>
        ''' <param name="pvs_MotivoCaso"></param>
        ''' <param name="pvd_FechaRegistroCaso"></param>
        ''' <param name="pvi_EstadoCaso"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgb_RegistrarCaso(ByVal pvi_TipoCaso As Integer,
                                          ByVal pvi_idUsuario As Integer,
                                          ByVal pvi_TipoCausa As Integer,
                                          ByVal pvs_RutColaborador As String,
                                          ByVal pvd_FechaCaso As Date,
                                          ByVal pvi_TurnoCaso As Integer,
                                          ByVal pvs_MotivoCaso As String,
                                          ByVal pvd_FechaRegistroCaso As Date,
                                          ByVal pvi_EstadoCaso As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarCaso"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                Dim vli_UsuarioAprobador As Integer = 0



                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_REGISTRARCASO.cls_RegistrarCaso

                vlo_Retorno = vpo_ManejadorUsuario.fgo_RegistrarCaso(pvi_TipoCaso,
                                                                      pvi_idUsuario,
                                                                      pvi_TipoCausa,
                                                                      pvs_RutColaborador,
                                                                      pvd_FechaCaso,
                                                                      pvi_TurnoCaso,
                                                                      pvs_MotivoCaso,
                                                                      pvd_FechaRegistroCaso,
                                                                      pvi_EstadoCaso)



                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.registrar_caso, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.registrar_caso, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_BuscarCausa(ByVal pvi_id_TipoCausa As Integer) As String
            Dim vlb_RetornoFuncion As String = ""
            Dim vls_NombreFuncionMetodo As String = "fgb_BuscarCausa"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_REGISTRARCASO.cls_RegistrarCaso
                vlo_Retorno = vpo_ManejadorUsuario.fgo_BuscarCausa(pvi_id_TipoCausa)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.buscar_Causa, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("valor_agregado") <> "") Then
                    vlb_RetornoFuncion = vlo_Retorno.Item("valor_agregado")
                    ' GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.buscar_Causa, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
            registrar_caso
            buscar_Causa
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region

    End Class
End Namespace

