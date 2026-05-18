<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRedeNeural
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txt1 = New System.Windows.Forms.TextBox
        Me.btnET = New System.Windows.Forms.Button
        Me.btnT = New System.Windows.Forms.Button
        Me.btnP = New System.Windows.Forms.Button
        Me.btnE = New System.Windows.Forms.Button
        Me.lbl9 = New System.Windows.Forms.Label
        Me.btnR = New System.Windows.Forms.Button
        Me.grpb2 = New System.Windows.Forms.GroupBox
        Me.txt3 = New System.Windows.Forms.TextBox
        Me.lbl10 = New System.Windows.Forms.Label
        Me.lbl11 = New System.Windows.Forms.Label
        Me.txt2 = New System.Windows.Forms.TextBox
        Me.lbl8 = New System.Windows.Forms.Label
        Me.cmb4 = New System.Windows.Forms.ComboBox
        Me.lbl7 = New System.Windows.Forms.Label
        Me.cmb3 = New System.Windows.Forms.ComboBox
        Me.lbl6 = New System.Windows.Forms.Label
        Me.cmb2 = New System.Windows.Forms.ComboBox
        Me.lbl5 = New System.Windows.Forms.Label
        Me.cmb1 = New System.Windows.Forms.ComboBox
        Me.lbl3 = New System.Windows.Forms.Label
        Me.lbl4 = New System.Windows.Forms.Label
        Me.btnAbortar = New System.Windows.Forms.Button
        Me.btnSair = New System.Windows.Forms.Button
        Me.lbl2 = New System.Windows.Forms.Label
        Me.pgbr1 = New System.Windows.Forms.ProgressBar
        Me.grpb1 = New System.Windows.Forms.GroupBox
        Me.cmb5 = New System.Windows.Forms.ComboBox
        Me.lbl12 = New System.Windows.Forms.Label
        Me.btnExecutar = New System.Windows.Forms.Button
        Me.ststrp1 = New System.Windows.Forms.StatusStrip
        Me.tslbl1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.grpb2.SuspendLayout()
        Me.grpb1.SuspendLayout()
        Me.ststrp1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt1
        '
        Me.txt1.BackColor = System.Drawing.SystemColors.Window
        Me.txt1.Location = New System.Drawing.Point(76, 13)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(163, 20)
        Me.txt1.TabIndex = 3
        Me.txt1.Text = "1000"
        '
        'btnET
        '
        Me.btnET.Location = New System.Drawing.Point(6, 189)
        Me.btnET.Name = "btnET"
        Me.btnET.Size = New System.Drawing.Size(135, 21)
        Me.btnET.TabIndex = 4
        Me.btnET.Text = "&EntradasTreinamento"
        Me.btnET.UseVisualStyleBackColor = True
        '
        'btnT
        '
        Me.btnT.Location = New System.Drawing.Point(151, 189)
        Me.btnT.Name = "btnT"
        Me.btnT.Size = New System.Drawing.Size(135, 21)
        Me.btnT.TabIndex = 5
        Me.btnT.Text = "&Target"
        Me.btnT.UseVisualStyleBackColor = True
        '
        'btnP
        '
        Me.btnP.Location = New System.Drawing.Point(292, 189)
        Me.btnP.Name = "btnP"
        Me.btnP.Size = New System.Drawing.Size(135, 21)
        Me.btnP.TabIndex = 6
        Me.btnP.Text = "&Pesos"
        Me.btnP.UseVisualStyleBackColor = True
        '
        'btnE
        '
        Me.btnE.Location = New System.Drawing.Point(6, 216)
        Me.btnE.Name = "btnE"
        Me.btnE.Size = New System.Drawing.Size(135, 21)
        Me.btnE.TabIndex = 7
        Me.btnE.Text = "&Erro"
        Me.btnE.UseVisualStyleBackColor = True
        '
        'lbl9
        '
        Me.lbl9.AutoSize = True
        Me.lbl9.Location = New System.Drawing.Point(10, 20)
        Me.lbl9.Name = "lbl9"
        Me.lbl9.Size = New System.Drawing.Size(54, 13)
        Me.lbl9.TabIndex = 11
        Me.lbl9.Text = "Iterações:"
        '
        'btnR
        '
        Me.btnR.Location = New System.Drawing.Point(151, 216)
        Me.btnR.Name = "btnR"
        Me.btnR.Size = New System.Drawing.Size(135, 21)
        Me.btnR.TabIndex = 18
        Me.btnR.Text = "&Resultado"
        Me.btnR.UseVisualStyleBackColor = True
        '
        'grpb2
        '
        Me.grpb2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.grpb2.Controls.Add(Me.txt3)
        Me.grpb2.Controls.Add(Me.lbl10)
        Me.grpb2.Controls.Add(Me.lbl11)
        Me.grpb2.Controls.Add(Me.txt2)
        Me.grpb2.Controls.Add(Me.lbl8)
        Me.grpb2.Controls.Add(Me.txt1)
        Me.grpb2.Controls.Add(Me.cmb4)
        Me.grpb2.Controls.Add(Me.lbl7)
        Me.grpb2.Controls.Add(Me.cmb3)
        Me.grpb2.Controls.Add(Me.lbl6)
        Me.grpb2.Controls.Add(Me.cmb2)
        Me.grpb2.Controls.Add(Me.lbl5)
        Me.grpb2.Controls.Add(Me.cmb1)
        Me.grpb2.Controls.Add(Me.lbl9)
        Me.grpb2.Controls.Add(Me.btnET)
        Me.grpb2.Controls.Add(Me.btnR)
        Me.grpb2.Controls.Add(Me.btnT)
        Me.grpb2.Controls.Add(Me.btnP)
        Me.grpb2.Controls.Add(Me.btnE)
        Me.grpb2.Location = New System.Drawing.Point(12, 12)
        Me.grpb2.Name = "grpb2"
        Me.grpb2.Size = New System.Drawing.Size(437, 243)
        Me.grpb2.TabIndex = 20
        Me.grpb2.TabStop = False
        Me.grpb2.Text = "Controle"
        '
        'txt3
        '
        Me.txt3.BackColor = System.Drawing.SystemColors.Window
        Me.txt3.Location = New System.Drawing.Point(102, 42)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(137, 20)
        Me.txt3.TabIndex = 30
        Me.txt3.Text = "2"
        '
        'lbl10
        '
        Me.lbl10.AutoSize = True
        Me.lbl10.Location = New System.Drawing.Point(10, 49)
        Me.lbl10.Name = "lbl10"
        Me.lbl10.Size = New System.Drawing.Size(86, 13)
        Me.lbl10.TabIndex = 31
        Me.lbl10.Text = "N° de neurônios:"
        '
        'lbl11
        '
        Me.lbl11.AutoSize = True
        Me.lbl11.Location = New System.Drawing.Point(245, 20)
        Me.lbl11.Name = "lbl11"
        Me.lbl11.Size = New System.Drawing.Size(29, 13)
        Me.lbl11.TabIndex = 29
        Me.lbl11.Text = "Erro:"
        '
        'txt2
        '
        Me.txt2.BackColor = System.Drawing.SystemColors.Window
        Me.txt2.Location = New System.Drawing.Point(280, 13)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(150, 20)
        Me.txt2.TabIndex = 28
        Me.txt2.Text = "0,004"
        '
        'lbl8
        '
        Me.lbl8.AutoSize = True
        Me.lbl8.Location = New System.Drawing.Point(10, 166)
        Me.lbl8.Name = "lbl8"
        Me.lbl8.Size = New System.Drawing.Size(109, 13)
        Me.lbl8.TabIndex = 26
        Me.lbl8.Text = "Prioridade do cálculo:"
        '
        'cmb4
        '
        Me.cmb4.BackColor = System.Drawing.SystemColors.Window
        Me.cmb4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb4.FormattingEnabled = True
        Me.cmb4.Location = New System.Drawing.Point(138, 158)
        Me.cmb4.Name = "cmb4"
        Me.cmb4.Size = New System.Drawing.Size(292, 21)
        Me.cmb4.TabIndex = 27
        '
        'lbl7
        '
        Me.lbl7.AutoSize = True
        Me.lbl7.Location = New System.Drawing.Point(10, 139)
        Me.lbl7.Name = "lbl7"
        Me.lbl7.Size = New System.Drawing.Size(85, 13)
        Me.lbl7.TabIndex = 24
        Me.lbl7.Text = "Escolha o Delta:"
        '
        'cmb3
        '
        Me.cmb3.BackColor = System.Drawing.SystemColors.Window
        Me.cmb3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb3.FormattingEnabled = True
        Me.cmb3.Location = New System.Drawing.Point(138, 131)
        Me.cmb3.Name = "cmb3"
        Me.cmb3.Size = New System.Drawing.Size(292, 21)
        Me.cmb3.TabIndex = 25
        '
        'lbl6
        '
        Me.lbl6.AutoSize = True
        Me.lbl6.Location = New System.Drawing.Point(10, 85)
        Me.lbl6.Name = "lbl6"
        Me.lbl6.Size = New System.Drawing.Size(122, 13)
        Me.lbl6.TabIndex = 22
        Me.lbl6.Text = "Escolha o tipo de saída:"
        '
        'cmb2
        '
        Me.cmb2.BackColor = System.Drawing.SystemColors.Window
        Me.cmb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb2.FormattingEnabled = True
        Me.cmb2.Location = New System.Drawing.Point(138, 104)
        Me.cmb2.Name = "cmb2"
        Me.cmb2.Size = New System.Drawing.Size(292, 21)
        Me.cmb2.TabIndex = 23
        '
        'lbl5
        '
        Me.lbl5.AutoSize = True
        Me.lbl5.Location = New System.Drawing.Point(10, 112)
        Me.lbl5.Name = "lbl5"
        Me.lbl5.Size = New System.Drawing.Size(113, 13)
        Me.lbl5.TabIndex = 19
        Me.lbl5.Text = "Escolha o tipo de erro:"
        '
        'cmb1
        '
        Me.cmb1.BackColor = System.Drawing.SystemColors.Window
        Me.cmb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb1.FormattingEnabled = True
        Me.cmb1.Location = New System.Drawing.Point(138, 77)
        Me.cmb1.Name = "cmb1"
        Me.cmb1.Size = New System.Drawing.Size(292, 21)
        Me.cmb1.TabIndex = 21
        '
        'lbl3
        '
        Me.lbl3.AutoSize = True
        Me.lbl3.Location = New System.Drawing.Point(17, 16)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(124, 13)
        Me.lbl3.TabIndex = 15
        Me.lbl3.Text = "Porcentagem concluída:"
        '
        'lbl4
        '
        Me.lbl4.BackColor = System.Drawing.SystemColors.Control
        Me.lbl4.Location = New System.Drawing.Point(6, 48)
        Me.lbl4.Name = "lbl4"
        Me.lbl4.Size = New System.Drawing.Size(421, 13)
        Me.lbl4.TabIndex = 16
        Me.lbl4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAbortar
        '
        Me.btnAbortar.Location = New System.Drawing.Point(151, 63)
        Me.btnAbortar.Name = "btnAbortar"
        Me.btnAbortar.Size = New System.Drawing.Size(135, 21)
        Me.btnAbortar.TabIndex = 14
        Me.btnAbortar.Text = "&Abortar"
        Me.btnAbortar.UseVisualStyleBackColor = True
        '
        'btnSair
        '
        Me.btnSair.Location = New System.Drawing.Point(292, 63)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(135, 21)
        Me.btnSair.TabIndex = 17
        Me.btnSair.Text = "&Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'lbl2
        '
        Me.lbl2.BackColor = System.Drawing.SystemColors.Control
        Me.lbl2.Location = New System.Drawing.Point(147, 16)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(85, 13)
        Me.lbl2.TabIndex = 13
        '
        'pgbr1
        '
        Me.pgbr1.BackColor = System.Drawing.SystemColors.Info
        Me.pgbr1.Location = New System.Drawing.Point(18, 32)
        Me.pgbr1.Name = "pgbr1"
        Me.pgbr1.Size = New System.Drawing.Size(214, 13)
        Me.pgbr1.TabIndex = 8
        '
        'grpb1
        '
        Me.grpb1.BackColor = System.Drawing.SystemColors.Control
        Me.grpb1.Controls.Add(Me.cmb5)
        Me.grpb1.Controls.Add(Me.lbl12)
        Me.grpb1.Controls.Add(Me.btnExecutar)
        Me.grpb1.Controls.Add(Me.pgbr1)
        Me.grpb1.Controls.Add(Me.lbl2)
        Me.grpb1.Controls.Add(Me.btnSair)
        Me.grpb1.Controls.Add(Me.btnAbortar)
        Me.grpb1.Controls.Add(Me.lbl4)
        Me.grpb1.Controls.Add(Me.lbl3)
        Me.grpb1.Location = New System.Drawing.Point(12, 261)
        Me.grpb1.Name = "grpb1"
        Me.grpb1.Size = New System.Drawing.Size(437, 119)
        Me.grpb1.TabIndex = 19
        Me.grpb1.TabStop = False
        Me.grpb1.Text = "Andamento"
        '
        'cmb5
        '
        Me.cmb5.BackColor = System.Drawing.SystemColors.Window
        Me.cmb5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb5.FormattingEnabled = True
        Me.cmb5.Location = New System.Drawing.Point(53, 90)
        Me.cmb5.Name = "cmb5"
        Me.cmb5.Size = New System.Drawing.Size(142, 21)
        Me.cmb5.TabIndex = 35
        '
        'lbl12
        '
        Me.lbl12.AutoSize = True
        Me.lbl12.Location = New System.Drawing.Point(6, 93)
        Me.lbl12.Name = "lbl12"
        Me.lbl12.Size = New System.Drawing.Size(41, 13)
        Me.lbl12.TabIndex = 34
        Me.lbl12.Text = "Tarefa:"
        '
        'btnExecutar
        '
        Me.btnExecutar.Location = New System.Drawing.Point(6, 63)
        Me.btnExecutar.Name = "btnExecutar"
        Me.btnExecutar.Size = New System.Drawing.Size(135, 21)
        Me.btnExecutar.TabIndex = 2
        Me.btnExecutar.Text = "&Executar"
        Me.btnExecutar.UseVisualStyleBackColor = True
        '
        'ststrp1
        '
        Me.ststrp1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslbl1, Me.tslbl2, Me.tslbl3, Me.tslbl4, Me.tslbl5, Me.tslbl6, Me.tslbl7, Me.tslbl8})
        Me.ststrp1.Location = New System.Drawing.Point(0, 392)
        Me.ststrp1.Name = "ststrp1"
        Me.ststrp1.Size = New System.Drawing.Size(460, 22)
        Me.ststrp1.TabIndex = 21
        Me.ststrp1.Text = "StatusStrip1"
        '
        'tslbl1
        '
        Me.tslbl1.Name = "tslbl1"
        Me.tslbl1.Size = New System.Drawing.Size(17, 17)
        Me.tslbl1.Text = "X:"
        '
        'tslbl2
        '
        Me.tslbl2.AutoSize = False
        Me.tslbl2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslbl2.Name = "tslbl2"
        Me.tslbl2.Size = New System.Drawing.Size(50, 17)
        '
        'tslbl3
        '
        Me.tslbl3.Name = "tslbl3"
        Me.tslbl3.Size = New System.Drawing.Size(17, 17)
        Me.tslbl3.Text = "Y:"
        '
        'tslbl4
        '
        Me.tslbl4.AutoSize = False
        Me.tslbl4.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslbl4.Name = "tslbl4"
        Me.tslbl4.Size = New System.Drawing.Size(50, 17)
        '
        'tslbl5
        '
        Me.tslbl5.Name = "tslbl5"
        Me.tslbl5.Size = New System.Drawing.Size(74, 17)
        Me.tslbl5.Text = "Comprimento:"
        '
        'tslbl6
        '
        Me.tslbl6.AutoSize = False
        Me.tslbl6.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslbl6.Name = "tslbl6"
        Me.tslbl6.Size = New System.Drawing.Size(50, 17)
        '
        'tslbl7
        '
        Me.tslbl7.Name = "tslbl7"
        Me.tslbl7.Size = New System.Drawing.Size(40, 17)
        Me.tslbl7.Text = "Altura:"
        '
        'tslbl8
        '
        Me.tslbl8.AutoSize = False
        Me.tslbl8.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslbl8.Name = "tslbl8"
        Me.tslbl8.Size = New System.Drawing.Size(50, 17)
        '
        'frmRedeNeural
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(460, 414)
        Me.Controls.Add(Me.ststrp1)
        Me.Controls.Add(Me.grpb2)
        Me.Controls.Add(Me.grpb1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmRedeNeural"
        Me.Text = "Rede Neural"
        Me.grpb2.ResumeLayout(False)
        Me.grpb2.PerformLayout()
        Me.grpb1.ResumeLayout(False)
        Me.grpb1.PerformLayout()
        Me.ststrp1.ResumeLayout(False)
        Me.ststrp1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    ' Flag que indica que não queremos o botão fechar.
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            ' Obtém as flags atuais
            Dim parametros As CreateParams = MyBase.CreateParams
            ' Adiciona a flag que indica que o "X" não deve ser mostrado
            parametros.ClassStyle = parametros.ClassStyle Or CP_NOCLOSE_BUTTON
            ' Retorna as flags modificadas
            Return parametros
        End Get
    End Property

    Private WithEvents txt1 As System.Windows.Forms.TextBox
    Private WithEvents btnET As System.Windows.Forms.Button
    Private WithEvents btnT As System.Windows.Forms.Button
    Private WithEvents btnP As System.Windows.Forms.Button
    Private WithEvents btnE As System.Windows.Forms.Button
    Friend WithEvents lbl9 As System.Windows.Forms.Label
    Private WithEvents btnR As System.Windows.Forms.Button
    Friend WithEvents grpb2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb1 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl5 As System.Windows.Forms.Label
    Friend WithEvents lbl6 As System.Windows.Forms.Label
    Friend WithEvents cmb2 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl8 As System.Windows.Forms.Label
    Friend WithEvents cmb4 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl7 As System.Windows.Forms.Label
    Friend WithEvents cmb3 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl11 As System.Windows.Forms.Label
    Private WithEvents txt2 As System.Windows.Forms.TextBox
    Private WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents lbl10 As System.Windows.Forms.Label
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents lbl4 As System.Windows.Forms.Label
    Private WithEvents btnAbortar As System.Windows.Forms.Button
    Private WithEvents btnSair As System.Windows.Forms.Button
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents pgbr1 As System.Windows.Forms.ProgressBar
    Friend WithEvents grpb1 As System.Windows.Forms.GroupBox
    Private WithEvents btnExecutar As System.Windows.Forms.Button
    Friend WithEvents cmb5 As System.Windows.Forms.ComboBox
    Friend WithEvents lbl12 As System.Windows.Forms.Label
    Friend WithEvents ststrp1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tslbl1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslbl2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslbl3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslbl4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslbl5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslbl6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslbl7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslbl8 As System.Windows.Forms.ToolStripStatusLabel

End Class
