Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmConfiguracoes
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfiguracoes))
            Me.ofd1 = New System.Windows.Forms.OpenFileDialog
            Me.btnLocalizacaoBaseDadosPrincipal = New System.Windows.Forms.Button
            Me.txtNomeServidorPrincipal = New System.Windows.Forms.TextBox
            Me.txtChavePrincipal = New System.Windows.Forms.TextBox
            Me.btnSair = New System.Windows.Forms.Button
            Me.txtLocalizacaoPrincipal = New System.Windows.Forms.TextBox
            Me.bar1 = New System.Windows.Forms.StatusStrip
            Me.blblSenhaCriptografada = New System.Windows.Forms.ToolStripStatusLabel
            Me.blblResultadoSenhaCriptografada = New System.Windows.Forms.ToolStripStatusLabel
            Me.lblNomeServidorPrincipal = New System.Windows.Forms.Label
            Me.lblChavePrincipal = New System.Windows.Forms.Label
            Me.lblLocalizacaoPrincipal = New System.Windows.Forms.Label
            Me.tctr1 = New System.Windows.Forms.TabControl
            Me.tabBaseDadosPrincipal = New System.Windows.Forms.TabPage
            Me.lblConexaoPrincipal = New System.Windows.Forms.Label
            Me.txtConexaoPrincipal = New System.Windows.Forms.TextBox
            Me.lblSenhaPrincipal = New System.Windows.Forms.Label
            Me.txtSenhaPrincipal = New System.Windows.Forms.TextBox
            Me.lblNomeBaseDadosPrincipal = New System.Windows.Forms.Label
            Me.txtNomeBaseDadosPrincipal = New System.Windows.Forms.TextBox
            Me.lblIdentificadorUsuarioPrincipal = New System.Windows.Forms.Label
            Me.txtIdentificadorUsuarioPrincipal = New System.Windows.Forms.TextBox
            Me.btnTestarConexaoPrincipal = New System.Windows.Forms.Button
            Me.tabBancoDadosColetor = New System.Windows.Forms.TabPage
            Me.grpMonitorarDiretorioArquivo = New System.Windows.Forms.GroupBox
            Me.btnMonitoramento = New System.Windows.Forms.Button
            Me.chkSubDiretorios = New System.Windows.Forms.CheckBox
            Me.rdbMonitorarDiretorio = New System.Windows.Forms.RadioButton
            Me.rdbMonitorarArquivo = New System.Windows.Forms.RadioButton
            Me.lblLocalizacaoColetor = New System.Windows.Forms.Label
            Me.btnLocalizacaoBaseDadosColetor = New System.Windows.Forms.Button
            Me.txtLocalizacaoColetor = New System.Windows.Forms.TextBox
            Me.lblSenhaColetor = New System.Windows.Forms.Label
            Me.txtSenhaColetor = New System.Windows.Forms.TextBox
            Me.lblNomeBaseDadosColetor = New System.Windows.Forms.Label
            Me.txtNomeBaseDadosColetor = New System.Windows.Forms.TextBox
            Me.lblIdentificadorUsuarioColetor = New System.Windows.Forms.Label
            Me.txtIdentificadorUsuarioColetor = New System.Windows.Forms.TextBox
            Me.btnTestarConexaoColetor = New System.Windows.Forms.Button
            Me.lblNomeServidorColetor = New System.Windows.Forms.Label
            Me.lblConexaoColetor = New System.Windows.Forms.Label
            Me.lblChaveColetor = New System.Windows.Forms.Label
            Me.txtNomeServidorColetor = New System.Windows.Forms.TextBox
            Me.txtChaveColetor = New System.Windows.Forms.TextBox
            Me.txtConexaoColetor = New System.Windows.Forms.TextBox
            Me.tabAcessoCADU = New System.Windows.Forms.TabPage
            Me.lblTabelaCADU = New System.Windows.Forms.Label
            Me.txtTabelaCADU = New System.Windows.Forms.TextBox
            Me.chbInformacaoSegurancaPersistenteCADU = New System.Windows.Forms.CheckBox
            Me.chbSegurancaIntengradaCADU = New System.Windows.Forms.CheckBox
            Me.lblSenhaCADU = New System.Windows.Forms.Label
            Me.txtSenhaCADU = New System.Windows.Forms.TextBox
            Me.lblNomeBaseDadosCADU = New System.Windows.Forms.Label
            Me.txtNomeBaseDadosCADU = New System.Windows.Forms.TextBox
            Me.lblIdentificadorUsuarioCADU = New System.Windows.Forms.Label
            Me.txtIdentificadorUsuarioCADU = New System.Windows.Forms.TextBox
            Me.btnTestarConexaoCADU = New System.Windows.Forms.Button
            Me.lblNomeServidorCADU = New System.Windows.Forms.Label
            Me.lblConexaoCADU = New System.Windows.Forms.Label
            Me.lblChaveCADU = New System.Windows.Forms.Label
            Me.txtNomeServidorCADU = New System.Windows.Forms.TextBox
            Me.txtChaveCADU = New System.Windows.Forms.TextBox
            Me.txtConexaoCADU = New System.Windows.Forms.TextBox
            Me.tabCarteiras = New System.Windows.Forms.TabPage
            Me.btnLocalizacaoTextoEmailCarteiras = New System.Windows.Forms.Button
            Me.lblLocalizacaoTextoEmailCarteiras = New System.Windows.Forms.Label
            Me.txtLocalizacaoTextoEmailCarteiras = New System.Windows.Forms.TextBox
            Me.lblMultiplicadorCodigoCarteiras = New System.Windows.Forms.Label
            Me.txtMultiplicadorCodigoCarteiras = New System.Windows.Forms.TextBox
            Me.lblNumeroLinhasCarteiras = New System.Windows.Forms.Label
            Me.txtNumeroLinhasCarteiras = New System.Windows.Forms.TextBox
            Me.btnLocalizacaoRelatorioCarteiras = New System.Windows.Forms.Button
            Me.lblLocalizacaoRelatorioCarteiras = New System.Windows.Forms.Label
            Me.txtLocalizacaoRelatorioCarteiras = New System.Windows.Forms.TextBox
            Me.lblPrazoValidadeCarteiras = New System.Windows.Forms.Label
            Me.txtPrazoValidadeCarteiras = New System.Windows.Forms.TextBox
            Me.tabCautelas = New System.Windows.Forms.TabPage
            Me.btnLocalizacaoTextoEmailCautelas = New System.Windows.Forms.Button
            Me.lblLocalizacaoTextoEmailCautelas = New System.Windows.Forms.Label
            Me.txtLocalizacaoTextoEmailCautelas = New System.Windows.Forms.TextBox
            Me.lblMultiplicadorCodigoCautelas = New System.Windows.Forms.Label
            Me.txtMultiplicadorCodigoCautelas = New System.Windows.Forms.TextBox
            Me.lblNumeroLinhasCautelas = New System.Windows.Forms.Label
            Me.txtNumeroLinhasCautelas = New System.Windows.Forms.TextBox
            Me.btnLocalizacaoRelatorioCautelas = New System.Windows.Forms.Button
            Me.lblLocalizacaoRelatorioCautelas = New System.Windows.Forms.Label
            Me.txtLocalizacaoRelatorioCautelas = New System.Windows.Forms.TextBox
            Me.txtPrazoEntregaCautelas = New System.Windows.Forms.TextBox
            Me.lblPrazoEntregaCautelas = New System.Windows.Forms.Label
            Me.tabMBPs = New System.Windows.Forms.TabPage
            Me.btnLocalizacaoTextoEmailMBPs = New System.Windows.Forms.Button
            Me.lblLocalizacaoTextoEmailMBPs = New System.Windows.Forms.Label
            Me.txtLocalizacaoTextoEmailMBPs = New System.Windows.Forms.TextBox
            Me.lblMultiplicadorCodigoMBPs = New System.Windows.Forms.Label
            Me.txtMultiplicadorCodigoMBPs = New System.Windows.Forms.TextBox
            Me.lblNumeroLinhasMBPs = New System.Windows.Forms.Label
            Me.txtNumeroLinhasMBPs = New System.Windows.Forms.TextBox
            Me.btnLocalizacaoRelatorioMBPs = New System.Windows.Forms.Button
            Me.lblLocalizacaoRelatorioMBPs = New System.Windows.Forms.Label
            Me.txtLocalizacaoRelatorioMBPs = New System.Windows.Forms.TextBox
            Me.txtPrazoEmprestimo = New System.Windows.Forms.TextBox
            Me.lblPrazoEmprestimo = New System.Windows.Forms.Label
            Me.tabInventarioBens = New System.Windows.Forms.TabPage
            Me.btnLocalizacaoTextoEmailInventarioBens = New System.Windows.Forms.Button
            Me.lblLocalizacaoTextoEmailInventarioBens = New System.Windows.Forms.Label
            Me.txtLocalizacaoTextoEmailInventarioBens = New System.Windows.Forms.TextBox
            Me.lblMultiplicadorCodigoInventarioBens = New System.Windows.Forms.Label
            Me.txtMultiplicadorCodigoInventarioBens = New System.Windows.Forms.TextBox
            Me.chbAtualizarData = New System.Windows.Forms.CheckBox
            Me.lblNumeroLinhasInventarioBens = New System.Windows.Forms.Label
            Me.txtNumeroLinhasInventarioBens = New System.Windows.Forms.TextBox
            Me.btnLocalizacaoRelatorioInventarioBens = New System.Windows.Forms.Button
            Me.lblLocalizacaoRelatorioInventarioBens = New System.Windows.Forms.Label
            Me.txtLocalizacaoRelatorioInventarioBens = New System.Windows.Forms.TextBox
            Me.tabBens = New System.Windows.Forms.TabPage
            Me.btnLocalizacaoTextoEmailBens = New System.Windows.Forms.Button
            Me.lblLocalizacaoTextoEmailBens = New System.Windows.Forms.Label
            Me.txtLocalizacaoTextoEmailBens = New System.Windows.Forms.TextBox
            Me.lblNumeroLinhasBens = New System.Windows.Forms.Label
            Me.txtNumeroLinhasBens = New System.Windows.Forms.TextBox
            Me.btnLocalizacaoRelatorioBens = New System.Windows.Forms.Button
            Me.lblLocalizacaoRelatorioBens = New System.Windows.Forms.Label
            Me.txtLocalizacaoRelatorioBens = New System.Windows.Forms.TextBox
            Me.tabTRG = New System.Windows.Forms.TabPage
            Me.btnDefinir = New System.Windows.Forms.Button
            Me.lblOrgaoGeralBens = New System.Windows.Forms.Label
            Me.txtOrgaoResponsavelGeralBens = New System.Windows.Forms.TextBox
            Me.txtMatriculaResponsavelGeralBens = New System.Windows.Forms.TextBox
            Me.lblMatriculaResponsavelGeralBens = New System.Windows.Forms.Label
            Me.txtNumeroTermoResponsavelGeralBens = New System.Windows.Forms.TextBox
            Me.lblNumeroTermoResponsavelGeralBens = New System.Windows.Forms.Label
            Me.lsvTRG = New System.Windows.Forms.ListView
            Me.txtNomeResponsavelGeralBens = New System.Windows.Forms.TextBox
            Me.lblNomeResponsavelGeralBens = New System.Windows.Forms.Label
            Me.tabEmail = New System.Windows.Forms.TabPage
            Me.tbcEmail = New System.Windows.Forms.TabControl
            Me.tbpGeral = New System.Windows.Forms.TabPage
            Me.grbConfiguraçõesGeral = New System.Windows.Forms.GroupBox
            Me.grpExportacaoRelatorios = New System.Windows.Forms.GroupBox
            Me.grbRelatorioBens = New System.Windows.Forms.GroupBox
            Me.rbtDOCBens = New System.Windows.Forms.RadioButton
            Me.rbtPDFBens = New System.Windows.Forms.RadioButton
            Me.grbRelatorioInventarioBens = New System.Windows.Forms.GroupBox
            Me.rbtDOCInventarioBens = New System.Windows.Forms.RadioButton
            Me.rbtPDFInventarioBens = New System.Windows.Forms.RadioButton
            Me.grbRelatorioMBPs = New System.Windows.Forms.GroupBox
            Me.rbtDOCMBP = New System.Windows.Forms.RadioButton
            Me.rbtPDFMBP = New System.Windows.Forms.RadioButton
            Me.grbRelatorioCautelas = New System.Windows.Forms.GroupBox
            Me.rbtDOCCautela = New System.Windows.Forms.RadioButton
            Me.rbtPDFCautela = New System.Windows.Forms.RadioButton
            Me.grbRelatorioCarteira = New System.Windows.Forms.GroupBox
            Me.rbtDOCCarteira = New System.Windows.Forms.RadioButton
            Me.rbtPDFCarteira = New System.Windows.Forms.RadioButton
            Me.grpConfiguracoesEmail = New System.Windows.Forms.GroupBox
            Me.txtDe = New System.Windows.Forms.TextBox
            Me.lblDe = New System.Windows.Forms.Label
            Me.txtMostrar = New System.Windows.Forms.TextBox
            Me.lblMostrar = New System.Windows.Forms.Label
            Me.txtServidorSMTP = New System.Windows.Forms.TextBox
            Me.lblServidorSMTP = New System.Windows.Forms.Label
            Me.tbpCarteiras = New System.Windows.Forms.TabPage
            Me.rtbCarteiras = New System.Windows.Forms.RichTextBox
            Me.tbpCautelas = New System.Windows.Forms.TabPage
            Me.rtbCautelas = New System.Windows.Forms.RichTextBox
            Me.tbpMBPs = New System.Windows.Forms.TabPage
            Me.rtbMBPs = New System.Windows.Forms.RichTextBox
            Me.tbpInventarioBens = New System.Windows.Forms.TabPage
            Me.rtbInventarioBens = New System.Windows.Forms.RichTextBox
            Me.tbpBens = New System.Windows.Forms.TabPage
            Me.rtbBens = New System.Windows.Forms.RichTextBox
            Me.tabBackupBancoDados = New System.Windows.Forms.TabPage
            Me.btnDiretorioBackupBancoDados = New System.Windows.Forms.Button
            Me.lblNumeroCopiasBackup = New System.Windows.Forms.Label
            Me.txtNumeroCopiasBackup = New System.Windows.Forms.TextBox
            Me.lblIntervaloBackupMinutos = New System.Windows.Forms.Label
            Me.lblIntervaloBackup = New System.Windows.Forms.Label
            Me.txtIntervaloBackup = New System.Windows.Forms.TextBox
            Me.txtDiretorioBackupBancoDados = New System.Windows.Forms.TextBox
            Me.lblDiretorioBackupBancoDados = New System.Windows.Forms.Label
            Me.tabUtilitarios = New System.Windows.Forms.TabPage
            Me.lblFazerBackupBancosDados = New System.Windows.Forms.Label
            Me.btnFazerBackupBancosDados = New System.Windows.Forms.Button
            Me.lblDiretorioInstalacaoAplicativo = New System.Windows.Forms.Label
            Me.txtDiretorioInstalacaoAplicativo = New System.Windows.Forms.TextBox
            Me.btnCriarBancoDadosPrincipal = New System.Windows.Forms.Button
            Me.btnCompactarRepararBancoDadosPrincipal2 = New System.Windows.Forms.Button
            Me.lblCriarTodasTabelas = New System.Windows.Forms.Label
            Me.btnCriarTodasTabelas = New System.Windows.Forms.Button
            Me.lblCriarBancoDadosPrincipal = New System.Windows.Forms.Label
            Me.lblCriarBancoDadosColetor = New System.Windows.Forms.Label
            Me.btnCriarBancoDadosColetor = New System.Windows.Forms.Button
            Me.lblCompactarRepararBancoDadosColetor = New System.Windows.Forms.Label
            Me.btnCompactarRepararBancoDadosColetor = New System.Windows.Forms.Button
            Me.lblCompactarRepararBancoDadosPrincipal = New System.Windows.Forms.Label
            Me.btnAbrir6 = New System.Windows.Forms.Button
            Me.fbd1 = New System.Windows.Forms.FolderBrowserDialog
            Me.Button1 = New System.Windows.Forms.Button
            Me.Label1 = New System.Windows.Forms.Label
            Me.TextBox1 = New System.Windows.Forms.TextBox
            Me.Label2 = New System.Windows.Forms.Label
            Me.TextBox2 = New System.Windows.Forms.TextBox
            Me.CheckBox1 = New System.Windows.Forms.CheckBox
            Me.Label3 = New System.Windows.Forms.Label
            Me.TextBox3 = New System.Windows.Forms.TextBox
            Me.Button2 = New System.Windows.Forms.Button
            Me.Label4 = New System.Windows.Forms.Label
            Me.TextBox4 = New System.Windows.Forms.TextBox
            Me.bar1.SuspendLayout()
            Me.tctr1.SuspendLayout()
            Me.tabBaseDadosPrincipal.SuspendLayout()
            Me.tabBancoDadosColetor.SuspendLayout()
            Me.grpMonitorarDiretorioArquivo.SuspendLayout()
            Me.tabAcessoCADU.SuspendLayout()
            Me.tabCarteiras.SuspendLayout()
            Me.tabCautelas.SuspendLayout()
            Me.tabMBPs.SuspendLayout()
            Me.tabInventarioBens.SuspendLayout()
            Me.tabBens.SuspendLayout()
            Me.tabTRG.SuspendLayout()
            Me.tabEmail.SuspendLayout()
            Me.tbcEmail.SuspendLayout()
            Me.tbpGeral.SuspendLayout()
            Me.grbConfiguraçõesGeral.SuspendLayout()
            Me.grpExportacaoRelatorios.SuspendLayout()
            Me.grbRelatorioBens.SuspendLayout()
            Me.grbRelatorioInventarioBens.SuspendLayout()
            Me.grbRelatorioMBPs.SuspendLayout()
            Me.grbRelatorioCautelas.SuspendLayout()
            Me.grbRelatorioCarteira.SuspendLayout()
            Me.grpConfiguracoesEmail.SuspendLayout()
            Me.tbpCarteiras.SuspendLayout()
            Me.tbpCautelas.SuspendLayout()
            Me.tbpMBPs.SuspendLayout()
            Me.tbpInventarioBens.SuspendLayout()
            Me.tbpBens.SuspendLayout()
            Me.tabBackupBancoDados.SuspendLayout()
            Me.tabUtilitarios.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnLocalizacaoBaseDadosPrincipal
            '
            Me.btnLocalizacaoBaseDadosPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoBaseDadosPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoBaseDadosPrincipal.Location = New System.Drawing.Point(522, 161)
            Me.btnLocalizacaoBaseDadosPrincipal.Name = "btnLocalizacaoBaseDadosPrincipal"
            Me.btnLocalizacaoBaseDadosPrincipal.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoBaseDadosPrincipal.TabIndex = 13
            Me.btnLocalizacaoBaseDadosPrincipal.Text = "..."
            Me.btnLocalizacaoBaseDadosPrincipal.UseVisualStyleBackColor = True
            '
            'txtNomeServidorPrincipal
            '
            Me.txtNomeServidorPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNomeServidorPrincipal.Enabled = False
            Me.txtNomeServidorPrincipal.Location = New System.Drawing.Point(143, 17)
            Me.txtNomeServidorPrincipal.Name = "txtNomeServidorPrincipal"
            Me.txtNomeServidorPrincipal.Size = New System.Drawing.Size(139, 20)
            Me.txtNomeServidorPrincipal.TabIndex = 3
            '
            'txtChavePrincipal
            '
            Me.txtChavePrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtChavePrincipal.Location = New System.Drawing.Point(143, 72)
            Me.txtChavePrincipal.Multiline = True
            Me.txtChavePrincipal.Name = "txtChavePrincipal"
            Me.txtChavePrincipal.Size = New System.Drawing.Size(139, 22)
            Me.txtChavePrincipal.TabIndex = 10
            '
            'btnSair
            '
            Me.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSair.Location = New System.Drawing.Point(477, 339)
            Me.btnSair.Name = "btnSair"
            Me.btnSair.Size = New System.Drawing.Size(94, 23)
            Me.btnSair.TabIndex = 0
            Me.btnSair.Text = "&Sair"
            Me.btnSair.UseVisualStyleBackColor = True
            '
            'txtLocalizacaoPrincipal
            '
            Me.txtLocalizacaoPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoPrincipal.Location = New System.Drawing.Point(11, 113)
            Me.txtLocalizacaoPrincipal.Multiline = True
            Me.txtLocalizacaoPrincipal.Name = "txtLocalizacaoPrincipal"
            Me.txtLocalizacaoPrincipal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoPrincipal.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoPrincipal.TabIndex = 11
            '
            'bar1
            '
            Me.bar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.blblSenhaCriptografada, Me.blblResultadoSenhaCriptografada})
            Me.bar1.Location = New System.Drawing.Point(0, 365)
            Me.bar1.Name = "bar1"
            Me.bar1.Size = New System.Drawing.Size(590, 22)
            Me.bar1.TabIndex = 91
            '
            'blblSenhaCriptografada
            '
            Me.blblSenhaCriptografada.BackColor = System.Drawing.SystemColors.InactiveBorder
            Me.blblSenhaCriptografada.Name = "blblSenhaCriptografada"
            Me.blblSenhaCriptografada.Size = New System.Drawing.Size(118, 17)
            Me.blblSenhaCriptografada.Text = "Senha Criptografada:"
            '
            'blblResultadoSenhaCriptografada
            '
            Me.blblResultadoSenhaCriptografada.AutoSize = False
            Me.blblResultadoSenhaCriptografada.BackColor = System.Drawing.Color.AliceBlue
            Me.blblResultadoSenhaCriptografada.Name = "blblResultadoSenhaCriptografada"
            Me.blblResultadoSenhaCriptografada.Size = New System.Drawing.Size(200, 17)
            '
            'lblNomeServidorPrincipal
            '
            Me.lblNomeServidorPrincipal.AutoSize = True
            Me.lblNomeServidorPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNomeServidorPrincipal.Location = New System.Drawing.Point(42, 17)
            Me.lblNomeServidorPrincipal.Name = "lblNomeServidorPrincipal"
            Me.lblNomeServidorPrincipal.Size = New System.Drawing.Size(95, 13)
            Me.lblNomeServidorPrincipal.TabIndex = 2
            Me.lblNomeServidorPrincipal.Text = "Nome do Servidor:"
            '
            'lblChavePrincipal
            '
            Me.lblChavePrincipal.AutoSize = True
            Me.lblChavePrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblChavePrincipal.Location = New System.Drawing.Point(96, 72)
            Me.lblChavePrincipal.Name = "lblChavePrincipal"
            Me.lblChavePrincipal.Size = New System.Drawing.Size(41, 13)
            Me.lblChavePrincipal.TabIndex = 9
            Me.lblChavePrincipal.Text = "Chave:"
            '
            'lblLocalizacaoPrincipal
            '
            Me.lblLocalizacaoPrincipal.AutoSize = True
            Me.lblLocalizacaoPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoPrincipal.Location = New System.Drawing.Point(8, 97)
            Me.lblLocalizacaoPrincipal.Name = "lblLocalizacaoPrincipal"
            Me.lblLocalizacaoPrincipal.Size = New System.Drawing.Size(158, 13)
            Me.lblLocalizacaoPrincipal.TabIndex = 10
            Me.lblLocalizacaoPrincipal.Text = "Localização da Base de Dados:"
            '
            'tctr1
            '
            Me.tctr1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
            Me.tctr1.Controls.Add(Me.tabBaseDadosPrincipal)
            Me.tctr1.Controls.Add(Me.tabBancoDadosColetor)
            Me.tctr1.Controls.Add(Me.tabAcessoCADU)
            Me.tctr1.Controls.Add(Me.tabCarteiras)
            Me.tctr1.Controls.Add(Me.tabCautelas)
            Me.tctr1.Controls.Add(Me.tabMBPs)
            Me.tctr1.Controls.Add(Me.tabInventarioBens)
            Me.tctr1.Controls.Add(Me.tabBens)
            Me.tctr1.Controls.Add(Me.tabTRG)
            Me.tctr1.Controls.Add(Me.tabEmail)
            Me.tctr1.Controls.Add(Me.tabBackupBancoDados)
            Me.tctr1.Controls.Add(Me.tabUtilitarios)
            Me.tctr1.Location = New System.Drawing.Point(12, 12)
            Me.tctr1.Name = "tctr1"
            Me.tctr1.SelectedIndex = 0
            Me.tctr1.Size = New System.Drawing.Size(571, 321)
            Me.tctr1.TabIndex = 1
            '
            'tabBaseDadosPrincipal
            '
            Me.tabBaseDadosPrincipal.Controls.Add(Me.lblConexaoPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.txtConexaoPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.lblSenhaPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.txtSenhaPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.lblNomeBaseDadosPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.txtNomeBaseDadosPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.lblIdentificadorUsuarioPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.txtIdentificadorUsuarioPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.btnTestarConexaoPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.lblNomeServidorPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.lblLocalizacaoPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.btnLocalizacaoBaseDadosPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.lblChavePrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.txtNomeServidorPrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.txtChavePrincipal)
            Me.tabBaseDadosPrincipal.Controls.Add(Me.txtLocalizacaoPrincipal)
            Me.tabBaseDadosPrincipal.Location = New System.Drawing.Point(4, 25)
            Me.tabBaseDadosPrincipal.Name = "tabBaseDadosPrincipal"
            Me.tabBaseDadosPrincipal.Padding = New System.Windows.Forms.Padding(3)
            Me.tabBaseDadosPrincipal.Size = New System.Drawing.Size(563, 292)
            Me.tabBaseDadosPrincipal.TabIndex = 0
            Me.tabBaseDadosPrincipal.Text = "Base de Dados - Principal"
            Me.tabBaseDadosPrincipal.UseVisualStyleBackColor = True
            '
            'lblConexaoPrincipal
            '
            Me.lblConexaoPrincipal.AutoSize = True
            Me.lblConexaoPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblConexaoPrincipal.Location = New System.Drawing.Point(8, 173)
            Me.lblConexaoPrincipal.Name = "lblConexaoPrincipal"
            Me.lblConexaoPrincipal.Size = New System.Drawing.Size(52, 13)
            Me.lblConexaoPrincipal.TabIndex = 14
            Me.lblConexaoPrincipal.Text = "Conexão:"
            '
            'txtConexaoPrincipal
            '
            Me.txtConexaoPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtConexaoPrincipal.Enabled = False
            Me.txtConexaoPrincipal.Location = New System.Drawing.Point(11, 189)
            Me.txtConexaoPrincipal.Multiline = True
            Me.txtConexaoPrincipal.Name = "txtConexaoPrincipal"
            Me.txtConexaoPrincipal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtConexaoPrincipal.Size = New System.Drawing.Size(544, 42)
            Me.txtConexaoPrincipal.TabIndex = 15
            '
            'lblSenhaPrincipal
            '
            Me.lblSenhaPrincipal.AutoSize = True
            Me.lblSenhaPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblSenhaPrincipal.Location = New System.Drawing.Point(369, 46)
            Me.lblSenhaPrincipal.Name = "lblSenhaPrincipal"
            Me.lblSenhaPrincipal.Size = New System.Drawing.Size(41, 13)
            Me.lblSenhaPrincipal.TabIndex = 8
            Me.lblSenhaPrincipal.Text = "Senha:"
            '
            'txtSenhaPrincipal
            '
            Me.txtSenhaPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSenhaPrincipal.Location = New System.Drawing.Point(416, 46)
            Me.txtSenhaPrincipal.Name = "txtSenhaPrincipal"
            Me.txtSenhaPrincipal.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtSenhaPrincipal.Size = New System.Drawing.Size(139, 20)
            Me.txtSenhaPrincipal.TabIndex = 9
            '
            'lblNomeBaseDadosPrincipal
            '
            Me.lblNomeBaseDadosPrincipal.AutoSize = True
            Me.lblNomeBaseDadosPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNomeBaseDadosPrincipal.Location = New System.Drawing.Point(8, 46)
            Me.lblNomeBaseDadosPrincipal.Name = "lblNomeBaseDadosPrincipal"
            Me.lblNomeBaseDadosPrincipal.Size = New System.Drawing.Size(129, 13)
            Me.lblNomeBaseDadosPrincipal.TabIndex = 6
            Me.lblNomeBaseDadosPrincipal.Text = "Nome da Base de Dados:"
            '
            'txtNomeBaseDadosPrincipal
            '
            Me.txtNomeBaseDadosPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNomeBaseDadosPrincipal.Location = New System.Drawing.Point(143, 46)
            Me.txtNomeBaseDadosPrincipal.Name = "txtNomeBaseDadosPrincipal"
            Me.txtNomeBaseDadosPrincipal.Size = New System.Drawing.Size(139, 20)
            Me.txtNomeBaseDadosPrincipal.TabIndex = 7
            '
            'lblIdentificadorUsuarioPrincipal
            '
            Me.lblIdentificadorUsuarioPrincipal.AutoSize = True
            Me.lblIdentificadorUsuarioPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblIdentificadorUsuarioPrincipal.Location = New System.Drawing.Point(288, 20)
            Me.lblIdentificadorUsuarioPrincipal.Name = "lblIdentificadorUsuarioPrincipal"
            Me.lblIdentificadorUsuarioPrincipal.Size = New System.Drawing.Size(122, 13)
            Me.lblIdentificadorUsuarioPrincipal.TabIndex = 4
            Me.lblIdentificadorUsuarioPrincipal.Text = "Identificador do Usuário:"
            '
            'txtIdentificadorUsuarioPrincipal
            '
            Me.txtIdentificadorUsuarioPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdentificadorUsuarioPrincipal.Enabled = False
            Me.txtIdentificadorUsuarioPrincipal.Location = New System.Drawing.Point(416, 20)
            Me.txtIdentificadorUsuarioPrincipal.Name = "txtIdentificadorUsuarioPrincipal"
            Me.txtIdentificadorUsuarioPrincipal.Size = New System.Drawing.Size(139, 20)
            Me.txtIdentificadorUsuarioPrincipal.TabIndex = 5
            '
            'btnTestarConexaoPrincipal
            '
            Me.btnTestarConexaoPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnTestarConexaoPrincipal.Location = New System.Drawing.Point(422, 161)
            Me.btnTestarConexaoPrincipal.Name = "btnTestarConexaoPrincipal"
            Me.btnTestarConexaoPrincipal.Size = New System.Drawing.Size(94, 22)
            Me.btnTestarConexaoPrincipal.TabIndex = 12
            Me.btnTestarConexaoPrincipal.Text = "&Testar Conexão"
            Me.btnTestarConexaoPrincipal.UseVisualStyleBackColor = True
            '
            'tabBancoDadosColetor
            '
            Me.tabBancoDadosColetor.Controls.Add(Me.grpMonitorarDiretorioArquivo)
            Me.tabBancoDadosColetor.Controls.Add(Me.lblLocalizacaoColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.btnLocalizacaoBaseDadosColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.txtLocalizacaoColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.lblSenhaColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.txtSenhaColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.lblNomeBaseDadosColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.txtNomeBaseDadosColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.lblIdentificadorUsuarioColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.txtIdentificadorUsuarioColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.btnTestarConexaoColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.lblNomeServidorColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.lblConexaoColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.lblChaveColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.txtNomeServidorColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.txtChaveColetor)
            Me.tabBancoDadosColetor.Controls.Add(Me.txtConexaoColetor)
            Me.tabBancoDadosColetor.Location = New System.Drawing.Point(4, 25)
            Me.tabBancoDadosColetor.Name = "tabBancoDadosColetor"
            Me.tabBancoDadosColetor.Size = New System.Drawing.Size(563, 292)
            Me.tabBancoDadosColetor.TabIndex = 7
            Me.tabBancoDadosColetor.Text = "Base de Dados - Coletor"
            Me.tabBancoDadosColetor.UseVisualStyleBackColor = True
            '
            'grpMonitorarDiretorioArquivo
            '
            Me.grpMonitorarDiretorioArquivo.Controls.Add(Me.btnMonitoramento)
            Me.grpMonitorarDiretorioArquivo.Controls.Add(Me.chkSubDiretorios)
            Me.grpMonitorarDiretorioArquivo.Controls.Add(Me.rdbMonitorarDiretorio)
            Me.grpMonitorarDiretorioArquivo.Controls.Add(Me.rdbMonitorarArquivo)
            Me.grpMonitorarDiretorioArquivo.Enabled = False
            Me.grpMonitorarDiretorioArquivo.Location = New System.Drawing.Point(11, 237)
            Me.grpMonitorarDiretorioArquivo.Name = "grpMonitorarDiretorioArquivo"
            Me.grpMonitorarDiretorioArquivo.Size = New System.Drawing.Size(544, 44)
            Me.grpMonitorarDiretorioArquivo.TabIndex = 18
            Me.grpMonitorarDiretorioArquivo.TabStop = False
            Me.grpMonitorarDiretorioArquivo.Text = "Modo de Monitoramento:"
            '
            'btnMonitoramento
            '
            Me.btnMonitoramento.BackColor = System.Drawing.Color.LightSkyBlue
            Me.btnMonitoramento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnMonitoramento.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnMonitoramento.Location = New System.Drawing.Point(368, 15)
            Me.btnMonitoramento.Name = "btnMonitoramento"
            Me.btnMonitoramento.Size = New System.Drawing.Size(119, 23)
            Me.btnMonitoramento.TabIndex = 22
            Me.btnMonitoramento.Text = "&Iniciar Monitoramento"
            Me.btnMonitoramento.UseVisualStyleBackColor = False
            '
            'chkSubDiretorios
            '
            Me.chkSubDiretorios.AutoSize = True
            Me.chkSubDiretorios.Enabled = False
            Me.chkSubDiretorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chkSubDiretorios.Location = New System.Drawing.Point(242, 22)
            Me.chkSubDiretorios.Name = "chkSubDiretorios"
            Me.chkSubDiretorios.Size = New System.Drawing.Size(117, 17)
            Me.chkSubDiretorios.TabIndex = 21
            Me.chkSubDiretorios.Text = "Incluir SubDiretórios"
            Me.chkSubDiretorios.UseVisualStyleBackColor = True
            '
            'rdbMonitorarDiretorio
            '
            Me.rdbMonitorarDiretorio.AutoSize = True
            Me.rdbMonitorarDiretorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.rdbMonitorarDiretorio.Location = New System.Drawing.Point(120, 21)
            Me.rdbMonitorarDiretorio.Name = "rdbMonitorarDiretorio"
            Me.rdbMonitorarDiretorio.Size = New System.Drawing.Size(115, 17)
            Me.rdbMonitorarDiretorio.TabIndex = 20
            Me.rdbMonitorarDiretorio.Text = "Monitorar Diretórios"
            Me.rdbMonitorarDiretorio.UseVisualStyleBackColor = True
            '
            'rdbMonitorarArquivo
            '
            Me.rdbMonitorarArquivo.AutoSize = True
            Me.rdbMonitorarArquivo.Checked = True
            Me.rdbMonitorarArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.rdbMonitorarArquivo.Location = New System.Drawing.Point(6, 21)
            Me.rdbMonitorarArquivo.Name = "rdbMonitorarArquivo"
            Me.rdbMonitorarArquivo.Size = New System.Drawing.Size(107, 17)
            Me.rdbMonitorarArquivo.TabIndex = 19
            Me.rdbMonitorarArquivo.TabStop = True
            Me.rdbMonitorarArquivo.Text = "Monitorar Arquivo"
            Me.rdbMonitorarArquivo.UseVisualStyleBackColor = True
            '
            'lblLocalizacaoColetor
            '
            Me.lblLocalizacaoColetor.AutoSize = True
            Me.lblLocalizacaoColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoColetor.Location = New System.Drawing.Point(8, 97)
            Me.lblLocalizacaoColetor.Name = "lblLocalizacaoColetor"
            Me.lblLocalizacaoColetor.Size = New System.Drawing.Size(158, 13)
            Me.lblLocalizacaoColetor.TabIndex = 12
            Me.lblLocalizacaoColetor.Text = "Localização da Base de Dados:"
            '
            'btnLocalizacaoBaseDadosColetor
            '
            Me.btnLocalizacaoBaseDadosColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoBaseDadosColetor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoBaseDadosColetor.Location = New System.Drawing.Point(522, 161)
            Me.btnLocalizacaoBaseDadosColetor.Name = "btnLocalizacaoBaseDadosColetor"
            Me.btnLocalizacaoBaseDadosColetor.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoBaseDadosColetor.TabIndex = 15
            Me.btnLocalizacaoBaseDadosColetor.Text = "..."
            Me.btnLocalizacaoBaseDadosColetor.UseVisualStyleBackColor = True
            '
            'txtLocalizacaoColetor
            '
            Me.txtLocalizacaoColetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoColetor.Location = New System.Drawing.Point(11, 113)
            Me.txtLocalizacaoColetor.Multiline = True
            Me.txtLocalizacaoColetor.Name = "txtLocalizacaoColetor"
            Me.txtLocalizacaoColetor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoColetor.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoColetor.TabIndex = 13
            '
            'lblSenhaColetor
            '
            Me.lblSenhaColetor.AutoSize = True
            Me.lblSenhaColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblSenhaColetor.Location = New System.Drawing.Point(369, 46)
            Me.lblSenhaColetor.Name = "lblSenhaColetor"
            Me.lblSenhaColetor.Size = New System.Drawing.Size(41, 13)
            Me.lblSenhaColetor.TabIndex = 8
            Me.lblSenhaColetor.Text = "Senha:"
            '
            'txtSenhaColetor
            '
            Me.txtSenhaColetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSenhaColetor.Location = New System.Drawing.Point(416, 46)
            Me.txtSenhaColetor.Name = "txtSenhaColetor"
            Me.txtSenhaColetor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtSenhaColetor.Size = New System.Drawing.Size(139, 20)
            Me.txtSenhaColetor.TabIndex = 9
            '
            'lblNomeBaseDadosColetor
            '
            Me.lblNomeBaseDadosColetor.AutoSize = True
            Me.lblNomeBaseDadosColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNomeBaseDadosColetor.Location = New System.Drawing.Point(8, 46)
            Me.lblNomeBaseDadosColetor.Name = "lblNomeBaseDadosColetor"
            Me.lblNomeBaseDadosColetor.Size = New System.Drawing.Size(129, 13)
            Me.lblNomeBaseDadosColetor.TabIndex = 6
            Me.lblNomeBaseDadosColetor.Text = "Nome da Base de Dados:"
            '
            'txtNomeBaseDadosColetor
            '
            Me.txtNomeBaseDadosColetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNomeBaseDadosColetor.Location = New System.Drawing.Point(143, 46)
            Me.txtNomeBaseDadosColetor.Name = "txtNomeBaseDadosColetor"
            Me.txtNomeBaseDadosColetor.Size = New System.Drawing.Size(139, 20)
            Me.txtNomeBaseDadosColetor.TabIndex = 7
            '
            'lblIdentificadorUsuarioColetor
            '
            Me.lblIdentificadorUsuarioColetor.AutoSize = True
            Me.lblIdentificadorUsuarioColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblIdentificadorUsuarioColetor.Location = New System.Drawing.Point(288, 20)
            Me.lblIdentificadorUsuarioColetor.Name = "lblIdentificadorUsuarioColetor"
            Me.lblIdentificadorUsuarioColetor.Size = New System.Drawing.Size(122, 13)
            Me.lblIdentificadorUsuarioColetor.TabIndex = 4
            Me.lblIdentificadorUsuarioColetor.Text = "Identificador do Usuário:"
            '
            'txtIdentificadorUsuarioColetor
            '
            Me.txtIdentificadorUsuarioColetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdentificadorUsuarioColetor.Enabled = False
            Me.txtIdentificadorUsuarioColetor.Location = New System.Drawing.Point(416, 20)
            Me.txtIdentificadorUsuarioColetor.Name = "txtIdentificadorUsuarioColetor"
            Me.txtIdentificadorUsuarioColetor.Size = New System.Drawing.Size(139, 20)
            Me.txtIdentificadorUsuarioColetor.TabIndex = 5
            '
            'btnTestarConexaoColetor
            '
            Me.btnTestarConexaoColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnTestarConexaoColetor.Location = New System.Drawing.Point(422, 161)
            Me.btnTestarConexaoColetor.Name = "btnTestarConexaoColetor"
            Me.btnTestarConexaoColetor.Size = New System.Drawing.Size(94, 22)
            Me.btnTestarConexaoColetor.TabIndex = 14
            Me.btnTestarConexaoColetor.Text = "&Testar Conexão"
            Me.btnTestarConexaoColetor.UseVisualStyleBackColor = True
            '
            'lblNomeServidorColetor
            '
            Me.lblNomeServidorColetor.AutoSize = True
            Me.lblNomeServidorColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNomeServidorColetor.Location = New System.Drawing.Point(42, 17)
            Me.lblNomeServidorColetor.Name = "lblNomeServidorColetor"
            Me.lblNomeServidorColetor.Size = New System.Drawing.Size(95, 13)
            Me.lblNomeServidorColetor.TabIndex = 2
            Me.lblNomeServidorColetor.Text = "Nome do Servidor:"
            '
            'lblConexaoColetor
            '
            Me.lblConexaoColetor.AutoSize = True
            Me.lblConexaoColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblConexaoColetor.Location = New System.Drawing.Point(8, 173)
            Me.lblConexaoColetor.Name = "lblConexaoColetor"
            Me.lblConexaoColetor.Size = New System.Drawing.Size(52, 13)
            Me.lblConexaoColetor.TabIndex = 16
            Me.lblConexaoColetor.Text = "Conexão:"
            '
            'lblChaveColetor
            '
            Me.lblChaveColetor.AutoSize = True
            Me.lblChaveColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblChaveColetor.Location = New System.Drawing.Point(96, 72)
            Me.lblChaveColetor.Name = "lblChaveColetor"
            Me.lblChaveColetor.Size = New System.Drawing.Size(41, 13)
            Me.lblChaveColetor.TabIndex = 10
            Me.lblChaveColetor.Text = "Chave:"
            '
            'txtNomeServidorColetor
            '
            Me.txtNomeServidorColetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNomeServidorColetor.Enabled = False
            Me.txtNomeServidorColetor.Location = New System.Drawing.Point(143, 17)
            Me.txtNomeServidorColetor.Name = "txtNomeServidorColetor"
            Me.txtNomeServidorColetor.Size = New System.Drawing.Size(139, 20)
            Me.txtNomeServidorColetor.TabIndex = 3
            '
            'txtChaveColetor
            '
            Me.txtChaveColetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtChaveColetor.Location = New System.Drawing.Point(143, 72)
            Me.txtChaveColetor.Multiline = True
            Me.txtChaveColetor.Name = "txtChaveColetor"
            Me.txtChaveColetor.Size = New System.Drawing.Size(139, 22)
            Me.txtChaveColetor.TabIndex = 11
            '
            'txtConexaoColetor
            '
            Me.txtConexaoColetor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtConexaoColetor.Enabled = False
            Me.txtConexaoColetor.Location = New System.Drawing.Point(11, 189)
            Me.txtConexaoColetor.Multiline = True
            Me.txtConexaoColetor.Name = "txtConexaoColetor"
            Me.txtConexaoColetor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtConexaoColetor.Size = New System.Drawing.Size(544, 42)
            Me.txtConexaoColetor.TabIndex = 17
            '
            'tabAcessoCADU
            '
            Me.tabAcessoCADU.Controls.Add(Me.lblTabelaCADU)
            Me.tabAcessoCADU.Controls.Add(Me.txtTabelaCADU)
            Me.tabAcessoCADU.Controls.Add(Me.chbInformacaoSegurancaPersistenteCADU)
            Me.tabAcessoCADU.Controls.Add(Me.chbSegurancaIntengradaCADU)
            Me.tabAcessoCADU.Controls.Add(Me.lblSenhaCADU)
            Me.tabAcessoCADU.Controls.Add(Me.txtSenhaCADU)
            Me.tabAcessoCADU.Controls.Add(Me.lblNomeBaseDadosCADU)
            Me.tabAcessoCADU.Controls.Add(Me.txtNomeBaseDadosCADU)
            Me.tabAcessoCADU.Controls.Add(Me.lblIdentificadorUsuarioCADU)
            Me.tabAcessoCADU.Controls.Add(Me.txtIdentificadorUsuarioCADU)
            Me.tabAcessoCADU.Controls.Add(Me.btnTestarConexaoCADU)
            Me.tabAcessoCADU.Controls.Add(Me.lblNomeServidorCADU)
            Me.tabAcessoCADU.Controls.Add(Me.lblConexaoCADU)
            Me.tabAcessoCADU.Controls.Add(Me.lblChaveCADU)
            Me.tabAcessoCADU.Controls.Add(Me.txtNomeServidorCADU)
            Me.tabAcessoCADU.Controls.Add(Me.txtChaveCADU)
            Me.tabAcessoCADU.Controls.Add(Me.txtConexaoCADU)
            Me.tabAcessoCADU.Location = New System.Drawing.Point(4, 25)
            Me.tabAcessoCADU.Name = "tabAcessoCADU"
            Me.tabAcessoCADU.Size = New System.Drawing.Size(563, 292)
            Me.tabAcessoCADU.TabIndex = 5
            Me.tabAcessoCADU.Text = "Acesso CADU"
            Me.tabAcessoCADU.UseVisualStyleBackColor = True
            '
            'lblTabelaCADU
            '
            Me.lblTabelaCADU.AutoSize = True
            Me.lblTabelaCADU.Location = New System.Drawing.Point(367, 72)
            Me.lblTabelaCADU.Name = "lblTabelaCADU"
            Me.lblTabelaCADU.Size = New System.Drawing.Size(43, 13)
            Me.lblTabelaCADU.TabIndex = 12
            Me.lblTabelaCADU.Text = "Tabela:"
            '
            'txtTabelaCADU
            '
            Me.txtTabelaCADU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTabelaCADU.Location = New System.Drawing.Point(416, 72)
            Me.txtTabelaCADU.Name = "txtTabelaCADU"
            Me.txtTabelaCADU.Size = New System.Drawing.Size(139, 20)
            Me.txtTabelaCADU.TabIndex = 13
            '
            'chbInformacaoSegurancaPersistenteCADU
            '
            Me.chbInformacaoSegurancaPersistenteCADU.AutoSize = True
            Me.chbInformacaoSegurancaPersistenteCADU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chbInformacaoSegurancaPersistenteCADU.Location = New System.Drawing.Point(11, 254)
            Me.chbInformacaoSegurancaPersistenteCADU.Name = "chbInformacaoSegurancaPersistenteCADU"
            Me.chbInformacaoSegurancaPersistenteCADU.Size = New System.Drawing.Size(186, 17)
            Me.chbInformacaoSegurancaPersistenteCADU.TabIndex = 17
            Me.chbInformacaoSegurancaPersistenteCADU.Text = "Informação Segurança Persistente"
            Me.chbInformacaoSegurancaPersistenteCADU.UseVisualStyleBackColor = True
            '
            'chbSegurancaIntengradaCADU
            '
            Me.chbSegurancaIntengradaCADU.AutoSize = True
            Me.chbSegurancaIntengradaCADU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chbSegurancaIntengradaCADU.Location = New System.Drawing.Point(11, 231)
            Me.chbSegurancaIntengradaCADU.Name = "chbSegurancaIntengradaCADU"
            Me.chbSegurancaIntengradaCADU.Size = New System.Drawing.Size(166, 17)
            Me.chbSegurancaIntengradaCADU.TabIndex = 16
            Me.chbSegurancaIntengradaCADU.Text = "Permitir Segurança Intengrada"
            Me.chbSegurancaIntengradaCADU.UseVisualStyleBackColor = True
            '
            'lblSenhaCADU
            '
            Me.lblSenhaCADU.AutoSize = True
            Me.lblSenhaCADU.Location = New System.Drawing.Point(369, 46)
            Me.lblSenhaCADU.Name = "lblSenhaCADU"
            Me.lblSenhaCADU.Size = New System.Drawing.Size(41, 13)
            Me.lblSenhaCADU.TabIndex = 8
            Me.lblSenhaCADU.Text = "Senha:"
            '
            'txtSenhaCADU
            '
            Me.txtSenhaCADU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSenhaCADU.Location = New System.Drawing.Point(416, 46)
            Me.txtSenhaCADU.Name = "txtSenhaCADU"
            Me.txtSenhaCADU.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.txtSenhaCADU.Size = New System.Drawing.Size(139, 20)
            Me.txtSenhaCADU.TabIndex = 9
            '
            'lblNomeBaseDadosCADU
            '
            Me.lblNomeBaseDadosCADU.AutoSize = True
            Me.lblNomeBaseDadosCADU.Location = New System.Drawing.Point(8, 46)
            Me.lblNomeBaseDadosCADU.Name = "lblNomeBaseDadosCADU"
            Me.lblNomeBaseDadosCADU.Size = New System.Drawing.Size(129, 13)
            Me.lblNomeBaseDadosCADU.TabIndex = 6
            Me.lblNomeBaseDadosCADU.Text = "Nome da Base de Dados:"
            '
            'txtNomeBaseDadosCADU
            '
            Me.txtNomeBaseDadosCADU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNomeBaseDadosCADU.Location = New System.Drawing.Point(143, 46)
            Me.txtNomeBaseDadosCADU.Name = "txtNomeBaseDadosCADU"
            Me.txtNomeBaseDadosCADU.Size = New System.Drawing.Size(139, 20)
            Me.txtNomeBaseDadosCADU.TabIndex = 7
            '
            'lblIdentificadorUsuarioCADU
            '
            Me.lblIdentificadorUsuarioCADU.AutoSize = True
            Me.lblIdentificadorUsuarioCADU.Location = New System.Drawing.Point(288, 20)
            Me.lblIdentificadorUsuarioCADU.Name = "lblIdentificadorUsuarioCADU"
            Me.lblIdentificadorUsuarioCADU.Size = New System.Drawing.Size(122, 13)
            Me.lblIdentificadorUsuarioCADU.TabIndex = 4
            Me.lblIdentificadorUsuarioCADU.Text = "Identificador do Usuário:"
            '
            'txtIdentificadorUsuarioCADU
            '
            Me.txtIdentificadorUsuarioCADU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIdentificadorUsuarioCADU.Location = New System.Drawing.Point(416, 20)
            Me.txtIdentificadorUsuarioCADU.Name = "txtIdentificadorUsuarioCADU"
            Me.txtIdentificadorUsuarioCADU.Size = New System.Drawing.Size(139, 20)
            Me.txtIdentificadorUsuarioCADU.TabIndex = 5
            '
            'btnTestarConexaoCADU
            '
            Me.btnTestarConexaoCADU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnTestarConexaoCADU.Location = New System.Drawing.Point(461, 161)
            Me.btnTestarConexaoCADU.Name = "btnTestarConexaoCADU"
            Me.btnTestarConexaoCADU.Size = New System.Drawing.Size(94, 22)
            Me.btnTestarConexaoCADU.TabIndex = 15
            Me.btnTestarConexaoCADU.Text = "&Testar Conexão"
            Me.btnTestarConexaoCADU.UseVisualStyleBackColor = True
            '
            'lblNomeServidorCADU
            '
            Me.lblNomeServidorCADU.AutoSize = True
            Me.lblNomeServidorCADU.Location = New System.Drawing.Point(42, 17)
            Me.lblNomeServidorCADU.Name = "lblNomeServidorCADU"
            Me.lblNomeServidorCADU.Size = New System.Drawing.Size(95, 13)
            Me.lblNomeServidorCADU.TabIndex = 2
            Me.lblNomeServidorCADU.Text = "Nome do Servidor:"
            '
            'lblConexaoCADU
            '
            Me.lblConexaoCADU.AutoSize = True
            Me.lblConexaoCADU.Location = New System.Drawing.Point(8, 97)
            Me.lblConexaoCADU.Name = "lblConexaoCADU"
            Me.lblConexaoCADU.Size = New System.Drawing.Size(52, 13)
            Me.lblConexaoCADU.TabIndex = 36
            Me.lblConexaoCADU.Text = "Conexão:"
            '
            'lblChaveCADU
            '
            Me.lblChaveCADU.AutoSize = True
            Me.lblChaveCADU.Location = New System.Drawing.Point(96, 72)
            Me.lblChaveCADU.Name = "lblChaveCADU"
            Me.lblChaveCADU.Size = New System.Drawing.Size(41, 13)
            Me.lblChaveCADU.TabIndex = 10
            Me.lblChaveCADU.Text = "Chave:"
            '
            'txtNomeServidorCADU
            '
            Me.txtNomeServidorCADU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNomeServidorCADU.Location = New System.Drawing.Point(143, 17)
            Me.txtNomeServidorCADU.Name = "txtNomeServidorCADU"
            Me.txtNomeServidorCADU.Size = New System.Drawing.Size(139, 20)
            Me.txtNomeServidorCADU.TabIndex = 3
            '
            'txtChaveCADU
            '
            Me.txtChaveCADU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtChaveCADU.Location = New System.Drawing.Point(143, 72)
            Me.txtChaveCADU.Multiline = True
            Me.txtChaveCADU.Name = "txtChaveCADU"
            Me.txtChaveCADU.Size = New System.Drawing.Size(139, 22)
            Me.txtChaveCADU.TabIndex = 11
            '
            'txtConexaoCADU
            '
            Me.txtConexaoCADU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtConexaoCADU.Enabled = False
            Me.txtConexaoCADU.Location = New System.Drawing.Point(11, 113)
            Me.txtConexaoCADU.Multiline = True
            Me.txtConexaoCADU.Name = "txtConexaoCADU"
            Me.txtConexaoCADU.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtConexaoCADU.Size = New System.Drawing.Size(544, 42)
            Me.txtConexaoCADU.TabIndex = 14
            '
            'tabCarteiras
            '
            Me.tabCarteiras.Controls.Add(Me.btnLocalizacaoTextoEmailCarteiras)
            Me.tabCarteiras.Controls.Add(Me.lblLocalizacaoTextoEmailCarteiras)
            Me.tabCarteiras.Controls.Add(Me.txtLocalizacaoTextoEmailCarteiras)
            Me.tabCarteiras.Controls.Add(Me.lblMultiplicadorCodigoCarteiras)
            Me.tabCarteiras.Controls.Add(Me.txtMultiplicadorCodigoCarteiras)
            Me.tabCarteiras.Controls.Add(Me.lblNumeroLinhasCarteiras)
            Me.tabCarteiras.Controls.Add(Me.txtNumeroLinhasCarteiras)
            Me.tabCarteiras.Controls.Add(Me.btnLocalizacaoRelatorioCarteiras)
            Me.tabCarteiras.Controls.Add(Me.lblLocalizacaoRelatorioCarteiras)
            Me.tabCarteiras.Controls.Add(Me.txtLocalizacaoRelatorioCarteiras)
            Me.tabCarteiras.Controls.Add(Me.lblPrazoValidadeCarteiras)
            Me.tabCarteiras.Controls.Add(Me.txtPrazoValidadeCarteiras)
            Me.tabCarteiras.Location = New System.Drawing.Point(4, 25)
            Me.tabCarteiras.Name = "tabCarteiras"
            Me.tabCarteiras.Size = New System.Drawing.Size(563, 292)
            Me.tabCarteiras.TabIndex = 1
            Me.tabCarteiras.Text = "Carteiras"
            Me.tabCarteiras.UseVisualStyleBackColor = True
            '
            'btnLocalizacaoTextoEmailCarteiras
            '
            Me.btnLocalizacaoTextoEmailCarteiras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoTextoEmailCarteiras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoTextoEmailCarteiras.Location = New System.Drawing.Point(526, 188)
            Me.btnLocalizacaoTextoEmailCarteiras.Name = "btnLocalizacaoTextoEmailCarteiras"
            Me.btnLocalizacaoTextoEmailCarteiras.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoTextoEmailCarteiras.TabIndex = 13
            Me.btnLocalizacaoTextoEmailCarteiras.Text = "..."
            Me.btnLocalizacaoTextoEmailCarteiras.UseVisualStyleBackColor = True
            '
            'lblLocalizacaoTextoEmailCarteiras
            '
            Me.lblLocalizacaoTextoEmailCarteiras.AutoSize = True
            Me.lblLocalizacaoTextoEmailCarteiras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoTextoEmailCarteiras.Location = New System.Drawing.Point(12, 124)
            Me.lblLocalizacaoTextoEmailCarteiras.Name = "lblLocalizacaoTextoEmailCarteiras"
            Me.lblLocalizacaoTextoEmailCarteiras.Size = New System.Drawing.Size(222, 13)
            Me.lblLocalizacaoTextoEmailCarteiras.TabIndex = 11
            Me.lblLocalizacaoTextoEmailCarteiras.Text = "Localização do Texto de E-mail das Carteiras:"
            '
            'txtLocalizacaoTextoEmailCarteiras
            '
            Me.txtLocalizacaoTextoEmailCarteiras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoTextoEmailCarteiras.Location = New System.Drawing.Point(15, 140)
            Me.txtLocalizacaoTextoEmailCarteiras.Multiline = True
            Me.txtLocalizacaoTextoEmailCarteiras.Name = "txtLocalizacaoTextoEmailCarteiras"
            Me.txtLocalizacaoTextoEmailCarteiras.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoTextoEmailCarteiras.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoTextoEmailCarteiras.TabIndex = 12
            '
            'lblMultiplicadorCodigoCarteiras
            '
            Me.lblMultiplicadorCodigoCarteiras.AutoSize = True
            Me.lblMultiplicadorCodigoCarteiras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblMultiplicadorCodigoCarteiras.Location = New System.Drawing.Point(301, 271)
            Me.lblMultiplicadorCodigoCarteiras.Name = "lblMultiplicadorCodigoCarteiras"
            Me.lblMultiplicadorCodigoCarteiras.Size = New System.Drawing.Size(120, 13)
            Me.lblMultiplicadorCodigoCarteiras.TabIndex = 9
            Me.lblMultiplicadorCodigoCarteiras.Text = "Multiplicador do Código:"
            '
            'txtMultiplicadorCodigoCarteiras
            '
            Me.txtMultiplicadorCodigoCarteiras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMultiplicadorCodigoCarteiras.Location = New System.Drawing.Point(427, 269)
            Me.txtMultiplicadorCodigoCarteiras.Name = "txtMultiplicadorCodigoCarteiras"
            Me.txtMultiplicadorCodigoCarteiras.Size = New System.Drawing.Size(132, 20)
            Me.txtMultiplicadorCodigoCarteiras.TabIndex = 10
            '
            'lblNumeroLinhasCarteiras
            '
            Me.lblNumeroLinhasCarteiras.AutoSize = True
            Me.lblNumeroLinhasCarteiras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNumeroLinhasCarteiras.Location = New System.Drawing.Point(288, 12)
            Me.lblNumeroLinhasCarteiras.Name = "lblNumeroLinhasCarteiras"
            Me.lblNumeroLinhasCarteiras.Size = New System.Drawing.Size(133, 13)
            Me.lblNumeroLinhasCarteiras.TabIndex = 4
            Me.lblNumeroLinhasCarteiras.Text = "Numero de Linhas do Grid:"
            '
            'txtNumeroLinhasCarteiras
            '
            Me.txtNumeroLinhasCarteiras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNumeroLinhasCarteiras.Location = New System.Drawing.Point(427, 12)
            Me.txtNumeroLinhasCarteiras.Name = "txtNumeroLinhasCarteiras"
            Me.txtNumeroLinhasCarteiras.Size = New System.Drawing.Size(132, 20)
            Me.txtNumeroLinhasCarteiras.TabIndex = 5
            '
            'btnLocalizacaoRelatorioCarteiras
            '
            Me.btnLocalizacaoRelatorioCarteiras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoRelatorioCarteiras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoRelatorioCarteiras.Location = New System.Drawing.Point(526, 112)
            Me.btnLocalizacaoRelatorioCarteiras.Name = "btnLocalizacaoRelatorioCarteiras"
            Me.btnLocalizacaoRelatorioCarteiras.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoRelatorioCarteiras.TabIndex = 8
            Me.btnLocalizacaoRelatorioCarteiras.Text = "..."
            Me.btnLocalizacaoRelatorioCarteiras.UseVisualStyleBackColor = True
            '
            'lblLocalizacaoRelatorioCarteiras
            '
            Me.lblLocalizacaoRelatorioCarteiras.AutoSize = True
            Me.lblLocalizacaoRelatorioCarteiras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoRelatorioCarteiras.Location = New System.Drawing.Point(12, 48)
            Me.lblLocalizacaoRelatorioCarteiras.Name = "lblLocalizacaoRelatorioCarteiras"
            Me.lblLocalizacaoRelatorioCarteiras.Size = New System.Drawing.Size(191, 13)
            Me.lblLocalizacaoRelatorioCarteiras.TabIndex = 6
            Me.lblLocalizacaoRelatorioCarteiras.Text = "Localização do Relatório das Carteiras:"
            '
            'txtLocalizacaoRelatorioCarteiras
            '
            Me.txtLocalizacaoRelatorioCarteiras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoRelatorioCarteiras.Location = New System.Drawing.Point(15, 64)
            Me.txtLocalizacaoRelatorioCarteiras.Multiline = True
            Me.txtLocalizacaoRelatorioCarteiras.Name = "txtLocalizacaoRelatorioCarteiras"
            Me.txtLocalizacaoRelatorioCarteiras.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoRelatorioCarteiras.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoRelatorioCarteiras.TabIndex = 7
            '
            'lblPrazoValidadeCarteiras
            '
            Me.lblPrazoValidadeCarteiras.AutoSize = True
            Me.lblPrazoValidadeCarteiras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblPrazoValidadeCarteiras.Location = New System.Drawing.Point(12, 12)
            Me.lblPrazoValidadeCarteiras.Name = "lblPrazoValidadeCarteiras"
            Me.lblPrazoValidadeCarteiras.Size = New System.Drawing.Size(96, 13)
            Me.lblPrazoValidadeCarteiras.TabIndex = 2
            Me.lblPrazoValidadeCarteiras.Text = "Prazo de Validade:"
            '
            'txtPrazoValidadeCarteiras
            '
            Me.txtPrazoValidadeCarteiras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPrazoValidadeCarteiras.Location = New System.Drawing.Point(114, 9)
            Me.txtPrazoValidadeCarteiras.Name = "txtPrazoValidadeCarteiras"
            Me.txtPrazoValidadeCarteiras.Size = New System.Drawing.Size(132, 20)
            Me.txtPrazoValidadeCarteiras.TabIndex = 3
            '
            'tabCautelas
            '
            Me.tabCautelas.Controls.Add(Me.btnLocalizacaoTextoEmailCautelas)
            Me.tabCautelas.Controls.Add(Me.lblLocalizacaoTextoEmailCautelas)
            Me.tabCautelas.Controls.Add(Me.txtLocalizacaoTextoEmailCautelas)
            Me.tabCautelas.Controls.Add(Me.lblMultiplicadorCodigoCautelas)
            Me.tabCautelas.Controls.Add(Me.txtMultiplicadorCodigoCautelas)
            Me.tabCautelas.Controls.Add(Me.lblNumeroLinhasCautelas)
            Me.tabCautelas.Controls.Add(Me.txtNumeroLinhasCautelas)
            Me.tabCautelas.Controls.Add(Me.btnLocalizacaoRelatorioCautelas)
            Me.tabCautelas.Controls.Add(Me.lblLocalizacaoRelatorioCautelas)
            Me.tabCautelas.Controls.Add(Me.txtLocalizacaoRelatorioCautelas)
            Me.tabCautelas.Controls.Add(Me.txtPrazoEntregaCautelas)
            Me.tabCautelas.Controls.Add(Me.lblPrazoEntregaCautelas)
            Me.tabCautelas.Location = New System.Drawing.Point(4, 25)
            Me.tabCautelas.Name = "tabCautelas"
            Me.tabCautelas.Size = New System.Drawing.Size(563, 292)
            Me.tabCautelas.TabIndex = 2
            Me.tabCautelas.Text = "Cautelas"
            Me.tabCautelas.UseVisualStyleBackColor = True
            '
            'btnLocalizacaoTextoEmailCautelas
            '
            Me.btnLocalizacaoTextoEmailCautelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoTextoEmailCautelas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoTextoEmailCautelas.Location = New System.Drawing.Point(526, 188)
            Me.btnLocalizacaoTextoEmailCautelas.Name = "btnLocalizacaoTextoEmailCautelas"
            Me.btnLocalizacaoTextoEmailCautelas.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoTextoEmailCautelas.TabIndex = 16
            Me.btnLocalizacaoTextoEmailCautelas.Text = "..."
            Me.btnLocalizacaoTextoEmailCautelas.UseVisualStyleBackColor = True
            '
            'lblLocalizacaoTextoEmailCautelas
            '
            Me.lblLocalizacaoTextoEmailCautelas.AutoSize = True
            Me.lblLocalizacaoTextoEmailCautelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoTextoEmailCautelas.Location = New System.Drawing.Point(12, 124)
            Me.lblLocalizacaoTextoEmailCautelas.Name = "lblLocalizacaoTextoEmailCautelas"
            Me.lblLocalizacaoTextoEmailCautelas.Size = New System.Drawing.Size(222, 13)
            Me.lblLocalizacaoTextoEmailCautelas.TabIndex = 14
            Me.lblLocalizacaoTextoEmailCautelas.Text = "Localização do Texto de E-mail das Cautelas:"
            '
            'txtLocalizacaoTextoEmailCautelas
            '
            Me.txtLocalizacaoTextoEmailCautelas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoTextoEmailCautelas.Location = New System.Drawing.Point(15, 140)
            Me.txtLocalizacaoTextoEmailCautelas.Multiline = True
            Me.txtLocalizacaoTextoEmailCautelas.Name = "txtLocalizacaoTextoEmailCautelas"
            Me.txtLocalizacaoTextoEmailCautelas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoTextoEmailCautelas.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoTextoEmailCautelas.TabIndex = 15
            '
            'lblMultiplicadorCodigoCautelas
            '
            Me.lblMultiplicadorCodigoCautelas.AutoSize = True
            Me.lblMultiplicadorCodigoCautelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblMultiplicadorCodigoCautelas.Location = New System.Drawing.Point(301, 271)
            Me.lblMultiplicadorCodigoCautelas.Name = "lblMultiplicadorCodigoCautelas"
            Me.lblMultiplicadorCodigoCautelas.Size = New System.Drawing.Size(120, 13)
            Me.lblMultiplicadorCodigoCautelas.TabIndex = 11
            Me.lblMultiplicadorCodigoCautelas.Text = "Multiplicador do Código:"
            '
            'txtMultiplicadorCodigoCautelas
            '
            Me.txtMultiplicadorCodigoCautelas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMultiplicadorCodigoCautelas.Location = New System.Drawing.Point(427, 269)
            Me.txtMultiplicadorCodigoCautelas.Name = "txtMultiplicadorCodigoCautelas"
            Me.txtMultiplicadorCodigoCautelas.Size = New System.Drawing.Size(132, 20)
            Me.txtMultiplicadorCodigoCautelas.TabIndex = 12
            '
            'lblNumeroLinhasCautelas
            '
            Me.lblNumeroLinhasCautelas.AutoSize = True
            Me.lblNumeroLinhasCautelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNumeroLinhasCautelas.Location = New System.Drawing.Point(288, 12)
            Me.lblNumeroLinhasCautelas.Name = "lblNumeroLinhasCautelas"
            Me.lblNumeroLinhasCautelas.Size = New System.Drawing.Size(133, 13)
            Me.lblNumeroLinhasCautelas.TabIndex = 4
            Me.lblNumeroLinhasCautelas.Text = "Numero de Linhas do Grid:"
            '
            'txtNumeroLinhasCautelas
            '
            Me.txtNumeroLinhasCautelas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNumeroLinhasCautelas.Location = New System.Drawing.Point(427, 12)
            Me.txtNumeroLinhasCautelas.Name = "txtNumeroLinhasCautelas"
            Me.txtNumeroLinhasCautelas.Size = New System.Drawing.Size(132, 20)
            Me.txtNumeroLinhasCautelas.TabIndex = 5
            '
            'btnLocalizacaoRelatorioCautelas
            '
            Me.btnLocalizacaoRelatorioCautelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoRelatorioCautelas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoRelatorioCautelas.Location = New System.Drawing.Point(526, 112)
            Me.btnLocalizacaoRelatorioCautelas.Name = "btnLocalizacaoRelatorioCautelas"
            Me.btnLocalizacaoRelatorioCautelas.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoRelatorioCautelas.TabIndex = 8
            Me.btnLocalizacaoRelatorioCautelas.Text = "..."
            Me.btnLocalizacaoRelatorioCautelas.UseVisualStyleBackColor = True
            '
            'lblLocalizacaoRelatorioCautelas
            '
            Me.lblLocalizacaoRelatorioCautelas.AutoSize = True
            Me.lblLocalizacaoRelatorioCautelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoRelatorioCautelas.Location = New System.Drawing.Point(12, 48)
            Me.lblLocalizacaoRelatorioCautelas.Name = "lblLocalizacaoRelatorioCautelas"
            Me.lblLocalizacaoRelatorioCautelas.Size = New System.Drawing.Size(191, 13)
            Me.lblLocalizacaoRelatorioCautelas.TabIndex = 6
            Me.lblLocalizacaoRelatorioCautelas.Text = "Localização do Relatório das Cautelas:"
            '
            'txtLocalizacaoRelatorioCautelas
            '
            Me.txtLocalizacaoRelatorioCautelas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoRelatorioCautelas.Location = New System.Drawing.Point(15, 64)
            Me.txtLocalizacaoRelatorioCautelas.Multiline = True
            Me.txtLocalizacaoRelatorioCautelas.Name = "txtLocalizacaoRelatorioCautelas"
            Me.txtLocalizacaoRelatorioCautelas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoRelatorioCautelas.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoRelatorioCautelas.TabIndex = 7
            '
            'txtPrazoEntregaCautelas
            '
            Me.txtPrazoEntregaCautelas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPrazoEntregaCautelas.Location = New System.Drawing.Point(110, 9)
            Me.txtPrazoEntregaCautelas.Name = "txtPrazoEntregaCautelas"
            Me.txtPrazoEntregaCautelas.Size = New System.Drawing.Size(132, 20)
            Me.txtPrazoEntregaCautelas.TabIndex = 3
            '
            'lblPrazoEntregaCautelas
            '
            Me.lblPrazoEntregaCautelas.AutoSize = True
            Me.lblPrazoEntregaCautelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblPrazoEntregaCautelas.Location = New System.Drawing.Point(12, 12)
            Me.lblPrazoEntregaCautelas.Name = "lblPrazoEntregaCautelas"
            Me.lblPrazoEntregaCautelas.Size = New System.Drawing.Size(92, 13)
            Me.lblPrazoEntregaCautelas.TabIndex = 2
            Me.lblPrazoEntregaCautelas.Text = "Prazo de Entrega:"
            '
            'tabMBPs
            '
            Me.tabMBPs.Controls.Add(Me.btnLocalizacaoTextoEmailMBPs)
            Me.tabMBPs.Controls.Add(Me.lblLocalizacaoTextoEmailMBPs)
            Me.tabMBPs.Controls.Add(Me.txtLocalizacaoTextoEmailMBPs)
            Me.tabMBPs.Controls.Add(Me.lblMultiplicadorCodigoMBPs)
            Me.tabMBPs.Controls.Add(Me.txtMultiplicadorCodigoMBPs)
            Me.tabMBPs.Controls.Add(Me.lblNumeroLinhasMBPs)
            Me.tabMBPs.Controls.Add(Me.txtNumeroLinhasMBPs)
            Me.tabMBPs.Controls.Add(Me.btnLocalizacaoRelatorioMBPs)
            Me.tabMBPs.Controls.Add(Me.lblLocalizacaoRelatorioMBPs)
            Me.tabMBPs.Controls.Add(Me.txtLocalizacaoRelatorioMBPs)
            Me.tabMBPs.Controls.Add(Me.txtPrazoEmprestimo)
            Me.tabMBPs.Controls.Add(Me.lblPrazoEmprestimo)
            Me.tabMBPs.Location = New System.Drawing.Point(4, 25)
            Me.tabMBPs.Name = "tabMBPs"
            Me.tabMBPs.Size = New System.Drawing.Size(563, 292)
            Me.tabMBPs.TabIndex = 3
            Me.tabMBPs.Text = "MBPs"
            Me.tabMBPs.UseVisualStyleBackColor = True
            '
            'btnLocalizacaoTextoEmailMBPs
            '
            Me.btnLocalizacaoTextoEmailMBPs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoTextoEmailMBPs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoTextoEmailMBPs.Location = New System.Drawing.Point(526, 188)
            Me.btnLocalizacaoTextoEmailMBPs.Name = "btnLocalizacaoTextoEmailMBPs"
            Me.btnLocalizacaoTextoEmailMBPs.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoTextoEmailMBPs.TabIndex = 71
            Me.btnLocalizacaoTextoEmailMBPs.Text = "..."
            Me.btnLocalizacaoTextoEmailMBPs.UseVisualStyleBackColor = True
            '
            'lblLocalizacaoTextoEmailMBPs
            '
            Me.lblLocalizacaoTextoEmailMBPs.AutoSize = True
            Me.lblLocalizacaoTextoEmailMBPs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoTextoEmailMBPs.Location = New System.Drawing.Point(12, 124)
            Me.lblLocalizacaoTextoEmailMBPs.Name = "lblLocalizacaoTextoEmailMBPs"
            Me.lblLocalizacaoTextoEmailMBPs.Size = New System.Drawing.Size(209, 13)
            Me.lblLocalizacaoTextoEmailMBPs.TabIndex = 69
            Me.lblLocalizacaoTextoEmailMBPs.Text = "Localização do Texto de E-mail das MBPs:"
            '
            'txtLocalizacaoTextoEmailMBPs
            '
            Me.txtLocalizacaoTextoEmailMBPs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoTextoEmailMBPs.Location = New System.Drawing.Point(15, 140)
            Me.txtLocalizacaoTextoEmailMBPs.Multiline = True
            Me.txtLocalizacaoTextoEmailMBPs.Name = "txtLocalizacaoTextoEmailMBPs"
            Me.txtLocalizacaoTextoEmailMBPs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoTextoEmailMBPs.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoTextoEmailMBPs.TabIndex = 70
            '
            'lblMultiplicadorCodigoMBPs
            '
            Me.lblMultiplicadorCodigoMBPs.AutoSize = True
            Me.lblMultiplicadorCodigoMBPs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblMultiplicadorCodigoMBPs.Location = New System.Drawing.Point(301, 271)
            Me.lblMultiplicadorCodigoMBPs.Name = "lblMultiplicadorCodigoMBPs"
            Me.lblMultiplicadorCodigoMBPs.Size = New System.Drawing.Size(120, 13)
            Me.lblMultiplicadorCodigoMBPs.TabIndex = 67
            Me.lblMultiplicadorCodigoMBPs.Text = "Multiplicador do Código:"
            '
            'txtMultiplicadorCodigoMBPs
            '
            Me.txtMultiplicadorCodigoMBPs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMultiplicadorCodigoMBPs.Location = New System.Drawing.Point(427, 269)
            Me.txtMultiplicadorCodigoMBPs.Name = "txtMultiplicadorCodigoMBPs"
            Me.txtMultiplicadorCodigoMBPs.Size = New System.Drawing.Size(132, 20)
            Me.txtMultiplicadorCodigoMBPs.TabIndex = 68
            '
            'lblNumeroLinhasMBPs
            '
            Me.lblNumeroLinhasMBPs.AutoSize = True
            Me.lblNumeroLinhasMBPs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNumeroLinhasMBPs.Location = New System.Drawing.Point(288, 12)
            Me.lblNumeroLinhasMBPs.Name = "lblNumeroLinhasMBPs"
            Me.lblNumeroLinhasMBPs.Size = New System.Drawing.Size(133, 13)
            Me.lblNumeroLinhasMBPs.TabIndex = 4
            Me.lblNumeroLinhasMBPs.Text = "Numero de Linhas do Grid:"
            '
            'txtNumeroLinhasMBPs
            '
            Me.txtNumeroLinhasMBPs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNumeroLinhasMBPs.Location = New System.Drawing.Point(427, 12)
            Me.txtNumeroLinhasMBPs.Name = "txtNumeroLinhasMBPs"
            Me.txtNumeroLinhasMBPs.Size = New System.Drawing.Size(132, 20)
            Me.txtNumeroLinhasMBPs.TabIndex = 5
            '
            'btnLocalizacaoRelatorioMBPs
            '
            Me.btnLocalizacaoRelatorioMBPs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoRelatorioMBPs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoRelatorioMBPs.Location = New System.Drawing.Point(526, 112)
            Me.btnLocalizacaoRelatorioMBPs.Name = "btnLocalizacaoRelatorioMBPs"
            Me.btnLocalizacaoRelatorioMBPs.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoRelatorioMBPs.TabIndex = 7
            Me.btnLocalizacaoRelatorioMBPs.Text = "..."
            Me.btnLocalizacaoRelatorioMBPs.UseVisualStyleBackColor = True
            '
            'lblLocalizacaoRelatorioMBPs
            '
            Me.lblLocalizacaoRelatorioMBPs.AutoSize = True
            Me.lblLocalizacaoRelatorioMBPs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoRelatorioMBPs.Location = New System.Drawing.Point(12, 48)
            Me.lblLocalizacaoRelatorioMBPs.Name = "lblLocalizacaoRelatorioMBPs"
            Me.lblLocalizacaoRelatorioMBPs.Size = New System.Drawing.Size(178, 13)
            Me.lblLocalizacaoRelatorioMBPs.TabIndex = 66
            Me.lblLocalizacaoRelatorioMBPs.Text = "Localização do Relatório das MBPs:"
            '
            'txtLocalizacaoRelatorioMBPs
            '
            Me.txtLocalizacaoRelatorioMBPs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoRelatorioMBPs.Location = New System.Drawing.Point(15, 64)
            Me.txtLocalizacaoRelatorioMBPs.Multiline = True
            Me.txtLocalizacaoRelatorioMBPs.Name = "txtLocalizacaoRelatorioMBPs"
            Me.txtLocalizacaoRelatorioMBPs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoRelatorioMBPs.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoRelatorioMBPs.TabIndex = 6
            '
            'txtPrazoEmprestimo
            '
            Me.txtPrazoEmprestimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPrazoEmprestimo.Location = New System.Drawing.Point(127, 9)
            Me.txtPrazoEmprestimo.Name = "txtPrazoEmprestimo"
            Me.txtPrazoEmprestimo.Size = New System.Drawing.Size(132, 20)
            Me.txtPrazoEmprestimo.TabIndex = 3
            '
            'lblPrazoEmprestimo
            '
            Me.lblPrazoEmprestimo.AutoSize = True
            Me.lblPrazoEmprestimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblPrazoEmprestimo.Location = New System.Drawing.Point(12, 12)
            Me.lblPrazoEmprestimo.Name = "lblPrazoEmprestimo"
            Me.lblPrazoEmprestimo.Size = New System.Drawing.Size(109, 13)
            Me.lblPrazoEmprestimo.TabIndex = 2
            Me.lblPrazoEmprestimo.Text = "Prazo de Emprestimo:"
            '
            'tabInventarioBens
            '
            Me.tabInventarioBens.Controls.Add(Me.btnLocalizacaoTextoEmailInventarioBens)
            Me.tabInventarioBens.Controls.Add(Me.lblLocalizacaoTextoEmailInventarioBens)
            Me.tabInventarioBens.Controls.Add(Me.txtLocalizacaoTextoEmailInventarioBens)
            Me.tabInventarioBens.Controls.Add(Me.lblMultiplicadorCodigoInventarioBens)
            Me.tabInventarioBens.Controls.Add(Me.txtMultiplicadorCodigoInventarioBens)
            Me.tabInventarioBens.Controls.Add(Me.chbAtualizarData)
            Me.tabInventarioBens.Controls.Add(Me.lblNumeroLinhasInventarioBens)
            Me.tabInventarioBens.Controls.Add(Me.txtNumeroLinhasInventarioBens)
            Me.tabInventarioBens.Controls.Add(Me.btnLocalizacaoRelatorioInventarioBens)
            Me.tabInventarioBens.Controls.Add(Me.lblLocalizacaoRelatorioInventarioBens)
            Me.tabInventarioBens.Controls.Add(Me.txtLocalizacaoRelatorioInventarioBens)
            Me.tabInventarioBens.Location = New System.Drawing.Point(4, 25)
            Me.tabInventarioBens.Name = "tabInventarioBens"
            Me.tabInventarioBens.Size = New System.Drawing.Size(563, 292)
            Me.tabInventarioBens.TabIndex = 9
            Me.tabInventarioBens.Text = "Inventário Bens"
            Me.tabInventarioBens.UseVisualStyleBackColor = True
            '
            'btnLocalizacaoTextoEmailInventarioBens
            '
            Me.btnLocalizacaoTextoEmailInventarioBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoTextoEmailInventarioBens.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoTextoEmailInventarioBens.Location = New System.Drawing.Point(526, 188)
            Me.btnLocalizacaoTextoEmailInventarioBens.Name = "btnLocalizacaoTextoEmailInventarioBens"
            Me.btnLocalizacaoTextoEmailInventarioBens.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoTextoEmailInventarioBens.TabIndex = 73
            Me.btnLocalizacaoTextoEmailInventarioBens.Text = "..."
            Me.btnLocalizacaoTextoEmailInventarioBens.UseVisualStyleBackColor = True
            '
            'lblLocalizacaoTextoEmailInventarioBens
            '
            Me.lblLocalizacaoTextoEmailInventarioBens.AutoSize = True
            Me.lblLocalizacaoTextoEmailInventarioBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoTextoEmailInventarioBens.Location = New System.Drawing.Point(12, 124)
            Me.lblLocalizacaoTextoEmailInventarioBens.Name = "lblLocalizacaoTextoEmailInventarioBens"
            Me.lblLocalizacaoTextoEmailInventarioBens.Size = New System.Drawing.Size(265, 13)
            Me.lblLocalizacaoTextoEmailInventarioBens.TabIndex = 71
            Me.lblLocalizacaoTextoEmailInventarioBens.Text = "Localização do Texto de E-mail do Inventário de Bens:"
            '
            'txtLocalizacaoTextoEmailInventarioBens
            '
            Me.txtLocalizacaoTextoEmailInventarioBens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoTextoEmailInventarioBens.Location = New System.Drawing.Point(15, 140)
            Me.txtLocalizacaoTextoEmailInventarioBens.Multiline = True
            Me.txtLocalizacaoTextoEmailInventarioBens.Name = "txtLocalizacaoTextoEmailInventarioBens"
            Me.txtLocalizacaoTextoEmailInventarioBens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoTextoEmailInventarioBens.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoTextoEmailInventarioBens.TabIndex = 72
            '
            'lblMultiplicadorCodigoInventarioBens
            '
            Me.lblMultiplicadorCodigoInventarioBens.AutoSize = True
            Me.lblMultiplicadorCodigoInventarioBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblMultiplicadorCodigoInventarioBens.Location = New System.Drawing.Point(301, 271)
            Me.lblMultiplicadorCodigoInventarioBens.Name = "lblMultiplicadorCodigoInventarioBens"
            Me.lblMultiplicadorCodigoInventarioBens.Size = New System.Drawing.Size(120, 13)
            Me.lblMultiplicadorCodigoInventarioBens.TabIndex = 69
            Me.lblMultiplicadorCodigoInventarioBens.Text = "Multiplicador do Código:"
            '
            'txtMultiplicadorCodigoInventarioBens
            '
            Me.txtMultiplicadorCodigoInventarioBens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMultiplicadorCodigoInventarioBens.Location = New System.Drawing.Point(427, 269)
            Me.txtMultiplicadorCodigoInventarioBens.Name = "txtMultiplicadorCodigoInventarioBens"
            Me.txtMultiplicadorCodigoInventarioBens.Size = New System.Drawing.Size(132, 20)
            Me.txtMultiplicadorCodigoInventarioBens.TabIndex = 70
            '
            'chbAtualizarData
            '
            Me.chbAtualizarData.AutoSize = True
            Me.chbAtualizarData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.chbAtualizarData.Location = New System.Drawing.Point(15, 12)
            Me.chbAtualizarData.Name = "chbAtualizarData"
            Me.chbAtualizarData.Size = New System.Drawing.Size(89, 17)
            Me.chbAtualizarData.TabIndex = 2
            Me.chbAtualizarData.Text = "Atualizar Data"
            Me.chbAtualizarData.UseVisualStyleBackColor = True
            '
            'lblNumeroLinhasInventarioBens
            '
            Me.lblNumeroLinhasInventarioBens.AutoSize = True
            Me.lblNumeroLinhasInventarioBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNumeroLinhasInventarioBens.Location = New System.Drawing.Point(288, 12)
            Me.lblNumeroLinhasInventarioBens.Name = "lblNumeroLinhasInventarioBens"
            Me.lblNumeroLinhasInventarioBens.Size = New System.Drawing.Size(133, 13)
            Me.lblNumeroLinhasInventarioBens.TabIndex = 3
            Me.lblNumeroLinhasInventarioBens.Text = "Numero de Linhas do Grid:"
            '
            'txtNumeroLinhasInventarioBens
            '
            Me.txtNumeroLinhasInventarioBens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNumeroLinhasInventarioBens.Location = New System.Drawing.Point(427, 12)
            Me.txtNumeroLinhasInventarioBens.Name = "txtNumeroLinhasInventarioBens"
            Me.txtNumeroLinhasInventarioBens.Size = New System.Drawing.Size(132, 20)
            Me.txtNumeroLinhasInventarioBens.TabIndex = 4
            '
            'btnLocalizacaoRelatorioInventarioBens
            '
            Me.btnLocalizacaoRelatorioInventarioBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoRelatorioInventarioBens.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoRelatorioInventarioBens.Location = New System.Drawing.Point(526, 112)
            Me.btnLocalizacaoRelatorioInventarioBens.Name = "btnLocalizacaoRelatorioInventarioBens"
            Me.btnLocalizacaoRelatorioInventarioBens.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoRelatorioInventarioBens.TabIndex = 7
            Me.btnLocalizacaoRelatorioInventarioBens.Text = "..."
            Me.btnLocalizacaoRelatorioInventarioBens.UseVisualStyleBackColor = True
            '
            'lblLocalizacaoRelatorioInventarioBens
            '
            Me.lblLocalizacaoRelatorioInventarioBens.AutoSize = True
            Me.lblLocalizacaoRelatorioInventarioBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoRelatorioInventarioBens.Location = New System.Drawing.Point(12, 48)
            Me.lblLocalizacaoRelatorioInventarioBens.Name = "lblLocalizacaoRelatorioInventarioBens"
            Me.lblLocalizacaoRelatorioInventarioBens.Size = New System.Drawing.Size(234, 13)
            Me.lblLocalizacaoRelatorioInventarioBens.TabIndex = 5
            Me.lblLocalizacaoRelatorioInventarioBens.Text = "Localização do Relatório do Inventário de Bens:"
            '
            'txtLocalizacaoRelatorioInventarioBens
            '
            Me.txtLocalizacaoRelatorioInventarioBens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoRelatorioInventarioBens.Location = New System.Drawing.Point(15, 64)
            Me.txtLocalizacaoRelatorioInventarioBens.Multiline = True
            Me.txtLocalizacaoRelatorioInventarioBens.Name = "txtLocalizacaoRelatorioInventarioBens"
            Me.txtLocalizacaoRelatorioInventarioBens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoRelatorioInventarioBens.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoRelatorioInventarioBens.TabIndex = 6
            '
            'tabBens
            '
            Me.tabBens.Controls.Add(Me.btnLocalizacaoTextoEmailBens)
            Me.tabBens.Controls.Add(Me.lblLocalizacaoTextoEmailBens)
            Me.tabBens.Controls.Add(Me.txtLocalizacaoTextoEmailBens)
            Me.tabBens.Controls.Add(Me.lblNumeroLinhasBens)
            Me.tabBens.Controls.Add(Me.txtNumeroLinhasBens)
            Me.tabBens.Controls.Add(Me.btnLocalizacaoRelatorioBens)
            Me.tabBens.Controls.Add(Me.lblLocalizacaoRelatorioBens)
            Me.tabBens.Controls.Add(Me.txtLocalizacaoRelatorioBens)
            Me.tabBens.Location = New System.Drawing.Point(4, 25)
            Me.tabBens.Name = "tabBens"
            Me.tabBens.Size = New System.Drawing.Size(563, 292)
            Me.tabBens.TabIndex = 11
            Me.tabBens.Text = "Bens"
            Me.tabBens.UseVisualStyleBackColor = True
            '
            'btnLocalizacaoTextoEmailBens
            '
            Me.btnLocalizacaoTextoEmailBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoTextoEmailBens.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoTextoEmailBens.Location = New System.Drawing.Point(526, 188)
            Me.btnLocalizacaoTextoEmailBens.Name = "btnLocalizacaoTextoEmailBens"
            Me.btnLocalizacaoTextoEmailBens.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoTextoEmailBens.TabIndex = 84
            Me.btnLocalizacaoTextoEmailBens.Text = "..."
            Me.btnLocalizacaoTextoEmailBens.UseVisualStyleBackColor = True
            '
            'lblLocalizacaoTextoEmailBens
            '
            Me.lblLocalizacaoTextoEmailBens.AutoSize = True
            Me.lblLocalizacaoTextoEmailBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoTextoEmailBens.Location = New System.Drawing.Point(12, 124)
            Me.lblLocalizacaoTextoEmailBens.Name = "lblLocalizacaoTextoEmailBens"
            Me.lblLocalizacaoTextoEmailBens.Size = New System.Drawing.Size(265, 13)
            Me.lblLocalizacaoTextoEmailBens.TabIndex = 82
            Me.lblLocalizacaoTextoEmailBens.Text = "Localização do Texto de E-mail do Inventário de Bens:"
            '
            'txtLocalizacaoTextoEmailBens
            '
            Me.txtLocalizacaoTextoEmailBens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoTextoEmailBens.Location = New System.Drawing.Point(15, 140)
            Me.txtLocalizacaoTextoEmailBens.Multiline = True
            Me.txtLocalizacaoTextoEmailBens.Name = "txtLocalizacaoTextoEmailBens"
            Me.txtLocalizacaoTextoEmailBens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoTextoEmailBens.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoTextoEmailBens.TabIndex = 83
            '
            'lblNumeroLinhasBens
            '
            Me.lblNumeroLinhasBens.AutoSize = True
            Me.lblNumeroLinhasBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNumeroLinhasBens.Location = New System.Drawing.Point(288, 12)
            Me.lblNumeroLinhasBens.Name = "lblNumeroLinhasBens"
            Me.lblNumeroLinhasBens.Size = New System.Drawing.Size(133, 13)
            Me.lblNumeroLinhasBens.TabIndex = 75
            Me.lblNumeroLinhasBens.Text = "Numero de Linhas do Grid:"
            '
            'txtNumeroLinhasBens
            '
            Me.txtNumeroLinhasBens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNumeroLinhasBens.Location = New System.Drawing.Point(427, 12)
            Me.txtNumeroLinhasBens.Name = "txtNumeroLinhasBens"
            Me.txtNumeroLinhasBens.Size = New System.Drawing.Size(132, 20)
            Me.txtNumeroLinhasBens.TabIndex = 76
            '
            'btnLocalizacaoRelatorioBens
            '
            Me.btnLocalizacaoRelatorioBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLocalizacaoRelatorioBens.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLocalizacaoRelatorioBens.Location = New System.Drawing.Point(526, 112)
            Me.btnLocalizacaoRelatorioBens.Name = "btnLocalizacaoRelatorioBens"
            Me.btnLocalizacaoRelatorioBens.Size = New System.Drawing.Size(33, 22)
            Me.btnLocalizacaoRelatorioBens.TabIndex = 79
            Me.btnLocalizacaoRelatorioBens.Text = "..."
            Me.btnLocalizacaoRelatorioBens.UseVisualStyleBackColor = True
            '
            'lblLocalizacaoRelatorioBens
            '
            Me.lblLocalizacaoRelatorioBens.AutoSize = True
            Me.lblLocalizacaoRelatorioBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblLocalizacaoRelatorioBens.Location = New System.Drawing.Point(12, 48)
            Me.lblLocalizacaoRelatorioBens.Name = "lblLocalizacaoRelatorioBens"
            Me.lblLocalizacaoRelatorioBens.Size = New System.Drawing.Size(234, 13)
            Me.lblLocalizacaoRelatorioBens.TabIndex = 77
            Me.lblLocalizacaoRelatorioBens.Text = "Localização do Relatório do Inventário de Bens:"
            '
            'txtLocalizacaoRelatorioBens
            '
            Me.txtLocalizacaoRelatorioBens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLocalizacaoRelatorioBens.Location = New System.Drawing.Point(15, 64)
            Me.txtLocalizacaoRelatorioBens.Multiline = True
            Me.txtLocalizacaoRelatorioBens.Name = "txtLocalizacaoRelatorioBens"
            Me.txtLocalizacaoRelatorioBens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtLocalizacaoRelatorioBens.Size = New System.Drawing.Size(544, 42)
            Me.txtLocalizacaoRelatorioBens.TabIndex = 78
            '
            'tabTRG
            '
            Me.tabTRG.Controls.Add(Me.btnDefinir)
            Me.tabTRG.Controls.Add(Me.lblOrgaoGeralBens)
            Me.tabTRG.Controls.Add(Me.txtOrgaoResponsavelGeralBens)
            Me.tabTRG.Controls.Add(Me.txtMatriculaResponsavelGeralBens)
            Me.tabTRG.Controls.Add(Me.lblMatriculaResponsavelGeralBens)
            Me.tabTRG.Controls.Add(Me.txtNumeroTermoResponsavelGeralBens)
            Me.tabTRG.Controls.Add(Me.lblNumeroTermoResponsavelGeralBens)
            Me.tabTRG.Controls.Add(Me.lsvTRG)
            Me.tabTRG.Controls.Add(Me.txtNomeResponsavelGeralBens)
            Me.tabTRG.Controls.Add(Me.lblNomeResponsavelGeralBens)
            Me.tabTRG.Location = New System.Drawing.Point(4, 25)
            Me.tabTRG.Name = "tabTRG"
            Me.tabTRG.Size = New System.Drawing.Size(563, 292)
            Me.tabTRG.TabIndex = 4
            Me.tabTRG.Text = "TRG"
            Me.tabTRG.UseVisualStyleBackColor = True
            '
            'btnDefinir
            '
            Me.btnDefinir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDefinir.Location = New System.Drawing.Point(486, 61)
            Me.btnDefinir.Name = "btnDefinir"
            Me.btnDefinir.Size = New System.Drawing.Size(68, 23)
            Me.btnDefinir.TabIndex = 10
            Me.btnDefinir.Text = "&Definir"
            Me.btnDefinir.UseVisualStyleBackColor = True
            '
            'lblOrgaoGeralBens
            '
            Me.lblOrgaoGeralBens.AutoSize = True
            Me.lblOrgaoGeralBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblOrgaoGeralBens.Location = New System.Drawing.Point(171, 64)
            Me.lblOrgaoGeralBens.Name = "lblOrgaoGeralBens"
            Me.lblOrgaoGeralBens.Size = New System.Drawing.Size(193, 13)
            Me.lblOrgaoGeralBens.TabIndex = 8
            Me.lblOrgaoGeralBens.Text = "Órgão do Responsável Geral dos bens:"
            '
            'txtOrgaoResponsavelGeralBens
            '
            Me.txtOrgaoResponsavelGeralBens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOrgaoResponsavelGeralBens.Location = New System.Drawing.Point(369, 61)
            Me.txtOrgaoResponsavelGeralBens.Name = "txtOrgaoResponsavelGeralBens"
            Me.txtOrgaoResponsavelGeralBens.Size = New System.Drawing.Size(111, 20)
            Me.txtOrgaoResponsavelGeralBens.TabIndex = 9
            '
            'txtMatriculaResponsavelGeralBens
            '
            Me.txtMatriculaResponsavelGeralBens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMatriculaResponsavelGeralBens.Location = New System.Drawing.Point(227, 9)
            Me.txtMatriculaResponsavelGeralBens.Name = "txtMatriculaResponsavelGeralBens"
            Me.txtMatriculaResponsavelGeralBens.Size = New System.Drawing.Size(132, 20)
            Me.txtMatriculaResponsavelGeralBens.TabIndex = 3
            '
            'lblMatriculaResponsavelGeralBens
            '
            Me.lblMatriculaResponsavelGeralBens.AutoSize = True
            Me.lblMatriculaResponsavelGeralBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblMatriculaResponsavelGeralBens.Location = New System.Drawing.Point(12, 13)
            Me.lblMatriculaResponsavelGeralBens.Name = "lblMatriculaResponsavelGeralBens"
            Me.lblMatriculaResponsavelGeralBens.Size = New System.Drawing.Size(209, 13)
            Me.lblMatriculaResponsavelGeralBens.TabIndex = 2
            Me.lblMatriculaResponsavelGeralBens.Text = "Matrícula do Responsável Geral dos bens:"
            '
            'txtNumeroTermoResponsavelGeralBens
            '
            Me.txtNumeroTermoResponsavelGeralBens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNumeroTermoResponsavelGeralBens.Location = New System.Drawing.Point(444, 9)
            Me.txtNumeroTermoResponsavelGeralBens.Name = "txtNumeroTermoResponsavelGeralBens"
            Me.txtNumeroTermoResponsavelGeralBens.Size = New System.Drawing.Size(111, 20)
            Me.txtNumeroTermoResponsavelGeralBens.TabIndex = 5
            '
            'lblNumeroTermoResponsavelGeralBens
            '
            Me.lblNumeroTermoResponsavelGeralBens.AutoSize = True
            Me.lblNumeroTermoResponsavelGeralBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNumeroTermoResponsavelGeralBens.Location = New System.Drawing.Point(365, 12)
            Me.lblNumeroTermoResponsavelGeralBens.Name = "lblNumeroTermoResponsavelGeralBens"
            Me.lblNumeroTermoResponsavelGeralBens.Size = New System.Drawing.Size(73, 13)
            Me.lblNumeroTermoResponsavelGeralBens.TabIndex = 4
            Me.lblNumeroTermoResponsavelGeralBens.Text = "Número TRG:"
            '
            'lsvTRG
            '
            Me.lsvTRG.BackColor = System.Drawing.Color.GhostWhite
            Me.lsvTRG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lsvTRG.Location = New System.Drawing.Point(15, 87)
            Me.lsvTRG.Name = "lsvTRG"
            Me.lsvTRG.Size = New System.Drawing.Size(540, 202)
            Me.lsvTRG.TabIndex = 11
            Me.lsvTRG.UseCompatibleStateImageBehavior = False
            '
            'txtNomeResponsavelGeralBens
            '
            Me.txtNomeResponsavelGeralBens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNomeResponsavelGeralBens.Location = New System.Drawing.Point(227, 35)
            Me.txtNomeResponsavelGeralBens.Name = "txtNomeResponsavelGeralBens"
            Me.txtNomeResponsavelGeralBens.Size = New System.Drawing.Size(328, 20)
            Me.txtNomeResponsavelGeralBens.TabIndex = 7
            '
            'lblNomeResponsavelGeralBens
            '
            Me.lblNomeResponsavelGeralBens.AutoSize = True
            Me.lblNomeResponsavelGeralBens.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNomeResponsavelGeralBens.Location = New System.Drawing.Point(12, 38)
            Me.lblNomeResponsavelGeralBens.Name = "lblNomeResponsavelGeralBens"
            Me.lblNomeResponsavelGeralBens.Size = New System.Drawing.Size(192, 13)
            Me.lblNomeResponsavelGeralBens.TabIndex = 6
            Me.lblNomeResponsavelGeralBens.Text = "Nome do Responsável Geral dos bens:"
            '
            'tabEmail
            '
            Me.tabEmail.Controls.Add(Me.tbcEmail)
            Me.tabEmail.Location = New System.Drawing.Point(4, 25)
            Me.tabEmail.Name = "tabEmail"
            Me.tabEmail.Size = New System.Drawing.Size(563, 292)
            Me.tabEmail.TabIndex = 10
            Me.tabEmail.Text = "E-mail"
            Me.tabEmail.UseVisualStyleBackColor = True
            '
            'tbcEmail
            '
            Me.tbcEmail.Controls.Add(Me.tbpGeral)
            Me.tbcEmail.Controls.Add(Me.tbpCarteiras)
            Me.tbcEmail.Controls.Add(Me.tbpCautelas)
            Me.tbcEmail.Controls.Add(Me.tbpMBPs)
            Me.tbcEmail.Controls.Add(Me.tbpInventarioBens)
            Me.tbcEmail.Controls.Add(Me.tbpBens)
            Me.tbcEmail.Location = New System.Drawing.Point(3, 3)
            Me.tbcEmail.Name = "tbcEmail"
            Me.tbcEmail.SelectedIndex = 0
            Me.tbcEmail.Size = New System.Drawing.Size(557, 286)
            Me.tbcEmail.TabIndex = 2
            '
            'tbpGeral
            '
            Me.tbpGeral.Controls.Add(Me.grbConfiguraçõesGeral)
            Me.tbpGeral.Location = New System.Drawing.Point(4, 22)
            Me.tbpGeral.Name = "tbpGeral"
            Me.tbpGeral.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpGeral.Size = New System.Drawing.Size(549, 260)
            Me.tbpGeral.TabIndex = 0
            Me.tbpGeral.Text = "Geral"
            Me.tbpGeral.UseVisualStyleBackColor = True
            '
            'grbConfiguraçõesGeral
            '
            Me.grbConfiguraçõesGeral.Controls.Add(Me.grpExportacaoRelatorios)
            Me.grbConfiguraçõesGeral.Controls.Add(Me.grpConfiguracoesEmail)
            Me.grbConfiguraçõesGeral.Location = New System.Drawing.Point(6, 6)
            Me.grbConfiguraçõesGeral.Name = "grbConfiguraçõesGeral"
            Me.grbConfiguraçõesGeral.Size = New System.Drawing.Size(537, 248)
            Me.grbConfiguraçõesGeral.TabIndex = 0
            Me.grbConfiguraçõesGeral.TabStop = False
            Me.grbConfiguraçõesGeral.Text = "Configurações Gerais"
            '
            'grpExportacaoRelatorios
            '
            Me.grpExportacaoRelatorios.Controls.Add(Me.grbRelatorioBens)
            Me.grpExportacaoRelatorios.Controls.Add(Me.grbRelatorioInventarioBens)
            Me.grpExportacaoRelatorios.Controls.Add(Me.grbRelatorioMBPs)
            Me.grpExportacaoRelatorios.Controls.Add(Me.grbRelatorioCautelas)
            Me.grpExportacaoRelatorios.Controls.Add(Me.grbRelatorioCarteira)
            Me.grpExportacaoRelatorios.Location = New System.Drawing.Point(5, 100)
            Me.grpExportacaoRelatorios.Name = "grpExportacaoRelatorios"
            Me.grpExportacaoRelatorios.Size = New System.Drawing.Size(525, 142)
            Me.grpExportacaoRelatorios.TabIndex = 10
            Me.grpExportacaoRelatorios.TabStop = False
            Me.grpExportacaoRelatorios.Text = "Exportação de Relatórios"
            '
            'grbRelatorioBens
            '
            Me.grbRelatorioBens.Controls.Add(Me.rbtDOCBens)
            Me.grbRelatorioBens.Controls.Add(Me.rbtPDFBens)
            Me.grbRelatorioBens.Location = New System.Drawing.Point(418, 19)
            Me.grbRelatorioBens.Name = "grbRelatorioBens"
            Me.grbRelatorioBens.Size = New System.Drawing.Size(101, 94)
            Me.grbRelatorioBens.TabIndex = 4
            Me.grbRelatorioBens.TabStop = False
            Me.grbRelatorioBens.Text = "Bens"
            '
            'rbtDOCBens
            '
            Me.rbtDOCBens.AutoSize = True
            Me.rbtDOCBens.Location = New System.Drawing.Point(6, 50)
            Me.rbtDOCBens.Name = "rbtDOCBens"
            Me.rbtDOCBens.Size = New System.Drawing.Size(48, 17)
            Me.rbtDOCBens.TabIndex = 1
            Me.rbtDOCBens.TabStop = True
            Me.rbtDOCBens.Text = "DOC"
            Me.rbtDOCBens.UseVisualStyleBackColor = True
            '
            'rbtPDFBens
            '
            Me.rbtPDFBens.AutoSize = True
            Me.rbtPDFBens.Location = New System.Drawing.Point(6, 19)
            Me.rbtPDFBens.Name = "rbtPDFBens"
            Me.rbtPDFBens.Size = New System.Drawing.Size(46, 17)
            Me.rbtPDFBens.TabIndex = 0
            Me.rbtPDFBens.TabStop = True
            Me.rbtPDFBens.Text = "PDF"
            Me.rbtPDFBens.UseVisualStyleBackColor = True
            '
            'grbRelatorioInventarioBens
            '
            Me.grbRelatorioInventarioBens.Controls.Add(Me.rbtDOCInventarioBens)
            Me.grbRelatorioInventarioBens.Controls.Add(Me.rbtPDFInventarioBens)
            Me.grbRelatorioInventarioBens.Location = New System.Drawing.Point(212, 69)
            Me.grbRelatorioInventarioBens.Name = "grbRelatorioInventarioBens"
            Me.grbRelatorioInventarioBens.Size = New System.Drawing.Size(200, 44)
            Me.grbRelatorioInventarioBens.TabIndex = 3
            Me.grbRelatorioInventarioBens.TabStop = False
            Me.grbRelatorioInventarioBens.Text = "Inventário de Bens"
            '
            'rbtDOCInventarioBens
            '
            Me.rbtDOCInventarioBens.AutoSize = True
            Me.rbtDOCInventarioBens.Location = New System.Drawing.Point(96, 19)
            Me.rbtDOCInventarioBens.Name = "rbtDOCInventarioBens"
            Me.rbtDOCInventarioBens.Size = New System.Drawing.Size(48, 17)
            Me.rbtDOCInventarioBens.TabIndex = 1
            Me.rbtDOCInventarioBens.TabStop = True
            Me.rbtDOCInventarioBens.Text = "DOC"
            Me.rbtDOCInventarioBens.UseVisualStyleBackColor = True
            '
            'rbtPDFInventarioBens
            '
            Me.rbtPDFInventarioBens.AutoSize = True
            Me.rbtPDFInventarioBens.Location = New System.Drawing.Point(6, 19)
            Me.rbtPDFInventarioBens.Name = "rbtPDFInventarioBens"
            Me.rbtPDFInventarioBens.Size = New System.Drawing.Size(46, 17)
            Me.rbtPDFInventarioBens.TabIndex = 0
            Me.rbtPDFInventarioBens.TabStop = True
            Me.rbtPDFInventarioBens.Text = "PDF"
            Me.rbtPDFInventarioBens.UseVisualStyleBackColor = True
            '
            'grbRelatorioMBPs
            '
            Me.grbRelatorioMBPs.Controls.Add(Me.rbtDOCMBP)
            Me.grbRelatorioMBPs.Controls.Add(Me.rbtPDFMBP)
            Me.grbRelatorioMBPs.Location = New System.Drawing.Point(212, 19)
            Me.grbRelatorioMBPs.Name = "grbRelatorioMBPs"
            Me.grbRelatorioMBPs.Size = New System.Drawing.Size(200, 44)
            Me.grbRelatorioMBPs.TabIndex = 3
            Me.grbRelatorioMBPs.TabStop = False
            Me.grbRelatorioMBPs.Text = "MBPs"
            '
            'rbtDOCMBP
            '
            Me.rbtDOCMBP.AutoSize = True
            Me.rbtDOCMBP.Location = New System.Drawing.Point(96, 19)
            Me.rbtDOCMBP.Name = "rbtDOCMBP"
            Me.rbtDOCMBP.Size = New System.Drawing.Size(48, 17)
            Me.rbtDOCMBP.TabIndex = 1
            Me.rbtDOCMBP.TabStop = True
            Me.rbtDOCMBP.Text = "DOC"
            Me.rbtDOCMBP.UseVisualStyleBackColor = True
            '
            'rbtPDFMBP
            '
            Me.rbtPDFMBP.AutoSize = True
            Me.rbtPDFMBP.Location = New System.Drawing.Point(6, 19)
            Me.rbtPDFMBP.Name = "rbtPDFMBP"
            Me.rbtPDFMBP.Size = New System.Drawing.Size(46, 17)
            Me.rbtPDFMBP.TabIndex = 0
            Me.rbtPDFMBP.TabStop = True
            Me.rbtPDFMBP.Text = "PDF"
            Me.rbtPDFMBP.UseVisualStyleBackColor = True
            '
            'grbRelatorioCautelas
            '
            Me.grbRelatorioCautelas.Controls.Add(Me.rbtDOCCautela)
            Me.grbRelatorioCautelas.Controls.Add(Me.rbtPDFCautela)
            Me.grbRelatorioCautelas.Location = New System.Drawing.Point(6, 69)
            Me.grbRelatorioCautelas.Name = "grbRelatorioCautelas"
            Me.grbRelatorioCautelas.Size = New System.Drawing.Size(200, 44)
            Me.grbRelatorioCautelas.TabIndex = 2
            Me.grbRelatorioCautelas.TabStop = False
            Me.grbRelatorioCautelas.Text = "Cautelas"
            '
            'rbtDOCCautela
            '
            Me.rbtDOCCautela.AutoSize = True
            Me.rbtDOCCautela.Location = New System.Drawing.Point(96, 19)
            Me.rbtDOCCautela.Name = "rbtDOCCautela"
            Me.rbtDOCCautela.Size = New System.Drawing.Size(48, 17)
            Me.rbtDOCCautela.TabIndex = 1
            Me.rbtDOCCautela.TabStop = True
            Me.rbtDOCCautela.Text = "DOC"
            Me.rbtDOCCautela.UseVisualStyleBackColor = True
            '
            'rbtPDFCautela
            '
            Me.rbtPDFCautela.AutoSize = True
            Me.rbtPDFCautela.Location = New System.Drawing.Point(6, 19)
            Me.rbtPDFCautela.Name = "rbtPDFCautela"
            Me.rbtPDFCautela.Size = New System.Drawing.Size(46, 17)
            Me.rbtPDFCautela.TabIndex = 0
            Me.rbtPDFCautela.TabStop = True
            Me.rbtPDFCautela.Text = "PDF"
            Me.rbtPDFCautela.UseVisualStyleBackColor = True
            '
            'grbRelatorioCarteira
            '
            Me.grbRelatorioCarteira.Controls.Add(Me.rbtDOCCarteira)
            Me.grbRelatorioCarteira.Controls.Add(Me.rbtPDFCarteira)
            Me.grbRelatorioCarteira.Location = New System.Drawing.Point(6, 19)
            Me.grbRelatorioCarteira.Name = "grbRelatorioCarteira"
            Me.grbRelatorioCarteira.Size = New System.Drawing.Size(200, 44)
            Me.grbRelatorioCarteira.TabIndex = 0
            Me.grbRelatorioCarteira.TabStop = False
            Me.grbRelatorioCarteira.Text = "Carteiras"
            '
            'rbtDOCCarteira
            '
            Me.rbtDOCCarteira.AutoSize = True
            Me.rbtDOCCarteira.Location = New System.Drawing.Point(96, 19)
            Me.rbtDOCCarteira.Name = "rbtDOCCarteira"
            Me.rbtDOCCarteira.Size = New System.Drawing.Size(48, 17)
            Me.rbtDOCCarteira.TabIndex = 1
            Me.rbtDOCCarteira.TabStop = True
            Me.rbtDOCCarteira.Text = "DOC"
            Me.rbtDOCCarteira.UseVisualStyleBackColor = True
            '
            'rbtPDFCarteira
            '
            Me.rbtPDFCarteira.AutoSize = True
            Me.rbtPDFCarteira.Location = New System.Drawing.Point(6, 19)
            Me.rbtPDFCarteira.Name = "rbtPDFCarteira"
            Me.rbtPDFCarteira.Size = New System.Drawing.Size(46, 17)
            Me.rbtPDFCarteira.TabIndex = 0
            Me.rbtPDFCarteira.TabStop = True
            Me.rbtPDFCarteira.Text = "PDF"
            Me.rbtPDFCarteira.UseVisualStyleBackColor = True
            '
            'grpConfiguracoesEmail
            '
            Me.grpConfiguracoesEmail.Controls.Add(Me.txtDe)
            Me.grpConfiguracoesEmail.Controls.Add(Me.lblDe)
            Me.grpConfiguracoesEmail.Controls.Add(Me.txtMostrar)
            Me.grpConfiguracoesEmail.Controls.Add(Me.lblMostrar)
            Me.grpConfiguracoesEmail.Controls.Add(Me.txtServidorSMTP)
            Me.grpConfiguracoesEmail.Controls.Add(Me.lblServidorSMTP)
            Me.grpConfiguracoesEmail.Location = New System.Drawing.Point(6, 19)
            Me.grpConfiguracoesEmail.Name = "grpConfiguracoesEmail"
            Me.grpConfiguracoesEmail.Size = New System.Drawing.Size(525, 75)
            Me.grpConfiguracoesEmail.TabIndex = 6
            Me.grpConfiguracoesEmail.TabStop = False
            Me.grpConfiguracoesEmail.Text = "Configurações do E-mail"
            '
            'txtDe
            '
            Me.txtDe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDe.Location = New System.Drawing.Point(301, 21)
            Me.txtDe.Name = "txtDe"
            Me.txtDe.Size = New System.Drawing.Size(197, 20)
            Me.txtDe.TabIndex = 9
            '
            'lblDe
            '
            Me.lblDe.AutoSize = True
            Me.lblDe.Location = New System.Drawing.Point(271, 21)
            Me.lblDe.Name = "lblDe"
            Me.lblDe.Size = New System.Drawing.Size(24, 13)
            Me.lblDe.TabIndex = 8
            Me.lblDe.Text = "De:"
            '
            'txtMostrar
            '
            Me.txtMostrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMostrar.Location = New System.Drawing.Point(113, 47)
            Me.txtMostrar.Name = "txtMostrar"
            Me.txtMostrar.Size = New System.Drawing.Size(139, 20)
            Me.txtMostrar.TabIndex = 7
            '
            'lblMostrar
            '
            Me.lblMostrar.AutoSize = True
            Me.lblMostrar.Location = New System.Drawing.Point(12, 47)
            Me.lblMostrar.Name = "lblMostrar"
            Me.lblMostrar.Size = New System.Drawing.Size(45, 13)
            Me.lblMostrar.TabIndex = 6
            Me.lblMostrar.Text = "Mostrar:"
            '
            'txtServidorSMTP
            '
            Me.txtServidorSMTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtServidorSMTP.Location = New System.Drawing.Point(113, 21)
            Me.txtServidorSMTP.Name = "txtServidorSMTP"
            Me.txtServidorSMTP.Size = New System.Drawing.Size(139, 20)
            Me.txtServidorSMTP.TabIndex = 5
            '
            'lblServidorSMTP
            '
            Me.lblServidorSMTP.AutoSize = True
            Me.lblServidorSMTP.Location = New System.Drawing.Point(12, 21)
            Me.lblServidorSMTP.Name = "lblServidorSMTP"
            Me.lblServidorSMTP.Size = New System.Drawing.Size(82, 13)
            Me.lblServidorSMTP.TabIndex = 4
            Me.lblServidorSMTP.Text = "Servidor SMTP:"
            '
            'tbpCarteiras
            '
            Me.tbpCarteiras.Controls.Add(Me.rtbCarteiras)
            Me.tbpCarteiras.Location = New System.Drawing.Point(4, 22)
            Me.tbpCarteiras.Name = "tbpCarteiras"
            Me.tbpCarteiras.Padding = New System.Windows.Forms.Padding(3)
            Me.tbpCarteiras.Size = New System.Drawing.Size(549, 260)
            Me.tbpCarteiras.TabIndex = 1
            Me.tbpCarteiras.Text = "Carteiras"
            Me.tbpCarteiras.UseVisualStyleBackColor = True
            '
            'rtbCarteiras
            '
            Me.rtbCarteiras.Location = New System.Drawing.Point(6, 6)
            Me.rtbCarteiras.Name = "rtbCarteiras"
            Me.rtbCarteiras.Size = New System.Drawing.Size(537, 248)
            Me.rtbCarteiras.TabIndex = 0
            Me.rtbCarteiras.Text = ""
            '
            'tbpCautelas
            '
            Me.tbpCautelas.Controls.Add(Me.rtbCautelas)
            Me.tbpCautelas.Location = New System.Drawing.Point(4, 22)
            Me.tbpCautelas.Name = "tbpCautelas"
            Me.tbpCautelas.Size = New System.Drawing.Size(549, 260)
            Me.tbpCautelas.TabIndex = 2
            Me.tbpCautelas.Text = "Cautelas"
            Me.tbpCautelas.UseVisualStyleBackColor = True
            '
            'rtbCautelas
            '
            Me.rtbCautelas.Location = New System.Drawing.Point(6, 6)
            Me.rtbCautelas.Name = "rtbCautelas"
            Me.rtbCautelas.Size = New System.Drawing.Size(537, 248)
            Me.rtbCautelas.TabIndex = 1
            Me.rtbCautelas.Text = ""
            '
            'tbpMBPs
            '
            Me.tbpMBPs.Controls.Add(Me.rtbMBPs)
            Me.tbpMBPs.Location = New System.Drawing.Point(4, 22)
            Me.tbpMBPs.Name = "tbpMBPs"
            Me.tbpMBPs.Size = New System.Drawing.Size(549, 260)
            Me.tbpMBPs.TabIndex = 3
            Me.tbpMBPs.Text = "MBPs"
            Me.tbpMBPs.UseVisualStyleBackColor = True
            '
            'rtbMBPs
            '
            Me.rtbMBPs.Location = New System.Drawing.Point(6, 6)
            Me.rtbMBPs.Name = "rtbMBPs"
            Me.rtbMBPs.Size = New System.Drawing.Size(537, 248)
            Me.rtbMBPs.TabIndex = 1
            Me.rtbMBPs.Text = ""
            '
            'tbpInventarioBens
            '
            Me.tbpInventarioBens.Controls.Add(Me.rtbInventarioBens)
            Me.tbpInventarioBens.Location = New System.Drawing.Point(4, 22)
            Me.tbpInventarioBens.Name = "tbpInventarioBens"
            Me.tbpInventarioBens.Size = New System.Drawing.Size(549, 260)
            Me.tbpInventarioBens.TabIndex = 4
            Me.tbpInventarioBens.Text = "Inventário Bens"
            Me.tbpInventarioBens.UseVisualStyleBackColor = True
            '
            'rtbInventarioBens
            '
            Me.rtbInventarioBens.Location = New System.Drawing.Point(6, 6)
            Me.rtbInventarioBens.Name = "rtbInventarioBens"
            Me.rtbInventarioBens.Size = New System.Drawing.Size(537, 248)
            Me.rtbInventarioBens.TabIndex = 1
            Me.rtbInventarioBens.Text = ""
            '
            'tbpBens
            '
            Me.tbpBens.Controls.Add(Me.rtbBens)
            Me.tbpBens.Location = New System.Drawing.Point(4, 22)
            Me.tbpBens.Name = "tbpBens"
            Me.tbpBens.Size = New System.Drawing.Size(549, 260)
            Me.tbpBens.TabIndex = 5
            Me.tbpBens.Text = "Bens"
            Me.tbpBens.UseVisualStyleBackColor = True
            '
            'rtbBens
            '
            Me.rtbBens.Location = New System.Drawing.Point(6, 6)
            Me.rtbBens.Name = "rtbBens"
            Me.rtbBens.Size = New System.Drawing.Size(537, 248)
            Me.rtbBens.TabIndex = 2
            Me.rtbBens.Text = ""
            '
            'tabBackupBancoDados
            '
            Me.tabBackupBancoDados.Controls.Add(Me.btnDiretorioBackupBancoDados)
            Me.tabBackupBancoDados.Controls.Add(Me.lblNumeroCopiasBackup)
            Me.tabBackupBancoDados.Controls.Add(Me.txtNumeroCopiasBackup)
            Me.tabBackupBancoDados.Controls.Add(Me.lblIntervaloBackupMinutos)
            Me.tabBackupBancoDados.Controls.Add(Me.lblIntervaloBackup)
            Me.tabBackupBancoDados.Controls.Add(Me.txtIntervaloBackup)
            Me.tabBackupBancoDados.Controls.Add(Me.txtDiretorioBackupBancoDados)
            Me.tabBackupBancoDados.Controls.Add(Me.lblDiretorioBackupBancoDados)
            Me.tabBackupBancoDados.Location = New System.Drawing.Point(4, 25)
            Me.tabBackupBancoDados.Name = "tabBackupBancoDados"
            Me.tabBackupBancoDados.Size = New System.Drawing.Size(563, 292)
            Me.tabBackupBancoDados.TabIndex = 6
            Me.tabBackupBancoDados.Text = "Backup - Banco de Dados"
            Me.tabBackupBancoDados.UseVisualStyleBackColor = True
            '
            'btnDiretorioBackupBancoDados
            '
            Me.btnDiretorioBackupBancoDados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDiretorioBackupBancoDados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDiretorioBackupBancoDados.Location = New System.Drawing.Point(526, 77)
            Me.btnDiretorioBackupBancoDados.Name = "btnDiretorioBackupBancoDados"
            Me.btnDiretorioBackupBancoDados.Size = New System.Drawing.Size(33, 22)
            Me.btnDiretorioBackupBancoDados.TabIndex = 9
            Me.btnDiretorioBackupBancoDados.Text = "..."
            Me.btnDiretorioBackupBancoDados.UseVisualStyleBackColor = True
            '
            'lblNumeroCopiasBackup
            '
            Me.lblNumeroCopiasBackup.AutoSize = True
            Me.lblNumeroCopiasBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblNumeroCopiasBackup.Location = New System.Drawing.Point(12, 102)
            Me.lblNumeroCopiasBackup.Name = "lblNumeroCopiasBackup"
            Me.lblNumeroCopiasBackup.Size = New System.Drawing.Size(97, 13)
            Me.lblNumeroCopiasBackup.TabIndex = 7
            Me.lblNumeroCopiasBackup.Text = "Número de Cópias:"
            '
            'txtNumeroCopiasBackup
            '
            Me.txtNumeroCopiasBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtNumeroCopiasBackup.Location = New System.Drawing.Point(124, 102)
            Me.txtNumeroCopiasBackup.Name = "txtNumeroCopiasBackup"
            Me.txtNumeroCopiasBackup.Size = New System.Drawing.Size(132, 20)
            Me.txtNumeroCopiasBackup.TabIndex = 8
            '
            'lblIntervaloBackupMinutos
            '
            Me.lblIntervaloBackupMinutos.AutoSize = True
            Me.lblIntervaloBackupMinutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblIntervaloBackupMinutos.Location = New System.Drawing.Point(262, 78)
            Me.lblIntervaloBackupMinutos.Name = "lblIntervaloBackupMinutos"
            Me.lblIntervaloBackupMinutos.Size = New System.Drawing.Size(49, 13)
            Me.lblIntervaloBackupMinutos.TabIndex = 6
            Me.lblIntervaloBackupMinutos.Text = "minuto(s)"
            '
            'lblIntervaloBackup
            '
            Me.lblIntervaloBackup.AutoSize = True
            Me.lblIntervaloBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblIntervaloBackup.Location = New System.Drawing.Point(12, 78)
            Me.lblIntervaloBackup.Name = "lblIntervaloBackup"
            Me.lblIntervaloBackup.Size = New System.Drawing.Size(106, 13)
            Me.lblIntervaloBackup.TabIndex = 4
            Me.lblIntervaloBackup.Text = "Intervalo de Backup:"
            '
            'txtIntervaloBackup
            '
            Me.txtIntervaloBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIntervaloBackup.Location = New System.Drawing.Point(124, 78)
            Me.txtIntervaloBackup.Name = "txtIntervaloBackup"
            Me.txtIntervaloBackup.Size = New System.Drawing.Size(132, 20)
            Me.txtIntervaloBackup.TabIndex = 5
            '
            'txtDiretorioBackupBancoDados
            '
            Me.txtDiretorioBackupBancoDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDiretorioBackupBancoDados.Location = New System.Drawing.Point(15, 29)
            Me.txtDiretorioBackupBancoDados.Multiline = True
            Me.txtDiretorioBackupBancoDados.Name = "txtDiretorioBackupBancoDados"
            Me.txtDiretorioBackupBancoDados.Size = New System.Drawing.Size(544, 42)
            Me.txtDiretorioBackupBancoDados.TabIndex = 3
            '
            'lblDiretorioBackupBancoDados
            '
            Me.lblDiretorioBackupBancoDados.AutoSize = True
            Me.lblDiretorioBackupBancoDados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblDiretorioBackupBancoDados.Location = New System.Drawing.Point(12, 13)
            Me.lblDiretorioBackupBancoDados.Name = "lblDiretorioBackupBancoDados"
            Me.lblDiretorioBackupBancoDados.Size = New System.Drawing.Size(202, 13)
            Me.lblDiretorioBackupBancoDados.TabIndex = 2
            Me.lblDiretorioBackupBancoDados.Text = "Diretório de Backup do Banco de Dados:"
            '
            'tabUtilitarios
            '
            Me.tabUtilitarios.Controls.Add(Me.lblFazerBackupBancosDados)
            Me.tabUtilitarios.Controls.Add(Me.btnFazerBackupBancosDados)
            Me.tabUtilitarios.Controls.Add(Me.lblDiretorioInstalacaoAplicativo)
            Me.tabUtilitarios.Controls.Add(Me.txtDiretorioInstalacaoAplicativo)
            Me.tabUtilitarios.Controls.Add(Me.btnCriarBancoDadosPrincipal)
            Me.tabUtilitarios.Controls.Add(Me.btnCompactarRepararBancoDadosPrincipal2)
            Me.tabUtilitarios.Controls.Add(Me.lblCriarTodasTabelas)
            Me.tabUtilitarios.Controls.Add(Me.btnCriarTodasTabelas)
            Me.tabUtilitarios.Controls.Add(Me.lblCriarBancoDadosPrincipal)
            Me.tabUtilitarios.Controls.Add(Me.lblCriarBancoDadosColetor)
            Me.tabUtilitarios.Controls.Add(Me.btnCriarBancoDadosColetor)
            Me.tabUtilitarios.Controls.Add(Me.lblCompactarRepararBancoDadosColetor)
            Me.tabUtilitarios.Controls.Add(Me.btnCompactarRepararBancoDadosColetor)
            Me.tabUtilitarios.Controls.Add(Me.lblCompactarRepararBancoDadosPrincipal)
            Me.tabUtilitarios.Location = New System.Drawing.Point(4, 25)
            Me.tabUtilitarios.Name = "tabUtilitarios"
            Me.tabUtilitarios.Size = New System.Drawing.Size(563, 292)
            Me.tabUtilitarios.TabIndex = 8
            Me.tabUtilitarios.Text = "Utilitários"
            Me.tabUtilitarios.UseVisualStyleBackColor = True
            '
            'lblFazerBackupBancosDados
            '
            Me.lblFazerBackupBancosDados.AutoSize = True
            Me.lblFazerBackupBancosDados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblFazerBackupBancosDados.Location = New System.Drawing.Point(12, 157)
            Me.lblFazerBackupBancosDados.Name = "lblFazerBackupBancosDados"
            Me.lblFazerBackupBancosDados.Size = New System.Drawing.Size(184, 13)
            Me.lblFazerBackupBancosDados.TabIndex = 14
            Me.lblFazerBackupBancosDados.Text = "Fazer Backup dos Bancos de Dados:"
            '
            'btnFazerBackupBancosDados
            '
            Me.btnFazerBackupBancosDados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnFazerBackupBancosDados.Location = New System.Drawing.Point(302, 152)
            Me.btnFazerBackupBancosDados.Name = "btnFazerBackupBancosDados"
            Me.btnFazerBackupBancosDados.Size = New System.Drawing.Size(251, 23)
            Me.btnFazerBackupBancosDados.TabIndex = 15
            Me.btnFazerBackupBancosDados.Text = "Fazer Backup"
            Me.btnFazerBackupBancosDados.UseVisualStyleBackColor = True
            '
            'lblDiretorioInstalacaoAplicativo
            '
            Me.lblDiretorioInstalacaoAplicativo.AutoSize = True
            Me.lblDiretorioInstalacaoAplicativo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblDiretorioInstalacaoAplicativo.Location = New System.Drawing.Point(12, 231)
            Me.lblDiretorioInstalacaoAplicativo.Name = "lblDiretorioInstalacaoAplicativo"
            Me.lblDiretorioInstalacaoAplicativo.Size = New System.Drawing.Size(180, 13)
            Me.lblDiretorioInstalacaoAplicativo.TabIndex = 12
            Me.lblDiretorioInstalacaoAplicativo.Text = "Diretório de Instalação do Aplicativo:"
            '
            'txtDiretorioInstalacaoAplicativo
            '
            Me.txtDiretorioInstalacaoAplicativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDiretorioInstalacaoAplicativo.Location = New System.Drawing.Point(15, 247)
            Me.txtDiretorioInstalacaoAplicativo.Multiline = True
            Me.txtDiretorioInstalacaoAplicativo.Name = "txtDiretorioInstalacaoAplicativo"
            Me.txtDiretorioInstalacaoAplicativo.ReadOnly = True
            Me.txtDiretorioInstalacaoAplicativo.Size = New System.Drawing.Size(544, 42)
            Me.txtDiretorioInstalacaoAplicativo.TabIndex = 13
            '
            'btnCriarBancoDadosPrincipal
            '
            Me.btnCriarBancoDadosPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCriarBancoDadosPrincipal.Location = New System.Drawing.Point(302, 7)
            Me.btnCriarBancoDadosPrincipal.Name = "btnCriarBancoDadosPrincipal"
            Me.btnCriarBancoDadosPrincipal.Size = New System.Drawing.Size(251, 23)
            Me.btnCriarBancoDadosPrincipal.TabIndex = 3
            Me.btnCriarBancoDadosPrincipal.Text = "Criar Banco Dados"
            Me.btnCriarBancoDadosPrincipal.UseVisualStyleBackColor = True
            '
            'btnCompactarRepararBancoDadosPrincipal2
            '
            Me.btnCompactarRepararBancoDadosPrincipal2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCompactarRepararBancoDadosPrincipal2.Location = New System.Drawing.Point(302, 65)
            Me.btnCompactarRepararBancoDadosPrincipal2.Name = "btnCompactarRepararBancoDadosPrincipal2"
            Me.btnCompactarRepararBancoDadosPrincipal2.Size = New System.Drawing.Size(251, 23)
            Me.btnCompactarRepararBancoDadosPrincipal2.TabIndex = 7
            Me.btnCompactarRepararBancoDadosPrincipal2.Text = "Compactar e Reparar o Banco de Dados"
            Me.btnCompactarRepararBancoDadosPrincipal2.UseVisualStyleBackColor = True
            '
            'lblCriarTodasTabelas
            '
            Me.lblCriarTodasTabelas.AutoSize = True
            Me.lblCriarTodasTabelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblCriarTodasTabelas.Location = New System.Drawing.Point(12, 128)
            Me.lblCriarTodasTabelas.Name = "lblCriarTodasTabelas"
            Me.lblCriarTodasTabelas.Size = New System.Drawing.Size(119, 13)
            Me.lblCriarTodasTabelas.TabIndex = 10
            Me.lblCriarTodasTabelas.Text = "Criar Todas as Tabelas:"
            '
            'btnCriarTodasTabelas
            '
            Me.btnCriarTodasTabelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCriarTodasTabelas.Location = New System.Drawing.Point(302, 123)
            Me.btnCriarTodasTabelas.Name = "btnCriarTodasTabelas"
            Me.btnCriarTodasTabelas.Size = New System.Drawing.Size(251, 23)
            Me.btnCriarTodasTabelas.TabIndex = 11
            Me.btnCriarTodasTabelas.Text = "Criar Tabelas"
            Me.btnCriarTodasTabelas.UseVisualStyleBackColor = True
            '
            'lblCriarBancoDadosPrincipal
            '
            Me.lblCriarBancoDadosPrincipal.AutoSize = True
            Me.lblCriarBancoDadosPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblCriarBancoDadosPrincipal.Location = New System.Drawing.Point(12, 12)
            Me.lblCriarBancoDadosPrincipal.Name = "lblCriarBancoDadosPrincipal"
            Me.lblCriarBancoDadosPrincipal.Size = New System.Drawing.Size(148, 13)
            Me.lblCriarBancoDadosPrincipal.TabIndex = 2
            Me.lblCriarBancoDadosPrincipal.Text = "Criar Banco Dados - Principal:"
            '
            'lblCriarBancoDadosColetor
            '
            Me.lblCriarBancoDadosColetor.AutoSize = True
            Me.lblCriarBancoDadosColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblCriarBancoDadosColetor.Location = New System.Drawing.Point(12, 41)
            Me.lblCriarBancoDadosColetor.Name = "lblCriarBancoDadosColetor"
            Me.lblCriarBancoDadosColetor.Size = New System.Drawing.Size(141, 13)
            Me.lblCriarBancoDadosColetor.TabIndex = 4
            Me.lblCriarBancoDadosColetor.Text = "Criar Banco Dados - Coletor:"
            '
            'btnCriarBancoDadosColetor
            '
            Me.btnCriarBancoDadosColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCriarBancoDadosColetor.Location = New System.Drawing.Point(302, 36)
            Me.btnCriarBancoDadosColetor.Name = "btnCriarBancoDadosColetor"
            Me.btnCriarBancoDadosColetor.Size = New System.Drawing.Size(251, 23)
            Me.btnCriarBancoDadosColetor.TabIndex = 5
            Me.btnCriarBancoDadosColetor.Text = "Criar Banco Dados"
            Me.btnCriarBancoDadosColetor.UseVisualStyleBackColor = True
            '
            'lblCompactarRepararBancoDadosColetor
            '
            Me.lblCompactarRepararBancoDadosColetor.AutoSize = True
            Me.lblCompactarRepararBancoDadosColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblCompactarRepararBancoDadosColetor.Location = New System.Drawing.Point(12, 99)
            Me.lblCompactarRepararBancoDadosColetor.Name = "lblCompactarRepararBancoDadosColetor"
            Me.lblCompactarRepararBancoDadosColetor.Size = New System.Drawing.Size(245, 13)
            Me.lblCompactarRepararBancoDadosColetor.TabIndex = 8
            Me.lblCompactarRepararBancoDadosColetor.Text = "Compactar e Reparar o Banco de Dados - Coletor:"
            '
            'btnCompactarRepararBancoDadosColetor
            '
            Me.btnCompactarRepararBancoDadosColetor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCompactarRepararBancoDadosColetor.Location = New System.Drawing.Point(302, 94)
            Me.btnCompactarRepararBancoDadosColetor.Name = "btnCompactarRepararBancoDadosColetor"
            Me.btnCompactarRepararBancoDadosColetor.Size = New System.Drawing.Size(251, 23)
            Me.btnCompactarRepararBancoDadosColetor.TabIndex = 9
            Me.btnCompactarRepararBancoDadosColetor.Text = "Compactar e Reparar o Banco de Dados"
            Me.btnCompactarRepararBancoDadosColetor.UseVisualStyleBackColor = True
            '
            'lblCompactarRepararBancoDadosPrincipal
            '
            Me.lblCompactarRepararBancoDadosPrincipal.AutoSize = True
            Me.lblCompactarRepararBancoDadosPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblCompactarRepararBancoDadosPrincipal.Location = New System.Drawing.Point(12, 70)
            Me.lblCompactarRepararBancoDadosPrincipal.Name = "lblCompactarRepararBancoDadosPrincipal"
            Me.lblCompactarRepararBancoDadosPrincipal.Size = New System.Drawing.Size(252, 13)
            Me.lblCompactarRepararBancoDadosPrincipal.TabIndex = 6
            Me.lblCompactarRepararBancoDadosPrincipal.Text = "Compactar e Reparar o Banco de Dados - Principal:"
            '
            'btnAbrir6
            '
            Me.btnAbrir6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAbrir6.Location = New System.Drawing.Point(522, 160)
            Me.btnAbrir6.Name = "btnAbrir6"
            Me.btnAbrir6.Size = New System.Drawing.Size(33, 22)
            Me.btnAbrir6.TabIndex = 34
            Me.btnAbrir6.Text = "..."
            Me.btnAbrir6.UseVisualStyleBackColor = True
            '
            'Button1
            '
            Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button1.Location = New System.Drawing.Point(526, 188)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(33, 22)
            Me.Button1.TabIndex = 73
            Me.Button1.Text = "..."
            Me.Button1.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Label1.Location = New System.Drawing.Point(12, 124)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(265, 13)
            Me.Label1.TabIndex = 71
            Me.Label1.Text = "Localização do Texto de E-mail do Inventário de Bens:"
            '
            'TextBox1
            '
            Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TextBox1.Location = New System.Drawing.Point(15, 140)
            Me.TextBox1.Multiline = True
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBox1.Size = New System.Drawing.Size(544, 42)
            Me.TextBox1.TabIndex = 72
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Label2.Location = New System.Drawing.Point(301, 271)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(120, 13)
            Me.Label2.TabIndex = 69
            Me.Label2.Text = "Multiplicador do Código:"
            '
            'TextBox2
            '
            Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TextBox2.Location = New System.Drawing.Point(427, 269)
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New System.Drawing.Size(132, 20)
            Me.TextBox2.TabIndex = 70
            '
            'CheckBox1
            '
            Me.CheckBox1.AutoSize = True
            Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.CheckBox1.Location = New System.Drawing.Point(15, 12)
            Me.CheckBox1.Name = "CheckBox1"
            Me.CheckBox1.Size = New System.Drawing.Size(89, 17)
            Me.CheckBox1.TabIndex = 2
            Me.CheckBox1.Text = "Atualizar Data"
            Me.CheckBox1.UseVisualStyleBackColor = True
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Label3.Location = New System.Drawing.Point(288, 12)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(133, 13)
            Me.Label3.TabIndex = 3
            Me.Label3.Text = "Numero de Linhas do Grid:"
            '
            'TextBox3
            '
            Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TextBox3.Location = New System.Drawing.Point(427, 12)
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Size = New System.Drawing.Size(132, 20)
            Me.TextBox3.TabIndex = 4
            '
            'Button2
            '
            Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.Location = New System.Drawing.Point(526, 112)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(33, 22)
            Me.Button2.TabIndex = 7
            Me.Button2.Text = "..."
            Me.Button2.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Label4.Location = New System.Drawing.Point(12, 48)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(234, 13)
            Me.Label4.TabIndex = 5
            Me.Label4.Text = "Localização do Relatório do Inventário de Bens:"
            '
            'TextBox4
            '
            Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TextBox4.Location = New System.Drawing.Point(15, 64)
            Me.TextBox4.Multiline = True
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBox4.Size = New System.Drawing.Size(544, 42)
            Me.TextBox4.TabIndex = 6
            '
            'frmConfiguracoes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.Window
            Me.ClientSize = New System.Drawing.Size(590, 387)
            Me.Controls.Add(Me.tctr1)
            Me.Controls.Add(Me.bar1)
            Me.Controls.Add(Me.btnSair)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.Name = "frmConfiguracoes"
            Me.Text = "Configurações"
            Me.bar1.ResumeLayout(False)
            Me.bar1.PerformLayout()
            Me.tctr1.ResumeLayout(False)
            Me.tabBaseDadosPrincipal.ResumeLayout(False)
            Me.tabBaseDadosPrincipal.PerformLayout()
            Me.tabBancoDadosColetor.ResumeLayout(False)
            Me.tabBancoDadosColetor.PerformLayout()
            Me.grpMonitorarDiretorioArquivo.ResumeLayout(False)
            Me.grpMonitorarDiretorioArquivo.PerformLayout()
            Me.tabAcessoCADU.ResumeLayout(False)
            Me.tabAcessoCADU.PerformLayout()
            Me.tabCarteiras.ResumeLayout(False)
            Me.tabCarteiras.PerformLayout()
            Me.tabCautelas.ResumeLayout(False)
            Me.tabCautelas.PerformLayout()
            Me.tabMBPs.ResumeLayout(False)
            Me.tabMBPs.PerformLayout()
            Me.tabInventarioBens.ResumeLayout(False)
            Me.tabInventarioBens.PerformLayout()
            Me.tabBens.ResumeLayout(False)
            Me.tabBens.PerformLayout()
            Me.tabTRG.ResumeLayout(False)
            Me.tabTRG.PerformLayout()
            Me.tabEmail.ResumeLayout(False)
            Me.tbcEmail.ResumeLayout(False)
            Me.tbpGeral.ResumeLayout(False)
            Me.grbConfiguraçõesGeral.ResumeLayout(False)
            Me.grpExportacaoRelatorios.ResumeLayout(False)
            Me.grbRelatorioBens.ResumeLayout(False)
            Me.grbRelatorioBens.PerformLayout()
            Me.grbRelatorioInventarioBens.ResumeLayout(False)
            Me.grbRelatorioInventarioBens.PerformLayout()
            Me.grbRelatorioMBPs.ResumeLayout(False)
            Me.grbRelatorioMBPs.PerformLayout()
            Me.grbRelatorioCautelas.ResumeLayout(False)
            Me.grbRelatorioCautelas.PerformLayout()
            Me.grbRelatorioCarteira.ResumeLayout(False)
            Me.grbRelatorioCarteira.PerformLayout()
            Me.grpConfiguracoesEmail.ResumeLayout(False)
            Me.grpConfiguracoesEmail.PerformLayout()
            Me.tbpCarteiras.ResumeLayout(False)
            Me.tbpCautelas.ResumeLayout(False)
            Me.tbpMBPs.ResumeLayout(False)
            Me.tbpInventarioBens.ResumeLayout(False)
            Me.tbpBens.ResumeLayout(False)
            Me.tabBackupBancoDados.ResumeLayout(False)
            Me.tabBackupBancoDados.PerformLayout()
            Me.tabUtilitarios.ResumeLayout(False)
            Me.tabUtilitarios.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents ofd1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents btnLocalizacaoBaseDadosPrincipal As System.Windows.Forms.Button
        Friend WithEvents txtNomeServidorPrincipal As System.Windows.Forms.TextBox
        Friend WithEvents txtChavePrincipal As System.Windows.Forms.TextBox
        Friend WithEvents btnSair As System.Windows.Forms.Button
        Friend WithEvents txtLocalizacaoPrincipal As System.Windows.Forms.TextBox
        Friend WithEvents bar1 As System.Windows.Forms.StatusStrip
        Friend WithEvents blblResultadoSenhaCriptografada As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents blblSenhaCriptografada As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents lblNomeServidorPrincipal As System.Windows.Forms.Label
        Friend WithEvents lblChavePrincipal As System.Windows.Forms.Label
        Friend WithEvents lblLocalizacaoPrincipal As System.Windows.Forms.Label
        Friend WithEvents tctr1 As System.Windows.Forms.TabControl
        Friend WithEvents tabBaseDadosPrincipal As System.Windows.Forms.TabPage
        Friend WithEvents btnTestarConexaoPrincipal As System.Windows.Forms.Button
        Friend WithEvents lblSenhaPrincipal As System.Windows.Forms.Label
        Friend WithEvents txtSenhaPrincipal As System.Windows.Forms.TextBox
        Friend WithEvents lblNomeBaseDadosPrincipal As System.Windows.Forms.Label
        Friend WithEvents txtNomeBaseDadosPrincipal As System.Windows.Forms.TextBox
        Friend WithEvents lblIdentificadorUsuarioPrincipal As System.Windows.Forms.Label
        Friend WithEvents txtIdentificadorUsuarioPrincipal As System.Windows.Forms.TextBox
        Friend WithEvents tabCarteiras As System.Windows.Forms.TabPage
        Friend WithEvents tabCautelas As System.Windows.Forms.TabPage
        Friend WithEvents tabMBPs As System.Windows.Forms.TabPage
        Friend WithEvents tabTRG As System.Windows.Forms.TabPage
        Friend WithEvents txtPrazoEntregaCautelas As System.Windows.Forms.TextBox
        Friend WithEvents txtPrazoValidadeCarteiras As System.Windows.Forms.TextBox
        Friend WithEvents btnLocalizacaoRelatorioCarteiras As System.Windows.Forms.Button
        Friend WithEvents lblLocalizacaoRelatorioCarteiras As System.Windows.Forms.Label
        Friend WithEvents txtLocalizacaoRelatorioCarteiras As System.Windows.Forms.TextBox
        Friend WithEvents lblPrazoValidadeCarteiras As System.Windows.Forms.Label
        Friend WithEvents btnLocalizacaoRelatorioCautelas As System.Windows.Forms.Button
        Friend WithEvents lblLocalizacaoRelatorioCautelas As System.Windows.Forms.Label
        Friend WithEvents txtLocalizacaoRelatorioCautelas As System.Windows.Forms.TextBox
        Friend WithEvents lblPrazoEntregaCautelas As System.Windows.Forms.Label
        Friend WithEvents txtNomeResponsavelGeralBens As System.Windows.Forms.TextBox
        Friend WithEvents lblNomeResponsavelGeralBens As System.Windows.Forms.Label
        Friend WithEvents lsvTRG As System.Windows.Forms.ListView
        Friend WithEvents lblNumeroTermoResponsavelGeralBens As System.Windows.Forms.Label
        Friend WithEvents txtNumeroTermoResponsavelGeralBens As System.Windows.Forms.TextBox
        Friend WithEvents tabAcessoCADU As System.Windows.Forms.TabPage
        Friend WithEvents lblSenhaCADU As System.Windows.Forms.Label
        Friend WithEvents txtSenhaCADU As System.Windows.Forms.TextBox
        Friend WithEvents lblNomeBaseDadosCADU As System.Windows.Forms.Label
        Friend WithEvents txtNomeBaseDadosCADU As System.Windows.Forms.TextBox
        Friend WithEvents lblIdentificadorUsuarioCADU As System.Windows.Forms.Label
        Friend WithEvents txtIdentificadorUsuarioCADU As System.Windows.Forms.TextBox
        Friend WithEvents btnTestarConexaoCADU As System.Windows.Forms.Button
        Friend WithEvents lblNomeServidorCADU As System.Windows.Forms.Label
        Friend WithEvents lblConexaoCADU As System.Windows.Forms.Label
        Friend WithEvents lblChaveCADU As System.Windows.Forms.Label
        Friend WithEvents txtNomeServidorCADU As System.Windows.Forms.TextBox
        Friend WithEvents txtChaveCADU As System.Windows.Forms.TextBox
        Friend WithEvents txtConexaoCADU As System.Windows.Forms.TextBox
        Friend WithEvents btnAbrir6 As System.Windows.Forms.Button
        Friend WithEvents chbSegurancaIntengradaCADU As System.Windows.Forms.CheckBox
        Friend WithEvents chbInformacaoSegurancaPersistenteCADU As System.Windows.Forms.CheckBox
        Friend WithEvents lblConexaoPrincipal As System.Windows.Forms.Label
        Friend WithEvents txtConexaoPrincipal As System.Windows.Forms.TextBox
        Friend WithEvents tabBackupBancoDados As System.Windows.Forms.TabPage
        Friend WithEvents lblTabelaCADU As System.Windows.Forms.Label
        Friend WithEvents txtTabelaCADU As System.Windows.Forms.TextBox
        Friend WithEvents tabBancoDadosColetor As System.Windows.Forms.TabPage
        Friend WithEvents lblSenhaColetor As System.Windows.Forms.Label
        Friend WithEvents txtSenhaColetor As System.Windows.Forms.TextBox
        Friend WithEvents lblNomeBaseDadosColetor As System.Windows.Forms.Label
        Friend WithEvents txtNomeBaseDadosColetor As System.Windows.Forms.TextBox
        Friend WithEvents lblIdentificadorUsuarioColetor As System.Windows.Forms.Label
        Friend WithEvents txtIdentificadorUsuarioColetor As System.Windows.Forms.TextBox
        Friend WithEvents btnTestarConexaoColetor As System.Windows.Forms.Button
        Friend WithEvents lblNomeServidorColetor As System.Windows.Forms.Label
        Friend WithEvents lblConexaoColetor As System.Windows.Forms.Label
        Friend WithEvents lblChaveColetor As System.Windows.Forms.Label
        Friend WithEvents txtNomeServidorColetor As System.Windows.Forms.TextBox
        Friend WithEvents txtChaveColetor As System.Windows.Forms.TextBox
        Friend WithEvents txtConexaoColetor As System.Windows.Forms.TextBox
        Friend WithEvents tabUtilitarios As System.Windows.Forms.TabPage
        Friend WithEvents lblCompactarRepararBancoDadosPrincipal As System.Windows.Forms.Label
        Friend WithEvents lblCompactarRepararBancoDadosColetor As System.Windows.Forms.Label
        Friend WithEvents btnCompactarRepararBancoDadosColetor As System.Windows.Forms.Button
        Friend WithEvents lblLocalizacaoColetor As System.Windows.Forms.Label
        Friend WithEvents btnLocalizacaoBaseDadosColetor As System.Windows.Forms.Button
        Friend WithEvents txtLocalizacaoColetor As System.Windows.Forms.TextBox
        Friend WithEvents lblCriarBancoDadosColetor As System.Windows.Forms.Label
        Friend WithEvents btnCriarBancoDadosColetor As System.Windows.Forms.Button
        Friend WithEvents txtMatriculaResponsavelGeralBens As System.Windows.Forms.TextBox
        Friend WithEvents lblMatriculaResponsavelGeralBens As System.Windows.Forms.Label
        Friend WithEvents lblOrgaoGeralBens As System.Windows.Forms.Label
        Friend WithEvents txtOrgaoResponsavelGeralBens As System.Windows.Forms.TextBox
        Friend WithEvents btnDefinir As System.Windows.Forms.Button
        Friend WithEvents tabInventarioBens As System.Windows.Forms.TabPage
        Friend WithEvents btnLocalizacaoRelatorioMBPs As System.Windows.Forms.Button
        Friend WithEvents lblLocalizacaoRelatorioMBPs As System.Windows.Forms.Label
        Friend WithEvents txtLocalizacaoRelatorioMBPs As System.Windows.Forms.TextBox
        Friend WithEvents txtPrazoEmprestimo As System.Windows.Forms.TextBox
        Friend WithEvents lblPrazoEmprestimo As System.Windows.Forms.Label
        Friend WithEvents btnLocalizacaoRelatorioInventarioBens As System.Windows.Forms.Button
        Friend WithEvents lblLocalizacaoRelatorioInventarioBens As System.Windows.Forms.Label
        Friend WithEvents txtLocalizacaoRelatorioInventarioBens As System.Windows.Forms.TextBox
        Private WithEvents grpMonitorarDiretorioArquivo As System.Windows.Forms.GroupBox
        Friend WithEvents btnMonitoramento As System.Windows.Forms.Button
        Friend WithEvents chkSubDiretorios As System.Windows.Forms.CheckBox
        Friend WithEvents rdbMonitorarDiretorio As System.Windows.Forms.RadioButton
        Friend WithEvents rdbMonitorarArquivo As System.Windows.Forms.RadioButton
        Friend WithEvents lblNumeroLinhasCarteiras As System.Windows.Forms.Label
        Friend WithEvents txtNumeroLinhasCarteiras As System.Windows.Forms.TextBox
        Friend WithEvents lblNumeroLinhasCautelas As System.Windows.Forms.Label
        Friend WithEvents txtNumeroLinhasCautelas As System.Windows.Forms.TextBox
        Friend WithEvents lblNumeroLinhasMBPs As System.Windows.Forms.Label
        Friend WithEvents txtNumeroLinhasMBPs As System.Windows.Forms.TextBox
        Friend WithEvents lblNumeroLinhasInventarioBens As System.Windows.Forms.Label
        Friend WithEvents txtNumeroLinhasInventarioBens As System.Windows.Forms.TextBox
        Friend WithEvents lblCriarBancoDadosPrincipal As System.Windows.Forms.Label
        Friend WithEvents lblCriarTodasTabelas As System.Windows.Forms.Label
        Friend WithEvents btnCriarTodasTabelas As System.Windows.Forms.Button
        Friend WithEvents chbAtualizarData As System.Windows.Forms.CheckBox
        Friend WithEvents btnCompactarRepararBancoDadosPrincipal2 As System.Windows.Forms.Button
        Friend WithEvents lblDiretorioBackupBancoDados As System.Windows.Forms.Label
        Friend WithEvents txtDiretorioBackupBancoDados As System.Windows.Forms.TextBox
        Friend WithEvents btnCriarBancoDadosPrincipal As System.Windows.Forms.Button
        Friend WithEvents lblIntervaloBackup As System.Windows.Forms.Label
        Friend WithEvents txtIntervaloBackup As System.Windows.Forms.TextBox
        Friend WithEvents lblIntervaloBackupMinutos As System.Windows.Forms.Label
        Friend WithEvents lblNumeroCopiasBackup As System.Windows.Forms.Label
        Friend WithEvents txtNumeroCopiasBackup As System.Windows.Forms.TextBox
        Friend WithEvents lblDiretorioInstalacaoAplicativo As System.Windows.Forms.Label
        Friend WithEvents txtDiretorioInstalacaoAplicativo As System.Windows.Forms.TextBox
        Friend WithEvents btnDiretorioBackupBancoDados As System.Windows.Forms.Button
        Friend WithEvents fbd1 As System.Windows.Forms.FolderBrowserDialog
        Friend WithEvents lblFazerBackupBancosDados As System.Windows.Forms.Label
        Friend WithEvents btnFazerBackupBancosDados As System.Windows.Forms.Button
        Friend WithEvents lblMultiplicadorCodigoCarteiras As System.Windows.Forms.Label
        Friend WithEvents txtMultiplicadorCodigoCarteiras As System.Windows.Forms.TextBox
        Friend WithEvents lblMultiplicadorCodigoCautelas As System.Windows.Forms.Label
        Friend WithEvents txtMultiplicadorCodigoCautelas As System.Windows.Forms.TextBox
        Friend WithEvents lblMultiplicadorCodigoMBPs As System.Windows.Forms.Label
        Friend WithEvents txtMultiplicadorCodigoMBPs As System.Windows.Forms.TextBox
        Friend WithEvents lblMultiplicadorCodigoInventarioBens As System.Windows.Forms.Label
        Friend WithEvents txtMultiplicadorCodigoInventarioBens As System.Windows.Forms.TextBox
        Friend WithEvents tabEmail As System.Windows.Forms.TabPage
        Friend WithEvents tbcEmail As System.Windows.Forms.TabControl
        Friend WithEvents tbpGeral As System.Windows.Forms.TabPage
        Friend WithEvents tbpCarteiras As System.Windows.Forms.TabPage
        Friend WithEvents rtbCarteiras As System.Windows.Forms.RichTextBox
        Friend WithEvents tbpCautelas As System.Windows.Forms.TabPage
        Friend WithEvents rtbCautelas As System.Windows.Forms.RichTextBox
        Friend WithEvents tbpMBPs As System.Windows.Forms.TabPage
        Friend WithEvents rtbMBPs As System.Windows.Forms.RichTextBox
        Friend WithEvents tbpInventarioBens As System.Windows.Forms.TabPage
        Friend WithEvents rtbInventarioBens As System.Windows.Forms.RichTextBox
        Friend WithEvents btnLocalizacaoTextoEmailCarteiras As System.Windows.Forms.Button
        Friend WithEvents lblLocalizacaoTextoEmailCarteiras As System.Windows.Forms.Label
        Friend WithEvents txtLocalizacaoTextoEmailCarteiras As System.Windows.Forms.TextBox
        Friend WithEvents btnLocalizacaoTextoEmailCautelas As System.Windows.Forms.Button
        Friend WithEvents lblLocalizacaoTextoEmailCautelas As System.Windows.Forms.Label
        Friend WithEvents txtLocalizacaoTextoEmailCautelas As System.Windows.Forms.TextBox
        Friend WithEvents btnLocalizacaoTextoEmailMBPs As System.Windows.Forms.Button
        Friend WithEvents lblLocalizacaoTextoEmailMBPs As System.Windows.Forms.Label
        Friend WithEvents txtLocalizacaoTextoEmailMBPs As System.Windows.Forms.TextBox
        Friend WithEvents btnLocalizacaoTextoEmailInventarioBens As System.Windows.Forms.Button
        Friend WithEvents lblLocalizacaoTextoEmailInventarioBens As System.Windows.Forms.Label
        Friend WithEvents txtLocalizacaoTextoEmailInventarioBens As System.Windows.Forms.TextBox
        Friend WithEvents grbConfiguraçõesGeral As System.Windows.Forms.GroupBox
        Friend WithEvents grpConfiguracoesEmail As System.Windows.Forms.GroupBox
        Friend WithEvents txtServidorSMTP As System.Windows.Forms.TextBox
        Friend WithEvents lblServidorSMTP As System.Windows.Forms.Label
        Friend WithEvents txtMostrar As System.Windows.Forms.TextBox
        Friend WithEvents lblMostrar As System.Windows.Forms.Label
        Friend WithEvents txtDe As System.Windows.Forms.TextBox
        Friend WithEvents lblDe As System.Windows.Forms.Label
        Friend WithEvents grpExportacaoRelatorios As System.Windows.Forms.GroupBox
        Friend WithEvents grbRelatorioCarteira As System.Windows.Forms.GroupBox
        Friend WithEvents rbtDOCCarteira As System.Windows.Forms.RadioButton
        Friend WithEvents rbtPDFCarteira As System.Windows.Forms.RadioButton
        Friend WithEvents grbRelatorioInventarioBens As System.Windows.Forms.GroupBox
        Friend WithEvents rbtDOCInventarioBens As System.Windows.Forms.RadioButton
        Friend WithEvents rbtPDFInventarioBens As System.Windows.Forms.RadioButton
        Friend WithEvents grbRelatorioMBPs As System.Windows.Forms.GroupBox
        Friend WithEvents rbtDOCMBP As System.Windows.Forms.RadioButton
        Friend WithEvents rbtPDFMBP As System.Windows.Forms.RadioButton
        Friend WithEvents grbRelatorioCautelas As System.Windows.Forms.GroupBox
        Friend WithEvents rbtDOCCautela As System.Windows.Forms.RadioButton
        Friend WithEvents rbtPDFCautela As System.Windows.Forms.RadioButton
        Friend WithEvents tabBens As System.Windows.Forms.TabPage
        Friend WithEvents btnLocalizacaoTextoEmailBens As System.Windows.Forms.Button
        Friend WithEvents lblLocalizacaoTextoEmailBens As System.Windows.Forms.Label
        Friend WithEvents txtLocalizacaoTextoEmailBens As System.Windows.Forms.TextBox
        Friend WithEvents lblNumeroLinhasBens As System.Windows.Forms.Label
        Friend WithEvents txtNumeroLinhasBens As System.Windows.Forms.TextBox
        Friend WithEvents btnLocalizacaoRelatorioBens As System.Windows.Forms.Button
        Friend WithEvents lblLocalizacaoRelatorioBens As System.Windows.Forms.Label
        Friend WithEvents txtLocalizacaoRelatorioBens As System.Windows.Forms.TextBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
        Friend WithEvents grbRelatorioBens As System.Windows.Forms.GroupBox
        Friend WithEvents rbtDOCBens As System.Windows.Forms.RadioButton
        Friend WithEvents rbtPDFBens As System.Windows.Forms.RadioButton
        Friend WithEvents tbpBens As System.Windows.Forms.TabPage
        Friend WithEvents rtbBens As System.Windows.Forms.RichTextBox
    End Class
End Namespace