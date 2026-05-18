Imports System
Imports System.Text

Namespace prjRedeNeuralCSCoreNet
    Friend Class clsRedeNeural
        Private modEpocaDisplay As Integer = 1
        Public tempoInicial As Date
        Private tempoIntermediario As Date
        Public tempoFinal As Date
        Private TipoSaida As Integer = 0
        Private TipoErro As Integer = 0
        Private TipoDeltaS As Integer = 0
        Private i As Integer = 0
        Private j As Integer = 0
        Private k As Integer = 0
        Private p As Integer = 0
        Private np As Integer = 0
        Private op As Integer = 0
        Private epoca As Integer = 0
        Private numPadroes As Integer = 0
        Private numEntrada As Integer = 0
        Public numEscondida As Integer = 0
        Private numSaida As Integer = 0
        Public numIteracoes As Integer = 100
        Private minimoValorEntrada As Integer = 0
        Private maximoValorEntrada As Integer = 0
        Private minimoValorAlvo As Integer = 0
        Private maximoValorAlvo As Integer = 0

        ' int ranpad[NUMEROPADROES+1];
        Private ranpad As Integer()
        ' double entrada[NUMEROPADROES+1][NUMEROENTRADAS+1];
        Private entrada As Double()()
        ' double target[NUMEROPADROES+1][NUMEROSAIDAS+1];
        Private target As Double()()
        ' double SomaEscondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
        Private SomaEscondida As Double()()
        ' double W12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
        Private W12 As Double()()
        ' double Escondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
        Private Escondida As Double()()
        ' double SomaSaida[NUMEROPADROES+1][NUMEROSAIDAS+1]; 
        Private SomaSaida As Double()()
        ' double W23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1]; 
        Private W23 As Double()()
        ' double SAIDA[NUMEROPADROES+1][NUMEROSAIDAS+1];
        Private Saida As Double()()
        ' double DeltaS[NUMEROSAIDAS+1];
        Private DeltaS As Double()
        ' double somaDWS[NUMEROESCONDIDA+1];
        Private somaDWS As Double()
        ' double DeltaE[NUMEROESCONDIDA+1];
        Private DeltaE As Double()
        ' double DeltaW12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
        Private DeltaW12 As Double()()
        ' double DeltaW23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1];
        Private DeltaW23 As Double()()

        Private Erro As Double = 0
        Private eta As Double = 0.05
        Private alpha As Double = 0
        Private wmax As Double = 1
        Public erroLimite As Double = 0.0001
        Public primeiraExecucao As Integer = 1

        Private objRandom As Random = New Random()

        Public Sub New()
        End Sub

        Protected Overrides Sub Finalize()

        End Sub

        Private Function rando() As Double
            Return objRandom.NextDouble()
        End Function

        Public Class sttGerarArquivoMatriz
            Public Shared coluna As Integer = 0
            Public Shared linha As Integer = 0
            Public Shared comprimento As Integer = 0
            Public Shared minimoValor As Integer = 0
            Public Shared maximoValor As Integer = 0
        End Class

        Public Function mtdCriarVetorDinamicoInteger(ByVal Comprimento As Integer) As Integer()
            Dim Vetor = New Integer(Comprimento - 1) {}

            Return Vetor
        End Function

        Public Function mtdCriarMatrizDinamicaInteger(ByVal Linha As Integer, ByVal Coluna As Integer) As Integer()()
            Dim Matriz = New Integer(Linha - 1)() {}

            For i = 0 To Linha - 1
                Matriz(i) = New Integer(Coluna - 1) {}
            Next

            Return Matriz
        End Function

        Public Function mtdCriarVetorDinamicoDouble(ByVal Comprimento As Integer) As Double()
            Dim Vetor = New Double(Comprimento - 1) {}

            Return Vetor
        End Function

        Public Function mtdCriarMatrizDinamicaDouble(ByVal Linha As Integer, ByVal Coluna As Integer) As Double()()
            Dim Matriz = New Double(Linha - 1)() {}

            For i = 0 To Linha - 1
                Matriz(i) = New Double(Coluna - 1) {}
            Next

            Return Matriz
        End Function

        Public Sub mtdObterVetorDinamicoInteger(ByVal Vetor As Integer(), ByVal Comprimento As Integer)
            For i = 0 To Comprimento - 1
                System.Console.Write("Vetor[" & i & "]: " & Vetor(i))
            Next
        End Sub

        Public Sub mtdObterMatrizDinamicaInteger(ByVal Matriz As Integer()(), ByVal Linha As Integer, ByVal Coluna As Integer)
            For i = 0 To Linha - 1
                For j = 0 To Coluna - 1
                    System.Console.Write("Matriz[" & i & "][" & j & "]: " & Matriz(i)(j))
                Next
            Next
        End Sub

        Public Sub mtdObterVetorDinamicoDouble(ByVal Vetor As Double(), ByVal Comprimento As Integer)
            For i = 0 To Comprimento - 1
                System.Console.Write("Vetor[" & i & "]: " & Vetor(i))
            Next
        End Sub

        Public Sub mtdObterMatrizDinamicaDouble(ByVal Matriz As Double()(), ByVal Linha As Integer, ByVal Coluna As Integer)
            For i = 0 To Linha - 1
                For j = 0 To Coluna - 1
                    System.Console.Write("Matriz[" & i & "][" & j & "]: " & Matriz(i)(j))
                Next
            Next
        End Sub

        Public Function mtdPreencherVetorDinamicoInteger(ByVal Comprimento As Integer, ByVal Conteudo As Integer) As Integer()
            Dim Vetor = New Integer(Comprimento - 1) {}

            For i = 0 To Comprimento - 1
                Vetor(i) = Conteudo
            Next

            Return Vetor
        End Function

        Public Function mtdPreencherMatrizDinamicaInteger(ByVal Linha As Integer, ByVal Coluna As Integer, ByVal Conteudo As Integer) As Integer()()
            Dim Matriz = New Integer(Linha - 1)() {}

            For i = 0 To Linha - 1
                For j = 0 To Coluna - 1
                    Matriz(i)(j) = Conteudo
                Next
            Next

            Return Matriz
        End Function

        Public Function mtdPreencherVetorDinamicoDouble(ByVal Comprimento As Integer, ByVal Conteudo As Double) As Double()
            Dim Vetor = New Double(Comprimento - 1) {}

            For i = 0 To Comprimento - 1
                Vetor(i) = Conteudo
            Next

            Return Vetor
        End Function

        Public Function mtdPreencherMatrizDinamicaDouble(ByVal Linha As Integer, ByVal Coluna As Integer, ByVal Conteudo As Double) As Double()()
            Dim Matriz = New Double(Linha - 1)() {}

            For i = 0 To Linha - 1
                Matriz(i) = New Double(Coluna - 1) {}

                For j = 0 To Coluna - 1
                    Matriz(i)(j) = Conteudo
                Next
            Next

            Return Matriz
        End Function

        Public Function mtdGerarArquivoMatriz(ByVal Arquivo As String, ByVal coluna As Integer, ByVal linha As Integer, ByVal comprimento As Integer, ByVal minimoValor As Integer, ByVal maximoValor As Integer) As Double()()
            Dim numero As StringBuilder = New StringBuilder()
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim enterRepetido As Integer = 1
            Dim espacoRepetido As Integer = 1
            Dim pontoRepetido As Integer = 0
            Dim sinalRepetido As Integer = 0
            Dim ultimaEntrada As Integer = 0
            Dim maxcoluna As Integer = 0
            Dim contador As Integer = 0
            Dim numeroEspaco As Integer = 0
            Dim chr As Integer = 0
            Dim vetnum = New Double(99999) {}
            Dim Matriz As Double()()

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(Arquivo)

            coluna = 0
            linha = 0

            While chr > -1
                If (chr = System.Convert.ToInt32("-"c) Or chr = System.Convert.ToInt32("+"c) Or chr = System.Convert.ToInt32("."c) Or chr = System.Convert.ToInt32(","c)) And (pontoRepetido = 0 Or sinalRepetido = 0) Or chr >= System.Convert.ToInt32("0"c) And chr <= System.Convert.ToInt32("9"c) Then
                    If chr = System.Convert.ToInt32(","c) Then
                        chr = System.Convert.ToInt32("."c)
                    End If
                    numero.Append(System.Char.ConvertFromUtf32(chr))
                    If ((numero.ToString() <> "-"c And numero.ToString() <> "+"c) And (numero.ToString() <> "."c And numero.ToString() <> ","c)) Then
                        vetnum(numeroEspaco) = Double.Parse(numero.ToString())
                    End If
                    enterRepetido = 0
                    espacoRepetido = 0
                    If chr = System.Convert.ToInt32("-"c) Or chr = System.Convert.ToInt32("+"c) Then
                        sinalRepetido += 1
                    End If
                    If chr = System.Convert.ToInt32("."c) Or chr = System.Convert.ToInt32(","c) Then
                        pontoRepetido += 1
                    End If
                    ultimaEntrada = 1
                Else
                    If Not (chr = System.Convert.ToInt32("-"c) Or chr = System.Convert.ToInt32("+"c) Or chr = System.Convert.ToInt32("."c) Or chr = System.Convert.ToInt32(","c)) Then
                        contador = 0

                        If espacoRepetido = 0 Then
                            coluna += 1
                            numeroEspaco += 1
                            numero = New StringBuilder()
                        End If
                        espacoRepetido += 1

                        If chr = 10 Or chr = 13 Then
                            If enterRepetido = 0 Then
                                If maxcoluna < coluna Then
                                    maxcoluna = coluna
                                End If

                                coluna = 0
                                linha += 1
                                numero = New StringBuilder()
                            End If
                            enterRepetido += 1
                        End If

                        pontoRepetido = 0
                        sinalRepetido = 0
                    Else
                        enterRepetido = 0
                        espacoRepetido = 0
                        pontoRepetido += 1
                        sinalRepetido += 1
                    End If
                    ultimaEntrada = 0
                End If

                chr = sr.Read()
            End While

            numeroEspaco += 1
            linha += 1
            coluna = maxcoluna
            comprimento = numeroEspaco

            If ultimaEntrada = 0 Then
                linha -= 1
            End If

            minimoValor = CInt(vetnum(0))
            maximoValor = CInt(vetnum(0))

            For i = 0 To comprimento - 1
                If minimoValor >= CInt(vetnum(i)) Then
                    minimoValor = CInt(vetnum(i))
                End If
                If maximoValor <= CInt(vetnum(i)) Then
                    maximoValor = CInt(vetnum(i))
                End If
            Next

            ' mtdCriarMatrizDinamicaDouble(Matriz, (*linha + 1), (*coluna + 1));
            Matriz = New Double(linha + 1 - 1)() {}

            For i = 0 To linha + 1 - 1
                Matriz(i) = New Double(coluna + 1 - 1) {}
            Next

            ' mtdPreencherMatrizDinamicaDouble(Matriz, (*linha + 1), (*coluna + 1), ((vetnum[(int)(((i - 1) * (*coluna)) + (j - 1))]) - (*minimoValor)) / ((*maximoValor) - (*minimoValor)));
            For i = 1 To linha + 1 - 1
                For j = 1 To coluna + 1 - 1
                    Matriz(i)(j) = (vetnum((i - 1) * coluna + (j - 1)) - minimoValor) / (maximoValor - minimoValor)
                Next
            Next

            sttGerarArquivoMatriz.coluna = coluna
            sttGerarArquivoMatriz.linha = linha
            sttGerarArquivoMatriz.comprimento = comprimento
            sttGerarArquivoMatriz.minimoValor = minimoValor
            sttGerarArquivoMatriz.maximoValor = maximoValor

            sr.Close()

            Return Matriz
        End Function

        Public Sub mtdGerarVetorMatriz()
            ' int ranpad[NUMEROPADROES+1];
            ranpad = mtdCriarVetorDinamicoInteger(numPadroes + 1)

            ' double SomaEscondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
            SomaEscondida = mtdCriarMatrizDinamicaDouble(numPadroes + 1, numEscondida + 1)

            ' double W12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
            W12 = mtdCriarMatrizDinamicaDouble(numEntrada + 1, numEscondida + 1)

            ' double Escondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
            Escondida = mtdCriarMatrizDinamicaDouble(numPadroes + 1, numEscondida + 1)

            ' double SomaSaida[NUMEROPADROES+1][NUMEROSAIDAS+1]; 
            SomaSaida = mtdCriarMatrizDinamicaDouble(numPadroes + 1, numSaida + 1)

            ' double W23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1]; 
            W23 = mtdCriarMatrizDinamicaDouble(numEscondida + 1, numSaida + 1)

            ' double Saida[NUMEROPADROES+1][NUMEROSAIDAS+1];
            Saida = mtdCriarMatrizDinamicaDouble(numPadroes + 1, numSaida + 1)

            ' double DeltaS[NUMEROSAIDAS+1];
            DeltaS = mtdCriarVetorDinamicoDouble(numSaida + 1)

            ' double somaDWS[NUMEROESCONDIDA+1];
            somaDWS = mtdCriarVetorDinamicoDouble(numEscondida + 1)

            ' double DeltaE[NUMEROESCONDIDA+1];
            DeltaE = mtdCriarVetorDinamicoDouble(numEscondida + 1)

            ' double DeltaW12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
            DeltaW12 = mtdCriarMatrizDinamicaDouble(numEntrada + 1, numEscondida + 1)

            ' double DeltaW23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1];
            DeltaW23 = mtdCriarMatrizDinamicaDouble(numEscondida + 1, numSaida + 1)
        End Sub

        Public Sub mtdFinalizarVetorMatriz()
            ' int ranpad[NUMEROPADROES+1];
            ranpad = Nothing

            ' double entrada[NUMEROPADROES+1][NUMEROENTRADAS+1];
            entrada = Nothing

            ' double target[NUMEROPADROES+1][NUMEROSAIDAS+1];
            target = Nothing

            ' double SomaEscondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
            SomaEscondida = Nothing

            ' double W12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
            W12 = Nothing

            ' double Escondida[NUMEROPADROES+1][NUMEROESCONDIDA+1];
            Escondida = Nothing

            ' double SomaSaida[NUMEROPADROES+1][NUMEROSAIDAS+1]; 
            SomaSaida = Nothing

            ' double W23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1]; 
            W23 = Nothing

            ' double SAIDA[NUMEROPADROES+1][NUMEROSAIDAS+1];
            Saida = Nothing

            ' double DeltaS[NUMEROSAIDAS+1];
            DeltaS = Nothing

            ' double somaDWS[NUMEROESCONDIDA+1];
            somaDWS = Nothing

            ' double DeltaE[NUMEROESCONDIDA+1];
            DeltaE = Nothing

            ' double DeltaW12[NUMEROENTRADAS+1][NUMEROESCONDIDA+1];
            DeltaW12 = Nothing

            ' double DeltaW23[NUMEROESCONDIDA+1][NUMEROSAIDAS+1];
            DeltaW23 = Nothing
        End Sub

        Public Sub mtdObterEntradasTreinamento()
            Dim coluna = 0
            Dim linha = 0
            Dim comprimento = 0
            ' double entrada[NUMEROPADROES+1][NUMEROENTRADAS+1];
            entrada = mtdGerarArquivoMatriz("entradastreinamento.dat", coluna, linha, comprimento, minimoValorEntrada, maximoValorEntrada)
            numEntrada = sttGerarArquivoMatriz.coluna
            numPadroes = sttGerarArquivoMatriz.linha
            minimoValorEntrada = sttGerarArquivoMatriz.minimoValor
            maximoValorEntrada = sttGerarArquivoMatriz.maximoValor
        End Sub

        Public Sub mtdObterEntradasExecucao()
            Dim coluna = 0
            Dim linha = 0
            Dim comprimento = 0
            ' double entrada[NUMEROPADROES+1][NUMEROENTRADAS+1];
            entrada = mtdGerarArquivoMatriz("entradasteste.dat", coluna, linha, comprimento, minimoValorEntrada, maximoValorEntrada)
            numEntrada = sttGerarArquivoMatriz.coluna
            numPadroes = sttGerarArquivoMatriz.linha
            minimoValorEntrada = sttGerarArquivoMatriz.minimoValor
            maximoValorEntrada = sttGerarArquivoMatriz.maximoValor
        End Sub

        Public Sub mtdObterAlvosTreinamento()

            Dim coluna = 0
            Dim linha = 0
            Dim comprimento = 0
            ' double target[NUMEROPADROES+1][NUMEROSAIDAS+1];
            target = mtdGerarArquivoMatriz("target.dat", coluna, linha, comprimento, minimoValorAlvo, maximoValorAlvo)
            numSaida = sttGerarArquivoMatriz.coluna
            numPadroes = sttGerarArquivoMatriz.linha
            minimoValorAlvo = sttGerarArquivoMatriz.minimoValor
            maximoValorAlvo = sttGerarArquivoMatriz.maximoValor

            mtdEscreverNumeroColunasAlvos()
        End Sub

        Public Sub mtdZerarAlvosExecucao(ByVal linha As Integer)
            mtdObterNumeroColunasAlvos()

            Dim coluna = numSaida

            ' double target[NUMEROPADROES+1][NUMEROSAIDAS+1];
            target = mtdCriarMatrizDinamicaDouble(linha + 1, coluna + 1)

            target = mtdPreencherMatrizDinamicaDouble(linha + 1, coluna + 1, 0.0)
        End Sub

        Public Sub mtdExportarPesos()
            Dim m, n As Integer
            ' cfPtr = fopen("pesos.dat", "w");
            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter("pesos.dat", False)

            For n = 0 To numEscondida + 1 - 1
                For m = 0 To numEntrada + 1 - 1
                    sw.Write(W12(m)(n) & If(m < numEntrada, vbTab, ""))
                Next

                sw.Write(vbLf)
            Next

            For n = 0 To numSaida + 1 - 1
                For m = 0 To numEscondida + 1 - 1
                    sw.Write(W23(m)(n) & If(m < numEscondida, vbTab, ""))
                Next

                If n < numSaida Then
                    sw.Write(vbLf)
                End If
            Next

            sw.Close()
        End Sub

        Public Sub mtdIniciarPesos()

            Dim m, n As Integer

            Dim Retorno = ""

            Dim strLinha = ""
            Dim vetLinha As String()

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader("pesos.dat")

            For n = 0 To numEscondida + 1 - 1
                strLinha = sr.ReadLine()
                vetLinha = strLinha.Split(vbTab)

                For m = 0 To numEntrada + 1 - 1
                    W12(m)(n) = Double.Parse(vetLinha(m))
                Next
            Next

            For n = 0 To numSaida + 1 - 1
                strLinha = sr.ReadLine()
                vetLinha = strLinha.Split(vbTab)

                For m = 0 To numEscondida + 1 - 1
                    W23(m)(n) = Double.Parse(vetLinha(m))
                Next
            Next

            sr.Close()
        End Sub

        Public Sub mtdDefinirModEpocaDisplay()
            If numIteracoes >= 100 Then
                modEpocaDisplay = CInt(numIteracoes / 100)
            Else
                modEpocaDisplay = 1
            End If
        End Sub

        Public Function mtdObterNumeroArquivo(ByVal EnderecoArquivo As String) As String
            Dim Retorno = ""

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(EnderecoArquivo)

            Dim intCharUnicode As Integer = sr.Read()
            Dim chrCharUnicode = Microsoft.VisualBasic.ChrW(intCharUnicode)
            Dim strNumero As StringBuilder = New StringBuilder()

            While intCharUnicode > -1
                If "-+0123456789.,ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".Contains(chrCharUnicode) Then
                    strNumero.Append(chrCharUnicode)
                    Retorno = strNumero.ToString()
                End If

                intCharUnicode = sr.Read()
                If intCharUnicode > -1 Then
                    chrCharUnicode = System.Convert.ToChar(Char.ConvertFromUtf32(intCharUnicode))
                End If
            End While

            sr.Close()

            Return Retorno
        End Function

        Public Sub mtdObterErroTreinamento()
            Erro = Double.Parse(mtdObterNumeroArquivo("errotreinamento.dat"))
        End Sub

        Public Sub mtdEscreverErroTreinamento()
            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter("errotreinamento.dat", False)

            sw.Write(Convert.ToString(Erro))
            sw.Close()
        End Sub

        Public Sub mtdObterNumeroNeuronios()
            numEscondida = Integer.Parse(mtdObterNumeroArquivo("numeroneuronios.dat"))
        End Sub

        Public Sub mtdEscreverNumeroNeuronios()
            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter("numeroneuronios.dat", False)

            sw.Write(Convert.ToString(numEscondida))
            sw.Close()
        End Sub

        Public Sub mtdObterNumeroColunasAlvos()
            If numSaida <= 0 Then
                mtdObterAlvosTreinamento()

                mtdEscreverNumeroColunasAlvos()
            Else
                numSaida = Integer.Parse(mtdObterNumeroArquivo("numerocolunasalvos.dat"))
            End If
        End Sub

        Private Sub mtdEscreverNumeroColunasAlvos()
            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter("numerocolunasalvos.dat", False)

            sw.Write(Convert.ToString(numSaida))
            sw.Close()
        End Sub

        Private Sub mtdEscreverSaida(ByVal TipoResultado As Integer)
            Dim strEnderecoArquivo = ""

            If TipoResultado = 0 Then
                strEnderecoArquivo = "resultadostreinamento.dat"
            ElseIf TipoResultado = 1 Then
                strEnderecoArquivo = "resultadosteste.dat"
            End If

            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(strEnderecoArquivo, False)

            tempoIntermediario = Date.Now
            ' fprintf(cfPtr, "NETWORK DATA - Epoca %d - Neuronios %d - Iteracoes %d - Erro %lf - Tempo Execucao %.0lf [s].\n\nPat:\t", epoca, numEscondida, numIteracoes, Erro, difftime(tempoIntermediario, tempoInicial)); // Mostra as SAIDAs
            sw.Write("NETWORK DATA - Epoca " & epoca & " - Neuronios " & numEscondida & " - Erro " & Erro & " - Tempo Execucao " & (tempoIntermediario - tempoInicial).TotalSeconds & " [s]." & vbLf & vbLf & "Pat:" & vbTab)

            i = 1

            While i < numEntrada + 1
                sw.Write("Entrada " & i & vbTab)
                i += 1
            End While

            k = 1

            While k < numSaida + 1
                sw.Write("Alvo " & k & vbTab & "Saida " & k & vbTab)
                k += 1
            End While

            p = 1

            While p < numPadroes + 1
                sw.Write(vbLf & p & vbTab)

                i = 1

                While i < numEntrada + 1
                    sw.Write((entrada(p)(i) * (maximoValorEntrada - minimoValorEntrada) + minimoValorEntrada) & vbTab)
                    i += 1
                End While

                k = 1

                While k < numSaida + 1
                    sw.Write((target(p)(k) * (maximoValorEntrada - minimoValorEntrada) + minimoValorEntrada) & vbTab & (Saida(p)(k) * (maximoValorAlvo - minimoValorAlvo) + minimoValorAlvo) & vbTab)
                    k += 1
                End While

                p += 1
            End While

            tempoIntermediario = Date.Now
            ' fprintf(stdout, "NETWORK DATA - Epoca %d - Neuronios %d - Iteracoes %d - Erro %lf - Tempo Execucao %.0lf [s].\n\nPat:\t", epoca, numEscondida, numIteracoes, Erro, difftime(tempoIntermediario, tempoInicial)); // Mostra as SAIDAs
            System.Console.Write("NETWORK DATA - Epoca " & epoca & " - Neuronios " & numEscondida & " - Erro " & Erro & " - Tempo Execucao " & (tempoIntermediario - tempoInicial).TotalSeconds & " [s]." & vbLf & vbLf & "Pat:" & vbTab)

            i = 1

            While i < numEntrada + 1
                System.Console.Write("Entrada " & i & vbTab)
                i += 1
            End While

            k = 1

            While k < numSaida + 1
                System.Console.Write("Alvo " & k & vbTab & "Saida " & k & vbTab)
                k += 1
            End While

            p = 1

            While p < numPadroes + 1
                System.Console.Write(vbLf & p & vbTab)
                i = 1

                While i < numEntrada + 1
                    System.Console.Write((entrada(p)(i) * (maximoValorEntrada - minimoValorEntrada) + minimoValorEntrada) & vbTab)
                    i += 1
                End While
                k = 1

                While k < numSaida + 1
                    System.Console.Write((target(p)(k) * (maximoValorEntrada - minimoValorEntrada) + minimoValorEntrada) & vbTab & (Saida(p)(k) * (maximoValorAlvo - minimoValorAlvo) + minimoValorAlvo) & vbTab)
                    k += 1
                End While

                p += 1
            End While

            System.Console.Write(vbLf & vbLf)

            sw.Close()

            ' mtdPausar();
        End Sub

        Public Function mtdTreinarRedeNeural() As Integer
            Dim retorno = 0

            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter("erro_TreinamentoRedeNeural.dat", False)

            mtdDefinirModEpocaDisplay()
            mtdObterEntradasTreinamento()
            mtdObterAlvosTreinamento()
            mtdGerarVetorMatriz()

            j = 1

            While j < numEscondida + 1
                ' Inicializa W12 e DeltaW12
                i = 0

                While i < numEntrada + 1
                    DeltaW12(i)(j) = 0.0
                    W12(i)(j) = 2.0 * (rando() - 0.5) * wmax
                    i += 1
                End While

                j += 1
            End While
            k = 1

            While k < numSaida + 1
                ' Inicializa W23 e DeltaW23
                j = 0

                While j < numEscondida + 1
                    DeltaW23(j)(k) = 0.0
                    W23(j)(k) = 2.0 * (rando() - 0.5) * wmax
                    j += 1
                End While

                k += 1
            End While

            epoca = 1

            While If(numIteracoes > 0, epoca < numIteracoes + 1, True)
                ' Faz a iteracao da atualizacao dos pesos
                p = 1

                While p < numPadroes + 1
                    ' Randomiza a ordem dos individuos
                    ranpad(p) = p
                    p += 1
                End While

                p = 1

                While p < numPadroes + 1
                    np = CInt((p + rando() * (numPadroes - p + 0)))
                    op = ranpad(p)
                    ranpad(p) = ranpad(np)
                    ranpad(np) = op
                    p += 1
                End While
                Erro = 0.0

                np = 1

                While np < numPadroes + 1
                    ' Repete para todos os padroes de treinamento
                    p = ranpad(np)

                    j = 1

                    While j < numEscondida + 1
                        ' Computa as ativacoes da unidade escondida
                        SomaEscondida(p)(j) = W12(0)(j)
                        i = 1

                        While i < numEntrada + 1
                            SomaEscondida(p)(j) += entrada(p)(i) * W12(i)(j)
                            i += 1
                        End While
                        Escondida(p)(j) = 1.0 / (1.0 + Math.Exp(-SomaEscondida(p)(j)))
                        j += 1
                    End While

                    k = 1

                    While k < numSaida + 1
                        ' Computa as unidades de ativacao da saida e erros
                        SomaSaida(p)(k) = W23(0)(k)
                        j = 1

                        While j < numEscondida + 1
                            SomaSaida(p)(k) += Escondida(p)(j) * W23(j)(k)
                            j += 1
                        End While

                        Select Case TipoSaida
                            Case 0
                                Saida(p)(k) = 1.0 / (1.0 + Math.Exp(-SomaSaida(p)(k))) ' Sigmoidal SAIDAs
                            Case 1
                                Saida(p)(k) = SomaSaida(p)(k) ' Linear SAIDAs
                        End Select

                        Select Case TipoErro
                            Case 0
                                Erro += 0.5 * (target(p)(k) - Saida(p)(k)) * (target(p)(k) - Saida(p)(k)) ' SSE
                            Case 1
                                Erro -= target(p)(k) * Math.Log(Saida(p)(k)) + (1.0 - target(p)(k)) * Math.Log(1.0 - Saida(p)(k)) ' Erro de Entropia Cruzada
                        End Select

                        Select Case TipoDeltaS
                            Case 0
                                DeltaS(k) = (target(p)(k) - Saida(p)(k)) * Saida(p)(k) * (1.0 - Saida(p)(k)) ' Sigmoidal SAIDAs, SSE 
                            Case 1
                                DeltaS(k) = target(p)(k) - Saida(p)(k) ' Sigmoidal SAIDAs, Cross-Entropy Erro
                            Case 2
                                DeltaS(k) = target(p)(k) - Saida(p)(k) ' Linear SAIDAs, SSE
                        End Select

                        k += 1
                    End While

                    j = 1

                    While j < numEscondida + 1
                        ' Retropropagacao de erros para a camada escondida
                        somaDWS(j) = 0.0
                        k = 1

                        While k < numSaida + 1
                            somaDWS(j) += W23(j)(k) * DeltaS(k)
                            k += 1
                        End While
                        DeltaE(j) = somaDWS(j) * Escondida(p)(j) * (1.0 - Escondida(p)(j))
                        j += 1
                    End While

                    j = 1

                    While j < numEscondida + 1
                        ' Atualiza pesos w12
                        DeltaW12(0)(j) = eta * DeltaE(j) + alpha * DeltaW12(0)(j)
                        W12(0)(j) += DeltaW12(0)(j)
                        i = 1

                        While i < numEntrada + 1
                            DeltaW12(i)(j) = eta * entrada(p)(i) * DeltaE(j) + alpha * DeltaW12(i)(j)
                            W12(i)(j) += DeltaW12(i)(j)
                            i += 1
                        End While

                        j += 1
                    End While

                    k = 1

                    While k < numSaida + 1
                        ' Atualiza pesos W23
                        DeltaW23(0)(k) = eta * DeltaS(k) + alpha * DeltaW23(0)(k)
                        W23(0)(k) += DeltaW23(0)(k)
                        j = 1

                        While j < numEscondida + 1
                            DeltaW23(j)(k) = eta * Escondida(p)(j) * DeltaS(k) + alpha * DeltaW23(j)(k)
                            W23(j)(k) += DeltaW23(j)(k)
                            j += 1
                        End While

                        k += 1
                    End While

                    np += 1
                End While

                If epoca Mod modEpocaDisplay = 0 OrElse epoca = numIteracoes Then
                    tempoIntermediario = Date.Now
                    ' fprintf(cfPtr, "NETWORK DATA - Epoca %d - Neuronios %d - Iteracoes %d - Erro %lf - Tempo Execucao %.0lf [s].\n", epoca, numEscondida, numIteracoes, Erro, difftime(tempoIntermediario, tempoInicial)); // Mostra as SAIDAs
                    sw.Write("NETWORK DATA - Epoca " & epoca & " - Neuronios " & numEscondida & " - Iteracoes " & numIteracoes & " - Erro " & Erro & " - Tempo Execucao " & (tempoIntermediario - tempoInicial).TotalSeconds & " [s]." & vbLf) ' Mostra as SAIDAs
                    System.Console.Write("NETWORK DATA - Epoca " & epoca & " - Neuronios " & numEscondida & " - Iteracoes " & numIteracoes & " - Erro " & Erro & " - Tempo Execucao " & (tempoIntermediario - tempoInicial).TotalSeconds & " [s]." & vbLf) ' Mostra as SAIDAs
                End If

                If Erro < erroLimite Then
                    Exit While ' Para o aprendizado quando o erro convergir para o valor descrito
                End If

                epoca += 1
            End While

            sw.Close()

            mtdExportarPesos()
            mtdEscreverErroTreinamento()
            mtdEscreverSaida(0)
            mtdFinalizarVetorMatriz()
            retorno = 1

            Return retorno
        End Function

        Public Function mtdExecutarRedeNeural() As Integer
            Dim retorno = 0

            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter("erro_ExecucaoRedeNeural.dat", False)

            mtdDefinirModEpocaDisplay()
            mtdObterEntradasExecucao()
            mtdZerarAlvosExecucao(numPadroes)
            mtdGerarVetorMatriz()
            mtdIniciarPesos()

            epoca = 1

            While If(numIteracoes > 0, epoca < numIteracoes + 1, True)
                ' Faz a iteracao da atualizacao dos pesos
                p = 1

                While p < numPadroes + 1
                    ' Randomiza a ordem dos individuos
                    ranpad(p) = p
                    p += 1
                End While
                p = 1

                While p < numPadroes + 1
                    np = CInt((p + rando() * (numPadroes - p + 0)))
                    op = ranpad(p)
                    ranpad(p) = ranpad(np)
                    ranpad(np) = op
                    p += 1
                End While
                Erro = 0.0
                np = 1

                While np < numPadroes + 1
                    ' Repete para todos os padroes de treinamento
                    p = ranpad(np)
                    j = 1

                    While j < numEscondida + 1
                        ' Computa as ativacoes da unidade escondida
                        SomaEscondida(p)(j) = W12(0)(j)
                        i = 1

                        While i < numEntrada + 1
                            SomaEscondida(p)(j) += entrada(p)(i) * W12(i)(j)
                            i += 1
                        End While
                        Escondida(p)(j) = 1.0 / (1.0 + Math.Exp(-SomaEscondida(p)(j)))
                        j += 1
                    End While
                    k = 1

                    While k < numSaida + 1
                        ' Computa as unidades de ativacao da saida e erros
                        SomaSaida(p)(k) = W23(0)(k)
                        j = 1

                        While j < numEscondida + 1
                            SomaSaida(p)(k) += Escondida(p)(j) * W23(j)(k)
                            j += 1
                        End While

                        Select Case TipoSaida
                            Case 0
                                Saida(p)(k) = 1.0 / (1.0 + Math.Exp(-SomaSaida(p)(k))) ' Sigmoidal SAIDAs
                            Case 1
                                Saida(p)(k) = SomaSaida(p)(k) ' Linear SAIDAs
                        End Select

                        Select Case TipoErro
                            Case 0
                                Erro += 0.5 * (target(p)(k) - Saida(p)(k)) * (target(p)(k) - Saida(p)(k)) ' SSE
                            Case 1
                                Erro -= target(p)(k) * Math.Log(Saida(p)(k)) + (1.0 - target(p)(k)) * Math.Log(1.0 - Saida(p)(k)) ' Erro de Entropia Cruzada
                        End Select

                        Select Case TipoDeltaS
                            Case 0
                                DeltaS(k) = (target(p)(k) - Saida(p)(k)) * Saida(p)(k) * (1.0 - Saida(p)(k)) ' Sigmoidal SAIDAs, SSE 
                            Case 1
                                DeltaS(k) = target(p)(k) - Saida(p)(k) ' Sigmoidal SAIDAs, Cross-Entropy Erro
                            Case 2
                                DeltaS(k) = target(p)(k) - Saida(p)(k) ' Linear SAIDAs, SSE
                        End Select

                        k += 1
                    End While
                    j = 1

                    While j < numEscondida + 1
                        ' Retropropagacao de erros para a camada escondida
                        somaDWS(j) = 0.0
                        k = 1

                        While k < numSaida + 1
                            somaDWS(j) += W23(j)(k) * DeltaS(k)
                            k += 1
                        End While
                        DeltaE(j) = somaDWS(j) * Escondida(p)(j) * (1.0 - Escondida(p)(j))
                        j += 1
                    End While
                    j = 1

                    While j < numEscondida + 1
                        ' Atualiza pesos w12
                        DeltaW12(0)(j) = eta * DeltaE(j) + alpha * DeltaW12(0)(j)
                        W12(0)(j) += DeltaW12(0)(j)
                        i = 1

                        While i < numEntrada + 1
                            DeltaW12(i)(j) = eta * entrada(p)(i) * DeltaE(j) + alpha * DeltaW12(i)(j)
                            W12(i)(j) += DeltaW12(i)(j)
                            i += 1
                        End While

                        j += 1
                    End While
                    k = 1

                    While k < numSaida + 1
                        ' Atualiza pesos W23
                        DeltaW23(0)(k) = eta * DeltaS(k) + alpha * DeltaW23(0)(k)
                        W23(0)(k) += DeltaW23(0)(k)
                        j = 1

                        While j < numEscondida + 1
                            DeltaW23(j)(k) = eta * Escondida(p)(j) * DeltaS(k) + alpha * DeltaW23(j)(k)
                            W23(j)(k) += DeltaW23(j)(k)
                            j += 1
                        End While

                        k += 1
                    End While

                    np += 1
                End While

                If epoca Mod modEpocaDisplay = 0 OrElse epoca = numIteracoes Then
                    tempoIntermediario = Date.Now
                    sw.Write("NETWORK DATA - Epoca " & epoca & " - Neuronios " & numEscondida & " - Iteracoes " & numIteracoes & " - Erro " & Erro & " - Tempo Execucao " & (tempoIntermediario - tempoInicial).TotalSeconds & " [s]." & vbLf) ' Mostra as SAIDAs
                    System.Console.Write("NETWORK DATA - Epoca " & epoca & " - Neuronios " & numEscondida & " - Iteracoes " & numIteracoes & " - Erro " & Erro & " - Tempo Execucao " & (tempoIntermediario - tempoInicial).TotalSeconds & " [s]." & vbLf) ' Mostra as SAIDAs
                End If

                epoca += 1
            End While

            sw.Close()

            mtdObterErroTreinamento()
            mtdEscreverSaida(1)
            mtdFinalizarVetorMatriz()
            retorno = 1

            Return retorno
        End Function

        Public Sub mtdPausar()
        End Sub

        Public Sub mtdSair()
        End Sub

        Public Sub mtdTreinamentoRedeNeural(ByVal Escondida As Integer, ByVal Iteracoes As Integer, ByVal ErroLimite As Double)
            tempoInicial = Date.Now
            numEscondida = Escondida
            numIteracoes = Iteracoes
            Me.erroLimite = ErroLimite

            If mtdTreinarRedeNeural() = 1 Then
                System.Console.Write("Rede treinada com sucesso." & vbLf)
            Else
                System.Console.Write("Ocorreram erros." & vbLf)
            End If
            tempoFinal = Date.Now
            System.Console.Write("Tempo decorrido para o treinamento da Rede Neural: " & (tempoFinal - tempoInicial).TotalSeconds & " [s]." & vbLf)

            ' mtdPausar();
        End Sub

        Public Sub mtdExecucaoRedeNeural(ByVal Escondida As Integer, ByVal Iteracoes As Integer)
            tempoInicial = Date.Now
            numEscondida = Escondida
            numIteracoes = Iteracoes

            If mtdExecutarRedeNeural() = 1 Then
                System.Console.Write("Rede executada com sucesso." & vbLf)
            Else
                System.Console.Write("Ocorreram erros." & vbLf)
            End If
            tempoFinal = Date.Now
            System.Console.Write("Tempo decorrido para a execucao da Rede Neural: " & (tempoFinal - tempoInicial).TotalSeconds & " [s]." & vbLf)

            ' mtdPausar();
        End Sub
    End Class
End Namespace
