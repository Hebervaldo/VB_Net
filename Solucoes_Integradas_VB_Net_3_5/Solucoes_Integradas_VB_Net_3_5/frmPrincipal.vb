Imports Microsoft.Win32
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal

        Public Shared intNumeroLinhasCarteiras As Integer = 100
        Public Shared intNumeroLinhasCautelas As Integer = 100
        Public Shared intNumeroLinhasMBPs As Integer = 100
        Public Shared intNumeroLinhasInventarioBens As Integer = 100
        Public Shared intNumeroLinhasBens As Integer = 100

        Public Shared intMultiplicadorCodigoCarteiras As Integer = 1000000
        Public Shared intMultiplicadorCodigoCautelas As Integer = 1000000
        Public Shared intMultiplicadorCodigoMBPs As Integer = 1000000
        Public Shared intMultiplicadorCodigoInventarioBens As Integer = 1000000
        Public Shared intMultiplicadorCodigoBens As Integer = 1000000

        Public Shared DiretorioArmazenamento As String = "Armazenamento"
        Public Shared DiretorioArmazenamentoCompleto As String = String.Empty
        Public Shared DiretorioArmazenamentoBackupCompleto As String = String.Empty
        Public Shared DiretorioRelatorio As String = "Relatorios"
        Public Shared DiretorioRelatorioCompleto As String = String.Empty
        Public Shared DiretorioTextoEmail As String = "Textos_Email"
        Public Shared DiretorioTextoEmailCompleto As String = String.Empty

        Public Shared cntIntervaloBackup As String = "240"
        Public Shared strIntervaloBackup As String = String.Empty
        Public Shared cntNumeroCopiasBackup As String = "1"
        Public Shared strNumeroCopiasBackup As String = String.Empty

        Public Shared cntNomeServidorPrincipal As String = String.Empty ' Nome do seu servidor.
        Public Shared cntExtensaoBancoDadosPrincipal As String = ".mdb"
        Public Shared cntNomeBancoDadosPrincipal As String = "dbPatrimonio" + cntExtensaoBancoDadosPrincipal ' Nome da base de dados
        Public Shared cntIdentificadorUsuarioPrincipal As String = String.Empty ' Identificador do usuário da base de dados
        Public Shared cntSenhaPrincipal As String = "12345678" ' Senha da base de dados
        Public Shared cntConexaoBancoDadosPrincipal As String = String.Empty
        Public Shared cntEnderecoBancoDadosPrincipal As String = String.Empty
        Public Shared cntTabelaPrincipal As String = String.Empty

        Public Shared strNomeServidorPrincipal As String = String.Empty ' Nome do seu servidor.
        'Public Shared strExtensaoBaseDadosPrincipal As String = String.Empty
        Public Shared strNomeBaseDadosPrincipal As String = String.Empty ' Nome da base de dados
        Public Shared strIdentificadorUsuarioPrincipal As String = String.Empty ' Identificador do usuário da base de dados
        Public Shared strSenhaPrincipal As String = String.Empty ' Senha da base de dados
        Public Shared strConexaoBancoDadosPrincipal As String = String.Empty
        Public Shared strEnderecoBancoDadosPrincipal As String = String.Empty
        Public Shared strTabelaPrincipal As String = String.Empty

        Public Shared cntNomeServidorCADU As String = "10.61.116.29" ' Nome do seu servidor.
        Public Shared cntNomeBaseDadosCADU As String = "cadu" ' Nome da base de dados
        Public Shared cntIdentificadorUsuarioCADU As String = "patrimonio_user" ' Identificador do usuário da base de dados
        Public Shared cntSenhaCADU As String = "p01t53wl" ' Senha da base de dados
        Public Shared cntConexaoBancoDadosCADU As String = String.Empty
        Public Shared cntEnderecoBancoDadosCADU As String = String.Empty
        Public Shared cntTabelaCADU As String = "vw_patrimonio"
        Public Shared cntSegurancaIntegradaCADU As String = "False"
        Public Shared cntInformacaoSegurancaPersistenteCADU As String = "True"

        Public Shared strNomeServidorCADU As String = String.Empty ' Nome do seu servidor.
        Public Shared strNomeBaseDadosCADU As String = String.Empty ' Nome da base de dados
        Public Shared strIdentificadorUsuarioCADU As String = String.Empty ' Identificador do usuário da base de dados
        Public Shared strSenhaCADU As String = String.Empty ' Senha da base de dados
        Public Shared strConexaoBancoDadosCADU As String = String.Empty
        Public Shared strEnderecoBancoDadosCADU As String = String.Empty
        Public Shared strTabelaCADU As String = String.Empty
        Public Shared strSegurancaIntegradaCADU As String = String.Empty
        Public Shared strInformacaoSegurancaPersistenteCADU As String = String.Empty

        Public Shared cntNomeServidorColetor As String = String.Empty ' Nome do seu servidor.
        Public Shared cntExtensaoBancoDadosColetor As String = ".sdf"
        Public Shared cntNomeBancoDadosColetor As String = "dbPatrimonio" + cntExtensaoBancoDadosColetor ' Nome da base de dados
        Public Shared cntIdentificadorUsuarioColetor As String = String.Empty ' Identificador do usuário da base de dados
        Public Shared cntSenhaColetor As String = "12345678" ' Senha da base de dados
        Public Shared cntConexaoBancoDadosColetor As String = String.Empty
        Public Shared cntEnderecoBancoDadosColetor As String = String.Empty
        Public Shared cntTabelaColetor As String = String.Empty

        Public Shared strNomeServidorColetor As String = String.Empty ' Nome do seu servidor.
        'Public Shared strExtensaoBaseDadosColetor As String = String.Empty
        Public Shared strNomeBaseDadosColetor As String = String.Empty ' Nome da base de dados
        Public Shared strIdentificadorUsuarioColetor As String = String.Empty ' Identificador do usuário da base de dados
        Public Shared strSenhaColetor As String = String.Empty ' Senha da base de dados
        Public Shared strConexaoBancoDadosColetor As String = String.Empty
        Public Shared strEnderecoBancoDadosColetor As String = String.Empty
        Public Shared strTabelaColetor As String = String.Empty

        Public Shared strPlanilhaExcelRelatorio As String = "ExportacaoRelatorio"
        Public Shared strPlanilhaExcelSap_R3 As String = "ExportacaoSap_R3"

        Public Shared strNomeArquivoRelatorioCarteira As String = "ImpressaoCarteiras.rpt"
        Public Shared strNomeArquivoRelatorioCautela As String = "ImpressaoCautelas.rpt"
        Public Shared strNomeArquivoRelatorioMBP As String = "ImpressaoMBPs.rpt"
        Public Shared strNomeArquivoRelatorioInventarioBens As String = "ImpressaoInventarioBens.rpt"
        Public Shared strNomeArquivoRelatorioBens As String = "ImpressaoBens.rpt"
        Public Shared strNomeArquivoTextoEmailCarteira As String = "TextoEmailCarteiras.txt"
        Public Shared strNomeArquivoTextoEmailCautela As String = "TextoEmailCautelas.txt"
        Public Shared strNomeArquivoTextoEmailMBP As String = "TextoEmailMBPs.txt"
        Public Shared strNomeArquivoTextoEmailInventarioBens As String = "TextoEmailInventarioBens.txt"
        Public Shared strNomeArquivoTextoEmailBens As String = "TextoEmailBens.txt"
        Public Shared strEnderecoRelatorioCarteira As String = String.Empty
        Public Shared strEnderecoRelatorioCautela As String = String.Empty
        Public Shared strEnderecoRelatorioMBP As String = String.Empty
        Public Shared strEnderecoRelatorioInventarioBens As String = String.Empty
        Public Shared strEnderecoRelatorioBens As String = String.Empty
        Public Shared strEnderecoTextoEmailCarteira As String = String.Empty
        Public Shared strEnderecoTextoEmailCautela As String = String.Empty
        Public Shared strEnderecoTextoEmailMBP As String = String.Empty
        Public Shared strEnderecoTextoEmailInventarioBens As String = String.Empty
        Public Shared strEnderecoTextoEmailBens As String = String.Empty
        Public Shared strEnderecoArquivoImportado As String = String.Empty
        Public Shared numFormularioSelecionado As Integer = 0
        Public Shared strEnderecoAplicativo As String = String.Empty
        Public Shared blnAtualizarData As Boolean = True

        Private Shared objEnderecoAplicativo As clsEnderecoAplicativo = New clsEnderecoAplicativo()
        Private Shared objRegistroWindows As clsRegistroWindows = New clsRegistroWindows()
        Private Shared objCriptografia As clsCriptografia = New clsCriptografia()
        Private varbarProgressivo As Boolean = True
        Private contTempo As Integer = 0
        Private Shared objImportadorBaseDadosPrincipal As frmImportadorBaseDadosPrincipal = New frmImportadorBaseDadosPrincipal()
        Private Shared objImportadorBaseDadosColetor As frmImportadorBaseDadosColetor = New frmImportadorBaseDadosColetor()
        Private Shared intTempoSaidaConexao As Integer = 15
        Protected Friend Shared ThCriarBancoDadosPrincipalColetor As Threading.Thread
        Protected Friend Shared ThCompactarRepararBancoDadosPrincipalColetor As Threading.Thread
        Protected Friend objConfiguracoes As frmConfiguracoes = New frmConfiguracoes()
        Protected Friend objCautela As frmCautelas = New frmCautelas()
        Protected Friend objMBP As frmMBPs = New frmMBPs()
        Protected Friend objCarteira As frmCarteiras = New frmCarteiras()
        Protected Friend objInventarioBens As frmInventarioBens = New frmInventarioBens()
        Protected Friend objCADU As frmCADU = New frmCADU()
        Protected Friend objTabelasAuxiliares As frmTabelasAuxiliares = New frmTabelasAuxiliares()
        Protected Friend objBens As frmBens = New frmBens()
        Protected Friend objCentroCusto As frmCentroCusto = New frmCentroCusto()

        Private intContador As Integer = 1

        'Private objBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
        Public Const cntNomeFormulario As String = "Eletronorte - Soluções Integradas"

        ' Métodos
        Private Sub smnVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnVertical.Click
            Me.LayoutMdi(MdiLayout.TileVertical)
        End Sub

        Private Sub smnCascata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnCascata.Click
            Me.LayoutMdi(MdiLayout.Cascade)
        End Sub

        Public Shared intProgresso As Integer = 0
        Public Shared strNomeProcesso As String = String.Empty

        Private dblTempotmr1_Tick As Double = DateTime.Now.TimeOfDay.TotalMilliseconds
        Private dblDiferencaTempotmr1_Tick As Double = 0

        Private Sub tmr1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr1.Tick
            ' Estrutura de controle do label que mostra as horas na barra de status.
            barlblMostrHorario.Text = String.Format(DateTime.Now.ToString(), "HH:mm")

            If CUInt(strIntervaloBackup) > 0 Then
                tmrSalvarBancoDados.Enabled = True
            Else
                tmrSalvarBancoDados.Enabled = False
            End If

            If Me.Enabled Then
                csmsSair.Visible = True

                If (intProgresso = 100) Then
                    dblDiferencaTempotmr1_Tick = System.DateTime.Now.TimeOfDay.TotalMilliseconds - dblTempotmr1_Tick

                    If dblDiferencaTempotmr1_Tick >= 20000 Then
                        blnSucessoExportarPlanilhaExcelRelatorio = False
                        blnSucessoExportarPlanilhaExcelSap_R3 = False
                        blnSucessoGerarCarteiraCautela = False
                        blnSucessoGerarInventarioCautela = False
                        blnSucessoGerarInventarioMBP = False
                        blnSucessoGerarMBPCautela = False
                        blnSucessoExportarDocumentoCarteira = False
                        blnSucessoExportarDocumentoCautela = False
                        blnSucessoExportarDocumentoMBP = False
                        blnSucessoExportarDocumentoBens = False
                        blnSucessoExportarDocumentoInventarioBens = False
                        blnSucessoImprimirCarteira = False
                        blnSucessoImprimirCautela = False
                        blnSucessoImprimirBens = False
                        blnSucessoImprimirInventarioBens = False
                        blnSucessoImprimirMBP = False
                        objImportadorBaseDadosPrincipal.blnSucessoImportarTabelaBensEletronorteCentroCustoPrincipal = False
                        objImportadorBaseDadosColetor.blnSucessoImportarTabelaBensEletronorteCentroCustoColetor = False
                        objBens.blnSucessoImportarTabelaBensEletronortePrincipal = False
                        objBens.blnSucessoImportarTabelaBensEletronorteColetor = False
                        objCADU.blnSucessoImportarTabelaEmpregadosPrincipal = False
                        objCADU.blnSucessoImportarTabelaEmpregadosColetor = False
                        objCentroCusto.blnSucessoImportarTabelaCentroCustoPrincipal = False
                        objCentroCusto.blnSucessoImportarTabelaCentroCustoColetor = False
                        objInventarioBens.blnSucessoImportarTabelaInventarioBensPrincipal = False
                        objInventarioBens.blnSucessoImportarTabelaInventarioBensColetor = False
                    End If
                End If

                If _
                ( _
                Not blnSucessoExportarPlanilhaExcelRelatorio And _
                Not blnSucessoExportarPlanilhaExcelSap_R3 And _
                Not blnSucessoGerarCarteiraCautela And _
                Not blnSucessoGerarInventarioCautela And _
                Not blnSucessoGerarInventarioMBP And _
                Not blnSucessoGerarMBPCautela And _
                Not blnSucessoExportarDocumentoCarteira And _
                Not blnSucessoExportarDocumentoCautela And _
                Not blnSucessoExportarDocumentoMBP And _
                Not blnSucessoExportarDocumentoBens And _
                Not blnSucessoExportarDocumentoInventarioBens And _
                Not blnSucessoImprimirCarteira And _
                Not blnSucessoImprimirCautela And _
                Not blnSucessoImprimirBens And _
                Not blnSucessoImprimirInventarioBens And _
                Not blnSucessoImprimirMBP And _
                Not objImportadorBaseDadosPrincipal.blnSucessoImportarTabelaBensEletronorteCentroCustoPrincipal And _
                Not objImportadorBaseDadosColetor.blnSucessoImportarTabelaBensEletronorteCentroCustoColetor And _
                Not objBens.blnSucessoImportarTabelaBensEletronortePrincipal And _
                Not objBens.blnSucessoImportarTabelaBensEletronorteColetor And _
                Not objCADU.blnSucessoImportarTabelaEmpregadosPrincipal And _
                Not objCADU.blnSucessoImportarTabelaEmpregadosColetor And _
                Not objCentroCusto.blnSucessoImportarTabelaCentroCustoPrincipal And _
                Not objCentroCusto.blnSucessoImportarTabelaCentroCustoColetor And _
                Not objInventarioBens.blnSucessoImportarTabelaInventarioBensPrincipal And _
                Not objInventarioBens.blnSucessoImportarTabelaInventarioBensColetor _
                ) _
                Then
                    csmsParar.Visible = False
                    'barprgfrmPrincipal.ToolTipText = String.Format("{0}", "Não há Processos")

                    ' Estrutura para controle da barra de progresso da barra de status.
                    If varbarProgressivo Then
                        If Not barprgfrmPrincipal.Value = 100 Then
                            barprgfrmPrincipal.Value += barprgfrmPrincipal.Step
                        End If
                        If Not barprgfrmPrincipal.Value < 100 Then
                            contTempo = 100
                            varbarProgressivo = False
                        End If
                    ElseIf barprgfrmPrincipal.Value > 0 Then
                        barprgfrmPrincipal.Value -= barprgfrmPrincipal.Step
                        If Not barprgfrmPrincipal.Value > 0 Then
                            contTempo = 0
                            varbarProgressivo = True
                        End If
                    End If
                Else
                    If (intProgresso >= 0 And intProgresso <= 100) Then
                        barprgfrmPrincipal.Value = intProgresso
                    End If

                    csmsParar.Visible = True

                    If blnSucessoGerarCarteiraCautela Then
                        mtdExibirNotificacao _
                        ( _
                        String.Format("{0}", strNomeProcesso) & _
                        vbNewLine & _
                        String.Format("Item: {0}", lngCodigoGerarCarteiraCautela) & _
                        vbNewLine & _
                        String.Format("Progresso: {0}%", intProgresso), _
                        "Processo" _
                        )
                    ElseIf blnSucessoGerarInventarioCautela Then
                        mtdExibirNotificacao _
                        ( _
                        String.Format("{0}", strNomeProcesso) & _
                        vbNewLine & _
                        String.Format("Item: {0}", strDadoGerarInventarioCautela) & _
                        vbNewLine & _
                        String.Format("Progresso: {0}%", intProgresso), _
                        "Processo" _
                        )
                    ElseIf blnSucessoGerarInventarioMBP Then
                        mtdExibirNotificacao _
                        ( _
                        String.Format("{0}", strNomeProcesso) & _
                        vbNewLine & _
                        String.Format("Item: {0}", strDadoGerarInventarioMBP) & _
                        vbNewLine & _
                        String.Format("Progresso: {0}%", intProgresso), _
                        "Processo" _
                        )
                    ElseIf blnSucessoGerarMBPCautela Then
                        mtdExibirNotificacao _
                        ( _
                        String.Format("{0}", strNomeProcesso) & _
                        vbNewLine & _
                        String.Format("Item: {0}", lngCodigoGerarMBPCautela) & _
                        vbNewLine & _
                        String.Format("Progresso: {0}%", intProgresso), _
                        "Processo" _
                        )
                    ElseIf blnSucessoImprimirCarteira Then
                        Try
                            mtdExibirNotificacao _
                            ( _
                            String.Format("{0}", strNomeProcesso) & _
                            vbNewLine & _
                            String.Format("Item: {0}", elemento(intContador).ToString()) & _
                            vbNewLine & _
                            String.Format("Progresso: {0}%", intProgresso), _
                            "Processo" _
                            )
                        Catch ex As Exception
                            mtdExibirNotificacao _
                              ( _
                              String.Format("{0}", strNomeProcesso) & _
                              vbNewLine & _
                              String.Format("Item: {0}", frmCarteiras.Codigo.ToString()) & _
                              vbNewLine & _
                              String.Format("Progresso: {0}%", intProgresso), _
                              "Processo" _
                              )
                        End Try
                    ElseIf blnSucessoImprimirCautela Then
                        Try
                            mtdExibirNotificacao _
                            ( _
                            String.Format("{0}", strNomeProcesso) & _
                            vbNewLine & _
                            String.Format("Item: {0}", elemento(intContador).ToString()) & _
                            vbNewLine & _
                            String.Format("Progresso: {0}%", intProgresso), _
                            "Processo" _
                            )
                        Catch ex As Exception
                            mtdExibirNotificacao _
                              ( _
                              String.Format("{0}", strNomeProcesso) & _
                              vbNewLine & _
                              String.Format("Item: {0}", frmCautelas.Codigo.ToString()) & _
                              vbNewLine & _
                              String.Format("Progresso: {0}%", intProgresso), _
                              "Processo" _
                              )
                        End Try
                    ElseIf blnSucessoImprimirBens Then
                        Try
                            mtdExibirNotificacao _
                            ( _
                            String.Format("{0}", strNomeProcesso) & _
                            vbNewLine & _
                            String.Format("Item: {0}", strVetItemsLSV1(intContador)(0)) & _
                            vbNewLine & _
                            String.Format("Progresso: {0}%", intProgresso), _
                            "Processo" _
                            )
                        Catch ex As Exception
                            mtdExibirNotificacao _
                            ( _
                            String.Format("{0}", strNomeProcesso) & _
                            vbNewLine & _
                            String.Format("Item: {0}", frmBens.Numero_Item.ToString()) & _
                            vbNewLine & _
                            String.Format("Progresso: {0}%", intProgresso), _
                            "Processo" _
                            )
                        End Try
                    ElseIf blnSucessoImprimirInventarioBens Then
                        Try
                            mtdExibirNotificacao _
                            ( _
                            String.Format("{0}", strNomeProcesso) & _
                            vbNewLine & _
                            String.Format("Item: {0}", strVetItemsLSV1(intContador)(0)) & _
                            vbNewLine & _
                            String.Format("Progresso: {0}%", intProgresso), _
                            "Processo" _
                            )
                        Catch ex As Exception
                            mtdExibirNotificacao _
                            ( _
                            String.Format("{0}", strNomeProcesso) & _
                            vbNewLine & _
                            String.Format("Item: {0}", frmInventarioBens.Numero_Inventario.ToString()) & _
                            vbNewLine & _
                            String.Format("Progresso: {0}%", intProgresso), _
                            "Processo" _
                            )
                        End Try
                    ElseIf blnSucessoImprimirMBP Then
                        Try
                            mtdExibirNotificacao _
                            ( _
                            String.Format("{0}", strNomeProcesso) & _
                            vbNewLine & _
                            String.Format("Item: {0}", elemento(intContador).ToString()) & _
                            vbNewLine & _
                            String.Format("Progresso: {0}%", intProgresso), _
                            "Processo" _
                            )
                        Catch ex As Exception
                            mtdExibirNotificacao _
                              ( _
                              String.Format("{0}", strNomeProcesso) & _
                              vbNewLine & _
                              String.Format("Item: {0}", frmMBPs.Codigo.ToString()) & _
                              vbNewLine & _
                              String.Format("Progresso: {0}%", intProgresso), _
                              "Processo" _
                              )
                        End Try
                    Else
                        mtdExibirNotificacao _
                        ( _
                        String.Format("{0}", strNomeProcesso) & _
                        vbNewLine & _
                        String.Format("Progresso: {0}%", intProgresso), _
                        "Processo" _
                        )
                    End If
                End If
            End If

            If blnOcultarMensagemTemporariamente Then
                If DateTime.Now.TimeOfDay.TotalMilliseconds - dblOcultarMensagemTemporariamente > 30000 Then
                    csmsMensagens.Text = "&Ocultar Mensagens"
                    smnMensagens.Text = "&Ocultar Mensagens"
                    blnOcultarMensagens = False
                    blnOcultarMensagemTemporariamente = False
                End If
            End If
        End Sub

        Private Sub smnHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnHorizontal.Click
            Me.LayoutMdi(MdiLayout.TileHorizontal)
        End Sub

        Private Sub mtdDesabilitarMenus()
            Me.mnuArquivo.Enabled = False
            Me.smnContasUsuarios.Enabled = False
            Me.mnuFormularios.Enabled = False
            Me.mnuInformacoes.Enabled = False
        End Sub

        Private intHashCode As Long = 0

        Private Sub tmrEdit_Notify_Elapsed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEdit_Notify.Tick
            'If m_bDirty Then
            '    Dim objFileInfo As System.IO.FileInfo = New System.IO.FileInfo(strEnderecoBancoDadosColetor)
            '    If objFileInfo.GetHashCode <> intHashCode Then
            '        Dim objInventarioBens As frmInventarioBens = New frmInventarioBens()
            '        objInventarioBens.mtdIniciarThreadImportarTabelaInventarioBensPrincipal(False)
            '        objInventarioBens.Dispose()
            '    End If

            '    intHashCode = objFileInfo.GetHashCode
            '    m_bDirty = False
            'End If
        End Sub

        Private Shared strChaveCriptografia_Padrao As String = "Chave_Padrao"

        Private Shared Sub mtdIniciarVariaveisBancoDados()
            Dim strSenhaCriptografadaPrincipal As String = String.Empty
            Dim strSenhaCriptografadaCADU As String = String.Empty
            Dim strSenhaCriptografadaColetor As String = String.Empty
            Dim strSenhaDescriptografadaPrincipal As String = String.Empty
            Dim strSenhaDescriptografadaCADU As String = String.Empty
            Dim strSenhaDescriptografadaColetor As String = String.Empty

            strEnderecoAplicativo = objEnderecoAplicativo.Endereco()

            DiretorioArmazenamentoCompleto = String.Format("{0}\{1}\", strEnderecoAplicativo, DiretorioArmazenamento)
            DiretorioRelatorioCompleto = String.Format("{0}\{1}\", strEnderecoAplicativo, DiretorioRelatorio)
            DiretorioTextoEmailCompleto = String.Format("{0}\{1}\", strEnderecoAplicativo, DiretorioTextoEmail)

            DiretorioArmazenamentoBackupCompleto = objRegistroWindows.mtdObterDadosRegistro(Registry.CurrentUser, _
                                                              "Software", _
                                                              "Eletronorte", _
                                                              "Eletronorte - Soluções Integradas", _
                                                              "DiretorioBackupBancoDados").ToString()

            If DiretorioArmazenamentoBackupCompleto = String.Empty Then
                DiretorioArmazenamentoBackupCompleto = DiretorioArmazenamentoCompleto

                objRegistroWindows.mtdSalvarDadosRegistro("DiretorioBackupBancoDados", DiretorioArmazenamentoBackupCompleto)
            End If

            strIntervaloBackup = objRegistroWindows.mtdObterDadosRegistro("IntervaloBackup").ToString()

            If strIntervaloBackup = String.Empty Then
                strIntervaloBackup = cntIntervaloBackup

                objRegistroWindows.mtdSalvarDadosRegistro("IntervaloBackup", strIntervaloBackup)
            End If

            strNumeroCopiasBackup = objRegistroWindows.mtdObterDadosRegistro("NumeroCopiasBackup").ToString()

            If strNumeroCopiasBackup = String.Empty Then
                strNumeroCopiasBackup = cntNumeroCopiasBackup

                objRegistroWindows.mtdSalvarDadosRegistro("NumeroCopiasBackup", strNumeroCopiasBackup)
            End If

            Try
                System.IO.Directory.CreateDirectory(DiretorioArmazenamentoCompleto)
                System.IO.Directory.CreateDirectory(DiretorioRelatorioCompleto)
                System.IO.Directory.CreateDirectory(DiretorioTextoEmailCompleto)
            Catch ex As Exception

            End Try

            strNomeServidorPrincipal = objRegistroWindows.mtdObterDadosRegistro(Registry.CurrentUser, _
                                                                             "Software", _
                                                                             "Eletronorte", _
                                                                             "Eletronorte - Soluções Integradas", _
                                                                             "NomeServidorPrincipal").ToString()

            If strNomeServidorPrincipal.Equals(String.Empty) Then
                strNomeServidorPrincipal = cntNomeServidorPrincipal

                objRegistroWindows.mtdSalvarDadosRegistro(Registry.CurrentUser, _
                                                                             "Software", _
                                                                             "Eletronorte", _
                                                                             "Eletronorte - Soluções Integradas", _
                                                                             "NomeServidorPrincipal", _
                                                                             strNomeServidorPrincipal _
                                                                             )
            End If

            strNomeBaseDadosPrincipal = objRegistroWindows.mtdObterDadosRegistro("NomeBaseDadosPrincipal").ToString()

            If strNomeBaseDadosPrincipal.Equals(String.Empty) Then
                strNomeBaseDadosPrincipal = cntNomeBancoDadosPrincipal

                objRegistroWindows.mtdSalvarDadosRegistro("NomeBaseDadosPrincipal", strNomeBaseDadosPrincipal)
            End If

            strIdentificadorUsuarioPrincipal = objRegistroWindows.mtdObterDadosRegistro("IdentificadorUsuarioPrincipal").ToString()

            If strIdentificadorUsuarioPrincipal.Equals(String.Empty) Then
                strIdentificadorUsuarioPrincipal = cntIdentificadorUsuarioPrincipal

                objRegistroWindows.mtdSalvarDadosRegistro("IdentificadorUsuarioPrincipal", strIdentificadorUsuarioPrincipal)
            End If

            Dim strChaveCriptografiaPrincipal As String = objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaPrincipal").ToString()

            If strChaveCriptografiaPrincipal.Equals(String.Empty) Then
                objRegistroWindows.mtdSalvarDadosRegistro _
                ( _
                "ChaveCriptografiaPrincipal", _
                strChaveCriptografia_Padrao _
                )
            End If

            strSenhaCriptografadaPrincipal = objRegistroWindows.mtdObterDadosRegistro("SenhaPrincipal").ToString()
            If Not strSenhaCriptografadaPrincipal.Equals(String.Empty) Then
                strSenhaDescriptografadaPrincipal = objCriptografia.mtdDesCriptografar(strSenhaCriptografadaPrincipal, _
                                                                    objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaPrincipal").ToString(), _
                                                                    Encryption.Symmetric.Provider.Rijndael)
            Else
                strSenhaDescriptografadaPrincipal = String.Empty
            End If
            strSenhaPrincipal = strSenhaDescriptografadaPrincipal

            If strSenhaPrincipal.Equals(String.Empty) Then
                strSenhaDescriptografadaPrincipal = cntSenhaPrincipal
                strSenhaPrincipal = strSenhaDescriptografadaPrincipal

                strSenhaCriptografadaPrincipal = objCriptografia.mtdCriptografar _
                ( _
                strSenhaPrincipal, _
                objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaPrincipal").ToString(), _
                Encryption.Symmetric.Provider.Rijndael _
                )

                objRegistroWindows.mtdSalvarDadosRegistro _
                ( _
                "SenhaPrincipal", _
                strSenhaCriptografadaPrincipal _
                )
            End If

            strEnderecoBancoDadosPrincipal = objRegistroWindows.mtdObterDadosRegistro("EnderecoBancoDadosPrincipal").ToString()

            If strEnderecoBancoDadosPrincipal.Equals(String.Empty) Then
                strEnderecoBancoDadosPrincipal = DiretorioArmazenamentoCompleto

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoBancoDadosPrincipal", strEnderecoBancoDadosPrincipal)
            End If

            strNomeServidorCADU = objRegistroWindows.mtdObterDadosRegistro(Registry.CurrentUser, _
                                                                                "Software", _
                                                                                "Eletronorte", _
                                                                                "Eletronorte - Soluções Integradas", _
                                                                                "NomeServidorCADU").ToString()

            If strNomeServidorCADU.Equals(String.Empty) Then
                strNomeServidorCADU = cntNomeServidorCADU

                objRegistroWindows.mtdSalvarDadosRegistro(Registry.CurrentUser, _
                                                          "Software", _
                                                          "Eletronorte", _
                                                          "Eletronorte - Soluções Integradas", _
                                                          "NomeServidorCADU", _
                                                          strNomeServidorCADU)
            End If

            strNomeBaseDadosCADU = objRegistroWindows.mtdObterDadosRegistro("NomeBaseDadosCADU").ToString()

            If strNomeBaseDadosCADU.Equals(String.Empty) Then
                strNomeBaseDadosCADU = cntNomeBaseDadosCADU

                objRegistroWindows.mtdSalvarDadosRegistro("NomeBaseDadosCADU", strNomeBaseDadosCADU)
            End If

            strIdentificadorUsuarioCADU = objRegistroWindows.mtdObterDadosRegistro("IdentificadorUsuarioCADU").ToString()

            If strIdentificadorUsuarioCADU.Equals(String.Empty) Then
                strIdentificadorUsuarioCADU = cntIdentificadorUsuarioCADU

                objRegistroWindows.mtdSalvarDadosRegistro("IdentificadorUsuarioCADU", strIdentificadorUsuarioCADU)
            End If

            Dim strChaveCriptografiaCADU As String = objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaCADU").ToString()

            If strChaveCriptografiaCADU.Equals(String.Empty) Then
                objRegistroWindows.mtdSalvarDadosRegistro _
                ( _
                "ChaveCriptografiaCADU", _
                strChaveCriptografia_Padrao _
                )
            End If

            strSenhaCriptografadaCADU = objRegistroWindows.mtdObterDadosRegistro("SenhaCADU").ToString()
            If Not strSenhaCriptografadaCADU.Equals(String.Empty) Then
                strSenhaDescriptografadaCADU = objCriptografia.mtdDesCriptografar(strSenhaCriptografadaCADU, _
                                                                    objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaCADU").ToString(), _
                                                                    Encryption.Symmetric.Provider.Rijndael)
            Else
                strSenhaDescriptografadaCADU = String.Empty
            End If
            strSenhaCADU = strSenhaDescriptografadaCADU

            If strSenhaCADU.Equals(String.Empty) Then
                strSenhaDescriptografadaCADU = cntSenhaCADU
                strSenhaCADU = strSenhaDescriptografadaCADU

                strSenhaCriptografadaCADU = objCriptografia.mtdCriptografar _
                ( _
                strSenhaCADU, _
                objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaCADU").ToString(), _
                Encryption.Symmetric.Provider.Rijndael _
                )

                objRegistroWindows.mtdSalvarDadosRegistro _
                ( _
                "SenhaCADU", _
                strSenhaCriptografadaCADU _
                )
            End If

            strTabelaCADU = objRegistroWindows.mtdObterDadosRegistro("TabelaCADU").ToString()

            If strTabelaCADU.Equals(String.Empty) Then
                strTabelaCADU = cntTabelaCADU

                objRegistroWindows.mtdSalvarDadosRegistro("TabelaCADU", strTabelaCADU)
            End If

            strSegurancaIntegradaCADU = objRegistroWindows.mtdObterDadosRegistro("SegurancaIntegradaCADU").ToString()

            If strSegurancaIntegradaCADU.Equals(String.Empty) Then
                strSegurancaIntegradaCADU = cntSegurancaIntegradaCADU

                objRegistroWindows.mtdSalvarDadosRegistro("SegurancaIntegradaCADU", strSegurancaIntegradaCADU)
            End If

            strInformacaoSegurancaPersistenteCADU = objRegistroWindows.mtdObterDadosRegistro("InformacaoSegurancaPersistenteCADU").ToString()

            If strInformacaoSegurancaPersistenteCADU.Equals(String.Empty) Then
                strInformacaoSegurancaPersistenteCADU = cntInformacaoSegurancaPersistenteCADU

                objRegistroWindows.mtdSalvarDadosRegistro("InformacaoSegurancaPersistenteCADU", strInformacaoSegurancaPersistenteCADU)
            End If

            strNomeServidorColetor = objRegistroWindows.mtdObterDadosRegistro(Registry.CurrentUser, _
                                                                                "Software", _
                                                                                "Eletronorte", _
                                                                                "Eletronorte - Soluções Integradas", _
                                                                                "NomeServidorColetor").ToString()

            If strNomeServidorColetor.Equals(String.Empty) Then
                strNomeServidorColetor = cntNomeServidorColetor

                objRegistroWindows.mtdSalvarDadosRegistro("NomeServidorColetor", strNomeServidorColetor)
            End If

            strNomeBaseDadosColetor = objRegistroWindows.mtdObterDadosRegistro("NomeBaseDadosColetor").ToString()

            If strNomeBaseDadosColetor.Equals(String.Empty) Then
                strNomeBaseDadosColetor = cntNomeBancoDadosColetor

                objRegistroWindows.mtdSalvarDadosRegistro("NomeBaseDadosColetor", strNomeBaseDadosColetor)
            End If

            strNomeServidorColetor = objRegistroWindows.mtdObterDadosRegistro("IdentificadorUsuarioColetor").ToString()

            If strNomeServidorColetor.Equals(String.Empty) Then
                strNomeServidorColetor = cntIdentificadorUsuarioColetor

                objRegistroWindows.mtdSalvarDadosRegistro("IdentificadorUsuarioColetor", strNomeServidorColetor)
            End If

            Dim strChaveCriptografiaColetor As String = objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaColetor").ToString()

            If strChaveCriptografiaColetor.Equals(String.Empty) Then
                objRegistroWindows.mtdSalvarDadosRegistro _
                ( _
                "ChaveCriptografiaColetor", _
                strChaveCriptografia_Padrao _
                )
            End If

            strSenhaCriptografadaColetor = objRegistroWindows.mtdObterDadosRegistro("SenhaColetor").ToString()
            If Not strSenhaCriptografadaColetor.Equals(String.Empty) Then
                strSenhaDescriptografadaColetor = objCriptografia.mtdDesCriptografar(strSenhaCriptografadaColetor, _
                                                                    objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaColetor").ToString(), _
                                                                    Encryption.Symmetric.Provider.Rijndael)
            Else
                strSenhaDescriptografadaColetor = String.Empty
            End If
            strSenhaColetor = strSenhaDescriptografadaColetor

            If strSenhaColetor.Equals(String.Empty) Then
                strSenhaDescriptografadaColetor = cntSenhaColetor
                strSenhaColetor = strSenhaDescriptografadaColetor

                strSenhaCriptografadaColetor = objCriptografia.mtdCriptografar _
                ( _
                strSenhaColetor, _
                objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaColetor").ToString(), _
                Encryption.Symmetric.Provider.Rijndael _
                )

                objRegistroWindows.mtdSalvarDadosRegistro _
                ( _
                "SenhaColetor", _
                strSenhaCriptografadaColetor _
                )
            End If

            strTabelaColetor = objRegistroWindows.mtdObterDadosRegistro("TabelaColetor").ToString()

            If strTabelaColetor.Equals(String.Empty) Then
                strTabelaColetor = cntTabelaColetor

                objRegistroWindows.mtdSalvarDadosRegistro("TabelaColetor", strTabelaColetor)
            End If

            strEnderecoBancoDadosColetor = objRegistroWindows.mtdObterDadosRegistro("EnderecoBancoDadosColetor").ToString()

            If strEnderecoBancoDadosColetor.Equals(String.Empty) Then
                strEnderecoBancoDadosColetor = DiretorioArmazenamentoCompleto

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoBancoDadosColetor", strEnderecoBancoDadosColetor)
            End If

            strEnderecoRelatorioCarteira = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioCarteira").ToString()
            strEnderecoRelatorioCautela = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioCautela").ToString()
            strEnderecoRelatorioMBP = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioMBP").ToString()
            strEnderecoRelatorioInventarioBens = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioInventarioBens").ToString()
            strEnderecoRelatorioBens = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioBens").ToString()

            strEnderecoTextoEmailCarteira = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailCarteira").ToString()
            strEnderecoTextoEmailCautela = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailCautela").ToString()
            strEnderecoTextoEmailMBP = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailMBP").ToString()
            strEnderecoTextoEmailInventarioBens = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailInventarioBens").ToString()
            strEnderecoTextoEmailBens = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailBens").ToString()

            strServidorSMTP = objRegistroWindows.mtdObterDadosRegistro("ServidorSMTP").ToString()
            strMostrar = objRegistroWindows.mtdObterDadosRegistro("Mostrar").ToString()
            strDe = objRegistroWindows.mtdObterDadosRegistro("De").ToString()

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            strConexaoBancoDadosPrincipal = objImplementacaoBancoDados.mtdDefinirStringConexaoAccess _
            ( _
            clsImplementacaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, _
            String.Format("{0}{1}", strEnderecoBancoDadosPrincipal, strNomeBaseDadosPrincipal), _
            String.Empty, _
            strSenhaPrincipal _
            )

            Dim strConexaoBancoDadosPrincipalAparente As String = objImplementacaoBancoDados.mtdDefinirStringConexaoAccess _
            ( _
            clsImplementacaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, _
            String.Format("{0}{1}", frmPrincipal.strEnderecoBancoDadosPrincipal, frmPrincipal.strNomeBaseDadosPrincipal), _
            String.Empty, _
            strSenhaCriptografadaPrincipal _
            )

            objRegistroWindows.mtdSalvarDadosRegistro("ConexaoPrincipal", strConexaoBancoDadosPrincipalAparente)

            Dim blnSegurancaIntegradaCADU As Boolean = False

            Try
                blnSegurancaIntegradaCADU = Boolean.Parse(strSegurancaIntegradaCADU)
            Catch ex As Exception
                blnSegurancaIntegradaCADU = False
            End Try

            Dim blnInformacaoSegurancaPersistenteCADU As Boolean = False

            Try
                blnInformacaoSegurancaPersistenteCADU = Boolean.Parse(strInformacaoSegurancaPersistenteCADU)
            Catch ex As Exception
                blnInformacaoSegurancaPersistenteCADU = False
            End Try

            Dim strConexaoBancoDadosCADUAparente As String = String.Empty
            If (blnSegurancaIntegradaCADU) Then
                strConexaoBancoDadosCADU = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServer _
                ( _
                clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerNativa, _
                strNomeServidorCADU, _
                strNomeBaseDadosCADU, _
                blnInformacaoSegurancaPersistenteCADU, _
                intTempoSaidaConexao _
                )

                strConexaoBancoDadosCADUAparente = strConexaoBancoDadosCADU
            Else
                strConexaoBancoDadosCADU = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServer _
                ( _
                clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerNativa, _
                strNomeServidorCADU, _
                strNomeBaseDadosCADU, _
                strIdentificadorUsuarioCADU, _
                strSenhaCADU, _
                blnInformacaoSegurancaPersistenteCADU _
                )

                strConexaoBancoDadosCADUAparente = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServer _
                ( _
                clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerNativa, _
                strNomeServidorCADU, _
                strNomeBaseDadosCADU, _
                strIdentificadorUsuarioCADU, _
                strSenhaCriptografadaCADU, _
                blnInformacaoSegurancaPersistenteCADU _
                )
            End If
            objRegistroWindows.mtdSalvarDadosRegistro("ConexaoCADU", strConexaoBancoDadosCADUAparente)

            frmPrincipal.strConexaoBancoDadosColetor = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE _
            ( _
            clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerCENativa, _
            String.Format("{0}{1}", strEnderecoBancoDadosColetor, strNomeBaseDadosColetor), _
            strSenhaColetor _
            )

            Dim strConexaoBancoDadosColetorAparente As String = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE _
            ( _
            clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerCENativa, _
            String.Format("{0}{1}", frmPrincipal.strEnderecoBancoDadosColetor, frmPrincipal.strNomeBaseDadosColetor), _
            strSenhaCriptografadaColetor _
            )

            objRegistroWindows.mtdSalvarDadosRegistro("ConexaoColetor", strConexaoBancoDadosColetorAparente)

            objImplementacaoBancoDados.Dispose()

            strEnderecoRelatorioCautela = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioCautela").ToString()

            If strEnderecoRelatorioCautela.Equals(String.Empty) Then
                strEnderecoRelatorioCautela = String.Format("{0}{1}", frmPrincipal.DiretorioRelatorioCompleto, strNomeArquivoRelatorioCautela)

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioCautela", strEnderecoRelatorioCautela)
            End If

            strEnderecoRelatorioCarteira = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioCarteira").ToString()

            If strEnderecoRelatorioCarteira.Equals(String.Empty) Then
                strEnderecoRelatorioCarteira = String.Format("{0}{1}", frmPrincipal.DiretorioRelatorioCompleto, strNomeArquivoRelatorioCarteira)

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioCarteira", strEnderecoRelatorioCarteira)
            End If

            strEnderecoRelatorioMBP = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioMBP").ToString()

            If strEnderecoRelatorioMBP.Equals(String.Empty) Then
                strEnderecoRelatorioMBP = String.Format("{0}{1}", frmPrincipal.DiretorioRelatorioCompleto, strNomeArquivoRelatorioMBP)

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioMBP", strEnderecoRelatorioMBP)
            End If

            strEnderecoRelatorioInventarioBens = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioInventarioBens").ToString()

            If strEnderecoRelatorioInventarioBens.Equals(String.Empty) Then
                strEnderecoRelatorioInventarioBens = String.Format("{0}{1}", frmPrincipal.DiretorioRelatorioCompleto, strNomeArquivoRelatorioInventarioBens)

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioInventarioBens", strEnderecoRelatorioInventarioBens)
            End If

            strEnderecoRelatorioBens = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioBens").ToString()

            If strEnderecoRelatorioBens.Equals(String.Empty) Then
                strEnderecoRelatorioBens = String.Format("{0}{1}", frmPrincipal.DiretorioRelatorioCompleto, strNomeArquivoRelatorioBens)

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioBens", strEnderecoRelatorioBens)
            End If

            strEnderecoTextoEmailCautela = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailCautela").ToString()

            If strEnderecoTextoEmailCautela.Equals(String.Empty) Then
                strEnderecoTextoEmailCautela = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, strNomeArquivoTextoEmailCautela)

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailCautela", strEnderecoTextoEmailCautela)
            End If

            strEnderecoTextoEmailCarteira = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailCarteira").ToString()

            If strEnderecoTextoEmailCarteira.Equals(String.Empty) Then
                strEnderecoTextoEmailCarteira = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, strNomeArquivoTextoEmailCarteira)

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailCarteira", strEnderecoTextoEmailCarteira)
            End If

            strEnderecoTextoEmailMBP = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailMBP").ToString()

            If strEnderecoTextoEmailMBP.Equals(String.Empty) Then
                strEnderecoTextoEmailMBP = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, strNomeArquivoTextoEmailMBP)

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailMBP", strEnderecoTextoEmailMBP)
            End If

            strEnderecoTextoEmailInventarioBens = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailInventarioBens").ToString()

            If strEnderecoTextoEmailInventarioBens.Equals(String.Empty) Then
                strEnderecoTextoEmailInventarioBens = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, strNomeArquivoTextoEmailInventarioBens)

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailInventarioBens", strEnderecoTextoEmailInventarioBens)
            End If

            strEnderecoTextoEmailBens = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailBens").ToString()

            If strEnderecoTextoEmailBens.Equals(String.Empty) Then
                strEnderecoTextoEmailBens = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, strNomeArquivoTextoEmailBens)

                objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailBens", strEnderecoTextoEmailBens)
            End If

            Try
                frmPrincipal.intMultiplicadorCodigoCarteiras = CInt(objRegistroWindows.mtdObterDadosRegistro("MultiplicadorCodigoCarteiras").ToString())
            Catch
                objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoCarteiras", frmPrincipal.intMultiplicadorCodigoCarteiras)
            End Try
            intMultiplicadorCodigoCarteiras = CInt(frmPrincipal.intMultiplicadorCodigoCarteiras.ToString())

            Try
                frmPrincipal.intMultiplicadorCodigoCautelas = CInt(objRegistroWindows.mtdObterDadosRegistro("MultiplicadorCodigoCautelas").ToString())
            Catch
                objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoCautelas", frmPrincipal.intMultiplicadorCodigoCautelas)
            End Try
            intMultiplicadorCodigoCautelas = CInt(frmPrincipal.intMultiplicadorCodigoCautelas.ToString())

            Try
                frmPrincipal.intMultiplicadorCodigoMBPs = CInt(objRegistroWindows.mtdObterDadosRegistro("MultiplicadorCodigoMBPs").ToString())
            Catch
                objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoMBPs", frmPrincipal.intMultiplicadorCodigoMBPs)
            End Try
            intMultiplicadorCodigoMBPs = CInt(frmPrincipal.intMultiplicadorCodigoMBPs.ToString())

            Try
                frmPrincipal.intMultiplicadorCodigoInventarioBens = CInt(objRegistroWindows.mtdObterDadosRegistro("MultiplicadorCodigoInventarioBens").ToString())
            Catch
                objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoInventarioBens", frmPrincipal.intMultiplicadorCodigoInventarioBens)
            End Try
            intMultiplicadorCodigoInventarioBens = CInt(frmPrincipal.intMultiplicadorCodigoInventarioBens.ToString())

            Try
                frmPrincipal.intMultiplicadorCodigoBens = CInt(objRegistroWindows.mtdObterDadosRegistro("MultiplicadorCodigoBens").ToString())
            Catch
                objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoBens", frmPrincipal.intMultiplicadorCodigoBens)
            End Try
            intMultiplicadorCodigoBens = CInt(frmPrincipal.intMultiplicadorCodigoBens.ToString())

            Dim strAtualizarData As String = objRegistroWindows.mtdObterDadosRegistro("AtualizarData").ToString()

            If strAtualizarData.Equals(String.Empty) Then
                strAtualizarData = CStr(blnAtualizarData)
                objRegistroWindows.mtdSalvarDadosRegistro("AtualizarData", strAtualizarData)
            End If

            If objRegistroWindows.mtdObterDadosRegistro("FormatoCarteira").ToString().Equals("ExportFormatType.WordForWindows") Then
                _FormatoCarteira = ExportFormatType.WordForWindows
            Else
                _FormatoCarteira = ExportFormatType.PortableDocFormat
            End If

            If objRegistroWindows.mtdObterDadosRegistro("FormatoCautela").ToString().Equals("ExportFormatType.WordForWindows") Then
                _FormatoCautela = ExportFormatType.WordForWindows
            Else
                _FormatoCautela = ExportFormatType.PortableDocFormat
            End If

            If objRegistroWindows.mtdObterDadosRegistro("FormatoMBP").ToString().Equals("ExportFormatType.WordForWindows") Then
                _FormatoMBP = ExportFormatType.WordForWindows
            Else
                _FormatoMBP = ExportFormatType.PortableDocFormat
            End If

            If objRegistroWindows.mtdObterDadosRegistro("FormatoInventarioBens").ToString().Equals("ExportFormatType.WordForWindows") Then
                _FormatoInventarioBens = ExportFormatType.WordForWindows
            Else
                _FormatoInventarioBens = ExportFormatType.PortableDocFormat
            End If

            If objRegistroWindows.mtdObterDadosRegistro("FormatoBens").ToString().Equals("ExportFormatType.WordForWindows") Then
                _FormatoBens = ExportFormatType.WordForWindows
            Else
                _FormatoBens = ExportFormatType.PortableDocFormat
            End If
        End Sub

        Shared Sub New()
            ' Add any initialization after the InitializeComponent() call.
            mtdIniciarVariaveisBancoDados()
        End Sub

        Private Shared LockCriarTabelas As Object = New Object()

        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
        End Sub

        Protected Friend Sub mtdCriarTabelas()
            Me.objCADU.blnComandoImplementadoPermitirMensagemTabelaEmpregadosPrincipal = False
            Me.objCADU.blnComandoImplementadoDeletarDadosTabelaEmpregadosPrincipal = False
            Me.objCADU.blnComandoImplementadoInserirDadosTabelaEmpregadosPrincipal = False
            Me.objCADU.mtdIniciarThreadImportarTabelaEmpregadosPrincipal()
            Me.objCADU.blnComandoImplementadoPermitirMensagemTabelaEmpregadosColetor = False
            Me.objCADU.blnComandoImplementadoDeletarDadosTabelaEmpregadosColetor = False
            Me.objCADU.blnComandoImplementadoInserirDadosTabelaEmpregadosColetor = False
            Me.objCADU.mtdIniciarThreadImportarTabelaEmpregadosColetor()

            Me.objBens.blnComandoImplementadoPermitirMensagemTabelaBensEletronortePrincipal = False
            Me.objBens.blnComandoImplementadoDeletarDadosTabelaBensEletronortePrincipal = False
            Me.objBens.blnComandoImplementadoInserirDadosTabelaBensEletronortePrincipal = False
            Me.objBens.mtdIniciarThreadImportarTabelaBensEletronortePrincipal()
            Me.objBens.blnComandoImplementadoPermitirMensagemTabelaBensEletronorteColetor = False
            Me.objBens.blnComandoImplementadoDeletarDadosTabelaBensEletronorteColetor = False
            Me.objBens.blnComandoImplementadoInserirDadosTabelaBensEletronorteColetor = False
            Me.objBens.mtdIniciarThreadImportarTabelaBensEletronorteColetor()

            Me.objCentroCusto.blnComandoImplementadoPermitirMensagemTabelaCentroCustoPrincipal = False
            Me.objCentroCusto.blnComandoImplementadoDeletarDadosTabelaCentroCustoPrincipal = False
            Me.objCentroCusto.blnComandoImplementadoInserirDadosTabelaCentroCustoPrincipal = False
            Me.objCentroCusto.mtdIniciarThreadImportarTabelaCentroCustoPrincipal()
            Me.objCentroCusto.blnComandoImplementadoPermitirMensagemTabelaCentroCustoColetor = False
            Me.objCentroCusto.blnComandoImplementadoDeletarDadosTabelaCentroCustoColetor = False
            Me.objCentroCusto.blnComandoImplementadoInserirDadosTabelaCentroCustoColetor = False
            Me.objCentroCusto.mtdIniciarThreadImportarTabelaCentroCustoColetor()

            Me.objCarteira.mtdIniciarThreadCriarTabelaCarteira()
            Me.objCarteira.mtdIniciarThreadCriarTabelaCarteiraBens()

            Me.objCautela.mtdIniciarThreadCriarTabelaCautela()
            Me.objCautela.mtdIniciarThreadCriarTabelaCautelaBens()

            Me.objMBP.mtdIniciarThreadCriarTabelaMBP()
            Me.objMBP.mtdIniciarThreadCriarTabelaMBPBens()

            Me.objInventarioBens.blnComandoImplementadoPermitirMensagemTabelaInventarioBensPrincipal = False
            Me.objInventarioBens.blnComandoImplementadoDeletarDadosTabelaInventarioBensPrincipal = False
            Me.objInventarioBens.blnComandoImplementadoInserirDadosTabelaInventarioBensPrincipal = False
            Me.objInventarioBens.mtdIniciarThreadImportarTabelaInventarioBensPrincipal()
            Me.objInventarioBens.blnComandoImplementadoPermitirMensagemTabelaInventarioBensPrincipal = False
            Me.objInventarioBens.blnComandoImplementadoDeletarDadosTabelaInventarioBensColetor = False
            Me.objInventarioBens.blnComandoImplementadoInserirDadosTabelaInventarioBensColetor = False
            Me.objInventarioBens.mtdIniciarThreadImportarTabelaInventarioBensColetor()

            Me.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaMBPTipo()
            Me.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaMBPPropriedade()
            Me.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaMBPMotivacao()
            Me.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaMBPConservacaoBens()
            Me.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral()
            Me.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaFiltroImportacao()
        End Sub

        Private Sub mtdPrepararAplicativo()
            objRegistroWindows.mtdSalvarDadosRegistro(Registry.CurrentUser, _
                                              "Software", _
                                              "Eletronorte", _
                                              "Eletronorte - Soluções Integradas", _
                                              "EnderecoAplicativo", _
                                              strEnderecoAplicativo)

            SyncLock (LockCriarTabelas)
                Try
                    frmPrincipal.mtdCriarBancoDadosPrincipal()
                Catch ex As Exception

                End Try

                Try
                    frmPrincipal.mtdIniciarThreadCriarBancoDadosColetor()
                Catch ex As Exception

                End Try

                Try
                    frmPrincipal.mtdIniciarThreadCompactarRepararBancoDadosPrincipalColetor()
                Catch ex As Exception

                End Try

                Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

                If Not objBDColetor.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosColetor) Then
                    frmPrincipal.strEnderecoBancoDadosColetor = frmPrincipal.strEnderecoBancoDadosPrincipal.Replace(cntExtensaoBancoDadosPrincipal, cntExtensaoBancoDadosColetor)
                    frmPrincipal.strNomeBaseDadosColetor = frmPrincipal.strNomeBaseDadosPrincipal.Replace(cntExtensaoBancoDadosPrincipal, cntExtensaoBancoDadosColetor)
                    frmPrincipal.strSenhaColetor = frmPrincipal.strSenhaPrincipal

                    objRegistroWindows.mtdSalvarDadosRegistro("EnderecoBancoDadosColetor", frmPrincipal.strEnderecoBancoDadosColetor)
                    objRegistroWindows.mtdSalvarDadosRegistro("NomeBaseDadosColetor", frmPrincipal.strNomeBaseDadosColetor)
                    Dim strChaveCriptografiaColetor As String = objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaPrincipal").ToString()
                    objRegistroWindows.mtdSalvarDadosRegistro("ChaveCriptografiaColetor", strChaveCriptografiaColetor)
                    Dim strSenhaColetorCriptografada As String = objCriptografia.mtdCriptografar(frmPrincipal.strSenhaColetor, _
                                                                                          objRegistroWindows.mtdObterDadosRegistro( _
                                                                                              "ChaveCriptografiaColetor").ToString(), _
                                                                                          Encryption.Symmetric.Provider.Rijndael)
                    objRegistroWindows.mtdSalvarDadosRegistro("SenhaColetor", strSenhaColetorCriptografada)

                    Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                       clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

                    frmPrincipal.strConexaoBancoDadosColetor = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE( _
                            clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerCENativa, _
                            String.Format("{0}\{1}", frmPrincipal.strEnderecoBancoDadosColetor, frmPrincipal.strNomeBaseDadosColetor), _
                            frmPrincipal.strSenhaColetor)

                    Dim strConexaoBancoDadosColetorAparente As String = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE( _
                    clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerCENativa, _
                    String.Format("{0}\{1}", frmPrincipal.strEnderecoBancoDadosColetor, frmPrincipal.strNomeBaseDadosColetor), _
                    strSenhaColetorCriptografada)

                    objRegistroWindows.mtdSalvarDadosRegistro("ConexaoColetor", strConexaoBancoDadosColetorAparente)
                    objImplementacaoBancoDados.Dispose()
                End If

                Me.objCadastroUsuario.mtdIniciarThreadImportarTabelaUsuarios()
            End SyncLock
        End Sub

        Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            mtdPrepararAplicativo()

            smnGerarDocumentos.Enabled = False
            ssmGerarCautela.Enabled = False
            ssmGerarMBP.Enabled = False
            csmsSair.Visible = False
            ' String.Concat(Replace(frmPrincipal.varEnderecoAplicativo, "\bin\Debug", ""), "ImpressaoCautelas.rpt")
            Try
                Dim objBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
                ( _
                strConexaoBancoDadosPrincipal, _
                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
                )

                If objBancoDados.mtdAbrirConexao() Then
                    barlblMostrNomeUser.Text = "                    "
                    barlblMostrContUser.Text = "                    "
                    barlblMostrStatusUser.Text = "                    "
                    tmr1.Interval = 1000
                    tmr1.Enabled = True
                    barprgfrmPrincipal.Step = 1
                    barprgfrmPrincipal.Style = ProgressBarStyle.Blocks
                    barprgfrmPrincipal.Value = 0
                    Me.Enabled = False
                    Dim objTelaLogon As New frmLogon()
                    ' objTelaLogon.MdiParent = Me
                    objBancoDados.Dispose()
                    objTelaLogon.Show()
                    objTelaLogon.Select()
                Else
                    mtdDesabilitarMenus()
                    Dim objConfiguracoes As New frmConfiguracoes()
                    objConfiguracoes.MdiParent = Me
                    objBancoDados.Dispose()
                    objConfiguracoes.Show()
                    objConfiguracoes.Select()
                End If
            Catch ex As System.Exception
                mtdDesabilitarMenus()
                MessageBox.Show("Configure a pasta dos arquivos que está localizada em: " & strEnderecoAplicativo)
                Me.Close()
            Finally
                'm_Sb = New System.Text.StringBuilder()
                'm_bDirty = False
                'm_bIsWatching = False
                'tmrEdit_Notify.Interval = 100
                'tmrEdit_Notify.Start()

                'mtdMonitorarDiretorioArquivo()

                ntf1.Visible = False
                ntf1.Visible = True

                mtdExibirNotificacao("Clique com o botão direito do mouse")
                ntf1.ShowBalloonTip(1000)

                tmrSalvarBancoDados.Interval = CInt(strIntervaloBackup) * 60 * 1000
            End Try
        End Sub

        Private Sub frmPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            'Pergunta se o usuário quer, realmente, fechar o formulário.
            Dim resposta As DialogResult
            resposta = MessageBox.Show("Deseja realmente fechar o aplicativo?", "Aviso!", MessageBoxButtons.YesNo)
            'Se o usuário respondeu "Não", cancela o fechamento do formulário.
            If (resposta = System.Windows.Forms.DialogResult.No) Then
                e.Cancel = True
            ElseIf (resposta = System.Windows.Forms.DialogResult.Yes) Then
                ntf1.Visible = False
                e.Cancel = False
            End If
        End Sub

        Public Shared Sub mtdIniciarThreadCriarBancoDadosColetor()
            ThCriarBancoDadosPrincipalColetor = New Threading.Thread(New Threading.ThreadStart(AddressOf mtdRotinaThreadCriarBancoDadosColetor))
            ThCriarBancoDadosPrincipalColetor.IsBackground = True
            ThCriarBancoDadosPrincipalColetor.Priority = Threading.ThreadPriority.Normal
            ThCriarBancoDadosPrincipalColetor.Start()
        End Sub

        Public Shared Sub mtdIniciarThreadCompactarRepararBancoDadosPrincipalColetor()
            ThCompactarRepararBancoDadosPrincipalColetor = New Threading.Thread(New Threading.ThreadStart(AddressOf mtdRotinaThreadCompactarRepararBancoDadosPrincipalColetor))
            ThCompactarRepararBancoDadosPrincipalColetor.IsBackground = True
            ThCompactarRepararBancoDadosPrincipalColetor.Priority = Threading.ThreadPriority.Normal
            ThCompactarRepararBancoDadosPrincipalColetor.Start()
        End Sub

        Public Shared Sub mtdRotinaThreadCriarBancoDadosColetor()
            Try
                mtdCriarBancoDadosColetor(False)
            Catch ex As Exception

            End Try

            ThCriarBancoDadosPrincipalColetor.Abort()
        End Sub

        Public Shared Sub mtdRotinaThreadCompactarRepararBancoDadosPrincipalColetor()
            Try
                mtdCompactarRepararBancoDadosPrincipal(False)

            Catch ex As Exception

            End Try
            Try
                mtdCompactarRepararBancoDadosColetor(False)
            Catch ex As Exception

            End Try

            ThCompactarRepararBancoDadosPrincipalColetor.Abort()
        End Sub

        Private Shared Sub smnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnSair.Click
            frmPrincipal.Close()
        End Sub

        Protected Friend objCadastroUsuario As frmCadastroUsuario = New frmCadastroUsuario()

        Private Sub smnContasUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnContasUsuarios.Click
            Try
                objCadastroUsuario = New frmCadastroUsuario()
                objCadastroUsuario.MdiParent = Me
                objCadastroUsuario.Show()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub smnCarteiras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnCarteiras.Click
            Try
                objCarteira = New frmCarteiras()
                objCarteira.MdiParent = Me
                objCarteira.Show()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub smnCautelas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnCautelas.Click
            Try
                objCautela = New frmCautelas()
                objCautela.MdiParent = Me
                objCautela.Show()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub smnConfiguracoes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnConfiguracoes.Click
            objConfiguracoes = New frmConfiguracoes()
            objConfiguracoes.MdiParent = Me
            objConfiguracoes.Show()
        End Sub

        Private Sub smnVisualizarImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnVisualizarImprimir.Click
            Try
                Dim objVisualizarImpressao As frmVisualizarImpressao = New frmVisualizarImpressao()
                Select Case numFormularioSelecionado
                    Case 1
                        If Not frmCautelas.Codigo = 0 Then
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCautela
                            frmVisualizarImpressao.Tabela = frmCautelas.strNomeTabelaCautela
                            frmVisualizarImpressao.SQL = "SELECT * FROM tblCautela WHERE tblCautela.Codigo LIKE " & frmCautelas.Codigo & ";"
                            objVisualizarImpressao.MdiParent = Me
                            'objCautela.mtdCorrigirBugCautela(System.Convert.ToInt64(frmCautelas.Codigo))
                            Try
                                objVisualizarImpressao.Show()
                            Catch ex As Exception

                            End Try
                        Else : MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Case 2
                        If Not frmMBPs.Codigo = 0 Then
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioMBP
                            frmVisualizarImpressao.Tabela = frmMBPs.strNomeTabelaMBP
                            frmVisualizarImpressao.SQL = "SELECT * FROM tblMBP WHERE tblMBP.Codigo LIKE " & frmMBPs.Codigo & ";"
                            objVisualizarImpressao.MdiParent = Me
                            'objMBP.mtdCorrigirBugMBP(System.Convert.ToInt64(frmMBPs.Codigo))
                            Try
                                objVisualizarImpressao.Show()
                            Catch ex As Exception

                            End Try
                        Else : MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Case 3
                        If Not frmCarteiras.Codigo = 0 Then
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCarteira
                            frmVisualizarImpressao.Tabela = frmCarteiras.strNomeTabelaCarteira
                            frmVisualizarImpressao.SQL = "SELECT * FROM tblCarteira WHERE tblCarteira.Codigo LIKE " & frmCarteiras.Codigo & ";"
                            objVisualizarImpressao.MdiParent = Me
                            'objCarteira.mtdCorrigirBugCarteira(System.Convert.ToInt64(frmCarteiras.Codigo))
                            Try
                                objVisualizarImpressao.Show()
                            Catch ex As Exception

                            End Try
                        Else : MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Case 4
                        Try
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                            frmVisualizarImpressao.Tabela = "tblInventarioBens"
                            If (objInventarioBens.lsv1.Columns.Count > 0) Then
                                If (objInventarioBens.lsv1.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False
                                    For contador As Integer = 0 To objInventarioBens.lsv1.Items.Count - 1 Step 1
                                        If objInventarioBens.lsv1.Items(contador).Checked Then
                                            objVisualizarImpressao = New frmVisualizarImpressao()
                                            blnChecado = True
                                            frmVisualizarImpressao.SQL = String.Format _
                                            ( _
                                            "SELECT {0} FROM {1} WHERE {2} ORDER BY {3};", _
                                            "*", _
                                            "tblInventarioBens", _
                                            String.Format("{0} LIKE '{1}'", objInventarioBens.lsv1.Columns(0).Text, objInventarioBens.lsv1.Items(contador).Text), _
                                            String.Format("{0} {1}", objInventarioBens.strColunaSelecionada, IIf(objInventarioBens.blnIndicadorCrescente, String.Empty, "DESC")) _
                                            )
                                            If Not frmInventarioBens.Numero_Inventario = 0 Then
                                                objVisualizarImpressao.MdiParent = Me
                                                objVisualizarImpressao.Show()
                                            Else
                                                MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                                            End If
                                            Exit Sub
                                        End If
                                    Next

                                    If Not blnChecado Then
                                        frmVisualizarImpressao.SQL = "SELECT * FROM tblInventarioBens WHERE tblInventarioBens.Numero_Inventario LIKE " & _
                                            frmInventarioBens.Numero_Inventario & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                                        If Not frmInventarioBens.Numero_Inventario = 0 Then
                                            objVisualizarImpressao.MdiParent = Me
                                            objVisualizarImpressao.Show()
                                        Else
                                            MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                                        End If
                                        Exit Sub
                                    End If
                                Else
                                    frmVisualizarImpressao.SQL = "SELECT * FROM tblInventarioBens WHERE tblInventarioBens.Numero_Inventario LIKE " & _
                                        frmInventarioBens.Numero_Inventario & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                                    If Not frmInventarioBens.Numero_Inventario = 0 Then
                                        objVisualizarImpressao.MdiParent = Me
                                        objVisualizarImpressao.Show()
                                    Else
                                        MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                                    End If
                                End If
                            Else
                                frmVisualizarImpressao.SQL = "SELECT * FROM tblInventarioBens WHERE tblInventarioBens.Numero_Inventario LIKE " & _
                                    frmInventarioBens.Numero_Inventario & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                                If Not frmInventarioBens.Numero_Inventario = 0 Then
                                    objVisualizarImpressao.MdiParent = Me
                                    objVisualizarImpressao.Show()
                                Else
                                    MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                                End If
                            End If
                        Catch
                            frmVisualizarImpressao.SQL = "SELECT * FROM tblInventarioBens WHERE tblInventarioBens.Numero_Inventario LIKE " & _
                                frmInventarioBens.Numero_Inventario & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                            If Not frmInventarioBens.Numero_Inventario = 0 Then
                                objVisualizarImpressao.MdiParent = Me
                                objVisualizarImpressao.Show()
                            Else
                                MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                            End If
                        End Try
                    Case 5
                        Try
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioBens
                            frmVisualizarImpressao.Tabela = "tblBensEletronorte"
                            If (objBens.lsv1.Columns.Count > 0) Then
                                If (objBens.lsv1.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False
                                    For contador As Integer = 0 To objBens.lsv1.Items.Count - 1 Step 1
                                        If objBens.lsv1.Items(contador).Checked Then
                                            objVisualizarImpressao = New frmVisualizarImpressao()
                                            blnChecado = True
                                            frmVisualizarImpressao.SQL = String.Format _
                                            ( _
                                            "SELECT {0} FROM {1} WHERE {2} ORDER BY {3};", _
                                            "*", _
                                            "tblBensEletronorte", _
                                            String.Format("{0} LIKE '{1}'", objBens.lsv1.Columns(0).Text, objBens.lsv1.Items(contador).Text), _
                                            String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) _
                                            )
                                            If Not frmBens.Numero_Item = 0 Then
                                                objVisualizarImpressao.MdiParent = Me
                                                objVisualizarImpressao.Show()
                                            Else
                                                MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                                            End If
                                            Exit Sub
                                        End If
                                    Next

                                    If Not blnChecado Then
                                        frmVisualizarImpressao.SQL = "SELECT * FROM tblBensEletronorte WHERE tblBensEletronorte.Imobilizado LIKE " & _
                                        frmBens.Numero_Item & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                                        If Not frmBens.Numero_Item = 0 Then
                                            objVisualizarImpressao.MdiParent = Me
                                            objVisualizarImpressao.Show()
                                        Else
                                            MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                                        End If
                                        Exit Sub
                                    End If
                                Else
                                    frmVisualizarImpressao.SQL = "SELECT * FROM tblBensEletronorte WHERE tblBensEletronorte.Imobilizado LIKE " & _
                                        frmBens.Numero_Item & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                                    If Not frmBens.Numero_Item = 0 Then
                                        objVisualizarImpressao.MdiParent = Me
                                        objVisualizarImpressao.Show()
                                    Else
                                        MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                                    End If
                                End If
                            Else
                                frmVisualizarImpressao.SQL = "SELECT * FROM tblBensEletronorte WHERE tblBensEletronorte.Imobilizado LIKE " & _
                                    frmBens.Numero_Item & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                                If Not frmBens.Numero_Item = 0 Then
                                    objVisualizarImpressao.MdiParent = Me
                                    objVisualizarImpressao.Show()
                                Else
                                    MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                                End If
                            End If
                        Catch
                            frmVisualizarImpressao.SQL = "SELECT * FROM tblBensEletronorte WHERE tblBensEletronorte.Imobilizado LIKE " & _
                                frmBens.Numero_Item & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                            If Not frmBens.Numero_Item = 0 Then
                                objVisualizarImpressao.MdiParent = Me
                                objVisualizarImpressao.Show()
                            Else
                                MessageBox.Show("Selecione um formulário para a visualização ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
                            End If
                        End Try
                End Select
            Catch ex As Exception
                MessageBox.Show _
                ( _
                "Não foi possível gerar o relatório. Verifique o endereço do relatório.", _
                "Aviso!", _
                MessageBoxButtons.OK _
                )
            End Try
        End Sub

        Private objVisualizarImpressao As frmVisualizarImpressao = New frmVisualizarImpressao()

        Private bcmb4text As String = String.Empty
        Private bcmb5text As String = String.Empty
        Private elemento() As Integer = Nothing
        Private objDtgv1MinimoValor As Object = Nothing
        Private objDtgv1MaximoValor As Object = Nothing

        Private intItemVetChecadoLSVCarteira As Integer = 0
        Private intContadorVetChecadoLSVCarteira As Integer = 0
        Private blnVetChecadoLSVCarteira As Boolean() = New Boolean() {}
        Private strVetColunasLSVCarteira As String() = New String() {}
        Private strVetItemsLSVCarteira As String()() = New String()() {}

        Private intItemVetChecadoLSVCautela As Integer = 0
        Private intContadorVetChecadoLSVCautela As Integer = 0
        Private blnVetChecadoLSVCautela As Boolean() = New Boolean() {}
        Private strVetColunasLSVCautela As String() = New String() {}
        Private strVetItemsLSVCautela As String()() = New String()() {}

        Private intItemVetChecadoLSVMBP As Integer = 0
        Private intContadorVetChecadoLSVMBP As Integer = 0
        Private blnVetChecadoLSVMBP As Boolean() = New Boolean() {}
        Private strVetColunasLSVMBP As String() = New String() {}
        Private strVetItemsLSVMBP As String()() = New String()() {}

        Private intItemVetChecadoLSV1 As Integer = 0
        Private intContadorVetChecadoLSV1 As Integer = 0
        Private blnVetChecadoLSV1 As Boolean() = New Boolean() {}
        Private strVetColunasLSV1 As String() = New String() {}
        Private strVetItemsLSV1 As String()() = New String()() {}

        'Private objLsv1 As System.Windows.Forms.ListView = Nothing

        Private Sub smnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnImprimir.Click
            If objVisualizarImpressao.mtdDialogo() Then
                Select Case numFormularioSelecionado
                    Case 1
                        If Not frmCautelas.Codigo = 0 Then
                            Try
                                Try
                                    bcmb4text = objCautela.bcmb4.Text
                                    bcmb5text = objCautela.bcmb5.Text
                                Catch ex As Exception

                                End Try
                                If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                                    elemento = New Integer(objCautela.bcmb4.Items.Count - 1) {}
                                    For contador As Integer = 0 To elemento.Count - 1 Step 1
                                        elemento(contador) = CInt(objCautela.bcmb4.Items(contador).ToString())
                                    Next
                                Else
                                    blnVetChecadoLSVCautela = New Boolean(objCautela.lsvCautela.Items.Count - 1) {}
                                    strVetColunasLSVCautela = New String(objCautela.lsvCautela.Columns.Count - 1) {}
                                    strVetItemsLSVCautela = New String(objCautela.lsvCautela.Items.Count - 1)() {}

                                    For linha As Integer = 0 To strVetItemsLSVCautela.Length - 1 Step 1
                                        strVetItemsLSVCautela(linha) = New String(objCautela.lsvCautela.Columns.Count - 1) {}
                                    Next

                                    For coluna As Integer = 0 To strVetColunasLSVCautela.Length - 1 Step 1
                                        strVetColunasLSVCautela(coluna) = objCautela.lsvCautela.Columns(coluna).Text
                                    Next

                                    intContadorVetChecadoLSVCautela = 0
                                    For linha As Integer = 0 To strVetItemsLSVCautela.Length - 1 Step 1
                                        blnVetChecadoLSVCautela(linha) = objCautela.lsvCautela.Items(linha).Checked
                                        If blnVetChecadoLSVCautela(linha) Then
                                            intContadorVetChecadoLSVCautela += 1
                                        End If

                                        For coluna As Integer = 0 To strVetItemsLSVCautela(linha).Length - 1 Step 1
                                            strVetItemsLSVCautela(linha)(coluna) = objCautela.lsvCautela.Items(linha).SubItems(coluna).Text
                                        Next
                                    Next
                                End If
                                'objDtgv1MinimoValor = objCautela.dtgv1.Item(0, 0).Value
                                'objDtgv1MaximoValor = objCautela.dtgv1.Item(0, objCautela.dtgv1.RowCount - 1).Value
                                objDtgv1MinimoValor = objCautela.dtgv1.Item(0, objCautela.dtgv1.RowCount - 1).Value
                                objDtgv1MaximoValor = objCautela.dtgv1.Item(0, 0).Value
                            Catch
                                bcmb4text = String.Empty
                                bcmb5text = String.Empty
                                elemento = Nothing
                                objDtgv1MinimoValor = Nothing
                                objDtgv1MaximoValor = Nothing
                            Finally
                                Try
                                    mtdIniciarThreadImprimirCautela()

                                    objCautela.bcmb4.Items.Add(String.Empty)
                                    objCautela.bcmb4.Text = objCautela.bcmb4.Items(0).ToString()
                                    objCautela.bcmb4.Items.RemoveAt(0)
                                    objCautela.bcmb5.Items.Add(String.Empty)
                                    objCautela.bcmb5.Text = objCautela.bcmb5.Items(0).ToString()
                                    objCautela.bcmb5.Items.RemoveAt(0)
                                Catch ex As Exception

                                End Try
                            End Try
                        Else
                            MessageBox.Show _
                            ( _
                            "Selecione um formulário para a impressão ou crie algum registro.", _
                            "Aviso!", _
                            MessageBoxButtons.OK _
                            )
                        End If
                    Case 2
                        If Not frmMBPs.Codigo = 0 Then
                            Try
                                Try
                                    bcmb4text = objMBP.bcmb4.Text
                                    bcmb5text = objMBP.bcmb5.Text
                                Catch ex As Exception

                                End Try
                                If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                                    elemento = New Integer(objMBP.bcmb4.Items.Count - 1) {}
                                    For contador As Integer = 0 To elemento.Count - 1 Step 1
                                        elemento(contador) = CInt(objMBP.bcmb4.Items(contador).ToString())
                                    Next
                                Else
                                    blnVetChecadoLSVMBP = New Boolean(objMBP.lsvMBP.Items.Count - 1) {}
                                    strVetColunasLSVMBP = New String(objMBP.lsvMBP.Columns.Count - 1) {}
                                    strVetItemsLSVMBP = New String(objMBP.lsvMBP.Items.Count - 1)() {}

                                    For linha As Integer = 0 To strVetItemsLSVMBP.Length - 1 Step 1
                                        strVetItemsLSVMBP(linha) = New String(objMBP.lsvMBP.Columns.Count - 1) {}
                                    Next

                                    For coluna As Integer = 0 To strVetColunasLSVMBP.Length - 1 Step 1
                                        strVetColunasLSVMBP(coluna) = objMBP.lsvMBP.Columns(coluna).Text
                                    Next

                                    intContadorVetChecadoLSVMBP = 0
                                    For linha As Integer = 0 To strVetItemsLSVMBP.Length - 1 Step 1
                                        blnVetChecadoLSVMBP(linha) = objMBP.lsvMBP.Items(linha).Checked
                                        If blnVetChecadoLSVMBP(linha) Then
                                            intContadorVetChecadoLSVMBP += 1
                                        End If

                                        For coluna As Integer = 0 To strVetItemsLSVMBP(linha).Length - 1 Step 1
                                            strVetItemsLSVMBP(linha)(coluna) = objMBP.lsvMBP.Items(linha).SubItems(coluna).Text
                                        Next
                                    Next
                                End If
                                'objDtgv1MinimoValor = objMBP.dtgv1.Item(0, 0).Value
                                'objDtgv1MaximoValor = objMBP.dtgv1.Item(0, objMBP.dtgv1.RowCount - 1).Value
                                objDtgv1MinimoValor = objMBP.dtgv1.Item(0, objMBP.dtgv1.RowCount - 1).Value
                                objDtgv1MaximoValor = objMBP.dtgv1.Item(0, 0).Value
                            Catch
                                bcmb4text = String.Empty
                                bcmb5text = String.Empty
                                elemento = Nothing
                                objDtgv1MinimoValor = Nothing
                                objDtgv1MaximoValor = Nothing
                            Finally
                                Try
                                    mtdIniciarThreadImprimirMBP()

                                    objMBP.bcmb4.Items.Add(String.Empty)
                                    objMBP.bcmb4.Text = objMBP.bcmb4.Items(0).ToString()
                                    objMBP.bcmb4.Items.RemoveAt(0)
                                    objMBP.bcmb5.Items.Add(String.Empty)
                                    objMBP.bcmb5.Text = objMBP.bcmb5.Items(0).ToString()
                                    objMBP.bcmb5.Items.RemoveAt(0)
                                Catch ex As Exception

                                End Try
                            End Try
                        Else
                            MessageBox.Show _
                            ( _
                            "Selecione um formulário para a impressão ou crie algum registro.", _
                            "Aviso!", _
                            MessageBoxButtons.OK _
                            )
                        End If
                    Case 3
                        If Not frmCarteiras.Codigo = 0 Then
                            Try
                                Try
                                    bcmb4text = objCarteira.bcmb4.Text
                                    bcmb5text = objCarteira.bcmb5.Text
                                Catch ex As Exception

                                End Try
                                If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                                    elemento = New Integer(objCarteira.bcmb4.Items.Count - 1) {}
                                    For contador As Integer = 0 To elemento.Count - 1 Step 1
                                        elemento(contador) = CInt(objCarteira.bcmb4.Items(contador).ToString())
                                    Next
                                Else
                                    blnVetChecadoLSVCarteira = New Boolean(objCarteira.lsvCarteira.Items.Count - 1) {}
                                    strVetColunasLSVCarteira = New String(objCarteira.lsvCarteira.Columns.Count - 1) {}
                                    strVetItemsLSVCarteira = New String(objCarteira.lsvCarteira.Items.Count - 1)() {}

                                    For linha As Integer = 0 To strVetItemsLSVCarteira.Length - 1 Step 1
                                        strVetItemsLSVCarteira(linha) = New String(objCarteira.lsvCarteira.Columns.Count - 1) {}
                                    Next

                                    For coluna As Integer = 0 To strVetColunasLSVCarteira.Length - 1 Step 1
                                        strVetColunasLSVCarteira(coluna) = objCarteira.lsvCarteira.Columns(coluna).Text
                                    Next

                                    intContadorVetChecadoLSVCarteira = 0
                                    For linha As Integer = 0 To strVetItemsLSVCarteira.Length - 1 Step 1
                                        blnVetChecadoLSVCarteira(linha) = objCarteira.lsvCarteira.Items(linha).Checked
                                        If blnVetChecadoLSVCarteira(linha) Then
                                            intContadorVetChecadoLSVCarteira += 1
                                        End If

                                        For coluna As Integer = 0 To strVetItemsLSVCarteira(linha).Length - 1 Step 1
                                            strVetItemsLSVCarteira(linha)(coluna) = objCarteira.lsvCarteira.Items(linha).SubItems(coluna).Text
                                        Next
                                    Next
                                End If
                                'objDtgv1MinimoValor = objCarteira.dtgv1.Item(0, 0).Value
                                'objDtgv1MaximoValor = objCarteira.dtgv1.Item(0, objCarteira.dtgv1.RowCount - 1).Value
                                objDtgv1MinimoValor = objCarteira.dtgv1.Item(0, objCarteira.dtgv1.RowCount - 1).Value
                                objDtgv1MaximoValor = objCarteira.dtgv1.Item(0, 0).Value
                            Catch
                                bcmb4text = String.Empty
                                bcmb5text = String.Empty
                                elemento = Nothing
                                objDtgv1MinimoValor = Nothing
                                objDtgv1MaximoValor = Nothing
                            Finally
                                Try
                                    mtdIniciarThreadImprimirCarteira()

                                    objCarteira.bcmb4.Items.Add(String.Empty)
                                    objCarteira.bcmb4.Text = objCarteira.bcmb4.Items(0).ToString()
                                    objCarteira.bcmb4.Items.RemoveAt(0)
                                    objCarteira.bcmb5.Items.Add(String.Empty)
                                    objCarteira.bcmb5.Text = objCarteira.bcmb5.Items(0).ToString()
                                    objCarteira.bcmb5.Items.RemoveAt(0)
                                Catch ex As Exception

                                End Try
                            End Try
                        Else
                            MessageBox.Show _
                            ( _
                            "Selecione um formulário para a impressão ou crie algum registro.", _
                            "Aviso!", _
                            MessageBoxButtons.OK _
                            )
                        End If
                    Case 4
                        Try
                            If Not frmInventarioBens.Numero_Inventario = 0 Then
                                blnVetChecadoLSV1 = New Boolean(objInventarioBens.lsv1.Items.Count - 1) {}
                                strVetColunasLSV1 = New String(objInventarioBens.lsv1.Columns.Count - 1) {}
                                strVetItemsLSV1 = New String(objInventarioBens.lsv1.Items.Count - 1)() {}

                                For linha As Integer = 0 To strVetItemsLSV1.Length - 1 Step 1
                                    strVetItemsLSV1(linha) = New String(objInventarioBens.lsv1.Columns.Count - 1) {}
                                Next

                                For coluna As Integer = 0 To strVetColunasLSV1.Length - 1 Step 1
                                    strVetColunasLSV1(coluna) = objInventarioBens.lsv1.Columns(coluna).Text
                                Next

                                intContadorVetChecadoLSV1 = 0
                                For linha As Integer = 0 To strVetItemsLSV1.Length - 1 Step 1
                                    blnVetChecadoLSV1(linha) = objInventarioBens.lsv1.Items(linha).Checked
                                    If blnVetChecadoLSV1(linha) Then
                                        intContadorVetChecadoLSV1 += 1
                                    End If

                                    For coluna As Integer = 0 To strVetItemsLSV1(linha).Length - 1 Step 1
                                        strVetItemsLSV1(linha)(coluna) = objInventarioBens.lsv1.Items(linha).SubItems(coluna).Text
                                    Next
                                Next

                                mtdIniciarThreadImprimirInventarioBens()

                            Else
                                MessageBox.Show _
                                ( _
                                "Selecione um formulário para a impressão ou crie algum registro.", _
                                "Aviso!", _
                                MessageBoxButtons.OK _
                                )
                            End If
                        Catch
                        End Try
                    Case 5
                        Try
                            If Not frmBens.Numero_Item = 0 Then
                                blnVetChecadoLSV1 = New Boolean(objBens.lsv1.Items.Count - 1) {}
                                strVetColunasLSV1 = New String(objBens.lsv1.Columns.Count - 1) {}
                                strVetItemsLSV1 = New String(objBens.lsv1.Items.Count - 1)() {}

                                For linha As Integer = 0 To strVetItemsLSV1.Length - 1 Step 1
                                    strVetItemsLSV1(linha) = New String(objBens.lsv1.Columns.Count - 1) {}
                                Next

                                For coluna As Integer = 0 To strVetColunasLSV1.Length - 1 Step 1
                                    strVetColunasLSV1(coluna) = objBens.lsv1.Columns(coluna).Text
                                Next

                                intContadorVetChecadoLSV1 = 0
                                For linha As Integer = 0 To strVetItemsLSV1.Length - 1 Step 1
                                    blnVetChecadoLSV1(linha) = objBens.lsv1.Items(linha).Checked
                                    If blnVetChecadoLSV1(linha) Then
                                        intContadorVetChecadoLSV1 += 1
                                    End If

                                    For coluna As Integer = 0 To strVetItemsLSV1(linha).Length - 1 Step 1
                                        strVetItemsLSV1(linha)(coluna) = objBens.lsv1.Items(linha).SubItems(coluna).Text
                                    Next
                                Next

                                mtdIniciarThreadImprimirBens()

                            Else
                                MessageBox.Show _
                                ( _
                                "Selecione um formulário para a impressão ou crie algum registro.", _
                                "Aviso!", _
                                MessageBoxButtons.OK _
                                )
                            End If
                        Catch
                        End Try
                End Select
            End If
        End Sub

        Private sfd As System.Windows.Forms.SaveFileDialog

        Private _NomeArquivo As String = String.Empty
        Private _objVisualizarImpressao As frmVisualizarImpressao = New frmVisualizarImpressao()
        Private _Extensao As String = String.Empty
        Private _Filtro As String = String.Empty

        Private _Formato As ExportFormatType

        Protected Friend Shared _FormatoCarteira As ExportFormatType
        Protected Friend Shared _FormatoCautela As ExportFormatType
        Protected Friend Shared _FormatoMBP As ExportFormatType
        Protected Friend Shared _FormatoInventarioBens As ExportFormatType
        Protected Friend Shared _FormatoBens As ExportFormatType

        Private Sub mtdExportarDocumento(ByVal Formato As ExportFormatType)
            mtdExportarDocumento(Formato, True)
        End Sub

        Private Sub mtdExportarDocumento(ByVal Formato As ExportFormatType, ByVal ThreadSeparada As Boolean)
            _Formato = Formato

            Select Case Formato
                Case ExportFormatType.PortableDocFormat
                    _Extensao = "pdf"
                    _Filtro = "Arquivos do Acrobat Reader (*.pdf)|*.pdf|Todos Arquivos (*.*)|*.*"
                Case ExportFormatType.WordForWindows
                    _Extensao = "doc"
                    _Filtro = "Arquivos do Microsoft Word (*.doc)|*.doc|Todos Arquivos (*.*)|*.*"
            End Select
            Select Case numFormularioSelecionado
                Case 1
                    FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                    FileIO.FileSystem.CreateDirectory("Cautelas_Impressas")
                    FileIO.FileSystem.CurrentDirectory = String.Concat(FileIO.FileSystem.CurrentDirectory, "\Cautelas_Impressas\")
                    sfd1.InitialDirectory = FileIO.FileSystem.CurrentDirectory & "\"
                    sfd1.OverwritePrompt = True
                    sfd1.Filter = _Filtro
                    sfd1.FilterIndex = 1
                    sfd = sfd1

                    If Not frmCautelas.Codigo = 0 Then
                        Try
                            Try
                                bcmb4text = objCautela.bcmb4.Text
                                bcmb5text = objCautela.bcmb5.Text
                            Catch ex As Exception

                            End Try
                            If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                                elemento = New Integer(objCautela.bcmb4.Items.Count - 1) {}
                                For contador As Integer = 0 To elemento.Count - 1 Step 1
                                    elemento(contador) = CInt(objCautela.bcmb4.Items(contador).ToString())
                                Next
                            Else
                                blnVetChecadoLSVCautela = New Boolean(objCautela.lsvCautela.Items.Count - 1) {}
                                strVetColunasLSVCautela = New String(objCautela.lsvCautela.Columns.Count - 1) {}
                                strVetItemsLSVCautela = New String(objCautela.lsvCautela.Items.Count - 1)() {}

                                For linha As Integer = 0 To strVetItemsLSVCautela.Length - 1 Step 1
                                    strVetItemsLSVCautela(linha) = New String(objCautela.lsvCautela.Columns.Count - 1) {}
                                Next

                                For coluna As Integer = 0 To strVetColunasLSVCautela.Length - 1 Step 1
                                    strVetColunasLSVCautela(coluna) = objCautela.lsvCautela.Columns(coluna).Text
                                Next

                                intContadorVetChecadoLSVCautela = 0
                                For linha As Integer = 0 To strVetItemsLSVCautela.Length - 1 Step 1
                                    blnVetChecadoLSVCautela(linha) = objCautela.lsvCautela.Items(linha).Checked
                                    If blnVetChecadoLSVCautela(linha) Then
                                        intContadorVetChecadoLSVCautela += 1
                                    End If

                                    For coluna As Integer = 0 To strVetItemsLSVCautela(linha).Length - 1 Step 1
                                        strVetItemsLSVCautela(linha)(coluna) = objCautela.lsvCautela.Items(linha).SubItems(coluna).Text
                                    Next
                                Next
                            End If
                            'objDtgv1MinimoValor = objCautela.dtgv1.Item(0, 0).Value
                            'objDtgv1MaximoValor = objCautela.dtgv1.Item(0, objCautela.dtgv1.RowCount - 1).Value
                            objDtgv1MinimoValor = objCautela.dtgv1.Item(0, objCautela.dtgv1.RowCount - 1).Value
                            objDtgv1MaximoValor = objCautela.dtgv1.Item(0, 0).Value
                        Catch
                        Finally
                            Try
                                If (ThreadSeparada) Then
                                    mtdIniciarThreadExportarDocumentoCautela()
                                Else
                                    mtdExportarDocumentoCautela()
                                    mtdAbortarThreadExportarDocumentoCautela(True)
                                End If

                                objCautela.bcmb4.Items.Add(String.Empty)
                                objCautela.bcmb4.Text = objCautela.bcmb4.Items(0).ToString()
                                objCautela.bcmb4.Items.RemoveAt(0)
                                objCautela.bcmb5.Items.Add(String.Empty)
                                objCautela.bcmb5.Text = objCautela.bcmb5.Items(0).ToString()
                                objCautela.bcmb5.Items.RemoveAt(0)
                            Catch ex As Exception

                            End Try
                        End Try
                    Else
                        MessageBox.Show _
                        ( _
                        "Selecione um formulário para a exportação ou crie algum registro.", _
                        "Aviso!", _
                        MessageBoxButtons.OK _
                        )
                    End If
                Case 2
                    FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                    FileIO.FileSystem.CreateDirectory("MBPs_Impressas")
                    FileIO.FileSystem.CurrentDirectory = String.Concat(FileIO.FileSystem.CurrentDirectory, "\MBPs_Impressas\")
                    sfd1.InitialDirectory = FileIO.FileSystem.CurrentDirectory & "\"
                    sfd1.OverwritePrompt = True
                    sfd1.Filter = _Filtro
                    sfd1.FilterIndex = 1
                    sfd = sfd1

                    If Not frmMBPs.Codigo = 0 Then
                        Try
                            Try
                                bcmb4text = objMBP.bcmb4.Text
                                bcmb5text = objMBP.bcmb5.Text
                            Catch ex As Exception

                            End Try
                            If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                                elemento = New Integer(objMBP.bcmb4.Items.Count - 1) {}
                                For contador As Integer = 0 To elemento.Count - 1 Step 1
                                    elemento(contador) = CInt(objMBP.bcmb4.Items(contador).ToString())
                                Next
                            Else
                                blnVetChecadoLSVMBP = New Boolean(objMBP.lsvMBP.Items.Count - 1) {}
                                strVetColunasLSVMBP = New String(objMBP.lsvMBP.Columns.Count - 1) {}
                                strVetItemsLSVMBP = New String(objMBP.lsvMBP.Items.Count - 1)() {}

                                For linha As Integer = 0 To strVetItemsLSVMBP.Length - 1 Step 1
                                    strVetItemsLSVMBP(linha) = New String(objMBP.lsvMBP.Columns.Count - 1) {}
                                Next

                                For coluna As Integer = 0 To strVetColunasLSVMBP.Length - 1 Step 1
                                    strVetColunasLSVMBP(coluna) = objMBP.lsvMBP.Columns(coluna).Text
                                Next

                                intContadorVetChecadoLSVMBP = 0
                                For linha As Integer = 0 To strVetItemsLSVMBP.Length - 1 Step 1
                                    blnVetChecadoLSVMBP(linha) = objMBP.lsvMBP.Items(linha).Checked
                                    If blnVetChecadoLSVMBP(linha) Then
                                        intContadorVetChecadoLSVMBP += 1
                                    End If

                                    For coluna As Integer = 0 To strVetItemsLSVMBP(linha).Length - 1 Step 1
                                        strVetItemsLSVMBP(linha)(coluna) = objMBP.lsvMBP.Items(linha).SubItems(coluna).Text
                                    Next
                                Next
                            End If
                            'objDtgv1MinimoValor = objMBP.dtgv1.Item(0, 0).Value
                            'objDtgv1MaximoValor = objMBP.dtgv1.Item(0, objMBP.dtgv1.RowCount - 1).Value
                            objDtgv1MinimoValor = objMBP.dtgv1.Item(0, objMBP.dtgv1.RowCount - 1).Value
                            objDtgv1MaximoValor = objMBP.dtgv1.Item(0, 0).Value
                        Catch
                        Finally
                            Try
                                If (ThreadSeparada) Then
                                    mtdIniciarThreadExportarDocumentoMBP()
                                Else
                                    mtdExportarDocumentoMBP()
                                    mtdAbortarThreadExportarDocumentoMBP(True)
                                End If

                                objMBP.bcmb4.Items.Add(String.Empty)
                                objMBP.bcmb4.Text = objMBP.bcmb4.Items(0).ToString()
                                objMBP.bcmb4.Items.RemoveAt(0)
                                objMBP.bcmb5.Items.Add(String.Empty)
                                objMBP.bcmb5.Text = objMBP.bcmb5.Items(0).ToString()
                                objMBP.bcmb5.Items.RemoveAt(0)
                            Catch ex As Exception

                            End Try
                        End Try
                    Else
                        MessageBox.Show _
                        ( _
                        "Selecione um formulário para a exportação ou crie algum registro.", _
                        "Aviso!", _
                        MessageBoxButtons.OK _
                        )
                    End If
                Case 3
                    FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                    FileIO.FileSystem.CreateDirectory("Carteiras_Impressas")
                    FileIO.FileSystem.CurrentDirectory = String.Concat(FileIO.FileSystem.CurrentDirectory, "\Carteiras_Impressas\")
                    sfd1.InitialDirectory = FileIO.FileSystem.CurrentDirectory & "\"
                    sfd1.OverwritePrompt = True
                    sfd1.Filter = _Filtro
                    sfd1.FilterIndex = 1
                    sfd = sfd1

                    If Not frmCarteiras.Codigo = 0 Then
                        Try
                            Try
                                bcmb4text = objCarteira.bcmb4.Text
                                bcmb5text = objCarteira.bcmb5.Text
                            Catch ex As Exception

                            End Try
                            If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                                elemento = New Integer(objCarteira.bcmb4.Items.Count - 1) {}
                                For contador As Integer = 0 To elemento.Count - 1 Step 1
                                    elemento(contador) = CInt(objCarteira.bcmb4.Items(contador).ToString())
                                Next
                            Else
                                blnVetChecadoLSVCarteira = New Boolean(objCarteira.lsvCarteira.Items.Count - 1) {}
                                strVetColunasLSVCarteira = New String(objCarteira.lsvCarteira.Columns.Count - 1) {}
                                strVetItemsLSVCarteira = New String(objCarteira.lsvCarteira.Items.Count - 1)() {}

                                For linha As Integer = 0 To strVetItemsLSVCarteira.Length - 1 Step 1
                                    strVetItemsLSVCarteira(linha) = New String(objCarteira.lsvCarteira.Columns.Count - 1) {}
                                Next

                                For coluna As Integer = 0 To strVetColunasLSVCarteira.Length - 1 Step 1
                                    strVetColunasLSVCarteira(coluna) = objCarteira.lsvCarteira.Columns(coluna).Text
                                Next

                                intContadorVetChecadoLSVCarteira = 0
                                For linha As Integer = 0 To strVetItemsLSVCarteira.Length - 1 Step 1
                                    blnVetChecadoLSVCarteira(linha) = objCarteira.lsvCarteira.Items(linha).Checked
                                    If blnVetChecadoLSVCarteira(linha) Then
                                        intContadorVetChecadoLSVCarteira += 1
                                    End If

                                    For coluna As Integer = 0 To strVetItemsLSVCarteira(linha).Length - 1 Step 1
                                        strVetItemsLSVCarteira(linha)(coluna) = objCarteira.lsvCarteira.Items(linha).SubItems(coluna).Text
                                    Next
                                Next
                            End If
                            'objDtgv1MinimoValor = objCarteira.dtgv1.Item(0, 0).Value
                            'objDtgv1MaximoValor = objCarteira.dtgv1.Item(0, objCarteira.dtgv1.RowCount - 1).Value
                            objDtgv1MinimoValor = objCarteira.dtgv1.Item(0, objCarteira.dtgv1.RowCount - 1).Value
                            objDtgv1MaximoValor = objCarteira.dtgv1.Item(0, 0).Value
                        Catch
                        Finally
                            Try
                                If (ThreadSeparada) Then
                                    mtdIniciarThreadExportarDocumentoCarteira()
                                Else
                                    mtdExportarDocumentoCarteira()
                                    mtdAbortarThreadExportarDocumentoCarteira(True)
                                End If

                                objCarteira.bcmb4.Items.Add(String.Empty)
                                objCarteira.bcmb4.Text = objCarteira.bcmb4.Items(0).ToString()
                                objCarteira.bcmb4.Items.RemoveAt(0)
                                objCarteira.bcmb5.Items.Add(String.Empty)
                                objCarteira.bcmb5.Text = objCarteira.bcmb5.Items(0).ToString()
                                objCarteira.bcmb5.Items.RemoveAt(0)
                            Catch ex As Exception

                            End Try
                        End Try
                    Else
                        MessageBox.Show _
                        ( _
                        "Selecione um formulário para a exportação ou crie algum registro.", _
                        "Aviso!", _
                        MessageBoxButtons.OK _
                        )
                    End If
                Case 4
                    Try
                        FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                        FileIO.FileSystem.CreateDirectory("InventarioBens_Impressos")
                        FileIO.FileSystem.CurrentDirectory = String.Concat(FileIO.FileSystem.CurrentDirectory, "\InventarioBens_Impressos\")
                        sfd1.InitialDirectory = FileIO.FileSystem.CurrentDirectory & "\"
                        sfd1.OverwritePrompt = True
                        sfd1.Filter = _Filtro
                        sfd1.FilterIndex = 1
                        sfd = sfd1

                        If Not frmInventarioBens.Numero_Inventario = 0 Then
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                            frmVisualizarImpressao.Tabela = "tblInventarioBens"

                            blnVetChecadoLSV1 = New Boolean(objInventarioBens.lsv1.Items.Count - 1) {}
                            strVetColunasLSV1 = New String(objInventarioBens.lsv1.Columns.Count - 1) {}
                            strVetItemsLSV1 = New String(objInventarioBens.lsv1.Items.Count - 1)() {}

                            For linha As Integer = 0 To strVetItemsLSV1.Length - 1 Step 1
                                strVetItemsLSV1(linha) = New String(objInventarioBens.lsv1.Columns.Count - 1) {}
                            Next

                            For coluna As Integer = 0 To strVetColunasLSV1.Length - 1 Step 1
                                strVetColunasLSV1(coluna) = objInventarioBens.lsv1.Columns(coluna).Text
                            Next

                            intContadorVetChecadoLSV1 = 0
                            For linha As Integer = 0 To strVetItemsLSV1.Length - 1 Step 1
                                blnVetChecadoLSV1(linha) = objInventarioBens.lsv1.Items(linha).Checked
                                If blnVetChecadoLSV1(linha) Then
                                    intContadorVetChecadoLSV1 += 1
                                End If

                                For coluna As Integer = 0 To strVetItemsLSV1(linha).Length - 1 Step 1
                                    strVetItemsLSV1(linha)(coluna) = objInventarioBens.lsv1.Items(linha).SubItems(coluna).Text
                                Next
                            Next

                            If (ThreadSeparada) Then
                                mtdIniciarThreadExportarDocumentoInventarioBens()
                            Else
                                mtdExportarDocumentoInventarioBens()
                                mtdAbortarThreadExportarDocumentoInventarioBens(True)
                            End If
                        Else
                            MessageBox.Show _
                            ( _
                            "Selecione um formulário para a exportação ou crie algum registro.", _
                            "Aviso!", _
                            MessageBoxButtons.OK _
                            )
                        End If
                    Catch
                    End Try
                Case 5
                    Try
                        FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                        FileIO.FileSystem.CreateDirectory("Bens_Impressos")
                        FileIO.FileSystem.CurrentDirectory = String.Concat(FileIO.FileSystem.CurrentDirectory, "\Bens_Impressos\")
                        sfd1.InitialDirectory = FileIO.FileSystem.CurrentDirectory & "\"
                        sfd1.OverwritePrompt = True
                        sfd1.Filter = _Filtro
                        sfd1.FilterIndex = 1
                        sfd = sfd1

                        If Not frmBens.Numero_Item = 0 Then
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioBens
                            frmVisualizarImpressao.Tabela = "tblBensEletronorte"

                            blnVetChecadoLSV1 = New Boolean(objBens.lsv1.Items.Count - 1) {}
                            strVetColunasLSV1 = New String(objBens.lsv1.Columns.Count - 1) {}
                            strVetItemsLSV1 = New String(objBens.lsv1.Items.Count - 1)() {}

                            For linha As Integer = 0 To strVetItemsLSV1.Length - 1 Step 1
                                strVetItemsLSV1(linha) = New String(objBens.lsv1.Columns.Count - 1) {}
                            Next

                            For coluna As Integer = 0 To strVetColunasLSV1.Length - 1 Step 1
                                strVetColunasLSV1(coluna) = objBens.lsv1.Columns(coluna).Text
                            Next

                            intContadorVetChecadoLSV1 = 0
                            For linha As Integer = 0 To strVetItemsLSV1.Length - 1 Step 1
                                blnVetChecadoLSV1(linha) = objBens.lsv1.Items(linha).Checked
                                If blnVetChecadoLSV1(linha) Then
                                    intContadorVetChecadoLSV1 += 1
                                End If

                                For coluna As Integer = 0 To strVetItemsLSV1(linha).Length - 1 Step 1
                                    strVetItemsLSV1(linha)(coluna) = objBens.lsv1.Items(linha).SubItems(coluna).Text
                                Next
                            Next

                            If (ThreadSeparada) Then
                                mtdIniciarThreadExportarDocumentoBens()
                            Else
                                mtdExportarDocumentoBens()
                                mtdAbortarThreadExportarDocumentoBens(True)
                            End If
                        Else
                            MessageBox.Show _
                            ( _
                            "Selecione um formulário para a exportação ou crie algum registro.", _
                            "Aviso!", _
                            MessageBoxButtons.OK _
                            )
                        End If
                    Catch
                    End Try
            End Select
        End Sub

        Private Shared strTabela As String = String.Empty

        Public Shared Sub mtdAtualizarDataImpressao(ByVal Codigo As String)
            Dim objImplementacaoBancoDadosPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()
            objImplementacaoBancoDadosPrincipal.mtdAbrirConexao(strConexaoBancoDadosPrincipal, clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            Select Case frmPrincipal.numFormularioSelecionado
                Case 1
                    strTabela = frmCautelas.strNomeTabelaCautela
                Case 2
                    strTabela = frmMBPs.strNomeTabelaMBP
                Case 3
                    strTabela = frmCarteiras.strNomeTabelaCarteira
            End Select

            Dim dados As Object()() = New Object(1)() {}

            objImplementacaoBancoDadosPrincipal.mtdExecutarComando(String.Format("SELECT * FROM {0};", strTabela))
            objImplementacaoBancoDadosPrincipal.mtdDefinirLeitorDados()

            dados(0) = New String(0) _
            { _
            "Data_Impressao" _
            }

            dados(1) = New Object(0) _
            { _
            mtdCorrigirBugData _
            ( _
            Convert.ToDateTime(DateTime.Now) _
            ) _
            }

            objImplementacaoBancoDadosPrincipal.mtdAtualizarDadosParametroComandoOleDb _
            ( _
            strTabela, _
            dados, _
            "Codigo", _
            "LIKE", _
            String.Format("{0}", Codigo), _
            clsImplementacaoBancoDados.enmModoParametroComando.Valor _
            )
        End Sub

        Private Sub smnMBPs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnMBPs.Click
            Try
                objMBP = New frmMBPs()
                objMBP.MdiParent = Me
                objMBP.Show()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub mnuSobre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSobre.Click
            Dim objSobreAplicativo As New frmSobreAplicativo()
            objSobreAplicativo.MdiParent = Me
            objSobreAplicativo.Show()
        End Sub

        Private objArquivoTXT As clsArquivoTXT = New clsArquivoTXT()

        Protected Friend Shared strServidorSMTP As String = String.Empty
        Protected Friend Shared strMostrar As String = String.Empty
        Protected Friend Shared strDe As String = String.Empty
        Private lstListaPara As List(Of String) = New List(Of String)
        Private lstListaCC As List(Of String) = New List(Of String)
        Private lstListaBCC As List(Of String) = New List(Of String)
        Private strAssunto As String = String.Empty
        Private strMensagem As String = String.Empty
        Private lstListaAnexo As List(Of String) = New List(Of String)

        Public Sub mtdEnviarEmailCarteira()
            Try
                lstListaPara.Clear()
                lstListaCC.Clear()
                lstListaBCC.Clear()
                lstListaAnexo.Clear()

                Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objImplementacaoBancoDados.prpConexao = frmPrincipal.strConexaoBancoDadosPrincipal
                objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, objImplementacaoBancoDados.mtdVetorLinhaCampos(frmCADU.vetCamposTabelaEmpregados), frmCADU.strNomeTabelaPrincipal, frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosMatricula), "LIKE", String.Format("{0}", barlblMostrContUser.Text))
                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                objImplementacaoBancoDados.mtdProximoRegistro()
                strMostrar = IIf(strMostrar.Equals(String.Empty), objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosNome), strMostrar).ToString()
                strDe = IIf(strDe.Equals(String.Empty), objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail), strDe).ToString()

                Dim objBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                Dim objVisualizarImpressao As frmVisualizarImpressao = New frmVisualizarImpressao()
                Dim objE_Mail As New frmE_Mail()
                Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
                objE_Mail.MdiParent = Me

                mtdExportarDocumento(_FormatoCarteira, False)

                objBancoDados.prpConexao = frmPrincipal.strConexaoBancoDadosPrincipal
                objBancoDados.mtdAbrirConexao()
                objBancoDados.mtdExecutarComando("SELECT tblEmpregados.Nome, tblEmpregados.Matricula, tblEmpregados.Orgao, tblEmpregados.Email FROM tblEmpregados WHERE tblEmpregados.Matricula LIKE '" & objCarteira.dtgv1.Item(2, frmCarteiras.numlinhaselecionada).Value.ToString() & "';")
                objBancoDados.mtdDefinirLeitorDados()
                objBancoDados.mtdProximoRegistro()
                lstListaPara.Add(objBancoDados.mtdObterValorRegistro(3).ToString())
                lstListaBCC.Add(objManipuladorTexto.mtdMinusculo(frmLogon.strEnderecoEmail))

                Dim NomeArquivo As String = String.Empty

                Select Case _FormatoCarteira
                    Case ExportFormatType.PortableDocFormat
                        _Extensao = ".pdf"
                    Case ExportFormatType.WordForWindows
                        _Extensao = ".doc"
                End Select

                If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                    strAssunto = "Carteiras n°: "
                    For contador As Integer = 0 To elemento.Count - 1 Step 1
                        If elemento(contador).ToString() <> String.Empty Then
                            If Convert.ToInt32(elemento(contador).ToString()) >= Int32.Parse(bcmb4text) And Convert.ToInt32(elemento(contador).ToString()) <= Int32.Parse(bcmb5text) Then
                                NomeArquivo = "Carteira_" & elemento(contador).ToString()
                                sfd1.FileName = NomeArquivo & _Extensao
                                lstListaAnexo.Add(sfd1.FileName)
                                strAssunto += IIf(elemento(contador) <> System.Convert.ToInt32(elemento.Last), String.Format("{0}, ", elemento(contador)), String.Format("{0}.", elemento(contador))).ToString()
                            End If
                        End If
                    Next
                Else
                    NomeArquivo = "Carteira_" & frmCarteiras.Codigo
                    sfd1.FileName = NomeArquivo & _Extensao
                    lstListaAnexo.Add(sfd1.FileName)
                    strAssunto = "Carteira n°: "
                    strAssunto += String.Format("{0}.", frmCarteiras.Codigo)
                End If
                strMensagem = objArquivoTXT.mtdLeitorBinario(strEnderecoTextoEmailCarteira)

                objImplementacaoBancoDados.mtdExecutarComando _
                ( _
                    String.Format _
                    ( _
                        "SELECT {0} FROM {1} WHERE {2} LIKE {3} AND {4} LIKE {5} ORDER BY {6}", _
                        objImplementacaoBancoDados.mtdVetorLinhaCampos(frmCADU.vetCamposTabelaEmpregados), _
                        frmCADU.strNomeTabelaPrincipal, _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosOrgao), _
                        String.Format("'{0}'", objBancoDados.mtdObterValorRegistro(2)), _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosFuncao), _
                        "'%Secretaria%'", _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosNome) _
                    ) _
                )

                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                objImplementacaoBancoDados.mtdProximoRegistro()
                If Not objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail) Is Nothing Then
                    lstListaCC.Add(objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail).ToString())
                End If

                frmE_Mail.mtdDefinirListaCampos(strServidorSMTP, strMostrar, strDe, lstListaPara, lstListaCC, lstListaBCC, strAssunto, strMensagem, True, lstListaAnexo)

                objBancoDados.Dispose()
                objImplementacaoBancoDados.Dispose()

                objE_Mail.Show()
            Catch ex As Exception
                System.Diagnostics.Debug.Print("mtdEnviarEmailCarteira: {0}", ex.Message)
            End Try
        End Sub

        Public Sub mtdEnviarEmailCautela()
            Try
                lstListaPara.Clear()
                lstListaCC.Clear()
                lstListaBCC.Clear()
                lstListaAnexo.Clear()

                Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objImplementacaoBancoDados.prpConexao = frmPrincipal.strConexaoBancoDadosPrincipal
                objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, objImplementacaoBancoDados.mtdVetorLinhaCampos(frmCADU.vetCamposTabelaEmpregados), frmCADU.strNomeTabelaPrincipal, frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosMatricula), "LIKE", String.Format("{0}", barlblMostrContUser.Text))
                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                objImplementacaoBancoDados.mtdProximoRegistro()
                strMostrar = IIf(strMostrar.Equals(String.Empty), objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosNome), strMostrar).ToString()
                strDe = IIf(strDe.Equals(String.Empty), objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail), strDe).ToString()

                Dim objBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                Dim objVisualizarImpressao As frmVisualizarImpressao = New frmVisualizarImpressao()
                Dim objE_Mail As New frmE_Mail()
                Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
                objE_Mail.MdiParent = Me

                mtdExportarDocumento(_FormatoCautela, False)

                objBancoDados.prpConexao = frmPrincipal.strConexaoBancoDadosPrincipal
                objBancoDados.mtdAbrirConexao()
                objBancoDados.mtdExecutarComando("SELECT tblEmpregados.Nome, tblEmpregados.Matricula, tblEmpregados.Orgao, tblEmpregados.Email FROM tblEmpregados WHERE tblEmpregados.Matricula LIKE '" & objCautela.dtgv1.Item(4, frmCautelas.numlinhaselecionada).Value.ToString() & "';")
                objBancoDados.mtdDefinirLeitorDados()
                objBancoDados.mtdProximoRegistro()
                lstListaPara.Add(objBancoDados.mtdObterValorRegistro(3).ToString())
                lstListaBCC.Add(objManipuladorTexto.mtdMinusculo(frmLogon.strEnderecoEmail))

                Dim NomeArquivo As String = String.Empty

                Select Case _FormatoCautela
                    Case ExportFormatType.PortableDocFormat
                        _Extensao = ".pdf"
                    Case ExportFormatType.WordForWindows
                        _Extensao = ".doc"
                End Select

                If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                    strAssunto = "Cautelas n°: "
                    For contador As Integer = 0 To elemento.Count - 1 Step 1
                        If elemento(contador).ToString() <> String.Empty Then
                            If Convert.ToInt32(elemento(contador).ToString()) >= Int32.Parse(bcmb4text) And Convert.ToInt32(elemento(contador).ToString()) <= Int32.Parse(bcmb5text) Then
                                NomeArquivo = "Cautela_" & elemento(contador).ToString()
                                sfd1.FileName = NomeArquivo & _Extensao
                                lstListaAnexo.Add(sfd1.FileName)
                                strAssunto += IIf(elemento(contador) <> System.Convert.ToInt32(elemento.Last), String.Format("{0}, ", elemento(contador)), String.Format("{0}.", elemento(contador))).ToString()
                            End If
                        End If
                    Next
                Else
                    NomeArquivo = "Cautela_" & frmCautelas.Codigo
                    sfd1.FileName = NomeArquivo & _Extensao
                    lstListaAnexo.Add(sfd1.FileName)
                    strAssunto = "Cautela n°: "
                    strAssunto += String.Format("{0}.", frmCautelas.Codigo)
                End If
                strMensagem = objArquivoTXT.mtdLeitorBinario(strEnderecoTextoEmailCautela)

                objImplementacaoBancoDados.mtdExecutarComando _
                ( _
                    String.Format _
                    ( _
                        "SELECT {0} FROM {1} WHERE {2} LIKE {3} AND {4} LIKE {5} ORDER BY {6}", _
                        objImplementacaoBancoDados.mtdVetorLinhaCampos(frmCADU.vetCamposTabelaEmpregados), _
                        frmCADU.strNomeTabelaPrincipal, _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosOrgao), _
                        String.Format("'{0}'", objBancoDados.mtdObterValorRegistro(2)), _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosFuncao), _
                        "'%Secretaria%'", _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosNome) _
                    ) _
                )

                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                objImplementacaoBancoDados.mtdProximoRegistro()
                If Not objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail) Is Nothing Then
                    lstListaCC.Add(objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail).ToString())
                End If

                frmE_Mail.mtdDefinirListaCampos(strServidorSMTP, strMostrar, strDe, lstListaPara, lstListaCC, lstListaBCC, strAssunto, strMensagem, True, lstListaAnexo)

                objBancoDados.Dispose()
                objImplementacaoBancoDados.Dispose()

                objE_Mail.Show()
            Catch ex As Exception
                System.Diagnostics.Debug.Print("mtdEnviarEmailCautela: {0}", ex.Message)
            End Try
        End Sub

        Public Sub mtdEnviarEmailMBP()
            Try
                lstListaPara.Clear()
                lstListaCC.Clear()
                lstListaBCC.Clear()
                lstListaAnexo.Clear()

                Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objImplementacaoBancoDados.prpConexao = frmPrincipal.strConexaoBancoDadosPrincipal
                objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, objImplementacaoBancoDados.mtdVetorLinhaCampos(frmCADU.vetCamposTabelaEmpregados), frmCADU.strNomeTabelaPrincipal, frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosMatricula), "LIKE", String.Format("{0}", barlblMostrContUser.Text))
                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                objImplementacaoBancoDados.mtdProximoRegistro()
                strMostrar = IIf(strMostrar.Equals(String.Empty), objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosNome), strMostrar).ToString()
                strDe = IIf(strDe.Equals(String.Empty), objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail), strDe).ToString()

                Dim objBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                Dim objVisualizarImpressao As frmVisualizarImpressao = New frmVisualizarImpressao()
                Dim objE_Mail As New frmE_Mail()
                Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
                objE_Mail.MdiParent = Me

                mtdExportarDocumento(_FormatoMBP, False)

                objBancoDados.prpConexao = frmPrincipal.strConexaoBancoDadosPrincipal
                objBancoDados.mtdAbrirConexao()
                objBancoDados.mtdExecutarComando("SELECT tblEmpregados.Nome, tblEmpregados.Matricula, tblEmpregados.Orgao, tblEmpregados.Email FROM tblEmpregados WHERE tblEmpregados.Matricula LIKE '" & objMBP.dtgv1.Item(10, frmMBPs.numlinhaselecionada).Value.ToString() & "';")
                objBancoDados.mtdDefinirLeitorDados()
                objBancoDados.mtdProximoRegistro()
                lstListaPara.Add(objBancoDados.mtdObterValorRegistro(3).ToString())
                lstListaBCC.Add(objManipuladorTexto.mtdMinusculo(frmLogon.strEnderecoEmail))

                Dim NomeArquivo As String = String.Empty

                Select Case _FormatoMBP
                    Case ExportFormatType.PortableDocFormat
                        _Extensao = ".pdf"
                    Case ExportFormatType.WordForWindows
                        _Extensao = ".doc"
                End Select

                If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                    strAssunto = "MBPs n°: "
                    For contador As Integer = 0 To elemento.Count - 1 Step 1
                        If elemento(contador).ToString() <> String.Empty Then
                            If Convert.ToInt32(elemento(contador).ToString()) >= Int32.Parse(bcmb4text) And Convert.ToInt32(elemento(contador).ToString()) <= Int32.Parse(bcmb5text) Then
                                NomeArquivo = "MBP_" & elemento(contador).ToString()
                                sfd1.FileName = NomeArquivo & _Extensao
                                lstListaAnexo.Add(sfd1.FileName)
                                strAssunto += IIf(elemento(contador) <> System.Convert.ToInt32(elemento.Last), String.Format("{0}, ", elemento(contador)), String.Format("{0}.", elemento(contador))).ToString()
                            End If
                        End If
                    Next
                Else
                    NomeArquivo = "MBP_" & frmMBPs.Codigo
                    sfd1.FileName = NomeArquivo & _Extensao
                    lstListaAnexo.Add(sfd1.FileName)
                    strAssunto = "MBP n°: "
                    strAssunto += String.Format("{0}.", frmMBPs.Codigo)
                End If
                strMensagem = objArquivoTXT.mtdLeitorBinario(strEnderecoTextoEmailMBP)

                objImplementacaoBancoDados.mtdExecutarComando _
                ( _
                    String.Format _
                    ( _
                        "SELECT {0} FROM {1} WHERE {2} LIKE {3} AND {4} LIKE {5} ORDER BY {6}", _
                        objImplementacaoBancoDados.mtdVetorLinhaCampos(frmCADU.vetCamposTabelaEmpregados), _
                        frmCADU.strNomeTabelaPrincipal, _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosOrgao), _
                        String.Format("'{0}'", objBancoDados.mtdObterValorRegistro(2)), _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosFuncao), _
                        "'%Secretaria%'", _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosNome) _
                    ) _
                )

                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                objImplementacaoBancoDados.mtdProximoRegistro()
                If Not objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail) Is Nothing Then
                    lstListaCC.Add(objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail).ToString())
                End If

                frmE_Mail.mtdDefinirListaCampos(strServidorSMTP, strMostrar, strDe, lstListaPara, lstListaCC, lstListaBCC, strAssunto, strMensagem, True, lstListaAnexo)

                objBancoDados.Dispose()
                objImplementacaoBancoDados.Dispose()

                objE_Mail.Show()
            Catch ex As Exception
                System.Diagnostics.Debug.Print("mtdEnviarEmailMBP: {0}", ex.Message)
            End Try
        End Sub

        Public Sub mtdEnviarEmailInventarioBens()
            Try
                lstListaPara.Clear()
                lstListaCC.Clear()
                lstListaBCC.Clear()
                lstListaAnexo.Clear()

                Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objImplementacaoBancoDados.prpConexao = frmPrincipal.strConexaoBancoDadosPrincipal
                objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, objImplementacaoBancoDados.mtdVetorLinhaCampos(frmCADU.vetCamposTabelaEmpregados), frmCADU.strNomeTabelaPrincipal, frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosMatricula), "LIKE", String.Format("{0}", barlblMostrContUser.Text))
                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                objImplementacaoBancoDados.mtdProximoRegistro()
                strMostrar = IIf(strMostrar.Equals(String.Empty), objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosNome), strMostrar).ToString()
                strDe = IIf(strDe.Equals(String.Empty), objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail), strDe).ToString()

                Dim objBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                Dim objVisualizarImpressao As frmVisualizarImpressao = New frmVisualizarImpressao()
                Dim objE_Mail As New frmE_Mail()
                Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
                objE_Mail.MdiParent = Me

                mtdExportarDocumento(_FormatoInventarioBens, False)

                objBancoDados.prpConexao = frmPrincipal.strConexaoBancoDadosPrincipal
                objBancoDados.mtdAbrirConexao()
                objBancoDados.mtdExecutarComando("SELECT tblEmpregados.Nome, tblEmpregados.Matricula, tblEmpregados.Orgao, tblEmpregados.Email FROM tblEmpregados WHERE tblEmpregados.Matricula LIKE '" & objInventarioBens.dtgv1.Item(7, System.Convert.ToInt32(frmInventarioBens.numlinhaselecionada)).Value.ToString() & "';")
                objBancoDados.mtdDefinirLeitorDados()
                objBancoDados.mtdProximoRegistro()
                lstListaPara.Add(objBancoDados.mtdObterValorRegistro(3).ToString())
                lstListaBCC.Add(objManipuladorTexto.mtdMinusculo(frmLogon.strEnderecoEmail))

                Dim NomeArquivo As String = String.Empty

                Select Case _FormatoInventarioBens
                    Case ExportFormatType.PortableDocFormat
                        _Extensao = ".pdf"
                    Case ExportFormatType.WordForWindows
                        _Extensao = ".doc"
                End Select

                If Not blnChecadoInventarioBens Then
                    NomeArquivo = "InventarioBens_" & frmInventarioBens.Numero_Inventario
                    sfd1.FileName = _NomeArquivo & _Extensao
                    lstListaAnexo.Add(sfd1.FileName)
                    strAssunto += String.Format("{0}.", frmInventarioBens.Numero_Inventario)
                Else
                    Dim intContador As Integer = 0
                    If (lstListaRelatoriosExportadosInventarioBens.Count > 0) Then
                        For Each Item As String In lstListaRelatoriosExportadosInventarioBens
                            NomeArquivo = "InventarioBens_" & Item
                            sfd1.FileName = NomeArquivo & _Extensao
                            lstListaAnexo.Add(sfd1.FileName)
                            strAssunto += IIf(intContador <> lstListaRelatoriosExportadosInventarioBens.Count - 1, String.Format("{0}, ", Item), String.Format("{0}.", Item)).ToString()
                            intContador += 1
                        Next
                    End If
                End If
                strMensagem = objArquivoTXT.mtdLeitorBinario(strEnderecoTextoEmailInventarioBens)

                objImplementacaoBancoDados.mtdExecutarComando _
                ( _
                    String.Format _
                    ( _
                        "SELECT {0} FROM {1} WHERE {2} LIKE {3} AND {4} LIKE {5} ORDER BY {6}", _
                        objImplementacaoBancoDados.mtdVetorLinhaCampos(frmCADU.vetCamposTabelaEmpregados), _
                        frmCADU.strNomeTabelaPrincipal, _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosOrgao), _
                        String.Format("'{0}'", objBancoDados.mtdObterValorRegistro(2)), _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosFuncao), _
                        "'%Secretaria%'", _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosNome) _
                    ) _
                )

                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                objImplementacaoBancoDados.mtdProximoRegistro()
                If Not objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail) Is Nothing Then
                    lstListaCC.Add(objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail).ToString())
                End If

                frmE_Mail.mtdDefinirListaCampos(strServidorSMTP, strMostrar, strDe, lstListaPara, lstListaCC, lstListaBCC, strAssunto, strMensagem, True, lstListaAnexo)

                objBancoDados.Dispose()
                objImplementacaoBancoDados.Dispose()

                objE_Mail.Show()
            Catch ex As Exception
                System.Diagnostics.Debug.Print("mtdEnviarEmailInventarioBens: {0}", ex.Message)
            End Try
        End Sub

        Public Sub mtdEnviarEmailBens()
            Try
                lstListaPara.Clear()
                lstListaCC.Clear()
                lstListaBCC.Clear()
                lstListaAnexo.Clear()

                Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objImplementacaoBancoDados.prpConexao = frmPrincipal.strConexaoBancoDadosPrincipal
                objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, objImplementacaoBancoDados.mtdVetorLinhaCampos(frmCADU.vetCamposTabelaEmpregados), frmCADU.strNomeTabelaPrincipal, frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosMatricula), "LIKE", String.Format("{0}", barlblMostrContUser.Text))
                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                objImplementacaoBancoDados.mtdProximoRegistro()
                strMostrar = IIf(strMostrar.Equals(String.Empty), objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosNome), strMostrar).ToString()
                strDe = IIf(strDe.Equals(String.Empty), objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail), strDe).ToString()

                Dim objBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                Dim objVisualizarImpressao As frmVisualizarImpressao = New frmVisualizarImpressao()
                Dim objE_Mail As New frmE_Mail()
                Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
                objE_Mail.MdiParent = Me

                mtdExportarDocumento(_FormatoBens, False)

                objBancoDados.prpConexao = frmPrincipal.strConexaoBancoDadosPrincipal
                objBancoDados.mtdAbrirConexao()
                objBancoDados.mtdExecutarComando("SELECT tblEmpregados.Nome, tblEmpregados.Matricula, tblEmpregados.Orgao, tblEmpregados.Email FROM tblEmpregados WHERE tblEmpregados.Matricula LIKE '" & objBens.dtgv1.Item(7, System.Convert.ToInt32(frmBens.numlinhaselecionada)).Value.ToString() & "';")
                objBancoDados.mtdDefinirLeitorDados()
                objBancoDados.mtdProximoRegistro()
                lstListaPara.Add(objBancoDados.mtdObterValorRegistro(3).ToString())
                lstListaBCC.Add(objManipuladorTexto.mtdMinusculo(frmLogon.strEnderecoEmail))

                Dim NomeArquivo As String = String.Empty

                Select Case _FormatoBens
                    Case ExportFormatType.PortableDocFormat
                        _Extensao = ".pdf"
                    Case ExportFormatType.WordForWindows
                        _Extensao = ".doc"
                End Select

                If Not blnChecadoBens Then
                    NomeArquivo = "Bens_" & frmBens.Numero_Item
                    sfd1.FileName = _NomeArquivo & _Extensao
                    lstListaAnexo.Add(sfd1.FileName)
                    strAssunto += String.Format("{0}.", frmBens.Numero_Item)
                Else
                    Dim intContador As Integer = 0
                    If (lstListaRelatoriosExportadosBens.Count > 0) Then
                        For Each Item As String In lstListaRelatoriosExportadosBens
                            NomeArquivo = "Bens_" & Item
                            sfd1.FileName = NomeArquivo & _Extensao
                            lstListaAnexo.Add(sfd1.FileName)
                            strAssunto += IIf(intContador <> lstListaRelatoriosExportadosBens.Count - 1, String.Format("{0}, ", Item), String.Format("{0}.", Item)).ToString()
                            intContador += 1
                        Next
                    End If
                End If
                strMensagem = objArquivoTXT.mtdLeitorBinario(strEnderecoTextoEmailBens)

                objImplementacaoBancoDados.mtdExecutarComando _
                ( _
                    String.Format _
                    ( _
                        "SELECT {0} FROM {1} WHERE {2} LIKE {3} AND {4} LIKE {5} ORDER BY {6}", _
                        objImplementacaoBancoDados.mtdVetorLinhaCampos(frmCADU.vetCamposTabelaEmpregados), _
                        frmCADU.strNomeTabelaPrincipal, _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosOrgao), _
                        String.Format("'{0}'", objBancoDados.mtdObterValorRegistro(2)), _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosFuncao), _
                        "'%Secretaria%'", _
                        frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosNome) _
                    ) _
                )

                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                objImplementacaoBancoDados.mtdProximoRegistro()
                If Not objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail) Is Nothing Then
                    lstListaCC.Add(objImplementacaoBancoDados.mtdObterValorRegistro(frmCADU.intColunaTabelaEmpregadosEmail).ToString())
                End If

                frmE_Mail.mtdDefinirListaCampos(strServidorSMTP, strMostrar, strDe, lstListaPara, lstListaCC, lstListaBCC, strAssunto, strMensagem, True, lstListaAnexo)

                objBancoDados.Dispose()
                objImplementacaoBancoDados.Dispose()

                objE_Mail.Show()
            Catch ex As Exception
                System.Diagnostics.Debug.Print("mtdEnviarEmailBens: {0}", ex.Message)
            End Try
        End Sub

        Public Sub mtdEnviarEmail()
            Select Case numFormularioSelecionado
                Case 1
                    mtdEnviarEmailCautela()
                Case 2
                    mtdEnviarEmailMBP()
                Case 3
                    mtdEnviarEmailCarteira()
                Case 4
                    mtdEnviarEmailInventarioBens()
                Case 5
                    mtdEnviarEmailBens()
                Case Else
                    Dim objE_Mail As New frmE_Mail()
                    objE_Mail.MdiParent = Me
                    objE_Mail.Show()
            End Select
        End Sub

        Private Sub smnEnviarEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnEnviarEmail.Click
            mtdEnviarEmail()
        End Sub

        Private Sub smnGerarCautela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnGerarDocumentos.Click
        End Sub

        Private Sub ssmPrincipal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ssmPrincipal.Click
            ofd1.InitialDirectory = DiretorioArmazenamentoCompleto
            ofd1.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            ofd1.FileName = String.Empty
            If ofd1.ShowDialog() = DialogResult.OK Then
                strEnderecoArquivoImportado = ofd1.FileName
                objImportadorBaseDadosPrincipal = New frmImportadorBaseDadosPrincipal()
                objImportadorBaseDadosPrincipal.MdiParent = Me
                objImportadorBaseDadosPrincipal.Show()
            End If
        End Sub

        Private Sub ssmColetor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ssmColetor.Click
            ofd1.InitialDirectory = DiretorioArmazenamentoCompleto
            ofd1.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            ofd1.FileName = String.Empty
            If ofd1.ShowDialog() = DialogResult.OK Then
                strEnderecoArquivoImportado = ofd1.FileName
                objImportadorBaseDadosColetor = New frmImportadorBaseDadosColetor()
                objImportadorBaseDadosColetor.MdiParent = Me
                objImportadorBaseDadosColetor.Show()
            End If
        End Sub

        Protected Friend objInformacoes As frmInformacoes

        Private Sub mnuInformacoes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInformacoes.Click
            Try
                objInformacoes = New frmInformacoes()
                objInformacoes.MdiParent = Me
                objInformacoes.Show()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub ssmAdobeReader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ssmAdobeReader.Click
            If MessageBox.Show("Deseja realmente exportar as linhas referidas?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                mtdExportarDocumento(ExportFormatType.PortableDocFormat)

                'If objVisualizarImpressao.blnExportarRelatorio Then
                '    MessageBox.Show("Relatório(s) foi/foram exportado(s) com sucesso.", "Aviso!", MessageBoxButtons.OK)
                'Else
                '    MessageBox.Show("Houve problemas ao exportar o(s) relatório(s).", "Aviso!", MessageBoxButtons.OK)
                'End If
            End If
        End Sub

        Private Sub ssmWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ssmWord.Click
            If MessageBox.Show("Deseja realmente exportar as linhas referidas?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                mtdExportarDocumento(ExportFormatType.WordForWindows)

                'If objVisualizarImpressao.blnExportarRelatorio Then
                '    MessageBox.Show("Relatório(s) foi/foram exportado(s) com sucesso.", "Aviso!", MessageBoxButtons.OK)
                'Else
                '    MessageBox.Show("Houve problemas ao exportar o(s) relatório(s).", "Aviso!", MessageBoxButtons.OK)
                'End If
            End If
        End Sub

        Private vetLsv As String() = New String() {}

        Private Sub mtdExcelRelatorio(ByVal ExcelRelatorioTodosItens As Boolean)
            Select Case numFormularioSelecionado
                Case 1
                    If MessageBox.Show("Deseja realmente gerar o relatório do dados da tabela de Cautelas?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        mtdExibirNotificacao("A barra de progresso está do lado esquerdo inferior da tela.")
                        vetLsv = New String() {}
                        If objCautela IsNot Nothing Or ExcelRelatorioTodosItens Then
                            If (objCautela.lsvCautela.Columns.Count > 0) Then
                                If (objCautela.lsvCautela.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False

                                    If Not ExcelRelatorioTodosItens Then
                                        vetLsv = New String(objCautela.lsvCautela.Items.Count) {}

                                        vetLsv(0) = objCautela.lsvCautela.Columns(0).Text

                                        intContadorVetChecadoLSVCautela = 0
                                        For contador As Integer = 0 To objCautela.lsvCautela.Items.Count - 1 Step 1
                                            If objCautela.lsvCautela.Items(contador).Checked Then
                                                blnChecado = True
                                                If objCautela.lsvCautela.Items(contador).Checked Then
                                                    intContadorVetChecadoLSVCautela += 1
                                                End If
                                                vetLsv(contador + 1) = objCautela.lsvCautela.Items(contador).Text
                                            Else
                                                vetLsv(contador + 1) = Nothing
                                            End If
                                        Next
                                    Else
                                        blnChecado = True

                                        frmCautelas.strTabelaOrdenadora = objCautela.strNomeTabelaCautelaBens
                                        vetLsv = New String(1) {frmCautelas.vetCamposTabelaCautela(0), "%"}
                                    End If

                                    If Not blnChecado Then
                                        mtdIniciarThreadExportarPlanilhaExcelRelatorio(frmCautelas.strNomeTabelaPrincipal, frmCautelas.vetCamposTabelaCautelaBens(1), CStr(frmCautelas.Codigo))
                                        Exit Sub
                                    Else
                                        mtdIniciarThreadExportarPlanilhaExcelRelatorio(vetLsv)
                                    End If
                                Else
                                    'mtdIniciarThreadExportarPlanilhaExcelRelatorio(objCautela.camposCautelaBens(1)(0), CStr(frmCautelas.Codigo))
                                End If
                            Else
                                'mtdIniciarThreadExportarPlanilhaExcelRelatorio(objCautela.camposCautelaBens(1)(0), CStr(frmCautelas.Codigo))
                            End If
                        Else
                            System.Windows.Forms.MessageBox.Show("Selecione o formulário de inventário para exportar o relatório.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        mtdAbortarThreadExportarPlanilhaExcelRelatorio(True)
                    End If
                Case 2
                    If MessageBox.Show("Deseja realmente gerar o relatório do dados da tabela de MBPs?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        mtdExibirNotificacao("A barra de progresso está do lado esquerdo inferior da tela.")
                        vetLsv = New String() {}
                        If objMBP IsNot Nothing Or ExcelRelatorioTodosItens Then
                            If (objMBP.lsvMBP.Columns.Count > 0) Then
                                If (objMBP.lsvMBP.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False

                                    If Not ExcelRelatorioTodosItens Then
                                        vetLsv = New String(objMBP.lsvMBP.Items.Count) {}

                                        vetLsv(0) = objMBP.lsvMBP.Columns(0).Text

                                        intContadorVetChecadoLSVMBP = 0
                                        For contador As Integer = 0 To objMBP.lsvMBP.Items.Count - 1 Step 1
                                            If objMBP.lsvMBP.Items(contador).Checked Then
                                                blnChecado = True
                                                If objMBP.lsvMBP.Items(contador).Checked Then
                                                    intContadorVetChecadoLSVMBP += 1
                                                End If
                                                vetLsv(contador + 1) = objMBP.lsvMBP.Items(contador).Text
                                            Else
                                                vetLsv(contador + 1) = Nothing
                                            End If
                                        Next
                                    Else
                                        blnChecado = True

                                        frmMBPs.strTabelaOrdenadora = objMBP.strNomeTabelaMBPBens
                                        vetLsv = New String(1) {frmMBPs.vetCamposTabelaMBP(0), "%"}
                                    End If

                                    If Not blnChecado Then
                                        mtdIniciarThreadExportarPlanilhaExcelRelatorio(frmMBPs.strNomeTabelaPrincipal, frmMBPs.vetCamposTabelaMBPBens(1), CStr(frmMBPs.Codigo))
                                        Exit Sub
                                    Else
                                        mtdIniciarThreadExportarPlanilhaExcelRelatorio(vetLsv)
                                    End If
                                Else
                                    'mtdIniciarThreadExportarPlanilhaExcelRelatorio(objMBP.camposMBPBens(1)(0), CStr(frmMBPs.Codigo))
                                End If
                            Else
                                'mtdIniciarThreadExportarPlanilhaExcelRelatorio(objMBP.camposMBPBens(1)(0), CStr(frmMBPs.Codigo))
                            End If
                        Else
                            System.Windows.Forms.MessageBox.Show("Selecione o formulário de inventário para exportar o relatório.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        mtdAbortarThreadExportarPlanilhaExcelRelatorio(True)
                    End If
                Case 3
                    If MessageBox.Show("Deseja realmente gerar o relatório do dados da tabela de Carteiras?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        mtdExibirNotificacao("A barra de progresso está do lado esquerdo inferior da tela.")
                        vetLsv = New String() {}
                        If objCarteira IsNot Nothing Or ExcelRelatorioTodosItens Then
                            If (objCarteira.lsvCarteira.Columns.Count > 0) Then
                                If (objCarteira.lsvCarteira.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False

                                    If Not ExcelRelatorioTodosItens Then
                                        vetLsv = New String(objCarteira.lsvCarteira.Items.Count) {}

                                        vetLsv(0) = objCarteira.lsvCarteira.Columns(0).Text

                                        intContadorVetChecadoLSVCarteira = 0
                                        For contador As Integer = 0 To objCarteira.lsvCarteira.Items.Count - 1 Step 1
                                            If objCarteira.lsvCarteira.Items(contador).Checked Then
                                                blnChecado = True
                                                If objCarteira.lsvCarteira.Items(contador).Checked Then
                                                    intContadorVetChecadoLSVCarteira += 1
                                                End If
                                                vetLsv(contador + 1) = objCarteira.lsvCarteira.Items(contador).Text
                                            Else
                                                vetLsv(contador + 1) = Nothing
                                            End If
                                        Next
                                    Else
                                        blnChecado = True

                                        frmCarteiras.strTabelaOrdenadora = objCarteira.strNomeTabelaCarteiraBens
                                        vetLsv = New String(1) {frmCarteiras.vetCamposTabelaCarteira(0), "%"}
                                    End If

                                    If Not blnChecado Then
                                        mtdIniciarThreadExportarPlanilhaExcelRelatorio(frmCarteiras.strNomeTabelaPrincipal, frmCarteiras.vetCamposTabelaCarteiraBens(1), CStr(frmCarteiras.Codigo))
                                        Exit Sub
                                    Else
                                        mtdIniciarThreadExportarPlanilhaExcelRelatorio(vetLsv)
                                    End If
                                Else
                                    'mtdIniciarThreadExportarPlanilhaExcelRelatorio(objCarteira.camposCarteiraBens(1)(0), CStr(frmCarteiras.Codigo))
                                End If
                            Else
                                'mtdIniciarThreadExportarPlanilhaExcelRelatorio(objCarteira.camposCarteiraBens(1)(0), CStr(frmCarteiras.Codigo))
                            End If
                        Else
                            System.Windows.Forms.MessageBox.Show("Selecione o formulário de inventário para exportar o relatório.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        mtdAbortarThreadExportarPlanilhaExcelRelatorio(True)
                    End If
                Case 4
                    If MessageBox.Show("Deseja realmente gerar o relatório do dados da tabela de inventário?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        mtdExibirNotificacao("A barra de progresso está do lado esquerdo inferior da tela.")
                        vetLsv = New String() {}
                        If objInventarioBens IsNot Nothing Or ExcelRelatorioTodosItens Then
                            If (objInventarioBens.lsv1.Columns.Count > 0) Then
                                If (objInventarioBens.lsv1.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False

                                    If Not ExcelRelatorioTodosItens Then
                                        vetLsv = New String(objInventarioBens.lsv1.Items.Count) {}

                                        vetLsv(0) = objInventarioBens.lsv1.Columns(0).Text

                                        intContadorVetChecadoLSV1 = 0
                                        For contador As Integer = 0 To objInventarioBens.lsv1.Items.Count - 1 Step 1
                                            If objInventarioBens.lsv1.Items(contador).Checked Then
                                                blnChecado = True
                                                intContadorVetChecadoLSV1 += 1
                                                vetLsv(contador + 1) = objInventarioBens.lsv1.Items(contador).Text
                                            Else
                                                vetLsv(contador + 1) = Nothing
                                            End If
                                        Next
                                    Else
                                        blnChecado = True

                                        vetLsv = New String(1) {frmInventarioBens.vetCamposTabelaInventarioBens(0), "%"}
                                    End If

                                    If Not blnChecado Then
                                        mtdIniciarThreadExportarPlanilhaExcelRelatorio(frmInventarioBens.strColunaPrincipal, frmInventarioBens.vetCamposTabelaInventarioBens(0), CStr(frmInventarioBens.Numero_Inventario))
                                        Exit Sub
                                    Else
                                        mtdIniciarThreadExportarPlanilhaExcelRelatorio(vetLsv)
                                    End If
                                Else
                                    'mtdIniciarThreadExportarPlanilhaExcelRelatorio(frmInventarioBens.vetCamposTabelaInventarioBens(0), CStr(frmInventarioBens.Numero_Inventario))
                                End If
                            Else
                                'mtdIniciarThreadExportarPlanilhaExcelRelatorio(frmInventarioBens.vetCamposTabelaInventarioBens(0), CStr(frmInventarioBens.Numero_Inventario))
                            End If
                        Else
                            System.Windows.Forms.MessageBox.Show("Selecione o formulário de inventário para exportar o relatório.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        mtdAbortarThreadExportarPlanilhaExcelRelatorio(True)
                    End If
                Case 5
                    If MessageBox.Show("Deseja realmente gerar o relatório do dados da tabela de bens?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        mtdExibirNotificacao("A barra de progresso está do lado esquerdo inferior da tela.")
                        vetLsv = New String() {}
                        If objBens IsNot Nothing Or ExcelRelatorioTodosItens Then
                            If (objBens.lsv1.Columns.Count > 0) Then
                                If (objBens.lsv1.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False

                                    If Not ExcelRelatorioTodosItens Then
                                        vetLsv = New String(objBens.lsv1.Items.Count) {}

                                        vetLsv(0) = objBens.lsv1.Columns(0).Text

                                        intContadorVetChecadoLSV1 = 0
                                        For contador As Integer = 0 To objBens.lsv1.Items.Count - 1 Step 1
                                            If objBens.lsv1.Items(contador).Checked Then
                                                blnChecado = True
                                                intContadorVetChecadoLSV1 += 1
                                                vetLsv(contador + 1) = objBens.lsv1.Items(contador).Text
                                            Else
                                                vetLsv(contador + 1) = Nothing
                                            End If
                                        Next
                                    Else
                                        blnChecado = True

                                        vetLsv = New String(1) {frmBens.vetCamposTabelaBens(0), "%"}
                                    End If

                                    If Not blnChecado Then
                                        mtdIniciarThreadExportarPlanilhaExcelRelatorio(frmBens.strNomeTabelaPrincipal, frmBens.vetCamposTabelaBens(0), CStr(frmBens.Numero_Item))
                                        Exit Sub
                                    Else
                                        mtdIniciarThreadExportarPlanilhaExcelRelatorio(vetLsv)
                                    End If
                                Else
                                    'mtdIniciarThreadExportarPlanilhaExcelRelatorio(frmBens.vetCamposTabelaBens(0), CStr(frmBens.Numero_Inventario))
                                End If
                            Else
                                'mtdIniciarThreadExportarPlanilhaExcelRelatorio(frmBens.vetCamposTabelaBens(0), CStr(frmBens.Numero_Inventario))
                            End If
                        Else
                            System.Windows.Forms.MessageBox.Show("Selecione o formulário de bens para exportar o relatório.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        mtdAbortarThreadExportarPlanilhaExcelRelatorio(True)
                    End If
            End Select
            ExcelRelatorioTodosItens = False
        End Sub

        Private Sub mtdExcelSap_R3(ByVal ExcelSap_R3TodosItens As Boolean)
            Select Case numFormularioSelecionado
                Case 1
                    If MessageBox.Show("Deseja realmente exportar os dados da tabela de Cautelass para uma planilha padrão, que poderá carregada no SAP/R3?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        mtdExibirNotificacao("A barra de progresso está do lado esquerdo inferior da tela.")
                        vetLsv = New String() {}
                        If objCautela IsNot Nothing Or ExcelSap_R3TodosItens Then
                            If (objCautela.lsvCautela.Columns.Count > 0) Then
                                If (objCautela.lsvCautela.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False

                                    If Not ExcelSap_R3TodosItens Then
                                        vetLsv = New String(objCautela.lsvCautela.Items.Count) {}

                                        vetLsv(0) = objCautela.lsvCautela.Columns(0).Text

                                        intContadorVetChecadoLSVCautela = 0
                                        For contador As Integer = 0 To objCautela.lsvCautela.Items.Count - 1 Step 1
                                            If objCautela.lsvCautela.Items(contador).Checked Then
                                                blnChecado = True
                                                If objCautela.lsvCautela.Items(contador).Checked Then
                                                    intContadorVetChecadoLSVCautela += 1
                                                End If
                                                vetLsv(contador + 1) = objCautela.lsvCautela.Items(contador).Text
                                            Else
                                                vetLsv(contador + 1) = Nothing
                                            End If
                                        Next
                                    Else
                                        blnChecado = True

                                        frmCautelas.strTabelaOrdenadora = objCautela.strNomeTabelaCautelaBens
                                        vetLsv = New String(1) {frmCautelas.vetCamposTabelaCautela(0), "%"}
                                    End If

                                    If Not blnChecado Then
                                        mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmCautelas.strNomeTabelaPrincipal, frmCautelas.vetCamposTabelaCautelaBens(1), CStr(frmCautelas.Codigo))
                                        Exit Sub
                                    Else
                                        mtdIniciarThreadExportarPlanilhaExcelSap_R3(vetLsv)
                                    End If
                                Else
                                    'mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmCautelass.vetCamposTabelaCautelass(0), CStr(frmCautelass.Numero_Inventario))
                                End If
                            Else
                                'mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmCautelass.vetCamposTabelaCautelass(0), CStr(frmCautelass.Numero_Inventario))
                            End If
                        Else
                            System.Windows.Forms.MessageBox.Show("Selecione o formulário de inventário para exportar o relatório.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        mtdAbortarThreadExportarPlanilhaExcelSap_R3(True)
                    End If
                Case 2
                    If MessageBox.Show("Deseja realmente exportar os dados da tabela de MBPs para uma planilha padrão, que poderá carregada no SAP/R3?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        mtdExibirNotificacao("A barra de progresso está do lado esquerdo inferior da tela.")
                        vetLsv = New String() {}
                        If objMBP IsNot Nothing Or ExcelSap_R3TodosItens Then
                            If (objMBP.lsvMBP.Columns.Count > 0) Then
                                If (objMBP.lsvMBP.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False

                                    If Not ExcelSap_R3TodosItens Then
                                        vetLsv = New String(objMBP.lsvMBP.Items.Count) {}

                                        vetLsv(0) = objMBP.lsvMBP.Columns(0).Text

                                        intContadorVetChecadoLSVMBP = 0
                                        For contador As Integer = 0 To objMBP.lsvMBP.Items.Count - 1 Step 1
                                            If objMBP.lsvMBP.Items(contador).Checked Then
                                                blnChecado = True
                                                If objMBP.lsvMBP.Items(contador).Checked Then
                                                    intContadorVetChecadoLSVMBP += 1
                                                End If
                                                vetLsv(contador + 1) = objMBP.lsvMBP.Items(contador).Text
                                            Else
                                                vetLsv(contador + 1) = Nothing
                                            End If
                                        Next
                                    Else
                                        blnChecado = True

                                        frmMBPs.strTabelaOrdenadora = objMBP.strNomeTabelaMBPBens
                                        vetLsv = New String(1) {frmMBPs.vetCamposTabelaMBP(0), "%"}
                                    End If

                                    If Not blnChecado Then
                                        mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmMBPs.strNomeTabelaPrincipal, frmMBPs.vetCamposTabelaMBPBens(1), CStr(frmMBPs.Codigo))
                                        Exit Sub
                                    Else
                                        mtdIniciarThreadExportarPlanilhaExcelSap_R3(vetLsv)
                                    End If
                                Else
                                    'mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmMBPs.vetCamposTabelaMBPs(0), CStr(frmMBPs.Numero_Inventario))
                                End If
                            Else
                                'mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmMBPs.vetCamposTabelaMBPs(0), CStr(frmMBPs.Numero_Inventario))
                            End If
                        Else
                            System.Windows.Forms.MessageBox.Show("Selecione o formulário de inventário para exportar o relatório.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        mtdAbortarThreadExportarPlanilhaExcelSap_R3(True)
                    End If
                Case 3
                    If MessageBox.Show("Deseja realmente exportar os dados da tabela de Carteiras para uma planilha padrão, que poderá carregada no SAP/R3?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        mtdExibirNotificacao("A barra de progresso está do lado esquerdo inferior da tela.")
                        vetLsv = New String() {}
                        If objCarteira IsNot Nothing Or ExcelSap_R3TodosItens Then
                            If (objCarteira.lsvCarteira.Columns.Count > 0) Then
                                If (objCarteira.lsvCarteira.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False

                                    If Not ExcelSap_R3TodosItens Then
                                        vetLsv = New String(objCarteira.lsvCarteira.Items.Count) {}

                                        vetLsv(0) = objCarteira.lsvCarteira.Columns(0).Text

                                        intContadorVetChecadoLSVCarteira = 0
                                        For contador As Integer = 0 To objCarteira.lsvCarteira.Items.Count - 1 Step 1
                                            If objCarteira.lsvCarteira.Items(contador).Checked Then
                                                blnChecado = True
                                                If objCarteira.lsvCarteira.Items(contador).Checked Then
                                                    intContadorVetChecadoLSVCarteira += 1
                                                End If
                                                vetLsv(contador + 1) = objCarteira.lsvCarteira.Items(contador).Text
                                            Else
                                                vetLsv(contador + 1) = Nothing
                                            End If
                                        Next
                                    Else
                                        blnChecado = True

                                        frmCarteiras.strTabelaOrdenadora = objCarteira.strNomeTabelaCarteiraBens
                                        vetLsv = New String(1) {frmCarteiras.vetCamposTabelaCarteira(0), "%"}
                                    End If

                                    If Not blnChecado Then
                                        mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmCarteiras.strNomeTabelaPrincipal, frmCarteiras.vetCamposTabelaCarteiraBens(1), CStr(frmCarteiras.Codigo))
                                        Exit Sub
                                    Else
                                        mtdIniciarThreadExportarPlanilhaExcelSap_R3(vetLsv)
                                    End If
                                Else
                                    'mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmCarteiras.vetCamposTabelaCarteiras(0), CStr(frmCarteiras.Numero_Inventario))
                                End If
                            Else
                                'mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmCarteiras.vetCamposTabelaCarteiras(0), CStr(frmCarteiras.Numero_Inventario))
                            End If
                        Else
                            System.Windows.Forms.MessageBox.Show("Selecione o formulário de inventário para exportar o relatório.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        mtdAbortarThreadExportarPlanilhaExcelSap_R3(True)
                    End If
                Case 4
                    If MessageBox.Show("Deseja realmente exportar os dados da tabela de inventário para uma planilha padrão, que poderá carregada no SAP/R3?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        mtdExibirNotificacao("A barra de progresso está do lado esquerdo inferior da tela.")
                        vetLsv = New String() {}
                        If objInventarioBens IsNot Nothing Or ExcelSap_R3TodosItens Then
                            If (objInventarioBens.lsv1.Columns.Count > 0) Then
                                If (objInventarioBens.lsv1.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False

                                    If Not ExcelSap_R3TodosItens Then
                                        vetLsv = New String(objInventarioBens.lsv1.Items.Count) {}

                                        vetLsv(0) = objInventarioBens.lsv1.Columns(0).Text

                                        intContadorVetChecadoLSV1 = 0
                                        For contador As Integer = 0 To objInventarioBens.lsv1.Items.Count - 1 Step 1
                                            If objInventarioBens.lsv1.Items(contador).Checked Then
                                                blnChecado = True
                                                intContadorVetChecadoLSV1 += 1
                                                vetLsv(contador + 1) = objInventarioBens.lsv1.Items(contador).Text
                                            Else
                                                vetLsv(contador + 1) = Nothing
                                            End If
                                        Next
                                    Else
                                        blnChecado = True

                                        vetLsv = New String(1) {frmInventarioBens.vetCamposTabelaInventarioBens(0), "%"}
                                    End If

                                    If Not blnChecado Then
                                        mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmInventarioBens.strNomeTabelaPrincipal, frmInventarioBens.vetCamposTabelaInventarioBens(0), CStr(frmInventarioBens.Numero_Inventario))
                                        Exit Sub
                                    Else
                                        mtdIniciarThreadExportarPlanilhaExcelSap_R3(vetLsv)
                                    End If
                                Else
                                    'mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmInventarioBens.vetCamposTabelaInventarioBens(0), CStr(frmInventarioBens.Numero_Inventario))
                                End If
                            Else
                                'mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmInventarioBens.vetCamposTabelaInventarioBens(0), CStr(frmInventarioBens.Numero_Inventario))
                            End If
                        Else
                            System.Windows.Forms.MessageBox.Show("Selecione o formulário de inventário para exportar o relatório.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        mtdAbortarThreadExportarPlanilhaExcelSap_R3(True)
                    End If
                Case 5
                    If MessageBox.Show("Deseja realmente exportar os dados da tabela de bens para uma planilha padrão, que poderá carregada no SAP/R3?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        mtdExibirNotificacao("A barra de progresso está do lado esquerdo inferior da tela.")
                        vetLsv = New String() {}
                        If objBens IsNot Nothing Or ExcelSap_R3TodosItens Then
                            If (objBens.lsv1.Columns.Count > 0) Then
                                If (objBens.lsv1.Items.Count > 0) Then
                                    Dim blnChecado As Boolean = False

                                    If Not ExcelSap_R3TodosItens Then
                                        vetLsv = New String(objBens.lsv1.Items.Count) {}

                                        vetLsv(0) = objBens.lsv1.Columns(0).Text

                                        intContadorVetChecadoLSV1 = 0
                                        For contador As Integer = 0 To objBens.lsv1.Items.Count - 1 Step 1
                                            If objBens.lsv1.Items(contador).Checked Then
                                                blnChecado = True
                                                intContadorVetChecadoLSV1 += 1
                                                vetLsv(contador + 1) = objBens.lsv1.Items(contador).Text
                                            Else
                                                vetLsv(contador + 1) = Nothing
                                            End If
                                        Next
                                    Else
                                        blnChecado = True

                                        vetLsv = New String(1) {frmBens.vetCamposTabelaBens(0), "%"}
                                    End If

                                    If Not blnChecado Then
                                        Exit Sub
                                    Else
                                        mtdIniciarThreadExportarPlanilhaExcelSap_R3(vetLsv)
                                    End If
                                Else
                                    'mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmBens.vetCamposTabelaBens(0), CStr(frmBens.Numero_Inventario))
                                End If
                            Else
                                'mtdIniciarThreadExportarPlanilhaExcelSap_R3(frmBens.vetCamposTabelaBens(0), CStr(frmBens.Numero_Inventario))
                            End If
                        Else
                            System.Windows.Forms.MessageBox.Show("Selecione o formulário de inventário para exportar o relatório.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        mtdAbortarThreadExportarPlanilhaExcelSap_R3(True)
                    End If
            End Select
            ExcelSap_R3TodosItens = False
        End Sub

        Private Sub smnCADU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnCADU.Click
            Try
                objCADU = New frmCADU()
                objCADU.MdiParent = Me
                objCADU.Show()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub smnTabelaAuxiliar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnTabelaAuxiliar.Click
            Try
                objTabelasAuxiliares = New frmTabelasAuxiliares()
                objTabelasAuxiliares.MdiParent = Me
                objTabelasAuxiliares.Show()
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Function mtdCriarBancoDadosPrincipal() As Boolean
            Return mtdCriarBancoDadosPrincipal(False)
        End Function

        Public Shared Function mtdCriarBancoDadosPrincipal(ByVal Mensagem As Boolean) As Boolean
            Dim saida As Boolean = False

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                   clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(strConexaoBancoDadosPrincipal, True)

            If (objImplementacaoBancoDados.mtdCriarBancoDadosAccess()) Then
                If Mensagem Then
                    System.Windows.Forms.MessageBox.Show("O banco de dados foi criado com sucesso.", "Aviso!", MessageBoxButtons.OK)
                End If
                saida = True
            Else
                If Mensagem Then
                    System.Windows.Forms.MessageBox.Show("Houve erros na criação do banco de dados, verifique se ele já existe.", "Aviso!", MessageBoxButtons.OK)
                End If
                saida = False
            End If
            objImplementacaoBancoDados.Dispose()

            Return saida
        End Function

        Public Shared Function mtdCompactarRepararBancoDadosPrincipal(ByVal Mensagem As Boolean) As Boolean
            Dim saida As Boolean = False

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                   clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(frmPrincipal.strConexaoBancoDadosPrincipal, True)

            If objImplementacaoBancoDados.mtdCompactarRepararBancoDadosAccess() Then
                If Mensagem Then
                    System.Windows.Forms.MessageBox.Show("O Banco de Dados foi compactado e reparado com sucesso.", "Aviso!", MessageBoxButtons.OK)
                End If
                saida = True
            Else
                If Mensagem Then
                    System.Windows.Forms.MessageBox.Show( _
                        "O Banco de Dados não foi compactado e reparado, verifique se o banco não está sendo acessado.", "Aviso!", _
                        MessageBoxButtons.OK)
                End If
                saida = False
            End If
            objImplementacaoBancoDados.Dispose()

            Return saida
        End Function

        Public Shared Function mtdCriarBancoDadosColetor(ByVal Mensagem As Boolean) As Boolean
            Dim saida As Boolean = False

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                   clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE(frmPrincipal.strConexaoBancoDadosColetor, True)

            If (objImplementacaoBancoDados.mtdCriarBancoDadosSQLServerCE()) Then
                If Mensagem Then
                    System.Windows.Forms.MessageBox.Show("O banco de dados foi criado com sucesso.", "Aviso!", MessageBoxButtons.OK)
                End If
                saida = True
            Else
                If Mensagem Then
                    System.Windows.Forms.MessageBox.Show("Houve erros na criação do banco de dados, verifique se ele já existe.", "Aviso!", MessageBoxButtons.OK)
                End If
                saida = False
            End If
            objImplementacaoBancoDados.Dispose()

            Return saida
        End Function

        Public Shared Function mtdCompactarRepararBancoDadosColetor(ByVal Mensagem As Boolean) As Boolean
            Dim saida As Boolean = False

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                   clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE(frmPrincipal.strConexaoBancoDadosColetor, True)

            If objImplementacaoBancoDados.mtdRepararBancoDadosSQLServerCE() And objImplementacaoBancoDados.mtdCompactarBancoDadosSQLServerCE() Then
                If Mensagem Then
                    System.Windows.Forms.MessageBox.Show("O Banco de Dados foi compactado e reparado com sucesso.", "Aviso!", MessageBoxButtons.OK)
                End If
                saida = True
            Else
                If Mensagem Then
                    System.Windows.Forms.MessageBox.Show( _
                        "O Banco de Dados não foi compactado e reparado, verifique se o banco não está sendo acessado.", "Aviso!", _
                        MessageBoxButtons.OK)
                End If
                saida = False
            End If

            objImplementacaoBancoDados.Dispose()

            Return saida
        End Function

        Public Function mtdVerificarData(ByVal dtgv As DataGridView, ByVal coluna As Integer, ByVal linha As Integer) As String
            Dim strdtgv As String = dtgv.Item(coluna, linha).Value.ToString()
            Dim dataRetornada As String = String.Empty
            If strdtgv = String.Empty Then
                strdtgv = "1/1/2000"
            Else
            End If
            Dim Data_dtgv As DateTime = Convert.ToDateTime(strdtgv)
            If Data_dtgv >= #1/1/2000# And Data_dtgv <= #12/31/2999# Then
                dataRetornada = Data_dtgv.ToString()
            ElseIf Data_dtgv <= #1/1/2000# Then
                dataRetornada = #1/1/2000#.ToString
            ElseIf Data_dtgv >= #12/31/2999# Then
                dataRetornada = #12/31/2999#.ToString
            End If
            Return dataRetornada
        End Function

        Public Shared Function mtdCorrigirBugData(ByVal DataTempo As DateTime) As DateTime
            Dim dt As DateTime = DataTempo
            If DataTempo.Day <= 12 Then
                dt = DateTime.Parse(String.Format("{0}/{1}/{2} {3}:{4}", DataTempo.Month, DataTempo.Day, DataTempo.Year, DataTempo.Hour, DataTempo.Minute))
            End If
            Return dt
        End Function

        Public Function mtdObterInformacoesUsuario(ByVal Matricula As String) As Object()
            Dim saida As Object() = New Object() {}
            Dim strTabela As String = frmCADU.strNomeTabelaPrincipal
            Dim strCampo As String = "Matricula"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            objImplementacaoBancoDados.mtdSelecionarDados( _
                String.Format("{0}, {1}, {2}, {3}, {4}", "Orgao", "Endereco", "Telefone", "Nome", strCampo), _
                strTabela, _
                strCampo, _
                "LIKE", _
                Matricula, _
                strCampo, _
                True)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()

            objImplementacaoBancoDados.mtdProximoRegistro()
            Dim intColuna As Integer = objImplementacaoBancoDados.mtdObterNumeroColuna(strCampo)
            objImplementacaoBancoDados.mtdObterValorRegistro(saida)
            objImplementacaoBancoDados.Dispose()

            Return saida
        End Function

        Public Function mtdGerarProximoNumeroContadorPrincipal(ByVal Tabela As String, ByVal Campo As String) As ULong
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            objImplementacaoBancoDados.mtdSelecionarDados(Campo, Tabela, Campo, False)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()

            Dim ulngNumero As ULong = 0
            Dim ulngMaximoNumero As ULong = 0

            If (objImplementacaoBancoDados.mtdProximoRegistro()) Then
                Dim Coluna As Integer = objImplementacaoBancoDados.mtdObterNumeroColuna(Campo)
                Dim strValorRegistro As String = objImplementacaoBancoDados.mtdObterValorRegistro(Coluna).ToString()
                If strValorRegistro <> String.Empty Then
                    ulngMaximoNumero = Convert.ToUInt64(strValorRegistro)
                    strValorRegistro = objImplementacaoBancoDados.mtdObterValorRegistro(Coluna).ToString()
                    If Not (objImplementacaoBancoDados.getExcecao.Equals( _
                            "mtdDefinirLeitorDados: ExecuteReader requires an open and available Connection. The connection's current state is Closed.")) Then
                        ulngMaximoNumero = Convert.ToUInt64(strValorRegistro)
                    Else
                        ulngMaximoNumero = Convert.ToUInt64(0)
                    End If
                End If
            Else
                ulngMaximoNumero = Convert.ToUInt64(0)
            End If
            ulngNumero = CULng(ulngMaximoNumero + 1)

            objImplementacaoBancoDados.Dispose()

            Return ulngNumero
        End Function

        Public Function mtdGerarProximoNumeroCodigoPrincipal(ByVal NumeroControle As Integer, ByVal Tabela As String, ByVal Campo As String) As ULong
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

            Dim dtAtual As System.DateTime = System.DateTime.Today

            objImplementacaoBancoDados.mtdSelecionarDados(Campo, Tabela, Campo, False)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()

            Dim ulngNumeroInventario As ULong = 0
            Dim ulngMaximoNumeroInventario As ULong = 0

            If (objImplementacaoBancoDados.mtdProximoRegistro()) Then
                Dim Coluna As Integer = objImplementacaoBancoDados.mtdObterNumeroColuna(Campo)
                Dim strValorRegistro As String = objImplementacaoBancoDados.mtdObterValorRegistro(Coluna).ToString()
                If strValorRegistro <> String.Empty Then
                    ulngMaximoNumeroInventario = Convert.ToUInt64(strValorRegistro)
                    If Not (ulngMaximoNumeroInventario > CULng(dtAtual.Year * NumeroControle) AndAlso ulngMaximoNumeroInventario < CULng(dtAtual.AddYears(1).Year * NumeroControle)) Then
                        objImplementacaoBancoDados.mtdExecutarComando( _
                            String.Format( _
                                "SELECT {0} FROM {1} WHERE  {0} > {2} AND {0} < {3} ORDER BY {0} DESC;", _
                                Campo, _
                                Tabela, _
                                dtAtual.Year * NumeroControle, _
                                (dtAtual.Year + 1) * NumeroControle) _
                            )
                        objImplementacaoBancoDados.mtdDefinirLeitorDados()
                        If objImplementacaoBancoDados.mtdProximoRegistro() Then
                            strValorRegistro = objImplementacaoBancoDados.mtdObterValorRegistro(Coluna).ToString()
                            ulngMaximoNumeroInventario = Convert.ToUInt64(strValorRegistro)
                        Else
                            ulngMaximoNumeroInventario = Convert.ToUInt64(dtAtual.Year * NumeroControle)
                        End If
                    End If
                    ulngNumeroInventario = CULng(ulngMaximoNumeroInventario + 1)
                Else
                    ulngNumeroInventario = CULng((dtAtual.Year * NumeroControle) + 1)
                End If
            Else
                ulngNumeroInventario = CULng((dtAtual.Year * NumeroControle) + 1)
            End If
            objImplementacaoBancoDados.Dispose()

            Return ulngNumeroInventario
        End Function

        Public Function mtdGerarProximoNumeroCodigoColetor(ByVal NumeroControle As Integer, ByVal Tabela As String, ByVal Campo As String) As ULong
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                   clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE(frmPrincipal.strConexaoBancoDadosColetor, True)
            Dim dtAtual As System.DateTime = System.DateTime.Today

            objImplementacaoBancoDados.mtdSelecionarDados(Campo, Tabela, Campo, False)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()

            Dim ulngNumeroInventario As ULong = 0
            Dim ulngMaximoNumeroInventario As ULong = 0

            If (objImplementacaoBancoDados.mtdProximoRegistro()) Then
                Dim Coluna As Integer = objImplementacaoBancoDados.mtdObterNumeroColuna(Campo)
                Dim strValorRegistro As String = objImplementacaoBancoDados.mtdObterValorRegistro(Coluna).ToString()
                If strValorRegistro <> String.Empty Then
                    ulngMaximoNumeroInventario = Convert.ToUInt64(strValorRegistro)
                    If Not (ulngMaximoNumeroInventario > CULng(dtAtual.Year * NumeroControle) AndAlso ulngMaximoNumeroInventario < CULng(dtAtual.AddYears(1).Year * NumeroControle)) Then
                        objImplementacaoBancoDados.mtdExecutarComando( _
                            String.Format( _
                                "SELECT {0} FROM {1} WHERE  {0} > {2} AND {0} < {3} ORDER BY {0} DESC;", _
                                Campo, _
                                Tabela, _
                                dtAtual.Year * NumeroControle, _
                                (dtAtual.Year + 1) * NumeroControle) _
                            )
                        objImplementacaoBancoDados.mtdDefinirLeitorDados()
                        If objImplementacaoBancoDados.mtdProximoRegistro() Then
                            strValorRegistro = objImplementacaoBancoDados.mtdObterValorRegistro(Coluna).ToString()
                            ulngMaximoNumeroInventario = Convert.ToUInt64(strValorRegistro)
                        Else
                            ulngMaximoNumeroInventario = Convert.ToUInt64(dtAtual.Year * NumeroControle)
                        End If
                    End If
                    ulngNumeroInventario = CULng(ulngMaximoNumeroInventario + 1)
                Else
                    ulngNumeroInventario = CULng((dtAtual.Year * NumeroControle) + 1)
                End If
            Else
                ulngNumeroInventario = CULng((dtAtual.Year * NumeroControle) + 1)
            End If
            objImplementacaoBancoDados.Dispose()

            Return ulngNumeroInventario
        End Function

        Public Sub mtdDestacarCelulas(ByRef dtgv As System.Windows.Forms.DataGridView, ByVal linhaselecionada As Integer, ByVal colunaselecionada As Integer, ByRef LinhaAnteriorDTGV As Integer, ByRef ColunaAnteriorDTGV As Integer, ByVal corAtual As System.Drawing.Color)
            If linhaselecionada > -1 And linhaselecionada < dtgv.RowCount Then
                mtdColorirDTGV(dtgv, ColunaAnteriorDTGV, LinhaAnteriorDTGV, Color.White, _
                               colunaselecionada, linhaselecionada, corAtual)
                LinhaAnteriorDTGV = linhaselecionada
            End If

            If colunaselecionada > -2 And colunaselecionada < dtgv.ColumnCount Then
                ColunaAnteriorDTGV = colunaselecionada
            End If
        End Sub

        Private Sub mtdColorirDTGV(ByRef dtgv As DataGridView, ByVal ColunaAnterior As Integer, ByVal LinhaAnterior As Integer, ByVal CorAntiga As Color, _
                      ByVal ColunaAtual As Integer, ByVal LinhaAtual As Integer, ByVal CorAtual As Color)

            Dim estiloAnterior As New DataGridViewCellStyle()
            Dim estiloAtual As New DataGridViewCellStyle()

            estiloAnterior.BackColor = CorAntiga
            estiloAtual.BackColor = CorAtual

            If ColunaAnterior > -2 And ColunaAtual > -2 And ColunaAnterior < dtgv.ColumnCount And ColunaAtual < dtgv.ColumnCount And _
                LinhaAnterior > -1 And LinhaAtual > -1 And LinhaAnterior < dtgv.RowCount And LinhaAtual < dtgv.RowCount Then
                For coluna As Integer = 0 To dtgv.ColumnCount - 1 Step 1
                    dtgv.Item(coluna, LinhaAnterior).Style = estiloAnterior
                Next

                If ColunaAnterior = -1 Then
                    ColunaAnterior = 0
                End If

                If ColunaAtual = -1 Then
                    ColunaAtual = 0
                End If

                For linha As Integer = 0 To dtgv.RowCount - 1 Step 1
                    dtgv.Item(ColunaAnterior, linha).Style = estiloAnterior
                Next

                For coluna As Integer = 0 To dtgv.ColumnCount - 1 Step 1
                    dtgv.Item(coluna, LinhaAtual).Style = estiloAtual
                Next

                For linha As Integer = 0 To dtgv.RowCount - 1 Step 1
                    dtgv.Item(ColunaAtual, linha).Style = estiloAtual
                Next
            End If
        End Sub

        Private Function mtdObterConservacaoBens() As Object()()
            Dim saida As Object()() = New Object()() {}
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(strConexaoBancoDadosPrincipal, True)
            objImplementacaoBancoDados.mtdSelecionarDados("CONSERVACAOBENS", "tblTabelasAuxiliaresConservacaoBens", "CONSERVACAOBENS", True)
            saida = New Object(objImplementacaoBancoDados.mtdNumeroLinhas)() {}
            Dim linha As Integer = 0
            objImplementacaoBancoDados.mtdDefinirLeitorDados()
            saida(linha) = objImplementacaoBancoDados.mtdObterCabecalhoColunas()
            While objImplementacaoBancoDados.mtdProximoRegistro()
                linha += 1
                objImplementacaoBancoDados.mtdObterValorRegistro(saida(linha))
            End While
            Return saida
        End Function

        Private Function mtdObterTipoMBP() As Object()()
            Dim saida As Object()() = New Object()() {}
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(strConexaoBancoDadosPrincipal, True)
            objImplementacaoBancoDados.mtdSelecionarDados("TIPO", "tblTabelasAuxiliaresTipo", "TIPO", True)
            saida = New Object(objImplementacaoBancoDados.mtdNumeroLinhas)() {}
            Dim linha As Integer = 0
            objImplementacaoBancoDados.mtdDefinirLeitorDados()
            saida(linha) = objImplementacaoBancoDados.mtdObterCabecalhoColunas()
            While objImplementacaoBancoDados.mtdProximoRegistro()
                linha += 1
                objImplementacaoBancoDados.mtdObterValorRegistro(saida(linha))
            End While
            Return saida
        End Function

        Private Function mtdObterPropriedadeMBP() As Object()()
            Dim saida As Object()() = New Object()() {}
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(strConexaoBancoDadosPrincipal, True)
            objImplementacaoBancoDados.mtdSelecionarDados("PROPRIEDADE", "tblTabelasAuxiliaresPropriedade", "PROPRIEDADE", True)
            saida = New Object(objImplementacaoBancoDados.mtdNumeroLinhas)() {}
            Dim linha As Integer = 0
            objImplementacaoBancoDados.mtdDefinirLeitorDados()
            saida(linha) = objImplementacaoBancoDados.mtdObterCabecalhoColunas()
            While objImplementacaoBancoDados.mtdProximoRegistro()
                linha += 1
                objImplementacaoBancoDados.mtdObterValorRegistro(saida(linha))
            End While
            Return saida
        End Function

        Private Function mtdObterMotivacaoMBP() As Object()()
            Dim saida As Object()() = New Object()() {}
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(strConexaoBancoDadosPrincipal, True)
            objImplementacaoBancoDados.mtdSelecionarDados("MOTIVACAO", "tblTabelasAuxiliaresMotivacao", "MOTIVACAO", True)
            saida = New Object(objImplementacaoBancoDados.mtdNumeroLinhas)() {}
            Dim linha As Integer = 0
            objImplementacaoBancoDados.mtdDefinirLeitorDados()
            saida(linha) = objImplementacaoBancoDados.mtdObterCabecalhoColunas()
            While objImplementacaoBancoDados.mtdProximoRegistro()
                linha += 1
                objImplementacaoBancoDados.mtdObterValorRegistro(saida(linha))
            End While
            Return saida
        End Function

        Private Sub smnTabelaBens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnBens.Click
            Try
                objBens = New frmBens()
                objBens.MdiParent = Me
                objBens.Show()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub smnTabelaCentroCusto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnCentroCusto.Click
            Try
                objCentroCusto = New frmCentroCusto()
                objCentroCusto.MdiParent = Me
                objCentroCusto.Show()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub smnTabelaInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnInventario.Click
            Try
                objInventarioBens = New frmInventarioBens()
                objInventarioBens.MdiParent = Me
                objInventarioBens.Show()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub btnWatchFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            'mtdMonitorarDiretorioArquivo()
        End Sub

        Private Sub ssmGerarMBP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ssmGerarMBP.Click
            Select Case numFormularioSelecionado
                Case 4
                    If MessageBox.Show("Deseja gerar a(s) MBP(s) do(s) inventário(s) selecionado(s)?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        If (objInventarioBens.lsv1.Columns.Count > 0) Then
                            Dim blnChecado As Boolean = False

                            vetLsv = New String(objInventarioBens.lsv1.Items.Count) {}

                            vetLsv(0) = objInventarioBens.lsv1.Columns(0).Text

                            intContadorVetChecadoLSV1 = 0
                            For contador As Integer = 0 To objInventarioBens.lsv1.Items.Count - 1 Step 1
                                If objInventarioBens.lsv1.Items(contador).Checked Then
                                    blnChecado = True
                                    intContadorVetChecadoLSV1 += 1
                                    vetLsv(contador + 1) = objInventarioBens.lsv1.Items(contador).Text
                                Else
                                    vetLsv(contador + 1) = Nothing
                                End If
                            Next

                            If Not blnChecado Then
                                mtdIniciarThreadGerarInventarioMBP(frmInventarioBens.vetCamposTabelaInventarioBens(0), CStr(frmInventarioBens.Numero_Inventario))
                            Else
                                mtdIniciarThreadGerarInventarioMBP(vetLsv)
                            End If
                        Else
                            mtdIniciarThreadGerarInventarioMBP(frmInventarioBens.vetCamposTabelaInventarioBens(0), CStr(frmInventarioBens.Numero_Inventario))
                        End If
                    Else
                        mtdAbortarThreadGerarInventarioMBP(True)
                    End If
            End Select
        End Sub

        Private Sub ssmGerarCautela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ssmGerarCautela.Click
            Select Case numFormularioSelecionado
                Case 2
                    If Not frmMBPs.Codigo = 0 Then
                        Try
                            Try
                                bcmb4text = objMBP.bcmb4.Text
                                bcmb5text = objMBP.bcmb5.Text
                            Catch ex As Exception

                            End Try
                            If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                                elemento = New Integer(objMBP.bcmb4.Items.Count - 1) {}
                                For contador As Integer = 0 To elemento.Count - 1 Step 1
                                    elemento(contador) = CInt(objMBP.bcmb4.Items(contador).ToString())
                                Next
                            Else
                                blnVetChecadoLSVMBP = New Boolean(objMBP.lsvMBP.Items.Count - 1) {}
                                strVetColunasLSVMBP = New String(objMBP.lsvMBP.Columns.Count - 1) {}
                                strVetItemsLSVMBP = New String(objMBP.lsvMBP.Items.Count - 1)() {}

                                For linha As Integer = 0 To strVetItemsLSVMBP.Length - 1 Step 1
                                    strVetItemsLSVMBP(linha) = New String(objMBP.lsvMBP.Columns.Count - 1) {}
                                Next

                                For coluna As Integer = 0 To strVetColunasLSVMBP.Length - 1 Step 1
                                    strVetColunasLSVMBP(coluna) = objMBP.lsvMBP.Columns(coluna).Text
                                Next

                                intContadorVetChecadoLSVMBP = 0
                                For linha As Integer = 0 To strVetItemsLSVMBP.Length - 1 Step 1
                                    blnVetChecadoLSVMBP(linha) = objMBP.lsvMBP.Items(linha).Checked
                                    If blnVetChecadoLSVMBP(linha) Then
                                        intContadorVetChecadoLSVMBP += 1
                                    End If

                                    For coluna As Integer = 0 To strVetItemsLSVMBP(linha).Length - 1 Step 1
                                        strVetItemsLSVMBP(linha)(coluna) = objMBP.lsvMBP.Items(linha).SubItems(coluna).Text
                                    Next
                                Next
                            End If
                            'objDtgv1MinimoValor = objMBP.dtgv1.Item(0, 0).Value
                            'objDtgv1MaximoValor = objMBP.dtgv1.Item(0, objMBP.dtgv1.RowCount - 1).Value
                            objDtgv1MinimoValor = objMBP.dtgv1.Item(0, objMBP.dtgv1.RowCount - 1).Value
                            objDtgv1MaximoValor = objMBP.dtgv1.Item(0, 0).Value
                        Catch
                        Finally
                            Try
                                mtdIniciarThreadGerarMBPCautela()

                                objMBP.bcmb4.Items.Add(String.Empty)
                                objMBP.bcmb4.Text = objMBP.bcmb4.Items(0).ToString()
                                objMBP.bcmb4.Items.RemoveAt(0)
                                objMBP.bcmb5.Items.Add(String.Empty)
                                objMBP.bcmb5.Text = objMBP.bcmb5.Items(0).ToString()
                                objMBP.bcmb5.Items.RemoveAt(0)
                            Catch ex As Exception

                            End Try
                        End Try
                    Else
                        MessageBox.Show _
                        ( _
                        "Selecione um formulário de MBPs para criar cautelas de responsabilidade", _
                        "Aviso!", _
                        MessageBoxButtons.OK _
                        )
                    End If
                Case 3
                    If Not frmCarteiras.Codigo = 0 Then
                        Try
                            Try
                                bcmb4text = objCarteira.bcmb4.Text
                                bcmb5text = objCarteira.bcmb5.Text
                            Catch ex As Exception

                            End Try
                            If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                                elemento = New Integer(objCarteira.bcmb4.Items.Count - 1) {}
                                For contador As Integer = 0 To elemento.Count - 1 Step 1
                                    elemento(contador) = CInt(objCarteira.bcmb4.Items(contador).ToString())
                                Next
                            Else
                                blnVetChecadoLSVCarteira = New Boolean(objCarteira.lsvCarteira.Items.Count - 1) {}
                                strVetColunasLSVCarteira = New String(objCarteira.lsvCarteira.Columns.Count - 1) {}
                                strVetItemsLSVCarteira = New String(objCarteira.lsvCarteira.Items.Count - 1)() {}

                                For linha As Integer = 0 To strVetItemsLSVCarteira.Length - 1 Step 1
                                    strVetItemsLSVCarteira(linha) = New String(objCarteira.lsvCarteira.Columns.Count - 1) {}
                                Next

                                For coluna As Integer = 0 To strVetColunasLSVCarteira.Length - 1 Step 1
                                    strVetColunasLSVCarteira(coluna) = objCarteira.lsvCarteira.Columns(coluna).Text
                                Next

                                intContadorVetChecadoLSVCarteira = 0
                                For linha As Integer = 0 To strVetItemsLSVCarteira.Length - 1 Step 1
                                    blnVetChecadoLSVCarteira(linha) = objCarteira.lsvCarteira.Items(linha).Checked
                                    If blnVetChecadoLSVCarteira(linha) Then
                                        intContadorVetChecadoLSVCarteira += 1
                                    End If

                                    For coluna As Integer = 0 To strVetItemsLSVCarteira(linha).Length - 1 Step 1
                                        strVetItemsLSVCarteira(linha)(coluna) = objCarteira.lsvCarteira.Items(linha).SubItems(coluna).Text
                                    Next
                                Next
                            End If
                            'objDtgv1MinimoValor = objCarteira.dtgv1.Item(0, 0).Value
                            'objDtgv1MaximoValor = objCarteira.dtgv1.Item(0, objCarteira.dtgv1.RowCount - 1).Value
                            objDtgv1MinimoValor = objCarteira.dtgv1.Item(0, objCarteira.dtgv1.RowCount - 1).Value
                            objDtgv1MaximoValor = objCarteira.dtgv1.Item(0, 0).Value
                        Catch
                        Finally
                            Try
                                mtdIniciarThreadGerarCarteiraCautela()

                                objCarteira.bcmb4.Items.Add(String.Empty)
                                objCarteira.bcmb4.Text = objCarteira.bcmb4.Items(0).ToString()
                                objCarteira.bcmb4.Items.RemoveAt(0)
                                objCarteira.bcmb5.Items.Add(String.Empty)
                                objCarteira.bcmb5.Text = objCarteira.bcmb5.Items(0).ToString()
                                objCarteira.bcmb5.Items.RemoveAt(0)
                            Catch ex As Exception

                            End Try
                        End Try
                    Else
                        MessageBox.Show _
                        ( _
                        "Selecione um formulário de Carteiras para criar cautelas de responsabilidade", _
                        "Aviso!", _
                        MessageBoxButtons.OK _
                        )
                    End If
                Case 4
                    If MessageBox.Show("Deseja gerar a(s) cautela(s) do(s) inventário(s) selecionado(s)?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        If (objInventarioBens.lsv1.Columns.Count > 0) Then
                            If (objInventarioBens.lsv1.Items.Count > 0) Then
                                Dim blnChecado As Boolean = False

                                vetLsv = New String(objInventarioBens.lsv1.Items.Count) {}

                                vetLsv(0) = objInventarioBens.lsv1.Columns(0).Text

                                intContadorVetChecadoLSV1 = 0
                                For contador As Integer = 0 To objInventarioBens.lsv1.Items.Count - 1 Step 1
                                    If objInventarioBens.lsv1.Items(contador).Checked Then
                                        blnChecado = True
                                        intContadorVetChecadoLSV1 += 1
                                        vetLsv(contador + 1) = objInventarioBens.lsv1.Items(contador).Text
                                    Else
                                        vetLsv(contador + 1) = Nothing
                                    End If
                                Next

                                If Not blnChecado Then
                                    mtdIniciarThreadGerarInventarioCautela(frmInventarioBens.vetCamposTabelaInventarioBens(0), CStr(frmInventarioBens.Numero_Inventario))
                                Else
                                    mtdIniciarThreadGerarInventarioCautela(vetLsv)
                                End If
                            Else
                                mtdIniciarThreadGerarInventarioCautela(frmInventarioBens.vetCamposTabelaInventarioBens(0), CStr(frmInventarioBens.Numero_Inventario))
                            End If
                        Else
                            mtdIniciarThreadGerarInventarioCautela(frmInventarioBens.vetCamposTabelaInventarioBens(0), CStr(frmInventarioBens.Numero_Inventario))
                        End If
                    Else
                        mtdAbortarThreadGerarInventarioCautela(True)
                    End If
            End Select
        End Sub

        Public Shared Function mtdProgresso(ByVal NumeroParcial As Integer, ByVal NumeroTotal As Integer) As Integer
            Dim Progresso As Integer = 0

            If NumeroTotal <> 0 Then
                Progresso = CInt(Math.Truncate((CDbl(NumeroParcial) * 100) / CDbl(NumeroTotal)))
            Else
                If NumeroParcial < 1 Then
                    Progresso = 0
                Else
                    Progresso = 100
                End If
            End If

            Progresso = If(Progresso >= 0, Progresso, 0)
            Progresso = If(Progresso <= 100, Progresso, 100)

            Return Progresso
        End Function

        Public Sub mtdExibirNotificacao(ByVal Notificacao As String)
            mtdExibirNotificacao(Notificacao, "Notificação")
        End Sub

        Public Sub mtdExibirNotificacao(ByVal Notificacao As String, ByVal Titulo As String)
            ntf1.BalloonTipTitle = Titulo
            ntf1.BalloonTipIcon = ToolTipIcon.Info
            ntf1.BalloonTipText = Notificacao
            If Notificacao.Length < 64 Then
                ntf1.Text = Notificacao
            Else
                Try
                    ntf1.Text = Notificacao.Replace(" ", String.Empty)
                Catch ex As Exception
                    ntf1.Text = "Ocorreu algum erro ao exibir a mensagem."
                End Try
            End If

            If Not blnOcultarMensagens Then
                ntf1.ShowBalloonTip(10)
            End If
        End Sub

        Private blnOcultarMensagens As Boolean = False

        Private Function mtdExibirOcultarMensagens() As Boolean
            If Not blnOcultarMensagens Then
                csmsMensagens.Text = "&Exibir Mensagens"
                smnMensagens.Text = "&Exibir Mensagens"
                blnOcultarMensagens = True
            Else
                csmsMensagens.Text = "&Ocultar Mensagens"
                smnMensagens.Text = "&Ocultar Mensagens"
                blnOcultarMensagens = False
            End If

            Return blnOcultarMensagens
        End Function

        Private Function mtdExibirOcultarIconeNotificador() As Boolean
            If ntf1.Visible Then
                csmsIconeNotificador.Text = "Exibir &Ícone Notificador"
                smnIconeNotificador.Text = "Exibir &Ícone Notificador"
                ntf1.Visible = False
            Else
                csmsIconeNotificador.Text = "Ocultar &Ícone Notificador"
                smnIconeNotificador.Text = "Ocultar &Ícone Notificador"
                ntf1.Visible = True
            End If

            Return ntf1.Visible
        End Function

        Private Sub csmsMensagens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csmsMensagens.Click
            mtdExibirOcultarMensagens()
        End Sub

        Private Sub csmsIconeNotificador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csmsIconeNotificador.Click
            mtdExibirOcultarIconeNotificador()
        End Sub

        Private Sub csmsParar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csmsParar.Click
            If blnSucessoExportarPlanilhaExcelRelatorio Then
                mtdAbortarThreadExportarPlanilhaExcelRelatorio(True)
            End If
            If blnSucessoExportarPlanilhaExcelSap_R3 Then
                mtdAbortarThreadExportarPlanilhaExcelSap_R3(True)
            End If
            If blnSucessoGerarCarteiraCautela Then
                mtdAbortarThreadGerarCarteiraCautela(True)
            End If
            If blnSucessoGerarInventarioCautela Then
                mtdAbortarThreadGerarInventarioCautela(True)
            End If
            If blnSucessoGerarInventarioMBP Then
                mtdAbortarThreadGerarInventarioMBP(True)
            End If
            If blnSucessoGerarMBPCautela Then
                mtdAbortarThreadGerarMBPCautela(True)
            End If

            If blnSucessoExportarDocumentoCarteira Then
                mtdAbortarThreadExportarDocumentoCarteira(True)
            End If
            If blnSucessoExportarDocumentoCautela Then
                mtdAbortarThreadExportarDocumentoCarteira(True)
            End If
            If blnSucessoExportarDocumentoMBP Then
                mtdAbortarThreadExportarDocumentoMBP()
            End If
            If blnSucessoExportarDocumentoInventarioBens Then
                mtdAbortarThreadExportarDocumentoInventarioBens(True)
            End If
            If blnSucessoExportarDocumentoBens Then
                mtdAbortarThreadExportarDocumentoBens(True)
            End If

            If blnSucessoImprimirCarteira Then
                mtdAbortarThreadImprimirCarteira(True)
            End If
            If blnSucessoImprimirCautela Then
                mtdAbortarThreadImprimirCautela(True)
            End If
            If blnSucessoImprimirInventarioBens Then
                mtdAbortarThreadImprimirInventarioBens(True)
            End If
            If blnSucessoImprimirBens Then
                mtdAbortarThreadImprimirBens(True)
            End If
            If blnSucessoImprimirMBP Then
                mtdAbortarThreadImprimirMBP(True)
            End If

            If objImportadorBaseDadosPrincipal.blnSucessoImportarTabelaBensEletronorteCentroCustoPrincipal Then
                objImportadorBaseDadosPrincipal.mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoPrincipal(True)
            End If
            If objImportadorBaseDadosColetor.blnSucessoImportarTabelaBensEletronorteCentroCustoColetor Then
                objImportadorBaseDadosColetor.mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor(True)
            End If

            If objBens.blnSucessoImportarTabelaBensEletronortePrincipal Then
                objBens.mtdAbortarThreadImportarTabelaBensEletronortePrincipal(True)
            End If
            If objBens.blnSucessoImportarTabelaBensEletronorteColetor Then
                objBens.mtdAbortarThreadImportarTabelaBensEletronorteColetor(True)
            End If
            If objCADU.blnSucessoImportarTabelaEmpregadosPrincipal Then
                objCADU.mtdAbortarThreadImportarTabelaEmpregadosPrincipal(True)
            End If
            If objCADU.blnSucessoImportarTabelaEmpregadosColetor Then
                objCADU.mtdAbortarThreadImportarTabelaEmpregadosColetor(True)
            End If
            If objCentroCusto.blnSucessoImportarTabelaCentroCustoPrincipal Then
                objCentroCusto.mtdAbortarThreadImportarTabelaCentroCustoPrincipal(True)
            End If
            If objCentroCusto.blnSucessoImportarTabelaCentroCustoColetor Then
                objCentroCusto.mtdAbortarThreadImportarTabelaCentroCustoColetor(True)
            End If
            If objInventarioBens.blnSucessoImportarTabelaInventarioBensPrincipal Then
                objInventarioBens.mtdAbortarThreadImportarTabelaInventarioBensPrincipal(True)
            End If
            If objInventarioBens.blnSucessoImportarTabelaInventarioBensColetor Then
                objInventarioBens.mtdAbortarThreadImportarTabelaInventarioBensColetor(True)
            End If
            If objInventarioBens.blnSucessoImportarTabelaInventarioBensPrincipal Then
                objInventarioBens.mtdAbortarThreadImportarTabelaInventarioBensPrincipal(True)
            End If
            If objInventarioBens.blnSucessoImportarTabelaInventarioBensColetor Then
                objInventarioBens.mtdAbortarThreadImportarTabelaInventarioBensColetor(True)
            End If
        End Sub

        Private Sub csmsSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles csmsSair.Click
            Me.Close()
        End Sub

        Private Sub smnMensagens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnMensagens.Click
            mtdExibirOcultarMensagens()
        End Sub

        Private Sub smnIconeNotificador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnIconeNotificador.Click
            mtdExibirOcultarIconeNotificador()
        End Sub

        Private Sub tmrSalvarBancoDados_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSalvarBancoDados.Tick
            mtdIniciarThreadSalvarBancoDados()
        End Sub

        Private objCodigoBarras As frmCodigoBarras = New frmCodigoBarras

        Private Sub smnCodigoBarraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnCodigoBarras.Click
            Try
                objCodigoBarras = New frmCodigoBarras()
                objCodigoBarras.MdiParent = Me
                objCodigoBarras.Show()
            Catch ex As Exception

            End Try
        End Sub

        Public Function mtdPreencherLsv(ByRef lsv As System.Windows.Forms.ListView, ByRef grpb As System.Windows.Forms.TabControl, ByVal Tabela As String, ByVal CampoSelecionado As String) As String
            Dim SQL As String = String.Empty

            Try
                Dim CampoContador As String = "Contador"
                lsv.Clear()
                'define o modo de exibição do listview 
                lsv.View = System.Windows.Forms.View.Details
                ' permite o usuario editar o item
                lsv.LabelEdit = False
                ' permite o usuario rearranjar as colunas
                lsv.AllowColumnReorder = True
                ' exibe as caixas de marcacao (check boxes.)
                lsv.CheckBoxes = True
                ' seleciona um item e subitem quando a seleção é feita
                lsv.FullRowSelect = True
                ' exibe as linhas
                lsv.GridLines = True
                ' ordena os itens na list na ordem ascendente
                Dim objBDPrincipal As New clsImplementacaoBancoDados _
                        ( _
                        frmPrincipal.strConexaoBancoDadosPrincipal, _
                        String.Format _
                        ( _
                        "SELECT DISTINCT {0}, Count({0}) AS {1} FROM {2} GROUP BY {0} ORDER BY {0};", _
                        CampoSelecionado, _
                        CampoContador, _
                        Tabela _
                        ), _
                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
                        )
                objBDPrincipal.mtdAbrirConexao()
                objBDPrincipal.mtdExecutarComando()
                SQL = objBDPrincipal.prpComando
                Dim numMaxRegistro As Integer = objBDPrincipal.mtdNumeroLinhas() - 1
                objBDPrincipal.prpAjustadorDados = New DataSet()
                objBDPrincipal.mtdAdaptadorDados()
                objBDPrincipal.mtdDefinirLeitorDados()
                Dim numColuna As Integer = objBDPrincipal.mtdNumeroColunas() - 1

                lsv.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(0), 150, HorizontalAlignment.Left)
                lsv.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(1), 100, HorizontalAlignment.Left)

                Dim numLinha As Integer = 0

                While objBDPrincipal.mtdProximoRegistro()
                    For contador As Integer = 0 To numColuna Step 1
                        Dim item As ListViewItem = Nothing
                        Dim subitem As ListViewItem.ListViewSubItem = Nothing
                        If contador = 0 Then
                            item = New ListViewItem(objBDPrincipal.mtdObterValorRegistro(contador).ToString(), 0)
                            lsv.Items.Add(item)
                        Else
                            subitem = New ListViewItem.ListViewSubItem()
                            subitem.Text = objBDPrincipal.mtdObterValorRegistro(contador).ToString()
                            lsv.Items(numLinha).SubItems.Add(subitem)
                        End If
                    Next
                    numLinha += 1
                End While

                objBDPrincipal.mtdFecharConexao()

                ' marca o ckeckbox para o item
                'item.Checked = True
                grpb.Controls.Add(lsv)
            Catch
            End Try
            Return SQL
        End Function

        'Public intRepeticao As Integer = 0

        Public Function mtdPreencherDtg _
            ( _
            ByRef lsv As System.Windows.Forms.ListView, _
            ByRef grpb As System.Windows.Forms.TabControl, _
            ByVal NumeroLinhas As UInteger, _
            ByVal Campo As String, _
            ByVal Tabela As String, _
            ByVal TabelaSelecionadora As String, _
            ByVal CampoSelecionador As String, _
            ByVal DadoSelecionador As String, _
            ByVal CampoOrdenador As String, _
            ByVal Crescente As Boolean, _
            ByVal Repeticao As Integer _
            ) As String
            Dim SQL As String = String.Empty

            lsv.Clear()
            'define o modo de exibição do listview 
            lsv.View = System.Windows.Forms.View.Details
            ' permite o usuario editar o item
            lsv.LabelEdit = False
            ' permite o usuario rearranjar as colunas
            lsv.AllowColumnReorder = True
            ' exibe as caixas de marcacao (check boxes.)
            lsv.CheckBoxes = True
            ' seleciona um item e subitem quando a seleção é feita
            lsv.FullRowSelect = True
            ' exibe as linhas
            lsv.GridLines = True
            ' ordena os itens na list na ordem ascendente

            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor ' set the wait cursor
            'Do some work

            Dim CampoContador As String = "Contador"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

            objImplementacaoBancoDados.mtdAbrirConexao()
            objImplementacaoBancoDados.mtdExecutarComando _
            ( _
            String.Format _
                ( _
                "SELECT DISTINCT {0}{1}, Count({1}) AS {2} FROM {3} GROUP BY {1} HAVING ({4}Count({1}) > {7}) ORDER BY {5}{6};", _
                IIf(NumeroLinhas <> 0, String.Format("TOP ({0}) ", NumeroLinhas), String.Empty), _
                Campo, _
                CampoContador, _
                Tabela, _
                IIf(DadoSelecionador <> String.Empty, String.Format("{0}.{1} LIKE {2} AND ", TabelaSelecionadora, CampoSelecionador, DadoSelecionador), String.Empty), _
                CampoOrdenador, _
                IIf(Crescente, String.Empty, " DESC"), _
                Repeticao _
                ) _
            )

            SQL = objImplementacaoBancoDados.prpComando

            Dim numMaxRegistro As Integer = objImplementacaoBancoDados.mtdNumeroLinhas() - 1
            objImplementacaoBancoDados.prpAjustadorDados = New DataSet()
            objImplementacaoBancoDados.mtdAdaptadorDados()
            objImplementacaoBancoDados.mtdDefinirLeitorDados()
            Dim numColuna As Integer = objImplementacaoBancoDados.mtdNumeroColunas() - 1

            lsv.Columns.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(0), 150, HorizontalAlignment.Left)
            lsv.Columns.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(1), 100, HorizontalAlignment.Left)

            Dim numLinha As Integer = 0

            While objImplementacaoBancoDados.mtdProximoRegistro()
                For contador As Integer = 0 To numColuna Step 1
                    Dim item As ListViewItem = Nothing
                    Dim subitem As ListViewItem.ListViewSubItem = Nothing
                    If contador = 0 Then
                        item = New ListViewItem(objImplementacaoBancoDados.mtdObterValorRegistro(contador).ToString(), 0)
                        lsv.Items.Add(item)
                    Else
                        subitem = New ListViewItem.ListViewSubItem()
                        subitem.Text = objImplementacaoBancoDados.mtdObterValorRegistro(contador).ToString()
                        lsv.Items(numLinha).SubItems.Add(subitem)
                    End If
                Next
                numLinha += 1
            End While

            objImplementacaoBancoDados.mtdFecharConexao()

            ' marca o ckeckbox para o item
            'item.Checked = True
            grpb.Controls.Add(lsv)
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default 'restore the old cursor

            objImplementacaoBancoDados.Dispose()

            Return SQL
        End Function

        Public Function mtdPreencherDtg_ _
            ( _
            ByRef lsv As System.Windows.Forms.ListView, _
            ByRef grpb As System.Windows.Forms.TabControl, _
            ByVal NumeroLinhas As UInteger, _
            ByVal Campo As String, _
            ByVal Tabela As String, _
            ByVal Tabela2 As String, _
            ByVal TabelaSelecionadora As String, _
            ByVal CampoSelecionador As String, _
            ByVal DadoSelecionador As String, _
            ByVal CampoOrdenador As String, _
            ByVal Crescente As Boolean, _
            ByVal Repeticao As Integer _
            ) As String
            Dim SQL As String = String.Empty

            lsv.Clear()
            'define o modo de exibição do listview 
            lsv.View = System.Windows.Forms.View.Details
            ' permite o usuario editar o item
            lsv.LabelEdit = False
            ' permite o usuario rearranjar as colunas
            lsv.AllowColumnReorder = True
            ' exibe as caixas de marcacao (check boxes.)
            lsv.CheckBoxes = True
            ' seleciona um item e subitem quando a seleção é feita
            lsv.FullRowSelect = True
            ' exibe as linhas
            lsv.GridLines = True
            ' ordena os itens na list na ordem ascendente

            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor ' set the wait cursor
            'Do some work

            Dim CampoContador As String = "Contador"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

            objImplementacaoBancoDados.mtdAbrirConexao()
            objImplementacaoBancoDados.mtdExecutarComando _
            ( _
            String.Format _
                ( _
                "SELECT DISTINCT {0}{1}, Count({1}) AS {2} FROM {3} INNER JOIN {4} ON {3}.Codigo={4}.Codigo GROUP BY {1} HAVING ({5}Count({2}) > {8}) ORDER BY {6}{7};", _
                IIf(NumeroLinhas <> 0, String.Format("TOP ({0}) ", NumeroLinhas), String.Empty), _
                Campo, _
                CampoContador, _
                Tabela, _
                Tabela2, _
                IIf(DadoSelecionador <> String.Empty, String.Format("{0}.{1} LIKE {2} AND ", TabelaSelecionadora, CampoSelecionador, DadoSelecionador), String.Empty), _
                CampoOrdenador, _
                IIf(Crescente, String.Empty, " DESC"), _
                Repeticao _
                ) _
            )

            SQL = objImplementacaoBancoDados.prpComando

            Dim numMaxRegistro As Integer = objImplementacaoBancoDados.mtdNumeroLinhas() - 1
            objImplementacaoBancoDados.prpAjustadorDados = New DataSet()
            objImplementacaoBancoDados.mtdAdaptadorDados()
            objImplementacaoBancoDados.mtdDefinirLeitorDados()
            Dim numColuna As Integer = objImplementacaoBancoDados.mtdNumeroColunas() - 1

            lsv.Columns.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(0), 150, HorizontalAlignment.Left)
            lsv.Columns.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(1), 100, HorizontalAlignment.Left)

            Dim numLinha As Integer = 0

            While objImplementacaoBancoDados.mtdProximoRegistro()
                For contador As Integer = 0 To numColuna Step 1
                    Dim item As ListViewItem = Nothing
                    Dim subitem As ListViewItem.ListViewSubItem = Nothing
                    If contador = 0 Then
                        item = New ListViewItem(objImplementacaoBancoDados.mtdObterValorRegistro(contador).ToString(), 0)
                        lsv.Items.Add(item)
                    Else
                        subitem = New ListViewItem.ListViewSubItem()
                        subitem.Text = objImplementacaoBancoDados.mtdObterValorRegistro(contador).ToString()
                        lsv.Items(numLinha).SubItems.Add(subitem)
                    End If
                Next
                numLinha += 1
            End While

            objImplementacaoBancoDados.mtdFecharConexao()

            ' marca o ckeckbox para o item
            'item.Checked = True
            grpb.Controls.Add(lsv)
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default 'restore the old cursor

            objImplementacaoBancoDados.Dispose()

            Return SQL
        End Function

        Public Function mtdConsultarItensRepetidosCampoInformado _
            ( _
            ByRef lsv As System.Windows.Forms.ListView, _
            ByRef grpb As System.Windows.Forms.TabControl, _
            ByVal Campo As String, _
            ByVal Tabela As String, _
            ByVal TabelaSelecionadora As String, _
            ByVal CampoSelecionador As String, _
            ByVal DadoSelecionador As String, _
            ByVal CampoOrdenador As String, _
            ByVal Crescente As Boolean, _
            ByVal Repeticao As Integer _
            ) As String
            Dim SQL As String = String.Empty

            Try
                Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

                Dim strCadeiaCarecteres As String = "'%{0}%'"

                objImplementacaoBancoDados.mtdSelecionarDados("*", TabelaSelecionadora)
                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                If objImplementacaoBancoDados.mtdProximoRegistro() Then
                    Select Case (objImplementacaoBancoDados.mtdObterTipoRegistro(objImplementacaoBancoDados.mtdObterNumeroColuna(CampoSelecionador)).ToString())
                        Case "System.Byte[]"
                            strCadeiaCarecteres = "{0}"
                        Case "System.DateTime"
                            strCadeiaCarecteres = "{0}"
                        Case "System.Int64"
                            strCadeiaCarecteres = "'%{0}%'"
                        Case "System.String"
                            strCadeiaCarecteres = "'%{0}%'"
                    End Select

                    SQL = mtdPreencherDtg _
                    ( _
                    lsv, _
                    grpb, _
                    0, _
                    Campo, _
                    Tabela, _
                    TabelaSelecionadora, _
                    CampoSelecionador, _
                    DadoSelecionador, _
                    CampoOrdenador, _
                    Crescente, _
                    Repeticao _
                    )
                End If

                objImplementacaoBancoDados.Dispose()
            Catch ex As System.Exception
                Dim strExcecao As String = "mtdConsultarItensRepetidosCampoInformado: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
                'frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            End Try

            Return SQL
        End Function

        Public Function mtdConsultarItensRepetidosCampoInformado_ _
            ( _
            ByRef lsv As System.Windows.Forms.ListView, _
            ByRef grpb As System.Windows.Forms.TabControl, _
            ByVal Campo As String, _
            ByVal Tabela As String, _
            ByVal Tabela2 As String, _
            ByVal TabelaSelecionadora As String, _
            ByVal CampoSelecionador As String, _
            ByVal DadoSelecionador As String, _
            ByVal CampoOrdenador As String, _
            ByVal Crescente As Boolean, _
            ByVal Repeticao As Integer _
            ) As String
            Dim SQL As String = String.Empty

            Try
                Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

                Dim strCadeiaCarecteres As String = "'%{0}%'"

                objImplementacaoBancoDados.mtdSelecionarDados("*", TabelaSelecionadora)
                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                If objImplementacaoBancoDados.mtdProximoRegistro() Then
                    Select Case (objImplementacaoBancoDados.mtdObterTipoRegistro(objImplementacaoBancoDados.mtdObterNumeroColuna(CampoSelecionador)).ToString())
                        Case "System.Byte[]"
                            strCadeiaCarecteres = "{0}"
                        Case "System.DateTime"
                            strCadeiaCarecteres = "{0}"
                        Case "System.Int64"
                            strCadeiaCarecteres = "'%{0}%'"
                        Case "System.String"
                            strCadeiaCarecteres = "'%{0}%'"
                    End Select

                    SQL = mtdPreencherDtg_ _
                    ( _
                    lsv, _
                    grpb, _
                    0, _
                    Campo, _
                    Tabela, _
                    Tabela2, _
                    TabelaSelecionadora, _
                    CampoSelecionador, _
                    DadoSelecionador, _
                    CampoOrdenador, _
                    Crescente, _
                    Repeticao _
                    )
                End If

                objImplementacaoBancoDados.Dispose()
            Catch ex As System.Exception
                Dim strExcecao As String = "mtdConsultarItensRepetidosCampoInformado: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
                'frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            End Try

            Return SQL
        End Function

        Public Function mtdPreencherDtg _
            ( _
            ByRef lsv As System.Windows.Forms.ListView, _
            ByRef grpb As System.Windows.Forms.TabControl, _
            ByVal NumeroLinhas As UInteger, _
            ByVal Campo As String, _
            ByVal Campo2 As String, _
            ByVal Tabela As String, _
            ByVal TabelaSelecionadora As String, _
            ByVal CampoSelecionador As String, _
            ByVal DadoSelecionador As String, _
            ByVal CampoOrdenador As String, _
            ByVal Crescente As Boolean, _
            ByVal Repeticao As Integer _
            ) As String
            Dim SQL As String = String.Empty

            lsv.Clear()
            'define o modo de exibição do listview 
            lsv.View = System.Windows.Forms.View.Details
            ' permite o usuario editar o item
            lsv.LabelEdit = False
            ' permite o usuario rearranjar as colunas
            lsv.AllowColumnReorder = True
            ' exibe as caixas de marcacao (check boxes.)
            lsv.CheckBoxes = True
            ' seleciona um item e subitem quando a seleção é feita
            lsv.FullRowSelect = True
            ' exibe as linhas
            lsv.GridLines = True
            ' ordena os itens na list na ordem ascendente

            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor ' set the wait cursor
            'Do some work

            Dim CampoContador As String = "Contador"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

            objImplementacaoBancoDados.mtdAbrirConexao()
            objImplementacaoBancoDados.mtdExecutarComando _
            ( _
            String.Format _
                ( _
                "SELECT DISTINCT {0}{1}, {2}, Count({1}) AS {3} FROM {4} GROUP BY {2}, {1} HAVING ({5}Count({1}) > {8}) ORDER BY {6}{7};", _
                IIf(NumeroLinhas <> 0, String.Format("TOP ({0}) ", NumeroLinhas), String.Empty), _
                Campo, _
                Campo2, _
                CampoContador, _
                Tabela, _
                IIf(DadoSelecionador <> String.Empty, String.Format("{0}.{1} LIKE {2} AND ", TabelaSelecionadora, CampoSelecionador, DadoSelecionador), String.Empty), _
                CampoOrdenador, _
                IIf(Crescente, String.Empty, " DESC"), _
                Repeticao - 1 _
                ) _
            )

            SQL = objImplementacaoBancoDados.prpComando

            Dim numMaxRegistro As Integer = objImplementacaoBancoDados.mtdNumeroLinhas() - 1
            objImplementacaoBancoDados.prpAjustadorDados = New DataSet()
            objImplementacaoBancoDados.mtdAdaptadorDados()
            objImplementacaoBancoDados.mtdDefinirLeitorDados()
            Dim numColuna As Integer = objImplementacaoBancoDados.mtdNumeroColunas() - 1

            lsv.Columns.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(0), 150, HorizontalAlignment.Left)
            lsv.Columns.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(1), 100, HorizontalAlignment.Left)
            lsv.Columns.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(2), 100, HorizontalAlignment.Left)

            Dim numLinha As Integer = 0

            While objImplementacaoBancoDados.mtdProximoRegistro()
                For contador As Integer = 0 To numColuna Step 1
                    Dim item As ListViewItem = Nothing
                    Dim subitem As ListViewItem.ListViewSubItem = Nothing
                    If contador = 0 Then
                        item = New ListViewItem(objImplementacaoBancoDados.mtdObterValorRegistro(contador).ToString(), 0)
                        lsv.Items.Add(item)
                    Else
                        subitem = New ListViewItem.ListViewSubItem()
                        subitem.Text = objImplementacaoBancoDados.mtdObterValorRegistro(contador).ToString()
                        lsv.Items(numLinha).SubItems.Add(subitem)
                    End If
                Next
                numLinha += 1
            End While

            objImplementacaoBancoDados.mtdFecharConexao()

            ' marca o ckeckbox para o item
            'item.Checked = True
            grpb.Controls.Add(lsv)
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default 'restore the old cursor

            objImplementacaoBancoDados.Dispose()

            Return SQL
        End Function

        Public Function mtdPreencherDtg_ _
            ( _
            ByRef lsv As System.Windows.Forms.ListView, _
            ByRef grpb As System.Windows.Forms.TabControl, _
            ByVal NumeroLinhas As UInteger, _
            ByVal Campo As String, _
            ByVal Campo2 As String, _
            ByVal Tabela As String, _
            ByVal Tabela2 As String, _
            ByVal TabelaSelecionadora As String, _
            ByVal CampoSelecionador As String, _
            ByVal DadoSelecionador As String, _
            ByVal CampoOrdenador As String, _
            ByVal Crescente As Boolean, _
            ByVal Repeticao As Integer _
            ) As String
            Dim SQL As String = String.Empty

            lsv.Clear()
            'define o modo de exibição do listview 
            lsv.View = System.Windows.Forms.View.Details
            ' permite o usuario editar o item
            lsv.LabelEdit = False
            ' permite o usuario rearranjar as colunas
            lsv.AllowColumnReorder = True
            ' exibe as caixas de marcacao (check boxes.)
            lsv.CheckBoxes = True
            ' seleciona um item e subitem quando a seleção é feita
            lsv.FullRowSelect = True
            ' exibe as linhas
            lsv.GridLines = True
            ' ordena os itens na list na ordem ascendente

            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor ' set the wait cursor
            'Do some work

            Dim CampoContador As String = "Contador"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

            objImplementacaoBancoDados.mtdAbrirConexao()
            objImplementacaoBancoDados.mtdExecutarComando _
            ( _
            String.Format _
                ( _
                "SELECT DISTINCT {0}{1}, {2}, Count({1}) AS {3} FROM {4} INNER JOIN {5} ON {4}.Codigo={5}.Codigo GROUP BY {2}, {1} HAVING ({6}Count({2}) > {9}) ORDER BY {7}{8};", _
                IIf(NumeroLinhas <> 0, String.Format("TOP ({0}) ", NumeroLinhas), String.Empty), _
                Campo, _
                Campo2, _
                CampoContador, _
                Tabela, _
                Tabela2, _
                IIf(DadoSelecionador <> String.Empty, String.Format("{0}.{1} LIKE {2} AND ", TabelaSelecionadora, CampoSelecionador, DadoSelecionador), String.Empty), _
                CampoOrdenador, _
                IIf(Crescente, String.Empty, " DESC"), _
                Repeticao - 1 _
                ) _
            )

            SQL = objImplementacaoBancoDados.prpComando

            Dim numMaxRegistro As Integer = objImplementacaoBancoDados.mtdNumeroLinhas() - 1
            objImplementacaoBancoDados.prpAjustadorDados = New DataSet()
            objImplementacaoBancoDados.mtdAdaptadorDados()
            objImplementacaoBancoDados.mtdDefinirLeitorDados()
            Dim numColuna As Integer = objImplementacaoBancoDados.mtdNumeroColunas() - 1

            lsv.Columns.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(0), 150, HorizontalAlignment.Left)
            lsv.Columns.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(1), 100, HorizontalAlignment.Left)
            lsv.Columns.Add(objImplementacaoBancoDados.mtdObterCabecalhoColunas(2), 100, HorizontalAlignment.Left)

            Dim numLinha As Integer = 0

            While objImplementacaoBancoDados.mtdProximoRegistro()
                For contador As Integer = 0 To numColuna Step 1
                    Dim item As ListViewItem = Nothing
                    Dim subitem As ListViewItem.ListViewSubItem = Nothing
                    If contador = 0 Then
                        item = New ListViewItem(objImplementacaoBancoDados.mtdObterValorRegistro(contador).ToString(), 0)
                        lsv.Items.Add(item)
                    Else
                        subitem = New ListViewItem.ListViewSubItem()
                        subitem.Text = objImplementacaoBancoDados.mtdObterValorRegistro(contador).ToString()
                        lsv.Items(numLinha).SubItems.Add(subitem)
                    End If
                Next
                numLinha += 1
            End While

            objImplementacaoBancoDados.mtdFecharConexao()

            ' marca o ckeckbox para o item
            'item.Checked = True
            grpb.Controls.Add(lsv)
            'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default 'restore the old cursor

            objImplementacaoBancoDados.Dispose()

            Return SQL
        End Function

        Public Function mtdConsultarItensRepetidosCampoInformado _
            ( _
            ByRef lsv As System.Windows.Forms.ListView, _
            ByRef grpb As System.Windows.Forms.TabControl, _
            ByVal Campo As String, _
            ByVal Campo2 As String, _
            ByVal Tabela As String, _
            ByVal TabelaSelecionadora As String, _
            ByVal CampoSelecionador As String, _
            ByVal DadoSelecionador As String, _
            ByVal CampoOrdenador As String, _
            ByVal Crescente As Boolean, _
            ByVal Repeticao As Integer _
            ) As String
            Dim SQL As String = String.Empty

            Try
                Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

                Dim strCadeiaCarecteres As String = "'%{0}%'"

                objImplementacaoBancoDados.mtdSelecionarDados("*", TabelaSelecionadora)
                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                If objImplementacaoBancoDados.mtdProximoRegistro() Then
                    Select Case (objImplementacaoBancoDados.mtdObterTipoRegistro(objImplementacaoBancoDados.mtdObterNumeroColuna(CampoSelecionador)).ToString())
                        Case "System.Byte[]"
                            strCadeiaCarecteres = "{0}"
                        Case "System.DateTime"
                            strCadeiaCarecteres = "{0}"
                        Case "System.Int64"
                            strCadeiaCarecteres = "'%{0}%'"
                        Case "System.String"
                            strCadeiaCarecteres = "'%{0}%'"
                    End Select

                    SQL = mtdPreencherDtg _
                    ( _
                    lsv, _
                    grpb, _
                    0, _
                    Campo, _
                    Campo2, _
                    Tabela, _
                    TabelaSelecionadora, _
                    CampoSelecionador, _
                    DadoSelecionador, _
                    CampoOrdenador, _
                    Crescente, _
                    Repeticao _
                    )
                End If

                objImplementacaoBancoDados.Dispose()
            Catch ex As System.Exception
                Dim strExcecao As String = "mtdConsultarItensRepetidosCampoInformado: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
                'frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            End Try

            Return SQL
        End Function

        Public Function mtdConsultarItensRepetidosCampoInformado_ _
            ( _
            ByRef lsv As System.Windows.Forms.ListView, _
            ByRef grpb As System.Windows.Forms.TabControl, _
            ByVal Campo As String, _
            ByVal Campo2 As String, _
            ByVal Tabela As String, _
            ByVal Tabela2 As String, _
            ByVal TabelaSelecionadora As String, _
            ByVal CampoSelecionador As String, _
            ByVal DadoSelecionador As String, _
            ByVal CampoOrdenador As String, _
            ByVal Crescente As Boolean, _
            ByVal Repeticao As Integer _
            ) As String
            Dim SQL As String = String.Empty

            Try
                Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

                Dim strCadeiaCarecteres As String = "'%{0}%'"

                objImplementacaoBancoDados.mtdSelecionarDados("*", TabelaSelecionadora)
                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                If objImplementacaoBancoDados.mtdProximoRegistro() Then
                    Select Case (objImplementacaoBancoDados.mtdObterTipoRegistro(objImplementacaoBancoDados.mtdObterNumeroColuna(CampoSelecionador)).ToString())
                        Case "System.Byte[]"
                            strCadeiaCarecteres = "{0}"
                        Case "System.DateTime"
                            strCadeiaCarecteres = "{0}"
                        Case "System.Int64"
                            strCadeiaCarecteres = "'%{0}%'"
                        Case "System.String"
                            strCadeiaCarecteres = "'%{0}%'"
                    End Select

                    SQL = mtdPreencherDtg_ _
                    ( _
                    lsv, _
                    grpb, _
                    0, _
                    Campo, _
                    Campo2, _
                    Tabela, _
                    Tabela2, _
                    TabelaSelecionadora, _
                    CampoSelecionador, _
                    DadoSelecionador, _
                    CampoOrdenador, _
                    Crescente, _
                    Repeticao _
                    )
                End If

                objImplementacaoBancoDados.Dispose()
            Catch ex As System.Exception
                Dim strExcecao As String = "mtdConsultarItensRepetidosCampoInformado: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
                'frmPrincipal.mtdGerarRelatorioErros(string.Format(@"{0}Relatorio_Erros.txt", frmPrincipal.DiretorioEnderecoAplicativo), strExcecao);
            End Try

            Return SQL
        End Function

        Public blnCrescente As Boolean = True

        Public Sub mtdPreencherCmb(ByRef cmb As System.Windows.Forms.ComboBox, ByVal CampoInicial As String, ByVal vetCampos As String())
            mtdPreencherCmb(cmb, CampoInicial, vetCampos, Nothing, 0)
        End Sub

        Public Sub mtdPreencherCmb(ByRef cmb As System.Windows.Forms.ComboBox, ByVal CampoInicial As String, ByVal vetCampos As String(), ByVal IndiceInicial As Integer)
            mtdPreencherCmb(cmb, CampoInicial, vetCampos, Nothing, IndiceInicial)
        End Sub

        Public Sub mtdPreencherCmb(ByRef cmb As System.Windows.Forms.ComboBox, ByVal CampoInicial As String, ByVal vetCampos As String(), ByVal vetCampos2 As String(), ByVal IndiceInicial As Integer)
            If cmb.Items.Count = 0 Then
                If CampoInicial <> String.Empty Then
                    cmb.Items.Add(CampoInicial)
                End If
                If vetCampos IsNot Nothing Then
                    If vetCampos.Length > 0 Then
                        cmb.Items.AddRange(vetCampos)
                    End If
                End If
                If vetCampos2 IsNot Nothing Then
                    If vetCampos2.Length > 0 Then
                        cmb.Items.AddRange(vetCampos2)
                    End If
                End If
                cmb.SelectedIndex = IndiceInicial
            Else
                cmb.SelectedIndex = IndiceInicial
            End If

            blnCrescente = True
        End Sub

        Public Sub mtdPreencherBcmb(ByRef bcmb As System.Windows.Forms.ToolStripComboBox, ByVal CampoInicial As String, ByVal vetCampos As String())
            mtdPreencherBcmb(bcmb, CampoInicial, vetCampos, Nothing, 0)
        End Sub

        Public Sub mtdPreencherBcmb(ByRef bcmb As System.Windows.Forms.ToolStripComboBox, ByVal CampoInicial As String, ByVal vetCampos As String(), ByVal IndiceInicial As Integer)
            mtdPreencherBcmb(bcmb, CampoInicial, vetCampos, Nothing, IndiceInicial)
        End Sub

        Public Sub mtdPreencherBcmb(ByRef bcmb As System.Windows.Forms.ToolStripComboBox, ByVal CampoInicial As String, ByVal vetCampos As String(), ByVal vetCampos2 As String(), ByVal IndiceInicial As Integer)
            If bcmb.Items.Count = 0 Then
                If CampoInicial <> String.Empty Then
                    bcmb.Items.Add(CampoInicial)
                End If
                If vetCampos IsNot Nothing Then
                    If vetCampos.Length > 0 Then
                        bcmb.Items.AddRange(vetCampos)
                    End If
                End If
                If vetCampos2 IsNot Nothing Then
                    If vetCampos2.Length > 0 Then
                        bcmb.Items.AddRange(vetCampos2)
                    End If
                End If
                bcmb.SelectedIndex = IndiceInicial
            Else
                bcmb.SelectedIndex = IndiceInicial
            End If

            blnCrescente = True
        End Sub

        Private blnChecarItens As Boolean = True

        Public Sub mtdChecarItens(ByRef lsv As System.Windows.Forms.ListView)
            If blnChecarItens Then
                For contador As Integer = 0 To lsv.Items.Count - 1 Step 1
                    lsv.Items(contador).Checked = True
                Next
                blnChecarItens = False
            Else
                For contador As Integer = 0 To lsv.Items.Count - 1 Step 1
                    lsv.Items(contador).Checked = False
                Next
                blnChecarItens = True
            End If
        End Sub

        Public Sub mtdOrdenarColunasLsv(ByRef lsv As System.Windows.Forms.ListView, ByVal SQL As String, ByVal coluna As Integer)
            Dim strColuna As String = lsv.Columns(coluna).Text()

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(frmPrincipal.strConexaoBancoDadosPrincipal, True)

            Dim strCadeiaCarecteres As String = "'%{0}%'"
            Dim Tipo As clsListViewItemComparer.enmTipo = clsListViewItemComparer.enmTipo.Texto
            objImplementacaoBancoDados.mtdAbrirConexao()
            objImplementacaoBancoDados.mtdExecutarComando(SQL)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()

            Try
                If strColuna = "Contador" Then
                    clsListViewItemComparer.mtdOrdenarListViewColuna(lsv, coluna, clsListViewItemComparer.enmTipo.Inteiro)
                Else
                    If objImplementacaoBancoDados.mtdProximoRegistro() Then
                        Select Case (objImplementacaoBancoDados.mtdObterTipoRegistro(objImplementacaoBancoDados.mtdObterNumeroColuna(strColuna)).ToString())
                            Case "System.Byte[]"
                                strCadeiaCarecteres = "{0}"
                                Tipo = clsListViewItemComparer.enmTipo.Texto
                            Case "System.DateTime"
                                strCadeiaCarecteres = "{0}"
                                Tipo = clsListViewItemComparer.enmTipo.Data
                            Case "System.Int32", "System.Int64"
                                strCadeiaCarecteres = "'%{0}%'"
                                Tipo = clsListViewItemComparer.enmTipo.Inteiro
                            Case "System.String"
                                strCadeiaCarecteres = "'%{0}%'"
                                Tipo = clsListViewItemComparer.enmTipo.Texto
                        End Select
                    End If

                    clsListViewItemComparer.mtdOrdenarListViewColuna(lsv, coluna, Tipo)
                End If
            Catch ex As Exception
                clsListViewItemComparer.mtdOrdenarListViewColuna(lsv, coluna, clsListViewItemComparer.enmTipo.Texto)
            End Try

            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Function mtdObterIndiceColunaClicada(ByRef lsv As System.Windows.Forms.ListView) As Integer
            Dim columnindex As Integer = 0

            Try
                Dim MousePosition As Point = lsv.PointToClient(Control.MousePosition)
                Dim hit As ListViewHitTestInfo = lsv.HitTest(MousePosition)
                columnindex = hit.Item.SubItems.IndexOf(hit.SubItem)

            Catch ex As Exception
                columnindex = 0
            End Try

            Return columnindex
        End Function

        Public Shared objColetorDados As prjColetorDadosCSNet20.frmPrincipal = Nothing

        Private Sub smnColetorDados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnColetorDados.Click
            Try
                objColetorDados = New prjColetorDadosCSNet20.frmPrincipal(prjColetorDadosCSNet20.frmPrincipal.prpEnderecoBancoDadosColetor)
                objColetorDados.MdiParent = Me
                objColetorDados.Show()
            Catch ex As Exception
                Dim erro As String = ex.Message
            End Try
        End Sub

        Private blnOcultarMensagemTemporariamente As Boolean = False
        Private dblOcultarMensagemTemporariamente As Double = DateTime.Now.TimeOfDay.TotalMilliseconds

        Private Sub ntf1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ntf1.MouseClick
            If e.Button = Windows.Forms.MouseButtons.Right Then
                dblOcultarMensagemTemporariamente = DateTime.Now.TimeOfDay.TotalMilliseconds
                blnOcultarMensagemTemporariamente = True
                csmsMensagens.Text = "&Exibir Mensagens"
                smnMensagens.Text = "&Exibir Mensagens"
                blnOcultarMensagens = True
            End If
        End Sub

        Private blnExcelRelatorioTodosItens As Boolean = False
        Private blnExcelSap_R3TodosItens As Boolean = False

        Private Sub sssExcelRelatorioItensSelecionados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sssExcelRelatorioItensSelecionados.Click
            blnExcelRelatorioTodosItens = False
            mtdExcelRelatorio(blnExcelRelatorioTodosItens)
        End Sub

        Private Sub sssExcelSap_R3ItensSelecionados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sssExcelSap_R3ItensSelecionados.Click
            blnExcelSap_R3TodosItens = False
            mtdExcelSap_R3(blnExcelSap_R3TodosItens)
        End Sub

        Private Sub sssExcelRelatorioTodosItens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sssExcelRelatorioTodosItens.Click
            blnExcelRelatorioTodosItens = True
            mtdExcelRelatorio(blnExcelRelatorioTodosItens)
        End Sub

        Private Sub sssExcelSap_R3TodosItens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sssExcelSap_R3TodosItens.Click
            blnExcelSap_R3TodosItens = True
            mtdExcelSap_R3(blnExcelSap_R3TodosItens)
        End Sub
    End Class
End Namespace