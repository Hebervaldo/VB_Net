Imports System.Collections.Generic
Imports System.Text

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class clsConexaoBancoDados

        Public Const cntStringConexaoAccessOdbc As String = "Driver={Microsoft Access Driver (*.mdb, *.accdb)}}; Dbq={0}; Uid={1}; Pwd={2};"
        Public Const cntStringConexaoAccess2003OleDb As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Jet OLEDB:Database Password={2};"
        Public Const cntStringConexaoAccess2007OleDb As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Jet OLEDB:Database Password={2};"

        Public Const cntExemploStringConexaoAccessOdbc As String = "Driver={Microsoft Access Driver (*.mdb, *.accdb)}}; Dbq=C:\mydatabase.mdb; Uid=Admin; Pwd=;"
        Public Const cntExemploStringConexaoAccess2003OleDb As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Jet OLEDB:Database Password=;"
        Public Const cntExemploStringConexaoAccess2007OleDb As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Jet OLEDB:Database Password=;"

        ' Variaveis somente leitura de instancia do Access

        Private ReadOnly cntProviderAccess As String() = {"Provider", "Microsoft.Jet.OLEDB.4.0", "Microsoft.ACE.OLEDB.12.0"}
        Private ReadOnly cntDriverAccess As String() = {"Driver", "{Microsoft Access Driver (*.mdb)}"}
        Private ReadOnly cntDataSourceAccess As String() = {"DataSource", String.Empty}
        Private ReadOnly cntUserIdAccess As String() = {"User Id", String.Empty}
        Private ReadOnly cntPasswordAccess As String() = {"Password", String.Empty}

        ' Variaveis de instancia do Access

        Private strProviderAccess As String()
        Private strDriverAccess As String()
        Private strDataSourceAccess As String()
        Private strUserIdAccess As String()
        Private strPasswordAccess As String()

        Private vetProviderAccess As String() = {"Provider"}
        Private vetDriverAccess As String() = {"Driver"}
        Private vetDataSourceAccess As String() = {"DataSource", "Data Source", "Dbq", "Server"}
        Private vetUserIdAccess As String() = {"User Id", "Uid"}
        Private vetPasswordAccess As String() = {"Password", "Pwd", "Jet OLEDB:Database Password"}

        ' Variaveis que determinam se a conexao incorporara o banco de dados. Isso facilita na criacao, alteracao ou delecao do banco de dados.

        Private blnPermitirBancoDadosAccess As Boolean = True

        ' Propriedades de instancia do Access

        Public Property prpProviderAccess() As String
            Get
                If strProviderAccess Is Nothing Then
                    strProviderAccess = New String(1) {cntProviderAccess(0), cntProviderAccess(1)}
                End If
                Return strProviderAccess(1)
            End Get
            Set(ByVal value As String)
                If strProviderAccess Is Nothing Then
                    strProviderAccess = New String(1) {cntProviderAccess(0), cntProviderAccess(1)}
                End If
                strProviderAccess(1) = value
                mtdReDefinirConexaoString(strProviderAccess)
            End Set
        End Property

        Public Property prpDriverAccess() As String
            Get
                If strDriverAccess Is Nothing Then
                    strDriverAccess = New String(1) {cntDriverAccess(0), cntDriverAccess(1)}
                End If
                Return strDriverAccess(1)
            End Get
            Set(ByVal value As String)
                If strDriverAccess Is Nothing Then
                    strDriverAccess = New String(1) {cntDriverAccess(0), cntDriverAccess(1)}
                End If
                strDriverAccess(1) = value
                mtdReDefinirConexaoString(strDriverAccess)
            End Set
        End Property

        Public Property prpDataSourceAccess() As String
            Get
                If strDataSourceAccess Is Nothing Then
                    strDataSourceAccess = New String(1) {cntDataSourceAccess(0), cntDataSourceAccess(1)}
                End If
                Return strDataSourceAccess(1)
            End Get
            Set(ByVal value As String)
                If strDataSourceAccess Is Nothing Then
                    strDataSourceAccess = New String(1) {cntDataSourceAccess(0), cntDataSourceAccess(1)}
                End If
                strDataSourceAccess(1) = value
                mtdReDefinirConexaoString(strDataSourceAccess)
            End Set
        End Property

        Public Property prpUserIdAccess() As String
            Get
                If strUserIdAccess Is Nothing Then
                    strUserIdAccess = New String(1) {cntUserIdAccess(0), cntUserIdAccess(1)}
                End If
                Return strUserIdAccess(1)
            End Get
            Set(ByVal value As String)
                If strUserIdAccess Is Nothing Then
                    strUserIdAccess = New String(1) {cntUserIdAccess(0), cntUserIdAccess(1)}
                End If
                strUserIdAccess(1) = value
                mtdReDefinirConexaoString(strUserIdAccess)
            End Set
        End Property

        Public Property prpPasswordAccess() As String
            Get
                If strPasswordAccess Is Nothing Then
                    strPasswordAccess = New String(1) {cntPasswordAccess(0), cntPasswordAccess(1)}
                End If
                Return strPasswordAccess(1)
            End Get
            Set(ByVal value As String)
                If strPasswordAccess Is Nothing Then
                    strPasswordAccess = New String(1) {cntPasswordAccess(0), cntPasswordAccess(1)}
                End If
                strPasswordAccess(1) = value
                mtdReDefinirConexaoString(strPasswordAccess)
            End Set
        End Property

        ' Metodos de instancia do Access

        Public Function mtdValidarConexaoDispositivoAccess(ByVal Conexao As String) As String()
            strDriverAccess = mtdValidarConexao(Conexao, vetDriverAccess)
            Return strDriverAccess
        End Function

        Public Function mtdValidarConexaoProvedorAccess(ByVal Conexao As String) As String()
            strProviderAccess = mtdValidarConexao(Conexao, vetProviderAccess)
            Return strProviderAccess
        End Function

        Public Function mtdValidarConexaoOrigemDadosAccess(ByVal Conexao As String) As String()
            strDataSourceAccess = mtdValidarConexao(Conexao, vetDataSourceAccess)
            Return strDataSourceAccess
        End Function

        Public Function mtdValidarConexaoUsuarioAccess(ByVal Conexao As String) As String()
            strUserIdAccess = mtdValidarConexao(Conexao, vetUserIdAccess)
            Return strUserIdAccess
        End Function

        Public Function mtdValidarConexaoSenhaAccess(ByVal Conexao As String) As String()
            strPasswordAccess = mtdValidarConexao(Conexao, vetPasswordAccess)
            Return strPasswordAccess
        End Function

        Public Function mtdValidarConexaoAccess(ByVal Conexao As String) As String
            Dim saida As String = String.Empty

            prpTipoConexao = TipoConexao.Indisponivel
            'if (strDriverAccess == null || strDriverAccess[1] == cntDriverAccess[1])
            '{
            mtdValidarConexaoDispositivoAccess(Conexao)
            '}
            If strDriverAccess IsNot Nothing Then
                prpTipoConexao = TipoConexao.ConexaoAccessOdbc
            End If
            'if (strProviderAccess == null || strProviderAccess[1] == cntProviderAccess[1])
            '{
            mtdValidarConexaoProvedorAccess(Conexao)
            '}
            If strProviderAccess IsNot Nothing Then
                If strProviderAccess(strProviderAccess.GetUpperBound(0)) = cntProviderAccess(cntProviderAccess.GetUpperBound(0)) Then
                    prpTipoConexao = TipoConexao.ConexaoAccess2007OleDb
                Else
                    prpTipoConexao = TipoConexao.ConexaoAccess2003OleDb
                End If
            End If
            'if (strDataSourceAccess == null || strDataSourceAccess[1] == cntDataSourceAccess[1])
            '{
            mtdValidarConexaoOrigemDadosAccess(Conexao)
            '}
            'if (strUserIdAccess == null || strUserIdAccess[1] == cntUserIdAccess[1])
            '{
            mtdValidarConexaoUsuarioAccess(Conexao)
            '}
            'if (strPasswordAccess == null || strPasswordAccess[1] == cntPasswordAccess[1])
            '{
            mtdValidarConexaoSenhaAccess(Conexao)
            '}

            If strDriverAccess IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strDriverAccess(0), strDriverAccess(1))
            End If
            If strProviderAccess IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strProviderAccess(0), strProviderAccess(1))
            End If
            If strDataSourceAccess IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strDataSourceAccess(0), strDataSourceAccess(1))
            End If
            If strUserIdAccess IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strUserIdAccess(0), strUserIdAccess(1))
            End If
            If strPasswordAccess IsNot Nothing Then
                saida += String.Format("{0}={1};", strPasswordAccess(0), strPasswordAccess(1))
            End If
            Return saida
        End Function

        Public Function mtdDefinirStringConexaoAccess() As String
            Return mtdDefinirStringConexaoAccess(prpConexao, True)
        End Function

        Public Function mtdDefinirStringConexaoAccess(ByVal Conexao As String, ByVal PermitirBancoDados As Boolean) As String
            blnPermitirBancoDadosAccess = PermitirBancoDados
            mtdValidarConexaoAccess(Conexao)
            Return mtdDefinirStringConexaoAccess(prpTipoConexao, prpDataSourceAccess, prpUserIdAccess, prpPasswordAccess)
        End Function

        Public Function mtdDefinirStringConexaoAccess(ByVal TipoConexao As TipoConexao, ByVal DataSource As String) As String
            Return mtdDefinirStringConexaoAccess(TipoConexao, DataSource, cntUserIdAccess(1), cntPasswordAccess(1))
        End Function

        Public Function mtdDefinirStringConexaoAccess(ByVal TipoConexao As TipoConexao, ByVal DataSource As String, ByVal UserId As String, ByVal Password As String) As String
            Dim saida As String = String.Empty
            Select Case TipoConexao
                Case TipoConexao.ConexaoAccessOdbc
                    saida = String.Format(cntStringConexaoAccessOdbc.Replace(String.Format("Driver={0}; ", cntDriverAccess(1)), String.Empty), DataSource, UserId, Password)
                    strDriverAccess = cntDriverAccess
                    saida = String.Format("{0}={1}; ", strDriverAccess(0), strDriverAccess(1)) & saida
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida)
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                    Exit Select
                Case TipoConexao.ConexaoAccess2003OleDb
                    saida = String.Format(cntStringConexaoAccess2003OleDb.Replace(String.Format("Provider={0}; ", cntProviderAccess(1)), String.Empty), DataSource, UserId, Password)
                    strProviderAccess = cntProviderAccess
                    saida = String.Format("{0}={1}; ", strProviderAccess(0), strProviderAccess(1)) & saida
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida)
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                    Exit Select
                Case TipoConexao.ConexaoAccess2007OleDb
                    saida = String.Format(cntStringConexaoAccess2007OleDb.Replace(String.Format("Provider={0}; ", cntProviderAccess(1)), String.Empty), DataSource, UserId, Password)
                    strProviderAccess = cntProviderAccess
                    saida = String.Format("{0}={1}; ", strProviderAccess(0), strProviderAccess(1)) & saida
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida)
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                    Exit Select
                Case TipoConexao.Indisponivel
                    saida = TipoConexao.Indisponivel.ToString()
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel
                    Exit Select
            End Select
            prpConexao = mtdValidarConexaoAccess(saida)
            Return prpConexao.Trim()
        End Function
    End Class

    Partial Public Class clsImplementacaoBancoDados
        ' Access

        Public Function mtdCompactarRepararBancoDadosAccess() As Boolean
            Return mtdCompactarRepararBancoDadosAccess(prpDataSourceAccess)
        End Function

        Public Function mtdCompactarRepararBancoDadosAccess(ByVal BancoDados As String) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("Não há banco de dados (arquivo) a ser compactado e reparado.")
            Dim objJRO As JRO.JetEngine
            Dim vetBancoDados As String() = BancoDados.Split("."c)
            Dim NovoBancoDados As String = String.Format("{0}_compactado_reparado.{1}", vetBancoDados(0), vetBancoDados(1))

            prpDataSourceAccess = BancoDados
            Dim strConexao As String = mtdDefinirStringConexaoAccess()
            mtdFecharConexao()
            prpDataSourceAccess = NovoBancoDados
            Dim strNovaConexao As String = mtdDefinirStringConexaoAccess()
            mtdFecharConexao()
            Try
                If System.IO.File.Exists(BancoDados) Then
                    If Not System.IO.File.Exists(NovoBancoDados) Then
                        objJRO = New JRO.JetEngine()
                        objJRO.CompactDatabase(strConexao, strNovaConexao)
                        System.IO.File.Delete(BancoDados)
                        System.IO.File.Move(NovoBancoDados, BancoDados)
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

        Public Function mtdAlterarBancoDadosAccess(ByVal NovoBancoDados As String) As Boolean
            Return mtdAlterarBancoDadosAccess(prpDataSourceAccess, NovoBancoDados)
        End Function

        Public Function mtdAlterarBancoDadosAccess(ByVal BancoDados As String, ByVal NovoBancoDados As String) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("Não há banco de dados (arquivo) a ser alterado.")

            Try
                prpDataSourceAccess = BancoDados
                mtdDefinirStringConexaoAccess()
                mtdFecharConexao()
                prpDataSourceAccess = NovoBancoDados
                mtdDefinirStringConexaoAccess()
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

        Public Function mtdCriarBancoDadosAccess() As Boolean
            Return mtdCriarBancoDadosAccess(prpDataSourceAccess)
        End Function

        Public Function mtdCriarBancoDadosAccess(ByVal BancoDados As String) As Boolean
            Dim saida As Boolean = False

            Dim ex As New System.Exception("Já existe um banco de dados (arquivo) com esse nome.")

            Try
                prpDataSourceAccess = BancoDados
                mtdDefinirStringConexaoAccess()
                mtdFecharConexao()
                If Not System.IO.File.Exists(BancoDados) Then
                    Dim objCatalogo As New ADOX.Catalog()
                    objCatalogo.Create(mtdDefinirStringConexaoAccess(prpConexao, True))
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

        Public Function mtdDeletarBancoDadosAccess() As Boolean
            Return mtdDeletarBancoDadosAccess(prpDataSourceAccess)
        End Function

        Public Function mtdDeletarBancoDadosAccess(ByVal BancoDados As String) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("Não há banco de dados (arquivo) a ser deletado.")

            Try
                prpDataSourceAccess = BancoDados
                mtdDefinirStringConexaoAccess()
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
    End Class
End Namespace