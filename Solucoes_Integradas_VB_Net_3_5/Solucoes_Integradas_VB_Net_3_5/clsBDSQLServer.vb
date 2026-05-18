Imports System.Collections.Generic
Imports System.Text

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class clsConexaoBancoDados
        ' Constantes de instancia do SQLServer

        Public Const cntStringConexaoSQLServerOdbc_SegurancaPadrao As String = "Driver={SQL Server}; Server={0}; DataBase={1}; Uid={2}; Pwd={3}; Trusted Connection={4}; Persist Security Info={5}; Connect Timeout={6};"
        Public Const cntStringConexaoSQLServerOdbc_SegurancaConfianca As String = "Driver={SQL Server}; Server={0}; DataBase={1}; Trusted Connection={2}; Persist Security Info={3}; Connect Timeout={4};"
        Public Const cntStringConexaoSQLServerOleDb_SegurancaPadrao As String = "Provider=SQLOLEDB; Data Source={0}; DataBase={1}; UserId={2}; Password={3}; Integrated Security={4}; Persist Security Info={5}; Connect Timeout={6};"
        Public Const cntStringConexaoSQLServerOleDb_SegurancaConfianca As String = "Provider=SQLOLEDB; Data Source={0}; DataBase={1}; Integrated Security={2}; Persist Security Info={3}; Connect Timeout={4};"
        Public Const cntStringConexaoSQLServerNativa_SegurancaPadrao As String = "Server={0}; DataBase={1}; User ID={2}; Password={3}; Integrated Security={4}; Persist Security Info={5}; Connect Timeout={6};"
        Public Const cntStringConexaoSQLServerNativa_SegurancaConfianca As String = "Server={0}; DataBase={1}; Integrated Security={2}; Persist Security Info={3}; Connect Timeout={4};"

        ' Variaveis somente leitura de instancia do SQLSever

        Private ReadOnly cntDriverSQLServer As String() = {"Driver", "{SQL Server}"}
        Private ReadOnly cntProviderSQLServer As String() = {"Provider", "SQLOLEDB"}
        Private ReadOnly cntServerSQLServer As String() = {"Server", String.Empty}
        Private ReadOnly cntDataBaseSQLServer As String() = {"DataBase", String.Empty}
        Private ReadOnly cntUserIdSQLServer As String() = {"User ID", String.Empty}
        Private ReadOnly cntPasswordSQLServer As String() = {"Password", String.Empty}
        Private ReadOnly cntIntegratedSecuritySQLServer As String() = {"Integrated Security", "False"}
        Private ReadOnly cntPersistSecurityInfoSQLServer As String() = {"Persist Security Info", "False"}
        Private ReadOnly cntConnectTimeoutSQLServer As String() = {"Connect Timeout", "15"}

        ' Variaveis de instancia do SQLServer

        Private strDriverSQLServer As String()
        Private strProviderSQLServer As String()
        Private strServerSQLServer As String()
        Private strDataBaseSQLServer As String()
        Private strUserIdSQLServer As String()
        Private strPasswordSQLServer As String()
        Private strIntegratedSecuritySQLServer As String()
        Private strPersistSecurityInfoSQLServer As String()
        Private strConnectTimeoutSQLServer As String()

        ' Variaveis de instancia do SQLServer

        Private vetDriverSQLServer As String() = {"Driver"}
        Private vetProviderSQLServer As String() = {"Provider"}
        Private vetServerSQLServer As String() = {"Addr", "Address", "DataSource", "Data Source", "NetworkAddress", "Network Address", _
         "Server"}
        Private vetDataBaseSQLServer As String() = {"DataBase", "Data Base", "InitialCatalog", "Initial Catalog"}
        Private vetUserIdSQLServer As String() = {"UserId", "User Id", "Uid"}
        Private vetPasswordSQLServer As String() = {"Password", "Pwd"}
        Private vetIntegratedSecuritySQLServer As String() = {"IntegratedSecurity", "Integrated Security", "TrustedConnection", "Trusted Connection"}
        Private vetPersistSecurityInfoSQLServer As String() = {"PersistSecurityInfo", "Persist Security Info"}
        Private vetConnectTimeoutSQLServer As String() = {"ConnectTimeout", "Connect Timeout"}

        ' Variaveis que determinam se a conexao incorporara o banco de dados. Isso facilita na criacao, alteracao ou delecao do banco de dados.

        Private blnPermitirBancoDadosSQLServer As Boolean = True

        Public Property prpPermitirBancoDadosSQLServer() As Boolean
            Get
                Return blnPermitirBancoDadosSQLServer
            End Get
            Set(ByVal value As Boolean)
                blnPermitirBancoDadosSQLServer = value
            End Set
        End Property

        ' Propriedades de instancia do SQLServer

        Public Property prpDriverSQLServer() As String
            Get
                If strDriverSQLServer Is Nothing Then
                    strDriverSQLServer = New String(1) {cntDriverSQLServer(0), cntDriverSQLServer(1)}
                End If
                Return strDriverSQLServer(1)
            End Get
            Set(ByVal value As String)
                If strDriverSQLServer Is Nothing Then
                    strDriverSQLServer = New String(1) {cntDriverSQLServer(0), cntDriverSQLServer(1)}
                End If
                strDriverSQLServer(1) = value
                mtdReDefinirConexaoString(strDriverSQLServer)
            End Set
        End Property

        Public Property prpProviderSQLServer() As String
            Get
                If strProviderSQLServer Is Nothing Then
                    strProviderSQLServer = New String(1) {cntProviderSQLServer(0), cntProviderSQLServer(1)}
                End If
                Return strProviderSQLServer(1)
            End Get
            Set(ByVal value As String)
                If strProviderSQLServer Is Nothing Then
                    strProviderSQLServer = New String(1) {cntProviderSQLServer(0), cntProviderSQLServer(1)}
                End If
                strProviderSQLServer(1) = value
                mtdReDefinirConexaoString(strProviderSQLServer)
            End Set
        End Property

        Public Property prpServerSQLServer() As String
            Get
                If strServerSQLServer Is Nothing Then
                    strServerSQLServer = New String(1) {cntServerSQLServer(0), cntServerSQLServer(1)}
                End If
                Return strServerSQLServer(1)
            End Get
            Set(ByVal value As String)
                If strServerSQLServer Is Nothing Then
                    strServerSQLServer = New String(1) {cntServerSQLServer(0), cntServerSQLServer(1)}
                End If
                strServerSQLServer(1) = value
                mtdReDefinirConexaoString(strProviderSQLServer)
            End Set
        End Property

        Public Property prpDataBaseSQLServer() As String
            Get
                If strDataBaseSQLServer Is Nothing Then
                    strDataBaseSQLServer = New String(1) {cntDataBaseSQLServer(0), cntDataBaseSQLServer(1)}
                End If
                Return strDataBaseSQLServer(1)
            End Get
            Set(ByVal value As String)
                If strDataBaseSQLServer Is Nothing Then
                    strDataBaseSQLServer = New String(1) {cntDataBaseSQLServer(0), cntDataBaseSQLServer(1)}
                End If
                strDataBaseSQLServer(1) = value
                mtdReDefinirConexaoString(strDataBaseSQLServer)
            End Set
        End Property

        Public Property prpUserIdSQLServer() As String
            Get
                If strUserIdSQLServer Is Nothing Then
                    strUserIdSQLServer = New String(1) {cntUserIdSQLServer(0), cntUserIdSQLServer(1)}
                End If
                Return strUserIdSQLServer(1)
            End Get
            Set(ByVal value As String)
                If strUserIdSQLServer Is Nothing Then
                    strUserIdSQLServer = New String(1) {cntUserIdSQLServer(0), cntUserIdSQLServer(1)}
                End If
                strUserIdSQLServer(1) = value
                mtdReDefinirConexaoString(strUserIdSQLServer)
            End Set
        End Property

        Public Property prpPasswordSQLServer() As String
            Get
                If strPasswordSQLServer Is Nothing Then
                    strPasswordSQLServer = New String(1) {cntPasswordSQLServer(0), cntPasswordSQLServer(1)}
                End If
                Return strPasswordSQLServer(1)
            End Get
            Set(ByVal value As String)
                If strPasswordSQLServer Is Nothing Then
                    strPasswordSQLServer = New String(1) {cntPasswordSQLServer(0), cntPasswordSQLServer(1)}
                End If
                strPasswordSQLServer(1) = value
                mtdReDefinirConexaoString(strPasswordSQLServer)
            End Set
        End Property

        Public Property prpIntegratedSecuritySQLServer() As String
            Get
                If strIntegratedSecuritySQLServer Is Nothing Then
                    strIntegratedSecuritySQLServer = New String(1) {cntIntegratedSecuritySQLServer(0), cntIntegratedSecuritySQLServer(1)}
                End If
                Return strIntegratedSecuritySQLServer(1)
            End Get
            Set(ByVal value As String)
                If strIntegratedSecuritySQLServer Is Nothing Then
                    strIntegratedSecuritySQLServer = New String(1) {cntIntegratedSecuritySQLServer(0), cntIntegratedSecuritySQLServer(1)}
                End If
                strIntegratedSecuritySQLServer(1) = value
                mtdReDefinirConexaoString(strIntegratedSecuritySQLServer)
            End Set
        End Property

        Public Property prpPersistSecurityInfoSQLServer() As String
            Get
                If strPersistSecurityInfoSQLServer Is Nothing Then
                    strPersistSecurityInfoSQLServer = New String(1) {cntPersistSecurityInfoSQLServer(0), cntPersistSecurityInfoSQLServer(1)}
                End If
                Return strPersistSecurityInfoSQLServer(1)
            End Get
            Set(ByVal value As String)
                If strPersistSecurityInfoSQLServer Is Nothing Then
                    strPersistSecurityInfoSQLServer = New String(1) {cntPersistSecurityInfoSQLServer(0), cntPersistSecurityInfoSQLServer(1)}
                End If
                strPersistSecurityInfoSQLServer(1) = value
                mtdReDefinirConexaoString(strPersistSecurityInfoSQLServer)
            End Set
        End Property

        Public Property prpConnectTimeoutSQLServer() As String
            Get
                If strConnectTimeoutSQLServer Is Nothing Then
                    strConnectTimeoutSQLServer = New String(1) {cntConnectTimeoutSQLServer(0), cntConnectTimeoutSQLServer(1)}
                End If
                Return strConnectTimeoutSQLServer(1)
            End Get
            Set(ByVal value As String)
                If strConnectTimeoutSQLServer Is Nothing Then
                    strConnectTimeoutSQLServer = New String(1) {cntConnectTimeoutSQLServer(0), cntConnectTimeoutSQLServer(1)}
                End If
                strConnectTimeoutSQLServer(1) = value
                mtdReDefinirConexaoString(strConnectTimeoutSQLServer)
            End Set
        End Property

        ' Metodos de instancia do SQLServer

        Public Function mtdValidarConexaoDispositivoSQLServer(ByVal Conexao As String) As String()
            strDriverSQLServer = mtdValidarConexao(Conexao, vetDriverSQLServer)
            Return strDriverSQLServer
        End Function

        Public Function mtdValidarConexaoProvedorSQLServer(ByVal Conexao As String) As String()
            strProviderSQLServer = mtdValidarConexao(Conexao, vetProviderSQLServer)
            Return strProviderSQLServer
        End Function

        Public Function mtdValidarConexaoServidorSQLServer(ByVal Conexao As String) As String()
            strServerSQLServer = mtdValidarConexao(Conexao, vetServerSQLServer)
            Return strServerSQLServer
        End Function

        Public Function mtdValidarConexaoBaseDadosSQLServer(ByVal Conexao As String) As String()
            strDataBaseSQLServer = mtdValidarConexao(Conexao, vetDataBaseSQLServer)
            Return strDataBaseSQLServer
        End Function

        Public Function mtdValidarConexaoUsuarioSQLServer(ByVal Conexao As String) As String()
            strUserIdSQLServer = mtdValidarConexao(Conexao, vetUserIdSQLServer)
            Return strUserIdSQLServer
        End Function

        Public Function mtdValidarConexaoSenhaSQLServer(ByVal Conexao As String) As String()
            strPasswordSQLServer = mtdValidarConexao(Conexao, vetPasswordSQLServer)
            Return strPasswordSQLServer
        End Function

        Public Function mtdValidarConexaoSegurancaIntegradaSQLServer(ByVal Conexao As String) As String()
            strIntegratedSecuritySQLServer = mtdValidarConexao(Conexao, vetIntegratedSecuritySQLServer)
            Return strIntegratedSecuritySQLServer
        End Function

        Public Function mtdValidarConexaoPersistenciaSegurancaSQLServer(ByVal Conexao As String) As String()
            strPersistSecurityInfoSQLServer = mtdValidarConexao(Conexao, vetPersistSecurityInfoSQLServer)
            Return strPersistSecurityInfoSQLServer
        End Function

        Public Function mtdValidarConexaoTempoSaidaSQLServer(ByVal Conexao As String) As String()
            strConnectTimeoutSQLServer = mtdValidarConexao(Conexao, vetConnectTimeoutSQLServer)
            Return strConnectTimeoutSQLServer
        End Function

        Public Function mtdValidarConexaoSQLServer(ByVal Conexao As String) As String
            Dim saida As String = String.Empty

            prpTipoConexao = TipoConexao.Indisponivel
            'if (strDriverSQLServer == null || strDriverSQLServer[1] == cntDriverSQLServer[1])
            '{
            mtdValidarConexaoDispositivoSQLServer(Conexao)
            '}
            If strDriverSQLServer IsNot Nothing Then
                prpTipoConexao = TipoConexao.ConexaoSQLServerOdbc
            End If
            'if (strProviderSQLServer == null || strProviderSQLServer[1] == cntProviderSQLServer[1])
            '{
            mtdValidarConexaoProvedorSQLServer(Conexao)
            '}
            If strProviderSQLServer IsNot Nothing Then
                prpTipoConexao = TipoConexao.ConexaoSQLServerOleDb
            End If
            'if (strServerSQLServer == null || strServerSQLServer[1] == cntServerSQLServer[1])
            '{
            mtdValidarConexaoServidorSQLServer(Conexao)
            '}
            'if (strDriverSQLServer == null && strServerSQLServer != null)
            '{
            prpTipoConexao = TipoConexao.ConexaoSQLServerNativa
            '}
            'if (strDataBaseSQLServer == null || strDataBaseSQLServer[1] == cntDataBaseSQLServer[1])
            '{
            mtdValidarConexaoBaseDadosSQLServer(Conexao)
            '}
            'if (strUserIdSQLServer == null || strUserIdSQLServer[1] == cntUserIdSQLServer[1])
            '{
            mtdValidarConexaoUsuarioSQLServer(Conexao)
            '}
            'if (strPasswordSQLServer == null || strPasswordSQLServer[1] == cntPasswordSQLServer[1])
            '{
            mtdValidarConexaoSenhaSQLServer(Conexao)
            '}
            'if (strIntegratedSecuritySQLServer == null || strIntegratedSecuritySQLServer[1] == cntIntegratedSecuritySQLServer[1])
            '{
            mtdValidarConexaoSegurancaIntegradaSQLServer(Conexao)
            '}
            'if (strPersistSecurityInfoSQLServer == null || strPersistSecurityInfoSQLServer[1] == cntPersistSecurityInfoSQLServer[1])
            '{
            mtdValidarConexaoPersistenciaSegurancaSQLServer(Conexao)
            '}
            'if (strConnectTimeoutSQLServer == null || strConnectTimeoutSQLServer[1] == cntConnectTimeoutSQLServer[1])
            '{
            mtdValidarConexaoTempoSaidaSQLServer(Conexao)
            '}

            If strDriverSQLServer IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strDriverSQLServer(0), strDriverSQLServer(1))
            End If
            If strProviderSQLServer IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strProviderSQLServer(0), strProviderSQLServer(1))
            End If
            If strServerSQLServer IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strServerSQLServer(0), strServerSQLServer(1))
            End If
            If strDataBaseSQLServer IsNot Nothing AndAlso blnPermitirBancoDadosSQLServer Then
                saida += String.Format("{0}={1}; ", strDataBaseSQLServer(0), strDataBaseSQLServer(1))
            End If
            If strUserIdSQLServer IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strUserIdSQLServer(0), strUserIdSQLServer(1))
            End If
            If strPasswordSQLServer IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strPasswordSQLServer(0), strPasswordSQLServer(1))
            End If
            If strIntegratedSecuritySQLServer IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strIntegratedSecuritySQLServer(0), strIntegratedSecuritySQLServer(1))
            End If
            If strPersistSecurityInfoSQLServer IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strPersistSecurityInfoSQLServer(0), strPersistSecurityInfoSQLServer(1))
            End If
            If strConnectTimeoutSQLServer IsNot Nothing Then
                saida += String.Format("{0}={1};", strConnectTimeoutSQLServer(0), strConnectTimeoutSQLServer(1))
            End If
            Return saida
        End Function

        Public Function mtdDefinirStringConexaoSQLServer() As String
            Return mtdDefinirStringConexaoSQLServer(prpConexao, True)
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal PermitirBancoDados As Boolean) As String
            Return mtdDefinirStringConexaoSQLServer(prpConexao, PermitirBancoDados)
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal Conexao As String) As String
            Return mtdDefinirStringConexaoSQLServer(Conexao, True)
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal Conexao As String, ByVal PermitirBancoDados As Boolean) As String
            blnPermitirBancoDadosSQLServer = PermitirBancoDados
            mtdValidarConexaoSQLServer(Conexao)
            Return mtdDefinirStringConexaoSQLServer(prpTipoConexao, prpServerSQLServer, prpDataBaseSQLServer, prpUserIdSQLServer, prpPasswordSQLServer, prpIntegratedSecuritySQLServer, _
             prpPersistSecurityInfoSQLServer, prpConnectTimeoutSQLServer)
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal TipoConexao As TipoConexao, ByVal Server As String) As String
            Return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, cntDataBaseSQLServer(1), cntUserIdSQLServer(1), cntPasswordSQLServer(1), "True", _
             cntPersistSecurityInfoSQLServer(1), cntConnectTimeoutSQLServer(1))
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal TipoConexao As TipoConexao, ByVal Server As String, ByVal DataBase As String) As String
            Return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, cntUserIdSQLServer(1), cntPasswordSQLServer(1), "True", _
             cntPersistSecurityInfoSQLServer(1), cntConnectTimeoutSQLServer(1))
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal TipoConexao As TipoConexao, ByVal Server As String, ByVal DataBase As String, ByVal PersistSecurityInfo As Boolean, ByVal ConnectTimeout As Integer) As String
            Return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, cntUserIdSQLServer(1), cntPasswordSQLServer(1), "True", _
             PersistSecurityInfo.ToString(), ConnectTimeout.ToString())
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal TipoConexao As TipoConexao, ByVal Server As String, ByVal DataBase As String, ByVal UserId As String, ByVal Password As String) As String
            Return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, UserId, Password, cntIntegratedSecuritySQLServer(1), _
             cntPersistSecurityInfoSQLServer(1), cntConnectTimeoutSQLServer(1))
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal TipoConexao As TipoConexao, ByVal Server As String, ByVal DataBase As String, ByVal UserId As String, ByVal Password As String, ByVal PersistSecurityInfo As Boolean) As String
            Return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, UserId, Password, cntIntegratedSecuritySQLServer(1), _
             PersistSecurityInfo.ToString(), cntConnectTimeoutSQLServer(1))
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal TipoConexao As TipoConexao, ByVal Server As String, ByVal DataBase As String, ByVal UserId As String, ByVal Password As String, ByVal ConnectTimeout As Integer) As String
            Return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, UserId, Password, cntIntegratedSecuritySQLServer(1), _
             cntPersistSecurityInfoSQLServer(1), ConnectTimeout.ToString())
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal TipoConexao As TipoConexao, ByVal Server As String, ByVal DataBase As String, ByVal UserId As String, ByVal Password As String, ByVal PersistSecurityInfo As Boolean, _
         ByVal ConnectTimeout As Integer) As String
            Return mtdDefinirStringConexaoSQLServer(TipoConexao, Server, DataBase, UserId, Password, cntIntegratedSecuritySQLServer(1), _
             PersistSecurityInfo.ToString(), ConnectTimeout.ToString())
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal TipoConexao As TipoConexao, ByVal Server As String, ByVal DataBase As String, ByVal UserId As String, ByVal Password As String, ByVal IntegratedSecurity As String, _
         ByVal PersistSecurityInfo As String, ByVal ConnectTimeout As String) As String
            Dim blnTipoIntegratedSecurity As Boolean = False
            Dim blnPersistSecurityInfo As Boolean = False

            Select Case IntegratedSecurity.ToLower()
                Case "false"
                    blnTipoIntegratedSecurity = False
                    Exit Select
                Case "no"
                    blnTipoIntegratedSecurity = False
                    Exit Select
                Case "sspi"
                    blnTipoIntegratedSecurity = True
                    Exit Select
                Case "true"
                    blnTipoIntegratedSecurity = True
                    Exit Select
                Case "yes"
                    blnTipoIntegratedSecurity = True
                    Exit Select
            End Select
            Select Case PersistSecurityInfo.ToLower()
                Case "false"
                    blnPersistSecurityInfo = False
                    Exit Select
                Case "no"
                    blnPersistSecurityInfo = False
                    Exit Select
                Case "true"
                    blnPersistSecurityInfo = True
                    Exit Select
                Case "yes"
                    blnPersistSecurityInfo = True
                    Exit Select
            End Select
            Return mtdDefinirStringConexaoSQLServer(TipoConexao, If(Server <> String.Empty, Server, cntServerSQLServer(1)), If(DataBase <> String.Empty, DataBase, cntDataBaseSQLServer(1)), If(UserId <> String.Empty, UserId, cntUserIdSQLServer(1)), If(Password <> String.Empty, Password, cntPasswordSQLServer(1)), blnTipoIntegratedSecurity, _
             blnPersistSecurityInfo, System.Convert.ToInt32(If(ConnectTimeout <> String.Empty, ConnectTimeout, cntConnectTimeoutSQLServer(1))))
        End Function

        Public Function mtdDefinirStringConexaoSQLServer(ByVal TipoConexao As TipoConexao, ByVal Server As String, ByVal DataBase As String, ByVal UserId As String, ByVal Password As String, ByVal IntegratedSecurity As Boolean, _
         ByVal PersistSecurityInfo As Boolean, ByVal ConnectTimeout As Integer) As String
            Dim saida As String = String.Empty
            Select Case TipoConexao
                Case TipoConexao.ConexaoSQLServerOdbc
                    If DataBase <> String.Empty Then
                        DataBase = String.Format("DataBase={0}; ", DataBase)
                    End If
                    If IntegratedSecurity Then
                        saida = String.Format(cntStringConexaoSQLServerOdbc_SegurancaConfianca.Replace(String.Format("Driver={0}; ", cntDriverSQLServer(1)), String.Empty).Replace("DataBase={1}; ", "{1}"), Server, DataBase, IntegratedSecurity, PersistSecurityInfo, ConnectTimeout)
                    Else
                        saida = String.Format(cntStringConexaoSQLServerOdbc_SegurancaPadrao.Replace(String.Format("Driver={0}; ", cntDriverSQLServer(1)), String.Empty).Replace("DataBase={1}; ", "{1}"), Server, DataBase, UserId, Password, IntegratedSecurity, _
                         PersistSecurityInfo, ConnectTimeout)
                    End If
                    saida = String.Format("{0}={1}; ", strDriverSQLServer(0), strDriverSQLServer(1)) & saida
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida)
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                    Exit Select
                Case TipoConexao.ConexaoSQLServerOleDb
                    If DataBase <> String.Empty Then
                        DataBase = String.Format("DataBase={0}; ", DataBase)
                    End If
                    If IntegratedSecurity Then
                        saida = String.Format(cntStringConexaoSQLServerOleDb_SegurancaConfianca.Replace(String.Format("Provider={0}; ", cntProviderSQLServer(1)), String.Empty).Replace("DataBase={1}; ", "{1}"), Server, DataBase, IntegratedSecurity, PersistSecurityInfo, ConnectTimeout)
                    Else
                        saida = String.Format(cntStringConexaoSQLServerOleDb_SegurancaPadrao.Replace(String.Format("Provider={0}; ", cntProviderSQLServer(1)), String.Empty).Replace("DataBase={1}; ", "{1}"), Server, DataBase, UserId, Password, IntegratedSecurity, _
                         PersistSecurityInfo, ConnectTimeout)
                    End If
                    saida = String.Format("{0}={1}; ", strProviderSQLServer(0), strProviderSQLServer(1)) & saida
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida)
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                    Exit Select
                Case TipoConexao.ConexaoSQLServerNativa
                    If DataBase <> String.Empty Then
                        DataBase = String.Format("DataBase={0}; ", DataBase)
                    End If
                    If IntegratedSecurity Then
                        saida = String.Format(cntStringConexaoSQLServerNativa_SegurancaConfianca.Replace("DataBase={1}; ", "{1}"), Server, DataBase, IntegratedSecurity, PersistSecurityInfo, ConnectTimeout)
                    Else
                        saida = String.Format(cntStringConexaoSQLServerNativa_SegurancaPadrao.Replace("DataBase={1}; ", "{1}"), Server, DataBase, UserId, Password, IntegratedSecurity, _
                         PersistSecurityInfo, ConnectTimeout)
                    End If
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida)
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                    Exit Select
                Case TipoConexao.Indisponivel
                    saida = TipoConexao.Indisponivel.ToString()
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel
                    Exit Select
            End Select
            prpConexao = mtdValidarConexaoSQLServer(saida)
            Return prpConexao.Trim()
        End Function
    End Class

    Partial Public Class clsBancoDados
        ' Variaveis do SQLServer
        Private objConexaoSQLServer As New System.Data.SqlClient.SqlConnection()
        Private objComandoSQLServer As New System.Data.SqlClient.SqlCommand()
        Private objAdaptadorDadosSQLServer As New System.Data.SqlClient.SqlDataAdapter()
        Private objLeitorDadosSQLServer As System.Data.SqlClient.SqlDataReader

        ' Propriedades do SQLServer

        Public Property prpConexaoSQLServer() As System.Data.SqlClient.SqlConnection
            Get
                Return objConexaoSQLServer
            End Get
            Set(ByVal value As System.Data.SqlClient.SqlConnection)
                objConexaoSQLServer = value
            End Set
        End Property

        Public Property prpComandoSQLServer() As System.Data.SqlClient.SqlCommand
            Get
                Return objComandoSQLServer
            End Get
            Set(ByVal value As System.Data.SqlClient.SqlCommand)
                objComandoSQLServer = value
            End Set
        End Property

        Public Property prpAdaptadorDadosSQLServer() As System.Data.SqlClient.SqlDataAdapter
            Get
                Return objAdaptadorDadosSQLServer
            End Get
            Set(ByVal value As System.Data.SqlClient.SqlDataAdapter)
                objAdaptadorDadosSQLServer = value
            End Set
        End Property

        Public Property prpLeitorDadosSQLServer() As System.Data.SqlClient.SqlDataReader
            Get
                Return objLeitorDadosSQLServer
            End Get
            Set(ByVal value As System.Data.SqlClient.SqlDataReader)
                objLeitorDadosSQLServer = value
            End Set
        End Property

        Public Sub mtdExecutarParametroComandoSQLServer(ByVal NomeParametro As String, ByVal Valor As Object)
            Dim objParametroSQLServer As New System.Data.SqlClient.SqlParameter(NomeParametro, Valor)
            prpComandoSQLServer.Parameters.Add(objParametroSQLServer)
        End Sub

        Public Sub mtdExecutarParametroComandoSQLServer(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.SqlDbType, ByVal Valor As Object)
            Dim objParametroSQLServer As New System.Data.SqlClient.SqlParameter(NomeParametro, TipoSqlDb)
            objParametroSQLServer.Value = Valor
            prpComandoSQLServer.Parameters.Add(objParametroSQLServer)
        End Sub

        Public Sub mtdExecutarParametroComandoSQLServer(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.SqlDbType, ByVal Valor As Object, ByVal Tamanho As Integer)
            Dim objParametroSQLServer As New System.Data.SqlClient.SqlParameter(NomeParametro, TipoSqlDb, Tamanho)
            objParametroSQLServer.Value = Valor
            prpComandoSQLServer.Parameters.Add(objParametroSQLServer)
        End Sub

        Public Sub mtdExecutarParametroComandoSQLServer(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.SqlDbType, ByVal Valor As Object, ByVal Tamanho As Integer, ByVal ColunaOrigem As String)
            Dim objParametroSQLServer As New System.Data.SqlClient.SqlParameter(NomeParametro, TipoSqlDb, Tamanho, ColunaOrigem)
            objParametroSQLServer.Value = Valor
            prpComandoSQLServer.Parameters.Add(objParametroSQLServer)
        End Sub

        Public Sub mtdExecutarParametroComandoSQLServer(ByVal OrigemVersao As System.Data.DataRowVersion, ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.SqlDbType, ByVal DirecaoParametro As System.Data.ParameterDirection, ByVal OrigemColuna As String, ByVal Valor As Object, _
         ByVal Tamanho As Integer)
            Dim objParametroSQLServer As New System.Data.SqlClient.SqlParameter(NomeParametro, TipoSqlDb, Tamanho, OrigemColuna)
            objParametroSQLServer.SourceVersion = OrigemVersao
            objParametroSQLServer.Direction = DirecaoParametro
            objParametroSQLServer.Value = Valor
            prpComandoSQLServer.Parameters.Add(objParametroSQLServer)
        End Sub
    End Class

    Partial Public Class clsImplementacaoBancoDados
        ' SQLServer

        Public Enum OpcaoAlterarBancoDadosSQLServer
            AUTHORIZATION_ON
            MODIFY_FILE_LOGICAL
            MODIFY_FILE_PHYSICAL
            MODIFY_NAME
        End Enum

        Public Function mtdAlterarBancoDadosSQLServer(ByVal OpcaoAlterarBancoDadosSQLServer As OpcaoAlterarBancoDadosSQLServer, ByVal NovoAtributo As String) As Boolean
            Return mtdAlterarBancoDadosSQLServer(prpDataBaseSQLServer, OpcaoAlterarBancoDadosSQLServer, NovoAtributo)
        End Function

        Public Function mtdAlterarBancoDadosSQLServer(ByVal OpcaoAlterarBancoDadosSQLServer As OpcaoAlterarBancoDadosSQLServer, ByVal AntigoAtributo As String, ByVal NovoAtributo As String) As Boolean
            Return mtdAlterarBancoDadosSQLServer(prpDataBaseSQLServer, OpcaoAlterarBancoDadosSQLServer, AntigoAtributo, NovoAtributo)
        End Function

        Public Function mtdAlterarBancoDadosSQLServer(ByVal OpcaoAlterarBancoDadosSQLServer As OpcaoAlterarBancoDadosSQLServer, ByVal EnderecoBancoDados As String, ByVal AntigoAtributo As String, ByVal NovoAtributo As String) As Boolean
            Return mtdAlterarBancoDadosSQLServer(prpDataBaseSQLServer, OpcaoAlterarBancoDadosSQLServer, EnderecoBancoDados, AntigoAtributo, NovoAtributo)
        End Function

        Public Function mtdAlterarBancoDadosSQLServer(ByVal BancoDados As String, ByVal OpcaoAlterarBancoDadosSQLServer As OpcaoAlterarBancoDadosSQLServer, ByVal NovoAtributo As String) As Boolean
            Dim saida As Boolean = True

            prpDataBaseSQLServer = BancoDados
            mtdDefinirStringConexaoSQLServer()
            If mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, False), prpTipoSistemaGerenciadorBancoDadosRelacional) Then
                mtdFecharConexao()
            End If
            If OpcaoAlterarBancoDadosSQLServer = OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_LOGICAL OrElse OpcaoAlterarBancoDadosSQLServer = OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_PHYSICAL OrElse OpcaoAlterarBancoDadosSQLServer = OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME Then
                prpDataBaseSQLServer = NovoAtributo
                mtdDefinirStringConexaoSQLServer()
                If mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, False), prpTipoSistemaGerenciadorBancoDadosRelacional) Then
                    mtdFecharConexao()
                End If
            End If
            saida = saida And mtdAbrirConexao()
            'mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET OFFLINE", Nome));
            Select Case OpcaoAlterarBancoDadosSQLServer
                Case OpcaoAlterarBancoDadosSQLServer.AUTHORIZATION_ON
                    saida = saida And mtdExecutarComando(String.Format("ALTER {1} DATABASE::{0} TO {2}", BancoDados, OpcaoAlterarBancoDadosSQLServer.ToString().Replace("_"c, " "c), NovoAtributo))
                    Exit Select
                Case OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME
                    saida = saida And mtdExecutarComando(String.Format("ALTER DATABASE {0} {1} = {2}", BancoDados, OpcaoAlterarBancoDadosSQLServer.ToString().Replace("_"c, " "c), NovoAtributo))
                    Exit Select
            End Select
            'mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET ONLINE", Nome));
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAlterarBancoDadosSQLServer(ByVal BancoDados As String, ByVal OpcaoAlterarBancoDadosSQLServer As OpcaoAlterarBancoDadosSQLServer, ByVal AntigoAtributo As String, ByVal NovoAtributo As String) As Boolean
            Dim saida As Boolean = True

            prpDataBaseSQLServer = BancoDados
            mtdDefinirStringConexaoSQLServer()
            If mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, False), prpTipoSistemaGerenciadorBancoDadosRelacional) Then
                mtdFecharConexao()
            End If
            If OpcaoAlterarBancoDadosSQLServer = OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_LOGICAL OrElse OpcaoAlterarBancoDadosSQLServer = OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_PHYSICAL OrElse OpcaoAlterarBancoDadosSQLServer = OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME Then
                prpDataBaseSQLServer = NovoAtributo
                mtdDefinirStringConexaoSQLServer()
                If mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, False), prpTipoSistemaGerenciadorBancoDadosRelacional) Then
                    mtdFecharConexao()
                End If
            End If
            saida = saida And mtdAbrirConexao()
            'mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET OFFLINE", Nome));
            Select Case OpcaoAlterarBancoDadosSQLServer
                Case OpcaoAlterarBancoDadosSQLServer.AUTHORIZATION_ON
                    saida = saida And mtdAlterarBancoDadosSQLServer(BancoDados, OpcaoAlterarBancoDadosSQLServer, NovoAtributo)
                    Exit Select
                Case OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME
                    saida = saida And mtdAlterarBancoDadosSQLServer(BancoDados, OpcaoAlterarBancoDadosSQLServer, NovoAtributo)
                    Exit Select
                Case OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_LOGICAL
                    saida = saida And mtdExecutarComando(String.Format("ALTER DATABASE {0} {1} (NAME = {2}, NEWNAME = {3})", BancoDados, OpcaoAlterarBancoDadosSQLServer.ToString().Replace("_LOGICAL", String.Empty).Replace("_"c, " "c), AntigoAtributo, NovoAtributo))
                    saida = saida And mtdExecutarComando(String.Format("ALTER DATABASE {0} {1} (NAME = {2}_log, NEWNAME = {3}_log)", BancoDados, OpcaoAlterarBancoDadosSQLServer.ToString().Replace("_LOGICAL", String.Empty).Replace("_"c, " "c), AntigoAtributo, NovoAtributo))
                    Exit Select
            End Select
            'mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET ONLINE", Nome));
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAlterarBancoDadosSQLServer(ByVal BancoDados As String, ByVal OpcaoAlterarBancoDadosSQLServer As OpcaoAlterarBancoDadosSQLServer, ByVal EnderecoBancoDados As String, ByVal AntigoAtributo As String, ByVal NovoAtributo As String) As Boolean
            Dim saida As Boolean = True

            Dim ex As New Exception()
            Dim intContador As Integer = 0
            Dim intNumeroTentativa As Integer = 10
            prpDataBaseSQLServer = BancoDados
            mtdDefinirStringConexaoSQLServer()
            If mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, False), prpTipoSistemaGerenciadorBancoDadosRelacional) Then
                mtdFecharConexao()
            End If
            If OpcaoAlterarBancoDadosSQLServer = OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_LOGICAL OrElse OpcaoAlterarBancoDadosSQLServer = OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_PHYSICAL OrElse OpcaoAlterarBancoDadosSQLServer = OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME Then
                prpDataBaseSQLServer = NovoAtributo
                mtdDefinirStringConexaoSQLServer()
                If mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, False), prpTipoSistemaGerenciadorBancoDadosRelacional) Then
                    mtdFecharConexao()
                End If
            End If
            saida = saida And mtdAbrirConexao()
            'mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET OFFLINE", Nome));
            Select Case OpcaoAlterarBancoDadosSQLServer
                Case OpcaoAlterarBancoDadosSQLServer.AUTHORIZATION_ON
                    saida = saida And mtdAlterarBancoDadosSQLServer(BancoDados, OpcaoAlterarBancoDadosSQLServer, NovoAtributo)
                    Exit Select
                Case OpcaoAlterarBancoDadosSQLServer.MODIFY_NAME
                    saida = saida And mtdAlterarBancoDadosSQLServer(BancoDados, OpcaoAlterarBancoDadosSQLServer, NovoAtributo)
                    Exit Select
                Case OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_LOGICAL
                    saida = saida And mtdAlterarBancoDadosSQLServer(BancoDados, OpcaoAlterarBancoDadosSQLServer, AntigoAtributo, NovoAtributo)
                    Exit Select
                Case OpcaoAlterarBancoDadosSQLServer.MODIFY_FILE_PHYSICAL
                    saida = saida And mtdExecutarComando(String.Format("ALTER DATABASE {0} {1} (NAME = {2}, FILENAME = '{3}.mdf')", BancoDados, OpcaoAlterarBancoDadosSQLServer.ToString().Replace("_PHYSICAL", String.Empty).Replace("_"c, " "c), AntigoAtributo, EnderecoBancoDados & NovoAtributo))
                    saida = saida And mtdExecutarComando(String.Format("ALTER DATABASE {0} {1} (NAME = {2}_log, FILENAME = '{3}_log.ldf')", BancoDados, OpcaoAlterarBancoDadosSQLServer.ToString().Replace("_PHYSICAL", String.Empty).Replace("_"c, " "c), AntigoAtributo, EnderecoBancoDados & NovoAtributo))
                    While ex.Message = "The process cannot access the file because it is being used by another process" AndAlso intContador <= intNumeroTentativa
                        System.IO.File.Move(EnderecoBancoDados & AntigoAtributo & ".mdf", EnderecoBancoDados & NovoAtributo & ".mdf")
                        System.IO.File.Move(EnderecoBancoDados & AntigoAtributo & "_log.ldf", EnderecoBancoDados & NovoAtributo & "_log.ldf")
                        intContador += 1
                        saida = saida And True
                    End While
                    If intContador = intNumeroTentativa Then
                        saida = False
                    End If
                    Exit Select
            End Select
            'mtdExecutarComando(string.Format(@"ALTER DATABASE {0} SET ONLINE", Nome));
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdCriarBancoDadosSQLServer() As Boolean
            Return mtdCriarBancoDadosSQLServer(prpDataBaseSQLServer)
        End Function

        Public Function mtdCriarBancoDadosSQLServer(ByVal Endereco As String, ByVal TamanhoArquivo As String, ByVal TamanhoMaximoArquivo As String, ByVal TamanhoExpansivelArquivo As String, ByVal TamanhoLog As String, ByVal TamanhoMaximoLog As String, _
         ByVal TamanhoExpansivelLog As String) As Boolean
            Return mtdCriarBancoDadosSQLServer(prpDataBaseSQLServer, Endereco, TamanhoArquivo, TamanhoMaximoArquivo, TamanhoExpansivelArquivo, TamanhoLog, _
             TamanhoMaximoLog, TamanhoExpansivelLog)
        End Function

        Public Function mtdCriarBancoDadosSQLServer(ByVal BancoDados As String) As Boolean
            Dim saida As Boolean = True

            prpDataBaseSQLServer = BancoDados
            mtdDefinirStringConexaoSQLServer()
            mtdFecharConexao()
            saida = saida And mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, False), prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("CREATE DATABASE {0};", BancoDados))
            mtdDefinirStringConexaoSQLServer(prpConexao, True)
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdCriarBancoDadosSQLServer(ByVal BancoDados As String, ByVal Endereco As String, ByVal TamanhoArquivo As String, ByVal TamanhoMaximoArquivo As String, ByVal TamanhoExpansivelArquivo As String, ByVal TamanhoLog As String, _
         ByVal TamanhoMaximoLog As String, ByVal TamanhoExpansivelLog As String) As Boolean
            Dim saida As Boolean = True

            prpDataBaseSQLServer = BancoDados
            mtdDefinirStringConexaoSQLServer()
            mtdFecharConexao()
            saida = saida And mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, False), prpTipoSistemaGerenciadorBancoDadosRelacional)
            ' objBancoDados.prpComando = @"CREATE DATABASE dbTeste ON PRIMARY (NAME=Teste, FILENAME = 'C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\Data\dbTeste.mdf', SIZE=4, MAXSIZE=10, FILEGROWTH=10%) LOG ON (NAME=Teste_log, FILENAME='C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\Data\dbTeste_log.ldf', SIZE=3, MAXSIZE=20,FILEGROWTH=1);";
            saida = saida And mtdExecutarComando(String.Format("CREATE DATABASE {0} ON (NAME = {0}, FILENAME = '{1}{0}.mdf', SIZE = {2}, MAXSIZE = {3}, FILEGROWTH = {4}) LOG ON (NAME={0}_log, FILENAME='{1}{0}.ldf', SIZE={5}, MAXSIZE={6}, FILEGROWTH={7});", BancoDados, Endereco, TamanhoArquivo, TamanhoMaximoArquivo, TamanhoExpansivelArquivo, _
             TamanhoLog, TamanhoMaximoLog, TamanhoExpansivelLog))
            mtdDefinirStringConexaoSQLServer(prpConexao, True)
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdDeletarBancoDadosSQLServer() As Boolean
            Return mtdDeletarBancoDadosSQLServer(prpDataBaseSQLServer)
        End Function

        Public Function mtdDeletarBancoDadosSQLServer(ByVal BancoDados As String) As Boolean
            Dim saida As Boolean = True

            prpDataBaseSQLServer = BancoDados
            mtdDefinirStringConexaoSQLServer()
            If mtdAbrirConexao(mtdDefinirStringConexaoSQLServer(prpConexao, False), prpTipoSistemaGerenciadorBancoDadosRelacional) Then
                mtdFecharConexao()
            End If
            saida = saida And mtdAbrirConexao()
            saida = saida And mtdExecutarComando(String.Format("DROP DATABASE {0};", BancoDados))
            mtdFecharConexao()

            Return saida
        End Function
    End Class
End Namespace