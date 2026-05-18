Imports System.Threading

Namespace Solucoes_Rede_Neural_VBCoreNet
    Public Class frmRedeNeural

        ' Variável de Instância
        Private objEnderecoAplicativo As clsEnderecoAplicativo = New clsEnderecoAplicativo()
        Private objPrincipal As New frmPrincipal()
        Public varEnderecoAplicativo As String
        ' Variáveis de classe
        ' Para usá-las, não precisa ser instancido nenhum objeto.
        Public Shared ENDERECOARQUIVOENTRADASTREINAMENTO As String
        Public Shared ENDERECOARQUIVOTARGET As String
        Public Shared ENDERECOARQUIVOPESOS As String
        Public Shared ENDERECOARQUIVOERRO As String
        Public Shared ENDERECOARQUIVORESULTADOS As String
        Public Shared NumeroEntrada As Integer, NumeroPadroes As Integer, NumeroPadroesConferencia As Integer, NumeroSaida As Integer,
    NumeroEscondida As Integer, NumeroIteracoes As Integer
        Public Shared Th1 As Thread, Th2 As Thread
        ' Variáveis de instância
        ' Para usá-las, precisa ser instancido pelo menos um objeto.
        Private linhamatriz As Integer = 1000
        Public matriz(linhamatriz, 10000) As String
        Private c As Integer = 0, l As Integer = 0, maxc As Integer = 0
        Public Shared dtgv As DataGridView
        Delegate Sub SetTextCallback(ByVal [text] As String)
        Delegate Sub SetText2Callback(ByVal [text] As String)
        Delegate Sub SetValueCallback(ByVal [value] As Integer)
        Private backgroundWorker1 As New System.ComponentModel.BackgroundWorker()
        Private objArquivoTXT As New clsArquivoTXT()
        Private objManipuladorTexto As New clsManipuladorTexto()
        Private epocaporcent As Double = 0, erro As Double, erro_max As Double = 0.004
        Private tipoerro As String = String.Empty, tiposaida As String = String.Empty, tipodelta As String = String.Empty,
    tipoprioridade As String = String.Empty, tipotarefa As String = String.Empty
        Private resultado As String = String.Empty, strerro As String, strpesos As String
        Private tempoinicio As DateTime, tempoexecucao As DateTime
        Private oldtxt1text As String = String.Empty
        Private Sub recebe_entradas(ByRef entrada(,) As Double)
            RotinaLeitura(ENDERECOARQUIVOENTRADASTREINAMENTO) ' recebe_entradas
            For coluna As Integer = entrada.GetLowerBound(0) To entrada.GetUpperBound(0) - 1 Step 1
                For linha As Integer = entrada.GetLowerBound(1) To entrada.GetUpperBound(1) - 1 Step 1
                    entrada(coluna + 1, linha + 1) = Convert.ToDouble(matriz(linha, coluna))
                Next
            Next
        End Sub
        Private Sub recebe_target(ByRef target(,) As Double)
            RotinaLeitura(ENDERECOARQUIVOTARGET) ' recebe_target
            For coluna As Integer = target.GetLowerBound(0) To target.GetUpperBound(0) - 1 Step 1
                For linha As Integer = target.GetLowerBound(1) To target.GetUpperBound(1) - 1 Step 1
                    target(coluna + 1, linha + 1) = Convert.ToDouble(matriz(linha, coluna))
                Next
            Next
        End Sub
        Private Sub recebe_pesos(ByRef W12(,) As Double, ByRef W23(,) As Double)
            Dim colunacount As Integer = 0
            RotinaLeitura(ENDERECOARQUIVOPESOS) ' recebe_entradas
            For coluna As Integer = W12.GetLowerBound(0) To W12.GetUpperBound(0) Step 1
                For linha As Integer = W12.GetLowerBound(1) To W12.GetUpperBound(1) - 1 Step 1
                    W12(coluna, linha + 1) = Convert.ToDouble(matriz(coluna, linha))
                    colunacount = linha
                Next
            Next
            For coluna As Integer = W23.GetLowerBound(0) To W23.GetUpperBound(0) Step 1
                For linha As Integer = W23.GetLowerBound(1) To W23.GetUpperBound(1) - 1 Step 1
                    W23(coluna, linha + 1) = Convert.ToDouble(matriz(coluna, linha + colunacount + 1))
                Next
            Next
        End Sub
        Private Sub exporta_pesos(ByVal strpesos As String)
            objArquivoTXT.mtdCriadorTexto(ENDERECOARQUIVOPESOS, strpesos)
        End Sub
        Private Sub btnE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnE.Click
            Dim objFV As New frmVisualizador()
            objFV.MdiParent = frmPrincipal
            objFV.EnderecoArquivo(ENDERECOARQUIVOENTRADASTREINAMENTO)
            frmVisualizador.tipoformulario = "Entradas"
            objFV.Show()
        End Sub
        Private Sub btnT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnT.Click
            Dim objFV As New frmVisualizador()
            objFV.MdiParent = frmPrincipal
            objFV.EnderecoArquivo(ENDERECOARQUIVOTARGET)
            frmVisualizador.tipoformulario = "Target"
            objFV.Show()
        End Sub
        Private Sub btnP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP.Click
            Dim objFV As New frmVisualizador()
            objFV.MdiParent = frmPrincipal
            objFV.EnderecoArquivo(ENDERECOARQUIVOPESOS)
            frmVisualizador.tipoformulario = "Pesos"
            objFV.Show()
        End Sub
        Private Sub btnEr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEr.Click
            Dim objFV As New frmVisualizador()
            objFV.MdiParent = frmPrincipal
            objFV.EnderecoArquivo(ENDERECOARQUIVOERRO)
            frmVisualizador.tipoformulario = "Erro"
            objFV.Show()
        End Sub
        Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnR.Click
            Dim objFV As New frmVisualizador()
            objFV.MdiParent = frmPrincipal
            objFV.EnderecoArquivo(ENDERECOARQUIVORESULTADOS)
            frmVisualizador.tipoformulario = "Resultado"
            objFV.Show()
        End Sub
        Public Sub RotinaCadastro(ByVal EnderecoArquivo As String, ByRef dtgv As DataGridView)
            Dim saida As String = String.Empty
            For linha As Integer = 0 To dtgv.Rows.Count - 2 Step 1
                For coluna As Integer = 0 To dtgv.Columns.Count - 1 Step 1
                    saida &= dtgv.Item(coluna, linha).Value.ToString()
                    If coluna < dtgv.Columns.Count - 1 Then
                        saida &= Convert.ToChar(9).ToString()
                    Else
                        saida = objManipuladorTexto.mtdTiradorCaractereInvalido(saida)
                    End If
                Next
                saida &= Convert.ToChar(13).ToString() & Convert.ToChar(10).ToString()
            Next
            saida = saida.Trim()
            objArquivoTXT.mtdCriadorTexto(EnderecoArquivo, saida)
            frmRedeNeural.dtgv = dtgv
        End Sub
        Public Sub RotinaLeitura(ByVal EnderecoArquivo As String)
            ' Laço com função de atribuir zero para todos os elementos da matriz entrada.
            For linha As Integer = matriz.GetLowerBound(0) To matriz.GetUpperBound(0)
                For coluna As Integer = matriz.GetLowerBound(1) To matriz.GetUpperBound(1)
                    matriz(linha, coluna) = "0"
                Next
            Next
            Dim str As String = String.Empty
            Try
                str = objArquivoTXT.mtdLeitorTexto(EnderecoArquivo)
            Catch ex As Exception
                System.IO.Directory.CreateDirectory(frmPrincipal.varEnderecoAplicativo & "Rede Neural\")
                objArquivoTXT.mtdCriadorTexto(EnderecoArquivo, String.Empty)
                str = objArquivoTXT.mtdLeitorTexto(EnderecoArquivo)
            End Try
            c = 0
            l = 0
            maxc = 0
            str = objArquivoTXT.mtdLeitorTexto(EnderecoArquivo)
            Dim texto As String = String.Empty
            For i As Integer = 0 To str.Length - 1 Step 1
                Dim caractere As Char = Convert.ToChar(str.Substring(i, 1))
                Dim numcaractere As Integer = Convert.ToInt32(caractere)
                Select Case numcaractere
                    Case 9
                        c += 1
                        maxc = c
                        texto = String.Empty
                    Case 10
                    Case 13
                        c = 0
                        l += 1
                        texto = String.Empty
                    Case 32
                        c += 1
                        maxc = c
                        texto = String.Empty
                    Case Else
                        texto &= caractere
                End Select
                matriz(c, l) = texto
            Next
        End Sub

        Private Shared thisLock As Object = New Object()

        Public Sub PreencherDataGridView(ByRef dtgv As DataGridView, ByVal nomecoluna As String)
            SyncLock (thisLock)
                Try
                    dtgv.Columns.Clear()
                    dtgv.Rows.Clear()
                Catch ex As Exception

                End Try
                For contador As Integer = 0 To maxc Step 1
                    dtgv.Columns.Add(String.Concat(nomecoluna, (contador + 1).ToString("000")), String.Concat(nomecoluna, (contador + 1).ToString("000")))
                Next
                For linha As Integer = 0 To l - 1 Step 1
                    dtgv.Rows.Add()
                Next
                Dim output As String = String.Empty
                For linha As Integer = 0 To l - 1 Step 1
                    For coluna As Integer = 0 To maxc Step 1
                        ' dtgv.Item(coluna, linha).Value = matriz(coluna, linha)
                        dtgv.Rows(linha).Cells(coluna).Value = matriz(coluna, linha)
                    Next
                Next
                frmRedeNeural.dtgv = dtgv
            End SyncLock
        End Sub
        Public Sub RePreencherDataGridView(ByRef dtgv As DataGridView, ByRef lstv As ListView)
            Dim contador As Integer
            dtgv.Columns.Clear()
            For contador = 0 To lstv.Items.Count - 1 Step 1
                dtgv.Columns.Add(lstv.Items(contador).Text.ToString(), lstv.Items(contador).Text.ToString())
            Next
        End Sub
        Private Sub RotinaExecutar()
            If txt1.Text = String.Empty Then
                txt1.Text = "1000"
            End If
            If txt2.Text = String.Empty Then
                txt2.Text = "0.004"
            End If
            If txt3.Text = String.Empty Then
                txt3.Text = "2"
            End If
            NumeroIteracoes = Convert.ToInt32(txt1.Text)
            erro_max = Convert.ToDouble(txt2.Text)
            NumeroEscondida = Convert.ToInt32(txt3.Text)
            Me.Cursor = Cursors.WaitCursor
            pgbr1.Value = pgbr1.Minimum
            tempoinicio = Now
            IniciarThreadExecutar()
            pgbr1.Value = pgbr1.Maximum
            Me.Cursor = Cursors.Default
        End Sub
        Private Sub btnAbortar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbortar.Click
            Try
                Th2.GetApartmentState()
                If MessageBox.Show("Você deseja realmente abortar a operação?", "Aviso!", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Th2.Abort()
                    MessageBox.Show("A operação foi abortada!", "Aviso!", MessageBoxButtons.OK)
                Else
                    MessageBox.Show("A operação ainda continua em execução.", "Aviso!", MessageBoxButtons.OK)
                End If
            Catch ex As Exception
                MessageBox.Show("Não foi iniciada nenhuma operação.", "Aviso!", MessageBoxButtons.OK)
            End Try
        End Sub
        Private Sub IniciarThreadProgresso()
            Th1 = New Thread(New ThreadStart(AddressOf Me.RotinaThreadProgresso))
            Th1.IsBackground = True
            Th1.Priority = ThreadPriority.Normal
            Th1.Start()
        End Sub
        Private Sub RotinaThreadProgresso()
            Dim strtempoestimado As String = String.Empty
            Try
                Do
                    Dim NewText As String = epocaporcent & " %"
                    Dim tempoparcial As Long = CLng(tempoexecucao.Subtract(tempoinicio).TotalSeconds)
                    Dim tempoestimado As Double = ((tempoparcial) / epocaporcent) * 100
                    If Double.IsNaN(tempoestimado) Then
                        strtempoestimado = "não há estimativa"
                    Else
                        strtempoestimado = Convert.ToString(Math.Round(tempoestimado)) & " (s)"
                    End If
                    Dim LogErro As Double = CDbl(IIf(erro <> 0, Math.Log10(erro), 1))
                    Dim strFormatoErro As String = String.Empty
                    If LogErro < 0 Then
                        strFormatoErro = "0."
                        For contador As Integer = 0 To CInt(Math.Round(Math.Abs(LogErro))) Step 1
                            strFormatoErro += "0"
                        Next
                    Else
                        strFormatoErro = "0"
                    End If
                    Dim NewText2 As String = "Tempo para o cálculo: " & String.Format(tempoparcial.ToString(), "0") & " (s); Tempo estimado: " & strtempoestimado + "; Erro atual: " + erro.ToString(strFormatoErro) + "."
                    Dim NewValue As Integer = Convert.ToInt32(epocaporcent)
                    If Me.lbl2.InvokeRequired Then
                        Dim d As New SetTextCallback(AddressOf Me.SetText)
                        Dim e As New SetText2Callback(AddressOf Me.SetText2)
                        Dim f As New SetValueCallback(AddressOf Me.SetValue)
                        Me.Invoke(d, New Object() {[NewText]})
                        Me.Invoke(e, New Object() {[NewText2]})
                        Me.Invoke(f, New Object() {[NewValue]})
                    Else
                        Me.lbl2.Text = [NewText]
                        Me.lbl4.Text = [NewText2]
                        If Me.pgbr1.Value < pgbr1.Maximum Then
                            Me.pgbr1.Value = Convert.ToInt32(epocaporcent)
                        End If
                    End If
                    Thread.Sleep(1)
                Loop
            Catch ex As Exception
            End Try
        End Sub
        Private Sub SetText(ByVal [text] As String)
            Me.lbl2.Text = [text]
        End Sub
        Private Sub SetText2(ByVal [text] As String)
            Me.lbl4.Text = [text]
        End Sub
        Private Sub SetValue(ByVal [value] As Integer)
            Me.pgbr1.Value = [value]
        End Sub
        Private Sub IniciarThreadExecutar()
            Th2 = New Thread(New ThreadStart(AddressOf Me.RotinaThreadExecutar))
            Th2.IsBackground = True
            Select Case tipoprioridade
                Case "Baixa"
                    Th2.Priority = ThreadPriority.Lowest
                Case "Abaixo do Normal"
                    Th2.Priority = ThreadPriority.BelowNormal
                Case "Normal"
                    Th2.Priority = ThreadPriority.Normal
                Case "Acima do Normal"
                    Th2.Priority = ThreadPriority.AboveNormal
                Case "Alta"
                    Th2.Priority = ThreadPriority.Highest
            End Select
            Th2.Start()
        End Sub
        Private Sub RotinaThreadExecutar()
            ' Dim objRedeNeural As New BibliotecaRedeNeural.clsRedeNeural() ' Definição da Biblioteca Rede Neural
            Dim objRedeNeural As New clsRedeNeural() 'Definição do Módulo Rede Neural
            Dim objFV As New frmVisualizador()
            objFV.EnderecoArquivo(ENDERECOARQUIVOENTRADASTREINAMENTO)
            frmVisualizador.tipoformulario = "Entradas"
            objFV.mtdLer(dtgv)
            objFV.mtdCadastrar(dtgv)
            objFV.EnderecoArquivo(ENDERECOARQUIVOTARGET)
            frmVisualizador.tipoformulario = "Target"
            objFV.mtdLer(dtgv)
            objFV.mtdCadastrar(dtgv)
            objFV.Close()
            Dim entrada(NumeroPadroes, NumeroEntrada) As Double
            Dim target(NumeroPadroesConferencia, NumeroSaida) As Double
            Dim W12(NumeroEntrada, NumeroEscondida) As Double
            Dim W23(NumeroEscondida, NumeroSaida) As Double
            Try
                recebe_entradas(entrada)
                recebe_target(target)
                Select Case tipotarefa
                    Case "Aprendizagem"
                        If objRedeNeural.mtdExecutar(entrada, target, NumeroEscondida, NumeroIteracoes, erro, erro_max, tiposaida,
            tipoerro, tipodelta, resultado, strerro, strpesos, epocaporcent, tempoexecucao, tipotarefa) Then
                            objArquivoTXT.mtdCriadorTexto(ENDERECOARQUIVOERRO, strerro)
                            objArquivoTXT.mtdCriadorTexto(ENDERECOARQUIVORESULTADOS, resultado)
                            exporta_pesos(strpesos)
                            MessageBox.Show("A tarefa foi concluída.", "Aviso!", MessageBoxButtons.OK)
                        Else
                            MessageBox.Show("O comprimento do vetor entrada é diferente do comprimento do vetor target, corrija-os.", "Aviso!", MessageBoxButtons.OK)
                        End If
                    Case "Verificação"
                        recebe_pesos(W12, W23)
                        If objRedeNeural.mtdExecutar(entrada, target, W12, W23, NumeroEscondida, NumeroIteracoes, erro, erro_max, tiposaida,
            tipoerro, tipodelta, resultado, strerro, strpesos, epocaporcent, tempoexecucao, tipotarefa) Then
                            objArquivoTXT.mtdCriadorTexto(ENDERECOARQUIVOERRO, strerro)
                            objArquivoTXT.mtdCriadorTexto(ENDERECOARQUIVORESULTADOS, resultado)
                            MessageBox.Show("A tarefa foi concluída.", "Aviso!", MessageBoxButtons.OK)
                        Else
                            MessageBox.Show("O comprimento do vetor entrada é diferente do comprimento do vetor target, corrija-os.", "Aviso!", MessageBoxButtons.OK)
                        End If
                End Select
            Catch ex As Exception
                MessageBox.Show("Digite valores (números!) para o cálculo da Rede Neural.", "Aviso!", MessageBoxButtons.OK)
            End Try
        End Sub
        Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
            Me.Close()
        End Sub
        ' O Método seguinte é o finalizador.
        Protected Overrides Sub Finalize()
            Try
                System.GC.Collect(0)
            Catch ex As Exception
                MyBase.Finalize()
            End Try
        End Sub
        Private Sub btnExecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecutar.Click
            RotinaExecutar()
        End Sub
        Private Sub frmRedeNeural_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.backgroundWorker1.RunWorkerAsync()
            IniciarThreadProgresso()
            cmb1.Items.Add("Sigmoidal SAIDAs")
            cmb1.Items.Add("Linear SAIDAs")
            cmb1.Text = cmb1.Items(0).ToString()
            cmb2.Items.Add("SSE")
            cmb2.Items.Add("Erro de Entropia Cruzada")
            cmb2.Text = cmb2.Items(0).ToString
            cmb3.Items.Add("Sigmoidal SAIDAs, SSE")
            cmb3.Items.Add("Sigmoidal SAIDAs, Cross-Entropy Erro")
            cmb3.Text = cmb3.Items(0).ToString
            cmb4.Items.Add("Baixa")
            cmb4.Items.Add("Abaixo do Normal")
            cmb4.Items.Add("Normal")
            cmb4.Items.Add("Acima do Normal")
            cmb4.Items.Add("Alta")
            cmb4.Text = cmb4.Items(2).ToString
            cmb5.Items.Add("Aprendizagem")
            cmb5.Items.Add("Verificação")
            cmb5.Text = cmb5.Items(0).ToString
            tiposaida = cmb1.Text
            tipoerro = cmb2.Text
            tipodelta = cmb3.Text
            tipoprioridade = cmb4.Text
            tipotarefa = cmb5.Text
            txt1.Text = "1000"
            oldtxt1text = txt1.Text
            mtdAtributos()
            varEnderecoAplicativo = objEnderecoAplicativo.Endereco()
            ENDERECOARQUIVOENTRADASTREINAMENTO = varEnderecoAplicativo + "Rede Neural\\entradas.dat"
            ENDERECOARQUIVOTARGET = varEnderecoAplicativo + "Rede Neural\\target.dat"
            ENDERECOARQUIVOPESOS = varEnderecoAplicativo + "Rede Neural\\pesos.dat"
            ENDERECOARQUIVOERRO = varEnderecoAplicativo + "Rede Neural\\erro.dat"
            ENDERECOARQUIVORESULTADOS = varEnderecoAplicativo + "Rede Neural\\resultados.dat"
            dtgv = New DataGridView()
        End Sub
        Private Sub cmb1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb5.SelectedValueChanged
            tiposaida = cmb1.Text
        End Sub
        Private Sub cmb2_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb5.SelectedValueChanged
            tipoerro = cmb2.Text
        End Sub
        Private Sub cmb3_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb5.SelectedValueChanged
            tipodelta = cmb3.Text
        End Sub
        Private Sub cmb4_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb5.SelectedValueChanged
            tipoprioridade = cmb4.Text
        End Sub
        Private Sub cmb5_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb5.SelectedValueChanged
            tipotarefa = cmb5.Text
            If tipotarefa = "Aprendizagem" Then
                txt1.Enabled = True
                txt1.Text = oldtxt1text
            ElseIf tipotarefa = "Verificação" Then
                txt1.Enabled = False
                oldtxt1text = txt1.Text
                txt1.Text = Convert.ToString(2)
            End If
        End Sub
        Private Sub frmRedeNeural_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
            mtdAtributos()
        End Sub
        Private Sub mtdAtributos()
            tslbl2.Text = Convert.ToString(Me.Location.X)
            tslbl4.Text = Convert.ToString(Me.Location.Y)
            tslbl6.Text = Convert.ToString(Me.Width)
            tslbl8.Text = Convert.ToString(Me.Height)
        End Sub
    End Class
End Namespace