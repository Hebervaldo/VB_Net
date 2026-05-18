Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmTabelasAuxiliares
        Private ThCriarTabelaMBPPropriedade As System.Threading.Thread

        Private strNomeProcessoCriarTabelaMBPPropriedade As String = "Criar Tabela de Usuários"

        Friend Sub mtdIniciarThreadCriarTabelaMBPPropriedade()
            mtdIniciarThreadCriarTabelaMBPPropriedade(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaMBPPropriedade(ByVal Iniciar As Boolean)
            Try
                frmPrincipal.intProgresso = 0
                frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPPropriedade
                blnAbortarThreadCriarTabelaMBPPropriedade = Not Iniciar
                blnForcarAbortarThreadCriarTabelaMBPPropriedade = False
                blnThreadAtivadaCriarTabelaMBPPropriedade = True
                blnSucessoCriarTabelaMBPPropriedade = False
                ThCriarTabelaMBPPropriedade = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaMBPPropriedade))
                ThCriarTabelaMBPPropriedade.IsBackground = True
                ThCriarTabelaMBPPropriedade.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaMBPPropriedade.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaMBPPropriedade: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaMBPPropriedade()
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPPropriedade
            blnAbortarThreadCriarTabelaMBPPropriedade = False
            blnForcarAbortarThreadCriarTabelaMBPPropriedade = False

            blnThreadAtivadaCriarTabelaMBPPropriedade = True
            blnSucessoCriarTabelaMBPPropriedade = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaMBPPropriedade As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaMBPPropriedade As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaMBPPropriedade As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaMBPPropriedade()
            mtdAbortarThreadCriarTabelaMBPPropriedade(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaMBPPropriedade(ByVal Forcar As Boolean)
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPPropriedade
            blnAbortarThreadCriarTabelaMBPPropriedade = True
            blnForcarAbortarThreadCriarTabelaMBPPropriedade = Forcar

            blnThreadAtivadaCriarTabelaMBPPropriedade = False
            blnSucessoCriarTabelaMBPPropriedade = False

            Try
                ThCriarTabelaMBPPropriedade.Join(intTempoSaidaAbortarThreadCriarTabelaMBPPropriedade)
                ThCriarTabelaMBPPropriedade.Abort()
                ThCriarTabelaMBPPropriedade = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaMBPPropriedade: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaMBPPropriedade()
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPPropriedade
            blnAbortarThreadCriarTabelaMBPPropriedade = True
            blnForcarAbortarThreadCriarTabelaMBPPropriedade = True

            blnThreadAtivadaCriarTabelaMBPPropriedade = False
            blnSucessoCriarTabelaMBPPropriedade = False
        End Sub

        Private Shared LockerCriarTabelaMBPPropriedade As New Object()

        Private Sub mtdRotinaThreadCriarTabelaMBPPropriedade()
            While Not blnForcarAbortarThreadCriarTabelaMBPPropriedade
                If Not blnAbortarThreadCriarTabelaMBPPropriedade Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaMBPPropriedade)
                    SyncLock (LockerCriarTabelaMBPPropriedade)
                        Try
                            mtdGerarTabelaMBPPropriedade()
                            mtdAbortarThreadCriarTabelaMBPPropriedade(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaMBPPropriedade)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaMBPPropriedade As Boolean = False
        Friend blnSucessoCriarTabelaMBPPropriedade As Boolean = False

        Private lngCodigoCriarTabelaMBPPropriedade As Long = 0

        Protected Friend Sub mtdGerarTabelaMBPPropriedade()
            'mtdDeletarTabelaMBPPropriedade()
            'mtdDeletarDadosTabelaMBPPropriedade()
            mtdCriarTabelaMBPPropriedade()
            mtdInserirDadosTabelaMBPPropriedade()
        End Sub

        Private intcolunaMBPPropriedade As Integer = 0

        Private camposMBPPropriedade As String()()

        Public Sub mtdDeletarTabelaMBPPropriedade()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strTabelaAuxiliaresPropriedadePrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaMBPPropriedade()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strTabelaAuxiliaresPropriedadePrincipal, strColunaPropriedadePrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdCriarTabelaMBPPropriedade()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            Dim campos As String()() = New String(0)() {}
            campos(0) = New String(3) { _
                strColunaPropriedadePrincipal, _
                "TEXT", _
                "255", _
                "CONSTRAINT primarykeyPropriedade PRIMARY KEY" _
            }
            objBDPrincipal.mtdCriarTabela( _
                strTabelaAuxiliaresPropriedadePrincipal, _
                campos)
            objBDPrincipal.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaMBPPropriedade()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando( _
                String.Format( _
                    "SELECT * FROM {0};", _
                    strTabelaAuxiliaresPropriedadePrincipal))
            objBDPrincipal.mtdDefinirLeitorDados()
            objBDPrincipal.mtdProximoRegistro()

            Dim dados As String()() = New String(2)() {}
            dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()
            dados(1) = New String(0) {"'ELETRONORTE'"}
            dados(2) = New String(0) {"'TERCEIROS'"}
            objBDPrincipal.mtdInserirDados( _
                strTabelaAuxiliaresPropriedadePrincipal, _
                dados)
            objBDPrincipal.Dispose()
        End Sub
    End Class
End Namespace