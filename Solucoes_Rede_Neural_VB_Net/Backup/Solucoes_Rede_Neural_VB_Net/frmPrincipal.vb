Public Class frmPrincipal

    ' Variável de Instância
    Private objEnderecoAplicativo As New clsEnderecoAplicativo()
    Public varEnderecoAplicativo As String = String.Empty

    ' Variável de Instância
    Private varbarProgressivo As Boolean = True
    Private contTempo As Integer = 0
    Public Const cntNomeFormulario As String = "Eletronorte - Soluções Integradas"

    ' Métodos

    Private Sub smnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnAbrir.Click
        If dlgabrirEletronorteGSDE.ShowDialog() = DialogResult.OK Then
            'Dim oformulario As New frmMDI()
            'oformulario.MdiParent = Me
            MessageBox.Show(dlgabrirEletronorteGSDE.FileName)
            'oformulario.Show()
        End If
    End Sub

    Private Sub tmrEletronorteGSDE_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr1.Tick
        ' Estrutura de controle do label que mostra as horas na barra de status
        barlblMostrHorario.Text = DateTime.Now.ToShortTimeString
        ' Estrutura para controle da barra de progresso da barra de status
        If varbarProgressivo = True Then
            barprgEletronorteGSDE.Value += barprgEletronorteGSDE.Step
            If Not barprgEletronorteGSDE.Value < 100 Then
                contTempo = 100
                varbarProgressivo = False
            End If
        Else
            barprgEletronorteGSDE.Value -= barprgEletronorteGSDE.Step
            If Not barprgEletronorteGSDE.Value > 0 Then
                contTempo = 0
                varbarProgressivo = True
            End If
        End If
    End Sub

    Private Sub smnHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub smnVertical_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub smnCascata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnCascata.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub frmEletronorteGSD_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        mtdFechar()
    End Sub

    Private Sub frmEletronorteGSD_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Pergunta se o usuário quer, realmente, fechar o formulário
        Dim resposta As DialogResult
        resposta = MessageBox.Show("Deseja realmente fechar o aplicativo?", "Aviso!", MessageBoxButtons.YesNo)
        'Se o usuário respondeu "Não", cancela o fechamento do formulário
        If (resposta = Windows.Forms.DialogResult.No) Then
            e.Cancel = True
        ElseIf (resposta = Windows.Forms.DialogResult.Yes) Then
            e.Cancel = False
        End If
    End Sub

    Private Sub frmEletronorteGSD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Comando que importa o DoEvents do VB6 para o VB.net.
        ' Application.DoEvents()
        varEnderecoAplicativo = objEnderecoAplicativo.Endereco()
        barlblMostrContUser.Text = System.Environment.UserName
        tmr1.Interval = 1000
        tmr1.Enabled = True
        barprgEletronorteGSDE.Step = 1
        barprgEletronorteGSDE.Style = ProgressBarStyle.Blocks
        barprgEletronorteGSDE.Value = 0
        contTempo = 0
    End Sub

    Private Sub mnuRedeNeural_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRedeNeural.Click
        Dim objRedeNeural As New frmRedeNeural()
        objRedeNeural.MdiParent = Me
        objRedeNeural.Show()
    End Sub

    Private Sub mtdFechar()
        Dim objRedeNeural As New frmRedeNeural()
        Try
            frmRedeNeural.Th1.Abort()
            Try
                frmRedeNeural.Th2.Abort()
            Catch ex As Exception
            End Try
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Private Sub smnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnSair.Click
        Me.Close()
    End Sub
End Class