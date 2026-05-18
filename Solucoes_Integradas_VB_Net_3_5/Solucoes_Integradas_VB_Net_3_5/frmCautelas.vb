Imports System.Threading

Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmCautelas
        ' Variável de Classe
        Public Shared Codigo As ULong
        ' Variáveis de Instância
        Private objRegistroWindows As clsRegistroWindows = New clsRegistroWindows()
        Private strConexaoBancoDadosPrincipal As String = frmPrincipal.strConexaoBancoDadosPrincipal
        Public strNomeTabelaPrincipal As String = String.Empty
        Public strNomeTabelaCautela As String = "tblCautela"
        Public strNomeTabelaCautelaBens As String = "tblCautelaBens"
        Public strColunaPrincipal As String = String.Empty
        Public strColunaCautela As String = "Codigo"
        Public strColunaCautelaBens As String = "Codigo"
        Private ReadOnly strConexaoBancoDados As String = frmPrincipal.strConexaoBancoDadosPrincipal

        Protected Friend Shared numlinhaselecionada As Integer = 0
        Protected Friend Shared numcolunaselecionada As Integer = 0
        Private objBDPrincipal1 As New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
        Private objBDPrincipal2 As New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
        Private dfrmdtgv1H As Integer
        Private dfrmdtgv1V As Integer
        Private dfrmgrpb1H As Integer
        Private dfrmgrpb1V As Integer
        Private dfrmgrpb2H As Integer
        Private dfrmlsv1H As Integer
        Private ddtgv1Vdtgv2V As Integer
        Private ddtgv2Vlsv1V As Integer
        Private dlsv1frmV As Integer
        Private dgrpb1VlsvCautelaV As Integer
        Private dgrpb2VlsvCautelaBensV As Integer

        Private varHouveRedimensionamento As Boolean = False
        Private numteclapressionada As Integer = 0
        Private numColunaDR1 As Integer
        Private numColunaDR2 As Integer
        Private maxlinha As Integer = 0
        Private intdtgvSelecionado As Integer = 1
        Private intcmbSelecionado As Integer = 0
        Private intModobcmb3 As Integer = 2
        Private intRepeticaoCautela As Integer = 0
        Private intRepeticaoCautelaBens As Integer = 0

        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            strConexaoBancoDadosPrincipal = frmPrincipal.strConexaoBancoDadosPrincipal
        End Sub

        Private strTabelaAuxiliaresTipoPrincipal As String = "tblTabelasAuxiliaresTipo"
        Private strTabelaAuxiliaresPropriedadePrincipal As String = "tblTabelasAuxiliaresPropriedade"
        Private strTabelaAuxiliaresMotivacaoPrincipal As String = "tblTabelasAuxiliaresMotivacao"
        Private strTabelaAuxiliaresConservacaoBensPrincipal As String = "tblTabelasAuxiliaresConservacaoBens"
        Private strColunaTipoPrincipal As String = "Tipo".ToUpper()
        Private strColunaPropriedadePrincipal As String = "Propriedade".ToUpper()
        Private strColunaMotivacaoPrincipal As String = "Motivacao".ToUpper()
        Private strColunaConservacaoBensPrincipal As String = "ConservacaoBens".ToUpper()

        Private Sub frmCautelas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            mtdCriarTabelas()
            'mtdIniciarThreadProgresso()

            objBDPrincipal1.prpConexao = strConexaoBancoDados
            objBDPrincipal1.mtdAbrirConexao()
            objBDPrincipal2.prpConexao = strConexaoBancoDados
            objBDPrincipal2.mtdAbrirConexao()
            bcmb1.Items.Add("Responsável")
            bcmb1.Items.Add("Bens")
            bcmb1.Text = bcmb1.Items(0).ToString()
            bcmb3.Items.Add("Campo Inteiro")
            bcmb3.Items.Add("Qualquer Parte do Campo")
            bcmb3.Text = bcmb3.Items(1).ToString()
            mtdAtualizarDtgv1(strNomeTabelaCautela, "Codigo", frmPrincipal.intNumeroLinhasCautelas)
            mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
            mtdPreencherLsv1()
            mtdCarregarBcmb2()
            If bcmb2.Items.Count > 0 Then
                bcmb2.Text = bcmb2.Items(0).ToString()
            End If
            'dtgv1.SelectionMode() = DataGridViewSelectionMode.CellSelect
            'dtgv2.SelectionMode() = DataGridViewSelectionMode.CellSelect

            mtdPreencherCmb9()
            If cmb9.Items.Count > 0 Then
                If cmb9.Items.Count > 1 Then
                    cmb9.Text = cmb9.Items(1).ToString()
                Else
                    cmb9.Text = cmb9.Items(0).ToString()
                End If
            End If

            cbx1.Checked = False
            cbx2.Checked = False

            frmPrincipal.mtdPreencherCmb(cmb11, "Alteração em Massa", vetCamposTabelaCautelaBens)
            frmPrincipal.mtdPreencherCmb(cmb12, "Todos", vetCamposTabelaCautela, vetCamposTabelaCautelaBens, vetCamposTabelaCautela.Length + intColunaTabelaCautelaBensPatrimonio + 1)
            frmPrincipal.mtdPreencherCmb(cmb13, "Todos", vetCamposTabelaCautela, vetCamposTabelaCautelaBens, vetCamposTabelaCautela.Length + intColunaTabelaCautelaBensPatrimonio + 1)

            txtProcurar.Select()
            txtProcurar.Text = "Pesquisar..."
            txtProcurar.Font = New System.Drawing.Font("Segoe UI", 9, FontStyle.Italic)
            dtgv1.AllowUserToAddRows = False
            dtgv2.AllowUserToAddRows = False
            bcmb4.Text = String.Empty
            bcmb5.Text = String.Empty
            txt1.Text = System.Convert.ToString(intRepeticaoCautela)
            txt2.Text = System.Convert.ToString(intRepeticaoCautelaBens)
            mtdPreencherLsvCautela()
            mtdPreencherLsvCautelaBens()
        End Sub

        Protected Friend Sub mtdCriarTabelas()
            frmPrincipal.objCautela.mtdIniciarThreadCriarTabelaCautela()
            frmPrincipal.objCautela.mtdIniciarThreadCriarTabelaCautelaBens()
        End Sub

        Protected Friend Sub mtdAtualizarDtgv1()
            mtdAtualizarDtgv1(0)
        End Sub

        Protected Friend Sub mtdAtualizarDtgv1(ByVal NumeroLinhas As Integer)
            mtdAtualizarDtgv1(strNomeTabelaCautela, "Codigo", NumeroLinhas)
        End Sub

        Private Sub mtdAtualizarDtgv1(ByVal strNomeTabela As String, ByVal strColuna As String, ByVal NumeroLinhas As Integer)
            mtdAtualizarDtgv1(strNomeTabela, strColuna, String.Empty, "SELECT " & If(NumeroLinhas <> 0, String.Format(" TOP {0} ", NumeroLinhas), String.Empty) & strNomeTabela & ".* FROM " & strNomeTabela & " WHERE " & strNomeTabela & "." & strColuna & " LIKE '%' ORDER BY " & strNomeTabela & "." & strColuna & " DESC;")
        End Sub

        Private Sub mtdAtualizarDtgv1(ByVal strNomeTabela As String, ByVal strColuna As String, ByVal strCondicao As String, ByVal NumeroLinhas As Integer)
            mtdAtualizarDtgv1(strNomeTabela, strColuna, String.Empty, "SELECT " & If(NumeroLinhas <> 0, String.Format(" TOP {0} ", NumeroLinhas), String.Empty) & strNomeTabela & ".* FROM " & strNomeTabela & " WHERE " & strNomeTabela & "." & strColuna & " LIKE " & strCondicao & " ORDER BY " & strNomeTabela & "." & strColuna & " DESC;")
        End Sub

        Private Sub mtdAtualizarDtgv1(ByVal strNomeTabela As String, ByVal strColuna As String, ByVal strCondicao As String, ByVal SQL As String)
            Try
                Me.strNomeTabelaPrincipal = strNomeTabela
                Me.strColunaPrincipal = strColuna
                objBDPrincipal1.prpComando = SQL
                objBDPrincipal1.mtdExecutarComando()
                objBDPrincipal1.mtdDefinirLeitorDados()
                objBDPrincipal1.mtdProximoRegistro()
                objBDPrincipal1.prpAjustadorDados = New DataSet()
                objBDPrincipal1.mtdAdaptadorDados()
                dtgv1.DataSource = objBDPrincipal1.prpAjustadorDados.Tables(0)
                dtgv1.Columns(0).ReadOnly = True
                For contador As Integer = 5 To 8 Step 1
                    dtgv1.Columns(contador).ReadOnly = True
                Next
                numColunaDR1 = objBDPrincipal1.mtdNumeroColunas() - 1
                maxlinha = objBDPrincipal1.mtdNumeroLinhas()
                mtddtgv1Clicar(numlinhaselecionada)
                dtgv1.FirstDisplayedCell = dtgv1.Item(0, 0)
                'dtgv1.FirstDisplayedCell = dtgv1.Item(0, dtgv1.RowCount - 1)

                mtdAtualizarTs(dtgv1)
            Catch
            End Try
        End Sub

        Protected Friend Sub mtdAtualizarDtgv2(ByVal strNomeTabela As String, ByVal strColuna As String)
            Try
                mtdAtualizarDtgv2(strNomeTabela, strColuna, String.Empty, "SELECT " & strNomeTabela & ".* FROM " & strNomeTabela & " WHERE " & strNomeTabela & "." & strColuna & " LIKE '" & dtgv1.Item(0, dtgv1.SelectedCells(0).RowIndex()).Value.ToString() & "' ORDER BY " & strNomeTabela & "." & "Contador" & ";")
            Catch
            End Try
        End Sub

        Private Sub mtdAtualizarDtgv2(ByVal strNomeTabela As String, ByVal strColuna As String, ByVal strCondicao As String)
            mtdAtualizarDtgv2(strNomeTabela, strColuna, String.Empty, "SELECT " & strNomeTabela & ".* FROM " & strNomeTabela & " WHERE " & strNomeTabela & "." & strColuna & " LIKE " & strCondicao & " ORDER BY " & strNomeTabela & "." & strColuna & ";")
        End Sub

        Private Sub mtdAtualizarDtgv2(ByVal strNomeTabela As String, ByVal strColuna As String, ByVal strCondicao As String, ByVal SQL As String)
            Try
                Me.strNomeTabelaPrincipal = strNomeTabela
                Me.strColunaPrincipal = strColuna
                objBDPrincipal2.prpComando = SQL
                objBDPrincipal2.mtdExecutarComando()
                objBDPrincipal2.mtdDefinirLeitorDados()
                objBDPrincipal2.mtdProximoRegistro()
                objBDPrincipal2.prpAjustadorDados = New DataSet()
                objBDPrincipal2.mtdAdaptadorDados()
                dtgv2.DataSource = objBDPrincipal2.prpAjustadorDados.Tables(0)
                For contador As Integer = 0 To 1 Step 1
                    dtgv2.Columns(contador).ReadOnly = True
                Next
                For contador As Integer = 9 To 12 Step 1
                    dtgv2.Columns(contador).ReadOnly = True
                Next
                numColunaDR2 = objBDPrincipal2.mtdNumeroColunas() - 1
                maxlinha = objBDPrincipal2.mtdNumeroLinhas()
                mtddtgv2Clicar(numlinhaselecionada)
                'dtgv2.FirstDisplayedCell = dtgv2.Item(0, 0)
                dtgv2.FirstDisplayedCell = dtgv2.Item(0, dtgv2.RowCount - 1)

                mtdAtualizarTs(dtgv2)
            Catch
            End Try
        End Sub

        Private Sub mtdPreencherLsv1()
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
                If Not dtgv1.Item(4, dtgv1.SelectedCells(0).RowIndex).Value.ToString().Equals("0") Then
                    Dim objBDPrincipal As New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, "SELECT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE (tblEmpregados.Matricula LIKE '" & _
             dtgv1.Item(4, dtgv1.SelectedCells(0).RowIndex).Value.ToString() & "');", clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                    objBDPrincipal.mtdAbrirConexao()
                    objBDPrincipal.mtdExecutarComando()
                    Dim numMaxRegistro As Integer = objBDPrincipal.mtdNumeroLinhas() - 1
                    objBDPrincipal.mtdDefinirLeitorDados()
                    objBDPrincipal.mtdProximoRegistro()
                    objBDPrincipal.prpAjustadorDados = New DataSet()
                    objBDPrincipal.mtdAdaptadorDados()
                    ' cria tres itens e tres conjuntos de subitems para cada item
                    Dim numColuna As Integer = objBDPrincipal.mtdNumeroColunas() - 1
                    Dim vetColuna(numColuna) As String
                    For contador As Integer = 0 To numColuna Step 1
                        If objBDPrincipal.mtdObterValorRegistro(contador).ToString() <> String.Empty Then
                            lsv1.Columns.Add(objBDPrincipal.mtdObterCabecalhoColunas(contador), 100, HorizontalAlignment.Left)
                            vetColuna(contador) = objBDPrincipal.mtdObterValorRegistro(contador).ToString()
                        Else
                            vetColuna(contador) = String.Empty
                        End If
                    Next
                    Dim item As New ListViewItem(vetColuna(0), 0)
                    For contador As Integer = 1 To numColuna Step 1
                        item.SubItems.Add(vetColuna(contador))
                    Next
                    ' marca o ckeckbox para o item
                    'item.Checked = True
                    lsv1.Items.Add(item)
                    Me.Controls.Add(lsv1)
                    SQLLsv1 = objBDPrincipal.prpComando
                    objBDPrincipal.mtdFecharConexao()
                End If
            Catch
            End Try
        End Sub

        Private Sub mtdPreencherBcmb(ByVal strSQL As String, ByRef bcmb As ToolStripComboBox)
            Try
                Dim objBDPrincipal As New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, strSQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objBDPrincipal.mtdAbrirConexao()
                objBDPrincipal.mtdExecutarComando()
                Dim numMaxRegistro As Integer = objBDPrincipal.mtdNumeroLinhas() - 1
                objBDPrincipal.mtdDefinirLeitorDados()
                objBDPrincipal.mtdProximoRegistro()
                objBDPrincipal.prpAjustadorDados = New DataSet()
                objBDPrincipal.mtdAdaptadorDados()
                ' cria tres itens e tres conjuntos de subitems para cada item
                For contador As Integer = 0 To bcmb.Items.Count - 1 Step 1
                    bcmb.Items.RemoveAt(0)
                Next
                Dim numColuna As Integer = objBDPrincipal.mtdNumeroColunas() - 1
                For contador As Integer = 0 To numColuna Step 1
                    bcmb.Items.Add(objBDPrincipal.mtdObterCabecalhoColunas(contador))
                Next
                objBDPrincipal.mtdFecharConexao()
            Catch
            End Try
        End Sub

        Private Sub mtdPreencherBcmb45(ByVal strSQL As String, ByRef bcmb As ToolStripComboBox)
            Try
                Dim objBDPrincipal As New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, strSQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
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

        Private strSQL As String = String.Empty

        Protected Friend Sub mtdAtualizarRegistro()
            mtdAtualizarRegistro(dtgv1, strNomeTabelaCautela, objBDPrincipal1, numColunaDR1)
        End Sub

        Private Sub mtdAtualizarRegistro(ByRef dtgv As DataGridView, ByVal NomeTabela As String, ByRef objBancoDados As clsImplementacaoBancoDados, ByVal numColunaDR As Integer)
            Try
                Dim strSQLColuna As String = String.Empty
                Dim strSQLValor As String = String.Empty
                Dim strSQLParcial As String = String.Empty
                Me.strNomeTabelaPrincipal = NomeTabela
                For coluna As Integer = 0 To numColunaDR Step 1
                    strSQLColuna = dtgv.Columns(coluna).HeaderText
                    strSQLValor = dtgv.Item(coluna, numlinhaselecionada).Value.ToString()
                    Select Case dtgv.Name
                        Case "dtgv1"
                            If Not (coluna = 6 Or (coluna >= 8 And coluna <= 11)) Then
                                strSQLParcial &= strSQLColuna & "='" & strSQLValor & "'"
                            Else
                                strSQLParcial &= strSQLColuna & "=#" & frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime((strSQLValor))) & "#"
                            End If
                        Case "dtgv2"
                            If Not (coluna = 10 Or coluna = 12) Then
                                strSQLParcial &= strSQLColuna & "='" & strSQLValor & "'"
                            Else
                                strSQLParcial &= strSQLColuna & "=#" & frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime((strSQLValor))) & "#"
                            End If
                    End Select
                    If coluna < numColunaDR Then
                        strSQLParcial &= ", "
                    End If
                Next
                strSQL = "UPDATE " & strNomeTabelaPrincipal & " SET " & strSQLParcial & " WHERE " & dtgv.Columns(0).HeaderText & " LIKE '" & _
                dtgv.Item(0, numlinhaselecionada).Value.ToString & "';"
                objBancoDados.mtdExecutarComando(strSQL)
            Catch ex As Exception
                'MessageBox.Show(ex.Message.ToString(), "Aviso!", MessageBoxButtons.OK)
            End Try
        End Sub

        Private Sub mtdAdicionarRegistro(ByRef dtgv As DataGridView, ByVal NomeTabela As String, ByRef objBancoDados As clsImplementacaoBancoDados, ByVal numColunaDR As Integer)
            Me.strNomeTabelaPrincipal = NomeTabela
            Dim strSQLColuna As String = String.Empty
            Dim strSQLValor As String = String.Empty
            Dim strSQLParcial As String = String.Empty
            Select Case dtgv.Name
                Case "dtgv1"
                    Dim strPrazoEntregaCautela As String = objRegistroWindows.mtdObterDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela").ToString()
                    If objRegistroWindows.getmensagemExcecao.Equals("Object reference not set to an instance of an object.") Or objRegistroWindows.getmensagemExcecao = "Não há conteúdo na variável mensagemExcecao." Then
                        objRegistroWindows.mtdSalvarDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela", frmConfiguracoes.PrazoEntregaCautela.ToString(), Microsoft.Win32.RegistryValueKind.DWord)
                        strPrazoEntregaCautela = objRegistroWindows.mtdObterDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela").ToString()
                    End If
                    dtgv.Item(0, numlinhaselecionada).Value = frmPrincipal.mtdGerarProximoNumeroCodigoPrincipal(frmPrincipal.intMultiplicadorCodigoCautelas, NomeTabela, dtgv.Columns(0).HeaderText)
                    If (dtgv.Item(1, numlinhaselecionada).Value.ToString() = String.Empty) Then
                        dtgv.Item(1, numlinhaselecionada).Value = 0
                    End If
                    If (dtgv.Item(4, numlinhaselecionada).Value.ToString() = String.Empty) Then
                        dtgv.Item(4, numlinhaselecionada).Value = 0
                    End If
                    dtgv.Item(5, numlinhaselecionada).Value = frmPrincipal.barlblMostrContUser.Text
                    dtgv.Item(6, numlinhaselecionada).Value = DateTime.Now
                    If (dtgv.Item(12, numlinhaselecionada).Value.ToString() = String.Empty) Then
                        dtgv.Item(12, numlinhaselecionada).Value = strPrazoEntregaCautela
                    End If
                    For coluna As Integer = 0 To numColunaDR - 1 Step 1
                        If (coluna = 0 Or coluna = 1 Or coluna = 4 Or coluna = 5 Or coluna = 6 Or (coluna >= 8 And coluna <= 12)) Then
                            strSQLColuna &= dtgv.Columns(coluna).HeaderText
                            If Not (coluna = 6 Or (coluna >= 8 And coluna <= 11)) Then
                                strSQLValor &= "'" & dtgv.Item(coluna, numlinhaselecionada).Value.ToString() & "'"
                            ElseIf (coluna = 6) Then
                                strSQLValor &= "#" & frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime(dtgv.Item(coluna, numlinhaselecionada).Value.ToString())) & "#"
                            ElseIf (coluna >= 8 And coluna <= 11) Then
                                strSQLValor &= "#1/1/2000#"
                            End If
                            If coluna < numColunaDR - 1 Then
                                strSQLColuna &= ", "
                                strSQLValor &= ", "
                            End If
                        End If
                    Next
                    strSQLParcial = " (" & strSQLColuna.Trim() & ") VALUES (" & strSQLValor & ")"
                    strSQL = "INSERT INTO " & strNomeTabelaPrincipal & strSQLParcial
                    objBancoDados.mtdExecutarComando(strSQL)
                    mtdAtualizarDtgv1(strNomeTabelaCautela, "Codigo", frmPrincipal.intNumeroLinhasCautelas)
                Case "dtgv2"
                    Dim maxContador As ULong = 0
                    Try
                        Codigo = Convert.ToUInt64(dtgv1.Item(0, dtgv1.SelectedCells(0).RowIndex).Value.ToString())
                        objBancoDados.mtdExecutarComando("SELECT * FROM " & NomeTabela & " ORDER BY Contador DESC;")
                        objBancoDados.mtdDefinirLeitorDados()
                        objBancoDados.mtdProximoRegistro()
                        Try
                            maxContador = Convert.ToUInt64(objBancoDados.mtdObterValorRegistro(0))
                            Try
                                objBancoDados.mtdExecutarComando("SELECT * FROM " & NomeTabela & " WHERE Codigo LIKE '" & Codigo & "' ORDER BY Contador DESC;")
                                objBancoDados.mtdDefinirLeitorDados()
                                objBancoDados.mtdProximoRegistro()
                                Dim maxItem As ULong = Convert.ToUInt64(objBancoDados.mtdObterValorRegistro(2))
                                dtgv.Item(2, numlinhaselecionada).Value = maxItem + 1
                            Catch
                                dtgv.Item(2, numlinhaselecionada).Value = 1
                            Finally
                                dtgv.Item(0, numlinhaselecionada).Value = maxContador + 1
                            End Try
                        Catch
                            maxContador = 0
                            dtgv.Item(0, numlinhaselecionada).Value = maxContador
                            dtgv.Item(2, numlinhaselecionada).Value = 1
                        End Try
                    Catch
                    End Try
                    Try
                        dtgv.Item(1, numlinhaselecionada).Value = Codigo
                        If (dtgv.Item(3, numlinhaselecionada).Value.ToString() = String.Empty) Then
                            dtgv.Item(3, numlinhaselecionada).Value = 0
                        End If
                        dtgv.Item(9, numlinhaselecionada).Value = frmPrincipal.barlblMostrContUser.Text
                        dtgv.Item(10, numlinhaselecionada).Value = DateTime.Now
                        For coluna As Integer = 0 To numColunaDR Step 1
                            If ((coluna >= 0 And coluna <= 3) Or coluna = 9 Or coluna = 10 Or coluna = 12) Then
                                strSQLColuna &= dtgv.Columns(coluna).HeaderText
                                If Not (coluna = 10 Or coluna = 12) Then
                                    strSQLValor &= "'" & dtgv.Item(coluna, numlinhaselecionada).Value.ToString() & "'"
                                ElseIf (coluna = 10) Then
                                    strSQLValor &= "#" & frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime(dtgv.Item(coluna, numlinhaselecionada).Value.ToString())) & "#"
                                ElseIf (coluna = 12) Then
                                    strSQLValor &= "#1/1/2000#"
                                End If
                                If coluna < numColunaDR Then
                                    strSQLColuna &= ", "
                                    strSQLValor &= ", "
                                End If
                            End If
                        Next
                        strSQLParcial = " (" & strSQLColuna & ") Values (" & strSQLValor & ")"
                        strSQL = "INSERT INTO " & strNomeTabelaPrincipal & strSQLParcial
                        objBancoDados.mtdExecutarComando(strSQL)
                        mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
                    Catch
                        MessageBox.Show("Selecione uma Cautela, para incluir um bem.", "Aviso!", MessageBoxButtons.OK)
                    End Try

            End Select
        End Sub

        Private Sub mtddtgv1Clicar(ByVal linhaselecionada As Integer)
            Try
                cmb1.Text = dtgv1.Item(3, linhaselecionada).Value.ToString()
                cmb2.Text = dtgv1.Item(4, linhaselecionada).Value.ToString()
                cmb3.Text = dtgv1.Item(2, linhaselecionada).Value.ToString()
                cmb4.Text = dtgv1.Item(1, linhaselecionada).Value.ToString()
                dtxt1.Text = frmPrincipal.mtdVerificarData(dtgv1, 10, linhaselecionada)
                dtxt2.Text = frmPrincipal.mtdVerificarData(dtgv1, 11, linhaselecionada)
                dtxt3.Text = frmPrincipal.mtdVerificarData(dtgv1, 9, linhaselecionada)
                lbl2.Text = dtgv1.Item(0, linhaselecionada).Value.ToString()
                Codigo = Convert.ToUInt64(lbl2.Text)
            Catch
            End Try
        End Sub

        Private Sub mtddtgv2Clicar(ByVal linhaselecionada As Integer)
            Try
                cmb5.Text = dtgv2.Item(3, linhaselecionada).Value.ToString()
                cmb6.Text = dtgv2.Item(4, linhaselecionada).Value.ToString()
                cmb7.Text = dtgv2.Item(5, linhaselecionada).Value.ToString()
                cmb8.Text = dtgv2.Item(6, linhaselecionada).Value.ToString()
                cmb9.Text = dtgv2.Item(7, linhaselecionada).Value.ToString()
                cmb10.Text = dtgv2.Item(8, linhaselecionada).Value.ToString()
                lbl11.Text = dtgv2.Item(0, linhaselecionada).Value.ToString()
            Catch
            End Try
        End Sub

        Private Sub mtdProximo(ByVal dtgv As DataGridView)
            If dtgv.Columns.Count > 0 Then
                If dtgv.Rows.Count > 0 Then
                    maxlinha = dtgv.Rows.Count
                    dtgv.SelectionMode() = DataGridViewSelectionMode.FullRowSelect
                    If numlinhaselecionada < maxlinha - 1 Then
                        numlinhaselecionada += 1
                        dtgv.Item(0, numlinhaselecionada - 1).Selected = False
                        dtgv.Item(0, numlinhaselecionada).Selected = True
                    Else
                        numlinhaselecionada = -1
                        numlinhaselecionada += 1
                        dtgv.Item(0, maxlinha - 1).Selected = False
                        dtgv.Item(0, numlinhaselecionada).Selected = True
                    End If
                    'dtgv.SelectionMode() = DataGridViewSelectionMode.CellSelect

                    mtdAtualizarTs(dtgv)
                End If
            End If
        End Sub

        Private Sub mtdAnterior(ByVal dtgv As DataGridView)
            If dtgv.Columns.Count > 0 Then
                If dtgv.Rows.Count > 0 Then
                    maxlinha = dtgv.Rows.Count
                    dtgv.SelectionMode() = DataGridViewSelectionMode.FullRowSelect
                    If numlinhaselecionada > 0 Then
                        numlinhaselecionada -= 1
                        dtgv.Item(0, numlinhaselecionada + 1).Selected = False
                        dtgv.Item(0, numlinhaselecionada).Selected = True
                    Else
                        numlinhaselecionada = maxlinha
                        numlinhaselecionada -= 1
                        dtgv.Item(0, 0).Selected = False
                        dtgv.Item(0, numlinhaselecionada).Selected = True
                    End If
                    'dtgv.SelectionMode() = DataGridViewSelectionMode.CellSelect

                    mtdAtualizarTs(dtgv)
                End If
            End If
        End Sub

        Private Sub mtdProcurar(ByRef dtgv As DataGridView)
            dtgv.AllowUserToAddRows = False
            Dim strValor As String = String.Empty, EnderecoEncontrado(dtgv.ColumnCount - 1, dtgv.RowCount - 1) As Boolean
            Dim valortxt1 As String = txtProcurar.Text.ToLower
            Dim estiloValorEncontrado As New DataGridViewCellStyle()
            Dim estiloValorNaoEncontrado As New DataGridViewCellStyle()
            Dim selecionar As Boolean = False
            estiloValorEncontrado.BackColor = Color.CadetBlue
            estiloValorEncontrado.ForeColor = Color.Empty
            estiloValorNaoEncontrado.BackColor = Color.Empty
            estiloValorNaoEncontrado.ForeColor = Color.Empty
            If Not txtProcurar.Text = String.Empty Then
                For coluna As Integer = 0 To dtgv.ColumnCount - 1 Step 1
                    For linha As Integer = 0 To dtgv.RowCount - 1 Step 1
                        strValor = dtgv.Item(coluna, linha).Value().ToString
                        strValor = strValor.ToLower
                        If strValor.Contains(valortxt1) Then
                            EnderecoEncontrado(coluna, linha) = True
                        End If
                    Next
                Next
                For coluna As Integer = EnderecoEncontrado.GetLowerBound(0) To EnderecoEncontrado.GetUpperBound(0)
                    For linha As Integer = EnderecoEncontrado.GetLowerBound(1) To EnderecoEncontrado.GetUpperBound(1)
                        If EnderecoEncontrado(coluna, linha) Then
                            dtgv.Item(coluna, linha).Style = estiloValorEncontrado
                            If Not selecionar Then
                                dtgv.Item(coluna, linha).Selected = True
                                selecionar = True
                            End If
                        Else
                            dtgv.Item(coluna, linha).Style = estiloValorNaoEncontrado
                        End If
                    Next
                Next
            Else
                For coluna As Integer = EnderecoEncontrado.GetLowerBound(0) To EnderecoEncontrado.GetUpperBound(0)
                    For linha As Integer = EnderecoEncontrado.GetLowerBound(1) To EnderecoEncontrado.GetUpperBound(1)
                        dtgv.Item(coluna, linha).Style = estiloValorNaoEncontrado
                    Next
                Next
            End If
        End Sub

        Private Sub mtdExcluir(ByRef dtgv As DataGridView, ByRef objBancoDados As clsImplementacaoBancoDados, ByVal strSQL As String)
            Select Case dtgv.Name
                Case "dtgv1"
                    objBancoDados.mtdExecutarComando(strSQL)
                    objBancoDados.mtdExecutarComando("DELETE FROM tblCautelaBens WHERE Codigo LIKE '" & dtgv.Item(0, dtgv.SelectedCells(0).RowIndex).Value.ToString() & "';")
                Case "dtgv2"
                    objBancoDados.mtdExecutarComando(strSQL)
            End Select
            Try
                dtgv.Rows.RemoveAt(numlinhaselecionada)
            Catch ex As Exception

            End Try
        End Sub

        Private Sub mtdExcluir(ByRef dtgv As DataGridView, ByRef objBancoDados As clsImplementacaoBancoDados, ByVal strSQL As String, ByVal Codigo As Long)
            Select Case dtgv.Name
                Case "dtgv1"
                    objBancoDados.mtdExecutarComando(strSQL)
                    objBancoDados.mtdExecutarComando("DELETE FROM tblCautelaBens WHERE Codigo LIKE '" & Codigo & "';")
                Case "dtgv2"
                    objBancoDados.mtdExecutarComando(strSQL)
            End Select
            Try
                dtgv.Rows.RemoveAt(numlinhaselecionada)
            Catch ex As Exception

            End Try
        End Sub

        Private Sub tsbExcluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExcluir.Click
            Select Case intdtgvSelecionado
                Case 1
                    Try
                        Dim bcmb4text As String = bcmb4.Text
                        Dim bcmb5text As String = bcmb5.Text
                        Dim elemento As System.Windows.Forms.ComboBox.ObjectCollection = bcmb4.Items

                        If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                            If MessageBox.Show("Deseja realmente deletar as linhas referidas?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                If Int32.Parse(bcmb4text) >= Int32.Parse(bcmb5text) Then
                                    bcmb4text = bcmb5.Text
                                    bcmb5text = bcmb4.Text
                                End If
                                'If Int32.Parse(bcmb4text) < Int32.Parse(dtgv1.Item(0, 0).Value.ToString()) Then
                                '    bcmb4text = dtgv1.Item(0, 0).Value.ToString()
                                'ElseIf Int32.Parse(bcmb5text) > Int32.Parse(dtgv1.Item(0, dtgv1.RowCount - 1).Value.ToString()) Then
                                '    bcmb5text = dtgv1.Item(0, dtgv1.RowCount - 1).Value.ToString()
                                'End If
                                If Int32.Parse(bcmb4text) < Int32.Parse(dtgv1.Item(0, dtgv1.RowCount - 1).Value.ToString()) Then
                                    bcmb4text = dtgv1.Item(0, dtgv1.RowCount - 1).Value.ToString()
                                ElseIf Int32.Parse(bcmb5text) > Int32.Parse(dtgv1.Item(0, 0).Value.ToString()) Then
                                    bcmb5text = dtgv1.Item(0, 0).Value.ToString()
                                End If

                                For contador As Integer = 0 To elemento.Count - 1 Step 1
                                    If Convert.ToInt32(elemento(contador).ToString()) >= Int32.Parse(bcmb4text) And Convert.ToInt32(elemento(contador).ToString()) <= Int32.Parse(bcmb5text) Then
                                        mtdExcluir(dtgv1, objBDPrincipal1, "DELETE FROM tblCautela WHERE Codigo LIKE " & elemento(contador).ToString(), Convert.ToInt32(elemento(contador)))
                                    End If
                                Next
                                mtdAtualizarDtgv1(strNomeTabelaCautela, "Codigo", frmPrincipal.intNumeroLinhasCautelas)
                                mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
                                If numlinhaselecionada <> 0 Then
                                    lbl2.Text = dtgv1.Item(0, numlinhaselecionada - 1).Value.ToString()
                                    dtgv1.Item(0, numlinhaselecionada - 1).Selected = True
                                End If
                            End If
                        Else
                            Dim vetBlnLsvCautela() As Boolean = New Boolean(lsvCautela.Items.Count) {}

                            For contador As Integer = 0 To lsvCautela.Items.Count - 1 Step 1
                                If lsvCautela.Items(contador).Checked Then
                                    vetBlnLsvCautela(contador + 1) = lsvCautela.Items(contador).Checked
                                Else
                                    vetBlnLsvCautela(contador + 1) = Nothing
                                End If
                            Next

                            If vetBlnLsvCautela.Contains(True) Then
                                If (lsvCautela.Columns.Count > 0) Then
                                    If (lsvCautela.Items.Count > 0) Then
                                        If MessageBox.Show("Deseja realmente deletar as linhas referidas?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                            For contador As Integer = 0 To lsvCautela.Items.Count - 1 Step 1
                                                If lsvCautela.Items(contador).Checked Then
                                                    mtdExcluir(dtgv1, objBDPrincipal1, String.Format("DELETE FROM {0} WHERE {1} LIKE {2}", frmMBPs.strNomeTabelaMBP, lsvCautela.Columns(0).Text, String.Format("'{0}'", lsvCautela.Items(contador).Text)), System.Convert.ToInt64(lsvCautela.Items(contador).Text))
                                                End If
                                            Next
                                        End If
                                    End If
                                End If
                            Else
                                If MessageBox.Show("Deseja realmente deletar a linha selecionada?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                    If dtgv1.AllowUserToDeleteRows Then
                                        Try
                                            mtdExcluir(dtgv1, objBDPrincipal1, "DELETE FROM tblCautela WHERE Codigo LIKE " & dtgv1.Rows(numlinhaselecionada).Cells(0).Value.ToString())
                                        Catch
                                            MessageBox.Show("Não há itens a serem excluídos.", "Aviso!", MessageBoxButtons.OK)
                                        End Try
                                        mtdAtualizarDtgv1(strNomeTabelaCautela, "Codigo", frmPrincipal.intNumeroLinhasCautelas)
                                        mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
                                        If numlinhaselecionada <> 0 Then
                                            lbl2.Text = dtgv1.Item(0, numlinhaselecionada - 1).Value.ToString()
                                            dtgv1.Item(0, numlinhaselecionada - 1).Selected = True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Catch
                        If MessageBox.Show("Deseja realmente deletar a linha selecionada?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                            If dtgv1.AllowUserToDeleteRows Then
                                Try
                                    mtdExcluir(dtgv1, objBDPrincipal1, "DELETE FROM tblCautela WHERE Codigo LIKE " & dtgv1.Rows(numlinhaselecionada).Cells(0).Value.ToString())
                                Catch
                                    MessageBox.Show("Não há itens a serem excluídos.", "Aviso!", MessageBoxButtons.OK)
                                End Try
                                mtdAtualizarDtgv1(strNomeTabelaCautela, "Codigo", frmPrincipal.intNumeroLinhasCautelas)
                                mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
                                If numlinhaselecionada <> 0 Then
                                    lbl2.Text = dtgv1.Item(0, numlinhaselecionada - 1).Value.ToString()
                                    dtgv1.Item(0, numlinhaselecionada - 1).Selected = True
                                End If
                            End If
                        End If
                    End Try
                Case 2
                    Try
                        Dim bcmb4text As String = bcmb4.Text
                        Dim bcmb5text As String = bcmb5.Text
                        Dim elemento As System.Windows.Forms.ComboBox.ObjectCollection = bcmb4.Items

                        If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                            If MessageBox.Show("Deseja realmente deletar as linhas referidas?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                If Int32.Parse(bcmb4text) >= Int32.Parse(bcmb5text) Then
                                    bcmb4text = bcmb5.Text
                                    bcmb5text = bcmb4.Text
                                End If
                                If Int32.Parse(bcmb4text) < Int32.Parse(dtgv2.Item(0, 0).Value.ToString()) Then
                                    bcmb4text = dtgv2.Item(0, 0).Value.ToString()
                                ElseIf Int32.Parse(bcmb5text) > Int32.Parse(dtgv2.Item(0, dtgv2.RowCount - 1).Value.ToString()) Then
                                    bcmb5text = dtgv2.Item(0, dtgv2.RowCount - 1).Value.ToString()
                                End If

                                For contador As Integer = 0 To elemento.Count - 1 Step 1
                                    If Convert.ToInt32(elemento(contador).ToString()) >= Int32.Parse(bcmb4text) And Convert.ToInt32(elemento(contador).ToString()) <= Int32.Parse(bcmb5text) Then
                                        mtdExcluir(dtgv2, objBDPrincipal2, "DELETE FROM tblCautelaBens WHERE Contador LIKE " & elemento(contador).ToString(), Convert.ToInt32(elemento(contador)))
                                    End If
                                Next
                                mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
                                If numlinhaselecionada <> 0 Then
                                    lbl11.Text = dtgv2.Item(0, numlinhaselecionada - 1).Value.ToString()
                                    dtgv2.Item(0, numlinhaselecionada - 1).Selected = True
                                End If
                            End If
                        Else
                            Dim vetBlnLsvCautelaBens() As Boolean = New Boolean(lsvCautelaBens.Items.Count) {}

                            For contador As Integer = 0 To lsvCautelaBens.Items.Count - 1 Step 1
                                If lsvCautelaBens.Items(contador).Checked Then
                                    vetBlnLsvCautelaBens(contador + 1) = lsvCautelaBens.Items(contador).Checked
                                Else
                                    vetBlnLsvCautelaBens(contador + 1) = Nothing
                                End If
                            Next

                            If vetBlnLsvCautelaBens.Contains(True) Then
                                If (lsvCautelaBens.Columns.Count > 2) Then
                                    If (lsvCautelaBens.Items.Count > 0) Then
                                        If MessageBox.Show("Deseja realmente deletar as linhas referidas?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                            For contador As Integer = 0 To lsvCautelaBens.Items.Count - 1 Step 1
                                                If lsvCautelaBens.Items(contador).Checked Then
                                                    mtdExcluir(dtgv2, objBDPrincipal2, String.Format("DELETE FROM {0} WHERE {1} LIKE {2} AND {3} LIKE {4}", strNomeTabelaCautelaBens, lsvCautelaBens.Columns(0).Text, String.Format("'{0}'", lsvCautelaBens.Items(contador).Text), lsvCautelaBens.Columns(1).Text, String.Format("'{0}'", lsvCautelaBens.Items(contador).SubItems(1).Text)))
                                                End If
                                            Next
                                        End If
                                    End If
                                End If
                            Else
                                If MessageBox.Show("Deseja realmente deletar a linha selecionada?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                    If dtgv2.AllowUserToDeleteRows Then
                                        Try
                                            mtdExcluir(dtgv2, objBDPrincipal2, "DELETE FROM tblCautelaBens WHERE Contador LIKE " & dtgv2.Rows(numlinhaselecionada).Cells(0).Value.ToString())
                                        Catch
                                            MessageBox.Show("Não há itens a serem excluídos.", "Aviso!", MessageBoxButtons.OK)
                                        End Try
                                        mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
                                        If numlinhaselecionada <> 0 Then
                                            lbl11.Text = dtgv2.Item(0, numlinhaselecionada - 1).Value.ToString()
                                            dtgv2.Item(0, numlinhaselecionada - 1).Selected = True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Catch
                        If MessageBox.Show("Deseja realmente deletar a linha selecionada?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                            If dtgv2.AllowUserToDeleteRows Then
                                Try
                                    mtdExcluir(dtgv2, objBDPrincipal2, "DELETE FROM tblCautelaBens WHERE Contador LIKE " & dtgv2.Rows(numlinhaselecionada).Cells(0).Value.ToString())
                                Catch
                                    MessageBox.Show("Não há itens a serem excluídos.", "Aviso!", MessageBoxButtons.OK)
                                End Try
                                mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
                                If numlinhaselecionada <> 0 Then
                                    lbl11.Text = dtgv2.Item(0, numlinhaselecionada - 1).Value.ToString()
                                    dtgv2.Item(0, numlinhaselecionada - 1).Selected = True
                                End If
                            End If
                        End If
                    End Try
            End Select
            Try
                bcmb4.Items.Add(String.Empty)
                bcmb4.Text = bcmb4.Items(0).ToString()
                bcmb4.Items.RemoveAt(0)
                bcmb5.Items.Add(String.Empty)
                bcmb5.Text = bcmb5.Items(0).ToString()
                bcmb5.Items.RemoveAt(0)
            Catch ex As Exception

            Finally
                mtdPreencherLsvCautela()
                mtdPreencherLsvCautelaBens()
            End Try
        End Sub

        Private Sub txtProcurar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProcurar.TextChanged
            Select Case intdtgvSelecionado
                Case 1
                    If txtProcurar.Text.Length Mod 4 = 0 Then
                        mtdProcurar(dtgv1)
                    End If
                Case 2
                    If txtProcurar.Text.Length Mod 4 = 0 Then
                        mtdProcurar(dtgv2)
                    End If
            End Select
        End Sub

        Private Sub tsbSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSair.Click
            Me.Close()
        End Sub

        Private Sub tsbAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnterior.Click
            Select Case intdtgvSelecionado
                Case 1
                    mtdAnterior(dtgv1)
                Case 2
                    mtdAnterior(dtgv2)
            End Select
        End Sub

        Private Sub tsbProximo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbProximo.Click
            Select Case intdtgvSelecionado
                Case 1
                    mtdProximo(dtgv1)
                Case 2
                    mtdProximo(dtgv2)
            End Select
        End Sub

        Private Sub tsbIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbIncluir.Click
            Dim numRegistrosAcrescentar As Integer = Convert.ToInt32(txtAcrescentar.Text)
            If MessageBox.Show("Deseja acrescentar um ou mais registros?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Select Case intdtgvSelecionado
                    Case 1
                        If dtgv1.Columns.Count > 0 Then
                            dtgv1.AllowUserToAddRows = True
                            For i As Integer = 1 To numRegistrosAcrescentar Step 1
                                'dtgv1.Item(0, 0).Selected = True
                                dtgv1.Item(0, dtgv1.RowCount - 1).Selected = True
                                dtgv1.EndEdit()
                                mtdAdicionarRegistro(dtgv1, strNomeTabelaCautela, objBDPrincipal1, numColunaDR1)
                                lbl2.Text = If(dtgv1.Item(0, 0).Value IsNot Nothing, dtgv1.Item(0, 0).Value.ToString(), String.Empty)
                                dtgv1.Item(0, 0).Selected = True
                                'lbl2.Text = dtgv1.Item(0, dtgv1.RowCount - 2).Value.ToString()
                                'dtgv1.Item(0, dtgv1.RowCount - 2).Selected = True
                            Next
                            dtgv1.AllowUserToAddRows = False
                            'dtgv1.SelectionMode() = DataGridViewSelectionMode.CellSelect
                            mtddtgv1Clicar(numlinhaselecionada)
                            mtdPreencherLsv1()
                            mtdAtualizarTs(dtgv1)
                            mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
                        End If
                    Case 2
                        If dtgv2.Columns.Count > 0 Then
                            dtgv2.AllowUserToAddRows = True
                            For i As Integer = 1 To numRegistrosAcrescentar Step 1
                                Try
                                    dtgv2.Item(0, dtgv2.RowCount - 1).Selected = True
                                Catch
                                End Try
                                dtgv2.EndEdit()
                                mtdAdicionarRegistro(dtgv2, strNomeTabelaCautelaBens, objBDPrincipal2, numColunaDR2)
                                Try
                                    dtgv2.Item(0, 0).Selected = False
                                    lbl11.Text = If(dtgv2.Item(0, dtgv2.RowCount - 2).Value IsNot Nothing, dtgv2.Item(0, dtgv2.RowCount - 2).Value.ToString(), String.Empty)
                                    dtgv2.Item(0, dtgv2.RowCount - 2).Selected = True
                                Catch
                                End Try
                            Next
                            dtgv2.AllowUserToAddRows = False
                            mtdAtualizarTs(dtgv2)
                        End If
                End Select
            End If
            txtAcrescentar.Text = "1"
        End Sub

        Private Sub tsbProcurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbProcurar.Click
            Select Case intdtgvSelecionado
                Case 1
                    mtdProcurar(dtgv1)
                Case 2
                    mtdProcurar(dtgv2)
            End Select
        End Sub

        Private Sub mtdSalvar()
            Try
                Select Case intdtgvSelecionado
                    Case 1
                        dtgv1.Item(1, dtgv1.SelectedCells(0).RowIndex).Selected = True
                        dtgv1.BeginEdit(True)
                        dtgv1.EndEdit()
                    Case 2
                        dtgv2.Item(3, dtgv2.SelectedCells(0).RowIndex).Selected = True
                        dtgv2.BeginEdit(True)
                        dtgv2.EndEdit()
                End Select
            Catch
                MessageBox.Show("Não há itens a serem atualizados.", "Aviso!", MessageBoxButtons.OK)
            End Try
        End Sub

        Private Sub tsbSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalvar.Click
            mtdSalvar()
        End Sub

        Private intLinhaAnteriorDTGV1 As Integer = 0
        Private intColunaAnteriorDTGV1 As Integer = 0

        Private intLinhaAnteriorDTGV2 As Integer = 0
        Private intColunaAnteriorDTGV2 As Integer = 0

        Private corAtual As Color = Color.LightSteelBlue

        Private Sub dtgv1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv1.CellClick
            'dtgv1.SelectionMode() = DataGridViewSelectionMode.CellSelect
            mtddtgv1Clicar(e.RowIndex)
            mtdPreencherLsv1()
            mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")

            numlinhaselecionada = e.RowIndex
            numcolunaselecionada = e.ColumnIndex

            mtdAtualizarTs(dtgv1)

            frmPrincipal.mtdDestacarCelulas(dtgv1, numlinhaselecionada, numcolunaselecionada, intLinhaAnteriorDTGV1, intColunaAnteriorDTGV1, corAtual)

            intLinhaAnteriorDTGV2 = 0
            intColunaAnteriorDTGV2 = 0
        End Sub

        Private Sub dtgv2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv2.CellClick
            'dtgv2.SelectionMode() = DataGridViewSelectionMode.CellSelect
            mtddtgv2Clicar(e.RowIndex)

            numlinhaselecionada = e.RowIndex
            numcolunaselecionada = e.ColumnIndex

            mtdAtualizarTs(dtgv2)

            If numlinhaselecionada >= 0 Then
                If Not mtdColorirBensPatrimonioNSerieRepetido(Convert.ToInt32(dtgv2.Item(3, numlinhaselecionada).Value), dtgv2.Item(6, numlinhaselecionada).Value.ToString()) Then
                    frmPrincipal.mtdDestacarCelulas(dtgv2, numlinhaselecionada, numcolunaselecionada, intLinhaAnteriorDTGV2, intColunaAnteriorDTGV2, corAtual)
                End If
            End If
        End Sub

        Private Sub dtgv1_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dtgv1.CellBeginEdit
            Try
                dtgv1.Item(7, e.RowIndex).Value = frmPrincipal.barlblMostrContUser.Text
                dtgv1.Item(8, e.RowIndex).Value = DateTime.Now
            Catch
            End Try
        End Sub
        Private Sub dtgv2_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dtgv2.CellBeginEdit
            Try
                dtgv2.Item(11, e.RowIndex).Value = frmPrincipal.barlblMostrContUser.Text
                dtgv2.Item(12, e.RowIndex).Value = DateTime.Now
            Catch
            End Try
        End Sub

        Private Sub cmb1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb1.DropDown
            mtdCarregarCmbItem(cmb1, 1, "SELECT DISTINCT tblEmpregados.Nome FROM tblEmpregados GROUP BY tblEmpregados.Nome HAVING Nome LIKE '%" & cmb1.Text & "%' ORDER BY Nome;")
        End Sub

        Private Sub cmb2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb2.DropDown
            mtdCarregarCmbItem(cmb2, 1, "SELECT DISTINCT tblEmpregados.Matricula FROM tblEmpregados GROUP BY tblEmpregados.Matricula HAVING tblEmpregados.Matricula LIKE '%" & cmb2.Text & "%' ORDER BY tblEmpregados.Matricula;")
        End Sub

        Private Sub cmb3_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb3.DropDown
            mtdCarregarCmbItem(cmb3, 1, "SELECT DISTINCT tblEmpregados.Orgao, tblEmpregados.Funcao FROM tblEmpregados GROUP BY tblEmpregados.Orgao, tblEmpregados.Funcao HAVING ((Orgao LIKE '%" & cmb3.Text & "%') AND (Funcao LIKE '%" & "Gerente" & "%')) ORDER BY Orgao, Funcao;")
        End Sub

        Private Sub cmb4_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb4.DropDown
            mtdCarregarCmbItem(cmb4, 1, "SELECT DISTINCT tblCentroCusto.CentroCusto FROM tblCentroCusto GROUP BY tblCentroCusto.CentroCusto HAVING (tblCentroCusto.CentroCusto) LIKE '%" & cmb4.Text & "%' ORDER BY tblCentroCusto.CentroCusto;")
        End Sub

        Private Sub cmb5_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb5.DropDown
            mtdCarregarCmbItem(cmb5, 1, "SELECT DISTINCT tblBensEletronorte.Patrimonio FROM tblBensEletronorte GROUP BY tblBensEletronorte.Patrimonio HAVING (tblBensEletronorte.Patrimonio) LIKE '%" & cmb5.Text & "%' ORDER BY tblBensEletronorte.Patrimonio;")
        End Sub

        Private Sub cmb6_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb6.DropDown
            mtdCarregarCmbItem(cmb6, 1, "SELECT DISTINCT tblBensEletronorte.Imobilizado FROM tblBensEletronorte GROUP BY tblBensEletronorte.Imobilizado HAVING (tblBensEletronorte.Imobilizado) LIKE '%" & cmb6.Text & "%' ORDER BY tblBensEletronorte.Imobilizado;")
        End Sub

        Private Sub cmb7_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb7.DropDown
            mtdCarregarCmbItem(cmb7, 1, "SELECT DISTINCT tblBensEletronorte.Denominacao FROM tblBensEletronorte GROUP BY tblBensEletronorte.Denominacao HAVING (tblBensEletronorte.Denominacao) LIKE '%" & cmb7.Text & "%' ORDER BY tblBensEletronorte.Denominacao;")
        End Sub

        Private Sub cmb8_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb8.DropDown
            mtdCarregarCmbItem(cmb8, 1, "SELECT DISTINCT tblBensEletronorte.N_Serie FROM tblBensEletronorte GROUP BY tblBensEletronorte.N_Serie HAVING (tblBensEletronorte.N_Serie) LIKE '%" & cmb8.Text & "%' ORDER BY tblBensEletronorte.N_Serie;")
        End Sub

        Private Sub cmb9_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb9.DropDown

        End Sub

        Private Sub cmb10_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb10.DropDown
            mtdCarregarCmbItem(cmb10, 1, "SELECT DISTINCT tblBensEletronorte.Sala FROM tblBensEletronorte GROUP BY tblBensEletronorte.Sala HAVING (tblBensEletronorte.Sala LIKE '%" & cmb10.Text & "%') ORDER BY tblBensEletronorte.Sala;")
        End Sub

        Private Sub mtdCarregarCmbItem(ByVal cmb As ComboBox, ByVal numCmb As Integer, ByVal SQL As String)
            Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, SQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
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
                    cmb.Items.Add(objManipuladorTexto.mtdMaiusculo(objBDPrincipal.mtdObterValorRegistro(numCmb - 1).ToString()))
                End If
            Next
            Try
                cmb.Text = cmb.Items(0).ToString()
            Catch
            End Try
            objBDPrincipal.mtdFecharConexao()
        End Sub

        Private Sub mtdCarregarGrp1CmbText(ByVal SQL As String)
            Dim strcmb1 As String = cmb1.Text
            Dim strcmb2 As String = cmb2.Text
            Dim strcmb3 As String = cmb3.Text
            Dim strcmb4 As String = cmb4.Text
            Dim strdtxt1 As String = dtxt1.Text
            Dim strdtxt2 As String = dtxt2.Text
            Dim strdtxt3 As String = dtxt3.Text
            Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
            'Try
            Dim objBDPrincipal As New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, SQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando()
            objBDPrincipal.mtdDefinirLeitorDados()
            If objBDPrincipal.mtdProximoRegistro() Then
                cmb1.Text = objManipuladorTexto.mtdMaiusculo(objBDPrincipal.mtdObterValorRegistro(0).ToString())
                cmb2.Text = objManipuladorTexto.mtdMaiusculo(objBDPrincipal.mtdObterValorRegistro(1).ToString())
                cmb3.Text = objManipuladorTexto.mtdMaiusculo(objBDPrincipal.mtdObterValorRegistro(2).ToString())
                cmb4.Text = objManipuladorTexto.mtdMaiusculo(objBDPrincipal.mtdObterValorRegistro(9).ToString())
                dtxt1.Text = dtgv1.Item(9, dtgv1.SelectedCells(0).RowIndex).Value.ToString()
                dtxt2.Text = dtgv1.Item(10, dtgv1.SelectedCells(0).RowIndex).Value.ToString()
                dtxt3.Text = dtgv1.Item(11, dtgv1.SelectedCells(0).RowIndex).Value.ToString()
            Else
                MessageBox.Show("Não foi possível encontrar nenhum registro relacionado ao campo solicitado.", "Aviso!", MessageBoxButtons.OK)
                cmb1.Text = strcmb1
                cmb2.Text = strcmb2
                cmb3.Text = strcmb3
                cmb4.Text = strcmb4
                dtxt1.Text = strdtxt1
                dtxt2.Text = strdtxt2
                dtxt3.Text = strdtxt3
            End If
            objBDPrincipal.mtdFecharConexao()
            'Catch
            'End Try
        End Sub

        Private Function mtdCarregarGrp2CmbText(ByVal SQL As String) As Boolean
            Return mtdCarregarGrp2CmbText(SQL, True)
        End Function

        Private Function mtdCarregarGrp2CmbText(ByVal SQL As String, ByVal modoInformacao As Boolean) As Boolean
            Dim blnEstadoErro As Boolean = False
            Dim strcmb5 As String = cmb5.Text
            Dim strcmb6 As String = cmb6.Text
            Dim strcmb7 As String = cmb7.Text
            Dim strcmb8 As String = cmb8.Text
            Dim strcmb9 As String = cmb9.Text
            Dim strcmb10 As String = cmb10.Text
            Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
            Dim objBDPrincipal As New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, SQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            objBDPrincipal.mtdAbrirConexao()
            objBDPrincipal.mtdExecutarComando()
            objBDPrincipal.mtdDefinirLeitorDados()
            If objBDPrincipal.mtdProximoRegistro() Then
                cmb5.Text = objBDPrincipal.mtdObterValorRegistro(1).ToString()
                cmb6.Text = objBDPrincipal.mtdObterValorRegistro(0).ToString()
                Dim strTexto As String = String.Empty
                Dim strTexto1 As String = objBDPrincipal.mtdObterValorRegistro(2).ToString()
                Dim strTexto2 As String = objBDPrincipal.mtdObterValorRegistro(3).ToString()
                If Not (strTexto1 = strTexto2) Then
                    strTexto = String.Concat(strTexto1, strTexto2)
                Else
                    strTexto = strTexto1
                End If
                cmb7.Text = objManipuladorTexto.mtdMaiusculo(objManipuladorTexto.mtdTiradorCaractereInvalido(strTexto))
                cmb8.Text = objManipuladorTexto.mtdMaiusculo(objBDPrincipal.mtdObterValorRegistro(4).ToString())
                cmb9.Text = objManipuladorTexto.mtdMaiusculo(cmb9.Items(1).ToString())
                cmb10.Text = objManipuladorTexto.mtdMaiusculo(objBDPrincipal.mtdObterValorRegistro(5).ToString())
                blnEstadoErro = True
            Else
                If modoInformacao Then
                    MessageBox.Show("Não foi possível encontrar nenhum registro relacionado ao campo solicitado.", "Aviso!", MessageBoxButtons.OK)
                End If
                cmb5.Text = strcmb5
                cmb6.Text = strcmb6
                cmb7.Text = strcmb7
                cmb8.Text = strcmb8
                cmb9.Text = strcmb9
                cmb10.Text = strcmb10
                blnEstadoErro = False
            End If
            objBDPrincipal.mtdFecharConexao()
            Return blnEstadoErro
        End Function

        Private Sub mtdCarregarDtgv1(ByVal linhaselecionada As Integer)
            Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
            'Try
            Dim strPrazoEntregaCautela As String = objRegistroWindows.mtdObterDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela").ToString()
            If objRegistroWindows.getmensagemExcecao.Equals("Object reference not set to an instance of an object.") Or objRegistroWindows.getmensagemExcecao = "Não há conteúdo na variável mensagemExcecao." Then
                objRegistroWindows.mtdSalvarDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela", frmConfiguracoes.PrazoEntregaCautela.ToString(), Microsoft.Win32.RegistryValueKind.DWord)
                strPrazoEntregaCautela = objRegistroWindows.mtdObterDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela").ToString()
            End If
            dtgv1.Item(3, linhaselecionada).Value = objManipuladorTexto.mtdMaiusculo(cmb1.Text)
            dtgv1.Item(4, linhaselecionada).Value = objManipuladorTexto.mtdMaiusculo(cmb2.Text)
            If dtgv1.Item(1, linhaselecionada).Value.Equals(0) Or dtgv1.Item(1, linhaselecionada).Value.Equals(String.Empty) Then
                If cmb4.Text.Equals(String.Empty) Then
                    dtgv1.Item(1, linhaselecionada).Value = 0
                Else
                    dtgv1.Item(1, linhaselecionada).Value = cmb4.Text
                End If
            End If
            If dtgv1.Item(2, linhaselecionada).Value.Equals(String.Empty) Then
                dtgv1.Item(2, linhaselecionada).Value = objManipuladorTexto.mtdMaiusculo(cmb3.Text)
            End If
            dtgv1.Item(12, linhaselecionada).Value = strPrazoEntregaCautela
            'Catch
            '    MessageBox.Show("Adicione um registro na tabela Responsável.", "Erro!", MessageBoxButtons.OK)
            'End Try
        End Sub

        Private Sub mtdCarregarDtgv2(ByVal linhaselecionada As Integer)
            Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
            Try
                dtgv2.Item(3, linhaselecionada).Value = objManipuladorTexto.mtdMaiusculo(cmb5.Text)
                dtgv2.Item(4, linhaselecionada).Value = objManipuladorTexto.mtdMaiusculo(cmb6.Text)
                dtgv2.Item(5, linhaselecionada).Value = objManipuladorTexto.mtdMaiusculo(cmb7.Text)
                dtgv2.Item(6, linhaselecionada).Value = objManipuladorTexto.mtdMaiusculo(cmb8.Text)
                dtgv2.Item(7, linhaselecionada).Value = objManipuladorTexto.mtdMaiusculo(cmb9.Text)
                dtgv2.Item(8, linhaselecionada).Value = objManipuladorTexto.mtdMaiusculo(cmb10.Text)
            Catch
                'MessageBox.Show("Adicione um registro na tabela Bens.", "Erro!", MessageBoxButtons.OK)
            End Try
        End Sub

        Private Sub mtdPreencherCmb9()
            Dim objImplementacaoBancoDadosPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados()
            objImplementacaoBancoDadosPrincipal.mtdAbrirConexao(strConexaoBancoDados, clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDadosPrincipal.mtdSelecionarDados("*", strTabelaAuxiliaresConservacaoBensPrincipal)
            objImplementacaoBancoDadosPrincipal.mtdDefinirLeitorDados()
            While objImplementacaoBancoDadosPrincipal.mtdProximoRegistro()
                cmb9.Items.Add(objImplementacaoBancoDadosPrincipal.mtdObterValorRegistro(0))
            End While

            objImplementacaoBancoDadosPrincipal.Dispose()
        End Sub

        Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
            If MessageBox.Show("Deseja realmente atualizar os dados do registro?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Select Case intcmbSelecionado
                    Case 1
                        If Not (cmb1.Text = String.Empty Or cmb1.Text = "0") Then
                            mtdCarregarGrp1CmbText("SELECT DISTINCT  tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE (tblEmpregados.Nome LIKE '%" & cmb1.Text & "%') ORDER BY tblEmpregados.Nome;")
                        End If
                    Case 2
                        If Not (cmb2.Text = String.Empty Or cmb2.Text = "0") Then
                            mtdCarregarGrp1CmbText("SELECT DISTINCT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE (tblEmpregados.Matricula LIKE '%" & cmb2.Text & "%') ORDER BY tblEmpregados.Matricula;")
                        End If
                    Case 3
                        If Not (cmb3.Text = String.Empty Or cmb3.Text = "0") Then
                            mtdCarregarGrp1CmbText("SELECT DISTINCT  tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE ((tblEmpregados.Orgao LIKE '%" & cmb3.Text & "%') AND ((Funcao LIKE '%" & "Assistente de Diretor" & "%') OR (Funcao LIKE '%" & "Superintendente" & "%') OR (Funcao LIKE '%" & "Gerente" & "%'))) ORDER BY tblEmpregados.Orgao, tblEmpregados.Funcao;")
                        End If
                    Case 4
                        If Not (cmb4.Text = String.Empty Or cmb4.Text = "0") Then
                            mtdCarregarGrp1CmbText("SELECT  DISTINCT  tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados INNER JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE(((tblCentroCusto.CentroCusto) LIKE '%" & cmb4.Text & "%') AND (Funcao LIKE '%" & "Gerente" & "%')) ORDER BY tblCentroCusto.CentroCusto;")
                        End If
                End Select
                Try
                    mtdCarregarDtgv1(numlinhaselecionada)
                    dtgv1.Item(1, numlinhaselecionada).Selected = True
                    dtgv1.BeginEdit(True)
                    dtgv1.EndEdit()
                    'mtdIniciarThreadProgresso()
                    mtdRotinaExcutarDtgv2()
                Catch
                End Try
                cbx1.Checked = False
            End If
        End Sub

        Private Sub bcmb1_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles bcmb1.DropDownClosed
            If bcmb1.Text = "Responsável" Then
                intdtgvSelecionado = 1
            ElseIf bcmb1.Text = "Bens" Then
                intdtgvSelecionado = 2
            End If
            mtdCarregarBcmb2()
            If bcmb2.Items.Count > 0 Then
                bcmb2.Text = bcmb2.Items(0).ToString()
            End If
        End Sub

        Private Sub cmb1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb1.TextChanged
            intcmbSelecionado = 1
        End Sub
        Private Sub cmb2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb2.TextChanged
            intcmbSelecionado = 2
        End Sub
        Private Sub cmb3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb3.TextChanged
            intcmbSelecionado = 3
        End Sub
        Private Sub cmb4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb4.TextChanged
            intcmbSelecionado = 4
        End Sub
        Private Sub cmb5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb5.TextChanged
            intcmbSelecionado = 5
        End Sub
        Private Sub cmb6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb6.TextChanged
            intcmbSelecionado = 6
        End Sub
        Private Sub cmb7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb7.TextChanged
            intcmbSelecionado = 7
        End Sub
        Private Sub cmb8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb8.TextChanged
            intcmbSelecionado = 8
        End Sub
        Private Sub cmb9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb9.TextChanged
            intcmbSelecionado = 9
        End Sub
        Private Sub cmb10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb10.TextChanged
            intcmbSelecionado = 10
        End Sub
        Private Sub cmb1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb1.Click
            intcmbSelecionado = 1
        End Sub
        Private Sub cmb2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb2.Click
            intcmbSelecionado = 2
        End Sub
        Private Sub cmb3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb3.Click
            intcmbSelecionado = 3
        End Sub
        Private Sub cmb4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb4.Click
            intcmbSelecionado = 4
        End Sub
        Private Sub cmb5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb5.Click
            intcmbSelecionado = 5
        End Sub
        Private Sub cmb6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb6.Click
            intcmbSelecionado = 6
        End Sub
        Private Sub cmb7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb7.Click
            intcmbSelecionado = 7
        End Sub
        Private Sub cmb8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb8.Click
            intcmbSelecionado = 8
        End Sub
        Private Sub cmb9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb9.Click
            intcmbSelecionado = 9
        End Sub
        Private Sub cmb10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb10.Click
            intcmbSelecionado = 10
        End Sub

        Private Sub frmCautelas_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
            If varHouveRedimensionamento = False Then
                dfrmdtgv1H = Me.Width - dtgv1.Width
                dfrmdtgv1V = dtgv1.Top - Me.Top
                dfrmgrpb1H = Me.Width - grpb1.Left
                'dfrmgrpb1V = Me.Height - gpb1.Top
                dfrmgrpb2H = Me.Width - grpb2.Left
                dfrmlsv1H = Me.Width - lsv1.Width
                ddtgv1Vdtgv2V = dtgv2.Top - (dtgv1.Height + dtgv1.Top)
                ddtgv2Vlsv1V = lsv1.Top - (dtgv2.Height + dtgv2.Top)
                dlsv1frmV = Me.Height - (dfrmdtgv1V + dtgv1.Height + ddtgv1Vdtgv2V + dtgv2.Height + ddtgv2Vlsv1V + lsv1.Height)

                dgrpb1VlsvCautelaV = grpb1.Height - lsvCautela.Height
                dgrpb2VlsvCautelaBensV = grpb2.Height - lsvCautelaBens.Height

                varHouveRedimensionamento = True
            End If
            dtgv1.Height = CInt((Me.Height - (dfrmdtgv1V + ddtgv1Vdtgv2V + ddtgv2Vlsv1V + lsv1.Height + dlsv1frmV)) / 2)
            dtgv1.Width = Me.Width - dfrmdtgv1H
            grpb1.Height = dtgv1.Height
            grpb1.Left = Me.Width - dfrmgrpb1H
            dtgv2.Height = dtgv1.Height 'Me.Height - dfrmdtgv2V
            dtgv2.Width = dtgv1.Width 'Me.Width - dfrmdtgv2H
            dtgv2.Top = dtgv1.Top + dtgv1.Height + ddtgv1Vdtgv2V
            grpb2.Height = grpb1.Height
            grpb2.Top = dtgv2.Top 'Me.Height - dtgv1.Height
            grpb2.Left = Me.Width - dfrmgrpb2H
            lsv1.Width = Me.Width - dfrmlsv1H
            lsv1.Top = dtgv2.Top + dtgv2.Height + ddtgv2Vlsv1V

            lsvCautela.Height = grpb1.Height - dgrpb1VlsvCautelaV
            lsvCautelaBens.Height = grpb2.Height - dgrpb2VlsvCautelaBensV
        End Sub

        Private Sub btxt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btxt1.TextChanged
            'mtdConteudoBtxt1()
        End Sub

        Private Sub btxt1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btxt1.KeyDown
            If (e.KeyCode = Keys.Enter) Then
                mtdConteudoBtxt1()
            End If
        End Sub

        Private Sub bcmb2_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb2.DropDown
            mtdCarregarBcmb2()
        End Sub

        Private Sub mtdConteudoBtxt1()
            mtdConteudoBtxt1(bcmb2.Text)
        End Sub

        Private Sub mtdConteudoBtxt1(ByVal BcmbTexto As String)
            mtdCarregarDtgv112(bcmb2.Text, btxt1.Text)
        End Sub

        Private Sub mtdCarregarDtgv112(ByVal CampoSelecionador As String, ByVal DadoSelecionador As String)
            'Dim strConteudo As String = DadoSelecionador
            'Select Case intModobcmb3
            '    Case 1
            '        strConteudo = "'" & DadoSelecionador & "'"
            '    Case 2
            '        strConteudo = "'%" & DadoSelecionador & "%'"
            'End Select
            'Select Case intdtgvSelecionado
            '    Case 1
            '        mtdAtualizarDtgv1(strNomeTabelaCautela, CampoSelecionador, strConteudo, 0)
            '        mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
            '    Case 2
            '        mtdAtualizarDtgv2(strNomeTabelaCautelaBens, CampoSelecionador, strConteudo)
            'End Select

            Dim strColuna As String = CampoSelecionador
            Dim strDado As String = DadoSelecionador
            Dim strTabelaOrdenadora As String = String.Empty
            Dim strCampoOrdenador As String = String.Empty
            Dim blnOrdenacaoCrescente As Boolean = False

            If vetCamposTabelaCautela.Contains(strColuna) Then
                mtdLsvSelecao(0, strNomeTabelaCautela, strColuna, strDado)
                strTabelaOrdenadora = strNomeTabelaCautela
                strCampoOrdenador = "Codigo"
                blnOrdenacaoCrescente = False
            ElseIf vetCamposTabelaCautelaBens.Contains(strColuna) Then
                mtdLsvSelecao(1, strNomeTabelaCautelaBens, strColuna, strDado)
                strTabelaOrdenadora = strNomeTabelaCautela
                strCampoOrdenador = "Codigo"
                blnOrdenacaoCrescente = False
            End If

            mtdPesquisarAtualizarDtgv1(strNomeTabelaPrincipal, strColuna, strDado, strTabelaOrdenadora, strCampoOrdenador, blnOrdenacaoCrescente, True)

            If vetCamposTabelaCautela.Contains(strColuna) Then
                mtdLsvSelecao(0, strNomeTabelaCautela, strColuna, strDado)
                strTabelaOrdenadora = strNomeTabelaCautelaBens
                strCampoOrdenador = "Codigo"
                blnOrdenacaoCrescente = False
            ElseIf vetCamposTabelaCautelaBens.Contains(strColuna) Then
                mtdLsvSelecao(1, strNomeTabelaCautelaBens, strColuna, strDado)
                strTabelaOrdenadora = strNomeTabelaCautelaBens
                strCampoOrdenador = "Codigo"
                blnOrdenacaoCrescente = False
            End If

            mtdPesquisarAtualizarDtgv2(strNomeTabelaPrincipal, strColuna, strDado, strTabelaOrdenadora, strCampoOrdenador, blnOrdenacaoCrescente, True)
        End Sub

        Private Sub mtdCarregarBcmb2()
            'Select Case intdtgvSelecionado
            '    Case 1
            '        strNomeTabelaPrincipal = strNomeTabelaCautela
            '        mtdPreencherBcmb("SELECT " & strNomeTabelaPrincipal & ".* FROM " & strNomeTabelaPrincipal & ";", bcmb2)
            '    Case 2
            '        strNomeTabelaPrincipal = strNomeTabelaCautelaBens
            '        mtdPreencherBcmb("SELECT " & strNomeTabelaPrincipal & ".* FROM " & strNomeTabelaPrincipal & ";", bcmb2)
            'End Select

            frmPrincipal.mtdPreencherBcmb(bcmb2, String.Empty, vetCamposTabelaCautela, vetCamposTabelaCautelaBens, intColunaTabelaCautelaCodigo + 1)
        End Sub

        Private Sub bcmb2_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb2.DropDownClosed
            btxt1.Text = String.Empty
            btxt1.Focus()
        End Sub

        Private Sub btxt1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btxt1.Click
            'mtdConteudoBtxt1(bcmb3.Text)
        End Sub

        Private Sub bcmb3_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb3.DropDownClosed
            Select Case bcmb3.Text
                Case "Campo Inteiro"
                    intModobcmb3 = 1
                Case "Qualquer Parte do Campo"
                    intModobcmb3 = 2
            End Select
            mtdConteudoBtxt1()
        End Sub

        Private Sub dtgv1_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgv1.DataError
            'Dim message As String = "Algum caractere digitado é invalido ou não está no formato aceito."
            'MessageBox.Show(message, "Aviso!", MessageBoxButtons.OK)
        End Sub

        Private Sub dtgv2_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dtgv2.DataError
            'Dim message As String = "Algum caractere digitado é invalido ou não está no formato aceito."
            'MessageBox.Show(message, "Aviso!", MessageBoxButtons.OK)
        End Sub

        Private Sub mtdRegistroAtrasado()
            Dim numlinhadtgv1 As Integer = dtgv1.RowCount
            Dim numcolunadtgv1 As Integer = dtgv1.ColumnCount
            Dim estiloRegistroAtrasado As New DataGridViewCellStyle()
            Dim estiloRegistroNaoAtrasado As New DataGridViewCellStyle()
            Dim estiloRegistroRecebido As New DataGridViewCellStyle()
            estiloRegistroAtrasado.BackColor = Color.Red
            estiloRegistroAtrasado.ForeColor = Color.Empty
            estiloRegistroNaoAtrasado.BackColor = Color.Yellow
            estiloRegistroNaoAtrasado.ForeColor = Color.Empty
            estiloRegistroRecebido.BackColor = Color.LightGreen
            estiloRegistroRecebido.ForeColor = Color.Empty
            For linha As Integer = 0 To numlinhadtgv1 - 1 Step 1
                For coluna As Integer = 0 To numcolunadtgv1 - 1 Step 1
                    Try
                        If dtgv1.Item(11, linha).Value.ToString().Equals(String.Empty) Then
                            If DateAdd(DateInterval.Day, Convert.ToDouble(dtgv1.Item(12, linha).Value.ToString()), Convert.ToDateTime(dtgv1.Item(10, linha).Value.ToString())) < DateTime.Now Then
                                dtgv1.Item(coluna, linha).Style = estiloRegistroAtrasado
                            Else
                                dtgv1.Item(coluna, linha).Style = estiloRegistroNaoAtrasado
                            End If
                        Else
                            dtgv1.Item(coluna, linha).Style = estiloRegistroRecebido
                        End If
                    Catch
                    End Try
                Next
            Next
        End Sub
        Private Sub dtxt1_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtxt1.CloseUp
            dtgv1.Item(10, dtgv1.SelectedCells(0).RowIndex).Value = Convert.ToDateTime(dtxt1.Text)
            mtdAtualizarRegistro()
        End Sub
        Private Sub dtxt2_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtxt2.CloseUp
            dtgv1.Item(11, dtgv1.SelectedCells(0).RowIndex).Value = Convert.ToDateTime(dtxt2.Text)
            mtdAtualizarRegistro()
        End Sub
        Private Sub dtxt3_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtxt3.CloseUp
            dtgv1.Item(9, dtgv1.SelectedCells(0).RowIndex).Value = Convert.ToDateTime(dtxt3.Text)
            mtdAtualizarRegistro()
        End Sub

        Private Sub blbl3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blbl3.Click
            mtdRegistroAtrasado()
        End Sub

        Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
            If MessageBox.Show("Deseja realmente atualizar os dados do registro?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Select Case intcmbSelecionado
                    Case 5
                        If cmb11.Text = "Patrimonio" Then
                            If MessageBox.Show("Deseja realmente fazer a alteração em massa?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                For linha As Integer = 0 To dtgv2.RowCount - 1
                                    dtgv2.Item(3, linha).Selected = True
                                    dtgv2.BeginEdit(True)
                                    dtgv2.Item(3, linha).Value = cmb5.Text
                                    dtgv2.EndEdit()
                                Next
                            End If
                        Else
                            If Not (cmb5.Text = String.Empty Or cmb5.Text = "0") Then
                                mtdCarregarGrp2CmbText("SELECT DISTINCT tblBensEletronorte.* FROM tblBensEletronorte WHERE (tblBensEletronorte.Patrimonio LIKE '%" & cmb5.Text & "%') ORDER BY tblBensEletronorte.Patrimonio, tblBensEletronorte.Imobilizado;")
                            End If
                        End If
                    Case 6
                        If cmb11.Text = "Imobilizado" Then
                            If MessageBox.Show("Deseja realmente fazer a alteração em massa?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                For linha As Integer = 0 To dtgv2.RowCount - 1
                                    dtgv2.Item(4, linha).Selected = True
                                    dtgv2.BeginEdit(True)
                                    dtgv2.Item(4, linha).Value = cmb6.Text
                                    dtgv2.EndEdit()
                                Next
                            End If
                        Else
                            If Not (cmb6.Text = String.Empty Or cmb6.Text = "0") Then
                                mtdCarregarGrp2CmbText("SELECT DISTINCT tblBensEletronorte.* FROM tblBensEletronorte WHERE (tblBensEletronorte.Imobilizado LIKE '%" & cmb6.Text & "%') ORDER BY tblBensEletronorte.Imobilizado;")
                            End If
                        End If
                    Case 7
                        If cmb11.Text = "Descricao" Then
                            If MessageBox.Show("Deseja realmente fazer a alteração em massa?", "Questionário", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                For linha As Integer = 0 To dtgv2.RowCount - 1
                                    dtgv2.Item(5, linha).Selected = True
                                    dtgv2.BeginEdit(True)
                                    dtgv2.Item(5, linha).Value = cmb7.Text
                                    dtgv2.EndEdit()
                                Next
                            End If
                        End If
                    Case 8
                        If cmb11.Text = "N_Serie" Then
                            If MessageBox.Show("Deseja realmente fazer a alteração em massa?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                For linha As Integer = 0 To dtgv2.RowCount - 1
                                    dtgv2.Item(6, linha).Selected = True
                                    dtgv2.BeginEdit(True)
                                    dtgv2.Item(6, linha).Value = cmb8.Text
                                    dtgv2.EndEdit()
                                Next
                            End If
                        Else
                            If Not (cmb8.Text = String.Empty Or cmb8.Text = "0") Then
                                mtdCarregarGrp2CmbText("SELECT DISTINCT tblBensEletronorte.* FROM tblBensEletronorte WHERE (tblBensEletronorte.N_Serie LIKE '%" & cmb8.Text & "%') ORDER BY tblBensEletronorte.N_Serie;")
                            End If
                        End If
                    Case 9
                        If cmb11.Text = "Estado_Conservacao" Then
                            If MessageBox.Show("Deseja realmente fazer a alteração em massa?", "Questionário", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                For linha As Integer = 0 To dtgv2.RowCount - 1
                                    dtgv2.Item(7, linha).Selected = True
                                    dtgv2.BeginEdit(True)
                                    dtgv2.Item(7, linha).Value = cmb9.Text
                                    dtgv2.EndEdit()
                                Next
                            End If
                        End If
                    Case 10
                        If cmb11.Text = "Localizacao" Then
                            If MessageBox.Show("Deseja realmente fazer a alteração em massa?", "Questionário", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                For linha As Integer = 0 To dtgv2.RowCount - 1
                                    dtgv2.Item(8, linha).Selected = True
                                    dtgv2.BeginEdit(True)
                                    dtgv2.Item(8, linha).Value = cmb10.Text
                                    dtgv2.EndEdit()
                                Next
                            End If
                        End If
                End Select
                If cmb11.Text = "Item" Then
                    If MessageBox.Show("Deseja realmente fazer a alteração em massa?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        For linha As Integer = 0 To dtgv2.RowCount - 1
                            dtgv2.Item(2, linha).Selected = True
                            dtgv2.BeginEdit(True)
                            dtgv2.Item(2, linha).Value = linha + 1
                            dtgv2.EndEdit()
                        Next
                    End If
                End If

                mtdCarregarDtgv2(numlinhaselecionada)

                Try
                    dtgv2.Item(3, numlinhaselecionada).Selected = True
                    dtgv2.BeginEdit(True)
                    dtgv2.EndEdit()
                Catch
                End Try

                mtdAtualizarRegistro(dtgv2, strNomeTabelaCautelaBens, objBDPrincipal2, numColunaDR2)
                frmPrincipal.mtdPreencherCmb(cmb11, "Alteração em Massa", vetCamposTabelaCautelaBens)
            End If
        End Sub

        Private Sub dtgv1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv1.CellEndEdit
            numcolunaselecionada = e.ColumnIndex
            numlinhaselecionada = e.RowIndex

            mtdAtualizarTs(dtgv1)

            mtddtgv1Clicar(numlinhaselecionada)
            mtdCampoMaiusculoDTGV(dtgv1, numlinhaselecionada)
            mtdAtualizarRegistro(dtgv1, strNomeTabelaCautela, objBDPrincipal1, numColunaDR1)
        End Sub

        Private Sub dtgv2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv2.CellEndEdit
            numcolunaselecionada = e.ColumnIndex
            numlinhaselecionada = e.RowIndex

            mtdAtualizarTs(dtgv2)

            mtddtgv2Clicar(numlinhaselecionada)
            mtdCampoMaiusculoDTGV(dtgv2, numlinhaselecionada)
            mtdAtualizarRegistro(dtgv2, strNomeTabelaCautelaBens, objBDPrincipal2, numColunaDR2)
            'Dim valorcodigodtgv2 As Integer = Convert.ToInt32(IIf(Not dtgv2.Item(1, numlinhaselecionada).Value.Equals(String.Empty), dtgv2.Item(1, numlinhaselecionada).Value.ToString(), "0"))
            'Dim valorpatrimoniodtgv2 As Integer = Convert.ToInt32(IIf(Not dtgv2.Item(3, numlinhaselecionada).Value.Equals(String.Empty), dtgv2.Item(3, numlinhaselecionada).Value.ToString(), "0"))
            'Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, "SELECT tblMBPBens.* FROM tblMBPBens WHERE tblMBPBens.Codigo LIKE '" & valorcodigodtgv2 & "' AND tblMBPBens.Patrimonio LIKE '" & valorpatrimoniodtgv2 & "';", clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
            'objBDPrincipal.mtdAbrirConexao()
            'objBDPrincipal.mtdExecutarComando()
            'If objBDPrincipal.mtdNumeroLinhas() >= 2 And Not valorpatrimoniodtgv2 = 0 Then
            '    MessageBox.Show("Verifique que o patrimônio está repetido, tais itens serão coloridos de laranja para melhor visualização.")
            'End If
            'objBDPrincipal.mtdFecharConexao()
        End Sub

        Private Sub dtgv1_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv1.RowEnter
            numlinhaselecionada = e.RowIndex
            numcolunaselecionada = e.ColumnIndex

            mtdAtualizarTs(dtgv1)
        End Sub

        Private Sub dtgv2_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv2.RowEnter
            numlinhaselecionada = e.RowIndex
            numcolunaselecionada = e.ColumnIndex

            mtdAtualizarTs(dtgv2)
        End Sub

        'Private Shared Th1 As Thread
        Private epocaporcent As Double = 0
        Delegate Sub SetValueCallback(ByVal [value] As Integer)

        'Private Sub mtdIniciarThreadProgresso()
        '    Th1 = New Thread(New ThreadStart(AddressOf Me.mtdRotinaThreadProgresso))
        '    Th1.IsBackground = True
        '    Th1.Priority = ThreadPriority.Normal
        '    Th1.Start()
        'End Sub

        Private Sub mtdRotinaExcutarDtgv2()
            dtgv2.AllowUserToAddRows = True
            If cbx1.Checked Then
                If MessageBox.Show("Deseja realmente importar os dados do SAP/R3?", "Questionário", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                    If dtgv2.RowCount <= 1 Then
                        Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
                        Dim SQL As String = "SELECT DISTINCT tblBensEletronorte.Patrimonio, tblBensEletronorte.Imobilizado, tblBensEletronorte.Denominacao, tblBensEletronorte.N_Serie, tblBensEletronorte.Sala FROM tblBensEletronorte WHERE ((tblBensEletronorte.Matricula LIKE '" & dtgv1.Item(4, dtgv1.SelectedCells(0).RowIndex).Value.ToString() & "') AND (tblBensEletronorte.Atividade='Ativo' OR tblBensEletronorte.Atividade='Inativo' OR tblBensEletronorte.Atividade='Capitalizado')) ORDER BY tblBensEletronorte.Patrimonio, tblBensEletronorte.Imobilizado DESC;"
                        Dim objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, SQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                        objBDPrincipal.mtdAbrirConexao()
                        objBDPrincipal.mtdExecutarComando()
                        Dim numMaxRegistro As Integer = objBDPrincipal.mtdNumeroLinhas()
                        objBDPrincipal.mtdDefinirLeitorDados()
                        Dim numMaxColuna As Integer = objBDPrincipal.mtdNumeroColunas()
                        'Try
                        If numMaxRegistro > 0 Then
                            For linha As Integer = 0 To numMaxRegistro - 1 Step 1
                                Dim NewValue As Integer = Convert.ToInt32((linha / numMaxRegistro) * 100)
                                Dim f As New SetValueCallback(AddressOf Me.SetValue)
                                Me.BeginInvoke(f, New Object() {[NewValue]})
                                epocaporcent = [NewValue]
                                dtgv2.Item(0, linha).Selected = True
                                mtdAdicionarRegistro(dtgv2, strNomeTabelaCautelaBens, objBDPrincipal2, numColunaDR2)
                                objBDPrincipal.mtdProximoRegistro()
                                For coluna As Integer = 0 To numMaxColuna Step 1
                                    Select Case coluna
                                        Case 4
                                            dtgv2.Item(7, linha).Value = cmb9.Items(1)
                                        Case 5
                                            If Not objBDPrincipal.mtdObterValorRegistro(4).Equals(String.Empty) Then
                                                dtgv2.Item(8, linha).Value = objManipuladorTexto.mtdTiradorCaractereInvalido(objBDPrincipal.mtdObterValorRegistro(4).ToString())
                                            End If
                                        Case Else
                                            If Not objBDPrincipal.mtdObterValorRegistro(coluna).Equals(String.Empty) Then
                                                dtgv2.Item(coluna + 3, linha).Value = objManipuladorTexto.mtdTiradorCaractereInvalido(objBDPrincipal.mtdObterValorRegistro(coluna).ToString())
                                            End If
                                    End Select
                                Next
                                dtgv2.Item(3, linha).Selected() = True
                                dtgv2.BeginEdit(True)
                                dtgv2.EndEdit()
                                dtgv2.Item(3, linha).Selected() = False
                                dtgv2.Item(0, linha).Selected = False
                                mtdAtualizarDtgv2(strNomeTabelaCautela, "Codigo")
                            Next
                        End If
                        'Catch
                        'End Try
                    Else : MessageBox.Show("Delete todos os Bens da Cautela do registro selecionado para poder fazer a adição em massa.", "Aviso!", MessageBoxButtons.OK)
                    End If
                End If
            End If
            dtgv2.AllowUserToAddRows = False
        End Sub

        Private Shared LockCautelas As Object = New Object()

        'Private Sub mtdRotinaThreadProgresso()
        '    Dim strtempoestimado As String = String.Empty
        '    Try
        '        Do
        '            SyncLock (LockCautelas)
        '                Dim NewValue As Integer = Convert.ToInt32(epocaporcent)
        '                If Me.InvokeRequired Then
        '                    'Dim f As New SetValueCallback(AddressOf Me.SetValue)
        '                    'Me.BeginInvoke(f, New Object() {[NewValue]})
        '                Else
        '                    If frmPrincipal.barprgfrmPrincipal.Value < 100 Then
        '                        frmPrincipal.barprgfrmPrincipal.Value = [NewValue]
        '                        frmPrincipal.barprgfrmPrincipal.ToolTipText = "Andamento do Processo em: " & [NewValue] & " %"
        '                        frmPrincipal.barprgfrmPrincipal.AutoToolTip = True
        '                    End If
        '                End If
        '                Thread.Sleep(1)
        '            End SyncLock
        '        Loop
        '    Catch ex As Exception

        '    End Try
        'End Sub

        Private Sub SetValue(ByVal [value] As Integer)
            frmPrincipal.barprgfrmPrincipal.Value = [value]
        End Sub

        Private Sub dtgv1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgv1.Click
            bcmb1.Text = "Responsável"
            intdtgvSelecionado = 1
            Try
                numlinhaselecionada = dtgv1.SelectedCells(0).RowIndex
                numcolunaselecionada = dtgv1.SelectedCells(0).ColumnIndex

                mtdAtualizarTs(dtgv1)
            Catch
                dtgv2.Columns.Clear()
                lsv1.Clear()
            End Try
        End Sub

        Private Sub dtgv2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgv2.Click
            bcmb1.Text = "Bens"
            intdtgvSelecionado = 2
            Try
                numlinhaselecionada = dtgv2.SelectedCells(0).RowIndex
                numcolunaselecionada = dtgv2.SelectedCells(0).ColumnIndex

                mtdAtualizarTs(dtgv2)
            Catch
            End Try
        End Sub

        Private Sub dtgv1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgv1.KeyDown
            dtgv1.AllowUserToDeleteRows = False
        End Sub

        Private Sub dtgv2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgv2.KeyDown
            dtgv2.AllowUserToDeleteRows = False
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
                    'dtgv1.SelectionMode() = DataGridViewSelectionMode.CellSelect
                    mtddtgv1Clicar(numlinhaselecionada)
                    mtdPreencherLsv1()
                    mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")

                    mtdAtualizarTs(dtgv1)

                    frmPrincipal.mtdDestacarCelulas(dtgv1, numlinhaselecionada, numcolunaselecionada, intLinhaAnteriorDTGV1, intColunaAnteriorDTGV1, System.Drawing.Color.White)

                    intLinhaAnteriorDTGV2 = 0
                    intColunaAnteriorDTGV2 = 0
                Case System.Windows.Forms.Keys.Insert
                    tsbIncluir_Click(sender, e)
            End Select
        End Sub

        Private Sub dtgv2_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgv2.KeyUp
            Try
                numlinhaselecionada = dtgv2.SelectedCells(0).RowIndex
                numcolunaselecionada = dtgv2.SelectedCells(0).ColumnIndex
            Catch ex As Exception

            End Try

            Select Case e.KeyCode
                Case System.Windows.Forms.Keys.Delete
                    dtgv2.AllowUserToDeleteRows = True
                    tsbExcluir_Click(sender, e)
                Case System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.PageUp, System.Windows.Forms.Keys.PageDown
                    'dtgv2.SelectionMode() = DataGridViewSelectionMode.CellSelect
                    mtddtgv2Clicar(numlinhaselecionada)

                    mtdAtualizarTs(dtgv2)

                    If Not mtdColorirBensPatrimonioNSerieRepetido(Convert.ToInt32(dtgv2.Item(3, numlinhaselecionada).Value), dtgv2.Item(6, numlinhaselecionada).Value.ToString()) Then
                        frmPrincipal.mtdDestacarCelulas(dtgv2, numlinhaselecionada, numcolunaselecionada, intLinhaAnteriorDTGV2, intColunaAnteriorDTGV2, corAtual)
                    End If
                Case System.Windows.Forms.Keys.Insert
                    tsbIncluir_Click(sender, e)
            End Select
        End Sub

        Public Sub mtdAtualizarDtgv1(ByVal vetDadoSelecionado As String())
            If MessageBox.Show("Deseja realmente atualizar os dados do registro?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Select Case numcolunaselecionada
                        Case 1
                            mtdCarregarGrp1CmbText("SELECT DISTINCT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE(((tblCentroCusto.CentroCusto) LIKE '" & vetDadoSelecionado(9) & "') AND (Funcao LIKE '%" & "Gerente" & "%')) ORDER BY tblCentroCusto.CentroCusto;")
                            mtdCarregarDtgv1(numlinhaselecionada)
                        Case 2
                            mtdCarregarGrp1CmbText("SELECT DISTINCT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE ((tblEmpregados.Orgao LIKE '" & vetDadoSelecionado(2) & "') AND ((Funcao LIKE '%" & "Assistente de Diretor" & "%') OR (Funcao LIKE '%" & "Superintendente" & "%') OR (Funcao LIKE '%" & "Gerente" & "%'))) ORDER BY tblEmpregados.Orgao, tblEmpregados.Funcao;")
                            mtdCarregarDtgv1(numlinhaselecionada)
                        Case 3
                            mtdCarregarGrp1CmbText("SELECT DISTINCT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE (tblEmpregados.Nome LIKE '" & vetDadoSelecionado(0) & "') ORDER BY tblEmpregados.Nome;")
                            mtdCarregarDtgv1(numlinhaselecionada)
                        Case 4
                            mtdCarregarGrp1CmbText("SELECT DISTINCT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE (tblEmpregados.Matricula LIKE '" & vetDadoSelecionado(1) & "') ORDER BY tblEmpregados.Matricula;")
                            mtdCarregarDtgv1(numlinhaselecionada)
                    End Select
                Catch
                Finally
                    mtdSalvar()
                End Try
            End If
        End Sub

        Private Sub dtgv1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgv1.MouseDoubleClick
            Try
                If dtgv1.Columns.Count > 0 Then
                    If dtgv1.Rows.Count > 0 Then
                        If (numlinhaselecionada > -1 And numcolunaselecionada > -1) Then
                            Dim valorlinhadtgv1 As String = dtgv1.Item(numcolunaselecionada, numlinhaselecionada).Value.ToString()
                            Dim objSugestionador As frmSugestionador = New frmSugestionador()
                            objSugestionador.prpFormulario = Me.Name
                            objSugestionador.prpTabela = bcmb1.Text
                            objSugestionador.prpTextoFormulario = "Escolha o Usuário a ser incluído"
                            objSugestionador.prpcorFundoLsv1 = Color.Lavender
                            Select Case numcolunaselecionada
                                Case 1
                                    objSugestionador.mtdCarregarLsv("SELECT DISTINCT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE(((tblCentroCusto.CentroCusto) LIKE '%" & valorlinhadtgv1 & "%') AND (Funcao LIKE '%" & "Gerente" & "%')) ORDER BY tblCentroCusto.CentroCusto;")
                                    objSugestionador.MdiParent = frmPrincipal
                                    objSugestionador.Show()
                                Case 2
                                    objSugestionador.mtdCarregarLsv("SELECT DISTINCT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE ((tblEmpregados.Orgao LIKE '%" & valorlinhadtgv1 & "%') AND ((Funcao LIKE '%" & "Assistente de Diretor" & "%') OR (Funcao LIKE '%" & "Superintendente" & "%') OR (Funcao LIKE '%" & "Gerente" & "%'))) ORDER BY tblEmpregados.Orgao, tblEmpregados.Funcao;")
                                    objSugestionador.MdiParent = frmPrincipal
                                    objSugestionador.Show()
                                Case 3
                                    objSugestionador.mtdCarregarLsv("SELECT DISTINCT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE (tblEmpregados.Nome LIKE '%" & valorlinhadtgv1 & "%') ORDER BY tblEmpregados.Nome;")
                                    objSugestionador.MdiParent = frmPrincipal
                                    objSugestionador.Show()
                                Case 4
                                    objSugestionador.mtdCarregarLsv("SELECT DISTINCT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE (tblEmpregados.Matricula LIKE '%" & valorlinhadtgv1 & "%') ORDER BY tblEmpregados.Matricula;")
                                    objSugestionador.MdiParent = frmPrincipal
                                    objSugestionador.Show()
                            End Select
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Public Sub mtdAtualizarDtgv2(ByVal vetDadoSelecionado As String())
            If MessageBox.Show("Deseja realmente atualizar os dados do registro?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    mtdCarregarGrp2CmbText("SELECT DISTINCT tblBensEletronorte.* FROM tblBensEletronorte WHERE (tblBensEletronorte.Imobilizado LIKE '" & vetDadoSelecionado(0) & "') ORDER BY tblBensEletronorte.Imobilizado;")
                    mtdCarregarDtgv2(numlinhaselecionada)
                Catch
                Finally
                    mtdSalvar()
                End Try
            End If
        End Sub

        Private Sub dtgv2_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgv2.MouseDoubleClick
            Try
                If dtgv2.Columns.Count > 0 Then
                    If dtgv2.Rows.Count > 0 Then
                        If (numlinhaselecionada > -1 And numcolunaselecionada > -1) Then
                            Dim valorlinhadtgv2 As String = dtgv2.Item(numcolunaselecionada, numlinhaselecionada).Value.ToString()
                            Dim objSugestionador As frmSugestionador = New frmSugestionador()
                            objSugestionador.prpFormulario = Me.Name
                            objSugestionador.prpTabela = bcmb1.Text
                            objSugestionador.prpTextoFormulario = "Escolha o Bem a ser incluído"
                            objSugestionador.prpcorFundoLsv1 = Color.Lavender
                            Select Case numcolunaselecionada
                                Case 3
                                    objSugestionador.mtdCarregarLsv("SELECT DISTINCT tblBensEletronorte.* FROM tblBensEletronorte WHERE (tblBensEletronorte.Patrimonio LIKE '%" & valorlinhadtgv2 & "%') ORDER BY tblBensEletronorte.Patrimonio, tblBensEletronorte.Imobilizado;")
                                    objSugestionador.MdiParent = frmPrincipal
                                    objSugestionador.Show()
                                Case 4
                                    objSugestionador.mtdCarregarLsv("SELECT DISTINCT tblBensEletronorte.* FROM tblBensEletronorte WHERE (tblBensEletronorte.Imobilizado LIKE '%" & valorlinhadtgv2 & "%') ORDER BY tblBensEletronorte.Imobilizado;")
                                    objSugestionador.MdiParent = frmPrincipal
                                    objSugestionador.Show()
                                Case 5
                                    objSugestionador.mtdCarregarLsv("SELECT DISTINCT tblBensEletronorte.* FROM tblBensEletronorte WHERE (tblBensEletronorte.Denominacao LIKE '%" & valorlinhadtgv2 & "%') ORDER BY tblBensEletronorte.Denominacao;")
                                    objSugestionador.MdiParent = frmPrincipal
                                    objSugestionador.Show()
                                Case 6
                                    objSugestionador.mtdCarregarLsv("SELECT DISTINCT tblBensEletronorte.* FROM tblBensEletronorte WHERE (tblBensEletronorte.N_Serie LIKE '%" & valorlinhadtgv2 & "%') ORDER BY tblBensEletronorte.N_Serie;")
                                    objSugestionador.MdiParent = frmPrincipal
                                    objSugestionador.Show()
                                Case 7
                                Case 8
                            End Select
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub bcmb4_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb4.DropDown
            mtdCarregarBcmb45(bcmb4)
        End Sub

        Private Sub bcmb5_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcmb5.DropDown
            mtdCarregarBcmb45(bcmb5)
        End Sub

        Private Sub mtdCarregarBcmb45(ByVal bcmb As ToolStripComboBox)
            Select Case intdtgvSelecionado
                Case 1
                    strNomeTabelaPrincipal = strNomeTabelaCautela
                    mtdPreencherBcmb45("SELECT " & strNomeTabelaPrincipal & ".Codigo FROM " & strNomeTabelaPrincipal & " ORDER BY Codigo;", bcmb)
                Case 2
                    strNomeTabelaPrincipal = strNomeTabelaCautelaBens
                    Try
                        mtdPreencherBcmb45("SELECT " & strNomeTabelaPrincipal & ".Contador FROM " & strNomeTabelaPrincipal & " WHERE " & strNomeTabelaPrincipal & ".Codigo LIKE " & dtgv2.Item(1, 0).Value.ToString() & " ORDER BY Contador;", bcmb)
                    Catch
                    End Try
            End Select
        End Sub

        Private Sub frmCautelas_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
            frmPrincipal.numFormularioSelecionado = 1
        End Sub

        Private Sub frmCautelas_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
            frmPrincipal.numFormularioSelecionado = 0
        End Sub

        Private Sub mtdCampoMaiusculoDTGV(ByRef dtgv As DataGridView, ByVal linhaselecionada As Integer)
            Dim objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
            Dim strTemp As String = String.Empty
            Dim numMaxColuna As Integer = dtgv.Columns.Count
            Try
                For coluna As Integer = 0 To numMaxColuna - 1 Step 1
                    strTemp = dtgv.Item(coluna, linhaselecionada).Value().ToString()
                    dtgv.Item(coluna, linhaselecionada).Value() = objManipuladorTexto.mtdExecutarTudo(strTemp)
                Next
            Catch
            End Try
        End Sub

        Private Sub txtAcrescentar_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAcrescentar.Enter
            txtAcrescentar.Text = String.Empty
        End Sub

        Private Sub txtAcrescentar_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAcrescentar.Leave
            If txtAcrescentar.Text = String.Empty Then
                txtAcrescentar.Text = "1"
            End If
        End Sub

        Private Sub txtProcurar_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcurar.Enter
            txtProcurar.Text = String.Empty
            txtProcurar.Font = New System.Drawing.Font("Segoe UI", 9, FontStyle.Regular)
        End Sub

        Private Function mtdColorirBensPatrimonioNSerieRepetido(ByVal Patrimonio As Integer, ByVal NSerie As String) As Boolean
            Dim saida As Boolean = False
            Try
                Dim valorcodigodtgv2 As Integer = Int32.Parse(dtgv2.Item(1, numlinhaselecionada).Value.ToString())
                Dim valorpatrimoniodtgv2 As Integer = Int32.Parse(dtgv2.Item(3, numlinhaselecionada).Value.ToString())
                Dim valornseriedtgv2 As String = dtgv2.Item(6, numlinhaselecionada).Value.ToString()
                Dim objBDPrincipal1 As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
                      ( _
                      frmPrincipal.strConexaoBancoDadosPrincipal, _
                      "SELECT tblCautelaBens.* FROM tblCautelaBens WHERE tblCautelaBens.Codigo LIKE '" & _
                      valorcodigodtgv2 & _
                      "' AND tblCautelaBens.Patrimonio LIKE '" & _
                      valorpatrimoniodtgv2 & _
                      "';", _
                      clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
                      )
                Dim objBDPrincipal2 As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
                      ( _
                      frmPrincipal.strConexaoBancoDadosPrincipal, _
                      "SELECT tblCautelaBens.* FROM tblCautelaBens WHERE tblCautelaBens.Codigo LIKE '" & _
                      valorcodigodtgv2 & _
                      "' AND tblCautelaBens.N_Serie LIKE '" & _
                      valornseriedtgv2 & _
                      "';", _
                      clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
                      )
                objBDPrincipal1.mtdAbrirConexao()
                objBDPrincipal1.mtdExecutarComando()
                objBDPrincipal2.mtdAbrirConexao()
                objBDPrincipal2.mtdExecutarComando()
                Dim strValor1 As String = String.Empty
                Dim strValor2 As String = String.Empty
                Dim EnderecoEncontrado(dtgv2.ColumnCount - 1, dtgv2.RowCount - 1) As Boolean
                Dim estiloValorEncontrado1 As New DataGridViewCellStyle()
                Dim estiloValorEncontrado2 As New DataGridViewCellStyle()
                Dim estiloValorEncontrado12 As New DataGridViewCellStyle()
                Dim estiloValorNaoEncontrado As New DataGridViewCellStyle()
                If objBDPrincipal1.mtdNumeroLinhas() >= 2 Or objBDPrincipal2.mtdNumeroLinhas() >= 2 Then
                    Dim selecionar As Boolean = False
                    estiloValorEncontrado1.BackColor = Color.Salmon
                    estiloValorEncontrado2.BackColor = Color.Pink
                    estiloValorEncontrado12.BackColor = Color.Plum
                    estiloValorNaoEncontrado.BackColor = Color.Empty
                    estiloValorNaoEncontrado.ForeColor = Color.Empty
                    For linha As Integer = 0 To dtgv2.RowCount - 1 Step 1
                        strValor1 = dtgv2.Item(3, linha).Value().ToString()
                        strValor1 = strValor1.ToLower()
                        If strValor1.Equals(valorpatrimoniodtgv2.ToString().ToLower()) Then
                            EnderecoEncontrado(3, linha) = True
                        End If

                        strValor2 = dtgv2.Item(6, linha).Value().ToString()
                        strValor2 = strValor2.ToLower()
                        If strValor2.Equals(valornseriedtgv2.ToString().ToLower()) Then
                            EnderecoEncontrado(6, linha) = True
                        End If
                    Next
                    For linha As Integer = EnderecoEncontrado.GetLowerBound(1) To EnderecoEncontrado.GetUpperBound(1) Step 1
                        If EnderecoEncontrado(3, linha) Or EnderecoEncontrado(6, linha) Then
                            For coluna As Integer = 0 To dtgv2.ColumnCount - 1 Step 1
                                If EnderecoEncontrado(3, linha) And EnderecoEncontrado(6, linha) Then
                                    dtgv2.Item(coluna, linha).Style = estiloValorEncontrado12
                                ElseIf EnderecoEncontrado(3, linha) Then
                                    dtgv2.Item(coluna, linha).Style = estiloValorEncontrado1
                                ElseIf EnderecoEncontrado(6, linha) Then
                                    dtgv2.Item(coluna, linha).Style = estiloValorEncontrado2
                                End If
                            Next
                        Else
                            For coluna As Integer = 0 To dtgv2.ColumnCount - 1 Step 1
                                dtgv2.Item(coluna, linha).Style = estiloValorNaoEncontrado
                            Next
                        End If
                    Next
                    saida = True
                Else
                    For linha As Integer = EnderecoEncontrado.GetLowerBound(1) To EnderecoEncontrado.GetUpperBound(1) Step 1
                        For coluna As Integer = 0 To dtgv2.ColumnCount - 1 Step 1
                            dtgv2.Item(coluna, linha).Style = estiloValorNaoEncontrado
                        Next
                    Next
                    saida = False
                End If

                objBDPrincipal1.mtdFecharConexao()
                objBDPrincipal2.mtdFecharConexao()
            Catch
            End Try
            Return saida
        End Function

        Private Sub btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4.Click
            Dim valorlinhadtgv2 As String = String.Empty
            Dim intPasso As Integer = 1
            Dim strAuxiliar As String = String.Empty
            If MessageBox.Show("Deseja fazer a alteração em massa? pois poderá haver manipulação de registros de forma errada.", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                For contador As Integer = 0 To dtgv2.RowCount - 1 Step intPasso
                    Try
                        valorlinhadtgv2 = dtgv2.Item(3, contador).Value.ToString()
                        If Not valorlinhadtgv2 = String.Empty Or Not valorlinhadtgv2 = "0" Then
                            If dtgv2.Item(4, contador).Value.ToString() = String.Empty Or cbx2.Checked Then
                                If mtdCarregarGrp2CmbText("SELECT DISTINCT tblBensEletronorte.* FROM tblBensEletronorte WHERE (tblBensEletronorte.Patrimonio LIKE '" & valorlinhadtgv2 & "') ORDER BY tblBensEletronorte.Patrimonio, tblBensEletronorte.Imobilizado;", False) Then
                                    mtdCarregarDtgv2(contador)
                                End If
                                dtgv2.Item(3, contador).Selected = True
                                dtgv2.BeginEdit(True)
                                dtgv2.EndEdit()
                            End If
                        End If
                    Catch
                    End Try
                Next
                MessageBox.Show("Alteração em massa realizada com sucesso.", "Aviso!", MessageBoxButtons.OK)
            End If
            cbx2.Checked = False
        End Sub

        Private Sub frmCautelas_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            objBDPrincipal1.mtdFecharConexao()
            objBDPrincipal2.mtdFecharConexao()
        End Sub

        Private Sub mtdReplicarCautela()
            If dtgv1.Columns.Count > 0 Then
                If dtgv1.Rows.Count > 0 Then
                    If dtgv2.Columns.Count > 0 Then
                        If dtgv2.Rows.Count > 0 Then
                            If MessageBox.Show("Deseja realizar a replicação da Cautela selecionada?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                For numeroCautelas As Integer = 0 To Integer.Parse(txtAcrescentar.Text) - 1 Step 1
                                    Dim strPrazoEntregaCautela As String = objRegistroWindows.mtdObterDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela").ToString()
                                    If objRegistroWindows.getmensagemExcecao.Equals("Object reference not set to an instance of an object.") Or objRegistroWindows.getmensagemExcecao = "Não há conteúdo na variável mensagemExcecao." Then
                                        objRegistroWindows.mtdSalvarDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela", frmConfiguracoes.PrazoEntregaCautela.ToString(), Microsoft.Win32.RegistryValueKind.DWord)
                                        strPrazoEntregaCautela = objRegistroWindows.mtdObterDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela").ToString()
                                    End If

                                    Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                                    objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(strConexaoBancoDados, True)

                                    Dim strCodigoSelecionado As String = dtgv1.Item(0, dtgv1.SelectedCells(0).RowIndex).Value.ToString()

                                    objImplementacaoBancoDados.mtdSelecionarDados("*", strNomeTabelaCautelaBens, "Codigo", "LIKE", strCodigoSelecionado, "Patrimonio", True)

                                    Dim intNumeroLinhas As Integer = objImplementacaoBancoDados.mtdNumeroLinhas()
                                    objImplementacaoBancoDados.mtdDefinirLeitorDados()
                                    Dim DadosCB()() As Object = New Object(intNumeroLinhas)() {}
                                    DadosCB(0) = objImplementacaoBancoDados.mtdObterCabecalhoColunas()

                                    Dim contador As Integer = 0
                                    While (objImplementacaoBancoDados.mtdProximoRegistro())
                                        contador += 1
                                        objImplementacaoBancoDados.mtdObterValorRegistro(DadosCB(contador))
                                    End While

                                    Dim ulngCodigo As ULong = frmPrincipal.mtdGerarProximoNumeroCodigoPrincipal(frmPrincipal.intMultiplicadorCodigoCautelas, strNomeTabelaCautela, "Codigo")
                                    objImplementacaoBancoDados.mtdSelecionarDados("*", strNomeTabelaCautela)
                                    objImplementacaoBancoDados.mtdDefinirLeitorDados()
                                    Dim DadosC()() As Object = New Object(1)() {}
                                    DadosC(0) = objImplementacaoBancoDados.mtdObterCabecalhoColunas()
                                    objImplementacaoBancoDados.mtdProximoRegistro()

                                    DadosC(1) = New Object() { _
                                        ulngCodigo, _
                                        String.Format("{0}", 0), _
                                        String.Format("'{0}'", String.Empty), _
                                        String.Format("'{0}'", String.Empty), _
                                        String.Format("{0}", 0), _
                                        String.Format("'{0}'", frmPrincipal.barlblMostrContUser.Text), _
                                        String.Format("#{0}#", frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime(DateTime.Now))), _
                                        String.Format("'{0}'", String.Empty), _
                                        String.Format("#{0}#", #1/1/2000#), _
                                        String.Format("#{0}#", #1/1/2000#), _
                                        String.Format("#{0}#", #1/1/2000#), _
                                        String.Format("#{0}#", #1/1/2000#), _
                                        String.Format("{0}", strPrazoEntregaCautela), _
                                        String.Format("'{0}'", String.Empty) _
                                    }

                                    For contador = DadosCB.GetLowerBound(0) + 1 To DadosCB.GetUpperBound(0) Step 1
                                        DadosCB(contador)(0) = String.Format("{0}", frmPrincipal.mtdGerarProximoNumeroContadorPrincipal(strNomeTabelaCautelaBens, "Contador") + contador - 1)
                                        DadosCB(contador)(1) = String.Format("{0}", ulngCodigo)
                                        DadosCB(contador)(2) = String.Format("{0}", contador)
                                        DadosCB(contador)(3) = String.Format("{0}", DadosCB(contador)(3))
                                        DadosCB(contador)(4) = String.Format("'{0}'", DadosCB(contador)(4))
                                        DadosCB(contador)(5) = String.Format("'{0}'", DadosCB(contador)(5))
                                        DadosCB(contador)(6) = String.Format("'{0}'", DadosCB(contador)(6))
                                        DadosCB(contador)(7) = String.Format("'{0}'", DadosCB(contador)(7))
                                        DadosCB(contador)(8) = String.Format("'{0}'", DadosCB(contador)(8))
                                        DadosCB(contador)(9) = String.Format("'{0}'", frmPrincipal.barlblMostrContUser.Text)
                                        DadosCB(contador)(10) = String.Format("#{0}#", frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime(DateTime.Now)))
                                        DadosCB(contador)(11) = String.Format("'{0}'", String.Empty)
                                        DadosCB(contador)(12) = String.Format("#{0}#", #1/1/2000#)
                                    Next

                                    objImplementacaoBancoDados.mtdInserirDados(strNomeTabelaCautela, DadosC)
                                    objImplementacaoBancoDados.mtdInserirDados(strNomeTabelaCautelaBens, DadosCB)
                                Next
                                mtdAtualizarDtgv1(strNomeTabelaCautela, "Codigo", frmPrincipal.intNumeroLinhasCautelas)
                                mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
                            End If
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub tsbReplicarCautela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReplicarCautela.Click
            mtdReplicarCautela()
            txtAcrescentar.Text = "1"
        End Sub

        Private Sub tsbConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbConsultar.Click
            mtdConteudoBtxt1(bcmb3.Text)
        End Sub

        Private Sub mtdAtualizarTs(ByRef Dtgv As System.Windows.Forms.DataGridView)
            Try
                tstxtLinhaSelecionada.Text = (numlinhaselecionada + 1).ToString()
                tstxtColunaSelecionada.Text = (numcolunaselecionada + 1).ToString()
                tstxtTotalLinhas.Text = (Dtgv.RowCount).ToString()
                tstxtTotalColunas.Text = (Dtgv.ColumnCount).ToString()
            Catch ex As Exception
                tstxtLinhaSelecionada.Text = "N/D"
                tstxtColunaSelecionada.Text = "N/D"
                tstxtTotalLinhas.Text = "N/D"
                tstxtTotalColunas.Text = "N/D"
            End Try

        End Sub

        Private Sub tsbEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEmail.Click
            frmPrincipal.mtdEnviarEmail()
        End Sub

        Public Sub mtdCorrigirBugCautela(ByVal CodigoSelecionado As Long)
            Try
                Dim strPrazoEntregaCautela As String = objRegistroWindows.mtdObterDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela").ToString()
                If objRegistroWindows.getmensagemExcecao.Equals("Object reference not set to an instance of an object.") Or objRegistroWindows.getmensagemExcecao = "Não há conteúdo na variável mensagemExcecao." Then
                    objRegistroWindows.mtdSalvarDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela", frmConfiguracoes.PrazoEntregaCautela.ToString(), Microsoft.Win32.RegistryValueKind.DWord)
                    strPrazoEntregaCautela = objRegistroWindows.mtdObterDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela").ToString()
                End If

                Dim objImplementacaoBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objImplementacaoBancoDados.mtdDefinirStringConexaoAccess(strConexaoBancoDados, True)

                Dim contador As Integer = 0
                Dim strCodigoSelecionado As String = CodigoSelecionado.ToString()

                objImplementacaoBancoDados.mtdSelecionarDados("*", strNomeTabelaCautela, "Codigo", "LIKE", strCodigoSelecionado, "Codigo", True)

                Dim intNumeroLinhas As Integer = objImplementacaoBancoDados.mtdNumeroLinhas()
                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                Dim DadosC()() As Object = New Object(1)() {}
                DadosC(0) = objImplementacaoBancoDados.mtdObterCabecalhoColunas()

                While (objImplementacaoBancoDados.mtdProximoRegistro())
                    contador += 1
                    objImplementacaoBancoDados.mtdObterValorRegistro(DadosC(contador))
                End While

                contador = 0

                objImplementacaoBancoDados.mtdSelecionarDados _
                ( _
                "*", _
                strNomeTabelaCautelaBens, _
                "Codigo", _
                "LIKE", _
                strCodigoSelecionado, _
                IIf(intcmb11IndiceSelecionado = 0, vetCamposTabelaCautelaBens(4), vetCamposTabelaCautelaBens(intcmb11IndiceSelecionado)).ToString(), _
                blnCrescente _
                )

                intNumeroLinhas = objImplementacaoBancoDados.mtdNumeroLinhas()
                objImplementacaoBancoDados.mtdDefinirLeitorDados()
                Dim DadosCB()() As Object = New Object(intNumeroLinhas)() {}
                DadosCB(0) = objImplementacaoBancoDados.mtdObterCabecalhoColunas()

                While (objImplementacaoBancoDados.mtdProximoRegistro())
                    contador += 1
                    objImplementacaoBancoDados.mtdObterValorRegistro(DadosCB(contador))
                End While

                'Dim ulngCodigo As ULong = frmPrincipal.mtdGerarProximoNumeroCodigoPrincipal(frmPrincipal.intMultiplicadorCodigoCautelas, strNomeTabelaCautelaBens, "Codigo")
                Dim ulngCodigo As ULong = System.Convert.ToUInt64(strCodigoSelecionado)
                objImplementacaoBancoDados.mtdSelecionarDados("*", strNomeTabelaCautelaBens)
                objImplementacaoBancoDados.mtdDefinirLeitorDados()

                objImplementacaoBancoDados.mtdProximoRegistro()

                For contador = DadosC.GetLowerBound(0) + 1 To DadosC.GetUpperBound(0) Step 1
                    DadosC(contador)(0) = String.Format("{0}", DadosC(contador)(0))
                    DadosC(contador)(1) = String.Format("{0}", DadosC(contador)(1))
                    DadosC(contador)(2) = String.Format("'{0}'", DadosC(contador)(2))
                    DadosC(contador)(3) = String.Format("'{0}'", DadosC(contador)(3))
                    DadosC(contador)(4) = String.Format("{0}", DadosC(contador)(4))
                    DadosC(contador)(5) = String.Format("'{0}'", DadosC(contador)(5))
                    DadosC(contador)(6) = String.Format("#{0}#", frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime(DadosC(contador)(6))))
                    DadosC(contador)(7) = String.Format("'{0}'", DadosC(contador)(7))
                    DadosC(contador)(8) = String.Format("#{0}#", frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime(DadosC(contador)(8))))
                    DadosC(contador)(9) = String.Format("#{0}#", frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime(DadosC(contador)(9))))
                    DadosC(contador)(10) = String.Format("#{0}#", frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime(DadosC(contador)(10))))
                    DadosC(contador)(11) = String.Format("#{0}#", frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime(DadosC(contador)(11))))
                    DadosC(contador)(12) = String.Format("{0}", DadosC(contador)(12))
                    DadosC(contador)(13) = String.Format("'{0}'", DadosC(contador)(13))
                Next


                Dim ulngAcumulador As ULong = ULong.MinValue

                For i As Integer = DadosCB.GetLowerBound(0) To DadosCB.GetUpperBound(0) Step 1
                    For j As Integer = DadosCB.GetLowerBound(0) To DadosCB.GetUpperBound(0) - 1 Step 1
                        If System.Convert.ToUInt64(DadosCB(contador)(0)) > System.Convert.ToUInt64(DadosCB(contador + 1)(0)) Then
                            ulngAcumulador = System.Convert.ToUInt64(DadosCB(contador)(0))
                            DadosCB(contador)(0) = DadosCB(contador + 1)(0)
                            DadosCB(contador + 1)(0) = ulngAcumulador
                        End If
                    Next
                Next

                For contador = DadosCB.GetLowerBound(0) + 1 To DadosCB.GetUpperBound(0) Step 1
                    'DadosCB(contador)(0) = String.Format("{0}", frmPrincipal.mtdGerarProximoNumeroContadorPrincipal(strNomeTabelaMBPBens, "Contador") + contador - 1)
                    DadosCB(contador)(0) = String.Format("{0}", System.Convert.ToUInt64(DadosCB(contador)(0)))
                    DadosCB(contador)(1) = String.Format("{0}", ulngCodigo)
                    DadosCB(contador)(2) = String.Format("{0}", contador)
                    DadosCB(contador)(3) = String.Format("{0}", DadosCB(contador)(3))
                    DadosCB(contador)(4) = String.Format("'{0}'", DadosCB(contador)(4))
                    DadosCB(contador)(5) = String.Format("'{0}'", DadosCB(contador)(5))
                    DadosCB(contador)(6) = String.Format("'{0}'", DadosCB(contador)(6))
                    DadosCB(contador)(7) = String.Format("'{0}'", DadosCB(contador)(7))
                    DadosCB(contador)(8) = String.Format("'{0}'", DadosCB(contador)(8))
                    DadosCB(contador)(9) = String.Format("'{0}'", DadosCB(contador)(9))
                    DadosCB(contador)(10) = String.Format("#{0}#", frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime(DadosCB(contador)(10))))
                    DadosCB(contador)(11) = String.Format("'{0}'", DadosCB(contador)(11))
                    DadosCB(contador)(12) = String.Format("#{0}#", frmPrincipal.mtdCorrigirBugData(Convert.ToDateTime(DadosCB(contador)(12))))
                Next

                mtdExcluir(dtgv1, objBDPrincipal1, "DELETE FROM tblCautela WHERE Codigo LIKE " & ulngCodigo.ToString(), System.Convert.ToInt64(ulngCodigo))
                objImplementacaoBancoDados.mtdInserirDados(strNomeTabelaCautela, DadosC)
                objImplementacaoBancoDados.mtdInserirDados(strNomeTabelaCautelaBens, DadosCB)

                mtdAtualizarDtgv1(strNomeTabelaCautela, "Codigo", frmPrincipal.intNumeroLinhasCautelas)
                mtdAtualizarDtgv2(strNomeTabelaCautelaBens, "Codigo")
            Catch ex As System.Exception
            End Try
        End Sub

        Private Sub tsbCorrigirBugCautela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCorrigirBugCautela.Click
            If dtgv1.Columns.Count > 0 Then
                If dtgv1.Rows.Count > 0 Then
                    If dtgv2.Columns.Count > 0 Then
                        If dtgv2.Rows.Count > 0 Then
                            If MessageBox.Show("Deseja corrigir o bug da Cautela selecionada?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                                mtdCorrigirBugCautela(System.Convert.ToInt64(dtgv1.Item(0, dtgv1.SelectedCells(0).RowIndex).Value))
                                frmPrincipal.mtdPreencherCmb(cmb11, "Alteração em Massa", vetCamposTabelaCautelaBens)
                            End If
                        End If
                    End If
                End If
            End If
        End Sub

        Private intcmb11IndiceSelecionado As Integer = 0

        Private Sub cmb11_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb11.DropDown
            frmPrincipal.mtdPreencherCmb(cmb11, "Alteração em Massa", vetCamposTabelaCautelaBens)
            btn3.Text = "C"
        End Sub

        Private Sub cmb11_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb11.DropDownClosed
            intcmb11IndiceSelecionado = cmb11.SelectedIndex
        End Sub

        Private blnCrescente As Boolean = True

        Private Sub btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click
            Select Case frmPrincipal.blnCrescente
                Case False
                    frmPrincipal.blnCrescente = True
                    btn3.Text = "C"
                Case True
                    frmPrincipal.blnCrescente = False
                    btn3.Text = "D"
            End Select
        End Sub

        Private Sub blblCarregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blblCarregar.Click
            'Select Case intdtgvSelecionado
            '    Case 1
            '        SQLLsvCautela = frmPrincipal.mtdPreencherLsv(lsvCautela, grpb1, strNomeTabelaCautela, bcmb2.Text)
            '    Case 2
            '        SQLLsvCautelaBens = frmPrincipal.mtdPreencherLsv(lsvCautelaBens, grpb2, strNomeTabelaCautelaBens, bcmb2.Text)
            'End Select

            mtdPreencherLsvCautela()
            mtdPreencherLsvCautelaBens()
        End Sub

        Private Sub mtdPreencherLsvCautela()
            Dim strTabela1 As String = String.Empty
            Dim strTabela2 As String = String.Empty
            Dim strColuna1 As String = IIf(bcmb2.Text <> String.Empty, bcmb2.Text, "Codigo").ToString()
            Dim strColuna2 As String = IIf(cmb12.SelectedIndex <> 0, cmb12.Text, "Patrimonio").ToString()
            Dim strCampoOrdenador As String = String.Empty
            Dim blnOrdenacaoCrescente As Boolean = False

            If vetCamposTabelaCautela.Contains(strColuna1) Then
                strTabela1 = strNomeTabelaCautela
                strCampoOrdenador = strColuna1
                If strCampoOrdenador = "Codigo" Then
                    blnOrdenacaoCrescente = False
                Else
                    blnOrdenacaoCrescente = True
                End If
            ElseIf vetCamposTabelaCautelaBens.Contains(strColuna1) Then
                strTabela1 = strNomeTabelaCautelaBens
                strCampoOrdenador = strColuna2
                blnOrdenacaoCrescente = True
            End If

            If vetCamposTabelaCautela.Contains(strColuna2) Then
                strTabela2 = strNomeTabelaCautela
            ElseIf vetCamposTabelaCautelaBens.Contains(strColuna2) Then
                strTabela2 = strNomeTabelaCautelaBens
            End If

            If System.Convert.ToInt32(txt1.Text) <= 0 Then
                SQLLsvCautela = frmPrincipal.mtdConsultarItensRepetidosCampoInformado_(lsvCautela, grpb1, String.Format("{0}.{1}", strTabela1, strColuna1), strNomeTabelaCautela, strNomeTabelaCautelaBens, strTabela1, strColuna1, String.Empty, String.Format("{0}.{1}", strTabela1, strCampoOrdenador), blnOrdenacaoCrescente, intRepeticaoCautela)
            Else
                SQLLsvCautela = frmPrincipal.mtdConsultarItensRepetidosCampoInformado_(lsvCautela, grpb1, String.Format("{0}.{1}", strTabela1, strColuna1), String.Format("{0}.{1}", strTabela2, strColuna2), strNomeTabelaCautela, strNomeTabelaCautelaBens, strTabela1, strColuna1, String.Empty, String.Format("{0}.{1}", strTabela1, strCampoOrdenador), blnOrdenacaoCrescente, intRepeticaoCautela)
            End If
        End Sub

        Private Sub btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5.Click
            mtdPreencherLsvCautela()
        End Sub

        Private Sub mtdPreencherLsvCautelaBens()
            Dim strTabela1 As String = String.Empty
            Dim strTabela2 As String = String.Empty
            Dim strColuna1 As String = IIf(bcmb2.Text <> String.Empty, bcmb2.Text, "Codigo").ToString()
            Dim strColuna2 As String = IIf(cmb13.SelectedIndex <> 0, cmb13.Text, "Patrimonio").ToString()
            Dim strCampoOrdenador As String = String.Empty
            Dim blnOrdenacaoCrescente As Boolean = False

            If vetCamposTabelaCautela.Contains(strColuna1) Then
                strTabela1 = strNomeTabelaCautela
                strCampoOrdenador = strColuna1
                If strCampoOrdenador = "Contador" Then
                    blnOrdenacaoCrescente = False
                Else
                    blnOrdenacaoCrescente = True
                End If
            ElseIf vetCamposTabelaCautelaBens.Contains(strColuna1) Then
                strTabela1 = strNomeTabelaCautelaBens
                strCampoOrdenador = strColuna2
                blnOrdenacaoCrescente = True
            End If

            If vetCamposTabelaCautela.Contains(strColuna2) Then
                strTabela2 = strNomeTabelaCautela
            ElseIf vetCamposTabelaCautelaBens.Contains(strColuna2) Then
                strTabela2 = strNomeTabelaCautelaBens
            End If

            If System.Convert.ToInt32(txt2.Text) <= 0 Then
                SQLLsvCautelaBens = frmPrincipal.mtdConsultarItensRepetidosCampoInformado_(lsvCautelaBens, grpb2, String.Format("{0}.{1}", strTabela1, strColuna1), strNomeTabelaCautela, strNomeTabelaCautelaBens, strTabela1, strColuna1, frmCautelas.Codigo.ToString(), String.Format("{0}.{1}", strTabela1, strCampoOrdenador), blnOrdenacaoCrescente, intRepeticaoCautelaBens)
            Else
                SQLLsvCautelaBens = frmPrincipal.mtdConsultarItensRepetidosCampoInformado_(lsvCautelaBens, grpb2, String.Format("{0}.{1}", strTabela1, strColuna1), String.Format("{0}.{1}", strTabela2, strColuna2), strNomeTabelaCautela, strNomeTabelaCautelaBens, strTabela1, strColuna1, frmCautelas.Codigo.ToString(), String.Format("{0}.{1}", strTabela1, strCampoOrdenador), blnOrdenacaoCrescente, intRepeticaoCautelaBens)
            End If
        End Sub

        Private Sub btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click
            mtdPreencherLsvCautelaBens()
        End Sub

        Private Sub cmb12_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb12.DropDown
            frmPrincipal.mtdPreencherCmb(cmb12, "Todos", vetCamposTabelaCautela, vetCamposTabelaCautelaBens, vetCamposTabelaCautela.Length + intColunaTabelaCautelaBensPatrimonio + 1)
        End Sub

        Private Sub cmb13_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb13.DropDown
            frmPrincipal.mtdPreencherCmb(cmb13, "Todos", vetCamposTabelaCautela, vetCamposTabelaCautelaBens, vetCamposTabelaCautela.Length + intColunaTabelaCautelaBensPatrimonio + 1)
        End Sub

        Private Sub txt1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt1.Leave
            Try
                intRepeticaoCautela = System.Convert.ToInt32(txt1.Text)
            Catch ex As System.Exception
                txt1.Text = System.Convert.ToString(intRepeticaoCautela)

                Dim strExcecao As String = "txt1_Leave: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub txt2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt2.Leave
            Try
                intRepeticaoCautelaBens = System.Convert.ToInt32(txt2.Text)
            Catch ex As System.Exception
                txt2.Text = System.Convert.ToString(intRepeticaoCautelaBens)

                Dim strExcecao As String = "txt2_Leave: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdLsvSelecao(ByVal IndiceBcmb1 As Integer, ByVal Tabela As String, ByVal Coluna As String, ByVal Dado As String)
            bcmb1.SelectedIndex = IndiceBcmb1
            strNomeTabelaPrincipal = Tabela
            bcmb2.Text = Coluna
            btxt1.Text = Dado
        End Sub

        Public Shared strTabelaOrdenadora As String = String.Empty

        Private Sub lsvCautela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvCautela.Click
            Try
                Dim strColunaOrdenadora As String = lsvCautela.Columns(frmPrincipal.mtdObterIndiceColunaClicada(lsvCautela)).Text

                If vetCamposTabelaCautela.Contains(strColunaOrdenadora) Then
                    strTabelaOrdenadora = strNomeTabelaCautela
                ElseIf vetCamposTabelaCautelaBens.Contains(strColunaOrdenadora) Then
                    strTabelaOrdenadora = strNomeTabelaCautelaBens
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private lsvCautelaIndiceItemSelecionado As Integer = -1

        Private Sub lsvCautela_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lsvCautela.ItemSelectionChanged
            If lsvCautela.Columns.Count > 0 Then
                If lsvCautela.Items.Count > 0 Then
                    lsvCautelaIndiceColunaSelecionada = frmPrincipal.mtdObterIndiceColunaClicada(lsvCautela)
                    lsvCautelaIndiceItemSelecionado = e.ItemIndex

                    Dim strColuna As String = lsvCautela.Columns(lsvCautelaIndiceColunaSelecionada).Text
                    Dim strDado As String = String.Format("{0}", lsvCautela.Items(lsvCautelaIndiceItemSelecionado).SubItems(lsvCautelaIndiceColunaSelecionada).Text)
                    Dim strTabelaOrdenadora As String = String.Empty
                    Dim strCampoOrdenador As String = String.Empty
                    Dim blnOrdenacaoCrescente As Boolean = False

                    If strColuna = "Contador" Then
                        strColuna = lsvCautela.Columns(0).Text
                        strDado = String.Format("{0}", lsvCautela.Items(lsvCautelaIndiceItemSelecionado).SubItems(0).Text)
                    End If

                    If vetCamposTabelaCautela.Contains(strColuna) Then
                        mtdLsvSelecao(0, strNomeTabelaCautela, strColuna, strDado)
                        strTabelaOrdenadora = strNomeTabelaCautela
                        strCampoOrdenador = "Codigo"
                        blnOrdenacaoCrescente = False
                    ElseIf vetCamposTabelaCautelaBens.Contains(strColuna) Then
                        mtdLsvSelecao(1, strNomeTabelaCautelaBens, strColuna, strDado)
                        strTabelaOrdenadora = strNomeTabelaCautela
                        strCampoOrdenador = "Codigo"
                        blnOrdenacaoCrescente = False
                    End If

                    mtdPesquisarAtualizarDtgv1(strNomeTabelaPrincipal, strColuna, strDado, strTabelaOrdenadora, strCampoOrdenador, blnOrdenacaoCrescente, False)

                    If vetCamposTabelaCautela.Contains(strColuna) Then
                        mtdLsvSelecao(0, strNomeTabelaCautela, strColuna, strDado)
                        strTabelaOrdenadora = strNomeTabelaCautelaBens
                        strCampoOrdenador = "Contador"
                        blnOrdenacaoCrescente = True
                    ElseIf vetCamposTabelaCautelaBens.Contains(strColuna) Then
                        mtdLsvSelecao(1, strNomeTabelaCautelaBens, strColuna, strDado)
                        strTabelaOrdenadora = strNomeTabelaCautelaBens
                        strCampoOrdenador = "Contador"
                        blnOrdenacaoCrescente = True
                    End If

                    mtdPesquisarAtualizarDtgv2(strNomeTabelaPrincipal, strColuna, strDado, strTabelaOrdenadora, strCampoOrdenador, blnOrdenacaoCrescente, False)

                    mtdPreencherLsvCautelaBens()
                End If
            End If
        End Sub

        Private Sub lsvCautelaBens_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvCautelaBens.Click
            Try
            Catch ex As Exception

            End Try
        End Sub

        Private lsvCautelaBensIndiceItemSelecionado As Integer = -1

        Private Sub lsvCautelaBens_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lsvCautelaBens.ItemSelectionChanged
            If lsvCautelaBens.Columns.Count > 0 Then
                If lsvCautelaBens.Items.Count > 0 Then
                    lsvCautelaBensIndiceColunaSelecionada = frmPrincipal.mtdObterIndiceColunaClicada(lsvCautelaBens)
                    lsvCautelaBensIndiceItemSelecionado = e.ItemIndex

                    Dim strColuna As String = lsvCautelaBens.Columns(lsvCautelaBensIndiceColunaSelecionada).Text
                    Dim strDado As String = String.Format("{0}", lsvCautelaBens.Items(lsvCautelaBensIndiceItemSelecionado).SubItems(lsvCautelaBensIndiceColunaSelecionada).Text)
                    Dim strTabelaOrdenadora As String = String.Empty
                    Dim strCampoOrdenador As String = String.Empty
                    Dim blnOrdenacaoCrescente As Boolean = False

                    If strColuna = "Contador" Then
                        strColuna = lsvCautelaBens.Columns(0).Text
                        strDado = String.Format("{0}", lsvCautelaBens.Items(lsvCautelaBensIndiceItemSelecionado).SubItems(0).Text)
                    End If

                    If vetCamposTabelaCautela.Contains(strColuna) Then
                        mtdLsvSelecao(0, strNomeTabelaCautela, strColuna, strDado)
                        strTabelaOrdenadora = strNomeTabelaCautela
                        strCampoOrdenador = "Codigo"
                        blnOrdenacaoCrescente = False
                    ElseIf vetCamposTabelaCautelaBens.Contains(strColuna) Then
                        mtdLsvSelecao(1, strNomeTabelaCautelaBens, strColuna, strDado)
                        strTabelaOrdenadora = strNomeTabelaCautela
                        strCampoOrdenador = "Codigo"
                        blnOrdenacaoCrescente = False
                    End If

                    mtdPesquisarAtualizarDtgv1(strNomeTabelaPrincipal, strColuna, strDado, strTabelaOrdenadora, strCampoOrdenador, blnOrdenacaoCrescente, False)

                    If vetCamposTabelaCautela.Contains(strColuna) Then
                        mtdLsvSelecao(0, strNomeTabelaCautela, strColuna, strDado)
                        strTabelaOrdenadora = strNomeTabelaCautelaBens
                        strCampoOrdenador = "Contador"
                        blnOrdenacaoCrescente = True
                    ElseIf vetCamposTabelaCautelaBens.Contains(strColuna) Then
                        mtdLsvSelecao(1, strNomeTabelaCautelaBens, strColuna, strDado)
                        strTabelaOrdenadora = strNomeTabelaCautelaBens
                        strCampoOrdenador = "Contador"
                        blnOrdenacaoCrescente = True
                    End If

                    mtdPesquisarAtualizarDtgv2(strNomeTabelaPrincipal, strColuna, strDado, lsvCautelaBens.Columns(0).Text, lsvCautelaBens.Items(lsvCautelaBensIndiceItemSelecionado).SubItems(0).Text, strTabelaOrdenadora, strCampoOrdenador, blnOrdenacaoCrescente)
                End If
            End If
        End Sub

        Private blnOrdenarCrescente As Boolean = True

        Private SQLLsv1 As String = String.Empty

        Private Sub lsv1_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsv1.ColumnClick
            frmPrincipal.mtdOrdenarColunasLsv(lsv1, SQLLsv1, e.Column)
        End Sub

        Private lsvCautelaIndiceColunaSelecionada As Integer = -1
        Private SQLLsvCautela As String = String.Empty

        Private Sub lsvCautela_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvCautela.ColumnClick
            lsvCautelaIndiceColunaSelecionada = e.Column

            frmPrincipal.mtdOrdenarColunasLsv(lsvCautela, SQLLsvCautela, e.Column)
        End Sub

        Private lsvCautelaBensIndiceColunaSelecionada As Integer = -1
        Private SQLLsvCautelaBens As String = String.Empty

        Private Sub lsvCautelaBens_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvCautelaBens.ColumnClick
            frmPrincipal.mtdOrdenarColunasLsv(lsvCautelaBens, SQLLsvCautelaBens, e.Column)
        End Sub

        Private Sub lsvCautela_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvCautela.DoubleClick
            frmPrincipal.mtdChecarItens(lsvCautela)
        End Sub

        Private Sub lsvCautelaBens_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsvCautelaBens.DoubleClick
            frmPrincipal.mtdChecarItens(lsvCautelaBens)
        End Sub

        Private Sub mtdPesquisarAtualizarDtgv1()
            If dtgv2.ColumnCount > 0 And dtgv2.RowCount > 0 Then
                Dim strTabela As String = strNomeTabelaCautelaBens
                Dim strColuna As String = dtgv2.Columns.Item(numcolunaselecionada).HeaderText
                Dim strDado As String = dtgv2.Item(numcolunaselecionada, numlinhaselecionada).Value.ToString()

                mtdPesquisarAtualizarDtgv1(strTabela, strColuna, strDado, strColuna, strTabela, True, False)
            End If
        End Sub

        Private Sub mtdPesquisarAtualizarDtgv1(ByVal Tabela As String, ByVal Coluna As String, ByVal Dado As String, ByVal TabelaOrdenadora As String, ByVal ColunaOrdenadora As String, ByVal Crescente As Boolean, ByVal PermitirCuringa As Boolean)
            Dim strTabela As String = Tabela
            Dim strColuna As String = Coluna
            Dim strDado As String = Dado
            Dim strConteudo As String = String.Empty

            If PermitirCuringa Then
                Select Case intModobcmb3
                    Case 1
                        strConteudo = "'{0}'"
                    Case 2
                        strConteudo = "'%{0}%'"
                End Select
            Else
                strConteudo = "'{0}'"
            End If

            If strColuna <> String.Empty Then
                Dim SQL As String = String.Format("SELECT DISTINCT {0} FROM {1} LEFT JOIN {2} ON {1}.{3}={2}.{4} WHERE {5}.{6} LIKE {7} ORDER BY {8}{9}", objBDPrincipal1.mtdVetorLinhaCampos(strNomeTabelaCautela, frmCautelas.vetCamposTabelaCautela), strNomeTabelaCautela, strNomeTabelaCautelaBens, "Codigo", "Codigo", strTabela, strColuna, String.Format(strConteudo, strDado), String.Format("{0}.{1}", TabelaOrdenadora, ColunaOrdenadora), IIf(Crescente, String.Empty, " DESC"))
                mtdAtualizarDtgv1(strNomeTabelaCautela, strColuna, strDado, SQL)
            End If
        End Sub

        Private Sub mtdPesquisarAtualizarDtgv2()
            If dtgv1.ColumnCount > 0 And dtgv1.RowCount > 0 Then
                Dim strTabela As String = strNomeTabelaCautela
                Dim strColuna As String = dtgv1.Columns.Item(numcolunaselecionada).HeaderText
                Dim strDado As String = dtgv1.Item(numcolunaselecionada, numlinhaselecionada).Value.ToString()

                mtdPesquisarAtualizarDtgv2(strTabela, strColuna, strDado, strTabela, strColuna, True, False)
            End If
        End Sub

        Private Sub mtdPesquisarAtualizarDtgv2(ByVal Tabela As String, ByVal Coluna As String, ByVal Dado As String, ByVal TabelaOrdenadora As String, ByVal ColunaOrdenadora As String, ByVal Crescente As Boolean, ByVal PermitirCuringa As Boolean)
            Dim strTabela As String = Tabela
            Dim strColuna As String = Coluna
            Dim strDado As String = Dado
            Dim strConteudo As String = String.Empty

            If PermitirCuringa Then
                Select Case intModobcmb3
                    Case 1
                        strConteudo = "'{0}'"
                    Case 2
                        strConteudo = "'%{0}%'"
                End Select
            Else
                strConteudo = "'{0}'"
            End If

            If strColuna <> String.Empty Then
                Dim SQL As String = String.Format("SELECT DISTINCT {0} FROM {1} LEFT JOIN {2} ON {1}.{3}={2}.{4} WHERE {5}.{6} LIKE {7} ORDER BY {8}{9}", objBDPrincipal1.mtdVetorLinhaCampos(strNomeTabelaCautelaBens, frmCautelas.vetCamposTabelaCautelaBens), strNomeTabelaCautela, strNomeTabelaCautelaBens, "Codigo", "Codigo", strTabela, strColuna, String.Format(strConteudo, strDado), String.Format("{0}.{1}", TabelaOrdenadora, ColunaOrdenadora), IIf(Crescente, String.Empty, " DESC"))
                mtdAtualizarDtgv2(strNomeTabelaCautelaBens, strColuna, strDado, SQL)
            End If
        End Sub

        Private Sub mtdPesquisarAtualizarDtgv2(ByVal Coluna As String, ByVal Dado As String, ByVal Coluna2 As String, ByVal Dado2 As String)
            If dtgv1.ColumnCount > 0 And dtgv1.RowCount > 0 Then
                mtdPesquisarAtualizarDtgv2(strNomeTabelaCautelaBens, Coluna, Dado, Coluna2, Dado2, strNomeTabelaCautelaBens, Coluna, True)
            End If
        End Sub

        Private Sub mtdPesquisarAtualizarDtgv2(ByVal Tabela As String, ByVal Coluna As String, ByVal Dado As String, ByVal Coluna2 As String, ByVal Dado2 As String, ByVal TabelaOrdenadora As String, ByVal ColunaOrdenadora As String, ByVal Crescente As Boolean)
            Dim strTabela As String = Tabela
            Dim strColuna As String = Coluna
            Dim strDado As String = Dado

            If strColuna <> String.Empty Then
                Dim SQL As String = String.Format("SELECT DISTINCT {0} FROM {1} LEFT JOIN {2} ON {1}.{3}={2}.{4} WHERE {5}.{6} LIKE {7} AND {8}.{9} LIKE {10} ORDER BY {11}{12}", objBDPrincipal1.mtdVetorLinhaCampos(strNomeTabelaCautelaBens, frmCautelas.vetCamposTabelaCautelaBens), strNomeTabelaCautela, strNomeTabelaCautelaBens, "Codigo", "Codigo", Tabela, strColuna, String.Format("'{0}'", strDado), strNomeTabelaCautelaBens, Coluna2, String.Format("'{0}'", Dado2), String.Format("{0}.{1}", TabelaOrdenadora, ColunaOrdenadora), IIf(Crescente, String.Empty, " DESC"))
                mtdAtualizarDtgv2(strNomeTabelaCautelaBens, strColuna, strDado, SQL)
            End If
        End Sub
    End Class
End Namespace