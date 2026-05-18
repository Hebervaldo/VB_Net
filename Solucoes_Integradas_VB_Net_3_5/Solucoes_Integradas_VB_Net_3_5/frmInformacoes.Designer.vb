Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmInformacoes
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInformacoes))
            Me.lsv1 = New System.Windows.Forms.ListView
            Me.txt1 = New System.Windows.Forms.TextBox
            Me.SuspendLayout()
            '
            'lsv1
            '
            Me.lsv1.BackColor = System.Drawing.Color.White
            Me.lsv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lsv1.Location = New System.Drawing.Point(12, 41)
            Me.lsv1.Name = "lsv1"
            Me.lsv1.Size = New System.Drawing.Size(628, 204)
            Me.lsv1.TabIndex = 2
            Me.lsv1.UseCompatibleStateImageBehavior = False
            '
            'txt1
            '
            Me.txt1.BackColor = System.Drawing.Color.White
            Me.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txt1.Enabled = False
            Me.txt1.Location = New System.Drawing.Point(12, 12)
            Me.txt1.Multiline = True
            Me.txt1.Name = "txt1"
            Me.txt1.Size = New System.Drawing.Size(628, 23)
            Me.txt1.TabIndex = 1
            Me.txt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'frmInformacoes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(652, 256)
            Me.Controls.Add(Me.txt1)
            Me.Controls.Add(Me.lsv1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.Name = "frmInformacoes"
            Me.Text = "Informações"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lsv1 As System.Windows.Forms.ListView
        Friend WithEvents txt1 As System.Windows.Forms.TextBox
    End Class
End Namespace