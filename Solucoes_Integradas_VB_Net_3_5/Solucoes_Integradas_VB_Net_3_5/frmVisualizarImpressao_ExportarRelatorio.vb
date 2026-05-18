Imports CrystalDecisions.Shared

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmVisualizarImpressao
        Private _eft As CrystalDecisions.Shared.ExportFormatType
        Private _EnderecoArquivo As String

        Private blnExportarRelatorio As Boolean = False

        Protected Friend Function mtdExportarRelatorio() As Boolean
            mtdDefinirRelatorio()

            Try
                Dim CrExportOptions As ExportOptions = New ExportOptions()
                Dim CrDiskFileDestinationOptions As DiskFileDestinationOptions = New DiskFileDestinationOptions()
                Dim CrFormatTypeOptions As PdfRtfWordFormatOptions = New PdfRtfWordFormatOptions()
                CrDiskFileDestinationOptions.DiskFileName = _EnderecoArquivo
                CrExportOptions = cryRpt.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = _eft
                    .FormatOptions = CrFormatTypeOptions
                    .DestinationOptions = CrDiskFileDestinationOptions
                End With

                cryRpt.Export()

                blnExportarRelatorio = True
            Catch ex As Exception
                'MessageBox.Show("Houve problemas ao exportar o(s) relatório(s).", "Aviso!", MessageBoxButtons.OK)
                frmPrincipal.mtdExibirNotificacao("Houve problemas ao exportar o(s) relatório(s).")

                blnExportarRelatorio = False
            End Try

            Return blnExportarRelatorio
        End Function

        Protected Friend Function mtdExportarRelatorio(ByVal eft As CrystalDecisions.Shared.ExportFormatType, ByVal EnderecoArquivo As String) As Boolean
            _eft = eft
            _EnderecoArquivo = EnderecoArquivo

            Return mtdExportarRelatorio()
        End Function
    End Class
End Namespace