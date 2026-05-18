Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThExportarDocumentoCautela As System.Threading.Thread

        Private strNomeProcessoExportarDocumentoCautela As String = "Exportar Documento Cautela"

        Friend Sub mtdIniciarThreadExportarDocumentoCautela(ByVal Codigo As Long)
            lngCodigoExportarDocumentoCautela = Codigo

            mtdIniciarThreadExportarDocumentoCautela(True)
        End Sub

        Friend Sub mtdIniciarThreadExportarDocumentoCautela()
            mtdIniciarThreadExportarDocumentoCautela(True)
        End Sub

        Friend Sub mtdIniciarThreadExportarDocumentoCautela(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoExportarDocumentoCautela
                blnAbortarThreadExportarDocumentoCautela = Not Iniciar
                blnForcarAbortarThreadExportarDocumentoCautela = False
                blnThreadAtivadaExportarDocumentoCautela = True
                blnSucessoExportarDocumentoCautela = False
                ThExportarDocumentoCautela = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadExportarDocumentoCautela))
                ThExportarDocumentoCautela.IsBackground = True
                ThExportarDocumentoCautela.Priority = System.Threading.ThreadPriority.Normal
                ThExportarDocumentoCautela.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadExportarDocumentoCautela: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadExportarDocumentoCautela()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoCautela
            blnAbortarThreadExportarDocumentoCautela = False
            blnForcarAbortarThreadExportarDocumentoCautela = False

            blnThreadAtivadaExportarDocumentoCautela = True
            blnSucessoExportarDocumentoCautela = False
        End Sub

        Private Shared blnForcarAbortarThreadExportarDocumentoCautela As Boolean = False
        Private Shared blnAbortarThreadExportarDocumentoCautela As Boolean = False
        Private Shared intTempoSaidaAbortarThreadExportarDocumentoCautela As Integer = 1000

        Friend Sub mtdAbortarThreadExportarDocumentoCautela()
            mtdAbortarThreadExportarDocumentoCautela(False)
        End Sub

        Friend Sub mtdAbortarThreadExportarDocumentoCautela(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoCautela
            blnAbortarThreadExportarDocumentoCautela = True
            blnForcarAbortarThreadExportarDocumentoCautela = Forcar

            blnThreadAtivadaExportarDocumentoCautela = False
            blnSucessoExportarDocumentoCautela = False

            Try
                ThExportarDocumentoCautela.Join(intTempoSaidaAbortarThreadExportarDocumentoCautela)
                ThExportarDocumentoCautela.Abort()
                ThExportarDocumentoCautela = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadExportarDocumentoCautela: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadExportarDocumentoCautela()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoCautela
            blnAbortarThreadExportarDocumentoCautela = True
            blnForcarAbortarThreadExportarDocumentoCautela = True

            blnThreadAtivadaExportarDocumentoCautela = False
            blnSucessoExportarDocumentoCautela = False
        End Sub

        Private Shared LockerExportarDocumentoCautela As New Object()

        Private Sub mtdRotinaThreadExportarDocumentoCautela()
            While Not blnForcarAbortarThreadExportarDocumentoCautela
                If Not blnAbortarThreadExportarDocumentoCautela Then
                    'System.Threading.Monitor.Enter(LockerExportarDocumentoCautela)
                    SyncLock (LockerExportarDocumentoCautela)
                        Try
                            mtdExportarDocumentoCautela()
                            mtdAbortarThreadExportarDocumentoCautela(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerExportarDocumentoCautela)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaExportarDocumentoCautela As Boolean = False
        Friend blnSucessoExportarDocumentoCautela As Boolean = False

        Private lngCodigoExportarDocumentoCautela As Long = 0

        Protected Friend Sub mtdExportarDocumentoCautela()
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoExportarDocumentoCautela
                blnSucessoExportarDocumentoCautela = True

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
                                _NomeArquivo = "Cautela_" & elemento(contador).ToString()
                                sfd.FileName = _NomeArquivo & "." & _Extensao
                                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCautela
                                frmVisualizarImpressao.Tabela = frmCautelas.strNomeTabelaCautela
                                frmVisualizarImpressao.SQL = "SELECT * FROM tblCautela WHERE tblCautela.Codigo LIKE '" & elemento(contador).ToString() & "';"
                                objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
                                mtdAtualizarDataImpressao(elemento(contador).ToString())
                            End If
                        End If

                        intProgresso = mtdProgresso(contador, elemento.Count - 1)
                        strNomeProcesso = strNomeProcessoExportarDocumentoCautela
                        blnSucessoExportarDocumentoCautela = True
                        System.Threading.Thread.Sleep(1)
                    Next
                Else
                    If (blnVetChecadoLSVCautela.Contains(True)) Then
                        If (strVetColunasLSVCautela.Length > 0) Then
                            If (strVetItemsLSVCautela.Length > 0) Then
                                'blnChecadoInventarioBens = False
                                'lstListaRelatoriosExportadosInventarioBens.Clear()
                                intItemVetChecadoLSVCautela = 0
                                For contador As Integer = 0 To strVetItemsLSVCautela.Length - 1 Step 1
                                    If blnVetChecadoLSVCautela(contador) Then
                                        intItemVetChecadoLSVCautela += 1
                                        _NomeArquivo = "Cautela_" & strVetItemsLSVCautela(contador)(0)
                                        sfd.FileName = _NomeArquivo & "." & _Extensao
                                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCautela
                                        frmVisualizarImpressao.Tabela = frmCautelas.strNomeTabelaCautela
                                        frmVisualizarImpressao.SQL = String.Format("SELECT * FROM tblCautela WHERE {0} LIKE '{1}';", strVetColunasLSVCautela(0), strVetItemsLSVCautela(contador)(0))
                                        objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
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
                        _NomeArquivo = "Cautela_" & frmCautelas.Codigo
                        sfd.FileName = _NomeArquivo & "." & _Extensao
                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCautela
                        frmVisualizarImpressao.Tabela = frmCautelas.strNomeTabelaCautela
                        frmVisualizarImpressao.SQL = "SELECT * FROM tblCautela WHERE tblCautela.Codigo LIKE '" & frmCautelas.Codigo & "';"
                        objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
                    End If
                End If
            Catch
                _NomeArquivo = "Cautela_" & frmCautelas.Codigo
                sfd.FileName = _NomeArquivo & "." & _Extensao
                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCautela
                frmVisualizarImpressao.Tabela = frmCautelas.strNomeTabelaCautela
                frmVisualizarImpressao.SQL = "SELECT * FROM tblCautela WHERE tblCautela.Codigo LIKE '" & frmCautelas.Codigo & "';"
                objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
            Finally
                mtdAtualizarDataImpressao(frmCautelas.Codigo.ToString())

                intProgresso = 100
                strNomeProcesso = strNomeProcessoExportarDocumentoCautela
                blnSucessoExportarDocumentoCautela = True
            End Try
        End Sub
    End Class
End Namespace