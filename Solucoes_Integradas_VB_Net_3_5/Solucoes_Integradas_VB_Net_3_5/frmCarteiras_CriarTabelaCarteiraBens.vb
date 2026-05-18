Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmCarteiras
        Private ThCriarTabelaCarteiraBens As System.Threading.Thread

        Private strNomeProcessoCriarTabelaCarteiraBens As String = "Criar Tabela de Carteira Bens"

        Friend Sub mtdIniciarThreadCriarTabelaCarteiraBens()
            mtdIniciarThreadCriarTabelaCarteiraBens(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaCarteiraBens(ByVal Iniciar As Boolean)
            Try
                'intProgresso = 0
                'strNomeProcesso = strNomeProcessoCriarTabelaCarteiraBens
                blnAbortarThreadCriarTabelaCarteiraBens = Not Iniciar
                blnForcarAbortarThreadCriarTabelaCarteiraBens = False
                blnThreadAtivadaCriarTabelaCarteiraBens = True
                blnSucessoCriarTabelaCarteiraBens = False
                ThCriarTabelaCarteiraBens = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaCarteiraBens))
                ThCriarTabelaCarteiraBens.IsBackground = True
                ThCriarTabelaCarteiraBens.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaCarteiraBens.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaCarteiraBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaCarteiraBens()
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCarteiraBens
            blnAbortarThreadCriarTabelaCarteiraBens = False
            blnForcarAbortarThreadCriarTabelaCarteiraBens = False

            blnThreadAtivadaCriarTabelaCarteiraBens = True
            blnSucessoCriarTabelaCarteiraBens = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaCarteiraBens As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaCarteiraBens As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaCarteiraBens As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaCarteiraBens()
            mtdAbortarThreadCriarTabelaCarteiraBens(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaCarteiraBens(ByVal Forcar As Boolean)
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCarteiraBens
            blnAbortarThreadCriarTabelaCarteiraBens = True
            blnForcarAbortarThreadCriarTabelaCarteiraBens = Forcar

            blnThreadAtivadaCriarTabelaCarteiraBens = False
            blnSucessoCriarTabelaCarteiraBens = False

            Try
                ThCriarTabelaCarteiraBens.Join(intTempoSaidaAbortarThreadCriarTabelaCarteiraBens)
                ThCriarTabelaCarteiraBens.Abort()
                ThCriarTabelaCarteiraBens = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaCarteiraBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaCarteiraBens()
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCarteiraBens
            blnAbortarThreadCriarTabelaCarteiraBens = True
            blnForcarAbortarThreadCriarTabelaCarteiraBens = True

            blnThreadAtivadaCriarTabelaCarteiraBens = False
            blnSucessoCriarTabelaCarteiraBens = False
        End Sub

        'Private Shared LockerCriarTabelaCarteiraBens As New Object()

        Private Sub mtdRotinaThreadCriarTabelaCarteiraBens()
            While Not blnForcarAbortarThreadCriarTabelaCarteiraBens
                If Not blnAbortarThreadCriarTabelaCarteiraBens Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaCarteira)
                    SyncLock (LockerCriarTabelaCarteira)
                        Try
                            mtdGerarTabelaCarteiraBens()
                            mtdAbortarThreadCriarTabelaCarteiraBens(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaCarteira)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaCarteiraBens As Boolean = False
        Friend blnSucessoCriarTabelaCarteiraBens As Boolean = False

        Private lngCodigoCriarTabelaCarteiraBens As Long = 0

        Protected Friend Sub mtdGerarTabelaCarteiraBens()
            'mtdDeletarTabelaCarteiraBens()
            'mtdDeletarDadosTabelaCarteiraBens()
            mtdCriarTabelaCarteiraBens()
            'mtdInserirDadosTabelaCarteiraBens()
        End Sub

        Private intcolunaCarteiraBens As Integer = 0

        Private camposCarteiraBens As String()()

        Public Sub mtdDeletarTabelaCarteiraBens()
            strNomeTabelaPrincipal = strNomeTabelaCarteiraBens

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strNomeTabelaPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaCarteiraBens()
            strNomeTabelaPrincipal = strNomeTabelaCarteiraBens
            strColunaPrincipal = "Contador"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strNomeTabelaPrincipal, strColunaPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Const intColunaTabelaCarteiraBensContador As Integer = 0
        Public Const intColunaTabelaCarteiraBensCodigo As Integer = 1
        Public Const intColunaTabelaCarteiraBensItem As Integer = 2
        Public Const intColunaTabelaCarteiraBensPatrimonio As Integer = 3
        Public Const intColunaTabelaCarteiraBensDescricao As Integer = 4
        Public Const intColunaTabelaCarteiraBensMarca As Integer = 5
        Public Const intColunaTabelaCarteiraBensN_Serie As Integer = 6
        Public Const intColunaTabelaCarteiraBensMatricula_Responsavel As Integer = 7
        Public Const intColunaTabelaCarteiraBensCriado_Por_Usuario As Integer = 8
        Public Const intColunaTabelaCarteiraBensData_Criacao As Integer = 9
        Public Const intColunaTabelaCarteiraBensModificado_Por_Usuario As Integer = 10
        Public Const intColunaTabelaCarteiraBensData_Modificado As Integer = 11

        Public Shared ReadOnly vetCamposTabelaCarteiraBens As String() = { _
                                                "Contador", _
                                                "Codigo", _
                                                "Item", _
                                                "Patrimonio", _
                                                "Descricao", _
                                                "Marca", _
                                                "N_Serie", _
                                                "Matricula_Responsavel", _
                                                "Criado_Por_Usuario", _
                                                "Data_Criacao", _
                                                "Modificado_Por_Usuario", _
                                                "Data_Modificado" _
                                                }

        Public Sub mtdCarregarCamposTabelaCarteiraBens()
            intcolunaCarteiraBens = 11

            camposCarteiraBens = New String(intcolunaCarteiraBens)() {}
            camposCarteiraBens(intColunaTabelaCarteiraBensContador) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensContador), "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyContador PRIMARY KEY"}
            camposCarteiraBens(intColunaTabelaCarteiraBensCodigo) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensCodigo), "INTEGER", String.Empty, String.Empty}
            camposCarteiraBens(intColunaTabelaCarteiraBensItem) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensItem), "INTEGER", String.Empty, String.Empty}
            camposCarteiraBens(intColunaTabelaCarteiraBensPatrimonio) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensPatrimonio), "INTEGER", String.Empty, String.Empty}
            camposCarteiraBens(intColunaTabelaCarteiraBensDescricao) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensDescricao), "TEXT", "255", String.Empty}
            camposCarteiraBens(intColunaTabelaCarteiraBensMarca) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensMarca), "TEXT", "255", String.Empty}
            camposCarteiraBens(intColunaTabelaCarteiraBensN_Serie) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensN_Serie), "TEXT", "255", String.Empty}
            camposCarteiraBens(intColunaTabelaCarteiraBensMatricula_Responsavel) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensMatricula_Responsavel), "INTEGER", String.Empty, String.Empty}
            camposCarteiraBens(intColunaTabelaCarteiraBensCriado_Por_Usuario) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensCriado_Por_Usuario), "TEXT", "255", String.Empty}
            camposCarteiraBens(intColunaTabelaCarteiraBensData_Criacao) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensData_Criacao), "DATE", String.Empty, String.Empty}
            camposCarteiraBens(intColunaTabelaCarteiraBensModificado_Por_Usuario) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensModificado_Por_Usuario), "TEXT", "255", String.Empty}
            camposCarteiraBens(intColunaTabelaCarteiraBensData_Modificado) = New String(3) {vetCamposTabelaCarteiraBens(intColunaTabelaCarteiraBensData_Modificado), "DATE", String.Empty, String.Empty}
        End Sub

        Public Sub mtdCriarTabelaCarteiraBens()
            strNomeTabelaPrincipal = strNomeTabelaCarteiraBens

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            mtdCarregarCamposTabelaCarteiraBens()

            objImplementacaoBancoDados.mtdCriarTabela(strNomeTabelaPrincipal, camposCarteiraBens)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaCarteiraBens()

        End Sub
    End Class
End Namespace