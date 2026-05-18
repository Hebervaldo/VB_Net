Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmSugestionador
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSugestionador))
            Me.lsv1 = New System.Windows.Forms.ListView
            Me.ststrp1 = New System.Windows.Forms.StatusStrip
            Me.tslblLinhaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtLinhaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tslblColunaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtColunaSelecionada = New System.Windows.Forms.ToolStripStatusLabel
            Me.tslblTotalLinhas = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtTotalLinhas = New System.Windows.Forms.ToolStripStatusLabel
            Me.tslblTotalColunas = New System.Windows.Forms.ToolStripStatusLabel
            Me.tstxtTotalColunas = New System.Windows.Forms.ToolStripStatusLabel
            Me.ststrp1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lsv1
            '
            Me.lsv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lsv1.Location = New System.Drawing.Point(12, 12)
            Me.lsv1.Name = "lsv1"
            Me.lsv1.Size = New System.Drawing.Size(810, 265)
            Me.lsv1.TabIndex = 0
            Me.lsv1.UseCompatibleStateImageBehavior = False
            '
            'ststrp1
            '
            Me.ststrp1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslblLinhaSelecionada, Me.tstxtLinhaSelecionada, Me.tslblColunaSelecionada, Me.tstxtColunaSelecionada, Me.tslblTotalLinhas, Me.tstxtTotalLinhas, Me.tslblTotalColunas, Me.tstxtTotalColunas})
            Me.ststrp1.Location = New System.Drawing.Point(0, 283)
            Me.ststrp1.Name = "ststrp1"
            Me.ststrp1.Size = New System.Drawing.Size(834, 22)
            Me.ststrp1.TabIndex = 47
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
            'frmSugestionador
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(834, 305)
            Me.Controls.Add(Me.ststrp1)
            Me.Controls.Add(Me.lsv1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "frmSugestionador"
            Me.ststrp1.ResumeLayout(False)
            Me.ststrp1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lsv1 As System.Windows.Forms.ListView
        Friend WithEvents ststrp1 As System.Windows.Forms.StatusStrip
        Friend WithEvents tslblLinhaSelecionada As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tstxtLinhaSelecionada As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslblColunaSelecionada As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tstxtColunaSelecionada As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslblTotalLinhas As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tstxtTotalLinhas As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tslblTotalColunas As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tstxtTotalColunas As System.Windows.Forms.ToolStripStatusLabel
    End Class
End Namespace