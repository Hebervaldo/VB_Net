Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports System.Runtime.CompilerServices

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmBens
        Protected Friend ThProgresso As Threading.Thread

        Public Shared Numero_Item As Long = 0

        Public Shared ReadOnly strNomeTabelaPrincipal As String = "tblBensEletronorte"
        Public Shared ReadOnly strNomeTabelaColetor As String = "tblBensEletronorte"
        Public Shared ReadOnly strColuna As String = "Imobilizado"
        Public Shared ReadOnly strColunaPrincipal As String = "Imobilizado"
        Public Shared ReadOnly strColunaColetor As String = "Imobilizado"
        Public Shared strValorColuna As String = String.Empty

        Public Const intColunaTabelaBensImobilizado As Integer = 0
        Public Const intColunaTabelaBensPatrimonio As Integer = 1
        Public Const intColunaTabelaBensDenominacao As Integer = 2
        Public Const intColunaTabelaBensDenominacao_Extra As Integer = 3
        Public Const intColunaTabelaBensN_Serie As Integer = 4
        Public Const intColunaTabelaBensSala As Integer = 5
        Public Const intColunaTabelaBensMatricula As Integer = 6
        Public Const intColunaTabelaBensCentro_Custo As Integer = 7
        Public Const intColunaTabelaBensAtividade As Integer = 8
        Public Const intColunaTabelaBensOrgao As Integer = 9

        Public Shared ReadOnly vetCamposTabelaBens As String() = { _
                                                  "Imobilizado", _
                                                  "Patrimonio", _
                                                  "Denominacao", _
                                                  "Denominacao_Extra", _
                                                  "N_Serie", _
                                                  "Sala", _
                                                  "Matricula", _
                                                  "Centro_Custo", _
                                                  "Atividade", _
                                                  "Orgao" _
                                             }

        Private Delegate Sub SetValueCallback(ByVal [value] As Integer)

        Private f As SetValueCallback = New SetValueCallback(AddressOf Me.SetValue)
        Private strConexaoBancoDadosPrincipal As String = frmPrincipal.strConexaoBancoDadosPrincipal
        Private strConexaoBancoDadosColetor As String = frmPrincipal.strConexaoBancoDadosColetor
        Private objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
        Private [NewValue] As Integer = 0
        Private dfrmHdtgv1H As Integer
        Private dfrmVdtgv1V As Integer
        Private dfrmVgrpb1V As Integer
        Private dfrm1Hgrpb1H As Integer
        Private dgrpb1Vgrpb2V As Integer
        Private dgrpb1Vlsv1V As Integer

        Private varHouveRedimensionamento As Boolean = False
        Private blnadicaolinha As Boolean = False
        'Private blnNotificacao As Boolean = False
        Private numteclapressionada As Integer = 0
        Protected Friend Shared numlinhaselecionada As Integer = 0
        Protected Friend Shared numcolunaselecionada As Integer = 0
        Private numColunaDR As Integer
        Private maxlinha As Integer = 0
        Private mudancadtgv1 As Boolean = False
        Private objCriptografia As clsCriptografia = New clsCriptografia()
        Private strModoCapitalizacao As String = "Capitalizado"
        Private intRepeticaoBens As Integer = 0

        Private objLockRotinaExecutada As Object = New Object()

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            strConexaoBancoDadosPrincipal = frmPrincipal.strConexaoBancoDadosPrincipal

            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            strConexaoBancoDadosColetor = frmPrincipal.strConexaoBancoDadosColetor

            objBDColetor.Dispose()
        End Sub

        Private Sub frmBens_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            mtdCriarTabelas()
            mtdIniciarThreadProgresso(True)

            dtgv1.SelectionMode() = DataGridViewSelectionMode.FullRowSelect

            frmPrincipal.mtdPreencherCmb(cmb1, "Todos", vetCamposTabelaBens, intColunaTabelaBensPatrimonio + 1)

            txtProcurar.Select()
            bcmb1.Items.Add("Principal")
            bcmb1.Items.Add("Coletor")
            bcmb1.Text = bcmb1.Items(0).ToString()
            bcmb3.Items.Add("Campo Inteiro")
            bcmb3.Items.Add("Qualquer Parte do Campo")
            mtdAtualizarDtgv1(strColunaPrincipal, String.Empty, frmPrincipal.intNumeroLinhasInventarioBens.ToString())
            mtdPreencherBcmb2()
            mtdPreencherBcmb4()
            txtProcurar.Focus()
            mtdAtivarDesativarMenuPrincipal(bcmb1.Text)
            txt1.Text = System.Convert.ToString(intRepeticaoBens)
            SQLLsv1 = mtdPreencherLsv1()
        End Sub

        Protected Friend Sub mtdCriarTabelas()
            frmPrincipal.objBens.blnComandoImplementadoPermitirMensagemTabelaBensEletronortePrincipal = False
            frmPrincipal.objBens.blnComandoImplementadoDeletarDadosTabelaBensEletronortePrincipal = False
            frmPrincipal.objBens.blnComandoImplementadoInserirDadosTabelaBensEletronortePrincipal = False
            frmPrincipal.objBens.mtdIniciarThreadImportarTabelaBensEletronortePrincipal()
            frmPrincipal.objBens.blnComandoImplementadoPermitirMensagemTabelaBensEletronorteColetor = False
            frmPrincipal.objBens.blnComandoImplementadoDeletarDadosTabelaBensEletronorteColetor = False
            frmPrincipal.objBens.blnComandoImplementadoInserirDadosTabelaBensEletronorteColetor = False
            frmPrincipal.objBens.mtdIniciarThreadImportarTabelaBensEletronorteColetor()

            frmPrincipal.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaTermoResponsabilidadeGeral()
            frmPrincipal.objTabelasAuxiliares.mtdIniciarThreadCriarTabelaFiltroImportacao()
        End Sub

        Private Sub frmBens_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
            If varHouveRedimensionamento = False Then
                dfrmHdtgv1H = Me.Width - dtgv1.Width
                dfrmVdtgv1V = Me.Height - dtgv1.Height
                dfrm1Hgrpb1H = Me.Width - grpb1.Left
                dgrpb1Vgrpb2V = grpb2.Top - (grpb1.Height + grpb1.Top)

                dgrpb1Vlsv1V = grpb1.Height - lsv1.Height

                varHouveRedimensionamento = True
            End If
            dtgv1.Width = dtgv1.Width + (Me.Width - dtgv1.Width) - dfrmHdtgv1H
            dtgv1.Height = dtgv1.Height + (Me.Height - dtgv1.Height) - dfrmVdtgv1V

            grpb1.Height = CInt((Me.Height - (dfrmVdtgv1V)) / 2)
            grpb1.Left = Me.Width - dfrm1Hgrpb1H
            grpb2.Height = grpb1.Height
            grpb2.Left = Me.Width - dfrm1Hgrpb1H
            grpb2.Height = grpb1.Height
            grpb2.Width = grpb1.Width
            grpb2.Top = grpb1.Top + grpb1.Height + dgrpb1Vgrpb2V

            lsv1.Height = grpb1.Height - dgrpb1Vlsv1V
        End Sub

        Private Sub dtgv1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv1.CellEndEdit
            numcolunaselecionada = e.ColumnIndex
            numlinhaselecionada = e.RowIndex

            mtdAtualizarTs()

            Try
                dtgv1.Item(1, numlinhaselecionada).Value = System.Convert.ToInt32(dtgv1.Item(1, numlinhaselecionada).Value.ToString())
            Catch ex As Exception
                dtgv1.Item(1, numlinhaselecionada).Value = 0
            End Try
            Try
                dtgv1.Item(6, numlinhaselecionada).Value = System.Convert.ToInt32(dtgv1.Item(6, numlinhaselecionada).Value.ToString())
            Catch ex As Exception
                dtgv1.Item(6, numlinhaselecionada).Value = 0
            End Try
            Try
                dtgv1.Item(7, numlinhaselecionada).Value = System.Convert.ToInt32(dtgv1.Item(7, numlinhaselecionada).Value.ToString())
            Catch ex As Exception
                dtgv1.Item(7, numlinhaselecionada).Value = 0
            End Try

            Try
                dtgv1.Item(0, numlinhaselecionada).Value = objManipuladorTexto.mtdExecutarTudo(dtgv1.Item(0, numlinhaselecionada).Value.ToString())
                dtgv1.Item(2, numlinhaselecionada).Value = objManipuladorTexto.mtdExecutarTudo(dtgv1.Item(2, numlinhaselecionada).Value.ToString())
                dtgv1.Item(3, numlinhaselecionada).Value = objManipuladorTexto.mtdExecutarTudo(dtgv1.Item(3, numlinhaselecionada).Value.ToString())
                dtgv1.Item(4, numlinhaselecionada).Value = objManipuladorTexto.mtdExecutarTudo(dtgv1.Item(4, numlinhaselecionada).Value.ToString())
                dtgv1.Item(5, numlinhaselecionada).Value = objManipuladorTexto.mtdExecutarTudo(dtgv1.Item(5, numlinhaselecionada).Value.ToString())
                dtgv1.Item(8, numlinhaselecionada).Value = objManipuladorTexto.mtdExecutarTudo(dtgv1.Item(8, numlinhaselecionada).Value.ToString())
                dtgv1.Item(9, numlinhaselecionada).Value = objManipuladorTexto.mtdExecutarTudo(dtgv1.Item(9, numlinhaselecionada).Value.ToString())
            Catch
            End Try

            mtdAdicionarRegistro()
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
            If (numlinhaselecionada > -1 And numcolunaselecionada > -1) Then
                Select Case bcmb1.Text
                    Case bcmb1.Items(0).ToString()
                        Try
                            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                                                clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                            objBDPrincipal.mtdAbrirConexao()

                            Dim dados As String()() = New String(1)() {}
                            Dim vetDadosTipo As String() = New String(numColunaDR) {}

                            objBDPrincipal.mtdExecutarComando(String.Format("SELECT * FROM {0};", strNomeTabelaPrincipal))
                            objBDPrincipal.mtdDefinirLeitorDados()
                            objBDPrincipal.mtdProximoRegistro()
                            dados(0) = objBDPrincipal.mtdObterCabecalhoColunas()

                            For contador As Integer = 0 To numColunaDR Step 1
                                vetDadosTipo(contador) = objBDPrincipal.mtdObterTipoRegistro(contador)
                            Next

                            If blnadicaolinha = False Then
                                Dim strNomeCabecalhoColuna As String = dtgv1.Columns(1).HeaderText
                                Dim Dado As String = String.Empty
                                Dim strFormatoTipo As String = String.Empty
                                Dim strValorRegistro As String = String.Empty
                                dados(1) = New String(numColunaDR + 3) {}
                                For coluna As Integer = 0 To numColunaDR Step 1
                                    strFormatoTipo = mtdObterFormatoTipo(vetDadosTipo(coluna))
                                    strValorRegistro = dtgv1.Item(coluna, numlinhaselecionada).Value.ToString()
                                    Dado = String.Format(If(strFormatoTipo = String.Empty, If(coluna = 1 Or coluna = 6 Or coluna = 7, "{0}", "'{0}'"), strFormatoTipo), strValorRegistro)
                                    dados(1)(coluna) = If(Dado.Equals(String.Empty), If(coluna = 1 Or coluna = 6 Or coluna = 7, "0", Dado), Dado)
                                Next
                                dados(1)(numColunaDR + 1) = strNomeCabecalhoColuna
                                dados(1)(numColunaDR + 2) = "="
                                dados(1)(numColunaDR + 3) = strValorColuna

                                objBDPrincipal.mtdAtualizarDados(strNomeTabelaPrincipal, dados)

                                blnadicaolinha = False
                            Else
                                Dim Dado As String = String.Empty
                                Dim strFormatoTipo As String = String.Empty
                                Dim strValorRegistro As String = String.Empty
                                dados(1) = New String(numColunaDR) {}
                                For coluna As Integer = 0 To numColunaDR Step 1
                                    strFormatoTipo = mtdObterFormatoTipo(vetDadosTipo(coluna))
                                    strValorRegistro = dtgv1.Item(coluna, numlinhaselecionada).Value.ToString()
                                    Dado = String.Format(If(strFormatoTipo = String.Empty, If(coluna = 1 Or coluna = 6 Or coluna = 7, "{0}", "'{0}'"), strFormatoTipo), strValorRegistro)
                                    dados(1)(coluna) = If(Dado.Equals(String.Empty), If(coluna = 1 Or coluna = 6 Or coluna = 7, "0", Dado), Dado)
                                Next

                                objBDPrincipal.mtdInserirDados(strNomeTabelaPrincipal, dados)

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
                    Case bcmb1.Items(1).ToString()
                        Try
                            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosColetor, _
                                               clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)
                            objBDColetor.mtdAbrirConexao()

                            Dim dados As String()() = New String(1)() {}
                            Dim vetDadosTipo As String() = New String(numColunaDR) {}

                            objBDColetor.mtdExecutarComando(String.Format("SELECT * FROM {0};", strNomeTabelaColetor))
                            objBDColetor.mtdDefinirLeitorDados()
                            objBDColetor.mtdProximoRegistro()
                            dados(0) = objBDColetor.mtdObterCabecalhoColunas()

                            For contador As Integer = 0 To numColunaDR Step 1
                                vetDadosTipo(contador) = objBDColetor.mtdObterTipoRegistro(contador)
                            Next

                            If blnadicaolinha = False Then
                                Dim strNomeCabecalhoColuna As String = dtgv1.Columns(1).HeaderText
                                Dim Dado As String = String.Empty
                                Dim strFormatoTipo As String = String.Empty
                                Dim strValorRegistro As String = String.Empty
                                dados(1) = New String(numColunaDR + 3) {}
                                For coluna As Integer = 0 To numColunaDR Step 1
                                    strFormatoTipo = mtdObterFormatoTipo(vetDadosTipo(coluna))
                                    strValorRegistro = dtgv1.Item(coluna, numlinhaselecionada).Value.ToString()
                                    Dado = String.Format(If(strFormatoTipo = String.Empty, If(coluna = 1 Or coluna = 6 Or coluna = 7, "{0}", "'{0}'"), strFormatoTipo), strValorRegistro)
                                    dados(1)(coluna) = If(Dado.Equals(String.Empty), If(coluna = 1 Or coluna = 6 Or coluna = 7, "0", Dado), Dado)
                                Next
                                dados(1)(numColunaDR + 1) = strNomeCabecalhoColuna
                                dados(1)(numColunaDR + 2) = "="
                                dados(1)(numColunaDR + 3) = strValorColuna

                                objBDColetor.mtdAtualizarDados(strNomeTabelaColetor, dados)

                                blnadicaolinha = False
                            Else
                                Dim Dado As String = String.Empty
                                Dim strFormatoTipo As String = String.Empty
                                Dim strValorRegistro As String = String.Empty
                                dados(1) = New String(numColunaDR) {}
                                For coluna As Integer = 0 To numColunaDR Step 1
                                    strFormatoTipo = mtdObterFormatoTipo(vetDadosTipo(coluna))
                                    strValorRegistro = dtgv1.Item(coluna, numlinhaselecionada).Value.ToString()
                                    Dado = String.Format(If(strFormatoTipo = String.Empty, If(coluna = 1 Or coluna = 6 Or coluna = 7, "{0}", "'{0}'"), strFormatoTipo), strValorRegistro)
                                    dados(1)(coluna) = If(Dado.Equals(String.Empty), If(coluna = 1 Or coluna = 6 Or coluna = 7, "0", Dado), Dado)
                                Next

                                objBDColetor.mtdInserirDados(strNomeTabelaColetor, dados)

                                blnadicaolinha = False
                            End If
                            objBDColetor.Dispose()
                        Catch ex As Exception
                            MessageBox.Show _
                            ( _
                            "Não foi possível adicionar o registro.", _
                            "Aviso!", _
                            MessageBoxButtons.OK _
                            )
                        End Try
                End Select

                mtdAtualizarTs()
            End If
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
                    Select Case bcmb1.Text
                        Case bcmb1.Items(0).ToString()
                            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                          strConexaoBancoDadosPrincipal, _
                                                                          clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
                                                                          )
                            'Try
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                            frmVisualizarImpressao.Tabela = "tblBensEletronorte"

                            If MessageBox.Show("Deseja realmente deletar as linhas referidas?", "Aviso!", _
                                               MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                Dim vetBlnLsv1() As Boolean = New Boolean(lsv1.Items.Count) {}

                                For contador As Integer = 0 To lsv1.Items.Count - 1 Step 1
                                    If lsv1.Items(contador).Checked Then
                                        vetBlnLsv1(contador + 1) = lsv1.Items(contador).Checked
                                    Else
                                        vetBlnLsv1(contador + 1) = Nothing
                                    End If
                                Next

                                If vetBlnLsv1.Contains(True) Then
                                    If (lsv1.Columns.Count > 0) Then
                                        If (lsv1.Items.Count > 0) Then
                                            For contador As Integer = 0 To lsv1.Items.Count - 1 Step 1
                                                If lsv1.Items(contador).Checked Then
                                                    objBDPrincipal.mtdDeletarDados _
                                                    ( _
                                                    strNomeTabelaPrincipal, _
                                                    lsv1.Columns(0).Text, _
                                                    "LIKE", _
                                                     String.Format("'{0}'", lsv1.Items(contador).Text) _
                                                    )
                                                Else
                                                    objBDPrincipal.mtdDeletarDados _
                                                    ( _
                                                    strNomeTabelaPrincipal, _
                                                    strColunaPrincipal, _
                                                    "LIKE", _
                                                    String.Format("'{0}'", dtgv1.Item(0, numlinhaselecionada).Value).ToString() _
                                                    )
                                                End If
                                            Next
                                        Else
                                            objBDPrincipal.mtdDeletarDados _
                                            ( _
                                            strNomeTabelaPrincipal, _
                                            strColunaPrincipal, _
                                            "LIKE", _
                                            String.Format("'{0}'", dtgv1.Item(0, numlinhaselecionada).Value).ToString() _
                                            )
                                        End If
                                    Else
                                        objBDPrincipal.mtdDeletarDados _
                                        ( _
                                        strNomeTabelaPrincipal, _
                                        strColunaPrincipal, _
                                        "LIKE", _
                                        String.Format("'{0}'", dtgv1.Item(0, numlinhaselecionada).Value).ToString() _
                                        )
                                    End If
                                    GoTo Saida
                                Else
                                    objBDPrincipal.mtdDeletarDados _
                                    ( _
                                    strNomeTabelaPrincipal, _
                                    strColunaPrincipal, _
                                    "LIKE", _
                                    String.Format("'{0}'", dtgv1.Item(0, numlinhaselecionada).Value).ToString() _
                                    )
                                End If
                                GoTo Saida
                            Else
                                MessageBox.Show( _
                                    "Não é possível deletar uma linha que ainda não foi criada.", _
                                    "Aviso!", _
                                    MessageBoxButtons.OK _
                                    )
                            End If
                            'Catch
                            '    MessageBox.Show( _
                            '           "Não é possível deletar uma linha que ainda não foi criada.", _
                            '           "Aviso!", _
                            '           MessageBoxButtons.OK _
                            '           )
                            'End Try

                            objBDPrincipal.Dispose()
                        Case bcmb1.Items(1).ToString()
                            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                                         strConexaoBancoDadosColetor, _
                                                                                         clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE _
                                                                                         )
                            'Try
                            frmVisualizarImpressao.strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                            frmVisualizarImpressao.Tabela = "tblBensEletronorte"

                            If MessageBox.Show("Deseja realmente deletar as linhas referidas?", "Aviso!", _
                                               MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                Dim vetBlnLsv1() As Boolean = New Boolean(lsv1.Items.Count) {}

                                For contador As Integer = 0 To lsv1.Items.Count - 1 Step 1
                                    If lsv1.Items(contador).Checked Then
                                        vetBlnLsv1(contador + 1) = lsv1.Items(contador).Checked
                                    Else
                                        vetBlnLsv1(contador + 1) = Nothing
                                    End If
                                Next

                                If vetBlnLsv1.Contains(True) Then
                                    If (lsv1.Columns.Count > 0) Then
                                        If (lsv1.Items.Count > 0) Then
                                            Dim blnChecado As Boolean = False
                                            For contador As Integer = 0 To lsv1.Items.Count - 1 Step 1
                                                If lsv1.Items(contador).Checked Then
                                                    blnChecado = True
                                                    objBDColetor.mtdDeletarDados _
                                                    ( _
                                                    strNomeTabelaColetor, _
                                                    lsv1.Columns(0).Text, _
                                                    "LIKE", _
                                                     String.Format("'{0}'", lsv1.Items(contador).Text) _
                                                    )
                                                End If
                                            Next

                                            If Not blnChecado Then
                                                objBDColetor.mtdDeletarDados _
                                                ( _
                                                strNomeTabelaColetor, _
                                                strColunaColetor, _
                                                "LIKE", _
                                                String.Format("'{0}'", dtgv1.Item(0, numlinhaselecionada).Value).ToString() _
                                                )
                                            End If
                                        Else
                                            objBDColetor.mtdDeletarDados _
                                            ( _
                                            strNomeTabelaColetor, _
                                            strColunaColetor, _
                                            "LIKE", _
                                            String.Format("'{0}'", dtgv1.Item(0, numlinhaselecionada).Value).ToString() _
                                            )
                                        End If
                                    Else
                                        objBDColetor.mtdDeletarDados _
                                        ( _
                                        strNomeTabelaColetor, _
                                        strColunaColetor, _
                                        "LIKE", _
                                        String.Format("'{0}'", dtgv1.Item(0, numlinhaselecionada).Value).ToString() _
                                        )
                                    End If
                                    GoTo Saida
                                Else
                                    objBDColetor.mtdDeletarDados _
                                    ( _
                                    strNomeTabelaColetor, _
                                    strColunaColetor, _
                                    "LIKE", _
                                    String.Format("'{0}'", dtgv1.Item(0, numlinhaselecionada).Value).ToString() _
                                    )
                                End If
                                GoTo Saida
                            Else
                                MessageBox.Show( _
                                    "Não é possível deletar uma linha que ainda não foi criada.", _
                                    "Aviso!", _
                                    MessageBoxButtons.OK _
                                    )
                            End If
                            'Catch
                            '    MessageBox.Show( _
                            '           "Não é possível deletar uma linha que ainda não foi criada.", _
                            '           "Aviso!", _
                            '           MessageBoxButtons.OK _
                            '           )
                            'End Try

                            objBDColetor.Dispose()
                    End Select

Saida:
                    mtdAtualizarDtgv1(strColuna, String.Empty, frmPrincipal.intNumeroLinhasInventarioBens.ToString())
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

            mtdAtualizarTs()
        End Sub

        Private Sub tsbProcurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            mtdProcurar()
        End Sub

        Private Sub txtProcurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            txtProcurar.Text = String.Empty
        End Sub

        Private Sub frmBens_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            mtdAbortarProcessos()
        End Sub

        Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
            mtdAtualizarDtgv1(strColuna, String.Empty, "0")
            mtdAtualizarTs()
        End Sub

        Private strArquivo As String = String.Empty

        Private Sub blbl5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blbl5.Click
            If blnThreadAtivadaImportarTabelaBensEletronortePrincipal Or blnThreadAtivadaImportarTabelaBensEletronorteColetor Then
                blbl3.Text = "Importar"
                mtdAbortarThreadImportarTabelaBensEletronortePrincipal(True)
                mtdAbortarThreadImportarTabelaBensEletronorteColetor(True)
            Else
                'blbl3.Text = "Parar"

                ' define as propriedades do controle 
                ' OpenFileDialog
                Me.ofd1.Multiselect = True
                Me.ofd1.Title = "Importar"
                ofd1.InitialDirectory = String.Concat(frmPrincipal.strEnderecoAplicativo, "Banco Dados\")
                ' filtra para exibir somente arquivos de imagens
                ofd1.Filter = "Texto (*.txt)|*.txt|Todos Arquivos (*.*)|*.*"
                ofd1.CheckFileExists = True
                ofd1.CheckPathExists = True
                ofd1.FilterIndex = 1
                ofd1.RestoreDirectory = True
                ofd1.ReadOnlyChecked = True
                ofd1.ShowReadOnly = True

                Dim dr As DialogResult = Me.ofd1.ShowDialog()

                strArquivo = String.Empty

                If (dr = System.Windows.Forms.DialogResult.OK) Then
                    ' Le os arquivos selecionados 
                    For Each arquivo As String In ofd1.FileNames
                        strArquivo += arquivo
                    Next

                    If System.Windows.Forms.MessageBox.Show( _
                        "Deseja realmente iniciar a importação dos dados do arquivo de texto para a tabela de bens do aplicativo?", _
                        "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        Select Case bcmb1.Text
                            Case bcmb1.Items(0).ToString()
                                blnComandoImplementadoPermitirMensagemTabelaBensEletronortePrincipal = True
                                blnComandoImplementadoDeletarDadosTabelaBensEletronortePrincipal = True
                                blnComandoImplementadoInserirDadosTabelaBensEletronortePrincipal = True
                                mtdIniciarThreadImportarTabelaBensEletronortePrincipal()
                            Case bcmb1.Items(1).ToString()
                                blnComandoImplementadoPermitirMensagemTabelaBensEletronorteColetor = True
                                blnComandoImplementadoDeletarDadosTabelaBensEletronorteColetor = True
                                blnComandoImplementadoInserirDadosTabelaBensEletronorteColetor = True
                                mtdIniciarThreadImportarTabelaBensEletronorteColetor()
                                'If frmPrincipal.m_bIsWatching Then
                                '    frmPrincipal.mtdMonitorarDiretorioArquivo()
                                'End If      
                        End Select
                    End If
                End If
            End If
        End Sub

        Private Function mtdIdentificarTipoPrincipal(ByVal Tipo As String) As String
            Dim strTipo As String = String.Empty
            Select Case Tipo
                Case "System.String"
                    strTipo = "TEXT"
                Case "System.Int16", "System.Int32", "System.Int64", "System.Double"
                    strTipo = "INTEGER"
            End Select
            Return strTipo
        End Function

        Private Function mtdIdentificarTipoColetor(ByVal Tipo As String) As String
            Dim strTipo As String = String.Empty
            Select Case Tipo
                Case "System.String"
                    strTipo = "NVARCHAR"
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
                Case "System.DateTime"
                    strFormato = "#{0}#"
            End Select
            Return strFormato
        End Function

        Public Sub mtdIniciarThreadProgresso(ByVal BarraAcessoria As Boolean)
            ThProgresso = New Threading.Thread(New Threading.ThreadStart(AddressOf Me.mtdRotinaThreadProgresso))
            ThProgresso.IsBackground = True
            ThProgresso.Priority = Threading.ThreadPriority.Normal
            ThProgresso.Start()
        End Sub

        Private Shared LockInventarioBens As Object = New Object()

        Private Sub mtdRotinaThreadProgresso()
            Dim strtempoestimado As String = String.Empty
            Try
                Do
                    SyncLock (LockInventarioBens)
                        If Me.InvokeRequired Then
                            Me.BeginInvoke(f, New Object() {[NewValue]})
                        Else
                            bprgProgresso.Value = [NewValue]
                            blblProgresso.Text = String.Format("{0} %", [NewValue])
                        End If
                        System.Threading.Thread.Sleep(1)
                    End SyncLock
                Loop
            Catch ex As Exception

            End Try
        End Sub

        Private Sub SetValue(ByVal [value] As Integer)
            If [value] >= 0 And [value] <= 100 Then
                bprgProgresso.Value = [value]
                blblProgresso.Text = String.Format("{0} %", [value])
            End If
        End Sub

        Private Sub mtdAtualizarDtgv1(ByVal Coluna As String, ByVal Dado As String, ByVal BcmbTexto As String, ByVal NumeroLinhas As String)
            Try
                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosColetor, _
                                                                           clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

                Dim blnCuringa As Boolean = True
                'Dim vetColunas As String()
                Dim vetTipoColunas As String() = Nothing
                Dim strDado As String = String.Empty

                Dim intNumeroColuna As Integer = 0
                Dim strFormatoTipo As String = String.Empty
                Dim strFormatoCuringa As String = String.Empty

                Select Case BcmbTexto
                    Case "Campo Inteiro"
                        blnCuringa = False
                    Case "Qualquer Parte do Campo"
                        blnCuringa = True
                End Select

                Select Case bcmb1.Text
                    Case bcmb1.Items(0).ToString()
                        objBDPrincipal.mtdSelecionarDados("1", "*", strNomeTabelaPrincipal)
                        objBDPrincipal.mtdDefinirLeitorDados()
                        objBDPrincipal.mtdProximoRegistro()
                        objBDPrincipal.mtdObterTipoRegistro(vetTipoColunas)

                        intNumeroColuna = objBDPrincipal.mtdObterNumeroColuna(Coluna)
                        'strFormatoTipo = mtdObterFormatoTipo(vetTipoColunas(intNumeroColuna))
                        strFormatoTipo = "'{0}'"
                        strFormatoCuringa = String.Format(strFormatoTipo, If(blnCuringa, "%{0}%", "{0}"))
                        strDado = String.Format(strFormatoCuringa, Dado)

                        objBDPrincipal.mtdSelecionarDados("*", _
                                                                     strNomeTabelaPrincipal, _
                                                                     Coluna, _
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
                    Case bcmb1.Items(1).ToString()
                        objBDColetor.mtdSelecionarDados("(1)", "*", strNomeTabelaColetor)
                        objBDColetor.mtdDefinirLeitorDados()
                        objBDColetor.mtdProximoRegistro()
                        objBDColetor.mtdObterTipoRegistro(vetTipoColunas)

                        intNumeroColuna = objBDColetor.mtdObterNumeroColuna(Coluna)
                        'strFormatoTipo = mtdObterFormatoTipo(vetTipoColunas(intNumeroColuna))
                        strFormatoTipo = "'{0}'"
                        strFormatoCuringa = String.Format(strFormatoTipo, If(blnCuringa, "%{0}%", "{0}"))
                        strDado = String.Format(strFormatoCuringa, Dado)

                        objBDColetor.mtdSelecionarDados("*", _
                                                                     strNomeTabelaColetor, _
                                                                     Coluna, _
                                                                     "LIKE", _
                                                                     strDado, _
                                                                     strColunaColetor, _
                                                                     True)

                        objBDColetor.mtdDefinirLeitorDados()
                        objBDColetor.mtdProximoRegistro()
                        objBDColetor.mtdAdaptadorDados()
                        dtgv1.DataSource = objBDColetor.prpTabelaDados
                        blnadicaolinha = False
                        numColunaDR = objBDColetor.mtdNumeroColunas() - 1
                        maxlinha = objBDColetor.mtdNumeroLinhas()
                End Select

                objBDPrincipal.Dispose()
                objBDColetor.Dispose()

                mtddtgv1Clicar(numlinhaselecionada)

                dtgv1.FirstDisplayedCell = dtgv1.Item(0, dtgv1.RowCount - 1)

                mtdAtualizarTs()
            Catch
            End Try
        End Sub

        Protected Friend Sub mtdAbortarProcessos()
            Try
                ThProgresso.Abort()
            Catch
            End Try

            mtdAbortarThreadImportarTabelaBensEletronortePrincipal(True)
            mtdAbortarThreadImportarTabelaBensEletronorteColetor(True)
        End Sub

        Private Sub dtgv1_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dtgv1.CellBeginEdit
            strValorColuna = dtgv1.Item(1, numlinhaselecionada).Value.ToString()
        End Sub

        Private Sub mtdPreencherPrincipalCmb(ByVal strSQL As String, ByRef cmb As ComboBox)
            'Try
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdAbrirConexao(strConexaoBancoDadosPrincipal)
            objBDPrincipal.mtdExecutarComando(strSQL)
            Dim numMaxRegistro As Integer = objBDPrincipal.mtdNumeroLinhas() - 1
            objBDPrincipal.mtdDefinirLeitorDados()
            objBDPrincipal.mtdProximoRegistro()
            'objBDPrincipal.mtdAdaptadorDados()
            ' cria tres itens e tres conjuntos de subitems para cada item
            For contador As Integer = 0 To cmb.Items.Count - 1 Step 1
                cmb.Items.RemoveAt(0)
            Next
            Dim numColuna As Integer = objBDPrincipal.mtdNumeroColunas() - 1
            For contador As Integer = 0 To numColuna Step 1
                cmb.Items.Add(objBDPrincipal.mtdObterCabecalhoColunas(contador))
            Next
            objBDPrincipal.Dispose()
            'Catch
            'End Try
        End Sub

        Private Sub mtdPreencherColetorCmb(ByVal strSQL As String, ByRef cmb As ComboBox)
            'Try
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                         strConexaoBancoDadosColetor, _
                                                                         clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            objBDColetor.mtdAbrirConexao(strConexaoBancoDadosColetor)
            objBDColetor.mtdExecutarComando(strSQL)
            Dim numMaxRegistro As Integer = objBDColetor.mtdNumeroLinhas() - 1
            objBDColetor.mtdDefinirLeitorDados()
            objBDColetor.mtdProximoRegistro()
            'objBDColetor.mtdAdaptadorDados()
            ' cria tres itens e tres conjuntos de subitems para cada item
            For contador As Integer = 0 To cmb.Items.Count - 1 Step 1
                cmb.Items.RemoveAt(0)
            Next
            Dim numColuna As Integer = objBDColetor.mtdNumeroColunas() - 1
            For contador As Integer = 0 To numColuna Step 1
                cmb.Items.Add(objBDColetor.mtdObterCabecalhoColunas(contador))
            Next
            objBDColetor.Dispose()
            'Catch
            'End Try
        End Sub

        Private Sub mtdPreencherPrincipalBcmb(ByVal strSQL As String, ByRef bcmb As ToolStripComboBox)
            'Try
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                    strConexaoBancoDadosPrincipal, _
                                                                    clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objBDPrincipal.mtdAbrirConexao(strConexaoBancoDadosPrincipal)
            objBDPrincipal.mtdExecutarComando(strSQL)
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

        Private Sub mtdPreencherColetorBcmb(ByVal strSQL As String, ByRef bcmb As ToolStripComboBox)
            'Try
            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                         strConexaoBancoDadosColetor, _
                                                                         clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            objBDColetor.mtdAbrirConexao(strConexaoBancoDadosColetor)
            objBDColetor.mtdExecutarComando(strSQL)
            Dim numMaxRegistro As Integer = objBDColetor.mtdNumeroLinhas() - 1
            objBDColetor.mtdDefinirLeitorDados()
            objBDColetor.mtdProximoRegistro()
            'objBDColetor.mtdAdaptadorDados()
            ' cria tres itens e tres conjuntos de subitems para cada item
            For contador As Integer = 0 To bcmb.Items.Count - 1 Step 1
                bcmb.Items.RemoveAt(0)
            Next
            Dim numColuna As Integer = objBDColetor.mtdNumeroColunas() - 1
            For contador As Integer = 0 To numColuna Step 1
                bcmb.Items.Add(objBDColetor.mtdObterCabecalhoColunas(contador))
            Next
            objBDColetor.Dispose()
            'Catch
            'End Try
        End Sub

        Private Sub mtdPreencherBcmb2()
            Select Case bcmb1.Text
                Case bcmb1.Items(0).ToString()
                    mtdPreencherPrincipalBcmb(String.Format("SELECT * FROM {0}", strNomeTabelaPrincipal), bcmb2)
                Case bcmb1.Items(1).ToString()
                    mtdPreencherColetorBcmb(String.Format("SELECT * FROM {0}", strNomeTabelaColetor), bcmb2)
            End Select
            bcmb2.SelectedIndex = intColunaTabelaBensOrgao
        End Sub

        Private Sub mtdPreencherBcmb4()
            Select Case bcmb1.Text
                Case bcmb1.Items(0).ToString()
                    mtdPreencherPrincipalBcmb(String.Format("SELECT * FROM {0}", strNomeTabelaPrincipal), bcmb4)
                Case bcmb1.Items(1).ToString()
                    mtdPreencherColetorBcmb(String.Format("SELECT * FROM {0}", strNomeTabelaColetor), bcmb4)
            End Select
        End Sub

        Private Sub bcmb1_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb1.DropDown
            mtdPreencherBcmb2()
            Try
                bcmb2.Text = bcmb2.Items(0).ToString()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub bcmb3_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb3.DropDown
            mtdAtualizarDtgv1(bcmb4.Text, btxt1.Text, "0")
        End Sub

        Private intLinhaAnteriorDTGV1 As Integer = 0
        Private intColunaAnteriorDTGV1 As Integer = 0

        Private corAtual As Color = Color.Azure

        Private Sub dtgv1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv1.CellClick
            mtddtgv1Clicar(e.RowIndex)

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
                Case System.Windows.Forms.Keys.Delete
                    dtgv1.AllowUserToDeleteRows = True
                    tsbExcluir_Click(sender, e)
                Case System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.PageUp, System.Windows.Forms.Keys.PageDown

                    mtdAtualizarTs()

                    frmPrincipal.mtdDestacarCelulas(dtgv1, numlinhaselecionada, numcolunaselecionada, intLinhaAnteriorDTGV1, intColunaAnteriorDTGV1, System.Drawing.Color.White)
                    mtdPreencherPpg1(numlinhaselecionada)
            End Select

            mtdAtualizarTs()
        End Sub

        Private Sub tsbProcurar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbProcurar.Click
            mtdProcurar()
        End Sub

        Private Sub dtgv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgv1.Click
            Try
                numlinhaselecionada = dtgv1.SelectedCells(0).RowIndex
                numcolunaselecionada = dtgv1.SelectedCells(0).ColumnIndex

                mtdAtualizarTs()
            Catch
            End Try
        End Sub

        Private Sub mtdAtivarDesativarMenuPrincipal(ByVal Texto As String)
            Select Case Texto
                Case bcmb1.Items(0).ToString()
                    frmPrincipal.smnEnviarEmail.Enabled = True
                    frmPrincipal.smnExportar.Enabled = True
                    frmPrincipal.smnGerarDocumentos.Enabled = True
                    frmPrincipal.smnImprimir.Enabled = True
                    frmPrincipal.smnVisualizarImprimir.Enabled = True
                Case bcmb1.Items(1).ToString()
                    frmPrincipal.smnEnviarEmail.Enabled = False
                    frmPrincipal.smnExportar.Enabled = False
                    frmPrincipal.smnGerarDocumentos.Enabled = False
                    frmPrincipal.smnImprimir.Enabled = False
                    frmPrincipal.smnVisualizarImprimir.Enabled = False
            End Select
        End Sub

        Private Sub bcmb1_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb1.DropDownClosed
            mtdAtualizarDtgv1(strColuna, String.Empty, frmPrincipal.intNumeroLinhasInventarioBens.ToString())
            mtdAtualizarTs()
            bcmb3.Text = bcmb3.Items(1).ToString()
            btxt1.Text = String.Empty
            lsv1.Clear()
            ppg1.SelectedObject = Nothing
            mtdAtivarDesativarMenuPrincipal(bcmb1.Text)
        End Sub

        Private Sub dtgv1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgv1.DataError
        End Sub

        Private Sub frmBens_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Enter
            frmPrincipal.smnGerarDocumentos.Enabled = True
            frmPrincipal.ssmGerarCautela.Enabled = True
            frmPrincipal.ssmGerarMBP.Enabled = True
        End Sub

        Private Sub frmBens_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
            frmPrincipal.smnGerarDocumentos.Enabled = False
            frmPrincipal.ssmGerarCautela.Enabled = False
            frmPrincipal.ssmGerarMBP.Enabled = False
        End Sub

        Private Sub frmBens_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
            frmPrincipal.numFormularioSelecionado = 5
        End Sub

        Private Sub frmBens_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
            frmPrincipal.numFormularioSelecionado = 0
        End Sub

        Private Sub mtddtgv1Clicar(ByVal linhaselecionada As Integer)
            Try
                Numero_Item = Convert.ToInt64(dtgv1.Item(0, linhaselecionada).Value.ToString())

                mtdPreencherPpg1(linhaselecionada)
            Catch
            End Try
        End Sub

        Private objBens_ As clsBens = New clsBens()

        Private Sub mtdPreencherPpg1(ByVal linhaselecionada As Integer)
            Try
                objBens_.Imobilizado = _
                CStr _
                ( _
                IIf _
                ( _
                Not dtgv1.Item(intColunaTabelaBensImobilizado, linhaselecionada).Value Is System.DBNull.Value, _
                dtgv1.Item(intColunaTabelaBensImobilizado, linhaselecionada).Value, _
                Nothing _
                ) _
                )
                objBens_.Patrimonio = _
                CLng _
                ( _
                IIf _
                ( _
                Not dtgv1.Item(intColunaTabelaBensPatrimonio, linhaselecionada).Value Is System.DBNull.Value, _
                dtgv1.Item(intColunaTabelaBensPatrimonio, linhaselecionada).Value, _
                Nothing _
                ) _
                )
                objBens_.Denominacao = _
                CStr _
                ( _
                IIf _
                ( _
                Not dtgv1.Item(intColunaTabelaBensDenominacao, linhaselecionada).Value Is System.DBNull.Value, _
                dtgv1.Item(intColunaTabelaBensDenominacao, linhaselecionada).Value, _
                Nothing _
                ) _
                )
                objBens_.Denominacao_Extra = _
                CStr _
                ( _
                IIf _
                ( _
                Not dtgv1.Item(intColunaTabelaBensDenominacao_Extra, linhaselecionada).Value Is System.DBNull.Value, _
                dtgv1.Item(intColunaTabelaBensDenominacao_Extra, linhaselecionada).Value, _
                Nothing _
                ) _
                )
                objBens_.N_Serie = _
                CStr _
                ( _
                IIf _
                ( _
                Not dtgv1.Item(intColunaTabelaBensN_Serie, linhaselecionada).Value Is System.DBNull.Value, _
                dtgv1.Item(intColunaTabelaBensN_Serie, linhaselecionada).Value, _
                Nothing _
                ) _
                )
                objBens_.Sala = _
                CStr _
                ( _
                IIf _
                ( _
                Not dtgv1.Item(intColunaTabelaBensSala, linhaselecionada).Value Is System.DBNull.Value, _
                dtgv1.Item(intColunaTabelaBensSala, linhaselecionada).Value, _
                Nothing _
                ) _
                )
                objBens_.Matricula = _
                CLng _
                ( _
                IIf _
                ( _
                Not dtgv1.Item(intColunaTabelaBensMatricula, linhaselecionada).Value Is System.DBNull.Value, _
                dtgv1.Item(intColunaTabelaBensMatricula, linhaselecionada).Value, _
                Nothing _
                ) _
                )
                objBens_.Centro_Custo = _
                CLng _
                ( _
                IIf _
                ( _
                Not dtgv1.Item(intColunaTabelaBensCentro_Custo, linhaselecionada).Value Is System.DBNull.Value, _
                dtgv1.Item(intColunaTabelaBensCentro_Custo, linhaselecionada).Value, _
                Nothing _
                ) _
                )
                objBens_.Atividade = _
                CStr _
                ( _
                IIf _
                ( _
                Not dtgv1.Item(intColunaTabelaBensAtividade, linhaselecionada).Value Is System.DBNull.Value, _
                dtgv1.Item(intColunaTabelaBensAtividade, linhaselecionada).Value, _
                Nothing _
                ) _
                )
                objBens_.Orgao = _
                CStr _
                ( _
                IIf _
                ( _
                Not dtgv1.Item(intColunaTabelaBensOrgao, linhaselecionada).Value Is System.DBNull.Value, _
                dtgv1.Item(intColunaTabelaBensOrgao, linhaselecionada).Value, _
                Nothing _
                ) _
                )

                ppg1.SelectedObject = objBens_
            Catch
            End Try
        End Sub

        'Private Sub bcmb4_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    mtdCarregarBcmb45(bcmb4)
        'End Sub

        'Private Sub bcmb5_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    mtdCarregarBcmb45(bcmb5)
        'End Sub

        Private Sub mtdPreencherBcmb45Principal(ByVal SQL As String, ByRef bcmb As ToolStripComboBox)
            Try
                Dim objBDPrincipal As New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, SQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objBDPrincipal.mtdAbrirConexao()
                objBDPrincipal.mtdExecutarComando()
                Dim numMaxRegistro As Integer = objBDPrincipal.mtdNumeroLinhas()
                objBDPrincipal.mtdDefinirLeitorDados()
                objBDPrincipal.prpAjustadorDados = New DataSet()
                objBDPrincipal.mtdAdaptadorDados()
                ' cria tres itens e tres conjuntos de subitems para cada item
                For contador As Integer = 0 To bcmb.Items.Count - 1 Step 1
                    bcmb.Items.RemoveAt(0)
                Next
                For contador As Integer = 0 To numMaxRegistro - 1 Step 1
                    objBDPrincipal.mtdProximoRegistro()
                    bcmb.Items.Add(objBDPrincipal.mtdObterValorRegistro(0))
                Next
                objBDPrincipal.mtdFecharConexao()
            Catch
            End Try
        End Sub

        Private Sub mtdPreencherBcmb45Coletor(ByVal strSQL As String, ByRef bcmb As ToolStripComboBox)
            Try
                Dim objBDColetor As New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosColetor, strSQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)
                objBDColetor.mtdAbrirConexao()
                objBDColetor.mtdExecutarComando()
                Dim numMaxRegistro As Integer = objBDColetor.mtdNumeroLinhas()
                objBDColetor.mtdDefinirLeitorDados()
                objBDColetor.prpAjustadorDados = New DataSet()
                objBDColetor.mtdAdaptadorDados()
                ' cria tres itens e tres conjuntos de subitems para cada item
                For contador As Integer = 0 To bcmb.Items.Count - 1 Step 1
                    bcmb.Items.RemoveAt(0)
                Next
                For contador As Integer = 0 To numMaxRegistro - 1 Step 1
                    objBDColetor.mtdProximoRegistro()
                    bcmb.Items.Add(objBDColetor.mtdObterValorRegistro(0))
                Next
                objBDColetor.mtdFecharConexao()
            Catch
            End Try
        End Sub

        Public Function imageToByteArray(ByVal imageIn As System.Drawing.Image) As Byte()
            Dim MS As System.IO.MemoryStream = New System.IO.MemoryStream()
            imageIn.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)
            Return MS.ToArray()
        End Function

        Public Function byteArrayToImage(ByVal byteArrayIn As Byte()) As System.Drawing.Image
            Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream(byteArrayIn)
            Dim returnImage As System.Drawing.Image = Image.FromStream(ms)
            Return returnImage
        End Function

        Private Function mtdGerarSQLUsuario(ByVal Campo As String, ByVal Dado As String) As String
            Dim strSQL As String = String.Format _
            ( _
            "SELECT DISTINCT tblCentroCusto.CentroCusto, tblCentroCusto.Orgao, tblEmpregados.Endereco, tblEmpregados.Nome, tblEmpregados.Matricula FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao = tblCentroCusto.Orgao GROUP BY tblCentroCusto.CentroCusto, tblCentroCusto.Orgao, tblEmpregados.Endereco, tblEmpregados.Nome, tblEmpregados.Matricula HAVING ((({0}) LIKE {1}));", _
            Campo, _
            Dado _
            )
            Return strSQL
        End Function

        Private Function mtdGerarSQLBens(ByVal Campo As String, ByVal Dado As String) As String
            Campo = CStr(IIf(Campo = "tblBensEletronorte.Denominacao", "([tblBensEletronorte]![Denominacao] & ' ' & [tblBensEletronorte]![Denominacao_Extra])", Campo))

            Dim strSQL As String = String.Format _
            ( _
            "SELECT DISTINCT tblBensEletronorte.Patrimonio, ([tblBensEletronorte]![Denominacao] & ' ' & [tblBensEletronorte]![Denominacao_Extra]) AS Denominacao, tblBensEletronorte.N_Serie FROM(tblBensEletronorte) GROUP BY tblBensEletronorte.Patrimonio, ([tblBensEletronorte]![Denominacao] & ' ' & [tblBensEletronorte]![Denominacao_Extra]), tblBensEletronorte.N_Serie HAVING ((({0}) LIKE {1}));", _
            Campo, _
            Dado _
            )
            Return strSQL
        End Function

        Private Sub mtdAtualizarDtgv1(ByVal Coluna As String, ByVal Dado As String)
            mtdAtualizarDtgv1(Coluna, Dado, bcmb3.Items(1).ToString())
        End Sub

        Private Sub mtdAtualizarDtgv1(ByVal Coluna As String, ByVal Dado As String, ByVal BcmbTexto As String)
            Try

                Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosPrincipal, _
                                                                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(strConexaoBancoDadosColetor, _
                                                                           clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

                Dim blnCuringa As Boolean = True
                'Dim vetColunas As String()
                Dim vetTipoColunas As String() = Nothing
                Dim strDado As String = String.Empty

                Dim intNumeroColuna As Integer = 0
                Dim strFormatoTipo As String = String.Empty
                Dim strFormatoCuringa As String = String.Empty

                Select Case BcmbTexto
                    Case "Campo Inteiro"
                        blnCuringa = False
                    Case "Qualquer Parte do Campo"
                        blnCuringa = True
                End Select

                Select Case bcmb1.Text
                    Case bcmb1.Items(0).ToString()
                        objBDPrincipal.mtdSelecionarDados("1", "*", strNomeTabelaPrincipal)
                        objBDPrincipal.mtdDefinirLeitorDados()
                        objBDPrincipal.mtdProximoRegistro()
                        objBDPrincipal.mtdObterTipoRegistro(vetTipoColunas)

                        intNumeroColuna = objBDPrincipal.mtdObterNumeroColuna(Coluna)
                        'strFormatoTipo = mtdObterFormatoTipo(vetTipoColunas(intNumeroColuna))
                        strFormatoTipo = "'{0}'"
                        strFormatoCuringa = String.Format(strFormatoTipo, If(blnCuringa, "%{0}%", "{0}"))
                        strDado = String.Format(strFormatoCuringa, Dado)

                        objBDPrincipal.mtdSelecionarDados("*", _
                                                                     strNomeTabelaPrincipal, _
                                                                     Coluna, _
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
                    Case bcmb1.Items(1).ToString()
                        objBDColetor.mtdSelecionarDados("(1)", "*", strNomeTabelaColetor)
                        objBDColetor.mtdDefinirLeitorDados()
                        objBDColetor.mtdProximoRegistro()
                        objBDColetor.mtdObterTipoRegistro(vetTipoColunas)

                        intNumeroColuna = objBDColetor.mtdObterNumeroColuna(Coluna)
                        'strFormatoTipo = mtdObterFormatoTipo(vetTipoColunas(intNumeroColuna))
                        strFormatoTipo = "'{0}'"
                        strFormatoCuringa = String.Format(strFormatoTipo, If(blnCuringa, "%{0}%", "{0}"))
                        strDado = String.Format(strFormatoCuringa, Dado)

                        objBDColetor.mtdSelecionarDados("*", _
                                                                     strNomeTabelaColetor, _
                                                                     Coluna, _
                                                                     "LIKE", _
                                                                     strDado, _
                                                                     strColunaColetor, _
                                                                     True)

                        objBDColetor.mtdDefinirLeitorDados()
                        objBDColetor.mtdProximoRegistro()
                        objBDColetor.mtdAdaptadorDados()
                        dtgv1.DataSource = objBDColetor.prpTabelaDados
                        blnadicaolinha = False
                        numColunaDR = objBDColetor.mtdNumeroColunas() - 1
                        maxlinha = objBDColetor.mtdNumeroLinhas()
                End Select

                objBDPrincipal.Dispose()
                objBDColetor.Dispose()

                mtddtgv1Clicar(numlinhaselecionada)

                dtgv1.FirstDisplayedCell = dtgv1.Item(0, dtgv1.RowCount - 1)

                mtdAtualizarTs()
            Catch
            End Try
        End Sub

        Private Sub mtdSalvar()
            Try
                dtgv1.Item(1, dtgv1.SelectedCells(0).RowIndex).Selected = True
                dtgv1.BeginEdit(True)
                dtgv1.EndEdit()
            Catch
            End Try
        End Sub

        Private Sub bcmb2_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb2.DropDown

        End Sub

        Private Sub bcmb2_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb2.DropDownClosed
            'mtdPreencherLsv1(bcmb2.Text)
        End Sub

        Private Function mtdPreencherLsv1(ByVal CampoSelecionado As String) As String
            Dim SQL As String = String.Empty

            Try
                Dim CampoContador As String = "Contador"
                lsv1.Clear()
                'define o modo de exibição do listview 
                lsv1.View = System.Windows.Forms.View.Details
                ' permite o usuario editar o item
                lsv1.LabelEdit = False
                ' permite o usuario rearranjar as colunas
                lsv1.AllowColumnReorder = True
                ' exibe as caixas de marcacao (check boxes.)
                lsv1.CheckBoxes = True
                ' seleciona um item e subitem quando a seleção é feita
                lsv1.FullRowSelect = True
                ' exibe as linhas
                lsv1.GridLines = True
                ' ordena os itens na list na ordem ascendente
                Select Case bcmb1.Text
                    Case bcmb1.Items(0).ToString()
                        Dim objBDPrincipal As New clsImplementacaoBancoDados _
                        ( _
                        frmPrincipal.strConexaoBancoDadosPrincipal, _
                        String.Format _
                        ( _
                        "SELECT DISTINCT {0}, COUNT({0}) AS {1} FROM {2} GROUP BY {0} ORDER BY {0};", _
                        CampoSelecionado, _
                        CampoContador, _
                        strNomeTabelaPrincipal _
                        ), _
                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
                        )
                        objBDPrincipal.mtdAbrirConexao()
                        objBDPrincipal.mtdExecutarComando()
                        SQL = objBDPrincipal.prpComando
                        Dim numMaxRegistro As Integer = objBDPrincipal.mtdNumeroLinhas() - 1
                        objBDPrincipal.prpAjustadorDados = New DataSet()
                        objBDPrincipal.mtdAdaptadorDados()
                        objBDPrincipal.mtdDefinirLeitorDados()
                        Dim numColuna As Integer = objBDPrincipal.mtdNumeroColunas() - 1

                        lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(0), 150, HorizontalAlignment.Left)
                        lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(1), 100, HorizontalAlignment.Left)

                        Dim numLinha As Integer = 0

                        While objBDPrincipal.mtdProximoRegistro()
                            For contador As Integer = 0 To numColuna Step 1
                                Dim item As ListViewItem = Nothing
                                Dim subitem As ListViewItem.ListViewSubItem = Nothing
                                If contador = 0 Then
                                    item = New ListViewItem(objBDPrincipal.mtdObterValorRegistro(contador).ToString(), 0)
                                    lsv1.Items.Add(item)
                                Else
                                    subitem = New ListViewItem.ListViewSubItem()
                                    subitem.Text = objBDPrincipal.mtdObterValorRegistro(contador).ToString()
                                    lsv1.Items(numLinha).SubItems.Add(subitem)
                                End If
                            Next
                            numLinha += 1
                            System.Threading.Thread.Sleep(1)
                        End While

                        objBDPrincipal.mtdFecharConexao()
                    Case bcmb1.Items(1).ToString()
                        Dim objBDColetor As New clsImplementacaoBancoDados _
                        ( _
                        frmPrincipal.strConexaoBancoDadosColetor, _
                        String.Format _
                        ( _
                        "SELECT DISTINCT {0}, COUNT({0}) AS {1} FROM {2} GROUP BY {0} ORDER BY {0};", _
                        CampoSelecionado, _
                        CampoContador, _
                        strNomeTabelaColetor _
                        ), _
                        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE _
                        )
                        objBDColetor.mtdAbrirConexao()
                        objBDColetor.mtdExecutarComando()
                        SQL = objBDColetor.prpComando
                        Dim numMaxRegistro As Integer = objBDColetor.mtdNumeroLinhas() - 1
                        objBDColetor.prpAjustadorDados = New DataSet()
                        objBDColetor.mtdAdaptadorDados()
                        objBDColetor.mtdDefinirLeitorDados()
                        Dim numColuna As Integer = objBDColetor.mtdNumeroColunas() - 1

                        lsv1.Columns.Add(objBDColetor.mtdObterCabecalhoColunas(0), 150, HorizontalAlignment.Left)
                        lsv1.Columns.Add(objBDColetor.mtdObterCabecalhoColunas(1), 100, HorizontalAlignment.Left)

                        Dim numLinha As Integer = 0

                        While objBDColetor.mtdProximoRegistro()
                            For contador As Integer = 0 To numColuna Step 1
                                Dim item As ListViewItem = Nothing
                                Dim subitem As ListViewItem.ListViewSubItem = Nothing
                                If contador = 0 Then
                                    item = New ListViewItem(objBDColetor.mtdObterValorRegistro(contador).ToString(), 0)
                                    lsv1.Items.Add(item)
                                Else
                                    subitem = New ListViewItem.ListViewSubItem()
                                    subitem.Text = objBDColetor.mtdObterValorRegistro(contador).ToString()
                                    lsv1.Items(numLinha).SubItems.Add(subitem)
                                End If
                            Next
                            numLinha += 1
                            System.Threading.Thread.Sleep(1)
                        End While

                        objBDColetor.mtdFecharConexao()
                End Select

                ' marca o ckeckbox para o item
                'item.Checked = True
                grpb1.Controls.Add(lsv1)
            Catch
            End Try

            Return SQL
        End Function

        Private Sub btxt1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btxt1.Click
            'mtdAtualizarDtgv1(bcmb2.Text, btxt1.Text, bcmb3.Text, "0")
        End Sub

        Private Sub btxt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btxt1.TextChanged
            'mtdAtualizarDtgv1(bcmb2.Text, btxt1.Text, bcmb3.Text)
        End Sub

        Private Sub btxt1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btxt1.KeyDown
            If (e.KeyCode = Keys.Enter) Then
                mtdAtualizarDtgv1(bcmb2.Text, btxt1.Text, bcmb3.Text, "0")
            End If
        End Sub

        Private Function mtdCalcularCodigoEspalhamentoPrincipal(ByVal Tabela As String, ByVal CampoSelecionador As String, ByVal Dado As String) As Long
            Dim saida As Long = 0

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            frmPrincipal.strConexaoBancoDadosPrincipal, _
            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
            )

            objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoOleDb(0, "*", Tabela, CampoSelecionador, "LIKE", Dado)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()
            Dim numColunas As Integer = objImplementacaoBancoDados.mtdNumeroColunas()

            If objImplementacaoBancoDados.mtdProximoRegistro() Then
                For coluna As Integer = 1 To numColunas - 1 Step 1
                    saida = saida Xor mtdObterCodigoEspalhamento(objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString())
                Next
            End If

            objImplementacaoBancoDados.Dispose()

            Return saida
        End Function

        Private Function mtdCalcularCodigoEspalhamentoColetor(ByVal Tabela As String, ByVal CampoSelecionador As String, ByVal Dado As String) As Long
            Dim saida As Long = 0

            Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
            ( _
            frmPrincipal.strConexaoBancoDadosColetor, _
            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE _
            )

            objImplementacaoBancoDados.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", Tabela, CampoSelecionador, "LIKE", Dado)
            objImplementacaoBancoDados.mtdDefinirLeitorDados()
            Dim numColunas As Integer = objImplementacaoBancoDados.mtdNumeroColunas()

            If objImplementacaoBancoDados.mtdProximoRegistro() Then
                For coluna As Integer = 1 To numColunas - 1 Step 1
                    saida = saida Xor mtdObterCodigoEspalhamento(objImplementacaoBancoDados.mtdObterValorRegistro(coluna).ToString())
                Next
            End If

            objImplementacaoBancoDados.Dispose()

            Return saida
        End Function

        Public Function mtdVerificarDataMaisAtualTabelaInventarioBensPrincipalColetor(ByVal coluna As Integer, ByVal CampoSelecionador As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = False

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                            strConexaoBancoDadosPrincipal, _
                                                            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                            strConexaoBancoDadosColetor, _
                                                            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            objBDPrincipal.mtdSelecionarDadosParametroComandoOleDb(0, "*", strNomeTabelaPrincipal, CampoSelecionador, "LIKE", Dado)
            objBDPrincipal.mtdDefinirLeitorDados()
            objBDPrincipal.mtdProximoRegistro()
            objBDColetor.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", strNomeTabelaColetor, CampoSelecionador, "LIKE", Dado)
            objBDColetor.mtdDefinirLeitorDados()
            objBDColetor.mtdProximoRegistro()

            If objBDPrincipal.mtdObterValorRegistro(coluna) IsNot Nothing Then
                If objBDColetor.mtdObterValorRegistro(coluna) IsNot Nothing Then
                    If System.Convert.ToDateTime(System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(coluna))).Ticks > System.Convert.ToDateTime(System.Convert.ToString(objBDColetor.mtdObterValorRegistro(coluna))).Ticks Then
                        saida = True
                    Else
                        saida = False
                    End If
                End If
            End If

            objBDPrincipal.Dispose()
            objBDColetor.Dispose()
            Return saida
        End Function

        Public Function mtdVerificarDataMaisAtualTabelaInventarioBensColetorPrincipal(ByVal coluna As Integer, ByVal CampoSelecionador As String, ByVal Dado As Object) As Boolean
            Dim saida As Boolean = False

            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                            strConexaoBancoDadosPrincipal, _
                                                            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            Dim objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                            strConexaoBancoDadosColetor, _
                                                            clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            objBDPrincipal.mtdSelecionarDadosParametroComandoOleDb(0, "*", strNomeTabelaPrincipal, CampoSelecionador, "LIKE", Dado)
            objBDPrincipal.mtdDefinirLeitorDados()
            objBDPrincipal.mtdProximoRegistro()
            objBDColetor.mtdSelecionarDadosParametroComandoSQLServerCE(0, "*", strNomeTabelaColetor, CampoSelecionador, "LIKE", Dado)
            objBDColetor.mtdDefinirLeitorDados()
            objBDColetor.mtdProximoRegistro()
            If objBDPrincipal.mtdObterValorRegistro(coluna) IsNot Nothing Then
                If objBDColetor.mtdObterValorRegistro(coluna) IsNot Nothing Then

                    If System.Convert.ToDateTime(System.Convert.ToString(objBDColetor.mtdObterValorRegistro(coluna))).Ticks > System.Convert.ToDateTime(System.Convert.ToString(objBDPrincipal.mtdObterValorRegistro(coluna))).Ticks Then
                        saida = True
                    Else
                        saida = False
                    End If
                End If
            End If

            objBDPrincipal.Dispose()
            objBDColetor.Dispose()
            Return saida
        End Function

        Private Sub blbl4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blbl4.Click
            Try
                If MessageBox.Show("Deseja realmente alterar todas linhas referidas as linhas referidas?", "Aviso!", _
                            MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                    If (lsv1.Columns.Count > 0) Then
                        If (lsv1.Items.Count > 0) Then
                            Dim numLinha As Integer = dtgv1.RowCount
                            For linha As Integer = 0 To numLinha - 2 Step 1
                                dtgv1.Item(dtgv1.Columns(bcmb4.Text).Index, linha).Value = btxt2.Text
                                dtgv1.Item(dtgv1.Columns(bcmb4.Text).Index, linha).Selected = True
                                dtgv1.BeginEdit(True)
                                dtgv1.EndEdit()
                            Next
                        End If
                    End If
                End If
            Catch ex As System.Exception
                MessageBox.Show("Escolha um campo a ser alterado.", "Aviso!", MessageBoxButtons.OK)
            End Try
        End Sub

        Public Function mtdObterCodigoEspalhamento(ByVal Dado As String) As Long
            Dim saida As Long = 0
            Dim algorithm As System.Security.Cryptography.HashAlgorithm = System.Security.Cryptography.SHA1.Create()
            Dim vetData As Byte() = Encoding.Unicode.GetBytes(Dado)
            Dim vetDataHash As Byte() = algorithm.ComputeHash(vetData)
            saida = BitConverter.ToInt64(vetDataHash, 0)

            Return saida
        End Function

        Private Sub ppg1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ppg1.Leave
            'Try
            dtgv1.Item(intColunaTabelaBensImobilizado, numlinhaselecionada).Value = objBens_.Imobilizado
            dtgv1.Item(intColunaTabelaBensPatrimonio, numlinhaselecionada).Value = objBens_.Patrimonio
            dtgv1.Item(intColunaTabelaBensDenominacao, numlinhaselecionada).Value = objBens_.Denominacao
            dtgv1.Item(intColunaTabelaBensDenominacao_Extra, numlinhaselecionada).Value = objBens_.Denominacao
            dtgv1.Item(intColunaTabelaBensN_Serie, numlinhaselecionada).Value = objBens_.N_Serie
            dtgv1.Item(intColunaTabelaBensSala, numlinhaselecionada).Value = objBens_.Sala
            dtgv1.Item(intColunaTabelaBensMatricula, numlinhaselecionada).Value = objBens_.Matricula
            dtgv1.Item(intColunaTabelaBensCentro_Custo, numlinhaselecionada).Value = objBens_.Centro_Custo
            dtgv1.Item(intColunaTabelaBensAtividade, numlinhaselecionada).Value = objBens_.Atividade
            dtgv1.Item(intColunaTabelaBensOrgao, numlinhaselecionada).Value = objBens_.Orgao
            'Catch
            'End Try
        End Sub

        Private Sub tsbEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEmail.Click
            frmPrincipal.mtdEnviarEmail()
        End Sub

        Private Sub blblCarregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blblCarregar.Click
            SQLLsv1 = mtdPreencherLsv1(bcmb2.Text)
        End Sub

        Private numTotalBens As Integer = 0

        Private CampoSelecionador As String = String.Empty
        Private DadoSelecionador As String = String.Empty

        Private intlsv As Integer = 0
        Private blnvetlsv() As Boolean
        Private strvetlsv() As String
        Private strvetlsvsi() As String

        Private Sub mtdPreencherVetorLsv1ContarTotalBens()
            intlsv = lsv1.Items.Count
            blnvetlsv = New Boolean(intlsv - 1) {}
            strvetlsv = New String(intlsv - 1) {}
            strvetlsvsi = New String(intlsv - 1) {}

            numTotalBens = 0

            For contador As Integer = 0 To intlsv - 1 Step 1
                blnvetlsv(contador) = lsv1.Items(contador).Checked
                strvetlsv(contador) = lsv1.Items(contador).Text
                strvetlsvsi(contador) = lsv1.Items(contador).SubItems(1).Text

                If blnvetlsv(contador) Then
                    numTotalBens += System.Convert.ToInt32(strvetlsvsi(contador))
                End If
            Next

            CampoSelecionador = bcmb2.Text
        End Sub

        Public blnIndicadorCrescente As Boolean = True
        Public intColunaSelecionada As Integer = -1
        Public strColunaSelecionada As String = vetCamposTabelaBens(intColunaTabelaBensImobilizado)

        Private Sub mtdOrdenadorPadrao()
            blnIndicadorCrescente = True
            intColunaSelecionada = -1
            strColunaSelecionada = vetCamposTabelaBens(intColunaTabelaBensImobilizado)
        End Sub

        Private Sub dtgv1_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dtgv1.ColumnHeaderMouseClick
            If intColunaSelecionada = -1 Then
                blnIndicadorCrescente = True
            Else
                If e.ColumnIndex = intColunaSelecionada Then
                    blnIndicadorCrescente = blnIndicadorCrescente Xor True
                Else
                    blnIndicadorCrescente = True
                End If
            End If

            intColunaSelecionada = e.ColumnIndex
            strColunaSelecionada = dtgv1.Columns(intColunaSelecionada).Name
        End Sub

        Private Function mtdPreencherLsv1() As String
            Dim SQL As String = String.Empty

            Dim strTabela As String = String.Empty

            If bcmb1.SelectedIndex = 0 Then
                strTabela = strNomeTabelaPrincipal
            ElseIf bcmb1.SelectedIndex = 1 Then
                strTabela = strNomeTabelaColetor
            End If

            Dim strColuna1 As String = bcmb2.Text
            'Dim strColuna1 As String = IIf(bcmb2.SelectedIndex <> 0, bcmb2.Text, vetCamposTabelaBens(intColunaTabelaBensOrgao)).ToString()
            Dim strColuna2 As String = IIf(cmb1.SelectedIndex <> 0, cmb1.Text, vetCamposTabelaBens(intColunaTabelaBensPatrimonio)).ToString()
            Dim strCampoOrdenador As String = strColuna1
            Dim blnOrdenacaoCrescente As Boolean = False

            If strCampoOrdenador = "Numero_Inventario" Then
                blnOrdenacaoCrescente = False
            Else
                blnOrdenacaoCrescente = True
            End If

            If System.Convert.ToInt32(txt1.Text) <= 0 Then
                SQL = frmPrincipal.mtdConsultarItensRepetidosCampoInformado(lsv1, grpb1, strColuna1, strTabela, strTabela, strColuna1, String.Empty, strCampoOrdenador, blnOrdenacaoCrescente, intRepeticaoBens)
            Else
                SQL = frmPrincipal.mtdConsultarItensRepetidosCampoInformado(lsv1, grpb1, strColuna1, strColuna2, strTabela, strTabela, strColuna2, String.Empty, strCampoOrdenador, blnOrdenacaoCrescente, intRepeticaoBens)
            End If

            Return SQL
        End Function

        Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
            SQLLsv1 = mtdPreencherLsv1(bcmb2.Text)
        End Sub

        Private Sub cmb1_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb1.DropDown
            frmPrincipal.mtdPreencherCmb(cmb1, "Todos", vetCamposTabelaBens, intColunaTabelaBensPatrimonio + 1)
        End Sub

        Private Sub txt1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt1.Leave
            Try
                intRepeticaoBens = System.Convert.ToInt32(txt1.Text)
            Catch ex As System.Exception
                txt1.Text = System.Convert.ToString(intRepeticaoBens)

                Dim strExcecao As String = "txt1_Leave: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdLsvSelecao(ByVal IndiceBcmb1 As Integer, ByVal Tabela As String, ByVal Coluna As String, ByVal Dado As String)
            'bcmb1.SelectedIndex = IndiceBcmb1
            bcmb2.Text = Coluna
            btxt1.Text = Dado
        End Sub

        Private lsv1IndiceItemSelecionado As Integer = -1

        Private Sub lsv1_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lsv1.ItemSelectionChanged
            If lsv1.Columns.Count > 0 Then
                If lsv1.Items.Count > 0 Then
                    lsv1IndiceColunaSelecionada = frmPrincipal.mtdObterIndiceColunaClicada(lsv1)
                    lsv1IndiceItemSelecionado = e.ItemIndex

                    Dim strColuna As String = lsv1.Columns(lsv1IndiceColunaSelecionada).Text
                    Dim strDado As String = String.Format("{0}", lsv1.Items(lsv1IndiceItemSelecionado).SubItems(lsv1IndiceColunaSelecionada).Text)

                    If strColuna = "Contador" Then
                        strColuna = lsv1.Columns(0).Text
                        strDado = String.Format("{0}", lsv1.Items(lsv1IndiceItemSelecionado).SubItems(0).Text)
                    End If

                    mtdLsvSelecao(0, strNomeTabelaPrincipal, strColuna, strDado)

                    mtdAtualizarDtgv1(strColuna, String.Format("{0}", strDado), bcmb3.Items(0).ToString(), "0")
                    mtdPreencherPpg1(0)
                    mtdOrdenadorPadrao()
                End If
            End If
        End Sub

        Private Sub lsv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsv1.Click
            Try
            Catch ex As Exception

            End Try
        End Sub

        'Private blnOrdenarCrescente As Boolean = True

        Private lsv1IndiceColunaSelecionada As Integer = -1
        Private SQLLsv1 As String = String.Empty

        Private Sub lsv1_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsv1.ColumnClick
            frmPrincipal.mtdOrdenarColunasLsv(lsv1, SQLLsv1, e.Column)
        End Sub

        Private Sub lsv1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsv1.DoubleClick
            frmPrincipal.mtdChecarItens(lsv1)
        End Sub
    End Class

    ''' <summary>
    ''' Customer class to be displayed in the property grid
    ''' </summary>

    <System.ComponentModel.DefaultPropertyAttribute("Name")> _
    Public Class clsBens

        Private _Imobilizado As String
        Private _Patrimonio As Long
        Private _Denominacao As String
        Private _Denominacao_Extra As String
        Private _N_Serie As String
        Private _Sala As String
        Private _Matricula As Long
        Private _Centro_Custo As Long
        Private _Atividade As String
        Private _Orgao As String

        ' Name property with category attribute and 
        ' description attribute added 
        <System.ComponentModel.CategoryAttribute("Dados Mestre"), System.ComponentModel.DescriptionAttribute("Imobilizado")> _
        Public Property Imobilizado() As String
            Get
                Return _Imobilizado
            End Get
            Set(ByVal value As String)
                _Imobilizado = value
            End Set
        End Property
        <System.ComponentModel.CategoryAttribute("Dados Gerais"), System.ComponentModel.DescriptionAttribute("Patrimônio")> _
        Public Property Patrimonio() As Long
            Get
                Return _Patrimonio
            End Get
            Set(ByVal value As Long)
                _Patrimonio = value
            End Set
        End Property
        <System.ComponentModel.CategoryAttribute("Dados Gerais"), System.ComponentModel.DescriptionAttribute("Denominação")> _
        Public Property Denominacao() As String
            Get
                Return _Denominacao
            End Get
            Set(ByVal value As String)
                _Denominacao = value
            End Set
        End Property
        <System.ComponentModel.CategoryAttribute("Dados Gerais"), System.ComponentModel.DescriptionAttribute("Denominação Extra")> _
        Public Property Denominacao_Extra() As String
            Get
                Return _Denominacao_Extra
            End Get
            Set(ByVal value As String)
                _Denominacao_Extra = value
            End Set
        End Property
        <System.ComponentModel.CategoryAttribute("Dados Gerais"), System.ComponentModel.DescriptionAttribute("Número de Série")> _
        Public Property N_Serie() As String
            Get
                Return _N_Serie
            End Get
            Set(ByVal value As String)
                _N_Serie = value
            End Set
        End Property
        <System.ComponentModel.CategoryAttribute("Controle Físico"), System.ComponentModel.DescriptionAttribute("Sala")> _
        Public Property Sala() As String
            Get
                Return _Sala
            End Get
            Set(ByVal value As String)
                _Sala = value
            End Set
        End Property
        <System.ComponentModel.CategoryAttribute("Controle Físico"), System.ComponentModel.DescriptionAttribute("Matrícula")> _
        Public Property Matricula() As Long
            Get
                Return _Matricula
            End Get
            Set(ByVal value As Long)
                _Matricula = value
            End Set
        End Property
        <System.ComponentModel.CategoryAttribute("Controle Físico"), System.ComponentModel.DescriptionAttribute("Centro Custo")> _
        Public Property Centro_Custo() As Long
            Get
                Return _Centro_Custo
            End Get
            Set(ByVal value As Long)
                _Centro_Custo = value
            End Set
        End Property
        <System.ComponentModel.CategoryAttribute("Estado de Ativação"), System.ComponentModel.DescriptionAttribute("Atividade")> _
        Public Property Atividade() As String
            Get
                Return _Atividade
            End Get
            Set(ByVal value As String)
                _Atividade = value
            End Set
        End Property
        <System.ComponentModel.CategoryAttribute("Controle Físico"), System.ComponentModel.DescriptionAttribute("Órgão")> _
                Public Property Orgao() As String
            Get
                Return _Orgao
            End Get
            Set(ByVal value As String)
                _Orgao = value
            End Set
        End Property
    End Class
End Namespace