Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThGerarInventarioMBP As System.Threading.Thread

        Private strNomeProcessoGerarInventarioMBP As String = "Gerar MBP (Inventário)"

        Private strLsvGerarInventarioMBP As String() = Nothing

        Private Sub mtdIniciarThreadGerarInventarioMBP(ByVal Lsv As String())
            strLsvGerarInventarioCautela = Lsv

            mtdIniciarThreadGerarInventarioMBP(True)
        End Sub

        Private Sub mtdIniciarThreadGerarInventarioMBP(ByVal Coluna As String, ByVal Dado As String)
            strColunaGerarInventarioMBP = Coluna
            strDadoGerarInventarioMBP = Dado

            mtdIniciarThreadGerarInventarioMBP(True)
        End Sub

        Private Sub mtdIniciarThreadGerarInventarioMBP()
            mtdIniciarThreadGerarInventarioMBP(True)
        End Sub

        Private Sub mtdIniciarThreadGerarInventarioMBP(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoGerarInventarioMBP
                blnAbortarThreadGerarInventarioMBP = Not Iniciar
                blnForcarAbortarThreadGerarInventarioMBP = False
                blnThreadAtivadaGerarInventarioMBP = True
                blnSucessoGerarInventarioMBP = False
                ThGerarInventarioMBP = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadGerarInventarioMBP))
                ThGerarInventarioMBP.IsBackground = True
                ThGerarInventarioMBP.Priority = System.Threading.ThreadPriority.Normal
                ThGerarInventarioMBP.Start()
            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadGerarInventarioMBP: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdReIniciarThreadGerarInventarioMBP()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoGerarInventarioMBP
            blnAbortarThreadGerarInventarioMBP = False
            blnForcarAbortarThreadGerarInventarioMBP = False

            blnThreadAtivadaGerarInventarioMBP = True
            blnSucessoGerarInventarioMBP = False
        End Sub

        Private Shared blnForcarAbortarThreadGerarInventarioMBP As Boolean = False
        Private Shared blnAbortarThreadGerarInventarioMBP As Boolean = False
        Private Shared intTempoSaidaAbortarThreadGerarInventarioMBP As Integer = 1000

        Private Sub mtdAbortarThreadGerarInventarioMBP()
            mtdAbortarThreadGerarInventarioMBP(False)
        End Sub

        Private Sub mtdAbortarThreadGerarInventarioMBP(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoGerarInventarioMBP
            blnAbortarThreadGerarInventarioMBP = True
            blnForcarAbortarThreadGerarInventarioMBP = Forcar

            blnThreadAtivadaGerarInventarioMBP = False
            blnSucessoGerarInventarioMBP = False

            Try
                ThGerarInventarioMBP.Join(intTempoSaidaAbortarThreadGerarInventarioMBP)
                ThGerarInventarioMBP.Abort()
                ThGerarInventarioMBP = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadGerarInventarioMBP: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdPararThreadGerarInventarioMBP()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoGerarInventarioMBP
            blnAbortarThreadGerarInventarioMBP = True
            blnForcarAbortarThreadGerarInventarioMBP = True

            blnThreadAtivadaGerarInventarioMBP = False
            blnSucessoGerarInventarioMBP = False
        End Sub

        Private Shared LockerGerarInventarioMBP As New Object()

        Private Sub mtdRotinaThreadGerarInventarioMBP()
            While Not blnForcarAbortarThreadGerarInventarioMBP
                If Not blnAbortarThreadGerarInventarioMBP Then
                    'System.Threading.Monitor.Enter(LockerGerarInventarioMBP)
                    SyncLock (LockerGerarInventarioMBP)
                        Try
                            If Not strLsvGerarInventarioCautela Is Nothing Then
                                For contador As Integer = 1 To strLsvGerarInventarioCautela.Length - 1 Step 1
                                    If strLsvGerarInventarioCautela(contador) <> Nothing Then
                                        strColunaGerarInventarioMBP = strLsvGerarInventarioCautela(0)
                                        strDadoGerarInventarioMBP = strLsvGerarInventarioCautela(contador)

                                        mtdGerarInventarioMBP()
                                    End If
                                Next
                            Else
                                mtdGerarInventarioMBP()
                            End If
                            mtdAbortarThreadGerarInventarioMBP(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerGerarInventarioMBP)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Private blnThreadAtivadaGerarInventarioMBP As Boolean = False
        Private blnSucessoGerarInventarioMBP As Boolean = False

        'Private strNomeArquivoGerarInventarioMBP As String = String.Empty
        'Private strCampo As String = String.Empty
        'Private strDado As String = String.Empty

        Private strColunaGerarInventarioMBP As String = String.Empty
        Private strDadoGerarInventarioMBP As String = String.Empty

        Private Sub mtdGerarInventarioMBP()
            Try
                Dim Matricula_RG As Long = Convert.ToInt32(objRegistroWindows.mtdObterDadosRegistro("Matricula_RG").ToString())
                Dim vetDadosUsuarioRG As Object() = mtdObterInformacoesUsuario(Matricula_RG.ToString())
                Dim vetTipoMBP As Object()() = mtdObterTipoMBP()
                Dim vetPropriedadeMBP As Object()() = mtdObterPropriedadeMBP()
                Dim vetMotivacaoMBP As Object()() = mtdObterMotivacaoMBP()
                'Dim PrazoEmprestimoMBP As Integer = Convert.ToInt32(
                '    objRegistroWindows.mtdObterDadosRegistro("PrazoEmprestimoMBP").ToString())

                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                Dim objBDPrincipal2 As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                Dim vetObterConservacaoBens As Object() = mtdObterConservacaoBens()
                Dim strObterConservacaoBens As String = String.Empty

                Dim dados As String()() = New String(1)() {}

                objBDPrincipal.mtdDefinirStringConexaoAccess( _
                clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

                objBDPrincipal2.mtdDefinirStringConexaoAccess( _
                clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

                objImplementacaoBancoDados.mtdDefinirStringConexaoAccess( _
                    clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)

                Dim vetCamposTabelaInventarioBens As String() = New String() { _
                    frmInventarioBens.vetCamposTabelaInventarioBens(4), _
                    frmInventarioBens.vetCamposTabelaInventarioBens(5), _
                    frmInventarioBens.vetCamposTabelaInventarioBens(6), _
                    frmInventarioBens.vetCamposTabelaInventarioBens(7), _
                    frmInventarioBens.vetCamposTabelaInventarioBens(13), _
                    frmInventarioBens.vetCamposTabelaInventarioBens(14) _
                }

                objImplementacaoBancoDados.mtdAbrirConexao()
                objImplementacaoBancoDados.mtdExecutarComando( _
                    String.Format( _
                        "SELECT DISTINCT {0} FROM {1} WHERE {2} LIKE {3} GROUP BY {4} ORDER BY {5}", _
                        String.Format _
                        ( _
                            "{0}, {1}, {2}, {3}, {4}, {5}", _
                            vetCamposTabelaInventarioBens(0), _
                            vetCamposTabelaInventarioBens(1), _
                            vetCamposTabelaInventarioBens(2), _
                            vetCamposTabelaInventarioBens(3), _
                            vetCamposTabelaInventarioBens(4), _
                            vetCamposTabelaInventarioBens(5) _
                        ), _
                        frmInventarioBens.strNomeTabelaPrincipal, _
                        String.Format("{0}", strColunaGerarInventarioMBP), _
                        String.Format("'{0}'", strDadoGerarInventarioMBP), _
                        String.Format _
                        ( _
                            "{0}, {1}, {2}, {3}, {4}, {5}", _
                            vetCamposTabelaInventarioBens(0), _
                            vetCamposTabelaInventarioBens(1), _
                            vetCamposTabelaInventarioBens(2), _
                            vetCamposTabelaInventarioBens(3), _
                            vetCamposTabelaInventarioBens(4), _
                            vetCamposTabelaInventarioBens(5) _
                        ), _
                        vetCamposTabelaInventarioBens(3)))

                Dim intNumeroMaximoLinhaProgresso As Integer = objImplementacaoBancoDados.mtdNumeroLinhas()
                Dim intNumeroLinhaProgresso As Integer = 0

                objImplementacaoBancoDados.mtdDefinirLeitorDados()

                intProgresso = 0
                strNomeProcesso = strNomeProcessoGerarInventarioMBP
                blnSucessoGerarInventarioMBP = True

                While (objImplementacaoBancoDados.mtdProximoRegistro())
                    Dim vetDadosUsuario() As Object = mtdObterInformacoesUsuario(objImplementacaoBancoDados.mtdObterValorRegistro(3).ToString())
                    objBDPrincipal.mtdSelecionarDados( _
                        "*", _
                        frmMBPs.strNomeTabelaMBP)
                    objBDPrincipal.mtdDefinirLeitorDados()

                    dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()
                    Dim uintCodigo As ULong = mtdGerarProximoNumeroCodigoPrincipal(frmPrincipal.intMultiplicadorCodigoMBPs, frmMBPs.strNomeTabelaMBP, "Codigo")
                    dados(1) = New String() { _
                        String.Format("{0}", uintCodigo.ToString()), _
                        String.Format("'{0}'", If(vetDadosUsuarioRG.Length > 0, vetDadosUsuarioRG(0), String.Empty)), _
                        String.Format("'{0}'", If(vetDadosUsuarioRG.Length > 1, vetDadosUsuarioRG(1), String.Empty)), _
                        String.Format("'{0}'", If(vetDadosUsuarioRG.Length > 2, vetDadosUsuarioRG(2), String.Empty)), _
                        String.Format("'{0}'", If(vetDadosUsuarioRG.Length > 3, vetDadosUsuarioRG(3), String.Empty)), _
                        String.Format("{0}", Matricula_RG), _
                        String.Format("'{0}'", objImplementacaoBancoDados.mtdObterValorRegistro(0)), _
                        String.Format("'{0}'", objImplementacaoBancoDados.mtdObterValorRegistro(1)), _
                        String.Format("'{0}'", If(vetDadosUsuario.Length > 2, vetDadosUsuario(2), String.Empty)), _
                        String.Format("'{0}'", objImplementacaoBancoDados.mtdObterValorRegistro(2)), _
                        String.Format("{0}", objImplementacaoBancoDados.mtdObterValorRegistro(3)), _
                        String.Format("'{0}'", Convert.ToString(vetTipoMBP(2)(0))), _
                        String.Format("'{0}'", Convert.ToString(vetPropriedadeMBP(1)(0))), _
                        String.Format("'{0}'", Convert.ToString(vetMotivacaoMBP(1)(0))), _
                        String.Format("'{0}'", barlblMostrContUser.Text), _
                        String.Format("#{0}#", mtdCorrigirBugData(DateTime.Now)), _
                        String.Format("'{0}'", String.Empty), _
                        String.Format("#{0}#", "01/01/2000"), _
                        String.Format("#{0}#", "01/01/2000"), _
                        String.Format("#{0}#", mtdCorrigirBugData(DateTime.Now)), _
                        String.Format("#{0}#", "01/01/2000"), _
                        String.Format("{0}", 0), _
                        String.Format("'{0} - {1}'", objImplementacaoBancoDados.mtdObterValorRegistro(4), objImplementacaoBancoDados.mtdObterValorRegistro(5)) _
                    }
                    objBDPrincipal.mtdInserirDados(frmMBPs.strNomeTabelaMBP, dados)

                    objBDPrincipal.mtdAbrirConexao()
                    objBDPrincipal.mtdExecutarComando( _
                        String.Format _
                        ( _
                        "SELECT {0} FROM {1} WHERE (({2} LIKE {3}) AND ({4} LIKE {5}) AND ({6} LIKE {7}) AND ({8} LIKE {9}) AND ({10} LIKE {11})) ORDER BY {12}, {13}", _
                        "*", _
                        frmInventarioBens.strNomeTabelaPrincipal, _
                        String.Format("{0}", strColunaGerarInventarioMBP), _
                        String.Format("'{0}'", strDadoGerarInventarioMBP), _
                        vetCamposTabelaInventarioBens(0), _
                        String.Format("'{0}'", objImplementacaoBancoDados.mtdObterValorRegistro(0)), _
                        vetCamposTabelaInventarioBens(1), _
                        String.Format("'{0}'", objImplementacaoBancoDados.mtdObterValorRegistro(1)), _
                        vetCamposTabelaInventarioBens(2), _
                        String.Format("'{0}'", objImplementacaoBancoDados.mtdObterValorRegistro(2)), _
                        vetCamposTabelaInventarioBens(3), _
                        String.Format("'{0}'", objImplementacaoBancoDados.mtdObterValorRegistro(3)), _
                        vetCamposTabelaInventarioBens(2), _
                        frmInventarioBens.vetCamposTabelaInventarioBens(8) _
                        ) _
                        )

                    objBDPrincipal.mtdDefinirLeitorDados()

                    dados = New String(1)() {}
                    objBDPrincipal2.mtdSelecionarDados( _
                        "*", _
                        frmMBPs.strNomeTabelaMBPBens)
                    objBDPrincipal2.mtdDefinirLeitorDados()

                    dados(0) = objBDPrincipal2.mtdObterCabecalhoColunas()

                    Dim intItem As Integer = 0

                    While (objBDPrincipal.mtdProximoRegistro())
                        intItem += 1

                        For contador As Integer = vetObterConservacaoBens.GetLowerBound(0) To vetObterConservacaoBens.GetUpperBound(0) Step 1
                            If objBDPrincipal.mtdObterValorRegistro(12).ToString().Contains(vetObterConservacaoBens(contador)(0).ToString()) Then
                                strObterConservacaoBens = vetObterConservacaoBens(contador)(0).ToString()
                                Exit For
                            Else
                                strObterConservacaoBens = vetObterConservacaoBens(2)(0).ToString()
                            End If
                            System.Threading.Thread.Sleep(1)
                        Next

                        dados(1) = New String() { _
                            String.Format("{0}", mtdGerarProximoNumeroContadorPrincipal(frmMBPs.strNomeTabelaMBPBens, "Contador").ToString()), _
                            String.Format("{0}", uintCodigo.ToString()), _
                            String.Format("{0}", intItem.ToString()), _
                            String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(8).ToString()), _
                            String.Format("'{0}'", objBDPrincipal.mtdObterValorRegistro(10).ToString()), _
                            String.Format("'{0}'", objBDPrincipal.mtdObterValorRegistro(11).ToString()), _
                            String.Format("'{0}'", strObterConservacaoBens), _
                            String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(7).ToString()), _
                            String.Format("'{0}'", barlblMostrContUser.Text), _
                            String.Format("#{0}#", mtdCorrigirBugData(DateTime.Now)), _
                            String.Format("'{0}'", String.Empty), _
                            String.Format("#{0}#", "01/01/2000") _
                        }
                        objBDPrincipal2.mtdInserirDados(frmMBPs.strNomeTabelaMBPBens, dados)
                        System.Threading.Thread.Sleep(1)
                    End While

                    intProgresso = mtdProgresso(intNumeroLinhaProgresso, intNumeroMaximoLinhaProgresso)
                    strNomeProcesso = strNomeProcessoGerarInventarioMBP
                    blnSucessoGerarInventarioMBP = True

                    intNumeroLinhaProgresso += 1
                    System.Threading.Thread.Sleep(1)
                End While

                intProgresso = 100
                strNomeProcesso = strNomeProcessoGerarInventarioMBP
                blnSucessoGerarInventarioMBP = True

                objBDPrincipal.Dispose()
                objBDPrincipal2.Dispose()
                objImplementacaoBancoDados.Dispose()
                'MessageBox.Show("A(s) MBP(s) foi(ram) geradas.", "Aviso!", MessageBoxButtons.OK)
                mtdExibirNotificacao("A(s) MBP(s) foi(ram) geradas.")
            Catch ex As System.Exception
                'MessageBox.Show("Não foi possível gerar a(s) MBP(s).", "Aviso!", MessageBoxButtons.OK)
                mtdExibirNotificacao("Não foi possível gerar a(s) MBP(s).")
            End Try
        End Sub
    End Class
End Namespace