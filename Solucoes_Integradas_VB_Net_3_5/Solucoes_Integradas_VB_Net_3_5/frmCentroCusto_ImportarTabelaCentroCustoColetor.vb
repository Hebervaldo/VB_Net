Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmCentroCusto
        Private ThImportarTabelaCentroCustoColetor As System.Threading.Thread

        Private strNomeProcessoImportarTabelaCentroCustoColetor As String = "Importar Tabela de Centro de Custo - Coletor"

        Friend Sub mtdIniciarThreadImportarTabelaCentroCustoColetor()
            mtdIniciarThreadImportarTabelaCentroCustoColetor(True)
        End Sub

        Friend Sub mtdIniciarThreadImportarTabelaCentroCustoColetor(ByVal Iniciar As Boolean)
            Try
                [NewValue] = 0
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoColetor
                blnAbortarThreadImportarTabelaCentroCustoColetor = Not Iniciar
                blnForcarAbortarThreadImportarTabelaCentroCustoColetor = False
                blnThreadAtivadaImportarTabelaCentroCustoColetor = True
                blnSucessoImportarTabelaCentroCustoColetor = False
                ThImportarTabelaCentroCustoColetor = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImportarTabelaCentroCustoColetor))
                ThImportarTabelaCentroCustoColetor.IsBackground = True
                ThImportarTabelaCentroCustoColetor.Priority = System.Threading.ThreadPriority.Normal
                ThImportarTabelaCentroCustoColetor.Start()
            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImportarTabelaCentroCustoColetor: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImportarTabelaCentroCustoColetor()
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoColetor
            blnAbortarThreadImportarTabelaCentroCustoColetor = False
            blnForcarAbortarThreadImportarTabelaCentroCustoColetor = False

            blnThreadAtivadaImportarTabelaCentroCustoColetor = True
            blnSucessoImportarTabelaCentroCustoColetor = False
        End Sub

        Private Shared blnForcarAbortarThreadImportarTabelaCentroCustoColetor As Boolean = False
        Private Shared blnAbortarThreadImportarTabelaCentroCustoColetor As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImportarTabelaCentroCustoColetor As Integer = 1000

        Friend Sub mtdAbortarThreadImportarTabelaCentroCustoColetor()
            mtdAbortarThreadImportarTabelaCentroCustoColetor(False)
        End Sub

        Friend Sub mtdAbortarThreadImportarTabelaCentroCustoColetor(ByVal Forcar As Boolean)
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoColetor
            blnAbortarThreadImportarTabelaCentroCustoColetor = True
            blnForcarAbortarThreadImportarTabelaCentroCustoColetor = Forcar

            blnThreadAtivadaImportarTabelaCentroCustoColetor = False
            blnSucessoImportarTabelaCentroCustoColetor = False

            Try
                ThImportarTabelaCentroCustoColetor.Join(intTempoSaidaAbortarThreadImportarTabelaCentroCustoColetor)
                ThImportarTabelaCentroCustoColetor.Abort()
                ThImportarTabelaCentroCustoColetor = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImportarTabelaCentroCustoColetor: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImportarTabelaCentroCustoColetor()
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoColetor
            blnAbortarThreadImportarTabelaCentroCustoColetor = True
            blnForcarAbortarThreadImportarTabelaCentroCustoColetor = True

            blnThreadAtivadaImportarTabelaCentroCustoColetor = False
            blnSucessoImportarTabelaCentroCustoColetor = False
        End Sub

        Private Shared LockerImportarTabelaCentroCustoColetor As New Object()

        Private Sub mtdRotinaThreadImportarTabelaCentroCustoColetor()
            While Not blnForcarAbortarThreadImportarTabelaCentroCustoColetor
                If Not blnAbortarThreadImportarTabelaCentroCustoColetor Then
                    'System.Threading.Monitor.Enter(LockerImportarTabelaCentroCustoColetor)
                    SyncLock (LockerImportarTabelaCentroCustoColetor)
                        Try
                            mtdImportarTabelaCentroCustoColetor _
                            ( _
                            blnComandoImplementadoDeletarDadosTabelaCentroCustoColetor, _
                            blnComandoImplementadoInserirDadosTabelaCentroCustoColetor _
                            )
                            mtdAbortarThreadImportarTabelaCentroCustoColetor(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImportarTabelaCentroCustoColetor)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImportarTabelaCentroCustoColetor As Boolean = False
        Friend blnSucessoImportarTabelaCentroCustoColetor As Boolean = False

        Private lngCodigoImportarTabelaCentroCustoColetor As Long = 0

        Protected Friend Sub mtdImportarTabelaCentroCustoColetor()
            mtdImportarTabelaCentroCustoColetor(True, True)
        End Sub

        Protected Friend Sub mtdImportarTabelaCentroCustoColetor(ByVal Deletar As Boolean, ByVal Inserir As Boolean)
            'Dim isWatching As Boolean = frmPrincipal.m_bIsWatching

            'If isWatching Then
            '    frmPrincipal.mtdMonitorarDiretorioArquivo()
            'End If

            blnComandoImplementadoDeletarDadosTabelaCentroCustoColetor = Deletar
            blnComandoImplementadoInserirDadosTabelaCentroCustoColetor = Inserir

            If Deletar Then
                mtdDeletarTabelaCentroCustoColetor()
                mtdDeletarDadosTabelaCentroCustoColetor()
            End If
            mtdCriarBancoDadosColetor()

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                      strConexaoBancoDadosColetor, _
                                                      clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE _
                                                      )

            objImplementacaoBancoDados.mtdSelecionarDados("*", strTabelaBensEletronorte)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()

            If Not objImplementacaoBancoDados.mtdProximoRegistro() Then
                'Dim objBens As frmBens = New frmBens()
                'objBens.mtdIniciarThreadProgresso(False)
                'objBens.mtdIniciarThreadImportarTabelaBensEletronorteColetor()
                If blnComandoImplementadoPermitirMensagemTabelaCentroCustoColetor Then
                    System.Windows.Forms.MessageBox.Show( _
                        "Certifique-se de que exista a tabela de bens, pois a geração da tabela de centro de custo depende daquela.", _
                        "Aviso!", _
                        MessageBoxButtons.OK)
                End If
            Else
                mtdCriarTabelaCentroCustoColetor()
                If Inserir Then
                    mtdInserirDadosTabelaCentroCustoColetor()
                End If
            End If

            'If Not isWatching Then
            '    frmPrincipal.mtdMonitorarDiretorioArquivo()
            'End If
            objImplementacaoBancoDados.Dispose()
        End Sub

        Private colColetor As Integer = 1
        Private linColetor As Integer = 0
        Private intcolunaColetor As Integer = 0
        Private intlinhaColetor As Integer = 0

        Private intNumeroColunasColetor As Integer = 0
        Private intNumeroLinhasColetor As Integer = 0
        Private vetTipoColunasColetor As String()
        Private camposColetor As String()()
        Private vetLinhaTextoColetor As String()()

        Public blnComandoImplementadoDeletarDadosTabelaCentroCustoColetor As Boolean = True

        Public Sub mtdDeletarTabelaCentroCustoColetor()
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                         strConexaoBancoDadosColetor, _
                                                                         clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE _
                                                                         )

            objBDColetor.mtdDeletarTabela(strNomeTabelaColetor)
            objBDColetor.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaCentroCustoColetor()
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                         strConexaoBancoDadosColetor, _
                                                                         clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE _
                                                                         )

            objBDColetor.mtdDeletarDados(strNomeTabelaColetor, strColunaPrincipal, "LIKE", "'%'")
            objBDColetor.Dispose()
        End Sub

        Public Sub mtdCriarBancoDadosColetor()
            frmPrincipal.mtdCriarBancoDadosColetor(False)
        End Sub

        Public blnComandoImplementadoPermitirMensagemTabelaCentroCustoColetor As Boolean = True

        Public Sub mtdCriarTabelaCentroCustoColetor()
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                       strConexaoBancoDadosColetor, _
                                                                       clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)
            intcolunaColetor = 2

            camposColetor = New String(intcolunaColetor)() {}
            camposColetor(0) = New String(3) {"CentroCusto", "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyCentroCusto PRIMARY KEY"}
            camposColetor(1) = New String(3) {"Orgao", "NVARCHAR", "255", String.Empty}
            camposColetor(2) = New String(3) {"OrgaoDescricao", "NVARCHAR", "255", String.Empty}

            objBDColetor.mtdCriarTabela(strNomeTabelaColetor, camposColetor)
            objBDColetor.Dispose()
        End Sub

        Public blnComandoImplementadoInserirDadosTabelaCentroCustoColetor As Boolean = True

        Public Sub mtdInserirDadosTabelaCentroCustoColetor()
            Try
                Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                         strConexaoBancoDadosColetor, _
                                                                         clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

                Dim objBDColetorI As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                           strConexaoBancoDadosColetor, _
                                                                           clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

                Dim dados As String()() = New String(1)() {}
                dados(0) = New String(intcolunaColetor) {}

                For contador As Integer = 0 To intcolunaColetor Step 1
                    dados(0)(contador) = camposColetor(contador)(0)
                Next

                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoColetor
                blnSucessoImportarTabelaCentroCustoColetor = True

                objBDColetor.mtdAbrirConexao()
                objBDColetor.mtdExecutarComando(String.Format("SELECT DISTINCT {0} FROM {1}", _
                                                                          "Centro_Custo, Orgao", _
                                                                          strTabelaBensEletronorte))
                intNumeroLinhasColetor = objBDColetor.mtdNumeroLinhas()
                objBDColetor.mtdDefinirLeitorDados()
                intNumeroColunasColetor = objBDColetor.mtdNumeroColunas()
                objBDColetor.mtdProximoRegistro()
                vetTipoColunasColetor = objBDColetor.mtdObterTipoRegistro()

                Dim dadosI As String() = New String(intcolunaColetor - 1) {}

                For linha As Integer = 0 To intNumeroLinhasColetor Step 1
                    If blnAbortarThreadImportarTabelaCentroCustoColetor And blnForcarAbortarThreadImportarTabelaCentroCustoColetor Then
                        GoTo SaidaInserirDadosTabelaCentroCustoColetor
                    End If

                    'dados(linha) = New String(intNumeroColunasColetor) {}
                    For coluna As Integer = 0 To intcolunaColetor - 1 Step 1
                        Dim strFormatoRegistro As String = mtdObterFormatoTipo(vetTipoColunasColetor(coluna))
                        Dim strValorRegistro As String = objManipuladorTexto.mtdExecutarTudo( _
                            If((objBDColetor.mtdObterValorRegistro(coluna) IsNot Nothing), _
                               objBDColetor.mtdObterValorRegistro(coluna).ToString(), String.Empty))

                        dadosI(coluna) = String.Format(strFormatoRegistro, strValorRegistro)
                    Next
                    dados(1) = New String(intcolunaColetor) {}

                    For coluna As Integer = 0 To intNumeroColunasColetor Step 1
                        Select Case coluna
                            Case 0
                                dados(1)(coluna) = dadosI(0)
                            Case 1
                                dados(1)(coluna) = String.Format("'{0}'", dadosI(1).Split(" "c)(0).Replace("'"c, ""))
                            Case 2
                                dados(1)(coluna) = dadosI(1)
                        End Select
                    Next
                    objBDColetorI.mtdInserirDados(strNomeTabelaColetor, dados)
                    objBDColetor.mtdProximoRegistro()
                    [NewValue] = Convert.ToInt32((linha / intNumeroLinhasColetor) * 100)
                    Try
                        Me.BeginInvoke(f, New Object() {[NewValue]})
                    Catch ex As Exception
                    End Try
                    frmPrincipal.intProgresso = [NewValue]
                    frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoColetor
                    blnSucessoImportarTabelaCentroCustoColetor = True
                    System.Threading.Thread.Sleep(1)
                Next
SaidaInserirDadosTabelaCentroCustoColetor:
                [NewValue] = 100
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoColetor
                blnSucessoImportarTabelaCentroCustoColetor = True
                objBDColetor.Dispose()
                objBDColetorI.Dispose()
                If blnComandoImplementadoPermitirMensagemTabelaCentroCustoColetor Then
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
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaCentroCustoColetor
                blnSucessoImportarTabelaCentroCustoColetor = False
            End Try
        End Sub
    End Class
End Namespace