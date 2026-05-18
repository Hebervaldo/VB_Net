Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThSalvarBancoDados As System.Threading.Thread

        Private strNomeProcessoSalvarBancoDados As String = "Salvar Banco de Dados"

        Friend Sub mtdIniciarThreadSalvarBancoDados()
            mtdIniciarThreadSalvarBancoDados(True)
        End Sub

        Friend Sub mtdIniciarThreadSalvarBancoDados(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoSalvarBancoDados
                blnAbortarThreadSalvarBancoDados = Not Iniciar
                blnForcarAbortarThreadSalvarBancoDados = False
                blnThreadAtivadaSalvarBancoDados = True
                blnSucessoSalvarBancoDados = False
                ThSalvarBancoDados = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadSalvarBancoDados))
                ThSalvarBancoDados.IsBackground = True
                ThSalvarBancoDados.Priority = System.Threading.ThreadPriority.Normal
                ThSalvarBancoDados.Start()

            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadSalvarBancoDados: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdReIniciarThreadSalvarBancoDados()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoSalvarBancoDados
            blnAbortarThreadSalvarBancoDados = False
            blnForcarAbortarThreadSalvarBancoDados = False

            blnThreadAtivadaSalvarBancoDados = True
            blnSucessoSalvarBancoDados = False
        End Sub

        Private Shared blnForcarAbortarThreadSalvarBancoDados As Boolean = False
        Private Shared blnAbortarThreadSalvarBancoDados As Boolean = False
        Private Shared intTempoSaidaAbortarThreadSalvarBancoDados As Integer = 1000

        Friend Sub mtdAbortarThreadSalvarBancoDados()
            mtdAbortarThreadSalvarBancoDados(False)
        End Sub

        Friend Sub mtdAbortarThreadSalvarBancoDados(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoSalvarBancoDados
            blnAbortarThreadSalvarBancoDados = True
            blnForcarAbortarThreadSalvarBancoDados = Forcar

            blnThreadAtivadaSalvarBancoDados = False
            blnSucessoSalvarBancoDados = False

            Try
                ThSalvarBancoDados.Join(intTempoSaidaAbortarThreadSalvarBancoDados)
                ThSalvarBancoDados.Abort()
                ThSalvarBancoDados = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadSalvarBancoDados: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Friend Sub mtdPararThreadSalvarBancoDados()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoSalvarBancoDados
            blnAbortarThreadSalvarBancoDados = True
            blnForcarAbortarThreadSalvarBancoDados = True

            blnThreadAtivadaSalvarBancoDados = False
            blnSucessoSalvarBancoDados = False
        End Sub

        Private Shared LockerSalvarBancoDados As New Object()

        Private Sub mtdRotinaThreadSalvarBancoDados()
            While Not blnForcarAbortarThreadSalvarBancoDados
                If Not blnAbortarThreadSalvarBancoDados Then
                    'System.Threading.Monitor.Enter(LockerSalvarBancoDados)
                    SyncLock (LockerSalvarBancoDados)
                        Try
                            mtdSalvarBancoDados()
                            mtdAbortarThreadSalvarBancoDados(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerSalvarBancoDados)
                        End Try
                    End SyncLock
                End If

                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Friend blnThreadAtivadaSalvarBancoDados As Boolean = False
        Friend blnSucessoSalvarBancoDados As Boolean = False

        Private Sub mtdRotinaSalvarBancoDados()
            mtdSalvarBancoDados()
        End Sub

        Public Sub mtdSalvarBancoDados()
            If (CUInt(strNumeroCopiasBackup) <> 0) Then
                intProgresso = 0
                strNomeProcesso = strNomeProcessoSalvarBancoDados
                blnSucessoSalvarBancoDados = False

                If (intContador <= CUInt(strNumeroCopiasBackup)) Then
                    mtdRealizarCopiaBancoDados()

                    intContador += 1
                Else
                    mtdRealizarCopiaBancoDados()

                    intContador = 1
                End If

                intProgresso = 100
                strNomeProcesso = strNomeProcessoSalvarBancoDados
                blnSucessoSalvarBancoDados = False
            End If
        End Sub

        Private Sub mtdRealizarCopiaBancoDados()
            Try
                System.IO.Directory.CreateDirectory(DiretorioArmazenamentoBackupCompleto)
            Catch ex As Exception

            End Try

            mtdCopiarArquivo _
            ( _
            strEnderecoBancoDadosPrincipal, _
            strNomeBaseDadosPrincipal, _
            DiretorioArmazenamentoBackupCompleto, _
            String.Format _
            ( _
            "{0}{1}", _
            strNomeBaseDadosPrincipal.Replace _
            ( _
            cntExtensaoBancoDadosPrincipal, _
            String.Format _
            ( _
            "Bkp_{0}", _
            intContador _
            ) _
            ), _
            cntExtensaoBancoDadosPrincipal _
            ), _
            True _
            )

            Dim objImplementacaoBancoDadosPrincipal As New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)

            objImplementacaoBancoDadosPrincipal.mtdDefinirStringConexaoAccess _
            ( _
            clsConexaoBancoDados.TipoConexao.ConexaoAccess2003OleDb, _
            String.Format _
            ( _
            "{0}\{1}{2}", _
            DiretorioArmazenamentoBackupCompleto, _
            strNomeBaseDadosPrincipal.Replace _
            ( _
            cntExtensaoBancoDadosPrincipal, _
            String.Format _
            ( _
            "Bkp_{0}", _
            intContador _
            ) _
            ), _
            cntExtensaoBancoDadosPrincipal _
            ), _
            String.Empty, _
            strSenhaPrincipal _
            )

            If objImplementacaoBancoDadosPrincipal.mtdAbrirConexao() Then
                objImplementacaoBancoDadosPrincipal.mtdFecharConexao()
                objImplementacaoBancoDadosPrincipal.mtdCompactarRepararBancoDadosAccess()
            End If

            objImplementacaoBancoDadosPrincipal.Dispose()

            Dim objImplementacaoBancoDadosColetor As New clsImplementacaoBancoDados(clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.SQLServerCE)

            objImplementacaoBancoDadosColetor.mtdDefinirStringConexaoSQLServerCE _
            ( _
            clsConexaoBancoDados.TipoConexao.ConexaoSQLServerCENativa, _
            String.Format _
            ( _
            "{0}{1}{2}", _
            DiretorioArmazenamentoBackupCompleto, _
            strNomeBaseDadosColetor.Replace _
            ( _
            cntExtensaoBancoDadosColetor, _
            String.Format _
            ( _
            "Bkp_{0}", _
            intContador _
            ) _
            ), _
            cntExtensaoBancoDadosColetor _
            ), _
            strSenhaColetor _
            )

            mtdCopiarArquivo _
            ( _
            strEnderecoBancoDadosColetor, _
            strNomeBaseDadosColetor, _
            DiretorioArmazenamentoBackupCompleto, _
            String.Format _
            ( _
            "{0}{1}", _
            strNomeBaseDadosColetor.Replace _
            ( _
            cntExtensaoBancoDadosColetor, _
            String.Format _
            ( _
            "Bkp_{0}", _
            intContador _
            ) _
            ), _
            cntExtensaoBancoDadosColetor _
            ), _
            True _
            )

            If objImplementacaoBancoDadosColetor.mtdAbrirConexao() Then
                objImplementacaoBancoDadosColetor.mtdFecharConexao()
                objImplementacaoBancoDadosColetor.mtdRepararBancoDadosSQLServerCE()
                objImplementacaoBancoDadosColetor.mtdCompactarBancoDadosSQLServerCE()
            End If

            objImplementacaoBancoDadosColetor.Dispose()
        End Sub

        Public Sub mtdCopiarArquivo(ByVal DiretorioOrigem As String, ByVal ArquivoOrigem As String, ByVal DiretorioDestino As String, ByVal ArquivoDestino As String, ByVal Sobreescrever As Boolean)
            Dim origemDiretorio As New System.IO.DirectoryInfo(DiretorioOrigem)
            Dim origemArquivo As New System.IO.FileInfo(ArquivoOrigem)
            Dim destinoDiretorio As New System.IO.DirectoryInfo(DiretorioDestino)
            Dim destinoArquivo As New System.IO.FileInfo(ArquivoDestino)

            Dim origemDiretorioArquivo As String = System.IO.Path.Combine(origemDiretorio.FullName, origemArquivo.Name)
            Dim destinoDiretorioArquivo As String = System.IO.Path.Combine(destinoDiretorio.FullName, destinoArquivo.Name)

            Dim strCalcularOrigemDiretorioArquivoCRC As String = mtdCalcularCRC(origemDiretorioArquivo)
            Dim strCalcularDestinoDiretorioArquivoCRC As String = mtdCalcularCRC(destinoDiretorioArquivo)

            If _
                ( _
                ( _
                strCalcularDestinoDiretorioArquivoCRC = String.Empty _
                And _
                strCalcularOrigemDiretorioArquivoCRC = String.Empty _
                ) _
                Or _
                strCalcularOrigemDiretorioArquivoCRC _
                <> _
                strCalcularDestinoDiretorioArquivoCRC _
                ) _
                Then
                Try
                    Dim objOrigemDiretorioArquivo As New System.IO.FileInfo(origemDiretorioArquivo)
                    objOrigemDiretorioArquivo.CopyTo(destinoDiretorioArquivo, Sobreescrever)
                Catch ex As System.Exception
                    Dim strExcecao As String = "mtdCopiarDiretorio: " & ex.Message
                    System.Diagnostics.Debug.WriteLine(strExcecao)
                End Try
            End If
        End Sub

        Private file As System.IO.FileStream = Nothing
        Private stream As clsCrcStream = Nothing

        Public Function mtdCalcularCRC(ByVal arquivo As String) As String
            Dim retorno As String = String.Empty

            ' Abre um fluxo de stream e o encapsula em um CrcStream
            Try
                file = New System.IO.FileStream(arquivo, System.IO.FileMode.Open)
                stream = New clsCrcStream(file)

                ' Usa o arquivo - neste caso le o arquivo como uma string
                Dim reader As System.IO.StreamReader = New System.IO.StreamReader(stream)
                Dim texto As String = reader.ReadToEnd()

                'Imprime o checksum calculado

                retorno = stream.ReadCrc.ToString("X8")
            Catch ex As Exception
                ' MessageBox.Show("Erro ao acessar o arquivo :  " + ex.Message);

                Dim strExcecao As String = "mtdCalcularCRC: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
            Return retorno
        End Function
    End Class
End Namespace