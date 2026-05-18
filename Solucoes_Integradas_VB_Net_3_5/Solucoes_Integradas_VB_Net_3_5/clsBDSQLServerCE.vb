Imports System.Collections.Generic
Imports System.Text

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class clsConexaoBancoDados

        ' Constantes de instancia do SQLServerCE

        Public Const cntStringConexaoSQLServerCEOleDb As String = "Provider={0}; Data Source={1}; SSCE:Database Password={2}; SSCE:Temp File Directory={3}; SSCE:Temp File Max Size={4}; SSCE:Encrypt Database={5}; SSCE:Max Buffer Size={6}; SSCE:Max Database Size={7};"
        Public Const cntStringConexaoSQLServerCENativa As String = "Data Source={0}; Password={1}; File Mode={2}; Temp File Max Size={3}; Encrypt Database={4}; Max Buffer Size={5}; Max Database Size={6}; Persist Security Info={7};"

        Public Const cntExemploStringConexaoSQLServerCEOleDb As String = "Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5; Data Source=myPath\myData.sdf; SSCE:Database Password=myPassword; SSCE:Temp File Directory=\myTempDir\; SSCE:Temp File Max Size=256; SSCE:Encrypt Database=True; SSCE:Max Buffer Size=1024; SSCE:Max Database Size=256;"
        Public Const cntExemploStringConexaoSQLServerCENativa As String = "Data Source=MyData.sdf; Password=myPassword; File Mode=shared read; Temp File Max Size=256; Encrypt Database=True; Max Buffer Size=1024; Max Database Size=256; Persist Security Info=False;"

        ' Variaveis somente leitura de instancia do SQLServerCE

        Private ReadOnly cntProviderSQLServerCE As String() = {"Provider", "SQLServerCEProv"}
        Private ReadOnly cntDataSourceSQLServerCE As String() = {"Data Source", String.Empty}
        Private ReadOnly cntPasswordSQLServerCE As String() = {"Password", String.Empty}
        Private ReadOnly cntFileModeSQLServerCE As String() = {"File Mode", String.Empty}
        Private ReadOnly cntTempFileMaxSizeSQLServerCE As String() = {"Temp File Max Size", "256"}
        Private ReadOnly cntEncryptDatabaseSQLServerCE As String() = {"Encrypt Database", "True"}
        Private ReadOnly cntMaxBufferSizeSQLServerCE As String() = {"Max Buffer Size", "1024"}
        Private ReadOnly cntMaxDatabaseSizeSQLServerCE As String() = {"Max Database Size", "256"}
        Private ReadOnly cntPersistSecurityInfoSQLServerCE As String() = {"Persist Security Inf", "False"}

        ' Variaveis de instancia do SQLServerCE

        Private strProviderSQLServerCE As String()
        Private strDataSourceSQLServerCE As String()
        Private strPasswordSQLServerCE As String()
        Private strFileModeSQLServerCE As String()
        Private strTempFileMaxSizeSQLServerCE As String()
        Private strEncryptDatabaseSQLServerCE As String()
        Private strMaxBufferSizeSQLServerCE As String()
        Private strMaxDatabaseSizeSQLServerCE As String()
        Private strPersistSecurityInfoSQLServerCE As String()

        Private vetProviderSQLServerCE As String() = {"Provider"}
        Private vetDataSourceSQLServerCE As String() = {"DataSource", "Data Source"}
        Private vetPasswordSQLServerCE As String() = {"Password", "SSCE:DatabasePassword", "SSCE:Database Password"}
        Private vetFileModeSQLServerCE As String() = {"FileMode", "File Mode"}
        Private vetTempFileMaxSizeSQLServerCE As String() = {"TempFileMaxSize", "Temp File Max Size", "SSCE:TempFileMaxSize", "SSCE:Temp File Max Size"}
        Private vetEncryptDatabaseSQLServerCE As String() = {"EncryptDatabase", "Encrypt Database", "SSCE:EncryptDatabase", "SSCE:Encrypt Database"}
        Private vetMaxBufferSizeSQLServerCE As String() = {"MaxBufferSize", "Max Buffer Size", "SSCE:MaxBufferSize", "SSCE:Max Buffer Size"}
        Private vetMaxDatabaseSizeSQLServerCE As String() = {"MaxDatabaseSize", "Max Database Size", "SSCE:MaxDatabaseSize", "SSCE:Max Database Size"}
        Private vetPersistSecurityInfoSQLServerCE As String() = {"PersistSecurityInf", "Persist Security Inf"}

        ' Variaveis que determinam se a conexao incorporara o banco de dados. Isso facilita na criacao, alteracao ou delecao do banco de dados.

        ' Propriedades de instancia do SQLServerCE

        Private blnPermitirBancoDadosSQLServerCE As Boolean = True

        Public Property prpPermitirBancoDadosSQLServerCE() As Boolean
            Get
                Return blnPermitirBancoDadosSQLServerCE
            End Get
            Set(ByVal value As Boolean)
                blnPermitirBancoDadosSQLServerCE = value
            End Set
        End Property

        ' Propriedades de instancia do SQLServerCE

        Public Property prpProviderSQLServerCE() As String
            Get
                If strProviderSQLServerCE Is Nothing Then
                    strProviderSQLServerCE = New String(1) {cntProviderSQLServerCE(0), cntProviderSQLServerCE(1)}
                End If
                Return strProviderSQLServerCE(1)
            End Get
            Set(ByVal value As String)
                If strProviderSQLServerCE Is Nothing Then
                    strProviderSQLServerCE = New String(1) {cntProviderSQLServerCE(0), cntProviderSQLServerCE(1)}
                End If
                strProviderSQLServerCE(1) = value
                mtdReDefinirConexaoString(strProviderSQLServerCE)
            End Set
        End Property

        Public Property prpDataSourceSQLServerCE() As String
            Get
                If strDataSourceSQLServerCE Is Nothing Then
                    strDataSourceSQLServerCE = New String(1) {cntDataSourceSQLServerCE(0), cntDataSourceSQLServerCE(1)}
                End If
                Return strDataSourceSQLServerCE(1)
            End Get
            Set(ByVal value As String)
                If strDataSourceSQLServerCE Is Nothing Then
                    strDataSourceSQLServerCE = New String(1) {cntDataSourceSQLServerCE(0), cntDataSourceSQLServerCE(1)}
                End If
                strDataSourceSQLServerCE(1) = value
                mtdReDefinirConexaoString(strDataSourceSQLServerCE)
            End Set
        End Property

        Public Property prpPasswordSQLServerCE() As String
            Get
                If strPasswordSQLServerCE Is Nothing Then
                    strPasswordSQLServerCE = New String(1) {cntPasswordSQLServerCE(0), cntPasswordSQLServerCE(1)}
                End If
                Return strPasswordSQLServerCE(1)
            End Get
            Set(ByVal value As String)
                If strPasswordSQLServerCE Is Nothing Then
                    strPasswordSQLServerCE = New String(1) {cntPasswordSQLServerCE(0), cntPasswordSQLServerCE(1)}
                End If
                strPasswordSQLServerCE(1) = value
                mtdReDefinirConexaoString(strPasswordSQLServerCE)
            End Set
        End Property

        Public Property prpFileModeSQLServerCE() As String
            Get
                If strFileModeSQLServerCE Is Nothing Then
                    strFileModeSQLServerCE = New String(1) {cntFileModeSQLServerCE(0), cntFileModeSQLServerCE(1)}
                End If
                Return strFileModeSQLServerCE(1)
            End Get
            Set(ByVal value As String)
                If strFileModeSQLServerCE Is Nothing Then
                    strFileModeSQLServerCE = New String(1) {cntFileModeSQLServerCE(0), cntFileModeSQLServerCE(1)}
                End If
                strFileModeSQLServerCE(1) = value
                mtdReDefinirConexaoString(strFileModeSQLServerCE)
            End Set
        End Property

        Public Property prpTempFileMaxSizeSQLServerCE() As String
            Get
                If strTempFileMaxSizeSQLServerCE Is Nothing Then
                    strTempFileMaxSizeSQLServerCE = New String(1) {cntTempFileMaxSizeSQLServerCE(0), cntTempFileMaxSizeSQLServerCE(1)}
                End If
                Return strTempFileMaxSizeSQLServerCE(1)
            End Get
            Set(ByVal value As String)
                If strTempFileMaxSizeSQLServerCE Is Nothing Then
                    strTempFileMaxSizeSQLServerCE = New String(1) {cntTempFileMaxSizeSQLServerCE(0), cntTempFileMaxSizeSQLServerCE(1)}
                End If
                strTempFileMaxSizeSQLServerCE(1) = value
                mtdReDefinirConexaoString(strTempFileMaxSizeSQLServerCE)
            End Set
        End Property

        Public Property prpEncryptDatabaseSQLServerCE() As String
            Get
                If strEncryptDatabaseSQLServerCE Is Nothing Then
                    strEncryptDatabaseSQLServerCE = New String(1) {cntEncryptDatabaseSQLServerCE(0), cntEncryptDatabaseSQLServerCE(1)}
                End If
                Return strEncryptDatabaseSQLServerCE(1)
            End Get
            Set(ByVal value As String)
                If strEncryptDatabaseSQLServerCE Is Nothing Then
                    strEncryptDatabaseSQLServerCE = New String(1) {cntEncryptDatabaseSQLServerCE(0), cntEncryptDatabaseSQLServerCE(1)}
                End If
                strEncryptDatabaseSQLServerCE(1) = value
                mtdReDefinirConexaoString(strEncryptDatabaseSQLServerCE)
            End Set
        End Property

        Public Property prpMaxBufferSizeSQLServerCE() As String
            Get
                If strMaxBufferSizeSQLServerCE Is Nothing Then
                    strMaxBufferSizeSQLServerCE = New String(1) {cntMaxBufferSizeSQLServerCE(0), cntMaxBufferSizeSQLServerCE(1)}
                End If
                Return strMaxBufferSizeSQLServerCE(1)
            End Get
            Set(ByVal value As String)
                If strMaxBufferSizeSQLServerCE Is Nothing Then
                    strMaxBufferSizeSQLServerCE = New String(1) {cntMaxBufferSizeSQLServerCE(0), cntMaxBufferSizeSQLServerCE(1)}
                End If
                strMaxBufferSizeSQLServerCE(1) = value
                mtdReDefinirConexaoString(strMaxDatabaseSizeSQLServerCE)
            End Set
        End Property

        Public Property prpMaxDatabaseSizeSQLServerCE() As String
            Get
                If strMaxDatabaseSizeSQLServerCE Is Nothing Then
                    strMaxDatabaseSizeSQLServerCE = New String(1) {cntMaxDatabaseSizeSQLServerCE(0), cntMaxDatabaseSizeSQLServerCE(1)}
                End If
                Return strMaxDatabaseSizeSQLServerCE(1)
            End Get
            Set(ByVal value As String)
                If strMaxDatabaseSizeSQLServerCE Is Nothing Then
                    strMaxDatabaseSizeSQLServerCE = New String(1) {cntMaxDatabaseSizeSQLServerCE(0), cntMaxDatabaseSizeSQLServerCE(1)}
                End If
                strMaxDatabaseSizeSQLServerCE(1) = value
                mtdReDefinirConexaoString(strMaxDatabaseSizeSQLServerCE)
            End Set
        End Property

        Public Property prpPersistSecurityInfoSQLServerCE() As String
            Get
                If strPersistSecurityInfoSQLServerCE Is Nothing Then
                    strPersistSecurityInfoSQLServerCE = New String(1) {cntPersistSecurityInfoSQLServerCE(0), cntPersistSecurityInfoSQLServerCE(1)}
                End If
                Return strPersistSecurityInfoSQLServerCE(1)
            End Get
            Set(ByVal value As String)
                If strPersistSecurityInfoSQLServerCE Is Nothing Then
                    strPersistSecurityInfoSQLServerCE = New String(1) {cntPersistSecurityInfoSQLServerCE(0), cntPersistSecurityInfoSQLServerCE(1)}
                End If
                strPersistSecurityInfoSQLServerCE(1) = value
                mtdReDefinirConexaoString(strPersistSecurityInfoSQLServerCE)
            End Set
        End Property

        ' Metodos de instancia do SQLServerCE

        Public Function mtdValidarConexaoProvedorSQLServerCE(ByVal Conexao As String) As String()
            strProviderSQLServerCE = mtdValidarConexao(Conexao, vetProviderSQLServerCE)
            Return strProviderSQLServerCE
        End Function

        Public Function mtdValidarConexaoOrigemDadosSQLServerCE(ByVal Conexao As String) As String()
            strDataSourceSQLServerCE = mtdValidarConexao(Conexao, vetDataSourceSQLServerCE)
            Return strDataSourceSQLServerCE
        End Function
        Public Function mtdValidarConexaoSenhaSQLServerCE(ByVal Conexao As String) As String()
            strPasswordSQLServerCE = mtdValidarConexao(Conexao, vetPasswordSQLServerCE)
            Return strPasswordSQLServerCE
        End Function
        Public Function mtdValidarConexaoFileModeSQLServerCE(ByVal Conexao As String) As String()
            strFileModeSQLServerCE = mtdValidarConexao(Conexao, vetFileModeSQLServerCE)
            Return strFileModeSQLServerCE
        End Function
        Public Function mtdValidarConexaoTempFileMaxSizeSQLServerCE(ByVal Conexao As String) As String()
            strTempFileMaxSizeSQLServerCE = mtdValidarConexao(Conexao, vetTempFileMaxSizeSQLServerCE)
            Return strTempFileMaxSizeSQLServerCE
        End Function
        Public Function mtdValidarConexaoEncryptDatabaseSQLServerCE(ByVal Conexao As String) As String()
            strEncryptDatabaseSQLServerCE = mtdValidarConexao(Conexao, vetEncryptDatabaseSQLServerCE)
            Return strEncryptDatabaseSQLServerCE
        End Function
        Public Function mtdValidarConexaoMaxBufferSizeSQLServerCE(ByVal Conexao As String) As String()
            strMaxBufferSizeSQLServerCE = mtdValidarConexao(Conexao, vetMaxBufferSizeSQLServerCE)
            Return strMaxBufferSizeSQLServerCE
        End Function
        Public Function mtdValidarConexaoMaxDatabaseSizeSQLServerCE(ByVal Conexao As String) As String()
            strMaxDatabaseSizeSQLServerCE = mtdValidarConexao(Conexao, vetMaxDatabaseSizeSQLServerCE)
            Return strMaxDatabaseSizeSQLServerCE
        End Function
        Public Function mtdValidarConexaoPersistSecurityInfoSQLServerCE(ByVal Conexao As String) As String()
            strPersistSecurityInfoSQLServerCE = mtdValidarConexao(Conexao, vetPersistSecurityInfoSQLServerCE)
            Return strPersistSecurityInfoSQLServerCE
        End Function

        Public Function mtdValidarConexaoSQLServerCE(ByVal Conexao As String) As String
            Dim saida As String = String.Empty

            prpTipoConexao = TipoConexao.Indisponivel
            'if (strProviderSQLServerCE == null || strProviderSQLServerCE[1] == cntProviderSQLServerCE[1])
            '{
            mtdValidarConexaoProvedorSQLServerCE(Conexao)
            '}
            If strProviderSQLServerCE IsNot Nothing Then
                prpTipoConexao = TipoConexao.ConexaoSQLServerCEOleDb
            End If
            'if (strDataSourceSQLServerCE == null || strDataSourceSQLServerCE[1] == cntDataSourceSQLServerCE[1])
            '{
            mtdValidarConexaoOrigemDadosSQLServerCE(Conexao)
            '}
            If strProviderSQLServerCE Is Nothing AndAlso strDataSourceSQLServerCE IsNot Nothing Then
                prpTipoConexao = TipoConexao.ConexaoSQLServerCENativa
            End If
            'if (strPasswordSQLServerCE == null || strPasswordSQLServerCE[1] == cntPasswordSQLServerCE[1])
            '{
            mtdValidarConexaoSenhaSQLServerCE(Conexao)
            '}
            'if (strFileModeSQLServerCE == null || strFileModeSQLServerCE[1] == cntFileModeSQLServerCE[1])
            '{
            mtdValidarConexaoFileModeSQLServerCE(Conexao)
            '}
            'if (strTempFileMaxSizeSQLServerCE == null || strTempFileMaxSizeSQLServerCE[1] == cntTempFileMaxSizeSQLServerCE[1])
            '{
            mtdValidarConexaoTempFileMaxSizeSQLServerCE(Conexao)
            '}
            'if (strEncryptDatabaseSQLServerCE == null || strEncryptDatabaseSQLServerCE[1] == cntEncryptDatabaseSQLServerCE[1])
            '{
            mtdValidarConexaoEncryptDatabaseSQLServerCE(Conexao)
            '}
            'if (strMaxBufferSizeSQLServerCE == null || strMaxBufferSizeSQLServerCE[1] == cntMaxBufferSizeSQLServerCE[1])
            '{
            mtdValidarConexaoMaxBufferSizeSQLServerCE(Conexao)
            '}
            'if (strMaxDatabaseSizeSQLServerCE == null || strMaxDatabaseSizeSQLServerCE[1] == cntMaxDatabaseSizeSQLServerCE[1])
            '{
            mtdValidarConexaoMaxDatabaseSizeSQLServerCE(Conexao)
            '}
            'if (strPersistSecurityInfoSQLServerCE == null || strPersistSecurityInfoSQLServerCE[1] == cntPersistSecurityInfoSQLServerCE[1])
            '{
            mtdValidarConexaoPersistSecurityInfoSQLServerCE(Conexao)
            '}

            If strProviderSQLServerCE IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strProviderSQLServerCE(0), strProviderSQLServerCE(1))
            End If
            If strDataSourceSQLServerCE IsNot Nothing AndAlso blnPermitirBancoDadosSQLServerCE Then
                saida += String.Format("{0}={1}; ", strDataSourceSQLServerCE(0), strDataSourceSQLServerCE(1))
            End If
            If strPasswordSQLServerCE IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strPasswordSQLServerCE(0), strPasswordSQLServerCE(1))
            End If
            If strFileModeSQLServerCE IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strFileModeSQLServerCE(0), strFileModeSQLServerCE(1))
            End If
            If strTempFileMaxSizeSQLServerCE IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strTempFileMaxSizeSQLServerCE(0), strTempFileMaxSizeSQLServerCE(1))
            End If
            If strEncryptDatabaseSQLServerCE IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strEncryptDatabaseSQLServerCE(0), strEncryptDatabaseSQLServerCE(1))
            End If
            If strMaxBufferSizeSQLServerCE IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strMaxBufferSizeSQLServerCE(0), strMaxBufferSizeSQLServerCE(1))
            End If
            If strMaxDatabaseSizeSQLServerCE IsNot Nothing Then
                saida += String.Format("{0}={1};", strMaxDatabaseSizeSQLServerCE(0), strMaxDatabaseSizeSQLServerCE(1))
            End If
            If strPersistSecurityInfoSQLServerCE IsNot Nothing Then
                saida += String.Format("{0}={1};", strPersistSecurityInfoSQLServerCE(0), strPersistSecurityInfoSQLServerCE(1))
            End If
            Return saida
        End Function

        Public Function mtdDefinirStringConexaoSQLServerCE() As String
            Return mtdDefinirStringConexaoSQLServerCE(prpConexao, True)
        End Function

        Public Function mtdDefinirStringConexaoSQLServerCE(ByVal PermitirBancoDados As Boolean) As String
            Return mtdDefinirStringConexaoSQLServerCE(prpConexao, PermitirBancoDados)
        End Function

        Public Function mtdDefinirStringConexaoSQLServerCE(ByVal Conexao As String) As String
            Return mtdDefinirStringConexaoSQLServerCE(Conexao, True)
        End Function

        Public Function mtdDefinirStringConexaoSQLServerCE(ByVal Conexao As String, ByVal PermitirBancoDados As Boolean) As String
            blnPermitirBancoDadosSQLServerCE = PermitirBancoDados
            mtdValidarConexaoSQLServerCE(Conexao)
            Return mtdDefinirStringConexaoSQLServerCE(prpTipoConexao, prpDataSourceSQLServerCE, prpPasswordSQLServerCE, prpFileModeSQLServerCE, prpTempFileMaxSizeSQLServerCE, prpEncryptDatabaseSQLServerCE, _
             prpMaxBufferSizeSQLServerCE, prpMaxDatabaseSizeSQLServerCE, prpPersistSecurityInfoSQLServerCE)
        End Function

        Public Function mtdDefinirStringConexaoSQLServerCE(ByVal TipoConexao As TipoConexao, ByVal DataSource As String) As String
            Return mtdDefinirStringConexaoSQLServerCE(TipoConexao, DataSource, cntPasswordSQLServerCE(1), cntFileModeSQLServerCE(1), cntTempFileMaxSizeSQLServerCE(1), cntEncryptDatabaseSQLServerCE(1), _
             cntMaxBufferSizeSQLServerCE(1), cntMaxDatabaseSizeSQLServerCE(1), cntPersistSecurityInfoSQLServerCE(1))
        End Function

        Public Function mtdDefinirStringConexaoSQLServerCE(ByVal TipoConexao As TipoConexao, ByVal DataSource As String, ByVal Password As String) As String
            Return mtdDefinirStringConexaoSQLServerCE(TipoConexao, DataSource, Password, cntFileModeSQLServerCE(1), cntTempFileMaxSizeSQLServerCE(1), cntEncryptDatabaseSQLServerCE(1), _
             cntMaxBufferSizeSQLServerCE(1), cntMaxDatabaseSizeSQLServerCE(1), cntPersistSecurityInfoSQLServerCE(1))
        End Function

        Public Function mtdDefinirStringConexaoSQLServerCE(ByVal TipoConexao As TipoConexao, ByVal DataSource As String, ByVal Password As String, ByVal FileMode As String, ByVal TempFileMaxSize As String, ByVal EncryptDatabase As String, _
         ByVal MaxBufferSize As String, ByVal MaxDatabaseSize As String, ByVal PersistSecurityInfo As String) As String
            Return mtdDefinirStringConexaoSQLServerCE(TipoConexao, If(DataSource <> String.Empty, DataSource, cntDataSourceSQLServerCE(1)), If(Password <> String.Empty, Password, cntPasswordSQLServerCE(1)), If(FileMode <> String.Empty, FileMode, cntFileModeSQLServerCE(1)), System.Convert.ToInt32(If(TempFileMaxSize <> String.Empty, TempFileMaxSize, cntTempFileMaxSizeSQLServerCE(1))), System.Convert.ToBoolean(If(EncryptDatabase <> String.Empty, EncryptDatabase, cntEncryptDatabaseSQLServerCE(1))), _
             System.Convert.ToInt32(If(MaxBufferSize <> String.Empty, MaxBufferSize, cntMaxBufferSizeSQLServerCE(1))), System.Convert.ToInt32(If(MaxDatabaseSize <> String.Empty, MaxDatabaseSize, cntMaxDatabaseSizeSQLServerCE(1))), System.Convert.ToBoolean(If(PersistSecurityInfo <> String.Empty, PersistSecurityInfo, cntPersistSecurityInfoSQLServerCE(1))))
        End Function

        Public Function mtdDefinirStringConexaoSQLServerCE(ByVal TipoConexao As TipoConexao, ByVal DataSource As String, ByVal Password As String, ByVal FileMode As String, ByVal TempFileMaxSize As Integer, ByVal EncryptDatabase As Boolean, _
         ByVal MaxBufferSize As Integer, ByVal MaxDatabaseSize As Integer, ByVal PersistSecurityInfo As Boolean) As String
            Dim saida As String = String.Empty
            Select Case TipoConexao
                Case TipoConexao.ConexaoSQLServerCEOleDb
                    If DataSource <> String.Empty Then
                        DataSource = String.Format("DataBase={0};", DataSource)
                    End If
                    saida = String.Format(cntStringConexaoSQLServerCEOleDb.Replace(String.Format("Provider={0}; ", cntProviderSQLServerCE(1)), String.Empty).Replace("Data Source={1}; ", "{1}"), Password, FileMode, TempFileMaxSize, EncryptDatabase, MaxBufferSize, _
                     MaxDatabaseSize, PersistSecurityInfo)
                    saida = String.Format("{0}={1}; ", strProviderSQLServerCE(0), strProviderSQLServerCE(1)) & saida
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida)
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                    Exit Select
                Case TipoConexao.ConexaoSQLServerCENativa
                    If DataSource <> String.Empty Then
                        DataSource = String.Format("DataBase={0}; ", DataSource)
                    End If
                    saida = String.Format(cntStringConexaoSQLServerCENativa.Replace("Database={2}; ", "{2}"), DataSource, Password, FileMode, TempFileMaxSize, EncryptDatabase, _
                     MaxBufferSize, MaxDatabaseSize, PersistSecurityInfo)
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida)
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                    Exit Select
                Case TipoConexao.Indisponivel
                    saida = TipoConexao.Indisponivel.ToString()
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel
                    Exit Select
            End Select
            prpConexao = mtdValidarConexaoSQLServerCE(saida)
            Return prpConexao.Trim()
        End Function

    End Class

    Partial Public Class clsBancoDados
        ' Variaveis do SQLServerCE
        Private objConexaoSQLServerCE As New System.Data.SqlServerCe.SqlCeConnection()
        Private objComandoSQLServerCE As New System.Data.SqlServerCe.SqlCeCommand()
        Private objAdaptadorDadosSQLServerCE As New System.Data.SqlServerCe.SqlCeDataAdapter()
        Private objLeitorDadosSQLServerCE As System.Data.SqlServerCe.SqlCeDataReader

        ' Propriedades do SQLServerCE

        Public Property prpConexaoSQLServerCE() As System.Data.SqlServerCe.SqlCeConnection
            Get
                Return objConexaoSQLServerCE
            End Get
            Set(ByVal value As System.Data.SqlServerCe.SqlCeConnection)
                objConexaoSQLServerCE = value
            End Set
        End Property

        Public Property prpComandoSQLServerCE() As System.Data.SqlServerCe.SqlCeCommand
            Get
                Return objComandoSQLServerCE
            End Get
            Set(ByVal value As System.Data.SqlServerCe.SqlCeCommand)
                objComandoSQLServerCE = value
            End Set
        End Property

        Public Property prpAdaptadorDadosSQLServerCE() As System.Data.SqlServerCe.SqlCeDataAdapter
            Get
                Return objAdaptadorDadosSQLServerCE
            End Get
            Set(ByVal value As System.Data.SqlServerCe.SqlCeDataAdapter)
                objAdaptadorDadosSQLServerCE = value
            End Set
        End Property

        Public Property prpLeitorDadosSQLServerCE() As System.Data.SqlServerCe.SqlCeDataReader
            Get
                Return objLeitorDadosSQLServerCE
            End Get
            Set(ByVal value As System.Data.SqlServerCe.SqlCeDataReader)
                objLeitorDadosSQLServerCE = value
            End Set
        End Property

        Public Sub mtdExecutarParametroComandoSQLServerCE(ByVal NomeParametro As String, ByVal Valor As Object)
            Dim objParametroSQLServerCE As New System.Data.SqlServerCe.SqlCeParameter(NomeParametro, Valor)
            prpComandoSQLServerCE.Parameters.Add(objParametroSQLServerCE)
        End Sub

        Public Sub mtdExecutarParametroComandoSQLServerCE(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.SqlDbType, ByVal Valor As Object)
            Dim objParametroSQLServerCE As New System.Data.SqlServerCe.SqlCeParameter(NomeParametro, Valor)
            objParametroSQLServerCE.SqlDbType = TipoSqlDb
            prpComandoSQLServerCE.Parameters.Add(objParametroSQLServerCE)
        End Sub

        Public Sub mtdExecutarParametroComandoSQLServerCE(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.SqlDbType, ByVal Valor As Object, ByVal Tamanho As Integer)
            Dim objParametroSQLServerCE As New System.Data.SqlServerCe.SqlCeParameter(NomeParametro, TipoSqlDb, Tamanho)
            objParametroSQLServerCE.Value = Valor
            prpComandoSQLServerCE.Parameters.Add(objParametroSQLServerCE)
        End Sub

        Public Sub mtdExecutarParametroComandoSQLServerCE(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.SqlDbType, ByVal Valor As Object, ByVal Tamanho As Integer, ByVal ColunaOrigem As String)
            Dim objParametroSQLServerCE As New System.Data.SqlServerCe.SqlCeParameter(NomeParametro, TipoSqlDb, Tamanho, ColunaOrigem)
            objParametroSQLServerCE.Value = Valor
            prpComandoSQLServerCE.Parameters.Add(objParametroSQLServerCE)
        End Sub

        Public Sub mtdExecutarParametroComandoSQLServerCE(ByVal OrigemVersao As System.Data.DataRowVersion, ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.SqlDbType, ByVal DirecaoParametro As System.Data.ParameterDirection, ByVal OrigemColuna As String, ByVal Valor As Object, _
         ByVal Tamanho As Integer)
            Dim objParametroSQLServerCE As New System.Data.SqlServerCe.SqlCeParameter(NomeParametro, TipoSqlDb, Tamanho, OrigemColuna)
            objParametroSQLServerCE.SourceVersion = OrigemVersao
            objParametroSQLServerCE.Direction = DirecaoParametro
            objParametroSQLServerCE.Value = Valor
            prpComandoSQLServerCE.Parameters.Add(objParametroSQLServerCE)
        End Sub
    End Class

    Partial Public Class clsImplementacaoBancoDados
        ' SQLServerCE

        Public Function mtdCompactarBancoDadosSQLServerCE() As Boolean
            Return mtdCompactarBancoDadosSQLServerCE(prpDataSourceSQLServerCE)
        End Function

        Public Function mtdCompactarBancoDadosSQLServerCE(ByVal BancoDados As String) As Boolean
            Dim saida As Boolean = True

            Try

                Dim ex As New System.Exception("Não há banco de dados (arquivo) a ser compactado.")
                Dim objSqlServerCeEngine As System.Data.SqlServerCe.SqlCeEngine = Nothing

                Dim vetBancoDados As String() = BancoDados.Split("."c)
                Dim NovoBancoDados As String = String.Format("{0}_compactado_reparado.{1}", vetBancoDados(0), vetBancoDados(1))

                prpDataSourceSQLServerCE = BancoDados
                Dim strConexao As String = mtdDefinirStringConexaoSQLServerCE()
                mtdFecharConexao()

                If System.IO.File.Exists(BancoDados) Then
                    objSqlServerCeEngine = New System.Data.SqlServerCe.SqlCeEngine(strConexao)
                    objSqlServerCeEngine.Compact(Nothing)
                    objSqlServerCeEngine.Compact(strConexao)
                    saida = True
                Else
                    setExcecao = ex.Message
                    saida = False
                End If
            Catch exception As Exception
                setExcecao = exception.Message
                saida = False
            End Try

            Return saida
        End Function

        Public Function mtdEncolherBancoDadosSQLServerCE() As Boolean
            Return mtdEncolherBancoDadosSQLServerCE(prpDataSourceSQLServerCE)
        End Function

        Public Function mtdEncolherBancoDadosSQLServerCE(ByVal BancoDados As String) As Boolean
            Dim saida As Boolean = False

            Dim ex As New System.Exception("Não há banco de dados (arquivo) a ser compactado.")
            Dim objSqlServerCeEngine As System.Data.SqlServerCe.SqlCeEngine = Nothing

            Dim vetBancoDados As String() = BancoDados.Split("."c)
            Dim NovoBancoDados As String = String.Format("{0}_compactado_reparado.{1}", vetBancoDados(0), vetBancoDados(1))

            prpDataSourceSQLServerCE = BancoDados
            Dim strConexao As String = mtdDefinirStringConexaoSQLServerCE()
            mtdFecharConexao()
            Try
                If Not System.IO.File.Exists(NovoBancoDados) Then
                    objSqlServerCeEngine = New System.Data.SqlServerCe.SqlCeEngine(strConexao)
                    objSqlServerCeEngine.Shrink()
                    saida = True
                Else
                    setExcecao = ex.Message
                    saida = False
                End If
            Catch exception As Exception
                setExcecao = exception.Message
                saida = False
            End Try

            Return saida
        End Function

        Public Function mtdRepararBancoDadosSQLServerCE() As Boolean
            Return mtdRepararBancoDadosSQLServerCE(prpDataSourceSQLServerCE, System.Data.SqlServerCe.RepairOption.RecoverAllPossibleRows)
        End Function

        Public Function mtdRepararBancoDadosSQLServerCE(ByVal OpcaoReparar As System.Data.SqlServerCe.RepairOption) As Boolean
            Return mtdRepararBancoDadosSQLServerCE(prpDataSourceSQLServerCE, OpcaoReparar)
        End Function

        Public Function mtdRepararBancoDadosSQLServerCE(ByVal BancoDados As String) As Boolean
            Return mtdRepararBancoDadosSQLServerCE(BancoDados, System.Data.SqlServerCe.RepairOption.RecoverAllPossibleRows)
        End Function

        Public Function mtdRepararBancoDadosSQLServerCE(ByVal BancoDados As String, ByVal OpcaoReparar As System.Data.SqlServerCe.RepairOption) As Boolean
            Dim saida As Boolean = False

            Try
                Dim ex As New System.Exception("Não há banco de dados (arquivo) a ser reparado.")
                Dim objSqlServerCeEngine As System.Data.SqlServerCe.SqlCeEngine = Nothing
                Dim vetBancoDados As String() = BancoDados.Split("."c)
                Dim NovoBancoDados As String = String.Format("{0}_compactado_reparado.{1}", vetBancoDados(0), vetBancoDados(1))

                prpDataSourceSQLServerCE = BancoDados
                Dim strConexao As String = mtdDefinirStringConexaoSQLServerCE()
                mtdFecharConexao()

                If System.IO.File.Exists(BancoDados) Then
                    objSqlServerCeEngine = New System.Data.SqlServerCe.SqlCeEngine(strConexao)
                    objSqlServerCeEngine.Repair(Nothing, OpcaoReparar)
                    saida = True
                Else
                    setExcecao = ex.Message
                    saida = False
                End If
            Catch exception As Exception
                setExcecao = exception.Message
                saida = False
            End Try
            Return saida
        End Function

        Public Function mtdAlterarBancoDadosSQLServerCE(ByVal NovoBancoDados As String) As Boolean
            Return mtdAlterarBancoDadosSQLServerCE(prpDataSourceSQLServerCE, NovoBancoDados)
        End Function

        Public Function mtdAlterarBancoDadosSQLServerCE(ByVal BancoDados As String, ByVal NovoBancoDados As String) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("Não há banco de dados (arquivo) a ser alterado.")

            Try
                prpDataSourceSQLServerCE = BancoDados
                mtdDefinirStringConexaoSQLServerCE()
                mtdFecharConexao()
                prpDataSourceSQLServerCE = NovoBancoDados
                mtdDefinirStringConexaoSQLServerCE()
                mtdFecharConexao()
                If System.IO.File.Exists(BancoDados) Then
                    If Not System.IO.File.Exists(NovoBancoDados) Then
                        System.IO.File.Move(BancoDados, NovoBancoDados)
                        saida = True
                    Else
                        ex = New System.Exception("Já existe um banco de dados (arquivo) com esse nome.")
                        saida = False
                    End If
                Else
                    setExcecao = ex.Message
                    saida = False
                End If
            Catch exception As Exception
                setExcecao = exception.Message
                saida = False
            End Try

            Return saida
        End Function

        Public Function mtdCriarBancoDadosSQLServerCE() As Boolean
            Return mtdCriarBancoDadosSQLServerCE(prpDataSourceSQLServerCE)
        End Function

        Public Function mtdCriarBancoDadosSQLServerCE(ByVal BancoDados As String) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("Já existe um banco de dados (arquivo) com esse nome.")

            Try
                prpDataSourceSQLServerCE = BancoDados
                mtdDefinirStringConexaoSQLServerCE()
                mtdFecharConexao()
                If Not System.IO.File.Exists(BancoDados) Then
                    Dim objSqlCeEngine As New System.Data.SqlServerCe.SqlCeEngine(prpConexao)
                    objSqlCeEngine.CreateDatabase()
                    objSqlCeEngine.Dispose()
                    saida = True
                Else
                    setExcecao = ex.Message
                    saida = False
                End If
            Catch exception As Exception
                setExcecao = exception.Message
                saida = False
            End Try

            Return saida
        End Function

        Public Function mtdDeletarBancoDadosSQLServerCE() As Boolean
            Return mtdDeletarBancoDadosSQLServerCE(prpDataSourceSQLServerCE)
        End Function

        Public Function mtdDeletarBancoDadosSQLServerCE(ByVal BancoDados As String) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("Não há banco de dados (arquivo) a ser deletado.")

            Try
                prpDataSourceSQLServerCE = BancoDados
                mtdDefinirStringConexaoSQLServerCE()
                mtdFecharConexao()
                If System.IO.File.Exists(BancoDados) Then
                    System.IO.File.Delete(BancoDados)
                    saida = True
                Else
                    setExcecao = ex.Message
                    saida = False
                End If
            Catch exception As Exception
                setExcecao = exception.Message
                saida = False
            End Try

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValor(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    strCampoBase = CampoBase
                    strOperacao = Operacao
                    objDadoBase = CampoBase

                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoSQLServerCE.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To (Campos_Dados.GetUpperBound(1))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados.GetUpperBound(1)), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    strCampoBase = CampoBase
                    strOperacao = Operacao
                    objDadoBase = DadoBase

                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.SqlDbType(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoSQLServerCE.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To (Campos_Dados.GetUpperBound(1))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    Exit Select
                                Case (1)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados(linha, coluna), System.Data.SqlDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    If Campos_Dados(1, coluna) IsNot Nothing Then
                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                    Else
                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados.GetUpperBound(1)), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    strCampoBase = CampoBase
                    strOperacao = Operacao
                    objDadoBase = DadoBase

                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.SqlDbType(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (2)
                                vetTamanhoColunas = New Integer(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoSQLServerCE.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To (Campos_Dados.GetUpperBound(1))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    Exit Select
                                Case (1)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados(linha, coluna), System.Data.SqlDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                    End If
                                    Exit Select
                                Case (2)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTamanhoColunas(coluna) = CInt(Campos_Dados(linha, coluna))
                                    Else
                                        vetTamanhoColunas(coluna) = CInt(0)
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    If Campos_Dados(1, coluna) IsNot Nothing Then
                                        If Campos_Dados(2, coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        End If
                                    Else
                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados.GetUpperBound(1)), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAtualizarDadosParametroComandoSQLServerCE(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object, ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
            End Select
            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValor(ByVal NomeTabela As String, ByVal Campos_Dados As Object()(), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        strCampoBase = CampoBase
                        strOperacao = Operacao
                        objDadoBase = DadoBase

                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoSQLServerCE.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To (Campos_Dados(linha).GetUpperBound(0))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados(linha).GetUpperBound(0)), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados As Object()(), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    strCampoBase = CampoBase
                    strOperacao = Operacao
                    objDadoBase = DadoBase

                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.SqlDbType(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoSQLServerCE.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To (Campos_Dados(linha).GetUpperBound(0))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados(linha)(coluna), System.Data.SqlDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        If Campos_Dados(1)(coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados(linha).GetUpperBound(0)), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados As Object()(), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.SqlDbType(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (2)
                                    vetTamanhoColunas = New Integer(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    strCampoBase = DirectCast(Campos_Dados(linha)(Campos_Dados(linha).GetUpperBound(0) - 2), String)
                                    strOperacao = DirectCast(Campos_Dados(linha)(Campos_Dados.GetUpperBound(0) - 1), String)
                                    objDadoBase = Campos_Dados(linha)(Campos_Dados(linha).GetUpperBound(0))
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoSQLServerCE.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To (Campos_Dados(linha).GetUpperBound(0))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados(linha)(coluna), System.Data.SqlDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case (2)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTamanhoColunas(coluna) = CInt(Campos_Dados(linha)(coluna))
                                        Else
                                            vetTamanhoColunas(coluna) = CInt(0)
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        If Campos_Dados(1)(coluna) IsNot Nothing Then
                                            If Campos_Dados(2)(coluna) IsNot Nothing Then
                                                mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                            Else
                                                mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                            End If
                                        Else
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados(linha).GetUpperBound(0) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAtualizarDadosParametroComandoSQLServerCE(ByVal NomeTabela As String, ByVal Campos_Dados As Object()(), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object, ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
            End Select
            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValor(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2), String)
                                strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1), String)
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1))
                                vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoSQLServerCE.Parameters.Clear()

                        For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), String)
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), Object)

                                    mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.SqlDbType(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2), String)
                                strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1), String)
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1))
                                vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoSQLServerCE.Parameters.Clear()

                        For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), String)
                                    Exit Select
                                Case (1)
                                    If Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), System.Data.SqlDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), Object)

                                    If Campos_Dados_CampoBase_Operacao_DadoBase(1, coluna) IsNot Nothing Then
                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                    Else
                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.SqlDbType(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case (2)
                                vetTamanhoColunas = New Integer(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2), String)
                                strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1), String)
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1))
                                vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoSQLServerCE.Parameters.Clear()

                        For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), String)
                                    Exit Select
                                Case (1)
                                    If Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), System.Data.SqlDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                    End If
                                    Exit Select
                                Case (2)
                                    If Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna) IsNot Nothing Then
                                        vetTamanhoColunas(coluna) = CInt(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna))
                                    Else
                                        vetTamanhoColunas(coluna) = CInt(0)
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), Object)

                                    If Campos_Dados_CampoBase_Operacao_DadoBase(1, coluna) IsNot Nothing Then
                                        If Campos_Dados_CampoBase_Operacao_DadoBase(2, coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        End If
                                    Else
                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAtualizarDadosParametroComandoSQLServerCE(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object(,), ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
            End Select
            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValor(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 2), String)
                                    strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 1), String)
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0))
                                    vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoSQLServerCE.Parameters.Clear()

                            For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetLowerBound(0) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), String)
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), Object)

                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.SqlDbType(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 2), String)
                                    strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 1), String)
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0))
                                    vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoSQLServerCE.Parameters.Clear()

                            For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetLowerBound(0) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), String)
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), System.Data.SqlDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), Object)

                                        If Campos_Dados_CampoBase_Operacao_DadoBase(1)(coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)


                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.SqlDbType(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (2)
                                    vetTamanhoColunas = New Integer(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 2), String)
                                    strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0) - 1), String)
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0))
                                    vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoSQLServerCE.Parameters.Clear()

                            For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetLowerBound(0) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), String)
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), System.Data.SqlDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case (2)
                                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna) IsNot Nothing Then
                                            vetTamanhoColunas(coluna) = CInt(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna))
                                        Else
                                            vetTamanhoColunas(coluna) = CInt(0)
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), Object)

                                        If Campos_Dados_CampoBase_Operacao_DadoBase(1)(coluna) IsNot Nothing Then
                                            If Campos_Dados_CampoBase_Operacao_DadoBase(2)(coluna) IsNot Nothing Then
                                                mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                            Else
                                                mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                            End If
                                        Else
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoSQLServerCE(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAtualizarDadosParametroComandoSQLServerCE(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object()(), ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdAtualizarDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
            End Select
            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoSQLServerCEValor(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        objResgistrosColunas = Nothing
                        prpComandoSQLServerCE.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To Campos_Dados.GetUpperBound(1)
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                    objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "@{0}, ", "@{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoSQLServerCEValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.SqlDbType(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        objResgistrosColunas = Nothing
                        prpComandoSQLServerCE.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To Campos_Dados.GetUpperBound(1)
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                                Case (1)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados(linha, coluna), System.Data.SqlDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    If Campos_Dados(1, coluna) IsNot Nothing Then
                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                    Else
                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "@{0}, ", "@{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoSQLServerCEValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.SqlDbType(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (2)
                                vetTamanhoColunas = New Integer(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        objResgistrosColunas = Nothing
                        prpComandoSQLServerCE.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To Campos_Dados.GetUpperBound(1)
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                                Case (1)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados(linha, coluna), System.Data.SqlDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                    End If
                                    Exit Select
                                Case (2)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTamanhoColunas(coluna) = CInt(Campos_Dados(linha, coluna))
                                    Else
                                        vetTamanhoColunas(coluna) = CInt(0)
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    If Campos_Dados(1, coluna) IsNot Nothing Then
                                        If Campos_Dados(2, coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        End If
                                    Else
                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "@{0}, ", "@{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdInserirDadosParametroComandoSQLServerCE(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,), ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdInserirDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdInserirDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdInserirDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados)
                    Exit Select
            End Select
            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoSQLServerCEValor(ByVal NomeTabela As String, ByVal Campos_Dados As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            objResgistrosColunas = Nothing
                            prpComandoSQLServerCE.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To Campos_Dados(linha).GetUpperBound(0)
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                        objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "@{0}, ", "@{0}"), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoSQLServerCEValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.SqlDbType(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            objResgistrosColunas = Nothing
                            prpComandoSQLServerCE.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To Campos_Dados(linha).GetUpperBound(0)
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados(linha)(coluna), System.Data.SqlDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        If Campos_Dados(1)(coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "@{0}, ", "@{0}"), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoSQLServerCEValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.SqlDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.SqlDbType(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (2)
                                    vetTamanhoColunas = New Integer(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            objResgistrosColunas = Nothing
                            prpComandoSQLServerCE.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To Campos_Dados(linha).GetUpperBound(0)
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados(linha)(coluna), System.Data.SqlDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.SqlDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case (2)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTamanhoColunas(coluna) = CInt(Campos_Dados(linha)(coluna))
                                        Else
                                            vetTamanhoColunas(coluna) = CInt(0)
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        If Campos_Dados(1)(coluna) IsNot Nothing Then
                                            If Campos_Dados(2)(coluna) IsNot Nothing Then
                                                mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                            Else
                                                mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                            End If
                                        Else
                                            mtdExecutarParametroComandoSQLServerCE(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "@{0}, ", "@{0}"), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdInserirDadosParametroComandoSQLServerCE(ByVal NomeTabela As String, ByVal Campos_Dados As Object()(), ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdInserirDadosParametroComandoSQLServerCEValor(NomeTabela, Campos_Dados)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdInserirDadosParametroComandoSQLServerCEValorTipo(NomeTabela, Campos_Dados)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdInserirDadosParametroComandoSQLServerCEValorTipoTamanho(NomeTabela, Campos_Dados)
                    Exit Select
            End Select
            Return saida
        End Function

        Public Function mtdDeletarDadosParametroComandoSQLServerCE(ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = True

            mtdExecutarParametroComandoSQLServerCE(CampoSelecionador, Dado)

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("DELETE FROM {0} WHERE {1} {2} @{1};", NomeTabela, CampoSelecionador, Operacao))
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdSelecionarDadosParametroComandoSQLServerCE(ByVal NumeroLinhas As UInteger, ByVal Campos As String, ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = True

            mtdExecutarParametroComandoSQLServerCE(CampoSelecionador, Dado)

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("SELECT {0}{1} FROM {2} WHERE {3} {4} @{3};", If(NumeroLinhas <> 0, String.Format("TOP ({0}) ", NumeroLinhas), String.Empty), Campos, NomeTabela, CampoSelecionador, Operacao, _
             Dado))

            Return saida
        End Function

        Public Function mtdSelecionarDadosParametroComandoSQLServerCE(ByVal NumeroLinhas As UInteger, ByVal Campos As String(), ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdSelecionarDadosParametroComandoSQLServerCE(NumeroLinhas, mtdVetorLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, Dado)

            Return saida
        End Function

        Public Function mtdSelecionarDadosParametroComandoSQLServerCE(ByVal NumeroLinhas As UInteger, ByVal Campos As String, ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object, _
         ByVal CampoOrdenador As String, ByVal Crescente As Boolean) As Boolean
            Dim saida As Boolean = True

            mtdExecutarParametroComandoSQLServerCE(CampoSelecionador, Dado)

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("SELECT {0}{1} FROM {2} WHERE {3} {4} @{3} ORDER BY {5}{6};;", If(NumeroLinhas <> 0, String.Format("TOP ({0}) ", NumeroLinhas), String.Empty), Campos, NomeTabela, CampoSelecionador, Operacao, _
             CampoOrdenador, If(Crescente, String.Empty, " DESC")))

            Return saida
        End Function

        Public Function mtdSelecionarDadosParametroComandoSQLServerCE(ByVal NumeroLinhas As UInteger, ByVal Campos As String(), ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object, _
         ByVal CampoOrdenador As String, ByVal Crescente As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdSelecionarDadosParametroComandoSQLServerCE(NumeroLinhas, mtdVetorLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, Dado, _
             CampoOrdenador, Crescente)

            Return saida
        End Function
    End Class
End Namespace