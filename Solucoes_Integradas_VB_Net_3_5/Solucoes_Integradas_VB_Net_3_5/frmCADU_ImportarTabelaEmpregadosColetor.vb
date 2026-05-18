Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmCADU
        Private ThImportarTabelaEmpregadosColetor As System.Threading.Thread

        Private strNomeProcessoImportarTabelaEmpregadosColetor As String = "Importar Tabela de Empregados - Coletor"

        Friend Sub mtdIniciarThreadImportarTabelaEmpregadosColetor()
            mtdIniciarThreadImportarTabelaEmpregadosColetor(True)
        End Sub

        Friend Sub mtdIniciarThreadImportarTabelaEmpregadosColetor(ByVal Iniciar As Boolean)
            Try
                [NewValue] = 0
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosColetor
                blnAbortarThreadImportarTabelaEmpregadosColetor = Not Iniciar
                blnForcarAbortarThreadImportarTabelaEmpregadosColetor = False
                blnThreadAtivadaImportarTabelaEmpregadosColetor = True
                blnSucessoImportarTabelaEmpregadosColetor = False
                ThImportarTabelaEmpregadosColetor = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadImportarTabelaEmpregadosColetor))
                ThImportarTabelaEmpregadosColetor.IsBackground = True
                ThImportarTabelaEmpregadosColetor.Priority = System.Threading.ThreadPriority.Normal
                ThImportarTabelaEmpregadosColetor.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadImportarTabelaEmpregadosColetor: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadImportarTabelaEmpregadosColetor()
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosColetor
            blnAbortarThreadImportarTabelaEmpregadosColetor = False
            blnForcarAbortarThreadImportarTabelaEmpregadosColetor = False

            blnThreadAtivadaImportarTabelaEmpregadosColetor = True
            blnSucessoImportarTabelaEmpregadosColetor = False
        End Sub

        Private Shared blnForcarAbortarThreadImportarTabelaEmpregadosColetor As Boolean = False
        Private Shared blnAbortarThreadImportarTabelaEmpregadosColetor As Boolean = False
        Private Shared intTempoSaidaAbortarThreadImportarTabelaEmpregadosColetor As Integer = 1000

        Friend Sub mtdAbortarThreadImportarTabelaEmpregadosColetor()
            mtdAbortarThreadImportarTabelaEmpregadosColetor(False)
        End Sub

        Friend Sub mtdAbortarThreadImportarTabelaEmpregadosColetor(ByVal Forcar As Boolean)
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosColetor
            blnAbortarThreadImportarTabelaEmpregadosColetor = True
            blnForcarAbortarThreadImportarTabelaEmpregadosColetor = Forcar

            blnThreadAtivadaImportarTabelaEmpregadosColetor = False
            blnSucessoImportarTabelaEmpregadosColetor = False

            Try
                ThImportarTabelaEmpregadosColetor.Join(intTempoSaidaAbortarThreadImportarTabelaEmpregadosColetor)
                ThImportarTabelaEmpregadosColetor.Abort()
                ThImportarTabelaEmpregadosColetor = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadImportarTabelaEmpregadosColetor: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadImportarTabelaEmpregadosColetor()
            [NewValue] = 100
            System.Threading.Thread.Sleep(1)
            [NewValue] = 0
            frmPrincipal.intProgresso = [NewValue]
            frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosColetor
            blnAbortarThreadImportarTabelaEmpregadosColetor = True
            blnForcarAbortarThreadImportarTabelaEmpregadosColetor = True

            blnThreadAtivadaImportarTabelaEmpregadosColetor = False
            blnSucessoImportarTabelaEmpregadosColetor = False
        End Sub

        Private Shared LockerImportarTabelaEmpregadosColetor As New Object()

        Private Sub mtdRotinaThreadImportarTabelaEmpregadosColetor()
            While Not blnForcarAbortarThreadImportarTabelaEmpregadosColetor
                If Not blnAbortarThreadImportarTabelaEmpregadosColetor Then
                    'System.Threading.Monitor.Enter(LockerImportarTabelaEmpregadosColetor)
                    SyncLock (LockerImportarTabelaEmpregadosColetor)
                        Try
                            mtdImportarTabelaEmpregadosColetor _
                            ( _
                            blnComandoImplementadoDeletarDadosTabelaEmpregadosColetor, _
                            blnComandoImplementadoInserirDadosTabelaEmpregadosColetor _
                            )
                            mtdAbortarThreadImportarTabelaEmpregadosColetor(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerImportarTabelaEmpregadosColetor)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaImportarTabelaEmpregadosColetor As Boolean = False
        Friend blnSucessoImportarTabelaEmpregadosColetor As Boolean = False

        Private lngCodigoImportarTabelaEmpregadosColetor As Long = 0

        Protected Friend Sub mtdImportarTabelaEmpregadosColetor()
            mtdImportarTabelaEmpregadosColetor(True, True)
        End Sub

        Protected Friend Sub mtdImportarTabelaEmpregadosColetor(ByVal Deletar As Boolean, ByVal Inserir As Boolean)
            'Dim isWatching As Boolean = frmPrincipal.m_bIsWatching

            'If isWatching Then
            '    frmPrincipal.mtdMonitorarDiretorioArquivo()
            'End If
            blnComandoImplementadoDeletarDadosTabelaEmpregadosColetor = Deletar
            blnComandoImplementadoInserirDadosTabelaEmpregadosColetor = Inserir
            If Deletar Then
                mtdDeletarTabelaEmpregadosColetor()
                mtdDeletarDadosTabelaEmpregadosColetor()
            End If
            mtdCriarBancoDadosColetor()
            mtdCriarTabelaEmpregadosColetor()
            If Inserir Then
                mtdInserirDadosTabelaEmpregadosColetor()
            End If

            'If isWatching Then
            '    frmPrincipal.mtdMonitorarDiretorioArquivo()
            'End If
        End Sub

        Private intcolunaColetor As Integer = 0

        Private camposColetor As String()()

        Public blnComandoImplementadoDeletarDadosTabelaEmpregadosColetor As Boolean = True

        Public Sub mtdDeletarTabelaEmpregadosColetor()
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosColetor, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            objBDColetor.mtdDeletarTabela(strNomeTabelaColetor)
            objBDColetor.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaEmpregadosColetor()
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosColetor, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            objBDColetor.mtdDeletarDados(strNomeTabelaColetor, strColunaPrincipal, "LIKE", "'%'")
            objBDColetor.Dispose()
        End Sub

        Public Sub mtdCriarBancoDadosColetor()
            frmPrincipal.mtdCriarBancoDadosColetor(False)
        End Sub

        Public blnComandoImplementadoPermitirMensagemTabelaEmpregadosColetor As Boolean = True

        Public Sub mtdCriarTabelaEmpregadosColetor()
            Try
                Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosColetor, _
                                            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)
                Dim objBancoDadosCADU As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosCADU, _
                                                                               clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServer)

                objBDColetor.prpConexao = frmPrincipal.strConexaoBancoDadosColetor
                objBDColetor.prpTipoSistemaGerenciadorBancoDadosRelacional = clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
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
                Next

                campos(0) = New String(3) {vetColunasCADU(0), mtdIdentificarTipoColetor(vetTipoColunasCADU(intColunaTabelaEmpregadosNome)), _
                                           mtdIdentificarTamanhoTipo(vetTipoColunasCADU(intColunaTabelaEmpregadosNome)), _
                                           String.Empty}
                For contador As Integer = 1 To intNumeroColunasCADU Step 1
                    Select Case contador
                        Case intColunaTabelaEmpregadosMatricula
                            campos(contador) = New String(3) {vetColunasCADU(contador), _
                                                              mtdIdentificarTipoColetor(vetTipoColunasCADU(contador)), _
                                                              mtdIdentificarTamanhoTipo(vetTipoColunasCADU(contador)), _
                                                              String.Format("CONSTRAINT PrimaryKey{0} PRIMARY KEY", vetColunasCADU(contador))}
                        Case Else
                            campos(contador) = New String(3) {vetColunasCADU(contador), _
                                      mtdIdentificarTipoColetor(vetTipoColunasCADU(contador)), _
                                      mtdIdentificarTamanhoTipo(vetTipoColunasCADU(contador)), _
                                      String.Empty}
                    End Select
                Next

                objBDColetor.mtdCriarTabela(strNomeTabelaColetor, campos)

                objBancoDadosCADU.Dispose()
                objBDColetor.Dispose()
            Catch ex As Exception
                Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosColetor, _
                             clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

                intcolunaColetor = 8

                camposColetor = New String(intcolunaColetor)() {}
                camposColetor(0) = New String(3) {"Nome", "NVARCHAR", "255", String.Empty}
                camposColetor(1) = New String(3) {"Matricula", "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyMatricula PRIMARY KEY"}
                camposColetor(2) = New String(3) {"Orgao", "NVARCHAR", "255", String.Empty}
                camposColetor(3) = New String(3) {"DDDDRR", "NVARCHAR", "255", String.Empty}
                camposColetor(4) = New String(3) {"Telefone", "NVARCHAR", "255", String.Empty}
                camposColetor(5) = New String(3) {"Endereco", "NVARCHAR", "255", String.Empty}
                camposColetor(6) = New String(3) {"Email", "NVARCHAR", "255", String.Empty}
                camposColetor(7) = New String(3) {"Conta", "NVARCHAR", "255", String.Empty}
                camposColetor(8) = New String(3) {"Funcao", "NVARCHAR", "255", String.Empty}

                objBDColetor.mtdCriarTabela(strNomeTabelaColetor, camposColetor)
                objBDColetor.Dispose()

                If blnComandoImplementadoPermitirMensagemTabelaEmpregadosColetor Then
                    System.Windows.Forms.MessageBox.Show("Verifique se as configurações do SQL Server estão corretas.", "Alerta!", MessageBoxButtons.OK)
                End If
            End Try
        End Sub

        Public blnComandoImplementadoInserirDadosTabelaEmpregadosColetor As Boolean = True

        Private Sub mtdInserirDadosTabelaEmpregadosColetor()
            Try
                Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                                strConexaoBancoDadosColetor, _
                                                                                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)
                Dim objBancoDadosCADU As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                           strConexaoBancoDadosCADU, _
                                                                           clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServer)

                [NewValue] = 0
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosColetor
                blnSucessoImportarTabelaEmpregadosColetor = True

                Dim dados As String()() = New String(1)() {}
                objBancoDadosCADU.mtdSelecionarDados("*", strNomeTabelaCADU)
                intNumeroLinhasCADU = objBancoDadosCADU.mtdNumeroLinhas()
                objBancoDadosCADU.mtdDefinirLeitorDados()
                objBancoDadosCADU.mtdProximoRegistro()
                intNumeroColunasCADU = objBancoDadosCADU.mtdNumeroColunas() - 1
                objBDColetor.mtdSelecionarDados("*", strNomeTabelaColetor)
                objBDColetor.mtdDefinirLeitorDados()
                dados(0) = objBDColetor.mtdObterCabecalhoColunas()
                dados(1) = New String(intNumeroColunasCADU) {}
                For linha As Integer = 0 To intNumeroLinhasCADU Step 1
                    If blnAbortarThreadImportarTabelaEmpregadosColetor And blnForcarAbortarThreadImportarTabelaEmpregadosColetor Then
                        GoTo SaidaInserirDadosTabelaEmpregadosColetor
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
                    objBDColetor.mtdInserirDados(strNomeTabelaColetor, dados)
                    objBancoDadosCADU.mtdProximoRegistro()
                    [NewValue] = Convert.ToInt32((linha / intNumeroLinhasCADU) * 100)
                    Try
                        Me.BeginInvoke(f, New Object() {[NewValue]})
                    Catch ex As Exception
                    End Try
                    frmPrincipal.intProgresso = [NewValue]
                    frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosColetor
                    blnSucessoImportarTabelaEmpregadosColetor = True
                    System.Threading.Thread.Sleep(1)
                Next
SaidaInserirDadosTabelaEmpregadosColetor:
                [NewValue] = 100
                Try
                    Me.BeginInvoke(f, New Object() {[NewValue]})
                Catch ex As Exception
                End Try
                frmPrincipal.intProgresso = [NewValue]
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosColetor
                blnSucessoImportarTabelaEmpregadosColetor = True
                objBDColetor.Dispose()
                objBancoDadosCADU.Dispose()
                If blnComandoImplementadoPermitirMensagemTabelaEmpregadosColetor Then
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
                frmPrincipal.strNomeProcesso = strNomeProcessoImportarTabelaEmpregadosColetor
                blnSucessoImportarTabelaEmpregadosColetor = False
            End Try
        End Sub
    End Class
End Namespace