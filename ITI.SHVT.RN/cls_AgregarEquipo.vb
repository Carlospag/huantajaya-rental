Namespace RN_REGISTRAREQUIPO

    Public Class cls_AgregarEquipo

#Region "VARIABLES"
        Private vpo_ManejadorUsuario As AD.AD_REGISTRAREQUIPO.cls_AgregarEquipo
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

#Region "METODOS Y FUNCIONES"
        'inicio de cambio 17/01/2024
        Public Function fgb_RegistrarEquipo(ByVal pvi_Afi As Integer,
                                            ByVal pvs_NumeroSerie As String,
                                            ByVal pvs_NombreEquipo As String,
                                            ByVal pvi_ValorCompra As Integer,
                                            ByVal pvs_MarcaEquipo As String,
                                            ByVal pvs_ModeloEquipo As String,
                                            ByVal pvs_Color As String,
                                            ByVal pvs_Patente As String,
                                            ByVal pvd_FechaAdquisicion As Date,
                                            ByVal pvi_Familia As Integer,
                                            ByVal pvi_Sucursal As Integer,
                                            ByVal pvi_EstadoEquipo As Integer,
                                            ByVal pvi_idUsuario As Integer,
                                            ByVal pvi_Horometro As Integer,
                                            ByVal pvs_Procedencia As String,
                                            ByVal pvi_AnhoEquipo As Integer,
                                            ByRef pvi_LargoEquipo As Integer,
                                            ByRef pvi_AltoEquipo As Integer,
                                            ByRef pvi_AnchoEquipo As Integer,
                                            ByRef pvi_PesoEquipo As Integer,
                                            ByRef pvs_AccionamientoEquipo As String,
                                            ByRef pvs_Dato1Equipo As String,
                                            ByRef pvs_Dato2Equipo As String
                                            ) As Boolean

            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarEquipo"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                Dim vli_UsuarioAprobador As Integer = 0



                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_REGISTRAREQUIPO.cls_AgregarEquipo

                vlo_Retorno = vpo_ManejadorUsuario.fgo_RegistrarEquipo(pvi_Afi,
                                                                     pvs_NumeroSerie,
                                                                     pvs_NombreEquipo,
                                                                     pvi_ValorCompra,
                                                                     pvs_MarcaEquipo,
                                                                     pvs_ModeloEquipo,
                                                                     pvs_Color,
                                                                     pvs_Patente,
                                                                     pvd_FechaAdquisicion,
                                                                     pvi_Familia,
                                                                     pvi_Sucursal,
                                                                     pvi_EstadoEquipo,
                                                                     pvi_idUsuario,
                                                                     pvi_Horometro,
                                                                     pvs_Procedencia,
                                                                     pvi_AnhoEquipo,
                                                                     pvi_LargoEquipo,
                                                                     pvi_AltoEquipo,
                                                                     pvi_AnchoEquipo,
                                                                     pvi_PesoEquipo,
                                                                     pvs_AccionamientoEquipo,
                                                                     pvs_Dato1Equipo,
                                                                     pvs_Dato2Equipo)

                'fin del cambio 17/01/2024
                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.registrar_Equipo, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.registrar_Equipo, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_BuscarAfi(ByVal pvi_Afi As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_BuscarRutCliente"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_REGISTRAREQUIPO.cls_AgregarEquipo
                vlo_Retorno = vpo_ManejadorUsuario.fgo_BuscarAfi(pvi_Afi)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.buscar_afi, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If

                If (vlo_Retorno.Item("filas_afectadas") > 0) Then
                    vlb_RetornoFuncion = True
                    ' GoTo RetornoFuncion
                End If

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.buscar_afi, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarEquipo(ByVal pvi_Afi As Integer,
                                             ByVal pvs_NumeroSerie As String,
                                             ByVal pvs_NombreEquipo As String,
                                             ByVal pvi_ValorCompra As Integer,
                                             ByVal pvs_MarcaEquipo As String,
                                             ByVal pvs_ModeloEquipo As String,
                                             ByVal pvs_Color As String,
                                             ByVal pvs_Patente As String,
                                             ByVal pvd_FechaAdquisicion As Date,
                                             ByVal pvi_Familia As Integer,
                                             ByVal pvi_Sucursal As Integer,
                                             ByVal pvi_EstadoEquipo As Integer,
                                             ByVal pvi_idUsuario As Integer,
                                             ByVal pvi_Horometro As Integer,
                                             ByVal pvs_Procedencia As String,
                                             ByVal pvi_AnhoEquipo As Integer,
                                             ByRef pvi_LargoEquipo As Integer,
                                             ByRef pvi_AltoEquipo As Integer,
                                             ByRef pvi_AnchoEquipo As Integer,
                                             ByRef pvi_PesoEquipo As Integer,
                                             ByRef pvs_AccionamientoEquipo As String,
                                             ByRef pvs_Dato1Equipo As String,
                                             ByRef pvs_Dato2Equipo As String
                                             ) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarEquipo"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                Dim vli_UsuarioAprobador As Integer = 0

                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_REGISTRAREQUIPO.cls_AgregarEquipo

                vlo_Retorno = vpo_ManejadorUsuario.fgo_ActualizarEquipo(pvi_Afi,
                                                                        pvs_NumeroSerie,
                                                                        pvs_NombreEquipo,
                                                                        pvi_ValorCompra,
                                                                        pvs_MarcaEquipo,
                                                                        pvs_ModeloEquipo,
                                                                        pvs_Color,
                                                                        pvs_Patente,
                                                                        pvd_FechaAdquisicion,
                                                                        pvi_Familia,
                                                                        pvi_Sucursal,
                                                                        pvi_EstadoEquipo,
                                                                        pvi_idUsuario,
                                                                        pvi_Horometro,
                                                                        pvs_Procedencia,
                                                                        pvi_AnhoEquipo,
                                                                        pvi_LargoEquipo,
                                                                        pvi_AltoEquipo,
                                                                        pvi_AnchoEquipo,
                                                                        pvi_PesoEquipo,
                                                                        pvs_AccionamientoEquipo,
                                                                        pvs_Dato1Equipo,
                                                                        pvs_Dato2Equipo
                                                                        )
                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.actualizar_equipo, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.actualizar_equipo, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
            End Try
RetornoFuncion:
            'Retorno función
            Return vlb_RetornoFuncion
        End Function

        Public Function fgb_ActualizarHorometro(ByVal pvi_Afi As Integer,
                                             ByVal pvs_FechaActualizacion As Date,
                                             ByVal pvi_Horometro As Integer) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarHorometro"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection
                Dim vli_UsuarioAprobador As Integer = 0

                'Instancia del objeto de la capa AD
                vpo_ManejadorUsuario = New AD.AD_REGISTRAREQUIPO.cls_AgregarEquipo

                vlo_Retorno = vpo_ManejadorUsuario.fgo_ActualizarHorometro(pvi_Afi,
                                                                           pvs_FechaActualizacion,
                                                                           pvi_Horometro)

                If Not vlo_Retorno.Item("estado") Then
                    'Activación de evento de excepción
                    RaiseEvent eExcepciones(eNm_Excepciones.actualizar_Horometro, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                    GoTo RetornoFuncion
                End If
                vlb_RetornoFuncion = True
                GoTo RetornoFuncion

            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.actualizar_Horometro, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
            buscar_afi
            buscar_Equipo
            agregar_equipo
            registrar_Equipo
            actualizar_equipo
            actualizar_Horometro
        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region

    End Class

End Namespace