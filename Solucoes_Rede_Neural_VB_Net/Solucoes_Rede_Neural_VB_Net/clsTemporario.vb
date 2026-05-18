Imports System.Data.OleDb
Imports System.IO
Imports System.Reflection.Assembly
Imports System.Security

Namespace Solucoes_Rede_Neural_VB_Net
    Public Class clsArquivoTXT : Inherits Object
        ' Variável de classe
        Private Shared numInstanciasCriadas As Integer = 0

        ' Variáveis de Instância
        Private strEnderecoArquivo As String
        Private strTexto As String

        ' Implementação dos Métodos.
        ' Método Construtor sem argumentos.
        Public Sub New()
            numInstanciasCriadas += 1
        End Sub
        ' Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe.
        Public Shared ReadOnly Property getnumInstanciasCriadas() As Integer
            Get
                Return numInstanciasCriadas
            End Get
        End Property
        Public ReadOnly Property getEnderecoArquivo() As String
            Get
                If Not (strEnderecoArquivo = String.Empty) Then
                    Return strEnderecoArquivo
                Else
                    Return "Digite um endereço e um nome de arquivo válidos."
                End If
            End Get
        End Property
        Public WriteOnly Property setEnderecoArquivo() As String
            Set(ByVal value As String)
                strEnderecoArquivo = value
            End Set
        End Property
        Public ReadOnly Property getTexto() As String
            Get
                If Not (strTexto = String.Empty) Then
                    Return strTexto
                Else
                    Return "Não há conteúdo."
                End If
            End Get
        End Property
        Public WriteOnly Property setTexto() As String
            Set(ByVal value As String)
                strTexto = value
            End Set
        End Property
        Public Overloads Function mtdCriadorTexto() As Boolean
            Dim stwEscritorTexto As StreamWriter = File.CreateText(getEnderecoArquivo)
            stwEscritorTexto.WriteLine(getTexto)
            stwEscritorTexto.Close()
            Return True
        End Function
        Public Overloads Function mtdCriadorTexto(ByVal Texto As String) As Boolean
            setTexto = Texto
            Return mtdCriadorTexto()
        End Function
        Public Overloads Function mtdCriadorTexto(ByVal EnderecoArquivo As String, ByVal Texto As String) As Boolean
            setEnderecoArquivo = EnderecoArquivo
            setTexto = Texto
            Return mtdCriadorTexto()
        End Function
        Public Overloads Function mtdAcrescentarTexto() As Boolean
            Dim TextoTemporario As String = String.Empty
            Try
                Dim stdLeitorTexto As StreamReader = File.OpenText(getEnderecoArquivo)
                TextoTemporario = stdLeitorTexto.ReadToEnd
                stdLeitorTexto.Close()
            Catch
            Finally

                Dim stwEscritorTexto As StreamWriter = File.CreateText(getEnderecoArquivo)
                stwEscritorTexto.Write(TextoTemporario & getTexto)
                stwEscritorTexto.Close()
            End Try
            Return True
        End Function
        Public Overloads Function mtdAcrescentarTexto(ByVal Texto As String) As Boolean
            setTexto = Texto
            Return mtdAcrescentarTexto()
        End Function
        Public Overloads Function mtdAcrescentarTexto(ByVal EnderecoArquivo As String, ByVal Texto As String) As Boolean
            setEnderecoArquivo = EnderecoArquivo
            setTexto = Texto
            Return mtdAcrescentarTexto()
        End Function
        Public Overloads Function mtdLeitorTexto() As String
            Dim stdLeitorTexto As StreamReader = File.OpenText(getEnderecoArquivo)
            setTexto = stdLeitorTexto.ReadToEnd
            stdLeitorTexto.Close()
            Return getTexto
        End Function
        Public Overloads Function mtdLeitorTexto(ByVal EnderecoArquivo As String) As String
            setEnderecoArquivo = EnderecoArquivo
            Return mtdLeitorTexto()
        End Function
        Public Overloads Function mtdEscritorBinario() As Boolean
            Dim EscritorBinario As New BinaryWriter(File.OpenWrite(getEnderecoArquivo))
            EscritorBinario.Write(getTexto)
            EscritorBinario.Close()
            Return True
        End Function
        Public Overloads Function mtdEscritorBinario(ByVal Texto As String) As Boolean
            setTexto = Texto
            Return mtdEscritorBinario()
        End Function
        Public Overloads Function mtdEscritorBinario(ByVal EnderecoArquivo As String, ByVal Texto As String) As Boolean
            setEnderecoArquivo = EnderecoArquivo
            setTexto = Texto
            Return True
        End Function
        Public Overloads Function mtdLeitorBinario() As String
            Dim bnrLeitorBinario As New BinaryReader(File.OpenRead(getEnderecoArquivo))
            setTexto = bnrLeitorBinario.ReadString()
            bnrLeitorBinario.Close()
            Return getTexto
        End Function
        Public Overloads Function mtdLeitorBinario(ByVal EnderecoArquivo As String) As String
            setEnderecoArquivo = EnderecoArquivo
            Return mtdLeitorBinario()
        End Function
        ' Método Finalizador
        Protected Overrides Sub Finalize()
            Try
                numInstanciasCriadas -= 1
                System.GC.Collect(0)
            Finally
                MyBase.Finalize()
            End Try
        End Sub
    End Class

    Public Class clsManipuladorTexto
        ' Variável de classe
        Private Shared numInstanciasCriadas As Integer = 0
        ' Variáveis de Instância
        Private intKey As Integer
        Private chrKeyChar As Char
        Private strTextoOriginal As String
        Private strTextoSemEspacoExtra As String
        Private strTextoSemCaractereInvalido As String
        Private strTextoMaiusculo As String
        Private strTextoMinusculo As String
        Private strSemAcentos As String
        Private strTudoExecutado As String
        ' Método construtor sem parâmetros.
        Sub New()
            numInstanciasCriadas += 1
        End Sub
        ' Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe.
        Public Shared ReadOnly Property getnumInstanciasCriadas() As Integer
            Get
                Return numInstanciasCriadas
            End Get
        End Property
        Public ReadOnly Property getKey() As Integer
            Get
                Return intKey
            End Get
        End Property
        Public WriteOnly Property setKey() As Integer
            Set(ByVal value As Integer)
                chrKeyChar = Convert.ToChar(value)
                intKey = value
            End Set
        End Property
        Public ReadOnly Property getKeyChar() As Char
            Get
                Return chrKeyChar
            End Get
        End Property
        Public WriteOnly Property setKeyChar() As Char
            Set(ByVal value As Char)
                intKey = Convert.ToInt32(value)
                chrKeyChar = value
            End Set
        End Property
        Public ReadOnly Property getTextoOriginal() As String
            Get
                Return strTextoOriginal
            End Get
        End Property
        Public WriteOnly Property setTextoOriginal() As String
            Set(ByVal value As String)
                strTextoOriginal = value
            End Set
        End Property
        Public ReadOnly Property getTextoSemEspacoExtra() As String
            Get
                Return strTextoSemEspacoExtra
            End Get
        End Property
        Public WriteOnly Property setTextoSemEspacoExtra() As String
            Set(ByVal value As String)
                strTextoSemEspacoExtra = value
            End Set
        End Property
        Public ReadOnly Property getTextoSemCaractereInvalido() As String
            Get
                Return strTextoSemCaractereInvalido
            End Get
        End Property
        Public WriteOnly Property setTextoSemCaractereInvalido() As String
            Set(ByVal value As String)
                strTextoSemCaractereInvalido = value
            End Set
        End Property
        Public ReadOnly Property getTextoMaiusculo() As String
            Get
                Return strTextoSemCaractereInvalido
            End Get
        End Property
        Public WriteOnly Property setTextoMaiusculo() As String
            Set(ByVal value As String)
                strTextoSemCaractereInvalido = value
            End Set
        End Property
        Public ReadOnly Property getTextoMinusculo() As String
            Get
                Return strTextoSemCaractereInvalido
            End Get
        End Property
        Public WriteOnly Property setTextoMinusculo() As String
            Set(ByVal value As String)
                strTextoSemCaractereInvalido = value
            End Set
        End Property
        Public ReadOnly Property getSemAcentos() As String
            Get
                Return strSemAcentos
            End Get
        End Property
        Public WriteOnly Property setSemAcentos() As String
            Set(ByVal value As String)
                strSemAcentos = value
            End Set
        End Property
        Public ReadOnly Property getTudoExecutado() As String
            Get
                Return strTudoExecutado
            End Get
        End Property
        Public WriteOnly Property setTudoExecutado() As String
            Set(ByVal value As String)
                strTudoExecutado = value
            End Set
        End Property
        Public Overloads Function mtdTiradorEspacoExtra() As String
            Dim Verificador As Boolean
            Dim chrCarac As Char
            Dim Index As Integer
            Dim strTextoTemporario As String = String.Empty
            If Index = 0 Then
                For i As Integer = 0 To getTextoOriginal.Length - 1
                    chrCarac = Convert.ToChar(getTextoOriginal.Substring(i, 1))
                    Index = Convert.ToInt32(chrCarac)
                    Select Case Index
                        Case 32
                            If Verificador = False Then
                                strTextoTemporario &= chrCarac
                                Verificador = True
                            End If
                        Case Else
                            strTextoTemporario &= chrCarac
                            Verificador = False
                    End Select
                Next
            End If
            setTextoSemEspacoExtra = strTextoTemporario.Trim()
            Return getTextoSemEspacoExtra
        End Function
        Public Overloads Function mtdTiradorEspacoExtra(ByVal Texto As String) As String
            setTextoOriginal = Texto
            Return mtdTiradorEspacoExtra()
        End Function
        Public Overloads Function mtdTiradorCaractereInvalido() As String
            Dim chrCarac As Char
            Dim Index As Integer
            Dim strTextoTemporario As String = String.Empty
            For i As Integer = 0 To getTextoOriginal.Length - 1
                chrCarac = Convert.ToChar(getTextoOriginal.Substring(i, 1))
                Index = Convert.ToInt32(chrCarac)
                If Not (Index = 34 Or Index = 39 Or Index = 45 Or Index = 47) Then
                    strTextoTemporario &= chrCarac
                End If
            Next
            setTextoSemCaractereInvalido = strTextoTemporario.Trim()
            Return getTextoSemCaractereInvalido
        End Function
        Public Overloads Function mtdTiradorCaractereInvalido(ByVal Texto As String) As String
            setTextoOriginal = Texto
            Return mtdTiradorCaractereInvalido()
        End Function
        ' Essa função devolve os caracteres digatados do texto em maiúsculo.
        Public Overloads Function mtdMaiusculo() As String
            setTextoMaiusculo = getTextoOriginal.ToUpper()
            Return getTextoMaiusculo
        End Function
        Public Overloads Function mtdMaiusculo(ByVal Texto As String) As String
            setTextoOriginal = Texto
            Return mtdMaiusculo()
        End Function
        ' Essa função devolve os caracteres digatados do texto em minúsculo.
        Public Overloads Function mtdMinusculo() As String
            setTextoMinusculo = getTextoOriginal.ToLower()
            Return getTextoMinusculo
        End Function
        Public Overloads Function mtdMinusculo(ByVal Texto As String) As String
            setTextoOriginal = Texto
            Return mtdMinusculo()
        End Function
        ' Essa função retira todos os acentos gráficos atinentes aos caracteres digitados.
        Public Overloads Function mtdTiradorAcentos() As String
            Dim chrCarac As Char
            Dim Index As Integer
            Dim strTextoTemporario As String = String.Empty
            For i As Integer = 0 To getTextoOriginal.Length - 1
                chrCarac = Convert.ToChar(getTextoOriginal.Substring(i, 1))
                Index = Convert.ToInt32(chrCarac)
                Select Case Index
                    Case 192, 193, 194, 195, 196, 197, 198
                        strTextoTemporario &= "A"
                    Case 199
                        strTextoTemporario &= "C"
                    Case 200, 201, 202, 203
                        strTextoTemporario &= "E"
                    Case 204, 205, 206, 207
                        strTextoTemporario &= "I"
                    Case 210, 211, 212, 213, 214
                        strTextoTemporario &= "O"
                    Case 217, 218, 219, 220
                        strTextoTemporario &= "U"
                    Case 224, 225, 226, 227, 228, 229
                        strTextoTemporario &= "a"
                    Case 231
                        strTextoTemporario &= "c"
                    Case 232, 233, 234, 235
                        strTextoTemporario &= "e"
                    Case 236, 237, 238, 239
                        strTextoTemporario &= "i"
                    Case 242, 243, 244, 245, 246
                        strTextoTemporario &= "o"
                    Case 249, 250, 251, 252
                        strTextoTemporario &= "u"
                    Case Else
                        strTextoTemporario &= chrCarac
                End Select
            Next
            setSemAcentos = strTextoTemporario
            Return getSemAcentos
        End Function
        Public Overloads Function mtdTiradorAcentos(ByVal Texto As String) As String
            setTextoOriginal = Texto
            Return mtdTiradorAcentos()
        End Function
        ' Essa função realiza todas as tarefas das funções anteriores, tornando todo o texto maiúsculo.
        Public Overloads Function mtdExecutarTudo() As String
            setTudoExecutado = mtdMaiusculo(mtdTiradorAcentos(mtdTiradorCaractereInvalido(mtdTiradorEspacoExtra(getTextoOriginal))))
            Return getTudoExecutado
        End Function
        Public Overloads Function mtdExecutarTudo(ByVal Texto As String) As String
            setTextoOriginal = Texto
            Return mtdExecutarTudo()
        End Function
        ' Essa função obriga somente digitar textos com números
        Public Overloads Function mtdPermitirDigitarSoNumero() As Boolean
            'Verifica se um caracter é permitido.
            Dim blnValor As Boolean = True
            'Selecione os caracteres que desejar.
            ' Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente.
            Dim Numeros As String = "0123456789" & Convert.ToChar(3) & Convert.ToChar(8) & Convert.ToChar(22) & Convert.ToChar(24)
            Return Not Numeros.Contains(getKeyChar)
        End Function
        Public Overloads Function mtdPermitirDigitarSoNumero(ByVal Key As Integer) As Boolean
            'Verifica se um caracter é permitido.
            setKey = Key
            Return mtdPermitirDigitarSoNumero()
        End Function
        Public Overloads Function mtdPermitirDigitarSoNumero(ByVal KeyChar As Char) As Boolean
            'Verifica se um caracter é permitido.
            setKeyChar = KeyChar
            Return mtdPermitirDigitarSoNumero()
        End Function
        ' Essa função obriga somente digitar textos com caracteres sem acentos gráficos
        Public Overloads Function mtdPermitirDigitarSoTexto() As Boolean
            'Verifica se um caracter é permitido.
            Dim blnValor As Boolean = True
            'Selecione os caracteres que desejar.
            ' Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente.
            Dim Texto As String = " ,.-0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" & Convert.ToChar(3) & Convert.ToChar(8) & Convert.ToChar(22) & Convert.ToChar(24)
            Return Not Texto.Contains(getKeyChar)
        End Function
        Public Overloads Function mtdPermitirDigitarSoTexto(ByVal Key As Integer) As Boolean
            'Verifica se um caracter é permitido.
            setKey = Key
            Return mtdPermitirDigitarSoTexto()
        End Function
        Public Overloads Function mtdPermitirDigitarSoTexto(ByVal KeyChar As Char) As Boolean
            'Verifica se um caracter é permitido.
            setKeyChar = KeyChar
            Return mtdPermitirDigitarSoTexto()
        End Function
        ' Essa função faz obriga somente digitar textos sem números
        Public Overloads Function mtdPermitirDigitarSoNome() As Boolean
            'Verifica se um caracter é permitido.
            Dim blnValor As Boolean = True
            'Selecione os caracteres que desejar.
            ' Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente.
            Dim Texto As String = " -abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" & Convert.ToChar(3) & Convert.ToChar(8) & Convert.ToChar(22) & Convert.ToChar(24)
            Return Not Texto.Contains(getKeyChar)
        End Function
        Public Overloads Function mtdPermitirDigitarSoNome(ByVal Key As Integer) As Boolean
            'Verifica se um caracter é permitido.
            setKey = Key
            Return mtdPermitirDigitarSoNome()
        End Function
        Public Overloads Function mtdPermitirDigitarSoNome(ByVal KeyChar As Char) As Boolean
            'Verifica se um caracter é permitido.
            setKeyChar = KeyChar
            Return mtdPermitirDigitarSoNome()
        End Function
        ' Essa função faz obriga somente digitar textos que sejam atinentes a datas
        Public Overloads Function mtdPermitirDigitarSoData() As Boolean
            'Verifica se um caracter é permitido.
            Dim blnValor As Boolean = True
            'Selecione os caracteres que desejar.
            ' Os valores ASC 3, 8, 22, 24 abilitam os comandos Ctrl+C, Backspace, Ctrl+V e Ctrl+X respectivamente.
            Dim Numeros As String = " -abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" & Convert.ToChar(3) & Convert.ToChar(8) & Convert.ToChar(22) & Convert.ToChar(24)
            Return Not Numeros.Contains(getKeyChar)
        End Function
        Public Overloads Function mtdPermitirDigitarSoData(ByVal Key As Integer) As Boolean
            'Verifica se um caracter é permitido.
            setKey = Key
            Return mtdPermitirDigitarSoData()
        End Function
        Public Overloads Function mtdPermitirDigitarSoData(ByVal KeyChar As Char) As Boolean
            'Verifica se um caracter é permitido.
            setKeyChar = KeyChar
            Return mtdPermitirDigitarSoData()
        End Function
        ' Método Finalizador.
        Protected Overrides Sub Finalize()
            Try
                numInstanciasCriadas -= 1
                System.GC.Collect(0)
            Finally
                MyBase.Finalize()
            End Try
        End Sub
    End Class

    ' Classe que gera um temporizador simples de ser usado, e razoavelmente preciso.
    Public Class clsTemporizador
        ' Como pode ser percebido abaixo, essa classe é inerente ao kernel32.dll, portanto, tendo sua portabilidade comprometida.
        ' Variável de classe
        Private Shared numInstanciasCriadas As Integer = 0
        ' Variável de instância
        Private intervalo As Double = 0
        Private tempo As Double = 0
        Private tempoMax As Double = 0
        Private contadorInicial As Long = 0
        Private contador As Long = 0
        Private difcontador As Long = 0
        Private frequencia As Long = Long.MaxValue ' Número máximo que um inteiro longo sinalizado positivo pode suportar (((2^64)/2)-1).
        Private numLoops As Double = 0
        Private mensagemErro As String = "Não houve erros."
        ' Métodos estáticos - Static (CS.Net) ou compartilhados - Shared (VB.Net)
        <SuppressUnmanagedCodeSecurity()>
        Private Declare Auto Function QueryPerformanceCounter Lib "kernel32.dll" (ByRef lpPerformanceCount As Long) As Boolean
        <SuppressUnmanagedCodeSecurity()>
        Private Declare Auto Function QueryPerformanceFrequency Lib "kernel32.dll" (ByRef lpFrequency As Long) As Boolean
        ' Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe.
        Public Shared ReadOnly Property getnumInstanciasCriadas() As Integer
            Get
                Return numInstanciasCriadas
            End Get
        End Property
        ' Propriedades que resgatam o valor das variáveis de instância.
        Public ReadOnly Property getintervalo() As Double
            Get
                Return intervalo
            End Get
        End Property
        Public ReadOnly Property gettempo() As Double
            Get
                Return tempo
            End Get
        End Property
        Public Property prptempoMax() As Double
            Get
                Return tempoMax
            End Get
            Set(ByVal value As Double)
                If (value > 0) Then
                    tempoMax = value
                Else
                    tempoMax = 1
                    mensagemErro = "Ajuste o valor da variável tempoMax para que seja maior do que zero, " &
                    "caso contrário será atribuído o tempo de um segundo a ela."
                End If
            End Set
        End Property
        Public ReadOnly Property getcontadorInicial() As Double
            Get
                Return contadorInicial
            End Get
        End Property
        Public ReadOnly Property getcontador() As Double
            Get
                Return contador
            End Get
        End Property
        Public ReadOnly Property getdifcontador() As Double
            Get
                Return difcontador
            End Get
        End Property
        Public ReadOnly Property getfrequencia() As Double
            Get
                Return intervalo
            End Get
        End Property
        Public ReadOnly Property getnumLoops() As Double
            Get
                Return numLoops
            End Get
        End Property
        Public ReadOnly Property getmensagemErro() As String
            Get
                Return mensagemErro
            End Get
        End Property
        ' Métodos que para serem usados, a classe deverá ser instanciada em um objeto. 
        ' Métodos construtores sobrecarregados.
        Public Sub New()
            numInstanciasCriadas += 1
        End Sub
        Public Sub New(ByVal tempoMax As Double)
            prptempoMax = tempoMax
            numInstanciasCriadas += 1
        End Sub
        ' Métodos convencionais.
        Public Function mtdInformacao() As String
            Return "O tempo é dado em segundos, e a frequência de operação é dada em hertz."
        End Function
        Public Function mtdTemporizador() As Boolean
            Dim erro As Boolean = False
            tempo = Convert.ToDouble((contador - contadorInicial) / frequencia)
            If QueryPerformanceCounter(contadorInicial) <> False Then
                ' Início do código temporizador. 
                While (tempo < tempoMax)
                    QueryPerformanceCounter(contador)
                    QueryPerformanceFrequency(frequencia)
                    intervalo = Convert.ToDouble(1.0 / frequencia)
                    tempo = (contador - contadorInicial) * intervalo
                End While
                mensagemErro = "Não houve erros."
                erro = True
            Else
                mensagemErro = "Resolução acima do suportado."
                erro = False
            End If
            Return erro
        End Function
        Public Function mtdTemporizador(ByVal tempoMax As Double) As Boolean
            prptempoMax = tempoMax
            Return mtdTemporizador()
        End Function
        Public Function mtdIniciarContador() As Long
            If (QueryPerformanceCounter(contadorInicial) = False) Then
                mensagemErro = "Resolução acima do suportado."
                Return contadorInicial
            End If
        End Function
        Public Function mtdPassoTempo() As Double
            If (contadorInicial = -1) Then
                contadorInicial = mtdIniciarContador()
            End If
            tempo = Convert.ToDouble((contador - contadorInicial) / frequencia)
            If (QueryPerformanceCounter(contador) <> False) Then
                ' Início do código temporizador. 
                QueryPerformanceCounter(contador)
                QueryPerformanceFrequency(frequencia)
                intervalo = Convert.ToDouble(1.0 / frequencia)
                tempo = (contador - contadorInicial) * intervalo
            Else
                mensagemErro = "Resolução acima do suportado."
            End If
            Return tempo
        End Function
        Public Function mtdPassoTempo(ByVal tempoMax As Double) As Double
            prptempoMax = tempoMax
            Return mtdPassoTempo()
        End Function
        Public Overrides Function ToString() As String
            Dim saida As String = "Contador Inicial: " & contadorInicial & "; Contador: " & contador & ";" & vbNewLine & "Tempo: " & tempo &
            " (s); Tempo Limite: " & tempoMax & " (s); Frequência: " & frequencia & " (Hz);" & vbNewLine & "Intervalo: " & intervalo &
            " (Hz); Diferença entre os contadores: " & difcontador & ";" & vbNewLine & "Números de Loops: " & numLoops &
            "; Número de Instâncias Criadas: " & numInstanciasCriadas & ";" & vbNewLine & "Mensagem de Erro: " & mensagemErro
            Return saida
        End Function
        ' Método finalizador.
        Protected Overrides Sub Finalize()
            Try
                numInstanciasCriadas -= 1
                System.GC.Collect(0)
            Finally
                MyBase.Finalize()
            End Try
        End Sub
    End Class

    Public Class clsEnderecoAplicativo
        ' Variável de classe
        Private Shared numInstanciasCriadas As Integer = 0
        ' Método construtor sem parâmetros da classe, construção essa comum em Java
        Public Sub New()
            numInstanciasCriadas += 1
            Endereco()
        End Sub
        ' Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe.
        Public Shared ReadOnly Property getnumInstanciasCriadas() As Integer
            Get
                Return numInstanciasCriadas
            End Get
        End Property
        Public Function Endereco() As String
            Dim varEnderecoAplicativo As String = String.Empty
            Dim chrCaractere As Char
            Dim countBI As Integer = 0, countmaxBI As Integer = 0
            For i As Integer = 0 To GetExecutingAssembly.Location().Length - 1
                chrCaractere = GetExecutingAssembly.Location(i)
                If chrCaractere = "\" Then
                    countmaxBI += 1
                End If
            Next
            For i As Integer = 0 To GetExecutingAssembly.Location().Length - 1
                chrCaractere = GetExecutingAssembly.Location(i)
                varEnderecoAplicativo &= chrCaractere
                If chrCaractere = "\" Then
                    If countmaxBI - 1 = countBI Then
                        Exit For
                    End If
                    countBI += 1
                End If
            Next
            Return varEnderecoAplicativo
        End Function
        Protected Overrides Sub Finalize()
            Try
                numInstanciasCriadas -= 1
                System.GC.Collect(0)
            Finally
                MyBase.Finalize()
            End Try
        End Sub
    End Class
End Namespace
