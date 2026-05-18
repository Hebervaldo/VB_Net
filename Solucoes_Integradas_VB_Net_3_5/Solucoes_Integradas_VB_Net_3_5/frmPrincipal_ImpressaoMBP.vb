Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThImprimirMBP As System.Threading.Thread

        Private strNomeProcessoImprimirMBP As String = "Imprimir MBP"

        Friend Sub mtdIniciarThreadImprimirMBP(ByVal Codigo As Long)
            lngCodigoImprimirMBP = Codigo

            mtdIniciarThreadImprimirMBP(True)
        End Sub

        Friend Sub mtdIniciarThreadImprimirMBP()
            mtdIniciarThreadImprimirMBP(True)
        End Sub

        Friend Sub mtdIniciarThreadImprimirMBP(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoImprimirMBP
                blnAbortarThreadImprimirMBP = Not Iniciar
                blnForcarAbortarThreadImprimirMBP = False
                blnThreadAtivadaImprimirMBP = True
                blnSucessoImprimirMBP = False
                ThImprimirMBP = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImprimirMBP))
                ThImprimirMBP.IsBackground = True
                ThImprimirMBP.Priority = System.Threading.ThreadPriority.Normal
                ThImprimirMBP.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImprimirMBP: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImprimirMBP()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirMBP
            blnAbortarThreadImprimirMBP = False
            blnForcarAbortarThreadImprimirMBP = False

            blnThreadAtivadaImprimirMBP = True
            blnSucessoImprimirMBP = False
        End Sub

        Private Shared blnForcarAbortarThreadImprimirMBP As Boolean = False
        Private Shared blnAbortarThreadImprimirMBP As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImprimirMBP As Integer = 1000

        Friend Sub mtdAbortarThreadImprimirMBP()
            mtdAbortarThreadImprimirMBP(False)
        End Sub

        Friend Sub mtdAbortarThreadImprimirMBP(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirMBP
            blnAbortarThreadImprimirMBP = True
            blnForcarAbortarThreadImprimirMBP = Forcar

            blnThreadAtivadaImprimirMBP = False
            blnSucessoImprimirMBP = False

            Try
                ThImprimirMBP.Join(intTempoSaidaAbortarThreadImprimirMBP)
                ThImprimirMBP.Abort()
                ThImprimirMBP = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImprimirMBP: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImprimirMBP()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirMBP
            blnAbortarThreadImprimirMBP = True
            blnForcarAbortarThreadImprimirMBP = True

            blnThreadAtivadaImprimirMBP = False
            blnSucessoImprimirMBP = False
        End Sub

        Private Shared LockerImprimirMBP As New Object()

        Private Sub mtdRotinaThreadImprimirMBP()
            While Not blnForcarAbortarThreadImprimirMBP
                If Not blnAbortarThreadImprimirMBP Then
                    'System.Threading.Monitor.Enter(LockerImprimirMBP)
                    SyncLock (LockerImprimirMBP)
                        Try
                            mtdImprimirMBP()
                            mtdAbortarThreadImprimirMBP(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImprimirMBP)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImprimirMBP As Boolean = False
        Friend blnSucessoImprimirMBP As Boolean = False

        'Private strNomeArquivoImprimirMBP As String = String.Empty
        'Private strCampo As String = String.Empty
        'Private strDado As String = String.Empty

        Private lngCodigoImprimirMBP As Long = 0

        'Protected Friend Sub mtdImprimirMBP()
        '    mtdImprimirMBP(nCopy, sPage, ePage, PrinterName)
        'End Sub

        Protected Friend Sub mtdImprimirMBP()
            Try
                If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                    intProgresso = 0
                    strNomeProcesso = strNomeProcessoImprimirMBP
                    blnSucessoImprimirMBP = True

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
                                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioMBP
                                frmVisualizarImpressao.Tabela = frmMBPs.strNomeTabelaMBP
                                frmVisualizarImpressao.SQL = "SELECT * FROM tblMBP WHERE tblMBP.Codigo LIKE " & elemento(contador).ToString() & " ORDER BY tblMBP.Codigo;"
                                'objMBP.mtdCorrigirBugMBP(System.Convert.ToInt64(frmMBPs.Codigo))
                                objVisualizarImpressao.mtdImprimir()
                                mtdAtualizarDataImpressao(elemento(contador).ToString())
                            End If
                        End If

                        intProgresso = mtdProgresso(contador, elemento.Count - 1)
                        strNomeProcesso = strNomeProcessoImprimirMBP
                        blnSucessoImprimirMBP = True
                        System.Threading.Thread.Sleep(1)
                    Next
                Else
                    If blnVetChecadoLSVMBP.Contains(True) Then
                        If (strVetColunasLSVMBP.Length > 0) Then
                            If (strVetItemsLSVMBP.Length > 0) Then
                                'blnChecadoInventarioBens = False
                                'lstListaRelatoriosExportadosInventarioBens.Clear()
                                intItemVetChecadoLSVMBP = 0
                                For contador As Integer = 0 To strVetItemsLSVMBP.Length - 1 Step 1
                                    If blnVetChecadoLSVMBP(contador) Then
                                        intItemVetChecadoLSVMBP += 1
                                        intContador = contador
                                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioMBP
                                        frmVisualizarImpressao.Tabela = frmMBPs.strNomeTabelaMBP
                                        frmVisualizarImpressao.SQL = String.Format("SELECT * FROM tblMBP WHERE {0} LIKE '{1}';", strVetColunasLSVMBP(0), strVetItemsLSVMBP(contador)(0))
                                        'objMBP.mtdCorrigirBugMBP(System.Convert.ToInt64(frmMBPs.Codigo))
                                        objVisualizarImpressao.mtdImprimir()
                                        mtdAtualizarDataImpressao(strVetItemsLSVMBP(contador)(0))

                                        intProgresso = mtdProgresso(intItemVetChecadoLSVMBP, intContadorVetChecadoLSVMBP)
                                        strNomeProcesso = strNomeProcessoExportarDocumentoMBP
                                        blnSucessoExportarDocumentoMBP = True
                                    End If
                                    System.Threading.Thread.Sleep(1)
                                Next
                            End If
                        End If
                    Else
                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioMBP
                        frmVisualizarImpressao.Tabela = frmMBPs.strNomeTabelaMBP
                        frmVisualizarImpressao.SQL = "SELECT * FROM tblMBP WHERE tblMBP.Codigo LIKE " & frmMBPs.Codigo & " ORDER BY tblMBP.Codigo;"
                        'objMBP.mtdCorrigirBugMBP(System.Convert.ToInt64(frmMBPs.Codigo))
                        objVisualizarImpressao.mtdImprimir()
                    End If
                End If
            Catch
                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioMBP
                frmVisualizarImpressao.Tabela = frmMBPs.strNomeTabelaMBP
                frmVisualizarImpressao.SQL = "SELECT * FROM tblMBP WHERE tblMBP.Codigo LIKE " & frmMBPs.Codigo & " ORDER BY tblMBP.Codigo;"
                'objMBP.mtdCorrigirBugMBP(System.Convert.ToInt64(frmMBPs.Codigo))
                objVisualizarImpressao.mtdImprimir()
            Finally
                mtdAtualizarDataImpressao(frmMBPs.Codigo.ToString())

                intProgresso = 100
                strNomeProcesso = strNomeProcessoImprimirMBP
                blnSucessoImprimirMBP = True
            End Try
        End Sub
    End Class
End Namespace