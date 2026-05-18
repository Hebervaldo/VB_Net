Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmCADU
        Private ThImportarTabelaEmpregadosPrincipal As System.Threading.Thread

        Private strNomeProcessoImportarTabelaEmpregadosPrincipal As String = "Importar Tabela de Empregados - Principal"

        Friend Sub mtdIniciarThreadImportarTabelaEmpregadosPrincipal()
            mtdIniciarThreadImportarTabelaEmpregadosPrincipal(True)
        End Sub

        Friend Sub mtdIniciarThreadImportarTabelaEmpregadosPrincipal(ByVal Iniciar As Boolean)
            Try
                [NewValue] = 0
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosPrincipal
                blnAbortarThreadImportarTabelaEmpregadosPrincipal = Not Iniciar
                blnForcarAbortarThreadImportarTabelaEmpregadosPrincipal = False
                blnThreadAtivadaImportarTabelaEmpregadosPrincipal = True
                blnSucessoImportarTabelaEmpregadosPrincipal = False
                ThImportarTabelaEmpregadosPrincipal = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImportarTabelaEmpregadosPrincipal))
                ThImportarTabelaEmpregadosPrincipal.IsBackground = True
                ThImportarTabelaEmpregadosPrincipal.Priority = System.Threading.ThreadPriority.Normal
                ThImportarTabelaEmpregadosPrincipal.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImportarTabelaEmpregadosPrincipal: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImportarTabelaEmpregadosPrincipal()
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosPrincipal
            blnAbortarThreadImportarTabelaEmpregadosPrincipal = False
            blnForcarAbortarThreadImportarTabelaEmpregadosPrincipal = False

            blnThreadAtivadaImportarTabelaEmpregadosPrincipal = True
            blnSucessoImportarTabelaEmpregadosPrincipal = False
        End Sub

        Private Shared blnForcarAbortarThreadImportarTabelaEmpregadosPrincipal As Boolean = False
        Private Shared blnAbortarThreadImportarTabelaEmpregadosPrincipal As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImportarTabelaEmpregadosPrincipal As Integer = 1000

        Friend Sub mtdAbortarThreadImportarTabelaEmpregadosPrincipal()
            mtdAbortarThreadImportarTabelaEmpregadosPrincipal(False)
        End Sub

        Friend Sub mtdAbortarThreadImportarTabelaEmpregadosPrincipal(ByVal Forcar As Boolean)
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosPrincipal
            blnAbortarThreadImportarTabelaEmpregadosPrincipal = True
            blnForcarAbortarThreadImportarTabelaEmpregadosPrincipal = Forcar

            blnThreadAtivadaImportarTabelaEmpregadosPrincipal = False
            blnSucessoImportarTabelaEmpregadosPrincipal = False

            Try
                ThImportarTabelaEmpregadosPrincipal.Join(intTempoSaidaAbortarThreadImportarTabelaEmpregadosPrincipal)
                ThImportarTabelaEmpregadosPrincipal.Abort()
                ThImportarTabelaEmpregadosPrincipal = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImportarTabelaEmpregadosPrincipal: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImportarTabelaEmpregadosPrincipal()
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosPrincipal
            blnAbortarThreadImportarTabelaEmpregadosPrincipal = True
            blnForcarAbortarThreadImportarTabelaEmpregadosPrincipal = True

            blnThreadAtivadaImportarTabelaEmpregadosPrincipal = False
            blnSucessoImportarTabelaEmpregadosPrincipal = False
        End Sub

        Private Shared LockerImportarTabelaEmpregadosPrincipal As New Object()

        Private Sub mtdRotinaThreadImportarTabelaEmpregadosPrincipal()
            While Not blnForcarAbortarThreadImportarTabelaEmpregadosPrincipal
                If Not blnAbortarThreadImportarTabelaEmpregadosPrincipal Then
                    'System.Threading.Monitor.Enter(LockerImportarTabelaEmpregadosPrincipal)
                    SyncLock (LockerImportarTabelaEmpregadosPrincipal)
                        Try
                            mtdImportarTabelaEmpregadosPrincipal _
                            ( _
                            blnComandoImplementadoDeletarDadosTabelaEmpregadosPrincipal, _
                            blnComandoImplementadoInserirDadosTabelaEmpregadosPrincipal _
                            )
                            mtdAbortarThreadImportarTabelaEmpregadosPrincipal(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImportarTabelaEmpregadosPrincipal)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImportarTabelaEmpregadosPrincipal As Boolean = False
        Friend blnSucessoImportarTabelaEmpregadosPrincipal As Boolean = False

        Private lngCodigoImportarTabelaEmpregadosPrincipal As Long = 0

        Protected Friend Sub mtdImportarTabelaEmpregadosPrincipal()
            mtdImportarTabelaEmpregadosPrincipal(True, True)
        End Sub

        Protected Friend Sub mtdImportarTabelaEmpregadosPrincipal(ByVal Deletar As Boolean, ByVal Inserir As Boolean)
            blnComandoImplementadoDeletarDadosTabelaEmpregadosPrincipal = Deletar
            blnComandoImplementadoInserirDadosTabelaEmpregadosPrincipal = Inserir
            If Deletar Then
                mtdDeletarTabelaEmpregadosPrincipal()
                mtdDeletarDadosTabelaEmpregadosPrincipal()
            End If
            mtdCriarTabelaEmpregadosPrincipal()
            If Inserir Then
                mtdInserirDadosTabelaEmpregadosPrincipal()
            End If
        End Sub

        Private intcolunaPrincipal As Integer = 0

        Private camposPrincipal As String()()

        Public blnComandoImplementadoDeletarDadosTabelaEmpregadosPrincipal As Boolean = True

        Public Sub mtdDeletarTabelaEmpregadosPrincipal()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdDeletarTabela(strNomeTabelaPrincipal)
            objBDPrincipal.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaEmpregadosPrincipal()
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdDeletarDados(strNomeTabelaPrincipal, strColunaPrincipal, "LIKE", "'%'")
            objBDPrincipal.Dispose()
        End Sub

        Public blnComandoImplementadoPermitirMensagemTabelaEmpregadosPrincipal As Boolean = True

        Public Sub mtdCriarTabelaEmpregadosPrincipal()
            Try
                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                        strConexaoBancoDadosPrincipal, _
                                                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                Dim objBancoDadosCADU As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                           strConexaoBancoDadosCADU, _
                                                                           clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServer)

                objBDPrincipal.prpConexao = frmPrincipal.strConexaoBancoDadosPrincipal
                objBDPrincipal.prpTipoSistemaGerenciadorBancoDadosRelacional = clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                objBancoDadosCADU.prpConexao = frmPrincipal.strConexaoBancoDadosCADU
                objBancoDadosCADU.prpTipoSistemaGerenciadorBancoDadosRelacional = clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                objBancoDadosCADU.mtdSelecionarDados("*", strNomeTabelaCADU)
                intNumeroLinhasCADU = objBancoDadosCADU.mtdNumeroLinhas()
                objBancoDadosCADU.mtdDefinirLeitorDados()
                Dim vetColunasCADU As String() = objBancoDadosCADU.mtdObterCabecalhoColunas()
                intNumeroColunasCADU = objBancoDadosCADU.mtdNumeroColunas() - 1
                Dim campos As String()() = New String(intNumeroColunasCADU)() {}

                ' A rotina abaixo gera uma tabela com as colunas e tipos de outra tabela
                vetTipoColunasCADU = New String(intNumeroColunasCADU) {}
                objBancoDadosCADU.mtdProximoRegistro()
                For contador As Integer = 0 To intNumeroColunasCADU Step 1
                    vetTipoColunasCADU(contador) = objBancoDadosCADU.mtdObterTipoRegistro(contador)
                    System.Threading.Thread.Sleep(1)
                Next

                campos(intColunaTabelaEmpregadosNome) = New String(3) {vetColunasCADU(intColunaTabelaEmpregadosNome), mtdIdentificarTipoPrincipal(vetTipoColunasCADU(intColunaTabelaEmpregadosNome)), _
                                           mtdIdentificarTamanhoTipo(vetTipoColunasCADU(intColunaTabelaEmpregadosNome)), _
                                           String.Empty}
                For contador As Integer = 1 To intNumeroColunasCADU Step 1
                    Select Case (contador)
                        Case intColunaTabelaEmpregadosMatricula
                            campos(contador) = New String(3) {vetColunasCADU(contador), _
                                                              mtdIdentificarTipoPrincipal(vetTipoColunasCADU(contador)), _
                                                              mtdIdentificarTamanhoTipo(vetTipoColunasCADU(contador)), _
                                                              String.Format("CONSTRAINT primarykey{0} PRIMARY KEY", vetColunasCADU(contador))}
                        Case Else
                            campos(contador) = New String(3) {vetColunasCADU(contador), _
                                      mtdIdentificarTipoPrincipal(vetTipoColunasCADU(contador)), _
                                      mtdIdentificarTamanhoTipo(vetTipoColunasCADU(contador)), _
                                      String.Empty}
                    End Select
                    System.Threading.Thread.Sleep(1)
                Next

                objBDPrincipal.mtdCriarTabela(strNomeTabelaPrincipal, campos)

                objBancoDadosCADU.Dispose()
                objBDPrincipal.Dispose()
            Catch ex As Exception
                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                                   clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                intcolunaPrincipal = 8

                camposPrincipal = New String(intcolunaPrincipal)() {}
                camposPrincipal(0) = New String(3) {"Nome", "TEXT", "255", String.Empty}
                camposPrincipal(1) = New String(3) {"Matricula", "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyMatricula PRIMARY KEY"}
                camposPrincipal(2) = New String(3) {"Orgao", "TEXT", "255", String.Empty}
                camposPrincipal(3) = New String(3) {"DDDDRR", "TEXT", "255", String.Empty}
                camposPrincipal(4) = New String(3) {"Telefone", "TEXT", "255", String.Empty}
                camposPrincipal(5) = New String(3) {"Endereco", "TEXT", "255", String.Empty}
                camposPrincipal(6) = New String(3) {"Email", "TEXT", "255", String.Empty}
                camposPrincipal(7) = New String(3) {"Conta", "TEXT", "255", String.Empty}
                camposPrincipal(8) = New String(3) {"Funcao", "TEXT", "255", String.Empty}

                objBDPrincipal.mtdCriarTabela(strNomeTabelaPrincipal, camposPrincipal)
                objBDPrincipal.Dispose()

                If blnComandoImplementadoPermitirMensagemTabelaEmpregadosPrincipal Then
                    System.Windows.Forms.MessageBox.Show("Verifique se as configurações do SQL Server estão corretas.", "Alerta!", MessageBoxButtons.OK)
                End If
            End Try
        End Sub

        Public blnComandoImplementadoInserirDadosTabelaEmpregadosPrincipal As Boolean = True

        Private Sub mtdInserirDadosTabelaEmpregadosPrincipal()
            Try
                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                        strConexaoBancoDadosPrincipal, _
                                                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                Dim objBancoDadosCADU As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                           strConexaoBancoDadosCADU, _
                                                                           clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServer)

                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosPrincipal
                blnSucessoImportarTabelaEmpregadosPrincipal = True

                Dim dados As String()() = New String(1)() {}
                objBancoDadosCADU.mtdSelecionarDados("*", strNomeTabelaCADU)
                intNumeroLinhasCADU = objBancoDadosCADU.mtdNumeroLinhas()
                objBancoDadosCADU.mtdDefinirLeitorDados()
                objBancoDadosCADU.mtdProximoRegistro()
                intNumeroColunasCADU = objBancoDadosCADU.mtdNumeroColunas() - 1
                objBDPrincipal.mtdSelecionarDados("*", strNomeTabelaPrincipal)
                objBDPrincipal.mtdDefinirLeitorDados()
                dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()
                dados(1) = New String(intNumeroColunasCADU) {}
                For linha As Integer = 0 To intNumeroLinhasCADU Step 1
                    If blnAbortarThreadImportarTabelaEmpregadosPrincipal And blnForcarAbortarThreadImportarTabelaEmpregadosPrincipal Then
                        GoTo SaidaInserirDadosTabelaEmpregadosPrincipal
                    End If

                    'dados(linha) = New String(intNumeroColunasCADU) {}
                    For coluna As Integer = 0 To intNumeroColunasCADU Step 1
                        Dim strFormatoRegistro As String = mtdObterFormatoTipo(vetTipoColunasCADU(coluna))
                        Dim strValorRegistro As String = String.Empty
                        If coluna = intColunaTabelaEmpregadosEmail Then
                            strValorRegistro = If(Not (objBancoDadosCADU.mtdObterValorRegistro(coluna) Is Nothing), _
                                                  objBancoDadosCADU.mtdObterValorRegistro(coluna).ToString().ToLower().Trim(), String.Empty)
                        Else
                            strValorRegistro = objManipuladorTexto.mtdExecutarTudo( _
                                If(Not (objBancoDadosCADU.mtdObterValorRegistro(coluna) Is Nothing), _
                                   objBancoDadosCADU.mtdObterValorRegistro(coluna).ToString(), String.Empty))
                        End If
                        dados(1)(coluna) = String.Format(strFormatoRegistro, strValorRegistro)
                        System.Threading.Thread.Sleep(1)
                    Next
                    objBDPrincipal.mtdInserirDados(strNomeTabelaPrincipal, dados)
                    objBancoDadosCADU.mtdProximoRegistro()
                    [NewValue] = Convert.ToInt32((linha / intNumeroLinhasCADU) * 100)
                    Try
                        Me.BeginInvoke(f, New Object() {[NewValue]})
                    Catch ex As Exception
                    End Try
                    frmPrincipal.intProgresso = [NewValue]
                    frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosPrincipal
                    blnSucessoImportarTabelaEmpregadosPrincipal = True
                    System.Threading.Thread.Sleep(1)
                Next
SaidaInserirDadosTabelaEmpregadosPrincipal:
                [NewValue] = 100
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                blnSucessoImportarTabelaEmpregadosPrincipal = True
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosPrincipal
                objBDPrincipal.Dispose()
                objBancoDadosCADU.Dispose()
                If blnComandoImplementadoPermitirMensagemTabelaEmpregadosPrincipal Then
                    System.Windows.Forms.MessageBox.Show("A importação dos dados finalizou com sucesso.", "Aviso!", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, _
                                                         MessageBoxOptions.DefaultDesktopOnly)
                End If
            Catch
                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosPrincipal
                blnSucessoImportarTabelaEmpregadosPrincipal = False
            End Try
        End Sub
    End Class
End Namespace