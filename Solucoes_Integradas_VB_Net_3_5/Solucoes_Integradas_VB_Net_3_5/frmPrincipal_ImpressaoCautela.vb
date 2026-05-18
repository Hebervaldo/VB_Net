Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThImprimirCautela As System.Threading.Thread

        Private strNomeProcessoImprimirCautela As String = "Imprimir Cautela"

        Friend Sub mtdIniciarThreadImprimirCautela(ByVal Codigo As Long)
            lngCodigoImprimirCautela = Codigo

            mtdIniciarThreadImprimirCautela(True)
        End Sub

        Friend Sub mtdIniciarThreadImprimirCautela()
            mtdIniciarThreadImprimirCautela(True)
        End Sub

        Friend Sub mtdIniciarThreadImprimirCautela(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoImprimirCautela
                blnAbortarThreadImprimirCautela = Not Iniciar
                blnForcarAbortarThreadImprimirCautela = False
                blnThreadAtivadaImprimirCautela = True
                blnSucessoImprimirCautela = False
                ThImprimirCautela = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImprimirCautela))
                ThImprimirCautela.IsBackground = True
                ThImprimirCautela.Priority = System.Threading.ThreadPriority.Normal
                ThImprimirCautela.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImprimirCautela: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImprimirCautela()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirCautela
            blnAbortarThreadImprimirCautela = False
            blnForcarAbortarThreadImprimirCautela = False

            blnThreadAtivadaImprimirCautela = True
            blnSucessoImprimirCautela = False
        End Sub

        Private Shared blnForcarAbortarThreadImprimirCautela As Boolean = False
        Private Shared blnAbortarThreadImprimirCautela As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImprimirCautela As Integer = 1000

        Friend Sub mtdAbortarThreadImprimirCautela()
            mtdAbortarThreadImprimirCautela(False)
        End Sub

        Friend Sub mtdAbortarThreadImprimirCautela(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirCautela
            blnAbortarThreadImprimirCautela = True
            blnForcarAbortarThreadImprimirCautela = Forcar

            blnThreadAtivadaImprimirCautela = False
            blnSucessoImprimirCautela = False

            Try
                ThImprimirCautela.Join(intTempoSaidaAbortarThreadImprimirCautela)
                ThImprimirCautela.Abort()
                ThImprimirCautela = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImprimirCautela: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImprimirCautela()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirCautela
            blnAbortarThreadImprimirCautela = True
            blnForcarAbortarThreadImprimirCautela = True

            blnThreadAtivadaImprimirCautela = False
            blnSucessoImprimirCautela = False
        End Sub

        Private Shared LockerImprimirCautela As New Object()

        Private Sub mtdRotinaThreadImprimirCautela()
            While Not blnForcarAbortarThreadImprimirCautela
                If Not blnAbortarThreadImprimirCautela Then
                    'System.Threading.Monitor.Enter(LockerImprimirCautela)
                    SyncLock (LockerImprimirCautela)
                        Try
                            mtdImprimirCautela()
                            mtdAbortarThreadImprimirCautela(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImprimirCautela)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImprimirCautela As Boolean = False
        Friend blnSucessoImprimirCautela As Boolean = False

        Private strNomeArquivoImprimirCautela As String = String.Empty
        'Private strCampo As String = String.Empty
        'Private strDado As String = String.Empty

        Private lngCodigoImprimirCautela As Long = 0

        Protected Friend Sub mtdImprimirCautela()
            Try
                If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                    intProgresso = 0
                    strNomeProcesso = strNomeProcessoImprimirCautela
                    blnSucessoImprimirCautela = True

                    If Int32.Parse(bcmb4text) >= Int32.Parse(bcmb5text) Then
                        Dim intVarTemp As String = bcmb4text
                        bcmb4text = bcmb5text
                        bcmb5text = intVarTemp
                    End If
                    If Int32.Parse(bcmb4text) < Int32.Parse(objDtgv1MinimoValor.ToString()) Then
                        bcmb4text = objDtgv1MinimoValor.ToString()
                    ElseIf Int32.Parse(bcmb5text) > Int32.Parse(objDtgv1MaximoValor.ToString()) Then
                        bcmb5text = objDtgv1MaximoValor.ToString()
                    End If

                    For contador As Integer = 0 To elemento.Count - 1 Step 1
                        If elemento(contador).ToString() <> String.Empty Then
                            If Convert.ToInt32(elemento(contador).ToString()) >= Int32.Parse(bcmb4text) And Convert.ToInt32(elemento(contador).ToString()) <= Int32.Parse(bcmb5text) Then
                                intContador = contador
                                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCautela
                                frmVisualizarImpressao.Tabela = frmCautelas.strNomeTabelaCautela
                                frmVisualizarImpressao.SQL = "SELECT * FROM tblCautela WHERE tblCautela.Codigo LIKE " & elemento(contador).ToString() & " ORDER BY tblCautela.Codigo;"
                                'objCautela.mtdCorrigirBugCautela(elemento(contador))
                                objVisualizarImpressao.mtdImprimir()
                                mtdAtualizarDataImpressao(elemento.Count.ToString())
                            End If
                        End If

                        intProgresso = mtdProgresso(contador, elemento.Count - 1)
                        strNomeProcesso = strNomeProcessoImprimirCautela
                        blnSucessoImprimirCautela = True
                        System.Threading.Thread.Sleep(1)
                    Next
                Else
                    If blnVetChecadoLSVCautela.Contains(True) Then
                        If (strVetColunasLSVCautela.Length > 0) Then
                            If (strVetItemsLSVCautela.Length > 0) Then
                                'blnChecadoInventarioBens = False
                                'lstListaRelatoriosExportadosInventarioBens.Clear()
                                intItemVetChecadoLSVCautela = 0
                                For contador As Integer = 0 To strVetItemsLSVCautela.Length - 1 Step 1
                                    If blnVetChecadoLSVCautela(contador) Then
                                        intItemVetChecadoLSVCautela += 1
                                        intContador = contador
                                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCautela
                                        frmVisualizarImpressao.Tabela = frmCautelas.strNomeTabelaCautela
                                        frmVisualizarImpressao.SQL = String.Format("SELECT * FROM tblCautela WHERE {0} LIKE '{1}';", strVetColunasLSVCautela(0), strVetItemsLSVCautela(contador)(0))
                                        'objCautela.mtdCorrigirBugCautela(System.Convert.ToInt64(frmCautelas.Codigo))
                                        objVisualizarImpressao.mtdImprimir()
                                        mtdAtualizarDataImpressao(strVetItemsLSVCautela(contador)(0))

                                        intProgresso = mtdProgresso(intItemVetChecadoLSVCautela, intContadorVetChecadoLSVCautela)
                                        strNomeProcesso = strNomeProcessoExportarDocumentoCautela
                                        blnSucessoExportarDocumentoCautela = True
                                    End If
                                    System.Threading.Thread.Sleep(1)
                                Next
                            End If
                        End If
                    Else
                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCautela
                        frmVisualizarImpressao.Tabela = frmCautelas.strNomeTabelaCautela
                        frmVisualizarImpressao.SQL = "SELECT * FROM tblCautela WHERE tblCautela.Codigo LIKE " & frmCautelas.Codigo & " ORDER BY tblCautela.Codigo;"
                        'objCautela.mtdCorrigirBugCautela(System.Convert.ToInt64(frmCautelas.Codigo))
                        objVisualizarImpressao.mtdImprimir()
                    End If
                End If
            Catch ex As Exception
                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCautela
                frmVisualizarImpressao.Tabela = frmCautelas.strNomeTabelaCautela
                frmVisualizarImpressao.SQL = "SELECT * FROM tblCautela WHERE tblCautela.Codigo LIKE " & frmCautelas.Codigo & " ORDER BY tblCautela.Codigo;"
                'objCautela.mtdCorrigirBugCautela(System.Convert.ToInt64(frmCautelas.Codigo))
                objVisualizarImpressao.mtdImprimir()
            Finally
                mtdAtualizarDataImpressao(frmCautelas.Codigo.ToString())

                intProgresso = 100
                strNomeProcesso = strNomeProcessoImprimirCautela
                blnSucessoImprimirCautela = True
            End Try
        End Sub
    End Class
End Namespace