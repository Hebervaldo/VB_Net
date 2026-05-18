Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmInformacoes
        Private Sub frmInformacoes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Preenchimento do texto.
            txt1.Text = "A lista abaixo informa os números que deverão ser colocados caso o bem não possua plaqueta ou não tenha sido tombado."
            'Preenchimento da lista.
            Try
                lsv1.Clear()
                'define o modo de exibição do listview 
                lsv1.View = System.Windows.Forms.View.Details
                ' permite o usuario editar o item
                lsv1.LabelEdit = False
                ' permite o usuario rearranjar as colunas
                lsv1.AllowColumnReorder = True
                ' exibe as caixas de marcacao (check boxes.)
                lsv1.CheckBoxes = False
                ' seleciona um item e subitem quando a seleção é feita
                lsv1.FullRowSelect = True
                ' exibe as linhas
                lsv1.GridLines = True
                ' ordena os itens na list na ordem ascendente
                ' cria tres itens e tres conjuntos de subitems para cada item
                lsv1.Columns.Add("Patrimônio", 100, HorizontalAlignment.Left)
                lsv1.Columns.Add("Finalidade", 200, HorizontalAlignment.Left)
                Dim item1 As ListViewItem = New ListViewItem("0", 0)
                Dim item2 As ListViewItem = New ListViewItem("1", 1)
                Dim item3 As ListViewItem = New ListViewItem("2", 2)
                Dim item4 As ListViewItem = New ListViewItem("3", 3)
                item1.SubItems.Add("PARTICULAR")
                item2.SubItems.Add("NÃO TOMBADO")
                item3.SubItems.Add("SEM PLAQUETA")
                item4.SubItems.Add("NÃO CADASTRADO")
                lsv1.Items.AddRange(New ListViewItem() {item1, item2, item3, item4})
                ' marca o ckeckbox para o item
                'item.Checked = True
                lsv1.Items.Add(item1)
                lsv1.Items.Add(item2)
                lsv1.Items.Add(item3)
                lsv1.Items.Add(item4)
                Me.Controls.Add(lsv1)
            Catch
            End Try
        End Sub
    End Class
End Namespace