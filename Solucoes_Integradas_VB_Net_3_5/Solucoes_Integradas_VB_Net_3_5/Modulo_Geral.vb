'Imports MySql.Data.MySqlClient ' Classe clsMySQL
Imports System.Data.OleDb ' Classe clsImplementacaoBancoDados
Imports System.IO
Imports System.Security
Imports System.Reflection.Assembly
Imports Microsoft.Win32 ' clsRegistroWindows

Module Modulo_Geral

#Region "clsRegistroWindows"
    Public Class clsRegistroWindows
        ' Variáveis de Instância.
        Private erro As Boolean = False
        Private TipoValor As RegistryValueKind = RegistryValueKind.String
        Private ChavePrincipal As Object, Secao As Object, Chave As Object, Valor As Object, Dados As Object ' Variáveis encapsuladas
        Private mensagem As String = String.Empty
        Private mensagemExcecao As String = String.Empty
        Private regKey As RegistryKey = Registry.CurrentUser
        Private SubRegistro As RegistryKey = Registry.CurrentUser
        ' Método construtor sem parâmetros.
        Public Sub New()
        End Sub
        ' Métodos construtores com parâmetros.
        Public Sub New(ByVal Chave As Object)
            setChave = Chave
        End Sub
        Public Sub New(ByVal Valor As Object, ByVal Dados As Object)
            setDados = Dados
            setValor = Valor
        End Sub
        Public Sub New(ByVal Valor As Object, ByVal Dados As Object, ByVal TipoValor As RegistryValueKind)
            setTipoValor = TipoValor
            setDados = Dados
            setValor = Valor
        End Sub
        Public Sub New(ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object)
            setDados = Dados
            setValor = Valor
            setChave = Chave
        End Sub
        Public Sub New(ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object, ByVal TipoValor As RegistryValueKind)
            setTipoValor = TipoValor
            setDados = Dados
            setValor = Valor
            setChave = Chave
        End Sub
        Public Sub New(ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object)
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
        End Sub
        Public Sub New(ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object, ByVal TipoValor As RegistryValueKind)
            setTipoValor = TipoValor
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
        End Sub
        Public Sub New(ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object)
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
            setChavePrincipal = ChavePrincipal
        End Sub
        Public Sub New(ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object, ByVal TipoValor As RegistryValueKind)
            setTipoValor = TipoValor
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
            setChavePrincipal = ChavePrincipal
        End Sub
        Public Sub New(ByVal SubRegistro As RegistryKey, ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object)
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
            setChavePrincipal = ChavePrincipal
            setSubRegistro = SubRegistro
        End Sub
        Public Sub New(ByVal SubRegistro As RegistryKey, ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object, ByVal TipoValor As RegistryValueKind)
            setTipoValor = TipoValor
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
            setChavePrincipal = ChavePrincipal
            setSubRegistro = SubRegistro
        End Sub

        ' Propriedade que resgata o conteúdo da variável de instância SubRegistro.
        Public ReadOnly Property getSubRegistro() As RegistryKey
            Get
                Return SubRegistro
            End Get
        End Property
        ' Propriedade que define o conteúdo da variável de instância SubRegistro.
        Public WriteOnly Property setSubRegistro() As RegistryKey
            Set(ByVal value As RegistryKey)
                SubRegistro = value
            End Set
        End Property
        ' Propriedade que resgata o conteúdo da variável de instância ChavePrincipal.
        Public ReadOnly Property getChavePrincipal() As Object
            Get
                If (Convert.ToString(ChavePrincipal) <> String.Empty) Then
                    mensagem = "Não ocorreu problemas."
                Else
                    mensagem = "Não há conteúdo na variável ChavePrincipal."
                End If
                Return ChavePrincipal
            End Get
        End Property
        ' Propriedade que define o conteúdo da variável de instância ChavePrincipal.
        Public WriteOnly Property setChavePrincipal() As Object
            Set(ByVal value As Object)
                ChavePrincipal = value
            End Set
        End Property
        ' Propriedade que resgata o conteúdo da variável de instância Secao.
        Public ReadOnly Property getSecao() As Object
            Get
                If (Convert.ToString(Secao) <> String.Empty) Then
                    mensagem = "Não ocorreu problemas."
                Else
                    mensagem = "Não há conteúdo na variável Secao."
                End If
                Return Secao
            End Get
        End Property
        ' Propriedade que define o conteúdo da variável de instância Secao.
        Public WriteOnly Property setSecao() As Object
            Set(ByVal value As Object)
                Secao = value
            End Set
        End Property
        ' Propriedade que resgata o conteúdo da variável de instância Chave. 
        Public ReadOnly Property getChave() As Object
            Get
                If (Convert.ToString(Chave) <> String.Empty) Then
                    mensagem = "Não ocorreu problemas."
                Else
                    mensagem = "Não há conteúdo na variável Chave."
                End If
                Return Chave
            End Get
        End Property
        ' Propriedade que define o conteúdo da variável de instância Chave. 
        Public WriteOnly Property setChave() As Object
            Set(ByVal value As Object)
                Chave = value
            End Set
        End Property
        ' Propriedade que resgata o conteúdo da variável de instância Valor. 
        Public ReadOnly Property getValor() As Object
            Get
                If (Convert.ToString(Valor) <> String.Empty) Then
                    mensagem = "Não ocorreu problemas."
                Else
                    mensagem = "Não há conteúdo na variável Valor."
                End If
                Return Valor
            End Get
        End Property
        ' Propriedade que define o conteúdo da variável de instância Valor. 
        Public WriteOnly Property setValor() As Object
            Set(ByVal value As Object)
                Valor = value
            End Set
        End Property
        ' Propriedade que resgata o conteúdo da variável de instância Secao. 
        Public ReadOnly Property getDados() As Object
            Get
                If Not (Convert.ToString(Dados) <> String.Empty) Then
                    mensagem = "Não ocorreu problemas."
                Else
                    mensagem = "Não há conteúdo na variável Dados."
                End If
                Return Dados
            End Get
        End Property
        ' Propriedade que define o conteúdo da variável de instância Secao. 
        Public WriteOnly Property setDados() As Object
            Set(ByVal value As Object)
                Dados = value
            End Set
        End Property
        ' Propriedade que resgata o conteúdo da variável de instância TipoValor. 
        Public ReadOnly Property getTipoValor() As RegistryValueKind
            Get
                Return TipoValor
            End Get
        End Property
        ' Propriedade que define o conteúdo da variável de instância TipoValor. 
        Public WriteOnly Property setTipoValor() As RegistryValueKind
            Set(ByVal value As RegistryValueKind)
                TipoValor = value
            End Set
        End Property
        ' Propriedade que resgata o conteúdo da variável de instância mensagem. 
        Public ReadOnly Property getmensagem() As String
            Get
                If (mensagem <> String.Empty) Then
                    Return mensagem
                Else
                    Return "Não há conteúdo na variável mensagem."
                End If
            End Get
        End Property
        ' Propriedade que define o conteúdo da variável de instância mensagem. 
        Private WriteOnly Property setmensagem() As String
            Set(ByVal value As String)
                mensagem = value
            End Set
        End Property
        ' Propriedade que resgata o conteúdo da variável de instância mensagemExcecao. 
        Public ReadOnly Property getmensagemExcecao() As String
            Get
                If (mensagemExcecao <> String.Empty) Then
                    Return mensagemExcecao
                Else
                    Return "Não há conteúdo na variável mensagemExcecao."
                End If
            End Get
        End Property
        ' Propriedade que define o conteúdo da variável de instância mensagemExcecao. 
        Private WriteOnly Property setmensagemExcecao() As String
            Set(ByVal value As String)
                mensagemExcecao = value
            End Set
        End Property
        ' Método sobrecarregado que salva os Dados no registro do Windows. 
        Public Overloads Function mtdSalvarDadosRegistro() As Boolean
            Try
                regKey = getSubRegistro
                ' Cria uma referêcnia para a Valor de registro na variável getSecao.
                regKey = regKey.CreateSubKey(Convert.ToString(getChavePrincipal))
                regKey = regKey.CreateSubKey(Convert.ToString(getSecao))
                ' Cria uma SubValor com o nome na variável getChave.
                regKey = regKey.CreateSubKey(Convert.ToString(getChave))
                ' Grava o caminho na SubValor GravaRegistro.
                Select Case getTipoValor
                    Case RegistryValueKind.MultiString
                        Dim blnExisteParagrafo As Boolean = False
                        Dim numeroParagrafo As Integer = 0
                        For contador As Integer = 0 To getDados.ToString.Length - 1 Step 1
                            Dim chrCaractere As Char = getDados.ToString.Chars(contador)
                            Dim intNumero As Integer = Convert.ToInt32(chrCaractere)
                            If (intNumero = 13) Then
                                If (Not intNumero = 10) Then
                                    numeroParagrafo += 1
                                End If
                            End If
                        Next
                        Dim vetDados(numeroParagrafo) As String
                        numeroParagrafo = 0
                        For contador As Integer = 0 To getDados.ToString.Length - 1 Step 1
                            Dim chrCaractere As Char = getDados.ToString.Chars(contador)
                            Dim intNumero As Integer = Convert.ToInt32(chrCaractere)
                            If (Not intNumero = 13) Then
                                If (Not intNumero = 10) Then
                                    If blnExisteParagrafo = True Then
                                        numeroParagrafo += 1
                                        blnExisteParagrafo = False
                                    End If
                                    vetDados(numeroParagrafo) &= chrCaractere
                                End If
                            Else
                                If Not vetDados(numeroParagrafo) Is Nothing Then
                                    vetDados(numeroParagrafo) = vetDados(numeroParagrafo).ToString()
                                    blnExisteParagrafo = True
                                End If
                            End If
                        Next
                        Dim stringDados(numeroParagrafo) As String
                        Array.Copy(vetDados, stringDados, numeroParagrafo + 1)
                        regKey.SetValue(Convert.ToString(getValor), stringDados, getTipoValor)
                    Case RegistryValueKind.Binary
                        Dim byteDados(getDados.ToString.Length) As Byte
                        For contador As Integer = 0 To getDados.ToString.Length - 1 Step 1
                            byteDados(contador) = Convert.ToByte(Convert.ToInt64(getDados.ToString.Chars(contador)))
                        Next
                        regKey.SetValue(Convert.ToString(getValor), byteDados, getTipoValor)
                    Case Else
                        regKey.SetValue(Convert.ToString(getValor), getDados, getTipoValor)
                End Select
                ' Fecha a Valor de Registro.
                erro = True
                mensagem = "Os Dados foram salvos no registro."
            Catch ex As Exception
                erro = False
                mensagem = "Os Dados não foram salvos no registro"
                mensagemExcecao = ex.Message
            End Try
            Return erro
        End Function
        ' Métodos que salvam os Dados no registro do Windows de acordo com os parâmetros fornecidos.
        Public Overloads Function mtdSalvarDadosRegistro(ByVal Valor As Object, ByVal Dados As Object) As Boolean
            setDados = Dados
            setValor = Valor
            Return mtdSalvarDadosRegistro()
        End Function
        Public Overloads Function mtdSalvarDadosRegistro(ByVal Valor As Object, ByVal Dados As Object, ByVal TipoValor As RegistryValueKind) As Boolean
            setTipoValor = TipoValor
            setDados = Dados
            setValor = Valor
            Return mtdSalvarDadosRegistro()
        End Function
        Public Overloads Function mtdSalvarDadosRegistro(ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object) As Boolean
            setDados = Dados
            setValor = Valor
            setChave = Chave
            Return mtdSalvarDadosRegistro()
        End Function
        Public Overloads Function mtdSalvarDadosRegistro(ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object, ByVal TipoValor As RegistryValueKind) As Boolean
            setTipoValor = TipoValor
            setDados = Dados
            setValor = Valor
            setChave = Chave
            Return mtdSalvarDadosRegistro()
        End Function
        Public Overloads Function mtdSalvarDadosRegistro(ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object) As Boolean
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
            Return mtdSalvarDadosRegistro()
        End Function
        Public Overloads Function mtdSalvarDadosRegistro(ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object, ByVal TipoValor As RegistryValueKind) As Boolean
            setTipoValor = TipoValor
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
            Return mtdSalvarDadosRegistro()
        End Function
        Public Overloads Function mtdSalvarDadosRegistro(ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object) As Boolean
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
            setChavePrincipal = ChavePrincipal
            Return mtdSalvarDadosRegistro()
        End Function
        Public Overloads Function mtdSalvarDadosRegistro(ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object, ByVal TipoValor As RegistryValueKind) As Boolean
            setTipoValor = TipoValor
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
            setChavePrincipal = ChavePrincipal
            Return mtdSalvarDadosRegistro()
        End Function
        Public Overloads Function mtdSalvarDadosRegistro(ByVal SubRegistro As RegistryKey, ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object) As Boolean
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
            setChavePrincipal = ChavePrincipal
            setSubRegistro = SubRegistro
            Return mtdSalvarDadosRegistro()
        End Function
        Public Overloads Function mtdSalvarDadosRegistro(ByVal SubRegistro As RegistryKey, ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object, ByVal Dados As Object, ByVal TipoValor As RegistryValueKind) As Boolean
            setTipoValor = TipoValor
            setDados = Dados
            setValor = Valor
            setChave = Chave
            setSecao = Secao
            setChavePrincipal = ChavePrincipal
            setSubRegistro = SubRegistro
            Return mtdSalvarDadosRegistro()
        End Function
        ' Método sobrecarregado que resgata os Dadoss no registro do Windows. 
        Public Overloads Function mtdObterDadosRegistro() As Object
            Dim saida As String = String.Empty
            Try
                regKey = getSubRegistro
                ' Cria uma referência para a Valor de registro na variável 
                regKey = regKey.OpenSubKey(Convert.ToString(getChavePrincipal), True)
                regKey = regKey.OpenSubKey(Convert.ToString(getSecao), True)
                regKey = regKey.OpenSubKey(Convert.ToString(getChave), True)
                ' realiza a leitura do registro
                saida = Convert.ToString(regKey.GetValue(Convert.ToString(getValor)))
                Select Case saida
                    Case "System.Byte[]"
                        Dim vet(100) As Object
                        saida = "Os dados proveem de um vetor do tipo byte, por isso não serão apresentados."
                    Case "System.String[]"
                        saida = "Os dados proveem de um vetor do tipo string, por isso não serão apresentados."
                End Select
            Catch ex As Exception
                erro = False
                mensagem = "Não há Dados nos Valores a serem retornados ou não foi possível obtê-los."
                mensagemExcecao = ex.Message
            End Try
            Return saida
        End Function
        ' Método sobrecarregado que resgatam os Dadoss no registro do Windows de acordo com os parâmetros fornecidos. 
        Public Overloads Function mtdObterDadosRegistro(ByVal Valor As Object) As Object
            setValor = Valor
            Return mtdObterDadosRegistro()
        End Function
        Public Overloads Function mtdObterDadosRegistro(ByVal Chave As Object, ByVal Valor As Object) As Object
            setChave = Chave
            setValor = Valor
            Return mtdObterDadosRegistro()
        End Function
        Public Overloads Function mtdObterDadosRegistro(ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object) As Object
            setSecao = Secao
            setChave = Chave
            setValor = Valor
            Return mtdObterDadosRegistro()
        End Function
        Public Overloads Function mtdObterDadosRegistro(ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object) As Object
            setChavePrincipal = ChavePrincipal
            setSecao = Secao
            setChave = Chave
            setValor = Valor
            Return mtdObterDadosRegistro()
        End Function
        Public Overloads Function mtdObterDadosRegistro(ByVal SubRegistro As RegistryKey, ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object) As Object
            setSubRegistro = SubRegistro
            setChavePrincipal = ChavePrincipal
            setSecao = Secao
            setChave = Chave
            setValor = Valor
            Return mtdObterDadosRegistro()
        End Function
        ' Método sobrecarregado que deleta o Nome de Aplicativo conjuntamente com o seu conteúdo. 
        Public Overloads Function mtdDeletarDadosRegistro() As Boolean
            Try
                regKey = getSubRegistro
                regKey = regKey.OpenSubKey(Convert.ToString(getChavePrincipal), True)
                regKey = regKey.OpenSubKey(Convert.ToString(getSecao), True)
                regKey = regKey.OpenSubKey(Convert.ToString(getChave), True)
                regKey.DeleteValue(Convert.ToString(getValor))
                erro = True
                mensagem = "O Dado foi deletado."
            Catch ex As Exception
                erro = False
                mensagem = "Não há Dados nos Valores a serem retornados ou não foi possível deletá-los."
                mensagemExcecao = ex.Message
            End Try
            Return erro
        End Function
        ' Método sobrecarregado que deleta a Seção conjuntamente com a suas Valors 
        ' dentro de um Nome de Aplicativo. 
        Public Overloads Function mtdDeletarDadosRegistro(ByVal Valor As Object) As Object
            setValor = Valor
            Return mtdDeletarDadosRegistro()
        End Function
        ' Método sobrecarregado que deleta a Valor dentro da Seção.
        Public Overloads Function mtdDeletarDadosRegistro(ByVal Chave As Object, ByVal Valor As Object) As Boolean
            setChave = Chave
            setValor = Valor
            Return mtdDeletarDadosRegistro()
        End Function
        ' Método sobrecarregado que deleta a Valor dentro da Seção que está contida no Nome de Aplicativo. 
        Public Overloads Function mtdDeletarDadosRegistro(ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object) As Boolean
            setSecao = Secao
            setChave = Chave
            setValor = Valor
            Return mtdDeletarDadosRegistro()
        End Function
        ' Método sobrecarregado que deleta a Valor dentro da Seção que está contida no Nome de Aplicativo, detro do Tipo de Registro. 
        Public Overloads Function mtdDeletarDadosRegistro(ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object) As Boolean
            setChavePrincipal = ChavePrincipal
            setSecao = Secao
            setChave = Chave
            setValor = Valor
            Return mtdDeletarDadosRegistro()
        End Function
        ' Método sobrecarregado que deleta a Valor dentro da Seção que está contida no Nome de Aplicativo, detro do Tipo de Registro. 
        Public Overloads Function mtdDeletarDadosRegistro(ByVal SubRegistro As RegistryKey, ByVal ChavePrincipal As Object, ByVal Secao As Object, ByVal Chave As Object, ByVal Valor As Object) As Boolean
            setSubRegistro = SubRegistro
            setChavePrincipal = ChavePrincipal
            setSecao = Secao
            setChave = Chave
            setValor = Valor
            Return mtdDeletarDadosRegistro()
        End Function
        Public Function mtdFimChaveRecursivo(ByVal Chave() As String) As Boolean
            Dim blnRetorno As Boolean = False
            regKey = Registry.CurrentUser
            If Chave.Length <> 0 Then
                For contador As Integer = 0 To Chave.Length - 1
                    regKey = regKey.OpenSubKey(Chave(contador))
                Next
                If regKey.GetSubKeyNames.Length = 0 Then
                    blnRetorno = True
                Else
                    blnRetorno = False
                End If
                blnRetorno = False
            End If
            Return blnRetorno
        End Function
        ' Método Finalizador. 
        Protected Overrides Sub Finalize()
            Try
                System.GC.Collect(0)
                'regKey.Close()
            Finally
                MyBase.Finalize()
            End Try
        End Sub
    End Class
