<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisualizador
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
        Me.dtgv1 = New System.Windows.Forms.DataGridView
        Me.btnAjustar = New System.Windows.Forms.Button
        Me.btnLer = New System.Windows.Forms.Button
        Me.btnCadastrar = New System.Windows.Forms.Button
        Me.btnSair = New System.Windows.Forms.Button
        Me.ststrp1 = New System.Windows.Forms.StatusStrip
        Me.tslbl1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslbl8 = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.dtgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ststrp1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgv1
        '
        Me.dtgv1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.dtgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv1.Location = New System.Drawing.Point(12, 12)
        Me.dtgv1.Name = "dtgv1"
        Me.dtgv1.Size = New System.Drawing.Size(570, 223)
        Me.dtgv1.TabIndex = 0
        '
        'btnAjustar
        '
        Me.btnAjustar.Location = New System.Drawing.Point(236, 241)
        Me.btnAjustar.Name = "btnAjustar"
        Me.btnAjustar.Size = New System.Drawing.Size(82, 22)
        Me.btnAjustar.TabIndex = 7
        Me.btnAjustar.Text = "&Ajustar"
        Me.btnAjustar.UseVisualStyleBackColor = True
        '
        'btnLer
        '
        Me.btnLer.Location = New System.Drawing.Point(324, 241)
        Me.btnLer.Name = "btnLer"
        Me.btnLer.Size = New System.Drawing.Size(82, 22)
        Me.btnLer.TabIndex = 6
        Me.btnLer.Text = "&Ler"
        Me.btnLer.UseVisualStyleBackColor = True
        '
        'btnCadastrar
        '
        Me.btnCadastrar.Location = New System.Drawing.Point(412, 241)
        Me.btnCadastrar.Name = "btnCadastrar"
        Me.btnCadastrar.Size = New System.Drawing.Size(82, 22)
        Me.btnCadastrar.TabIndex = 5
        Me.btnCadastrar.Text = "&Cadastrar"
        Me.btnCadastrar.UseVisualStyleBackColor = True
        '
        'btnSair
        '
        Me.btnSair.Location = New System.Drawing.Point(500, 241)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(82, 22)
        Me.btnSair.TabIndex = 11
        Me.btnSair.Text = "&Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'ststrp1
        '
        Me.ststrp1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslbl1, Me.tslbl2, Me.tslbl3, Me.tslbl4, Me.tslbl5, Me.tslbl6, Me.tslbl7, Me.tslbl8})
        Me.ststrp1.Location = New System.Drawing.Point(0, 268)
        Me.ststrp1.Name = "ststrp1"
        Me.ststrp1.Size = New System.Drawing.Size(593, 22)
        Me.ststrp1.TabIndex = 14
        Me.ststrp1.Text = "StatusStrip1"
        '
        'tslbl1
        '
        Me.tslbl1.Name = "tslbl1"
        Me.tslbl1.Size = New System.Drawing.Size(83, 17)
        Me.tslbl1.Text = "Total de Linhas:"
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
        Me.tslbl3.Size = New System.Drawing.Size(91, 17)
        Me.tslbl3.Text = "Total de Colunas:"
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
        Me.tslbl5.Size = New System.Drawing.Size(96, 17)
        Me.tslbl5.Text = "Linha Selecionada:"
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
        Me.tslbl7.Size = New System.Drawing.Size(104, 17)
        Me.tslbl7.Text = "Coluna Selecionada:"
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
        'frmVisualizador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(593, 290)
        Me.Controls.Add(Me.ststrp1)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.btnAjustar)
        Me.Controls.Add(Me.btnLer)
        Me.Controls.Add(Me.btnCadastrar)
        Me.Controls.Add(Me.dtgv1)
        Me.Name = "frmVisualizador"
        Me.Text = "Tabela de Dados"
        CType(Me.dtgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ststrp1.ResumeLayout(False)
        Me.ststrp1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    'Flag que indica que não queremos o botão fechar..
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            'Obtém as flags atuais
            Dim parametros As CreateParams = MyBase.CreateParams
            'Adiciona a flag que indica que o "X" não deve ser mostrado
            parametros.ClassStyle = parametros.ClassStyle Or CP_NOCLOSE_BUTTON
            'Retorna as flags modificadas
            Return parametros
        End Get
    End Property

    Friend WithEvents dtgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnAjustar As System.Windows.Forms.Button
    Friend WithEvents btnLer As System.Windows.Forms.Button
    Friend WithEvents btnCadastrar As System.Windows.Forms.Button
    Friend WithEvents btnSair As System.Windows.Forms.Button
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
