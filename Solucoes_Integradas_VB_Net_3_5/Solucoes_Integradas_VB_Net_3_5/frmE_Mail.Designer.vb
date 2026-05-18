Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmE_Mail
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmE_Mail))
            Me.lstAnexo = New System.Windows.Forms.ListBox
            Me.lstCC = New System.Windows.Forms.ListBox
            Me.btnRemoverCCO = New System.Windows.Forms.Button
            Me.btnRemoverCC = New System.Windows.Forms.Button
            Me.btnRemoverPara = New System.Windows.Forms.Button
            Me.btnAdicionarCCO = New System.Windows.Forms.Button
            Me.btnAdicionarCC = New System.Windows.Forms.Button
            Me.btnAdicionarPara = New System.Windows.Forms.Button
            Me.lstPara = New System.Windows.Forms.ListBox
            Me.btnEnviar = New System.Windows.Forms.Button
            Me.chkFormatoHTML = New System.Windows.Forms.CheckBox
            Me.lbl9 = New System.Windows.Forms.Label
            Me.txtAssunto = New System.Windows.Forms.TextBox
            Me.lbl8 = New System.Windows.Forms.Label
            Me.lbl7 = New System.Windows.Forms.Label
            Me.btnRemoverAnexo = New System.Windows.Forms.Button
            Me.btnAdicionarAnexo = New System.Windows.Forms.Button
            Me.lstBCC = New System.Windows.Forms.ListBox
            Me.lbl4 = New System.Windows.Forms.Label
            Me.txtMostrar = New System.Windows.Forms.TextBox
            Me.txtDe = New System.Windows.Forms.TextBox
            Me.lbl3 = New System.Windows.Forms.Label
            Me.lbl6 = New System.Windows.Forms.Label
            Me.txtServidorSMTP = New System.Windows.Forms.TextBox
            Me.lbl5 = New System.Windows.Forms.Label
            Me.lbl1 = New System.Windows.Forms.Label
            Me.OFD = New System.Windows.Forms.OpenFileDialog
            Me.lbl2 = New System.Windows.Forms.Label
            Me.cmbPara = New System.Windows.Forms.ComboBox
            Me.cmbCC = New System.Windows.Forms.ComboBox
            Me.cmbCCO = New System.Windows.Forms.ComboBox
            Me.rtbMensagem = New System.Windows.Forms.RichTextBox
            Me.SuspendLayout()
            '
            'lstAnexo
            '
            Me.lstAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lstAnexo.Location = New System.Drawing.Point(100, 471)
            Me.lstAnexo.Name = "lstAnexo"
            Me.lstAnexo.Size = New System.Drawing.Size(432, 106)
            Me.lstAnexo.TabIndex = 22
            '
            'lstCC
            '
            Me.lstCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lstCC.Location = New System.Drawing.Point(100, 243)
            Me.lstCC.Name = "lstCC"
            Me.lstCC.Size = New System.Drawing.Size(434, 93)
            Me.lstCC.TabIndex = 15
            '
            'btnRemoverCCO
            '
            Me.btnRemoverCCO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRemoverCCO.Location = New System.Drawing.Point(463, 344)
            Me.btnRemoverCCO.Name = "btnRemoverCCO"
            Me.btnRemoverCCO.Size = New System.Drawing.Size(69, 23)
            Me.btnRemoverCCO.TabIndex = 19
            Me.btnRemoverCCO.Text = "&Remover"
            '
            'btnRemoverCC
            '
            Me.btnRemoverCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRemoverCC.Location = New System.Drawing.Point(463, 218)
            Me.btnRemoverCC.Name = "btnRemoverCC"
            Me.btnRemoverCC.Size = New System.Drawing.Size(71, 23)
            Me.btnRemoverCC.TabIndex = 14
            Me.btnRemoverCC.Text = "&Remover"
            '
            'btnRemoverPara
            '
            Me.btnRemoverPara.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRemoverPara.Location = New System.Drawing.Point(463, 90)
            Me.btnRemoverPara.Name = "btnRemoverPara"
            Me.btnRemoverPara.Size = New System.Drawing.Size(71, 23)
            Me.btnRemoverPara.TabIndex = 9
            Me.btnRemoverPara.Text = "&Remover"
            '
            'btnAdicionarCCO
            '
            Me.btnAdicionarCCO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAdicionarCCO.Location = New System.Drawing.Point(386, 344)
            Me.btnAdicionarCCO.Name = "btnAdicionarCCO"
            Me.btnAdicionarCCO.Size = New System.Drawing.Size(71, 23)
            Me.btnAdicionarCCO.TabIndex = 18
            Me.btnAdicionarCCO.Text = "&Adicionar"
            '
            'btnAdicionarCC
            '
            Me.btnAdicionarCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAdicionarCC.Location = New System.Drawing.Point(386, 218)
            Me.btnAdicionarCC.Name = "btnAdicionarCC"
            Me.btnAdicionarCC.Size = New System.Drawing.Size(71, 23)
            Me.btnAdicionarCC.TabIndex = 13
            Me.btnAdicionarCC.Text = "&Adicionar"
            '
            'btnAdicionarPara
            '
            Me.btnAdicionarPara.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAdicionarPara.Location = New System.Drawing.Point(386, 90)
            Me.btnAdicionarPara.Name = "btnAdicionarPara"
            Me.btnAdicionarPara.Size = New System.Drawing.Size(71, 23)
            Me.btnAdicionarPara.TabIndex = 8
            Me.btnAdicionarPara.Text = "&Adicionar"
            '
            'lstPara
            '
            Me.lstPara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lstPara.Location = New System.Drawing.Point(100, 117)
            Me.lstPara.Name = "lstPara"
            Me.lstPara.Size = New System.Drawing.Size(434, 93)
            Me.lstPara.TabIndex = 10
            '
            'btnEnviar
            '
            Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEnviar.Location = New System.Drawing.Point(899, 583)
            Me.btnEnviar.Name = "btnEnviar"
            Me.btnEnviar.Size = New System.Drawing.Size(82, 23)
            Me.btnEnviar.TabIndex = 30
            Me.btnEnviar.Text = "&Enviar"
            Me.btnEnviar.UseVisualStyleBackColor = True
            '
            'chkFormatoHTML
            '
            Me.chkFormatoHTML.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkFormatoHTML.Location = New System.Drawing.Point(740, 583)
            Me.chkFormatoHTML.Name = "chkFormatoHTML"
            Me.chkFormatoHTML.Size = New System.Drawing.Size(153, 20)
            Me.chkFormatoHTML.TabIndex = 29
            Me.chkFormatoHTML.Text = "Enviar em Formato HTML"
            '
            'lbl9
            '
            Me.lbl9.AutoSize = True
            Me.lbl9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl9.Location = New System.Drawing.Point(545, 15)
            Me.lbl9.Name = "lbl9"
            Me.lbl9.Size = New System.Drawing.Size(48, 13)
            Me.lbl9.TabIndex = 25
            Me.lbl9.Text = "Assunto:"
            '
            'txtAssunto
            '
            Me.txtAssunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAssunto.Location = New System.Drawing.Point(545, 38)
            Me.txtAssunto.Name = "txtAssunto"
            Me.txtAssunto.Size = New System.Drawing.Size(436, 20)
            Me.txtAssunto.TabIndex = 26
            '
            'lbl8
            '
            Me.lbl8.AutoSize = True
            Me.lbl8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl8.Location = New System.Drawing.Point(545, 67)
            Me.lbl8.Name = "lbl8"
            Me.lbl8.Size = New System.Drawing.Size(62, 13)
            Me.lbl8.TabIndex = 27
            Me.lbl8.Text = "Mensagem:"
            '
            'lbl7
            '
            Me.lbl7.AutoSize = True
            Me.lbl7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl7.Location = New System.Drawing.Point(12, 489)
            Me.lbl7.Name = "lbl7"
            Me.lbl7.Size = New System.Drawing.Size(40, 13)
            Me.lbl7.TabIndex = 21
            Me.lbl7.Text = "Anexo:"
            '
            'btnRemoverAnexo
            '
            Me.btnRemoverAnexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRemoverAnexo.Location = New System.Drawing.Point(461, 582)
            Me.btnRemoverAnexo.Name = "btnRemoverAnexo"
            Me.btnRemoverAnexo.Size = New System.Drawing.Size(71, 23)
            Me.btnRemoverAnexo.TabIndex = 24
            Me.btnRemoverAnexo.Text = "&Remover"
            '
            'btnAdicionarAnexo
            '
            Me.btnAdicionarAnexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAdicionarAnexo.Location = New System.Drawing.Point(384, 582)
            Me.btnAdicionarAnexo.Name = "btnAdicionarAnexo"
            Me.btnAdicionarAnexo.Size = New System.Drawing.Size(71, 23)
            Me.btnAdicionarAnexo.TabIndex = 23
            Me.btnAdicionarAnexo.Text = "&Adicionar"
            '
            'lstBCC
            '
            Me.lstBCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lstBCC.Location = New System.Drawing.Point(100, 370)
            Me.lstBCC.Name = "lstBCC"
            Me.lstBCC.Size = New System.Drawing.Size(432, 93)
            Me.lstBCC.TabIndex = 20
            '
            'lbl4
            '
            Me.lbl4.AutoSize = True
            Me.lbl4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl4.Location = New System.Drawing.Point(12, 97)
            Me.lbl4.Name = "lbl4"
            Me.lbl4.Size = New System.Drawing.Size(32, 13)
            Me.lbl4.TabIndex = 6
            Me.lbl4.Text = "Para:"
            '
            'txtMostrar
            '
            Me.txtMostrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMostrar.Location = New System.Drawing.Point(100, 38)
            Me.txtMostrar.Name = "txtMostrar"
            Me.txtMostrar.Size = New System.Drawing.Size(434, 20)
            Me.txtMostrar.TabIndex = 3
            '
            'txtDe
            '
            Me.txtDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDe.Location = New System.Drawing.Point(100, 64)
            Me.txtDe.Name = "txtDe"
            Me.txtDe.Size = New System.Drawing.Size(434, 20)
            Me.txtDe.TabIndex = 5
            '
            'lbl3
            '
            Me.lbl3.AutoSize = True
            Me.lbl3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl3.Location = New System.Drawing.Point(12, 71)
            Me.lbl3.Name = "lbl3"
            Me.lbl3.Size = New System.Drawing.Size(24, 13)
            Me.lbl3.TabIndex = 4
            Me.lbl3.Text = "De:"
            '
            'lbl6
            '
            Me.lbl6.AutoSize = True
            Me.lbl6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl6.Location = New System.Drawing.Point(12, 351)
            Me.lbl6.Name = "lbl6"
            Me.lbl6.Size = New System.Drawing.Size(32, 13)
            Me.lbl6.TabIndex = 16
            Me.lbl6.Text = "CCO:"
            '
            'txtServidorSMTP
            '
            Me.txtServidorSMTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtServidorSMTP.Enabled = False
            Me.txtServidorSMTP.Location = New System.Drawing.Point(100, 12)
            Me.txtServidorSMTP.Name = "txtServidorSMTP"
            Me.txtServidorSMTP.Size = New System.Drawing.Size(434, 20)
            Me.txtServidorSMTP.TabIndex = 1
            '
            'lbl5
            '
            Me.lbl5.AutoSize = True
            Me.lbl5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl5.Location = New System.Drawing.Point(12, 224)
            Me.lbl5.Name = "lbl5"
            Me.lbl5.Size = New System.Drawing.Size(24, 13)
            Me.lbl5.TabIndex = 11
            Me.lbl5.Text = "CC:"
            '
            'lbl1
            '
            Me.lbl1.AutoSize = True
            Me.lbl1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl1.Location = New System.Drawing.Point(12, 19)
            Me.lbl1.Name = "lbl1"
            Me.lbl1.Size = New System.Drawing.Size(82, 13)
            Me.lbl1.TabIndex = 0
            Me.lbl1.Text = "Servidor SMTP:"
            '
            'OFD
            '
            Me.OFD.DefaultExt = "*.*"
            Me.OFD.InitialDirectory = "c:\"
            Me.OFD.Multiselect = True
            '
            'lbl2
            '
            Me.lbl2.AutoSize = True
            Me.lbl2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lbl2.Location = New System.Drawing.Point(12, 45)
            Me.lbl2.Name = "lbl2"
            Me.lbl2.Size = New System.Drawing.Size(45, 13)
            Me.lbl2.TabIndex = 2
            Me.lbl2.Text = "Mostrar:"
            '
            'cmbPara
            '
            Me.cmbPara.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cmbPara.FormattingEnabled = True
            Me.cmbPara.Location = New System.Drawing.Point(100, 90)
            Me.cmbPara.Name = "cmbPara"
            Me.cmbPara.Size = New System.Drawing.Size(280, 21)
            Me.cmbPara.TabIndex = 7
            '
            'cmbCC
            '
            Me.cmbCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cmbCC.FormattingEnabled = True
            Me.cmbCC.Location = New System.Drawing.Point(100, 218)
            Me.cmbCC.Name = "cmbCC"
            Me.cmbCC.Size = New System.Drawing.Size(280, 21)
            Me.cmbCC.TabIndex = 12
            '
            'cmbCCO
            '
            Me.cmbCCO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cmbCCO.FormattingEnabled = True
            Me.cmbCCO.Location = New System.Drawing.Point(100, 344)
            Me.cmbCCO.Name = "cmbCCO"
            Me.cmbCCO.Size = New System.Drawing.Size(280, 21)
            Me.cmbCCO.TabIndex = 17
            '
            'rtbMensagem
            '
            Me.rtbMensagem.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.rtbMensagem.Location = New System.Drawing.Point(545, 83)
            Me.rtbMensagem.Name = "rtbMensagem"
            Me.rtbMensagem.Size = New System.Drawing.Size(436, 494)
            Me.rtbMensagem.TabIndex = 31
            Me.rtbMensagem.Text = ""
            '
            'frmE_Mail
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(993, 608)
            Me.Controls.Add(Me.rtbMensagem)
            Me.Controls.Add(Me.cmbCCO)
            Me.Controls.Add(Me.cmbCC)
            Me.Controls.Add(Me.cmbPara)
            Me.Controls.Add(Me.lstAnexo)
            Me.Controls.Add(Me.lstCC)
            Me.Controls.Add(Me.btnRemoverCCO)
            Me.Controls.Add(Me.btnRemoverCC)
            Me.Controls.Add(Me.btnRemoverPara)
            Me.Controls.Add(Me.btnAdicionarCCO)
            Me.Controls.Add(Me.btnAdicionarCC)
            Me.Controls.Add(Me.btnAdicionarPara)
            Me.Controls.Add(Me.lstPara)
            Me.Controls.Add(Me.btnEnviar)
            Me.Controls.Add(Me.chkFormatoHTML)
            Me.Controls.Add(Me.lbl9)
            Me.Controls.Add(Me.txtAssunto)
            Me.Controls.Add(Me.lbl8)
            Me.Controls.Add(Me.lbl7)
            Me.Controls.Add(Me.btnRemoverAnexo)
            Me.Controls.Add(Me.btnAdicionarAnexo)
            Me.Controls.Add(Me.lstBCC)
            Me.Controls.Add(Me.lbl4)
            Me.Controls.Add(Me.txtMostrar)
            Me.Controls.Add(Me.txtDe)
            Me.Controls.Add(Me.lbl3)
            Me.Controls.Add(Me.lbl6)
            Me.Controls.Add(Me.txtServidorSMTP)
            Me.Controls.Add(Me.lbl5)
            Me.Controls.Add(Me.lbl1)
            Me.Controls.Add(Me.lbl2)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.Name = "frmE_Mail"
            Me.Text = "Envio de Emails"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lstAnexo As System.Windows.Forms.ListBox
        Friend WithEvents lstCC As System.Windows.Forms.ListBox
        Friend WithEvents btnRemoverCCO As System.Windows.Forms.Button
        Friend WithEvents btnRemoverCC As System.Windows.Forms.Button
        Friend WithEvents btnRemoverPara As System.Windows.Forms.Button
        Friend WithEvents btnAdicionarCCO As System.Windows.Forms.Button
        Friend WithEvents btnAdicionarCC As System.Windows.Forms.Button
        Friend WithEvents btnAdicionarPara As System.Windows.Forms.Button
        Friend WithEvents lstPara As System.Windows.Forms.ListBox
        Private WithEvents btnEnviar As System.Windows.Forms.Button
        Friend WithEvents chkFormatoHTML As System.Windows.Forms.CheckBox
        Friend WithEvents lbl9 As System.Windows.Forms.Label
        Friend WithEvents txtAssunto As System.Windows.Forms.TextBox
        Friend WithEvents lbl8 As System.Windows.Forms.Label
        Friend WithEvents lbl7 As System.Windows.Forms.Label
        Friend WithEvents btnRemoverAnexo As System.Windows.Forms.Button
        Friend WithEvents btnAdicionarAnexo As System.Windows.Forms.Button
        Friend WithEvents lstBCC As System.Windows.Forms.ListBox
        Friend WithEvents lbl4 As System.Windows.Forms.Label
        Friend WithEvents txtMostrar As System.Windows.Forms.TextBox
        Friend WithEvents txtDe As System.Windows.Forms.TextBox
        Friend WithEvents lbl3 As System.Windows.Forms.Label
        Friend WithEvents lbl6 As System.Windows.Forms.Label
        Friend WithEvents txtServidorSMTP As System.Windows.Forms.TextBox
        Friend WithEvents lbl5 As System.Windows.Forms.Label
        Friend WithEvents lbl1 As System.Windows.Forms.Label
        Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
        Friend WithEvents lbl2 As System.Windows.Forms.Label
        Friend WithEvents cmbPara As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCC As System.Windows.Forms.ComboBox
        Friend WithEvents cmbCCO As System.Windows.Forms.ComboBox
        Friend WithEvents rtbMensagem As System.Windows.Forms.RichTextBox
    End Class
End Namespace