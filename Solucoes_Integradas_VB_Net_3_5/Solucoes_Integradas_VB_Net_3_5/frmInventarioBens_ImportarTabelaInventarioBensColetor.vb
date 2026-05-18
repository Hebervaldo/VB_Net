Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmInventarioBens
        Private ThImportarTabelaInventarioBensColetor As System.Threading.Thread

        Private strNomeProcessoImportarTabelaInventarioBensColetor As String = "Exportar Tabela de Inventário de Bens - Principal"

        Friend Sub mtdIniciarThreadImportarTabelaInventarioBensColetor()
            mtdIniciarThreadImportarTabelaInventarioBensColetor(True)
        End Sub

        Friend Sub mtdIniciarThreadImportarTabelaInventarioBensColetor(ByVal Iniciar As Boolean)
            Try
                [NewValue] = 0
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensColetor
                blnAbortarThreadImportarTabelaInventarioBensColetor = Not Iniciar
                blnForcarAbortarThreadImportarTabelaInventarioBensColetor = False
                blnThreadAtivadaImportarTabelaInventarioBensColetor = True
                blnSucessoImportarTabelaInventarioBensColetor = False
                ThImportarTabelaInventarioBensColetor = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImportarTabelaInventarioBensColetor))
                ThImportarTabelaInventarioBensColetor.IsBackground = True
                ThImportarTabelaInventarioBensColetor.Priority = System.Threading.ThreadPriority.Normal
                ThImportarTabelaInventarioBensColetor.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImportarTabelaInventarioBensColetor: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImportarTabelaInventarioBensColetor()
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensColetor
            blnAbortarThreadImportarTabelaInventarioBensColetor = False
            blnForcarAbortarThreadImportarTabelaInventarioBensColetor = False

            blnThreadAtivadaImportarTabelaInventarioBensColetor = True
            blnSucessoImportarTabelaInventarioBensColetor = False
        End Sub

        Private Shared blnForcarAbortarThreadImportarTabelaInventarioBensColetor As Boolean = False
        Private Shared blnAbortarThreadImportarTabelaInventarioBensColetor As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImportarTabelaInventarioBensColetor As Integer = 1000

        Friend Sub mtdAbortarThreadImportarTabelaInventarioBensColetor()
            mtdAbortarThreadImportarTabelaInventarioBensColetor(False)
        End Sub

        Friend Sub mtdAbortarThreadImportarTabelaInventarioBensColetor(ByVal Forcar As Boolean)
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensColetor
            blnAbortarThreadImportarTabelaInventarioBensColetor = True
            blnForcarAbortarThreadImportarTabelaInventarioBensColetor = Forcar

            blnThreadAtivadaImportarTabelaInventarioBensColetor = False
            blnSucessoImportarTabelaInventarioBensColetor = False

            Try
                ThImportarTabelaInventarioBensColetor.Join(intTempoSaidaAbortarThreadImportarTabelaInventarioBensColetor)
                ThImportarTabelaInventarioBensColetor.Abort()
                ThImportarTabelaInventarioBensColetor = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImportarTabelaInventarioBensColetor: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImportarTabelaInventarioBensColetor()
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensColetor
            blnAbortarThreadImportarTabelaInventarioBensColetor = True
            blnForcarAbortarThreadImportarTabelaInventarioBensColetor = True

            blnThreadAtivadaImportarTabelaInventarioBensColetor = False
            blnSucessoImportarTabelaInventarioBensColetor = False
        End Sub

        Private Shared LockerImportarTabelaInventarioBensColetor As New Object()

        Private Sub mtdRotinaThreadImportarTabelaInventarioBensColetor()
            While Not blnForcarAbortarThreadImportarTabelaInventarioBensColetor
                If Not blnAbortarThreadImportarTabelaInventarioBensColetor Then
                    'System.Threading.Monitor.Enter(LockerImportarTabelaInventarioBensColetor)
                    SyncLock (LockerImportarTabelaInventarioBensColetor)
                        Try
                            mtdImportarTabelaInventarioBensColetor _
                            ( _
                            blnComandoImplementadoDeletarDadosTabelaInventarioBensColetor, _
                            blnComandoImplementadoInserirDadosTabelaInventarioBensColetor _
                            )
                            mtdAbortarThreadImportarTabelaInventarioBensColetor(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImportarTabelaInventarioBensColetor)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImportarTabelaInventarioBensColetor As Boolean = False
        Friend blnSucessoImportarTabelaInventarioBensColetor As Boolean = False

        Private lngCodigoImportarTabelaInventarioBensColetor As Long = 0

        Protected Friend Sub mtdImportarTabelaInventarioBensColetor()
            mtdIniciarThreadImportarTabelaInventarioBensColetor(True)
        End Sub

        Protected Friend Sub mtdImportarTabelaInventarioBensColetor(ByVal Deletar As Boolean, ByVal Inserir As Boolean)
            'Dim isWatching As Boolean = frmPrincipal.m_bIsWatching

            'If isWatching Then
            '    frmPrincipal.mtdMonitorarDiretorioArquivo()
            'End If

            blnComandoImplementadoDeletarDadosTabelaInventarioBensColetor = Deletar
            blnComandoImplementadoInserirDadosTabelaInventarioBensColetor = Inserir

            If Deletar Then
                mtdDeletarTabelaInventarioBensColetor()
                mtdDeletarDadosTabelaInventarioBensColetor()
            End If
            mtdCriarBancoDadosColetor()
            mtdCriarTabelaInventarioBensColetor()
            If Inserir Then
                mtdInserirDadosTabelaInventarioBensColetor()
            End If

            'If Not isWatching Then
            '    frmPrincipal.mtdMonitorarDiretorioArquivo()
            'End If
        End Sub

        Private colColetor As Integer = 1
        Private linColetor As Integer = 0
        Private intcolunaColetor As Integer = 0
        Private intlinhaColetor As Integer = 0

        Private intNumeroColunasColetor As Integer = 0
        Private intNumeroLinhasColetor As Integer = 0
        Private vetTipoColunasColetor As String()
        Private camposColetor As String()()
        Private vetLinhaTextoColetor As String()

        Public blnComandoImplementadoDeletarDadosTabelaInventarioBensColetor As Boolean = True

        Public Sub mtdDeletarTabelaInventarioBensColetor()
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                         strConexaoBancoDadosColetor, _
                                                                         clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE _
                                                                         )

            objBDColetor.mtdDeletarTabela(strNomeTabelaColetor)
            objBDColetor.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaInventarioBensColetor()
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                         strConexaoBancoDadosColetor, _
                                                                         clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE _
                                                                         )

            objBDColetor.mtdDeletarDados(strNomeTabelaColetor, strColunaColetor, "LIKE", "'%'")
            objBDColetor.Dispose()
        End Sub

        Public Sub mtdCriarBancoDadosColetor()
            frmPrincipal.mtdCriarBancoDadosColetor(False)
        End Sub

        Public blnComandoImplementadoPermitirMensagemTabelaInventarioBensColetor As Boolean = True

        Public Sub mtdCriarTabelaInventarioBensColetor()
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosColetor, _
                                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            intcolunaColetor = 24

            camposColetor = New String(intcolunaColetor)() {}
            camposColetor(0) = New String(3) {"Numero_Inventario", "BIGINT", String.Empty, "CONSTRAINT PrimaryKeyNumero_Inventario PRIMARY KEY"}
            camposColetor(1) = New String(3) {"Data_Inventario", "DATETIME", String.Empty, String.Empty}
            camposColetor(2) = New String(3) {"TRG", "NVARCHAR", "255", String.Empty}
            camposColetor(3) = New String(3) {"CentroCusto", "NVARCHAR", "255", String.Empty}
            camposColetor(4) = New String(3) {"Orgao", "NVARCHAR", "255", String.Empty}
            camposColetor(5) = New String(3) {"Sala", "NVARCHAR", "255", String.Empty}
            camposColetor(6) = New String(3) {"Nome", "NVARCHAR", "255", String.Empty}
            camposColetor(7) = New String(3) {"Matricula", "NVARCHAR", "255", String.Empty}
            camposColetor(8) = New String(3) {"Patrimonio", "NVARCHAR", "255", String.Empty}
            camposColetor(9) = New String(3) {"Quantidade", "BIGINT", String.Empty, String.Empty}
            camposColetor(10) = New String(3) {"Denominacao", "NVARCHAR", "255", String.Empty}
            camposColetor(11) = New String(3) {"N_Serie", "NVARCHAR", "255", String.Empty}
            camposColetor(12) = New String(3) {"Placa_Veiculo", "NVARCHAR", "255", String.Empty}
            camposColetor(13) = New String(3) {"Identificacao_Inventario", "NVARCHAR", "255", String.Empty}
            camposColetor(14) = New String(3) {"OutrosDados_Inventario", "NVARCHAR", "255", String.Empty}
            camposColetor(15) = New String(3) {"Observacao", "NVARCHAR", "255", String.Empty}
            camposColetor(16) = New String(3) {"Coletor", "NVARCHAR", "255", String.Empty}
            camposColetor(17) = New String(3) {"Usuario_Inventariante", "NVARCHAR", "255", String.Empty}
            camposColetor(18) = New String(3) {"Matricula_Inventariante", "NVARCHAR", "255", String.Empty}
            camposColetor(19) = New String(3) {"Inventario", "NVARCHAR", "255", String.Format(" UNIQUE REFERENCES {0}({1})", strNomeTabelaColetor, "Inventario")}
            camposColetor(20) = New String(3) {"Fotografia", "IMAGE", String.Empty, String.Empty}
            camposColetor(21) = New String(3) {"GPS_Latitute", "NVARCHAR", "255", String.Empty}
            camposColetor(22) = New String(3) {"GPS_Longitude", "NVARCHAR", "255", String.Empty}
            camposColetor(23) = New String(3) {"GPS_EllipsoidAltitude", "NVARCHAR", "255", String.Empty}
            camposColetor(24) = New String(3) {"GPS_PositionDilutionOfPrecision", "NVARCHAR", "255", String.Empty}

            objBDColetor.mtdCriarTabela(strNomeTabelaColetor, camposColetor)
            objBDColetor.Dispose()
        End Sub

        Public blnComandoImplementadoInserirDadosTabelaInventarioBensColetor As Boolean = True

        Private blnSucessoColetor As Boolean = False

        Private Sub mtdInserirDadosTabelaInventarioBensColetor()
            Dim numLinha As Integer = 0
            Dim vetNumeroItens() As String = New String(intlsv - 1) {}
            Dim vetNumeroItensTotal As String()

            For linha As Integer = 0 To intlsv - 1 Step 1
                If (blnvetlsv(linha)) Then
                    vetNumeroItens(linha) = strvetlsv(linha)
                    numLinha += 1
                End If
            Next

            vetNumeroItensTotal = New String(numLinha - 1) {}

            Dim contador As Integer = 0
            For linha As Integer = 0 To intlsv - 1 Step 1
                If blnvetlsv(linha) Then
                    vetNumeroItensTotal(contador) = vetNumeroItens(linha)
                    contador += 1
                End If
            Next
            Dim intNumeroItensTotal As Integer = 0

            Try
                intNumeroItensTotal = vetNumeroItensTotal.Length
            Catch ex As System.Exception
                intNumeroItensTotal = 0
            End Try

            If intNumeroItensTotal > 0 Then
                For contadorGeral As Integer = vetNumeroItensTotal.GetLowerBound(0) To vetNumeroItensTotal.GetUpperBound(0) Step 1
                    CampoSelecionador = IIf(CampoSelecionador <> String.Empty, CampoSelecionador, vetCamposTabelaInventarioBens(intColunaTabelaInventarioBensInventario)).ToString()
                    DadoSelecionador = IIf(vetNumeroItensTotal(contadorGeral) <> String.Empty, String.Format("'%{0}%'", vetNumeroItensTotal(contadorGeral)), "'%'").ToString()

                    blnSucessoColetor = mtdComandoInserirDadosTabelaInventarioBensColetor(CampoSelecionador, DadoSelecionador)
                Next
            Else
                CampoSelecionador = vetCamposTabelaInventarioBens(intColunaTabelaInventarioBensInventario).ToString()
                DadoSelecionador = "'%'"

                blnSucessoColetor = mtdComandoInserirDadosTabelaInventarioBensColetor(CampoSelecionador, DadoSelecionador)
            End If

            mtdAbortarThreadImportarTabelaInventarioBensColetor(True)

            If blnComandoImplementadoPermitirMensagemTabelaInventarioBensColetor Then
                If blnSucessoColetor Then
                    System.Windows.Forms.MessageBox.Show( _
                        "A exportação dos dados finalizou com sucesso.", _
                        "Aviso!", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, _
                        MessageBoxOptions.DefaultDesktopOnly _
                        )
                Else
                    System.Windows.Forms.MessageBox.Show( _
                        "Houve erros ao exportar os dados.", _
                        "Aviso!", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, _
                        MessageBoxOptions.DefaultDesktopOnly _
                        )
                End If
            End If
        End Sub

        Private Function mtdComandoInserirDadosTabelaInventarioBensColetor(ByVal CampoSelecionador As String, ByVal DadoSelecionador As String) As Boolean
            Dim Retorno As Boolean = False

            Try
                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                strConexaoBancoDadosPrincipal, _
                                                                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                strConexaoBancoDadosColetor, _
                                                                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

                'objBDPrincipal.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosPrincipal)
                objBDPrincipal.mtdSelecionarDados(objBDPrincipal.mtdVetorLinhaCampos(vetCamposTabelaInventarioBens), strNomeTabelaPrincipal, CampoSelecionador, "LIKE", DadoSelecionador)

                Dim NumeroLinha As Integer = objBDPrincipal.mtdNumeroLinhas()

                objBDPrincipal.mtdDefinirLeitorDados()
                Dim NumeroColuna As Integer = objBDPrincipal.mtdNumeroColunas()

                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensColetor
                blnSucessoImportarTabelaInventarioBensColetor = True

                Dim dados As Object()() = New Object(1)() {}
                dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()

                Dim dadosP()() As Object = New Object(1)() {}

                dadosP(0) = dados(0)
                dadosP(1) = New Object(dados(0).GetUpperBound(0)) {}

                Dim count As Integer = 1

                While (objBDPrincipal.mtdProximoRegistro())
                    If blnAbortarThreadImportarTabelaInventarioBensColetor And blnForcarAbortarThreadImportarTabelaInventarioBensColetor Then
                        GoTo SaidaComandoInserirDadosTabelaInventarioBensColetor
                    End If

                    objBDColetor.prpComandoSQLServerCE.Parameters.Clear()

                    For contador As Integer = 0 To NumeroColuna - 1 Step 1
                        Select Case contador
                            Case 0
                                dadosP(1)(contador) = frmPrincipal.mtdGerarProximoNumeroCodigoColetor _
                                    ( _
                                    frmPrincipal.intMultiplicadorCodigoInventarioBens, _
                                    strNomeTabelaColetor, _
                                    strColunaColetor _
                                    )
                            Case Else
                                dadosP(1)(contador) = objBDPrincipal.mtdObterValorRegistro(contador)
                        End Select
                        System.Threading.Thread.Sleep(1)
                    Next

                    Dim objRegistroExisteTabelaInventarioBensColetor As Object = mtdSelecionarTabelaInventarioBensColetor _
                    ( _
                    dadosP(0)(intColunaTabelaInventarioBensInventario).ToString(), _
                    String.Format("'{0}'", dadosP(1)(intColunaTabelaInventarioBensInventario)) _
                    )

                    For contador As Integer = dadosP(0).GetLowerBound(0) To dadosP(0).GetUpperBound(0) Step 1
                        Select Case (contador)
                            Case 0
                                If objRegistroExisteTabelaInventarioBensColetor IsNot Nothing Then
                                    dadosP(1)(contador) = objRegistroExisteTabelaInventarioBensColetor
                                End If
                                objBDColetor.mtdExecutarParametroComandoSQLServerCE _
                                ( _
                                dadosP(0)(contador).ToString(), _
                                dadosP(1)(contador) _
                                )
                            Case 1
                                objBDColetor.mtdExecutarParametroComandoSQLServerCE _
                                ( _
                                dadosP(0)(contador).ToString(), _
                                System.Data.SqlDbType.DateTime, _
                                dadosP(1)(contador) _
                                )
                            Case Else
                                objBDColetor.mtdExecutarParametroComandoSQLServerCE _
                                ( _
                                dadosP(0)(contador).ToString(), _
                                dadosP(1)(contador) _
                                )
                        End Select
                        System.Threading.Thread.Sleep(1)
                    Next

                    dados(1) = objBDPrincipal.mtdObterCabecalhoColunas()

                    For contador As Integer = dados(0).GetLowerBound(0) To dados(0).GetUpperBound(0) Step 1
                        dados(1)(contador) = String.Format("@{0}", dados(0)(contador).ToString())
                        System.Threading.Thread.Sleep(1)
                    Next

                    blnComandoImplementadoInserirDadosTabelaInventarioBensColetor = objBDColetor.mtdInserirDados(strNomeTabelaColetor, dados)

                    'If objRegistroExisteTabelaInventarioBensColetor IsNot Nothing Then
                    '    Dim lngCodigoEspalhamentoColetor As Long = mtdCalcularCodigoEspalhamentoColetor _
                    '    ( _
                    '    strNomeTabelaColetor, _
                    '    vetCamposTabelaInventarioBens(intColunaTabelaInventarioBensInventario), _
                    '    String.Format("{0}", dadosP(1)(intColunaTabelaInventarioBensInventario)) _
                    '    )
                    '    Dim lngCodigoEspalhamentoPrincipal As Long = mtdCalcularCodigoEspalhamentoPrincipal _
                    '    ( _
                    '    strNomeTabelaPrincipal, _
                    '    vetCamposTabelaInventarioBens(intColunaTabelaInventarioBensInventario), _
                    '    String.Format("{0}", dadosP(1)(intColunaTabelaInventarioBensInventario)) _
                    '    )

                    '    If Not lngCodigoEspalhamentoColetor = lngCodigoEspalhamentoPrincipal Then
                    If Not blnComandoImplementadoInserirDadosTabelaInventarioBensColetor Then
                        dados(1) = New Object(dados(0).GetUpperBound(0) + 0 + 3) {}
                        If (mtdVerificarDataMaisAtualTabelaInventarioBensPrincipalColetor(1, vetCamposTabelaInventarioBens(intColunaTabelaInventarioBensInventario), dadosP(1)(intColunaTabelaInventarioBensInventario))) Then
                            For contador As Integer = dados(0).GetLowerBound(0) To dados(0).GetUpperBound(0) Step 1
                                dados(1)(contador) = String.Format("@{0}", dados(0)(contador).ToString())
                            Next

                            dados(1)(dados(0).GetUpperBound(0) + 1) = String.Format _
                            ( _
                            "{0}", _
                            dadosP(0)(intColunaTabelaInventarioBensInventario) _
                            )
                            dados(1)(dados(0).GetUpperBound(0) + 2) = String.Format _
                            ( _
                            "{0}", _
                            "LIKE" _
                            )
                            dados(1)(dados(0).GetUpperBound(0) + 3) = String.Format _
                            ( _
                            "'{0}'", _
                            dadosP(1)(intColunaTabelaInventarioBensInventario) _
                            )

                            blnComandoImplementadoInserirDadosTabelaInventarioBensColetor = objBDColetor.mtdAtualizarDados(strNomeTabelaColetor, dados)
                        End If
                    End If
                    'End If
                    'End If

                    [NewValue] = Convert.ToInt32((count / NumeroLinha) * 100)
                    Try
                        Me.BeginInvoke(f, New Object() {[NewValue]})
                    Catch ex As System.Exception
                    End Try
                    frmPrincipal.intProgresso = [NewValue]
                    frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensColetor
                    blnSucessoImportarTabelaInventarioBensColetor = True
                    count += 1
                    System.Threading.Thread.Sleep(1)
                End While

SaidaComandoInserirDadosTabelaInventarioBensColetor:
                [NewValue] = 100
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As System.Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensColetor
                blnSucessoImportarTabelaInventarioBensColetor = True

                objBDPrincipal.Dispose()
                objBDColetor.Dispose()

                Retorno = True
            Catch ex As System.Exception
                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex_ As System.Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensColetor
                blnSucessoImportarTabelaInventarioBensColetor = False

                Retorno = False
            End Try

            Return Retorno
        End Function

        Public Function mtdSelecionarTabelaInventarioBensColetor(ByVal Campo As String, ByVal Dado As String) As Object
            Dim saida As Object = Nothing

            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                    strConexaoBancoDadosColetor, _
                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            objBDColetor.mtdSelecionarDados("*", strNomeTabelaColetor, Campo, "LIKE", String.Format("{0}", Dado), Campo, True)
            objBDColetor.mtdDefinirLeitorDados()
            If (objBDColetor.mtdProximoRegistro()) Then
                saida = objBDColetor.mtdObterValorRegistro(0)
            End If
            objBDColetor.Dispose()

            Return saida
        End Function
    End Class
End Namespace