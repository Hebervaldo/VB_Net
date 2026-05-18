Imports Microsoft.Win32

Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmConfiguracoes
        'Private objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
        Public Shared PrazoValidadeCarteira As Integer = 366
        Public Shared PrazoEntregaCautela As Integer = 5
        Public Shared PrazoEmprestimoMBP As Integer = 0
        Public Shared Nome_RG As String = String.Empty
        Public Shared Matricula_RG As Long = 0
        Public Shared Orgao_RG As String = String.Empty
        Public Shared Numero_TRG As Long = 0
        Public Shared AtualizarData As Boolean = False

        Public Shared clrMonitoramento As Color = Color.LightSkyBlue
        Public Shared strMonitoramento As String = "&Iniciar Monitoramento"
        Public Shared blnMonitorarArquivo As Boolean = True
        Public Shared blnMonitorarDiretorio As Boolean = False
        Public Shared blnSubDiretorios As Boolean = False

        Private objArquivoTXT As clsArquivoTXT = New clsArquivoTXT()
        Private objRegistroWindows As clsRegistroWindows = New clsRegistroWindows()
        Private objCriptografia As clsCriptografia = New clsCriptografia()
        Private senhaCriptografada As String = String.Empty

        Private WithEvents tmrVerificarParametrosBtnMonitoramento As System.Timers.Timer = New System.Timers.Timer()

        Private Sub frmConfiguracoes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                blblResultadoSenhaCriptografada.Text = objRegistroWindows.mtdObterDadosRegistro( _
                    Registry.CurrentUser, _
                    "Software", _
                    "Eletronorte", _
                    "Eletronorte - Soluções Integradas", _
                    "SenhaPrincipal").ToString()
                txtChavePrincipal.Text = objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaPrincipal").ToString()
                txtSenhaPrincipal.Text = objCriptografia.mtdDesCriptografar( _
                    blblResultadoSenhaCriptografada.Text, _
                    txtChavePrincipal.Text, _
                    Encryption.Symmetric.Provider.Rijndael)
                txtChaveCADU.Text = objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaCADU").ToString()
                txtSenhaCADU.Text = objCriptografia.mtdDesCriptografar(objRegistroWindows.mtdObterDadosRegistro( _
                                                                            Registry.CurrentUser, _
                                                                            "Software", _
                                                                            "Eletronorte", _
                                                                            "Eletronorte - Soluções Integradas", _
                                                                            "SenhaCADU").ToString(), _
                                                                        txtChaveCADU.Text, _
                                                                        Encryption.Symmetric.Provider.Rijndael)
                txtChaveColetor.Text = objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaColetor").ToString()
                txtSenhaColetor.Text = objCriptografia.mtdDesCriptografar(objRegistroWindows.mtdObterDadosRegistro( _
                                                                            Registry.CurrentUser, _
                                                                            "Software", _
                                                                            "Eletronorte", _
                                                                            "Eletronorte - Soluções Integradas", _
                                                                            "SenhaColetor").ToString(), _
                                                                        txtChaveColetor.Text, _
                                                                        Encryption.Symmetric.Provider.Rijndael)
            Catch ex As Exception
                MessageBox.Show( _
                    "Digite outra senha ou outra chave, pois uma dessas são inválidas, dessa forma, continuarão salvas a senha e a chave mais antigas válidas.", "Aviso!", MessageBoxButtons.OK)
            Finally
                txtNomeServidorPrincipal.Text = objRegistroWindows.mtdObterDadosRegistro("NomeServidorPrincipal").ToString()
                txtIdentificadorUsuarioPrincipal.Text = objRegistroWindows.mtdObterDadosRegistro("IdentificadorUsuarioPrincipal").ToString()
                txtNomeBaseDadosPrincipal.Text = objRegistroWindows.mtdObterDadosRegistro("NomeBaseDadosPrincipal").ToString()
                txtLocalizacaoPrincipal.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoBancoDadosPrincipal").ToString()
                txtConexaoPrincipal.Text = objRegistroWindows.mtdObterDadosRegistro("ConexaoPrincipal").ToString()

                txtNomeServidorCADU.Text = objRegistroWindows.mtdObterDadosRegistro("NomeServidorCADU").ToString()
                txtIdentificadorUsuarioCADU.Text = objRegistroWindows.mtdObterDadosRegistro("IdentificadorUsuarioCADU").ToString()
                txtNomeBaseDadosCADU.Text = objRegistroWindows.mtdObterDadosRegistro("NomeBaseDadosCADU").ToString()
                txtTabelaCADU.Text = objRegistroWindows.mtdObterDadosRegistro("TabelaCADU").ToString()
                txtConexaoCADU.Text = objRegistroWindows.mtdObterDadosRegistro("ConexaoCADU").ToString()

                Try
                    chbSegurancaIntengradaCADU.Checked = Convert.ToBoolean(objRegistroWindows.mtdObterDadosRegistro( _
                                                                                "SegurancaIntegradaCADU").ToString())
                Catch ex As Exception
                    chbSegurancaIntengradaCADU.Checked = False
                    objRegistroWindows.mtdSalvarDadosRegistro("SegurancaIntegradaCADU", _
                                                              chbSegurancaIntengradaCADU.Checked.ToString(), _
                                                              RegistryValueKind.String)
                End Try
                Try
                    chbInformacaoSegurancaPersistenteCADU.Checked = Convert.ToBoolean(objRegistroWindows.mtdObterDadosRegistro( _
                                                                                           "InformacaoSegurancaPersistenteCADU").ToString())
                Catch ex As Exception
                    chbInformacaoSegurancaPersistenteCADU.Checked = False
                    objRegistroWindows.mtdSalvarDadosRegistro("InformacaoSegurancaPersistenteCADU", _
                                                              chbInformacaoSegurancaPersistenteCADU.Checked, _
                                                              RegistryValueKind.String)
                End Try
                Try
                    AtualizarData = Convert.ToBoolean(objRegistroWindows.mtdObterDadosRegistro( _
                                                                                  "AtualizarData").ToString())
                    frmPrincipal.blnAtualizarData = AtualizarData
                Catch ex As Exception
                    chbAtualizarData.Checked = AtualizarData
                    frmPrincipal.blnAtualizarData = AtualizarData

                    objRegistroWindows.mtdSalvarDadosRegistro("AtualizarData", _
                                                              chbAtualizarData.Checked, _
                                                              RegistryValueKind.String)
                End Try
                chbAtualizarData.Checked = AtualizarData

                txtNomeServidorColetor.Text = objRegistroWindows.mtdObterDadosRegistro("NomeServidorColetor").ToString()
                txtIdentificadorUsuarioColetor.Text = objRegistroWindows.mtdObterDadosRegistro("IdentificadorUsuarioColetor").ToString()
                txtNomeBaseDadosColetor.Text = objRegistroWindows.mtdObterDadosRegistro("NomeBaseDadosColetor").ToString()
                txtLocalizacaoColetor.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoBancoDadosColetor").ToString()
                txtConexaoColetor.Text = objRegistroWindows.mtdObterDadosRegistro("ConexaoColetor").ToString()

                Try
                    PrazoEntregaCautela = Convert.ToInt32(objRegistroWindows.mtdObterDadosRegistro("PrazoEntregaCautela").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("PrazoEntregaCautela", PrazoEntregaCautela)
                End Try
                txtPrazoEntregaCautelas.Text = PrazoEntregaCautela.ToString()
                Try
                    PrazoEmprestimoMBP = Convert.ToInt32(objRegistroWindows.mtdObterDadosRegistro("PrazoEmprestimoMBP").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("PrazoEmprestimoMBP", PrazoEmprestimoMBP)
                End Try
                txtPrazoEmprestimo.Text = PrazoEmprestimoMBP.ToString()
                Try
                    PrazoValidadeCarteira = Convert.ToInt32(objRegistroWindows.mtdObterDadosRegistro("PrazoValidadeCarteira").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("PrazoValidadeCarteira", PrazoValidadeCarteira)
                End Try
                txtPrazoValidadeCarteiras.Text = PrazoValidadeCarteira.ToString()

                Nome_RG = objRegistroWindows.mtdObterDadosRegistro("Nome_RG").ToString()
                txtNomeResponsavelGeralBens.Text = Nome_RG.ToString()
                Try
                    Matricula_RG = Convert.ToInt32(objRegistroWindows.mtdObterDadosRegistro("Matricula_RG").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("Matricula_RG", Matricula_RG)
                End Try
                txtMatriculaResponsavelGeralBens.Text = Matricula_RG.ToString()
                Try
                    Orgao_RG = objRegistroWindows.mtdObterDadosRegistro("Orgao_RG").ToString()
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("Orgao_RG", Orgao_RG)
                End Try
                txtOrgaoResponsavelGeralBens.Text = Orgao_RG.ToString()
                Try
                    Numero_TRG = Convert.ToInt32(objRegistroWindows.mtdObterDadosRegistro("Numero_TRG").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("Numero_TRG", Numero_TRG)
                End Try
                txtNumeroTermoResponsavelGeralBens.Text = Numero_TRG.ToString()

                Try
                    txtLocalizacaoRelatorioCautelas.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioCautela").ToString()
                Catch ex As Exception
                    frmPrincipal.strEnderecoRelatorioCautela = String.Format("{0}{1}", frmPrincipal.DiretorioRelatorioCompleto, frmPrincipal.strNomeArquivoRelatorioCautela)

                    objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioCautela", frmPrincipal.strEnderecoRelatorioCautela)
                End Try
                Try
                    txtLocalizacaoRelatorioMBPs.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioMBP").ToString()
                Catch ex As Exception
                    frmPrincipal.strEnderecoRelatorioMBP = String.Format("{0}{1}", frmPrincipal.DiretorioRelatorioCompleto, frmPrincipal.strNomeArquivoRelatorioMBP)

                    objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioMBP", frmPrincipal.strEnderecoRelatorioMBP)
                End Try
                Try
                    txtLocalizacaoRelatorioCarteiras.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioCarteira").ToString()
                Catch ex As Exception
                    frmPrincipal.strEnderecoRelatorioCarteira = String.Format("{0}{1}", frmPrincipal.DiretorioRelatorioCompleto, frmPrincipal.strNomeArquivoRelatorioCarteira)

                    objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioCarteira", frmPrincipal.strEnderecoRelatorioCarteira)
                End Try
                Try
                    txtLocalizacaoRelatorioInventarioBens.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioInventarioBens").ToString()
                Catch ex As Exception
                    frmPrincipal.strEnderecoRelatorioInventarioBens = String.Format("{0}{1}", frmPrincipal.DiretorioRelatorioCompleto, frmPrincipal.strNomeArquivoRelatorioInventarioBens)

                    objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioInventarioBens", frmPrincipal.strEnderecoRelatorioInventarioBens)
                End Try
                Try
                    txtLocalizacaoRelatorioBens.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoRelatorioBens").ToString()
                Catch ex As Exception
                    frmPrincipal.strEnderecoRelatorioBens = String.Format("{0}{1}", frmPrincipal.DiretorioRelatorioCompleto, frmPrincipal.strNomeArquivoRelatorioBens)

                    objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioBens", frmPrincipal.strEnderecoRelatorioBens)
                End Try

                Try
                    txtLocalizacaoTextoEmailCautelas.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailCautela").ToString()
                Catch ex As Exception
                    frmPrincipal.strEnderecoTextoEmailCautela = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, frmPrincipal.strNomeArquivoTextoEmailCautela)

                    objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailCautela", frmPrincipal.strEnderecoTextoEmailCautela)
                End Try
                Try
                    txtLocalizacaoTextoEmailMBPs.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailMBP").ToString()
                Catch ex As Exception
                    frmPrincipal.strEnderecoTextoEmailMBP = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, frmPrincipal.strNomeArquivoTextoEmailMBP)

                    objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailMBP", frmPrincipal.strEnderecoTextoEmailMBP)
                End Try

                Try
                    txtLocalizacaoTextoEmailCarteiras.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailCarteira").ToString()
                Catch ex As Exception
                    frmPrincipal.strEnderecoTextoEmailCarteira = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, frmPrincipal.strNomeArquivoTextoEmailCarteira)

                    objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailCarteira", frmPrincipal.strEnderecoTextoEmailCarteira)
                End Try
                Try
                    txtLocalizacaoTextoEmailInventarioBens.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailInventarioBens").ToString()
                Catch ex As Exception
                    frmPrincipal.strEnderecoTextoEmailInventarioBens = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, frmPrincipal.strNomeArquivoTextoEmailInventarioBens)

                    objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailInventarioBens", frmPrincipal.strEnderecoTextoEmailInventarioBens)
                End Try
                Try
                    txtLocalizacaoTextoEmailBens.Text = objRegistroWindows.mtdObterDadosRegistro("EnderecoTextoEmailBens").ToString()
                Catch ex As Exception
                    frmPrincipal.strEnderecoTextoEmailBens = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, frmPrincipal.strNomeArquivoTextoEmailBens)

                    objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailBens", frmPrincipal.strEnderecoTextoEmailBens)
                End Try

                Try
                    frmPrincipal.intNumeroLinhasCarteiras = CInt(objRegistroWindows.mtdObterDadosRegistro("NumeroLinhasCarteiras").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("NumeroLinhasCarteiras", frmPrincipal.intNumeroLinhasCarteiras)
                End Try
                txtNumeroLinhasCarteiras.Text = frmPrincipal.intNumeroLinhasCarteiras.ToString()

                Try
                    frmPrincipal.intNumeroLinhasCautelas = CInt(objRegistroWindows.mtdObterDadosRegistro("NumeroLinhasCautelas").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("NumeroLinhasCautelas", frmPrincipal.intNumeroLinhasCautelas)
                End Try
                txtNumeroLinhasCautelas.Text = frmPrincipal.intNumeroLinhasCautelas.ToString()

                Try
                    frmPrincipal.intNumeroLinhasMBPs = CInt(objRegistroWindows.mtdObterDadosRegistro("NumeroLinhasMBPs").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("NumeroLinhasMBPs", frmPrincipal.intNumeroLinhasMBPs)
                End Try
                txtNumeroLinhasMBPs.Text = frmPrincipal.intNumeroLinhasMBPs.ToString()

                Try
                    frmPrincipal.intNumeroLinhasInventarioBens = CInt(objRegistroWindows.mtdObterDadosRegistro("NumeroLinhasInventarioBens").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("NumeroLinhasInventarioBens", frmPrincipal.intNumeroLinhasInventarioBens)
                End Try
                txtNumeroLinhasInventarioBens.Text = frmPrincipal.intNumeroLinhasInventarioBens.ToString()

                Try
                    frmPrincipal.intNumeroLinhasBens = CInt(objRegistroWindows.mtdObterDadosRegistro("NumeroLinhasBens").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("NumeroLinhasBens", frmPrincipal.intNumeroLinhasBens)
                End Try
                txtNumeroLinhasBens.Text = frmPrincipal.intNumeroLinhasBens.ToString()

                txtDiretorioInstalacaoAplicativo.Text = frmPrincipal.strEnderecoAplicativo

                frmPrincipal.DiretorioArmazenamentoBackupCompleto = objRegistroWindows.mtdObterDadosRegistro("DiretorioBackupBancoDados").ToString()
                If (frmPrincipal.DiretorioArmazenamentoBackupCompleto = String.Empty) Then
                    frmPrincipal.DiretorioArmazenamentoBackupCompleto = frmPrincipal.DiretorioArmazenamentoCompleto
                    objRegistroWindows.mtdSalvarDadosRegistro("DiretorioBackupBancoDados", frmPrincipal.DiretorioArmazenamentoBackupCompleto)
                End If
                txtDiretorioBackupBancoDados.Text = frmPrincipal.DiretorioArmazenamentoBackupCompleto

                frmPrincipal.strIntervaloBackup = objRegistroWindows.mtdObterDadosRegistro("IntervaloBackup").ToString()
                If (frmPrincipal.strIntervaloBackup = String.Empty) Then
                    frmPrincipal.strIntervaloBackup = frmPrincipal.cntIntervaloBackup
                    objRegistroWindows.mtdSalvarDadosRegistro("IntervaloBackup", frmPrincipal.strIntervaloBackup)
                End If
                txtIntervaloBackup.Text = frmPrincipal.strIntervaloBackup
                frmPrincipal.tmrSalvarBancoDados.Interval = CInt(frmPrincipal.strIntervaloBackup) * 60 * 1000

                frmPrincipal.strNumeroCopiasBackup = objRegistroWindows.mtdObterDadosRegistro("NumeroCopiasBackup").ToString()
                If (frmPrincipal.strNumeroCopiasBackup = String.Empty) Then
                    frmPrincipal.strNumeroCopiasBackup = frmPrincipal.cntNumeroCopiasBackup
                    objRegistroWindows.mtdSalvarDadosRegistro("NumeroCopiasBackup", frmPrincipal.strNumeroCopiasBackup)
                End If
                txtNumeroCopiasBackup.Text = frmPrincipal.strNumeroCopiasBackup

                Try
                    frmPrincipal.intMultiplicadorCodigoCarteiras = CInt(objRegistroWindows.mtdObterDadosRegistro("MultiplicadorCodigoCarteiras").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoCarteiras", frmPrincipal.intMultiplicadorCodigoCarteiras)
                End Try
                txtMultiplicadorCodigoCarteiras.Text = frmPrincipal.intMultiplicadorCodigoCarteiras.ToString()

                Try
                    frmPrincipal.intMultiplicadorCodigoCautelas = CInt(objRegistroWindows.mtdObterDadosRegistro("MultiplicadorCodigoCautelas").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoCautelas", frmPrincipal.intMultiplicadorCodigoCautelas)
                End Try
                txtMultiplicadorCodigoCautelas.Text = frmPrincipal.intMultiplicadorCodigoCautelas.ToString()

                Try
                    frmPrincipal.intMultiplicadorCodigoMBPs = CInt(objRegistroWindows.mtdObterDadosRegistro("MultiplicadorCodigoMBPs").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoMBPs", frmPrincipal.intMultiplicadorCodigoMBPs)
                End Try
                txtMultiplicadorCodigoMBPs.Text = frmPrincipal.intMultiplicadorCodigoMBPs.ToString()

                Try
                    frmPrincipal.intMultiplicadorCodigoInventarioBens = CInt(objRegistroWindows.mtdObterDadosRegistro("MultiplicadorCodigoInventarioBens").ToString())
                Catch
                    objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoInventarioBens", frmPrincipal.intMultiplicadorCodigoInventarioBens)
                End Try
                txtMultiplicadorCodigoInventarioBens.Text = frmPrincipal.intMultiplicadorCodigoInventarioBens.ToString()

                'Try
                '    frmPrincipal.intMultiplicadorCodigoBens = CInt(objRegistroWindows.mtdObterDadosRegistro("MultiplicadorCodigoBens").ToString())
                'Catch
                '    objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoBens", frmPrincipal.intMultiplicadorCodigoBens)
                'End Try
                'txtMultiplicadorCodigoBens.Text = frmPrincipal.intMultiplicadorCodigoBens.ToString()

                Try
                    rtbCarteiras.Text = objArquivoTXT.mtdLeitorBinario(frmPrincipal.strEnderecoTextoEmailCarteira)
                Catch ex As Exception
                    frmPrincipal.strEnderecoTextoEmailCarteira = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, frmPrincipal.strNomeArquivoTextoEmailCarteira)

                    objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailCarteira, rtbCarteiras.Text)
                End Try
                Try
                    rtbCautelas.Text = objArquivoTXT.mtdLeitorBinario(frmPrincipal.strEnderecoTextoEmailCautela)
                Catch ex As Exception
                    frmPrincipal.strEnderecoTextoEmailCautela = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, frmPrincipal.strNomeArquivoTextoEmailCautela)

                    objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailCautela, rtbCautelas.Text)
                End Try
                Try
                    rtbMBPs.Text = objArquivoTXT.mtdLeitorBinario(frmPrincipal.strEnderecoTextoEmailMBP)
                Catch ex As Exception
                    frmPrincipal.strEnderecoTextoEmailMBP = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, frmPrincipal.strNomeArquivoTextoEmailMBP)

                    objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailMBP, rtbMBPs.Text)
                End Try
                Try
                    rtbInventarioBens.Text = objArquivoTXT.mtdLeitorBinario(frmPrincipal.strEnderecoTextoEmailInventarioBens)
                Catch ex As Exception
                    frmPrincipal.strEnderecoTextoEmailInventarioBens = String.Format("{0}{1}", frmPrincipal.DiretorioTextoEmailCompleto, frmPrincipal.strNomeArquivoTextoEmailInventarioBens)

                    objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailInventarioBens, rtbInventarioBens.Text)
                End Try

                txtServidorSMTP.Text = objRegistroWindows.mtdObterDadosRegistro("ServidorSMTP").ToString()
                txtMostrar.Text = objRegistroWindows.mtdObterDadosRegistro("Mostrar").ToString()
                txtDe.Text = objRegistroWindows.mtdObterDadosRegistro("De").ToString()

                If objRegistroWindows.mtdObterDadosRegistro("FormatoCarteira").ToString().Equals("ExportFormatType.WordForWindows") Then
                    rbtPDFCarteira.Checked = False
                    rbtDOCCarteira.Checked = True
                Else
                    rbtPDFCarteira.Checked = True
                    rbtDOCCarteira.Checked = False
                End If

                If objRegistroWindows.mtdObterDadosRegistro("FormatoCautela").ToString().Equals("ExportFormatType.WordForWindows") Then
                    rbtPDFCautela.Checked = False
                    rbtDOCCautela.Checked = True
                Else
                    rbtPDFCautela.Checked = True
                    rbtDOCCautela.Checked = False
                End If

                If objRegistroWindows.mtdObterDadosRegistro("FormatoMBP").ToString().Equals("ExportFormatType.WordForWindows") Then
                    rbtPDFMBP.Checked = False
                    rbtDOCMBP.Checked = True
                Else
                    rbtPDFMBP.Checked = True
                    rbtDOCMBP.Checked = False
                End If

                If objRegistroWindows.mtdObterDadosRegistro("FormatoInventarioBens").ToString().Equals("ExportFormatType.WordForWindows") Then
                    rbtPDFInventarioBens.Checked = False
                    rbtDOCInventarioBens.Checked = True
                Else
                    rbtPDFInventarioBens.Checked = True
                    rbtDOCInventarioBens.Checked = False
                End If

                If objRegistroWindows.mtdObterDadosRegistro("FormatoBens").ToString().Equals("ExportFormatType.WordForWindows") Then
                    rbtPDFBens.Checked = False
                    rbtDOCBens.Checked = True
                Else
                    rbtPDFBens.Checked = True
                    rbtDOCBens.Checked = False
                End If

                mtdPreencherLsv("Matricula", Matricula_RG.ToString())
                tmrVerificarParametrosBtnMonitoramento.Interval = 1000
                tmrVerificarParametrosBtnMonitoramento.Start()
            End Try
        End Sub

        Private Sub txtNomeServidorPrincipal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNomeServidorPrincipal.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NomeServidorPrincipal", _
                                                      txtNomeServidorPrincipal.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strNomeServidorPrincipal = txtNomeServidorPrincipal.Text
            txtConexaoPrincipal.Text = mtdStringConexaoPrincipal()
        End Sub

        Private Sub txtIdentificadorUsuarioPrincipal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdentificadorUsuarioPrincipal.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("IdentificadorUsuarioPrincipal", _
                                                      txtIdentificadorUsuarioPrincipal.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strIdentificadorUsuarioPrincipal = txtIdentificadorUsuarioPrincipal.Text
            txtConexaoPrincipal.Text = mtdStringConexaoPrincipal()
        End Sub

        Private Sub txtNomeBaseDadosPrincipal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNomeBaseDadosPrincipal.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NomeBaseDadosPrincipal", _
                                                      txtNomeBaseDadosPrincipal.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strNomeBaseDadosPrincipal = txtNomeBaseDadosPrincipal.Text
            txtConexaoPrincipal.Text = mtdStringConexaoPrincipal()
        End Sub

        Private Sub txtSenhaPrincipal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSenhaPrincipal.TextChanged
            If (txtChavePrincipal.Text.Length > 0 And txtChavePrincipal.Text.Length < 17) And txtSenhaPrincipal.Text.Length > 0 Then
                blblResultadoSenhaCriptografada.Text = objCriptografia.mtdCriptografar(txtSenhaPrincipal.Text, txtChavePrincipal.Text, Encryption.Symmetric.Provider.Rijndael)
                Try
                    senhaCriptografada = objCriptografia.mtdCriptografar( _
                        txtSenhaPrincipal.Text, _
                        objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaPrincipal").ToString(), _
                        Encryption.Symmetric.Provider.Rijndael)
                    objRegistroWindows.mtdSalvarDadosRegistro("SenhaPrincipal", _
                                                              senhaCriptografada, _
                                                              RegistryValueKind.String)
                    objRegistroWindows.mtdSalvarDadosRegistro("ChaveCriptografiaPrincipal", _
                                                              txtChavePrincipal.Text, _
                                                              RegistryValueKind.String)
                    frmPrincipal.strSenhaPrincipal = txtSenhaPrincipal.Text
                Catch ex As Exception
                    MessageBox.Show("Digite outra senha ou outra chave, pois uma dessas são inválidas, dessa forma, continuarão salvas a senha e a chave mais antigas válidas.", "Aviso!", MessageBoxButtons.OK)
                End Try
            End If
            txtConexaoPrincipal.Text = mtdStringConexaoPrincipal()
        End Sub

        Private Sub txtChavePrincipal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChavePrincipal.TextChanged
            If (txtChavePrincipal.Text.Length > 0 And txtChavePrincipal.Text.Length < 17) And txtSenhaPrincipal.Text.Length > 0 Then
                blblResultadoSenhaCriptografada.Text = objCriptografia.mtdCriptografar(txtSenhaPrincipal.Text, txtChavePrincipal.Text, Encryption.Symmetric.Provider.Rijndael)
                Try
                    objRegistroWindows.mtdSalvarDadosRegistro("ChaveCriptografiaPrincipal", txtChavePrincipal.Text, RegistryValueKind.String)
                    senhaCriptografada = objCriptografia.mtdCriptografar( _
                    txtSenhaPrincipal.Text, _
                    objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaPrincipal").ToString(), _
                    Encryption.Symmetric.Provider.Rijndael)
                    objRegistroWindows.mtdSalvarDadosRegistro("SenhaPrincipal", _
                                                              senhaCriptografada, _
                                                              RegistryValueKind.String)
                    frmPrincipal.strSenhaPrincipal = txtSenhaPrincipal.Text
                Catch ex As Exception
                    MessageBox.Show("Digite outra senha ou outra chave, pois uma dessas são inválidas, dessa forma, continuarão salvas a senha e a chave mais antigas válidas.", "Aviso!", MessageBoxButtons.OK)
                End Try
            End If
            txtConexaoPrincipal.Text = mtdStringConexaoPrincipal()
        End Sub

        Private Sub txtLocalizacaoPrincipal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoPrincipal.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoBancoDadosPrincipal", _
                                                      txtLocalizacaoPrincipal.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoBancoDadosPrincipal = txtLocalizacaoPrincipal.Text
            txtConexaoPrincipal.Text = mtdStringConexaoPrincipal()
        End Sub

        'Private Sub txtConexaoPrincipal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtConexaoPrincipal.TextChanged
        '    objRegistroWindows.mtdSalvarDadosRegistro("ConexaoPrincipal", String.Empty, RegistryValueKind.String)
        '    frmPrincipal.strConexaoBancoDadosPrincipal = txtConexaoPrincipal.Text
        'End Sub

        Private Sub txtLocalizacaoRelatorioCautelas_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoRelatorioCautelas.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioCautela", _
                                                      txtLocalizacaoRelatorioCautelas.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoRelatorioCautela = txtLocalizacaoRelatorioCautelas.Text
        End Sub

        Private Sub txtLocalizacaoRelatorioMBPs_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoRelatorioMBPs.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioMBP", _
                                                      txtLocalizacaoRelatorioMBPs.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoRelatorioMBP = txtLocalizacaoRelatorioMBPs.Text
        End Sub

        Private Sub txtLocalizacaoRelatorioCarteiras_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoRelatorioCarteiras.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioCarteira", _
                                                      txtLocalizacaoRelatorioCarteiras.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoRelatorioCarteira = txtLocalizacaoRelatorioCarteiras.Text
        End Sub

        Private Sub txtLocalizacaoRelatorioInventarioBens_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoRelatorioInventarioBens.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioInventarioBens", _
                                                      txtLocalizacaoRelatorioInventarioBens.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoRelatorioInventarioBens = txtLocalizacaoRelatorioInventarioBens.Text
        End Sub

        Private Sub txtLocalizacaoRelatorioBens_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoRelatorioBens.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoRelatorioBens", _
                                                      txtLocalizacaoRelatorioBens.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoRelatorioBens = txtLocalizacaoRelatorioBens.Text
        End Sub

        Private Sub txtLocalizacaoTextoEmailCarteiras_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoTextoEmailCarteiras.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailCarteira", _
                                                      txtLocalizacaoTextoEmailCarteiras.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoTextoEmailCarteira = txtLocalizacaoTextoEmailCarteiras.Text
        End Sub

        Private Sub txtLocalizacaoTextoEmailCautelas_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoTextoEmailCautelas.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailCautela", _
                                                      txtLocalizacaoTextoEmailCautelas.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoTextoEmailCautela = txtLocalizacaoTextoEmailCautelas.Text
        End Sub

        Private Sub txtLocalizacaoTextoEmailMBPs_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoTextoEmailMBPs.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailMBP", _
                                                      txtLocalizacaoTextoEmailMBPs.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoTextoEmailMBP = txtLocalizacaoTextoEmailMBPs.Text
        End Sub

        Private Sub txtLocalizacaoTextoEmailInventarioBens_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoTextoEmailInventarioBens.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailInventarioBens", _
                                                      txtLocalizacaoTextoEmailInventarioBens.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoTextoEmailInventarioBens = txtLocalizacaoTextoEmailInventarioBens.Text
        End Sub

        Private Sub txtLocalizacaoTextoEmailBens_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoTextoEmailBens.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoTextoEmailBens", _
                                                      txtLocalizacaoTextoEmailBens.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoTextoEmailBens = txtLocalizacaoTextoEmailBens.Text
        End Sub

        Private Sub txtDiretorioBackupBancoDados_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiretorioBackupBancoDados.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("DiretorioBackupBancoDados", _
                                                      txtDiretorioBackupBancoDados.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.DiretorioArmazenamentoBackupCompleto = txtDiretorioBackupBancoDados.Text
        End Sub

        Private Sub txtIntervaloBackup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIntervaloBackup.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("IntervaloBackup", _
                                                      txtIntervaloBackup.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strIntervaloBackup = txtIntervaloBackup.Text
            If (frmPrincipal.strIntervaloBackup = String.Empty) Then
                frmPrincipal.strIntervaloBackup = frmPrincipal.cntIntervaloBackup
                objRegistroWindows.mtdSalvarDadosRegistro("IntervaloBackup", frmPrincipal.strIntervaloBackup)
            End If
            Try
                frmPrincipal.tmrSalvarBancoDados.Interval = CInt(frmPrincipal.strIntervaloBackup) * 60 * 1000
            Catch ex As Exception
                frmPrincipal.tmrSalvarBancoDados.Interval = CInt(frmPrincipal.cntIntervaloBackup) * 60 * 1000
            End Try
        End Sub

        Private Sub txtNumeroCopias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroCopiasBackup.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NumeroCopiasBackup", _
                                              txtNumeroCopiasBackup.Text, _
                                              RegistryValueKind.String)
            frmPrincipal.strNumeroCopiasBackup = txtNumeroCopiasBackup.Text
            If (frmPrincipal.strNumeroCopiasBackup = String.Empty) Then
                frmPrincipal.strNumeroCopiasBackup = frmPrincipal.cntNumeroCopiasBackup
                objRegistroWindows.mtdSalvarDadosRegistro("NumeroCopiasBackup", frmPrincipal.strNumeroCopiasBackup)
            End If
        End Sub

        Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
            If Not frmPrincipal.Enabled Then
                frmPrincipal.Close()
            Else
                Me.Close()
            End If
        End Sub

        Private Sub btnTestarConexaoPrincipal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestarConexaoPrincipal.Click
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            If objBDPrincipal.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosPrincipal) Then
                MessageBox.Show("A conexão foi realizada com sucesso.", _
                                "Aviso!", _
                                MessageBoxButtons.OK)
            Else
                MessageBox.Show("Não foi possível realizar a conexão.", _
                                "Aviso!", _
                                MessageBoxButtons.OK)
            End If
            objBDPrincipal.Dispose()
        End Sub

        Private Sub btnLocalizacaoBaseDadosPrincipal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoBaseDadosPrincipal.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioArmazenamentoCompleto
            ofd1.Filter = "Arquivos do Principal (*.mdb)|*.mdb|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim strFileName As String() = ofd1.FileName.Split("\"c)
                Dim LocalizacaoPrincipal As String = String.Empty
                Dim NomeBaseDadosPrincipal As String = String.Empty

                For contador As Integer = strFileName.GetLowerBound(0) To strFileName.GetUpperBound(0) Step 1
                    Select Case (contador)
                        Case strFileName.GetLowerBound(0)
                            LocalizacaoPrincipal = strFileName(contador)
                        Case strFileName.GetUpperBound(0)
                            NomeBaseDadosPrincipal = strFileName(contador)
                        Case Else
                            LocalizacaoPrincipal += String.Format("\{0}", strFileName(contador))
                    End Select
                Next

                txtLocalizacaoPrincipal.Text = String.Format("{0}\", LocalizacaoPrincipal)
                txtNomeBaseDadosPrincipal.Text = NomeBaseDadosPrincipal
            End If
        End Sub

        Private Sub btnLocalizacaoBaseDadosColetor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoBaseDadosColetor.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioArmazenamentoCompleto
            ofd1.Filter = "Arquivos do SQL Server CE (*.sdf)|*.sdf|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = DialogResult.OK Then
                Dim strFileName As String() = ofd1.FileName.Split("\"c)
                Dim LocalizacaoColetor As String = String.Empty
                Dim NomeBaseDadosColetor As String = String.Empty

                For contador As Integer = strFileName.GetLowerBound(0) To strFileName.GetUpperBound(0) Step 1
                    Select Case (contador)
                        Case strFileName.GetLowerBound(0)
                            LocalizacaoColetor = strFileName(contador)
                        Case strFileName.GetUpperBound(0)
                            NomeBaseDadosColetor = strFileName(contador)
                        Case Else
                            LocalizacaoColetor += String.Format("\{0}", strFileName(contador))
                    End Select
                Next

                txtLocalizacaoColetor.Text = String.Format("{0}\", LocalizacaoColetor)
                txtNomeBaseDadosColetor.Text = NomeBaseDadosColetor
            End If
        End Sub

        Private Sub btnLocalizacaoRelatorioCautelas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoRelatorioCautelas.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioRelatorioCompleto
            ofd1.Filter = "Arquivos do Crystal Reports (*.rpt)|*.rpt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = DialogResult.OK Then
                'Dim oformulario As New frmMDI()
                'oformulario.MdiParent = Me
                txtLocalizacaoRelatorioCautelas.Text = ofd1.FileName
                'oformulario.Show()
            End If
        End Sub

        Private Sub btnLocalizacaoRelatorioMBPs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoRelatorioMBPs.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioRelatorioCompleto
            ofd1.Filter = "Arquivos do Crystal Reports (*.rpt)|*.rpt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = DialogResult.OK Then
                'Dim oformulario As New frmMDI()
                'oformulario.MdiParent = Me
                txtLocalizacaoRelatorioMBPs.Text = ofd1.FileName
                'oformulario.Show()
            End If
        End Sub

        Private Sub btnLocalizacaoRelatorioCarteiras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoRelatorioCarteiras.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioRelatorioCompleto
            ofd1.Filter = "Arquivos do Crystal Reports (*.rpt)|*.rpt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = DialogResult.OK Then
                'Dim oformulario As New frmMDI()
                'oformulario.MdiParent = Me
                txtLocalizacaoRelatorioCarteiras.Text = ofd1.FileName
                'oformulario.Show()
            End If
        End Sub

        Private Sub btnLocalizacaoRelatorioInventarioBens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoRelatorioInventarioBens.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioRelatorioCompleto
            ofd1.Filter = "Arquivos do Crystal Reports (*.rpt)|*.rpt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = DialogResult.OK Then
                'Dim oformulario As New frmMDI()
                'oformulario.MdiParent = Me
                txtLocalizacaoRelatorioInventarioBens.Text = ofd1.FileName
                'oformulario.Show()
            End If
        End Sub

        Private Sub btnLocalizacaoRelatorioBens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoRelatorioBens.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioRelatorioCompleto
            ofd1.Filter = "Arquivos do Crystal Reports (*.rpt)|*.rpt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = DialogResult.OK Then
                'Dim oformulario As New frmMDI()
                'oformulario.MdiParent = Me
                txtLocalizacaoRelatorioBens.Text = ofd1.FileName
                'oformulario.Show()
            End If
        End Sub

        Private Sub btnLocalizacaoTextoEmailCarteiras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoTextoEmailCarteiras.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioRelatorioCompleto
            ofd1.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = DialogResult.OK Then
                'Dim oformulario As New frmMDI()
                'oformulario.MdiParent = Me
                txtLocalizacaoTextoEmailCarteiras.Text = ofd1.FileName
                'oformulario.Show()
            End If
        End Sub

        Private Sub btnLocalizacaoTextoEmailCautelas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoTextoEmailCautelas.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioRelatorioCompleto
            ofd1.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = DialogResult.OK Then
                'Dim oformulario As New frmMDI()
                'oformulario.MdiParent = Me
                txtLocalizacaoTextoEmailCautelas.Text = ofd1.FileName
                'oformulario.Show()
            End If
        End Sub

        Private Sub btnLocalizacaoTextoEmailMBPs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoTextoEmailMBPs.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioRelatorioCompleto
            ofd1.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = DialogResult.OK Then
                'Dim oformulario As New frmMDI()
                'oformulario.MdiParent = Me
                txtLocalizacaoTextoEmailMBPs.Text = ofd1.FileName
                'oformulario.Show()
            End If
        End Sub

        Private Sub btnLocalizacaoTextoEmailInventarioBens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoTextoEmailInventarioBens.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioRelatorioCompleto
            ofd1.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = DialogResult.OK Then
                'Dim oformulario As New frmMDI()
                'oformulario.MdiParent = Me
                txtLocalizacaoTextoEmailInventarioBens.Text = ofd1.FileName
                'oformulario.Show()
            End If
        End Sub

        Private Sub btnLocalizacaoTextoEmailBens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizacaoTextoEmailBens.Click
            ofd1.InitialDirectory = frmPrincipal.DiretorioRelatorioCompleto
            ofd1.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos Arquivos (*.*)|*.*"
            ofd1.FilterIndex = 1
            If ofd1.ShowDialog() = DialogResult.OK Then
                'Dim oformulario As New frmMDI()
                'oformulario.MdiParent = Me
                txtLocalizacaoTextoEmailBens.Text = ofd1.FileName
                'oformulario.Show()
            End If
        End Sub

        Private objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()

        Private Sub txtPrazoEntregaCautelas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrazoEntregaCautelas.TextChanged
            If Not txtPrazoEntregaCautelas.Text.Equals(String.Empty) Then
                If Convert.ToInt32(txtPrazoEntregaCautelas.Text) <= 120 Then
                    PrazoEntregaCautela = Convert.ToInt32(txtPrazoEntregaCautelas.Text)
                    objRegistroWindows.mtdSalvarDadosRegistro("PrazoEntregaCautela", _
                                                              PrazoEntregaCautela, _
                                                              RegistryValueKind.DWord)
                Else
                    MessageBox.Show("Digite um valor menor ou igual a 120 dias. Dessa forma será mantido o último valor válido.", "Aviso!", MessageBoxButtons.OK)
                End If
            End If
        End Sub

        Private Sub txtPrazoEmprestimo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrazoEmprestimo.TextChanged
            If Not txtPrazoEmprestimo.Text.Equals(String.Empty) Then
                If Convert.ToInt32(txtPrazoEmprestimo.Text) <= 120 Then
                    PrazoEmprestimoMBP = Convert.ToInt32(txtPrazoEmprestimo.Text)
                    objRegistroWindows.mtdSalvarDadosRegistro("PrazoEmprestimoMBP", _
                                                              PrazoEmprestimoMBP, _
                                                              RegistryValueKind.DWord)
                Else
                    MessageBox.Show("Digite um valor menor ou igual a 120 dias. Dessa forma será mantido o último valor válido.", "Aviso!", MessageBoxButtons.OK)
                End If
            End If
        End Sub

        Private Sub txtPrazoEntregaCautelas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrazoEntregaCautelas.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtPrazoEmprestimo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrazoEmprestimo.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtPrazoValidadeCarteiras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrazoValidadeCarteiras.TextChanged
            If Not txtPrazoValidadeCarteiras.Text.Equals(String.Empty) Then
                If Convert.ToInt32(txtPrazoValidadeCarteiras.Text) <= 732 Then
                    PrazoValidadeCarteira = Convert.ToInt32(txtPrazoValidadeCarteiras.Text)
                    objRegistroWindows.mtdSalvarDadosRegistro("PrazoValidadeCarteira", _
                                                              PrazoValidadeCarteira, _
                                                              RegistryValueKind.DWord)
                Else
                    MessageBox.Show("Digite um valor menor ou igual a 732 dias. Dessa forma será mantido o último valor válido.", "Aviso!", MessageBoxButtons.OK)
                End If
            End If
        End Sub

        Private Sub txtPrazoValidadeCarteiras_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrazoValidadeCarteiras.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtMatriculaResponsavelGeralBens_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMatriculaResponsavelGeralBens.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtNumeroTRG_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroTermoResponsavelGeralBens.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtNomeServidorCADU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomeServidorCADU.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NomeServidorCADU", _
                                                      txtNomeServidorCADU.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strNomeServidorCADU = txtNomeServidorCADU.Text
            txtConexaoCADU.Text = mtdStringConexaoCADU(chbSegurancaIntengradaCADU.Checked)
        End Sub

        Private Sub txtIdentificadorUsuarioCADU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIdentificadorUsuarioCADU.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("IdentificadorUsuarioCADU", _
                                                      txtIdentificadorUsuarioCADU.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strIdentificadorUsuarioCADU = txtIdentificadorUsuarioCADU.Text
            txtConexaoCADU.Text = mtdStringConexaoCADU(chbSegurancaIntengradaCADU.Checked)
        End Sub

        Private Sub txtNomeBaseDadosCADU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomeBaseDadosCADU.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NomeBaseDadosCADU", _
                                                      txtNomeBaseDadosCADU.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strNomeBaseDadosCADU = txtNomeBaseDadosCADU.Text
            txtConexaoCADU.Text = mtdStringConexaoCADU(chbSegurancaIntengradaCADU.Checked)
        End Sub

        Private Sub txtSenhaCADU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSenhaCADU.TextChanged
            If (txtChaveCADU.Text.Length > 0 And txtChaveCADU.Text.Length < 17) And txtSenhaCADU.Text.Length > 0 Then
                blblResultadoSenhaCriptografada.Text = objCriptografia.mtdCriptografar(txtSenhaCADU.Text, _
                                                                                       txtChaveCADU.Text, _
                                                                                       Encryption.Symmetric.Provider.Rijndael)
                Try
                    senhaCriptografada = objCriptografia.mtdCriptografar(txtSenhaCADU.Text, _
                                                                         objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaCADU").ToString(), _
                                                                         Encryption.Symmetric.Provider.Rijndael)
                    objRegistroWindows.mtdSalvarDadosRegistro("SenhaCADU", senhaCriptografada, RegistryValueKind.String)
                    objRegistroWindows.mtdSalvarDadosRegistro("ChaveCriptografiaCADU", txtChaveCADU.Text, RegistryValueKind.String)
                    frmPrincipal.strSenhaCADU = txtSenhaCADU.Text
                Catch ex As Exception
                    MessageBox.Show("Digite outra senha ou outra chave, pois uma dessas são inválidas, dessa forma, continuarão salvas a senha e a chave mais antigas válidas.", _
                                    "Aviso!", _
                                    MessageBoxButtons.OK)
                End Try
            End If
            txtConexaoCADU.Text = mtdStringConexaoCADU(chbSegurancaIntengradaCADU.Checked)
        End Sub

        Private Sub txtChaveCADU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChaveCADU.TextChanged
            If (txtChaveCADU.Text.Length > 0 And txtChaveCADU.Text.Length < 17) And txtSenhaCADU.Text.Length > 0 Then
                blblResultadoSenhaCriptografada.Text = objCriptografia.mtdCriptografar(txtSenhaCADU.Text, txtChaveCADU.Text, Encryption.Symmetric.Provider.Rijndael)
                Try
                    objRegistroWindows.mtdSalvarDadosRegistro("ChaveCriptografiaCADU", txtChaveCADU.Text, RegistryValueKind.String)
                    senhaCriptografada = objCriptografia.mtdCriptografar(txtSenhaCADU.Text, _
                                                         objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaCADU").ToString(), _
                                                         Encryption.Symmetric.Provider.Rijndael)
                    objRegistroWindows.mtdSalvarDadosRegistro("SenhaCADU", senhaCriptografada, RegistryValueKind.String)
                    frmPrincipal.strSenhaCADU = txtSenhaCADU.Text
                Catch ex As Exception
                    MessageBox.Show("Digite outra senha ou outra chave, pois uma dessas são inválidas, dessa forma, continuarão salvas a senha e a chave mais antigas válidas.", _
                                    "Aviso!", _
                                    MessageBoxButtons.OK)
                End Try
            End If
            txtConexaoCADU.Text = mtdStringConexaoCADU(chbSegurancaIntengradaCADU.Checked)
        End Sub

        'Private Sub txtConexaoCADU_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtConexaoCADU.TextChanged
        '    objRegistroWindows.mtdSalvarDadosRegistro("ConexaoCADU", String.Empty, RegistryValueKind.String)
        '    frmPrincipal.strConexaoBancoDadosCADU = txtConexaoCADU.Text
        'End Sub

        Private Sub txtTabelaCADU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTabelaCADU.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("TabelaCADU", txtTabelaCADU.Text, RegistryValueKind.String)
            frmPrincipal.strTabelaCADU = txtTabelaCADU.Text
        End Sub

        Private Sub chbSegurancaIntengradaCADU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSegurancaIntengradaCADU.CheckedChanged
            objRegistroWindows.mtdSalvarDadosRegistro("SegurancaIntegradaCADU", Convert.ToString(chbSegurancaIntengradaCADU.Checked), RegistryValueKind.String)
            frmPrincipal.strSegurancaIntegradaCADU = Convert.ToString(chbSegurancaIntengradaCADU.Checked)
            txtConexaoCADU.Text = mtdStringConexaoCADU(chbSegurancaIntengradaCADU.Checked)
        End Sub

        Private Sub chbInformacaoSegurancaPersistenteCADU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbInformacaoSegurancaPersistenteCADU.CheckedChanged
            objRegistroWindows.mtdSalvarDadosRegistro("InformacaoSegurancaPersistenteCADU", Convert.ToString(chbInformacaoSegurancaPersistenteCADU.Checked), RegistryValueKind.String)
            frmPrincipal.strInformacaoSegurancaPersistenteCADU = Convert.ToString(chbInformacaoSegurancaPersistenteCADU.Checked)
            txtConexaoCADU.Text = mtdStringConexaoCADU(chbSegurancaIntengradaCADU.Checked)
        End Sub

        Private Sub chbAtualizarData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbAtualizarData.CheckedChanged
            objRegistroWindows.mtdSalvarDadosRegistro("AtualizarData", Convert.ToString(chbAtualizarData.Checked), RegistryValueKind.String)
            AtualizarData = chbAtualizarData.Checked
            frmPrincipal.blnAtualizarData = AtualizarData
        End Sub

        Private Sub btnTestarConexaoCADU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestarConexaoCADU.Click
            Dim objBDCADU As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                               clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServer)
            If objBDCADU.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosCADU) Then
                MessageBox.Show("A conexão foi realizada com sucesso.", _
                                "Aviso!", _
                                MessageBoxButtons.OK)
            Else
                MessageBox.Show("Não foi possível realizar a conexão.", _
                                "Aviso!", _
                                MessageBoxButtons.OK)
            End If
            objBDCADU.Dispose()
        End Sub

        Private Sub txtNomeServidorColetor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomeServidorColetor.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NomeServidorColetor", txtNomeServidorColetor.Text, RegistryValueKind.String)
            frmPrincipal.strNomeServidorColetor = txtNomeServidorColetor.Text
            txtConexaoColetor.Text = mtdStringConexaoColetor()
        End Sub

        Private Sub txtIdentificadorUsuarioColetor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIdentificadorUsuarioColetor.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("IdentificadorUsuarioColetor", txtIdentificadorUsuarioColetor.Text, RegistryValueKind.String)
            frmPrincipal.strNomeServidorColetor = txtIdentificadorUsuarioColetor.Text
            txtConexaoColetor.Text = mtdStringConexaoColetor()
        End Sub

        Private Sub txtNomeBaseDadosColetor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomeBaseDadosColetor.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NomeBaseDadosColetor", txtNomeBaseDadosColetor.Text, RegistryValueKind.String)
            frmPrincipal.strNomeBaseDadosColetor = txtNomeBaseDadosColetor.Text
            txtConexaoColetor.Text = mtdStringConexaoColetor()
        End Sub

        Private Sub txtSenhaColetor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSenhaColetor.TextChanged
            If (txtChaveColetor.Text.Length > 0 And txtChaveColetor.Text.Length < 17) And txtSenhaColetor.Text.Length > 0 Then
                blblResultadoSenhaCriptografada.Text = objCriptografia.mtdCriptografar(txtSenhaColetor.Text, _
                                                                                       txtChaveColetor.Text, _
                                                                                       Encryption.Symmetric.Provider.Rijndael)
                Try
                    senhaCriptografada = objCriptografia.mtdCriptografar(txtSenhaColetor.Text, _
                                                                         objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaColetor").ToString(), _
                                                                         Encryption.Symmetric.Provider.Rijndael)
                    objRegistroWindows.mtdSalvarDadosRegistro("SenhaColetor", _
                                                              senhaCriptografada, _
                                                              RegistryValueKind.String)
                    objRegistroWindows.mtdSalvarDadosRegistro("ChaveCriptografiaColetor", _
                                                              txtChaveColetor.Text, _
                                                              RegistryValueKind.String)
                    frmPrincipal.strSenhaColetor = txtSenhaColetor.Text
                Catch ex As Exception
                    MessageBox.Show("Digite outra senha ou outra chave, pois uma dessas são inválidas, dessa forma, continuarão salvas a senha e a chave mais antigas válidas.", _
                                    "Aviso!", _
                                    MessageBoxButtons.OK)
                End Try
            End If
            txtConexaoColetor.Text = mtdStringConexaoColetor()
        End Sub

        Private Sub txtChaveColetor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChaveColetor.TextChanged
            If (txtChaveColetor.Text.Length > 0 And txtChaveColetor.Text.Length < 17) And txtSenhaColetor.Text.Length > 0 Then
                blblResultadoSenhaCriptografada.Text = objCriptografia.mtdCriptografar(txtSenhaColetor.Text, _
                                                                                       txtChaveColetor.Text, _
                                                                                       Encryption.Symmetric.Provider.Rijndael)
                Try
                    objRegistroWindows.mtdSalvarDadosRegistro("ChaveCriptografiaColetor", _
                                                              txtChaveColetor.Text, _
                                                              RegistryValueKind.String)
                    senhaCriptografada = objCriptografia.mtdCriptografar(txtSenhaColetor.Text, _
                                                                         objRegistroWindows.mtdObterDadosRegistro("ChaveCriptografiaColetor").ToString(), _
                                                                         Encryption.Symmetric.Provider.Rijndael)
                    objRegistroWindows.mtdSalvarDadosRegistro("SenhaColetor", _
                                                              senhaCriptografada, _
                                                              RegistryValueKind.String)
                    frmPrincipal.strSenhaColetor = txtSenhaColetor.Text
                Catch ex As Exception
                    MessageBox.Show("Digite outra senha ou outra chave, pois uma dessas são inválidas, dessa forma, continuarão salvas a senha e a chave mais antigas válidas.", _
                                    "Aviso!", _
                                    MessageBoxButtons.OK)
                End Try
            End If
            txtConexaoColetor.Text = mtdStringConexaoColetor()
        End Sub

        'Private Sub txtConexaoColetor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtConexaoColetor.TextChanged
        '    objRegistroWindows.mtdSalvarDadosRegistro("ConexaoColetor", String.Empty, RegistryValueKind.String)
        '    frmPrincipal.strConexaoBancoDadosColetor = txtConexaoColetor.Text
        'End Sub

        Private Sub txtLocalizacaoColetor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocalizacaoColetor.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("EnderecoBancoDadosColetor", _
                                                      txtLocalizacaoColetor.Text, _
                                                      RegistryValueKind.String)
            frmPrincipal.strEnderecoBancoDadosColetor = txtLocalizacaoColetor.Text
            txtConexaoColetor.Text = mtdStringConexaoColetor()
        End Sub

        Private Sub txtNumeroLinhasCarteiras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroLinhasCarteiras.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NumeroLinhasCarteiras", _
                                                 txtNumeroLinhasCarteiras.Text, _
                                                 RegistryValueKind.String)
            frmPrincipal.intNumeroLinhasCarteiras = CInt(txtNumeroLinhasCarteiras.Text)
        End Sub

        Private Sub txtNumeroLinhasCautelas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroLinhasCautelas.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NumeroLinhasCautelas", _
                                                 txtNumeroLinhasCautelas.Text, _
                                                 RegistryValueKind.String)
            frmPrincipal.intNumeroLinhasCautelas = CInt(txtNumeroLinhasCautelas.Text)
        End Sub

        Private Sub txtNumeroLinhasMBPs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroLinhasMBPs.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NumeroLinhasMBPs", _
                                                 txtNumeroLinhasMBPs.Text, _
                                                 RegistryValueKind.String)
            frmPrincipal.intNumeroLinhasMBPs = CInt(txtNumeroLinhasMBPs.Text)
        End Sub

        Private Sub txtNumeroLinhasInventarioBens_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroLinhasInventarioBens.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NumeroLinhasInventarioBens", _
                                         txtNumeroLinhasInventarioBens.Text, _
                                         RegistryValueKind.String)
            frmPrincipal.intNumeroLinhasInventarioBens = CInt(txtNumeroLinhasInventarioBens.Text)
        End Sub

        Private Sub txtNumeroLinhasBens_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroLinhasBens.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("NumeroLinhasBens", _
                                         txtNumeroLinhasBens.Text, _
                                         RegistryValueKind.String)
            frmPrincipal.intNumeroLinhasBens = CInt(txtNumeroLinhasBens.Text)
        End Sub

        Private Sub txtNumeroLinhasCarteiras_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroLinhasCarteiras.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtNumeroLinhasCautelas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroLinhasCautelas.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtNumeroLinhasMBPs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroLinhasMBPs.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtNumeroLinhasInventarioBens_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroLinhasInventarioBens.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtNumeroLinhasBens_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroLinhasBens.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtIntervaloBackup_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIntervaloBackup.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtNumeroCopias_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroCopiasBackup.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub btnTestarConexaoColetor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestarConexaoColetor.Click
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                               clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)
            If objBDColetor.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosColetor) Then
                MessageBox.Show("A conexão foi realizada com sucesso.", "Aviso!", MessageBoxButtons.OK)
            Else
                MessageBox.Show("Não foi possível realizar a conexão.", "Aviso!", MessageBoxButtons.OK)

            End If
            objBDColetor.Dispose()
        End Sub

        Private Function mtdStringConexaoPrincipal() As String
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                           clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            Dim strStringConexao As String = objImplementacaoBancoDados.mtdDefinirStringConexaoAccess( _
                clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, _
                String.Format("{0}{1}", txtLocalizacaoPrincipal.Text, txtNomeBaseDadosPrincipal.Text), _
                String.Empty, _
                blblResultadoSenhaCriptografada.Text)
            frmPrincipal.strConexaoBancoDadosPrincipal = objImplementacaoBancoDados.mtdDefinirStringConexaoAccess( _
                clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, _
                String.Format("{0}{1}", txtLocalizacaoPrincipal.Text, txtNomeBaseDadosPrincipal.Text), _
                String.Empty, _
                txtSenhaPrincipal.Text)
            objRegistroWindows.mtdSalvarDadosRegistro("ConexaoPrincipal", _
                                                      strStringConexao, _
                                                      RegistryValueKind.String)
            objImplementacaoBancoDados.Dispose()
            Return strStringConexao
        End Function

        Private Function mtdStringConexaoCADU(ByVal SegurancaIntegrada As Boolean) As String
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                           clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServer)
            Dim strStringConexao As String = String.Empty
            Dim intTempoSaidaConexao As Integer = 15
            Dim strSenhaConexao As String = String.Empty

            If (SegurancaIntegrada) Then
                strStringConexao = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServer( _
                    clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerNativa, _
                    txtNomeServidorCADU.Text, _
                    txtNomeBaseDadosCADU.Text, _
                    chbInformacaoSegurancaPersistenteCADU.Checked, _
                    intTempoSaidaConexao)
                frmPrincipal.strConexaoBancoDadosCADU = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServer( _
                    clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerNativa, _
                    txtNomeServidorCADU.Text, _
                    txtNomeBaseDadosCADU.Text, _
                    chbInformacaoSegurancaPersistenteCADU.Checked, _
                    intTempoSaidaConexao)
            Else
                strStringConexao = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServer( _
                    clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerNativa, _
                    txtNomeServidorCADU.Text, _
                    txtNomeBaseDadosCADU.Text, _
                    txtIdentificadorUsuarioCADU.Text, _
                    blblResultadoSenhaCriptografada.Text, _
                    chbInformacaoSegurancaPersistenteCADU.Checked, _
                    intTempoSaidaConexao)
                frmPrincipal.strConexaoBancoDadosCADU = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServer( _
                    clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerNativa, _
                    txtNomeServidorCADU.Text, _
                    txtNomeBaseDadosCADU.Text, _
                    txtIdentificadorUsuarioCADU.Text, _
                    txtSenhaCADU.Text, _
                    chbInformacaoSegurancaPersistenteCADU.Checked, _
                    intTempoSaidaConexao)
            End If
            objRegistroWindows.mtdSalvarDadosRegistro("ConexaoCADU", _
                                                      strStringConexao, _
                                                      RegistryValueKind.String)
            objImplementacaoBancoDados.Dispose()
            Return strStringConexao
        End Function

        Public Function mtdStringConexaoColetor() As String
            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                           clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)
            Dim strStringConexao As String = String.Empty
            Dim strSenhaConexao As String = String.Empty

            strStringConexao = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE( _
                    clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerCENativa, _
                    String.Format("{0}{1}", txtLocalizacaoColetor.Text, txtNomeBaseDadosColetor.Text), _
                    blblResultadoSenhaCriptografada.Text)
            frmPrincipal.strConexaoBancoDadosColetor = objImplementacaoBancoDados.mtdDefinirStringConexaoSQLServerCE( _
                clsImplementacaoBancoDados.TipoConexao.ConexaoSQLServerCENativa, _
                String.Format("{0}{1}", txtLocalizacaoColetor.Text, txtNomeBaseDadosColetor.Text), _
                txtSenhaColetor.Text)
            objRegistroWindows.mtdSalvarDadosRegistro("ConexaoColetor", _
                                                      strStringConexao, _
                                                      RegistryValueKind.String)
            objImplementacaoBancoDados.Dispose()
            Return strStringConexao
        End Function

        Private Sub btnCompactarRepararBancoDadosPrincipal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompactarRepararBancoDadosPrincipal2.Click
            Try
                Cursor.Current = Cursors.WaitCursor ' set the wait cursor
                ' Do some work
                frmPrincipal.mtdCompactarRepararBancoDadosPrincipal(True)
            Finally
                Cursor.Current = Cursors.Default 'restore the old cursor
            End Try
        End Sub

        Private Sub btnCompactarRepararBancoDadosColetor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompactarRepararBancoDadosColetor.Click
            Try
                Cursor.Current = Cursors.WaitCursor ' set the wait cursor
                ' Do some work
                frmPrincipal.mtdCompactarRepararBancoDadosColetor(True)
            Finally
                Cursor.Current = Cursors.Default 'restore the old cursor
            End Try
        End Sub

        Private Sub btnCriarBancoDadosPrincipal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCriarBancoDadosPrincipal.Click
            Try
                Cursor.Current = Cursors.WaitCursor ' set the wait cursor
                ' Do some work
                frmPrincipal.mtdCriarBancoDadosPrincipal(True)
            Finally
                Cursor.Current = Cursors.Default 'restore the old cursor
            End Try
        End Sub

        Private Sub btnCriarBancoDadosColetor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCriarBancoDadosColetor.Click
            Try
                Cursor.Current = Cursors.WaitCursor ' set the wait cursor
                ' Do some work
                frmPrincipal.mtdCriarBancoDadosColetor(True)
            Finally
                Cursor.Current = Cursors.Default 'restore the old cursor
            End Try
        End Sub

        Private Sub mtdPreencherLsv(ByVal CampoTabela As String, ByVal ValorTabela As String)
            If Not ValorTabela.Equals(String.Empty) Then
                If Convert.ToInt64(txtMatriculaResponsavelGeralBens.Text) <= 1000000000 Then
                    Try
                        lsvTRG.Clear()
                        lsvTRG.View = System.Windows.Forms.View.Details
                        lsvTRG.LabelEdit = False
                        lsvTRG.AllowColumnReorder = True
                        lsvTRG.CheckBoxes = False
                        lsvTRG.FullRowSelect = True
                        lsvTRG.GridLines = True
                        lsvTRG.Columns.Add("Atributos", 100, HorizontalAlignment.Left)
                        lsvTRG.Columns.Add("Informações", 300, HorizontalAlignment.Left)
                        Dim objBDtemp As clsImplementacaoBancoDados = _
                            New clsImplementacaoBancoDados( _
                            frmPrincipal.strConexaoBancoDadosPrincipal, _
                            String.Format( _
                                "SELECT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE (tblEmpregados.{0} LIKE '%{1}%');", _
                                CampoTabela, _
                                ValorTabela), _
                            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                        objBDtemp.mtdAbrirConexao()
                        objBDtemp.mtdExecutarComando()
                        objBDtemp.mtdDefinirLeitorDados()
                        objBDtemp.mtdProximoRegistro()
                        objBDtemp.mtdAdaptadorDados()
                        Dim NumColunaDR As Integer = objBDtemp.mtdNumeroColunas()
                        Dim item(NumColunaDR - 1) As ListViewItem
                        Dim vetAtributos(NumColunaDR - 1) As String
                        For contador As Integer = item.GetLowerBound(0) To item.GetUpperBound(0) Step 1
                            item(contador) = New ListViewItem(objBDtemp.mtdObterCabecalhoColunas(contador), contador)
                            item(contador).SubItems.Add(objBDtemp.mtdObterValorRegistro(contador).ToString())
                        Next
                        objBDtemp.Dispose()
                        lsvTRG.Items.AddRange(item)
                        For contador As Integer = item.GetLowerBound(0) To item.GetUpperBound(0) Step 1
                            lsvTRG.Items.Add(item(contador))
                        Next
                        Me.Controls.Add(lsvTRG)
                    Catch
                    End Try
                Else
                    MessageBox.Show("Digite uma matrícula válida. Dessa forma será mantido o último valor válido.", _
                                    "Aviso!", _
                                    MessageBoxButtons.OK)
                End If
            End If
        End Sub

        Private CampoTextoUtilizado As String = String.Empty

        Private Sub txtNomeResponsavelGeralBens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomeResponsavelGeralBens.Click
            CampoTextoUtilizado = txtNomeResponsavelGeralBens.Name
        End Sub

        Private Sub txtMatriculaResponsavelGeralBens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMatriculaResponsavelGeralBens.TextChanged
            CampoTextoUtilizado = txtMatriculaResponsavelGeralBens.Name
        End Sub

        Private Sub txtOrgaoResponsavelGeralBens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrgaoResponsavelGeralBens.Click
            CampoTextoUtilizado = txtOrgaoResponsavelGeralBens.Name
        End Sub

        Private Sub txtNumeroTermoResponsavelGeralBens_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroTermoResponsavelGeralBens.TextChanged
            If Not txtNumeroTermoResponsavelGeralBens.Text.Equals(String.Empty) Then
                If Convert.ToInt32(txtNumeroTermoResponsavelGeralBens.Text) <= 10000 Then
                    Numero_TRG = Convert.ToInt32(txtNumeroTermoResponsavelGeralBens.Text)
                    objRegistroWindows.mtdSalvarDadosRegistro("Numero_TRG", _
                                                              Numero_TRG, _
                                                              RegistryValueKind.DWord)
                Else
                    MessageBox.Show( _
                        "Digite um valor menor ou igual a 10000. Dessa forma será mantido o último valor válido.", _
                        "Aviso!", _
                        MessageBoxButtons.OK)
                End If
            End If
        End Sub

        Private Sub btnConsultarResponsavelGeralBens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefinir.Click
            Select Case CampoTextoUtilizado
                Case txtNomeResponsavelGeralBens.Name
                    mtdPreencherLsv("Nome", txtNomeResponsavelGeralBens.Text)
                Case txtMatriculaResponsavelGeralBens.Name
                    mtdPreencherLsv("Matricula", txtMatriculaResponsavelGeralBens.Text)
                Case txtOrgaoResponsavelGeralBens.Name
                    mtdPreencherLsv("Orgao", txtOrgaoResponsavelGeralBens.Text)
            End Select
            If lsvTRG.Items.Count > 2 Then
                txtNomeResponsavelGeralBens.Text = lsvTRG.Items(0).SubItems(1).Text
                txtMatriculaResponsavelGeralBens.Text = lsvTRG.Items(1).SubItems(1).Text
                txtOrgaoResponsavelGeralBens.Text = lsvTRG.Items(2).SubItems(1).Text
            End If

            objRegistroWindows.mtdSalvarDadosRegistro("Nome_RG", txtNomeResponsavelGeralBens.Text)
            objRegistroWindows.mtdSalvarDadosRegistro("Matricula_RG", txtMatriculaResponsavelGeralBens.Text)
            objRegistroWindows.mtdSalvarDadosRegistro("Orgao_RG", txtOrgaoResponsavelGeralBens.Text)
        End Sub

        Private Sub btnDiretorioBackupBancoDados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiretorioBackupBancoDados.Click
            fbd1.Description = "Selecione o Diretório em que se deseja criar os arquivos de Backup."
            fbd1.SelectedPath = frmPrincipal.DiretorioRelatorioCompleto
            If fbd1.ShowDialog() = DialogResult.OK Then
                txtDiretorioBackupBancoDados.Text = fbd1.SelectedPath
            End If
        End Sub

        Private Sub btnIniciarMonitoramento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonitoramento.Click
            'frmPrincipal.mtdMonitorarDiretorioArquivo()
        End Sub

        Private Sub rdbMonitorarArquivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMonitorarArquivo.Click
            If rdbMonitorarArquivo.Checked Then
                chkSubDiretorios.Enabled = False
                chkSubDiretorios.Checked = False
            End If
        End Sub

        Private Sub rdbMonitorarDiretorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMonitorarDiretorio.Click
            If rdbMonitorarDiretorio.Checked Then
                chkSubDiretorios.Enabled = True
            End If
        End Sub

        Private Sub tmrVerificarParametrosBtnMonitoramento_Elapsed() Handles tmrVerificarParametrosBtnMonitoramento.Elapsed
            Try
                btnMonitoramento.Text = strMonitoramento
                btnMonitoramento.BackColor = clrMonitoramento
                rdbMonitorarArquivo.Checked = blnMonitorarArquivo
                rdbMonitorarDiretorio.Checked = blnMonitorarDiretorio
                chkSubDiretorios.Checked = blnSubDiretorios
            Catch
            End Try
        End Sub

        Private Sub btnCriarTodasTabelas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCriarTodasTabelas.Click
            Try
                Cursor.Current = Cursors.WaitCursor ' set the wait cursor
                ' Do some work
                frmPrincipal.mtdCriarTabelas()
            Finally
                Cursor.Current = Cursors.Default 'restore the old cursor
            End Try
        End Sub

        Private Sub btnFazerBackupBancosDados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFazerBackupBancosDados.Click
            Try
                Cursor.Current = Cursors.WaitCursor ' set the wait cursor
                ' Do some work
                frmPrincipal.mtdSalvarBancoDados()
            Finally
                Cursor.Current = Cursors.Default 'restore the old cursor
            End Try
        End Sub

        Private Sub txtMultiplicadorCodigoCarteiras_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMultiplicadorCodigoCarteiras.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtMultiplicadorCodigoCarteiras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMultiplicadorCodigoCarteiras.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoCarteiras", _
                                                txtMultiplicadorCodigoCarteiras.Text, _
                                                RegistryValueKind.String)
            frmPrincipal.intMultiplicadorCodigoCarteiras = CInt(txtMultiplicadorCodigoCarteiras.Text)
        End Sub

        Private Sub txtMultiplicadorCodigoCautelas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMultiplicadorCodigoCautelas.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtMultiplicadorCodigoCautelas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMultiplicadorCodigoCautelas.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoCautelas", _
                                                txtMultiplicadorCodigoCautelas.Text, _
                                                RegistryValueKind.String)
            frmPrincipal.intMultiplicadorCodigoCautelas = CInt(txtMultiplicadorCodigoCautelas.Text)
        End Sub

        Private Sub txtMultiplicadorCodigoMBPs_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMultiplicadorCodigoMBPs.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtMultiplicadorCodigoMBPs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMultiplicadorCodigoMBPs.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoMBPs", _
                                                txtMultiplicadorCodigoMBPs.Text, _
                                                RegistryValueKind.String)
            frmPrincipal.intMultiplicadorCodigoMBPs = CInt(txtMultiplicadorCodigoMBPs.Text)
        End Sub

        Private Sub txtMultiplicadorCodigoInventarioBens_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMultiplicadorCodigoInventarioBens.KeyPress
            If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtMultiplicadorCodigoInventarioBens_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMultiplicadorCodigoInventarioBens.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoInventarioBens", _
                                                txtMultiplicadorCodigoInventarioBens.Text, _
                                                RegistryValueKind.String)
            frmPrincipal.intMultiplicadorCodigoInventarioBens = CInt(txtMultiplicadorCodigoInventarioBens.Text)
        End Sub

        'Private Sub txtMultiplicadorCodigoBens_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMultiplicadorCodigoBens.KeyPress
        '    If Not objManipuladorTexto.mtdPermitirDigitarSoNumero(e.KeyChar) Then
        '        e.Handled = False
        '    Else
        '        e.Handled = True
        '    End If
        'End Sub

        'Private Sub txtMultiplicadorCodigoBens_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMultiplicadorCodigoBens.TextChanged
        '    objRegistroWindows.mtdSalvarDadosRegistro("MultiplicadorCodigoBens", _
        '                                        txtMultiplicadorCodigoBens.Text, _
        '                                        RegistryValueKind.String)
        '    frmPrincipal.intMultiplicadorCodigoBens = CInt(txtMultiplicadorCodigoBens.Text)
        'End Sub

        'Private Sub rtbCarteiras_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbCarteiras.Leave
        '    objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailCarteira, rtbCarteiras.Text)
        'End Sub

        'Private Sub rtbCautelas_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbCautelas.Leave
        '    objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailCautela, rtbCautelas.Text)
        'End Sub

        'Private Sub rtbMBPs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbMBPs.Leave
        '    objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailMBP, rtbMBPs.Text)
        'End Sub

        'Private Sub rtbInventarioBens_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbInventarioBens.Leave
        '    objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailInventarioBens, rtbInventarioBens.Text)
        'End Sub

        'Private Sub rtbBens_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbBens.Leave
        '    objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailBens, rtbBens.Text)
        'End Sub

        Private Sub rtbCarteiras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbCarteiras.TextChanged
            objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailCarteira, rtbCarteiras.Text)
        End Sub

        Private Sub rtbCautelas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbCautelas.TextChanged
            objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailCautela, rtbCautelas.Text)
        End Sub

        Private Sub rtbMBPs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbMBPs.TextChanged
            objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailMBP, rtbMBPs.Text)
        End Sub

        Private Sub rtbInventarioBens_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbInventarioBens.TextChanged
            objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailInventarioBens, rtbInventarioBens.Text)
        End Sub

        Private Sub rtbBens_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbBens.TextChanged
            objArquivoTXT.mtdEscritorBinario(frmPrincipal.strEnderecoTextoEmailBens, rtbBens.Text)
        End Sub

        Private Sub txtServidorSMTP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServidorSMTP.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("ServidorSMTP", txtServidorSMTP.Text, RegistryValueKind.String)
            frmPrincipal.strServidorSMTP = txtServidorSMTP.Text
        End Sub

        Private Sub txtMostrar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMostrar.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("Mostrar", txtMostrar.Text, RegistryValueKind.String)
            frmPrincipal.strMostrar = txtMostrar.Text
        End Sub

        Private Sub txtDe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDe.TextChanged
            objRegistroWindows.mtdSalvarDadosRegistro("De", txtDe.Text, RegistryValueKind.String)
            frmPrincipal.strDe = txtDe.Text
        End Sub

        Private Sub rbtPDFCarteira_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPDFCarteira.CheckedChanged
            If rbtPDFCarteira.Checked Then
                objRegistroWindows.mtdSalvarDadosRegistro("FormatoCarteira", "ExportFormatType.PortableDocFormat", RegistryValueKind.String)
                frmPrincipal._FormatoCarteira = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
            End If
        End Sub

        Private Sub rbtDOCCarteira_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDOCCarteira.CheckedChanged
            If rbtDOCCarteira.Checked Then
                objRegistroWindows.mtdSalvarDadosRegistro("FormatoCarteira", "ExportFormatType.WordForWindows", RegistryValueKind.String)
                frmPrincipal._FormatoCarteira = CrystalDecisions.Shared.ExportFormatType.WordForWindows
            End If
        End Sub

        Private Sub rbtPDFCautela_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPDFCautela.CheckedChanged
            If rbtPDFCautela.Checked Then
                objRegistroWindows.mtdSalvarDadosRegistro("FormatoCautela", "ExportFormatType.PortableDocFormat", RegistryValueKind.String)
                frmPrincipal._FormatoCautela = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
            End If
        End Sub

        Private Sub rbtDOCCautela_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDOCCautela.CheckedChanged
            If rbtDOCCautela.Checked Then
                objRegistroWindows.mtdSalvarDadosRegistro("FormatoCautela", "ExportFormatType.WordForWindows", RegistryValueKind.String)
                frmPrincipal._FormatoCautela = CrystalDecisions.Shared.ExportFormatType.WordForWindows
            End If
        End Sub

        Private Sub rbtPDFMBP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPDFMBP.CheckedChanged
            If rbtPDFMBP.Checked Then
                objRegistroWindows.mtdSalvarDadosRegistro("FormatoMBP", "ExportFormatType.PortableDocFormat", RegistryValueKind.String)
                frmPrincipal._FormatoMBP = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
            End If
        End Sub

        Private Sub rbtDOCMBP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDOCMBP.CheckedChanged
            If rbtDOCMBP.Checked Then
                objRegistroWindows.mtdSalvarDadosRegistro("FormatoMBP", "ExportFormatType.WordForWindows", RegistryValueKind.String)
                frmPrincipal._FormatoMBP = CrystalDecisions.Shared.ExportFormatType.WordForWindows
            End If
        End Sub

        Private Sub rbtPDFInventarioBens_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPDFInventarioBens.CheckedChanged
            If rbtPDFInventarioBens.Checked Then
                objRegistroWindows.mtdSalvarDadosRegistro("FormatoInventarioBens", "ExportFormatType.PortableDocFormat", RegistryValueKind.String)
                frmPrincipal._FormatoInventarioBens = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
            End If
        End Sub

        Private Sub rbtDOCInventarioBens_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDOCInventarioBens.CheckedChanged
            If rbtDOCInventarioBens.Checked Then
                objRegistroWindows.mtdSalvarDadosRegistro("FormatoInventarioBens", "ExportFormatType.WordForWindows", RegistryValueKind.String)
                frmPrincipal._FormatoInventarioBens = CrystalDecisions.Shared.ExportFormatType.WordForWindows
            End If
        End Sub

        Private Sub rbtPDFBens_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtPDFBens.CheckedChanged
            If rbtPDFBens.Checked Then
                objRegistroWindows.mtdSalvarDadosRegistro("FormatoBens", "ExportFormatType.PortableDocFormat", RegistryValueKind.String)
                frmPrincipal._FormatoBens = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
            End If
        End Sub

        Private Sub rbtDOCBens_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDOCBens.CheckedChanged
            If rbtDOCBens.Checked Then
                objRegistroWindows.mtdSalvarDadosRegistro("FormatoBens", "ExportFormatType.WordForWindows", RegistryValueKind.String)
                frmPrincipal._FormatoBens = CrystalDecisions.Shared.ExportFormatType.WordForWindows
            End If
        End Sub
    End Class
End Namespace