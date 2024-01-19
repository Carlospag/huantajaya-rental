Namespace RN_PROVEEDORES
    Public Class cls_Proveedores
#Region "VARIABLES"
        Private vpo_ManejadorUsuario As AD.AD_PROVEEDORES.cls_Proveedores
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

#Region "METODOS Y FUNCIONES"

        Public Function fgb_RegistrarProveedor(ByVal pvs_RutProveedor As String,
                                               ByVal pvs_NombreProveedor As String,
                                               ByVal pvs_GiroProveedor As String,
                                               ByVal pvs_DireccionProveedor As String,
                                               ByVal pvi_RegionProveedor As Integer,
                                               ByVal pvi_ComunaProveedor As Integer,
                                               ByVal pvs_TelefonoProveedor As String,
                                               ByVal pvs_CorreoProveedor As String,
                                               ByVal pvs_NombreContactoProveedor As String,
                                               ByVal pvs_TelefonoContactoProveedor As String,
                                               ByVal pvs_CorreoContactoProveedor As String,
                                               ByVal pvs_DireccionContactoProveedor As String,
                                               ByVal pvi_DocumentoDeCompra As Integer,
                                               ByVal pvi_MedioDePago As Integer,
                                               ByVal pvs_Servicios As String,
                                               ByVal pvi_EstadoProveedor As Integer,
                                               ByVal pvs_RutDestinatario As String,
                                               ByVal pvs_NombreDestinatario As String,
                                               ByVal pvi_idBanco As Integer,
                                               ByVal pvi_idTipoCuenta As Integer,
                                               ByVal pvs_NumeroCuenta As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarProveedor"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                Dim vli_UsuarioAprobador As Integer = 0



                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_PROVEEDORES.cls_Proveedores

                vlo_Retorno = vpo_ManejadorUsuario.fgo_RegistrarProveedor(pvs_RutProveedor,
                                                                          pvs_NombreProveedor,
                                                                          pvs_GiroProveedor,
                                                                          pvs_DireccionProveedor,
                                                                          pvi_RegionProveedor,
                                                                          pvi_ComunaProveedor,
                                                                          pvs_TelefonoProveedor,
                                                                          pvs_CorreoProveedor,
                                                                          pvs_NombreContactoProveedor,
                                                                          pvs_TelefonoContactoProveedor,
                                                                          pvs_CorreoContactoProveedor,
                                                                          pvs_DireccionContactoProveedor,
                                                                          pvi_DocumentoDeCompra,
                                                                          pvi_MedioDePago,
                                                                          pvs_Servicios,
                                                                          pvi_EstadoProveedor,
                                                                          pvs_RutDestinatario,
                                                                          pvs_NombreDestinatario,
                                                                          pvi_idBanco,
                                                                          pvi_idTipoCuenta,
                                                                          pvs_NumeroCuenta)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.registrar_Proveedor, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.registrar_Proveedor, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarProveedor(ByVal pvs_RutProveedor As String,
                                               ByVal pvs_NombreProveedor As String,
                                               ByVal pvs_GiroProveedor As String,
                                               ByVal pvs_DireccionProveedor As String,
                                               ByVal pvi_RegionProveedor As Integer,
                                               ByVal pvi_ComunaProveedor As Integer,
                                               ByVal pvs_TelefonoProveedor As String,
                                               ByVal pvs_CorreoProveedor As String,
                                               ByVal pvs_NombreContactoProveedor As String,
                                               ByVal pvs_TelefonoContactoProveedor As String,
                                               ByVal pvs_CorreoContactoProveedor As String,
                                               ByVal pvs_DireccionContactoProveedor As String,
                                               ByVal pvi_DocumentoDeCompra As Integer,
                                               ByVal pvi_MedioDePago As Integer,
                                               ByVal pvs_Servicios As String,
                                               ByVal pvi_EstadoProveedor As Integer,
                                               ByVal pvs_RutDestinatario As String,
                                               ByVal pvs_NombreDestinatario As String,
                                               ByVal pvi_idBanco As Integer,
                                               ByVal pvi_idTipoCuenta As Integer,
                                               ByVal pvs_NumeroCuenta As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarProveedor"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                Dim vli_UsuarioAprobador As Integer = 0



                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_PROVEEDORES.cls_Proveedores

                vlo_Retorno = vpo_ManejadorUsuario.fgo_ActualizarProveedor(pvs_RutProveedor,
                                                                          pvs_NombreProveedor,
                                                                          pvs_GiroProveedor,
                                                                          pvs_DireccionProveedor,
                                                                          pvi_RegionProveedor,
                                                                          pvi_ComunaProveedor,
                                                                          pvs_TelefonoProveedor,
                                                                          pvs_CorreoProveedor,
                                                                          pvs_NombreContactoProveedor,
                                                                          pvs_TelefonoContactoProveedor,
                                                                          pvs_CorreoContactoProveedor,
                                                                          pvs_DireccionContactoProveedor,
                                                                          pvi_DocumentoDeCompra,
                                                                          pvi_MedioDePago,
                                                                          pvs_Servicios,
                                                                          pvi_EstadoProveedor,
                                                                          pvs_RutDestinatario,
                                                                          pvs_NombreDestinatario,
                                                                          pvi_idBanco,
                                                                          pvi_idTipoCuenta,
                                                                          pvs_NumeroCuenta)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.Actualizar_Proveedor, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.registrar_Proveedor, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_BuscarRutProveedor(ByVal pvs_RutProveedor As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_BuscarRutProveedor"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_PROVEEDORES.cls_Proveedores
                vlo_Retorno = vpo_ManejadorUsuario.fgo_BuscarRutProveedor(pvs_RutProveedor)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.buscar_RutProveedor, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    ' GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.buscar_RutProveedor, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
            buscar_Proveedor
            buscar_RutProveedor
            agregar_Proveedor
            registrar_Proveedor
            Actualizar_Proveedor
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region
    End Class
End Namespace

