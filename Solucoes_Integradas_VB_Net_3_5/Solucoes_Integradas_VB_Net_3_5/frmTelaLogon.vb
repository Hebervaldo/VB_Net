Imports System.Security.Cryptography

Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmLogon
        ' TODO: Insert code to perform custom authentication using the provided username and password 
        ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
        ' The custom principal can then be attached to the current thread's principal as follows: 
        '     My.User.CurrentPrincipal = CustomPrincipal
        ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
        ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
        ' such as the username, display name, etc.

        Public Shared strEnderecoEmail As String = String.Empty

        'Private objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
        Private objCriptografia As clsCriptografia = New clsCriptografia()
        Private objRegistroWindows As clsRegistroWindows = New clsRegistroWindows()

        Structure sttEstruturaConta
            Public Usuario As String
            Public Status As String
            Public Senha_Criptografada As String
            Public Chave As String

            Public Sub New(ByVal Usuario As String, ByVal Status As String, ByVal Senha_Criptografada As String, ByVal Chave As String)
                Me.Usuario = Usuario
                Me.Status = Status
                Me.Senha_Criptografada = Senha_Criptografada
                Me.Chave = Chave
            End Sub
        End Structure

        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            If Not txtNomeUsuario.Text.Equals(String.Empty) Then
                If Not txtSenhaUsuario.Text.Equals(String.Empty) Then
                    Dim senha As String = txtSenhaUsuario.Text
                    Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                    objBDPrincipal.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosPrincipal)
                    objBDPrincipal.prpComando = "SELECT tblUsuarios.* FROM tblUsuarios WHERE tblUsuarios.Usuario LIKE '" & Me.txtNomeUsuario.Text & "'"
                    objBDPrincipal.mtdExecutarComando()
                    objBDPrincipal.mtdDefinirLeitorDados()
                    If objBDPrincipal.mtdProximoRegistro() Then
                        Dim objEstruturaConta As New sttEstruturaConta(objBDPrincipal.mtdObterValorRegistro(1).ToString(), _
                                                                       objBDPrincipal.mtdObterValorRegistro(2).ToString(), _
                                                                       objBDPrincipal.mtdObterValorRegistro(3).ToString(), _
                                                                       objBDPrincipal.mtdObterValorRegistro(4).ToString())
                        'If (objBDPrincipal.getExcecao.Equals("mtdNumeroColunas: Nao houve excecao.")) Then
                        If txtNomeUsuario.Text = objEstruturaConta.Usuario And senha = objCriptografia.mtdDesCriptografar( _
                            objEstruturaConta.Senha_Criptografada, objEstruturaConta.Chave, Encryption.Symmetric.Provider.Rijndael) Then
                            Dim vetColuntblEmpregados As String()
                            objBDPrincipal.prpComando = "SELECT tblEmpregados.* FROM tblEmpregados WHERE tblEmpregados.Matricula LIKE '" & _
                                    Me.txtNomeUsuario.Text & "' ORDER BY tblEmpregados.Nome"
                            objBDPrincipal.mtdExecutarComando()
                            objBDPrincipal.mtdDefinirLeitorDados()
                            'If Not objBDPrincipal.mtdDefinirLeitorDados() Then
                            '    Dim objCADU As frmCADU = New frmCADU()
                            '    objCADU.mtdIniciarThreadProgresso(False)
                            '    objCADU.mtdIniciarThreadImportarTabelaEmpregadosPrincipal()
                            '    System.Threading.Thread.Sleep(10000)
                            '    objBDPrincipal.prpComando = "SELECT tblEmpregados.* FROM tblEmpregados WHERE tblEmpregados.Matricula LIKE '" & _
                            '        Me.txtNomeUsuario.Text & "' ORDER BY tblEmpregados.Nome"
                            '    objBDPrincipal.mtdExecutarComando()
                            '    objBDPrincipal.mtdDefinirLeitorDados()
                            'End If
                            If objBDPrincipal.mtdProximoRegistro() Then
                                vetColuntblEmpregados = New String(objBDPrincipal.mtdNumeroColunas()) {}
                                Dim intNumeroColuna As Integer = objBDPrincipal.mtdNumeroColunas()
                                vetColuntblEmpregados = New String(intNumeroColuna - 1) {}
                                Try
                                    For i As Integer = 0 To intNumeroColuna - 1
                                        vetColuntblEmpregados(i) = objBDPrincipal.mtdObterValorRegistro(i).ToString()
                                    Next

                                    strEnderecoEmail = vetColuntblEmpregados(6)
                                    With frmPrincipal
                                        .barlblMostrNomeUser.Text = vetColuntblEmpregados(0)
                                        .barlblMostrContUser.Text = vetColuntblEmpregados(1)
                                        .barlblMostrStatusUser.Text = objEstruturaConta.Status
                                    End With
                                Catch
                                    strEnderecoEmail = String.Empty
                                    With frmPrincipal
                                        .barlblMostrNomeUser.Text = objEstruturaConta.Usuario
                                        .barlblMostrContUser.Text = objEstruturaConta.Usuario
                                        .barlblMostrStatusUser.Text = objEstruturaConta.Status
                                    End With
                                End Try
                            Else
                                Try
                                    strEnderecoEmail = String.Empty
                                    With frmPrincipal
                                        .barlblMostrNomeUser.Text = objEstruturaConta.Usuario
                                        .barlblMostrContUser.Text = objEstruturaConta.Usuario
                                        .barlblMostrStatusUser.Text = objEstruturaConta.Status
                                    End With
                                Catch ex As Exception

                                End Try
                            End If

                            frmPrincipal.Enabled = True
                            Select Case objEstruturaConta.Status
                                Case "Usuário"
                                    frmPrincipal.mnuConfiguracoes.Enabled = False
                                Case "Administrador"
                                    frmPrincipal.mnuConfiguracoes.Enabled = True
                                Case Else
                                    frmPrincipal.mnuConfiguracoes.Enabled = False
                            End Select
                            objBDPrincipal.Dispose()

                            'frmPrincipal.mtdCriarTabelas()

                            Me.Close()
                        Else
                            MessageBox.Show("Não foi possível logar no sistema, verifique o estado das teclas Caps Lock e Num Lock.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                        End If
                    Else
                        MessageBox.Show("Não foi possível logar no sistema, verifique o estado das teclas Caps Lock e Num Lock.", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    MessageBox.Show("Digite uma senha.", "Aviso!", MessageBoxButtons.OK)
                End If
            Else
                MessageBox.Show("Digite o nome de um usuário.", "Aviso!", MessageBoxButtons.OK)
            End If
        End Sub

        Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
            frmPrincipal.Close()
        End Sub

        Private Sub frmTelaLogon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtNomeUsuario.Select()
        End Sub
    End Class
End Namespace