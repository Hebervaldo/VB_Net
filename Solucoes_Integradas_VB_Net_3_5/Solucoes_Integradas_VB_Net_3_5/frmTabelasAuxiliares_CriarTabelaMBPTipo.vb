Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmTabelasAuxiliares
        Private ThCriarTabelaMBPTipo As System.Threading.Thread

        Private strNomeProcessoCriarTabelaMBPTipo As String = "Criar Tabela de Usuários"

        Friend Sub mtdIniciarThreadCriarTabelaMBPTipo()
            mtdIniciarThreadCriarTabelaMBPTipo(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaMBPTipo(ByVal Iniciar As Boolean)
            Try
                frmPrincipal.intProgresso = 0
                frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPTipo
                blnAbortarThreadCriarTabelaMBPTipo = Not Iniciar
                blnForcarAbortarThreadCriarTabelaMBPTipo = False
                blnThreadAtivadaCriarTabelaMBPTipo = True
                blnSucessoCriarTabelaMBPTipo = False
                ThCriarTabelaMBPTipo = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaMBPTipo))
                ThCriarTabelaMBPTipo.IsBackground = True
                ThCriarTabelaMBPTipo.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaMBPTipo.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaMBPTipo: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaMBPTipo()
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPTipo
            blnAbortarThreadCriarTabelaMBPTipo = False
            blnForcarAbortarThreadCriarTabelaMBPTipo = False

            blnThreadAtivadaCriarTabelaMBPTipo = True
            blnSucessoCriarTabelaMBPTipo = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaMBPTipo As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaMBPTipo As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaMBPTipo As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaMBPTipo()
            mtdAbortarThreadCriarTabelaMBPTipo(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaMBPTipo(ByVal Forcar As Boolean)
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPTipo
            blnAbortarThreadCriarTabelaMBPTipo = True
            blnForcarAbortarThreadCriarTabelaMBPTipo = Forcar

            blnThreadAtivadaCriarTabelaMBPTipo = False
            blnSucessoCriarTabelaMBPTipo = False

            Try
                ThCriarTabelaMBPTipo.Join(intTempoSaidaAbortarThreadCriarTabelaMBPTipo)
                ThCriarTabelaMBPTipo.Abort()
                ThCriarTabelaMBPTipo = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaMBPTipo: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaMBPTipo()
            frmPrincipal.intProgresso = 100
            System.Threading.Thread.Sleep(1)
            frmPrincipal.intProgresso = 0
            frmPrincipal.strNomeProcesso = strNomeProcessoCriarTabelaMBPTipo
            blnAbortarThreadCriarTabelaMBPTipo = True
            blnForcarAbortarThreadCriarTabelaMBPTipo = True

            blnThreadAtivadaCriarTabelaMBPTipo = False
            blnSucessoCriarTabelaMBPTipo = False
        End Sub

        Private Shared LockerCriarTabelaMBPTipo As New Object()

        Private Sub mtdRotinaThreadCriarTabelaMBPTipo()
            While Not blnForcarAbortarThreadCriarTabelaMBPTipo
                If Not blnAbortarThreadCriarTabelaMBPTipo Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaMBPTipo)
                    SyncLock (LockerCriarTabelaMBPTipo)
                        Try
                            mtdGerarTabelaMBPTipo()
                            mtdAbortarThreadCriarTabelaMBPTipo(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaMBPTipo)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaMBPTipo As Boolean = False
        Friend blnSucessoCriarTabelaMBPTipo As Boolean = False

        Private lngCodigoCriarTabelaMBPTipo As Long = 0

        Protected Friend Sub mtdGerarTabelaMBPTipo()
            'mtdDeletarTabelaMBPTipo()
            'mtdDeletarDadosTabelaMBPTipo()
            mtdCriarTabelaMBPTipo()
            mtdInserirDadosTabelaMBPTipo()
        End Sub

        Public Sub mtdDeletarTabelaMBPTipo()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strTabelaAuxiliaresTipoPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaMBPTipo()
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strTabelaAuxiliaresTipoPrincipal, strColunaTipoPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdCriarTabelaMBPTipo()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            Dim campos As String()() = New String(0)() {}
            campos(0) = New String(3) { _
                strColunaTipoPrincipal, _
                "TEXT", _
                "255", _
                "CONSTRAINT primarykeyTipo PRIMARY KEY"}
            objBDPrincipal.mtdCriarTabela( _
                strTabelaAuxiliaresTipoPrincipal, _
                campos)
            objBDPrincipal.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaMBPTipo()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando(String.Format( _
                                                   "SELECT * FROM {0};", _
                                                   strTabelaAuxiliaresTipoPrincipal))
            objBDPrincipal.mtdDefinirLeitorDados()
            objBDPrincipal.mtdProximoRegistro()

            Dim dados As String()() = New String(2)() {}
            dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()
            dados(1) = New String(0) {"'INTERNA'"}
            dados(2) = New String(0) {"'EXTERNA'"}
            objBDPrincipal.mtdInserirDados( _
                strTabelaAuxiliaresTipoPrincipal, _
                dados)
            objBDPrincipal.Dispose()
        End Sub
    End Class
End Namespace