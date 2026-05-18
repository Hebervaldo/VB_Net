Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmCentroCusto
        Private ThImportarTabelaCentroCustoPrincipal As System.Threading.Thread

        Private strNomeProcessoImportarTabelaCentroCustoPrincipal As String = "Importar Tabela de Centro de Custo - Principal"

        Friend Sub mtdIniciarThreadImportarTabelaCentroCustoPrincipal()
            mtdIniciarThreadImportarTabelaCentroCustoPrincipal(True)
        End Sub

        Friend Sub mtdIniciarThreadImportarTabelaCentroCustoPrincipal(ByVal Iniciar As Boolean)
            Try
                [NewValue] = 0
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoPrincipal
                blnAbortarThreadImportarTabelaCentroCustoPrincipal = Not Iniciar
                blnForcarAbortarThreadImportarTabelaCentroCustoPrincipal = False
                blnThreadAtivadaImportarTabelaCentroCustoPrincipal = True
                blnSucessoImportarTabelaCentroCustoPrincipal = False
                ThImportarTabelaCentroCustoPrincipal = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImportarTabelaCentroCustoPrincipal))
                ThImportarTabelaCentroCustoPrincipal.IsBackground = True
                ThImportarTabelaCentroCustoPrincipal.Priority = System.Threading.ThreadPriority.Normal
                ThImportarTabelaCentroCustoPrincipal.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImportarTabelaCentroCustoPrincipal: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImportarTabelaCentroCustoPrincipal()
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoPrincipal
            blnAbortarThreadImportarTabelaCentroCustoPrincipal = False
            blnForcarAbortarThreadImportarTabelaCentroCustoPrincipal = False

            blnThreadAtivadaImportarTabelaCentroCustoPrincipal = True
            blnSucessoImportarTabelaCentroCustoPrincipal = False
        End Sub

        Private Shared blnForcarAbortarThreadImportarTabelaCentroCustoPrincipal As Boolean = False
        Private Shared blnAbortarThreadImportarTabelaCentroCustoPrincipal As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImportarTabelaCentroCustoPrincipal As Integer = 1000

        Friend Sub mtdAbortarThreadImportarTabelaCentroCustoPrincipal()
            mtdAbortarThreadImportarTabelaCentroCustoPrincipal(False)
        End Sub

        Friend Sub mtdAbortarThreadImportarTabelaCentroCustoPrincipal(ByVal Forcar As Boolean)
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoPrincipal
            blnAbortarThreadImportarTabelaCentroCustoPrincipal = True
            blnForcarAbortarThreadImportarTabelaCentroCustoPrincipal = Forcar

            blnThreadAtivadaImportarTabelaCentroCustoPrincipal = False
            blnSucessoImportarTabelaCentroCustoPrincipal = False

            Try
                ThImportarTabelaCentroCustoPrincipal.Join(intTempoSaidaAbortarThreadImportarTabelaCentroCustoPrincipal)
                ThImportarTabelaCentroCustoPrincipal.Abort()
                ThImportarTabelaCentroCustoPrincipal = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImportarTabelaCentroCustoPrincipal: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImportarTabelaCentroCustoPrincipal()
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoPrincipal
            blnAbortarThreadImportarTabelaCentroCustoPrincipal = True
            blnForcarAbortarThreadImportarTabelaCentroCustoPrincipal = True

            blnThreadAtivadaImportarTabelaCentroCustoPrincipal = False
            blnSucessoImportarTabelaCentroCustoPrincipal = False
        End Sub

        Private Shared LockerImportarTabelaCentroCustoPrincipal As New Object()

        Private Sub mtdRotinaThreadImportarTabelaCentroCustoPrincipal()
            While Not blnForcarAbortarThreadImportarTabelaCentroCustoPrincipal
                If Not blnAbortarThreadImportarTabelaCentroCustoPrincipal Then
                    'System.Threading.Monitor.Enter(LockerImportarTabelaCentroCustoPrincipal)
                    SyncLock (LockerImportarTabelaCentroCustoPrincipal)
                        Try
                            mtdImportarTabelaCentroCustoPrincipal _
                            ( _
                            blnComandoImplementadoDeletarDadosTabelaCentroCustoPrincipal, _
                            blnComandoImplementadoInserirDadosTabelaCentroCustoPrincipal _
                            )
                            mtdAbortarThreadImportarTabelaCentroCustoPrincipal(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImportarTabelaCentroCustoPrincipal)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImportarTabelaCentroCustoPrincipal As Boolean = False
        Friend blnSucessoImportarTabelaCentroCustoPrincipal As Boolean = False

        Private lngCodigoImportarTabelaCentroCustoPrincipal As Long = 0

        Protected Friend Sub mtdImportarTabelaCentroCustoPrincipal()
            mtdImportarTabelaCentroCustoPrincipal(True, True)
        End Sub

        Protected Friend Sub mtdImportarTabelaCentroCustoPrincipal(ByVal Deletar As Boolean, ByVal Inserir As Boolean)
            blnComandoImplementadoDeletarDadosTabelaCentroCustoPrincipal = Deletar
            blnComandoImplementadoInserirDadosTabelaCentroCustoPrincipal = Inserir

            If Deletar Then
                mtdDeletarTabelaCentroCustoPrincipal()
                mtdDeletarDadosTabelaCentroCustoPrincipal()
            End If

            mtdCriarTabelaCentroCustoPrincipal()

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
            strConexaoBancoDadosPrincipal, _
            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdSelecionarDados("*", strTabelaBensEletronorte)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()

            If Not objImplementacaoBancoDados.mtdProximoRegistro() Then
                'Dim objBens As frmBens = New frmBens()
                'objBens.mtdIniciarThreadProgresso(False)
                'objBens.mtdIniciarThreadImportarTabelaBensEletronortePrincipal()
                If blnComandoImplementadoPermitirMensagemTabelaCentroCustoPrincipal Then
                    System.Windows.Forms.MessageBox.Show( _
                        "Certifique-se de que exista a tabela de bens, pois a geração da tabela de centro de custo depende daquela.", _
                        "Aviso!", _
                        MessageBoxButtons.OK)
                End If
            Else
                If Inserir Then
                    mtdInserirDadosTabelaCentroCustoPrincipal()
                End If
            End If
            objImplementacaoBancoDados.Dispose()
        End Sub

        Private colPrincipal As Integer = 1
        Private linPrincipal As Integer = 0
        Private intcolunaPrincipal As Integer = 0
        Private intlinhaPrincipal As Integer = 0

        Private intNumeroColunasPrincipal As Integer = 0
        Private intNumeroLinhasPrincipal As Integer = 0
        Private vetTipoColunasPrincipal As String()
        Private camposPrincipal As String()()
        Private vetLinhaTextoPrincipal As String()()

        Public blnComandoImplementadoDeletarDadosTabelaCentroCustoPrincipal As Boolean = True

        Public Sub mtdDeletarTabelaCentroCustoPrincipal()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdDeletarTabela(strNomeTabelaPrincipal)
            objBDPrincipal.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaCentroCustoPrincipal()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdDeletarDados(strNomeTabelaPrincipal, strColunaPrincipal, "LIKE", "'%'")
            objBDPrincipal.Dispose()
        End Sub

        Public blnComandoImplementadoPermitirMensagemTabelaCentroCustoPrincipal As Boolean = True

        Public Sub mtdCriarTabelaCentroCustoPrincipal()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                       strConexaoBancoDadosPrincipal, _
                                                                       clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            intcolunaPrincipal = 2

            camposPrincipal = New String(intcolunaPrincipal)() {}
            camposPrincipal(0) = New String(3) {"CentroCusto", "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyCentroCusto PRIMARY KEY"}
            camposPrincipal(1) = New String(3) {"Orgao", "TEXT", "255", String.Empty}
            camposPrincipal(2) = New String(3) {"OrgaoDescricao", "TEXT", "255", String.Empty}

            objBDPrincipal.mtdCriarTabela(strNomeTabelaPrincipal, camposPrincipal)
            objBDPrincipal.Dispose()
        End Sub

        Public blnComandoImplementadoInserirDadosTabelaCentroCustoPrincipal As Boolean = True

        Public Sub mtdInserirDadosTabelaCentroCustoPrincipal()
            Try
                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                           strConexaoBancoDadosPrincipal, _
                                                                           clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
                                                                           )

                Dim objBDPrincipalI As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                           strConexaoBancoDadosPrincipal, _
                                                                           clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
                                                                           )

                Dim dados As String()() = New String(1)() {}
                dados(0) = New String(intcolunaPrincipal) {}

                For contador As Integer = 0 To intcolunaPrincipal Step 1
                    dados(0)(contador) = camposPrincipal(contador)(0)
                Next

                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoPrincipal
                blnSucessoImportarTabelaCentroCustoPrincipal = True

                objBDPrincipal.mtdAbrirConexao()
                objBDPrincipal.mtdExecutarComando(String.Format("SELECT DISTINCT {0} FROM {1}", _
                                                                          "Centro_Custo, Orgao", _
                                                                          strTabelaBensEletronorte))
                intNumeroLinhasPrincipal = objBDPrincipal.mtdNumeroLinhas()
                objBDPrincipal.mtdDefinirLeitorDados()
                intNumeroColunasPrincipal = objBDPrincipal.mtdNumeroColunas()
                objBDPrincipal.mtdProximoRegistro()
                vetTipoColunasPrincipal = objBDPrincipal.mtdObterTipoRegistro()

                Dim dadosI As String() = New String(intcolunaPrincipal - 1) {}

                For linha As Integer = 0 To intNumeroLinhasPrincipal Step 1
                    If blnAbortarThreadImportarTabelaCentroCustoPrincipal And blnForcarAbortarThreadImportarTabelaCentroCustoPrincipal Then
                        GoTo SaidaInserirDadosTabelaCentroCustoPrincipal
                    End If

                    'dados(linha) = New String(intNumeroColunasPrincipal) {}
                    For coluna As Integer = 0 To intcolunaPrincipal - 1 Step 1
                        Dim strFormatoRegistro As String = mtdObterFormatoTipo(vetTipoColunasPrincipal(coluna))
                        Dim strValorRegistro As String = objManipuladorTexto.mtdExecutarTudo( _
                            If((objBDPrincipal.mtdObterValorRegistro(coluna) IsNot Nothing), _
                               objBDPrincipal.mtdObterValorRegistro(coluna).ToString(), String.Empty))

                        dadosI(coluna) = String.Format(strFormatoRegistro, strValorRegistro)
                    Next
                    dados(1) = New String(intcolunaPrincipal) {}

                    For coluna As Integer = 0 To intNumeroColunasPrincipal Step 1
                        Select Case coluna
                            Case 0
                                dados(1)(coluna) = dadosI(0)
                            Case 1
                                dados(1)(coluna) = String.Format("'{0}'", dadosI(1).Split(" "c)(0).Replace("'"c, ""))
                            Case 2
                                dados(1)(coluna) = dadosI(1)
                        End Select
                    Next
                    objBDPrincipalI.mtdInserirDados(strNomeTabelaPrincipal, dados)
                    objBDPrincipal.mtdProximoRegistro()
                    [NewValue] = Convert.ToInt32((linha / intNumeroLinhasPrincipal) * 100)
                    Try
                        Me.BeginInvoke(f, New Object() {[NewValue]})
                    Catch ex As Exception
                    End Try
                    frmPrincipal.intProgresso = [NewValue]
                    frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoPrincipal
                    blnSucessoImportarTabelaCentroCustoPrincipal = True
                    System.Threading.Thread.Sleep(1)
                Next
SaidaInserirDadosTabelaCentroCustoPrincipal:
                [NewValue] = 100
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoPrincipal
                blnSucessoImportarTabelaCentroCustoPrincipal = True
                objBDPrincipal.Dispose()
                objBDPrincipalI.Dispose()
                If blnComandoImplementadoPermitirMensagemTabelaCentroCustoPrincipal Then
                    System.Windows.Forms.MessageBox.Show("A importação dos dados finalizou com sucesso.", "Aviso!", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, _
                                                         MessageBoxOptions.DefaultDesktopOnly)
                End If
            Catch
                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoPrincipal
                blnSucessoImportarTabelaCentroCustoPrincipal = False
            End Try
        End Sub
    End Class
End Namespace