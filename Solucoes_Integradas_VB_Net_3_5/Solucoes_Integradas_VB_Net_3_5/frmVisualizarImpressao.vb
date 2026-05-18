Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmVisualizarImpressao
        Protected Friend Shared Tabela As String = String.Empty
        Protected Friend Shared SQL As String = String.Empty
        Protected Friend Shared strEnderecoRelatorio As String = String.Empty

        Private objBDPrincipal As clsImplementacaoBancoDados
        Private cryRpt As ReportDocument = New ReportDocument()
        Private crTableLogOnInfo As CrystalDecisions.Shared.TableLogOnInfo
        Private crTableLogOnInfos As CrystalDecisions.Shared.TableLogOnInfos
        Private crConnectionInfo As ConnectionInfo
        Private crTable As CrystalDecisions.CrystalReports.Engine.Table
        Private crTables As CrystalDecisions.CrystalReports.Engine.Tables
        Private totalPages As Integer = 2
        Private page As Integer
        Private maxPage As Integer
        Private myFont As System.Drawing.Font = Nothing

        Private Sub frmImpressao_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            mtdDefinirRelatorio()
            crv1.DisplayGroupTree = True
            crv1.ShowPrintButton = True
            crv1.ShowRefreshButton = True
            crv1.ShowCloseButton = True
            crv1.ShowGroupTreeButton = True
            crv1.ReportSource = cryRpt
            crv1.Refresh()
        End Sub

        Protected Friend Function mtdDefinirRelatorio() As Boolean
            Dim Retorno As Boolean = False

            Try
                objBDPrincipal = New clsImplementacaoBancoDados(frmPrincipal.strConexaoBancoDadosPrincipal, frmVisualizarImpressao.SQL, clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                crTableLogOnInfo = New CrystalDecisions.Shared.TableLogOnInfo()
                crTableLogOnInfos = New CrystalDecisions.Shared.TableLogOnInfos()
                crConnectionInfo = New ConnectionInfo()
                objBDPrincipal.mtdAbrirConexao()
                Retorno = objBDPrincipal.mtdExecutarComando()
                objBDPrincipal.mtdAdaptadorDados(Tabela)

                strEnderecoRelatorio = String.Empty

                Select Case frmPrincipal.numFormularioSelecionado
                    Case 1
                        strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCautela
                        cryRpt.Load(strEnderecoRelatorio)
                    Case 2
                        strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioMBP
                        cryRpt.Load(strEnderecoRelatorio)
                    Case 3
                        strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioCarteira
                        cryRpt.Load(strEnderecoRelatorio)
                        'cryRpt.OpenSubreport("ImpressaoCarteiraBens.rpt")
                    Case 4
                        strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioInventarioBens
                        cryRpt.Load(strEnderecoRelatorio)
                    Case 5
                        strEnderecoRelatorio = frmPrincipal.strEnderecoRelatorioBens
                        cryRpt.Load(strEnderecoRelatorio)
                End Select
                'crConnectionInfo.ServerName = frmPrincipal.strNomeServidorPrincipal ' Nome do seu servidor.
                'crConnectionInfo.DatabaseName = frmPrincipal.strNomeBaseDadosPrincipal ' Nome da base de dados
                'crConnectionInfo.UserID = frmPrincipal.strIdentificadorUsuarioPrincipal ' Nome de usuário da base de dados
                crConnectionInfo.Password = frmPrincipal.strSenhaPrincipal ' Senha da base de dados
                crTables = cryRpt.Database.Tables
                For Each Me.crTable In crTables
                    crTableLogOnInfo = Me.crTable.LogOnInfo
                    crTableLogOnInfo.ConnectionInfo = crConnectionInfo
                    Me.crTable.ApplyLogOnInfo(crTableLogOnInfo)
                Next
                cryRpt.SetDataSource(objBDPrincipal.prpAjustadorDados)

                objBDPrincipal.Dispose()
            Catch ex As System.Exception
                Retorno = False

                System.Windows.Forms.MessageBox.Show _
                            ( _
                            "Não foi possível carregar o relatório.", _
                            "Aviso!", _
                            MessageBoxButtons.OK _
                            )
            End Try

            Return Retorno
        End Function

        Protected Friend Function mtdDialogo() As Boolean
            Dim blnOpcaoDialogo As Boolean = False

            Try
                Me.ptdg1.Document = Me.ptdc1
                Dim dr As DialogResult = New DialogResult()

                dr = Me.ptdg1.ShowDialog()
                If dr = DialogResult.OK Then
                    ' Get the Copy times
                    _nCopy = Me.ptdc1.PrinterSettings.Copies
                    ' Get the number of Start Page
                    _sPage = Me.ptdc1.PrinterSettings.FromPage
                    ' Get the number of End Page
                    _ePage = Me.ptdc1.PrinterSettings.ToPage
                    _PrinterName = Me.ptdc1.PrinterSettings.PrinterName
                    blnOpcaoDialogo = True
                Else
                    blnOpcaoDialogo = False
                End If
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show _
                            ( _
                            "Não foi possível carregar o relatório.", _
                            "Aviso!", _
                            MessageBoxButtons.OK _
                            )
            End Try

            Return blnOpcaoDialogo
        End Function

        Private Sub frmVisualizarImpressao_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            Try
                Me.Dispose()
            Catch ex As Exception

            End Try
        End Sub
    End Class
End Namespace