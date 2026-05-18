Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThGerarInventarioCautela As System.Threading.Thread

        Private strNomeProcessoGerarInventarioCautela As String = "Gerar Cautela (Inventário)"

        Private strLsvGerarInventarioCautela As String() = Nothing

        Private Sub mtdIniciarThreadGerarInventarioCautela(ByVal Lsv As String())
            strLsvGerarInventarioCautela = Lsv

            mtdIniciarThreadGerarInventarioCautela(True)
        End Sub

        Private Sub mtdIniciarThreadGerarInventarioCautela(ByVal Coluna As String, ByVal Dado As String)
            strColunaGerarInventarioCautela = Coluna
            strDadoGerarInventarioCautela = Dado

            mtdIniciarThreadGerarInventarioCautela(True)
        End Sub

        Private Sub mtdIniciarThreadGerarInventarioCautela()
            mtdIniciarThreadGerarInventarioCautela(True)
        End Sub

        Private Sub mtdIniciarThreadGerarInventarioCautela(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoGerarInventarioCautela
                blnAbortarThreadGerarInventarioCautela = Not Iniciar
                blnForcarAbortarThreadGerarInventarioCautela = False
                blnThreadAtivadaGerarInventarioCautela = True
                blnSucessoGerarInventarioCautela = False
                ThGerarInventarioCautela = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadGerarInventarioCautela))
                ThGerarInventarioCautela.IsBackground = True
                ThGerarInventarioCautela.Priority = System.Threading.ThreadPriority.Normal
                ThGerarInventarioCautela.Start()
            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadGerarInventarioCautela: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdReIniciarThreadGerarInventarioCautela()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoGerarInventarioCautela
            blnAbortarThreadGerarInventarioCautela = False
            blnForcarAbortarThreadGerarInventarioCautela = False

            blnThreadAtivadaGerarInventarioCautela = True
            blnSucessoGerarInventarioCautela = False
        End Sub

        Private Shared blnForcarAbortarThreadGerarInventarioCautela As Boolean = False
        Private Shared blnAbortarThreadGerarInventarioCautela As Boolean = False
        Private Shared intTempoSaidaAbortarThreadGerarInventarioCautela As Integer = 1000

        Private Sub mtdAbortarThreadGerarInventarioCautela()
            mtdAbortarThreadGerarInventarioCautela(False)
        End Sub

        Private Sub mtdAbortarThreadGerarInventarioCautela(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoGerarInventarioCautela
            blnAbortarThreadGerarInventarioCautela = True
            blnForcarAbortarThreadGerarInventarioCautela = Forcar

            blnThreadAtivadaGerarInventarioCautela = False
            blnSucessoGerarInventarioCautela = False

            Try
                ThGerarInventarioCautela.Join(intTempoSaidaAbortarThreadGerarInventarioCautela)
                ThGerarInventarioCautela.Abort()
                ThGerarInventarioCautela = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadGerarInventarioCautela: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdPararThreadGerarInventarioCautela()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoGerarInventarioCautela
            blnAbortarThreadGerarInventarioCautela = True
            blnForcarAbortarThreadGerarInventarioCautela = True

            blnThreadAtivadaGerarInventarioCautela = False
            blnSucessoGerarInventarioCautela = False
        End Sub

        Private Shared LockerGerarInventarioCautela As New Object()

        Private Sub mtdRotinaThreadGerarInventarioCautela()
            While Not blnForcarAbortarThreadGerarInventarioCautela
                If Not blnAbortarThreadGerarInventarioCautela Then
                    'System.Threading.Monitor.Enter(LockerGerarInventarioCautela)
                    SyncLock (LockerGerarInventarioCautela)
                        Try
                            If Not strLsvGerarInventarioCautela Is Nothing Then
                                For contador As Integer = 1 To strLsvGerarInventarioCautela.Length - 1 Step 1
                                    If strLsvGerarInventarioCautela(contador) <> Nothing Then
                                        strColunaGerarInventarioCautela = strLsvGerarInventarioCautela(0)
                                        strDadoGerarInventarioCautela = strLsvGerarInventarioCautela(contador)

                                        mtdGerarInventarioCautela()
                                    End If
                                    System.Threading.Thread.Sleep(1)
                                Next
                            Else
                                mtdGerarInventarioCautela()
                            End If
                            mtdAbortarThreadGerarInventarioCautela(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerGerarInventarioCautela)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Private blnThreadAtivadaGerarInventarioCautela As Boolean = False
        Private blnSucessoGerarInventarioCautela As Boolean = False

        'Private strNomeArquivoGerarInventarioCautela As String = String.Empty
        'Private strCampo As String = String.Empty
        'Private strDado As String = String.Empty

        Private strColunaGerarInventarioCautela As String = String.Empty
        Private strDadoGerarInventarioCautela As String = String.Empty

        Private Sub mtdGerarInventarioCautela()
            Try
                Dim PrazoEntregaCautela As Integer = Convert.ToInt32( _
                    objRegistroWindows.mtdObterDadosRegistro("PrazoEntregaCautela").ToString())

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
                    frmInventarioBens.vetCamposTabelaInventarioBens(3), _
                    frmInventarioBens.vetCamposTabelaInventarioBens(4), _
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
                        String.Format("{0}", strColunaGerarInventarioCautela), _
                        String.Format("'{0}'", strDadoGerarInventarioCautela), _
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
                strNomeProcesso = strNomeProcessoGerarInventarioCautela
                blnSucessoGerarInventarioCautela = True

                While (objImplementacaoBancoDados.mtdProximoRegistro())
                    objBDPrincipal.mtdSelecionarDados( _
                        "*", _
                        frmCautelas.strNomeTabelaCautela)
                    objBDPrincipal.mtdDefinirLeitorDados()

                    dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()
                    Dim uintCodigo As ULong = mtdGerarProximoNumeroCodigoPrincipal(frmPrincipal.intMultiplicadorCodigoCautelas, frmCautelas.strNomeTabelaCautela, "Codigo")
                    dados(1) = New String() { _
                        String.Format("{0}", uintCodigo.ToString()), _
                        String.Format("{0}", objImplementacaoBancoDados.mtdObterValorRegistro(0)), _
                        String.Format("'{0}'", objImplementacaoBancoDados.mtdObterValorRegistro(1)), _
                        String.Format("'{0}'", objImplementacaoBancoDados.mtdObterValorRegistro(2)), _
                        String.Format("{0}", objImplementacaoBancoDados.mtdObterValorRegistro(3)), _
                        String.Format("'{0}'", barlblMostrContUser.Text), _
                        String.Format("#{0}#", mtdCorrigirBugData(DateTime.Now)), _
                        String.Format("'{0}'", String.Empty), _
                        String.Format("#{0}#", "01/01/2000"), _
                        String.Format("#{0}#", "01/01/2000"), _
                        String.Format("#{0}#", "01/01/2000"), _
                        String.Format("#{0}#", "01/01/2000"), _
                        String.Format("{0}", PrazoEntregaCautela.ToString()), _
                        String.Format("'{0} - {1}'", objImplementacaoBancoDados.mtdObterValorRegistro(4), objImplementacaoBancoDados.mtdObterValorRegistro(5)) _
                    }
                    objBDPrincipal.mtdFecharConexao()
                    objBDPrincipal.mtdInserirDados(frmCautelas.strNomeTabelaCautela, dados)

                    'objBDPrincipal.mtdSelecionarDados(
                    '    frmInventarioBens.vetCamposTabelaInventarioBens,
                    '    "tblInventarioBens",
                    '    vetCamposTabelaInventarioBens(3),
                    '    "LIKE",
                    '    objImplementacaoBancoDados.mtdObterValorRegistro(3),
                    '    frmInventarioBens.vetCamposTabelaInventarioBens(0),
                    '    True)

                    objBDPrincipal.mtdAbrirConexao()
                    objBDPrincipal.mtdExecutarComando( _
                        String.Format _
                        ( _
                        "SELECT {0} FROM {1} WHERE (({2} LIKE {3}) AND ({4} LIKE {5}) AND ({6} LIKE {7}) AND ({8} LIKE {9}) AND ({10} LIKE {11})) ORDER BY {12}, {13}", _
                        "*", _
                        frmInventarioBens.strNomeTabelaPrincipal, _
                        String.Format("{0}", strColunaGerarInventarioCautela), _
                        String.Format("'{0}'", strDadoGerarInventarioCautela), _
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
                        frmCautelas.strNomeTabelaCautelaBens)
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

                        dados(1) = New String() _
                        { _
                            String.Format("{0}", mtdGerarProximoNumeroContadorPrincipal(frmCautelas.strNomeTabelaCautelaBens, "Contador").ToString()), _
                            String.Format("{0}", uintCodigo.ToString()), _
                            String.Format("{0}", intItem.ToString()), _
                            String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(8).ToString()), _
                            String.Format("'{0}'", mtdObterImobilizadoBens(objBDPrincipal.mtdObterValorRegistro(8).ToString())), _
                            String.Format("'{0}'", objBDPrincipal.mtdObterValorRegistro(10).ToString()), _
                            String.Format("'{0}'", objBDPrincipal.mtdObterValorRegistro(11).ToString()), _
                            String.Format("'{0}'", strObterConservacaoBens), _
                            String.Format("'{0}'", objBDPrincipal.mtdObterValorRegistro(5).ToString()), _
                            String.Format("'{0}'", barlblMostrContUser.Text), _
                            String.Format("#{0}#", mtdCorrigirBugData(DateTime.Now)), _
                            String.Format("'{0}'", String.Empty), _
                            String.Format("#{0}#", "01/01/2000") _
                        }
                        objBDPrincipal2.mtdInserirDados(frmCautelas.strNomeTabelaCautelaBens, dados)
                        System.Threading.Thread.Sleep(1)
                    End While

                    intProgresso = mtdProgresso(intNumeroLinhaProgresso, intNumeroMaximoLinhaProgresso)
                    strNomeProcesso = strNomeProcessoGerarInventarioCautela
                    blnSucessoGerarInventarioCautela = True

                    intNumeroLinhaProgresso += 1
                    System.Threading.Thread.Sleep(1)
                End While

                intProgresso = 100
                strNomeProcesso = strNomeProcessoGerarInventarioCautela
                blnSucessoGerarInventarioCautela = True

                objBDPrincipal.Dispose()
                objBDPrincipal2.Dispose()
                objImplementacaoBancoDados.Dispose()
                'MessageBox.Show("A(s) cautela(s) foi(ram) geradas.", "Aviso!", MessageBoxButtons.OK)
                mtdExibirNotificacao("A(s) cautela(s) foi(ram) geradas.")
            Catch ex As System.Exception
                'MessageBox.Show("Não foi possível gerar a(s) cautela(s).", "Aviso!", MessageBoxButtons.OK)
                mtdExibirNotificacao("Não foi possível gerar a(s) cautela(s).")
            End Try
        End Sub
    End Class
End Namespace