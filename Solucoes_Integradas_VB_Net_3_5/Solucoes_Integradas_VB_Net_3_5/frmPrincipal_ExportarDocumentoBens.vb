Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThExportarDocumentoBens As System.Threading.Thread

        Private strNomeProcessoExportarDocumentoBens As String = "Exportar Documento Bens"

        Friend Sub mtdIniciarThreadExportarDocumentoBens(ByVal Codigo As Long)
            lngCodigoExportarDocumentoBens = Codigo

            mtdIniciarThreadExportarDocumentoBens(True)
        End Sub

        Friend Sub mtdIniciarThreadExportarDocumentoBens()
            mtdIniciarThreadExportarDocumentoBens(True)
        End Sub

        Friend Sub mtdIniciarThreadExportarDocumentoBens(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoExportarDocumentoBens
                blnAbortarThreadExportarDocumentoBens = Not Iniciar
                blnForcarAbortarThreadExportarDocumentoBens = False
                blnThreadAtivadaExportarDocumentoBens = True
                blnSucessoExportarDocumentoBens = False
                ThExportarDocumentoBens = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadExportarDocumentoBens))
                ThExportarDocumentoBens.IsBackground = True
                ThExportarDocumentoBens.Priority = System.Threading.ThreadPriority.Normal
                ThExportarDocumentoBens.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadExportarDocumentoBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadExportarDocumentoBens()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoBens
            blnAbortarThreadExportarDocumentoBens = False
            blnForcarAbortarThreadExportarDocumentoBens = False

            blnThreadAtivadaExportarDocumentoBens = True
            blnSucessoExportarDocumentoBens = False
        End Sub

        Private Shared blnForcarAbortarThreadExportarDocumentoBens As Boolean = False
        Private Shared blnAbortarThreadExportarDocumentoBens As Boolean = False
        Private Shared intTempoSaidaAbortarThreadExportarDocumentoBens As Integer = 1000

        Friend Sub mtdAbortarThreadExportarDocumentoBens()
            mtdAbortarThreadExportarDocumentoBens(False)
        End Sub

        Friend Sub mtdAbortarThreadExportarDocumentoBens(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoBens
            blnAbortarThreadExportarDocumentoBens = True
            blnForcarAbortarThreadExportarDocumentoBens = Forcar

            blnThreadAtivadaExportarDocumentoBens = False
            blnSucessoExportarDocumentoBens = False

            Try
                ThExportarDocumentoBens.Join(intTempoSaidaAbortarThreadExportarDocumentoBens)
                ThExportarDocumentoBens.Abort()
                ThExportarDocumentoBens = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadExportarDocumentoBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadExportarDocumentoBens()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoBens
            blnAbortarThreadExportarDocumentoBens = True
            blnForcarAbortarThreadExportarDocumentoBens = True

            blnThreadAtivadaExportarDocumentoBens = False
            blnSucessoExportarDocumentoBens = False
        End Sub

        Private Shared LockerExportarDocumentoBens As New Object()

        Private Sub mtdRotinaThreadExportarDocumentoBens()
            While Not blnForcarAbortarThreadExportarDocumentoBens
                If Not blnAbortarThreadExportarDocumentoBens Then
                    'System.Threading.Monitor.Enter(LockerExportarDocumentoBens)
                    SyncLock (LockerExportarDocumentoBens)
                        Try
                            mtdExportarDocumentoBens()
                            mtdAbortarThreadExportarDocumentoBens(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerExportarDocumentoBens)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaExportarDocumentoBens As Boolean = False
        Friend blnSucessoExportarDocumentoBens As Boolean = False

        Private blnChecadoBens As Boolean = False
        Private lstListaRelatoriosExportadosBens As List(Of String) = New List(Of String)

        Private lngCodigoExportarDocumentoBens As Long = 0

        Protected Friend Sub mtdExportarDocumentoBens()
            'Try
            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarDocumentoBens
            blnSucessoExportarDocumentoBens = True

            If (strVetColunasLSV1.Length > 0) Then
                If (strVetItemsLSV1.Length > 0) Then
                    blnChecadoBens = False
                    lstListaRelatoriosExportadosBens.Clear()
                    intItemVetChecadoLSV1 = 0
                    For contador As Integer = 0 To strVetItemsLSV1.Length - 1 Step 1
                        If blnVetChecadoLSV1(contador) Then
                            objVisualizarImpressao = New frmVisualizarImpressao()
                            blnChecadoBens = True
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioBens
                            frmVisualizarImpressao.Tabela = "tblBensEletronorte"
                            frmVisualizarImpressao.SQL = String.Format _
                                                      ( _
                                                      "SELECT {0} FROM {1} WHERE {2} ORDER BY {3};", _
                                                      "*", _
                                                      "tblBensEletronorte", _
                                                      String.Format _
                                                      ( _
                                                      "{0} LIKE '{1}'", _
                                                      strVetColunasLSV1(0), _
                                                      strVetItemsLSV1(contador)(0) _
                                                      ), _
                                                      String.Format _
                                                      ( _
                                                      "{0} {1}", _
                                                      objBens.strColunaSelecionada, _
                                                      IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC") _
                                                      ) _
                                                      )
                            _NomeArquivo = String.Format _
                            ( _
                            "{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", _
                            "Bens", _
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

                            lstListaRelatoriosExportadosBens.Add(sfd.FileName)

                            objVisualizarImpressao.mtdExportarRelatorio(_Formato, sfd.FileName)
                            intItemVetChecadoLSV1 += 1
                        End If

                        intProgresso = mtdProgresso(intItemVetChecadoLSV1, intContadorVetChecadoLSV1 - 1)
                        strNomeProcesso = strNomeProcessoExportarDocumentoBens
                        blnSucessoExportarDocumentoBens = True
                        System.Threading.Thread.Sleep(1)
                    Next

                    If Not blnChecadoBens Then
                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioBens
                        frmVisualizarImpressao.Tabela = "tblBensEletronorte"
                        frmVisualizarImpressao.SQL = "SELECT * FROM tblBensEletronorte WHERE tblBensEletronorte.Imobilizado LIKE " & _
                            frmBens.Numero_Item & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                        _NomeArquivo = String.Format _
                        ( _
                        "{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", _
                        "Bens", _
                        frmBens.dtgv1.Columns(0).HeaderText, _
                        frmBens.Numero_Item, _
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
            '    frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioBens
            '    frmVisualizarImpressao.Tabela = "tblBensEletronorte"
            '    frmVisualizarImpressao.SQL = "SELECT * FROM tblBensEletronorte WHERE tblBensEletronorte.Imobilizado LIKE " & _
            '        frmBens.Numero_Item & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
            '    _NomeArquivo = String.Format _
            '        ( _
            '        "{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", _
            '        "Inventario", _
            '        frmBens.vetCamposTabelaBens(0), _
            '        frmBens.Numero_Item, _
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
            strNomeProcesso = strNomeProcessoExportarDocumentoBens
            blnSucessoExportarDocumentoBens = True
            'End Try
        End Sub
    End Class
End Namespace