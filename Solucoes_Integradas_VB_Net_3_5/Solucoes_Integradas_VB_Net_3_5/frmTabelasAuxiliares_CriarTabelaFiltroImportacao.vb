Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmTabelasAuxiliares
        Private ThCriarTabelaFiltroImportacao As System.Threading.Thread

        Private strNomeProcessoCriarTabelaFiltroImportacao As String = "Criar Tabela de Usuários"

        Friend Sub mtdIniciarThreadCriarTabelaFiltroImportacao()
            mtdIniciarThreadCriarTabelaFiltroImportacao(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaFiltroImportacao(ByVal Iniciar As Boolean)
            Try
                frmPrincipal.intProgresso = 0
                frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaFiltroImportacao
                blnAbortarThreadCriarTabelaFiltroImportacao = Not Iniciar
                blnForcarAbortarThreadCriarTabelaFiltroImportacao = False
                blnThreadAtivadaCriarTabelaFiltroImportacao = True
                blnSucessoCriarTabelaFiltroImportacao = False
                ThCriarTabelaFiltroImportacao = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaFiltroImportacao))
                ThCriarTabelaFiltroImportacao.IsBackground = True
                ThCriarTabelaFiltroImportacao.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaFiltroImportacao.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaFiltroImportacao: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaFiltroImportacao()
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaFiltroImportacao
            blnAbortarThreadCriarTabelaFiltroImportacao = False
            blnForcarAbortarThreadCriarTabelaFiltroImportacao = False

            blnThreadAtivadaCriarTabelaFiltroImportacao = True
            blnSucessoCriarTabelaFiltroImportacao = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaFiltroImportacao As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaFiltroImportacao As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaFiltroImportacao As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaFiltroImportacao()
            mtdAbortarThreadCriarTabelaFiltroImportacao(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaFiltroImportacao(ByVal Forcar As Boolean)
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaFiltroImportacao
            blnAbortarThreadCriarTabelaFiltroImportacao = True
            blnForcarAbortarThreadCriarTabelaFiltroImportacao = Forcar

            blnThreadAtivadaCriarTabelaFiltroImportacao = False
            blnSucessoCriarTabelaFiltroImportacao = False

            Try
                ThCriarTabelaFiltroImportacao.Join(intTempoSaidaAbortarThreadCriarTabelaFiltroImportacao)
                ThCriarTabelaFiltroImportacao.Abort()
                ThCriarTabelaFiltroImportacao = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaFiltroImportacao: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaFiltroImportacao()
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaFiltroImportacao
            blnAbortarThreadCriarTabelaFiltroImportacao = True
            blnForcarAbortarThreadCriarTabelaFiltroImportacao = True

            blnThreadAtivadaCriarTabelaFiltroImportacao = False
            blnSucessoCriarTabelaFiltroImportacao = False
        End Sub

        Private Shared LockerCriarTabelaFiltroImportacao As New Object()

        Private Sub mtdRotinaThreadCriarTabelaFiltroImportacao()
            While Not blnForcarAbortarThreadCriarTabelaFiltroImportacao
                If Not blnAbortarThreadCriarTabelaFiltroImportacao Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaFiltroImportacao)
                    SyncLock (LockerCriarTabelaFiltroImportacao)
                        Try
                            mtdGerarTabelaFiltroImportacao()
                            mtdAbortarThreadCriarTabelaFiltroImportacao(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaFiltroImportacao)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaFiltroImportacao As Boolean = False
        Friend blnSucessoCriarTabelaFiltroImportacao As Boolean = False

        Private lngCodigoCriarTabelaFiltroImportacao As Long = 0

        Protected Friend Sub mtdGerarTabelaFiltroImportacao()
            'mtdDeletarTabelaFiltroImportacao()
            'mtdDeletarDadosTabelaFiltroImportacao()
            mtdCriarTabelaFiltroImportacao()
            'mtdInserirDadosTabelaFiltroImportacao()
        End Sub

        Private intcolunaFiltroImportacao As Integer = 0

        Private camposFiltroImportacao As String()()

        Public Sub mtdDeletarTabelaFiltroImportacao()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strTabelaAuxiliaresFiltroImportacaoPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaFiltroImportacao()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strTabelaAuxiliaresFiltroImportacaoPrincipal, strColunaFiltroImportacaoPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdCriarTabelaFiltroImportacao()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            Dim campos As String()() = New String(0)() {}
            campos(0) = New String(3) { _
                strColunaFiltroImportacaoPrincipal, _
                "TEXT", _
                "255", _
                "CONSTRAINT primarykeyFiltroImportacao PRIMARY KEY" _
            }
            objBDPrincipal.mtdCriarTabela( _
                strTabelaAuxiliaresFiltroImportacaoPrincipal, _
                campos)

            objBDPrincipal.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaFiltroImportacao()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando( _
                String.Format("SELECT * FROM {0};", _
                              strTabelaAuxiliaresFiltroImportacaoPrincipal))
            objBDPrincipal.mtdDefinirLeitorDados()
            objBDPrincipal.mtdProximoRegistro()

            Dim dados As String()() = New String(1)() {}
            dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()
            dados(1) = New String(0) {"'|4000'"}
            dados(2) = New String(0) {"'|5000'"}
            dados(3) = New String(0) {"'|6000'"}
            objBDPrincipal.mtdInserirDados( _
                strTabelaAuxiliaresFiltroImportacaoPrincipal, _
                dados)

            objBDPrincipal.Dispose()
        End Sub
    End Class
End Namespace