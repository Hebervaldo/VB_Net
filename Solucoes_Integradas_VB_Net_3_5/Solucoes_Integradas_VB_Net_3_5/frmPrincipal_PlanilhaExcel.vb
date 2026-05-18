Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThExportarPlanilhaExcelRelatorio As System.Threading.Thread

        Private ThExportarPlanilhaExcelSap_R3 As System.Threading.Thread

        Private strExcelRelatorio As String = "Relatorio"

        Private strExcelSap_R3 As String = "Sap_R3"

        Private strNomeProcessoExportarPlanilhaExcelRelatorio As String = "Exportar Relatório (Excel)"

        Private strNomeProcessoExportarPlanilhaExcelSap_R3 As String = "Exportar Sap/R3 (Excel)"

        Private strLsvExportarPlanilhaExcelRelatorio As String() = Nothing

        Private strLsvExportarPlanilhaExcelSap_R3 As String() = Nothing

        Private Sub mtdIniciarThreadExportarPlanilhaExcelRelatorio(ByVal Lsv As String())
            strLsvExportarPlanilhaExcelRelatorio = Lsv

            mtdIniciarThreadExportarPlanilhaExcelRelatorio(True)
        End Sub

        Private Sub mtdIniciarThreadExportarPlanilhaExcelSap_R3(ByVal Lsv As String())
            strLsvExportarPlanilhaExcelSap_R3 = Lsv

            mtdIniciarThreadExportarPlanilhaExcelSap_R3(True)
        End Sub

        Private Sub mtdIniciarThreadExportarPlanilhaExcelRelatorio(ByVal Tabela As String, ByVal Campo As String, ByVal Dado As String, ByVal Relatorio As Boolean)
            If Relatorio Then
                mtdIniciarThreadExportarPlanilhaExcelRelatorio(Tabela, Campo, Dado)
            Else
                mtdIniciarThreadExportarPlanilhaExcelSap_R3(Tabela, Campo, Dado)
            End If
        End Sub

        Private Sub mtdIniciarThreadExportarPlanilhaExcelSap_R3(ByVal Tabela As String, ByVal Campo As String, ByVal Dado As String, ByVal Relatorio As Boolean)
            If Relatorio Then
                mtdIniciarThreadExportarPlanilhaExcelRelatorio(Tabela, Campo, Dado)
            Else
                mtdIniciarThreadExportarPlanilhaExcelSap_R3(Tabela, Campo, Dado)
            End If
        End Sub

        Private Sub mtdIniciarThreadExportarPlanilhaExcelRelatorio(ByVal Tabela As String, ByVal Campo As String, ByVal Dado As String)
            Dim Extensao As String = "xls"
            Dim Filtro As String = "Arquivo do Excel 2003 (*.xls)|*.xls|Arquivo do Excel 2007 (*.xlsx)|*.xlsx|Todos Arquivos (*.*)|*.*"
            Dim NomeArquivo As String = String.Format _
            ( _
            "{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", _
            strExcelRelatorio, _
            Campo, _
            Dado, _
            DateTime.Now.Year, _
            DateTime.Now.Month, _
            DateTime.Now.Day, _
            DateTime.Now.Hour, _
            DateTime.Now.Minute, _
            DateTime.Now.Second _
            )

            FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            FileIO.FileSystem.CreateDirectory(strPlanilhaExcelRelatorio)
            FileIO.FileSystem.CurrentDirectory = String.Format("{0}\{1}", FileIO.FileSystem.CurrentDirectory, strPlanilhaExcelRelatorio)
            sfd1.InitialDirectory = FileIO.FileSystem.CurrentDirectory & "\"
            sfd1.FileName = NomeArquivo & "." & Extensao
            sfd1.OverwritePrompt = True
            sfd1.Filter = Filtro
            sfd1.FilterIndex = 1

            If sfd1.ShowDialog() = DialogResult.OK Then
                strNomeArquivoExportarPlanilhaExcelRelatorio = sfd1.FileName
                strTabelaPrincipal = Tabela
                strCampo = Campo
                strDado = Dado
                mtdIniciarThreadExportarPlanilhaExcelRelatorio(True)
            End If
        End Sub

        Private Sub mtdIniciarThreadExportarPlanilhaExcelSap_R3(ByVal Tabela As String, ByVal Campo As String, ByVal Dado As String)
            Dim Extensao As String = "xls"
            Dim Filtro As String = "Arquivo do Excel 2003 (*.xls)|*.xls|Arquivo do Excel 2007 (*.xlsx)|*.xlsx|Todos Arquivos (*.*)|*.*"
            Dim NomeArquivo As String = String.Format _
            ( _
            "{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", _
            strExcelSap_R3, _
            Campo, _
            Dado, _
            DateTime.Now.Year, _
            DateTime.Now.Month, _
            DateTime.Now.Day, _
            DateTime.Now.Hour, _
            DateTime.Now.Minute, _
            DateTime.Now.Second _
            )

            FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            FileIO.FileSystem.CreateDirectory(strPlanilhaExcelSap_R3)
            FileIO.FileSystem.CurrentDirectory = String.Format("{0}\{1}", FileIO.FileSystem.CurrentDirectory, strPlanilhaExcelSap_R3)
            sfd1.InitialDirectory = FileIO.FileSystem.CurrentDirectory & "\"
            sfd1.FileName = NomeArquivo & "." & Extensao
            sfd1.OverwritePrompt = True
            sfd1.Filter = Filtro
            sfd1.FilterIndex = 1

            If sfd1.ShowDialog() = DialogResult.OK Then
                strNomeArquivoExportarPlanilhaExcelSap_R3 = sfd1.FileName
                strTabelaPrincipal = Tabela
                strCampo = Campo
                strDado = Dado
                mtdIniciarThreadExportarPlanilhaExcelSap_R3(True)
            End If
        End Sub

        Private Sub mtdIniciarThreadExportarPlanilhaExcelSap_R3()
            mtdIniciarThreadExportarPlanilhaExcelSap_R3(True)
        End Sub

        Private Sub mtdIniciarThreadExportarPlanilhaExcelRelatorio()
            mtdIniciarThreadExportarPlanilhaExcelRelatorio(True)
        End Sub

        Private Sub mtdIniciarThreadExportarPlanilhaExcelRelatorio(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                'strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
                blnAbortarThreadExportarPlanilhaExcelRelatorio = Not Iniciar
                blnForcarAbortarThreadExportarPlanilhaExcelRelatorio = False
                blnThreadAtivadaExportarPlanilhaExcelRelatorio = True
                blnSucessoExportarPlanilhaExcelRelatorio = False
                ThExportarPlanilhaExcelRelatorio = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadExportarPlanilhaExcelRelatorio))
                ThExportarPlanilhaExcelRelatorio.IsBackground = True
                ThExportarPlanilhaExcelRelatorio.Priority = System.Threading.ThreadPriority.Normal
                ThExportarPlanilhaExcelRelatorio.Start()
            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadExportarPlanilhaExcelRelatorio: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdIniciarThreadExportarPlanilhaExcelSap_R3(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                'strNomeProcesso = strNomeProcessoExportarPlanilhaExcel
                blnAbortarThreadExportarPlanilhaExcelSap_R3 = Not Iniciar
                blnForcarAbortarThreadExportarPlanilhaExcelSap_R3 = False
                blnThreadAtivadaExportarPlanilhaExcelSap_R3 = True
                blnSucessoExportarPlanilhaExcelSap_R3 = False
                ThExportarPlanilhaExcelSap_R3 = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadExportarPlanilhaExcelSap_R3))
                ThExportarPlanilhaExcelSap_R3.IsBackground = True
                ThExportarPlanilhaExcelSap_R3.Priority = System.Threading.ThreadPriority.Normal
                ThExportarPlanilhaExcelSap_R3.Start()
            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadExportarPlanilhaExcelSap_R3: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdReIniciarThreadExportarPlanilhaExcelRelatorio()
            intProgresso = 0
            'strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnAbortarThreadExportarPlanilhaExcelRelatorio = False
            blnForcarAbortarThreadExportarPlanilhaExcelRelatorio = False

            blnThreadAtivadaExportarPlanilhaExcelRelatorio = True
            blnSucessoExportarPlanilhaExcelRelatorio = False
        End Sub

        Private Sub mtdReIniciarThreadExportarPlanilhaExcelSap_R3()
            intProgresso = 0
            'strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnAbortarThreadExportarPlanilhaExcelSap_R3 = False
            blnForcarAbortarThreadExportarPlanilhaExcelSap_R3 = False

            blnThreadAtivadaExportarPlanilhaExcelSap_R3 = True
            blnSucessoExportarPlanilhaExcelSap_R3 = False
        End Sub

        Private Shared blnForcarAbortarThreadExportarPlanilhaExcelRelatorio As Boolean = False
        Private Shared blnAbortarThreadExportarPlanilhaExcelRelatorio As Boolean = False
        Private Shared intTempoSaidaAbortarThreadExportarPlanilhaExcelRelatorio As Integer = 1000

        Private Shared blnForcarAbortarThreadExportarPlanilhaExcelSap_R3 As Boolean = False
        Private Shared blnAbortarThreadExportarPlanilhaExcelSap_R3 As Boolean = False
        Private Shared intTempoSaidaAbortarThreadExportarPlanilhaExcelSap_R3 As Integer = 1000

        Private Sub mtdAbortarThreadExportarPlanilhaExcelRelatorio()
            mtdAbortarThreadExportarPlanilhaExcelRelatorio(False)
        End Sub

        Private Sub mtdAbortarThreadExportarPlanilhaExcelSap_R3()
            mtdAbortarThreadExportarPlanilhaExcelSap_R3(False)
        End Sub

        Private Sub mtdAbortarThreadExportarPlanilhaExcelRelatorio(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            'strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnAbortarThreadExportarPlanilhaExcelRelatorio = True
            blnForcarAbortarThreadExportarPlanilhaExcelRelatorio = Forcar

            blnThreadAtivadaExportarPlanilhaExcelRelatorio = False
            blnSucessoExportarPlanilhaExcelRelatorio = False

            Try
                ThExportarPlanilhaExcelRelatorio.Join(intTempoSaidaAbortarThreadExportarPlanilhaExcelRelatorio)
                ThExportarPlanilhaExcelRelatorio.Abort()
                ThExportarPlanilhaExcelRelatorio = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadExportarPlanilhaExcelRelatorio: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdAbortarThreadExportarPlanilhaExcelSap_R3(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            'strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnAbortarThreadExportarPlanilhaExcelSap_R3 = True
            blnForcarAbortarThreadExportarPlanilhaExcelSap_R3 = Forcar

            blnThreadAtivadaExportarPlanilhaExcelSap_R3 = False
            blnSucessoExportarPlanilhaExcelSap_R3 = False

            Try
                ThExportarPlanilhaExcelSap_R3.Join(intTempoSaidaAbortarThreadExportarPlanilhaExcelSap_R3)
                ThExportarPlanilhaExcelSap_R3.Abort()
                ThExportarPlanilhaExcelSap_R3 = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadExportarPlanilhaExcelSap_R3: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdPararThreadExportarPlanilhaExcelRelatorio()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            'strNomeProcesso = strNomeProcessoExportarPlanilhaExcel
            blnAbortarThreadExportarPlanilhaExcelRelatorio = True
            blnForcarAbortarThreadExportarPlanilhaExcelRelatorio = True

            blnThreadAtivadaExportarPlanilhaExcelRelatorio = False
            blnSucessoExportarPlanilhaExcelRelatorio = False
        End Sub

        Private Sub mtdPararThreadExportarPlanilhaExcelSap_R3()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            'strNomeProcesso = strNomeProcessoExportarPlanilhaExcel
            blnAbortarThreadExportarPlanilhaExcelSap_R3 = True
            blnForcarAbortarThreadExportarPlanilhaExcelSap_R3 = True

            blnThreadAtivadaExportarPlanilhaExcelSap_R3 = False
            blnSucessoExportarPlanilhaExcelSap_R3 = False
        End Sub

        Private Shared LockerExportarPlanilhaExcelSap_R3 As New Object()

        Private Shared LockerExportarPlanilhaExcelRelatorio As New Object()

        Private Sub mtdRotinaThreadExportarPlanilhaExcelRelatorio()
            While Not blnForcarAbortarThreadExportarPlanilhaExcelRelatorio
                Dim blnStatusFuncionado As Boolean = False
                If Not blnAbortarThreadExportarPlanilhaExcelRelatorio Then
                    SyncLock (LockerExportarPlanilhaExcelSap_R3)
                        'System.Threading.Monitor.Enter(LockerExportarPlanilhaExcelRelatorio)
                        Try
                            Select Case frmPrincipal.numFormularioSelecionado
                                Case 1
                                    strExcelRelatorio = "Cautelas_Relatorio"
                                    strPlanilhaExcelRelatorio = "Cautelas_Relatorio_"
                                    strNomeProcessoExportarPlanilhaExcelRelatorio = "Exportar Relatório Cautela (Excel)"

                                    strTabelaPrincipal = objCautela.strNomeTabelaCautela
                                Case 2
                                    strExcelRelatorio = "MBPs_Relatorio"
                                    strPlanilhaExcelRelatorio = "MBPs_Relatorio_"
                                    strNomeProcessoExportarPlanilhaExcelRelatorio = "Exportar Relatório MBP (Excel)"

                                    strTabelaPrincipal = objMBP.strNomeTabelaMBP
                                Case 3
                                    strExcelRelatorio = "Carteiras_Relatorio"
                                    strPlanilhaExcelRelatorio = "Carteiras_Relatorio_"
                                    strNomeProcessoExportarPlanilhaExcelRelatorio = "Exportar Relatório Carteira (Excel)"

                                    strTabelaPrincipal = objCarteira.strNomeTabelaCarteira
                                Case 4
                                    strExcelRelatorio = "Inventario_Bens_Relatorio"
                                    strPlanilhaExcelRelatorio = "Inventario_Bens_Relatorio_"
                                    strNomeProcessoExportarPlanilhaExcelRelatorio = "Exportar Relatório Inventario_Bens (Excel)"

                                    strTabelaPrincipal = frmInventarioBens.strNomeTabelaPrincipal
                                Case 5
                                    strExcelRelatorio = "Bens_Relatorio"
                                    strPlanilhaExcelRelatorio = "Bens_Relatorio_"
                                    strNomeProcessoExportarPlanilhaExcelRelatorio = "Exportar Relatório Bens (Excel)"

                                    strTabelaPrincipal = frmBens.strNomeTabelaPrincipal
                            End Select

                            If Not strLsvExportarPlanilhaExcelRelatorio Is Nothing Then
                                For contador As Integer = 1 To strLsvExportarPlanilhaExcelRelatorio.Length() - 1 Step 1
                                    If strLsvExportarPlanilhaExcelRelatorio(contador) <> Nothing Then
                                        strCampo = strLsvExportarPlanilhaExcelRelatorio(0)
                                        strDado = strLsvExportarPlanilhaExcelRelatorio(contador)

                                        Dim Extensao As String = "xls"
                                        Dim NomeArquivo As String = String.Format _
                                        ( _
                                        "{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", _
                                        strExcelRelatorio, _
                                        strCampo, _
                                        strDado, _
                                        DateTime.Now.Year, _
                                        DateTime.Now.Month, _
                                        DateTime.Now.Day, _
                                        DateTime.Now.Hour, _
                                        DateTime.Now.Minute, _
                                        DateTime.Now.Second _
                                        ).Replace(" "c, "_"c).Replace("\\", "\")

                                        FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                                        FileIO.FileSystem.CreateDirectory(strExcelRelatorio)
                                        FileIO.FileSystem.CurrentDirectory = String.Format("{0}\{1}", FileIO.FileSystem.CurrentDirectory, strExcelRelatorio)
                                        strNomeArquivoExportarPlanilhaExcelRelatorio = FileIO.FileSystem.CurrentDirectory & "\"
                                        strNomeArquivoExportarPlanilhaExcelRelatorio &= NomeArquivo & "." & Extensao

                                        Select Case frmPrincipal.numFormularioSelecionado
                                            Case 1
                                                mtdExportarPlanilhaExcelRelatorioCautelas()
                                            Case 2
                                                mtdExportarPlanilhaExcelRelatorioMBPs()
                                            Case 3
                                                mtdExportarPlanilhaExcelRelatorioCarteiras()
                                            Case 4
                                                mtdExportarPlanilhaExcelRelatorioInventarioBens()
                                            Case 5
                                                mtdExportarPlanilhaExcelRelatorioBens()
                                        End Select
                                    End If
                                Next
                            Else
                                Select Case frmPrincipal.numFormularioSelecionado
                                    Case 1
                                        mtdExportarPlanilhaExcelRelatorioCautelas()
                                    Case 2
                                        mtdExportarPlanilhaExcelRelatorioMBPs()
                                    Case 3
                                        mtdExportarPlanilhaExcelRelatorioCarteiras()
                                    Case 4
                                        mtdExportarPlanilhaExcelRelatorioInventarioBens()
                                    Case 5
                                        mtdExportarPlanilhaExcelRelatorioBens()
                                End Select
                            End If

                            'System.Windows.Forms.MessageBox.Show _
                            '( _
                            '"Os dados da tabela de inventário foram exportados para uma planilha excel.", "Aviso!", _
                            'MessageBoxButtons.OK _
                            ')
                            mtdExibirNotificacao("Os dados da tabela de inventário foram exportados.")
                            blnStatusFuncionado = True
                            mtdAbortarThreadExportarPlanilhaExcelRelatorio(True)
                        Catch ex As System.Exception
                            If Not blnStatusFuncionado Then
                                'System.Windows.Forms.MessageBox.Show _
                                '( _
                                '"Os dados da tabela de inventário não foram exportados.", "Aviso!", _
                                'MessageBoxButtons.OK _
                                ')
                                mtdExibirNotificacao("Os dados da tabela de inventário não foram exportados.")

                                mtdAbortarThreadExportarPlanilhaExcelRelatorio(True)
                            End If
                        End Try
                        'System.Threading.Monitor.[Exit](LockerExportarPlanilhaExcelRelatorio)
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Private Sub mtdRotinaThreadExportarPlanilhaExcelSap_R3()
            While Not blnForcarAbortarThreadExportarPlanilhaExcelSap_R3
                Dim blnStatusFuncionado As Boolean = False
                If Not blnAbortarThreadExportarPlanilhaExcelSap_R3 Then
                    SyncLock (LockerExportarPlanilhaExcelSap_R3)
                        'System.Threading.Monitor.Enter(LockerExportarPlanilhaExcelSap_R3)
                        Try
                            Select Case frmPrincipal.numFormularioSelecionado
                                Case 1
                                    strExcelSap_R3 = "Cautelas_Sap_R3"
                                    strPlanilhaExcelSap_R3 = "Cautelas_Sap_R3_"
                                    strNomeProcessoExportarPlanilhaExcelSap_R3 = "Exportar Cautela Sap/R3 (Excel)"

                                    strTabelaPrincipal = objCautela.strNomeTabelaCautela
                                Case 2
                                    strExcelSap_R3 = "MBPs_Sap_R3"
                                    strPlanilhaExcelSap_R3 = "MBPs_Sap_R3_"
                                    strNomeProcessoExportarPlanilhaExcelSap_R3 = "Exportar MBP Sap/R3 (Excel)"

                                    strTabelaPrincipal = objMBP.strNomeTabelaMBP
                                Case 3
                                    strExcelSap_R3 = "Carteiras_Sap_R3"
                                    strPlanilhaExcelSap_R3 = "Carteiras_Sap_R3_"
                                    strNomeProcessoExportarPlanilhaExcelSap_R3 = "Exportar Carteira Sap/R3 (Excel)"

                                    strTabelaPrincipal = objCarteira.strNomeTabelaCarteira
                                Case 4
                                    strExcelSap_R3 = "Inventario_Bens_Sap_R3"
                                    strPlanilhaExcelSap_R3 = "Inventario_Bens_Sap_R3_"
                                    strNomeProcessoExportarPlanilhaExcelSap_R3 = "Exportar Inventario_Bens Sap/R3 (Excel)"

                                    strTabelaPrincipal = frmInventarioBens.strNomeTabelaPrincipal
                                Case 5
                                    strExcelSap_R3 = "Bens_Sap_R3"
                                    strPlanilhaExcelSap_R3 = "Bens_Sap_R3_"
                                    strNomeProcessoExportarPlanilhaExcelSap_R3 = "Exportar Bens Sap/R3 (Excel)"

                                    strTabelaPrincipal = frmBens.strNomeTabelaPrincipal
                            End Select

                            If Not strLsvExportarPlanilhaExcelSap_R3 Is Nothing Then
                                For contador As Integer = 1 To strLsvExportarPlanilhaExcelSap_R3.Length() - 1 Step 1
                                    If strLsvExportarPlanilhaExcelSap_R3(contador) <> Nothing Then
                                        strCampo = strLsvExportarPlanilhaExcelSap_R3(0)
                                        strDado = strLsvExportarPlanilhaExcelSap_R3(contador)

                                        Dim Extensao As String = "xls"
                                        Dim NomeArquivo As String = String.Format _
                                        ( _
                                        "{0}_{1}_{2}_{3}_{4}_{5}_{6}_{7}_{8}", _
                                        strExcelSap_R3, _
                                        strCampo, _
                                        strDado, _
                                        DateTime.Now.Year, _
                                        DateTime.Now.Month, _
                                        DateTime.Now.Day, _
                                        DateTime.Now.Hour, _
                                        DateTime.Now.Minute, _
                                        DateTime.Now.Second _
                                        ).Replace(" "c, "_"c).Replace("\\", "\")

                                        FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                                        FileIO.FileSystem.CreateDirectory(strExcelSap_R3)
                                        FileIO.FileSystem.CurrentDirectory = String.Format("{0}\{1}", FileIO.FileSystem.CurrentDirectory, strExcelSap_R3)
                                        strNomeArquivoExportarPlanilhaExcelSap_R3 = FileIO.FileSystem.CurrentDirectory & "\"
                                        strNomeArquivoExportarPlanilhaExcelSap_R3 &= NomeArquivo & "." & Extensao

                                        Select Case frmPrincipal.numFormularioSelecionado
                                            Case 1
                                                mtdExportarPlanilhaExcelSap_R3Cautelas()
                                            Case 2
                                                mtdExportarPlanilhaExcelSap_R3MBPs()
                                            Case 3
                                                mtdExportarPlanilhaExcelSap_R3Carteiras()
                                            Case 4
                                                mtdExportarPlanilhaExcelSap_R3InventarioBens()
                                            Case 5
                                                mtdExportarPlanilhaExcelSap_R3Bens()
                                        End Select
                                    End If
                                Next
                            Else
                                Select Case frmPrincipal.numFormularioSelecionado
                                    Case 1
                                        mtdExportarPlanilhaExcelSap_R3Cautelas()
                                    Case 2
                                        mtdExportarPlanilhaExcelSap_R3MBPs()
                                    Case 3
                                        mtdExportarPlanilhaExcelSap_R3Carteiras()
                                    Case 4
                                        mtdExportarPlanilhaExcelSap_R3InventarioBens()
                                    Case 5
                                        mtdExportarPlanilhaExcelSap_R3Bens()
                                End Select
                            End If

                            'System.Windows.Forms.MessageBox.Show _
                            '( _
                            '"Os dados da tabela de inventário foram exportados para uma planilha excel.", "Aviso!", _
                            'MessageBoxButtons.OK _
                            ')
                            mtdExibirNotificacao("Os dados da tabela de inventário foram exportados.")
                            blnStatusFuncionado = True
                            mtdAbortarThreadExportarPlanilhaExcelSap_R3(True)
                        Catch ex As System.Exception
                            If Not blnStatusFuncionado Then
                                'System.Windows.Forms.MessageBox.Show _
                                '( _
                                '"Os dados da tabela de inventário não foram exportados.", "Aviso!", _
                                'MessageBoxButtons.OK _
                                ')
                                mtdExibirNotificacao("Os dados da tabela de inventário não foram exportados.")

                                mtdAbortarThreadExportarPlanilhaExcelSap_R3(True)
                            End If
                        End Try
                        'System.Threading.Monitor.[Exit](LockerExportarPlanilhaExcelSap_R3)
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Private blnThreadAtivadaExportarPlanilhaExcelRelatorio As Boolean = False
        Private blnSucessoExportarPlanilhaExcelRelatorio As Boolean = False

        Private blnThreadAtivadaExportarPlanilhaExcelSap_R3 As Boolean = False
        Private blnSucessoExportarPlanilhaExcelSap_R3 As Boolean = False

        Public Const intColunaTabelaExportacaoMassaExcelImobilizado As Integer = 0
        Public Const intColunaTabelaExportacaoMassaExcelDenomin As Integer = 1
        Public Const intColunaTabelaExportacaoMassaExcelDenomin_Extra As Integer = 2
        Public Const intColunaTabelaExportacaoMassaExcelSerie As Integer = 3
        Public Const intColunaTabelaExportacaoMassaExcelPatrimonio As Integer = 4
        Public Const intColunaTabelaExportacaoMassaExcelQtd As Integer = 5
        Public Const intColunaTabelaExportacaoMassaExcelUn As Integer = 6
        Public Const intColunaTabelaExportacaoMassaExcelUlt_invent As Integer = 7
        Public Const intColunaTabelaExportacaoMassaExcelNt_Invent As Integer = 8
        Public Const intColunaTabelaExportacaoMassaExcelAtiv As Integer = 9
        Public Const intColunaTabelaExportacaoMassaExcelCc As Integer = 10
        Public Const intColunaTabelaExportacaoMassaExcelCcR As Integer = 11
        Public Const intColunaTabelaExportacaoMassaExcelCen_Dep As Integer = 12
        Public Const intColunaTabelaExportacaoMassaExcelEnder As Integer = 13
        Public Const intColunaTabelaExportacaoMassaExcelSala As Integer = 14
        Public Const intColunaTabelaExportacaoMassaExcelMatr As Integer = 15
        Public Const intColunaTabelaExportacaoMassaExcelUc As Integer = 16
        Public Const intColunaTabelaExportacaoMassaExcelUar As Integer = 17
        Public Const intColunaTabelaExportacaoMassaExcelOdi As Integer = 18
        Public Const intColunaTabelaExportacaoMassaExcelTp As Integer = 19
        Public Const intColunaTabelaExportacaoMassaExcelLocal As Integer = 20
        Public Const intColunaTabelaExportacaoMassaExcelGener As Integer = 21
        Public Const intColunaTabelaExportacaoMassaExcelFornec As Integer = 22
        Public Const intColunaTabelaExportacaoMassaExcelDoc_Aquis As Integer = 23
        Public Const intColunaTabelaExportacaoMassaExcelCD As Integer = 24
        Public Const intColunaTabelaExportacaoMassaExcelOrigem As Integer = 25

        Private ReadOnly vetCamposTabelaExportacaoMassaExcel() As String = New String() { _
             String.Format("{0}", "Imobilizado"), _
             String.Format("{0}", "Denomin"), _
             String.Format("{0}", "Denomin_Extra"), _
             String.Format("{0}", "Serie"), _
             String.Format("{0}", "Patrimonio"), _
             String.Format("{0}", "Qtd"), _
             String.Format("{0}", "Un"), _
             String.Format("{0}", "Ult_invent"), _
             String.Format("{0}", "Nt_Invent"), _
             String.Format("{0}", "Ativ"), _
             String.Format("{0}", "Cc"), _
             String.Format("{0}", "CcR"), _
             String.Format("{0}", "Cen_Dep"), _
             String.Format("{0}", "Ender"), _
             String.Format("{0}", "Sala"), _
             String.Format("{0}", "Matr"), _
             String.Format("{0}", "Uc"), _
             String.Format("{0}", "Uar"), _
             String.Format("{0}", "Odi"), _
             String.Format("{0}", "Tp"), _
             String.Format("{0}", "Local"), _
             String.Format("{0}", "Gener"), _
             String.Format("{0}", "Fornec"), _
             String.Format("{0}", "Doc_Aquis"), _
             String.Format("{0}", "CD"), _
             String.Format("{0}", "Origem") _
         }

        Private Sub mtdRenomearDeletarPlanilhasExcelRelatorio(ByVal Endereco_Arquivo As String)
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = New Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim chartRange As Microsoft.Office.Interop.Excel.Range

            xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass()
            xlWorkBook = xlApp.Workbooks.Add(misValue)

            Try
                If xlWorkBook.Sheets.Count > 0 Then
                    xlWorkSheet = DirectCast(xlWorkBook.Sheets(3), Microsoft.Office.Interop.Excel.Worksheet)
                    xlWorkSheet.Name = strExcelRelatorio 'Rename the sheet
                End If

                For contador As Integer = 1 To 2 Step 1
                    If xlWorkBook.Sheets.Count > 0 Then
                        DirectCast(xlApp.ActiveWorkbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet).Delete()
                    End If
                Next
            Catch ex As System.Exception
                If xlWorkBook.Sheets.Count > 0 Then
                    xlWorkSheet = DirectCast(xlWorkBook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                    xlWorkSheet.Name = strExcelRelatorio 'Rename the sheet
                End If
            End Try

            xlWorkSheet.Range("b2", "j2").Merge(False)

            chartRange = xlWorkSheet.Range("b2", "j2")
            chartRange.FormulaR1C1 = "A planilha ao lado contém o relatório."
            chartRange.HorizontalAlignment = 2
            chartRange.VerticalAlignment = 2
            chartRange.Font.Bold = True
            chartRange.BorderAround( _
                Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, _
                Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, _
                Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, _
                Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic _
                )

            xlWorkBook.SaveAs(Endereco_Arquivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, _
                              Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
            xlWorkBook.Close(True, misValue, misValue)
            xlApp.Quit()

            releaseObject(xlWorkSheet)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)
        End Sub

        Private Sub mtdRenomearDeletarPlanilhasExcelSap_R3(ByVal Endereco_Arquivo As String)
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet = New Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim chartRange As Microsoft.Office.Interop.Excel.Range

            xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass()
            xlWorkBook = xlApp.Workbooks.Add(misValue)

            Try
                If xlWorkBook.Sheets.Count > 0 Then
                    xlWorkSheet = DirectCast(xlWorkBook.Sheets(3), Microsoft.Office.Interop.Excel.Worksheet)
                    xlWorkSheet.Name = strExcelSap_R3 'Rename the sheet
                End If

                For contador As Integer = 1 To 2 Step 1
                    If xlWorkBook.Sheets.Count > 0 Then
                        DirectCast(xlApp.ActiveWorkbook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet).Delete()
                    End If
                Next
            Catch ex As System.Exception
                If xlWorkBook.Sheets.Count > 0 Then
                    xlWorkSheet = DirectCast(xlWorkBook.Sheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                    xlWorkSheet.Name = strExcelSap_R3 'Rename the sheet
                End If
            End Try

            xlWorkSheet.Range("b2", "j2").Merge(False)

            chartRange = xlWorkSheet.Range("b2", "j2")
            chartRange.FormulaR1C1 = "A planilha ao lado contém os dados do inventário para serem exportados para o SAP/R3."
            chartRange.HorizontalAlignment = 2
            chartRange.VerticalAlignment = 2
            chartRange.Font.Bold = True
            chartRange.BorderAround( _
                Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, _
                Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium, _
                Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, _
                Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic _
                )

            xlWorkBook.SaveAs(Endereco_Arquivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, _
                              Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
            xlWorkBook.Close(True, misValue, misValue)
            xlApp.Quit()

            releaseObject(xlWorkSheet)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)

        End Sub

        Private Sub releaseObject(ByVal obj As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            Catch ex As Exception
                obj = Nothing
                MessageBox.Show("Unable to release the Object " & ex.ToString())
            Finally
                GC.Collect()
            End Try
        End Sub

        Private Sub mtdExportarPlanilhaExcelRelatorioCautelas()
            'mtdRenomearDeletarPlanilhasExcelRelatorio(strNomeArquivoExportarPlanilhaExcelRelatorio)

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDPrincipal.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            'objBDPrincipal.mtdSelecionarDados(frmBens.vetCamposTabelaBens, strTabelaPrincipal, strCampo, "LIKE", String.Format("'{0}'", strDado), strCampo, True)
            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando _
            ( _
            String.Format _
            ( _
            "SELECT {0} FROM {1} INNER JOIN {2} ON {1}.{3}={2}.{4} WHERE {5} LIKE '{6}' ORDER BY {7}{8}", _
            "*", _
            objCautela.strNomeTabelaCautela, _
            objCautela.strNomeTabelaCautelaBens, _
            "Codigo", _
            "Codigo", _
            String.Format("{0}.{1}", frmCautelas.strTabelaOrdenadora, strCampo), _
            String.Format("{0}", strDado), _
            String.Format("{0}.{1}", frmCautelas.strTabelaOrdenadora, strCampo), _
            String.Empty _
            ) _
            )
            Dim intNumeroLinhasPrincipal As Integer = objBDPrincipal.mtdNumeroLinhas()
            objBDPrincipal.mtdDefinirLeitorDados()
            Dim intNumeroColunasPrincipal As Integer = objBDPrincipal.mtdNumeroColunas()

            Dim campos As String()() = New String(frmCautelas.vetCamposTabelaCautela.Length() - 1 + frmCautelas.vetCamposTabelaCautelaBens.Length() - 1)() {}

            For contador As Integer = 0 To frmCautelas.vetCamposTabelaCautela.Length() - 1 Step 1
                campos(contador) = New String() {String.Format("{0}_{1}", frmCautelas.strNomeTabelaCautela, frmCautelas.vetCamposTabelaCautela(contador)), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            For contador As Integer = 0 To frmCautelas.vetCamposTabelaCautelaBens.Length() - 2 Step 1
                campos(frmCautelas.vetCamposTabelaCautela.Length() + contador) = New String() {String.Format("{0}_{1}", frmCautelas.strNomeTabelaCautelaBens, frmCautelas.vetCamposTabelaCautelaBens(contador)), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            Dim objBDExcel As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            Dim vetCampos As String() = New String(campos.Length() - 1) {}

            For contador As Integer = 0 To campos.Length() - 1 Step 1
                vetCampos(contador) = IIf(campos IsNot Nothing, campos(contador)(0), String.Empty).ToString()
                System.Threading.Thread.Sleep(1)
            Next

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, strNomeArquivoExportarPlanilhaExcelRelatorio)
            'objBDExcel.mtdCriarBancoDadosExcel()
            'objBDExcel.mtdCriarTabela(strPlanilhaExcelRelatorio, campos)
            'objBDExcel.mtdSelecionarDados(vetCampos, strPlanilhaExcelRelatorio)
            'objBDExcel.mtdDefinirLeitorDados()

            Dim dados()() As String = New String(1)() {}
            'dados(0) = objBDExcel.mtdObterCabecalhoColunas()
            dados(0) = New String(vetCampos.Length - 1) {}
            dados(1) = New String(dados(0).Length() - 1) {}

            For contador As Integer = 0 To dados(0).Length() - 1 Step 1
                'dados(0)(contador) = String.Format("{0}", dados(0)(contador))
                dados(0)(contador) = String.Format("{0}", campos(contador)(0))
                System.Threading.Thread.Sleep(1)
            Next

            Dim intLinha As Integer = 0

            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnSucessoExportarPlanilhaExcelRelatorio = False

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(strPlanilhaExcelRelatorio)
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados)
            intLinha += 1

            While (objBDPrincipal.mtdProximoRegistro())
                For contador As Integer = 0 To campos.Length() - 1 Step 1
                    dados(1)(contador) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(contador))
                    System.Threading.Thread.Sleep(1)
                Next

                'objBDExcel.mtdInserirDados(strPlanilhaExcelRelatorio, dados)
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, False)

                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal)
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
                blnSucessoExportarPlanilhaExcelRelatorio = True

                intLinha += 1
                System.Threading.Thread.Sleep(1)
            End While

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(strNomeArquivoExportarPlanilhaExcelRelatorio)

            intProgresso = 100
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnSucessoExportarPlanilhaExcelRelatorio = False

            objBDPrincipal.Dispose()
            objBDExcel.Dispose()
        End Sub

        Private Sub mtdExportarPlanilhaExcelRelatorioMBPs()
            'mtdRenomearDeletarPlanilhasExcelRelatorio(strNomeArquivoExportarPlanilhaExcelRelatorio)

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDPrincipal.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            'objBDPrincipal.mtdSelecionarDados(frmBens.vetCamposTabelaBens, strTabelaPrincipal, strCampo, "LIKE", String.Format("'{0}'", strDado), strCampo, True)
            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando _
            ( _
            String.Format _
            ( _
            "SELECT {0} FROM {1} INNER JOIN {2} ON {1}.{3}={2}.{4} WHERE {5} LIKE '{6}' ORDER BY {7}{8}", _
            "*", _
            objMBP.strNomeTabelaMBP, _
            objMBP.strNomeTabelaMBPBens, _
            "Codigo", _
            "Codigo", _
            String.Format("{0}.{1}", frmMBPs.strTabelaOrdenadora, strCampo), _
            String.Format("{0}", strDado), _
            String.Format("{0}.{1}", frmMBPs.strTabelaOrdenadora, strCampo), _
            String.Empty _
            ) _
            )
            Dim intNumeroLinhasPrincipal As Integer = objBDPrincipal.mtdNumeroLinhas()
            objBDPrincipal.mtdDefinirLeitorDados()
            Dim intNumeroColunasPrincipal As Integer = objBDPrincipal.mtdNumeroColunas()

            Dim campos As String()() = New String(frmMBPs.vetCamposTabelaMBP.Length() - 1 + frmMBPs.vetCamposTabelaMBPBens.Length() - 1)() {}

            For contador As Integer = 0 To frmMBPs.vetCamposTabelaMBP.Length() - 1 Step 1
                campos(contador) = New String() {String.Format("{0}_{1}", frmMBPs.strNomeTabelaMBP, frmMBPs.vetCamposTabelaMBP(contador)), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            For contador As Integer = 0 To frmMBPs.vetCamposTabelaMBPBens.Length() - 2 Step 1
                campos(frmMBPs.vetCamposTabelaMBP.Length() + contador) = New String() {String.Format("{0}_{1}", frmMBPs.strNomeTabelaMBPBens, frmMBPs.vetCamposTabelaMBPBens(contador)), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            Dim objBDExcel As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            Dim vetCampos As String() = New String(campos.Length() - 1) {}

            For contador As Integer = 0 To campos.Length() - 1 Step 1
                vetCampos(contador) = IIf(campos IsNot Nothing, campos(contador)(0), String.Empty).ToString()
            Next

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, strNomeArquivoExportarPlanilhaExcelRelatorio)
            'objBDExcel.mtdCriarBancoDadosExcel()
            'objBDExcel.mtdCriarTabela(strPlanilhaExcelRelatorio, campos)
            'objBDExcel.mtdSelecionarDados(vetCampos, strPlanilhaExcelRelatorio)
            'objBDExcel.mtdDefinirLeitorDados()

            Dim dados()() As String = New String(1)() {}
            'dados(0) = objBDExcel.mtdObterCabecalhoColunas()
            dados(0) = New String(vetCampos.Length - 1) {}
            dados(1) = New String(dados(0).Length() - 1) {}

            For contador As Integer = 0 To dados(0).Length() - 1 Step 1
                'dados(0)(contador) = String.Format("{0}", dados(0)(contador))
                dados(0)(contador) = String.Format("{0}", campos(contador)(0))
                System.Threading.Thread.Sleep(1)
            Next

            Dim intLinha As Integer = 0

            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnSucessoExportarPlanilhaExcelRelatorio = False

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(strPlanilhaExcelRelatorio)
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados)
            intLinha += 1

            While (objBDPrincipal.mtdProximoRegistro())
                For contador As Integer = 0 To campos.Length() - 1 Step 1
                    dados(1)(contador) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(contador))
                    System.Threading.Thread.Sleep(1)
                Next

                'objBDExcel.mtdInserirDados(strPlanilhaExcelRelatorio, dados)
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, False)

                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal)
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
                blnSucessoExportarPlanilhaExcelRelatorio = True

                intLinha += 1
                System.Threading.Thread.Sleep(1)
            End While

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(strNomeArquivoExportarPlanilhaExcelRelatorio)

            intProgresso = 100
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnSucessoExportarPlanilhaExcelRelatorio = False

            objBDPrincipal.Dispose()
            objBDExcel.Dispose()
        End Sub

        Private Sub mtdExportarPlanilhaExcelRelatorioCarteiras()
            'mtdRenomearDeletarPlanilhasExcelRelatorio(strNomeArquivoExportarPlanilhaExcelRelatorio)

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDPrincipal.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            'objBDPrincipal.mtdSelecionarDados(frmBens.vetCamposTabelaBens, strTabelaPrincipal, strCampo, "LIKE", String.Format("'{0}'", strDado), strCampo, True)
            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando _
            ( _
            String.Format _
            ( _
            "SELECT {0} FROM {1} INNER JOIN {2} ON {1}.{3}={2}.{4} WHERE {5} LIKE '{6}' ORDER BY {7}{8}", _
            "*", _
            objCarteira.strNomeTabelaCarteira, _
            objCarteira.strNomeTabelaCarteiraBens, _
            "Codigo", _
            "Codigo", _
            String.Format("{0}.{1}", frmCarteiras.strTabelaOrdenadora, strCampo), _
            String.Format("{0}", strDado), _
            String.Format("{0}.{1}", frmCarteiras.strTabelaOrdenadora, strCampo), _
            String.Empty _
            ) _
            )
            Dim intNumeroLinhasPrincipal As Integer = objBDPrincipal.mtdNumeroLinhas()
            objBDPrincipal.mtdDefinirLeitorDados()
            Dim intNumeroColunasPrincipal As Integer = objBDPrincipal.mtdNumeroColunas()

            Dim campos As String()() = New String(frmCarteiras.vetCamposTabelaCarteira.Length() - 1 + frmCarteiras.vetCamposTabelaCarteiraBens.Length() - 1)() {}

            For contador As Integer = 0 To frmCarteiras.vetCamposTabelaCarteira.Length() - 1 Step 1
                campos(contador) = New String() {String.Format("{0}_{1}", frmCarteiras.strNomeTabelaCarteira, frmCarteiras.vetCamposTabelaCarteira(contador)), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            For contador As Integer = 0 To frmCarteiras.vetCamposTabelaCarteiraBens.Length() - 2 Step 1
                campos(frmCarteiras.vetCamposTabelaCarteira.Length() + contador) = New String() {String.Format("{0}_{1}", frmCarteiras.strNomeTabelaCarteiraBens, frmCarteiras.vetCamposTabelaCarteiraBens(contador)), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            Dim objBDExcel As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            Dim vetCampos As String() = New String(campos.Length() - 1) {}

            For contador As Integer = 0 To campos.Length() - 1 Step 1
                vetCampos(contador) = IIf(campos IsNot Nothing, campos(contador)(0), String.Empty).ToString()
                System.Threading.Thread.Sleep(1)
            Next

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, strNomeArquivoExportarPlanilhaExcelRelatorio)
            'objBDExcel.mtdCriarBancoDadosExcel()
            'objBDExcel.mtdCriarTabela(strPlanilhaExcelRelatorio, campos)
            'objBDExcel.mtdSelecionarDados(vetCampos, strPlanilhaExcelRelatorio)
            'objBDExcel.mtdDefinirLeitorDados()

            Dim dados()() As String = New String(1)() {}
            'dados(0) = objBDExcel.mtdObterCabecalhoColunas()
            dados(0) = New String(vetCampos.Length - 1) {}
            dados(1) = New String(dados(0).Length() - 1) {}

            For contador As Integer = 0 To dados(0).Length() - 1 Step 1
                'dados(0)(contador) = String.Format("{0}", dados(0)(contador))
                dados(0)(contador) = String.Format("{0}", campos(contador)(0))
                System.Threading.Thread.Sleep(1)
            Next

            Dim intLinha As Integer = 0

            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnSucessoExportarPlanilhaExcelRelatorio = False

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(strPlanilhaExcelRelatorio)
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados)
            intLinha += 1

            While (objBDPrincipal.mtdProximoRegistro())
                For contador As Integer = 0 To campos.Length() - 1 Step 1
                    dados(1)(contador) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(contador))
                    System.Threading.Thread.Sleep(1)
                Next

                'objBDExcel.mtdInserirDados(strPlanilhaExcelRelatorio, dados)
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, False)

                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal)
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
                blnSucessoExportarPlanilhaExcelRelatorio = True

                intLinha += 1
                System.Threading.Thread.Sleep(1)
            End While

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(strNomeArquivoExportarPlanilhaExcelRelatorio)

            intProgresso = 100
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnSucessoExportarPlanilhaExcelRelatorio = False

            objBDPrincipal.Dispose()
            objBDExcel.Dispose()
        End Sub

        Private Sub mtdExportarPlanilhaExcelRelatorioBens()
            'mtdRenomearDeletarPlanilhasExcelRelatorio(strNomeArquivoExportarPlanilhaExcelRelatorio)

            Dim campos As String()() = New String(frmBens.vetCamposTabelaBens.GetLength(0) - 1)() {}

            For contador As Integer = 0 To frmBens.vetCamposTabelaBens.GetLength(0) - 1 Step 1
                campos(contador) = New String() {frmBens.vetCamposTabelaBens(contador), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDPrincipal.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            objBDPrincipal.mtdSelecionarDados(frmBens.vetCamposTabelaBens, strTabelaPrincipal, strCampo, "LIKE", String.Format("'{0}'", strDado), strCampo, True)
            Dim intNumeroLinhasPrincipal As Integer = objBDPrincipal.mtdNumeroLinhas()
            objBDPrincipal.mtdDefinirLeitorDados()
            Dim intNumeroColunasPrincipal As Integer = objBDPrincipal.mtdNumeroColunas()

            Dim objBDExcel As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, strNomeArquivoExportarPlanilhaExcelRelatorio)
            'objBDExcel.mtdCriarBancoDadosExcel()
            'objBDExcel.mtdCriarTabela(strPlanilhaExcelRelatorio, campos)
            'objBDExcel.mtdSelecionarDados(frmBens.vetCamposTabelaBens, strPlanilhaExcelRelatorio)
            'objBDExcel.mtdDefinirLeitorDados()

            Dim dados()() As String = New String(1)() {}
            'dados(0) = objBDExcel.mtdObterCabecalhoColunas()
            dados(0) = New String(frmBens.vetCamposTabelaBens.Length - 1) {}
            dados(1) = New String(frmBens.vetCamposTabelaBens.GetUpperBound(0)) {}

            For contador As Integer = 0 To dados(0).Length() - 1 Step 1
                'dados(0)(contador) = String.Format("{0}", dados(0)(contador))
                dados(0)(contador) = String.Format("{0}", campos(contador)(0))
                System.Threading.Thread.Sleep(1)
            Next

            Dim intLinha As Integer = 0

            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnSucessoExportarPlanilhaExcelRelatorio = False

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(strPlanilhaExcelRelatorio)
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados)
            intLinha += 1

            While (objBDPrincipal.mtdProximoRegistro())
                dados(1)(frmBens.intColunaTabelaBensImobilizado) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensImobilizado))
                dados(1)(frmBens.intColunaTabelaBensPatrimonio) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensPatrimonio))
                dados(1)(frmBens.intColunaTabelaBensDenominacao) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensDenominacao))
                dados(1)(frmBens.intColunaTabelaBensDenominacao_Extra) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensDenominacao_Extra))
                dados(1)(frmBens.intColunaTabelaBensN_Serie) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensN_Serie))
                dados(1)(frmBens.intColunaTabelaBensSala) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensSala))
                dados(1)(frmBens.intColunaTabelaBensMatricula) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensMatricula))
                dados(1)(frmBens.intColunaTabelaBensCentro_Custo) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensCentro_Custo))
                dados(1)(frmBens.intColunaTabelaBensAtividade) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensAtividade))
                dados(1)(frmBens.intColunaTabelaBensOrgao) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensOrgao))

                'objBDExcel.mtdInserirDados(strPlanilhaExcelRelatorio, dados)
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, False)

                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal)
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
                blnSucessoExportarPlanilhaExcelRelatorio = True

                intLinha += 1
                System.Threading.Thread.Sleep(1)
            End While

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(strNomeArquivoExportarPlanilhaExcelRelatorio)

            intProgresso = 100
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnSucessoExportarPlanilhaExcelRelatorio = False

            objBDPrincipal.Dispose()
            objBDExcel.Dispose()
        End Sub

        Private Sub mtdExportarPlanilhaExcelRelatorioInventarioBens()
            'mtdRenomearDeletarPlanilhasExcelRelatorio(strNomeArquivoExportarPlanilhaExcelRelatorio)

            Dim campos As String()() = New String(frmInventarioBens.vetCamposTabelaInventarioBens.GetLength(0) - 1)() {}

            For contador As Integer = 0 To frmInventarioBens.vetCamposTabelaInventarioBens.GetLength(0) - 1 Step 1
                campos(contador) = New String() {frmInventarioBens.vetCamposTabelaInventarioBens(contador), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDPrincipal.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            objBDPrincipal.mtdSelecionarDados(frmInventarioBens.vetCamposTabelaInventarioBens, strTabelaPrincipal, strCampo, "LIKE", String.Format("'{0}'", strDado), strCampo, True)
            Dim intNumeroLinhasPrincipal As Integer = objBDPrincipal.mtdNumeroLinhas()
            objBDPrincipal.mtdDefinirLeitorDados()
            Dim intNumeroColunasPrincipal As Integer = objBDPrincipal.mtdNumeroColunas()

            Dim objBDExcel As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, strNomeArquivoExportarPlanilhaExcelRelatorio)
            'objBDExcel.mtdCriarBancoDadosExcel()
            'objBDExcel.mtdCriarTabela(strPlanilhaExcelRelatorio, campos)
            'objBDExcel.mtdSelecionarDados(frmInventarioBens.vetCamposTabelaInventarioBens, strPlanilhaExcelRelatorio)
            'objBDExcel.mtdDefinirLeitorDados()

            Dim dados()() As String = New String(1)() {}
            'dados(0) = objBDExcel.mtdObterCabecalhoColunas()
            dados(0) = New String(frmInventarioBens.vetCamposTabelaInventarioBens.Length - 1) {}
            dados(1) = New String(frmInventarioBens.vetCamposTabelaInventarioBens.GetUpperBound(0)) {}

            For contador As Integer = 0 To dados(0).Length() - 1 Step 1
                'dados(0)(contador) = String.Format("{0}", dados(0)(contador))
                dados(0)(contador) = String.Format("{0}", campos(contador)(0))
                System.Threading.Thread.Sleep(1)
            Next

            Dim intLinha As Integer = 0

            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnSucessoExportarPlanilhaExcelRelatorio = False

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(strPlanilhaExcelRelatorio)
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados)
            intLinha += 1

            While (objBDPrincipal.mtdProximoRegistro())
                Dim dtDataInventario As DateTime = DirectCast(objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensData_Inventario), System.DateTime)
                'Dim strDenominacao As String = objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensDenominacao).ToString()
                'Dim strDenominacaoExtra As String = String.Empty
                'If strDenominacao.Length() > 50 Then
                '    strDenominacaoExtra = strDenominacao.Substring(intNumeroCaracteresPorCampoSap_R3)
                '    strDenominacao = strDenominacao.Substring(0, intNumeroCaracteresPorCampoSap_R3)
                'End If

                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensNumero_Inventario) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensNumero_Inventario))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensData_Inventario) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensData_Inventario))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensTRG) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensTRG))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensCentroCusto) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensCentroCusto))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensOrgao) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensOrgao))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensSala) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensSala))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensNome) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensNome))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensMatricula) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensMatricula))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensPatrimonio) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensPatrimonio))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensQuantidade) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensQuantidade))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensDenominacao) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensDenominacao))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensN_Serie) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensN_Serie))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensPlaca_Veiculo) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensPlaca_Veiculo))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensIdentificacao_Inventario) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensIdentificacao_Inventario))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensOutrosDados_Inventario) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensOutrosDados_Inventario))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensObservacao) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensObservacao))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensColetor) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensColetor).ToString())
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensUsuario_Inventariante) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensUsuario_Inventariante))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensMatricula_Inventariante) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensMatricula_Inventariante))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensInventario) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensInventario))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensFotografia) = String.Format("{0}", String.Empty) 'String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensFotografia))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensGPS_Latitute) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensGPS_Latitute))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensGPS_Longitude) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensGPS_Longitude))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensGPS_EllipsoidAltitude) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensGPS_EllipsoidAltitude))
                dados(1)(frmInventarioBens.intColunaTabelaInventarioBensGPS_PositionDilutionOfPrecision) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensGPS_PositionDilutionOfPrecision))

                'objBDExcel.mtdInserirDados(strPlanilhaExcelRelatorio, dados)
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, False)

                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal)
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
                blnSucessoExportarPlanilhaExcelRelatorio = True

                intLinha += 1
                System.Threading.Thread.Sleep(1)
            End While

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(strNomeArquivoExportarPlanilhaExcelRelatorio)

            intProgresso = 100
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelRelatorio
            blnSucessoExportarPlanilhaExcelRelatorio = False

            objBDPrincipal.Dispose()
            objBDExcel.Dispose()
        End Sub

        Private strNomeArquivoExportarPlanilhaExcelRelatorio As String = String.Empty
        Private strNomeArquivoExportarPlanilhaExcelSap_R3 As String = String.Empty
        Private strCampo As String = String.Empty
        Private strDado As String = String.Empty

        Private strQtd As String = "1"
        Private strUn As String = "UN"

        Private intNumeroCaracteresPorCampoSap_R3 As Integer = 50

        Private Sub mtdExportarPlanilhaExcelSap_R3Cautelas()
            'mtdRenomearDeletarPlanilhasExcelSap_R3(strNomeArquivoExportarPlanilhaExcelSap_R3)

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDPrincipal.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            'objBDPrincipal.mtdSelecionarDados(frmCautelas.vetCamposTabelaCautelaBens, strTabelaPrincipal, strCampo, "LIKE", String.Format("'{0}'", strDado), strCampo, True)
            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando _
            ( _
            String.Format _
            ( _
            "SELECT {0} FROM {1} INNER JOIN {2} ON {1}.{3}={2}.{4} WHERE {5} LIKE '{6}' ORDER BY {7}{8}", _
            "*", _
            objCautela.strNomeTabelaCautela, _
            objCautela.strNomeTabelaCautelaBens, _
            "Codigo", _
            "Codigo", _
            String.Format("{0}.{1}", frmCautelas.strTabelaOrdenadora, strCampo), _
            String.Format("{0}", strDado), _
            String.Format("{0}.{1}", frmCautelas.strTabelaOrdenadora, strCampo), _
            String.Empty _
            ) _
            )
            Dim intNumeroLinhasPrincipal As Integer = objBDPrincipal.mtdNumeroLinhas()
            objBDPrincipal.mtdDefinirLeitorDados()
            Dim intNumeroColunasPrincipal As Integer = objBDPrincipal.mtdNumeroColunas()

            Dim campos As String()() = New String(vetCamposTabelaExportacaoMassaExcel.GetLength(0) - 1)() {}

            For contador As Integer = 0 To vetCamposTabelaExportacaoMassaExcel.GetLength(0) - 1 Step 1
                campos(contador) = New String() {vetCamposTabelaExportacaoMassaExcel(contador), "CHAR", "255", String.Empty}
            Next

            Dim objBDExcel As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, strNomeArquivoExportarPlanilhaExcelSap_R3)
            'objBDExcel.mtdCriarBancoDadosExcel()
            'objBDExcel.mtdCriarTabela(strPlanilhaExcelSap_R3, campos)
            'objBDExcel.mtdSelecionarDados(vetCamposTabelaExportacaoMassaExcel, strPlanilhaExcelSap_R3)
            'objBDExcel.mtdDefinirLeitorDados()

            Dim dados()() As String = New String(1)() {}
            'dados(0) = objBDExcel.mtdObterCabecalhoColunas()
            dados(0) = New String(vetCamposTabelaExportacaoMassaExcel.Length - 1) {}
            dados(1) = New String(dados(0).Length() - 1) {}

            For contador As Integer = 0 To dados(0).Length() - 1 Step 1
                'dados(0)(contador) = String.Format("{0}", dados(0)(contador))
                dados(0)(contador) = String.Format("{0}", campos(contador)(0))
                System.Threading.Thread.Sleep(1)
            Next

            Dim intLinha As Integer = 0

            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnSucessoExportarPlanilhaExcelSap_R3 = False

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(strTabelaPrincipal)
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados)
            intLinha += 1

            While (objBDPrincipal.mtdProximoRegistro())
                Dim dtDataInventario As DateTime = DirectCast(System.Convert.ToDateTime(objBDPrincipal.mtdObterValorRegistro(frmCautelas.vetCamposTabelaCautela.Length() + frmCautelas.intColunaTabelaCautelaBensData_Criacao)), System.DateTime)
                'Dim dtDataInventario As DateTime = DirectCast(objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensData_Inventario), System.DateTime)
                Dim strDenominacao As String = System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(frmCautelas.vetCamposTabelaCautela.Length() + frmCautelas.intColunaTabelaCautelaBensDescricao))
                Dim strDenominacaoExtra As String = String.Empty
                If strDenominacao.Length() > 50 Then
                    strDenominacaoExtra = strDenominacao.Substring(intNumeroCaracteresPorCampoSap_R3)
                    strDenominacao = strDenominacao.Substring(0, intNumeroCaracteresPorCampoSap_R3)
                End If
                'Dim strCentroCusto As String = mtdObterCentroCustoOrgao(objBDPrincipal.mtdObterValorRegistro(frmCautelas.intColunaTabelaCautelaOrgao).ToString()).ToString()

                'strQtd = IIf(objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensQuantidade).ToString().Equals(String.Empty), "1", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensQuantidade).ToString()).ToString()

                dados(1)(intColunaTabelaExportacaoMassaExcelImobilizado) = String.Format("{0}", mtdObterImobilizadoBens(System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(frmCautelas.vetCamposTabelaCautela.Length() + frmCautelas.intColunaTabelaCautelaBensPatrimonio))))
                'dados(1)(intColunaTabelaExportacaoMassaExcelImobilizado) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelDenomin) = String.Format("{0}", strDenominacao)
                dados(1)(intColunaTabelaExportacaoMassaExcelDenomin_Extra) = String.Format("{0}", strDenominacaoExtra)
                dados(1)(intColunaTabelaExportacaoMassaExcelSerie) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmCautelas.vetCamposTabelaCautela.Length() + frmCautelas.intColunaTabelaCautelaBensN_Serie))
                dados(1)(intColunaTabelaExportacaoMassaExcelPatrimonio) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmCautelas.vetCamposTabelaCautela.Length() + frmCautelas.intColunaTabelaCautelaBensPatrimonio))
                dados(1)(intColunaTabelaExportacaoMassaExcelQtd) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUn) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUlt_invent) = String.Format("{0}", String.Format("{0:00}{1:00}{2:0000}", dtDataInventario.Day, dtDataInventario.Month, dtDataInventario.Year))
                dados(1)(intColunaTabelaExportacaoMassaExcelNt_Invent) = String.Format("{0}", String.Format("Cautela_{0}", objBDPrincipal.mtdObterValorRegistro(frmCautelas.vetCamposTabelaCautela.Length() + frmCautelas.intColunaTabelaCautelaBensCodigo)))
                dados(1)(intColunaTabelaExportacaoMassaExcelAtiv) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelCc) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmCautelas.intColunaTabelaCautelaCentro_Custo))
                dados(1)(intColunaTabelaExportacaoMassaExcelCcR) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmCautelas.intColunaTabelaCautelaCentro_Custo))
                dados(1)(intColunaTabelaExportacaoMassaExcelCen_Dep) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelEnder) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelSala) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmCautelas.vetCamposTabelaCautela.Length() + frmCautelas.intColunaTabelaCautelaBensLocalizacao))
                dados(1)(intColunaTabelaExportacaoMassaExcelMatr) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmCautelas.intColunaTabelaCautelaMatricula))
                dados(1)(intColunaTabelaExportacaoMassaExcelUc) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUar) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelOdi) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelTp) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelLocal) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelGener) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelFornec) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelDoc_Aquis) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelCD) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelOrigem) = String.Format("{0}", String.Empty)

                'objBDExcel.mtdInserirDados(strPlanilhaExcelSap_R3, dados)
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, False)

                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal)
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
                blnSucessoExportarPlanilhaExcelSap_R3 = True

                intLinha += 1
                System.Threading.Thread.Sleep(1)
            End While

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(strNomeArquivoExportarPlanilhaExcelSap_R3)

            intProgresso = 100
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnSucessoExportarPlanilhaExcelSap_R3 = False

            objBDPrincipal.Dispose()
            objBDExcel.Dispose()
        End Sub

        Private Sub mtdExportarPlanilhaExcelSap_R3MBPs()
            'mtdRenomearDeletarPlanilhasExcelSap_R3(strNomeArquivoExportarPlanilhaExcelSap_R3)

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDPrincipal.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            'objBDPrincipal.mtdSelecionarDados(frmMBPs.vetCamposTabelaMBPBens, strTabelaPrincipal, strCampo, "LIKE", String.Format("'{0}'", strDado), strCampo, True)
            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando _
            ( _
            String.Format _
            ( _
            "SELECT {0} FROM {1} INNER JOIN {2} ON {1}.{3}={2}.{4} WHERE {5} LIKE '{6}' ORDER BY {7}{8}", _
            "*", _
            objMBP.strNomeTabelaMBP, _
            objMBP.strNomeTabelaMBPBens, _
            "Codigo", _
            "Codigo", _
            String.Format("{0}.{1}", frmMBPs.strTabelaOrdenadora, strCampo), _
            String.Format("{0}", strDado), _
            String.Format("{0}.{1}", frmMBPs.strTabelaOrdenadora, strCampo), _
            String.Empty _
            ) _
            )
            Dim intNumeroLinhasPrincipal As Integer = objBDPrincipal.mtdNumeroLinhas()
            objBDPrincipal.mtdDefinirLeitorDados()
            Dim intNumeroColunasPrincipal As Integer = objBDPrincipal.mtdNumeroColunas()

            Dim campos As String()() = New String(vetCamposTabelaExportacaoMassaExcel.GetLength(0) - 1)() {}

            For contador As Integer = 0 To vetCamposTabelaExportacaoMassaExcel.GetLength(0) - 1 Step 1
                campos(contador) = New String() {vetCamposTabelaExportacaoMassaExcel(contador), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            Dim objBDExcel As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, strNomeArquivoExportarPlanilhaExcelSap_R3)
            'objBDExcel.mtdCriarBancoDadosExcel()
            'objBDExcel.mtdCriarTabela(strPlanilhaExcelSap_R3, campos)
            'objBDExcel.mtdSelecionarDados(vetCamposTabelaExportacaoMassaExcel, strPlanilhaExcelSap_R3)
            'objBDExcel.mtdDefinirLeitorDados()

            Dim dados()() As String = New String(1)() {}
            'dados(0) = objBDExcel.mtdObterCabecalhoColunas()
            dados(0) = New String(vetCamposTabelaExportacaoMassaExcel.Length - 1) {}
            dados(1) = New String(dados(0).Length() - 1) {}

            For contador As Integer = 0 To dados(0).Length() - 1 Step 1
                'dados(0)(contador) = String.Format("{0}", dados(0)(contador))
                dados(0)(contador) = String.Format("{0}", campos(contador)(0))
                System.Threading.Thread.Sleep(1)
            Next

            Dim intLinha As Integer = 0

            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnSucessoExportarPlanilhaExcelSap_R3 = False

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(strTabelaPrincipal)
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados)
            intLinha += 1

            While (objBDPrincipal.mtdProximoRegistro())
                Dim dtDataInventario As DateTime = DirectCast(System.Convert.ToDateTime(objBDPrincipal.mtdObterValorRegistro(frmMBPs.vetCamposTabelaMBP.Length() + frmMBPs.intColunaTabelaMBPBensData_Criacao)), System.DateTime)
                'Dim dtDataInventario As DateTime = DirectCast(objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensData_Inventario), System.DateTime)
                Dim strDenominacao As String = System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(frmMBPs.vetCamposTabelaMBP.Length() + frmMBPs.intColunaTabelaMBPBensDescricao))
                Dim strDenominacaoExtra As String = String.Empty
                If strDenominacao.Length() > 50 Then
                    strDenominacaoExtra = strDenominacao.Substring(intNumeroCaracteresPorCampoSap_R3)
                    strDenominacao = strDenominacao.Substring(0, intNumeroCaracteresPorCampoSap_R3)
                End If
                Dim strCentroCusto As String = System.Convert.ToString(mtdObterCentroCustoOrgao(System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(frmMBPs.intColunaTabelaMBPOrgao_Recebedor))))

                'strQtd = IIf(objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensQuantidade).ToString().Equals(String.Empty), "1", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensQuantidade).ToString()).ToString()

                dados(1)(intColunaTabelaExportacaoMassaExcelImobilizado) = String.Format("{0}", mtdObterImobilizadoBens(System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(frmMBPs.vetCamposTabelaMBP.Length() + frmMBPs.intColunaTabelaMBPBensPatrimonio))))
                'dados(1)(intColunaTabelaExportacaoMassaExcelImobilizado) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelDenomin) = String.Format("{0}", strDenominacao)
                dados(1)(intColunaTabelaExportacaoMassaExcelDenomin_Extra) = String.Format("{0}", strDenominacaoExtra)
                dados(1)(intColunaTabelaExportacaoMassaExcelSerie) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmMBPs.vetCamposTabelaMBP.Length() + frmMBPs.intColunaTabelaMBPBensN_Serie))
                dados(1)(intColunaTabelaExportacaoMassaExcelPatrimonio) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmMBPs.vetCamposTabelaMBP.Length() + frmMBPs.intColunaTabelaMBPBensPatrimonio))
                dados(1)(intColunaTabelaExportacaoMassaExcelQtd) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUn) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUlt_invent) = String.Format("{0}", String.Format("{0:00}{1:00}{2:0000}", dtDataInventario.Day, dtDataInventario.Month, dtDataInventario.Year))
                dados(1)(intColunaTabelaExportacaoMassaExcelNt_Invent) = String.Format("{0}", String.Format("MBP_{0}", objBDPrincipal.mtdObterValorRegistro(frmMBPs.vetCamposTabelaMBP.Length() + frmMBPs.intColunaTabelaMBPBensCodigo)))
                dados(1)(intColunaTabelaExportacaoMassaExcelAtiv) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelCc) = String.Format("{0}", strCentroCusto)
                dados(1)(intColunaTabelaExportacaoMassaExcelCcR) = String.Format("{0}", strCentroCusto)
                dados(1)(intColunaTabelaExportacaoMassaExcelCen_Dep) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelEnder) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelSala) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmMBPs.intColunaTabelaMBPSala_Recebedor))
                dados(1)(intColunaTabelaExportacaoMassaExcelMatr) = String.Format("{0}", IIf(System.Convert.ToInt32(objBDPrincipal.mtdObterValorRegistro(frmMBPs.vetCamposTabelaMBP.Length() + frmMBPs.intColunaTabelaMBPBensMatricula_Responsavel)) <> 0, objBDPrincipal.mtdObterValorRegistro(frmMBPs.intColunaTabelaMBPMatricula_Recebedor), objBDPrincipal.mtdObterValorRegistro(frmMBPs.vetCamposTabelaMBP.Length() + frmMBPs.intColunaTabelaMBPBensMatricula_Responsavel)))
                dados(1)(intColunaTabelaExportacaoMassaExcelUc) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUar) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelOdi) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelTp) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelLocal) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelGener) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelFornec) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelDoc_Aquis) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelCD) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelOrigem) = String.Format("{0}", String.Empty)

                'objBDExcel.mtdInserirDados(strPlanilhaExcelSap_R3, dados)
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, False)

                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal)
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
                blnSucessoExportarPlanilhaExcelSap_R3 = True

                intLinha += 1
                System.Threading.Thread.Sleep(1)
            End While

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(strNomeArquivoExportarPlanilhaExcelSap_R3)

            intProgresso = 100
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnSucessoExportarPlanilhaExcelSap_R3 = False

            objBDPrincipal.Dispose()
            objBDExcel.Dispose()
        End Sub

        Private Sub mtdExportarPlanilhaExcelSap_R3Carteiras()
            'mtdRenomearDeletarPlanilhasExcelSap_R3(strNomeArquivoExportarPlanilhaExcelSap_R3)

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDPrincipal.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            'objBDPrincipal.mtdSelecionarDados(frmCarteiras.vetCamposTabelaCarteiraBens, strTabelaPrincipal, strCampo, "LIKE", String.Format("'{0}'", strDado), strCampo, True)
            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando _
            ( _
            String.Format _
            ( _
            "SELECT {0} FROM {1} INNER JOIN {2} ON {1}.{3}={2}.{4} WHERE {5} LIKE '{6}' ORDER BY {7}{8}", _
            "*", _
            objCarteira.strNomeTabelaCarteira, _
            objCarteira.strNomeTabelaCarteiraBens, _
            "Codigo", _
            "Codigo", _
            String.Format("{0}.{1}", frmCarteiras.strTabelaOrdenadora, strCampo), _
            String.Format("{0}", strDado), _
            String.Format("{0}.{1}", frmCarteiras.strTabelaOrdenadora, strCampo), _
            String.Empty _
            ) _
            )
            Dim intNumeroLinhasPrincipal As Integer = objBDPrincipal.mtdNumeroLinhas()
            objBDPrincipal.mtdDefinirLeitorDados()
            Dim intNumeroColunasPrincipal As Integer = objBDPrincipal.mtdNumeroColunas()

            Dim campos As String()() = New String(vetCamposTabelaExportacaoMassaExcel.GetLength(0) - 1)() {}

            For contador As Integer = 0 To vetCamposTabelaExportacaoMassaExcel.GetLength(0) - 1 Step 1
                campos(contador) = New String() {vetCamposTabelaExportacaoMassaExcel(contador), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            Dim objBDExcel As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, strNomeArquivoExportarPlanilhaExcelSap_R3)
            'objBDExcel.mtdCriarBancoDadosExcel()
            'objBDExcel.mtdCriarTabela(strPlanilhaExcelSap_R3, campos)
            'objBDExcel.mtdSelecionarDados(vetCamposTabelaExportacaoMassaExcel, strPlanilhaExcelSap_R3)
            'objBDExcel.mtdDefinirLeitorDados()

            Dim dados()() As String = New String(1)() {}
            'dados(0) = objBDExcel.mtdObterCabecalhoColunas()
            dados(0) = New String(vetCamposTabelaExportacaoMassaExcel.Length - 1) {}
            dados(1) = New String(dados(0).Length() - 1) {}

            For contador As Integer = 0 To dados(0).Length() - 1 Step 1
                'dados(0)(contador) = String.Format("{0}", dados(0)(contador))
                dados(0)(contador) = String.Format("{0}", campos(contador)(0))
                System.Threading.Thread.Sleep(1)
            Next

            Dim intLinha As Integer = 0

            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnSucessoExportarPlanilhaExcelSap_R3 = False

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(strTabelaPrincipal)
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados)
            intLinha += 1

            While (objBDPrincipal.mtdProximoRegistro())
                Dim dtDataInventario As DateTime = DirectCast(System.Convert.ToDateTime(objBDPrincipal.mtdObterValorRegistro(frmCarteiras.vetCamposTabelaCarteira.Length() + frmCarteiras.intColunaTabelaCarteiraBensData_Criacao)), System.DateTime)
                'Dim dtDataInventario As DateTime = DirectCast(objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensData_Inventario), System.DateTime)
                Dim strDenominacao As String = System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(frmCarteiras.vetCamposTabelaCarteira.Length() + frmCarteiras.intColunaTabelaCarteiraBensDescricao))
                Dim strDenominacaoExtra As String = String.Empty
                If strDenominacao.Length() > 50 Then
                    strDenominacaoExtra = strDenominacao.Substring(intNumeroCaracteresPorCampoSap_R3)
                    strDenominacao = strDenominacao.Substring(0, intNumeroCaracteresPorCampoSap_R3)
                End If
                Dim ListaDadosBens As List(Of String) = mtdObterListaDadosTabela("tblBensEletronorte", frmBens.vetCamposTabelaBens(frmBens.intColunaTabelaBensPatrimonio), System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(frmCarteiras.vetCamposTabelaCarteira.Length + frmCarteiras.intColunaTabelaCarteiraBensPatrimonio)))
                Dim ListaDadosEmpregados As List(Of String) = mtdObterListaDadosTabela("tblEmpregados", frmCADU.vetCamposTabelaEmpregados(frmCADU.intColunaTabelaEmpregadosMatricula), System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(frmCarteiras.intColunaTabelaCarteiraMatricula_Solicitador)))
                Dim strCentroCusto As Integer = mtdObterCentroCustoOrgao(ListaDadosEmpregados(frmCADU.intColunaTabelaEmpregadosOrgao))

                'strQtd = IIf(objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensQuantidade).ToString().Equals(String.Empty), "1", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensQuantidade).ToString()).ToString()

                dados(1)(intColunaTabelaExportacaoMassaExcelImobilizado) = String.Format("{0}", mtdObterImobilizadoBens(System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(frmCarteiras.vetCamposTabelaCarteira.Length() + frmCarteiras.intColunaTabelaCarteiraBensPatrimonio))))
                'dados(1)(intColunaTabelaExportacaoMassaExcelImobilizado) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelDenomin) = String.Format("{0}", strDenominacao)
                dados(1)(intColunaTabelaExportacaoMassaExcelDenomin_Extra) = String.Format("{0}", strDenominacaoExtra)
                dados(1)(intColunaTabelaExportacaoMassaExcelSerie) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmCarteiras.vetCamposTabelaCarteira.Length() + frmCarteiras.intColunaTabelaCarteiraBensN_Serie))
                dados(1)(intColunaTabelaExportacaoMassaExcelPatrimonio) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmCarteiras.vetCamposTabelaCarteira.Length() + frmCarteiras.intColunaTabelaCarteiraBensPatrimonio))
                dados(1)(intColunaTabelaExportacaoMassaExcelQtd) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUn) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUlt_invent) = String.Format("{0}", String.Format("{0:00}{1:00}{2:0000}", dtDataInventario.Day, dtDataInventario.Month, dtDataInventario.Year))
                dados(1)(intColunaTabelaExportacaoMassaExcelNt_Invent) = String.Format("{0}", String.Format("Carteira_{0}", objBDPrincipal.mtdObterValorRegistro(frmCarteiras.vetCamposTabelaCarteira.Length() + frmCarteiras.intColunaTabelaCarteiraBensCodigo)))
                dados(1)(intColunaTabelaExportacaoMassaExcelAtiv) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelCc) = String.Format("{0}", strCentroCusto)
                dados(1)(intColunaTabelaExportacaoMassaExcelCcR) = String.Format("{0}", strCentroCusto)
                dados(1)(intColunaTabelaExportacaoMassaExcelCen_Dep) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelEnder) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelSala) = String.Format("{0}", ListaDadosBens(frmBens.intColunaTabelaBensSala))
                dados(1)(intColunaTabelaExportacaoMassaExcelMatr) = String.Format("{0}", ListaDadosEmpregados(frmCADU.intColunaTabelaEmpregadosMatricula))
                dados(1)(intColunaTabelaExportacaoMassaExcelUc) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUar) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelOdi) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelTp) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelLocal) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelGener) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelFornec) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelDoc_Aquis) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelCD) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelOrigem) = String.Format("{0}", String.Empty)

                'objBDExcel.mtdInserirDados(strPlanilhaExcelSap_R3, dados)
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, False)

                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal)
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
                blnSucessoExportarPlanilhaExcelSap_R3 = True

                intLinha += 1
                System.Threading.Thread.Sleep(1)
            End While

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(strNomeArquivoExportarPlanilhaExcelSap_R3)

            intProgresso = 100
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnSucessoExportarPlanilhaExcelSap_R3 = False

            objBDPrincipal.Dispose()
            objBDExcel.Dispose()
        End Sub

        Private Sub mtdExportarPlanilhaExcelSap_R3Bens()
            'mtdRenomearDeletarPlanilhasExcelSap_R3(strNomeArquivoExportarPlanilhaExcelSap_R3)

            Dim campos As String()() = New String(vetCamposTabelaExportacaoMassaExcel.GetLength(0) - 1)() {}

            For contador As Integer = 0 To vetCamposTabelaExportacaoMassaExcel.GetLength(0) - 1 Step 1
                campos(contador) = New String() {vetCamposTabelaExportacaoMassaExcel(contador), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDPrincipal.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            objBDPrincipal.mtdSelecionarDados(frmBens.vetCamposTabelaBens, strTabelaPrincipal, strCampo, "LIKE", String.Format("'{0}'", strDado), strCampo, True)
            Dim intNumeroLinhasPrincipal As Integer = objBDPrincipal.mtdNumeroLinhas()
            objBDPrincipal.mtdDefinirLeitorDados()
            Dim intNumeroColunasPrincipal As Integer = objBDPrincipal.mtdNumeroColunas()

            Dim objBDExcel As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, strNomeArquivoExportarPlanilhaExcelSap_R3)
            'objBDExcel.mtdCriarBancoDadosExcel()
            'objBDExcel.mtdCriarTabela(strPlanilhaExcelSap_R3, campos)
            'objBDExcel.mtdSelecionarDados(vetCamposTabelaExportacaoMassaExcel, strPlanilhaExcelSap_R3)
            'objBDExcel.mtdDefinirLeitorDados()

            Dim dados()() As String = New String(1)() {}
            'dados(0) = objBDExcel.mtdObterCabecalhoColunas()
            dados(0) = New String(vetCamposTabelaExportacaoMassaExcel.Length - 1) {}
            dados(1) = New String(vetCamposTabelaExportacaoMassaExcel.GetUpperBound(0)) {}

            For contador As Integer = 0 To dados(0).Length() - 1 Step 1
                'dados(0)(contador) = String.Format("{0}", dados(0)(contador))
                dados(0)(contador) = String.Format("{0}", campos(contador)(0))
                System.Threading.Thread.Sleep(1)
            Next

            Dim intLinha As Integer = 0

            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnSucessoExportarPlanilhaExcelSap_R3 = False

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(strTabelaPrincipal)
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados)
            intLinha += 1

            While (objBDPrincipal.mtdProximoRegistro())
                Dim dtDataInventario As DateTime = DirectCast(System.DateTime.Now, System.DateTime)
                'Dim dtDataInventario As DateTime = DirectCast(objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensData_Inventario), System.DateTime)
                Dim strDenominacao As String = System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensDenominacao))
                Dim strDenominacaoExtra As String = String.Empty
                If strDenominacao.Length() > 50 Then
                    strDenominacaoExtra = strDenominacao.Substring(intNumeroCaracteresPorCampoSap_R3)
                    strDenominacao = strDenominacao.Substring(0, intNumeroCaracteresPorCampoSap_R3)
                End If

                'strQtd = IIf(objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensQuantidade).ToString().Equals(String.Empty), "1", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensQuantidade).ToString()).ToString()

                dados(1)(intColunaTabelaExportacaoMassaExcelImobilizado) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensImobilizado))
                'dados(1)(intColunaTabelaExportacaoMassaExcelImobilizado) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelDenomin) = String.Format("{0}", strDenominacao)
                dados(1)(intColunaTabelaExportacaoMassaExcelDenomin_Extra) = String.Format("{0}", strDenominacaoExtra)
                dados(1)(intColunaTabelaExportacaoMassaExcelSerie) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensN_Serie))
                dados(1)(intColunaTabelaExportacaoMassaExcelPatrimonio) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensPatrimonio))
                dados(1)(intColunaTabelaExportacaoMassaExcelQtd) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUn) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUlt_invent) = String.Format("{0}", String.Format("{0:00}{1:00}{2:0000}", dtDataInventario.Day, dtDataInventario.Month, dtDataInventario.Year))
                dados(1)(intColunaTabelaExportacaoMassaExcelNt_Invent) = String.Format("{0}", String.Format("IN_{0}_{1}_{2}", System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day))
                dados(1)(intColunaTabelaExportacaoMassaExcelAtiv) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelCc) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensCentro_Custo))
                dados(1)(intColunaTabelaExportacaoMassaExcelCcR) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensCentro_Custo))
                dados(1)(intColunaTabelaExportacaoMassaExcelCen_Dep) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelEnder) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelSala) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensSala))
                dados(1)(intColunaTabelaExportacaoMassaExcelMatr) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmBens.intColunaTabelaBensMatricula))
                dados(1)(intColunaTabelaExportacaoMassaExcelUc) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUar) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelOdi) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelTp) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelLocal) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelGener) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelFornec) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelDoc_Aquis) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelCD) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelOrigem) = String.Format("{0}", String.Empty)

                'objBDExcel.mtdInserirDados(strPlanilhaExcelSap_R3, dados)
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, False)

                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal)
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
                blnSucessoExportarPlanilhaExcelSap_R3 = True

                intLinha += 1
                System.Threading.Thread.Sleep(1)
            End While

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(strNomeArquivoExportarPlanilhaExcelSap_R3)

            intProgresso = 100
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnSucessoExportarPlanilhaExcelSap_R3 = False

            objBDPrincipal.Dispose()
            objBDExcel.Dispose()
        End Sub

        Private Sub mtdExportarPlanilhaExcelSap_R3InventarioBens()
            'mtdRenomearDeletarPlanilhasExcelSap_R3(strNomeArquivoExportarPlanilhaExcelSap_R3)

            Dim campos As String()() = New String(vetCamposTabelaExportacaoMassaExcel.GetLength(0) - 1)() {}

            For contador As Integer = 0 To vetCamposTabelaExportacaoMassaExcel.GetLength(0) - 1 Step 1
                campos(contador) = New String() {vetCamposTabelaExportacaoMassaExcel(contador), "CHAR", "255", String.Empty}
                System.Threading.Thread.Sleep(1)
            Next

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDPrincipal.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            objBDPrincipal.mtdSelecionarDados(frmInventarioBens.vetCamposTabelaInventarioBens, strTabelaPrincipal, strCampo, "LIKE", String.Format("'{0}'", strDado), strCampo, True)
            Dim intNumeroLinhasPrincipal As Integer = objBDPrincipal.mtdNumeroLinhas()
            objBDPrincipal.mtdDefinirLeitorDados()
            Dim intNumeroColunasPrincipal As Integer = objBDPrincipal.mtdNumeroColunas()

            Dim objBDExcel As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()

            objBDExcel.mtdDefinirStringConexaoExcel(clsConexaoBancoDados.TipoConexao.ConexaoExcel2003OleDb, strNomeArquivoExportarPlanilhaExcelSap_R3)
            'objBDExcel.mtdCriarBancoDadosExcel()
            'objBDExcel.mtdCriarTabela(strPlanilhaExcelSap_R3, campos)
            'objBDExcel.mtdSelecionarDados(vetCamposTabelaExportacaoMassaExcel, strPlanilhaExcelSap_R3)
            'objBDExcel.mtdDefinirLeitorDados()

            Dim dados()() As String = New String(1)() {}
            'dados(0) = objBDExcel.mtdObterCabecalhoColunas()
            dados(0) = New String(vetCamposTabelaExportacaoMassaExcel.Length - 1) {}
            dados(1) = New String(vetCamposTabelaExportacaoMassaExcel.GetUpperBound(0)) {}

            For contador As Integer = 0 To dados(0).Length() - 1 Step 1
                'dados(0)(contador) = String.Format("{0}", dados(0)(contador))
                dados(0)(contador) = String.Format("{0}", campos(contador)(0))
                System.Threading.Thread.Sleep(1)
            Next

            Dim intLinha As Integer = 1

            intProgresso = 0
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnSucessoExportarPlanilhaExcelSap_R3 = False

            objBDExcel.mtdAbrirInserirPlanilhaExcel_Otimizado(strTabelaPrincipal)
            objBDExcel.mtdCabecalhoInserirPlanilhaExcel_Otimizado(dados)
            intLinha += 1

            While (objBDPrincipal.mtdProximoRegistro())
                Dim dtDataInventario As DateTime = DirectCast(objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensData_Inventario), System.DateTime)
                Dim strDenominacao As String = objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensDenominacao).ToString()
                Dim strDenominacaoExtra As String = String.Empty
                If strDenominacao.Length() > 50 Then
                    strDenominacaoExtra = strDenominacao.Substring(intNumeroCaracteresPorCampoSap_R3)
                    strDenominacao = strDenominacao.Substring(0, intNumeroCaracteresPorCampoSap_R3)
                End If

                strQtd = IIf(objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensQuantidade).ToString().Equals(String.Empty), "1", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensQuantidade).ToString()).ToString()

                dados(1)(intColunaTabelaExportacaoMassaExcelImobilizado) = String.Format("{0}", mtdObterImobilizadoBens(objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensPatrimonio).ToString()))
                'dados(1)(intColunaTabelaExportacaoMassaExcelImobilizado) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelDenomin) = String.Format("{0}", strDenominacao)
                dados(1)(intColunaTabelaExportacaoMassaExcelDenomin_Extra) = String.Format("{0}", strDenominacaoExtra)
                dados(1)(intColunaTabelaExportacaoMassaExcelSerie) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensN_Serie).ToString())
                dados(1)(intColunaTabelaExportacaoMassaExcelPatrimonio) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensPatrimonio).ToString())
                dados(1)(intColunaTabelaExportacaoMassaExcelQtd) = String.Format("{0}", strQtd)
                dados(1)(intColunaTabelaExportacaoMassaExcelUn) = String.Format("{0}", strUn)
                dados(1)(intColunaTabelaExportacaoMassaExcelUlt_invent) = String.Format("{0}", String.Format("{0:00}{1:00}{2:0000}", dtDataInventario.Day, dtDataInventario.Month, dtDataInventario.Year))
                dados(1)(intColunaTabelaExportacaoMassaExcelNt_Invent) = String.Format("{0}", String.Format("IN_{0}", objBDPrincipal.mtdObterValorRegistro(0)))
                dados(1)(intColunaTabelaExportacaoMassaExcelAtiv) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelCc) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensCentroCusto).ToString())
                dados(1)(intColunaTabelaExportacaoMassaExcelCcR) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensCentroCusto).ToString())
                dados(1)(intColunaTabelaExportacaoMassaExcelCen_Dep) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelEnder) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelSala) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensSala).ToString())
                dados(1)(intColunaTabelaExportacaoMassaExcelMatr) = String.Format("{0}", objBDPrincipal.mtdObterValorRegistro(frmInventarioBens.intColunaTabelaInventarioBensMatricula).ToString())
                dados(1)(intColunaTabelaExportacaoMassaExcelUc) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelUar) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelOdi) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelTp) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelLocal) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelGener) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelFornec) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelDoc_Aquis) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelCD) = String.Format("{0}", String.Empty)
                dados(1)(intColunaTabelaExportacaoMassaExcelOrigem) = String.Format("{0}", String.Empty)

                'objBDExcel.mtdInserirDados(strPlanilhaExcelSap_R3, dados)
                objBDExcel.mtdDadosInserirPlanilhaExcel_Otimizado(dados, False)

                intProgresso = mtdProgresso(intLinha, intNumeroLinhasPrincipal)
                strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
                blnSucessoExportarPlanilhaExcelSap_R3 = True

                intLinha += 1
                System.Threading.Thread.Sleep(1)
            End While

            objBDExcel.mtdFecharInserirPlanilhaExcel_Otimizado(strNomeArquivoExportarPlanilhaExcelSap_R3)

            intProgresso = 100
            strNomeProcesso = strNomeProcessoExportarPlanilhaExcelSap_R3
            blnSucessoExportarPlanilhaExcelSap_R3 = False

            objBDPrincipal.Dispose()
            objBDExcel.Dispose()
        End Sub

        Public Function mtdObterListaDadosTabela(ByVal Tabela As String, ByVal CampoSelecionador As String, ByVal DadoSelecionador As String) As List(Of String)
            Dim saida As List(Of String) = New List(Of String)
            Dim strTabela As String = Tabela
            Dim strCampos As String = "*"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            objImplementacaoBancoDados.mtdSelecionarDados( _
                String.Format("{0}", strCampos), _
                strTabela, _
                CampoSelecionador, _
                "LIKE", _
                String.Format("'{0}'", DadoSelecionador), _
                CampoSelecionador, _
                False)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()

            Dim intColuna As Integer = objImplementacaoBancoDados.mtdNumeroColunas()
            If (objImplementacaoBancoDados.mtdProximoRegistro()) Then
                For contador As Integer = 0 To intColuna - 1 Step 1
                    saida.Add(objImplementacaoBancoDados.mtdObterValorRegistro(contador).ToString())
                Next
            End If

            objImplementacaoBancoDados.Dispose()

            Return saida
        End Function

        Public Function mtdObterCentroCustoOrgao(ByVal Orgao As String) As Integer
            Dim saida As Integer = 0
            Dim strTabela As String = "tblCentroCusto"
            Dim strCampo As String = "CentroCusto"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            objImplementacaoBancoDados.mtdSelecionarDados( _
                String.Format("{0}, {1}", strCampo, "Orgao"), _
                strTabela, _
                "Orgao", _
                "LIKE", _
                String.Format("'{0}'", Orgao), _
                strCampo, _
                False)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()

            If (objImplementacaoBancoDados.mtdProximoRegistro()) Then
                Dim intColuna As Integer = objImplementacaoBancoDados.mtdObterNumeroColuna(strCampo)
                saida = System.Convert.ToInt32(objImplementacaoBancoDados.mtdObterValorRegistro(intColuna))
            End If

            objImplementacaoBancoDados.Dispose()

            Return saida
        End Function

        Public Function mtdObterImobilizadoBens(ByVal Patrimonio As String) As String
            Dim saida As String = String.Empty
            Dim strTabela As String = "tblBensEletronorte"
            Dim strCampo As String = "Imobilizado"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, strConexaoBancoDadosPrincipal)
            objImplementacaoBancoDados.mtdSelecionarDados( _
                String.Format("{0}, {1}", strCampo, "Patrimonio"), _
                strTabela, _
                "Patrimonio", _
                "LIKE", _
                String.Format("{0}", Patrimonio), _
                strCampo, _
                False)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()

            If (objImplementacaoBancoDados.mtdProximoRegistro()) Then
                Dim intColuna As Integer = objImplementacaoBancoDados.mtdObterNumeroColuna(strCampo)
                saida = objImplementacaoBancoDados.mtdObterValorRegistro(intColuna).ToString()
            End If

            objImplementacaoBancoDados.Dispose()

            Return saida
        End Function
    End Class
End Namespace