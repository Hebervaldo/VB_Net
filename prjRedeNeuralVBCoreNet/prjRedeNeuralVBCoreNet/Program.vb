Imports System

Namespace prjRedeNeuralCSCoreNet
    Class Program
        Private Shared objRedeNeural As clsRedeNeural = New clsRedeNeural()

        Public Shared Sub mtdPadrao()
            Dim opcao As Integer = 0

            Do
                System.Console.Write("Menu Rede Neural - Escolha uma opcao" & vbLf)
                System.Console.Write("0. Treinar a Rede Neural" & vbLf)
                System.Console.Write("1. Executar a Rede Neural" & vbLf)
                System.Console.Write("2. Sair." & vbLf)
                opcao = Integer.Parse(System.Console.ReadLine().Replace(".", ","))

                Select Case opcao
                    Case 0
                        System.Console.Write("Digite o numero de neuronios da Rede Neural:" & vbLf)
                        objRedeNeural.numEscondida = Integer.Parse(System.Console.ReadLine().Replace(".", ","))
                        System.Console.Write("Digite o numero de iteracoes da Rede Neural:" & vbLf)
                        objRedeNeural.numIteracoes = Integer.Parse(System.Console.ReadLine().Replace(".", ","))
                        System.Console.Write("Digite o erro limite: " & vbLf)
                        objRedeNeural.erroLimite = Double.Parse(System.Console.ReadLine().Replace(".", ","))
                        objRedeNeural.tempoInicial = DateTime.Now

                        If objRedeNeural.mtdTreinarRedeNeural() = 1 Then
                            System.Console.Write("Rede treinada com sucesso." & vbLf)
                        Else
                            System.Console.Write("Ocorreram erros." & vbLf)
                        End If

                        objRedeNeural.tempoFinal = DateTime.Now
                        System.Console.Write("Tempo decorrido para o treinamento da Rede Neural: " & (objRedeNeural.tempoFinal - objRedeNeural.tempoInicial).TotalSeconds & " [s]." & vbLf)
                        objRedeNeural.mtdEscreverNumeroNeuronios()
                        objRedeNeural.primeiraExecucao = 0
                    Case 1
                        objRedeNeural.mtdObterNumeroNeuronios()

                        If objRedeNeural.numEscondida <= 0 AndAlso objRedeNeural.primeiraExecucao = 1 Then
                            System.Console.Write("Digite o numero de neuronios da Rede Neural:" & vbLf)
                            objRedeNeural.numEscondida = Integer.Parse(System.Console.ReadLine().Replace(".", ","))
                            objRedeNeural.mtdEscreverNumeroNeuronios()
                        End If

                        objRedeNeural.numIteracoes = 1
                        objRedeNeural.tempoInicial = DateTime.Now

                        If objRedeNeural.mtdExecutarRedeNeural() = 1 Then
                            System.Console.Write("Rede executada com sucesso." & vbLf)
                        Else
                            System.Console.Write("Ocorreram erros." & vbLf)
                        End If

                        objRedeNeural.tempoFinal = DateTime.Now
                        System.Console.Write("Tempo decorrido para a execucao da Rede Neural: " & (objRedeNeural.tempoFinal - objRedeNeural.tempoInicial).TotalSeconds & " [s]." & vbLf)
                        objRedeNeural.primeiraExecucao = 0
                    Case 2
                        objRedeNeural.mtdSair()
                    Case Else
                        System.Console.Write("Digite uma opcao valida." & vbLf)
                End Select

                objRedeNeural.mtdPausar()
            Loop While opcao <> 2
        End Sub

        Public Shared Sub Main(ByVal args As String())
            Select Case args.Length
                Case 2
                    If Integer.Parse(args(1)) <= 0 Then
                        objRedeNeural.mtdObterNumeroNeuronios()
                    Else
                        objRedeNeural.numEscondida = Integer.Parse(args(1).Replace(".", ","))
                    End If

                    objRedeNeural.mtdExecucaoRedeNeural(objRedeNeural.numEscondida, 1)
                    objRedeNeural.mtdEscreverNumeroNeuronios()
                Case 4
                    objRedeNeural.mtdTreinamentoRedeNeural(Integer.Parse(args(1).Replace(".", ",")), Integer.Parse(args(2).Replace(".", ",")), Double.Parse(args(3).Replace(".", ",")))
                    objRedeNeural.mtdEscreverNumeroNeuronios()
                Case Else
                    mtdPadrao()
            End Select
        End Sub
    End Class
End Namespace
