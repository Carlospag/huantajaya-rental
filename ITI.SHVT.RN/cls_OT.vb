Public Class cls_OT

    Private vpo_DatosTrabajadores As AD.cls_OT
    Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
    Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)

    Public Function fgo_DatosTrabajadores(ByVal id_Trabajador As Integer, ByVal Tiempo As Integer) As DataTable

        Dim vlo_RetornoFuncion As New DataTable
        Dim vls_NombreFuncionMetodo As String = "fgo_DatosTrabajadores"

        'Inicio de captura de errores
        Try
            'Variable que recibe el retorno de la capa AD
            Dim vlo_Retorno As New Collection

            'Instancia de objeto
            vpo_DatosTrabajadores = New AD.cls_OT

            'Obtiene información de releción de turnos personal nombrada
            vlo_Retorno = vpo_DatosTrabajadores.fgo_DatosTrabajador(id_Trabajador, Tiempo)
            'Verificación de correcta ejecución de la capa AD
            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.DatosTrabajadores, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            'Verificación de existencia
            Dim vlo_DataSet As DataSet = vlo_Retorno.Item("datos")
            If vlo_DataSet IsNot Nothing AndAlso vlo_DataSet.Tables.Count > 0 AndAlso vlo_DataSet.Tables(0).Rows.Count > 0 Then
                vlo_RetornoFuncion = vlo_DataSet.Tables(0)
                Return vlo_RetornoFuncion
                'GoTo RetornoFuncion
            End If

            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.DatosTrabajadores, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try

RetornoFuncion:
        'Retorno función
        Return vlo_RetornoFuncion
    End Function

    Public Function fgb_RegistrarOT(ByVal pvi_NumeroOT As Integer,
                                            ByVal pvi_AFI As Integer,
                                            ByVal pvi_Responsable As Integer,
                                            ByVal pvi_Supervisor As Integer,
                                            ByVal pvd_FechaOT As Date,
                                            ByVal pvi_IdTipoOT As Integer,
                                            ByVal pvi_idUsuario As Integer) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarOT"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_RegistrarOT = New AD.cls_OT

            vlo_Retorno = vpo_RegistrarOT.fgo_RegistrarOT(pvi_NumeroOT,
                                                          pvi_AFI,
                                                          pvi_Responsable,
                                                          pvi_Supervisor,
                                                          pvd_FechaOT,
                                                          pvi_IdTipoOT,
                                                          pvi_idUsuario)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Registrar_OT, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.Registrar_OT, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_ActualizarOT(ByVal pvi_NumeroOT As Integer,
                                            ByVal pvi_AFI As Integer,
                                            ByVal pvi_Responsable As Integer,
                                            ByVal pvi_Supervisor As Integer,
                                            ByVal pvd_FechaOT As DateTime,
                                            ByVal pvi_IdTipoOT As Integer,
                                            ByVal pvi_CostoRepuesto As Integer,
                                            ByVal pvi_EstadoOT As Integer) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarOT"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_RegistrarOT = New AD.cls_OT

            vlo_Retorno = vpo_RegistrarOT.fgo_ActualizarOT(pvi_NumeroOT,
                                                          pvi_AFI,
                                                          pvi_Responsable,
                                                          pvi_Supervisor,
                                                          pvd_FechaOT,
                                                          pvi_IdTipoOT,
                                                          pvi_CostoRepuesto,
                                                          pvi_EstadoOT)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Actualizar_OT, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.Actualizar_OT, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_RegistrarActividadOT(ByVal pvi_NumeroOT As Integer,
                                            ByVal pvi_idActividad As Integer) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarActividadOT"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_RegistrarOT = New AD.cls_OT

            vlo_Retorno = vpo_RegistrarOT.fgo_RegistrarActividadOT(pvi_NumeroOT,
                                                                            pvi_idActividad)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Registrar_OT, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.Registrar_OT, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function


    Public Function fgb_ElimiarActividadOT(ByVal pvi_NumeroOT As Integer) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_ElimiarActividadOT"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_RegistrarOT = New AD.cls_OT

            vlo_Retorno = vpo_RegistrarOT.fgo_EliminarActividadOT(pvi_NumeroOT)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.EliminarActividad, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.EliminarActividad, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_ElimiarTrabajadorOT(ByVal pvi_NumeroOT As Integer) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_ElimiarTrabajadorOT"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_RegistrarOT = New AD.cls_OT

            vlo_Retorno = vpo_RegistrarOT.fgo_EliminarTrabajadorOT(pvi_NumeroOT)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.EliminarTrabajadorOT, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.EliminarTrabajadorOT, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_ActualizarEstadoOT(ByVal pvi_NumeroOT As Integer,
                                            ByVal pvi_EstadoOT As Integer,
                                           ByVal pvs_Observacion As String) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarEstadoOT"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_RegistrarOT = New AD.cls_OT

            vlo_Retorno = vpo_RegistrarOT.fgo_ActualizarEstadoOT(pvi_NumeroOT,
                                                                            pvi_EstadoOT, pvs_Observacion)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Registrar_OT, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.Registrar_OT, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Function fgb_RegistrarTrabajadordOT(ByVal pvi_NumeroOT As Integer,
                                              ByVal pvi_idTrabajador As Integer,
                                              ByVal pvi_Horas As Integer) As Boolean

        Dim vlb_RetornoFuncion As Boolean = False
        Dim vls_NombreFuncionMetodo As String = "fgb_RegistrarTrabajadordOT"
        Try
            'Variable que recibe el retorno de AD
            Dim vlo_Retorno As New Collection
            Dim vli_UsuarioAprobador As Integer = 0



            'Instancia del objeto de la capa AD
            Dim vpo_RegistrarOT = New AD.cls_OT

            vlo_Retorno = vpo_RegistrarOT.fgo_RegistrarTrabajadorOT(pvi_NumeroOT,
                                                                   pvi_idTrabajador,
                                                                   pvi_Horas)

            If Not vlo_Retorno.Item("estado") Then
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.Registrar_OT, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                GoTo RetornoFuncion
            End If
            vlb_RetornoFuncion = True
            GoTo RetornoFuncion

        Catch ex As Exception
            'Activación de evento de excepción
            RaiseEvent eExcepciones(eNm_Excepciones.Registrar_OT, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
        End Try
RetornoFuncion:
        'Retorno función
        Return vlb_RetornoFuncion
    End Function

    Public Enum eNm_Validaciones As Short
        parametro_requerido
        no_existen
        ingresa_no_data
    End Enum
    Public Enum eNm_Excepciones As Short
        DatosTrabajadores
        Registrar_OT
        Actualizar_OT
        EliminarActividad
        EliminarTrabajadorOT
    End Enum
    Public Enum enm_CapaExcepciones As Short
        acceso_datos
        regla_de_negocio
        interfaz_de_usuarios
    End Enum

End Class
