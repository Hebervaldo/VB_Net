Imports System.Security
Imports System.Security.Cryptography
Imports System.Text

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmCadastroUsuario
        Private strConexaoBancoDadosPrincipal As String = frmPrincipal.strConexaoBancoDadosPrincipal
        Private strNomeTabelaPrincipal As String = "tblUsuarios"
        Private strColunaPrincipal As String = "Contador"
        Private objBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
        Private dfrmdtgv1H As Integer
        Private dfrmdtgv1V As Integer
        Private dfrmgrpb1H As Integer
        Private dfrmgrpb1V As Integer
        Private dfrmcmb1H As Integer
        Private varHouveRedimensionamento As Boolean = False
        Private blnadicaolinha As Boolean = False
        Private numteclapressionada As Integer = 0
        Private numlinhaselecionada As Integer = 0
        Private numcolunaselecionada As Integer = 0
        Private numColunaDR As Integer
        Private maxlinha As Integer = 0
        Private mudancadtgv1 As Boolean = False
        Private objCriptografia As clsCriptografia = New clsCriptografia()
        Private strChavePadrao As String = "Chave_Padrao"

        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            strConexaoBancoDadosPrincipal = frmPrincipal.strConexaoBancoDadosPrincipal
        End Sub

        Private Sub frmCadastroUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            objBancoDados.prpConexao = strConexaoBancoDadosPrincipal
            objBancoDados.mtdAbrirConexao()
            mtdAtualizarDtgv1()
            dtgv1.SelectionMode() = DataGridViewSelectionMode.FullRowSelect
            txtProcurar.Select()
            cmb1.Items.Add("Administrador")
            cmb1.Items.Add("Usuario")
            cmb1.Text = cmb1.Items(0).ToString()
            txtProcurar.Focus()
            'txt3.Text = strChavePadrao
        End Sub

        Private Sub mtdAtualizarDtgv1()
            Try
                objBancoDados.prpComando = "SELECT " & strNomeTabelaPrincipal & ".* FROM " & strNomeTabelaPrincipal & " WHERE " & strNomeTabelaPrincipal & "." & strColunaPrincipal & " LIKE '%'"
                objBancoDados.mtdExecutarComando()
                objBancoDados.mtdDefinirLeitorDados()
                objBancoDados.mtdProximoRegistro()
                objBancoDados.mtdAdaptadorDados()
                dtgv1.DataSource = objBancoDados.prpAjustadorDados.Tables(0)
                dtgv1.Columns(0).ReadOnly = True
                dtgv1.Columns(1).ReadOnly = False
                dtgv1.Columns(2).ReadOnly = True
                dtgv1.Columns(3).ReadOnly = True
                dtgv1.Columns(4).ReadOnly = True
                blnadicaolinha = False
                numColunaDR = objBancoDados.mtdNumeroColunas() - 1
                maxlinha = objBancoDados.mtdNumeroLinhas()
                dtgv1.FirstDisplayedCell = dtgv1.Item(0, dtgv1.RowCount - 1)

                mtdAtualizarTs()
            Catch
            End Try
        End Sub

        Private Sub frmCadastroUsuario_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
            If varHouveRedimensionamento = False Then
                dfrmdtgv1H = Me.Width - dtgv1.Width
                dfrmdtgv1V = Me.Height - dtgv1.Height
                dfrmgrpb1H = Me.Width - grpb1.Left
                ' dfrmgrpb1V = Me.Height - grpb1.Top
                varHouveRedimensionamento = True
            End If
            dtgv1.Height = Me.Height - dfrmdtgv1V
            dtgv1.Width = Me.Width - dfrmdtgv1H
            grpb1.Left = Me.Width - dfrmgrpb1H
            grpb2.Left = grpb1.Left
            ' grpb1.Top = Me.Height - dfrmgrpb1V
        End Sub

        Private Sub dtgv1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv1.CellEndEdit
            numcolunaselecionada = e.ColumnIndex
            numlinhaselecionada = e.RowIndex

            mtdAtualizarTs()

            mtdAdicionarRegistro()
        End Sub

        Private Sub dtgv1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgv1.KeyDown
            If e.KeyCode = System.Windows.Forms.Keys.Delete Then
                If MessageBox.Show("Deseja realmente deletar a linha selecionada?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                    dtgv1.AllowUserToDeleteRows = True
                Else
                    dtgv1.AllowUserToDeleteRows = False
                End If

                mtdDeletarLinhaSelecionada()
            End If
            numteclapressionada = e.KeyCode
        End Sub

        Private Sub dtgv1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv1.RowEnter
            blnadicaolinha = False
            dtgv1.SelectionMode() = DataGridViewSelectionMode.RowHeaderSelect
            numlinhaselecionada = e.RowIndex
            numcolunaselecionada = e.ColumnIndex

            mtdAtualizarTs()

            Try
                strSQL = ("DELETE FROM " & strNomeTabelaPrincipal & " WHERE " & dtgv1.Columns(0).HeaderText & "=" & dtgv1.Item(0, numlinhaselecionada).Value.ToString)
            Catch
            End Try
        End Sub

        Private strSQL As String = String.Empty

        Private Sub mtdProximo()
            If dtgv1.Columns.Count > 0 Then
                If dtgv1.Rows.Count > 0 Then
                    maxlinha = dtgv1.Rows.Count
                    dtgv1.SelectionMode() = DataGridViewSelectionMode.FullRowSelect
                    If numlinhaselecionada < maxlinha - 1 Then
                        numlinhaselecionada += 1
                        dtgv1.Item(0, numlinhaselecionada - 1).Selected = False
                        dtgv1.Item(0, numlinhaselecionada).Selected = True
                    Else
                        numlinhaselecionada = -1
                        numlinhaselecionada += 1
                        dtgv1.Item(0, maxlinha - 1).Selected = False
                        dtgv1.Item(0, numlinhaselecionada).Selected = True
                    End If
                    mtddtgv1Clicar()
                    mtdAtualizarTs()
                End If
            End If
        End Sub

        Private Sub mtdAnterior()
            If dtgv1.Columns.Count > 0 Then
                If dtgv1.Rows.Count > 0 Then
                    maxlinha = dtgv1.Rows.Count
                    dtgv1.SelectionMode() = DataGridViewSelectionMode.FullRowSelect
                    If numlinhaselecionada > 0 Then
                        numlinhaselecionada -= 1
                        dtgv1.Item(0, numlinhaselecionada + 1).Selected = False
                        dtgv1.Item(0, numlinhaselecionada).Selected = True
                    Else
                        numlinhaselecionada = maxlinha
                        numlinhaselecionada -= 1
                        dtgv1.Item(0, 0).Selected = False
                        dtgv1.Item(0, numlinhaselecionada).Selected = True
                    End If
                    mtddtgv1Clicar()
                    mtdAtualizarTs()
                End If
            End If
        End Sub

        Private Sub mtdAdicionarRegistro()
            Try
                Dim strSQLColuna As String = String.Empty
                Dim strSQLValor As String = String.Empty
                Dim strSQLParcial As String = String.Empty
                Dim maxContador As Integer
                If blnadicaolinha = False Then
                    For contador As Integer = 0 To numColunaDR Step 1
                        strSQLColuna = dtgv1.Columns(contador).HeaderText
                        strSQLValor = dtgv1.Item(contador, numlinhaselecionada).Value.ToString
                        strSQLParcial &= strSQLColuna & "='" & strSQLValor & "'"
                        If contador <> numColunaDR Then
                            strSQLParcial &= ", "
                        End If
                    Next
                    strSQL = "UPDATE " & strNomeTabelaPrincipal & " SET " & strSQLParcial & " WHERE " & dtgv1.Columns(0).HeaderText & "=" & _
                    dtgv1.Item(0, numlinhaselecionada).Value.ToString
                    objBancoDados.mtdExecutarComando(strSQL)
                    blnadicaolinha = False
                Else
                    Try
                        maxContador = Int32.Parse(dtgv1.Item(0, numlinhaselecionada - 1).Value.ToString)
                    Catch
                        maxContador = -1
                    Finally
                        dtgv1.Item(0, numlinhaselecionada).Value = maxContador + 1
                        For contador As Integer = 0 To numColunaDR Step 1
                            strSQLColuna &= dtgv1.Columns(contador).HeaderText
                            strSQLValor &= "'" & dtgv1.Item(contador, numlinhaselecionada).Value.ToString & "'"
                            If contador <> numColunaDR Then
                                strSQLColuna &= ", "
                                strSQLValor &= ", "
                            End If
                        Next
                        strSQLParcial = " (" & strSQLColuna.Trim() & ") Values (" & strSQLValor & ")"
                        strSQL = "INSERT INTO " & strNomeTabelaPrincipal & strSQLParcial
                        objBancoDados.mtdExecutarComando(strSQL)
                        blnadicaolinha = False
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show _
                ( _
                "Não foi possível adicionar o registro.", _
                "Aviso!", _
                MessageBoxButtons.OK _
                )
            End Try
        End Sub

        Private Sub dtgv1_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dtgv1.UserAddedRow
            blnadicaolinha = True
        End Sub

        'Private Sub dtgv1_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dtgv1.UserDeletingRow
        '    If dtgv1.AllowUserToDeleteRows Then
        '        strSQL = ("DELETE FROM " & strNomeTabela & " WHERE " & dtgv1.Columns(0).HeaderText & "=" & dtgv1.Item(0, numlinhaselecionada).Value.ToString)
        '        objBancoDados.mtdExecutarComando(strSQL)
        '        MessageBox.Show("A linha selecionada foi removida.", "Aviso!", MessageBoxButtons.OK)
        '    Else
        '        MessageBox.Show("Nenhuma linha foi deletada.", "Aviso!", MessageBoxButtons.OK)
        '    End If
        'End Sub

        Private Sub txtProcurar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = System.Windows.Forms.Keys.Enter Then
                mtdProcurar()
            End If
        End Sub

        Private Sub mtdProcurar()
            Try
                Dim strValor As String = String.Empty, EnderecoEncontrado(dtgv1.ColumnCount - 1, dtgv1.RowCount - 2) As Boolean
                Dim valortxt1 As String = txtProcurar.Text.ToLower
                Dim estiloValorEncontrado As New DataGridViewCellStyle()
                Dim estiloValorNaoEncontrado As New DataGridViewCellStyle()
                Dim selecionar As Boolean = False
                estiloValorEncontrado.BackColor = Color.CadetBlue
                estiloValorEncontrado.ForeColor = Color.Empty
                estiloValorNaoEncontrado.BackColor = Color.Empty
                estiloValorNaoEncontrado.ForeColor = Color.Empty
                If Not txtProcurar.Text = String.Empty Then
                    For coluna As Integer = 0 To dtgv1.ColumnCount - 1 Step 1
                        For linha As Integer = 0 To dtgv1.RowCount - 2 Step 1
                            strValor = dtgv1.Item(coluna, linha).Value().ToString
                            strValor = strValor.ToLower
                            If strValor.Contains(valortxt1) Then
                                EnderecoEncontrado(coluna, linha) = True
                            End If
                        Next
                    Next
                    Dim TX As Integer = valortxt1.GetHashCode
                    For coluna As Integer = EnderecoEncontrado.GetLowerBound(0) To EnderecoEncontrado.GetUpperBound(0)
                        For linha As Integer = EnderecoEncontrado.GetLowerBound(1) To EnderecoEncontrado.GetUpperBound(1)
                            If EnderecoEncontrado(coluna, linha) Then
                                dtgv1.Item(coluna, linha).Style = estiloValorEncontrado
                                If Not selecionar Then
                                    dtgv1.Item(coluna, linha).Selected = True
                                    selecionar = True
                                End If
                            Else
                                dtgv1.Item(coluna, linha).Style = estiloValorNaoEncontrado
                            End If
                        Next
                    Next
                Else
                    For coluna As Integer = EnderecoEncontrado.GetLowerBound(0) To EnderecoEncontrado.GetUpperBound(0)
                        For linha As Integer = EnderecoEncontrado.GetLowerBound(1) To EnderecoEncontrado.GetUpperBound(1)
                            dtgv1.Item(coluna, linha).Style = estiloValorNaoEncontrado
                        Next
                    Next
                End If
            Catch
            End Try
        End Sub

        Private Sub mtddtgv1Clicar()
            Try
                mudancadtgv1 = True
                If Not dtgv1.Item(3, numlinhaselecionada).Value.ToString().Equals(String.Empty) Then
                    txt2.Text = objCriptografia.mtdDesCriptografar(dtgv1.Item(3, numlinhaselecionada).Value.ToString(), dtgv1.Item(4, numlinhaselecionada).Value.ToString(), Encryption.Symmetric.Provider.Rijndael)
                Else
                    txt2.Text = String.Empty
                End If
                cmb1.Text = dtgv1.Item(2, numlinhaselecionada).Value.ToString()
                txt3.Text = dtgv1.Item(4, numlinhaselecionada).Value.ToString()
                txt4.Text = dtgv1.Item(3, numlinhaselecionada).Value.ToString()
            Catch
            End Try
        End Sub

        Private Sub dtgv1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgv1.Click
            mtddtgv1Clicar()
        End Sub
        Private Sub txtProcurar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProcurar.TextChanged
            If txtProcurar.Text.Length Mod 4 = 0 Then
                mtdProcurar()
            End If
        End Sub

        Private Sub mtdMudarTexto()
            If dtgv1.Columns.Count > 0 Then
                If dtgv1.Rows.Count > 0 Then
                    Dim senhaDescriptografada As String = String.Empty
                    If Not mudancadtgv1 Then
                        If (txt3.Text.Length > 0 And txt3.Text.Length < 17) And txt2.Text.Length > 0 Then
                            txt4.Text = objCriptografia.mtdCriptografar(txt2.Text, txt3.Text, Encryption.Symmetric.Provider.Rijndael)
                            Try
                                senhaDescriptografada = objCriptografia.mtdDesCriptografar()
                                dtgv1.Item(2, numlinhaselecionada).Value = cmb1.Text
                                dtgv1.Item(3, numlinhaselecionada).Value = txt4.Text
                                dtgv1.Item(4, numlinhaselecionada).Value = txt3.Text
                                mtdAdicionarRegistro()
                            Catch ex As Exception
                                MessageBox.Show("Digite outra senha ou outra chave, pois uma dessas são inválidas, dessa forma, continuarão salvas a senha e a chave mais antigas válidas.", "Aviso!", MessageBoxButtons.OK)
                            End Try
                        End If
                    Else
                        mudancadtgv1 = False
                    End If
                End If
            End If
        End Sub

        Private Sub txt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt2.TextChanged
            mtdMudarTexto()
        End Sub

        Private Sub txt3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt3.TextChanged
            mtdMudarTexto()
        End Sub

        Private Sub mtdAtualizarTs()
            Try
                tstxtLinhaSelecionada.Text = (numlinhaselecionada + 1).ToString()
                tstxtColunaSelecionada.Text = (numcolunaselecionada + 1).ToString()
                tstxtTotalLinhas.Text = (dtgv1.RowCount).ToString()
                tstxtTotalColunas.Text = (dtgv1.ColumnCount).ToString()
            Catch ex As Exception
                tstxtLinhaSelecionada.Text = "N/D"
                tstxtColunaSelecionada.Text = "N/D"
                tstxtTotalLinhas.Text = "N/D"
                tstxtTotalColunas.Text = "N/D"
            End Try
        End Sub

        Private Sub mtdDeletarLinhaSelecionada()
            If dtgv1.Columns.Count > 0 Then
                If dtgv1.Rows.Count > 0 Then
                    If numlinhaselecionada <> dtgv1.NewRowIndex Then
                        If dtgv1.AllowUserToDeleteRows = True Then
                            strSQL = ("DELETE FROM " & strNomeTabelaPrincipal & " WHERE " & dtgv1.Columns(0).HeaderText & "=" & dtgv1.Item(0, numlinhaselecionada).Value.ToString)
                            objBancoDados.mtdExecutarComando(strSQL)
                            dtgv1.Rows.RemoveAt(numlinhaselecionada)
                            MessageBox.Show("A linha selecionada foi removida.", "Aviso!", MessageBoxButtons.OK)
                        Else
                            MessageBox.Show("Nenhuma linha foi deletada.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        MessageBox.Show("Não é possível deletar uma linha que ainda não foi criada.", "Aviso!", MessageBoxButtons.OK)
                    End If
                End If
            End If
        End Sub

        Private Sub tsbExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExcluir.Click
            If MessageBox.Show("Deseja realmente deletar a linha selecionada?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                dtgv1.AllowUserToDeleteRows = True
            Else
                dtgv1.AllowUserToDeleteRows = False
            End If

            mtdDeletarLinhaSelecionada()
        End Sub

        Private Sub tsbSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSair.Click
            Me.Close()
        End Sub

        Private Sub tsbAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnterior.Click
            mtdAnterior()
        End Sub

        Private Sub tsbProximo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbProximo.Click
            mtdProximo()
        End Sub

        Private Sub tsbIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbIncluir.Click
            numlinhaselecionada = dtgv1.NewRowIndex()
            mtdAtualizarTs()
            Dim maxContador As Integer = Int32.Parse(dtgv1.Item(0, numlinhaselecionada - 1).Value.ToString)
            dtgv1.Rows.Insert(numlinhaselecionada, 4)
            dtgv1.Item(0, numlinhaselecionada).Value = maxContador + 1
            For contador As Integer = 0 To dtgv1.Columns.Count - 1 Step 1
                dtgv1.Item(contador, numlinhaselecionada).Value = String.Empty
            Next
            dtgv1.Item(1, numlinhaselecionada).Selected = True
            dtgv1.Item(1, numlinhaselecionada).DataGridView.BeginEdit(True)
            blnadicaolinha = True
            mtdAdicionarRegistro()
        End Sub

        Private Sub tsbProcurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbProcurar.Click
            mtdProcurar()
        End Sub

        Private Sub cmb1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb1.TextChanged
            Try
                dtgv1.Item(2, numlinhaselecionada).Value = cmb1.Text
                dtgv1.BeginEdit(True)
                dtgv1.EndEdit()
            Catch
            End Try
        End Sub

        Private Sub txtProcurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcurar.Click
            txtProcurar.Text = String.Empty
        End Sub

        Private Sub frmCadastroUsuario_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            objBancoDados.mtdFecharConexao()
        End Sub

        Private intLinhaAnteriorDTGV1 As Integer = 0
        Private intColunaAnteriorDTGV1 As Integer = 0

        Private corAtual As Color = Color.FromArgb(255, 192, 192)

        Private Sub dtgv1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv1.CellClick
            numlinhaselecionada = e.RowIndex
            numcolunaselecionada = e.ColumnIndex

            mtdAtualizarTs()

            frmPrincipal.mtdDestacarCelulas(dtgv1, numlinhaselecionada, numcolunaselecionada, intLinhaAnteriorDTGV1, intColunaAnteriorDTGV1, corAtual)
        End Sub

        Private Sub dtgv1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgv1.KeyUp
            Try
                numlinhaselecionada = dtgv1.SelectedCells(0).RowIndex
                numcolunaselecionada = dtgv1.SelectedCells(0).ColumnIndex
            Catch ex As Exception

            End Try

            Select Case e.KeyCode
                Case System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.PageUp, System.Windows.Forms.Keys.PageDown

                    mtdAtualizarTs()

                    frmPrincipal.mtdDestacarCelulas(dtgv1, numlinhaselecionada, numcolunaselecionada, intLinhaAnteriorDTGV1, intColunaAnteriorDTGV1, System.Drawing.Color.White)
            End Select
        End Sub

        Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
            mtdAtualizarDtgv1()
        End Sub

        Private Sub dtgv1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgv1.DataError

        End Sub
    End Class
End Namespace