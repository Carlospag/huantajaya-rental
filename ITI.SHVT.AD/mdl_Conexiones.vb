''' <summary>
''' Módulo de conexiones a base de datos.
''' </summary>
''' <remarks>Marcelo Woloszyn - 29/04/2013</remarks>
Module mdl_Conexiones

#Region "PROPIEDADES"
    ''' <summary>
    ''' Entrega la cadena de conexión a la base de datos principal del software SGT.
    ''' </summary>
    ''' <value></value>
    ''' <returns>Cadena de conexión a la base de datos</returns>
    ''' <remarks>Marcelo Woloszyn - 29/04/2013</remarks>
    Public ReadOnly Property pgs_ConnectionStringBDPrincipalSHVT() As String
        Get
            'Retorno de propiedad (Cadena de conexión se obtiene de las propiedades del proyecto, archivo app.config)
            Return My.Settings.SHVTBDConnectionStringDesarrollo


            'Return My.Settings.SHVTBDConnectionStringExplotacion
        End Get
    End Property


    
#End Region

End Module
