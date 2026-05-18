Imports System.Net.Mail

Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmE_Mail
        Inherits System.Windows.Forms.Form
        Private sMail As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()
        Private Attachment As System.Net.Mail.Attachment   'Variable to store the attachments

        Private Shared strServidorSMTP As String = String.Empty
        Private Shared strMostrar As String = String.Empty
        Private Shared strDe As String = String.Empty
        Private Shared lstListaPara As List(Of String) = New List(Of String)
        Private Shared lstListaCC As List(Of String) = New List(Of String)
        Private Shared lstListaBCC As List(Of String) = New List(Of String)
        Private Shared strAssunto As String = String.Empty
        Private Shared strMensagem As String = String.Empty
        Private Shared blnFormatoHTML As Boolean = False
        Private Shared lstListaAnexo As List(Of String) = New List(Of String)

        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Public Sub mtdDefinirListaCampos(ByVal ServidorSMTP As String, ByVal Mostrar As String, ByVal De As String, ByVal ListaPara As List(Of String), ByVal ListaCC As List(Of String), ByVal ListaBCC As List(Of String), ByVal Assunto As String, ByVal Mensagem As String, ByVal FormatoHTML As Boolean, ByVal ListaAnexo As List(Of String))
            strServidorSMTP = ServidorSMTP
            strMostrar = Mostrar
            strDe = De
            lstListaPara = ListaPara
            lstListaCC = ListaCC
            lstListaBCC = ListaBCC
            strAssunto = Assunto
            strMensagem = Mensagem
            blnFormatoHTML = FormatoHTML
            lstListaAnexo = ListaAnexo
        End Sub

        Private Sub BtnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEnviar.Click
            Dim Mailmsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
            sMail.Host = txtServidorSMTP.Text
            If Not txtDe.Text.Equals(String.Empty) Then
                If Not lstPara.Items.Count = 0 Then
                    If Not lstPara.Items.Count = 1 Then
                        For contador As Integer = 1 To lstPara.Items.Count - 1 Step 1
                            Mailmsg.To.Add(lstPara.Items(contador).ToString())
                        Next
                    End If
                    Mailmsg = New System.Net.Mail.MailMessage(txtMostrar.Text & "<" & txtDe.Text & ">", lstPara.Items(0).ToString())
                    If Not lstCC.Items.Count = 0 Then
                        For contador As Integer = 0 To lstCC.Items.Count - 1 Step 1
                            Mailmsg.CC.Add(lstCC.Items(contador).ToString())
                        Next
                    End If
                    If Not lstBCC.Items.Count = 0 Then
                        For contador As Integer = 0 To lstBCC.Items.Count - 1 Step 1
                            Mailmsg.Bcc.Add(lstBCC.Items(contador).ToString())
                        Next
                    End If
                    If Not txtAssunto.Text.Equals(String.Empty) Then
                        Mailmsg.Subject = txtAssunto.Text
                        If Not rtbMensagem.Text.Equals(String.Empty) Then
                            Mailmsg.Body = rtbMensagem.Text
                            Mailmsg.IsBodyHtml = chkFormatoHTML.Checked
                            For contador As Integer = 0 To lstAnexo.Items.Count - 1
                                Attachment = New System.Net.Mail.Attachment(lstAnexo.Items(contador).ToString())
                                Mailmsg.Attachments.Add(Attachment)
                            Next
                            Try
                                sMail.Send(Mailmsg)
                                MessageBox.Show("O e-mail foi enviado com sucesso.", "Aviso!", MessageBoxButtons.OK)
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK)
                            End Try
                        Else
                            MessageBox.Show("Digite uma mensagem.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        MessageBox.Show("Digite um assunto.", "Aviso!", MessageBoxButtons.OK)
                    End If
                Else
                    MessageBox.Show("Adicione um endereço de à lista e-mail para que seja enviado.", "Aviso!", MessageBoxButtons.OK)
                End If
            Else
                MessageBox.Show("Digite um endereço de e-mail remetente.", "Aviso!", MessageBoxButtons.OK)
            End If
        End Sub

        Private Sub BtnAdicionarTo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdicionarPara.Click
            If (Not cmbPara.Text.Equals(String.Empty)) Then
                If Not (cmbPara.Text.Contains("@"c) And cmbPara.Text.Contains("."c)) Then
                    Dim SQL As String = "SELECT tblEmpregados.Nome, tblEmpregados.Email FROM tblEmpregados WHERE tblEmpregados.Nome LIKE '%" & cmbPara.Text & "%';"
                    Dim objBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, SQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                    Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
                    objBancoDados.mtdAbrirConexao()
                    objBancoDados.mtdExecutarComando()
                    objBancoDados.mtdDefinirLeitorDados()
                    objBancoDados.mtdProximoRegistro()
                    cmbPara.Text = objBancoDados.mtdObterValorRegistro(1).ToString()
                    objBancoDados.Dispose()
                End If
                If Not lstPara.Items.Contains(cmbPara.Text) Then
                    If cmbPara.Text.Contains("@"c) And cmbPara.Text.Contains("."c) Then
                        lstPara.Items.Add(cmbPara.Text)
                        cmbPara.Text = String.Empty
                    Else
                        MessageBox.Show("Verifique se o email informado está no formato correto.", "Aviso!", MessageBoxButtons.OK)
                    End If
                Else
                    MessageBox.Show("O email digitado já existe na lista, por favor digite outro.", "Aviso", MessageBoxButtons.OK)
                End If
            Else
                MessageBox.Show("Verifique se o campo está em branco.", "Aviso", MessageBoxButtons.OK)
            End If
        End Sub

        Private Sub BtnRemoverTo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemoverPara.Click
            lstPara.Items.Remove(lstPara.SelectedItem)
        End Sub

        Private Sub BtnAdicionarCC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdicionarCC.Click
            If (Not cmbCC.Text.Equals(String.Empty)) Then
                If Not (cmbCC.Text.Contains("@") And cmbCC.Text.Contains(".")) Then
                    Dim SQL As String = "SELECT tblEmpregados.Nome, tblEmpregados.Email FROM tblEmpregados WHERE tblEmpregados.Nome LIKE '%" & cmbCC.Text & "%';"
                    Dim objBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, SQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                    Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
                    objBancoDados.mtdAbrirConexao()
                    objBancoDados.mtdExecutarComando()
                    objBancoDados.mtdDefinirLeitorDados()
                    objBancoDados.mtdProximoRegistro()
                    cmbCC.Text = objBancoDados.mtdObterValorRegistro(1).ToString()
                    objBancoDados.Dispose()
                End If
                If Not (cmbCC.Items.Contains(cmbPara.Text)) Then
                    If cmbCC.Text.Contains("@") And cmbCC.Text.Contains(".") Then
                        lstCC.Items.Add(cmbCC.Text)
                        cmbCC.Text = String.Empty
                    Else
                        MessageBox.Show("Verifique se o email informado está no formato correto.", "Aviso!", MessageBoxButtons.OK)
                    End If
                Else
                    MessageBox.Show("O email digitado já existe na lista, por favor digite outro.", "Aviso", MessageBoxButtons.OK)
                End If
            Else
                MessageBox.Show("Verifique se o campo está em branco.", "Aviso", MessageBoxButtons.OK)
            End If

        End Sub

        Private Sub BtnRemoverCC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemoverCC.Click 'Handles btnRemoverCC.Click
            lstCC.Items.Remove(lstCC.SelectedItem)
        End Sub

        Sub BtnAdicionarAnexo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdicionarAnexo.Click
            OFD.CheckFileExists = True
            OFD.Title = "Selecione o arquivo ou os arquivos que desenja anexar à mensagem."
            OFD.ShowDialog()
            For Contador As Integer = OFD.FileNames.GetLowerBound(0) To OFD.FileNames.GetUpperBound(0)
                lstAnexo.Items.Add(OFD.FileNames(Contador))
            Next
        End Sub

        Sub BtnRemoverAnexo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemoverAnexo.Click
            If lstAnexo.SelectedIndex > -1 Then
                lstAnexo.Items.RemoveAt(lstAnexo.SelectedIndex)
            End If
        End Sub

        Sub BtnAdicionarCCO_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdicionarCCO.Click
            lstBCC.Items.Add(cmbCCO.Text)
        End Sub

        Sub BtnRemoverCCO_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemoverCCO.Click
            lstBCC.Items.Remove(lstBCC.SelectedItem)
        End Sub

        Private Sub cmbPara_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPara.DropDown
            mtdCarregarCmbItem(cmbPara, 1, "SELECT DISTINCT tblEmpregados.Nome FROM tblEmpregados GROUP BY tblEmpregados.Nome HAVING Nome LIKE '%" & cmbPara.Text & "%' ORDER BY Nome;")
        End Sub

        Private Sub cmbCC_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCC.DropDown
            mtdCarregarCmbItem(cmbCC, 1, "SELECT DISTINCT tblEmpregados.Nome FROM tblEmpregados GROUP BY tblEmpregados.Nome HAVING Nome LIKE '%" & cmbPara.Text & "%' ORDER BY Nome;")
        End Sub

        Private Sub cmbCCO_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCCO.DropDown
            mtdCarregarCmbItem(cmbCCO, 1, "SELECT DISTINCT tblEmpregados.Nome FROM tblEmpregados GROUP BY tblEmpregados.Nome HAVING Nome LIKE '%" & cmbPara.Text & "%' ORDER BY Nome;")
        End Sub

        Private Sub mtdCarregarCmbItem(ByVal cmb As ComboBox, ByVal numCmb As Integer, ByVal SQL As String)
            Dim objBDPrincipal As New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, SQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            Try
                objBDPrincipal.mtdAbrirConexao()
                objBDPrincipal.mtdExecutarComando()
                For contador As Integer = 0 To cmb.Items.Count - 1 Step 1
                    cmb.Items.RemoveAt(0)
                Next
                Dim numMaxRegistroDR As Integer = objBDPrincipal.mtdNumeroLinhas() - 1
                objBDPrincipal.mtdDefinirLeitorDados()
                For contador As Integer = 0 To numMaxRegistroDR Step 1
                    objBDPrincipal.mtdProximoRegistro()
                    If Not (objBDPrincipal.mtdObterValorRegistro(numCmb - 1).ToString() = String.Empty) Then
                        cmb.Items.Add(objBDPrincipal.mtdObterValorRegistro(numCmb - 1))
                    End If
                Next
                cmb.Text = cmb.Items(0).ToString()
            Catch ex As System.Exception
            End Try
            objBDPrincipal.Dispose()
        End Sub

        Private strNomeTabela As String = frmCADU.strNomeTabelaPrincipal
        Private strMatriculaConta As String = frmPrincipal.barlblMostrContUser.Text

        Private Sub frmE_Mail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtServidorSMTP.Text = strServidorSMTP
            txtMostrar.Text = strMostrar
            txtDe.Text = strDe

            lstPara.Items.Clear()
            For Each Item As String In lstListaPara
                lstPara.Items.Add(Item)
            Next

            lstCC.Items.Clear()
            For Each Item As String In lstListaCC
                lstCC.Items.Add(Item)
            Next

            lstBCC.Items.Clear()
            For Each Item As String In lstListaBCC
                lstBCC.Items.Add(Item)
            Next

            txtAssunto.Text = strAssunto
            rtbMensagem.Text = strMensagem

            chkFormatoHTML.Checked = blnFormatoHTML

            lstAnexo.Items.Clear()
            For Each Item As String In lstListaAnexo
                lstAnexo.Items.Add(Item)
            Next
        End Sub
    End Class
End Namespace