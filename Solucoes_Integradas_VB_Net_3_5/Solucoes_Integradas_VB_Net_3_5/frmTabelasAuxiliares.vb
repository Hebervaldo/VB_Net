Imports System.Security
Imports System.Security.Cryptography
Imports System.Text

Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmTabelasAuxiliares
        ' Variáveis de Instância
        Private objRegistroWindows As clsRegistroWindows = New clsRegistroWindows( _
                                                           Microsoft.Win32.Registry.CurrentUser, _
                                                           "Software", _
                                                           "Eletronorte", _
                                                           "Eletronorte - Soluções Integradas")

        Private strConexaoBancoDadosPrincipal As String = frmPrincipal.strConexaoBancoDadosPrincipal
        Private strTabelaAuxiliaresPrincipal As String = String.Empty
        Private strTabelaAuxiliaresTipoPrincipal As String = "tblTabelasAuxiliaresTipo"
        Private strTabelaAuxiliaresPropriedadePrincipal As String = "tblTabelasAuxiliaresPropriedade"
        Private strTabelaAuxiliaresMotivacaoPrincipal As String = "tblTabelasAuxiliaresMotivacao"
        Private strTabelaAuxiliaresConservacaoBensPrincipal As String = "tblTabelasAuxiliaresConservacaoBens"
        Private strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal As String = "tblTabelasAuxiliaresTermoResponsabilidadeGeral"
        Private strTabelaAuxiliaresFiltroImportacaoPrincipal As String = "tblTabelasAuxiliaresFiltroImportacao"

        Private strColunaPrincipal As String = String.Empty
        Private strColunaTipoPrincipal As String = "Tipo".ToUpper()
        Private strColunaPropriedadePrincipal As String = "Propriedade".ToUpper()
        Private strColunaMotivacaoPrincipal As String = "Motivacao".ToUpper()
        Private strColunaConservacaoBensPrincipal As String = "ConservacaoBens".ToUpper()
        Private strColunaTermoResponsabilidadeGeralPrincipal As String = "TermoResponsabilidadeGeral".ToUpper()
        Private strColunaFiltroImportacaoPrincipal As String = "FiltroImportacao".ToUpper()

        Private strValorColuna As String = String.Empty
        Private objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
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
        Private numColunaDR As Integer = 0
        Private maxlinha As Integer = 0
        Private mudancadtgv1 As Boolean = False
        Private objCriptografia As clsCriptografia = New clsCriptografia()

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            Dim objBancoDadosCADU As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                       clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServer)
        End Sub

        Private Sub frmTabelasAuxiliares_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            mtdCriarTabelas()
            dtgv1.SelectionMode() = DataGridViewSelectionMode.FullRowSelect
            txtProcurar.Select()
            bcmb1.Items.Add(strColunaTipoPrincipal)
            bcmb1.Items.Add(strColunaPropriedadePrincipal)
            bcmb1.Items.Add(strColunaMotivacaoPrincipal)
            bcmb1.Items.Add(strColunaConservacaoBensPrincipal)
            bcmb1.Items.Add(strColunaTermoResponsabilidadeGeralPrincipal)
            bcmb1.Items.Add(strColunaFiltroImportacaoPrincipal)
            bcmb1.Text = bcmb1.Items(0).ToString()

            bcmb3.Items.Add("Campo Inteiro")
            bcmb3.Items.Add("Qualquer Parte do Campo")
            bcmb3.Text = bcmb3.Items(1).ToString()

            mtdIniciarThreadCriarTabelaMBPTipo()
            mtdIniciarThreadCriarTabelaMBPPropriedade()
            mtdIniciarThreadCriarTabelaMBPMotivacao()
            mtdIniciarThreadCriarTabelaMBPConservacaoBens()
            mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral()
            mtdIniciarThreadCriarTabelaFiltroImportacao()

            mtdAtualizarDtgv1("%")
            mtdPreencherBcmb2()
            If bcmb2.Items.Count > 0 Then
                bcmb2.Text = bcmb2.Items(0).ToString()
            End If
            txtProcurar.Focus()
        End Sub

        Protected Friend Sub mtdCriarTabelas()
            frmPrincipal.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaMBPTipo()
            frmPrincipal.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaMBPPropriedade()
            frmPrincipal.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaMBPMotivacao()
            frmPrincipal.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaMBPConservacaoBens()
            frmPrincipal.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral()
            frmPrincipal.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaFiltroImportacao()
        End Sub

        Private Sub frmTabelasAuxiliares_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
            If varHouveRedimensionamento = False Then
                dfrmdtgv1H = Me.Width - dtgv1.Width
                dfrmdtgv1V = Me.Height - dtgv1.Height
                ' dfrmgrpb1V = Me.Height - grpb1.Top
                varHouveRedimensionamento = True
            End If
            dtgv1.Height = Me.Height - dfrmdtgv1V
            dtgv1.Width = Me.Width - dfrmdtgv1H
            ' grpb1.Top = Me.Height - dfrmgrpb1V
        End Sub
        Private Sub dtgv1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv1.CellEndEdit
            numcolunaselecionada = e.ColumnIndex
            numlinhaselecionada = e.RowIndex

            mtdAtualizarTs()

            mtdAdicionarRegistro()
            Select Case bcmb1.Text
                Case bcmb1.Items(4).ToString()
                    objRegistroWindows.mtdSalvarDadosRegistro("Numero_TRG", dtgv1.Item(e.ColumnIndex, 0).Value.ToString())
            End Select
        End Sub
        Private Sub dtgv1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgv1.KeyDown
            If e.KeyCode = System.Windows.Forms.Keys.Delete Then
                mtdDeletarDtgv1()
            End If
        End Sub

        Private Sub dtgv1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv1.RowEnter
            blnadicaolinha = False
            dtgv1.SelectionMode() = DataGridViewSelectionMode.RowHeaderSelect
            numlinhaselecionada = e.RowIndex
            numcolunaselecionada = e.ColumnIndex

            mtdAtualizarTs()
        End Sub

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

                    mtdAtualizarTs()
                End If
            End If
        End Sub

        Private Sub mtdAdicionarRegistro()
            Try
                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                objBDPrincipal.mtdAbrirConexao()
                mtdTabelaColunaAuxiliares(strTabelaAuxiliaresPrincipal, strColunaPrincipal)
                objBDPrincipal.mtdExecutarComando(String.Format("SELECT * FROM {0};", strTabelaAuxiliaresPrincipal))
                objBDPrincipal.mtdDefinirLeitorDados()
                objBDPrincipal.mtdProximoRegistro()

                numColunaDR = objBDPrincipal.mtdNumeroColunas() - 1

                Dim dados As String()() = New String(1)() {}
                Dim vetDadosTipo As String() = New String(numColunaDR) {}

                dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()
                For contador As Integer = 0 To numColunaDR Step 1
                    vetDadosTipo(contador) = objBDPrincipal.mtdObterTipoRegistro(contador)
                Next

                If Not blnadicaolinha Then
                    Dim strNomeCabecalhoColuna As String = dtgv1.Columns(0).HeaderText
                    Dim Dado As String = String.Empty
                    Dim strFormatoTipo As String = String.Empty
                    Dim strValorRegistro As String = String.Empty
                    dados(1) = New String(numColunaDR + 3) {}
                    For coluna As Integer = 0 To numColunaDR Step 1
                        strFormatoTipo = mtdObterFormatoTipo(vetDadosTipo(coluna))
                        strValorRegistro = dtgv1.Item(coluna, numlinhaselecionada).Value.ToString()
                        Dado = String.Format(If(strFormatoTipo = String.Empty, If(coluna = 0, "{0}", "'{0}'"), strFormatoTipo), strValorRegistro)
                        dados(1)(coluna) = If(Dado.Equals(String.Empty), If(coluna = 0, "0", Dado), Dado)
                    Next
                    dados(1)(numColunaDR + 1) = strNomeCabecalhoColuna
                    dados(1)(numColunaDR + 2) = "="

                    strFormatoTipo = mtdObterFormatoTipo(vetDadosTipo(0))
                    strValorRegistro = strValorColuna
                    Dado = String.Format(strFormatoTipo, strValorRegistro)

                    dados(1)(numColunaDR + 3) = If(Dado.Equals(String.Empty), "0", Dado)

                    objBDPrincipal.mtdAtualizarDados(strTabelaAuxiliaresPrincipal, dados)

                    blnadicaolinha = False
                Else
                    Dim Dado As String = String.Empty
                    Dim strFormatoTipo As String = String.Empty
                    Dim strValorRegistro As String = String.Empty
                    dados(1) = New String(numColunaDR) {}
                    For coluna As Integer = 0 To numColunaDR Step 1
                        strFormatoTipo = mtdObterFormatoTipo(vetDadosTipo(coluna))
                        strValorRegistro = dtgv1.Item(coluna, numlinhaselecionada).Value.ToString()
                        Dado = String.Format(If(strFormatoTipo = String.Empty, If(coluna = 0, "{0}", "'{0}'"), strFormatoTipo), strValorRegistro)
                        dados(1)(coluna) = If(Dado.Equals(String.Empty), If(coluna = 0, "0", Dado), Dado)
                    Next

                    objBDPrincipal.mtdInserirDados(strTabelaAuxiliaresPrincipal, dados)

                    blnadicaolinha = False
                End If
                objBDPrincipal.Dispose()
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

        Private Sub txtProcurar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If txtProcurar.Text.Length Mod 4 = 0 Then
                mtdProcurar()
            End If
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

        Private Sub tsbExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExcluir.Click
            mtdDeletarDtgv1()
        End Sub

        Private Sub mtdDeletarDtgv1()
            If dtgv1.Columns.Count > 0 Then
                If dtgv1.Rows.Count > 0 Then
                    Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                    mtdTabelaColunaAuxiliares(strTabelaAuxiliaresPrincipal, strColunaPrincipal)

                    If MessageBox.Show("Deseja realmente deletar a linha selecionada?", "Aviso!", MessageBoxButtons.YesNo) = _
                        System.Windows.Forms.DialogResult.Yes Then
                        dtgv1.AllowUserToDeleteRows = True
                    Else
                        dtgv1.AllowUserToDeleteRows = False
                    End If
                    If numlinhaselecionada <> dtgv1.NewRowIndex Then
                        If dtgv1.AllowUserToDeleteRows Then
                            Dim strNomeCabecalhoColuna As String = dtgv1.Columns(0).HeaderText
                            Dim Dado As String = String.Empty
                            Dim strFormatoTipo As String = String.Empty
                            Dim strValorRegistro As String = String.Empty

                            objBDPrincipal.mtdAbrirConexao()
                            objBDPrincipal.mtdExecutarComando(String.Format("SELECT * FROM {0};", strTabelaAuxiliaresPrincipal))
                            objBDPrincipal.mtdDefinirLeitorDados()
                            numColunaDR = objBDPrincipal.mtdNumeroColunas()
                            objBDPrincipal.mtdProximoRegistro()
                            Dim vetDadosTipo As String() = New String(numColunaDR - 1) {}
                            For contador As Integer = 0 To numColunaDR - 1 Step 1
                                vetDadosTipo(contador) = objBDPrincipal.mtdObterTipoRegistro(contador)
                            Next

                            strFormatoTipo = mtdObterFormatoTipo(vetDadosTipo(0))
                            strValorRegistro = dtgv1.Item(0, numlinhaselecionada).Value.ToString()
                            Dado = String.Format(strFormatoTipo, strValorRegistro)

                            objBDPrincipal.mtdDeletarDados(strTabelaAuxiliaresPrincipal, dtgv1.Columns(0).HeaderText, "LIKE", _
                                                                      Dado)
                            'MessageBox.Show("A linha selecionada foi removida.", "Aviso!", MessageBoxButtons.OK)
                        Else
                            MessageBox.Show("Nenhuma linha foi deletada.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Else
                        MessageBox.Show("Não é possível deletar uma linha que ainda não foi criada.", "Aviso!", MessageBoxButtons.OK)
                    End If
                    objBDPrincipal.Dispose()
                    mtdAtualizarDtgv1("%")
                    mtdAtualizarTs()
                End If
            End If
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
            For contador As Integer = 0 To dtgv1.Columns.Count - 1
                dtgv1.Item(contador, numlinhaselecionada).Value = String.Empty
            Next
            dtgv1.Item(0, numlinhaselecionada).Selected = True
            dtgv1.Item(0, numlinhaselecionada).DataGridView.BeginEdit(True)
            blnadicaolinha = True
            mtdAdicionarRegistro()
        End Sub

        Private Sub tsbProcurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            mtdProcurar()
        End Sub

        Private Sub txtProcurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            txtProcurar.Text = String.Empty
        End Sub

        Private Sub frmTabelasAuxiliares_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        End Sub

        Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
            mtdAtualizarDtgv1("%")
            mtdAtualizarTs()
        End Sub

        Private Function mtdIdentificarTipo(ByVal Tipo As String) As String
            Dim strTipo As String = String.Empty
            Select Case Tipo
                Case "System.String"
                    strTipo = "VARCHAR"
                Case "System.Int16", "System.Int32", "System.Int64", "System.Double"
                    strTipo = "INTEGER"
            End Select
            Return strTipo
        End Function

        Private Function mtdIdentificarTamanhoTipo(ByVal Tipo As String) As String
            Dim strTamanho As String = String.Empty
            Select Case Tipo
                Case "System.String"
                    strTamanho = "255"
                Case "System.Int16", "System.Int32", "System.Int64", "System.Double"
                    strTamanho = String.Empty
            End Select
            Return strTamanho
        End Function

        Private Function mtdObterFormatoTipo(ByVal Tipo As String) As String
            Dim strFormato As String = String.Empty
            Select Case Tipo
                Case "System.String"
                    strFormato = "'{0}'"
                Case "System.Int16", "System.Int32", "System.Int64", "System.Double"
                    strFormato = "{0}"
            End Select
            Return strFormato
        End Function

        Private Sub mtdTabelaColunaAuxiliares(ByRef TabelaAuxiliaresPrincipal As String, ByRef ColunaPrincipal As String)
            Select Case bcmb1.Text
                Case bcmb1.Items(0).ToString()
                    TabelaAuxiliaresPrincipal = strTabelaAuxiliaresTipoPrincipal
                    ColunaPrincipal = strColunaTipoPrincipal
                Case bcmb1.Items(1).ToString()
                    TabelaAuxiliaresPrincipal = strTabelaAuxiliaresPropriedadePrincipal
                    ColunaPrincipal = strColunaPropriedadePrincipal
                Case bcmb1.Items(2).ToString()
                    TabelaAuxiliaresPrincipal = strTabelaAuxiliaresMotivacaoPrincipal
                    ColunaPrincipal = strColunaMotivacaoPrincipal
                Case bcmb1.Items(3).ToString()
                    TabelaAuxiliaresPrincipal = strTabelaAuxiliaresConservacaoBensPrincipal
                    ColunaPrincipal = strColunaConservacaoBensPrincipal
                Case bcmb1.Items(4).ToString()
                    TabelaAuxiliaresPrincipal = strTabelaAuxiliaresTermoResponsabilidadeGeralPrincipal
                    ColunaPrincipal = strColunaTermoResponsabilidadeGeralPrincipal
                Case bcmb1.Items(5).ToString()
                    TabelaAuxiliaresPrincipal = strTabelaAuxiliaresFiltroImportacaoPrincipal
                    ColunaPrincipal = strColunaFiltroImportacaoPrincipal
            End Select
        End Sub

        Private Sub mtdAtualizarDtgv1(ByVal Dado As String)
            mtdAtualizarDtgv1(Dado, bcmb3.Items(1).ToString())
        End Sub

        Private Sub mtdAtualizarDtgv1(ByVal Dado As String, ByVal BcmbTexto As String)
            Try
                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

                Dim blnCuringa As Boolean = True
                'Dim vetColunas As String()
                Dim vetTipoColunas As String() = Nothing
                Dim strDado As String = Dado

                Dim intNumeroColuna As Integer = 0
                Dim strFormatoTipo As String = String.Empty
                Dim strFormatoCuringa As String = String.Empty

                mtdTabelaColunaAuxiliares(strTabelaAuxiliaresPrincipal, strColunaPrincipal)

                Select Case BcmbTexto
                    Case "Campo Inteiro"
                        blnCuringa = False
                    Case "Qualquer Parte do Campo"
                        blnCuringa = True
                End Select

                objBDPrincipal.mtdAbrirConexao(strConexaoBancoDadosPrincipal)
                objBDPrincipal.mtdSelecionarDados("*", strTabelaAuxiliaresPrincipal)
                objBDPrincipal.mtdDefinirLeitorDados()
                objBDPrincipal.mtdProximoRegistro()
                objBDPrincipal.mtdObterTipoRegistro(vetTipoColunas)

                intNumeroColuna = objBDPrincipal.mtdObterNumeroColuna(strColunaPrincipal.ToUpper())
                'strFormatoTipo = mtdObterFormatoTipo(vetTipoColunas(intNumeroColuna))
                strFormatoTipo = "'{0}'"
                strFormatoCuringa = String.Format(strFormatoTipo, If(blnCuringa, "%{0}%", "{0}"))
                strDado = String.Format(strFormatoCuringa, Dado)

                objBDPrincipal.mtdSelecionarDados("*", _
                                                             strTabelaAuxiliaresPrincipal, _
                                                             strColunaPrincipal, _
                                                             "LIKE", _
                                                             strDado, _
                                                             strColunaPrincipal, _
                                                             True)

                objBDPrincipal.mtdDefinirLeitorDados()
                objBDPrincipal.mtdProximoRegistro()
                objBDPrincipal.mtdAdaptadorDados()
                dtgv1.DataSource = objBDPrincipal.prpTabelaDados
                blnadicaolinha = False
                numColunaDR = objBDPrincipal.mtdNumeroColunas() - 1
                maxlinha = objBDPrincipal.mtdNumeroLinhas()

                objBDPrincipal.Dispose()
                dtgv1.FirstDisplayedCell = dtgv1.Item(0, dtgv1.RowCount - 1)

                mtdAtualizarTs()
            Catch
            End Try
        End Sub

        Private Sub dtgv1_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dtgv1.CellBeginEdit
            strValorColuna = dtgv1.Item(0, numlinhaselecionada).Value.ToString()
        End Sub

        Private Sub mtdPreencherBcmb(ByRef bcmb As ToolStripComboBox)
            'Try
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            mtdTabelaColunaAuxiliares(strTabelaAuxiliaresPrincipal, strColunaPrincipal)

            objBDPrincipal.mtdAbrirConexao(strConexaoBancoDadosPrincipal)
            objBDPrincipal.mtdExecutarComando(String.Format("SELECT * FROM {0};", strTabelaAuxiliaresPrincipal))
            Dim numMaxRegistro As Integer = objBDPrincipal.mtdNumeroLinhas() - 1
            objBDPrincipal.mtdDefinirLeitorDados()
            objBDPrincipal.mtdProximoRegistro()
            'objBDPrincipal.mtdAdaptadorDados()
            ' cria tres itens e tres conjuntos de subitems para cada item
            For contador As Integer = 0 To bcmb.Items.Count - 1 Step 1
                bcmb.Items.RemoveAt(0)
            Next
            Dim numColuna As Integer = objBDPrincipal.mtdNumeroColunas() - 1
            For contador As Integer = 0 To numColuna Step 1
                bcmb.Items.Add(objBDPrincipal.mtdObterCabecalhoColunas(contador))
            Next
            objBDPrincipal.Dispose()
            'Catch
            'End Try
        End Sub

        Private Sub mtdPreencherBcmb2()
            mtdPreencherBcmb(bcmb2)
        End Sub

        Private Sub bcmb3_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb3.DropDown
            mtdAtualizarDtgv1(btxt1.Text)
        End Sub

        Private intLinhaAnteriorDTGV1 As Integer = 0
        Private intColunaAnteriorDTGV1 As Integer = 0

        Private corAtual As Color = Color.Silver

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

        Private Sub tsbProcurar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbProcurar.Click
            mtdProcurar()
        End Sub

        Private Sub bcmb1_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb1.DropDownClosed
            mtdPreencherBcmb2()
            If bcmb2.Items.Count > 0 Then
                bcmb2.Text = bcmb2.Items(0).ToString()
            End If
            mtdAtualizarDtgv1("%")
            mtdAtualizarTs()
            intLinhaAnteriorDTGV1 = 0
            intColunaAnteriorDTGV1 = 0
        End Sub

        Private Sub dtgv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgv1.Click
            Try
                numlinhaselecionada = dtgv1.SelectedCells(0).RowIndex
                numcolunaselecionada = dtgv1.SelectedCells(0).ColumnIndex

                mtdAtualizarTs()
            Catch
            End Try
        End Sub

        Private Sub btxt1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btxt1.Click
            mtdAtualizarDtgv1(btxt1.Text, bcmb3.Text)
        End Sub

        Private Sub btxt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btxt1.TextChanged
            mtdAtualizarDtgv1(btxt1.Text, bcmb3.Text)
        End Sub

        Private Sub dtgv1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgv1.DataError

        End Sub
    End Class
End Namespace