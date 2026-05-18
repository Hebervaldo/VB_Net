Imports System.Collections.Generic
Imports System.Text

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class clsImplementacaoBancoDados
        Inherits clsConexaoBancoDados
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

        Public Enum enmModoParametroComando
            Valor
            ValorTipo
            ValorTipoTamanho
        End Enum

        Public Function mtdAlterarTabela(ByVal Nome As String, ByVal Operacao_Campo_Tipo_Comprimento_Restricao As String) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional) AndAlso mtdExecutarComando(String.Format("ALTER TABLE {0} {1});", Nome, Operacao_Campo_Tipo_Comprimento_Restricao))
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAlterarTabela(ByVal Nome As String, ByVal Operacao_Campo_Tipo_Comprimento_Restricao As String(,)) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("O numero de colunas está incorreto, informe uma matriz com cinco colunas.")

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Operacao_Campo_Tipo_Comprimento_Restricao.GetUpperBound(1) + 1 = 5 Then
                Dim strTexto As StringBuilder = New StringBuilder()
                For linha As Integer = Operacao_Campo_Tipo_Comprimento_Restricao.GetLowerBound(0) To Operacao_Campo_Tipo_Comprimento_Restricao.GetUpperBound(0)
                    For coluna As Integer = Operacao_Campo_Tipo_Comprimento_Restricao.GetLowerBound(1) To Operacao_Campo_Tipo_Comprimento_Restricao.GetUpperBound(1)
                        Select Case coluna
                            Case 0
                                strTexto.Append(String.Format("{0} ", Operacao_Campo_Tipo_Comprimento_Restricao(linha, coluna)))
                                Exit Select
                            Case 1
                                strTexto.Append(String.Format("{0} ", Operacao_Campo_Tipo_Comprimento_Restricao(linha, coluna)))
                                Exit Select
                            Case 2
                                If Operacao_Campo_Tipo_Comprimento_Restricao(linha, coluna + 1).Equals(String.Empty) Then
                                    strTexto.Append(String.Format("{0} ", Operacao_Campo_Tipo_Comprimento_Restricao(linha, coluna)))
                                Else
                                    strTexto.Append(String.Format("{0}", Operacao_Campo_Tipo_Comprimento_Restricao(linha, coluna)))
                                End If
                                Exit Select
                            Case 3
                                If Operacao_Campo_Tipo_Comprimento_Restricao(linha, coluna).Equals(String.Empty) Then
                                    strTexto.Append(String.Empty)
                                Else
                                    strTexto.Append(String.Format("({0})", Operacao_Campo_Tipo_Comprimento_Restricao(linha, coluna)))
                                End If
                                Exit Select
                            Case 4
                                strTexto.Append(String.Format("{0}", Operacao_Campo_Tipo_Comprimento_Restricao(linha, coluna)))
                                Exit Select
                        End Select
                    Next
                    saida = saida And mtdExecutarComando(String.Format("ALTER TABLE {0} {1};", Nome, strTexto))
                Next
            Else
                setExcecao = ex.Message
                saida = False
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAlterarTabela(ByVal Nome As String, ByVal Operacao_Campo_Tipo_Comprimento_Restricao As String()()) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("O numero de colunas está incorreto, informe uma matriz com cinco colunas.")

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            Dim strTexto As StringBuilder = New StringBuilder()
            For linha As Integer = Operacao_Campo_Tipo_Comprimento_Restricao.GetLowerBound(0) To Operacao_Campo_Tipo_Comprimento_Restricao.GetUpperBound(0)
                If Operacao_Campo_Tipo_Comprimento_Restricao(linha).GetUpperBound(0) + 1 = 5 Then
                    For coluna As Integer = Operacao_Campo_Tipo_Comprimento_Restricao(linha).GetLowerBound(0) To Operacao_Campo_Tipo_Comprimento_Restricao(linha).GetUpperBound(0)
                        Select Case coluna
                            Case 0
                                strTexto.Append(String.Format("{0} ", Operacao_Campo_Tipo_Comprimento_Restricao(linha)(coluna)))
                                Exit Select
                            Case 1
                                strTexto.Append(String.Format("{0} ", Operacao_Campo_Tipo_Comprimento_Restricao(linha)(coluna)))
                                Exit Select
                            Case 2
                                If Operacao_Campo_Tipo_Comprimento_Restricao(linha)(coluna + 1).Equals(String.Empty) Then
                                    strTexto.Append(String.Format("{0} ", Operacao_Campo_Tipo_Comprimento_Restricao(linha)(coluna)))
                                Else
                                    strTexto.Append(String.Format("{0}", Operacao_Campo_Tipo_Comprimento_Restricao(linha)(coluna)))
                                End If
                                Exit Select
                            Case 3
                                If Operacao_Campo_Tipo_Comprimento_Restricao(linha)(coluna).Equals(String.Empty) Then
                                    strTexto.Append(String.Empty)
                                Else
                                    strTexto.Append(String.Format("({0})", Operacao_Campo_Tipo_Comprimento_Restricao(linha)(coluna)))
                                End If
                                Exit Select
                            Case 4
                                strTexto.Append(String.Format("{0}", Operacao_Campo_Tipo_Comprimento_Restricao(linha)(coluna)))
                                Exit Select
                        End Select
                    Next
                Else
                    setExcecao = ex.Message
                    saida = False
                End If
                saida = saida And mtdExecutarComando(String.Format("ALTER TABLE {0} {1};", Nome, strTexto))
            Next
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdCriarTabela(ByVal Nome As String, ByVal Registro_Tipo_Comprimento_Restricao As String) As Boolean
            Dim saida As Boolean = True

            saida = mtdExecutarComando(String.Format("CREATE TABLE {0}({1});", Nome, Registro_Tipo_Comprimento_Restricao))
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdCriarTabela(ByVal Nome As String, ByVal Registro_Tipo_Comprimento_Restricao As String(,)) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("O numero de colunas está incorreto, informe uma matriz com quatro colunas.")

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Registro_Tipo_Comprimento_Restricao.GetUpperBound(1) + 1 = 4 Then
                Dim strTexto As StringBuilder = New StringBuilder()
                For linha As Integer = Registro_Tipo_Comprimento_Restricao.GetLowerBound(0) To Registro_Tipo_Comprimento_Restricao.GetUpperBound(0)
                    For coluna As Integer = Registro_Tipo_Comprimento_Restricao.GetLowerBound(1) To Registro_Tipo_Comprimento_Restricao.GetUpperBound(1)
                        Select Case coluna
                            Case 0
                                strTexto.Append(String.Format("{0} ", Registro_Tipo_Comprimento_Restricao(linha, coluna)))
                                Exit Select
                            Case 1
                                If Registro_Tipo_Comprimento_Restricao(linha, coluna + 1).Equals(String.Empty) Then
                                    strTexto.Append(String.Format("{0} ", Registro_Tipo_Comprimento_Restricao(linha, coluna)))
                                Else
                                    strTexto.Append(String.Format("{0}", Registro_Tipo_Comprimento_Restricao(linha, coluna)))
                                End If
                                Exit Select
                            Case 2
                                If Registro_Tipo_Comprimento_Restricao(linha, coluna).Equals(String.Empty) Then
                                    strTexto.Append(String.Empty)
                                Else
                                    strTexto.Append(String.Format("({0})", Registro_Tipo_Comprimento_Restricao(linha, coluna)))
                                End If
                                Exit Select
                            Case 3
                                strTexto.Append(String.Format("{0}", Registro_Tipo_Comprimento_Restricao(linha, coluna)))
                                Exit Select
                        End Select
                    Next
                    If linha <> Registro_Tipo_Comprimento_Restricao.GetUpperBound(0) Then
                        strTexto.Append(", ")
                    End If
                Next
                saida = saida And mtdExecutarComando(String.Format("CREATE TABLE {0}({1});", Nome, strTexto))
            Else
                setExcecao = ex.Message
                saida = False
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdCriarTabela(ByVal Nome As String, ByVal Registro_Tipo_Comprimento_Restricao As String()()) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("O numero de colunas está incorreto, informe uma matriz com quatro colunas.")

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            Dim strTexto As StringBuilder = New StringBuilder()
            For linha As Integer = Registro_Tipo_Comprimento_Restricao.GetLowerBound(0) To Registro_Tipo_Comprimento_Restricao.GetUpperBound(0)
                If Registro_Tipo_Comprimento_Restricao(linha).GetUpperBound(0) + 1 = 4 Then
                    For coluna As Integer = Registro_Tipo_Comprimento_Restricao(linha).GetLowerBound(0) To Registro_Tipo_Comprimento_Restricao(linha).GetUpperBound(0)
                        Select Case coluna
                            Case 0
                                strTexto.Append(String.Format("{0} ", Registro_Tipo_Comprimento_Restricao(linha)(coluna)))
                                Exit Select
                            Case 1
                                If Registro_Tipo_Comprimento_Restricao(linha)(coluna + 1).Equals(String.Empty) Then
                                    strTexto.Append(String.Format("{0} ", Registro_Tipo_Comprimento_Restricao(linha)(coluna)))
                                Else
                                    strTexto.Append(String.Format("{0}", Registro_Tipo_Comprimento_Restricao(linha)(coluna)))
                                End If
                                Exit Select
                            Case 2
                                If Registro_Tipo_Comprimento_Restricao(linha)(coluna).Equals(String.Empty) Then
                                    strTexto.Append(String.Empty)
                                Else
                                    strTexto.Append(String.Format("({0})", Registro_Tipo_Comprimento_Restricao(linha)(coluna)))
                                End If
                                Exit Select
                            Case 3
                                strTexto.Append(String.Format("{0}", Registro_Tipo_Comprimento_Restricao(linha)(coluna)))
                                Exit Select
                        End Select
                    Next
                    If linha <> Registro_Tipo_Comprimento_Restricao.GetUpperBound(0) AndAlso Registro_Tipo_Comprimento_Restricao(linha + 1) IsNot Nothing Then
                        strTexto.Append(", ")
                    End If
                Else
                    setExcecao = ex.Message
                    saida = False
                End If
            Next
            saida = saida And mtdExecutarComando(String.Format("CREATE TABLE {0}({1});", Nome, strTexto))
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdDeletarTabela(ByVal Nome As String) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("DROP TABLE {0};", Nome))
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAtualizarDados(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                    strTexto = New StringBuilder
                    If linha <> Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) Then
                        strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 2), String)
                        strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 1), String)
                        objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha, Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1))
                        vetRegistrosColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                    Else
                        vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1)) {}
                    End If

                    For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(1) To (If((linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0)), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1), Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3))
                        If linha <> Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) Then
                            vetRegistrosColunas(coluna) = Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna)

                            strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(1) - 3), "{0} = {1}", "{0} = {1}, "), vetNomeColunas(coluna), DirectCast(vetRegistrosColunas(coluna), Object)))
                        Else
                            vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha, coluna), String)
                        End If
                    Next
                    If linha <> Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) Then
                        saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, strTexto, strCampoBase, strOperacao, DirectCast(objDadoBase, Object)))
                    End If
                Next
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAtualizarDados(ByVal NomeTabela As String, ByVal Campos_Dados_CampoBase_Operacao_DadoBase As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim strCampoBase As String = String.Empty
            Dim strOperacao As String = String.Empty
            Dim objDadoBase As Object = String.Empty
            Dim strTexto As StringBuilder = New StringBuilder()
            Dim vetNomeColunas As String() = Nothing
            Dim vetRegistrosColunas As Object() = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Campos_Dados_CampoBase_Operacao_DadoBase IsNot Nothing Then
                For linha As Integer = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) To Campos_Dados_CampoBase_Operacao_DadoBase.GetUpperBound(0)
                    If Campos_Dados_CampoBase_Operacao_DadoBase(linha) IsNot Nothing Then
                        strTexto = New StringBuilder
                        If linha <> Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) Then
                            strCampoBase = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 2), String)
                            strOperacao = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 1), String)
                            objDadoBase = Campos_Dados_CampoBase_Operacao_DadoBase(linha)(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0))
                            vetRegistrosColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                        Else
                            vetNomeColunas = New String(Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0)) {}
                        End If

                        For coluna As Integer = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetLowerBound(0) To (If((linha = Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0)), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0), Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3))
                            If linha <> Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) Then
                                vetRegistrosColunas(coluna) = Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna)

                                strTexto.Append(String.Format(If((coluna = Campos_Dados_CampoBase_Operacao_DadoBase(linha).GetUpperBound(0) - 3), "{0} = {1}", "{0} = {1}, "), vetNomeColunas(coluna), DirectCast(vetRegistrosColunas(coluna), Object)))
                            Else
                                vetNomeColunas(coluna) = DirectCast(Campos_Dados_CampoBase_Operacao_DadoBase(linha)(coluna), String)
                            End If
                        Next
                        If linha <> Campos_Dados_CampoBase_Operacao_DadoBase.GetLowerBound(0) Then
                            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, strTexto, strCampoBase, strOperacao, DirectCast(objDadoBase, Object)))
                        End If
                    End If
                Next
            End If
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdAtualizarDados(ByVal NomeTabela As String, ByVal CampoDado As Object, ByVal CampoBase As String, ByVal Operacao As String, ByVal DadoBase As Object) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("UPDATE {0} SET {1} WHERE {2} {3} {4};", NomeTabela, CampoDado, CampoBase, Operacao, DadoBase))
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdInserirDados(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,)) As Boolean
            Dim saida As Boolean = True

            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                If Campos_Dados IsNot Nothing Then
                    objResgistrosColunas = String.Empty
                    For coluna As Integer = Campos_Dados.GetLowerBound(1) To Campos_Dados.GetUpperBound(1)
                        If linha = Campos_Dados.GetLowerBound(0) Then
                            strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "{0}, ", "{0}"), Campos_Dados(linha, coluna)))
                        Else
                            objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados.GetUpperBound(1)), "{0}, ", "{0}"), Campos_Dados(linha, coluna)))
                        End If
                    Next
                    If linha <> Campos_Dados.GetLowerBound(0) Then
                        saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                    End If
                End If
            Next
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdInserirDados(ByVal NomeTabela As String, ByVal Campos_Dados As Object()()) As Boolean
            Dim saida As Boolean = True

            Dim strNomeColunas As StringBuilder = New StringBuilder()
            Dim objResgistrosColunas As Object = Nothing

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            For linha As Integer = Campos_Dados.GetLowerBound(0) To Campos_Dados.GetUpperBound(0)
                If Campos_Dados(linha) IsNot Nothing Then
                    objResgistrosColunas = String.Empty
                    For coluna As Integer = Campos_Dados(linha).GetLowerBound(0) To Campos_Dados(linha).GetUpperBound(0)
                        If linha = Campos_Dados.GetLowerBound(0) Then
                            strNomeColunas.Append(String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "{0}, ", "{0}"), Campos_Dados(linha)(coluna)))
                        Else
                            objResgistrosColunas = CObj(CStr(objResgistrosColunas) + String.Format(If((coluna <> Campos_Dados(linha).GetUpperBound(0)), "{0}, ", "{0}"), Campos_Dados(linha)(coluna)))
                        End If
                    Next
                    If linha <> Campos_Dados.GetLowerBound(0) Then
                        saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, strNomeColunas, objResgistrosColunas))
                    End If
                End If
            Next
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdInserirDados(ByVal NomeTabela As String, ByVal Campos As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("INSERT INTO {0}({1}) VALUES({2});", NomeTabela, Campos, Dado))
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdDeletarDados(ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("DELETE FROM {0} WHERE {1} {2} {3};", NomeTabela, CampoSelecionador, Operacao, Dado))
            mtdFecharConexao()

            Return saida
        End Function

        Public Function mtdVetorLinhaCampos(ByVal Campos As String()) As String
            Return mtdVetorLinhaCampos(String.Empty, Campos)
        End Function

        Public Function mtdVetorLinhaCampos(ByVal Tabela As String, ByVal Campos As String()) As String
            Dim strCampos As String = String.Empty
            For contador As Integer = Campos.GetLowerBound(0) To Campos.GetUpperBound(0)
                strCampos += String.Format(If((Not (contador = Campos.GetUpperBound(0))), IIf(Tabela <> String.Empty, "{0}.{1}, ", "{1}, ").ToString(), IIf(Tabela <> String.Empty, "{0}.{1}", "{1}").ToString()), Tabela, Campos(contador))
            Next
            Return strCampos
        End Function

        Public Function mtdSelecionarDados(ByVal Campos As String, ByVal NomeTabela As String) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("SELECT {0} FROM {1};", Campos, NomeTabela))

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal Campos As String(), ByVal NomeTabela As String) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdSelecionarDados(mtdVetorLinhaCampos(Campos), NomeTabela)

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal Campos As String, ByVal NomeTabela As String, ByVal CampoOrdenador As String, ByVal Crescente As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            If Crescente Then
                saida = saida And mtdExecutarComando(String.Format("SELECT {0} FROM {1} ORDER BY {2};", Campos, NomeTabela, CampoOrdenador))
            Else
                saida = saida And mtdExecutarComando(String.Format("SELECT {0} FROM {1} ORDER BY {2} DESC;", Campos, NomeTabela, CampoOrdenador))
            End If

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal Campos As String(), ByVal NomeTabela As String, ByVal CampoOrdenador As String, ByVal Crescente As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdSelecionarDados(mtdVetorLinhaCampos(Campos), NomeTabela, CampoOrdenador, Crescente)

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal Campos As String, ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("SELECT {0} FROM {1} WHERE {2} {3} {4};", Campos, NomeTabela, CampoSelecionador, Operacao, Dado))

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal Campos As String(), ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdSelecionarDados(mtdVetorLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, Dado)

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal Campos As String, ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object, ByVal CampoOrdenador As String, _
         ByVal Crescente As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("SELECT {0} FROM {1} WHERE {2} {3} {4} ORDER BY {5}{6};", Campos, NomeTabela, CampoSelecionador, Operacao, Dado, _
             CampoOrdenador, IIf(Crescente, String.Empty, " DESC")))

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal Campos As String(), ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object, ByVal CampoOrdenador As String, _
         ByVal Crescente As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdSelecionarDados(mtdVetorLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, Dado, CampoOrdenador, _
             Crescente)

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal Distinguir As Boolean, ByVal DistinguirLinha As Boolean, ByVal Campos As String, ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, _
         ByVal Dado As Object, ByVal CampoAgrupador As String) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("SELECT {0} {1} FROM {2} HAVING {3} {4} {5} GROUP BY {6};", If(Distinguir, If(DistinguirLinha, "DISTINCTROW", "DISTINCT"), String.Empty), Campos, NomeTabela, CampoSelecionador, Operacao, _
             Dado, CampoAgrupador))

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal Distinguir As Boolean, ByVal DistinguirLinha As Boolean, ByVal Campos As String(), ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, _
         ByVal Dado As Object, ByVal CampoAgrupador As String) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdSelecionarDados(Distinguir, DistinguirLinha, mtdVetorLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, _
             Dado, CampoAgrupador)

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal Distinguir As Boolean, ByVal DistinguirLinha As Boolean, ByVal Campos As String, ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, _
         ByVal Dado As Object, ByVal CampoAgrupador As String, ByVal CampoOrdenador As String, ByVal Crescente As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("SELECT {0} {1} FROM {2} WHERE {3} {4} {5} GROUP BY {6} ORDER BY {7}{8};", If(Distinguir, If(DistinguirLinha, "DISTINCTROW", "DISTINCT"), String.Empty), Campos, NomeTabela, CampoSelecionador, Operacao, _
             Dado, CampoAgrupador, CampoOrdenador, If(Crescente, String.Empty, " DESC")))

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal Distinguir As Boolean, ByVal DistinguirLinha As Boolean, ByVal Campos As String(), ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, _
         ByVal Dado As Object, ByVal CampoAgrupador As String, ByVal CampoOrdenador As String, ByVal Crescente As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdSelecionarDados(Distinguir, DistinguirLinha, mtdVetorLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, _
             Dado, CampoAgrupador, CampoOrdenador, Crescente)

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal NumeroLinhas As String, ByVal Campos As String, ByVal NomeTabela As String) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("SELECT {0}{1} FROM {2};", If(CInt(NumeroLinhas.Replace("(", String.Empty).Replace(")", String.Empty)) > 0, String.Format("TOP {0} ", NumeroLinhas), String.Empty), Campos, NomeTabela))

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal NumeroLinhas As String, ByVal Campos As String(), ByVal NomeTabela As String) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdSelecionarDados(NumeroLinhas, mtdVetorLinhaCampos(Campos), NomeTabela)

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal NumeroLinhas As String, ByVal Campos As String, ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("SELECT {0}{1} FROM {2} WHERE {3} {4} {5};", If(CInt(NumeroLinhas.Replace("(", String.Empty).Replace(")", String.Empty)) > 0, String.Format("TOP {0} ", NumeroLinhas), String.Empty), Campos, NomeTabela, CampoSelecionador, Operacao, _
             Dado))

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal NumeroLinhas As String, ByVal Campos As String(), ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdSelecionarDados(NumeroLinhas, mtdVetorLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, Dado)

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal NumeroLinhas As String, ByVal Campos As String, ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object, _
         ByVal CampoOrdenador As String, ByVal Crescente As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirConexao(prpConexao, prpTipoSistemaGerenciadorBancoDadosRelacional)
            saida = saida And mtdExecutarComando(String.Format("SELECT {0}{1} FROM {2} WHERE {3} {4} {5} ORDER BY {6}{7};", If(CInt(NumeroLinhas.Replace("(", String.Empty).Replace(")", String.Empty)) > 0, String.Format("TOP {0} ", NumeroLinhas), String.Empty), Campos, NomeTabela, CampoSelecionador, Operacao, _
                                                               Dado, CampoOrdenador, If(Crescente, String.Empty, " DESC")))

            Return saida
        End Function

        Public Function mtdSelecionarDados(ByVal NumeroLinhas As String, ByVal Campos As String(), ByVal NomeTabela As String, ByVal CampoSelecionador As String, ByVal Operacao As String, ByVal Dado As Object, _
         ByVal CampoOrdenador As String, ByVal Crescente As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdSelecionarDados(NumeroLinhas, mtdVetorLinhaCampos(Campos), NomeTabela, CampoSelecionador, Operacao, Dado, _
             CampoOrdenador, Crescente)

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