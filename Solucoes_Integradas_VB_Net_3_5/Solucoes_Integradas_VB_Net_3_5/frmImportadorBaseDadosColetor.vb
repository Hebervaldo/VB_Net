Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmImportadorBaseDadosColetor
        Protected Friend ThProgresso As Threading.Thread
        Private Delegate Sub SetItemCallback(ByVal [item]() As ListViewItem)
        Private Delegate Sub SetValueCallback(ByVal [value] As Integer)

        Private dfrmlsv1H As Integer
        Private dfrmlsv1V As Integer
        Private dfrmgrpb1H As Integer
        Private dfrmgrpb1V As Integer
        Private dfrmcmb1H As Integer
        Private dfrmtxtsH As Integer
        Private varHouveRedimensionamento As Boolean = False

        Private ccc1 As Integer
        Private ccc2 As Integer

        Private objArquivoTXT As clsArquivoTXT = New clsArquivoTXT()
        Private objManipuladorTexto As clsManipuladorTexto = New clsManipuladorTexto()
        Private objBDColetor As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosColetor, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)
        Private objRegistroWindows As clsRegistroWindows = New clsRegistroWindows()
        Private dblPorcentagem As Double = 0
        Private [NewValue] As Integer = 0
        Private blnLinhaAdicionada As Boolean = False
        Private intNumLinhaAdicionada As Integer = 0
        Private intNumLinhaVerificada As Integer = 0
        Private intNumMaxLinha As Integer = 0
        Private tspDiferencaTempo As TimeSpan
        Private dblTempoRestanteEstimado As Double = 0
        Private dblTempoTotalEstimado As Double = 0
        Private dtmTempoInicial As DateTime = New DateTime()
        Private dtmTempoParcial As DateTime = New DateTime()
        Private dtmTempoFinal As DateTime = New DateTime()
        Private stbSQL As System.Text.StringBuilder = New System.Text.StringBuilder(String.Empty)
        Private stbSQLParcial As System.Text.StringBuilder = New System.Text.StringBuilder(String.Empty)
        Private stbSQLParcial2 As System.Text.StringBuilder = New System.Text.StringBuilder(String.Empty)
        Private stbTexto As System.Text.StringBuilder = New System.Text.StringBuilder(String.Empty)
        Private stbRegistros As System.Text.StringBuilder = New System.Text.StringBuilder(String.Empty)

        Private Sub frmImportadorBaseDadosColetor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            txt1.Text = frmPrincipal.strEnderecoArquivoImportado
            txt2.Text = String.Format("{0}{1}", frmPrincipal.strEnderecoBancoDadosColetor, frmPrincipal.strNomeBaseDadosColetor)
            mtdIniciarThreadImportarTabelaBensEletronorteCentroCustoColetor()
            mtdIniciarThreadProgresso()
        End Sub

        Private Sub mtdIniciarThreadProgresso()
            ThProgresso = New Threading.Thread(New Threading.ThreadStart(AddressOf Me.mtdRotinaThreadProgresso))
            ThProgresso.IsBackground = True
            ThProgresso.Priority = Threading.ThreadPriority.Normal
            ThProgresso.Start()
        End Sub

        Private Shared LockImportadorBaseDadosColetor As Object = New Object()

        Private Sub mtdRotinaThreadProgresso()
            Dim [NewItem](10) As ListViewItem
            Dim strtempoestimado As String = String.Empty
            Try
                Do
                    SyncLock (LockImportadorBaseDadosColetor)
                        If lsv1.InvokeRequired Then
                            Dim f As SetItemCallback = New SetItemCallback(AddressOf Me.SetItem)
                            Me.Invoke(f, New Object() {[NewItem]})
                        Else
                            For contador As Integer = 0 To 10 Step 1
                                lsv1.Items.Add([NewItem](contador))
                            Next
                        End If
                        System.Threading.Thread.Sleep(1)
                    End SyncLock
                Loop
            Catch ex As Exception

            End Try
        End Sub

        Private Sub SetValue(ByVal [value] As Integer)
            frmPrincipal.barprgfrmPrincipal.Value = [value]
            If [value] >= 0 And [value] <= 100 Then
                frmPrincipal.barprgfrmPrincipal.Value = [value]
            End If
        End Sub

        Private Sub SetItem(ByVal [item]() As ListViewItem)
            lsv1.Clear()
            lsv1.Columns.Add("Informações", ccc1, HorizontalAlignment.Left)
            lsv1.Columns.Add("Dados", ccc2, HorizontalAlignment.Left)
            For contador As Integer = item.GetLowerBound(0) To item.GetUpperBound(0) Step 1
                lsv1.Items.Add(item(contador))
            Next
            Me.Controls.Add(lsv1)
        End Sub

        Private Sub mtdRotinaExcutarColetor()

        End Sub

        Protected Friend Sub mtdAbortarProcessos()
            Try
                ThProgresso.Abort()
            Catch
            End Try
            mtdAbortarThreadImportarTabelaBensEletronorteCentroCustoColetor(True)
        End Sub

        Private Sub frmImportadorBaseDados_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            'Pergunta se o usuário quer, realmente, fechar o formulário.
            Dim resposta As DialogResult
            resposta = MessageBox.Show("Deseja realmente fechar o formulário de importação dos dados?", "Aviso!", MessageBoxButtons.YesNo)
            'Se o usuário respondeu "Não", cancela o fechamento do formulário.
            If (resposta = System.Windows.Forms.DialogResult.No) Then
                e.Cancel = True
            ElseIf (resposta = System.Windows.Forms.DialogResult.Yes) Then
                mtdAbortarProcessos()
                e.Cancel = False
            End If
        End Sub

        Private Sub frmImportadorBaseDados_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
            If varHouveRedimensionamento = False Then
                dfrmlsv1H = Me.Width - lsv1.Width
                dfrmlsv1V = Me.Height - lsv1.Height
                dfrmgrpb1H = Me.Width - grpb1.Width
                dfrmtxtsH = Me.Width - txt1.Width
                ' dfrmgrpb1V = Me.Height - grpb1.Height
                varHouveRedimensionamento = True
            End If
            lsv1.Height = Me.Height - dfrmlsv1V
            lsv1.Width = Me.Width - dfrmlsv1H
            grpb1.Width = Me.Width - dfrmgrpb1H
            txt1.Width = Me.Width - dfrmtxtsH
            txt2.Width = Me.Width - dfrmtxtsH
            ccc1 = 300
            ccc2 = lsv1.Width - ccc1 - 10
            ' grpb1.Top = Me.Height - dfrmgrpb1V
        End Sub
    End Class
End Namespace