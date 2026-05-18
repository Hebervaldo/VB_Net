Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmCautelas
        Private ThCriarTabelaCautela As System.Threading.Thread

        Private strNomeProcessoCriarTabelaCautela As String = "Criar Tabela de Cautela"

        Friend Sub mtdIniciarThreadCriarTabelaCautela()
            mtdIniciarThreadCriarTabelaCautela(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaCautela(ByVal Iniciar As Boolean)
            Try
                'intProgresso = 0
                'strNomeProcesso = strNomeProcessoCriarTabelaCautela
                blnAbortarThreadCriarTabelaCautela = Not Iniciar
                blnForcarAbortarThreadCriarTabelaCautela = False
                blnThreadAtivadaCriarTabelaCautela = True
                blnSucessoCriarTabelaCautela = False
                ThCriarTabelaCautela = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaCautela))
                ThCriarTabelaCautela.IsBackground = True
                ThCriarTabelaCautela.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaCautela.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaCautela: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaCautela()
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCautela
            blnAbortarThreadCriarTabelaCautela = False
            blnForcarAbortarThreadCriarTabelaCautela = False

            blnThreadAtivadaCriarTabelaCautela = True
            blnSucessoCriarTabelaCautela = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaCautela As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaCautela As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaCautela As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaCautela()
            mtdAbortarThreadCriarTabelaCautela(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaCautela(ByVal Forcar As Boolean)
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCautela
            blnAbortarThreadCriarTabelaCautela = True
            blnForcarAbortarThreadCriarTabelaCautela = Forcar

            blnThreadAtivadaCriarTabelaCautela = False
            blnSucessoCriarTabelaCautela = False

            Try
                ThCriarTabelaCautela.Join(intTempoSaidaAbortarThreadCriarTabelaCautela)
                ThCriarTabelaCautela.Abort()
                ThCriarTabelaCautela = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaCautela: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaCautela()
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCautela
            blnAbortarThreadCriarTabelaCautela = True
            blnForcarAbortarThreadCriarTabelaCautela = True

            blnThreadAtivadaCriarTabelaCautela = False
            blnSucessoCriarTabelaCautela = False
        End Sub

        Private Shared LockerCriarTabelaCautela As New Object()

        Private Sub mtdRotinaThreadCriarTabelaCautela()
            While Not blnForcarAbortarThreadCriarTabelaCautela
                If Not blnAbortarThreadCriarTabelaCautela Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaCautela)
                    SyncLock (LockerCriarTabelaCautela)
                        Try
                            mtdGerarTabelaCautela()
                            mtdAbortarThreadCriarTabelaCautela(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaCautela)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaCautela As Boolean = False
        Friend blnSucessoCriarTabelaCautela As Boolean = False

        Private lngCodigoCriarTabelaCautela As Long = 0

        Protected Friend Sub mtdGerarTabelaCautela()
            'mtdDeletarTabelaCautela()
            'mtdDeletarDadosTabelaCautela()
            mtdCriarTabelaCautela()
            'mtdInserirDadosTabelaCautela()
        End Sub

        Private intcolunaCautela As Integer = 0

        Private camposCautela As String()()

        Public Sub mtdDeletarTabelaCautela()
            strNomeTabelaPrincipal = strNomeTabelaCautela

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strNomeTabelaPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaCautela()
            strNomeTabelaPrincipal = strNomeTabelaCautela
            strColunaPrincipal = "Codigo"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strNomeTabelaPrincipal, strColunaPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Const intColunaTabelaCautelaCodigo As Integer = 0
        Public Const intColunaTabelaCautelaCentro_Custo As Integer = 1
        Public Const intColunaTabelaCautelaOrgao As Integer = 2
        Public Const intColunaTabelaCautelaResponsavel As Integer = 3
        Public Const intColunaTabelaCautelaMatricula As Integer = 4
        Public Const intColunaTabelaCautelaCriado_Por_Usuario As Integer = 5
        Public Const intColunaTabelaCautelaData_Criacao As Integer = 6
        Public Const intColunaTabelaCautelaModificado_Por_Usuario As Integer = 7
        Public Const intColunaTabelaCautelaData_Modificacao As Integer = 8
        Public Const intColunaTabelaCautelaData_Impressao As Integer = 9
        Public Const intColunaTabelaCautelaData_Envio As Integer = 10
        Public Const intColunaTabelaCautelaData_Recebimento As Integer = 11
        Public Const intColunaTabelaCautelaPrazo_Entrega As Integer = 12
        Public Const intColunaTabelaCautelaObservacoes As Integer = 13

        Public Shared ReadOnly vetCamposTabelaCautela As String() = { _
                                                "Codigo", _
                                                "Centro_Custo", _
                                                "Orgao", _
                                                "Responsavel", _
                                                "Matricula", _
                                                "Criado_Por_Usuario", _
                                                "Data_Criacao", _
                                                "Modificado_Por_Usuario", _
                                                "Data_Modificacao", _
                                                "Data_Impressao", _
                                                "Data_Envio", _
                                                "Data_Recebimento", _
                                                "Prazo_Entrega", _
                                                "Observacoes" _
                                           }

        Public Sub mtdCarregarCamposTabelaCautela()
            intcolunaCautela = 13

            camposCautela = New String(intcolunaCautela)() {}
            camposCautela(intColunaTabelaCautelaCodigo) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaCodigo), "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyCodigo PRIMARY KEY"}
            camposCautela(intColunaTabelaCautelaCentro_Custo) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaCentro_Custo), "INTEGER", String.Empty, String.Empty}
            camposCautela(intColunaTabelaCautelaOrgao) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaOrgao), "TEXT", "255", String.Empty}
            camposCautela(intColunaTabelaCautelaResponsavel) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaResponsavel), "TEXT", "255", String.Empty}
            camposCautela(intColunaTabelaCautelaMatricula) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaMatricula), "INTEGER", String.Empty, String.Empty}
            camposCautela(intColunaTabelaCautelaCriado_Por_Usuario) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaCriado_Por_Usuario), "TEXT", "255", String.Empty}
            camposCautela(intColunaTabelaCautelaData_Criacao) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaData_Criacao), "DATE", String.Empty, String.Empty}
            camposCautela(intColunaTabelaCautelaModificado_Por_Usuario) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaModificado_Por_Usuario), "TEXT", "255", String.Empty}
            camposCautela(intColunaTabelaCautelaData_Modificacao) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaData_Modificacao), "DATE", String.Empty, String.Empty}
            camposCautela(intColunaTabelaCautelaData_Impressao) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaData_Impressao), "DATE", String.Empty, String.Empty}
            camposCautela(intColunaTabelaCautelaData_Envio) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaData_Envio), "DATE", String.Empty, String.Empty}
            camposCautela(intColunaTabelaCautelaData_Recebimento) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaData_Recebimento), "DATE", String.Empty, String.Empty}
            camposCautela(intColunaTabelaCautelaPrazo_Entrega) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaPrazo_Entrega), "INTEGER", String.Empty, String.Empty}
            camposCautela(intColunaTabelaCautelaObservacoes) = New String(3) {vetCamposTabelaCautela(intColunaTabelaCautelaObservacoes), "TEXT", "255", String.Empty}
        End Sub

        Public Sub mtdCriarTabelaCautela()
            strNomeTabelaPrincipal = strNomeTabelaCautela

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            mtdCarregarCamposTabelaCautela()

            objImplementacaoBancoDados.mtdCriarTabela(strNomeTabelaPrincipal, camposCautela)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaCautela()

        End Sub
    End Class
End Namespace