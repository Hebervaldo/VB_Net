Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmTabelasAuxiliares
        Private ThCriarTabelaTermoResponsabilidadeGeral As System.Threading.Thread

        Private strNomeProcessoCriarTabelaTermoResponsabilidadeGeral As String = "Criar Tabela de Usuários"

        Friend Sub mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral()
            mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral(ByVal Iniciar As Boolean)
            Try
                frmPrincipal.intProgresso = 0
                frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaTermoResponsabilidadeGeral
                blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral = Not Iniciar
                blnForcarAbortarThreadCriarTabelaTermoResponsabilidadeGeral = False
                blnThreadAtivadaCriarTabelaTermoResponsabilidadeGeral = True
                blnSucessoCriarTabelaTermoResponsabilidadeGeral = False
                ThCriarTabelaTermoResponsabilidadeGeral = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaTermoResponsabilidadeGeral))
                ThCriarTabelaTermoResponsabilidadeGeral.IsBackground = True
                ThCriarTabelaTermoResponsabilidadeGeral.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaTermoResponsabilidadeGeral.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaTermoResponsabilidadeGeral()
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaTermoResponsabilidadeGeral
            blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral = False
            blnForcarAbortarThreadCriarTabelaTermoResponsabilidadeGeral = False

            blnThreadAtivadaCriarTabelaTermoResponsabilidadeGeral = True
            blnSucessoCriarTabelaTermoResponsabilidadeGeral = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaTermoResponsabilidadeGeral As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaTermoResponsabilidadeGeral As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaTermoResponsabilidadeGeral()
            mtdAbortarThreadCriarTabelaTermoResponsabilidadeGeral(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaTermoResponsabilidadeGeral(ByVal Forcar As Boolean)
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaTermoResponsabilidadeGeral
            blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral = True
            blnForcarAbortarThreadCriarTabelaTermoResponsabilidadeGeral = Forcar

            blnThreadAtivadaCriarTabelaTermoResponsabilidadeGeral = False
            blnSucessoCriarTabelaTermoResponsabilidadeGeral = False

            Try
                ThCriarTabelaTermoResponsabilidadeGeral.Join(intTempoSaidaAbortarThreadCriarTabelaTermoResponsabilidadeGeral)
                ThCriarTabelaTermoResponsabilidadeGeral.Abort()
                ThCriarTabelaTermoResponsabilidadeGeral = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaTermoResponsabilidadeGeral: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaTermoResponsabilidadeGeral()
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaTermoResponsabilidadeGeral
            blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral = True
            blnForcarAbortarThreadCriarTabelaTermoResponsabilidadeGeral = True

            blnThreadAtivadaCriarTabelaTermoResponsabilidadeGeral = False
            blnSucessoCriarTabelaTermoResponsabilidadeGeral = False
        End Sub

        Private Shared LockerCriarTabelaTermoResponsabilidadeGeral As New Object()

        Private Sub mtdRotinaThreadCriarTabelaTermoResponsabilidadeGeral()
            While Not blnForcarAbortarThreadCriarTabelaTermoResponsabilidadeGeral
                If Not blnAbortarThreadCriarTabelaTermoResponsabilidadeGeral Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaTermoResponsabilidadeGeral)
                    SyncLock (LockerCriarTabelaTermoResponsabilidadeGeral)
                        Try
                            mtdGerarTabelaTermoResponsabilidadeGeral()
                            mtdAbortarThreadCriarTabelaTermoResponsabilidadeGeral(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaTermoResponsabilidadeGeral)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaTermoResponsabilidadeGeral As Boolean = False
        Friend blnSucessoCriarTabelaTermoResponsabilidadeGeral As Boolean = False

        Private lngCodigoCriarTabelaTermoResponsabilidadeGeral As Long = 0

        Protected Friend Sub mtdGerarTabelaTermoResponsabilidadeGeral()
            'mtdDeletarTabelaTermoResponsabilidadeGeral()
            'mtdDeletarDadosTabelaTermoResponsabilidadeGeral()
            mtdCriarTabelaTermoResponsabilidadeGeral()
            'mtdInserirDadosTabelaTermoResponsabilidadeGeral()
        End Sub

        Private intcolunaTermoResponsabilidadeGeral As Integer = 0

        Private camposTermoResponsabilidadeGeral As String()()

        Public Sub mtdDeletarTabelaTermoResponsabilidadeGeral()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaTermoResponsabilidadeGeral()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal, strColunaTermoResponsabilidadeGeralPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdCriarTabelaTermoResponsabilidadeGeral()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            Dim campos As String()() = New String(0)() {}
            campos(0) = New String(3) { _
            strColunaTermoResponsabilidadeGeralPrincipal, _
            "TEXT", _
            "255", _
            "CONSTRAINT primarykeyTermoResponsabilidadeGeral PRIMARY KEY" _
            }
            objBDPrincipal.mtdCriarTabela( _
                strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal, _
                campos)
            objBDPrincipal.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaTermoResponsabilidadeGeral()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando( _
                String.Format("SELECT * FROM {0};", _
                              strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal))
            objBDPrincipal.mtdDefinirLeitorDados()
            objBDPrincipal.mtdProximoRegistro()

            Dim dados As String()() = New String(1)() {}
            dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()
            dados(1) = New String(0) { _
            objRegistroWindows.mtdObterDadosRegistro( _
                Microsoft.Win32.Registry.CurrentUser, _
                "Software", _
                "Eletronorte", _
                "Eletronorte - Soluções Integradas", _
                "Numero_TRG").ToString() _
            }
            objBDPrincipal.mtdInserirDados( _
                strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal, _
                dados)

            objBDPrincipal.Dispose()
        End Sub
    End Class
End Namespace