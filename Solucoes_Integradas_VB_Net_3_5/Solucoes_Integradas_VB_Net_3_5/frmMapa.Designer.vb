Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmMapa
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMapa))
            Me.wbMapa = New System.Windows.Forms.WebBrowser
            Me.tcbMapa = New System.Windows.Forms.TrackBar
            Me.lblTipoMapa = New System.Windows.Forms.Label
            Me.cmbMapa = New System.Windows.Forms.ComboBox
            Me.lblZoom = New System.Windows.Forms.Label
            Me.grpb1 = New System.Windows.Forms.GroupBox
            Me.btnVisualizar = New System.Windows.Forms.Button
            CType(Me.tcbMapa, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpb1.SuspendLayout()
            Me.SuspendLayout()
            '
            'wbMapa
            '
            Me.wbMapa.Location = New System.Drawing.Point(12, 12)
            Me.wbMapa.MinimumSize = New System.Drawing.Size(20, 20)
            Me.wbMapa.Name = "wbMapa"
            Me.wbMapa.Size = New System.Drawing.Size(749, 597)
            Me.wbMapa.TabIndex = 0
            '
            'tcbMapa
            '
            Me.tcbMapa.Location = New System.Drawing.Point(9, 39)
            Me.tcbMapa.Maximum = 21
            Me.tcbMapa.Name = "tcbMapa"
            Me.tcbMapa.Size = New System.Drawing.Size(208, 42)
            Me.tcbMapa.TabIndex = 3
            Me.tcbMapa.TickStyle = System.Windows.Forms.TickStyle.Both
            '
            'lblTipoMapa
            '
            Me.lblTipoMapa.BackColor = System.Drawing.SystemColors.Control
            Me.lblTipoMapa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.lblTipoMapa.ForeColor = System.Drawing.Color.Black
            Me.lblTipoMapa.Location = New System.Drawing.Point(6, 84)
            Me.lblTipoMapa.Name = "lblTipoMapa"
            Me.lblTipoMapa.Size = New System.Drawing.Size(208, 20)
            Me.lblTipoMapa.TabIndex = 91
            Me.lblTipoMapa.Text = "Tipo do Mapa"
            Me.lblTipoMapa.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'cmbMapa
            '
            Me.cmbMapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbMapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cmbMapa.Location = New System.Drawing.Point(9, 107)
            Me.cmbMapa.Name = "cmbMapa"
            Me.cmbMapa.Size = New System.Drawing.Size(208, 21)
            Me.cmbMapa.TabIndex = 4
            '
            'lblZoom
            '
            Me.lblZoom.BackColor = System.Drawing.SystemColors.Control
            Me.lblZoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.lblZoom.ForeColor = System.Drawing.Color.Black
            Me.lblZoom.Location = New System.Drawing.Point(6, 16)
            Me.lblZoom.Name = "lblZoom"
            Me.lblZoom.Size = New System.Drawing.Size(211, 20)
            Me.lblZoom.TabIndex = 2
            Me.lblZoom.Text = "Zoom"
            Me.lblZoom.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'grpb1
            '
            Me.grpb1.Controls.Add(Me.btnVisualizar)
            Me.grpb1.Controls.Add(Me.lblZoom)
            Me.grpb1.Controls.Add(Me.lblTipoMapa)
            Me.grpb1.Controls.Add(Me.tcbMapa)
            Me.grpb1.Controls.Add(Me.cmbMapa)
            Me.grpb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.grpb1.Location = New System.Drawing.Point(767, 12)
            Me.grpb1.Name = "grpb1"
            Me.grpb1.Size = New System.Drawing.Size(223, 597)
            Me.grpb1.TabIndex = 1
            Me.grpb1.TabStop = False
            Me.grpb1.Text = "Controles"
            '
            'btnVisualizar
            '
            Me.btnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnVisualizar.Location = New System.Drawing.Point(9, 134)
            Me.btnVisualizar.Name = "btnVisualizar"
            Me.btnVisualizar.Size = New System.Drawing.Size(205, 23)
            Me.btnVisualizar.TabIndex = 5
            Me.btnVisualizar.Text = "&Visualizar"
            Me.btnVisualizar.UseVisualStyleBackColor = True
            '
            'frmMapa
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1002, 621)
            Me.Controls.Add(Me.grpb1)
            Me.Controls.Add(Me.wbMapa)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "frmMapa"
            CType(Me.tcbMapa, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpb1.ResumeLayout(False)
            Me.grpb1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents wbMapa As System.Windows.Forms.WebBrowser
        Friend WithEvents tcbMapa As System.Windows.Forms.TrackBar
        Private WithEvents lblTipoMapa As System.Windows.Forms.Label
        Private WithEvents cmbMapa As System.Windows.Forms.ComboBox
        Private WithEvents lblZoom As System.Windows.Forms.Label
        Friend WithEvents grpb1 As System.Windows.Forms.GroupBox
        Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    End Class
End Namespace