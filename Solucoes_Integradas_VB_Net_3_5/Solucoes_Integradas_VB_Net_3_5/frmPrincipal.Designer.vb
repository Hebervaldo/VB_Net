Namespace Solucoes_Integradas_VB_Net_3_5
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
            Me.bar2 = New System.Windows.Forms.StatusStrip
            Me.barprgfrmPrincipal = New System.Windows.Forms.ToolStripProgressBar
            Me.barlblHorario = New System.Windows.Forms.ToolStripStatusLabel
            Me.barlblMostrHorario = New System.Windows.Forms.ToolStripStatusLabel
            Me.barlblContUser = New System.Windows.Forms.ToolStripStatusLabel
            Me.barlblMostrContUser = New System.Windows.Forms.ToolStripStatusLabel
            Me.barlblNomeUser = New System.Windows.Forms.ToolStripStatusLabel
            Me.barlblMostrNomeUser = New System.Windows.Forms.ToolStripStatusLabel
            Me.barlblbarStatus = New System.Windows.Forms.ToolStripStatusLabel
            Me.barlblStatusUser = New System.Windows.Forms.ToolStripStatusLabel
            Me.barlblMostrStatusUser = New System.Windows.Forms.ToolStripStatusLabel
            Me.tmr1 = New System.Windows.Forms.Timer(Me.components)
            Me.bar1 = New System.Windows.Forms.MenuStrip
            Me.mnuArquivo = New System.Windows.Forms.ToolStripMenuItem
            Me.smnEnviarEmail = New System.Windows.Forms.ToolStripMenuItem
            Me.smnExportar = New System.Windows.Forms.ToolStripMenuItem
            Me.ssmWord = New System.Windows.Forms.ToolStripMenuItem
            Me.ssmExcelSap_R3 = New System.Windows.Forms.ToolStripMenuItem
            Me.sssExcelRelatorio = New System.Windows.Forms.ToolStripMenuItem
            Me.sssExcelRelatorioItensSelecionados = New System.Windows.Forms.ToolStripMenuItem
            Me.sssExcelRelatorioTodosItens = New System.Windows.Forms.ToolStripMenuItem
            Me.sssExcelSap_R3 = New System.Windows.Forms.ToolStripMenuItem
            Me.sssExcelSap_R3ItensSelecionados = New System.Windows.Forms.ToolStripMenuItem
            Me.sssExcelSap_R3TodosItens = New System.Windows.Forms.ToolStripMenuItem
            Me.ssmAdobeReader = New System.Windows.Forms.ToolStripMenuItem
            Me.smnGerarDocumentos = New System.Windows.Forms.ToolStripMenuItem
            Me.ssmGerarCautela = New System.Windows.Forms.ToolStripMenuItem
            Me.ssmGerarMBP = New System.Windows.Forms.ToolStripMenuItem
            Me.smnImportar = New System.Windows.Forms.ToolStripMenuItem
            Me.ssmPrincipal = New System.Windows.Forms.ToolStripMenuItem
            Me.ssmColetor = New System.Windows.Forms.ToolStripMenuItem
            Me.smnImprimir = New System.Windows.Forms.ToolStripMenuItem
            Me.smnVisualizarImprimir = New System.Windows.Forms.ToolStripMenuItem
            Me.smnSair = New System.Windows.Forms.ToolStripMenuItem
            Me.mnuJanela = New System.Windows.Forms.ToolStripMenuItem
            Me.smnHorizontal = New System.Windows.Forms.ToolStripMenuItem
            Me.smnVertical = New System.Windows.Forms.ToolStripMenuItem
            Me.smnCascata = New System.Windows.Forms.ToolStripMenuItem
            Me.mnuConfiguracoes = New System.Windows.Forms.ToolStripMenuItem
            Me.smnConfiguracoes = New System.Windows.Forms.ToolStripMenuItem
            Me.smnContasUsuarios = New System.Windows.Forms.ToolStripMenuItem
            Me.smnMensagens = New System.Windows.Forms.ToolStripMenuItem
            Me.smnIconeNotificador = New System.Windows.Forms.ToolStripMenuItem
            Me.mnuFormularios = New System.Windows.Forms.ToolStripMenuItem
            Me.smnCADU = New System.Windows.Forms.ToolStripMenuItem
            Me.smnCarteiras = New System.Windows.Forms.ToolStripMenuItem
            Me.smnCautelas = New System.Windows.Forms.ToolStripMenuItem
            Me.smnCodigoBarras = New System.Windows.Forms.ToolStripMenuItem
            Me.smnColetorDados = New System.Windows.Forms.ToolStripMenuItem
            Me.smnBens = New System.Windows.Forms.ToolStripMenuItem
            Me.smnCentroCusto = New System.Windows.Forms.ToolStripMenuItem
            Me.smnInventario = New System.Windows.Forms.ToolStripMenuItem
            Me.smnMBPs = New System.Windows.Forms.ToolStripMenuItem
            Me.smnTabelaAuxiliar = New System.Windows.Forms.ToolStripMenuItem
            Me.mnuInformacoes = New System.Windows.Forms.ToolStripMenuItem
            Me.mnuSobre = New System.Windows.Forms.ToolStripMenuItem
            Me.sfd1 = New System.Windows.Forms.SaveFileDialog
            Me.ofd1 = New System.Windows.Forms.OpenFileDialog
            Me.tmrEdit_Notify = New System.Windows.Forms.Timer(Me.components)
            Me.ntf1 = New System.Windows.Forms.NotifyIcon(Me.components)
            Me.cms1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.csmsIconeNotificador = New System.Windows.Forms.ToolStripMenuItem
            Me.csmsMensagens = New System.Windows.Forms.ToolStripMenuItem
            Me.csmsParar = New System.Windows.Forms.ToolStripMenuItem
            Me.csmsSair = New System.Windows.Forms.ToolStripMenuItem
            Me.tmrSalvarBancoDados = New System.Windows.Forms.Timer(Me.components)
            Me.bar2.SuspendLayout()
            Me.bar1.SuspendLayout()
            Me.cms1.SuspendLayout()
            Me.SuspendLayout()
            '
            'bar2
            '
            Me.bar2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.barprgfrmPrincipal, Me.barlblHorario, Me.barlblMostrHorario, Me.barlblContUser, Me.barlblMostrContUser, Me.barlblNomeUser, Me.barlblMostrNomeUser, Me.barlblbarStatus, Me.barlblStatusUser, Me.barlblMostrStatusUser})
            Me.bar2.Location = New System.Drawing.Point(0, 639)
            Me.bar2.Name = "bar2"
            Me.bar2.Size = New System.Drawing.Size(1084, 22)
            Me.bar2.TabIndex = 1
            Me.bar2.Text = "Horario"
            '
            'barprgfrmPrincipal
            '
            Me.barprgfrmPrincipal.BackColor = System.Drawing.SystemColors.MenuBar
            Me.barprgfrmPrincipal.Name = "barprgfrmPrincipal"
            Me.barprgfrmPrincipal.Size = New System.Drawing.Size(100, 16)
            Me.barprgfrmPrincipal.Style = System.Windows.Forms.ProgressBarStyle.Continuous
            '
            'barlblHorario
            '
            Me.barlblHorario.BackColor = System.Drawing.Color.Transparent
            Me.barlblHorario.Name = "barlblHorario"
            Me.barlblHorario.Size = New System.Drawing.Size(53, 17)
            Me.barlblHorario.Text = " Horário:"
            '
            'barlblMostrHorario
            '
            Me.barlblMostrHorario.BackColor = System.Drawing.Color.Transparent
            Me.barlblMostrHorario.Name = "barlblMostrHorario"
            Me.barlblMostrHorario.Size = New System.Drawing.Size(0, 17)
            '
            'barlblContUser
            '
            Me.barlblContUser.BackColor = System.Drawing.Color.Transparent
            Me.barlblContUser.Name = "barlblContUser"
            Me.barlblContUser.Size = New System.Drawing.Size(102, 17)
            Me.barlblContUser.Text = "Conta do Usuário:"
            '
            'barlblMostrContUser
            '
            Me.barlblMostrContUser.BackColor = System.Drawing.Color.Transparent
            Me.barlblMostrContUser.Name = "barlblMostrContUser"
            Me.barlblMostrContUser.Size = New System.Drawing.Size(0, 17)
            '
            'barlblNomeUser
            '
            Me.barlblNomeUser.BackColor = System.Drawing.Color.Transparent
            Me.barlblNomeUser.Name = "barlblNomeUser"
            Me.barlblNomeUser.Size = New System.Drawing.Size(103, 17)
            Me.barlblNomeUser.Text = "Nome do Usuário:"
            '
            'barlblMostrNomeUser
            '
            Me.barlblMostrNomeUser.BackColor = System.Drawing.Color.Transparent
            Me.barlblMostrNomeUser.Name = "barlblMostrNomeUser"
            Me.barlblMostrNomeUser.Size = New System.Drawing.Size(0, 17)
            '
            'barlblbarStatus
            '
            Me.barlblbarStatus.BackColor = System.Drawing.Color.Transparent
            Me.barlblbarStatus.Name = "barlblbarStatus"
            Me.barlblbarStatus.Size = New System.Drawing.Size(0, 17)
            '
            'barlblStatusUser
            '
            Me.barlblStatusUser.BackColor = System.Drawing.Color.Transparent
            Me.barlblStatusUser.Name = "barlblStatusUser"
            Me.barlblStatusUser.Size = New System.Drawing.Size(102, 17)
            Me.barlblStatusUser.Text = "Status do Usuário:"
            '
            'barlblMostrStatusUser
            '
            Me.barlblMostrStatusUser.BackColor = System.Drawing.Color.Transparent
            Me.barlblMostrStatusUser.Name = "barlblMostrStatusUser"
            Me.barlblMostrStatusUser.Size = New System.Drawing.Size(0, 17)
            '
            'tmr1
            '
            '
            'bar1
            '
            Me.bar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuArquivo, Me.mnuJanela, Me.mnuConfiguracoes, Me.mnuFormularios, Me.mnuInformacoes, Me.mnuSobre})
            Me.bar1.Location = New System.Drawing.Point(0, 0)
            Me.bar1.Name = "bar1"
            Me.bar1.Size = New System.Drawing.Size(1084, 24)
            Me.bar1.TabIndex = 0
            '
            'mnuArquivo
            '
            Me.mnuArquivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnEnviarEmail, Me.smnExportar, Me.smnGerarDocumentos, Me.smnImportar, Me.smnImprimir, Me.smnVisualizarImprimir, Me.smnSair})
            Me.mnuArquivo.Name = "mnuArquivo"
            Me.mnuArquivo.Size = New System.Drawing.Size(61, 20)
            Me.mnuArquivo.Text = "&Arquivo"
            '
            'smnEnviarEmail
            '
            Me.smnEnviarEmail.Name = "smnEnviarEmail"
            Me.smnEnviarEmail.Size = New System.Drawing.Size(180, 22)
            Me.smnEnviarEmail.Text = "En&viar Email"
            '
            'smnExportar
            '
            Me.smnExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssmAdobeReader, Me.ssmExcelSap_R3, Me.ssmWord})
            Me.smnExportar.Name = "smnExportar"
            Me.smnExportar.Size = New System.Drawing.Size(180, 22)
            Me.smnExportar.Text = "&Exportar"
            '
            'ssmWord
            '
            Me.ssmWord.Name = "ssmWord"
            Me.ssmWord.Size = New System.Drawing.Size(180, 22)
            Me.ssmWord.Text = "Word (DOC)"
            '
            'ssmExcelSap_R3
            '
            Me.ssmExcelSap_R3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sssExcelRelatorio, Me.sssExcelSap_R3})
            Me.ssmExcelSap_R3.Name = "ssmExcelSap_R3"
            Me.ssmExcelSap_R3.Size = New System.Drawing.Size(180, 22)
            Me.ssmExcelSap_R3.Text = "Excel (XLS)"
            '
            'sssExcelRelatorio
            '
            Me.sssExcelRelatorio.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sssExcelRelatorioItensSelecionados, Me.sssExcelRelatorioTodosItens})
            Me.sssExcelRelatorio.Name = "sssExcelRelatorio"
            Me.sssExcelRelatorio.Size = New System.Drawing.Size(152, 22)
            Me.sssExcelRelatorio.Text = "Relatório"
            '
            'sssExcelRelatorioItensSelecionados
            '
            Me.sssExcelRelatorioItensSelecionados.Name = "sssExcelRelatorioItensSelecionados"
            Me.sssExcelRelatorioItensSelecionados.Size = New System.Drawing.Size(171, 22)
            Me.sssExcelRelatorioItensSelecionados.Text = "Itens Selecionados"
            '
            'sssExcelRelatorioTodosItens
            '
            Me.sssExcelRelatorioTodosItens.Name = "sssExcelRelatorioTodosItens"
            Me.sssExcelRelatorioTodosItens.Size = New System.Drawing.Size(171, 22)
            Me.sssExcelRelatorioTodosItens.Text = "Todos Itens"
            '
            'sssExcelSap_R3
            '
            Me.sssExcelSap_R3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sssExcelSap_R3ItensSelecionados, Me.sssExcelSap_R3TodosItens})
            Me.sssExcelSap_R3.Name = "sssExcelSap_R3"
            Me.sssExcelSap_R3.Size = New System.Drawing.Size(152, 22)
            Me.sssExcelSap_R3.Text = "Sap/R3"
            '
            'sssExcelSap_R3ItensSelecionados
            '
            Me.sssExcelSap_R3ItensSelecionados.Name = "sssExcelSap_R3ItensSelecionados"
            Me.sssExcelSap_R3ItensSelecionados.Size = New System.Drawing.Size(171, 22)
            Me.sssExcelSap_R3ItensSelecionados.Text = "Itens Selecionados"
            '
            'sssExcelSap_R3TodosItens
            '
            Me.sssExcelSap_R3TodosItens.Name = "sssExcelSap_R3TodosItens"
            Me.sssExcelSap_R3TodosItens.Size = New System.Drawing.Size(171, 22)
            Me.sssExcelSap_R3TodosItens.Text = "Todos Itens"
            '
            'ssmAdobeReader
            '
            Me.ssmAdobeReader.Name = "ssmAdobeReader"
            Me.ssmAdobeReader.Size = New System.Drawing.Size(180, 22)
            Me.ssmAdobeReader.Text = "Adobe Reader (PDF)"
            '
            'smnGerarDocumentos
            '
            Me.smnGerarDocumentos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssmGerarCautela, Me.ssmGerarMBP})
            Me.smnGerarDocumentos.Name = "smnGerarDocumentos"
            Me.smnGerarDocumentos.Size = New System.Drawing.Size(180, 22)
            Me.smnGerarDocumentos.Text = "&Gerar Documentos"
            Me.smnGerarDocumentos.ToolTipText = "Selecione a MBP "
            '
            'ssmGerarCautela
            '
            Me.ssmGerarCautela.Name = "ssmGerarCautela"
            Me.ssmGerarCautela.Size = New System.Drawing.Size(152, 22)
            Me.ssmGerarCautela.Text = "&Gerar Cautela"
            '
            'ssmGerarMBP
            '
            Me.ssmGerarMBP.Name = "ssmGerarMBP"
            Me.ssmGerarMBP.Size = New System.Drawing.Size(152, 22)
            Me.ssmGerarMBP.Text = "&Gerar MBP"
            '
            'smnImportar
            '
            Me.smnImportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ssmColetor, Me.ssmPrincipal})
            Me.smnImportar.Name = "smnImportar"
            Me.smnImportar.Size = New System.Drawing.Size(180, 22)
            Me.smnImportar.Text = "&Importar"
            '
            'ssmPrincipal
            '
            Me.ssmPrincipal.Name = "ssmPrincipal"
            Me.ssmPrincipal.Size = New System.Drawing.Size(237, 22)
            Me.ssmPrincipal.Text = "&Principal (Bens - Centro Custo)"
            '
            'ssmColetor
            '
            Me.ssmColetor.Name = "ssmColetor"
            Me.ssmColetor.Size = New System.Drawing.Size(237, 22)
            Me.ssmColetor.Text = "&Coletor (Bens - CentroCusto)"
            '
            'smnImprimir
            '
            Me.smnImprimir.Name = "smnImprimir"
            Me.smnImprimir.Size = New System.Drawing.Size(180, 22)
            Me.smnImprimir.Text = "I&mprimir"
            '
            'smnVisualizarImprimir
            '
            Me.smnVisualizarImprimir.Name = "smnVisualizarImprimir"
            Me.smnVisualizarImprimir.Size = New System.Drawing.Size(180, 22)
            Me.smnVisualizarImprimir.Text = "&Visualizar Impressao"
            '
            'smnSair
            '
            Me.smnSair.Name = "smnSair"
            Me.smnSair.Size = New System.Drawing.Size(180, 22)
            Me.smnSair.Text = "&Sair"
            '
            'mnuJanela
            '
            Me.mnuJanela.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnHorizontal, Me.smnVertical, Me.smnCascata})
            Me.mnuJanela.Name = "mnuJanela"
            Me.mnuJanela.Size = New System.Drawing.Size(51, 20)
            Me.mnuJanela.Text = "&Janela"
            '
            'smnHorizontal
            '
            Me.smnHorizontal.Name = "smnHorizontal"
            Me.smnHorizontal.Size = New System.Drawing.Size(201, 22)
            Me.smnHorizontal.Text = "Lado a lado - &Horizontal"
            '
            'smnVertical
            '
            Me.smnVertical.Name = "smnVertical"
            Me.smnVertical.Size = New System.Drawing.Size(201, 22)
            Me.smnVertical.Text = "Lado a lado - &Vertical"
            '
            'smnCascata
            '
            Me.smnCascata.Name = "smnCascata"
            Me.smnCascata.Size = New System.Drawing.Size(201, 22)
            Me.smnCascata.Text = "&Cascata"
            '
            'mnuConfiguracoes
            '
            Me.mnuConfiguracoes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnConfiguracoes, Me.smnContasUsuarios, Me.smnIconeNotificador, Me.smnMensagens})
            Me.mnuConfiguracoes.Name = "mnuConfiguracoes"
            Me.mnuConfiguracoes.Size = New System.Drawing.Size(96, 20)
            Me.mnuConfiguracoes.Text = "&Configurações"
            '
            'smnConfiguracoes
            '
            Me.smnConfiguracoes.Name = "smnConfiguracoes"
            Me.smnConfiguracoes.Size = New System.Drawing.Size(208, 22)
            Me.smnConfiguracoes.Text = "C&onfigurações"
            '
            'smnContasUsuarios
            '
            Me.smnContasUsuarios.Name = "smnContasUsuarios"
            Me.smnContasUsuarios.Size = New System.Drawing.Size(208, 22)
            Me.smnContasUsuarios.Text = "Co&ntas de Usuários"
            '
            'smnMensagens
            '
            Me.smnMensagens.Name = "smnMensagens"
            Me.smnMensagens.Size = New System.Drawing.Size(208, 22)
            Me.smnMensagens.Text = "&Ocultar Mensagens"
            '
            'smnIconeNotificador
            '
            Me.smnIconeNotificador.Name = "smnIconeNotificador"
            Me.smnIconeNotificador.Size = New System.Drawing.Size(208, 22)
            Me.smnIconeNotificador.Text = "&Ocultar Ícone Notificador"
            '
            'mnuFormularios
            '
            Me.mnuFormularios.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnBens, Me.smnCADU, Me.smnCarteiras, Me.smnCautelas, Me.smnCentroCusto, Me.smnCodigoBarras, Me.smnColetorDados, Me.smnInventario, Me.smnMBPs, Me.smnTabelaAuxiliar})
            Me.mnuFormularios.Name = "mnuFormularios"
            Me.mnuFormularios.Size = New System.Drawing.Size(82, 20)
            Me.mnuFormularios.Text = "&Formulários"
            '
            'smnCADU
            '
            Me.smnCADU.Name = "smnCADU"
            Me.smnCADU.Size = New System.Drawing.Size(165, 22)
            Me.smnCADU.Text = "&CADU"
            '
            'smnCarteiras
            '
            Me.smnCarteiras.Name = "smnCarteiras"
            Me.smnCarteiras.Size = New System.Drawing.Size(165, 22)
            Me.smnCarteiras.Text = "Ca&rteiras"
            '
            'smnCautelas
            '
            Me.smnCautelas.Name = "smnCautelas"
            Me.smnCautelas.Size = New System.Drawing.Size(165, 22)
            Me.smnCautelas.Text = "Ca&utelas"
            '
            'smnCodigoBarras
            '
            Me.smnCodigoBarras.Name = "smnCodigoBarras"
            Me.smnCodigoBarras.Size = New System.Drawing.Size(165, 22)
            Me.smnCodigoBarras.Text = "C&odigo de Barras"
            '
            'smnColetorDados
            '
            Me.smnColetorDados.Name = "smnColetorDados"
            Me.smnColetorDados.Size = New System.Drawing.Size(165, 22)
            Me.smnColetorDados.Text = "Cole&tor de Dados"
            '
            'smnBens
            '
            Me.smnBens.Name = "smnBens"
            Me.smnBens.Size = New System.Drawing.Size(165, 22)
            Me.smnBens.Text = "&Bens"
            '
            'smnCentroCusto
            '
            Me.smnCentroCusto.Name = "smnCentroCusto"
            Me.smnCentroCusto.Size = New System.Drawing.Size(165, 22)
            Me.smnCentroCusto.Text = "C&entro Custo"
            '
            'smnInventario
            '
            Me.smnInventario.Name = "smnInventario"
            Me.smnInventario.Size = New System.Drawing.Size(165, 22)
            Me.smnInventario.Text = "&Inventário"
            '
            'smnMBPs
            '
            Me.smnMBPs.Name = "smnMBPs"
            Me.smnMBPs.Size = New System.Drawing.Size(165, 22)
            Me.smnMBPs.Text = "&MBPs"
            '
            'smnTabelaAuxiliar
            '
            Me.smnTabelaAuxiliar.Name = "smnTabelaAuxiliar"
            Me.smnTabelaAuxiliar.Size = New System.Drawing.Size(165, 22)
            Me.smnTabelaAuxiliar.Text = "&Tabela Auxiliar"
            '
            'mnuInformacoes
            '
            Me.mnuInformacoes.Name = "mnuInformacoes"
            Me.mnuInformacoes.Size = New System.Drawing.Size(85, 20)
            Me.mnuInformacoes.Text = "&Informações"
            '
            'mnuSobre
            '
            Me.mnuSobre.Name = "mnuSobre"
            Me.mnuSobre.Size = New System.Drawing.Size(49, 20)
            Me.mnuSobre.Text = "&Sobre"
            '
            'ofd1
            '
            Me.ofd1.FileName = "OpenFileDialog1"
            '
            'tmrEdit_Notify
            '
            '
            'ntf1
            '
            Me.ntf1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
            Me.ntf1.ContextMenuStrip = Me.cms1
            Me.ntf1.Icon = CType(resources.GetObject("ntf1.Icon"), System.Drawing.Icon)
            Me.ntf1.Visible = True
            '
            'cms1
            '
            Me.cms1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.csmsIconeNotificador, Me.csmsMensagens, Me.csmsParar, Me.csmsSair})
            Me.cms1.Name = "cms1"
            Me.cms1.Size = New System.Drawing.Size(209, 92)
            '
            'csmsIconeNotificador
            '
            Me.csmsIconeNotificador.Name = "csmsIconeNotificador"
            Me.csmsIconeNotificador.Size = New System.Drawing.Size(208, 22)
            Me.csmsIconeNotificador.Text = "Ocultar &Ícone Notificador"
            '
            'csmsMensagens
            '
            Me.csmsMensagens.Name = "csmsMensagens"
            Me.csmsMensagens.Size = New System.Drawing.Size(208, 22)
            Me.csmsMensagens.Text = "&Ocultar Mensagens"
            '
            'csmsParar
            '
            Me.csmsParar.Name = "csmsParar"
            Me.csmsParar.Size = New System.Drawing.Size(208, 22)
            Me.csmsParar.Text = "&Parar"
            '
            'csmsSair
            '
            Me.csmsSair.Name = "csmsSair"
            Me.csmsSair.Size = New System.Drawing.Size(208, 22)
            Me.csmsSair.Text = "&Sair"
            '
            'tmrSalvarBancoDados
            '
            Me.tmrSalvarBancoDados.Interval = 14400000
            '
            'frmPrincipal
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.InactiveCaption
            Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ClientSize = New System.Drawing.Size(1084, 661)
            Me.Controls.Add(Me.bar1)
            Me.Controls.Add(Me.bar2)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.IsMdiContainer = True
            Me.MainMenuStrip = Me.bar1
            Me.Name = "frmPrincipal"
            Me.Text = "Eletronorte - Soluções Integradas"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.bar2.ResumeLayout(False)
            Me.bar2.PerformLayout()
            Me.bar1.ResumeLayout(False)
            Me.bar1.PerformLayout()
            Me.cms1.ResumeLayout(False)
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

        Friend WithEvents bar2 As System.Windows.Forms.StatusStrip
        Friend WithEvents barprgfrmPrincipal As System.Windows.Forms.ToolStripProgressBar
        Friend WithEvents barlblHorario As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents barlblMostrHorario As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents barlblContUser As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents barlblMostrContUser As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents tmr1 As System.Windows.Forms.Timer
        Friend WithEvents bar1 As System.Windows.Forms.MenuStrip
        Friend WithEvents mnuJanela As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuFormularios As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnHorizontal As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnVertical As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnCascata As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents barlblNomeUser As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents barlblMostrNomeUser As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents barlblbarStatus As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents barlblStatusUser As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents barlblMostrStatusUser As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents mnuConfiguracoes As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnCautelas As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuSobre As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnConfiguracoes As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnContasUsuarios As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents sfd1 As System.Windows.Forms.SaveFileDialog
        Friend WithEvents smnMBPs As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ofd1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents mnuInformacoes As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnCarteiras As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents mnuArquivo As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnEnviarEmail As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnExportar As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnGerarDocumentos As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnImportar As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ssmPrincipal As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnImprimir As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnVisualizarImprimir As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnSair As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ssmWord As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ssmAdobeReader As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnCADU As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnTabelaAuxiliar As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnBens As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnCentroCusto As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnInventario As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ssmExcelSap_R3 As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents tmrEdit_Notify As System.Windows.Forms.Timer
        Friend WithEvents ssmGerarCautela As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ssmGerarMBP As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ntf1 As System.Windows.Forms.NotifyIcon
        Friend WithEvents cms1 As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents csmsParar As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents csmsSair As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ssmColetor As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents csmsMensagens As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnMensagens As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnIconeNotificador As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents csmsIconeNotificador As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents tmrSalvarBancoDados As System.Windows.Forms.Timer
        Friend WithEvents sssExcelRelatorio As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents sssExcelSap_R3 As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnCodigoBarras As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents smnColetorDados As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents sssExcelRelatorioTodosItens As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents sssExcelSap_R3TodosItens As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents sssExcelRelatorioItensSelecionados As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents sssExcelSap_R3ItensSelecionados As System.Windows.Forms.ToolStripMenuItem
    End Class
End Namespace