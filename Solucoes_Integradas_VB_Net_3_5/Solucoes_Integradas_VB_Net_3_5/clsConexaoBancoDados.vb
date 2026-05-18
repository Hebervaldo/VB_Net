Imports System.Collections.Generic
Imports System.Text

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class clsConexaoBancoDados
        Inherits clsBancoDados

        Private enuTipoConexao As TipoConexao = TipoConexao.Indisponivel

        Public Enum TipoConexao
            ConexaoAccessOdbc
            ConexaoAccess2003OleDb
            ConexaoAccess2007OleDb
            'ConexaoDB2Nativa
            'ConexaoDB2Odbc
            ConexaoExcelOdbc
            ConexaoExcel2003OleDb
            ConexaoExcel2007OleDb
            'ConexaoFirebirdNativa
            'ConexaoFirebirdOdbc
            'ConexaoMySQLNativa
            'ConexaoMySQLOdbc
            'ConexaoMySQLOleDb
            'ConexaoOracleNativa
            'ConexaoOracleOdbc
            'ConexaoOracleOleDb
            'ConexaoPostgreNativa
            'ConexaoPostgreOdbc
            'ConexaoPostgreOleDb
            'ConexaoSQLiteNativa
            'ConexaoSQLiteOdbc
            ConexaoSQLServerNativa
            ConexaoSQLServerOdbc
            ConexaoSQLServerOleDb
            ConexaoSQLServerCENativa
            ConexaoSQLServerCEOleDb
            Indisponivel
        End Enum

        Public Property prpTipoConexao() As TipoConexao
            Get
                Return enuTipoConexao
            End Get
            Set(ByVal value As TipoConexao)
                enuTipoConexao = value
            End Set
        End Property

        ' Metodo de Instancia, Construtor

        Public Sub New()
            MyBase.New(String.Empty, String.Empty, TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel)
        End Sub

        Public Sub New(ByVal Conexao As String)
            MyBase.New(Conexao, String.Empty, TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel)
        End Sub

        Public Sub New(ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional)
            MyBase.New(String.Empty, String.Empty, TipoSistemaGerenciadorBancoDadosRelacional)
        End Sub

        Public Sub New(ByVal Conexao As String, ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional)
            MyBase.New(Conexao, String.Empty, TipoSistemaGerenciadorBancoDadosRelacional)
        End Sub

        Public Sub New(ByVal Conexao As String, ByVal Comando As String, ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional)
            MyBase.New(Conexao, Comando, TipoSistemaGerenciadorBancoDadosRelacional)
        End Sub

        ' Metodos de instancia generico

        Private Function mtdEliminarAtribudoIndisponivelStringConexao(ByVal StringConexao As String) As String
            Dim saida As String = String.Empty
            Dim vetSubTexto As String() = StringConexao.Split(";"c)
            Dim vetSubSubTexto As String()
            For contador As Integer = vetSubTexto.GetLowerBound(0) To vetSubTexto.GetUpperBound(0)
                vetSubSubTexto = vetSubTexto(contador).Split("="c)
                saida += If(vetSubSubTexto(vetSubSubTexto.GetUpperBound(0)) <> String.Empty, String.Format("{0}={1}; ", vetSubSubTexto(vetSubSubTexto.GetLowerBound(0)), vetSubSubTexto(vetSubSubTexto.GetUpperBound(0))), String.Empty)
            Next
            Return saida.Trim()
        End Function

        Private Function mtdValidarConexao(ByVal Conexao As String, ByVal vetGenerico As String()) As String()
            Dim vetConexao As String() = Conexao.Split(";"c)
            Dim vetPartes As String() = Nothing
            Dim saida As String() = Nothing

            For i_vetConexao As Integer = vetConexao.GetLowerBound(0) To vetConexao.GetUpperBound(0)
                vetPartes = vetConexao(i_vetConexao).Split("="c)
                For i_vetCategoria As Integer = vetGenerico.GetLowerBound(0) To vetGenerico.GetUpperBound(0)
                    If vetPartes(vetPartes.GetLowerBound(0)).ToLower().Trim().Equals(vetGenerico(i_vetCategoria).ToLower().Trim()) Then
                        saida = vetConexao(i_vetConexao).Split("="c)
                    End If
                Next
            Next
            Return saida
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            ' Code to cleanup managed resources held by the class.
            If disposing Then
            End If
            ' Code to cleanup unmanaged resources held by the class.
            MyBase.Dispose(disposing)
        End Sub
        ' Note that the derived class does not // re-implement IDisposable
    End Class
End Namespace