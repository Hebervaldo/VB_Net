Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmCadastroUsuario
        Private ThImportarTabelaUsuarios As System.Threading.Thread

        Private strNomeProcessoImportarTabelaUsuarios As String = "Importar Tabela de Usuários"

        Friend Sub mtdIniciarThreadImportarTabelaUsuarios()
            mtdIniciarThreadImportarTabelaUsuarios(True)
        End Sub

        Friend Sub mtdIniciarThreadImportarTabelaUsuarios(ByVal Iniciar As Boolean)
            Try
                'intProgresso = 0
                'strNomeProcesso = strNomeProcessoImportarTabelaUsuarios
                blnAbortarThreadImportarTabelaUsuarios = Not Iniciar
                blnForcarAbortarThreadImportarTabelaUsuarios = False
                blnThreadAtivadaImportarTabelaUsuarios = True
                blnSucessoImportarTabelaUsuarios = False
                ThImportarTabelaUsuarios = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImportarTabelaUsuarios))
                ThImportarTabelaUsuarios.IsBackground = True
                ThImportarTabelaUsuarios.Priority = System.Threading.ThreadPriority.Normal
                ThImportarTabelaUsuarios.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImportarTabelaUsuarios: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImportarTabelaUsuarios()
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoImportarTabelaUsuarios
            blnAbortarThreadImportarTabelaUsuarios = False
            blnForcarAbortarThreadImportarTabelaUsuarios = False

            blnThreadAtivadaImportarTabelaUsuarios = True
            blnSucessoImportarTabelaUsuarios = False
        End Sub

        Private Shared blnForcarAbortarThreadImportarTabelaUsuarios As Boolean = False
        Private Shared blnAbortarThreadImportarTabelaUsuarios As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImportarTabelaUsuarios As Integer = 1000

        Friend Sub mtdAbortarThreadImportarTabelaUsuarios()
            mtdAbortarThreadImportarTabelaUsuarios(False)
        End Sub

        Friend Sub mtdAbortarThreadImportarTabelaUsuarios(ByVal Forcar As Boolean)
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoImportarTabelaUsuarios
            blnAbortarThreadImportarTabelaUsuarios = True
            blnForcarAbortarThreadImportarTabelaUsuarios = Forcar

            blnThreadAtivadaImportarTabelaUsuarios = False
            blnSucessoImportarTabelaUsuarios = False

            Try
                ThImportarTabelaUsuarios.Join(intTempoSaidaAbortarThreadImportarTabelaUsuarios)
                ThImportarTabelaUsuarios.Abort()
                ThImportarTabelaUsuarios = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImportarTabelaUsuarios: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImportarTabelaUsuarios()
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoImportarTabelaUsuarios
            blnAbortarThreadImportarTabelaUsuarios = True
            blnForcarAbortarThreadImportarTabelaUsuarios = True

            blnThreadAtivadaImportarTabelaUsuarios = False
            blnSucessoImportarTabelaUsuarios = False
        End Sub

        Private Shared LockerImportarTabelaUsuarios As New Object()

        Private Sub mtdRotinaThreadImportarTabelaUsuarios()
            While Not blnForcarAbortarThreadImportarTabelaUsuarios
                If Not blnAbortarThreadImportarTabelaUsuarios Then
                    'System.Threading.Monitor.Enter(LockerImportarTabelaUsuarios)
                    SyncLock (LockerImportarTabelaUsuarios)
                        Try
                            mtdImportarTabelaUsuarios()
                            mtdAbortarThreadImportarTabelaUsuarios(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImportarTabelaUsuarios)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImportarTabelaUsuarios As Boolean = False
        Friend blnSucessoImportarTabelaUsuarios As Boolean = False

        Private lngCodigoImportarTabelaUsuarios As Long = 0

        Protected Friend Sub mtdImportarTabelaUsuarios()
            'mtdDeletarTabelaUsuarios()
            'mtdDeletarDadosTabelaUsuarios()
            mtdCriarTabelaUsuarios()
            mtdInserirDadosTabelaUsuarios()
        End Sub

        Private intcoluna As Integer = 0

        Private campos As String()()

        Public Sub mtdDeletarTabelaUsuarios()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strNomeTabelaPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaUsuarios()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strNomeTabelaPrincipal, strColunaPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdCriarTabelaUsuarios()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            intcoluna = 4

            campos = New String(intcoluna)() {}
            campos(0) = New String(3) {"Contador", "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyContador PRIMARY KEY"}
            campos(1) = New String(3) {"Usuario", "TEXT", "255", " NOT NULL CONSTRAINT UniqueInventario UNIQUE"}
            campos(2) = New String(3) {"Status", "TEXT", "255", String.Empty}
            campos(3) = New String(3) {"Senha_Criptografada", "TEXT", "255", String.Empty}
            campos(4) = New String(3) {"Chave", "TEXT", "255", String.Empty}

            objImplementacaoBancoDados.mtdCriarTabela(strNomeTabelaPrincipal, campos)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Private intContador As Integer = 0
        Private strUsuario As String = "Administrador"
        Private strStatus As String = "Administrador"
        Private strSenhaDescriptografada As String = "12345678"
        Private strSenhaCriptografada As String = String.Empty
        Private strChave As String = "Chave_Padrao"

        Public Sub mtdInserirDadosTabelaUsuarios()
            strSenhaCriptografada = objCriptografia.mtdCriptografar(strSenhaDescriptografada, strChave, Encryption.Symmetric.Provider.Rijndael)

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            Dim dados As String()() = New String(1)() {}
            objImplementacaoBancoDados.mtdAbrirConexao()
            objImplementacaoBancoDados.mtdExecutarComando(String.Format("SELECT * FROM {0};", strNomeTabelaPrincipal))
            objImplementacaoBancoDados.mtdDefinirLeitorDados()
            dados(0) = objImplementacaoBancoDados.mtdObterCabecalhoColunas()
            dados(1) = New String() _
            { _
            String.Format("{0}", intContador), _
            String.Format("'{0}'", strUsuario), _
            String.Format("'{0}'", strStatus), _
            String.Format("'{0}'", strSenhaCriptografada), _
            String.Format("'{0}'", strChave) _
            }
            objImplementacaoBancoDados.mtdInserirDados(strNomeTabelaPrincipal, dados)

            objImplementacaoBancoDados.Dispose()
        End Sub
    End Class
End Namespace