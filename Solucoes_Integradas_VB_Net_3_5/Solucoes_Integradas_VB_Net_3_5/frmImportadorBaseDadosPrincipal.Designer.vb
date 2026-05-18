Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmImportadorBaseDadosPrincipal
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportadorBaseDadosPrincipal))
            Me.lsv1 = New System.Windows.Forms.ListView
            Me.grpb1 = New System.Windows.Forms.GroupBox
            Me.txt2 = New System.Windows.Forms.TextBox
            Me.txt1 = New System.Windows.Forms.TextBox
            Me.lbl2 = New System.Windows.Forms.Label
            Me.lbl1 = New System.Windows.Forms.Label
            Me.grpb1.SuspendLayout()
            Me.SuspendLayout()
            '
            'lsv1
            '
            Me.lsv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lsv1.Location = New System.Drawing.Point(12, 97)
            Me.lsv1.Name = "lsv1"
            Me.lsv1.Size = New System.Drawing.Size(728, 276)
            Me.lsv1.TabIndex = 5
            Me.lsv1.UseCompatibleStateImageBehavior = False
            '
            'grpb1
            '
            Me.grpb1.Controls.Add(Me.txt2)
            Me.grpb1.Controls.Add(Me.txt1)
            Me.grpb1.Controls.Add(Me.lbl2)
            Me.grpb1.Controls.Add(Me.lbl1)
            Me.grpb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.grpb1.Location = New System.Drawing.Point(12, 12)
            Me.grpb1.Name = "grpb1"
            Me.grpb1.Size = New System.Drawing.Size(728, 79)
            Me.grpb1.TabIndex = 0
            Me.grpb1.TabStop = False
            Me.grpb1.Text = "Painel"
            '
            'txt2
            '
            Me.txt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txt2.Enabled = False
            Me.txt2.Location = New System.Drawing.Point(186, 46)
            Me.txt2.Name = "txt2"
            Me.txt2.Size = New System.Drawing.Size(536, 20)
            Me.txt2.TabIndex = 4
            '
            'txt1
            '
            Me.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txt1.Enabled = False
            Me.txt1.Location = New System.Drawing.Point(186, 20)
            Me.txt1.Name = "txt1"
            Me.txt1.Size = New System.Drawing.Size(536, 20)
            Me.txt1.TabIndex = 2
            '
            'lbl2
            '
            Me.lbl2.AutoSize = True
            Me.lbl2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl2.Location = New System.Drawing.Point(6, 49)
            Me.lbl2.Name = "lbl2"
            Me.lbl2.Size = New System.Drawing.Size(168, 13)
            Me.lbl2.TabIndex = 3
            Me.lbl2.Text = "Localização do Banco de Dados: "
            '
            'lbl1
            '
            Me.lbl1.AutoSize = True
            Me.lbl1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl1.Location = New System.Drawing.Point(6, 23)
            Me.lbl1.Name = "lbl1"
            Me.lbl1.Size = New System.Drawing.Size(174, 13)
            Me.lbl1.TabIndex = 1
            Me.lbl1.Text = "Localização do Arquivo Importado: "
            '
            'frmImportadorBaseDadosPrincipal
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(752, 385)
            Me.Controls.Add(Me.grpb1)
            Me.Controls.Add(Me.lsv1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "frmImportadorBaseDadosPrincipal"
            Me.Text = "Importação Bens - Principal"
            Me.grpb1.ResumeLayout(False)
            Me.grpb1.PerformLayout()
            Me.ResumeLayout(False)

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

        Friend WithEvents lsv1 As System.Windows.Forms.ListView
        Friend WithEvents grpb1 As System.Windows.Forms.GroupBox
        Friend WithEvents txt2 As System.Windows.Forms.TextBox
        Friend WithEvents txt1 As System.Windows.Forms.TextBox
        Friend WithEvents lbl2 As System.Windows.Forms.Label
        Friend WithEvents lbl1 As System.Windows.Forms.Label
    End Class
End Namespace