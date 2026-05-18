Imports System.Collections.Generic
Imports System.Text

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class clsConexaoBancoDados

    End Class

    Partial Public Class clsBancoDados
        ' Variaveis do Odbc
        Private objConexaoOdbc As New System.Data.Odbc.OdbcConnection()
        Private objComandoOdbc As New System.Data.Odbc.OdbcCommand()
        Private objAdaptadorDadosOdbc As New System.Data.Odbc.OdbcDataAdapter()
        Private objLeitorDadosOdbc As System.Data.Odbc.OdbcDataReader

        ' Propriedades do Odbc

        Public Property prpConexaoOdbc() As System.Data.Odbc.OdbcConnection
            Get
                Return objConexaoOdbc
            End Get
            Set(ByVal value As System.Data.Odbc.OdbcConnection)
                objConexaoOdbc = value
            End Set
        End Property

        Public Property prpComandoOdbc() As System.Data.Odbc.OdbcCommand
            Get
                Return objComandoOdbc
            End Get
            Set(ByVal value As System.Data.Odbc.OdbcCommand)
                objComandoOdbc = value
            End Set
        End Property

        Public Property prpAdaptadorDadosOdbc() As System.Data.Odbc.OdbcDataAdapter
            Get
                Return objAdaptadorDadosOdbc
            End Get
            Set(ByVal value As System.Data.Odbc.OdbcDataAdapter)
                objAdaptadorDadosOdbc = value
            End Set
        End Property

        Public Property prpLeitorDadosOdbc() As System.Data.Odbc.OdbcDataReader
            Get
                Return objLeitorDadosOdbc
            End Get
            Set(ByVal value As System.Data.Odbc.OdbcDataReader)
                objLeitorDadosOdbc = value
            End Set
        End Property

        Public Sub mtdExecutarParametroComandoOdbc(ByVal NomeParametro As String, ByVal Valor As Object)
            Dim objParametroOdbc As New System.Data.Odbc.OdbcParameter(NomeParametro, Valor)
            prpComandoOdbc.Parameters.Add(objParametroOdbc)
        End Sub

        Public Sub mtdExecutarParametroComandoOdbc(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.Odbc.OdbcType, ByVal Valor As Object)
            Dim objParametroOdbc As New System.Data.Odbc.OdbcParameter(NomeParametro, TipoSqlDb)
            objParametroOdbc.Value = Valor
            prpComandoOdbc.Parameters.Add(objParametroOdbc)
        End Sub

        Public Sub mtdExecutarParametroComandoOdbc(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.Odbc.OdbcType, ByVal Valor As Object, ByVal Tamanho As Integer)
            Dim objParametroOdbc As New System.Data.Odbc.OdbcParameter(NomeParametro, TipoSqlDb, Tamanho)
            objParametroOdbc.Value = Valor
            prpComandoOdbc.Parameters.Add(objParametroOdbc)
        End Sub

        Public Sub mtdExecutarParametroComandoOdbc(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.Odbc.OdbcType, ByVal Valor As Object, ByVal Tamanho As Integer, ByVal ColunaOrigem As String)
            Dim objParametroOdbc As New System.Data.Odbc.OdbcParameter(NomeParametro, TipoSqlDb, Tamanho, ColunaOrigem)
            objParametroOdbc.Value = Valor
            prpComandoOdbc.Parameters.Add(objParametroOdbc)
        End Sub

        Public Sub mtdExecutarParametroComandoOdbc(ByVal OrigemVersao As System.Data.DataRowVersion, ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.Odbc.OdbcType, ByVal DirecaoParametro As System.Data.ParameterDirection, ByVal OrigemColuna As String, ByVal Valor As Object, _
         ByVal Tamanho As Integer)
            Dim objParametroOdbc As New System.Data.Odbc.OdbcParameter(NomeParametro, TipoSqlDb, Tamanho, OrigemColuna)
            objParametroOdbc.SourceVersion = OrigemVersao
            objParametroOdbc.Direction = DirecaoParametro
            objParametroOdbc.Value = Valor
            prpComandoOdbc.Parameters.Add(objParametroOdbc)
        End Sub
    End Class

    Partial Public Class clsImplementacaoBancoDados

    End Class
End Namespace