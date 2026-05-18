Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThExportarDocumentoMBP As System.Threading.Thread

        Private strNomeProcessoExportarDocumentoMBP As String = "Exportar Documento MBP"

        Friend Sub mtdIniciarThreadExportarDocumentoMBP(ByVal Codigo As Long)
            lngCodigoExportarDocumentoMBP = Codigo

            mtdIniciarThreadExportarDocumentoMBP(True)
        End Sub

        Friend Sub mtdIniciarThreadExportarDocumentoMBP()
            mtdIniciarThreadExportarDocumentoMBP(True)
        End Sub

        Friend Sub mtdIniciarThreadExportarDocumentoMBP(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoExportarDocumentoMBP
                blnAbortarThreadExportarDocumentoMBP = Not Iniciar
                blnForcarAbortarThreadExportarDocumentoMBP = False
                blnThreadAtivadaExportarDocumentoMBP = True
                blnSucessoExportarDocumentoMBP = False
                ThExportarDocumentoMBP = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadExportarDocumentoMBP))
                ThExportarDocumentoMBP.IsBackground = True
                ThExportarDocumentoMBP.Priority = System.Threading.ThreadPriority.Normal
                ThExportarDocumentoMBP.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadExportarDocumentoMBP: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadExportarDocumentoMBP()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoMBP
            blnAbortarThreadExportarDocumentoMBP = False
            blnForcarAbortarThreadExportarDocumentoMBP = False

            blnThreadAtivadaExportarDocumentoMBP = True
            blnSucessoExportarDocumentoMBP = False
        End Sub

        Private Shared blnForcarAbortarThreadExportarDocumentoMBP As Boolean = False
        Private Shared blnAbortarThreadExportarDocumentoMBP As Boolean = False
        Private Shared intTempoSaidaAbortarThreadExportarDocumentoMBP As Integer = 1000

        Friend Sub mtdAbortarThreadExportarDocumentoMBP()
            mtdAbortarThreadExportarDocumentoMBP(False)
        End Sub

        Friend Sub mtdAbortarThreadExportarDocumentoMBP(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoMBP
            blnAbortarThreadExportarDocumentoMBP = True
            blnForcarAbortarThreadExportarDocumentoMBP = Forcar

            blnThreadAtivadaExportarDocumentoMBP = False
            blnSucessoExportarDocumentoMBP = False

            Try
                ThExportarDocumentoMBP.Join(intTempoSaidaAbortarThreadExportarDocumentoMBP)
                ThExportarDocumentoMBP.Abort()
                ThExportarDocumentoMBP = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadExportarDocumentoMBP: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadExportarDocumentoMBP()
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoExportarDocumentoMBP
            blnAbortarThreadExportarDocumentoMBP = True
            blnForcarAbortarThreadExportarDocumentoMBP = True

            blnThreadAtivadaExportarDocumentoMBP = False
            blnSucessoExportarDocumentoMBP = False
        End Sub

        Private Shared LockerExportarDocumentoMBP As New Object()

        Private Sub mtdRotinaThreadExportarDocumentoMBP()
            While Not blnForcarAbortarThreadExportarDocumentoMBP
                If Not blnAbortarThreadExportarDocumentoMBP Then
                    'System.Threading.Monitor.Enter(LockerExportarDocumentoMBP)
                    SyncLock (LockerExportarDocumentoMBP)
                        Try
                            mtdExportarDocumentoMBP()
                            mtdAbortarThreadExportarDocumentoMBP(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerExportarDocumentoMBP)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaExportarDocumentoMBP As Boolean = False
        Friend blnSucessoExportarDocumentoMBP As Boolean = False

        Private lngCodigoExportarDocumentoMBP As Long = 0

        Protected Friend Sub mtdExportarDocumentoMBP()
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoExportarDocumentoMBP
                blnSucessoExportarDocumentoMBP = True

                If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
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
                                _NomeArquivo = "MBP_" & elemento(contador).ToString()
                                sfd.FileName = _NomeArquivo & "." & _Extensao
                                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioMBP
                                frmVisualizarImpressao.Tabela = frmMBPs.strNomeTabelaMBP
                                frmVisualizarImpressao.SQL = "SELECT * FROM tblMBP WHERE tblMBP.Codigo LIKE '" & elemento(contador).ToString() & "';"
                                objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
                                mtdAtualizarDataImpressao(elemento(contador).ToString())
                            End If
                        End If

                        intProgresso = mtdProgresso(contador, elemento.Count - 1)
                        strNomeProcesso = strNomeProcessoExportarDocumentoMBP
                        blnSucessoExportarDocumentoMBP = True
                        System.Threading.Thread.Sleep(1)
                    Next
                Else
                    If (blnVetChecadoLSVMBP.Contains(True)) Then
                        If (strVetColunasLSVMBP.Length > 0) Then
                            If (strVetItemsLSVMBP.Length > 0) Then
                                'blnChecadoInventarioBens = False
                                'lstListaRelatoriosExportadosInventarioBens.Clear()
                                intItemVetChecadoLSVMBP = 0
                                For contador As Integer = 0 To strVetItemsLSVMBP.Length - 1 Step 1
                                    If blnVetChecadoLSVMBP(contador) Then
                                        intItemVetChecadoLSVMBP += 1
                                        _NomeArquivo = "MBP_" & strVetItemsLSVMBP(contador)(0)
                                        sfd.FileName = _NomeArquivo & "." & _Extensao
                                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioMBP
                                        frmVisualizarImpressao.Tabela = frmMBPs.strNomeTabelaMBP
                                        frmVisualizarImpressao.SQL = String.Format("SELECT * FROM tblMBP WHERE {0} LIKE '{1}';", strVetColunasLSVMBP(0), strVetItemsLSVMBP(contador)(0))
                                        objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
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
                        _NomeArquivo = "MBP_" & frmMBPs.Codigo
                        sfd.FileName = _NomeArquivo & "." & _Extensao
                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioMBP
                        frmVisualizarImpressao.Tabela = frmMBPs.strNomeTabelaMBP
                        frmVisualizarImpressao.SQL = "SELECT * FROM tblMBP WHERE tblMBP.Codigo LIKE '" & frmMBPs.Codigo & "';"
                        objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
                    End If
                End If
            Catch
                _NomeArquivo = "MBP_" & frmMBPs.Codigo
                sfd.FileName = _NomeArquivo & "." & _Extensao
                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioMBP
                frmVisualizarImpressao.Tabela = frmMBPs.strNomeTabelaMBP
                frmVisualizarImpressao.SQL = "SELECT * FROM tblMBP WHERE tblMBP.Codigo LIKE '" & frmMBPs.Codigo & "';"
                objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
            Finally
                mtdAtualizarDataImpressao(frmMBPs.Codigo.ToString())

                intProgresso = 100
                strNomeProcesso = strNomeProcessoExportarDocumentoMBP
                blnSucessoExportarDocumentoMBP = True
            End Try
        End Sub
    End Class
End Namespace