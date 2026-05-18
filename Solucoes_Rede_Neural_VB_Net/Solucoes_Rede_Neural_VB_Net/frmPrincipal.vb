Namespace Solucoes_Rede_Neural_VB_Net
    Public Class frmPrincipal

        ' Variável de Instância
        Private objEnderecoAplicativo As clsEnderecoAplicativo = New clsEnderecoAplicativo()
        Public varEnderecoAplicativo As String = String.Empty

        ' Variável de Instância
        Private varbarProgressivo As Boolean = True
        Private contTempo As Integer = 0

        ' Métodos

        Private Sub smnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnAbrir.Click
            If dlgabrir1.ShowDialog() = DialogResult.OK Then
                'Dim oformulario As New frmMDI()
                'oformulario.MdiParent = Me
                MessageBox.Show(dlgabrir1.FileName)
                'oformulario.Show()
            End If
        End Sub

        Private Sub tmr1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmr1.Tick
            ' Estrutura de controle do label que mostra as horas na barra de status
            barlblMostrHorario.Text = DateTime.Now.ToShortTimeString
            ' Estrutura para controle da barra de progresso da barra de status
            If varbarProgressivo = True Then
                barprg1.Value += barprg1.Step
                If Not barprg1.Value < 100 Then
                    contTempo = 100
                    varbarProgressivo = False
                End If
            Else
                barprg1.Value -= barprg1.Step
                If Not barprg1.Value > 0 Then
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

        Private Sub frmPrincipal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
            mtdFechar()
        End Sub

        Private Sub frmPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

        Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Comando que importa o DoEvents do VB6 para o VB.net.
            ' Application.DoEvents()
            varEnderecoAplicativo = objEnderecoAplicativo.Endereco()
            barlblMostrContUser.Text = System.Environment.UserName
            tmr1.Interval = 1000
            tmr1.Enabled = True
            barprg1.Step = 1
            barprg1.Style = ProgressBarStyle.Blocks
            barprg1.Value = 0
            contTempo = 0
        End Sub

        Private Sub mnuRedeNeural_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRedeNeural.Click
            Dim objRedeNeural As frmRedeNeural = New frmRedeNeural()
            objRedeNeural.MdiParent = Me
            objRedeNeural.Show()
        End Sub

        Private Sub mtdFechar()
            Try
                ' frmPrincipal.Th1.Abort()
                Try
                    ' frmPrincipal.Th2.Abort()
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
End Namespace