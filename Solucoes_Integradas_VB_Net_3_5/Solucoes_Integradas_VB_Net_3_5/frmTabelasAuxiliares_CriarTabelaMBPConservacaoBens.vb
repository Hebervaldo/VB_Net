Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmTabelasAuxiliares
        Private ThCriarTabelaMBPConservacaoBens As System.Threading.Thread

        Private strNomeProcessoCriarTabelaMBPConservacaoBens As String = "Criar Tabela de Usuários"

        Friend Sub mtdIniciarThreadCriarTabelaMBPConservacaoBens()
            mtdIniciarThreadCriarTabelaMBPConservacaoBens(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaMBPConservacaoBens(ByVal Iniciar As Boolean)
            Try
                frmPrincipal.intProgresso = 0
                frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPConservacaoBens
                blnAbortarThreadCriarTabelaMBPConservacaoBens = Not Iniciar
                blnForcarAbortarThreadCriarTabelaMBPConservacaoBens = False
                blnThreadAtivadaCriarTabelaMBPConservacaoBens = True
                blnSucessoCriarTabelaMBPConservacaoBens = False
                ThCriarTabelaMBPConservacaoBens = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaMBPConservacaoBens))
                ThCriarTabelaMBPConservacaoBens.IsBackground = True
                ThCriarTabelaMBPConservacaoBens.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaMBPConservacaoBens.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaMBPConservacaoBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaMBPConservacaoBens()
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPConservacaoBens
            blnAbortarThreadCriarTabelaMBPConservacaoBens = False
            blnForcarAbortarThreadCriarTabelaMBPConservacaoBens = False

            blnThreadAtivadaCriarTabelaMBPConservacaoBens = True
            blnSucessoCriarTabelaMBPConservacaoBens = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaMBPConservacaoBens As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaMBPConservacaoBens As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaMBPConservacaoBens As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaMBPConservacaoBens()
            mtdAbortarThreadCriarTabelaMBPConservacaoBens(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaMBPConservacaoBens(ByVal Forcar As Boolean)
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPConservacaoBens
            blnAbortarThreadCriarTabelaMBPConservacaoBens = True
            blnForcarAbortarThreadCriarTabelaMBPConservacaoBens = Forcar

            blnThreadAtivadaCriarTabelaMBPConservacaoBens = False
            blnSucessoCriarTabelaMBPConservacaoBens = False

            Try
                ThCriarTabelaMBPConservacaoBens.Join(intTempoSaidaAbortarThreadCriarTabelaMBPConservacaoBens)
                ThCriarTabelaMBPConservacaoBens.Abort()
                ThCriarTabelaMBPConservacaoBens = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaMBPConservacaoBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaMBPConservacaoBens()
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPConservacaoBens
            blnAbortarThreadCriarTabelaMBPConservacaoBens = True
            blnForcarAbortarThreadCriarTabelaMBPConservacaoBens = True

            blnThreadAtivadaCriarTabelaMBPConservacaoBens = False
            blnSucessoCriarTabelaMBPConservacaoBens = False
        End Sub

        Private Shared LockerCriarTabelaMBPConservacaoBens As New Object()

        Private Sub mtdRotinaThreadCriarTabelaMBPConservacaoBens()
            While Not blnForcarAbortarThreadCriarTabelaMBPConservacaoBens
                If Not blnAbortarThreadCriarTabelaMBPConservacaoBens Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaMBPConservacaoBens)
                    SyncLock (LockerCriarTabelaMBPConservacaoBens)
                        Try
                            mtdGerarTabelaMBPConservacaoBens()
                            mtdAbortarThreadCriarTabelaMBPConservacaoBens(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaMBPConservacaoBens)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaMBPConservacaoBens As Boolean = False
        Friend blnSucessoCriarTabelaMBPConservacaoBens As Boolean = False

        Private lngCodigoCriarTabelaMBPConservacaoBens As Long = 0

        Protected Friend Sub mtdGerarTabelaMBPConservacaoBens()
            'mtdDeletarTabelaMBPConservacaoBens()
            'mtdDeletarDadosTabelaMBPConservacaoBens()
            mtdCriarTabelaMBPConservacaoBens()
            mtdInserirDadosTabelaMBPConservacaoBens()
        End Sub

        Private intcolunaMBPConservacaoBens As Integer = 0

        Private camposMBPConservacaoBens As String()()

        Public Sub mtdDeletarTabelaMBPConservacaoBens()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strTabelaAuxiliaresConservacaoBensPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaMBPConservacaoBens()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strTabelaAuxiliaresConservacaoBensPrincipal, strColunaConservacaoBensPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdCriarTabelaMBPConservacaoBens()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            Dim campos As String()() = New String(0)() {}
            campos(0) = New String(3) { _
            strColunaConservacaoBensPrincipal, _
                "TEXT", _
                "255", _
                "CONSTRAINT primarykeyConservacaoBens PRIMARY KEY" _
            }
            objBDPrincipal.mtdCriarTabela( _
                strTabelaAuxiliaresConservacaoBensPrincipal, _
                campos)

            objBDPrincipal.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaMBPConservacaoBens()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando( _
                String.Format("SELECT * FROM {0};", _
                              strTabelaAuxiliaresConservacaoBensPrincipal))
            objBDPrincipal.mtdDefinirLeitorDados()
            objBDPrincipal.mtdProximoRegistro()

            Dim dados As String()() = New String(4)() {}
            dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()
            dados(1) = New String(0) {"'BEM NOVO'"}
            dados(2) = New String(0) {"'BOM (BEM EM USO)'"}
            dados(3) = New String(0) {"'REGULAR (BEM EM USO)'"}
            dados(4) = New String(0) {"'PESSIMO (FORA DE USO)'"}
            objBDPrincipal.mtdInserirDados( _
                strTabelaAuxiliaresConservacaoBensPrincipal, _
                dados)

            objBDPrincipal.Dispose()
        End Sub
    End Class
End Namespace