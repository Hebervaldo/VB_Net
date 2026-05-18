Namespace Solucoes_Rede_Neural_VBCoreNet
    Public Class frmVisualizador

        Public Shared tipoformulario As String = String.Empty

        Private vetCelulaSelecionada(1) As Integer
        Private dfrmbtnAjustarH As Integer
        Private dfrmbtnAjustarV As Integer
        Private dfrmbtnCadastrarH As Integer
        Private dfrmbtnCadastrarV As Integer
        Private dfrmbtnLerH As Integer
        Private dfrmbtnLerV As Integer
        Private dfrmbtnSairH As Integer
        Private dfrmbtnSairV As Integer
        Private dfrmdtgv1H As Integer
        Private dfrmdtgv1V As Integer
        Private objArquivoTXT As New clsArquivoTXT()
        Private objManipuladorTexto As New clsManipuladorTexto()
        Private objSF As New frmSubVisualizador()
        Private strEnderecoArquivo As String
        Private varHouveRedimensionamento As Boolean = False
        Private Sub EntradasTreinamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            mtdLer(dtgv1)
            mtdAtributos()
            Select Case tipoformulario
                Case "Entradas"
                    btnAjustar.Enabled = True
                Case "Target"
                    btnAjustar.Enabled = True
                Case Else
                    btnAjustar.Enabled = False
            End Select
        End Sub
        Private Sub btnAjustar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAjustar.Click
            Dim objSF As New frmSubVisualizador
            objSF.Show()
        End Sub
        Private Sub btnLer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLer.Click
            mtdLer(dtgv1)
        End Sub
        Private Sub btnCadastrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCadastrar.Click
            mtdCadastrar(dtgv1)
            mtdAtributos()
        End Sub
        Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
            Me.Close()
        End Sub
        Public Sub EnderecoArquivo(ByVal EnderecoArquivo As String)
            strEnderecoArquivo = EnderecoArquivo
        End Sub
        Public Sub mtdLer(ByVal dtgv As DataGridView)
            Dim nomecoluna As String = String.Empty
            frmRedeNeural.RotinaLeitura(strEnderecoArquivo)
            Select Case tipoformulario
                Case "Entradas"
                    nomecoluna = "Entrada"
                Case "Target"
                    nomecoluna = "Alvo"
                Case Else
                    nomecoluna = "Campo"
            End Select
            frmRedeNeural.PreencherDataGridView(dtgv, nomecoluna)
        End Sub
        Public Sub mtdCadastrar(ByVal dtgv As DataGridView)
            frmRedeNeural.RotinaCadastro(strEnderecoArquivo, dtgv)
            Select Case tipoformulario
                Case "Entradas"
                    frmRedeNeural.NumeroEntrada = dtgv.ColumnCount
                    frmRedeNeural.NumeroPadroes = dtgv.RowCount - 1
                Case "Target"
                    frmRedeNeural.NumeroSaida = dtgv.ColumnCount
                    frmRedeNeural.NumeroPadroesConferencia = dtgv.RowCount - 1
            End Select
        End Sub
        Private Sub dtgv1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv1.CellClick
            mtdAtributos()
            vetCelulaSelecionada(0) = dtgv1.SelectedCells().Item(0).ColumnIndex
            vetCelulaSelecionada(1) = dtgv1.SelectedCells().Item(0).RowIndex
        End Sub
        Private Sub frmVisualizador_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
            mtdRedimensionar()
        End Sub
        Private Sub mtdRedimensionar()
            If Not varHouveRedimensionamento Then
                dfrmbtnAjustarH = Me.Size.Width - btnAjustar.Left
                dfrmbtnAjustarV = Me.Size.Height - btnAjustar.Top
                dfrmbtnCadastrarH = Me.Size.Width - btnCadastrar.Left
                dfrmbtnCadastrarV = Me.Size.Height - btnCadastrar.Top
                dfrmbtnLerH = Me.Size.Width - btnLer.Left
                dfrmbtnLerV = Me.Size.Height - btnLer.Top
                dfrmbtnSairH = Me.Size.Width - btnSair.Left
                dfrmbtnSairV = Me.Size.Height - btnSair.Top
                dfrmdtgv1H = Me.Size.Width - dtgv1.Width
                dfrmdtgv1V = Me.Size.Height - dtgv1.Height
                varHouveRedimensionamento = True
            End If
            btnSair.Top = Me.Size.Height - dfrmbtnSairV
            btnSair.Left = Me.Size.Width - dfrmbtnSairH
            btnCadastrar.Top = Me.Size.Height - dfrmbtnCadastrarV
            btnCadastrar.Left = Me.Size.Width - dfrmbtnCadastrarH
            btnLer.Top = Me.Size.Height - dfrmbtnLerV
            btnLer.Left = Me.Size.Width - dfrmbtnLerH
            btnAjustar.Top = Me.Size.Height - dfrmbtnAjustarV
            btnAjustar.Left = Me.Size.Width - dfrmbtnAjustarH
            dtgv1.Height = Me.Height - dfrmdtgv1V
            dtgv1.Width = Me.Width - dfrmdtgv1H
        End Sub
        Private Sub mtdAtributos()
            tslbl2.Text = Convert.ToString(dtgv1.RowCount - 1)
            tslbl4.Text = Convert.ToString(dtgv1.ColumnCount)
            tslbl6.Text = Convert.ToString(dtgv1.SelectedCells().Item(0).RowIndex + 1)
            tslbl8.Text = Convert.ToString(dtgv1.SelectedCells().Item(0).ColumnIndex + 1)
        End Sub
    End Class
End Namespace