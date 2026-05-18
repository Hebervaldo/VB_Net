Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmInventarioBens
        Private ThImportarTabelaInventarioBensPrincipal As System.Threading.Thread

        Private strNomeProcessoImportarTabelaInventarioBensPrincipal As String = "Exportar Tabela de Inventário de Bens - Coletor"

        Friend Sub mtdIniciarThreadImportarTabelaInventarioBensPrincipal()
            mtdIniciarThreadImportarTabelaInventarioBensPrincipal(True)
        End Sub

        Friend Sub mtdIniciarThreadImportarTabelaInventarioBensPrincipal(ByVal Iniciar As Boolean)
            Try
                [NewValue] = 0
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensPrincipal
                blnAbortarThreadImportarTabelaInventarioBensPrincipal = Not Iniciar
                blnForcarAbortarThreadImportarTabelaInventarioBensPrincipal = False
                blnThreadAtivadaImportarTabelaInventarioBensPrincipal = True
                blnSucessoImportarTabelaInventarioBensPrincipal = False
                ThImportarTabelaInventarioBensPrincipal = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImportarTabelaInventarioBensPrincipal))
                ThImportarTabelaInventarioBensPrincipal.IsBackground = True
                ThImportarTabelaInventarioBensPrincipal.Priority = System.Threading.ThreadPriority.Normal
                ThImportarTabelaInventarioBensPrincipal.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImportarTabelaInventarioBensPrincipal: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImportarTabelaInventarioBensPrincipal()
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensPrincipal
            blnAbortarThreadImportarTabelaInventarioBensPrincipal = False
            blnForcarAbortarThreadImportarTabelaInventarioBensPrincipal = False

            blnThreadAtivadaImportarTabelaInventarioBensPrincipal = True
            blnSucessoImportarTabelaInventarioBensPrincipal = False
        End Sub

        Private Shared blnForcarAbortarThreadImportarTabelaInventarioBensPrincipal As Boolean = False
        Private Shared blnAbortarThreadImportarTabelaInventarioBensPrincipal As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImportarTabelaInventarioBensPrincipal As Integer = 1000

        Friend Sub mtdAbortarThreadImportarTabelaInventarioBensPrincipal()
            mtdAbortarThreadImportarTabelaInventarioBensPrincipal(False)
        End Sub

        Friend Sub mtdAbortarThreadImportarTabelaInventarioBensPrincipal(ByVal Forcar As Boolean)
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensPrincipal
            blnAbortarThreadImportarTabelaInventarioBensPrincipal = True
            blnForcarAbortarThreadImportarTabelaInventarioBensPrincipal = Forcar

            blnThreadAtivadaImportarTabelaInventarioBensPrincipal = False
            blnSucessoImportarTabelaInventarioBensPrincipal = False

            Try
                ThImportarTabelaInventarioBensPrincipal.Join(intTempoSaidaAbortarThreadImportarTabelaInventarioBensPrincipal)
                ThImportarTabelaInventarioBensPrincipal.Abort()
                ThImportarTabelaInventarioBensPrincipal = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImportarTabelaInventarioBensPrincipal: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImportarTabelaInventarioBensPrincipal()
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensPrincipal
            blnAbortarThreadImportarTabelaInventarioBensPrincipal = True
            blnForcarAbortarThreadImportarTabelaInventarioBensPrincipal = True

            blnThreadAtivadaImportarTabelaInventarioBensPrincipal = False
            blnSucessoImportarTabelaInventarioBensPrincipal = False
        End Sub

        Private Shared LockerImportarTabelaInventarioBensPrincipal As New Object()

        Private Sub mtdRotinaThreadImportarTabelaInventarioBensPrincipal()
            While Not blnForcarAbortarThreadImportarTabelaInventarioBensPrincipal
                If Not blnAbortarThreadImportarTabelaInventarioBensPrincipal Then
                    'System.Threading.Monitor.Enter(LockerImportarTabelaInventarioBensPrincipal)
                    SyncLock (LockerImportarTabelaInventarioBensPrincipal)
                        Try
                            mtdImportarTabelaInventarioBensPrincipal _
                            ( _
                            blnComandoImplementadoDeletarDadosTabelaInventarioBensPrincipal, _
                            blnComandoImplementadoInserirDadosTabelaInventarioBensPrincipal _
                            )
                            mtdAbortarThreadImportarTabelaInventarioBensPrincipal(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImportarTabelaInventarioBensPrincipal)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImportarTabelaInventarioBensPrincipal As Boolean = False
        Friend blnSucessoImportarTabelaInventarioBensPrincipal As Boolean = False

        Private lngCodigoImportarTabelaInventarioBensPrincipal As Long = 0

        Protected Friend Sub mtdImportarTabelaInventarioBensPrincipal()
            mtdIniciarThreadImportarTabelaInventarioBensPrincipal(True)
        End Sub

        Protected Friend Sub mtdImportarTabelaInventarioBensPrincipal(ByVal Deletar As Boolean, ByVal Inserir As Boolean)
            blnComandoImplementadoDeletarDadosTabelaInventarioBensPrincipal = Deletar
            blnComandoImplementadoInserirDadosTabelaInventarioBensPrincipal = Inserir

            If Deletar Then
                mtdDeletarTabelaInventarioBensPrincipal()
                mtdDeletarDadosTabelaInventarioBensPrincipal()
            End If
            mtdCriarTabelaInventarioBensPrincipal()
            If Inserir Then
                mtdInserirDadosTabelaInventarioBensPrincipal()
            End If
        End Sub

        Private colPrincipal As Integer = 1
        Private linPrincipal As Integer = 0
        Private intcolunaPrincipal As Integer = 0
        Private intlinhaPrincipal As Integer = 0

        Private intNumeroColunasPrincipal As Integer = 0
        Private intNumeroLinhasPrincipal As Integer = 0
        Private vetTipoColunasPrincipal As String()
        Private camposPrincipal As String()()
        Private vetLinhaTextoPrincipal As String()

        Public blnComandoImplementadoDeletarDadosTabelaInventarioBensPrincipal As Boolean = True

        Public Sub mtdDeletarTabelaInventarioBensPrincipal()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdDeletarTabela(strNomeTabelaPrincipal)
            objBDPrincipal.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaInventarioBensPrincipal()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdDeletarDados(strNomeTabelaPrincipal, strColunaPrincipal, "LIKE", "'%'")
            objBDPrincipal.Dispose()
        End Sub

        Public blnComandoImplementadoPermitirMensagemTabelaInventarioBensPrincipal As Boolean = True

        Public Sub mtdCriarTabelaInventarioBensPrincipal()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            intcolunaPrincipal = 24

            camposPrincipal = New String(intcolunaPrincipal)() {}
            camposPrincipal(0) = New String(3) {"Numero_Inventario", "LONG", String.Empty, "CONSTRAINT PrimaryKeyNumero_Inventario PRIMARY KEY"}
            camposPrincipal(1) = New String(3) {"Data_Inventario", "DATETIME", String.Empty, String.Empty}
            camposPrincipal(2) = New String(3) {"TRG", "TEXT", "255", String.Empty}
            camposPrincipal(3) = New String(3) {"CentroCusto", "TEXT", "255", String.Empty}
            camposPrincipal(4) = New String(3) {"Orgao", "TEXT", "255", String.Empty}
            camposPrincipal(5) = New String(3) {"Sala", "TEXT", "255", String.Empty}
            camposPrincipal(6) = New String(3) {"Nome", "TEXT", "255", String.Empty}
            camposPrincipal(7) = New String(3) {"Matricula", "TEXT", "255", String.Empty}
            camposPrincipal(8) = New String(3) {"Patrimonio", "TEXT", "255", String.Empty}
            camposPrincipal(9) = New String(3) {"Quantidade", "LONG", String.Empty, String.Empty}
            camposPrincipal(10) = New String(3) {"Denominacao", "TEXT", "255", String.Empty}
            camposPrincipal(11) = New String(3) {"N_Serie", "TEXT", "255", String.Empty}
            camposPrincipal(12) = New String(3) {"Placa_Veiculo", "TEXT", "255", String.Empty}
            camposPrincipal(13) = New String(3) {"Identificacao_Inventario", "TEXT", "255", String.Empty}
            camposPrincipal(14) = New String(3) {"OutrosDados_Inventario", "TEXT", "255", String.Empty}
            camposPrincipal(15) = New String(3) {"Observacao", "TEXT", "255", String.Empty}
            camposPrincipal(16) = New String(3) {"Coletor", "TEXT", "255", String.Empty}
            camposPrincipal(17) = New String(3) {"Usuario_Inventariante", "TEXT", "255", String.Empty}
            camposPrincipal(18) = New String(3) {"Matricula_Inventariante", "TEXT", "255", String.Empty}
            camposPrincipal(19) = New String(3) {"Inventario", "TEXT", "255", " NOT NULL CONSTRAINT UniqueInventario UNIQUE"}
            camposPrincipal(20) = New String(3) {"Fotografia", "IMAGE", String.Empty, String.Empty}
            camposPrincipal(21) = New String(3) {"GPS_Latitute", "TEXT", "255", String.Empty}
            camposPrincipal(22) = New String(3) {"GPS_Longitude", "TEXT", "255", String.Empty}
            camposPrincipal(23) = New String(3) {"GPS_EllipsoidAltitude", "TEXT", "255", String.Empty}
            camposPrincipal(24) = New String(3) {"GPS_PositionDilutionOfPrecision", "TEXT", "255", String.Empty}

            objBDPrincipal.mtdCriarTabela(strNomeTabelaPrincipal, camposPrincipal)
            objBDPrincipal.Dispose()
        End Sub

        Public blnComandoImplementadoInserirDadosTabelaInventarioBensPrincipal As Boolean = True

        Private blnSucessoPrincipal As Boolean = False

        Private Sub mtdInserirDadosTabelaInventarioBensPrincipal()
            Dim numLinha As Integer = 0
            Dim vetNumeroItens() As String = New String(intlsv - 1) {}
            Dim vetNumeroItensTotal As String()

            For linha As Integer = 0 To intlsv - 1 Step 1
                If (blnvetlsv(linha)) Then
                    vetNumeroItens(linha) = strvetlsv(linha)
                    numLinha += 1
                Else
                    vetNumeroItens(linha) = String.Empty
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

                    blnSucessoPrincipal = mtdComandoInserirDadosTabelaInventarioBensPrincipal(CampoSelecionador, DadoSelecionador)
                Next
            Else
                CampoSelecionador = vetCamposTabelaInventarioBens(intColunaTabelaInventarioBensInventario).ToString()
                DadoSelecionador = "'%'"

                blnSucessoPrincipal = mtdComandoInserirDadosTabelaInventarioBensPrincipal(CampoSelecionador, DadoSelecionador)
            End If

            mtdAbortarThreadImportarTabelaInventarioBensPrincipal(True)

            If blnComandoImplementadoPermitirMensagemTabelaInventarioBensPrincipal Then
                If blnSucessoPrincipal Then
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

        Private Function mtdComandoInserirDadosTabelaInventarioBensPrincipal(ByVal CampoSelecionador As String, ByVal DadoSelecionador As String) As Boolean
            Dim Retorno As Boolean = False
            Try
                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                        strConexaoBancoDadosPrincipal, _
                                                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                strConexaoBancoDadosColetor, _
                                                                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

                'objBDColetor.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosColetor)
                objBDColetor.mtdSelecionarDados(objBDColetor.mtdVetorLinhaCampos(vetCamposTabelaInventarioBens), strNomeTabelaColetor, CampoSelecionador, "LIKE", DadoSelecionador)

                Dim NumeroLinha As Integer = objBDColetor.mtdNumeroLinhas()

                objBDColetor.mtdDefinirLeitorDados()
                Dim NumeroColuna As Integer = objBDColetor.mtdNumeroColunas()

                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensPrincipal
                blnSucessoImportarTabelaInventarioBensPrincipal = True

                Dim dados As Object()() = New Object(1)() {}
                dados(0) = objBDColetor.mtdObterCabecalhoColunas()

                Dim dadosP()() As Object = New Object(1)() {}

                dadosP(0) = dados(0)
                dadosP(1) = New Object(dados(0).GetUpperBound(0)) {}

                Dim count As Integer = 1

                While (objBDColetor.mtdProximoRegistro())
                    If blnAbortarThreadImportarTabelaInventarioBensPrincipal And blnForcarAbortarThreadImportarTabelaInventarioBensPrincipal Then
                        GoTo SaidaComandoInserirDadosTabelaInventarioBensPrincipal
                    End If

                    objBDPrincipal.prpComandoOleDb.Parameters.Clear()

                    For contador As Integer = 0 To NumeroColuna - 1 Step 1
                        Select Case contador
                            Case 0
                                dadosP(1)(contador) = frmPrincipal.mtdGerarProximoNumeroCodigoPrincipal _
                                    ( _
                                    frmPrincipal.intMultiplicadorCodigoInventarioBens, _
                                    strNomeTabelaPrincipal, _
                                    strColunaPrincipal _
                                    )
                            Case Else
                                dadosP(1)(contador) = objBDColetor.mtdObterValorRegistro(contador)
                        End Select
                        System.Threading.Thread.Sleep(1)
                    Next

                    Dim objRegistroExisteTabelaInventarioBensPrincipal As Object = mtdSelecionarTabelaInventarioBensPrincipal _
                    ( _
                    dadosP(0)(intColunaTabelaInventarioBensInventario).ToString(), _
                    String.Format("'{0}'", dadosP(1)(intColunaTabelaInventarioBensInventario)) _
                    )

                    For contador As Integer = dadosP(0).GetLowerBound(0) To dadosP(0).GetUpperBound(0) Step 1
                        Select Case (contador)
                            Case 0
                                If objRegistroExisteTabelaInventarioBensPrincipal IsNot Nothing Then
                                    dadosP(1)(contador) = objRegistroExisteTabelaInventarioBensPrincipal
                                End If
                                objBDPrincipal.mtdExecutarParametroComandoOleDb _
                                ( _
                                dadosP(0)(contador).ToString(), _
                                dadosP(1)(contador) _
                                )
                            Case 1
                                objBDPrincipal.mtdExecutarParametroComandoOleDb _
                                ( _
                                dadosP(0)(contador).ToString(), _
                                System.Data.OleDb.OleDbType.Date, _
                                dadosP(1)(contador) _
                                )
                            Case Else
                                objBDPrincipal.mtdExecutarParametroComandoOleDb _
                                ( _
                                dadosP(0)(contador).ToString(), _
                                dadosP(1)(contador) _
                                )
                        End Select
                        System.Threading.Thread.Sleep(1)
                    Next

                    dados(1) = objBDColetor.mtdObterCabecalhoColunas()

                    For contador As Integer = dados(0).GetLowerBound(0) To dados(0).GetUpperBound(0) Step 1
                        dados(1)(contador) = String.Format("@{0}", dados(0)(contador).ToString())
                        System.Threading.Thread.Sleep(1)
                    Next

                    blnComandoImplementadoInserirDadosTabelaInventarioBensPrincipal = objBDPrincipal.mtdInserirDados(strNomeTabelaPrincipal, dados)

                    'If objRegistroExisteTabelaInventarioBensPrincipal IsNot Nothing Then
                    'Dim lngCodigoEspalhamentoPrincipal As Long = mtdCalcularCodigoEspalhamentoPrincipal _
                    '( _
                    'strNomeTabelaPrincipal, _
                    'vetCamposTabelaInventarioBens(intColunaTabelaInventarioBensInventario), _
                    'String.Format("{0}", dadosP(1)(intColunaTabelaInventarioBensInventario)) _
                    ')
                    'Dim lngCodigoEspalhamentoColetor As Long = mtdCalcularCodigoEspalhamentoColetor _
                    '( _
                    'strNomeTabelaColetor, _
                    'vetCamposTabelaInventarioBens(intColunaTabelaInventarioBensInventario), _
                    'String.Format("{0}", dadosP(1)(intColunaTabelaInventarioBensInventario)) _
                    ')

                    'If Not lngCodigoEspalhamentoPrincipal = lngCodigoEspalhamentoColetor Then
                    If Not blnComandoImplementadoInserirDadosTabelaInventarioBensPrincipal Then
                        dados(1) = New Object(dados(0).GetUpperBound(0) + 0 + 3) {}
                        If (mtdVerificarDataMaisAtualTabelaInventarioBensColetorPrincipal(1, vetCamposTabelaInventarioBens(intColunaTabelaInventarioBensInventario), dadosP(1)(intColunaTabelaInventarioBensInventario), dadosP(1)(intColunaTabelaInventarioBensData_Inventario))) Then
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

                            blnComandoImplementadoInserirDadosTabelaInventarioBensPrincipal = objBDPrincipal.mtdAtualizarDados(strNomeTabelaPrincipal, dados)
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
                    frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensPrincipal
                    blnSucessoImportarTabelaInventarioBensPrincipal = True
                    count += 1
                    System.Threading.Thread.Sleep(1)
                End While

SaidaComandoInserirDadosTabelaInventarioBensPrincipal:
                [NewValue] = 100
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As System.Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensPrincipal
                blnSucessoImportarTabelaInventarioBensPrincipal = True

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
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaInventarioBensPrincipal
                blnSucessoImportarTabelaInventarioBensPrincipal = False

                Retorno = False
            End Try

            Return Retorno
        End Function

        Public Function mtdSelecionarTabelaInventarioBensPrincipal(ByVal Campo As String, ByVal Dado As String) As Object
            Dim saida As Object = Nothing

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objBDPrincipal.mtdSelecionarDados("*", strNomeTabelaPrincipal, Campo, "LIKE", String.Format("{0}", Dado), Campo, True)
            objBDPrincipal.mtdDefinirLeitorDados()
            If (objBDPrincipal.mtdProximoRegistro()) Then
                saida = objBDPrincipal.mtdObterValorRegistro(0)
            End If
            objBDPrincipal.Dispose()

            Return saida
        End Function
    End Class
End Namespace