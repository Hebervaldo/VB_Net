Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmCarteiras
        Private ThCriarTabelaCarteira As System.Threading.Thread

        Private strNomeProcessoCriarTabelaCarteira As String = "Criar Tabela de Carteira"

        Friend Sub mtdIniciarThreadCriarTabelaCarteira()
            mtdIniciarThreadCriarTabelaCarteira(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaCarteira(ByVal Iniciar As Boolean)
            Try
                'intProgresso = 0
                'strNomeProcesso = strNomeProcessoCriarTabelaCarteira
                blnAbortarThreadCriarTabelaCarteira = Not Iniciar
                blnForcarAbortarThreadCriarTabelaCarteira = False
                blnThreadAtivadaCriarTabelaCarteira = True
                blnSucessoCriarTabelaCarteira = False
                ThCriarTabelaCarteira = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaCarteira))
                ThCriarTabelaCarteira.IsBackground = True
                ThCriarTabelaCarteira.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaCarteira.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaCarteira: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaCarteira()
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCarteira
            blnAbortarThreadCriarTabelaCarteira = False
            blnForcarAbortarThreadCriarTabelaCarteira = False

            blnThreadAtivadaCriarTabelaCarteira = True
            blnSucessoCriarTabelaCarteira = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaCarteira As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaCarteira As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaCarteira As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaCarteira()
            mtdAbortarThreadCriarTabelaCarteira(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaCarteira(ByVal Forcar As Boolean)
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCarteira
            blnAbortarThreadCriarTabelaCarteira = True
            blnForcarAbortarThreadCriarTabelaCarteira = Forcar

            blnThreadAtivadaCriarTabelaCarteira = False
            blnSucessoCriarTabelaCarteira = False

            Try
                ThCriarTabelaCarteira.Join(intTempoSaidaAbortarThreadCriarTabelaCarteira)
                ThCriarTabelaCarteira.Abort()
                ThCriarTabelaCarteira = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaCarteira: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaCarteira()
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCarteira
            blnAbortarThreadCriarTabelaCarteira = True
            blnForcarAbortarThreadCriarTabelaCarteira = True

            blnThreadAtivadaCriarTabelaCarteira = False
            blnSucessoCriarTabelaCarteira = False
        End Sub

        Private Shared LockerCriarTabelaCarteira As New Object()

        Private Sub mtdRotinaThreadCriarTabelaCarteira()
            While Not blnForcarAbortarThreadCriarTabelaCarteira
                If Not blnAbortarThreadCriarTabelaCarteira Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaCarteira)
                    SyncLock (LockerCriarTabelaCarteira)
                        Try
                            mtdGerarTabelaCarteira()
                            mtdAbortarThreadCriarTabelaCarteira(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaCarteira)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaCarteira As Boolean = False
        Friend blnSucessoCriarTabelaCarteira As Boolean = False

        Private lngCodigoCriarTabelaCarteira As Long = 0

        Protected Friend Sub mtdGerarTabelaCarteira()
            'mtdDeletarTabelaCarteira()
            'mtdDeletarDadosTabelaCarteira()
            mtdCriarTabelaCarteira()
            'mtdInserirDadosTabelaCarteira()
        End Sub

        Private intcolunaCarteira As Integer = 0

        Private camposCarteira As String()()

        Public Sub mtdDeletarTabelaCarteira()
            strNomeTabelaPrincipal = strNomeTabelaCarteira

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strNomeTabelaPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaCarteira()
            strNomeTabelaPrincipal = strNomeTabelaCarteira
            strColunaPrincipal = "Codigo"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strNomeTabelaPrincipal, strColunaPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Const intColunaTabelaCarteiraCodigo As Integer = 0
        Public Const intColunaTabelaCarteiraAutorizado As Integer = 1
        Public Const intColunaTabelaCarteiraMatricula_Autorizado As Integer = 2
        Public Const intColunaTabelaCarteiraSolicitador As Integer = 3
        Public Const intColunaTabelaCarteiraMatricula_Solicitador As Integer = 4
        Public Const intColunaTabelaCarteiraAprovador As Integer = 5
        Public Const intColunaTabelaCarteiraMatricula_Aprovador As Integer = 6
        Public Const intColunaTabelaCarteiraData_Autorizacao As Integer = 7
        Public Const intColunaTabelaCarteiraData_Validade As Integer = 8
        Public Const intColunaTabelaCarteiraCriado_Por_Usuario As Integer = 9
        Public Const intColunaTabelaCarteiraData_Criacao As Integer = 10
        Public Const intColunaTabelaCarteiraModificado_Por_Usuario As Integer = 11
        Public Const intColunaTabelaCarteiraData_Modificacao As Integer = 12
        Public Const intColunaTabelaCarteiraData_Impressao As Integer = 13
        Public Const intColunaTabelaCarteiraData_Envio As Integer = 14
        Public Const intColunaTabelaCarteiraPrazo_Validade As Integer = 15
        Public Const intColunaTabelaCarteiraObservacoes As Integer = 16

        Public Shared ReadOnly vetCamposTabelaCarteira As String() = { _
                                                "Codigo", _
                                                "Autorizado", _
                                                "Matricula_Autorizado", _
                                                "Solicitador", _
                                                "Matricula_Solicitador", _
                                                "Aprovador", _
                                                "Matricula_Aprovador", _
                                                "Data_Autorizacao", _
                                                "Data_Validade", _
                                                "Criado_Por_Usuario", _
                                                "Data_Criacao", _
                                                "Modificado_Por_Usuario", _
                                                "Data_Modificacao", _
                                                "Data_Impressao", _
                                                "Data_Envio", _
                                                "Prazo_Validade", _
                                                "Observacoes" _
                                           }


        Public Sub mtdCarregarCamposTabelaCarteira()
            intcolunaCarteira = 16

            camposCarteira = New String(intcolunaCarteira)() {}
            camposCarteira(intColunaTabelaCarteiraCodigo) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraCodigo), "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyCodigo PRIMARY KEY"}
            camposCarteira(intColunaTabelaCarteiraAutorizado) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraAutorizado), "TEXT", "255", String.Empty}
            camposCarteira(intColunaTabelaCarteiraMatricula_Autorizado) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraMatricula_Autorizado), "INTEGER", String.Empty, String.Empty}
            camposCarteira(intColunaTabelaCarteiraSolicitador) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraSolicitador), "TEXT", "255", String.Empty}
            camposCarteira(intColunaTabelaCarteiraMatricula_Solicitador) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraMatricula_Solicitador), "INTEGER", String.Empty, String.Empty}
            camposCarteira(intColunaTabelaCarteiraAprovador) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraAprovador), "TEXT", "255", String.Empty}
            camposCarteira(intColunaTabelaCarteiraMatricula_Aprovador) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraMatricula_Aprovador), "INTEGER", String.Empty, String.Empty}
            camposCarteira(intColunaTabelaCarteiraData_Autorizacao) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraData_Autorizacao), "DATE", String.Empty, String.Empty}
            camposCarteira(intColunaTabelaCarteiraData_Validade) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraData_Validade), "DATE", String.Empty, String.Empty}
            camposCarteira(intColunaTabelaCarteiraCriado_Por_Usuario) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraCriado_Por_Usuario), "TEXT", "255", String.Empty}
            camposCarteira(intColunaTabelaCarteiraData_Criacao) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraData_Criacao), "DATE", String.Empty, String.Empty}
            camposCarteira(intColunaTabelaCarteiraModificado_Por_Usuario) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraModificado_Por_Usuario), "TEXT", "255", String.Empty}
            camposCarteira(intColunaTabelaCarteiraData_Modificacao) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraData_Modificacao), "DATE", String.Empty, String.Empty}
            camposCarteira(intColunaTabelaCarteiraData_Impressao) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraData_Impressao), "DATE", String.Empty, String.Empty}
            camposCarteira(intColunaTabelaCarteiraData_Envio) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraData_Envio), "DATE", String.Empty, String.Empty}
            camposCarteira(intColunaTabelaCarteiraPrazo_Validade) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraPrazo_Validade), "INTEGER", String.Empty, String.Empty}
            camposCarteira(intColunaTabelaCarteiraObservacoes) = New String(3) {vetCamposTabelaCarteira(intColunaTabelaCarteiraObservacoes), "TEXT", "255", String.Empty}
        End Sub

        Public Sub mtdCriarTabelaCarteira()
            strNomeTabelaPrincipal = strNomeTabelaCarteira

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            mtdCarregarCamposTabelaCarteira()

            objImplementacaoBancoDados.mtdCriarTabela(strNomeTabelaPrincipal, camposCarteira)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaCarteira()

        End Sub
    End Class
End Namespace