#End Region
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
            For i As Integer = 0 To getTextoOriginal.Length - 1 Step 1
                chrCarac = Convert.ToChar(getTextoOriginal.Substring(i, 1))
                Index = Convert.ToInt32(chrCarac)
                Select Case Index
                    Case 32
                        If Not Verificador Then
                            strTextoTemporario &= chrCarac
                            Verificador = True
                        End If
                    Case Else
                        strTextoTemporario &= chrCarac
                        Verificador = False
                End Select
            Next
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
                'If Not (Index = 34 Or Index = 39 Or Index = 45 Or Index = 47 Or Index = 92) Then
                If Not (Index = 34 Or Index = 39 Or Index = 47 Or Index = 92) Then
                    strTextoTemporario &= chrCarac
                Else
                    strTextoTemporario &= Convert.ToChar(32)
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
                    Case System.Convert.ToInt16("á"c), 192, 193, 194, 195, 196, 197, 198
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
        <SuppressUnmanagedCodeSecurity()> _
        Private Declare Auto Function QueryPerformanceCounter Lib "kernel32.dll" (ByRef lpPerformanceCount As Long) As Boolean
        <SuppressUnmanagedCodeSecurity()> _
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
                    mensagemErro = "Ajuste o valor da variável tempoMax para que seja maior do que zero, " & _
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
            End If
            Return contadorInicial
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
            Dim saida As String = "Contador Inicial: " & contadorInicial & "; Contador: " & contador & ";" & vbNewLine & "Tempo: " & tempo & _
            " (s); Tempo Limite: " & tempoMax & " (s); Frequência: " & frequencia & " (Hz);" & vbNewLine & "Intervalo: " & intervalo & _
            " (Hz); Diferença entre os contadores: " & difcontador & ";" & vbNewLine & "Números de Loops: " & numLoops & _
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
    ''' <summary>
    ''' Classe que inicia procedimentos relativos a Criptografia.
    ''' </summary>
    Public Class clsCriptografia
        ''' <summary>
        ''' Variável de Classe
        ''' </summary>
        Private Shared numInstanciasCriadas As Integer = 0
        ''' <summary>
        ''' Variáveis de Instâncias
        ''' </summary>
        Private senha As String = String.Empty
        Private chave As String = String.Empty
        Private senhaCriptografada As String = String.Empty
        Private strMensagemErro As String = "Não há erros."
        Private tipoCriptografia As Encryption.Symmetric.Provider = Encryption.Symmetric.Provider.Rijndael
        ''' <summary>
        ''' Método Construtor sem argumentos.
        ''' </summary>
        Public Sub New()
            numInstanciasCriadas += 1
        End Sub
        ''' <summary>
        ''' Método Construtor com argumentos.
        ''' </summary>
        Public Sub New(ByVal senha As String)
            numInstanciasCriadas += 1
            setsenha = senha
        End Sub
        Public Sub New(ByVal senha As String, ByVal chave As String)
            numInstanciasCriadas += 1
            setsenha = senha
            setchave = chave
        End Sub
        Public Sub New(ByVal senha As String, ByVal chave As String, ByVal tipoCriptografia As Encryption.Symmetric.Provider)
            numInstanciasCriadas += 1
            setsenha = senha
            setchave = chave
            settipoCriptografia = tipoCriptografia
        End Sub
        ''' <summary>
        ''' Propriedade estática (compartilhada pela classe entre os objetos) que resgata o valor da variável de classe.
        ''' </summary>
        Public Shared ReadOnly Property getnumInstanciasCriadas() As Integer
            Get
                Return numInstanciasCriadas
            End Get
        End Property
        ''' <summary>
        ''' Propriedade que resgata a senha.
        ''' </summary>
        Public ReadOnly Property getsenha() As String
            Get
                Return senha
            End Get
        End Property
        ''' <summary>
        ''' Propriedade que ajusta a senha.
        ''' </summary>
        Public WriteOnly Property setsenha() As String
            Set(ByVal value As String)
                If value.Length > 0 Then
                    senha = value
                Else
                    strMensagemErro = "Digite uma senha que não seja nula."
                End If
            End Set
        End Property
        ''' <summary>
        ''' Propriedade que resgata a chave.
        ''' </summary>
        Public ReadOnly Property getchave() As String
            Get
                Return chave
            End Get
        End Property
        ''' <summary>
        ''' Propriedade que ajusta a chave.
        ''' </summary>
        Public WriteOnly Property setchave() As String
            Set(ByVal value As String)
                If value.Length > 0 And value.Length < 17 Then
                    chave = value
                Else
                    strMensagemErro = "Digite uma chave com comprimento entre 1 e 16 caracteres."
                End If
            End Set
        End Property
        ''' <summary>
        ''' Propriedade que resgata a senha criptografada.
        ''' </summary>
        Public ReadOnly Property getsenhaCriptografada() As String
            Get
                Return senhaCriptografada
            End Get
        End Property
        ''' <summary>
        ''' Propriedade que ajusta a senha criptografada.
        ''' </summary>
        Public WriteOnly Property setsenhaCriptografada() As String
            Set(ByVal value As String)
                If value.Length > 0 Then
                    senhaCriptografada = value
                Else
                    strMensagemErro = "Digite uma senha criptografada que não seja nula."
                End If
            End Set
        End Property
        ''' <summary>
        ''' Propriedade que resgata a mensagem de erro.
        ''' </summary>
        Public ReadOnly Property getMensagemErro() As String
            Get
                Return strMensagemErro
            End Get
        End Property
        ''' <summary>
        ''' Propriedade que ajusta a mensagem de erro.
        ''' </summary>
        Public WriteOnly Property setMensagemErro() As String
            Set(ByVal value As String)
                strMensagemErro = value
            End Set
        End Property
        ''' <summary>
        ''' Propriedade que resgata o tipo de criptografia.
        ''' </summary>
        Public ReadOnly Property gettipoCriptografia() As Encryption.Symmetric.Provider
            Get
                Return tipoCriptografia
            End Get
        End Property
        ''' <summary>
        ''' Propriedade que ajusta o tipo de criptografia.
        ''' </summary>
        Public WriteOnly Property settipoCriptografia() As Encryption.Symmetric.Provider
            Set(ByVal value As Encryption.Symmetric.Provider)
                tipoCriptografia = value
            End Set
        End Property
        ''' <summary>
        ''' Métodos sobrecarregados de criptografar senha.
        ''' </summary>
        Public Overloads Function mtdCriptografar() As String
            Dim senhaCriptografada As String = String.Empty
            Dim sym As New Encryption.Symmetric(tipoCriptografia)
            Dim key As New Encryption.Data(chave)
            Dim encryptedData As Encryption.Data
            If Not chave = String.Empty Then
                If Not senha = String.Empty Then
                    encryptedData = sym.Encrypt(New Encryption.Data(senha), key)
                    senhaCriptografada = encryptedData.Text
                Else
                    senhaCriptografada = String.Empty
                End If
            End If
            setsenhaCriptografada = senhaCriptografada
            Return getsenhaCriptografada
        End Function
        Public Overloads Function mtdCriptografar(ByVal senha As String) As String
            setsenha = senha
            Return mtdCriptografar()
        End Function
        Public Overloads Function mtdCriptografar(ByVal senha As String, ByVal chave As String) As String
            setsenha = senha
            setchave = chave
            Return mtdCriptografar()
        End Function
        Public Overloads Function mtdCriptografar(ByVal senha As String, ByVal chave As String, ByVal tipoCriptografia As Encryption.Symmetric.Provider) As String
            setsenha = senha
            setchave = chave
            settipoCriptografia = tipoCriptografia
            Return mtdCriptografar()
        End Function
        ''' <summary>
        ''' Métodos sobrecarregados de descriptografar senha.
        ''' </summary>
        Public Overloads Function mtdDesCriptografar() As String
            Dim senhaDescriptografada As String = String.Empty
            Dim sym As New Encryption.Symmetric(tipoCriptografia)
            Dim key As New Encryption.Data(chave)
            Dim encryptedData As Encryption.Data = New Encryption.Data(senhaCriptografada)
            Dim decryptedData As Encryption.Data
            If Not chave = String.Empty Then
                If Not senhaCriptografada = String.Empty Then
                    decryptedData = sym.Decrypt(encryptedData, key)
                    senhaDescriptografada = decryptedData.Text
                Else
                    senhaDescriptografada = String.Empty
                End If
            End If
            setsenha = senhaDescriptografada
            Return getsenha
        End Function
        Public Overloads Function mtdDesCriptografar(ByVal senhaCriptografada As String) As String
            setsenhaCriptografada = senhaCriptografada
            Return mtdDesCriptografar()
        End Function
        Public Overloads Function mtdDesCriptografar(ByVal senhaCriptografada As String, ByVal chave As String) As String
            setsenhaCriptografada = senhaCriptografada
            setchave = chave
            Return mtdDesCriptografar()
        End Function
        Public Overloads Function mtdDesCriptografar(ByVal senhaCriptografada As String, ByVal chave As String, ByVal tipoCriptografia As Encryption.Symmetric.Provider) As String
            setsenhaCriptografada = senhaCriptografada
            setchave = chave
            settipoCriptografia = tipoCriptografia
            Return mtdDesCriptografar()
        End Function
        ''' <summary> 
        ''' Método Finalizador.
        ''' </summary>
        Protected Overrides Sub finalize()
            Try
                numInstanciasCriadas -= 1
                System.GC.Collect(0)
            Finally
                MyBase.Finalize()
            End Try
        End Sub
    End Class
    Public Class clsArquivoTXT
        Inherits Object
        ' Variável de classe
        Private Shared numInstanciasCriadas As Integer = 0

        ' Variáveis de Instância
        Private strEnderecoArquivo As String
        Private strTexto As String
        Private stwEscritorTexto As System.IO.StreamWriter
        Private stdLeitorTexto As System.IO.StreamReader
        Private bnrEscritorBinario As System.IO.BinaryWriter
        Private bnrLeitorBinario As System.IO.BinaryReader

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
            Set(value As String)
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
            Set(value As String)
                strTexto = value
            End Set
        End Property
        Public ReadOnly Property getFimArquivo() As Boolean
            Get
                Return stdLeitorTexto.EndOfStream
            End Get
        End Property
        Public Property prpEscritorTexto() As System.IO.StreamWriter
            Get
                Return stwEscritorTexto
            End Get
            Set(value As System.IO.StreamWriter)
                value = stwEscritorTexto
            End Set
        End Property
        Public Property prpLeitorTexto() As System.IO.StreamReader
            Get
                Return stdLeitorTexto
            End Get
            Set(value As System.IO.StreamReader)
                value = stdLeitorTexto
            End Set
        End Property
        Public Property prpEscritorBinario() As System.IO.BinaryWriter
            Get
                Return bnrEscritorBinario
            End Get
            Set(value As System.IO.BinaryWriter)
                value = bnrEscritorBinario
            End Set
        End Property
        Public Property prpLeitorBinario() As System.IO.BinaryReader
            Get
                Return bnrLeitorBinario
            End Get
            Set(value As System.IO.BinaryReader)
                value = bnrLeitorBinario
            End Set
        End Property

        Public Function mtdCriadorTexto() As Boolean
            Dim blnRetorno As Boolean = False

            Try
                stwEscritorTexto = System.IO.File.CreateText(getEnderecoArquivo)
                stwEscritorTexto.WriteLine(getTexto)
                stwEscritorTexto.Close()
                blnRetorno = True
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function
        Public Function mtdCriadorTexto(Texto As String) As Boolean
            setTexto = Texto
            Return mtdCriadorTexto()
        End Function
        Public Function mtdCriadorTexto(EnderecoArquivo As String, Texto As String) As Boolean
            setEnderecoArquivo = EnderecoArquivo
            setTexto = Texto
            Return mtdCriadorTexto()
        End Function
        Public Function mtdAcrescentarTexto() As Boolean
            Dim blnRetorno As Boolean = False
            Dim TextoTemporario As String = String.Empty
            Try
                Dim stdLeitorTexto As System.IO.StreamReader = System.IO.File.OpenText(getEnderecoArquivo)
                TextoTemporario = stdLeitorTexto.ReadToEnd()
                stdLeitorTexto.Close()
            Catch
                blnRetorno = False
            Finally
                Dim stwEscritorTexto As System.IO.StreamWriter = System.IO.File.CreateText(getEnderecoArquivo)
                stwEscritorTexto.Write(TextoTemporario & getTexto)
                stwEscritorTexto.Close()
                blnRetorno = True
            End Try

            Return blnRetorno
        End Function
        Public Function mtdAcrescentarTexto(Texto As String) As Boolean
            setTexto = Texto
            Return mtdAcrescentarTexto()
        End Function
        Public Function mtdAcrescentarTexto(EnderecoArquivo As String, Texto As String) As Boolean
            setEnderecoArquivo = EnderecoArquivo
            setTexto = Texto
            Return mtdAcrescentarTexto()
        End Function
        Public Function mtdLeitorTexto() As String
            stdLeitorTexto = System.IO.File.OpenText(getEnderecoArquivo)
            setTexto = stdLeitorTexto.ReadToEnd()
            stdLeitorTexto.Close()
            Return getTexto
        End Function
        Public Function mtdLeitorTexto(EnderecoArquivo As String) As String
            setEnderecoArquivo = EnderecoArquivo
            Return mtdLeitorTexto()
        End Function
        Public Sub mtdAbrirLeitorTexto()
            stdLeitorTexto = System.IO.File.OpenText(getEnderecoArquivo)
        End Sub
        Public Sub mtdAbrirLeitorTexto(EnderecoArquivo As String)
            setEnderecoArquivo = EnderecoArquivo
            stdLeitorTexto = System.IO.File.OpenText(getEnderecoArquivo)
        End Sub
        Public Function mtdLeitorTextoLinha() As String
            setTexto = stdLeitorTexto.ReadLine()
            Return getTexto
        End Function
        Public Function mtdEscritorBinario() As Boolean
            Dim blnRetorno As Boolean = False
            Try
                bnrEscritorBinario = New System.IO.BinaryWriter(System.IO.File.OpenWrite(getEnderecoArquivo))
                bnrEscritorBinario.Write(getTexto)
                bnrEscritorBinario.Close()
                blnRetorno = True
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function
        Public Function mtdEscritorBinario(Texto As String) As Boolean
            setTexto = Texto
            Return mtdEscritorBinario()
        End Function
        Public Function mtdEscritorBinario(EnderecoArquivo As String, Texto As String) As Boolean
            setEnderecoArquivo = EnderecoArquivo
            setTexto = Texto
            Return mtdEscritorBinario()
        End Function
        Public Function mtdLeitorBinario() As String
            bnrLeitorBinario = New System.IO.BinaryReader(System.IO.File.OpenRead(getEnderecoArquivo))
            setTexto = bnrLeitorBinario.ReadString()
            bnrLeitorBinario.Close()
            Return getTexto
        End Function
        Public Function mtdLeitorBinario(EnderecoArquivo As String) As String
            setEnderecoArquivo = EnderecoArquivo
            Return mtdLeitorBinario()
        End Function
        Protected Overrides Sub Finalize()
            Try
                ' Método Finalizador
                numInstanciasCriadas -= 1
                System.GC.Collect(0)
            Finally
                MyBase.Finalize()
            End Try
        End Sub
    End Class

    ''' <summary>
    ''' Encapsula um <see cref="System.IO.Stream" /> para calcular o checksum CRC32
    ''' em tempo de execução
    ''' </summary>
    Public Class clsCrcStream
        Inherits Stream
        ''' <summary>
        ''' Encapsula um <see cref="System.IO.Stream" />.
        ''' </summary>
        ''' <param name="stream">O stream para calcular o checksum.</param>
        Public Sub New(ByVal stream As Stream)
            Me.m_stream = stream
        End Sub

        Private m_stream As Stream

        ''' <summary>
        ''' Obtem o stream.
        ''' </summary>
        Public ReadOnly Property Stream() As Stream
            Get
                Return m_stream
            End Get
        End Property

        Public Overrides ReadOnly Property CanRead() As Boolean
            Get
                Return m_stream.CanRead
            End Get
        End Property

        Public Overrides ReadOnly Property CanSeek() As Boolean
            Get
                Return m_stream.CanSeek
            End Get
        End Property

        Public Overrides ReadOnly Property CanWrite() As Boolean
            Get
                Return m_stream.CanWrite
            End Get
        End Property

        Public Overrides Sub Flush()
            m_stream.Flush()
        End Sub

        Public Overrides ReadOnly Property Length() As Long
            Get
                Return m_stream.Length
            End Get
        End Property

        Public Overrides Property Position() As Long
            Get
                Return m_stream.Position
            End Get
            Set(ByVal value As Long)
                m_stream.Position = value
            End Set
        End Property

        Public Overrides Function Seek(ByVal offset As Long, ByVal origin As SeekOrigin) As Long
            Return m_stream.Seek(offset, origin)
        End Function

        Public Overrides Sub SetLength(ByVal value As Long)
            m_stream.SetLength(value)
        End Sub

        Public Overrides Function Read(ByVal buffer As Byte(), ByVal offset As Integer, ByVal count As Integer) As Integer
            count = m_stream.Read(buffer, offset, count)
            m_readCrc = CalculateCrc(m_readCrc, buffer, offset, count)
            Return count
        End Function

        Public Overrides Sub Write(ByVal buffer As Byte(), ByVal offset As Integer, ByVal count As Integer)
            m_stream.Write(buffer, offset, count)

            m_writeCrc = CalculateCrc(m_writeCrc, buffer, offset, count)
        End Sub

        Private Function CalculateCrc(ByVal crc As ULong, ByVal buffer As Byte(), ByVal offset As Integer, ByVal count As Integer) As ULong
            Dim i As Integer = offset, [end] As Integer = offset + count
            While i < [end]
                crc = (crc >> 8) Xor table(CInt((crc Xor CULng(buffer(i))) And CULng(&HFF)))
                i += 1
            End While

            Return crc
        End Function

        Private Shared table As ULong() = GenerateTable()

        Private Shared Function GenerateTable() As ULong()
            Dim table As ULong() = New ULong(255) {}

            Dim crc As ULong
            Const poly As ULong = &HEDB88320UI
            For i As ULong = 0 To CULng(table.Length - 1)
                crc = i
                For j As Integer = 8 To 1 Step -1
                    If (CLng(crc) And 1) = 1 Then
                        crc = (crc >> 1) Xor poly
                    Else
                        crc >>= 1
                    End If
                Next
                table(CInt(i)) = crc
            Next
            Return table

        End Function

        Private m_readCrc As ULong = &HFFFFFFFFUI

        ''' <summary>
        ''' Obtem o checksum CRC dos dados que foram lidos pelo stream
        ''' </summary>
        Public ReadOnly Property ReadCrc() As ULong
            Get
                Return m_readCrc Xor &HFFFFFFFFUI
            End Get
        End Property

        Private m_writeCrc As ULong = &HFFFFFFFFUI

        ''' <summary>
        ''' Obtem o checksum CRC dos dados que foram escritos para o stream
        ''' </summary>
        Public ReadOnly Property WriteCrc() As ULong
            Get
                Return m_writeCrc Xor &HFFFFFFFFUI
            End Get
        End Property

        ''' <summary>
        ''' Reseta a leitura e escrita dos checksums.
        ''' </summary>
        Public Sub ResetChecksum()
            m_readCrc = &HFFFFFFFFUI
            m_writeCrc = &HFFFFFFFFUI
        End Sub
    End Class
End Module