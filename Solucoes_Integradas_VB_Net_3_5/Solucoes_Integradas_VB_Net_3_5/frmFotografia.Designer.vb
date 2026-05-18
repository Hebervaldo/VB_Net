Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmFotografia
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFotografia))
            Me.svfFotografia = New System.Windows.Forms.SaveFileDialog
            Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
            Me.pct1 = New System.Windows.Forms.PictureBox
            Me.tsbFotografia = New System.Windows.Forms.ToolStrip
            Me.tsbIncluir = New System.Windows.Forms.ToolStripButton
            Me.tsbSalvar = New System.Windows.Forms.ToolStripButton
            Me.ToolStripContainer1.ContentPanel.SuspendLayout()
            Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
            Me.ToolStripContainer1.SuspendLayout()
            CType(Me.pct1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tsbFotografia.SuspendLayout()
            Me.SuspendLayout()
            '
            'ToolStripContainer1
            '
            '
            'ToolStripContainer1.ContentPanel
            '
            Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.pct1)
            Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(824, 613)
            Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
            Me.ToolStripContainer1.Name = "ToolStripContainer1"
            Me.ToolStripContainer1.Size = New System.Drawing.Size(824, 638)
            Me.ToolStripContainer1.TabIndex = 2
            Me.ToolStripContainer1.Text = "ToolStripContainer1"
            '
            'ToolStripContainer1.TopToolStripPanel
            '
            Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.tsbFotografia)
            '
            'pct1
            '
            Me.pct1.Location = New System.Drawing.Point(12, 3)
            Me.pct1.Name = "pct1"
            Me.pct1.Size = New System.Drawing.Size(800, 598)
            Me.pct1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.pct1.TabIndex = 0
            Me.pct1.TabStop = False
            '
            'tsbFotografia
            '
            Me.tsbFotografia.Dock = System.Windows.Forms.DockStyle.None
            Me.tsbFotografia.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbIncluir, Me.tsbSalvar})
            Me.tsbFotografia.Location = New System.Drawing.Point(3, 0)
            Me.tsbFotografia.Name = "tsbFotografia"
            Me.tsbFotografia.Size = New System.Drawing.Size(56, 25)
            Me.tsbFotografia.TabIndex = 43
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
            'tsbSalvar
            '
            Me.tsbSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.tsbSalvar.Image = CType(resources.GetObject("tsbSalvar.Image"), System.Drawing.Image)
            Me.tsbSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbSalvar.Name = "tsbSalvar"
            Me.tsbSalvar.Size = New System.Drawing.Size(23, 22)
            Me.tsbSalvar.Text = "Salvar"
            '
            'frmFotografia
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(824, 638)
            Me.Controls.Add(Me.ToolStripContainer1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmFotografia"
            Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
            Me.ToolStripContainer1.ContentPanel.PerformLayout()
            Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
            Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
            Me.ToolStripContainer1.ResumeLayout(False)
            Me.ToolStripContainer1.PerformLayout()
            CType(Me.pct1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tsbFotografia.ResumeLayout(False)
            Me.tsbFotografia.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents svfFotografia As System.Windows.Forms.SaveFileDialog
        Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
        Friend WithEvents tsbFotografia As System.Windows.Forms.ToolStrip
        Friend WithEvents tsbIncluir As System.Windows.Forms.ToolStripButton
        Friend WithEvents tsbSalvar As System.Windows.Forms.ToolStripButton
        Friend WithEvents pct1 As System.Windows.Forms.PictureBox
    End Class
End Namespace