Namespace RN_CONFIRMACIONFALTOS
    Public Class cls_ConfirmacionFaltos

#Region "VARIABLES"
        Private vpo_ConfirmacionFaltos As AD.AD_CONFIRMACIONFALTOS.cls_ConfirmacionFaltos
        Event eValidaciones(ByVal pveNm_Validacion As eNm_Validaciones)
        Event eExcepciones(ByVal pveNm_Excepcion As eNm_Excepciones, ByVal pveNm_CapaExcepciones As SERV.enm_CapaExcepciones, ByVal pvs_ClaseExcepcion As String, ByVal pvs_FuncionMetodoExcepcion As String, ByVal pvl_NroExcepcion As Long, ByVal pvs_MensajeDeExcepcion As String)
#End Region

#Region "METODOS Y FUNCIONES"
        
        Public Function fgb_ConfirmacionFaltos(ByVal dt_DatosFaltos As DataTable) As Boolean
            Dim vlb_RetornoFuncion As Boolean = False
            Dim vls_NombreFuncionMetodo As String = "fgb_ConfirmacionFaltos"
            Try
                'Variable que recibe el retorno de AD
                Dim vlo_Retorno As New Collection

                'Ciclo FOR que recorre todas las tablas
                For Each tablaDatos As DataRow In dt_DatosFaltos.Rows
                    ' Ciclo FOR que recorre cada solicitud efectuada para los dirigentes.

                    Dim pvs_RutColaborador As String = tablaDatos(0)
                    Dim pvd_FechaCaso As Date = tablaDatos(1)
                    Dim pvd_TurnoCaso As String = tablaDatos(2)
                 
                    If pvd_TurnoCaso = "No aplica" Then
                        pvd_TurnoCaso = "999"
                    Else
                        pvd_TurnoCaso = pvd_TurnoCaso
                    End If


                    Dim vpo_ConfirmacionFaltos As New AD.AD_CONFIRMACIONFALTOS.cls_ConfirmacionFaltos
                    vlo_Retorno = vpo_ConfirmacionFaltos.fgo_ConfirmacionFalto(pvs_RutColaborador, pvd_FechaCaso, pvd_TurnoCaso)

                    If Not vlo_Retorno.Item("estado") Then
                        'Activación de evento de excepción
                        RaiseEvent eExcepciones(eNm_Excepciones.insercion_ConfirmacionFaltos, vlo_Retorno.Item("capa_excepcion"), vlo_Retorno.Item("clase_excepcion"), vlo_Retorno.Item("funcion_metodo_excepcion"), vlo_Retorno.Item("nro_excepcion"), vlo_Retorno.Item("mensaje_excepcion"))
                        Throw New Exception()
                        'GoTo RetornoFuncion
                    End If
                Next
                'si no están mandando una fecha nula o en blanco.
                vlb_RetornoFuncion = True
                ' GoTo RetornoFuncion
            Catch ex As Exception
                'Activación de evento de excepción
                RaiseEvent eExcepciones(eNm_Excepciones.insercion_ConfirmacionFaltos, enm_CapaExcepciones.regla_de_negocio, Me.ToString, vls_NombreFuncionMetodo, System.Runtime.InteropServices.Marshal.GetHRForException(ex), ex.Message)
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
            insercion_ConfirmacionFaltos

        End Enum
        Public Enum enm_CapaExcepciones As Short
            acceso_datos
            regla_de_negocio
            interfaz_de_usuarios
        End Enum
#End Region
    End Class
End Namespace