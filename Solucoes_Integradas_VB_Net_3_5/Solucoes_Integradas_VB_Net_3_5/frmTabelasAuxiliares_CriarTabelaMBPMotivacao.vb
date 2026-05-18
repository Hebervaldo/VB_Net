Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmTabelasAuxiliares
        Private ThCriarTabelaMBPMotivacao As System.Threading.Thread

        Private strNomeProcessoCriarTabelaMBPMotivacao As String = "Criar Tabela de Usuários"

        Friend Sub mtdIniciarThreadCriarTabelaMBPMotivacao()
            mtdIniciarThreadCriarTabelaMBPMotivacao(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaMBPMotivacao(ByVal Iniciar As Boolean)
            Try
                frmPrincipal.intProgresso = 0
                frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPMotivacao
                blnAbortarThreadCriarTabelaMBPMotivacao = Not Iniciar
                blnForcarAbortarThreadCriarTabelaMBPMotivacao = False
                blnThreadAtivadaCriarTabelaMBPMotivacao = True
                blnSucessoCriarTabelaMBPMotivacao = False
                ThCriarTabelaMBPMotivacao = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaMBPMotivacao))
                ThCriarTabelaMBPMotivacao.IsBackground = True
                ThCriarTabelaMBPMotivacao.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaMBPMotivacao.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaMBPMotivacao: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaMBPMotivacao()
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPMotivacao
            blnAbortarThreadCriarTabelaMBPMotivacao = False
            blnForcarAbortarThreadCriarTabelaMBPMotivacao = False

            blnThreadAtivadaCriarTabelaMBPMotivacao = True
            blnSucessoCriarTabelaMBPMotivacao = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaMBPMotivacao As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaMBPMotivacao As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaMBPMotivacao As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaMBPMotivacao()
            mtdAbortarThreadCriarTabelaMBPMotivacao(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaMBPMotivacao(ByVal Forcar As Boolean)
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPMotivacao
            blnAbortarThreadCriarTabelaMBPMotivacao = True
            blnForcarAbortarThreadCriarTabelaMBPMotivacao = Forcar

            blnThreadAtivadaCriarTabelaMBPMotivacao = False
            blnSucessoCriarTabelaMBPMotivacao = False

            Try
                ThCriarTabelaMBPMotivacao.Join(intTempoSaidaAbortarThreadCriarTabelaMBPMotivacao)
                ThCriarTabelaMBPMotivacao.Abort()
                ThCriarTabelaMBPMotivacao = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaMBPMotivacao: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaMBPMotivacao()
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPMotivacao
            blnAbortarThreadCriarTabelaMBPMotivacao = True
            blnForcarAbortarThreadCriarTabelaMBPMotivacao = True

            blnThreadAtivadaCriarTabelaMBPMotivacao = False
            blnSucessoCriarTabelaMBPMotivacao = False
        End Sub

        Private Shared LockerCriarTabelaMBPMotivacao As New Object()

        Private Sub mtdRotinaThreadCriarTabelaMBPMotivacao()
            While Not blnForcarAbortarThreadCriarTabelaMBPMotivacao
                If Not blnAbortarThreadCriarTabelaMBPMotivacao Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaMBPMotivacao)
                    SyncLock (LockerCriarTabelaMBPMotivacao)
                        Try
                            mtdGerarTabelaMBPMotivacao()
                            mtdAbortarThreadCriarTabelaMBPMotivacao(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaMBPMotivacao)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaMBPMotivacao As Boolean = False
        Friend blnSucessoCriarTabelaMBPMotivacao As Boolean = False

        Private lngCodigoCriarTabelaMBPMotivacao As Long = 0

        Protected Friend Sub mtdGerarTabelaMBPMotivacao()
            'mtdDeletarTabelaMBPMotivacao()
            'mtdDeletarDadosTabelaMBPMotivacao()
            mtdCriarTabelaMBPMotivacao()
            mtdInserirDadosTabelaMBPMotivacao()
        End Sub

        Private intcolunaMBPMotivacao As Integer = 0

        Private camposMBPMotivacao As String()()

        Public Sub mtdDeletarTabelaMBPMotivacao()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strTabelaAuxiliaresMotivacaoPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaMBPMotivacao()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strTabelaAuxiliaresMotivacaoPrincipal, strColunaMotivacaoPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdCriarTabelaMBPMotivacao()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            Dim campos As String()() = New String(0)() {}
            campos(0) = New String(3) { _
                strColunaMotivacaoPrincipal, _
                "TEXT", _
                "255", _
                "CONSTRAINT primarykeyMotivacao PRIMARY KEY" _
            }
            objBDPrincipal.mtdCriarTabela( _
                strTabelaAuxiliaresMotivacaoPrincipal, _
                campos)

            objBDPrincipal.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaMBPMotivacao()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando( _
                String.Format( _
                    "SELECT * FROM {0};", _
                    strTabelaAuxiliaresMotivacaoPrincipal))
            objBDPrincipal.mtdDefinirLeitorDados()
            objBDPrincipal.mtdProximoRegistro()

            Dim dados As String()() = New String(7)() {}
            dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()
            dados(1) = New String(0) {"'CADASTRO'"}
            dados(2) = New String(0) {"'DEVOLUCAO'"}
            dados(3) = New String(0) {"'EMPRESTIMO'"}
            dados(4) = New String(0) {"'MANUTENCAO'"}
            dados(5) = New String(0) {"'OBSOLESCENCIA'"}
            dados(6) = New String(0) {"'TRANSFERENCIA DE UMA UND. PARA OUTRA'"}
            dados(7) = New String(0) {"'TRANSFERENCIA DENTRO DA MESMA UNIDADE'"}
            objBDPrincipal.mtdInserirDados( _
                strTabelaAuxiliaresMotivacaoPrincipal, _
                dados)

            objBDPrincipal.Dispose()
        End Sub
    End Class
End Namespace