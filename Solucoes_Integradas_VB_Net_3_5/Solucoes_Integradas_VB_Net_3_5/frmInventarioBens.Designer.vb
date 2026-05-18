Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmInventarioBens
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventarioBens))
            Me.dtgv1 = New System.Windows.Forms.DataGridView
            Me.tsbMenu = New System.Windows.Forms.ToolStrip
            Me.bcmb1 = New System.Windows.Forms.ToolStripComboBox
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
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
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
            Me.blbl2 = New System.Windows.Forms.ToolStripLabel
            Me.bcmb2 = New System.Windows.Forms.ToolStripComboBox
            Me.btxt1 = New System.Windows.Forms.ToolStripTextBox
            Me.bcmb3 = New System.Windows.Forms.ToolStripComboBox
            Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
            Me.blblCarregar = New System.Windows.Forms.ToolStripLabel
            Me.blbl3 = New System.Windows.Forms.ToolStripLabel
            Me.bcmb4 = New System.Windows.Forms.ToolStripComboBox
            Me.btxt2 = New System.Windows.Forms.ToolStripTextBox
            Me.blbl4 = New System.Windows.Forms.ToolStripLabel
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
            Me.blbl5 = New System.Windows.Forms.ToolStripLabel
            Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
            Me.blbl6 = New System.Windows.Forms.ToolStripLabel
            Me.bprgProgresso = New System.Windows.Forms.ToolStripProgressBar
            Me.blblProgresso = New System.Windows.Forms.ToolStripLabel
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
            Me.ofd1 = New System.Windows.Forms.OpenFileDialog
            Me.lsv1 = New System.Windows.Forms.ListView
            Me.ppg1 = New System.Windows.Forms.PropertyGrid
            Me.ststrp1 = New System.Windows.Forms.StatusStrip
            Me.tslblLinhaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtLinhaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tslblColunaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtColunaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tslblTotalLinhas = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtTotalLinhas = New System.Windows.Forms.ToolStripStatusLabel
            Me.tslblTotalColunas = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtTotalColunas = New System.Windows.Forms.ToolStripStatusLabel
            Me.grpb1 = New System.Windows.Forms.TabControl
            Me.tbpRelatorio = New System.Windows.Forms.TabPage
            Me.grpb11 = New System.Windows.Forms.GroupBox
            Me.cmb1 = New System.Windows.Forms.ComboBox
            Me.txt1 = New System.Windows.Forms.TextBox
            Me.btn1 = New System.Windows.Forms.Button
            Me.TabPage3 = New System.Windows.Forms.TabPage
            Me.TabPage4 = New System.Windows.Forms.TabPage
            Me.TabPage5 = New System.Windows.Forms.TabPage
            Me.TabPage6 = New System.Windows.Forms.TabPage
            Me.TabPage1 = New System.Windows.Forms.TabPage
            Me.grpb2 = New System.Windows.Forms.TabControl
            Me.tbpPropriedades = New System.Windows.Forms.TabPage
            CType(Me.dtgv1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tsbMenu.SuspendLayout()
            Me.ststrp1.SuspendLayout()
            Me.grpb1.SuspendLayout()
            Me.tbpRelatorio.SuspendLayout()
            Me.grpb11.SuspendLayout()
            Me.grpb2.SuspendLayout()
            Me.tbpPropriedades.SuspendLayout()
            Me.SuspendLayout()
            '
            'dtgv1
            '
            Me.dtgv1.BackgroundColor = System.Drawing.Color.GhostWhite
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
            Me.dtgv1.Location = New System.Drawing.Point(12, 30)
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
            Me.dtgv1.Size = New System.Drawing.Size(726, 598)
            Me.dtgv1.TabIndex = 1
            '
            'tsbMenu
            '
            Me.tsbMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bcmb1, Me.ToolStripSeparator1, Me.tsbConsultar, Me.tsbIncluir, Me.tsbExcluir, Me.tsbSalvar, Me.tsbEmail, Me.tsbAnterior, Me.tsbProximo, Me.txtProcurar, Me.tsbProcurar, Me.tsbSair, Me.ToolStripSeparator2, Me.blbl2, Me.bcmb2, Me.btxt1, Me.bcmb3, Me.ToolStripSeparator6, Me.blblCarregar, Me.blbl3, Me.bcmb4, Me.btxt2, Me.blbl4, Me.ToolStripSeparator4, Me.blbl5, Me.ToolStripSeparator5, Me.blbl6, Me.bprgProgresso, Me.blblProgresso, Me.ToolStripSeparator3})
            Me.tsbMenu.Location = New System.Drawing.Point(0, 0)
            Me.tsbMenu.Name = "tsbMenu"
            Me.tsbMenu.Size = New System.Drawing.Size(1022, 27)
            Me.tsbMenu.TabIndex = 0
            '
            'bcmb1
            '
            Me.bcmb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.bcmb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.bcmb1.Name = "bcmb1"
            Me.bcmb1.Size = New System.Drawing.Size(100, 27)
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
            '
            'tsbConsultar
            '
            Me.tsbConsultar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbConsultar.Image = CType(resources.GetObject("tsbConsultar.Image"), System.Drawing.Image)
            Me.tsbConsultar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbConsultar.Name = "tsbConsultar"
            Me.tsbConsultar.Size = New System.Drawing.Size(23, 24)
            Me.tsbConsultar.Text = "Consultar"
            '
            'tsbIncluir
            '
            Me.tsbIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbIncluir.Enabled = False
            Me.tsbIncluir.Image = CType(resources.GetObject("tsbIncluir.Image"), System.Drawing.Image)
            Me.tsbIncluir.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbIncluir.Name = "tsbIncluir"
            Me.tsbIncluir.Size = New System.Drawing.Size(23, 24)
            Me.tsbIncluir.Text = "Incluir "
            '
            'tsbExcluir
            '
            Me.tsbExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbExcluir.Image = CType(resources.GetObject("tsbExcluir.Image"), System.Drawing.Image)
            Me.tsbExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbExcluir.Name = "tsbExcluir"
            Me.tsbExcluir.Size = New System.Drawing.Size(23, 24)
            Me.tsbExcluir.Text = "Excluir"
            '
            'tsbSalvar
            '
            Me.tsbSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbSalvar.Enabled = False
            Me.tsbSalvar.Image = CType(resources.GetObject("tsbSalvar.Image"), System.Drawing.Image)
            Me.tsbSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbSalvar.Name = "tsbSalvar"
            Me.tsbSalvar.Size = New System.Drawing.Size(23, 24)
            Me.tsbSalvar.Text = "Salvar"
            '
            'tsbEmail
            '
            Me.tsbEmail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbEmail.Image = CType(resources.GetObject("tsbEmail.Image"), System.Drawing.Image)
            Me.tsbEmail.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbEmail.Name = "tsbEmail"
            Me.tsbEmail.Size = New System.Drawing.Size(23, 24)
            Me.tsbEmail.Text = "Email"
            '
            'tsbAnterior
            '
            Me.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbAnterior.Image = CType(resources.GetObject("tsbAnterior.Image"), System.Drawing.Image)
            Me.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbAnterior.Name = "tsbAnterior"
            Me.tsbAnterior.Size = New System.Drawing.Size(23, 24)
            Me.tsbAnterior.Text = "Anterior"
            '
            'tsbProximo
            '
            Me.tsbProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbProximo.Image = CType(resources.GetObject("tsbProximo.Image"), System.Drawing.Image)
            Me.tsbProximo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbProximo.Name = "tsbProximo"
            Me.tsbProximo.Size = New System.Drawing.Size(23, 24)
            Me.tsbProximo.Text = "Próximo"
            '
            'txtProcurar
            '
            Me.txtProcurar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProcurar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtProcurar.Name = "txtProcurar"
            Me.txtProcurar.Size = New System.Drawing.Size(100, 27)
            '
            'tsbProcurar
            '
            Me.tsbProcurar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbProcurar.Image = CType(resources.GetObject("tsbProcurar.Image"), System.Drawing.Image)
            Me.tsbProcurar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbProcurar.Name = "tsbProcurar"
            Me.tsbProcurar.Size = New System.Drawing.Size(23, 24)
            Me.tsbProcurar.Text = "Procurar"
            '
            'tsbSair
            '
            Me.tsbSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbSair.Image = CType(resources.GetObject("tsbSair.Image"), System.Drawing.Image)
            Me.tsbSair.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbSair.Name = "tsbSair"
            Me.tsbSair.Size = New System.Drawing.Size(23, 24)
            Me.tsbSair.Text = "Sair"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
            '
            'blbl2
            '
            Me.blbl2.Name = "blbl2"
            Me.blbl2.Size = New System.Drawing.Size(61, 24)
            Me.blbl2.Text = "Consultar:"
            Me.blbl2.ToolTipText = "Consulte os campos desejados na tabela."
            '
            'bcmb2
            '
            Me.bcmb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.bcmb2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.bcmb2.Name = "bcmb2"
            Me.bcmb2.Size = New System.Drawing.Size(100, 27)
            '
            'btxt1
            '
            Me.btxt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.btxt1.Name = "btxt1"
            Me.btxt1.Size = New System.Drawing.Size(100, 27)
            '
            'bcmb3
            '
            Me.bcmb3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.bcmb3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.bcmb3.Name = "bcmb3"
            Me.bcmb3.Size = New System.Drawing.Size(100, 27)
            '
            'ToolStripSeparator6
            '
            Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
            Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 27)
            '
            'blblCarregar
            '
            Me.blblCarregar.Name = "blblCarregar"
            Me.blblCarregar.Size = New System.Drawing.Size(79, 24)
            Me.blblCarregar.Text = "Carregar Lista"
            '
            'blbl3
            '
            Me.blbl3.Name = "blbl3"
            Me.blbl3.Size = New System.Drawing.Size(122, 15)
            Me.blbl3.Text = "Alterar Itens - Coluna:"
            '
            'bcmb4
            '
            Me.bcmb4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.bcmb4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.bcmb4.Name = "bcmb4"
            Me.bcmb4.Size = New System.Drawing.Size(100, 23)
            '
            'btxt2
            '
            Me.btxt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.btxt2.Name = "btxt2"
            Me.btxt2.Size = New System.Drawing.Size(100, 23)
            '
            'blbl4
            '
            Me.blbl4.Name = "blbl4"
            Me.blbl4.Size = New System.Drawing.Size(42, 15)
            Me.blbl4.Text = "Alterar"
            '
            'ToolStripSeparator4
            '
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 27)
            '
            'blbl5
            '
            Me.blbl5.Name = "blbl5"
            Me.blbl5.Size = New System.Drawing.Size(50, 15)
            Me.blbl5.Text = "Exportar"
            Me.blbl5.ToolTipText = "Clique aqui para exportar os dados."
            '
            'ToolStripSeparator5
            '
            Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
            Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 27)
            '
            'blbl6
            '
            Me.blbl6.Name = "blbl6"
            Me.blbl6.Size = New System.Drawing.Size(62, 15)
            Me.blbl6.Text = "Progresso:"
            '
            'bprgProgresso
            '
            Me.bprgProgresso.Name = "bprgProgresso"
            Me.bprgProgresso.Size = New System.Drawing.Size(100, 24)
            Me.bprgProgresso.Style = System.Windows.Forms.ProgressBarStyle.Continuous
            '
            'blblProgresso
            '
            Me.blblProgresso.Name = "blblProgresso"
            Me.blblProgresso.Size = New System.Drawing.Size(0, 0)
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
            '
            'lsv1
            '
            Me.lsv1.BackColor = System.Drawing.Color.GhostWhite
            Me.lsv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lsv1.Dock = System.Windows.Forms.DockStyle.Top
            Me.lsv1.Location = New System.Drawing.Point(3, 3)
            Me.lsv1.Name = "lsv1"
            Me.lsv1.Size = New System.Drawing.Size(252, 208)
            Me.lsv1.TabIndex = 2
            Me.lsv1.UseCompatibleStateImageBehavior = False
            '
            'ppg1
            '
            Me.ppg1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ppg1.Location = New System.Drawing.Point(3, 3)
            Me.ppg1.Name = "ppg1"
            Me.ppg1.Size = New System.Drawing.Size(252, 264)
            Me.ppg1.TabIndex = 3
            Me.ppg1.ViewBackColor = System.Drawing.Color.GhostWhite
            '
            'ststrp1
            '
            Me.ststrp1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblLinhaSelecionada, Me.tstxtLinhaSelecionada, Me.tslblColunaSelecionada, Me.tstxtColunaSelecionada, Me.tslblTotalLinhas, Me.tstxtTotalLinhas, Me.tslblTotalColunas, Me.tstxtTotalColunas})
            Me.ststrp1.Location = New System.Drawing.Point(0, 631)
            Me.ststrp1.Name = "ststrp1"
            Me.ststrp1.Size = New System.Drawing.Size(1022, 22)
            Me.ststrp1.TabIndex = 46
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
            'grpb1
            '
            Me.grpb1.Controls.Add(Me.tbpRelatorio)
            Me.grpb1.Location = New System.Drawing.Point(744, 30)
            Me.grpb1.Name = "grpb1"
            Me.grpb1.SelectedIndex = 0
            Me.grpb1.Size = New System.Drawing.Size(266, 296)
            Me.grpb1.TabIndex = 47
            '
            'tbpRelatorio
            '
            Me.tbpRelatorio.Controls.Add(Me.grpb11)
            Me.tbpRelatorio.Controls.Add(Me.lsv1)
            Me.tbpRelatorio.Location = New System.Drawing.Point(4, 22)
            Me.tbpRelatorio.Name = "tbpRelatorio"
            Me.tbpRelatorio.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpRelatorio.Size = New System.Drawing.Size(258, 270)
            Me.tbpRelatorio.TabIndex = 0
            Me.tbpRelatorio.Text = "Relatório"
            Me.tbpRelatorio.UseVisualStyleBackColor = True
            '
            'grpb11
            '
            Me.grpb11.Controls.Add(Me.cmb1)
            Me.grpb11.Controls.Add(Me.txt1)
            Me.grpb11.Controls.Add(Me.btn1)
            Me.grpb11.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.grpb11.Location = New System.Drawing.Point(3, 217)
            Me.grpb11.Name = "grpb11"
            Me.grpb11.Size = New System.Drawing.Size(252, 50)
            Me.grpb11.TabIndex = 6
            Me.grpb11.TabStop = False
            Me.grpb11.Text = "Controle"
            '
            'cmb1
            '
            Me.cmb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmb1.FormattingEnabled = True
            Me.cmb1.Location = New System.Drawing.Point(40, 19)
            Me.cmb1.Name = "cmb1"
            Me.cmb1.Size = New System.Drawing.Size(130, 21)
            Me.cmb1.TabIndex = 2
            '
            'txt1
            '
            Me.txt1.Location = New System.Drawing.Point(9, 19)
            Me.txt1.Name = "txt1"
            Me.txt1.Size = New System.Drawing.Size(25, 20)
            Me.txt1.TabIndex = 4
            '
            'btn1
            '
            Me.btn1.BackColor = System.Drawing.Color.GhostWhite
            Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btn1.Location = New System.Drawing.Point(176, 19)
            Me.btn1.Name = "btn1"
            Me.btn1.Size = New System.Drawing.Size(70, 23)
            Me.btn1.TabIndex = 1
            Me.btn1.Text = "&Consultar"
            Me.btn1.UseVisualStyleBackColor = False
            '
            'TabPage3
            '
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage3.Size = New System.Drawing.Size(192, 74)
            Me.TabPage3.TabIndex = 0
            Me.TabPage3.Text = "TabPage1"
            Me.TabPage3.UseVisualStyleBackColor = True
            '
            'TabPage4
            '
            Me.TabPage4.Location = New System.Drawing.Point(4, 22)
            Me.TabPage4.Name = "TabPage4"
            Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage4.Size = New System.Drawing.Size(192, 74)
            Me.TabPage4.TabIndex = 1
            Me.TabPage4.Text = "TabPage2"
            Me.TabPage4.UseVisualStyleBackColor = True
            '
            'TabPage5
            '
            Me.TabPage5.Location = New System.Drawing.Point(4, 22)
            Me.TabPage5.Name = "TabPage5"
            Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage5.Size = New System.Drawing.Size(192, 74)
            Me.TabPage5.TabIndex = 0
            Me.TabPage5.Text = "TabPage1"
            Me.TabPage5.UseVisualStyleBackColor = True
            '
            'TabPage6
            '
            Me.TabPage6.Location = New System.Drawing.Point(4, 22)
            Me.TabPage6.Name = "TabPage6"
            Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage6.Size = New System.Drawing.Size(192, 74)
            Me.TabPage6.TabIndex = 1
            Me.TabPage6.Text = "TabPage2"
            Me.TabPage6.UseVisualStyleBackColor = True
            '
            'TabPage1
            '
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(258, 244)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Relatório"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'grpb2
            '
            Me.grpb2.Controls.Add(Me.tbpPropriedades)
            Me.grpb2.Location = New System.Drawing.Point(744, 332)
            Me.grpb2.Name = "grpb2"
            Me.grpb2.SelectedIndex = 0
            Me.grpb2.Size = New System.Drawing.Size(266, 296)
            Me.grpb2.TabIndex = 48
            '
            'tbpPropriedades
            '
            Me.tbpPropriedades.Controls.Add(Me.ppg1)
            Me.tbpPropriedades.Location = New System.Drawing.Point(4, 22)
            Me.tbpPropriedades.Name = "tbpPropriedades"
            Me.tbpPropriedades.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpPropriedades.Size = New System.Drawing.Size(258, 270)
            Me.tbpPropriedades.TabIndex = 0
            Me.tbpPropriedades.Text = "Propriedades"
            Me.tbpPropriedades.UseVisualStyleBackColor = True
            '
            'frmInventarioBens
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.Window
            Me.ClientSize = New System.Drawing.Size(1022, 653)
            Me.Controls.Add(Me.grpb2)
            Me.Controls.Add(Me.grpb1)
            Me.Controls.Add(Me.ststrp1)
            Me.Controls.Add(Me.tsbMenu)
            Me.Controls.Add(Me.dtgv1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "frmInventarioBens"
            Me.Text = "Inventário de Bens"
            CType(Me.dtgv1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tsbMenu.ResumeLayout(False)
            Me.tsbMenu.PerformLayout()
            Me.ststrp1.ResumeLayout(False)
            Me.ststrp1.PerformLayout()
            Me.grpb1.ResumeLayout(False)
            Me.tbpRelatorio.ResumeLayout(False)
            Me.grpb11.ResumeLayout(False)
            Me.grpb11.PerformLayout()
            Me.grpb2.ResumeLayout(False)
            Me.tbpPropriedades.ResumeLayout(False)
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
        Friend WithEvents tsbMenu As System.Windows.Forms.ToolStrip
        Friend WithEvents bcmb1 As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents tsbIncluir As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbExcluir As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbSalvar As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbAnterior As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbProximo As System.Windows.Forms.ToolStripButton
        Friend WithEvents txtProcurar As System.Windows.Forms.ToolStripTextBox
        Friend WithEvents tsbProcurar As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbSair As System.Windows.Forms.ToolStripButton
        Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents blbl2 As System.Windows.Forms.ToolStripLabel
        Friend WithEvents bcmb4 As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents btxt1 As System.Windows.Forms.ToolStripTextBox
        Friend WithEvents bcmb3 As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents blbl5 As System.Windows.Forms.ToolStripLabel
        Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents blbl6 As System.Windows.Forms.ToolStripLabel
        Friend WithEvents bprgProgresso As System.Windows.Forms.ToolStripProgressBar
        Friend WithEvents tsbConsultar As System.Windows.Forms.ToolStripButton
        Friend WithEvents ofd1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents blbl4 As System.Windows.Forms.ToolStripLabel
        Friend WithEvents lsv1 As System.Windows.Forms.ListView
        Friend WithEvents ppg1 As System.Windows.Forms.PropertyGrid
        Friend WithEvents btxt2 As System.Windows.Forms.ToolStripTextBox
        Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents bcmb2 As System.Windows.Forms.ToolStripComboBox
        Friend WithEvents blbl3 As System.Windows.Forms.ToolStripLabel
        Friend WithEvents blblProgresso As System.Windows.Forms.ToolStripLabel
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
        Friend WithEvents blblCarregar As System.Windows.Forms.ToolStripLabel
        Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
        Friend WithEvents grpb1 As System.Windows.Forms.TabControl
        Friend WithEvents tbpRelatorio As System.Windows.Forms.TabPage
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents grpb2 As System.Windows.Forms.TabControl
        Friend WithEvents tbpPropriedades As System.Windows.Forms.TabPage
        Friend WithEvents grpb11 As System.Windows.Forms.GroupBox
        Friend WithEvents cmb1 As System.Windows.Forms.ComboBox
        Friend WithEvents txt1 As System.Windows.Forms.TextBox
        Friend WithEvents btn1 As System.Windows.Forms.Button
    End Class
End Namespace