Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmVisualizarImpressao
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisualizarImpressao))
            Me.ptdc1 = New System.Drawing.Printing.PrintDocument
            Me.ppdg1 = New System.Windows.Forms.PrintPreviewDialog
            Me.ptdg1 = New System.Windows.Forms.PrintDialog
            Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
            Me.SuspendLayout()
            '
            'ppdg1
            '
            Me.ppdg1.AutoScrollMargin = New System.Drawing.Size(0, 0)
            Me.ppdg1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
            Me.ppdg1.ClientSize = New System.Drawing.Size(400, 300)
            Me.ppdg1.Enabled = True
            Me.ppdg1.Icon = CType(resources.GetObject("ppdg1.Icon"), System.Drawing.Icon)
            Me.ppdg1.Name = "ppdg1"
            Me.ppdg1.Visible = False
            '
            'ptdg1
            '
            Me.ptdg1.UseEXDialog = True
            '
            'crv1
            '
            Me.crv1.ActiveViewIndex = -1
            Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.crv1.DisplayGroupTree = False
            Me.crv1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.crv1.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.crv1.Location = New System.Drawing.Point(0, 0)
            Me.crv1.Name = "crv1"
            Me.crv1.SelectionFormula = ""
            Me.crv1.Size = New System.Drawing.Size(1022, 612)
            Me.crv1.TabIndex = 0
            Me.crv1.ViewTimeSelectionFormula = ""
            '
            'frmVisualizarImpressao
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoSize = True
            Me.ClientSize = New System.Drawing.Size(1022, 612)
            Me.Controls.Add(Me.crv1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "frmVisualizarImpressao"
            Me.Text = "Visualizar Impressão"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
        Friend WithEvents ptdc1 As System.Drawing.Printing.PrintDocument
        Friend WithEvents ppdg1 As System.Windows.Forms.PrintPreviewDialog
        Friend WithEvents ptdg1 As System.Windows.Forms.PrintDialog
    End Class
End Namespace