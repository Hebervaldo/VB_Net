Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmLogon
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
        Friend WithEvents lblNomeUsuario As System.Windows.Forms.Label
        Friend WithEvents lblSenhaUsuario As System.Windows.Forms.Label
        Friend WithEvents txtNomeUsuario As System.Windows.Forms.TextBox
        Friend WithEvents txtSenhaUsuario As System.Windows.Forms.TextBox
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnSair As System.Windows.Forms.Button

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogon))
            Me.lblNomeUsuario = New System.Windows.Forms.Label
            Me.lblSenhaUsuario = New System.Windows.Forms.Label
            Me.txtNomeUsuario = New System.Windows.Forms.TextBox
            Me.txtSenhaUsuario = New System.Windows.Forms.TextBox
            Me.btnOK = New System.Windows.Forms.Button
            Me.btnSair = New System.Windows.Forms.Button
            Me.PictureBox1 = New System.Windows.Forms.PictureBox
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblNomeUsuario
            '
            Me.lblNomeUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNomeUsuario.Location = New System.Drawing.Point(190, 12)
            Me.lblNomeUsuario.Name = "lblNomeUsuario"
            Me.lblNomeUsuario.Size = New System.Drawing.Size(220, 23)
            Me.lblNomeUsuario.TabIndex = 0
            Me.lblNomeUsuario.Text = "Nome do Usuário:"
            Me.lblNomeUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSenhaUsuario
            '
            Me.lblSenhaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblSenhaUsuario.Location = New System.Drawing.Point(190, 69)
            Me.lblSenhaUsuario.Name = "lblSenhaUsuario"
            Me.lblSenhaUsuario.Size = New System.Drawing.Size(220, 23)
            Me.lblSenhaUsuario.TabIndex = 2
            Me.lblSenhaUsuario.Text = "Senha:"
            Me.lblSenhaUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtNomeUsuario
            '
            Me.txtNomeUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNomeUsuario.Location = New System.Drawing.Point(192, 32)
            Me.txtNomeUsuario.Name = "txtNomeUsuario"
            Me.txtNomeUsuario.Size = New System.Drawing.Size(220, 20)
            Me.txtNomeUsuario.TabIndex = 0
            '
            'txtSenhaUsuario
            '
            Me.txtSenhaUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSenhaUsuario.Location = New System.Drawing.Point(192, 89)
            Me.txtSenhaUsuario.Name = "txtSenhaUsuario"
            Me.txtSenhaUsuario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtSenhaUsuario.Size = New System.Drawing.Size(220, 20)
            Me.txtSenhaUsuario.TabIndex = 1
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOK.Location = New System.Drawing.Point(215, 149)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(94, 23)
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "&OK"
            Me.btnOK.UseVisualStyleBackColor = False
            '
            'btnSair
            '
            Me.btnSair.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSair.Location = New System.Drawing.Point(318, 149)
            Me.btnSair.Name = "btnSair"
            Me.btnSair.Size = New System.Drawing.Size(94, 23)
            Me.btnSair.TabIndex = 3
            Me.btnSair.Text = "&Sair"
            Me.btnSair.UseVisualStyleBackColor = False
            '
            'PictureBox1
            '
            Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
            Me.PictureBox1.InitialImage = Nothing
            Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(172, 172)
            Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.PictureBox1.TabIndex = 7
            Me.PictureBox1.TabStop = False
            '
            'frmLogon
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoSize = True
            Me.BackColor = System.Drawing.SystemColors.InactiveCaption
            Me.CancelButton = Me.btnSair
            Me.ClientSize = New System.Drawing.Size(424, 192)
            Me.ControlBox = False
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.btnSair)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.txtSenhaUsuario)
            Me.Controls.Add(Me.txtNomeUsuario)
            Me.Controls.Add(Me.lblSenhaUsuario)
            Me.Controls.Add(Me.lblNomeUsuario)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmLogon"
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Logon"
            Me.TopMost = True
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

    End Class
End Namespace