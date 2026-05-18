Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmMBPs
        Private ThCriarTabelaMBPBens As System.Threading.Thread

        Private strNomeProcessoCriarTabelaMBPBens As String = "Criar Tabela de MBP Bens"

        Friend Sub mtdIniciarThreadCriarTabelaMBPBens()
            mtdIniciarThreadCriarTabelaMBPBens(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaMBPBens(ByVal Iniciar As Boolean)
            Try
                'intProgresso = 0
                'strNomeProcesso = strNomeProcessoCriarTabelaMBPBens
                blnAbortarThreadCriarTabelaMBPBens = Not Iniciar
                blnForcarAbortarThreadCriarTabelaMBPBens = False
                blnThreadAtivadaCriarTabelaMBPBens = True
                blnSucessoCriarTabelaMBPBens = False
                ThCriarTabelaMBPBens = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaMBPBens))
                ThCriarTabelaMBPBens.IsBackground = True
                ThCriarTabelaMBPBens.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaMBPBens.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaMBPBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaMBPBens()
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaMBPBens
            blnAbortarThreadCriarTabelaMBPBens = False
            blnForcarAbortarThreadCriarTabelaMBPBens = False

            blnThreadAtivadaCriarTabelaMBPBens = True
            blnSucessoCriarTabelaMBPBens = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaMBPBens As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaMBPBens As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaMBPBens As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaMBPBens()
            mtdAbortarThreadCriarTabelaMBPBens(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaMBPBens(ByVal Forcar As Boolean)
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaMBPBens
            blnAbortarThreadCriarTabelaMBPBens = True
            blnForcarAbortarThreadCriarTabelaMBPBens = Forcar

            blnThreadAtivadaCriarTabelaMBPBens = False
            blnSucessoCriarTabelaMBPBens = False

            Try
                ThCriarTabelaMBPBens.Join(intTempoSaidaAbortarThreadCriarTabelaMBPBens)
                ThCriarTabelaMBPBens.Abort()
                ThCriarTabelaMBPBens = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaMBPBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaMBPBens()
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaMBPBens
            blnAbortarThreadCriarTabelaMBPBens = True
            blnForcarAbortarThreadCriarTabelaMBPBens = True

            blnThreadAtivadaCriarTabelaMBPBens = False
            blnSucessoCriarTabelaMBPBens = False
        End Sub

        'Private Shared LockerCriarTabelaMBPBens As New Object()

        Private Sub mtdRotinaThreadCriarTabelaMBPBens()
            While Not blnForcarAbortarThreadCriarTabelaMBPBens
                If Not blnAbortarThreadCriarTabelaMBPBens Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaMBP)
                    SyncLock (LockerCriarTabelaMBP)
                        Try
                            mtdGerarTabelaMBPBens()
                            mtdAbortarThreadCriarTabelaMBPBens(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaMBP)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaMBPBens As Boolean = False
        Friend blnSucessoCriarTabelaMBPBens As Boolean = False

        Private lngCodigoCriarTabelaMBPBens As Long = 0

        Protected Friend Sub mtdGerarTabelaMBPBens()
            'mtdDeletarTabelaMBPBens()
            'mtdDeletarDadosTabelaMBPBens()
            mtdCriarTabelaMBPBens()
            'mtdInserirDadosTabelaMBPBens()
        End Sub

        Private intcolunaMBPBens As Integer = 0

        Public camposMBPBens As String()()

        Public Sub mtdDeletarTabelaMBPBens()
            strNomeTabelaPrincipal = strNomeTabelaMBPBens

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strNomeTabelaPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaMBPBens()
            strNomeTabelaPrincipal = strNomeTabelaMBPBens
            strColunaPrincipal = "Contador"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strNomeTabelaPrincipal, strColunaPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Const intColunaTabelaMBPBensContador As Integer = 0
        Public Const intColunaTabelaMBPBensCodigo As Integer = 1
        Public Const intColunaTabelaMBPBensItem As Integer = 2
        Public Const intColunaTabelaMBPBensPatrimonio As Integer = 3
        Public Const intColunaTabelaMBPBensDescricao As Integer = 4
        Public Const intColunaTabelaMBPBensN_Serie As Integer = 5
        Public Const intColunaTabelaMBPBensEstado_Conservacao As Integer = 6
        Public Const intColunaTabelaMBPBensMatricula_Responsavel As Integer = 7
        Public Const intColunaTabelaMBPBensCriado_Por_Usuario As Integer = 8
        Public Const intColunaTabelaMBPBensData_Criacao As Integer = 9
        Public Const intColunaTabelaMBPBensModificado_Por_Usuario As Integer = 10
        Public Const intColunaTabelaMBPBensData_Modificado As Integer = 11

        Public Shared ReadOnly vetCamposTabelaMBPBens As String() = { _
                                                "Contador", _
                                                "Codigo", _
                                                "Item", _
                                                "Patrimonio", _
                                                "Descricao", _
                                                "N_Serie", _
                                                "Estado_Conservacao", _
                                                "Matricula_Responsavel", _
                                                "Criado_Por_Usuario", _
                                                "Data_Criacao", _
                                                "Modificado_Por_Usuario", _
                                                "Data_Modificado" _
                                                }

        Public Sub mtdCarregarCamposTabelaMBPBens()
            intcolunaMBPBens = 11

            camposMBPBens = New String(intcolunaMBPBens)() {}
            camposMBPBens(intColunaTabelaMBPBensContador) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensContador), "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyContador PRIMARY KEY"}
            camposMBPBens(intColunaTabelaMBPBensCodigo) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensCodigo), "INTEGER", String.Empty, String.Empty}
            camposMBPBens(intColunaTabelaMBPBensItem) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensItem), "INTEGER", String.Empty, String.Empty}
            camposMBPBens(intColunaTabelaMBPBensPatrimonio) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensPatrimonio), "INTEGER", String.Empty, String.Empty}
            camposMBPBens(intColunaTabelaMBPBensDescricao) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensDescricao), "TEXT", "255", String.Empty}
            camposMBPBens(intColunaTabelaMBPBensN_Serie) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensN_Serie), "TEXT", "255", String.Empty}
            camposMBPBens(intColunaTabelaMBPBensEstado_Conservacao) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensEstado_Conservacao), "TEXT", "255", String.Empty}
            camposMBPBens(intColunaTabelaMBPBensMatricula_Responsavel) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensMatricula_Responsavel), "TEXT", "255", String.Empty}
            camposMBPBens(intColunaTabelaMBPBensCriado_Por_Usuario) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensCriado_Por_Usuario), "TEXT", "255", String.Empty}
            camposMBPBens(intColunaTabelaMBPBensData_Criacao) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensData_Criacao), "DATE", String.Empty, String.Empty}
            camposMBPBens(intColunaTabelaMBPBensModificado_Por_Usuario) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensModificado_Por_Usuario), "TEXT", "255", String.Empty}
            camposMBPBens(intColunaTabelaMBPBensData_Modificado) = New String(3) {vetCamposTabelaMBPBens(intColunaTabelaMBPBensData_Modificado), "DATE", String.Empty, String.Empty}
        End Sub

        Public Sub mtdCriarTabelaMBPBens()
            strNomeTabelaPrincipal = strNomeTabelaMBPBens

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            mtdCarregarCamposTabelaMBPBens()

            objImplementacaoBancoDados.mtdCriarTabela(strNomeTabelaPrincipal, camposMBPBens)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaMBPBens()

        End Sub
    End Class
End Namespace