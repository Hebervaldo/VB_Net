Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmBens
        Private ThImportarTabelaBensEletronorteColetor As System.Threading.Thread

        Private strNomeProcessoImportarTabelaBensEletronorteColetor As String = "Importar Tabela de Bens da Eletronorte - Coletor"

        Friend Sub mtdIniciarThreadImportarTabelaBensEletronorteColetor()
            mtdIniciarThreadImportarTabelaBensEletronorteColetor(True)
        End Sub

        Friend Sub mtdIniciarThreadImportarTabelaBensEletronorteColetor(ByVal Iniciar As Boolean)
            Try
                [NewValue] = 0
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteColetor
                blnAbortarThreadImportarTabelaBensEletronorteColetor = Not Iniciar
                blnForcarAbortarThreadImportarTabelaBensEletronorteColetor = False
                blnThreadAtivadaImportarTabelaBensEletronorteColetor = True
                blnSucessoImportarTabelaBensEletronorteColetor = False
                ThImportarTabelaBensEletronorteColetor = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImportarTabelaBensEletronorteColetor))
                ThImportarTabelaBensEletronorteColetor.IsBackground = True
                ThImportarTabelaBensEletronorteColetor.Priority = System.Threading.ThreadPriority.Normal
                ThImportarTabelaBensEletronorteColetor.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImportarTabelaBensEletronorteColetor: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImportarTabelaBensEletronorteColetor()
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteColetor
            blnAbortarThreadImportarTabelaBensEletronorteColetor = False
            blnForcarAbortarThreadImportarTabelaBensEletronorteColetor = False

            blnThreadAtivadaImportarTabelaBensEletronorteColetor = True
            blnSucessoImportarTabelaBensEletronorteColetor = False
        End Sub

        Private Shared blnForcarAbortarThreadImportarTabelaBensEletronorteColetor As Boolean = False
        Private Shared blnAbortarThreadImportarTabelaBensEletronorteColetor As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImportarTabelaBensEletronorteColetor As Integer = 1000

        Friend Sub mtdAbortarThreadImportarTabelaBensEletronorteColetor()
            mtdAbortarThreadImportarTabelaBensEletronorteColetor(False)
        End Sub

        Friend Sub mtdAbortarThreadImportarTabelaBensEletronorteColetor(ByVal Forcar As Boolean)
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteColetor
            blnAbortarThreadImportarTabelaBensEletronorteColetor = True
            blnForcarAbortarThreadImportarTabelaBensEletronorteColetor = Forcar

            blnThreadAtivadaImportarTabelaBensEletronorteColetor = False
            blnSucessoImportarTabelaBensEletronorteColetor = False

            Try
                ThImportarTabelaBensEletronorteColetor.Join(intTempoSaidaAbortarThreadImportarTabelaBensEletronorteColetor)
                ThImportarTabelaBensEletronorteColetor.Abort()
                ThImportarTabelaBensEletronorteColetor = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImportarTabelaBensEletronorteColetor: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImportarTabelaBensEletronorteColetor()
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteColetor
            blnAbortarThreadImportarTabelaBensEletronorteColetor = True
            blnForcarAbortarThreadImportarTabelaBensEletronorteColetor = True

            blnThreadAtivadaImportarTabelaBensEletronorteColetor = False
            blnSucessoImportarTabelaBensEletronorteColetor = False
        End Sub

        Private Shared LockerImportarTabelaBensEletronorteColetor As New Object()

        Private Sub mtdRotinaThreadImportarTabelaBensEletronorteColetor()
            While Not blnForcarAbortarThreadImportarTabelaBensEletronorteColetor
                If Not blnAbortarThreadImportarTabelaBensEletronorteColetor Then
                    'System.Threading.Monitor.Enter(LockerImportarTabelaBensEletronorteColetor)
                    SyncLock (LockerImportarTabelaBensEletronorteColetor)
                        Try
                            mtdImportarTabelaBensEletronorteColetor _
                            ( _
                            blnComandoImplementadoDeletarDadosTabelaBensEletronorteColetor, _
                            blnComandoImplementadoInserirDadosTabelaBensEletronorteColetor _
                            )
                            mtdAbortarThreadImportarTabelaBensEletronorteColetor(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImportarTabelaBensEletronorteColetor)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImportarTabelaBensEletronorteColetor As Boolean = False
        Friend blnSucessoImportarTabelaBensEletronorteColetor As Boolean = False

        Private lngCodigoImportarTabelaBensEletronorteColetor As Long = 0

        Protected Friend Sub mtdImportarTabelaBensEletronorteColetor()
            mtdImportarTabelaBensEletronorteColetor(True, True)
        End Sub

        Protected Friend Sub mtdImportarTabelaBensEletronorteColetor(ByVal Deletar As Boolean, ByVal Inserir As Boolean)
            'Dim isWatching As Boolean = frmPrincipal.m_bIsWatching

            'If isWatching Then
            '    frmPrincipal.mtdMonitorarDiretorioArquivo()
            'End If

            blnComandoImplementadoDeletarDadosTabelaBensEletronorteColetor = Deletar
            blnComandoImplementadoInserirDadosTabelaBensEletronorteColetor = Inserir
            If Deletar Then
                mtdDeletarTabelaBensEletronorteColetor()
                mtdDeletarDadosTabelaBensEletronorteColetor()
            End If
            mtdCriarTabelaBensEletronorteColetor()
            If Inserir Then
                mtdInserirDadosTabelaBensEletronorteColetor()
            End If

            'If isWatching Then
            '    frmPrincipal.mtdMonitorarDiretorioArquivo()
            'End If
        End Sub

        Private colServerCE As Integer = 1
        Private linServerCE As Integer = 0
        Private intcolunaSQLColetor As Integer = 0
        Private intlinhaServerCE As Integer = 0

        Private intNumeroColunasColetor As Integer = 0
        Private intNumeroLinhasColetor As Integer = 0
        Private vetTipoColunasColetor As String()
        Private camposColetor As String()()
        Private vetLinhaTextoServerCE As String()
        Private FiltroServerCE As String = "40000"

        Public blnComandoImplementadoDeletarDadosTabelaBensEletronorteColetor As Boolean = True

        Public Sub mtdDeletarTabelaBensEletronorteColetor()
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                         strConexaoBancoDadosColetor, _
            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE _
                                                                         )

            objBDColetor.mtdDeletarTabela(strNomeTabelaColetor)
            objBDColetor.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaBensEletronorteColetor()
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

        Public blnComandoImplementadoPermitirMensagemTabelaBensEletronorteColetor As Boolean = True

        Public Sub mtdCriarTabelaBensEletronorteColetor()
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosColetor, _
                                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            intcolunaSQLColetor = 11

            camposColetor = New String(intcolunaSQLColetor)() {}
            camposColetor(0) = New String(3) {"Imobilizado", "NVARCHAR", "255", String.Empty}
            camposColetor(1) = New String(3) {"Patrimonio", "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyPatrimonio PRIMARY KEY"}
            camposColetor(2) = New String(3) {"Denominacao", "NVARCHAR", "255", String.Empty}
            camposColetor(3) = New String(3) {"Denominacao_Extra", "NVARCHAR", "255", String.Empty}
            camposColetor(4) = New String(3) {"N_Serie", "NVARCHAR", "255", String.Empty}
            camposColetor(5) = New String(3) {"Sala", "NVARCHAR", "255", String.Empty}
            camposColetor(6) = New String(3) {"Matricula", "INTEGER", String.Empty, String.Empty}
            camposColetor(7) = New String(3) {"Centro_Custo", "INTEGER", String.Empty, String.Empty}
            camposColetor(8) = New String(3) {"Atividade", "NVARCHAR", "255", String.Empty}
            camposColetor(9) = New String(3) {"Orgao", "NVARCHAR", "255", String.Empty}
            camposColetor(10) = New String(3) {"TRG", "NVARCHAR", "255", String.Empty}
            camposColetor(11) = New String(3) {"Placa_Veiculo", "NVARCHAR", "255", String.Empty}

            objBDColetor.mtdCriarTabela(strNomeTabelaColetor, camposColetor)
            objBDColetor.Dispose()
        End Sub

        Public blnComandoImplementadoInserirDadosTabelaBensEletronorteColetor As Boolean = True

        Private Sub mtdInserirDadosTabelaBensEletronorteColetor()
            Try
                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                        strConexaoBancoDadosPrincipal, _
                                                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                        strConexaoBancoDadosColetor, _
                                                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

                'objBDPrincipal.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosPrincipal)

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
                    System.Threading.Thread.Sleep(1)
                End While

                count = 0

                objBDPrincipal.mtdFecharConexao()
                objBDPrincipal.mtdSelecionarDados("*", strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal)
                Dim intNumeroLinhasTermoResponsabilidadeGeral As Integer = objBDPrincipal.mtdNumeroLinhas()
                Dim vetTermoResponsabilidadeGeral As String() = New String(intNumeroLinhasTermoResponsabilidadeGeral - 1) {}

                objBDPrincipal.mtdDefinirLeitorDados()

                While objBDPrincipal.mtdProximoRegistro()
                    vetTermoResponsabilidadeGeral(count) = System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(0))

                    count += 1
                    System.Threading.Thread.Sleep(1)
                End While

                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteColetor
                blnSucessoImportarTabelaBensEletronortePrincipal = True

                Dim dados As String()() = New String(1)() {}
                dados(0) = New String(intcolunaSQLColetor) {}
                dados(0)(0) = camposColetor(0)(0)

                Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
                Dim objArquivoTXT As clsArquivoTXT = New clsArquivoTXT()
                Dim numLinhaArquivoTXT As Integer = 0

                objArquivoTXT.mtdAbrirLeitorTexto(strArquivo)

                Dim intNumMaxLinha As Integer = Integer.MaxValue

                While (Not objArquivoTXT.getFimArquivo)
                    numLinhaArquivoTXT += 1

                    If numLinhaArquivoTXT <= 10 Then
                        Dim strConteudo As String = String.Empty
                        Dim strLinha As String = objArquivoTXT.mtdLeitorTextoLinha()

                        If strLinha.Contains("Registros selecionados:") Then
                            For contador As Integer = 0 To strLinha.Length - 1 Step 1
                                If Not Convert.ToInt32(strLinha.Chars(contador)) = Convert.ToInt32(":"c) Then
                                    strConteudo = strLinha.Split(":"c)(1)
                                    intNumMaxLinha = Int32.Parse(strConteudo.Trim())
                                    numLinhaArquivoTXT = intNumMaxLinha
                                    Exit While
                                End If
                            Next
                        End If
                    End If

                    System.Threading.Thread.Sleep(1)
                End While

                objArquivoTXT.prpLeitorTexto.Close()

                Dim strLinhaTexto As String = String.Empty
                Dim intCabecalho As Integer = 0
                'Dim blnVerificado As Boolean = False
                For coluna As Integer = camposColetor.GetLowerBound(0) To camposColetor.GetUpperBound(0) Step 1
                    dados(0)(coluna) = camposColetor(coluna)(0)
                    System.Threading.Thread.Sleep(1)
                Next

                objArquivoTXT.mtdAbrirLeitorTexto()

                While (Not objArquivoTXT.getFimArquivo)
                    If blnAbortarThreadImportarTabelaBensEletronorteColetor And blnForcarAbortarThreadImportarTabelaBensEletronorteColetor Then
                        GoTo SaidaInserirDadosTabelaBensEletronorteColetor
                    End If

                    vetLinhaTextoServerCE = Nothing
                    strLinhaTexto = objArquivoTXT.prpLeitorTexto.ReadLine()
                    'If Not blnVerificado Then
                    '    If (strLinhaTexto.Contains(String.Format("|{0} |", strColuna))) Then
                    '        vetLinhaTexto = New String(intcoluna) {}
                    '        vetLinhaTexto = strLinhaTexto.Split("|"c)
                    '        blnVerificado = True
                    '    End If
                    'End If

                    Dim blnContemFiltroImportacao As Boolean = False
                    For count = vetFiltroImportacao.GetLowerBound(0) To vetFiltroImportacao.GetUpperBound(0) Step 1
                        blnContemFiltroImportacao = blnContemFiltroImportacao Or strLinhaTexto.Contains(vetFiltroImportacao(count))
                        System.Threading.Thread.Sleep(1)
                    Next

                    Dim blnContemTermoResponsabilidadeGeral As Boolean = False
                    For count = vetTermoResponsabilidadeGeral.GetLowerBound(0) To vetTermoResponsabilidadeGeral.GetUpperBound(0) Step 1
                        blnContemTermoResponsabilidadeGeral = blnContemTermoResponsabilidadeGeral Or strLinhaTexto.Contains(vetTermoResponsabilidadeGeral(count))
                        System.Threading.Thread.Sleep(1)
                    Next

                    If (blnContemFiltroImportacao And blnContemTermoResponsabilidadeGeral) Then
                        vetLinhaTextoServerCE = New String(intcolunaSQLColetor) {}
                        vetLinhaTextoServerCE = strLinhaTexto.Split("|"c)
                    End If

                    If Not vetLinhaTextoServerCE Is Nothing Then
                        dados(1) = New String(intcolunaSQLColetor) {}
                        colServerCE = 0
                        For coluna As Integer = vetLinhaTextoServerCE.GetLowerBound(0) To vetLinhaTextoServerCE.GetUpperBound(0) Step 1
                            If colServerCE = 8 Then
                                dados(1)(8) = String.Format("'{0}'", strModoCapitalizacao)
                                colServerCE += 1
                            End If

                            Select Case coluna
                                Case 1
                                    dados(1)(0) = String.Format("{0}", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoServerCE(coluna)))
                                    colServerCE += 1
                                Case 2
                                    dados(1)(1) = String.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoServerCE(coluna)))
                                    colServerCE += 1
                                Case 3
                                    dados(1)(2) = String.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoServerCE(coluna)))
                                    colServerCE += 1
                                Case 4
                                    dados(1)(3) = String.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoServerCE(coluna)))
                                    colServerCE += 1
                                Case 5
                                    dados(1)(4) = String.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoServerCE(coluna)))
                                    colServerCE += 1
                                Case 8
                                    dados(1)(5) = String.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoServerCE(coluna)))
                                    colServerCE += 1
                                Case 10
                                    dados(1)(6) = String.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoServerCE(coluna)))
                                    colServerCE += 1
                                Case 11
                                    dados(1)(7) = String.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoServerCE(coluna)))
                                    colServerCE += 1
                                Case 14
                                    dados(1)(9) = String.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoServerCE(coluna)))
                                    colServerCE += 1
                                Case 12
                                    dados(1)(10) = String.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoServerCE(coluna)))
                                    colServerCE += 1
                                Case 9
                                    dados(1)(11) = String.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoServerCE(coluna)))
                                    colServerCE += 1
                            End Select
                            System.Threading.Thread.Sleep(1)
                        Next
                        objBDColetor.mtdInserirDados(strNomeTabelaColetor, dados)
                    End If
                    [NewValue] = Convert.ToInt32((linServerCE / numLinhaArquivoTXT) * 100)
                    Try
                        Me.BeginInvoke(f, New Object() {[NewValue]})
                    Catch ex As System.Exception
                    End Try
                    frmPrincipal.intProgresso = [NewValue]
                    frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteColetor
                    blnSucessoImportarTabelaBensEletronortePrincipal = True
                    linServerCE += 1
                    System.Threading.Thread.Sleep(1)
                End While

SaidaInserirDadosTabelaBensEletronorteColetor:
                [NewValue] = 100
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As System.Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteColetor
                blnSucessoImportarTabelaBensEletronortePrincipal = True

                objArquivoTXT.prpLeitorTexto.Close()
                objBDPrincipal.Dispose()
                objBDColetor.Dispose()

                If blnComandoImplementadoPermitirMensagemTabelaBensEletronorteColetor Then
                    System.Windows.Forms.MessageBox.Show( _
                        "A importação dos dados finalizou com sucesso.", _
                        "Aviso!", _
                        MessageBoxButtons.OK, _
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, _
                        MessageBoxOptions.DefaultDesktopOnly _
                        )
                End If
            Catch ex As System.Exception
                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex_ As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronorteColetor
                blnSucessoImportarTabelaBensEletronortePrincipal = False
            End Try
        End Sub
    End Class
End Namespace