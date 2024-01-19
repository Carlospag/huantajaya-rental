Namespace RN_REGISTRARCLIENTE
    Public Class cls_RegistrarCliente

#Region "VARIABLES"
        Private vpo_ManejadorUsuario As AD.AD_REGISTRARCLIENTE.cls_RegistrarCliente
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

#Region "METODOS Y FUNCIONES"

        Public Function fgb_RegistrarCliente(ByVal pvs_RutCliente As String,
                                             ByVal pvi_Ciudad As Integer,
                                             ByVal pvs_NombreCliente As String,
                                             ByVal pvs_NombreRepresentante As String,
                                             ByVal pvi_TelUno As Integer,
                                             ByVal pvi_TelDos As Integer,
                                             ByVal pvs_CorreoUno As String,
                                             ByVal pvs_CorreoDos As String,
                                             ByVal pvs_Observaciones As String,
                                             ByVal pvi_EstadoCliente As Integer,
                                             ByVal pvd_FechaRegistro As Date,
                                             ByVal pvi_idUsuario As Integer,
                                             ByVal pvs_Direccion As String,
                                             ByVal pvs_NombreRepresentanteFinanzas As String,
                                             ByVal pvs_CargoContacto As String,
                                             ByVal pvs_CargoFinanzas As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarCliente"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                Dim vli_UsuarioAprobador As Integer = 0



                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_REGISTRARCLIENTE.cls_RegistrarCliente

                vlo_Retorno = vpo_ManejadorUsuario.fgo_RegistrarCliente(pvs_RutCliente,
                                                                     pvi_Ciudad,
                                                                     pvs_NombreCliente,
                                                                     pvs_NombreRepresentante,
                                                                     pvi_TelUno,
                                                                     pvi_TelDos,
                                                                     pvs_CorreoUno,
                                                                     pvs_CorreoDos,
                                                                     pvs_Observaciones,
                                                                     pvi_EstadoCliente,
                                                                     pvd_FechaRegistro,
                                                                     pvi_idUsuario,
                                                                     pvs_Direccion,
                                                                     pvs_NombreRepresentanteFinanzas,
                                                                     pvs_CargoContacto,
                                                                     pvs_CargoFinanzas)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.registrar_Cliente, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.registrar_Cliente, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarCliente(ByVal pvs_RutCliente As String,
                                             ByVal pvi_Ciudad As Integer,
                                             ByVal pvs_NombreCliente As String,
                                             ByVal pvs_NombreRepresentante As String,
                                             ByVal pvi_TelUno As Integer,
                                             ByVal pvi_TelDos As Integer,
                                             ByVal pvs_CorreoUno As String,
                                             ByVal pvs_CorreoDos As String,
                                             ByVal pvs_Observaciones As String,
                                             ByVal pvi_EstadoCliente As Integer,
                                             ByVal pvd_FechaRegistro As Date,
                                             ByVal pvi_idUsuario As Integer,
                                             ByVal pvs_Direccion As String,
                                             ByVal pvs_NombreRepresentanteFinanzas As String,
                                             ByVal pvs_CargoContacto As String,
                                             ByVal pvs_CargoFinanzas As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarCliente"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                Dim vli_UsuarioAprobador As Integer = 0

                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_REGISTRARCLIENTE.cls_RegistrarCliente

                vlo_Retorno = vpo_ManejadorUsuario.fgo_ActualizarCliente(pvs_RutCliente,
                                                                     pvi_Ciudad,
                                                                     pvs_NombreCliente,
                                                                     pvs_NombreRepresentante,
                                                                     pvi_TelUno,
                                                                     pvi_TelDos,
                                                                     pvs_CorreoUno,
                                                                     pvs_CorreoDos,
                                                                     pvs_Observaciones,
                                                                     pvi_EstadoCliente,
                                                                     pvd_FechaRegistro,
                                                                     pvi_idUsuario,
                                                                     pvs_Direccion,
                                                                     pvs_NombreRepresentanteFinanzas,
                                                                     pvs_CargoContacto,
                                                                     pvs_CargoFinanzas)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.registrar_Cliente, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.registrar_Cliente, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_BuscarRutCliente(ByVal pvs_RutCliente As String) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_BuscarRutCliente"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_REGISTRARCLIENTE.cls_RegistrarCliente
                vlo_Retorno = vpo_ManejadorUsuario.fgo_BuscarCliente(pvs_RutCliente)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.buscar_Cliente, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    ' GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.buscar_Cliente, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
            buscar_Cliente
            buscar_RutCliente
            agregar_Clienteo
            registrar_Cliente
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region

    End Class
End Namespace
