Namespace Solucoes_Rede_Neural_VBNet
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmSubVisualizador
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
            Me.btnCriar = New System.Windows.Forms.Button
            Me.lstv1 = New System.Windows.Forms.ListView
            Me.txt1 = New System.Windows.Forms.TextBox
            Me.btnRemover = New System.Windows.Forms.Button
            Me.btnSair = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'btnCriar
            '
            Me.btnCriar.Location = New System.Drawing.Point(552, 38)
            Me.btnCriar.Name = "btnCriar"
            Me.btnCriar.Size = New System.Drawing.Size(197, 22)
            Me.btnCriar.TabIndex = 3
            Me.btnCriar.Text = "&Criar"
            Me.btnCriar.UseVisualStyleBackColor = True
            '
            'lstv1
            '
            Me.lstv1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
            Me.lstv1.Location = New System.Drawing.Point(12, 12)
            Me.lstv1.Name = "lstv1"
            Me.lstv1.Size = New System.Drawing.Size(534, 243)
            Me.lstv1.TabIndex = 4
            Me.lstv1.UseCompatibleStateImageBehavior = False
            '
            'txt1
            '
            Me.txt1.Location = New System.Drawing.Point(552, 12)
            Me.txt1.Name = "txt1"
            Me.txt1.Size = New System.Drawing.Size(197, 20)
            Me.txt1.TabIndex = 5
            '
            'btnRemover
            '
            Me.btnRemover.Location = New System.Drawing.Point(552, 66)
            Me.btnRemover.Name = "btnRemover"
            Me.btnRemover.Size = New System.Drawing.Size(197, 22)
            Me.btnRemover.TabIndex = 6
            Me.btnRemover.Text = "&Remover"
            Me.btnRemover.UseVisualStyleBackColor = True
            '
            'btnSair
            '
            Me.btnSair.Location = New System.Drawing.Point(552, 94)
            Me.btnSair.Name = "btnSair"
            Me.btnSair.Size = New System.Drawing.Size(197, 21)
            Me.btnSair.TabIndex = 7
            Me.btnSair.Text = "&Sair"
            Me.btnSair.UseVisualStyleBackColor = True
            '
            'frmSubVisualizador
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.Window
            Me.ClientSize = New System.Drawing.Size(761, 269)
            Me.Controls.Add(Me.btnSair)
            Me.Controls.Add(Me.btnRemover)
            Me.Controls.Add(Me.txt1)
            Me.Controls.Add(Me.lstv1)
            Me.Controls.Add(Me.btnCriar)
            Me.Name = "frmSubVisualizador"
            Me.Text = "Fornecer as Colunas"
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

        Friend WithEvents btnCriar As System.Windows.Forms.Button
        Friend WithEvents lstv1 As System.Windows.Forms.ListView
        Friend WithEvents txt1 As System.Windows.Forms.TextBox
        Friend WithEvents btnRemover As System.Windows.Forms.Button
        Friend WithEvents btnSair As System.Windows.Forms.Button
    End Class
End Namespace