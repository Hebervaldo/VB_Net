Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class frmCadastroUsuario
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadastroUsuario))
            Me.dtgv1 = New System.Windows.Forms.DataGridView
            Me.grpb1 = New System.Windows.Forms.GroupBox
            Me.txt4 = New System.Windows.Forms.TextBox
            Me.lbl4 = New System.Windows.Forms.Label
            Me.lbl3 = New System.Windows.Forms.Label
            Me.lbl2 = New System.Windows.Forms.Label
            Me.txt3 = New System.Windows.Forms.TextBox
            Me.txt2 = New System.Windows.Forms.TextBox
            Me.grpb2 = New System.Windows.Forms.GroupBox
            Me.cmb1 = New System.Windows.Forms.ComboBox
            Me.lbl5 = New System.Windows.Forms.Label
            Me.tsbMenu = New System.Windows.Forms.ToolStrip
            Me.tsbConsultar = New System.Windows.Forms.ToolStripButton
            Me.tsbIncluir = New System.Windows.Forms.ToolStripButton
            Me.tsbExcluir = New System.Windows.Forms.ToolStripButton
            Me.tsbSalvar = New System.Windows.Forms.ToolStripButton
            Me.tsbEmail = New System.Windows.Forms.ToolStripButton
            Me.tsbAnterior = New System.Windows.Forms.ToolStripButton
            Me.tsbProximo = New System.Windows.Forms.ToolStripButton
            Me.txtProcurar = New System.Windows.Forms.ToolStripTextBox
            Me.tsbProcurar = New System.Windows.Forms.ToolStripButton
            Me.tsbSair = New System.Windows.Forms.ToolStripButton
            Me.ststrp1 = New System.Windows.Forms.StatusStrip
            Me.tslblLinhaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtLinhaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tslblColunaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtColunaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tslblTotalLinhas = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtTotalLinhas = New System.Windows.Forms.ToolStripStatusLabel
            Me.tslblTotalColunas = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtTotalColunas = New System.Windows.Forms.ToolStripStatusLabel
            CType(Me.dtgv1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpb1.SuspendLayout()
            Me.grpb2.SuspendLayout()
            Me.tsbMenu.SuspendLayout()
            Me.ststrp1.SuspendLayout()
            Me.SuspendLayout()
            '
            'dtgv1
            '
            Me.dtgv1.BackgroundColor = System.Drawing.Color.Beige
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dtgv1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dtgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dtgv1.DefaultCellStyle = DataGridViewCellStyle2
            Me.dtgv1.Location = New System.Drawing.Point(12, 29)
            Me.dtgv1.MultiSelect = False
            Me.dtgv1.Name = "dtgv1"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dtgv1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
            Me.dtgv1.Size = New System.Drawing.Size(834, 619)
            Me.dtgv1.TabIndex = 1
            '
            'grpb1
            '
            Me.grpb1.Controls.Add(Me.txt4)
            Me.grpb1.Controls.Add(Me.lbl4)
            Me.grpb1.Controls.Add(Me.lbl3)
            Me.grpb1.Controls.Add(Me.lbl2)
            Me.grpb1.Controls.Add(Me.txt3)
            Me.grpb1.Controls.Add(Me.txt2)
            Me.grpb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.grpb1.Location = New System.Drawing.Point(852, 39)
            Me.grpb1.Name = "grpb1"
            Me.grpb1.Size = New System.Drawing.Size(164, 196)
            Me.grpb1.TabIndex = 2
            Me.grpb1.TabStop = False
            Me.grpb1.Text = "Criptografia"
            '
            'txt4
            '
            Me.txt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txt4.Enabled = False
            Me.txt4.Location = New System.Drawing.Point(6, 71)
            Me.txt4.Multiline = True
            Me.txt4.Name = "txt4"
            Me.txt4.Size = New System.Drawing.Size(152, 50)
            Me.txt4.TabIndex = 6
            '
            'lbl4
            '
            Me.lbl4.AutoSize = True
            Me.lbl4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl4.Location = New System.Drawing.Point(6, 124)
            Me.lbl4.Name = "lbl4"
            Me.lbl4.Size = New System.Drawing.Size(41, 13)
            Me.lbl4.TabIndex = 7
            Me.lbl4.Text = "Chave:"
            '
            'lbl3
            '
            Me.lbl3.AutoSize = True
            Me.lbl3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl3.Location = New System.Drawing.Point(3, 55)
            Me.lbl3.Name = "lbl3"
            Me.lbl3.Size = New System.Drawing.Size(107, 13)
            Me.lbl3.TabIndex = 5
            Me.lbl3.Text = "Senha Criptografada:"
            '
            'lbl2
            '
            Me.lbl2.AutoSize = True
            Me.lbl2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl2.Location = New System.Drawing.Point(6, 16)
            Me.lbl2.Name = "lbl2"
            Me.lbl2.Size = New System.Drawing.Size(41, 13)
            Me.lbl2.TabIndex = 3
            Me.lbl2.Text = "Senha:"
            '
            'txt3
            '
            Me.txt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txt3.Location = New System.Drawing.Point(6, 140)
            Me.txt3.Multiline = True
            Me.txt3.Name = "txt3"
            Me.txt3.Size = New System.Drawing.Size(152, 50)
            Me.txt3.TabIndex = 8
            '
            'txt2
            '
            Me.txt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txt2.Location = New System.Drawing.Point(6, 32)
            Me.txt2.Name = "txt2"
            Me.txt2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txt2.Size = New System.Drawing.Size(152, 20)
            Me.txt2.TabIndex = 4
            '
            'grpb2
            '
            Me.grpb2.Controls.Add(Me.cmb1)
            Me.grpb2.Controls.Add(Me.lbl5)
            Me.grpb2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.grpb2.Location = New System.Drawing.Point(852, 241)
            Me.grpb2.Name = "grpb2"
            Me.grpb2.Size = New System.Drawing.Size(164, 60)
            Me.grpb2.TabIndex = 9
            Me.grpb2.TabStop = False
            Me.grpb2.Text = "Status do Usuário"
            '
            'cmb1
            '
            Me.cmb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cmb1.FormattingEnabled = True
            Me.cmb1.Location = New System.Drawing.Point(6, 32)
            Me.cmb1.Name = "cmb1"
            Me.cmb1.Size = New System.Drawing.Size(152, 21)
            Me.cmb1.TabIndex = 11
            '
            'lbl5
            '
            Me.lbl5.AutoSize = True
            Me.lbl5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl5.Location = New System.Drawing.Point(6, 16)
            Me.lbl5.Name = "lbl5"
            Me.lbl5.Size = New System.Drawing.Size(40, 13)
            Me.lbl5.TabIndex = 10
            Me.lbl5.Text = "Status:"
            '
            'tsbMenu
            '
            Me.tsbMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsultar, Me.tsbIncluir, Me.tsbExcluir, Me.tsbSalvar, Me.tsbEmail, Me.tsbAnterior, Me.tsbProximo, Me.txtProcurar, Me.tsbProcurar, Me.tsbSair})
            Me.tsbMenu.Location = New System.Drawing.Point(0, 0)
            Me.tsbMenu.Name = "tsbMenu"
            Me.tsbMenu.Size = New System.Drawing.Size(1022, 25)
            Me.tsbMenu.TabIndex = 0
            '
            'tsbConsultar
            '
            Me.tsbConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
            Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbConsultar.Name = "tsbConsultar"
            Me.tsbConsultar.Size = New System.Drawing.Size(23, 22)
            Me.tsbConsultar.Text = "Consultar"
            '
            'tsbIncluir
            '
            Me.tsbIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbIncluir.Enabled = False
            Me.tsbIncluir.Image = CType(resources.GetObject("tsbIncluir.Image"), System.Drawing.Image)
            Me.tsbIncluir.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbIncluir.Name = "tsbIncluir"
            Me.tsbIncluir.Size = New System.Drawing.Size(23, 22)
            Me.tsbIncluir.Text = "Incluir "
            '
            'tsbExcluir
            '
            Me.tsbExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbExcluir.Image = CType(resources.GetObject("tsbExcluir.Image"), System.Drawing.Image)
            Me.tsbExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbExcluir.Name = "tsbExcluir"
            Me.tsbExcluir.Size = New System.Drawing.Size(23, 22)
            Me.tsbExcluir.Text = "Excluir"
            '
            'tsbSalvar
            '
            Me.tsbSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbSalvar.Enabled = False
            Me.tsbSalvar.Image = CType(resources.GetObject("tsbSalvar.Image"), System.Drawing.Image)
            Me.tsbSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbSalvar.Name = "tsbSalvar"
            Me.tsbSalvar.Size = New System.Drawing.Size(23, 22)
            Me.tsbSalvar.Text = "Salvar"
            '
            'tsbEmail
            '
            Me.tsbEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbEmail.Enabled = False
            Me.tsbEmail.Image = CType(resources.GetObject("tsbEmail.Image"), System.Drawing.Image)
            Me.tsbEmail.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbEmail.Name = "tsbEmail"
            Me.tsbEmail.Size = New System.Drawing.Size(23, 22)
            Me.tsbEmail.Text = "Email"
            '
            'tsbAnterior
            '
            Me.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbAnterior.Image = CType(resources.GetObject("tsbAnterior.Image"), System.Drawing.Image)
            Me.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbAnterior.Name = "tsbAnterior"
            Me.tsbAnterior.Size = New System.Drawing.Size(23, 22)
            Me.tsbAnterior.Text = "Anterior"
            '
            'tsbProximo
            '
            Me.tsbProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbProximo.Image = CType(resources.GetObject("tsbProximo.Image"), System.Drawing.Image)
            Me.tsbProximo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbProximo.Name = "tsbProximo"
            Me.tsbProximo.Size = New System.Drawing.Size(23, 22)
            Me.tsbProximo.Text = "Próximo"
            '
            'txtProcurar
            '
            Me.txtProcurar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProcurar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtProcurar.Name = "txtProcurar"
            Me.txtProcurar.Size = New System.Drawing.Size(100, 25)
            '
            'tsbProcurar
            '
            Me.tsbProcurar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbProcurar.Image = CType(resources.GetObject("tsbProcurar.Image"), System.Drawing.Image)
            Me.tsbProcurar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbProcurar.Name = "tsbProcurar"
            Me.tsbProcurar.Size = New System.Drawing.Size(23, 22)
            Me.tsbProcurar.Text = "Procurar"
            '
            'tsbSair
            '
            Me.tsbSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbSair.Image = CType(resources.GetObject("tsbSair.Image"), System.Drawing.Image)
            Me.tsbSair.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbSair.Name = "tsbSair"
            Me.tsbSair.Size = New System.Drawing.Size(23, 22)
            Me.tsbSair.Text = "Sair"
            '
            'ststrp1
            '
            Me.ststrp1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblLinhaSelecionada, Me.tstxtLinhaSelecionada, Me.tslblColunaSelecionada, Me.tstxtColunaSelecionada, Me.tslblTotalLinhas, Me.tstxtTotalLinhas, Me.tslblTotalColunas, Me.tstxtTotalColunas})
            Me.ststrp1.Location = New System.Drawing.Point(0, 651)
            Me.ststrp1.Name = "ststrp1"
            Me.ststrp1.Size = New System.Drawing.Size(1022, 22)
            Me.ststrp1.TabIndex = 45
            '
            'tslblLinhaSelecionada
            '
            Me.tslblLinhaSelecionada.Name = "tslblLinhaSelecionada"
            Me.tslblLinhaSelecionada.Size = New System.Drawing.Size(105, 17)
            Me.tslblLinhaSelecionada.Text = "Linha Selecionada:"
            '
            'tstxtLinhaSelecionada
            '
            Me.tstxtLinhaSelecionada.AutoSize = False
            Me.tstxtLinhaSelecionada.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                        Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                        Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
            Me.tstxtLinhaSelecionada.Name = "tstxtLinhaSelecionada"
            Me.tstxtLinhaSelecionada.Size = New System.Drawing.Size(50, 17)
            '
            'tslblColunaSelecionada
            '
            Me.tslblColunaSelecionada.Name = "tslblColunaSelecionada"
            Me.tslblColunaSelecionada.Size = New System.Drawing.Size(114, 17)
            Me.tslblColunaSelecionada.Text = "Coluna Selecionada:"
            '
            'tstxtColunaSelecionada
            '
            Me.tstxtColunaSelecionada.AutoSize = False
            Me.tstxtColunaSelecionada.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                        Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                        Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
            Me.tstxtColunaSelecionada.Name = "tstxtColunaSelecionada"
            Me.tstxtColunaSelecionada.Size = New System.Drawing.Size(50, 17)
            '
            'tslblTotalLinhas
            '
            Me.tslblTotalLinhas.Name = "tslblTotalLinhas"
            Me.tslblTotalLinhas.Size = New System.Drawing.Size(90, 17)
            Me.tslblTotalLinhas.Text = "Total de Linhas:"
            '
            'tstxtTotalLinhas
            '
            Me.tstxtTotalLinhas.AutoSize = False
            Me.tstxtTotalLinhas.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                        Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                        Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
            Me.tstxtTotalLinhas.Name = "tstxtTotalLinhas"
            Me.tstxtTotalLinhas.Size = New System.Drawing.Size(50, 17)
            '
            'tslblTotalColunas
            '
            Me.tslblTotalColunas.Name = "tslblTotalColunas"
            Me.tslblTotalColunas.Size = New System.Drawing.Size(99, 17)
            Me.tslblTotalColunas.Text = "Total de Colunas:"
            '
            'tstxtTotalColunas
            '
            Me.tstxtTotalColunas.AutoSize = False
            Me.tstxtTotalColunas.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                        Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                        Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
            Me.tstxtTotalColunas.Name = "tstxtTotalColunas"
            Me.tstxtTotalColunas.Size = New System.Drawing.Size(50, 17)
            '
            'frmCadastroUsuario
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.Window
            Me.ClientSize = New System.Drawing.Size(1022, 673)
            Me.Controls.Add(Me.ststrp1)
            Me.Controls.Add(Me.tsbMenu)
            Me.Controls.Add(Me.grpb2)
            Me.Controls.Add(Me.grpb1)
            Me.Controls.Add(Me.dtgv1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "frmCadastroUsuario"
            Me.Text = "Cadastro de Usuários"
            CType(Me.dtgv1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpb1.ResumeLayout(False)
            Me.grpb1.PerformLayout()
            Me.grpb2.ResumeLayout(False)
            Me.grpb2.PerformLayout()
            Me.tsbMenu.ResumeLayout(False)
            Me.tsbMenu.PerformLayout()
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
                ' parametros.ClassStyle = parametros.ClassStyle Or CP_NOCLOSE_BUTTON
                ' Retorna as flags modificadas
                Return parametros
            End Get
        End Property

        Friend WithEvents dtgv1 As System.Windows.Forms.DataGridView
        Friend WithEvents grpb1 As System.Windows.Forms.GroupBox
        Friend WithEvents txt2 As System.Windows.Forms.TextBox
        Friend WithEvents txt3 As System.Windows.Forms.TextBox
        Friend WithEvents lbl4 As System.Windows.Forms.Label
        Friend WithEvents lbl3 As System.Windows.Forms.Label
        Friend WithEvents lbl2 As System.Windows.Forms.Label
        Friend WithEvents txt4 As System.Windows.Forms.TextBox
        Friend WithEvents grpb2 As System.Windows.Forms.GroupBox
        Friend WithEvents cmb1 As System.Windows.Forms.ComboBox
        Friend WithEvents lbl5 As System.Windows.Forms.Label
        Friend WithEvents tsbMenu As System.Windows.Forms.ToolStrip
        Friend WithEvents tsbIncluir As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbExcluir As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbSalvar As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbAnterior As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbProximo As System.Windows.Forms.ToolStripButton
        Friend WithEvents txtProcurar As System.Windows.Forms.ToolStripTextBox
        Friend WithEvents tsbProcurar As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbSair As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
        Friend WithEvents ststrp1 As System.Windows.Forms.StatusStrip
        Friend WithEvents tslblLinhaSelecionada As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tstxtLinhaSelecionada As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslblColunaSelecionada As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tstxtColunaSelecionada As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslblTotalLinhas As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tstxtTotalLinhas As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslblTotalColunas As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tstxtTotalColunas As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tsbEmail As System.Windows.Forms.ToolStripButton
    End Class
End Namespace