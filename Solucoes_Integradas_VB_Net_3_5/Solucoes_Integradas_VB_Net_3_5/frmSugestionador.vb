Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmSugestionador
        Private dfrmlsv1H As Integer
        Private dfrmlsv1V As Integer
        Private varHouveRedimensionamento As Boolean = False
        Private strFormulario As String = String.Empty
        Private strTabela As String = String.Empty
        Private strTextoFormulario As String = String.Empty
        Private corFundoLsv1 As Color

        Public Property prpcorFundoLsv1() As Color
            Get
                Return corFundoLsv1
            End Get
            Set(ByVal value As Color)
                corFundoLsv1 = value
            End Set
        End Property

        Public Property prpTextoFormulario() As String
            Get
                Return strTextoFormulario
            End Get
            Set(ByVal value As String)
                strTextoFormulario = value
            End Set
        End Property

        Public Property prpFormulario() As String
            Get
                Return strFormulario
            End Get
            Set(ByVal value As String)
                strFormulario = value
            End Set
        End Property

        Public Property prpTabela() As String
            Get
                Return strTabela
            End Get
            Set(ByVal value As String)
                strTabela = value
            End Set
        End Property

        Private SQL As String = String.Empty

        Public Sub mtdCarregarLsv(ByVal SQL As String)
            Me.SQL = SQL
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            frmPrincipal.strConexaoBancoDadosPrincipal, _
            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

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
                objBDPrincipal.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosPrincipal)
                objBDPrincipal.mtdExecutarComando(SQL)
                objBDPrincipal.prpAjustadorDados = New DataSet()
                objBDPrincipal.mtdAdaptadorDados()
                Dim numMaxRegistro As Integer = objBDPrincipal.mtdNumeroLinhas() - 1
                objBDPrincipal.mtdDefinirLeitorDados()
                Dim numColuna As Integer = objBDPrincipal.mtdNumeroColunas() - 1
                Dim item(numMaxRegistro) As ListViewItem
                Dim vetColuna(numColuna) As String
                If strTabela = "Responsáveis" Or strTabela = "Responsável" Then
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(0), 300, HorizontalAlignment.Left)
                    For coluna As Integer = 1 To numColuna Step 1
                        lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(coluna), 100, HorizontalAlignment.Left)
                    Next
                ElseIf strTabela = "Bens" Then
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(0), 100, HorizontalAlignment.Left)
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(1), 100, HorizontalAlignment.Left)
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(2), 300, HorizontalAlignment.Left)
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(3), 300, HorizontalAlignment.Left)
                    For coluna As Integer = 4 To numColuna Step 1
                        lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(coluna), 100, HorizontalAlignment.Left)
                    Next
                ElseIf strTabela = "Inventario_Bens" Then
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(0), 100, HorizontalAlignment.Left)
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(1), 700, HorizontalAlignment.Left)
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(2), 200, HorizontalAlignment.Left)
                ElseIf strTabela = "Inventario_Usuario" Then
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(0), 100, HorizontalAlignment.Left)
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(1), 100, HorizontalAlignment.Left)
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(2), 100, HorizontalAlignment.Left)
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(3), 300, HorizontalAlignment.Left)
                    lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(4), 100, HorizontalAlignment.Left)
                End If
                For linha As Integer = 0 To numMaxRegistro Step 1
                    objBDPrincipal.mtdProximoRegistro()
                    If objBDPrincipal.mtdObterValorRegistro(0).ToString() <> String.Empty Then
                        vetColuna(0) = objBDPrincipal.mtdObterValorRegistro(0).ToString()
                    Else
                        vetColuna(0) = String.Empty
                    End If
                    item(linha) = New ListViewItem(vetColuna(0), linha)
                    For coluna As Integer = 1 To numColuna Step 1
                        If objBDPrincipal.mtdObterValorRegistro(coluna).ToString() <> String.Empty Then
                            vetColuna(coluna) = objBDPrincipal.mtdObterValorRegistro(coluna).ToString()
                        Else
                            vetColuna(coluna) = String.Empty
                        End If
                        item(linha).SubItems.Add(vetColuna(coluna))
                    Next
                    lsv1.Items.Add(item(linha))
                Next
                Me.Controls.Add(lsv1)
            Catch
            End Try

            objBDPrincipal.Dispose()
        End Sub

        Public Function mtdgetDadosSelecionados() As String()
                Dim vetDados(lsv1.Columns.Count - 1) As String
            Try
                For contador As Integer = 0 To lsv1.Columns.Count - 1 Step 1
                    vetDados(contador) = lsv1.Items(lsv1.SelectedItems(0).Index).SubItems(contador).Text
                Next

            Catch ex As System.Exception

            End Try
            Return vetDados
        End Function

        Private Sub lsv1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsv1.MouseDoubleClick
            Select Case strFormulario
                Case "frmCarteiras"
                    Select Case strTabela
                        Case "Responsáveis"
                            frmPrincipal.objCarteira.mtdAtualizarDtgv1(mtdgetDadosSelecionados)
                        Case "Bens"
                            frmPrincipal.objCarteira.mtdAtualizarDtgv2(mtdgetDadosSelecionados)
                    End Select
                Case "frmCautelas"
                    Select Case strTabela
                        Case "Responsável"
                            frmPrincipal.objCautela.mtdAtualizarDtgv1(mtdgetDadosSelecionados)
                        Case "Bens"
                            frmPrincipal.objCautela.mtdAtualizarDtgv2(mtdgetDadosSelecionados)
                    End Select
                Case "frmMBPs"
                    Select Case strTabela
                        Case "Responsáveis"
                            frmPrincipal.objMBP.mtdAtualizarDtgv1(mtdgetDadosSelecionados)
                        Case "Bens"
                            frmPrincipal.objMBP.mtdAtualizarDtgv2(mtdgetDadosSelecionados)
                    End Select
                Case "frmInventarioBens"
                    frmPrincipal.objInventarioBens.mtdAtualizarDtgv1(mtdgetDadosSelecionados)
            End Select
            Me.Close()
        End Sub

        Private Sub frmSugestionador_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
            If varHouveRedimensionamento = False Then
                dfrmlsv1H = Me.Width - lsv1.Width
                dfrmlsv1V = Me.Height - lsv1.Height
                varHouveRedimensionamento = True
            End If
            lsv1.Height = Me.Height - dfrmlsv1V
            lsv1.Width = Me.Width - dfrmlsv1H
        End Sub

        Private Sub frmSugestionador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.Text = strTextoFormulario
            lsv1.BackColor = corFundoLsv1

            mtdAtualizarTs()
        End Sub

        Private Sub mtdAtualizarTs()
            Try
                tstxtLinhaSelecionada.Text = lsv1.SelectedItems(0).Index.ToString()
            Catch ex As Exception
                tstxtLinhaSelecionada.Text = "N/D"
            End Try

            tstxtColunaSelecionada.Text = "N/D"

            Try
                tstxtTotalLinhas.Text = lsv1.Items.Count.ToString()
                tstxtTotalColunas.Text = lsv1.Columns.Count.ToString()
            Catch ex As Exception
                tstxtTotalLinhas.Text = "N/D"
                tstxtTotalColunas.Text = "N/D"
            End Try
        End Sub

        Private Sub lsv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsv1.Click
            mtdAtualizarTs()
        End Sub

        Private Sub lsv1_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsv1.ColumnClick
            frmPrincipal.mtdOrdenarColunasLsv(lsv1, SQL, e.Column)
        End Sub
    End Class
End Namespace