Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThExportarDocumentoInventarioBens As System.Threading.Thread

        Private strNomeProcessoExportarDocumentoInventarioBens As String = "Exportar Documento Inventario Bens"

        Friend Sub mtdIniciarThreadExportarDocumentoInventarioBens(ByVal Codigo As Long)
            lngCodigoExportarDocumentoInventarioBens = Codigo

            mtdIniciarThreadExportarDocumentoInventarioBens(True)
        End Sub

        Friend Sub mtdIniciarThreadExportarDocumentoInventarioBens()
            mtdIniciarThreadExportarDocumentoInventarioBens(True)
        End Sub

        Friend Sub mtdIniciarThreadExportarDocumentoInventarioBens(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoExportarDocumentoInventarioBens
                blnAbortarThreadExportarDocumentoInventarioBens = Not Iniciar
                blnForcarAbortarThreadExportarDocumentoInventarioBens = False
                blnThreadAtivadaExportarDocumentoInventarioBens = True
                blnSucessoExportarDocumentoInventarioBens = False
                ThExportarDocumentoInventarioBens = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadExportarDocumentoInventarioBens))
                ThExportarDocumentoInventarioBens.IsBackground = True
                ThExportarDocumentoInventarioBens.Priority = System.Threading.ThreadPriority.Normal
                ThExportarDocumentoInventarioBens.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadExportarDocumentoInventarioBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadExportarDocumentoInventarioBens()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoInventarioBens
            blnAbortarThreadExportarDocumentoInventarioBens = False
            blnForcarAbortarThreadExportarDocumentoInventarioBens = False

            blnThreadAtivadaExportarDocumentoInventarioBens = True
            blnSucessoExportarDocumentoInventarioBens = False
        End Sub

        Private Shared blnForcarAbortarThreadExportarDocumentoInventarioBens As Boolean = False
        Private Shared blnAbortarThreadExportarDocumentoInventarioBens As Boolean = False
        Private Shared intTempoSaidaAbortarThreadExportarDocumentoInventarioBens As Integer = 1000

        Friend Sub mtdAbortarThreadExportarDocumentoInventarioBens()
            mtdAbortarThreadExportarDocumentoInventarioBens(False)
        End Sub

        Friend Sub mtdAbortarThreadExportarDocumentoInventarioBens(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoInventarioBens
            blnAbortarThreadExportarDocumentoInventarioBens = True
            blnForcarAbortarThreadExportarDocumentoInventarioBens = Forcar

            blnThreadAtivadaExportarDocumentoInventarioBens = False
            blnSucessoExportarDocumentoInventarioBens = False

            Try
                ThExportarDocumentoInventarioBens.Join(intTempoSaidaAbortarThreadExportarDocumentoInventarioBens)
                ThExportarDocumentoInventarioBens.Abort()
                ThExportarDocumentoInventarioBens = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadExportarDocumentoInventarioBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadExportarDocumentoInventarioBens()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoInventarioBens
            blnAbortarThreadExportarDocumentoInventarioBens = True
            blnForcarAbortarThreadExportarDocumentoInventarioBens = True

            blnThreadAtivadaExportarDocumentoInventarioBens = False
            blnSucessoExportarDocumentoInventarioBens = False
        End Sub

        Private Shared LockerExportarDocumentoInventarioBens As New Object()

        Private Sub mtdRotinaThreadExportarDocumentoInventarioBens()
            While Not blnForcarAbortarThreadExportarDocumentoInventarioBens
                If Not blnAbortarThreadExportarDocumentoInventarioBens Then
                    'System.Threading.Monitor.Enter(LockerExportarDocumentoInventarioBens)
                    SyncLock (LockerExportarDocumentoInventarioBens)
                        Try
                            mtdExportarDocumentoInventarioBens()
                            mtdAbortarThreadExportarDocumentoInventarioBens(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerExportarDocumentoInventarioBens)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaExportarDocumentoInventarioBens As Boolean = False
        Friend blnSucessoExportarDocumentoInventarioBens As Boolean = False

        Private blnChecadoInventarioBens As Boolean = False
        Private lstListaRelatoriosExportadosInventarioBens As List(Of String) = New List(Of String)

        Private lngCodigoExportarDocumentoInventarioBens As Long = 0

        Protected Friend Sub mtdExportarDocumentoInventarioBens()
            'Try
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoInventarioBens
            blnSucessoExportarDocumentoInventarioBens = True

            If (strVetColunasLSV1.Length > 0) Then
                If (strVetItemsLSV1.Length > 0) Then
                    intItemVetChecadoLSV1 = 0
                    blnChecadoInventarioBens = False
                    lstListaRelatoriosExportadosInventarioBens.Clear()
                    For contador As Integer = 0 To strVetItemsLSV1.Length - 1 Step 1
                        If blnVetChecadoLSV1(contador) Then
                            intItemVetChecadoLSV1 += 1
                            objVisualizarImpressao = New frmVisualizarImpressao()
                            blnChecadoInventarioBens = True
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                            frmVisualizarImpressao.Tabela = "tblInventarioBens"
                            frmVisualizarImpressao.SQL = String.Format _
                                                      ( _
                                                      "SELECT {0} FROM {1} WHERE {2} ORDER BY {3};", _
                                                      "*", _
                                                      "tblInventarioBens", _
                                                      String.Format _
                                                      ( _
                                                      "{0} LIKE '{1}'", _
                                                      strVetColunasLSV1(0), _
                                                      strVetItemsLSV1(contador)(0) _
                                                      ), _
                                                      String.Format _
                                                      ( _
                                                      "{0} {1}", _
                                                      objInventarioBens.strColunaSelecionada, _
                                                      IIf(objInventarioBens.blnIndicadorCrescente, String.Empty, "DESC") _
                                                      ) _
                                                      )
                            _NomeArquivo = String.Format _
                            ( _
                            "{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", _
                            "Inventario", _
                            strVetColunasLSV1(0), _
                            strVetItemsLSV1(contador)(0), _
                            DateTime.Now.Year, _
                            DateTime.Now.Month, _
                            DateTime.Now.Day, _
                            DateTime.Now.Hour, _
                            DateTime.Now.Minute, _
                            DateTime.Now.Second _
                            )
                            sfd.FileName = _NomeArquivo & "." & _Extensao

                            lstListaRelatoriosExportadosInventarioBens.Add(sfd.FileName)

                            objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)

                            intProgresso = mtdProgresso(intItemVetChecadoLSV1, intContadorVetChecadoLSV1 - 1)
                            strNomeProcesso = strNomeProcessoExportarDocumentoInventarioBens
                            blnSucessoExportarDocumentoInventarioBens = True
                        End If
                        System.Threading.Thread.Sleep(1)
                    Next

                    If Not blnChecadoInventarioBens Then
                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                        frmVisualizarImpressao.Tabela = "tblInventarioBens"
                        frmVisualizarImpressao.SQL = "SELECT * FROM tblInventarioBens WHERE tblInventarioBens.Numero_Inventario LIKE " & _
                            frmInventarioBens.Numero_Inventario & " ORDER BY " & String.Format("{0} {1}", objInventarioBens.strColunaSelecionada, IIf(objInventarioBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                        _NomeArquivo = String.Format _
                        ( _
                        "{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", _
                        "Inventario", _
                        frmInventarioBens.dtgv1.Columns(0).HeaderText, _
                        frmInventarioBens.Numero_Inventario, _
                        DateTime.Now.Year, _
                        DateTime.Now.Month, _
                        DateTime.Now.Day, _
                        DateTime.Now.Hour, _
                        DateTime.Now.Minute, _
                        DateTime.Now.Second _
                        )
                        sfd.FileName = _NomeArquivo & "." & _Extensao

                        objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
                    End If
                End If
            Else
                MessageBox.Show("Selecione um formulário para a impressão ou crie algum registro.", "Aviso!", MessageBoxButtons.OK)
            End If
            'Catch
            '    frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
            '    frmVisualizarImpressao.Tabela = "tblInventarioBens"
            '    frmVisualizarImpressao.SQL = "SELECT * FROM tblInventarioBens WHERE tblInventarioBens.Numero_Inventario LIKE " & _
            '        frmInventarioBens.Numero_Inventario & " ORDER BY " & String.Format("{0} {1}", objInventarioBens.strColunaSelecionada, IIf(objInventarioBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
            '    _NomeArquivo = String.Format _
            '        ( _
            '        "{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", _
            '        "Inventario", _
            '        frmInventarioBens.vetCamposTabelaInventarioBens(0), _
            '        frmInventarioBens.Numero_Inventario, _
            '        DateTime.Now.Year, _
            '        DateTime.Now.Month, _
            '        DateTime.Now.Day, _
            '        DateTime.Now.Hour, _
            '        DateTime.Now.Minute, _
            '        DateTime.Now.Second _
            '        )
            '    sfd.FileName = _NomeArquivo & "." & _Extensao

            '    objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
            'Finally
            intProgresso = 100
            strNomeProcesso = strNomeProcessoExportarDocumentoInventarioBens
            blnSucessoExportarDocumentoInventarioBens = True
            'End Try
        End Sub
    End Class
End Namespace