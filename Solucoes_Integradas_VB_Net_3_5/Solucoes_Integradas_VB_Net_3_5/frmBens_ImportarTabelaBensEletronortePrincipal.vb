Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmBens
        Private ThImportarTabelaBensEletronortePrincipal As System.Threading.Thread

        Private strNomeProcessoImportarTabelaBensEletronortePrincipal As String = "Importar Tabela de Bens da Eletronorte - Principal"

        Friend Sub mtdIniciarThreadImportarTabelaBensEletronortePrincipal()
            mtdIniciarThreadImportarTabelaBensEletronortePrincipal(True)
        End Sub

        Friend Sub mtdIniciarThreadImportarTabelaBensEletronortePrincipal(ByVal Iniciar As Boolean)
            Try
                [NewValue] = 0
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronortePrincipal
                blnAbortarThreadImportarTabelaBensEletronortePrincipal = Not Iniciar
                blnForcarAbortarThreadImportarTabelaBensEletronortePrincipal = False
                blnThreadAtivadaImportarTabelaBensEletronortePrincipal = True
                blnSucessoImportarTabelaBensEletronortePrincipal = False
                ThImportarTabelaBensEletronortePrincipal = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImportarTabelaBensEletronortePrincipal))
                ThImportarTabelaBensEletronortePrincipal.IsBackground = True
                ThImportarTabelaBensEletronortePrincipal.Priority = System.Threading.ThreadPriority.Normal
                ThImportarTabelaBensEletronortePrincipal.Start()
            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImportarTabelaBensEletronortePrincipal: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImportarTabelaBensEletronortePrincipal()
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronortePrincipal
            blnAbortarThreadImportarTabelaBensEletronortePrincipal = False
            blnForcarAbortarThreadImportarTabelaBensEletronortePrincipal = False

            blnThreadAtivadaImportarTabelaBensEletronortePrincipal = True
            blnSucessoImportarTabelaBensEletronortePrincipal = False
        End Sub

        Private Shared blnForcarAbortarThreadImportarTabelaBensEletronortePrincipal As Boolean = False
        Private Shared blnAbortarThreadImportarTabelaBensEletronortePrincipal As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImportarTabelaBensEletronortePrincipal As Integer = 1000

        Friend Sub mtdAbortarThreadImportarTabelaBensEletronortePrincipal()
            mtdAbortarThreadImportarTabelaBensEletronortePrincipal(False)
        End Sub

        Friend Sub mtdAbortarThreadImportarTabelaBensEletronortePrincipal(ByVal Forcar As Boolean)
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronortePrincipal
            blnAbortarThreadImportarTabelaBensEletronortePrincipal = True
            blnForcarAbortarThreadImportarTabelaBensEletronortePrincipal = Forcar

            blnThreadAtivadaImportarTabelaBensEletronortePrincipal = False
            blnSucessoImportarTabelaBensEletronortePrincipal = False

            Try
                ThImportarTabelaBensEletronortePrincipal.Join(intTempoSaidaAbortarThreadImportarTabelaBensEletronortePrincipal)
                ThImportarTabelaBensEletronortePrincipal.Abort()
                ThImportarTabelaBensEletronortePrincipal = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImportarTabelaBensEletronortePrincipal: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImportarTabelaBensEletronortePrincipal()
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronortePrincipal
            blnAbortarThreadImportarTabelaBensEletronortePrincipal = True
            blnForcarAbortarThreadImportarTabelaBensEletronortePrincipal = True

            blnThreadAtivadaImportarTabelaBensEletronortePrincipal = False
            blnSucessoImportarTabelaBensEletronortePrincipal = False
        End Sub

        Private Shared LockerImportarTabelaBensEletronortePrincipal As New Object()

        Private Sub mtdRotinaThreadImportarTabelaBensEletronortePrincipal()
            While Not blnForcarAbortarThreadImportarTabelaBensEletronortePrincipal
                If Not blnAbortarThreadImportarTabelaBensEletronortePrincipal Then
                    'System.Threading.Monitor.Enter(LockerImportarTabelaBensEletronortePrincipal)
                    SyncLock (LockerImportarTabelaBensEletronortePrincipal)
                        Try
                            mtdImportarTabelaBensEletronortePrincipal _
                            ( _
                            blnComandoImplementadoDeletarDadosTabelaBensEletronortePrincipal, _
                            blnComandoImplementadoInserirDadosTabelaBensEletronortePrincipal _
                            )
                            mtdAbortarThreadImportarTabelaBensEletronortePrincipal(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImportarTabelaBensEletronortePrincipal)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImportarTabelaBensEletronortePrincipal As Boolean = False
        Friend blnSucessoImportarTabelaBensEletronortePrincipal As Boolean = False

        Private lngCodigoImportarTabelaBensEletronortePrincipal As Long = 0

        Protected Friend Sub mtdImportarTabelaBensEletronortePrincipal()
            mtdImportarTabelaBensEletronortePrincipal(True, True)
        End Sub

        Protected Friend Sub mtdImportarTabelaBensEletronortePrincipal(ByVal Deletar As Boolean, ByVal Inserir As Boolean)
            blnComandoImplementadoDeletarDadosTabelaBensEletronortePrincipal = Deletar
            blnComandoImplementadoInserirDadosTabelaBensEletronortePrincipal = Inserir
            If Deletar Then
                mtdDeletarTabelaBensEletronortePrincipal()
                mtdDeletarDadosTabelaBensEletronortePrincipal()
            End If
            mtdCriarTabelaBensEletronortePrincipal()
            If Inserir Then
                mtdInserirDadosTabelaBensEletronortePrincipal()
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
        Private FiltroPrincipal As String = "40000"

        Public blnComandoImplementadoDeletarDadosTabelaBensEletronortePrincipal As Boolean = True

        Public Sub mtdDeletarTabelaBensEletronortePrincipal()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdDeletarTabela(strNomeTabelaPrincipal)
            objBDPrincipal.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaBensEletronortePrincipal()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdDeletarDados(strNomeTabelaPrincipal, strColunaPrincipal, "LIKE", "'%'")
            objBDPrincipal.Dispose()
        End Sub

        Public blnComandoImplementadoPermitirMensagemTabelaBensEletronortePrincipal As Boolean = True

        Public Sub mtdCriarTabelaBensEletronortePrincipal()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            intcolunaPrincipal = 9

            camposPrincipal = New String(intcolunaPrincipal)() {}
            camposPrincipal(0) = New String(3) {"Imobilizado", "TEXT", "255", String.Empty}
            camposPrincipal(1) = New String(3) {"Patrimonio", "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyPatrimonio PRIMARY KEY"}
            camposPrincipal(2) = New String(3) {"Denominacao", "TEXT", "255", String.Empty}
            camposPrincipal(3) = New String(3) {"Denominacao_Extra", "TEXT", "255", String.Empty}
            camposPrincipal(4) = New String(3) {"N_Serie", "TEXT", "255", String.Empty}
            camposPrincipal(5) = New String(3) {"Sala", "TEXT", "255", String.Empty}
            camposPrincipal(6) = New String(3) {"Matricula", "INTEGER", String.Empty, String.Empty}
            camposPrincipal(7) = New String(3) {"Centro_Custo", "INTEGER", String.Empty, String.Empty}
            camposPrincipal(8) = New String(3) {"Atividade", "TEXT", "255", String.Empty}
            camposPrincipal(9) = New String(3) {"Orgao", "TEXT", "255", String.Empty}

            objBDPrincipal.mtdCriarTabela(strNomeTabelaPrincipal, camposPrincipal)
            objBDPrincipal.Dispose()
        End Sub

        Public blnComandoImplementadoInserirDadosTabelaBensEletronortePrincipal As Boolean = True

        Private Sub mtdInserirDadosTabelaBensEletronortePrincipal()
            Try
                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                        strConexaoBancoDadosPrincipal, _
                                                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

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

                objBDPrincipal.mtdSelecionarDados("*", strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal)
                Dim intNumeroLinhasTermoResponsabilidadeGeral As Integer = objBDPrincipal.mtdNumeroLinhas()
                Dim vetTermoResponsabilidadeGeral As String() = New String(intNumeroLinhasTermoResponsabilidadeGeral - 1) {}

                objBDPrincipal.mtdDefinirLeitorDados()

                While objBDPrincipal.mtdProximoRegistro()
                    vetTermoResponsabilidadeGeral(count) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(0))

                    count += 1
                    System.Threading.Thread.Sleep(1)
                End While

                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronortePrincipal
                blnSucessoImportarTabelaBensEletronortePrincipal = True

                Dim dados As String()() = New String(1)() {}
                dados(0) = New String(intcolunaPrincipal) {}
                dados(0)(0) = camposPrincipal(0)(0)

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
                For coluna As Integer = camposPrincipal.GetLowerBound(0) To camposPrincipal.GetUpperBound(0) Step 1
                    dados(0)(coluna) = camposPrincipal(coluna)(0)
                    System.Threading.Thread.Sleep(1)
                Next

                objArquivoTXT.mtdAbrirLeitorTexto()

                While (Not objArquivoTXT.getFimArquivo)
                    If blnAbortarThreadImportarTabelaBensEletronortePrincipal And blnForcarAbortarThreadImportarTabelaBensEletronortePrincipal Then
                        GoTo SaidaInserirDadosTabelaBensEletronortePrincipal
                    End If

                    vetLinhaTextoPrincipal = Nothing
                    strLinhaTexto = objArquivoTXT.prpLeitorTexto.ReadLine()
                    'If Not blnVerificado Then
                    '    If (strLinhaTexto.Contains(String.Format("|{0} |", strColuna))) Then
                    '        vetLinhaTexto = New String(intcoluna) {}
                    '        vetLinhaTexto = strLinhaTexto.Split("|"c)
                    '        blnVerificado = True
                    '    End If
                    'End If

                    Dim blnContemFiltroImportacao As Boolean = True
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
                        vetLinhaTextoPrincipal = New String(intcolunaPrincipal) {}
                        vetLinhaTextoPrincipal = strLinhaTexto.Split("|"c)
                    End If

                    If Not vetLinhaTextoPrincipal Is Nothing Then
                        dados(1) = New String(intcolunaPrincipal) {}
                        colPrincipal = 0
                        For coluna As Integer = vetLinhaTextoPrincipal.GetLowerBound(0) To vetLinhaTextoPrincipal.GetUpperBound(0) Step 1
                            If colPrincipal = 8 Then
                                dados(1)(colPrincipal) = String.Format("'{0}'", strModoCapitalizacao)
                                colPrincipal += 1
                            End If

                            Select Case coluna
                                Case 1
                                    dados(1)(colPrincipal) = String.Format("{0}", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoPrincipal(coluna)))
                                    colPrincipal += 1
                                Case 2, 3, 4, 5, 8, 10, 11, 14
                                    dados(1)(colPrincipal) = String.Format("'{0}'", objManipuladorTexto.mtdExecutarTudo(vetLinhaTextoPrincipal(coluna)))
                                    colPrincipal += 1
                            End Select
                            System.Threading.Thread.Sleep(1)
                        Next
                        objBDPrincipal.mtdFecharConexao()
                        objBDPrincipal.mtdInserirDados(strNomeTabelaPrincipal, dados)
                    End If
                    [NewValue] = Convert.ToInt32((linPrincipal / numLinhaArquivoTXT) * 100)
                    Try
                        Me.BeginInvoke(f, New Object() {[NewValue]})
                    Catch ex As Exception
                    End Try
                    frmPrincipal.intProgresso = [NewValue]
                    frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronortePrincipal
                    blnSucessoImportarTabelaBensEletronortePrincipal = True
                    linPrincipal += 1
                    System.Threading.Thread.Sleep(1)
                End While

SaidaInserirDadosTabelaBensEletronortePrincipal:
                [NewValue] = 100
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronortePrincipal
                blnSucessoImportarTabelaBensEletronortePrincipal = True

                objArquivoTXT.prpLeitorTexto.Close()
                objBDPrincipal.Dispose()

                If blnComandoImplementadoPermitirMensagemTabelaBensEletronortePrincipal Then
                    System.Windows.Forms.MessageBox.Show( _
                                  "A importação dos dados finalizou com sucesso.", _
                                  "Aviso!", _
                                  MessageBoxButtons.OK, _
                                  MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, _
                                  MessageBoxOptions.DefaultDesktopOnly _
                                  )
                End If
            Catch
                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaBensEletronortePrincipal
                blnSucessoImportarTabelaBensEletronortePrincipal = False
            End Try
        End Sub
    End Class
End Namespace