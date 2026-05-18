Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmCautelas
        Private ThCriarTabelaCautelaBens As System.Threading.Thread

        Private strNomeProcessoCriarTabelaCautelaBens As String = "Criar Tabela de Cautela Bens"

        Friend Sub mtdIniciarThreadCriarTabelaCautelaBens()
            mtdIniciarThreadCriarTabelaCautelaBens(True)
        End Sub

        Friend Sub mtdIniciarThreadCriarTabelaCautelaBens(ByVal Iniciar As Boolean)
            Try
                'intProgresso = 0
                'strNomeProcesso = strNomeProcessoCriarTabelaCautelaBens
                blnAbortarThreadCriarTabelaCautelaBens = Not Iniciar
                blnForcarAbortarThreadCriarTabelaCautelaBens = False
                blnThreadAtivadaCriarTabelaCautelaBens = True
                blnSucessoCriarTabelaCautelaBens = False
                ThCriarTabelaCautelaBens = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadCriarTabelaCautelaBens))
                ThCriarTabelaCautelaBens.IsBackground = True
                ThCriarTabelaCautelaBens.Priority = System.Threading.ThreadPriority.Normal
                ThCriarTabelaCautelaBens.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadCriarTabelaCautelaBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadCriarTabelaCautelaBens()
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCautelaBens
            blnAbortarThreadCriarTabelaCautelaBens = False
            blnForcarAbortarThreadCriarTabelaCautelaBens = False

            blnThreadAtivadaCriarTabelaCautelaBens = True
            blnSucessoCriarTabelaCautelaBens = False
        End Sub

        Private Shared blnForcarAbortarThreadCriarTabelaCautelaBens As Boolean = False
        Private Shared blnAbortarThreadCriarTabelaCautelaBens As Boolean = False
        Private Shared intTempoSaidaAbortarThreadCriarTabelaCautelaBens As Integer = 1000

        Friend Sub mtdAbortarThreadCriarTabelaCautelaBens()
            mtdAbortarThreadCriarTabelaCautelaBens(False)
        End Sub

        Friend Sub mtdAbortarThreadCriarTabelaCautelaBens(ByVal Forcar As Boolean)
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCautelaBens
            blnAbortarThreadCriarTabelaCautelaBens = True
            blnForcarAbortarThreadCriarTabelaCautelaBens = Forcar

            blnThreadAtivadaCriarTabelaCautelaBens = False
            blnSucessoCriarTabelaCautelaBens = False

            Try
                ThCriarTabelaCautelaBens.Join(intTempoSaidaAbortarThreadCriarTabelaCautelaBens)
                ThCriarTabelaCautelaBens.Abort()
                ThCriarTabelaCautelaBens = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadCriarTabelaCautelaBens: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadCriarTabelaCautelaBens()
            'intProgresso = 100
            System.Threading.Thread.Sleep(1)
            'intProgresso = 0
            'strNomeProcesso = strNomeProcessoCriarTabelaCautelaBens
            blnAbortarThreadCriarTabelaCautelaBens = True
            blnForcarAbortarThreadCriarTabelaCautelaBens = True

            blnThreadAtivadaCriarTabelaCautelaBens = False
            blnSucessoCriarTabelaCautelaBens = False
        End Sub

        'Private Shared LockerCriarTabelaCautelaBens As New Object()

        Private Sub mtdRotinaThreadCriarTabelaCautelaBens()
            While Not blnForcarAbortarThreadCriarTabelaCautelaBens
                If Not blnAbortarThreadCriarTabelaCautelaBens Then
                    'System.Threading.Monitor.Enter(LockerCriarTabelaCautela)
                    SyncLock (LockerCriarTabelaCautela)
                        Try
                            mtdGerarTabelaCautelaBens()
                            mtdAbortarThreadCriarTabelaCautelaBens(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerCriarTabelaCautela)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaCriarTabelaCautelaBens As Boolean = False
        Friend blnSucessoCriarTabelaCautelaBens As Boolean = False

        Private lngCodigoCriarTabelaCautelaBens As Long = 0

        Protected Friend Sub mtdGerarTabelaCautelaBens()
            'mtdDeletarTabelaCautelaBens()
            'mtdDeletarDadosTabelaCautelaBens()
            mtdCriarTabelaCautelaBens()
            'mtdInserirDadosTabelaCautelaBens()
        End Sub

        Private intcolunaCautelaBens As Integer = 0

        Private camposCautelaBens As String()()

        Public Sub mtdDeletarTabelaCautelaBens()
            strNomeTabelaPrincipal = strNomeTabelaCautelaBens

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarTabela(strNomeTabelaPrincipal)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdDeletarDadosTabelaCautelaBens()
            strNomeTabelaPrincipal = strNomeTabelaCautelaBens
            strColunaPrincipal = "Contador"

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdDeletarDados(strNomeTabelaPrincipal, strColunaPrincipal, "LIKE", "'%'")
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Const intColunaTabelaCautelaBensContador As Integer = 0
        Public Const intColunaTabelaCautelaBensCodigo As Integer = 1
        Public Const intColunaTabelaCautelaBensItem As Integer = 2
        Public Const intColunaTabelaCautelaBensPatrimonio As Integer = 3
        Public Const intColunaTabelaCautelaBensImobilizado As Integer = 4
        Public Const intColunaTabelaCautelaBensDescricao As Integer = 5
        Public Const intColunaTabelaCautelaBensN_Serie As Integer = 6
        Public Const intColunaTabelaCautelaBensEstado_Conservacao As Integer = 7
        Public Const intColunaTabelaCautelaBensLocalizacao As Integer = 8
        Public Const intColunaTabelaCautelaBensCriado_Por_Usuario As Integer = 9
        Public Const intColunaTabelaCautelaBensData_Criacao As Integer = 10
        Public Const intColunaTabelaCautelaBensModificado_Por_Usuario As Integer = 11
        Public Const intColunaTabelaCautelaBensData_Modificado As Integer = 12

        Public Shared ReadOnly vetCamposTabelaCautelaBens As String() = { _
                                                "Contador", _
                                                "Codigo", _
                                                "Item", _
                                                "Patrimonio", _
                                                "Imobilizado", _
                                                "Descricao", _
                                                "N_Serie", _
                                                "Estado_Conservacao", _
                                                "Localizacao", _
                                                "Criado_Por_Usuario", _
                                                "Data_Criacao", _
                                                "Modificado_Por_Usuario", _
                                                "Data_Modificado" _
                                                }

        Public Sub mtdCarregarCamposTabelaCautelaBens()
            intcolunaCautelaBens = 12

            camposCautelaBens = New String(intcolunaCautelaBens)() {}
            camposCautelaBens(0) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensContador), "INTEGER", String.Empty, "CONSTRAINT PrimaryKeyContador PRIMARY KEY"}
            camposCautelaBens(1) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensCodigo), "INTEGER", String.Empty, String.Empty}
            camposCautelaBens(2) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensItem), "INTEGER", String.Empty, String.Empty}
            camposCautelaBens(3) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensPatrimonio), "INTEGER", String.Empty, String.Empty}
            camposCautelaBens(4) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensImobilizado), "TEXT", "255", String.Empty}
            camposCautelaBens(5) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensDescricao), "TEXT", "255", String.Empty}
            camposCautelaBens(6) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensN_Serie), "TEXT", "255", String.Empty}
            camposCautelaBens(7) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensEstado_Conservacao), "TEXT", "255", String.Empty}
            camposCautelaBens(8) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensLocalizacao), "TEXT", "255", String.Empty}
            camposCautelaBens(9) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensCriado_Por_Usuario), "TEXT", "255", String.Empty}
            camposCautelaBens(10) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensData_Criacao), "DATE", String.Empty, String.Empty}
            camposCautelaBens(11) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensModificado_Por_Usuario), "TEXT", "255", String.Empty}
            camposCautelaBens(12) = New String(3) {vetCamposTabelaCautelaBens(intColunaTabelaCautelaBensData_Modificado), "DATE", String.Empty, String.Empty}
        End Sub

        Public Sub mtdCriarTabelaCautelaBens()
            strNomeTabelaPrincipal = strNomeTabelaCautelaBens

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            strConexaoBancoDadosPrincipal, _
            clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            mtdCarregarCamposTabelaCautelaBens()

            objImplementacaoBancoDados.mtdCriarTabela(strNomeTabelaPrincipal, camposCautelaBens)
            objImplementacaoBancoDados.Dispose()
        End Sub

        Public Sub mtdInserirDadosTabelaCautelaBens()

        End Sub
    End Class
End Namespace