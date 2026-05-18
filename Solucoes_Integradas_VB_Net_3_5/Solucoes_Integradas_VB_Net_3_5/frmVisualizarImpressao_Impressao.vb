Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmVisualizarImpressao
        Private Shared _nCopy As Integer = 0
        Private Shared _sPage As Integer = 0
        Private Shared _ePage As Integer = 0
        Private Shared _PrinterName As String = String.Empty

        Protected Friend Function mtdImprimir() As Boolean
            Dim blnRetorno As Boolean = False

            Try
                ' Open the PrintDialog

                blnRetorno = mtdDefinirRelatorio()

                If blnRetorno Then
                    ' Set the printer name to print the report to.  By default the sample
                    ' report does not have a defult printer specified.  This will tell the
                    ' engine to use the specified printer to print the report.  Print out 
                    ' a test page (from Printer properties) to get the correct value.
                    cryRpt.PrintOptions.PrinterName = _PrinterName
                    ' Start the printing process. Provide details of the print job
                    ' using the arguments.
                    cryRpt.PrintToPrinter(_nCopy, True, _sPage, _ePage)
                    ' Let the user know that the print job is completed
                End If
            Catch ex As Exception
                'MessageBox.Show("Houve problemas ao imprimir o(s) relatório(s).", "Aviso!", MessageBoxButtons.OK)
                frmPrincipal.mtdExibirNotificacao("Houve problemas ao imprimir o(s) relatório(s).")

                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Protected Friend Function mtdImprimir(ByVal nCopy As Integer, ByVal sPage As Integer, ByVal ePage As Integer, ByVal PrinterName As String) As Boolean
            _nCopy = nCopy
            _sPage = sPage
            _ePage = ePage
            _PrinterName = PrinterName

            Return mtdImprimir()
        End Function
    End Class
End Namespace