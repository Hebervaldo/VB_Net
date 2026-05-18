Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmImportadorBaseDadosColetor
        Private ThImportarTabelaBensEletronorteCentroCustoColetor As System.Threading.Thread

        Private strNomeProcessoImportarTabelaBensEletronorteCentroCustoColetor As String = "Importar Tabela de Bens - C. Custo - Coletor"
        Friend Sub mtdIniciarThreadImportarTabelaBensEletronorteCentroCustoColetor()
            mtdIniciarThreadImportarTabelaBensEletronorteCentroCustoColetor(True)
        End Sub

        Friend Sub mtdIniciarThreadImportarTabelaBensEletronorteCentroCustoColetor(ByVal Iniciar As Boolean)
            Try
                [NewValue] = 0
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoColetor
                blnAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor = Not Iniciar
                blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor = False
                blnThreadAtivadaImportarTabelaBensEletronorteCentroCustoColetor = True
                blnSucessoImportarTabelaBensEletronorteCentroCustoColetor = False
                ThImportarTabelaBensEletronorteCentroCustoColetor = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImportarTabelaBensEletronorteCentroCustoColetor))
                ThImportarTabelaBensEletronorteCentroCustoColetor.IsBackground = True
                ThImportarTabelaBensEletronorteCentroCustoColetor.Priority = System.Threading.ThreadPriority.Normal
                ThImportarTabelaBensEletronorteCentroCustoColetor.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImportarTabelaBensEletronorteCentroCustoColetor: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImportarTabelaBensEletronorteCentroCustoColetor()
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoColetor
            blnAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor = False
            blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor = False

            blnThreadAtivadaImportarTabelaBensEletronorteCentroCustoColetor = True
            blnSucessoImportarTabelaBensEletronorteCentroCustoColetor = False
        End Sub

        Private Shared blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor As Boolean = False
        Private Shared blnAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor As Integer = 1000

        Friend Sub mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor()
            mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor(False)
        End Sub

        Friend Sub mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor(ByVal Forcar As Boolean)
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoColetor
            blnAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor = True
            blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor = Forcar

            blnThreadAtivadaImportarTabelaBensEletronorteCentroCustoColetor = False
            blnSucessoImportarTabelaBensEletronorteCentroCustoColetor = False

            Try
                ThImportarTabelaBensEletronorteCentroCustoColetor.Join(intTempoSaidaAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor)
                ThImportarTabelaBensEletronorteCentroCustoColetor.Abort()
                ThImportarTabelaBensEletronorteCentroCustoColetor = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImportarTabelaBensEletronorteCentroCustoColetor()
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoColetor
            blnAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor = True
            blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor = True

            blnThreadAtivadaImportarTabelaBensEletronorteCentroCustoColetor = False
            blnSucessoImportarTabelaBensEletronorteCentroCustoColetor = False
        End Sub

        Private Shared LockerImportarTabelaBensEletronorteCentroCustoColetor As New Object()

        Private Sub mtdRotinaThreadImportarTabelaBensEletronorteCentroCustoColetor()
            While Not blnForcarAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor
                If Not blnAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor Then
                    'System.Threading.Monitor.Enter(LockerImportarTabelaBensEletronorteCentroCustoColetor)
                    SyncLock (LockerImportarTabelaBensEletronorteCentroCustoColetor)
                        Try
                            blnComandoImplementadoDeletarDadosTabelaBensEletronorteCentroCustoColetor = True
                            blnComandoImplementadoInserirDadosTabelaBensEletronorteCentroCustoColetor = True
                            mtdImportarTabelaBensEletronorteCentroCustoColetor _
                            ( _
                            blnComandoImplementadoDeletarDadosTabelaBensEletronorteCentroCustoColetor, _
                            blnComandoImplementadoInserirDadosTabelaBensEletronorteCentroCustoColetor _
                            )
                            mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImportarTabelaBensEletronorteCentroCustoColetor)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImportarTabelaBensEletronorteCentroCustoColetor As Boolean = False
        Friend blnSucessoImportarTabelaBensEletronorteCentroCustoColetor As Boolean = False

        Private lngCodigoImportarTabelaBensEletronorteCentroCustoColetor As Long = 0

        Protected Friend Sub mtdImportarTabelaBensEletronorteCentroCustoColetor()
            mtdIniciarThreadImportarTabelaBensEletronorteCentroCustoColetor(True)
        End Sub

        Protected Friend Sub mtdImportarTabelaBensEletronorteCentroCustoColetor(ByVal Deletar As Boolean, ByVal Inserir As Boolean)
            blnComandoImplementadoDeletarDadosTabelaBensEletronorteCentroCustoColetor = Deletar
            blnComandoImplementadoInserirDadosTabelaBensEletronorteCentroCustoColetor = Inserir

            If Deletar Then
                mtdDeletarTabelaBensEletronorteCentroCustoColetor()
                mtdDeletarDadosTabelaBensEletronorteCentroCustoColetor()
            End If
            mtdCriarTabelaBensEletronorteCentroCustoColetor()
            If Inserir Then
                mtdInserirDadosTabelaBensEletronorteCentroCustoColetor()
            End If
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

        Public blnComandoImplementadoDeletarDadosTabelaBensEletronorteCentroCustoColetor As Boolean = True

        Public Sub mtdDeletarTabelaBensEletronorteCentroCustoColetor()
            frmBens.mtdDeletarTabelaBensEletronorteColetor()
            frmCentroCusto.mtdDeletarTabelaCentroCustoColetor()
        End Sub

        Public Sub mtdDeletarDadosTabelaBensEletronorteCentroCustoColetor()
            frmBens.mtdDeletarDadosTabelaBensEletronorteColetor()
            frmCentroCusto.mtdDeletarTabelaCentroCustoColetor()
        End Sub

        Public blnComandoImplementadoPermitirMensagemTabelaBensEletronorteCentroCustoColetor As Boolean = True

        Public Sub mtdCriarTabelaBensEletronorteCentroCustoColetor()
            frmBens.mtdCriarTabelaBensEletronorteColetor()
            frmCentroCusto.mtdCriarTabelaCentroCustoColetor()
        End Sub

        Public blnComandoImplementadoInserirDadosTabelaBensEletronorteCentroCustoColetor As Boolean = True

        Private Sub mtdInserirDadosTabelaBensEletronorteCentroCustoColetor()
            Try
                Dim stbRegistro As System.Text.StringBuilder = New System.Text.StringBuilder()
                Dim [NewItem](10) As ListViewItem
                [NewValue] = 0
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoColetor
                blnSucessoImportarTabelaBensEletronorteCentroCustoColetor = True
                Dim f As SetItemCallback = New SetItemCallback(AddressOf Me.SetItem)
                Dim g As SetValueCallback = New SetValueCallback(AddressOf Me.SetValue)
                Dim Matricula_RG As Integer = 0
                Dim strOrgao As String = String.Empty

                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
                ( _
                frmPrincipal.strConexaoBancoDadosPrincipal, _
                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
                )

                Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
                ( _
                frmPrincipal.strConexaoBancoDadosColetor, _
                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE _
                )

                objBDColetor.mtdAbrirConexao()

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
                    vetTermoResponsabilidadeGeral(count) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(0))

                    count += 1
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

                stbSQL = New System.Text.StringBuilder("CREATE TABLE tblCentroCustoTemp (CentroCusto INTEGER NULL, Orgao TEXT(250) NULL, OrgaoDescricao TEXT(250) NULL);")
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
                                blnContemTermoResponsabilidadeGeral = blnContemTermoResponsabilidadeGeral Or stbBuffer.ToString().Contains(vetTermoResponsabilidadeGeral(count))
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
                                objBDColetor.mtdExecutarComando(stbSQL.ToString())

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
                        frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoColetor
                        blnSucessoImportarTabelaBensEletronorteCentroCustoColetor = True
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
                        System.Threading.Thread.Sleep(1)
                    End If
                End While
                tspDiferencaTempo = dtmTempoParcial - dtmTempoInicial
                dblPorcentagem = 100
                [NewValue] = Convert.ToInt32(dblPorcentagem)
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteCentroCustoColetor
                blnSucessoImportarTabelaBensEletronorteCentroCustoColetor = True
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

                Dim objBDColetorTemp As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosColetor, "SELECT DISTINCT tblCentroCustoTemp.* FROM tblCentroCustoTemp", clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objBDColetorTemp.mtdAbrirConexao()
                objBDColetorTemp.mtdExecutarComando()
                Dim numMaxRegistroDR As Integer = objBDColetorTemp.mtdNumeroLinhas() - 1
                objBDColetorTemp.mtdDefinirLeitorDados()
                For contador As Integer = 0 To numMaxRegistroDR Step 1
                    objBDColetorTemp.mtdProximoRegistro()
                    objBDColetor.mtdExecutarComando("INSERT INTO tblCentroCusto (CentroCusto, Orgao, OrgaoDescricao) VALUES ('" & objBDColetorTemp.mtdObterValorRegistro(0).ToString() & "', '" & objBDColetorTemp.mtdObterValorRegistro(1).ToString() & "', '" & objBDColetorTemp.mtdObterValorRegistro(2).ToString() & "');")
                Next
                objBDColetor.mtdExecutarComando("DROP TABLE tblCentroCustoTemp;")
                objBDColetorTemp.mtdFecharConexao()
                objBDColetor.Dispose()
                objBDColetorTemp.Dispose()
                If blnComandoImplementadoPermitirMensagemTabelaBensEletronorteCentroCustoColetor Then
                    MessageBox.Show("A importação dos dados finalizou com sucesso.", "Aviso!", MessageBoxButtons.OK)
                End If
            Catch ex As System.Exception
                If blnComandoImplementadoPermitirMensagemTabelaBensEletronorteCentroCustoColetor Then
                    MessageBox.Show("Ocorreu algum erro ao importar o arquivo.", "Aviso!", MessageBoxButtons.OK)
                End If

                Dim strExcecao As String = "mtdPreencherDtg: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub
    End Class
End Namespace