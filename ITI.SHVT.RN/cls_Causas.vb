Namespace RN_CAUSAS
    Public Class cls_Causas
#Region "VARIABLES"
        Private vpo_ManejadorCausas As AD.AD_CAUSAS.cls_Causas
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

        ''' <summary>
        ''' Agregar caausales al sistema
        ''' </summary>
        ''' <param name="pvs_NombreCausa"></param>
        ''' <param name="pvs_DetalleCausa"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgb_AgregarCausas(ByVal pvs_NombreCausa As String,
                                                   ByVal pvs_DetalleCausa As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_AgregarUsuario"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorCausas = New AD.AD_CAUSAS.cls_Causas

                vlo_Retorno = vpo_ManejadorCausas.fgo_AgregarCausas(pvs_NombreCausa,
                                                                      pvs_DetalleCausa)

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

        ''' <summary>
        ''' Modificar causas
        ''' </summary>
        ''' <param name="pvi_idCausa"></param>
        ''' <param name="pvs_NombreCausa"></param>
        ''' <param name="pvs_DetalleCausa"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgb_ModificarCausas(ByVal pvi_idCausa As Integer,
                                            ByVal pvs_NombreCausa As String,
                                            ByVal pvs_DetalleCausa As String,
                                            ByVal pvi_EstadoCausa As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ModificarCausas"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorCausas = New AD.AD_CAUSAS.cls_Causas

                vlo_Retorno = vpo_ManejadorCausas.fgo_ModificarCausas(pvi_idCausa,
                                                                    pvs_NombreCausa,
                                                                    pvs_DetalleCausa,
                                                                    pvi_EstadoCausa)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Modificar_causas, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Modificar_causas, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
                vpo_ManejadorCausas = New AD.AD_CAUSAS.cls_Causas
                vlo_Retorno = vpo_ManejadorCausas.fgo_BuscarCausa(pvi_id_TipoCausa)

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
            Modificar_causas
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

