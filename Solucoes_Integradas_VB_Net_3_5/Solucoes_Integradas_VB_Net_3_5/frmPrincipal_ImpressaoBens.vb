Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThImprimirBens As System.Threading.Thread

        Private strNomeProcessoImprimirBens As String = "Imprimir Bens"

        Friend Sub mtdIniciarThreadImprimirBens(ByVal Codigo As Long)
            lngCodigoImprimirBens = Codigo

            mtdIniciarThreadImprimirBens(True)
        End Sub

        Friend Sub mtdIniciarThreadImprimirBens()
            mtdIniciarThreadImprimirBens(True)
        End Sub

        Friend Sub mtdIniciarThreadImprimirBens(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoImprimirBens
                blnAbortarThreadImprimirBens = Not Iniciar
                blnForcarAbortarThreadImprimirBens = False
                blnThreadAtivadaImprimirBens = True
                blnSucessoImprimirBens = False
                ThImprimirBens = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImprimirBens))
                ThImprimirBens.IsBackground = True
                ThImprimirBens.Priority = System.Threading.ThreadPriority.Normal
                ThImprimirBens.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImprimirBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImprimirBens()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirBens
            blnAbortarThreadImprimirBens = False
            blnForcarAbortarThreadImprimirBens = False

            blnThreadAtivadaImprimirBens = True
            blnSucessoImprimirBens = False
        End Sub

        Private Shared blnForcarAbortarThreadImprimirBens As Boolean = False
        Private Shared blnAbortarThreadImprimirBens As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImprimirBens As Integer = 1000

        Friend Sub mtdAbortarThreadImprimirBens()
            mtdAbortarThreadImprimirBens(False)
        End Sub

        Friend Sub mtdAbortarThreadImprimirBens(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirBens
            blnAbortarThreadImprimirBens = True
            blnForcarAbortarThreadImprimirBens = Forcar

            blnThreadAtivadaImprimirBens = False
            blnSucessoImprimirBens = False

            Try
                ThImprimirBens.Join(intTempoSaidaAbortarThreadImprimirBens)
                ThImprimirBens.Abort()
                ThImprimirBens = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImprimirBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImprimirBens()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirBens
            blnAbortarThreadImprimirBens = True
            blnForcarAbortarThreadImprimirBens = True

            blnThreadAtivadaImprimirBens = False
            blnSucessoImprimirBens = False
        End Sub

        Private Shared LockerImprimirBens As New Object()

        Private Sub mtdRotinaThreadImprimirBens()
            While Not blnForcarAbortarThreadImprimirBens
                If Not blnAbortarThreadImprimirBens Then
                    'System.Threading.Monitor.Enter(LockerImprimirBens)
                    SyncLock (LockerImprimirBens)
                        Try
                            mtdImprimirBens()
                            mtdAbortarThreadImprimirBens(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImprimirBens)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImprimirBens As Boolean = False
        Friend blnSucessoImprimirBens As Boolean = False

        'Private strNomeArquivoImprimirBens As String = String.Empty
        'Private strCampo As String = String.Empty
        'Private strDado As String = String.Empty

        Private lngCodigoImprimirBens As Long = 0

        'Protected Friend Sub mtdImprimirBens()
        '    mtdImprimirBens(nCopy, sPage, ePage, PrinterName)
        'End Sub

        Protected Friend Sub mtdImprimirBens()
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoImprimirBens
                blnSucessoImprimirBens = True

                If blnVetChecadoLSV1.Contains(True) Then
                    If (strVetColunasLSV1.Length > 0) Then
                        If (strVetItemsLSV1.Length > 0) Then
                            If _
                            ( _
                            MessageBox.Show _
                            ( _
                            "Deseja realmente imprimir os itens indicado(s), verifique se não é um número excessivo de páginas.", _
                            "Aviso!", _
                            MessageBoxButtons.YesNo _
                            ) _
                            = _
                            Windows.Forms.DialogResult.Yes _
                            ) _
                            Then
                                Dim blnChecado As Boolean = False
                                For contador As Integer = 0 To strVetItemsLSV1.Length - 1 Step 1
                                    If blnVetChecadoLSV1(contador) Then
                                        intItemVetChecadoLSV1 += 1
                                        intContador = contador
                                        objVisualizarImpressao = New frmVisualizarImpressao()
                                        blnChecado = True
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
                                        objVisualizarImpressao.mtdImprimir()

                                        intProgresso = mtdProgresso(intItemVetChecadoLSV1, intContadorVetChecadoLSV1)
                                        strNomeProcesso = strNomeProcessoImprimirBens
                                        blnSucessoImprimirBens = True
                                    End If
                                    System.Threading.Thread.Sleep(1)
                                Next
                                'Else
                                '    frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioBens
                                '    frmVisualizarImpressao.Tabela = "tblBensEletronorte"
                                '    frmVisualizarImpressao.SQL = "SELECT * FROM tblBensEletronorte WHERE tblBensEletronorte.Imobilizado LIKE " & _
                                '        frmBens.Numero_Item & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                                '    objVisualizarImpressao.mtdImprimir()
                            End If
                        Else
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioBens
                            frmVisualizarImpressao.Tabela = "tblBensEletronorte"
                            frmVisualizarImpressao.SQL = "SELECT * FROM tblBensEletronorte WHERE tblBensEletronorte.Imobilizado LIKE " & _
                                frmBens.Numero_Item & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                            objVisualizarImpressao.mtdImprimir()
                        End If
                    Else
                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioBens
                        frmVisualizarImpressao.Tabela = "tblBensEletronorte"
                        frmVisualizarImpressao.SQL = "SELECT * FROM tblBensEletronorte WHERE tblBensEletronorte.Imobilizado LIKE " & _
                            frmBens.Numero_Item & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                        objVisualizarImpressao.mtdImprimir()
                    End If
                Else
                    frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioBens
                    frmVisualizarImpressao.Tabela = "tblBensEletronorte"
                    frmVisualizarImpressao.SQL = "SELECT * FROM tblBensEletronorte WHERE tblBensEletronorte.Imobilizado LIKE " & _
                        frmBens.Numero_Item & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                    objVisualizarImpressao.mtdImprimir()
                End If
            Catch
                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioBens
                frmVisualizarImpressao.Tabela = "tblBensEletronorte"
                frmVisualizarImpressao.SQL = "SELECT * FROM tblBensEletronorte WHERE tblBensEletronorte.Imobilizado LIKE " & _
                    frmBens.Numero_Item & " ORDER BY " & String.Format("{0} {1}", objBens.strColunaSelecionada, IIf(objBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                objVisualizarImpressao.mtdImprimir()
            Finally
                intProgresso = 100
                strNomeProcesso = strNomeProcessoImprimirBens
                blnSucessoImprimirBens = True
            End Try
        End Sub
    End Class
End Namespace