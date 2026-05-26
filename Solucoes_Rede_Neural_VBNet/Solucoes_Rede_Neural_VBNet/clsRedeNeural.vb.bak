Imports System.Math

Namespace Solucoes_Rede_Neural_VBCoreNet
    Public Class clsRedeNeural
        ' Variáveis de classe.
        Private Shared objRandom As New Random()
        ' Variáveis de instância.
        Private NumEntrada As Integer, NumPadroes As Integer, NumSaida As Integer, NumEscondida As Integer, NumIteracoes As Integer
        Private i, j, k, p, np, op, epoca As Integer
        Private Erro As Double, eta As Double = 0.05, alpha As Double = 0, wmax As Double = 1
        Private rando As Double = objRandom.NextDouble
        Private tipoerro As String = String.Empty, tiposaida As String = String.Empty,
        tipodelta As String = String.Empty, tipoprioridade As String = String.Empty
        Private NumPadroesConferencia As Integer
        Private resultado As String = String.Empty
        Private dblMaximoValor As Double = 0
        Public Function Autor() As String
            Return "Joel Fernado Jardim Martins"
        End Function
        Public Function Adaptado_por() As String
            Return "Hebervaldo de Paula Carvalhêdo"
        End Function
        Public Function Nota_do_Autor() As String
            Return "Projeto final de conclusão de curso de Engenharia Elétrica na UNB, que trata sobre redes neurais."
        End Function
        Public Function Nota_do_Aplicativo() As String
            Return "Módulo de Rede Neural feito em VB.NET."
        End Function
        Public Overloads Function mtdExecutar(ByRef entrada(,) As Double, ByRef target(,) As Double, ByVal NumeroEscondida As Integer,
        ByVal NumeroIteracoes As Integer, ByRef erro As Double, ByVal erro_max As Double, ByVal tiposaida As String, ByVal tipoerro As String,
        ByVal tipodelta As String, ByRef resultado As String, ByRef strerro As String, ByRef strpesos As String,
        ByRef epocaporcent As Double, ByRef tempoexecucao As Date, ByVal ModoOperacao As String) As Boolean
            Me.NumEntrada = entrada.GetUpperBound(1) - entrada.GetLowerBound(1)
            Me.NumSaida = target.GetUpperBound(1) - target.GetLowerBound(1)
            Me.NumPadroes = entrada.GetUpperBound(0) - entrada.GetLowerBound(0)
            Me.NumPadroesConferencia = target.GetUpperBound(0) - target.GetLowerBound(0)
            Me.NumEscondida = NumeroEscondida
            Me.NumIteracoes = NumeroIteracoes
            Dim W12(NumEntrada + 1, NumEscondida + 1) As Double
            Dim W23(NumEscondida + 1, NumSaida + 1) As Double
            ' Os dois laços a seguir geram valores aleatórios para os vetores pesos W12 e W23.
            For j = 1 To NumEscondida Step 1
                For i = 0 To NumEntrada Step 1
                    rando = objRandom.NextDouble()
                    W12(i, j) = 2.0 * (rando - 0.5) * wmax
                Next
            Next
            For k = 1 To NumSaida Step 1 ' inicializa W23 e DeltaW23 
                For j = 0 To NumEscondida Step 1
                    rando = objRandom.NextDouble()
                    W23(j, k) = 2.0 * (rando - 0.5) * wmax
                Next
            Next
            Return mtdRotina(entrada, target, W12, W23, NumeroEscondida, NumeroIteracoes, erro, erro_max, tiposaida, tipoerro,
            tipodelta, resultado, strerro, strpesos, epocaporcent, tempoexecucao)
        End Function
        Public Overloads Function mtdExecutar(ByRef entrada(,) As Double, ByRef target(,) As Double, ByRef W12(,) As Double,
        ByRef W23(,) As Double, ByVal NumeroEscondida As Integer, ByVal NumeroIteracoes As Integer, ByRef erro As Double, ByVal erro_max As Double,
        ByVal tiposaida As String, ByVal tipoerro As String, ByVal tipodelta As String, ByRef resultado As String, ByRef strerro As String,
        ByRef strpesos As String, ByRef epocaporcent As Double, ByRef tempoexecucao As Date, ByVal ModoOperacao As String) As Boolean
            Me.NumEntrada = entrada.GetUpperBound(1) - entrada.GetLowerBound(1)
            Me.NumSaida = target.GetUpperBound(1) - target.GetLowerBound(1)
            Me.NumPadroes = entrada.GetUpperBound(0) - entrada.GetLowerBound(0)
            Me.NumPadroesConferencia = target.GetUpperBound(0) - target.GetLowerBound(0)
            Me.NumEscondida = NumeroEscondida
            Me.NumIteracoes = NumeroIteracoes
            ' Zerar o vetor target para que não haja influência do target no resultado.
            For linha As Integer = target.GetLowerBound(0) To target.GetUpperBound(0)
                For coluna As Integer = target.GetLowerBound(1) To target.GetUpperBound(1)
                    target(linha, coluna) = 0
                Next
            Next
            Return mtdRotina(entrada, target, W12, W23, NumeroEscondida, NumeroIteracoes, erro, erro_max, tiposaida, tipoerro,
            tipodelta, resultado, strerro, strpesos, epocaporcent, tempoexecucao)
        End Function
        Private Function mtdRotina(ByVal entrada(,) As Double, ByVal target(,) As Double, ByRef W12(,) As Double, ByRef W23(,) As Double, ByVal NumeroEscondida As Integer,
        ByVal NumeroIteracoes As Integer, ByRef erro As Double, ByVal erro_max As Double, ByVal tiposaida As String, ByVal tipoerro As String,
        ByVal tipodelta As String, ByRef resultado As String, ByRef strerro As String, ByRef strpesos As String,
        ByRef epocaporcent As Double, ByRef tempoexecucao As Date) As Boolean
            Dim blnMensagem As Boolean = False
            resultado = String.Empty
            Dim dblmaxvetvalor As Double
            Dim ranpad(NumPadroes + 1) As Integer
            Dim SomaEscondida(NumPadroes + 1, NumEscondida + 1) As Double
            Dim Escondida(NumPadroes + 1, NumEscondida + 1) As Double
            Dim SomaSaida(NumPadroes + 1, NumSaida + 1) As Double
            Dim SAIDA(NumPadroes + 1, NumSaida + 1) As Double
            Dim DeltaS(NumSaida + 1) As Double
            Dim somaDWS(NumEscondida + 1) As Double
            Dim DeltaE(NumEscondida + 1) As Double
            Dim DeltaW12(NumEntrada + 1, NumEscondida + 1) As Double
            Dim DeltaW23(NumEscondida + 1, NumSaida + 1) As Double
            Dim maxvetentrada As Double = mtdMaximoValor(entrada)
            Dim maxvettarget As Double = mtdMaximoValor(target)
            Dim restoepoca As Integer = 0
            Dim divNumIteracoes As Integer = Convert.ToInt32(NumIteracoes / 100)
            strerro = String.Empty
            strpesos = String.Empty
            If (divNumIteracoes <> 0) Then
                restoepoca = epoca Mod divNumIteracoes
            Else
                restoepoca = 0
            End If
            If maxvetentrada > maxvettarget Then
                dblmaxvetvalor = maxvetentrada
            Else
                dblmaxvetvalor = maxvettarget
            End If
            mtdNormalizarMatriz(entrada, dblmaxvetvalor)
            mtdNormalizarMatriz(target, dblmaxvetvalor)
            If NumPadroes = NumPadroesConferencia Then
                For epoca = 0 To NumIteracoes - 1 Step 1 ' faz a iteração da atualização dos pesos
                    For p = 1 To NumPadroes Step 1 ' randomiza a ordem dos indivíduos
                        ranpad(p) = p
                    Next
                    For p = 1 To NumPadroes Step 1
                        rando = objRandom.NextDouble()
                        np = Convert.ToInt32(Math.Truncate(p + rando * (NumPadroes + 1 - p)))
                        op = ranpad(p)
                        ranpad(p) = ranpad(np)
                        ranpad(np) = op
                    Next
                    Me.Erro = 0
                    For np = 1 To NumPadroes Step 1 ' repete para todos os padrões de treinamento
                        p = ranpad(np)
                        For j = 1 To NumEscondida Step 1 ' computa as ativações da unidade escondida
                            SomaEscondida(p, j) = W12(0, j)
                            For i = 1 To NumEntrada Step 1
                                SomaEscondida(p, j) += entrada(p, i) * W12(i, j)
                            Next
                            Escondida(p, j) = 1 / (1 + Exp(-SomaEscondida(p, j)))
                            ' Escondida(p, j) = (Exp(SomaSaida(p, j)) - Exp(-SomaSaida(p, j))) / (Exp(SomaSaida(p, j)) + Exp(-SomaSaida(p, j)))
                        Next
                        For k = 1 To NumSaida Step 1 ' computa as unidades de ativação da saída e erros
                            SomaSaida(p, k) = W23(0, k)
                            For j = 1 To NumEscondida Step 1
                                SomaSaida(p, k) += Escondida(p, j) * W23(j, k)
                            Next
                            If tiposaida = "Sigmoidal SAIDAs" Then
                                SAIDA(p, k) = 1 / (1 + Exp(-SomaSaida(p, k))) ' Sigmoidal SAIDAs
                                ' SAIDA(p, k) = (Exp(SomaSaida(p, k)) - Exp(-SomaSaida(p, k))) / (Exp(SomaSaida(p, k)) + Exp(-SomaSaida(p, k))) ' Sigmoidal SAIDAs
                            ElseIf tiposaida = "Linear SAIDAs" Then
                                SAIDA(p, k) = SomaSaida(p, k) ' Linear SAIDAs
                            End If
                            If tipoerro = "SSE" Then
                                Me.Erro += 0.5 * ((target(p, k) - SAIDA(p, k)) ^ 2)  ' SSE 
                            ElseIf tipoerro = "Erro de Entropia Cruzada" Then
                                Me.Erro -= (target(p, k) * Log(SAIDA(p, k)) + (1 - target(p, k)) * Log(1 - SAIDA(p, k))) ' Erro de Entropia Cruzada
                            End If
                            If tipodelta = "Sigmoidal SAIDAs, SSE" Then
                                DeltaS(k) = (target(p, k) - SAIDA(p, k)) * SAIDA(p, k) * (1 - SAIDA(p, k)) ' Sigmoidal SAIDAs, SSE 
                            ElseIf tipodelta = "Sigmoidal SAIDAs, Cross-Entropy Erro" Then
                                DeltaS(k) = target(p, k) - SAIDA(p, k) ' Sigmoidal SAIDAs, Cross-Entropy Erro 
                            End If
                            ' DeltaS((k) = target(p, k) - SAIDA(p, k)) ' Linear SAIDAs, SSE
                        Next
                        For j = 1 To NumEscondida Step 1 '  retropropagação de erros para a camada escondida
                            somaDWS(j) = 0
                            For k = 1 To NumSaida Step 1
                                somaDWS(j) += W23(j, k) * DeltaS(k)
                            Next
                            DeltaE(j) = somaDWS(j) * Escondida(p, j) * (1 - Escondida(p, j))
                        Next
                        For j = 1 To NumEscondida Step 1 ' atualiza pesos w12
                            DeltaW12(0, j) = eta * DeltaE(j) + alpha * DeltaW12(0, j)
                            W12(0, j) += DeltaW12(0, j)
                            For i = 1 To NumEntrada Step 1
                                DeltaW12(i, j) = eta * entrada(p, i) * DeltaE(j) + alpha * DeltaW12(i, j)
                                W12(i, j) += DeltaW12(i, j)
                            Next
                        Next
                        For k = 1 To NumSaida Step 1   ' atualiza pesos W23 
                            DeltaW23(0, k) = eta * DeltaS(k) + alpha * DeltaW23(0, k)
                            W23(0, k) += DeltaW23(0, k)
                            For j = 1 To NumEscondida Step 1
                                DeltaW23(j, k) = eta * Escondida(p, j) * DeltaS(k) + alpha * DeltaW23(j, k)
                                W23(j, k) += DeltaW23(j, k)
                            Next
                        Next
                    Next
                    erro = Me.Erro
                    strerro &= "epoca" & vbTab & epoca & vbTab & "erro" & vbTab & Me.Erro & Convert.ToChar(13).ToString() & Convert.ToChar(10).ToString()
                    epocaporcent = (epoca / NumIteracoes) * 100
                    tempoexecucao = DateTime.Now
                    If Me.Erro < erro_max Then Exit For ' pára o aprendizado quando o erro convergir para o valor descrito
                Next
                mtdDesNormalizarMatriz(entrada, dblmaxvetvalor)
                mtdDesNormalizarMatriz(target, dblmaxvetvalor)
                mtdDesNormalizarMatriz(SAIDA, dblmaxvetvalor)
                For p As Integer = 1 To NumPadroes Step 1
                    For i As Integer = entrada.GetLowerBound(1) + 1 To entrada.GetUpperBound(1) Step 1
                        resultado &= entrada(p, i) & vbTab
                    Next
                    For i As Integer = target.GetLowerBound(1) + 1 To target.GetUpperBound(1) Step 1
                        resultado &= target(p, i) & vbTab
                    Next
                    For i As Integer = target.GetLowerBound(1) + 1 To target.GetUpperBound(1) Step 1
                        resultado &= SAIDA(p, i) & vbTab
                    Next
                    resultado &= Convert.ToChar(13).ToString() & Convert.ToChar(10).ToString()
                Next
                strpesos = mtdPesos(W23, mtdPesos(W12, String.Empty) & Convert.ToChar(13).ToString() & Convert.ToChar(10).ToString())
                resultado = resultado.Trim()
                strerro = strerro.Trim()
                blnMensagem = True ' "O comprimento do vetor entrada é igual do comprimento do vetor target."
                epocaporcent = 100
                tempoexecucao = DateTime.Now
            Else
                blnMensagem = False ' "O comprimento do vetor entrada é diferente do comprimento do vetor target."
            End If
            Return blnMensagem
        End Function
        Private Sub mtdNormalizarMatriz(ByRef matriz(,) As Double, ByVal maxvalorvetor As Double)
            For linha As Integer = matriz.GetLowerBound(0) To matriz.GetUpperBound(0) Step 1
                For coluna As Integer = matriz.GetLowerBound(1) To matriz.GetUpperBound(1) Step 1
                    matriz(linha, coluna) /= maxvalorvetor
                Next
            Next
        End Sub
        Private Sub mtdDesNormalizarMatriz(ByRef matriz(,) As Double, ByVal maxvalorvetor As Double)
            For linha As Integer = matriz.GetLowerBound(0) To matriz.GetUpperBound(0) Step 1
                For coluna As Integer = matriz.GetLowerBound(1) To matriz.GetUpperBound(1) Step 1
                    matriz(linha, coluna) *= maxvalorvetor
                Next
            Next
        End Sub
        Private Function mtdMaximoValor(ByVal matriz(,) As Double) As Double
            For linha As Integer = matriz.GetLowerBound(0) To matriz.GetUpperBound(0) Step 1
                For coluna As Integer = matriz.GetLowerBound(1) To matriz.GetUpperBound(1) Step 1
                    If matriz(linha, coluna) > dblMaximoValor Then
                        dblMaximoValor = matriz(linha, coluna)
                    End If
                Next
            Next
            Return dblMaximoValor
        End Function
        Private Function mtdPesos(ByVal matriz(,) As Double, ByVal TextoAnterior As String) As String
            Dim saida As String = TextoAnterior
            For linha As Integer = matriz.GetLowerBound(1) + 1 To matriz.GetUpperBound(1) - 1 Step 1
                For coluna As Integer = matriz.GetLowerBound(0) To matriz.GetUpperBound(0) - 1 Step 1
                    saida &= matriz(coluna, linha).ToString()
                    saida &= Convert.ToChar(9).ToString()
                Next
                saida = saida.Trim()
                saida &= Convert.ToChar(13).ToString() & Convert.ToChar(10).ToString()
            Next
            Return saida.Trim()
        End Function
    End Class
End Namespace