Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThImprimirCarteira As System.Threading.Thread

        Private strNomeProcessoImprimirCarteira As String = "Imprimir Carteira"

        Friend Sub mtdIniciarThreadImprimirCarteira(ByVal Codigo As Long)
            lngCodigoImprimirCarteira = Codigo

            mtdIniciarThreadImprimirCarteira(True)
        End Sub

        Friend Sub mtdIniciarThreadImprimirCarteira()
            mtdIniciarThreadImprimirCarteira(True)
        End Sub

        Friend Sub mtdIniciarThreadImprimirCarteira(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoImprimirCarteira
                blnAbortarThreadImprimirCarteira = Not Iniciar
                blnForcarAbortarThreadImprimirCarteira = False
                blnThreadAtivadaImprimirCarteira = True
                blnSucessoImprimirCarteira = False
                ThImprimirCarteira = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImprimirCarteira))
                ThImprimirCarteira.IsBackground = True
                ThImprimirCarteira.Priority = System.Threading.ThreadPriority.Normal
                ThImprimirCarteira.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImprimirCarteira: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImprimirCarteira()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirCarteira
            blnAbortarThreadImprimirCarteira = False
            blnForcarAbortarThreadImprimirCarteira = False

            blnThreadAtivadaImprimirCarteira = True
            blnSucessoImprimirCarteira = False
        End Sub

        Private Shared blnForcarAbortarThreadImprimirCarteira As Boolean = False
        Private Shared blnAbortarThreadImprimirCarteira As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImprimirCarteira As Integer = 1000

        Friend Sub mtdAbortarThreadImprimirCarteira()
            mtdAbortarThreadImprimirCarteira(False)
        End Sub

        Friend Sub mtdAbortarThreadImprimirCarteira(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirCarteira
            blnAbortarThreadImprimirCarteira = True
            blnForcarAbortarThreadImprimirCarteira = Forcar

            blnThreadAtivadaImprimirCarteira = False
            blnSucessoImprimirCarteira = False

            Try
                ThImprimirCarteira.Join(intTempoSaidaAbortarThreadImprimirCarteira)
                ThImprimirCarteira.Abort()
                ThImprimirCarteira = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImprimirCarteira: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImprimirCarteira()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirCarteira
            blnAbortarThreadImprimirCarteira = True
            blnForcarAbortarThreadImprimirCarteira = True

            blnThreadAtivadaImprimirCarteira = False
            blnSucessoImprimirCarteira = False
        End Sub

        Private Shared LockerImprimirCarteira As New Object()

        Private Sub mtdRotinaThreadImprimirCarteira()
            While Not blnForcarAbortarThreadImprimirCarteira
                If Not blnAbortarThreadImprimirCarteira Then
                    'System.Threading.Monitor.Enter(LockerImprimirCarteira)
                    SyncLock (LockerImprimirCarteira)
                        Try
                            mtdImprimirCarteira()
                            mtdAbortarThreadImprimirCarteira(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImprimirCarteira)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImprimirCarteira As Boolean = False
        Friend blnSucessoImprimirCarteira As Boolean = False

        'Private strNomeArquivoImprimirCarteira As String = String.Empty
        'Private strCampo As String = String.Empty
        'Private strDado As String = String.Empty

        Private lngCodigoImprimirCarteira As Long = 0

        'Protected Friend Sub mtdImprimirCarteira()
        '    mtdImprimirCarteira(nCopy, sPage, ePage, PrinterName)
        'End Sub

        Protected Friend Sub mtdImprimirCarteira()
            Try
                If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                    intProgresso = 0
                    strNomeProcesso = strNomeProcessoImprimirCarteira
                    blnSucessoImprimirCarteira = True

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
                                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCarteira
                                frmVisualizarImpressao.Tabela = frmCarteiras.strNomeTabelaCarteira
                                frmVisualizarImpressao.SQL = "SELECT * FROM tblCarteira WHERE tblCarteira.Codigo LIKE " & elemento(contador).ToString() & " ORDER BY tblCarteira.Codigo;"
                                'objCarteira.mtdCorrigirBugCarteira(System.Convert.ToInt64(frmCarteiras.Codigo))
                                objVisualizarImpressao.mtdImprimir()
                                mtdAtualizarDataImpressao(elemento(contador).ToString())
                            End If
                        End If

                        intProgresso = mtdProgresso(contador, elemento.Count - 1)
                        strNomeProcesso = strNomeProcessoImprimirCarteira
                        blnSucessoImprimirCarteira = True
                        System.Threading.Thread.Sleep(1)
                    Next
                Else
                    If blnVetChecadoLSVCarteira.Contains(True) Then
                        If (strVetColunasLSVCarteira.Length > 0) Then
                            If (strVetItemsLSVCarteira.Length > 0) Then
                                'blnChecadoInventarioBens = False
                                'lstListaRelatoriosExportadosInventarioBens.Clear()
                                intItemVetChecadoLSVCarteira = 0
                                For contador As Integer = 0 To strVetItemsLSVCarteira.Length - 1 Step 1
                                    If blnVetChecadoLSVCarteira(contador) Then
                                        intItemVetChecadoLSVCarteira += 1
                                        intContador = contador
                                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCarteira
                                        frmVisualizarImpressao.Tabela = frmCarteiras.strNomeTabelaCarteira
                                        frmVisualizarImpressao.SQL = String.Format("SELECT * FROM tblCarteira WHERE {0} LIKE '{1}';", strVetColunasLSVCarteira(0), strVetItemsLSVCarteira(contador)(0))
                                        'objCarteira.mtdCorrigirBugCarteira(System.Convert.ToInt64(frmCarteiras.Codigo))
                                        objVisualizarImpressao.mtdImprimir()
                                        mtdAtualizarDataImpressao(strVetItemsLSVCarteira(contador)(0))

                                        intProgresso = mtdProgresso(intItemVetChecadoLSVCarteira, intContadorVetChecadoLSVCarteira)
                                        strNomeProcesso = strNomeProcessoExportarDocumentoCarteira
                                        blnSucessoExportarDocumentoCarteira = True
                                    End If
                                    System.Threading.Thread.Sleep(1)
                                Next
                            End If
                        End If
                    Else
                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCarteira
                        frmVisualizarImpressao.Tabela = frmCarteiras.strNomeTabelaCarteira
                        frmVisualizarImpressao.SQL = "SELECT * FROM tblCarteira WHERE tblCarteira.Codigo LIKE " & frmCarteiras.Codigo & " ORDER BY tblCarteira.Codigo;"
                        'objCarteira.mtdCorrigirBugCarteira(System.Convert.ToInt64(frmCarteiras.Codigo))
                        objVisualizarImpressao.mtdImprimir()
                    End If
                End If
            Catch
                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCarteira
                frmVisualizarImpressao.Tabela = frmCarteiras.strNomeTabelaCarteira
                frmVisualizarImpressao.SQL = "SELECT * FROM tblCarteira WHERE tblCarteira.Codigo LIKE " & frmCarteiras.Codigo & " ORDER BY tblCarteira.Codigo;"
                'objCarteira.mtdCorrigirBugCarteira(System.Convert.ToInt64(frmCarteiras.Codigo))
                objVisualizarImpressao.mtdImprimir()
            Finally
                mtdAtualizarDataImpressao(frmCarteiras.Codigo.ToString())

                intProgresso = 100
                strNomeProcesso = strNomeProcessoImprimirCarteira
                blnSucessoImprimirCarteira = True
            End Try
        End Sub
    End Class
End Namespace