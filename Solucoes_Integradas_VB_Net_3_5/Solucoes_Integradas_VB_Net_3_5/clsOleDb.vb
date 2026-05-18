Imports System.Collections.Generic
Imports System.Text

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class clsConexaoBancoDados

    End Class

    Partial Public Class clsBancoDados
        ' Variaveis do OleDb
        Private objConexaoOleDb As New System.Data.OleDb.OleDbConnection()
        Private objComandoOleDb As New System.Data.OleDb.OleDbCommand()
        Private objAdaptadorDadosOleDb As New System.Data.OleDb.OleDbDataAdapter()
        Private objLeitorDadosOleDb As System.Data.OleDb.OleDbDataReader

        ' Propriedades do OleDb

        Public Property prpConexaoOleDb() As System.Data.OleDb.OleDbConnection
            Get
                Return objConexaoOleDb
            End Get
            Set(ByVal value As System.Data.OleDb.OleDbConnection)
                objConexaoOleDb = value
            End Set
        End Property

        Public Property prpComandoOleDb() As System.Data.OleDb.OleDbCommand
            Get
                Return objComandoOleDb
            End Get
            Set(ByVal value As System.Data.OleDb.OleDbCommand)
                objComandoOleDb = value
            End Set
        End Property

        Public Property prpAdaptadorDadosOleDb() As System.Data.OleDb.OleDbDataAdapter
            Get
                Return objAdaptadorDadosOleDb
            End Get
            Set(ByVal value As System.Data.OleDb.OleDbDataAdapter)
                objAdaptadorDadosOleDb = value
            End Set
        End Property

        Public Property prpLeitorOleDb() As System.Data.OleDb.OleDbDataReader
            Get
                Return objLeitorDadosOleDb
            End Get
            Set(ByVal value As System.Data.OleDb.OleDbDataReader)
                objLeitorDadosOleDb = value
            End Set
        End Property

        Public Sub mtdExecutarParametroComandoOleDb(ByVal NomeParametro As String, ByVal Valor As Object)
            Dim objParametroOleDb As New System.Data.OleDb.OleDbParameter(NomeParametro, Valor)
            prpComandoOleDb.Parameters.Add(objParametroOleDb)
        End Sub

        Public Sub mtdExecutarParametroComandoOleDb(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.OleDb.OleDbType, ByVal Valor As Object)
            Dim objParametroOleDb As New System.Data.OleDb.OleDbParameter(NomeParametro, TipoSqlDb)
            objParametroOleDb.Value = Valor
            prpComandoOleDb.Parameters.Add(objParametroOleDb)
        End Sub

        Public Sub mtdExecutarParametroComandoOleDb(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.OleDb.OleDbType, ByVal Valor As Object, ByVal Tamanho As Integer)
            Dim objParametroOleDb As New System.Data.OleDb.OleDbParameter(NomeParametro, TipoSqlDb, Tamanho)
            objParametroOleDb.Value = Valor
            prpComandoOleDb.Parameters.Add(objParametroOleDb)
        End Sub

        Public Sub mtdExecutarParametroComandoOleDb(ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.OleDb.OleDbType, ByVal Valor As Object, ByVal Tamanho As Integer, ByVal ColunaOrigem As String)
            Dim objParametroOleDb As New System.Data.OleDb.OleDbParameter(NomeParametro, TipoSqlDb, Tamanho, ColunaOrigem)
            objParametroOleDb.Value = Valor
            prpComandoOleDb.Parameters.Add(objParametroOleDb)
        End Sub

        Public Sub mtdExecutarParametroComandoOleDb(ByVal OrigemVersao As System.Data.DataRowVersion, ByVal NomeParametro As String, ByVal TipoSqlDb As System.Data.OleDb.OleDbType, ByVal DirecaoParametro As System.Data.ParameterDirection, ByVal OrigemColuna As String, ByVal Valor As Object, _
         ByVal Tamanho As Integer)
            Dim objParametroOleDb As New System.Data.OleDb.OleDbParameter(NomeParametro, TipoSqlDb, Tamanho, OrigemColuna)
            objParametroOleDb.SourceVersion = OrigemVersao
            objParametroOleDb.Direction = DirecaoParametro
            objParametroOleDb.Value = Valor
            prpComandoOleDb.Parameters.Add(objParametroOleDb)
        End Sub
    End Class

    Partial Public Class clsImplementacaoBancoDados
        Private Function mtdAtualizarDadosParametroComandoOleDbValor(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    strCampoBase = CampoBase
                    strOperacao = Operacao
                    objDadoBase = CampoBase

                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoOleDb.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To (Campos_Dados.GetUpperBound(1))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados.GetUpperBound(1)), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoOleDbValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    strCampoBase = CampoBase
                    strOperacao = Operacao
                    objDadoBase = DadoBase

                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoOleDb.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To (Campos_Dados.GetUpperBound(1))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    Exit Select
                                Case (1)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados(linha, coluna), System.Data.OleDb.OleDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    If Campos_Dados(1, coluna) IsNot Nothing Then
                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                    Else
                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados.GetUpperBound(1)), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoOleDbValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    strCampoBase = CampoBase
                    strOperacao = Operacao
                    objDadoBase = DadoBase

                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (2)
                                vetTamanhoColunas = New Integer(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoOleDb.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To (Campos_Dados.GetUpperBound(1))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    Exit Select
                                Case (1)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados(linha, coluna), System.Data.OleDb.OleDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                    End If
                                    Exit Select
                                Case (2)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTamanhoColunas(coluna) = CInt(Campos_Dados(linha, coluna))
                                    Else
                                        vetTamanhoColunas(coluna) = CInt(0)
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    If Campos_Dados(1, coluna) IsNot Nothing Then
                                        If Campos_Dados(2, coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        End If
                                    Else
                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados.GetUpperBound(1)), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAtualizarDadosParametroComandoOleDb(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object, ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdAtualizarDadosParametroComandoOleDbValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdAtualizarDadosParametroComandoOleDbValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdAtualizarDadosParametroComandoOleDbValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
            End Select
            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoOleDbValor(ByVal NomeTabela As String, ByVal Campos_Dados As Object()(), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        strCampoBase = CampoBase
                        strOperacao = Operacao
                        objDadoBase = DadoBase

                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoOleDb.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To (Campos_Dados(linha).GetUpperBound(0))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados(linha).GetUpperBound(0)), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoOleDbValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados As Object()(), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    strCampoBase = CampoBase
                    strOperacao = Operacao
                    objDadoBase = DadoBase

                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoOleDb.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To (Campos_Dados(linha).GetUpperBound(0))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados(linha)(coluna), System.Data.OleDb.OleDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        If Campos_Dados(1)(coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados(linha).GetUpperBound(0)), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoOleDbValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados As Object()(), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (2)
                                    vetTamanhoColunas = New Integer(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    strCampoBase = DirectCast(Campos_Dados(linha)(Campos_Dados(linha).GetUpperBound(0) - 2), String)
                                    strOperacao = DirectCast(Campos_Dados(linha)(Campos_Dados.GetUpperBound(0) - 1), String)
                                    objDadoBase = Campos_Dados(linha)(Campos_Dados(linha).GetUpperBound(0))
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoOleDb.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To (Campos_Dados(linha).GetUpperBound(0))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados(linha)(coluna), System.Data.OleDb.OleDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case (2)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTamanhoColunas(coluna) = CInt(Campos_Dados(linha)(coluna))
                                        Else
                                            vetTamanhoColunas(coluna) = CInt(0)
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        If Campos_Dados(1)(coluna) IsNot Nothing Then
                                            If Campos_Dados(2)(coluna) IsNot Nothing Then
                                                mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                            Else
                                                mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                            End If
                                        Else
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados(linha).GetUpperBound(0) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAtualizarDadosParametroComandoOleDb(ByVal NomeTabela As String, ByVal Campos_Dados As Object()(), ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object, ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdAtualizarDadosParametroComandoOleDbValor(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdAtualizarDadosParametroComandoOleDbValorTipo(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdAtualizarDadosParametroComandoOleDbValorTipoTamanho(NomeTabela, Campos_Dados, CampoBase, Operacao, DadoBase)
                    Exit Select
            End Select
            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoOleDbValor(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2), String)
                                strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1), String)
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1))
                                vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoOleDb.Parameters.Clear()

                        For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), String)
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), Object)

                                    mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoOleDbValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2), String)
                                strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1), String)
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1))
                                vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoOleDb.Parameters.Clear()

                        For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), String)
                                    Exit Select
                                Case (1)
                                    If Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), System.Data.OleDb.OleDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), Object)

                                    If Campos_Dados_CampoBase_Operacao_DadoBase(1, coluna) IsNot Nothing Then
                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                    Else
                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoOleDbValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case (2)
                                vetTamanhoColunas = New Integer(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2), String)
                                strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1), String)
                                objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1))
                                vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        strTexto = New StringBuilder
                        prpComandoOleDb.Parameters.Clear()

                        For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3))
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), String)
                                    Exit Select
                                Case (1)
                                    If Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), System.Data.OleDb.OleDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                    End If
                                    Exit Select
                                Case (2)
                                    If Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna) IsNot Nothing Then
                                        vetTamanhoColunas(coluna) = CInt(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna))
                                    Else
                                        vetTamanhoColunas(coluna) = CInt(0)
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), Object)

                                    If Campos_Dados_CampoBase_Operacao_DadoBase(1, coluna) IsNot Nothing Then
                                        If Campos_Dados_CampoBase_Operacao_DadoBase(2, coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        End If
                                    Else
                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                            mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAtualizarDadosParametroComandoOleDb(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object(,), ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdAtualizarDadosParametroComandoOleDbValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdAtualizarDadosParametroComandoOleDbValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdAtualizarDadosParametroComandoOleDbValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
            End Select
            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoOleDbValor(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 2), String)
                                    strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 1), String)
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0))
                                    vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoOleDb.Parameters.Clear()

                            For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetLowerBound(0) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), String)
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), Object)

                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoOleDbValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 2), String)
                                    strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 1), String)
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0))
                                    vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoOleDb.Parameters.Clear()

                            For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetLowerBound(0) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), String)
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), System.Data.OleDb.OleDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), Object)

                                        If Campos_Dados_CampoBase_Operacao_DadoBase(1)(coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)


                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdAtualizarDadosParametroComandoOleDbValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                If Campos_Dados_CampoBase_Operacao_DadoBase.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (2)
                                    vetTamanhoColunas = New Integer(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 2), String)
                                    strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0) - 1), String)
                                    objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0))
                                    vetRegistrosColunas = New Object(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            strTexto = New StringBuilder
                            prpComandoOleDb.Parameters.Clear()

                            For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetLowerBound(0) To (If((linha <= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais - 1), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3))
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), String)
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), System.Data.OleDb.OleDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case (2)
                                        If Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna) IsNot Nothing Then
                                            vetTamanhoColunas(coluna) = CInt(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna))
                                        Else
                                            vetTamanhoColunas(coluna) = CInt(0)
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), Object)

                                        If Campos_Dados_CampoBase_Operacao_DadoBase(1)(coluna) IsNot Nothing Then
                                            If Campos_Dados_CampoBase_Operacao_DadoBase(2)(coluna) IsNot Nothing Then
                                                mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                            Else
                                                mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                            End If
                                        Else
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3), "{0} = @{1}", "{0} = @{1}, "), vetNomeColunas(coluna), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) + intLinhasAdicionais Then
                                mtdExecutarParametroComandoOleDb(String.Format("Alterar_{0}", strCampoBase), objDadoBase)

                                saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} @Alterar_{2};", NomeTabela, strTexto, strCampoBase, strOperacao))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAtualizarDadosParametroComandoOleDb(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object()(), ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdAtualizarDadosParametroComandoOleDbValor(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdAtualizarDadosParametroComandoOleDbValorTipo(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdAtualizarDadosParametroComandoOleDbValorTipoTamanho(NomeTabela, Campos_Dados_CampoBase_Operacao_DadoBase)
                    Exit Select
            End Select
            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoOleDbValor(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        objResgistrosColunas = Nothing
                        prpComandoOleDb.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To Campos_Dados.GetUpperBound(1)
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                    objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "@{0}, ", "@{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoOleDbValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        objResgistrosColunas = Nothing
                        prpComandoOleDb.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To Campos_Dados.GetUpperBound(1)
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                                Case (1)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados(linha, coluna), System.Data.OleDb.OleDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    If Campos_Dados(1, coluna) IsNot Nothing Then
                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                    Else
                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "@{0}, ", "@{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoOleDbValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        Select Case linha
                            Case (0)
                                vetNomeColunas = New String(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (1)
                                vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case (2)
                                vetTamanhoColunas = New Integer(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                            Case Else
                                vetRegistrosColunas = New Object(Campos_Dados.GetUpperBound(1)) {}
                                Exit Select
                        End Select

                        objResgistrosColunas = Nothing
                        prpComandoOleDb.Parameters.Clear()

                        For coluna As Integer = Campos_Dados.GetLowerBound(1) To Campos_Dados.GetUpperBound(1)
                            Select Case linha
                                Case (0)
                                    vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), String)
                                    strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                                Case (1)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTipoColunas(coluna) = CType(Campos_Dados(linha, coluna), System.Data.OleDb.OleDbType)
                                    Else
                                        vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                    End If
                                    Exit Select
                                Case (2)
                                    If Campos_Dados(linha, coluna) IsNot Nothing Then
                                        vetTamanhoColunas(coluna) = CInt(Campos_Dados(linha, coluna))
                                    Else
                                        vetTamanhoColunas(coluna) = CInt(0)
                                    End If
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha, coluna), Object)

                                    If Campos_Dados(1, coluna) IsNot Nothing Then
                                        If Campos_Dados(2, coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        End If
                                    Else
                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                    End If

                                    objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "@{0}, ", "@{0}"), vetNomeColunas(coluna)))
                                    Exit Select
                            End Select
                        Next
                        If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                            saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdInserirDadosParametroComandoOleDb(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,), ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdInserirDadosParametroComandoOleDbValor(NomeTabela, Campos_Dados)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdInserirDadosParametroComandoOleDbValorTipo(NomeTabela, Campos_Dados)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdInserirDadosParametroComandoOleDbValorTipoTamanho(NomeTabela, Campos_Dados)
                    Exit Select
            End Select
            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoOleDbValor(ByVal NomeTabela As String, ByVal Campos_Dados As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 1
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            objResgistrosColunas = Nothing
                            prpComandoOleDb.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To Campos_Dados(linha).GetUpperBound(0)
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))

                                        objResgistrosColunas = CObj(CStr(String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "@{0}, ", "@{0}"), vetNomeColunas(coluna))))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoOleDbValorTipo(ByVal NomeTabela As String, ByVal Campos_Dados As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 2
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            objResgistrosColunas = Nothing
                            prpComandoOleDb.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To Campos_Dados(linha).GetUpperBound(0)
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados(linha)(coluna), System.Data.OleDb.OleDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        If Campos_Dados(1)(coluna) IsNot Nothing Then
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                        Else
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "@{0}, ", "@{0}"), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Private Function mtdInserirDadosParametroComandoOleDbValorTipoTamanho(ByVal NomeTabela As String, ByVal Campos_Dados As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim intLinhasAdicionais As Integer = 3
            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing
            Dim vetNomeColunas As String() = Nothing
            Dim vetTipoColunas As System.Data.OleDb.OleDbType() = Nothing
            Dim vetTamanhoColunas As Integer() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados IsNot Nothing Then
                If Campos_Dados.GetLength(0) >= intLinhasAdicionais + 1 Then
                    For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                        If Campos_Dados(linha) IsNot Nothing Then
                            Select Case linha
                                Case (0)
                                    vetNomeColunas = New String(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (1)
                                    vetTipoColunas = New System.Data.OleDb.OleDbType(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case (2)
                                    vetTamanhoColunas = New Integer(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                                Case Else
                                    vetRegistrosColunas = New Object(Campos_Dados(linha).GetUpperBound(0)) {}
                                    Exit Select
                            End Select

                            objResgistrosColunas = Nothing
                            prpComandoOleDb.Parameters.Clear()

                            For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To Campos_Dados(linha).GetUpperBound(0)
                                Select Case linha
                                    Case (0)
                                        vetNomeColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), String)
                                        strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "{0}, ", "{0}"), vetNomeColunas(coluna)))
                                        Exit Select
                                    Case (1)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTipoColunas(coluna) = CType(Campos_Dados(linha)(coluna), System.Data.OleDb.OleDbType)
                                        Else
                                            vetTipoColunas(coluna) = System.Data.OleDb.OleDbType.[Variant]
                                        End If
                                        Exit Select
                                    Case (2)
                                        If Campos_Dados(linha)(coluna) IsNot Nothing Then
                                            vetTamanhoColunas(coluna) = CInt(Campos_Dados(linha)(coluna))
                                        Else
                                            vetTamanhoColunas(coluna) = CInt(0)
                                        End If
                                        Exit Select
                                    Case Else
                                        vetRegistrosColunas(coluna) = DirectCast(Campos_Dados(linha)(coluna), Object)

                                        If Campos_Dados(1)(coluna) IsNot Nothing Then
                                            If Campos_Dados(2)(coluna) IsNot Nothing Then
                                                mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna), vetTamanhoColunas(coluna))
                                            Else
                                                mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetTipoColunas(coluna), vetRegistrosColunas(coluna))
                                            End If
                                        Else
                                            mtdExecutarParametroComandoOleDb(vetNomeColunas(coluna), vetRegistrosColunas(coluna))
                                        End If

                                        objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "@{0}, ", "@{0}"), vetNomeColunas(coluna)))
                                        Exit Select
                                End Select
                            Next
                            If linha >= Campos_Dados.GetLowerBound(0) + intLinhasAdicionais Then
                                saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                            End If
                        End If
                    Next
                End If
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdInserirDadosParametroComandoOleDb(ByVal NomeTabela As String, ByVal Campos_Dados As Object()(), ByVal ModoParametroComando As enmModoParametroComando) As Boolean
            Dim saida As Boolean = False
            Select Case ModoParametroComando
                Case enmModoParametroComando.Valor
                    saida = mtdInserirDadosParametroComandoOleDbValor(NomeTabela, Campos_Dados)
                    Exit Select
                Case enmModoParametroComando.ValorTipo
                    saida = mtdInserirDadosParametroComandoOleDbValorTipo(NomeTabela, Campos_Dados)
                    Exit Select
                Case enmModoParametroComando.ValorTipoTamanho
                    saida = mtdInserirDadosParametroComandoOleDbValorTipoTamanho(NomeTabela, Campos_Dados)
                    Exit Select
            End Select
            Return saida
        End Function

        Public Function mtdDeletarDadosParametroComandoOleDb(ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = True

            mtdExecutarParametroComandoOleDb(CampoSelecionador, Dado)

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("DELETE FROM {0} WHERE {1} {2} @{1};", NomeTabela, CampoSelecionador, Operacao))
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdSelecionarDadosParametroComandoOleDb(ByVal NumeroLinhas As UInteger, ByVal Campos As String, ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = True

            mtdExecutarParametroComandoOleDb(CampoSelecionador, Dado)

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("SELECT {0}{1} FROM {2} WHERE {3} {4} @{3};", If(NumeroLinhas <> 0, String.Format("TOP {0} ", NumeroLinhas), String.Empty), Campos, NomeTabela, CampoSelecionador, Operacao, _
             Dado))

            Return saida
        End Function
    End Class
End Namespace