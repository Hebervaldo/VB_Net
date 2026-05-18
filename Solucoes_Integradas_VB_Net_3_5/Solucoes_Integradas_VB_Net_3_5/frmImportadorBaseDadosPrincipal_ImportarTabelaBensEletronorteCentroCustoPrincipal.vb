Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmImportadorBaseDadosPrincipal
        Private ThImportarTabelaBensEletronorteCentroCustoPrincipal As System.Threading.Thread

        Private strNomeProcessoImportarTabelaBensEletronorteCentroCustoPrincipal As String = "Importar Tabela de Bens - C. Custo - Principal"

        Friend Sub mtdIniciarThreadImportarTabelaBensEletronorteCentroCustoPrincipal()
            mtdIniciarThreadImportarTabelaBensEletronorteCentroCustoPrincipal(True)
        End Sub

        Friend Sub mtdIniciarThreadImportarTabelaBensEletronorteCentroCustoPrincipal(ByVal Iniciar As Boolean)
            Try
                [NewValue] = 0
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoPrincipal
                blnAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal = Not Iniciar
                blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal = False
                blnThreadAtivadaImportarTabelaBensEletronorteCentroCustoPrincipal = True
                blnSucessoImportarTabelaBensEletronorteCentroCustoPrincipal = False
                ThImportarTabelaBensEletronorteCentroCustoPrincipal = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImportarTabelaBensEletronorteCentroCustoPrincipal))
                ThImportarTabelaBensEletronorteCentroCustoPrincipal.IsBackground = True
                ThImportarTabelaBensEletronorteCentroCustoPrincipal.Priority = System.Threading.ThreadPriority.Normal
                ThImportarTabelaBensEletronorteCentroCustoPrincipal.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImportarTabelaBensEletronorteCentroCustoPrincipal: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImportarTabelaBensEletronorteCentroCustoPrincipal()
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoPrincipal
            blnAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal = False
            blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal = False

            blnThreadAtivadaImportarTabelaBensEletronorteCentroCustoPrincipal = True
            blnSucessoImportarTabelaBensEletronorteCentroCustoPrincipal = False
        End Sub

        Private Shared blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal As Boolean = False
        Private Shared blnAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal As Integer = 1000

        Friend Sub mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal()
            mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal(False)
        End Sub

        Friend Sub mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal(ByVal Forcar As Boolean)
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoPrincipal
            blnAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal = True
            blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal = Forcar

            blnThreadAtivadaImportarTabelaBensEletronorteCentroCustoPrincipal = False
            blnSucessoImportarTabelaBensEletronorteCentroCustoPrincipal = False

            Try
                ThImportarTabelaBensEletronorteCentroCustoPrincipal.Join(intTempoSaidaAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal)
                ThImportarTabelaBensEletronorteCentroCustoPrincipal.Abort()
                ThImportarTabelaBensEletronorteCentroCustoPrincipal = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImportarTabelaBensEletronorteCentroCustoPrincipal()
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoPrincipal
            blnAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal = True
            blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal = True

            blnThreadAtivadaImportarTabelaBensEletronorteCentroCustoPrincipal = False
            blnSucessoImportarTabelaBensEletronorteCentroCustoPrincipal = False
        End Sub

        Private Shared LockerImportarTabelaBensEletronorteCentroCustoPrincipal As New Object()

        Private Sub mtdRotinaThreadImportarTabelaBensEletronorteCentroCustoPrincipal()
            While Not blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal
                If Not blnAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal Then
                    'System.Threading.Monitor.Enter(LockerImportarTabelaBensEletronorteCentroCustoPrincipal)
                    SyncLock (LockerImportarTabelaBensEletronorteCentroCustoPrincipal)
                        Try
                            blnComandoImplementadoDeletarDadosTabelaBensEletronorteCentroCustoPrincipal = True
                            blnComandoImplementadoInserirDadosTabelaBensEletronorteCentroCustoPrincipal = True
                            mtdImportarTabelaBensEletronorteCentroCustoPrincipal _
                            ( _
                            blnComandoImplementadoDeletarDadosTabelaBensEletronorteCentroCustoPrincipal, _
                            blnComandoImplementadoInserirDadosTabelaBensEletronorteCentroCustoPrincipal _
                            )
                            mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImportarTabelaBensEletronorteCentroCustoPrincipal)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImportarTabelaBensEletronorteCentroCustoPrincipal As Boolean = False
        Friend blnSucessoImportarTabelaBensEletronorteCentroCustoPrincipal As Boolean = False

        Private lngCodigoImportarTabelaBensEletronorteCentroCustoPrincipal As Long = 0

        Protected Friend Sub mtdImportarTabelaBensEletronorteCentroCustoPrincipal()
            mtdIniciarThreadImportarTabelaBensEletronorteCentroCustoPrincipal(True)
        End Sub

        Protected Friend Sub mtdImportarTabelaBensEletronorteCentroCustoPrincipal(ByVal Deletar As Boolean, ByVal Inserir As Boolean)
            blnComandoImplementadoDeletarDadosTabelaBensEletronorteCentroCustoPrincipal = Deletar
            blnComandoImplementadoInserirDadosTabelaBensEletronorteCentroCustoPrincipal = Inserir

            If Deletar Then
                mtdDeletarTabelaBensEletronorteCentroCustoPrincipal()
                mtdDeletarDadosTabelaBensEletronorteCentroCustoPrincipal()
            End If
            mtdCriarTabelaBensEletronorteCentroCustoPrincipal()
            If Inserir Then
                mtdInserirDadosTabelaBensEletronorteCentroCustoPrincipal()
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

        Public blnComandoImplementadoDeletarDadosTabelaBensEletronorteCentroCustoPrincipal As Boolean = True

        Public Sub mtdDeletarTabelaBensEletronorteCentroCustoPrincipal()
            frmBens.mtdDeletarTabelaBensEletronortePrincipal()
            frmCentroCusto.mtdDeletarTabelaCentroCustoPrincipal()
        End Sub

        Public Sub mtdDeletarDadosTabelaBensEletronorteCentroCustoPrincipal()
            frmBens.mtdDeletarDadosTabelaBensEletronortePrincipal()
            frmCentroCusto.mtdDeletarDadosTabelaCentroCustoPrincipal()
        End Sub

        Public blnComandoImplementadoPermitirMensagemTabelaBensEletronorteCentroCustoPrincipal As Boolean = True

        Public Sub mtdCriarTabelaBensEletronorteCentroCustoPrincipal()
            frmBens.mtdCriarTabelaBensEletronortePrincipal()
            frmCentroCusto.mtdCriarTabelaCentroCustoPrincipal()
        End Sub

        Public blnComandoImplementadoInserirDadosTabelaBensEletronorteCentroCustoPrincipal As Boolean = True

        Private Sub mtdInserirDadosTabelaBensEletronorteCentroCustoPrincipal()
            Try
                Dim stbRegistro As System.Text.StringBuilder = New System.Text.StringBuilder()
                Dim [NewItem](10) As ListViewItem
                [NewValue] = 0
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoPrincipal
                blnSucessoImportarTabelaBensEletronorteCentroCustoPrincipal = True
                Dim f As SetItemCallback = New SetItemCallback(AddressOf Me.SetItem)
                Dim g As SetValueCallback = New SetValueCallback(AddressOf Me.SetValue)
                Dim Matricula_RG As Integer = 0
                Dim strOrgao As String = String.Empty

                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
                ( _
                frmPrincipal.strConexaoBancoDadosPrincipal, _
                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
                )

                Dim strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal As String = "tblTabelasAuxiliaresTermoResponsabilidadeGeral"
                Dim strTabelaAuxiliaresFiltroImportacaoPrincipal As String = "tblTabelasAuxiliaresFiltroImportacao"

                Dim count As Integer = 0

                objBDPrincipal.mtdSelecionarDados("*", strTabelaAuxiliaresFiltroImportacaoPrincipal)
                Dim intNumeroLinhasFiltroImportacao As Integer = objBDPrincipal.mtdNumeroLinhas()
                Dim vetFiltroImportacao As String() = New String(intNumeroLinhasFiltroImportacao - 1) {}

                objBDPrincipal.mtdDefinirLeitorDados()

                While objBDPrincipal.mtdProximoRegistro()
                    vetFiltroImportacao(count) = objBDPrincipal.mtdObterValorRegistro(0).ToString()
                    count += 1
                End While

                objBDPrincipal.mtdSelecionarDados("*", strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal)
                Dim intNumeroLinhasTermoResponsabilidadeGeral As Integer = objBDPrincipal.mtdNumeroLinhas()
                Dim vetTermoResponsabilidadeGeral As String() = New String(intNumeroLinhasTermoResponsabilidadeGeral - 1) {}

                count = 0

                objBDPrincipal.mtdDefinirLeitorDados()

                While objBDPrincipal.mtdProximoRegistro()
                    vetTermoResponsabilidadeGeral(count) = System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(0))

                    count += 1
                    System.Threading.Thread.Sleep(1)
                End While

                objArquivoTXT.mtdAbrirLeitorTexto(frmPrincipal.strEnderecoArquivoImportado)

                While (Not objArquivoTXT.getFimArquivo)
                    intNumMaxLinha += 1

                    If intNumMaxLinha <= 10 Then
                        Dim strConteudo As String = String.Empty
                        Dim strLinha As String = objArquivoTXT.mtdLeitorTextoLinha()

                        If strLinha.Contains("Registros selecionados:") Then
                            For contador As Integer = 0 To strLinha.Length - 1 Step 1
                                If Not Convert.ToInt32(strLinha.Chars(contador)) = Convert.ToInt32(":"c) Then
                                    strConteudo = strLinha.Split(":"c)(1)
                                    intNumMaxLinha = Int32.Parse(strConteudo.Trim())
                                    Exit While
                                End If
                            Next
                        End If
                    End If

                    System.Threading.Thread.Sleep(1)
                End While

                objArquivoTXT.prpLeitorTexto.Close()

                objArquivoTXT.mtdAbrirLeitorTexto(frmPrincipal.strEnderecoArquivoImportado)
                stbTexto = New System.Text.StringBuilder(objArquivoTXT.mtdLeitorTextoLinha())

                objBDPrincipal.mtdExecutarComando("DROP TABLE tblCentroCustoTemp;")

                stbSQL = New System.Text.StringBuilder("CREATE TABLE tblCentroCustoTemp (CentroCusto INTEGER NULL, Orgao NVARCHAR(250) NULL, OrgaoDescricao NVARCHAR(250) NULL);")
                objBDPrincipal.mtdExecutarComando(stbSQL.ToString())

                Dim numRandom As Random = New Random()
                dtmTempoInicial = DateTime.Now
                Dim stbBuffer(14) As System.Text.StringBuilder
                Dim incrementador As Integer = 0
                While Not objArquivoTXT.getFimArquivo
                    stbRegistro = New System.Text.StringBuilder(String.Empty)
                    intNumLinhaVerificada += 1
                    stbTexto = New System.Text.StringBuilder(objArquivoTXT.mtdLeitorTextoLinha())
                    If Not stbTexto.ToString() = "Não há conteúdo." Then
                        'If stbTexto.ToString().Contains("Registros selecionados:") Then
                        '    For contador As Integer = stbBuffer.GetLowerBound(0) To stbBuffer.GetUpperBound(0) Step 1
                        '        stbBuffer(contador) = New System.Text.StringBuilder(String.Empty)
                        '    Next
                        '    incrementador = 0
                        '    For contador As Integer = 0 To stbTexto.ToString().Length - 1 Step 1
                        '        If Not Convert.ToInt32(stbTexto.Chars(contador)) = Convert.ToInt32(":"c) Then
                        '           If incrementador <= stbBuffer.Length - 1 Then
                        '               stbBuffer(incrementador).Append(stbTexto.Chars(contador))
                        '           End If
                        '        Else
                        '            incrementador += 1
                        '        End If
                        '    Next
                        '    intNumMaxLinha = Int32.Parse(stbBuffer(1).ToString().Trim())
                        'End If

                        Dim blnContemFiltroImportacao As Boolean = False
                        For count = vetFiltroImportacao.GetLowerBound(0) To vetFiltroImportacao.GetUpperBound(0) Step 1
                            blnContemFiltroImportacao = blnContemFiltroImportacao Or stbTexto.ToString().Contains(vetFiltroImportacao(count))
                        Next

                        If blnContemFiltroImportacao Then
                            For contador As Integer = stbBuffer.GetLowerBound(0) To stbBuffer.GetUpperBound(0) Step 1
                                stbBuffer(contador) = New System.Text.StringBuilder(String.Empty)
                            Next
                            incrementador = 0
                            For contador As Integer = 0 To stbTexto.ToString().Length - 1 Step 1
                                If Not Convert.ToInt32(stbTexto.Chars(contador)) = Convert.ToInt32("|"c) Then
                                    If incrementador <= stbBuffer.Length - 1 Then
                                        stbBuffer(incrementador).Append(stbTexto.Chars(contador))
                                    End If
                                Else
                                    incrementador += 1
                                End If
                            Next

                            For contador As Integer = stbBuffer.GetLowerBound(0) To stbBuffer.GetUpperBound(0) Step 1
                                stbBuffer(contador) = New System.Text.StringBuilder(objManipuladorTexto.mtdExecutarTudo(stbBuffer(contador).ToString()))
                            Next

                            'Matricula_RG = Convert.ToInt32(IIf(Not objRegistroWindows.mtdObterDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "Numero_TRG").ToString() = String.Empty, objRegistroWindows.mtdObterDadosRegistro("Numero_TRG").ToString(), "0"))

                            Dim blnContemTermoResponsabilidadeGeral As Boolean = False
                            For count = vetTermoResponsabilidadeGeral.GetLowerBound(0) To vetTermoResponsabilidadeGeral.GetUpperBound(0) Step 1
                                blnContemTermoResponsabilidadeGeral = blnContemTermoResponsabilidadeGeral Or stbTexto.ToString().Contains(vetTermoResponsabilidadeGeral(count))
                            Next

                            If blnContemTermoResponsabilidadeGeral Then
                                ' Tabela tblBensEletronorte
                                stbSQL = New System.Text.StringBuilder("INSERT INTO tblBensEletronorte ")
                                stbSQLParcial = New System.Text.StringBuilder("(Imobilizado, Patrimonio, Denominacao, Denominacao_Extra, N_Serie, Sala, Matricula, Centro_Custo, Atividade, Orgao")
                                stbSQLParcial2 = New System.Text.StringBuilder("(").Append(stbBuffer(1)).Append(", '"). _
                                Append(IIf(Not stbBuffer(2).ToString() = String.Empty, stbBuffer(2), "0")).Append("', '"). _
                                Append(IIf(Not stbBuffer(3).ToString() = String.Empty, stbBuffer(3), String.Empty)).Append("', '"). _
                                Append(IIf(Not stbBuffer(4).ToString() = String.Empty, stbBuffer(4), String.Empty)).Append("', '"). _
                                Append(IIf(Not stbBuffer(5).ToString() = String.Empty, stbBuffer(5), String.Empty)).Append("', '"). _
                                Append(IIf(Not stbBuffer(8).ToString() = String.Empty, stbBuffer(8), String.Empty)).Append("', '"). _
                                Append(IIf(Not stbBuffer(10).ToString() = String.Empty, stbBuffer(10), "0")).Append("', '"). _
                                Append(IIf(Not stbBuffer(11).ToString() = String.Empty, stbBuffer(11), "0")).Append("', '").Append("Capitalizado").Append("', '"). _
                                Append(IIf(Not stbBuffer(14).ToString() = String.Empty, stbBuffer(14), String.Empty)).Append("'")
                                stbSQLParcial.Append(")")
                                stbSQLParcial2.Append(")")
                                stbSQL.Append(stbSQLParcial.Append(" VALUES ").Append(stbSQLParcial2))
                                blnLinhaAdicionada = objBDPrincipal.mtdExecutarComando(stbSQL.ToString())
                                If (blnLinhaAdicionada) Then
                                    intNumLinhaAdicionada += 1
                                End If
                                ' Tabela tblCentroCusto
                                Dim contador As Integer = 0
                                Dim blnOcorreuEspaco As Boolean = False
                                strOrgao = String.Empty
                                While (contador < stbBuffer(14).ToString().Length And Not blnOcorreuEspaco)
                                    Dim chrCaractere As Char = Convert.ToChar(stbBuffer(14).ToString().Substring(contador, 1))
                                    Dim intCaractere As Integer = Convert.ToInt32(chrCaractere)
                                    If Not intCaractere = 32 Then
                                        strOrgao &= chrCaractere
                                    Else
                                        blnOcorreuEspaco = True
                                    End If
                                    contador += 1
                                End While
                                strOrgao = objManipuladorTexto.mtdExecutarTudo(strOrgao)
                                stbSQL = New System.Text.StringBuilder("INSERT INTO tblCentroCustoTemp ")
                                stbSQLParcial = New System.Text.StringBuilder("(CentroCusto, Orgao, OrgaoDescricao")
                                stbSQLParcial2 = New System.Text.StringBuilder("('").Append(IIf(Not stbBuffer(11).ToString() = String.Empty, stbBuffer(11), "0")).Append("', '"). _
                                Append(IIf(Not strOrgao = String.Empty, strOrgao, String.Empty)).Append("', '"). _
                                Append(IIf(Not stbBuffer(14).ToString() = String.Empty, stbBuffer(14), String.Empty)).Append("'")
                                stbSQLParcial.Append(")")
                                stbSQLParcial2.Append(")")
                                stbSQL.Append(stbSQLParcial.Append(" VALUES ").Append(stbSQLParcial2))
                                objBDPrincipal.mtdExecutarComando(stbSQL.ToString())

                                If (blnLinhaAdicionada) Then
                                    [NewItem](9) = New ListViewItem("Número do Termo de Responsabilidade Geral: ", 9)
                                    [NewItem](9).SubItems.Add(stbBuffer(12).ToString())
                                    [NewItem](10) = New ListViewItem("Registro adicionado: ", 10)
                                    [NewItem](10).SubItems.Add(stbBuffer(1).ToString() & " - " & stbBuffer(2).ToString() & " - " & stbBuffer(3).ToString() & " - " & _
                                    stbBuffer(4).ToString() & " - " & stbBuffer(5).ToString() & " - " & stbBuffer(8).ToString() & " - " & stbBuffer(10).ToString() & _
                                    " - " & stbBuffer(11).ToString() & " - " & stbBuffer(14).ToString())
                                End If
                            End If
                        End If
                        ' Restante da estrutura
                        dtmTempoParcial = DateTime.Now
                        tspDiferencaTempo = dtmTempoParcial - dtmTempoInicial
                        If (intNumMaxLinha <= 0) Then
                            intNumMaxLinha = Integer.MaxValue
                        End If
                        [NewValue] = Convert.ToInt32((intNumLinhaVerificada / intNumMaxLinha) * 100)
                        frmPrincipal.intProgresso = [NewValue]
                        frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoPrincipal
                        blnSucessoImportarTabelaBensEletronorteCentroCustoPrincipal = True
                        dblPorcentagem = [NewValue]
                        dblTempoTotalEstimado = 100 * tspDiferencaTempo.TotalMinutes / dblPorcentagem
                        dblTempoRestanteEstimado = dblTempoTotalEstimado - tspDiferencaTempo.TotalMinutes
                        [NewItem](0) = New ListViewItem("Número de linhas total: ", 0)
                        [NewItem](0).SubItems.Add(intNumMaxLinha.ToString())
                        [NewItem](1) = New ListViewItem("Número de linhas verificadas: ", 1)
                        [NewItem](1).SubItems.Add(intNumLinhaVerificada.ToString())
                        [NewItem](2) = New ListViewItem("Número de linhas adicionadas: ", 2)
                        [NewItem](2).SubItems.Add(intNumLinhaAdicionada.ToString())
                        [NewItem](3) = New ListViewItem("Porcentagem Conluída: ", 3)
                        [NewItem](3).SubItems.Add(dblPorcentagem & " %")
                        [NewItem](4) = New ListViewItem("Horário de início: ", 4)
                        [NewItem](4).SubItems.Add(dtmTempoInicial.ToString())
                        [NewItem](5) = New ListViewItem("Tempo Atual: ", 5)
                        [NewItem](5).SubItems.Add(dtmTempoParcial.ToString())
                        [NewItem](6) = New ListViewItem("Tempo transcorrido: ", 6)
                        [NewItem](6).SubItems.Add(tspDiferencaTempo.ToString())
                        [NewItem](7) = New ListViewItem("Tempo restante estimado: ", 7)
                        [NewItem](7).SubItems.Add(dblTempoRestanteEstimado & " (min)")
                        [NewItem](8) = New ListViewItem("Tempo total estimado: ", 8)
                        [NewItem](8).SubItems.Add(dblTempoTotalEstimado & " (min)")
                        [NewItem](9) = New ListViewItem("Número do Termo de Responsabilidade Geral: ", 9)
                        '[NewItem](9).SubItems.Add(String.Empty)
                        [NewItem](10) = New ListViewItem("Registro adicionado: ", 10)
                        '[NewItem](10).SubItems.Add(String.Empty)
                        Me.Invoke(f, New Object() {[NewItem]})
                        Me.Invoke(g, New Object() {[NewValue]})
                    End If
                    System.Threading.Thread.Sleep(1)
                End While
                tspDiferencaTempo = dtmTempoParcial - dtmTempoInicial
                dblPorcentagem = 100
                [NewValue] = Convert.ToInt32(dblPorcentagem)
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoPrincipal
                blnSucessoImportarTabelaBensEletronorteCentroCustoPrincipal = True
                dblTempoTotalEstimado = 100 * tspDiferencaTempo.TotalMinutes / dblPorcentagem
                dblTempoRestanteEstimado = dblTempoTotalEstimado - tspDiferencaTempo.TotalMinutes
                [NewItem](0) = New ListViewItem("Número de linhas total: ", 0)
                [NewItem](0).SubItems.Add(intNumMaxLinha.ToString())
                [NewItem](1) = New ListViewItem("Número de linhas verificadas: ", 1)
                [NewItem](1).SubItems.Add(intNumLinhaVerificada.ToString())
                [NewItem](2) = New ListViewItem("Número de linhas adicionadas: ", 2)
                [NewItem](2).SubItems.Add(intNumLinhaAdicionada.ToString())
                [NewItem](3) = New ListViewItem("Porcentagem Conluída: ", 3)
                [NewItem](3).SubItems.Add(dblPorcentagem & " %")
                [NewItem](4) = New ListViewItem("Horário de início: ", 4)
                [NewItem](4).SubItems.Add(dtmTempoInicial.ToString())
                [NewItem](5) = New ListViewItem("Tempo Atual: ", 5)
                [NewItem](5).SubItems.Add(dtmTempoParcial.ToString())
                [NewItem](6) = New ListViewItem("Tempo transcorrido: ", 6)
                [NewItem](6).SubItems.Add(tspDiferencaTempo.ToString())
                [NewItem](7) = New ListViewItem("Tempo restante estimado: ", 7)
                [NewItem](7).SubItems.Add(dblTempoRestanteEstimado & " (min)")
                [NewItem](8) = New ListViewItem("Tempo total estimado: ", 8)
                [NewItem](8).SubItems.Add(dblTempoTotalEstimado & " (min)")
                [NewItem](9) = New ListViewItem(String.Empty, 9)
                [NewItem](9).SubItems.Add(String.Empty)
                [NewItem](10) = New ListViewItem(String.Empty, 10)
                [NewItem](10).SubItems.Add(String.Empty)
                Me.Invoke(f, New Object() {[NewItem]})
                Me.Invoke(g, New Object() {[NewValue]})

                objArquivoTXT.prpLeitorTexto.Close()

                Dim objBDPrincipalTemp As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, "SELECT DISTINCT tblCentroCustoTemp.* FROM tblCentroCustoTemp", clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objBDPrincipalTemp.mtdAbrirConexao()
                objBDPrincipalTemp.mtdExecutarComando()
                Dim numMaxRegistroDR As Integer = objBDPrincipalTemp.mtdNumeroLinhas() - 1
                objBDPrincipalTemp.mtdDefinirLeitorDados()
                For contador As Integer = 0 To numMaxRegistroDR Step 1
                    objBDPrincipalTemp.mtdProximoRegistro()
                    objBDPrincipal.mtdExecutarComando("INSERT INTO tblCentroCusto (CentroCusto, Orgao, OrgaoDescricao) VALUES ('" & objBDPrincipalTemp.mtdObterValorRegistro(0).ToString() & "', '" & objBDPrincipalTemp.mtdObterValorRegistro(1).ToString() & "', '" & objBDPrincipalTemp.mtdObterValorRegistro(2).ToString() & "');")
                Next
                objBDPrincipal.mtdExecutarComando("DROP TABLE tblCentroCustoTemp;")
                objBDPrincipalTemp.mtdFecharConexao()
                objBDPrincipal.Dispose()
                objBDPrincipalTemp.Dispose()
                If blnComandoImplementadoPermitirMensagemTabelaBensEletronorteCentroCustoPrincipal Then
                    MessageBox.Show("A importação dos dados finalizou com sucesso.", "Aviso!", MessageBoxButtons.OK)
                End If
            Catch ex As System.Exception
                If blnComandoImplementadoPermitirMensagemTabelaBensEletronorteCentroCustoPrincipal Then
                    MessageBox.Show("Ocorreu algum erro ao importar o arquivo.", "Aviso!", MessageBoxButtons.OK)
                End If
                Dim strExcecao As String = "mtdPreencherDtg: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub
    End Class
End Namespace