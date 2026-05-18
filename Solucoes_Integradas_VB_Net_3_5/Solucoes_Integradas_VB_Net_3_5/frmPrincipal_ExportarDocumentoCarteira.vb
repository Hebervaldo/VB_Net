Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThExportarDocumentoCarteira As System.Threading.Thread

        Private strNomeProcessoExportarDocumentoCarteira As String = "Exportar Documento Carteira"

        Friend Sub mtdIniciarThreadExportarDocumentoCarteira(ByVal Codigo As Long)
            lngCodigoExportarDocumentoCarteira = Codigo

            mtdIniciarThreadExportarDocumentoCarteira(True)
        End Sub

        Friend Sub mtdIniciarThreadExportarDocumentoCarteira()
            mtdIniciarThreadExportarDocumentoCarteira(True)
        End Sub

        Friend Sub mtdIniciarThreadExportarDocumentoCarteira(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoExportarDocumentoCarteira
                blnAbortarThreadExportarDocumentoCarteira = Not Iniciar
                blnForcarAbortarThreadExportarDocumentoCarteira = False
                blnThreadAtivadaExportarDocumentoCarteira = True
                blnSucessoExportarDocumentoCarteira = False
                ThExportarDocumentoCarteira = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadExportarDocumentoCarteira))
                ThExportarDocumentoCarteira.IsBackground = True
                ThExportarDocumentoCarteira.Priority = System.Threading.ThreadPriority.Normal
                ThExportarDocumentoCarteira.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadExportarDocumentoCarteira: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadExportarDocumentoCarteira()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoCarteira
            blnAbortarThreadExportarDocumentoCarteira = False
            blnForcarAbortarThreadExportarDocumentoCarteira = False

            blnThreadAtivadaExportarDocumentoCarteira = True
            blnSucessoExportarDocumentoCarteira = False
        End Sub

        Private Shared blnForcarAbortarThreadExportarDocumentoCarteira As Boolean = False
        Private Shared blnAbortarThreadExportarDocumentoCarteira As Boolean = False
        Private Shared intTempoSaidaAbortarThreadExportarDocumentoCarteira As Integer = 1000

        Friend Sub mtdAbortarThreadExportarDocumentoCarteira()
            mtdAbortarThreadExportarDocumentoCarteira(False)
        End Sub

        Friend Sub mtdAbortarThreadExportarDocumentoCarteira(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoCarteira
            blnAbortarThreadExportarDocumentoCarteira = True
            blnForcarAbortarThreadExportarDocumentoCarteira = Forcar

            blnThreadAtivadaExportarDocumentoCarteira = False
            blnSucessoExportarDocumentoCarteira = False

            Try
                ThExportarDocumentoCarteira.Join(intTempoSaidaAbortarThreadExportarDocumentoCarteira)
                ThExportarDocumentoCarteira.Abort()
                ThExportarDocumentoCarteira = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadExportarDocumentoCarteira: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadExportarDocumentoCarteira()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoCarteira
            blnAbortarThreadExportarDocumentoCarteira = True
            blnForcarAbortarThreadExportarDocumentoCarteira = True

            blnThreadAtivadaExportarDocumentoCarteira = False
            blnSucessoExportarDocumentoCarteira = False
        End Sub

        Private Shared LockerExportarDocumentoCarteira As New Object()

        Private Sub mtdRotinaThreadExportarDocumentoCarteira()
            While Not blnForcarAbortarThreadExportarDocumentoCarteira
                If Not blnAbortarThreadExportarDocumentoCarteira Then
                    'System.Threading.Monitor.Enter(LockerExportarDocumentoCarteira)
                    SyncLock (LockerExportarDocumentoCarteira)
                        Try
                            mtdExportarDocumentoCarteira()
                            mtdAbortarThreadExportarDocumentoCarteira(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerExportarDocumentoCarteira)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaExportarDocumentoCarteira As Boolean = False
        Friend blnSucessoExportarDocumentoCarteira As Boolean = False

        Private lngCodigoExportarDocumentoCarteira As Long = 0

        Protected Friend Sub mtdExportarDocumentoCarteira()
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoExportarDocumentoCarteira
                blnSucessoExportarDocumentoCarteira = True

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
                                _NomeArquivo = "Carteira_" & elemento(contador).ToString()
                                sfd.FileName = _NomeArquivo & "." & _Extensao
                                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCarteira
                                frmVisualizarImpressao.Tabela = frmCarteiras.strNomeTabelaCarteira
                                frmVisualizarImpressao.SQL = "SELECT * FROM tblCarteira WHERE tblCarteira.Codigo LIKE '" & elemento(contador).ToString() & "';"
                                objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
                                mtdAtualizarDataImpressao(elemento(contador).ToString())
                            End If
                        End If

                        intProgresso = mtdProgresso(contador, elemento.Count - 1)
                        strNomeProcesso = strNomeProcessoExportarDocumentoCarteira
                        blnSucessoExportarDocumentoCarteira = True
                        System.Threading.Thread.Sleep(1)
                    Next
                Else
                    If (blnVetChecadoLSVCarteira.Contains(True)) Then
                        If (strVetColunasLSVCarteira.Length > 0) Then
                            If (strVetItemsLSVCarteira.Length > 0) Then
                                'blnChecadoInventarioBens = False
                                'lstListaRelatoriosExportadosInventarioBens.Clear()
                                intItemVetChecadoLSVCarteira = 0
                                For contador As Integer = 0 To strVetItemsLSVCarteira.Length - 1 Step 1
                                    If blnVetChecadoLSVCarteira(contador) Then
                                        intItemVetChecadoLSVCarteira += 1
                                        _NomeArquivo = "Carteira_" & strVetItemsLSVCarteira(contador)(0)
                                        sfd.FileName = _NomeArquivo & "." & _Extensao
                                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCarteira
                                        frmVisualizarImpressao.Tabela = frmCarteiras.strNomeTabelaCarteira
                                        frmVisualizarImpressao.SQL = String.Format("SELECT * FROM tblCarteira WHERE {0} LIKE '{1}';", strVetColunasLSVCarteira(0), strVetItemsLSVCarteira(contador)(0))
                                        objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
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
                        _NomeArquivo = "Carteira_" & frmCarteiras.Codigo
                        sfd.FileName = _NomeArquivo & "." & _Extensao
                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCarteira
                        frmVisualizarImpressao.Tabela = frmCarteiras.strNomeTabelaCarteira
                        frmVisualizarImpressao.SQL = "SELECT * FROM tblCarteira WHERE tblCarteira.Codigo LIKE '" & frmCarteiras.Codigo & "';"
                        objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
                    End If
                End If
            Catch
                _NomeArquivo = "Carteira_" & frmCarteiras.Codigo
                sfd.FileName = _NomeArquivo & "." & _Extensao
                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCarteira
                frmVisualizarImpressao.Tabela = frmCarteiras.strNomeTabelaCarteira
                frmVisualizarImpressao.SQL = "SELECT * FROM tblCarteira WHERE tblCarteira.Codigo LIKE '" & frmCarteiras.Codigo & "';"
                objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
            Finally
                mtdAtualizarDataImpressao(frmCarteiras.Codigo.ToString())

                intProgresso = 100
                strNomeProcesso = strNomeProcessoExportarDocumentoCarteira
                blnSucessoExportarDocumentoCarteira = True
            End Try
        End Sub
    End Class
End Namespace