Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmMBPs
        Private ThCriarTabelaMBP As System.Threading.Thread

        Private strNomeProcessoCriarTabelaMBP As String = "Criar Tabela de MBP"

        Friend Sub mtdIniciarThreadCriarTabelaMBP()
            mtdIniciarThreadCriarTabelaMBP(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaMBP(ByVal Iniciar As Boolean)
            Try
                'intProgresso = 0
                'strNomeProcesso = strNomeProcessoCriarTabelaMBP
                blnAbortarThreadCriarTabelaMBP = Not Iniciar
                blnForcarAbortarThreadCriarTabelaMBP = False
                blnThreadAtivadaCriarTabelaMBP = True
                blnSucessoCriarTabelaMBP = False
                ThCriarTabelaMBP = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaMBP))
                ThCriarTabelaMBP.IsBackground = True
                ThCriarTabelaMBP.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaMBP.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaMBP: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaMBP()
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaMBP
            blnAbortarThreadCriarTabelaMBP = False
            blnForcarAbortarThreadCriarTabelaMBP = False

            blnThreadAtivadaCriarTabelaMBP = True
            blnSucessoCriarTabelaMBP = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaMBP As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaMBP As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaMBP As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaMBP()
            mtdAbortarThreadCriarTabelaMBP(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaMBP(ByVal Forcar As Boolean)
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaMBP
            blnAbortarThreadCriarTabelaMBP = True
            blnForcarAbortarThreadCriarTabelaMBP = Forcar

            blnThreadAtivadaCriarTabelaMBP = False
            blnSucessoCriarTabelaMBP = False

            Try
                ThCriarTabelaMBP.Join(intTempoSaidaAbortarThreadCriarTabelaMBP)
                ThCriarTabelaMBP.Abort()
                ThCriarTabelaMBP = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaMBP: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaMBP()
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaMBP
            blnAbortarThreadCriarTabelaMBP = True
            blnForcarAbortarThreadCriarTabelaMBP = True

            blnThreadAtivadaCriarTabelaMBP = False
            blnSucessoCriarTabelaMBP = False
        End Sub

        Private Shared LockerCriarTabelaMBP As New Object()

        Private Sub mtdRotinaThreadCriarTabelaMBP()
            While Not blnForcarAbortarThreadCriarTabelaMBP
                If Not blnAbortarThreadCriarTabelaMBP Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaMBP)
                    SyncLock (LockerCriarTabelaMBP)
                        Try
                            mtdGerarTabelaMBP()
                            mtdAbortarThreadCriarTabelaMBP(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaMBP)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaMBP As Boolean = False
        Friend blnSucessoCriarTabelaMBP As Boolean = False

        Private lngCodigoCriarTabelaMBP As Long = 0

        Protected Friend Sub mtdGerarTabelaMBP()
            'mtdDeletarTabelaMBP()
            'mtdDeletarDadosTabelaMBP()
            mtdCriarTabelaMBP()
            'mtdInserirDadosTabelaMBP()
        End Sub

        Private intcolunaMBP As Integer = 0

        Public camposMBP As String()()

        Public Sub mtdDeletarTabelaMBP()
            strNomeTabelaPrincipal = strNomeTabelaMBP

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strNomeTabelaPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaMBP()
            strNomeTabelaPrincipal = strNomeTabelaMBP
            strColunaPrincipal = "Codigo"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strNomeTabelaPrincipal, strColunaPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Const intColunaTabelaMBPCodigo As Integer = 0
        Public Const intColunaTabelaMBPOrgao_Emitente As Integer = 1
        Public Const intColunaTabelaMBPSala_Emitente As Integer = 2
        Public Const intColunaTabelaMBPRamal_Emitente As Integer = 3
        Public Const intColunaTabelaMBPEmitente As Integer = 4
        Public Const intColunaTabelaMBPMatricula_Emitente As Integer = 5
        Public Const intColunaTabelaMBPOrgao_Recebedor As Integer = 6
        Public Const intColunaTabelaMBPSala_Recebedor As Integer = 7
        Public Const intColunaTabelaMBPRamal_Recebedor As Integer = 8
        Public Const intColunaTabelaMBPRecebedor As Integer = 9
        Public Const intColunaTabelaMBPMatricula_Recebedor As Integer = 10
        Public Const intColunaTabelaMBPTipo_Movimentacao As Integer = 11
        Public Const intColunaTabelaMBPPropriedade As Integer = 12
        Public Const intColunaTabelaMBPMotivacao_MBP As Integer = 13
        Public Const intColunaTabelaMBPCriado_Por_Usuario As Integer = 14
        Public Const intColunaTabelaMBPData_Criacao As Integer = 15
        Public Const intColunaTabelaMBPModificado_Por_Usuario As Integer = 16
        Public Const intColunaTabelaMBPData_Modificacao As Integer = 17
        Public Const intColunaTabelaMBPData_Impressao As Integer = 18
        Public Const intColunaTabelaMBPData_Movimentacao As Integer = 19
        Public Const intColunaTabelaMBPData_Devolucao As Integer = 20
        Public Const intColunaTabelaMBPPrazo_Emprestimo As Integer = 21
        Public Const intColunaTabelaMBPObservacoes As Integer = 22

        Public Shared ReadOnly vetCamposTabelaMBP As String() = { _
                                                "Codigo", _
                                                "Orgao_Emitente", _
                                                "Sala_Emitente", _
                                                "Ramal_Emitente", _
                                                "Emitente", _
                                                "Matricula_Emitente", _
                                                "Orgao_Recebedor", _
                                                "Sala_Recebedor", _
                                                "Ramal_Recebedor", _
                                                "Recebedor", _
                                                "Matricula_Recebedor", _
                                                "Tipo_Movimentacao", _
                                                "Propriedade", _
                                                "Motivacao_MBP", _
                                                "Criado_Por_Usuario", _
                                                "Data_Criacao", _
                                                "Modificado_Por_Usuario", _
                                                "Data_Modificacao", _
                                                "Data_Impressao", _
                                                "Data_Movimentacao", _
                                                "Data_Devolucao", _
                                                "Prazo_Emprestimo", _
                                                "Observacoes" _
                                           }

        Public Sub mtdCarregarCamposTabelaMBP()
            intcolunaMBP = 22

            camposMBP = New String(intcolunaMBP)() {}
            camposMBP(intColunaTabelaMBPCodigo) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPCodigo), "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyCodigo PRIMARY KEY"}
            camposMBP(intColunaTabelaMBPOrgao_Emitente) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPOrgao_Emitente), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPSala_Emitente) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPSala_Emitente), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPRamal_Emitente) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPRamal_Emitente), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPEmitente) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPEmitente), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPMatricula_Emitente) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPMatricula_Emitente), "INTEGER", String.Empty, String.Empty}
            camposMBP(intColunaTabelaMBPOrgao_Recebedor) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPOrgao_Recebedor), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPSala_Recebedor) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPSala_Recebedor), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPRamal_Recebedor) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPRamal_Recebedor), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPRecebedor) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPRecebedor), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPMatricula_Recebedor) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPMatricula_Recebedor), "INTEGER", String.Empty, String.Empty}
            camposMBP(intColunaTabelaMBPTipo_Movimentacao) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPTipo_Movimentacao), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPPropriedade) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPPropriedade), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPMotivacao_MBP) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPMotivacao_MBP), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPCriado_Por_Usuario) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPCriado_Por_Usuario), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPData_Criacao) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPData_Criacao), "DATE", String.Empty, String.Empty}
            camposMBP(intColunaTabelaMBPModificado_Por_Usuario) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPModificado_Por_Usuario), "TEXT", "255", String.Empty}
            camposMBP(intColunaTabelaMBPData_Modificacao) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPData_Modificacao), "DATE", String.Empty, String.Empty}
            camposMBP(intColunaTabelaMBPData_Impressao) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPData_Impressao), "DATE", String.Empty, String.Empty}
            camposMBP(intColunaTabelaMBPData_Movimentacao) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPData_Movimentacao), "DATE", String.Empty, String.Empty}
            camposMBP(intColunaTabelaMBPData_Devolucao) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPData_Devolucao), "DATE", String.Empty, String.Empty}
            camposMBP(intColunaTabelaMBPPrazo_Emprestimo) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPPrazo_Emprestimo), "INTEGER", String.Empty, String.Empty}
            camposMBP(intColunaTabelaMBPObservacoes) = New String(3) {vetCamposTabelaMBP(intColunaTabelaMBPObservacoes), "TEXT", "255", String.Empty}
        End Sub

        Public Sub mtdCriarTabelaMBP()
            strNomeTabelaPrincipal = strNomeTabelaMBP

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
                   ( _
                   strConexaoBancoDadosPrincipal, _
                   clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
                   )

            mtdCarregarCamposTabelaMBP()

            objImplementacaoBancoDados.mtdCriarTabela(strNomeTabelaPrincipal, camposMBP)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaMBP()

        End Sub
    End Class
End Namespace