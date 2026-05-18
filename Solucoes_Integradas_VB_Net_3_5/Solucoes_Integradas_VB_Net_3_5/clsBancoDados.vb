Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
#Region "BancoDados"

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class clsBancoDados
        Implements IDisposable

        Protected Shared intNumeroInstanciasCriadas As Integer = 0
        Private intColuna As Integer = 0
        Private intLinha As Integer = 0
        Protected strConexao As String = String.Empty
        Protected strComando As String = String.Empty
        Private strExcecao As String = "Nao há excecoes."
        Private strTabela As String = "Tabela"
        Private bhvComportamenteComando As System.Data.CommandBehavior = System.Data.CommandBehavior.[Default]
        Private objAjustadorDados As New System.Data.DataSet()
        Private objTabelaDados As New System.Data.DataTable()

        Private enuTipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel

        Public Sub New()
            Me.New(String.Empty, String.Empty, TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel)
        End Sub

        Public Sub New(ByVal Conexao As String)
            Me.New(Conexao, String.Empty, TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel)
        End Sub

        Public Sub New(ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional)
            Me.New(String.Empty, String.Empty, TipoSistemaGerenciadorBancoDadosRelacional)
        End Sub

        Public Sub New(ByVal Conexao As String, ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional)
            Me.New(Conexao, String.Empty, TipoSistemaGerenciadorBancoDadosRelacional)
        End Sub

        Public Sub New(ByVal Conexao As String, ByVal Comando As String, ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional)
            strConexao = Conexao
            strComando = Comando
            prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional
            intNumeroInstanciasCriadas += 1
        End Sub

        Public Enum TipoSistemaGerenciadorBancoDadosRelacional
            Indisponivel
            DB2
            Firebird
            MySQL
            Odbc
            OleDb
            Oracle
            Postgre
            SQLite
            SQLServer
            SQLServerCE
        End Enum

        Public Property prpTipoSistemaGerenciadorBancoDadosRelacional() As TipoSistemaGerenciadorBancoDadosRelacional
            Get
                Return enuTipoSistemaGerenciadorBancoDadosRelacional
            End Get
            Set(ByVal value As TipoSistemaGerenciadorBancoDadosRelacional)
                enuTipoSistemaGerenciadorBancoDadosRelacional = value
            End Set
        End Property

        Public Shared ReadOnly Property getNumeroInstanciasCriadas() As Integer
            Get
                Return intNumeroInstanciasCriadas
            End Get
        End Property

        Protected Shared WriteOnly Property setNumeroInstanciasCriadas() As Integer
            Set(ByVal value As Integer)
                intNumeroInstanciasCriadas = value
            End Set
        End Property

        Public ReadOnly Property getExcecao() As String
            Get
                Return strExcecao
            End Get
        End Property

        Protected WriteOnly Property setExcecao() As String
            Set(ByVal value As String)
                strExcecao = value
            End Set
        End Property

        ''' <summary>
        ''' Propriedade que ajusta e resgata o valor da string contida na variável de instância strConexao.
        ''' </summary>
        ''' <returns></returns>
        Public Property prpConexao() As String
            Get
                Return strConexao
            End Get
            Set(ByVal value As String)
                strConexao = value
            End Set
        End Property

        Private Shared LockBancoDados As Object = New Object()

        ''' <summary>
        ''' O Método a seguir tem por finalidade abrir uma conexão de dados.
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdAbrirConexao() As Boolean
            Return mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
        End Function

        Public Function mtdAbrirConexao(ByVal Conexao As String) As Boolean
            Return mtdAbrirConexao(Conexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
        End Function

        Public Function mtdAbrirConexao(ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional) As Boolean
            Return mtdAbrirConexao(prpConexao, TipoSistemaGerenciadorBancoDadosRelacional)
        End Function

        ''' <summary>
        '''  O método a seguir abre a conexão de dados definindo uma conexão de dados pelo seu argumento.
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdAbrirConexao(ByVal Conexao As String, ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional) As Boolean
            SyncLock (LockBancoDados)
                Dim saida As Boolean = False
                strExcecao = "mtdAbrirConexao: Nao houve excecao."
                prpConexao = Conexao
                prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional
                Try
                    Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                        '    objConexaoDB2.ConnectionString = prpConexao
                        '    objConexaoDB2.Open()
                        '    If objConexaoDB2.State = System.Data.ConnectionState.Open Then
                        '        saida = True
                        '    End If
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                        '    objConexaoFirebird.ConnectionString = prpConexao
                        '    objConexaoFirebird.Open()
                        '    If objConexaoFirebird.State = System.Data.ConnectionState.Open Then
                        '        saida = True
                        '    End If
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                        '    objConexaoMySQL.ConnectionString = prpConexao
                        '    objConexaoMySQL.Open()
                        '    If objConexaoMySQL.State = System.Data.ConnectionState.Open Then
                        '        saida = True
                        '    End If
                        '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                            If objConexaoOdbc.State = System.Data.ConnectionState.Open Then
                                saida = True
                            Else
                                objConexaoOdbc.ConnectionString = prpConexao
                                objConexaoOdbc.Open()
                                If objConexaoOdbc.State = System.Data.ConnectionState.Open Then
                                    saida = True
                                Else
                                    saida = False
                                End If
                            End If
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                            If objConexaoOdbc.State = System.Data.ConnectionState.Open Then
                                saida = True
                            Else
                                objConexaoOleDb.ConnectionString = prpConexao
                                objConexaoOleDb.Open()
                                If objConexaoOleDb.State = System.Data.ConnectionState.Open Then
                                    saida = True
                                Else
                                    saida = False
                                End If
                            End If
                            Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                            '    objConexaoOracle.ConnectionString = prpConexao
                            '    objConexaoOracle.Open()
                            '    If objConexaoOracle.State = System.Data.ConnectionState.Open Then
                            '        saida = True
                            '    End If
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                            '    objConexaoPostgre.ConnectionString = prpConexao
                            '    objConexaoPostgre.Open()
                            '    If objConexaoPostgre.State = System.Data.ConnectionState.Open Then
                            '        saida = True
                            '    End If
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                            '    objConexaoSQLite.ConnectionString = prpConexao
                            '    objConexaoSQLite.Open()
                            '    If objConexaoSQLite.State = System.Data.ConnectionState.Open Then
                            '        saida = True
                            '    End If
                            '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                            If objConexaoSQLServer.State = System.Data.ConnectionState.Open Then
                                saida = True
                            Else
                                objConexaoSQLServer.ConnectionString = prpConexao
                                objConexaoSQLServer.Open()
                                If objConexaoSQLServer.State = System.Data.ConnectionState.Open Then
                                    saida = True
                                Else
                                    saida = False
                                End If
                            End If
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                            If objConexaoSQLServerCE.State = System.Data.ConnectionState.Open Then
                                saida = True
                            Else
                                objConexaoSQLServerCE.ConnectionString = prpConexao
                                objConexaoSQLServerCE.Open()
                                If objConexaoSQLServerCE.State = System.Data.ConnectionState.Open Then
                                    saida = True
                                Else
                                    saida = False
                                End If
                            End If
                            Exit Select
                    End Select
                Catch ex As System.Exception
                    strExcecao = "mtdAbrirConexao: " & ex.Message
                    saida = False
                End Try
                Return saida
            End SyncLock
        End Function

        ''' <summary>
        ''' Método que fecha a conexão aberta.
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdFecharConexao() As Boolean
            SyncLock (LockBancoDados)
                Dim saida As Boolean = False
                strExcecao = "mtdFecharConexao: Nao houve excecao."
                setNumeroLinhas = 0
                Try
                    Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                        '    objConexaoDB2.Close()
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                        '    objConexaoFirebird.Close()
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                        '    objConexaoMySQL.Close()
                        '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                            objConexaoOdbc.Close()
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                            objConexaoOleDb.Close()
                            Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                            '    objConexaoOracle.Close()
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                            '    objConexaoPostgre.Close()
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                            '    objConexaoSQLite.Close()
                            '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                            objConexaoSQLServer.Close()
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                            objConexaoSQLServerCE.Close()
                            Exit Select
                    End Select
                    saida = True
                Catch ex As System.Exception
                    strExcecao = "mtdFecharConexao: " & ex.Message
                    saida = False
                End Try
                Return saida
            End SyncLock
        End Function

        ''' <summary>
        ''' Propriedade que ajusta e resgata o valor da string contida na variável de instância strComando.
        ''' </summary>
        ''' <returns></returns>
        Public Property prpComando() As String
            Get
                Return strComando
            End Get
            Set(ByVal value As String)
                strComando = value
            End Set
        End Property

        Public Function mtdExecutarComando() As Boolean
            Return mtdExecutarComando(prpComando)
        End Function

        ''' <summary>
        ''' O Método a seguir tem por finalidade executar o comando sql informado com a string definida no argumento.
        ''' </summary>
        ''' <returns></returns>
        ''' 
        Public Function mtdExecutarComando(ByVal Comando As String) As Boolean
            SyncLock (LockBancoDados)
                Dim saida As Boolean = False
                strExcecao = "mtdExecutarComando: Nao houve excecao."
                Try
                    prpComando = Comando
                    Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                        '    objComandoDB2.CommandType = System.Data.CommandType.Text
                        '    objComandoDB2.CommandText = prpComando
                        '    objComandoDB2.Connection = objConexaoDB2
                        '    mtdFecharLeitorDados()
                        '    objComandoDB2.ExecuteNonQuery()
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                        '    objComandoFirebird.CommandType = System.Data.CommandType.Text
                        '    objComandoFirebird.CommandText = prpComando
                        '    objComandoFirebird.Connection = objConexaoFirebird
                        '    mtdFecharLeitorDados()
                        '    objComandoFirebird.ExecuteNonQuery()
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                        '    objComandoMySQL.CommandType = System.Data.CommandType.Text
                        '    objComandoMySQL.CommandText = prpComando
                        '    objComandoMySQL.Connection = objConexaoMySQL
                        '    mtdFecharLeitorDados()
                        '    objComandoMySQL.ExecuteNonQuery()
                        '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                            objComandoOdbc.CommandType = System.Data.CommandType.Text
                            objComandoOdbc.CommandText = prpComando
                            objComandoOdbc.Connection = objConexaoOdbc
                            mtdFecharLeitorDados()
                            objComandoOdbc.ExecuteNonQuery()
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                            objComandoOleDb.CommandType = System.Data.CommandType.Text
                            objComandoOleDb.CommandText = prpComando
                            objComandoOleDb.Connection = objConexaoOleDb
                            mtdFecharLeitorDados()
                            objComandoOleDb.ExecuteNonQuery()
                            Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                            '    objComandoOracle.CommandType = System.Data.CommandType.Text
                            '    objComandoOracle.CommandText = prpComando
                            '    objComandoOracle.Connection = objConexaoOracle
                            '    mtdFecharLeitorDados()
                            '    objComandoOracle.ExecuteNonQuery()
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                            '    objComandoPostgre.CommandType = System.Data.CommandType.Text
                            '    objComandoPostgre.CommandText = prpComando
                            '    objComandoPostgre.Connection = objConexaoPostgre
                            '    mtdFecharLeitorDados()
                            '    objComandoPostgre.ExecuteNonQuery()
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                            '    objComandoSQLite.CommandType = System.Data.CommandType.Text
                            '    objComandoSQLite.CommandText = prpComando
                            '    objComandoSQLite.Connection = objConexaoSQLite
                            '    mtdFecharLeitorDados()
                            '    objComandoSQLite.ExecuteNonQuery()
                            '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                            objComandoSQLServer.CommandType = System.Data.CommandType.Text
                            objComandoSQLServer.CommandText = prpComando
                            objComandoSQLServer.Connection = objConexaoSQLServer
                            mtdFecharLeitorDados()
                            objComandoSQLServer.ExecuteNonQuery()
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                            objComandoSQLServerCE.CommandType = System.Data.CommandType.Text
                            objComandoSQLServerCE.CommandText = prpComando
                            objComandoSQLServerCE.Connection = objConexaoSQLServerCE
                            mtdFecharLeitorDados()
                            objComandoSQLServerCE.ExecuteNonQuery()
                            Exit Select
                    End Select

                    System.Threading.Thread.Sleep(10)

                    saida = True
                Catch ex As System.Exception
                    strExcecao = "mtdExecutarComando: " & ex.Message
                    saida = False
                End Try
                Return saida
            End SyncLock
        End Function

        Public Property prpComandoComportamento() As System.Data.CommandBehavior
            Get
                Return bhvComportamenteComando
            End Get
            Set(ByVal value As System.Data.CommandBehavior)
                bhvComportamenteComando = value
            End Set
        End Property

        Public Function mtdReDefinirConexaoString(ByVal SubStringConexao As String()) As String
            Dim vetConexao As String() = prpConexao.Split(";"c)
            Dim vetSubConexao As String() = Nothing

            prpConexao = String.Empty
            For contador As Integer = vetConexao.GetLowerBound(0) To vetConexao.GetUpperBound(0) - 1
                If vetConexao(contador).Contains(SubStringConexao(0)) Then
                    vetSubConexao = vetConexao(contador).Split("="c)
                    vetSubConexao(1) = SubStringConexao(1).Trim()
                    vetConexao(contador) = String.Format("{0}={1}", vetSubConexao(0).Trim(), vetSubConexao(1).Trim())
                End If
                prpConexao += String.Format("{0}; ", vetConexao(contador).Trim())
            Next
            prpConexao = prpConexao.Trim()
            Return prpConexao
        End Function

        Public Function mtdObterCabecalhoColunas() As String()
            Return mtdObterCabecalhoColunas(True)
        End Function

        Public Function mtdObterCabecalhoColunas(ByVal Coluna As Integer) As String
            Return mtdObterCabecalhoColunas(True)(Coluna)
        End Function

        Public Function mtdObterCabecalhoColunas(ByVal Coluna As Integer, ByVal Otimizacao As Boolean) As String
            Return mtdObterCabecalhoColunas(Otimizacao)(Coluna)
        End Function

        Public Function mtdObterCabecalhoColunas(ByVal Coluna As String) As String
            Return mtdObterCabecalhoColunas(True)(mtdObterNumeroColuna(Coluna))
        End Function

        Public Sub mtdObterCabecalhoColunas(ByRef Colunas As String())
            Colunas = mtdObterCabecalhoColunas(True)
        End Sub

        Public Sub mtdObterCabecalhoColunas(ByRef Colunas As String(), ByVal Otimizacao As Boolean)
            Colunas = mtdObterCabecalhoColunas(Otimizacao)
        End Sub

        Public Function mtdObterCabecalhoColunas(ByVal Otimizacao As Boolean) As String()
            SyncLock (LockBancoDados)
                strExcecao = "mtdObterCabecalhoColunas: Nao houve excecao."

                Dim intNumeroColunas As Integer = 0
                Dim vetCabecalhos As String() = New String(intNumeroColunas - 1) {}
                Try
                    If Otimizacao Then
                        intNumeroColunas = mtdNumeroColunas()
                        vetCabecalhos = New String(intNumeroColunas - 1) {}
                        For contador As Integer = 0 To intNumeroColunas - 1
                            Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                                '    vetCabecalhos(contador) = objLeitorDadosDB2.GetName(contador)
                                '    Exit Select
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                                '    vetCabecalhos(contador) = objLeitorDadosFirebird.GetName(contador)
                                '    Exit Select
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                                '    vetCabecalhos(contador) = objLeitorDadosMySQL.GetName(contador)
                                '    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                                    vetCabecalhos(contador) = objLeitorDadosOdbc.GetName(contador)
                                    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                                    vetCabecalhos(contador) = objLeitorDadosOleDb.GetName(contador)
                                    Exit Select
                                    'Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                                    '    vetCabecalhos(contador) = objLeitorDadosOracle.GetName(contador)
                                    '    Exit Select
                                    'Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                                    '    vetCabecalhos(contador) = objLeitorDadosPostgre.GetName(contador)
                                    '    Exit Select
                                    'Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                                    '    vetCabecalhos(contador) = objLeitorDadosSQLite.GetName(contador)
                                    '    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                                    vetCabecalhos(contador) = objLeitorDadosSQLServer.GetName(contador)
                                    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                                    vetCabecalhos(contador) = objLeitorDadosSQLServerCE.GetName(contador)
                                    Exit Select
                            End Select
                        Next
                    Else
                        mtdAdaptadorDados()
                        intNumeroColunas = mtdNumeroColunas(False)
                        vetCabecalhos = New String(intNumeroColunas - 1) {}
                        For contador As Integer = 0 To intNumeroColunas - 1
                            vetCabecalhos(contador) = objAjustadorDados.Tables(strTabela).Columns(contador).ColumnName.ToString()
                        Next
                    End If
                Catch ex As System.Exception
                    strExcecao = "mtdObterCabecalhoColunas: " & ex.Message
                End Try
                Return vetCabecalhos
            End SyncLock
        End Function

        Public Function mtdObterNumeroColuna(ByVal Coluna As String) As Integer
            SyncLock (LockBancoDados)
                strExcecao = "mtdObterNumeroColuna: Nao houve excecao."
                Dim ex As New System.Exception("A coluna informada nao foi encontrada.")

                Dim vetObterCabecalhoColunas As String() = mtdObterCabecalhoColunas()
                Dim saida As Integer = -1

                For dimensao As Integer = 0 To vetObterCabecalhoColunas.Rank - 1
                    For contador As Integer = vetObterCabecalhoColunas.GetLowerBound(dimensao) To vetObterCabecalhoColunas.GetUpperBound(dimensao)
                        If Coluna = vetObterCabecalhoColunas(contador) Then
                            saida = contador
                        End If
                    Next
                Next
                If saida = -1 Then
                    Try
                        Throw ex
                    Catch
                        strExcecao = "mtdObterNumeroColuna: " & ex.Message
                    End Try
                End If
                Return saida
            End SyncLock
        End Function

        ''' <summary>
        ''' Propriedade que resgata o valor da string contida na variável de instância objAjustadorDados.
        ''' </summary>
        ''' <returns></returns>
        Public Property prpAjustadorDados() As System.Data.DataSet
            Get
                Return objAjustadorDados
            End Get
            Set(ByVal value As System.Data.DataSet)
                objAjustadorDados = value
            End Set
        End Property

        ''' <summary>
        ''' O Método a seguir tem por finalidade definir o leitor de dados a partir do comando (objComando.ExecuteReader).
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdDefinirLeitorDados() As Boolean
            Return mtdDefinirLeitorDados(prpComandoComportamento)
        End Function

        ''' <summary>
        ''' O Método a seguir tem por finalidade definir o leitor de dados a partir do comando (objComando.ExecuteReader).
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdDefinirLeitorDados(ByVal ComandoComportamento As System.Data.CommandBehavior) As Boolean
            SyncLock (LockBancoDados)
                Dim saida As Boolean = False
                strExcecao = "mtdDefinirLeitorDados: Nao houve excecao."
                prpComandoComportamento = ComandoComportamento
                Try
                    Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                        '    objLeitorDadosDB2 = objComandoDB2.ExecuteReader(prpComandoComportamento)
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                        '    objLeitorDadosFirebird = objComandoFirebird.ExecuteReader(prpComandoComportamento)
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                        '    objLeitorDadosMySQL = objComandoMySQL.ExecuteReader(prpComandoComportamento)
                        '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                            objLeitorDadosOdbc = objComandoOdbc.ExecuteReader(prpComandoComportamento)
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                            objLeitorDadosOleDb = objComandoOleDb.ExecuteReader(prpComandoComportamento)
                            Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                            '    objLeitorDadosOracle = objComandoOracle.ExecuteReader(prpComandoComportamento)
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                            '    objLeitorDadosPostgre = objComandoPostgre.ExecuteReader(prpComandoComportamento)
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                            '    objLeitorDadosSQLite = objComandoSQLite.ExecuteReader(prpComandoComportamento)
                            '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                            objLeitorDadosSQLServer = objComandoSQLServer.ExecuteReader(prpComandoComportamento)
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                            objLeitorDadosSQLServerCE = objComandoSQLServerCE.ExecuteReader(prpComandoComportamento)
                            Exit Select
                    End Select
                    saida = True
                Catch ex As System.Exception
                    strExcecao = "mtdDefinirLeitorDados: " & ex.Message
                    saida = False
                End Try
                intLinha = 0
                Return saida
            End SyncLock
        End Function

        ''' <summary>
        ''' Método que resgata o valor do datareader contido na variável de instância objLeitorDados, no entanto o datareader mantêm-se no mesmo registro.
        ''' </summary>
        ''' <returns></returns>

        Public Function mtdObterValorRegistro(ByVal Coluna As Integer) As Object
            Return mtdObterValorRegistro()(Coluna)
        End Function

        'public object mtdObterValorRegistro(string Coluna)
        '{
        '    return mtdObterValorRegistro()[mtdObterNumeroColuna(Coluna)];
        '}

        Public Sub mtdObterValorRegistro(ByRef Colunas As Object())
            Colunas = mtdObterValorRegistro()
        End Sub

        Public Function mtdObterValorRegistro() As Object()
            Return mtdObterValorRegistro(prpTabela, prpComando)
        End Function

        Public Function mtdObterValorRegistro(ByVal Comando As String) As Object()
            Return mtdObterValorRegistro(prpTabela, Comando)
        End Function

        Public Function mtdObterValorRegistro(ByVal Tabela As String, ByVal Comando As String) As Object()
            Return mtdObterValorRegistro(Tabela, Comando, True)
        End Function

        Public Function mtdObterValorRegistro(ByVal Tabela As String, ByVal Comando As String, ByVal Otimizacao As Boolean) As Object()
            SyncLock (LockBancoDados)
                strExcecao = "mtdObterValorRegistro: Nao houve excecao."
                Dim intNumeroColunas As Integer = 0
                Dim vetValores As Object() = Nothing
                Try
                    If Otimizacao Then
                        prpTabela = Tabela
                        prpComando = Comando
                        intNumeroColunas = mtdNumeroColunas()
                        vetValores = New Object(intNumeroColunas - 1) {}
                        For contador As Integer = 0 To intNumeroColunas - 1
                            Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                                '    vetValores(contador) = objLeitorDadosDB2(contador)
                                '    Exit Select
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                                '    vetValores(contador) = objLeitorDadosFirebird(contador)
                                '    Exit Select
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                                '    vetValores(contador) = objLeitorDadosMySQL(contador)
                                '    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                                    vetValores(contador) = objLeitorDadosOdbc(contador)
                                    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                                    vetValores(contador) = objLeitorDadosOleDb(contador)
                                    Exit Select
                                    'Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                                    '    vetValores(contador) = objLeitorDadosOracle(contador)
                                    '    Exit Select
                                    'Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                                    '    vetValores(contador) = objLeitorDadosPostgre(contador)
                                    '    Exit Select
                                    'Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                                    '    vetValores(contador) = objLeitorDadosSQLite(contador)
                                    '    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                                    vetValores(contador) = objLeitorDadosSQLServer(contador)
                                    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                                    vetValores(contador) = DirectCast(objLeitorDadosSQLServerCE(contador), Object)
                                    Exit Select
                            End Select
                        Next
                    Else
                        mtdAdaptadorDados()
                        intNumeroColunas = mtdNumeroColunas(False)
                        vetValores = New String(intNumeroColunas - 1) {}
                        For contador As Integer = 0 To intNumeroColunas - 1
                            vetValores(contador) = objAjustadorDados.Tables(strTabela).Rows(0)(contador)
                        Next
                    End If
                Catch ex As System.Exception
                    strExcecao = "mtdObterValorRegistro: " & ex.Message
                End Try
                Return vetValores
            End SyncLock
        End Function

        ''' <summary>
        ''' Método que resgata o tipo do datareader contido na variável de instância objLeitorDados, no entanto o datareader mantêm-se no mesmo registro.
        ''' </summary>
        ''' <returns></returns>

        Public Function mtdObterTipoRegistro(ByVal Coluna As Integer) As String
            Return mtdObterTipoRegistro()(Coluna)
        End Function

        'public string mtdObterTipoRegistro(string Coluna)
        '{
        '    return mtdObterTipoRegistro()[mtdObterNumeroColuna[Coluna]];
        '}

        Public Sub mtdObterTipoRegistro(ByRef Colunas As String())
            Colunas = mtdObterTipoRegistro()
        End Sub

        Public Function mtdObterTipoRegistro() As String()
            Return mtdObterTipoRegistro(prpTabela, prpComando)
        End Function

        Public Function mtdObterTipoRegistro(ByVal Comando As String) As String()
            Return mtdObterTipoRegistro(prpTabela, Comando)
        End Function

        Public Function mtdObterTipoRegistro(ByVal Tabela As String, ByVal Comando As String) As String()
            Return mtdObterTipoRegistro(Tabela, Comando, True)
        End Function

        Public Function mtdObterTipoRegistro(ByVal Tabela As String, ByVal Comando As String, ByVal Otimizacao As Boolean) As String()
            SyncLock (LockBancoDados)
                strExcecao = "mtdObterTipoRegistro: Nao houve excecao."
                Dim intNumeroColunas As Integer = 0
                Dim vetTipos As String() = Nothing
                Try
                    If Otimizacao Then
                        prpTabela = Tabela
                        prpComando = Comando
                        intNumeroColunas = mtdNumeroColunas()
                        vetTipos = New String(intNumeroColunas - 1) {}
                        For contador As Integer = 0 To intNumeroColunas - 1
                            Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                                '    vetTipos(contador) = objLeitorDadosDB2.GetValue(contador).[GetType]().ToString()
                                '    Exit Select
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                                '    vetTipos(contador) = objLeitorDadosFirebird.GetValue(contador).[GetType]().ToString()
                                '    Exit Select
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                                '    vetTipos(contador) = objLeitorDadosMySQL.GetValue(contador).[GetType]().ToString()
                                '    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                                    vetTipos(contador) = objLeitorDadosOdbc.GetValue(contador).[GetType]().ToString()
                                    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                                    vetTipos(contador) = objLeitorDadosOleDb.GetValue(contador).[GetType]().ToString()
                                    Exit Select
                                    'Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                                    '    vetTipos(contador) = objLeitorDadosOracle.GetValue(contador).[GetType]().ToString()
                                    '    Exit Select
                                    'Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                                    '    vetTipos(contador) = objLeitorDadosPostgre.GetValue(contador).[GetType]().ToString()
                                    '    Exit Select
                                    'Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                                    '    vetTipos(contador) = objLeitorDadosSQLite.GetValue(contador).[GetType]().ToString()
                                    '    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                                    vetTipos(contador) = objLeitorDadosSQLServer.GetValue(contador).[GetType]().ToString()
                                    Exit Select
                                Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                                    vetTipos(contador) = objLeitorDadosSQLServerCE.GetValue(contador).[GetType]().ToString()
                                    Exit Select
                            End Select
                        Next
                    Else
                        mtdAdaptadorDados()
                        intNumeroColunas = mtdNumeroColunas(False)
                        vetTipos = New String(intNumeroColunas - 1) {}
                        For contador As Integer = 0 To intNumeroColunas - 1
                            vetTipos(contador) = objAjustadorDados.Tables(strTabela).Columns(contador).Caption.[GetType]().ToString()
                        Next
                    End If
                Catch ex As System.Exception
                    strExcecao = "mtdObterTipoRegistro: " & ex.Message
                End Try
                Return vetTipos
            End SyncLock
        End Function

        Public Sub mtdObterCabecalhoTipoRegistro(ByVal CabecalhoTipoRegistro As String()())
            CabecalhoTipoRegistro = New String(1)() {mtdObterCabecalhoColunas(), mtdObterTipoRegistro()}
        End Sub

        Public Sub mtdObterCabecalhoTipoRegistro(ByVal Coluna As Integer, ByVal CabecalhoTipoRegistro As String())
            CabecalhoTipoRegistro = New String(1) {mtdObterCabecalhoColunas(Coluna), mtdObterTipoRegistro(Coluna)}
        End Sub

        Public Sub mtdObterCabecalhoTipoRegistro(ByVal Coluna As String, ByVal CabecalhoTipoRegistro As String())
            CabecalhoTipoRegistro = New String(1) {mtdObterCabecalhoColunas(mtdObterNumeroColuna(Coluna)), mtdObterTipoRegistro(mtdObterNumeroColuna(Coluna))}
        End Sub

        Public Function mtdObterCabecalhoTipoRegistro() As String()()
            Return New String(1)() {mtdObterCabecalhoColunas(), mtdObterTipoRegistro()}
        End Function

        Public Function mtdObterCabecalhoTipoRegistro(ByVal Coluna As Integer) As String()
            Return New String(1) {mtdObterCabecalhoColunas(Coluna), mtdObterTipoRegistro(Coluna)}
        End Function

        Public Function mtdObterCabecalhoTipoRegistro(ByVal Coluna As String) As String()
            Return New String(1) {mtdObterCabecalhoColunas(mtdObterNumeroColuna(Coluna)), mtdObterTipoRegistro(mtdObterNumeroColuna(Coluna))}
        End Function

        Public Sub mtdObterValorTipoRegistro(ByVal ValorTipoRegistro As Object()())
            ValorTipoRegistro = New Object(1)() {mtdObterValorRegistro(), mtdObterTipoRegistro()}
        End Sub

        Public Sub mtdObterValorTipoRegistro(ByVal Coluna As Integer, ByVal ValorTipoRegistro As Object())
            ValorTipoRegistro = New Object(1) {mtdObterValorRegistro(Coluna), mtdObterTipoRegistro(Coluna)}
        End Sub

        Public Sub mtdObterValorTipoRegistro(ByVal Coluna As String, ByVal ValorTipoRegistro As Object())
            ValorTipoRegistro = New Object(1) {mtdObterValorRegistro(mtdObterNumeroColuna(Coluna)), mtdObterTipoRegistro(mtdObterNumeroColuna(Coluna))}
        End Sub

        Public Function mtdObterValorTipoRegistro() As Object()()
            Return New Object(1)() {mtdObterValorRegistro(), mtdObterTipoRegistro()}
        End Function

        Public Function mtdObterValorTipoRegistro(ByVal Coluna As Integer) As Object()
            Return New Object(1) {mtdObterValorRegistro(Coluna), mtdObterTipoRegistro(Coluna)}
        End Function

        Public Function mtdObterValorTipoRegistro(ByVal Coluna As String) As Object()
            Return New Object(1) {mtdObterValorRegistro(mtdObterNumeroColuna(Coluna)), mtdObterTipoRegistro(mtdObterNumeroColuna(Coluna))}
        End Function

        ''' <summary>
        ''' O Método a seguir fecha o Leitor de Dados.
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdFecharLeitorDados() As Boolean
            SyncLock (LockBancoDados)
                Dim saida As Boolean = False
                strExcecao = "mtdFecharLeitorDados: Nao houve excecao."
                Try
                    Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                        '    If Not objLeitorDadosDB2.IsClosed Then
                        '        objLeitorDadosDB2.Close()
                        '    End If
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                        '    If Not objLeitorDadosFirebird.IsClosed Then
                        '        objLeitorDadosFirebird.Close()
                        '    End If
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                        '    If Not objLeitorDadosMySQL.IsClosed Then
                        '        objLeitorDadosMySQL.Close()
                        '    End If
                        '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                            If Not objLeitorDadosOdbc.IsClosed Then
                                objLeitorDadosOdbc.Close()
                            End If
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                            If Not objLeitorDadosOleDb.IsClosed Then
                                objLeitorDadosOleDb.Close()
                            End If
                            Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                            '    If Not objLeitorDadosOracle.IsClosed Then
                            '        objLeitorDadosOracle.Close()
                            '    End If
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                            '    If Not objLeitorDadosPostgre.IsClosed Then
                            '        objLeitorDadosPostgre.Close()
                            '    End If
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                            '    If Not objLeitorDadosSQLite.IsClosed Then
                            '        objLeitorDadosSQLite.Close()
                            '    End If
                            '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                            If Not objLeitorDadosSQLServer.IsClosed Then
                                objLeitorDadosSQLServer.Close()
                            End If
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                            If Not objLeitorDadosSQLServerCE.IsClosed Then
                                objLeitorDadosSQLServerCE.Close()
                            End If
                            Exit Select
                    End Select
                    saida = True
                Catch ex As System.Exception
                    strExcecao = "mtdFecharLeitorDados: " & ex.Message
                    saida = False
                End Try
                intLinha = 0
                Return saida
            End SyncLock
        End Function

        Public Property prpTabela() As String
            Get
                Return strTabela
            End Get
            Set(ByVal value As String)
                strTabela = value
            End Set
        End Property

        Public Property prpTabelaDados() As System.Data.DataTable
            Get
                Return objTabelaDados
            End Get
            Set(ByVal value As System.Data.DataTable)
                objTabelaDados = value
            End Set
        End Property

        '''<summary>
        ''' O Método a seguir tem por finalidade definir (ou redefinir) a conexão e o comando do Adaptador de Dados que no caso é a variável de instância (objAdaptadorDados).
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdAdaptadorDados() As Boolean
            Return mtdAdaptadorDados(prpConexao, prpComando, prpTabela, prpTipoSistemaGerenciadorBancoDadosRelacional)
        End Function

        '''<summary>
        ''' Método mtdAdaptadorDados está sobrecarregado.
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdAdaptadorDados(ByVal Tabela As String) As Boolean
            Return mtdAdaptadorDados(prpConexao, prpComando, Tabela, prpTipoSistemaGerenciadorBancoDadosRelacional)
        End Function

        Public Function mtdAdaptadorDados(ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional) As Boolean
            Return mtdAdaptadorDados(prpConexao, prpComando, prpTabela, TipoSistemaGerenciadorBancoDadosRelacional)
        End Function

        Public Function mtdAdaptadorDados(ByVal Tabela As String, ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional) As Boolean
            Return mtdAdaptadorDados(prpConexao, prpComando, Tabela, TipoSistemaGerenciadorBancoDadosRelacional)
        End Function

        '''<summary>
        ''' Método mtdAdaptadorDados está sobrecarregado.
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdAdaptadorDados(ByVal Conexao As String, ByVal Tabela As String) As Boolean
            Return mtdAdaptadorDados(Conexao, prpComando, Tabela, prpTipoSistemaGerenciadorBancoDadosRelacional)
        End Function

        Public Function mtdAdaptadorDados(ByVal Conexao As String, ByVal Tabela As String, ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional) As Boolean
            Return mtdAdaptadorDados(Conexao, prpComando, Tabela, TipoSistemaGerenciadorBancoDadosRelacional)
        End Function

        Public Function mtdAdaptadorDados(ByVal Conexao As String, ByVal Comando As String, ByVal Tabela As String) As Boolean
            Return mtdAdaptadorDados(Conexao, Comando, Tabela, prpTipoSistemaGerenciadorBancoDadosRelacional)
        End Function

        '''<summary>
        ''' Método mtdAdaptadorDados está sobrecarregado.
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdAdaptadorDados(ByVal Conexao As String, ByVal Comando As String, ByVal Tabela As String, ByVal TipoSistemaGerenciadorBancoDadosRelacional As TipoSistemaGerenciadorBancoDadosRelacional) As Boolean
            SyncLock (LockBancoDados)
                Dim saida As Boolean = False
                strExcecao = "mtdAdaptadorDados: Nao houve excecao."
                prpConexao = Conexao
                prpComando = Comando
                prpTabela = Tabela
                prpAjustadorDados = New System.Data.DataSet()
                prpTabelaDados = New System.Data.DataTable()
                prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional
                Try
                    Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                        '    objAdaptadorDadosDB2 = New IBM.Data.DB2.DB2DataAdapter(prpComando, prpConexao)
                        '    objAdaptadorDadosDB2.Fill(prpAjustadorDados, Tabela)
                        '    objAdaptadorDadosDB2.Fill(prpTabelaDados)
                        '    saida = True
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                        '    objAdaptadorDadosFirebird = New FirebirdSql.Data.FirebirdClient.FbDataAdapter(prpComando, prpConexao)
                        '    objAdaptadorDadosFirebird.Fill(prpAjustadorDados, Tabela)
                        '    objAdaptadorDadosFirebird.Fill(prpTabelaDados)
                        '    saida = True
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                        '    objAdaptadorDadosMySQL = New MySql.Data.MySqlClient.MySqlDataAdapter(prpComando, prpConexao)
                        '    objAdaptadorDadosMySQL.Fill(prpAjustadorDados, Tabela)
                        '    objAdaptadorDadosMySQL.Fill(prpTabelaDados)
                        '    saida = True
                        '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                            objAdaptadorDadosOdbc = New System.Data.Odbc.OdbcDataAdapter(prpComando, prpConexao)
                            objAdaptadorDadosOdbc.Fill(prpAjustadorDados, Tabela)
                            objAdaptadorDadosOdbc.Fill(prpTabelaDados)
                            saida = True
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                            objAdaptadorDadosOleDb = New System.Data.OleDb.OleDbDataAdapter(prpComando, prpConexao)
                            objAdaptadorDadosOleDb.Fill(prpAjustadorDados, Tabela)
                            objAdaptadorDadosOleDb.Fill(prpTabelaDados)
                            saida = True
                            Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                            '    objAdaptadorDadosOracle = New System.Data.OracleClient.OracleDataAdapter(prpComando, prpConexao)
                            '    objAdaptadorDadosOracle.Fill(prpAjustadorDados, Tabela)
                            '    objAdaptadorDadosOracle.Fill(prpTabelaDados)
                            '    saida = True
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                            '    objAdaptadorDadosPostgre = New Npgsql.NpgsqlDataAdapter(prpComando, prpConexao)
                            '    objAdaptadorDadosPostgre.Fill(prpAjustadorDados, Tabela)
                            '    objAdaptadorDadosPostgre.Fill(prpTabelaDados)
                            '    saida = True
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                            '    objAdaptadorDadosSQLite = New System.Data.SQLite.SQLiteDataAdapter(prpComando, prpConexao)
                            '    objAdaptadorDadosSQLite.Fill(prpAjustadorDados, Tabela)
                            '    objAdaptadorDadosSQLite.Fill(prpTabelaDados)
                            '    saida = True
                            '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                            objAdaptadorDadosSQLServer = New System.Data.SqlClient.SqlDataAdapter(prpComando, prpConexao)
                            objAdaptadorDadosSQLServer.Fill(prpAjustadorDados, Tabela)
                            objAdaptadorDadosSQLServer.Fill(prpTabelaDados)
                            saida = True
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                            objAdaptadorDadosSQLServerCE = New System.Data.SqlServerCe.SqlCeDataAdapter(prpComando, prpConexao)
                            objAdaptadorDadosSQLServerCE.Fill(prpAjustadorDados, Tabela)
                            objAdaptadorDadosSQLServerCE.Fill(prpTabelaDados)
                            saida = True
                            Exit Select
                    End Select
                Catch ex As System.Exception
                    strExcecao = "mtdAdaptadorDados: " & ex.Message
                    saida = False
                End Try
                Return saida
            End SyncLock
        End Function

        '''<summary>
        ''' O Método seguinte tem por finalidade ler o próximo registro.
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdProximoRegistro() As Boolean
            SyncLock (LockBancoDados)
                strExcecao = "mtdProximoRegistro: Nao houve excecao."
                Dim saida As Boolean = False
                Try
                    Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                        '    saida = objLeitorDadosDB2.Read()
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                        '    saida = objLeitorDadosFirebird.Read()
                        '    Exit Select
                        'Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                        '    saida = objLeitorDadosMySQL.Read()
                        '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                            saida = objLeitorDadosOdbc.Read()
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                            saida = objLeitorDadosOleDb.Read()
                            Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                            '    saida = objLeitorDadosOracle.Read()
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                            '    saida = objLeitorDadosPostgre.Read()
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                            '    saida = objLeitorDadosSQLite.Read()
                            '    Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                            saida = objLeitorDadosSQLServer.Read()
                            Exit Select
                        Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                            saida = objLeitorDadosSQLServerCE.Read()
                            Exit Select
                    End Select
                    If saida Then
                        intLinha += 1
                    Else
                        intLinha = 0
                    End If
                Catch ex As System.Exception
                    intLinha = -1
                    strExcecao = "mtdProximoRegistro: " & ex.Message
                End Try
                Return saida
            End SyncLock
        End Function

        Public Sub mtdAvancarRegistro()
            If Not mtdProximoRegistro() Then
                mtdFecharLeitorDados()
                mtdDefinirLeitorDados()
                If enuTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.SQLite Then
                    mtdProximoRegistro()
                End If
            End If
        End Sub

        Public Function mtdAvancarRegistro(ByVal Coluna As Integer) As Object
            mtdAvancarRegistro()
            Return mtdObterValorRegistro(Coluna)
        End Function

        Public Function mtdAvancarRegistro(ByVal Coluna As String) As Object
            Return mtdAvancarRegistro(mtdObterNumeroColuna(Coluna))
        End Function

        Public Sub mtdPrimeiroRegistro()
            mtdFecharLeitorDados()
            mtdDefinirLeitorDados()
            mtdProximoRegistro()
        End Sub

        Public Function mtdPrimeiroRegistro(ByVal Coluna As Integer) As Object
            mtdPrimeiroRegistro()
            Return mtdObterValorRegistro(Coluna)
        End Function

        Public Function mtdPrimeiroRegistro(ByVal Coluna As String) As Object
            Return mtdPrimeiroRegistro(mtdObterNumeroColuna(Coluna))
        End Function

        Public Sub mtdRetrocederRegistro()
            Dim intNumeroLinhas As Integer = mtdNumeroLinhas()
            Dim intIncrementarValor As Integer = 0
            mtdFecharLeitorDados()
            mtdDefinirLeitorDados()
            If enuTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.SQLite Then
                intIncrementarValor = 1
            End If
            For contador As Integer = 0 To intNumeroLinhas - intIncrementarValor - 1
                mtdAvancarRegistro()
            Next
        End Sub

        Public Function mtdRetrocederRegistro(ByVal Coluna As Integer) As Object
            mtdRetrocederRegistro()
            Return mtdObterValorRegistro(Coluna)
        End Function

        Public Function mtdRetrocederRegistro(ByVal Coluna As String) As Object
            Return mtdRetrocederRegistro(mtdObterNumeroColuna(Coluna))
        End Function

        Public Sub mtdUltimoRegistro()
            Dim intNumeroLinhas As Integer = mtdNumeroLinhas()
            mtdFecharLeitorDados()
            mtdDefinirLeitorDados()
            For contador As Integer = 0 To intNumeroLinhas - 1
                mtdProximoRegistro()
            Next
        End Sub

        Public Function mtdUltimoRegistro(ByVal Coluna As Integer) As Object
            mtdUltimoRegistro()
            Return mtdObterValorRegistro(Coluna)
        End Function

        Public Function mtdUltimoRegistro(ByVal Coluna As String) As Object
            Return mtdUltimoRegistro(mtdObterNumeroColuna(Coluna))
        End Function

        Public Sub mtdSelecionarRegistro(ByVal Linha As Integer)
            strExcecao = "mtdSelecionarRegistro: Nao houve excecao."
            Dim ex As New System.Exception("O numero da linha informada e maior do que o numero de linhas da tabela selecionada.")
            If Linha <= mtdNumeroLinhas() Then
                mtdFecharLeitorDados()
                mtdDefinirLeitorDados()
                For contador As Integer = 0 To Linha - 1
                    mtdProximoRegistro()
                    If enuTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.SQLite Then
                        mtdProximoRegistro()
                    End If
                Next
            Else
                Try
                    Throw ex
                Catch
                    strExcecao = "mtdSelecionarRegistro: " & ex.Message
                End Try
            End If
        End Sub

        Public Function mtdSelecionarRegistro(ByVal Linha As Integer, ByVal Coluna As Integer) As Object
            mtdSelecionarRegistro(Linha)
            Return mtdObterValorRegistro(Coluna)
        End Function

        Public Function mtdSelecionarRegistro(ByVal Linha As Integer, ByVal Coluna As String) As Object
            Return mtdSelecionarRegistro(Linha, mtdObterNumeroColuna(Coluna))
        End Function

        Public ReadOnly Property getNumeroColunas() As Integer
            Get
                Return intColuna
            End Get
        End Property

        Protected WriteOnly Property setNumeroColunas() As Integer
            Set(ByVal value As Integer)
                intColuna = value
            End Set
        End Property

        '''<summary>
        ''' O método a seguir resgata o número de colunas do Leitor de Dados.
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdNumeroColunas() As Integer
            Return mtdNumeroColunas(True)
        End Function

        Public Function mtdNumeroColunas(ByVal Otimizacao As Boolean) As Integer
            SyncLock (LockBancoDados)
                strExcecao = "mtdNumeroColunas: Nao houve excecao."
                Dim intNumeroColunas As Integer = 0
                Try
                    If Otimizacao Then
                        Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                            '    intNumeroColunas = objLeitorDadosDB2.FieldCount
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                            '    intNumeroColunas = objLeitorDadosFirebird.FieldCount
                            '    Exit Select
                            'Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                            '    intNumeroColunas = objLeitorDadosMySQL.FieldCount
                            '    Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                                intNumeroColunas = objLeitorDadosOdbc.FieldCount
                                Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                                intNumeroColunas = objLeitorDadosOleDb.FieldCount
                                Exit Select
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                                '    intNumeroColunas = objLeitorDadosOracle.FieldCount
                                '    Exit Select
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                                '    intNumeroColunas = objLeitorDadosPostgre.FieldCount
                                '    Exit Select
                                'Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                                '    intNumeroColunas = objLeitorDadosSQLite.FieldCount
                                '    Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                                intNumeroColunas = objLeitorDadosSQLServer.FieldCount
                                Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                                intNumeroColunas = objLeitorDadosSQLServerCE.FieldCount
                                Exit Select
                        End Select
                    Else
                        mtdAdaptadorDados()
                        intNumeroColunas = objAjustadorDados.Tables(strTabela).Columns.Count
                    End If
                Catch ex As System.Exception
                    strExcecao = "mtdNumeroColunas: " & ex.Message
                End Try
                Return intNumeroColunas
            End SyncLock
        End Function

        Public ReadOnly Property getNumeroLinhas() As Integer
            Get
                Return intLinha
            End Get
        End Property

        Protected WriteOnly Property setNumeroLinhas() As Integer
            Set(ByVal value As Integer)
                intLinha = value
            End Set
        End Property

        ''' <summary>
        ''' O Método a seguir encontra e resgata o número máximo de registros presente no Leitor de Dados.
        ''' </summary>
        ''' <returns></returns>
        Public Function mtdNumeroLinhas() As Integer
            Return mtdNumeroLinhas(True)
        End Function

        Public Function mtdNumeroLinhas(ByVal Otimizacao As Boolean) As Integer
            SyncLock (LockBancoDados)
                strExcecao = "mtdNumeroLinhas: Nao houve excecao."
                Dim intNumeroLinhas As Integer = 0
                Try
                    If Otimizacao Then
                        Select Case enuTipoSistemaGerenciadorBancoDadosRelacional
                            Case TipoSistemaGerenciadorBancoDadosRelacional.DB2
                                intNumeroLinhas = mtdContarNumeroLinhas()
                                Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.Firebird
                                intNumeroLinhas = mtdContarNumeroLinhas()
                                Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.MySQL
                                intNumeroLinhas = mtdContarNumeroLinhas()
                                Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                                intNumeroLinhas = mtdContarNumeroLinhas()
                                Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                                intNumeroLinhas = mtdContarNumeroLinhas()
                                Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.Oracle
                                intNumeroLinhas = mtdContarNumeroLinhas()
                                Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.Postgre
                                intNumeroLinhas = mtdContarNumeroLinhas()
                                Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.SQLite
                                intNumeroLinhas = mtdContarNumeroLinhas()
                                Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServer
                                intNumeroLinhas = mtdContarNumeroLinhas()
                                Exit Select
                            Case TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE
                                intNumeroLinhas = mtdContarNumeroLinhas()
                                Exit Select
                        End Select
                    Else
                        mtdAdaptadorDados()
                        intNumeroLinhas = objAjustadorDados.Tables(strTabela).Rows.Count
                    End If
                Catch ex As System.Exception
                    strExcecao = "mtdNumeroLinhas: " & ex.Message
                End Try
                Return intNumeroLinhas
            End SyncLock
        End Function

        Private Function mtdContarNumeroLinhas() As Integer
            Dim intNumeroLinhas As Integer = 0
            mtdExecutarComando()
            mtdDefinirLeitorDados()
            While mtdProximoRegistro()
                intNumeroLinhas += 1
            End While
            mtdFecharLeitorDados()
            Return intNumeroLinhas
        End Function

        Private isDisposed As Boolean = False

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not isDisposed Then
                If disposing Then
                    ' Code to dispose managed resources
                    ' held by the class
                    mtdFecharLeitorDados()
                    mtdFecharConexao()
                    intNumeroInstanciasCriadas -= 1
                    System.GC.Collect(0)
                End If
            End If
            ' Code to dispose unmanaged resources
            ' held by the class
            isDisposed = True
            'base.Dispose(disposing);
        End Sub

        Protected Overrides Sub Finalize()
            Try
                Dispose(False)
            Finally
                MyBase.Finalize()
            End Try
        End Sub
    End Class
End Namespace
#End Region