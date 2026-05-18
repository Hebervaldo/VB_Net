Namespace Solucoes_Rede_Neural_VB_Net
    Public Class frmSubVisualizador

        Private dfrmbtntxt1H As Integer
        Private dfrmbtntxt1V As Integer
        Private dfrmbtnSairH As Integer
        Private dfrmbtnSairV As Integer
        Private dfrmbtnRemoverH As Integer
        Private dfrmbtnRemoverV As Integer
        Private dfrmbtnCriarH As Integer
        Private dfrmbtnCriarV As Integer
        Private dfrmlstv1V As Integer
        Private dfrmlstv1H As Integer
        Private varHouveRedimensionamento As Boolean = False
        Private objArquivoTXT As New clsArquivoTXT
        Private i As Integer

        Private Sub SubEntradasTreinamento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'define o modo de exibição do listview 
            lstv1.View = View.Details
            ' permite o usuario editar o item
            lstv1.LabelEdit = False
            ' permite o usuario rearranjar as colunas
            lstv1.AllowColumnReorder = True
            ' exibe as caixas de marcacao (check boxes.)
            lstv1.CheckBoxes = True
            ' seleciona um item e subitem quando a seleção é feita
            lstv1.FullRowSelect = True
            ' exibe as linhas
            lstv1.GridLines = True
            ' ordena os itens na list na ordem ascendente
            lstv1.Sorting = SortOrder.Ascending
            lstv1.Columns.Add("Acrescentar Campo", 200, HorizontalAlignment.Left)
            For i = 0 To frmRedeNeural.dtgv.Columns.Count - 1 Step 1
                lstv1.Items.Add(frmRedeNeural.dtgv.Columns.Item(i).HeaderText)
            Next
            Me.Controls.Add(lstv1)
            txt1.Text = String.Concat(mtdRotinaNomeCampo(), (i + 1).ToString("000"))
        End Sub

        Private Sub btnRemover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemover.Click
            Dim iMax As Integer = lstv1.CheckedItems.Count

            For i As Integer = 1 To iMax
                If lstv1.CheckedItems.Item(0).Checked Then
                    lstv1.Items(lstv1.CheckedItems.Item(0).Index).Remove()
                End If
            Next
            frmRedeNeural.RePreencherDataGridView(frmRedeNeural.dtgv, lstv1)
        End Sub

        Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
            Me.Close()
        End Sub

        Private Sub btnCriar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCriar.Click
            lstv1.Items.Add(txt1.Text)
            frmRedeNeural.RePreencherDataGridView(frmRedeNeural.dtgv, lstv1)
            txt1.Text = String.Concat(mtdRotinaNomeCampo(), (i + 1).ToString("000"))
        End Sub
        Private Function mtdRotinaNomeCampo() As String
            Dim chrChr As Char, strStr As String = String.Empty, strStrAux As String = String.Empty, strNumeros As String = "0123456789"
            i = frmRedeNeural.dtgv.ColumnCount
            strStrAux = lstv1.Items(i - 1).Text
            For j As Integer = 0 To strStrAux.Length - 1
                chrChr = Convert.ToChar(strStrAux.Substring(j, 1))
                If Not strNumeros.Contains(Convert.ToString(chrChr)) Then
                    strStr &= chrChr
                End If
            Next
            Return strStr
        End Function

        Private Sub mtdRedimensionar()
            If varHouveRedimensionamento = False Then
                dfrmbtntxt1H = Me.Size.Width - txt1.Left
                ' dfrmbtntxt1V = Me.Size.Height - txt1.Top
                dfrmbtnSairH = Me.Size.Width - btnSair.Left
                ' dfrmbtnSairV = Me.Size.Height - btnSair.Top
                dfrmbtnRemoverH = Me.Size.Width - btnRemover.Left
                ' dfrmbtnRemoverV = Me.Size.Height - btnRemover.Top
                dfrmbtnCriarH = Me.Size.Width - btnCriar.Left
                ' dfrmbtnCriarV = Me.Size.Height - btnCriar.Top
                dfrmlstv1V = Me.Size.Height - lstv1.Height
                dfrmlstv1H = Me.Size.Width - lstv1.Width
                varHouveRedimensionamento = True
            End If
            ' txt1.Top = Me.Size.Height - dfrmbtntxt1V
            txt1.Left = Me.Size.Width - dfrmbtntxt1H
            ' btnSair.Top = Me.Size.Height - dfrmbtnSairV
            btnSair.Left = Me.Size.Width - dfrmbtnSairH
            ' btnRemover.Top = Me.Size.Height - dfrmbtnRemoverV
            btnRemover.Left = Me.Size.Width - dfrmbtnRemoverH
            ' btnCriar.Top = Me.Size.Height - dfrmbtnCriarV
            btnCriar.Left = Me.Size.Width - dfrmbtnCriarH
            lstv1.Height = Me.Height - dfrmlstv1V
            lstv1.Width = Me.Width - dfrmlstv1H
        End Sub

        Private Sub frmSubVisualizador_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
            mtdRedimensionar()
        End Sub
    End Class
End Namespace