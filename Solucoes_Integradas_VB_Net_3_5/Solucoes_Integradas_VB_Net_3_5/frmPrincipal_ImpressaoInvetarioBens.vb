Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThImprimirInventarioBens As System.Threading.Thread

        Private strNomeProcessoImprimirInventarioBens As String = "Imprimir Inventario Bens"

        Friend Sub mtdIniciarThreadImprimirInventarioBens(ByVal Codigo As Long)
            lngCodigoImprimirInventarioBens = Codigo

            mtdIniciarThreadImprimirInventarioBens(True)
        End Sub

        Friend Sub mtdIniciarThreadImprimirInventarioBens()
            mtdIniciarThreadImprimirInventarioBens(True)
        End Sub

        Friend Sub mtdIniciarThreadImprimirInventarioBens(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoImprimirInventarioBens
                blnAbortarThreadImprimirInventarioBens = Not Iniciar
                blnForcarAbortarThreadImprimirInventarioBens = False
                blnThreadAtivadaImprimirInventarioBens = True
                blnSucessoImprimirInventarioBens = False
                ThImprimirInventarioBens = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImprimirInventarioBens))
                ThImprimirInventarioBens.IsBackground = True
                ThImprimirInventarioBens.Priority = System.Threading.ThreadPriority.Normal
                ThImprimirInventarioBens.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImprimirInventarioBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImprimirInventarioBens()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirInventarioBens
            blnAbortarThreadImprimirInventarioBens = False
            blnForcarAbortarThreadImprimirInventarioBens = False

            blnThreadAtivadaImprimirInventarioBens = True
            blnSucessoImprimirInventarioBens = False
        End Sub

        Private Shared blnForcarAbortarThreadImprimirInventarioBens As Boolean = False
        Private Shared blnAbortarThreadImprimirInventarioBens As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImprimirInventarioBens As Integer = 1000

        Friend Sub mtdAbortarThreadImprimirInventarioBens()
            mtdAbortarThreadImprimirInventarioBens(False)
        End Sub

        Friend Sub mtdAbortarThreadImprimirInventarioBens(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirInventarioBens
            blnAbortarThreadImprimirInventarioBens = True
            blnForcarAbortarThreadImprimirInventarioBens = Forcar

            blnThreadAtivadaImprimirInventarioBens = False
            blnSucessoImprimirInventarioBens = False

            Try
                ThImprimirInventarioBens.Join(intTempoSaidaAbortarThreadImprimirInventarioBens)
                ThImprimirInventarioBens.Abort()
                ThImprimirInventarioBens = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImprimirInventarioBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImprimirInventarioBens()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoImprimirInventarioBens
            blnAbortarThreadImprimirInventarioBens = True
            blnForcarAbortarThreadImprimirInventarioBens = True

            blnThreadAtivadaImprimirInventarioBens = False
            blnSucessoImprimirInventarioBens = False
        End Sub

        Private Shared LockerImprimirInventarioBens As New Object()

        Private Sub mtdRotinaThreadImprimirInventarioBens()
            While Not blnForcarAbortarThreadImprimirInventarioBens
                If Not blnAbortarThreadImprimirInventarioBens Then
                    'System.Threading.Monitor.Enter(LockerImprimirInventarioBens)
                    SyncLock (LockerImprimirInventarioBens)
                        Try
                            mtdImprimirInventarioBens()
                            mtdAbortarThreadImprimirInventarioBens(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImprimirInventarioBens)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImprimirInventarioBens As Boolean = False
        Friend blnSucessoImprimirInventarioBens As Boolean = False

        'Private strNomeArquivoImprimirInventarioBens As String = String.Empty
        'Private strCampo As String = String.Empty
        'Private strDado As String = String.Empty

        Private lngCodigoImprimirInventarioBens As Long = 0

        'Protected Friend Sub mtdImprimirInventarioBens()
        '    mtdImprimirInventarioBens(nCopy, sPage, ePage, PrinterName)
        'End Sub

        Protected Friend Sub mtdImprimirInventarioBens()
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoImprimirInventarioBens
                blnSucessoImprimirInventarioBens = True

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
                                        objVisualizarImpressao.mtdImprimir()

                                        intProgresso = mtdProgresso(intItemVetChecadoLSV1, intContadorVetChecadoLSV1)
                                        strNomeProcesso = strNomeProcessoImprimirInventarioBens
                                        blnSucessoImprimirInventarioBens = True
                                    End If
                                    System.Threading.Thread.Sleep(1)
                                Next
                                'Else
                                '    frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                                '    frmVisualizarImpressao.Tabela = "tblInventarioBens"
                                '    frmVisualizarImpressao.SQL = "SELECT * FROM tblInventarioBens WHERE tblInventarioBens.Numero_Inventario LIKE " & _
                                '        frmInventarioBens.Numero_Inventario & " ORDER BY " & String.Format("{0} {1}", objInventarioBens.strColunaSelecionada, IIf(objInventarioBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                                '    objVisualizarImpressao.mtdImprimir()
                            End If
                        Else
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                            frmVisualizarImpressao.Tabela = "tblInventarioBens"
                            frmVisualizarImpressao.SQL = "SELECT * FROM tblInventarioBens WHERE tblInventarioBens.Numero_Inventario LIKE " & _
                                frmInventarioBens.Numero_Inventario & " ORDER BY " & String.Format("{0} {1}", objInventarioBens.strColunaSelecionada, IIf(objInventarioBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                            objVisualizarImpressao.mtdImprimir()
                        End If
                    Else
                        frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                        frmVisualizarImpressao.Tabela = "tblInventarioBens"
                        frmVisualizarImpressao.SQL = "SELECT * FROM tblInventarioBens WHERE tblInventarioBens.Numero_Inventario LIKE " & _
                            frmInventarioBens.Numero_Inventario & " ORDER BY " & String.Format("{0} {1}", objInventarioBens.strColunaSelecionada, IIf(objInventarioBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                        objVisualizarImpressao.mtdImprimir()
                    End If
                Else
                    frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                    frmVisualizarImpressao.Tabela = "tblInventarioBens"
                    frmVisualizarImpressao.SQL = "SELECT * FROM tblInventarioBens WHERE tblInventarioBens.Numero_Inventario LIKE " & _
                        frmInventarioBens.Numero_Inventario & " ORDER BY " & String.Format("{0} {1}", objInventarioBens.strColunaSelecionada, IIf(objInventarioBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                    objVisualizarImpressao.mtdImprimir()
                End If
            Catch
                frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                frmVisualizarImpressao.Tabela = "tblInventarioBens"
                frmVisualizarImpressao.SQL = "SELECT * FROM tblInventarioBens WHERE tblInventarioBens.Numero_Inventario LIKE " & _
                    frmInventarioBens.Numero_Inventario & " ORDER BY " & String.Format("{0} {1}", objInventarioBens.strColunaSelecionada, IIf(objInventarioBens.blnIndicadorCrescente, String.Empty, "DESC")) & ";"
                objVisualizarImpressao.mtdImprimir()
            Finally
                intProgresso = 100
                strNomeProcesso = strNomeProcessoImprimirInventarioBens
                blnSucessoImprimirInventarioBens = True
            End Try
        End Sub
    End Class
End Namespace