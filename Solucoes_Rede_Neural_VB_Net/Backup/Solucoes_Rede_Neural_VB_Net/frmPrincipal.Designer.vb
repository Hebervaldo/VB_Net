<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
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
        Me.components = New System.ComponentModel.Container
        Me.barstsEletronorteGSDE = New System.Windows.Forms.StatusStrip
        Me.barprgEletronorteGSDE = New System.Windows.Forms.ToolStripProgressBar
        Me.barlblHorario = New System.Windows.Forms.ToolStripStatusLabel
        Me.barlblMostrHorario = New System.Windows.Forms.ToolStripStatusLabel
        Me.barlblContUser = New System.Windows.Forms.ToolStripStatusLabel
        Me.barlblMostrContUser = New System.Windows.Forms.ToolStripStatusLabel
        Me.barlblbarStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.tmr1 = New System.Windows.Forms.Timer(Me.components)
        Me.dlgabrirEletronorteGSDE = New System.Windows.Forms.OpenFileDialog
        Me.barmnuEletronorteGSDE = New System.Windows.Forms.MenuStrip
        Me.mnuArquivo = New System.Windows.Forms.ToolStripMenuItem
        Me.smnAbrir = New System.Windows.Forms.ToolStripMenuItem
        Me.smnSair = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuJanela = New System.Windows.Forms.ToolStripMenuItem
        Me.smnHorizontal = New System.Windows.Forms.ToolStripMenuItem
        Me.smnVertical = New System.Windows.Forms.ToolStripMenuItem
        Me.smnCascata = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRedeNeural = New System.Windows.Forms.ToolStripMenuItem
        Me.barstsEletronorteGSDE.SuspendLayout()
        Me.barmnuEletronorteGSDE.SuspendLayout()
        Me.SuspendLayout()
        '
        'barstsEletronorteGSDE
        '
        Me.barstsEletronorteGSDE.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barprgEletronorteGSDE, Me.barlblHorario, Me.barlblMostrHorario, Me.barlblContUser, Me.barlblMostrContUser, Me.barlblbarStatus})
        Me.barstsEletronorteGSDE.Location = New System.Drawing.Point(0, 410)
        Me.barstsEletronorteGSDE.Name = "barstsEletronorteGSDE"
        Me.barstsEletronorteGSDE.Size = New System.Drawing.Size(742, 22)
        Me.barstsEletronorteGSDE.TabIndex = 4
        Me.barstsEletronorteGSDE.Text = "Horario"
        '
        'barprgEletronorteGSDE
        '
        Me.barprgEletronorteGSDE.Name = "barprgEletronorteGSDE"
        Me.barprgEletronorteGSDE.Size = New System.Drawing.Size(100, 16)
        '
        'barlblHorario
        '
        Me.barlblHorario.Name = "barlblHorario"
        Me.barlblHorario.Size = New System.Drawing.Size(49, 17)
        Me.barlblHorario.Text = " Horário:"
        '
        'barlblMostrHorario
        '
        Me.barlblMostrHorario.Name = "barlblMostrHorario"
        Me.barlblMostrHorario.Size = New System.Drawing.Size(0, 17)
        '
        'barlblContUser
        '
        Me.barlblContUser.Name = "barlblContUser"
        Me.barlblContUser.Size = New System.Drawing.Size(94, 17)
        Me.barlblContUser.Text = "Conta do Usuário:"
        '
        'barlblMostrContUser
        '
        Me.barlblMostrContUser.Name = "barlblMostrContUser"
        Me.barlblMostrContUser.Size = New System.Drawing.Size(0, 17)
        '
        'barlblbarStatus
        '
        Me.barlblbarStatus.Name = "barlblbarStatus"
        Me.barlblbarStatus.Size = New System.Drawing.Size(0, 17)
        '
        'tmr1
        '
        '
        'dlgabrirEletronorteGSDE
        '
        Me.dlgabrirEletronorteGSDE.FileName = "OpenFileDialog1"
        '
        'barmnuEletronorteGSDE
        '
        Me.barmnuEletronorteGSDE.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArquivo, Me.mnuJanela, Me.mnuRedeNeural})
        Me.barmnuEletronorteGSDE.Location = New System.Drawing.Point(0, 0)
        Me.barmnuEletronorteGSDE.Name = "barmnuEletronorteGSDE"
        Me.barmnuEletronorteGSDE.Size = New System.Drawing.Size(742, 24)
        Me.barmnuEletronorteGSDE.TabIndex = 7
        '
        'mnuArquivo
        '
        Me.mnuArquivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnAbrir, Me.smnSair})
        Me.mnuArquivo.Name = "mnuArquivo"
        Me.mnuArquivo.Size = New System.Drawing.Size(56, 20)
        Me.mnuArquivo.Text = "&Arquivo"
        '
        'smnAbrir
        '
        Me.smnAbrir.Enabled = False
        Me.smnAbrir.Name = "smnAbrir"
        Me.smnAbrir.Size = New System.Drawing.Size(108, 22)
        Me.smnAbrir.Text = "&Abrir"
        '
        'smnSair
        '
        Me.smnSair.Name = "smnSair"
        Me.smnSair.Size = New System.Drawing.Size(108, 22)
        Me.smnSair.Text = "&Sair"
        '
        'mnuJanela
        '
        Me.mnuJanela.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnHorizontal, Me.smnVertical, Me.smnCascata})
        Me.mnuJanela.Name = "mnuJanela"
        Me.mnuJanela.Size = New System.Drawing.Size(50, 20)
        Me.mnuJanela.Text = "&Janela"
        '
        'smnHorizontal
        '
        Me.smnHorizontal.Name = "smnHorizontal"
        Me.smnHorizontal.Size = New System.Drawing.Size(198, 22)
        Me.smnHorizontal.Text = "Lado a lado - &Horizontal"
        '
        'smnVertical
        '
        Me.smnVertical.Name = "smnVertical"
        Me.smnVertical.Size = New System.Drawing.Size(198, 22)
        Me.smnVertical.Text = "Lado a lado - &Vertical"
        '
        'smnCascata
        '
        Me.smnCascata.Name = "smnCascata"
        Me.smnCascata.Size = New System.Drawing.Size(198, 22)
        Me.smnCascata.Text = "&Cascata"
        '
        'mnuRedeNeural
        '
        Me.mnuRedeNeural.Name = "mnuRedeNeural"
        Me.mnuRedeNeural.Size = New System.Drawing.Size(78, 20)
        Me.mnuRedeNeural.Text = "Rede &Neural"
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(742, 432)
        Me.Controls.Add(Me.barmnuEletronorteGSDE)
        Me.Controls.Add(Me.barstsEletronorteGSDE)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.barmnuEletronorteGSDE
        Me.Name = "frmPrincipal"
        Me.Text = "Rede Neural (VB.Net)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.barstsEletronorteGSDE.ResumeLayout(False)
        Me.barstsEletronorteGSDE.PerformLayout()
        Me.barmnuEletronorteGSDE.ResumeLayout(False)
        Me.barmnuEletronorteGSDE.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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

    Friend WithEvents barstsEletronorteGSDE As System.Windows.Forms.StatusStrip
    Friend WithEvents barprgEletronorteGSDE As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents barlblHorario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents barlblMostrHorario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents barlblContUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents barlblMostrContUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmr1 As System.Windows.Forms.Timer
    Friend WithEvents dlgabrirEletronorteGSDE As System.Windows.Forms.OpenFileDialog
    Friend WithEvents barmnuEletronorteGSDE As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuArquivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnAbrir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuJanela As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRedeNeural As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnSair As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnHorizontal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnVertical As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnCascata As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents barlblbarStatus As System.Windows.Forms.ToolStripStatusLabel


End Class
