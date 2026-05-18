Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class frmPrincipal
        Private ThGerarCarteiraCautela As System.Threading.Thread

        Private strNomeProcessoGerarCarteiraCautela As String = "Gerar Cautela (Carteira)"

        Private Sub mtdIniciarThreadGerarCarteiraCautela(ByVal Codigo As Long)
            lngCodigoGerarCarteiraCautela = Codigo

            mtdIniciarThreadGerarCarteiraCautela(True)
        End Sub

        Private Sub mtdIniciarThreadGerarCarteiraCautela()
            mtdIniciarThreadGerarCarteiraCautela(True)
        End Sub

        Private Sub mtdIniciarThreadGerarCarteiraCautela(ByVal Iniciar As Boolean)
            Try
                intProgresso = 0
                strNomeProcesso = strNomeProcessoGerarCarteiraCautela
                blnAbortarThreadGerarCarteiraCautela = Not Iniciar
                blnForcarAbortarThreadGerarCarteiraCautela = False
                blnThreadAtivadaGerarCarteiraCautela = True
                blnSucessoGerarCarteiraCautela = False
                ThGerarCarteiraCautela = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf mtdRotinaThreadGerarCarteiraCautela))
                ThGerarCarteiraCautela.IsBackground = True
                ThGerarCarteiraCautela.Priority = System.Threading.ThreadPriority.Normal
                ThGerarCarteiraCautela.Start()
            Catch ex As Exception
                Dim strExcecao As String = "mtdIniciarThreadGerarCarteiraCautela: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdReIniciarThreadGerarCarteiraCautela()
            intProgresso = 0
            strNomeProcesso = strNomeProcessoGerarCarteiraCautela
            blnAbortarThreadGerarCarteiraCautela = False
            blnForcarAbortarThreadGerarCarteiraCautela = False

            blnThreadAtivadaGerarCarteiraCautela = True
            blnSucessoGerarCarteiraCautela = False
        End Sub

        Private Shared blnForcarAbortarThreadGerarCarteiraCautela As Boolean = False
        Private Shared blnAbortarThreadGerarCarteiraCautela As Boolean = False
        Private Shared intTempoSaidaAbortarThreadGerarCarteiraCautela As Integer = 1000

        Private Sub mtdAbortarThreadGerarCarteiraCautela()
            mtdAbortarThreadGerarCarteiraCautela(False)
        End Sub

        Private Sub mtdAbortarThreadGerarCarteiraCautela(ByVal Forcar As Boolean)
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoGerarCarteiraCautela
            blnAbortarThreadGerarCarteiraCautela = True
            blnForcarAbortarThreadGerarCarteiraCautela = Forcar

            blnThreadAtivadaGerarCarteiraCautela = False
            blnSucessoGerarCarteiraCautela = False

            Try
                ThGerarCarteiraCautela.Join(intTempoSaidaAbortarThreadGerarCarteiraCautela)
                ThGerarCarteiraCautela.Abort()
                ThGerarCarteiraCautela = Nothing
            Catch ex As Exception
                Dim strExcecao As String = "mtdAbortarThreadGerarCarteiraCautela: " + ex.Message
                System.Diagnostics.Debug.WriteLine(strExcecao)
            End Try
        End Sub

        Private Sub mtdPararThreadGerarCarteiraCautela()
            intProgresso = 100
            System.Threading.Thread.Sleep(1)
            intProgresso = 0
            strNomeProcesso = strNomeProcessoGerarCarteiraCautela
            blnAbortarThreadGerarCarteiraCautela = True
            blnForcarAbortarThreadGerarCarteiraCautela = True

            blnThreadAtivadaGerarCarteiraCautela = False
            blnSucessoGerarCarteiraCautela = False
        End Sub

        Private Shared LockerGerarCarteiraCautela As New Object()

        Private Sub mtdRotinaThreadGerarCarteiraCautela()
            While Not blnForcarAbortarThreadGerarCarteiraCautela
                If Not blnAbortarThreadGerarCarteiraCautela Then
                    'System.Threading.Monitor.Enter(LockerGerarCarteiraCautela)
                    SyncLock (LockerGerarCarteiraCautela)
                        Try
                            mtdGerarCarteiraCautela()
                            mtdAbortarThreadGerarCarteiraCautela(True)
                        Finally
                            'System.Threading.Monitor.[Exit](LockerGerarCarteiraCautela)
                        End Try
                    End SyncLock
                End If
                System.Threading.Thread.Sleep(1)
            End While
        End Sub

        Private blnThreadAtivadaGerarCarteiraCautela As Boolean = False
        Private blnSucessoGerarCarteiraCautela As Boolean = False

        'Private strNomeArquivoGerarCarteiraCautela As String = String.Empty
        'Private strCampo As String = String.Empty
        'Private strDado As String = String.Empty

        Private lngCodigoGerarCarteiraCautela As Long = 0

        Private Sub mtdGerarCarteiraCautela()
            Try
                If bcmb4text <> String.Empty And bcmb5text <> String.Empty Then
                    If MessageBox.Show("Deseja gerar a(s) cautela(s) da(s) carteira(s) selecionada(s)?", "Aviso!", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                        intProgresso = 0
                        strNomeProcesso = strNomeProcessoImprimirCautela
                        blnSucessoImprimirCautela = True

                        If Int32.Parse(bcmb4text) >= Int32.Parse(bcmb5text) Then
                            Dim intVarTemp As String = bcmb4text
                            bcmb4text = bcmb5text
                            bcmb5text = intVarTemp
                        End If
                        If Int32.Parse(bcmb4text) < Int32.Parse(objDtgv1MinimoValor.ToString()) Then
                            bcmb4text = objDtgv1MinimoValor.ToString()
                        ElseIf Int32.Parse(bcmb5text) > Int32.Parse(objDtgv1MaximoValor.ToString()) Then
                            bcmb5text = objDtgv1MaximoValor.ToString()
                        End If

                        For contador As Integer = 0 To elemento.Count - 1 Step 1
                            If elemento(contador).ToString() <> String.Empty Then
                                If Convert.ToInt32(elemento(contador).ToString()) >= Int32.Parse(bcmb4text) And Convert.ToInt32(elemento(contador).ToString()) <= Int32.Parse(bcmb5text) Then
                                    lngCodigoGerarCarteiraCautela = CLng(elemento(contador).ToString())
                                    mtdGerarCarteiraCautelaIndividual()
                                End If
                            End If
                            System.Threading.Thread.Sleep(1)
                        Next
                    End If
                Else
                    lngCodigoGerarCarteiraCautela = CLng(frmCarteiras.Codigo)
                    mtdGerarCarteiraCautelaIndividual()
                End If
            Catch ex As Exception
                lngCodigoGerarCarteiraCautela = CLng(frmCarteiras.Codigo)
                mtdGerarCarteiraCautelaIndividual()
            Finally
            End Try
        End Sub

        Private Sub mtdGerarCarteiraCautelaIndividual()
            Try
                Dim arrayCarteira() As String

                Dim intNumeroControle As Integer = frmPrincipal.intMultiplicadorCodigoCautelas

                Dim objBancoDados As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                Dim strNumeroCautela As String = "CAUTELA - "
                Dim objBDPrincipal As New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objBDPrincipal.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosPrincipal)
                Dim objBDPrincipal1 As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                 frmPrincipal.strConexaoBancoDadosPrincipal, _
                                                                 "SELECT tblCarteira.* FROM tblCarteira WHERE tblCarteira.Codigo LIKE '" & lngCodigoGerarCarteiraCautela & "';", _
                                                                 clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objBDPrincipal1.mtdAbrirConexao()
                objBDPrincipal1.mtdExecutarComando()
                objBDPrincipal1.mtdDefinirLeitorDados()
                objBDPrincipal1.mtdProximoRegistro()
                Dim objBDPrincipal2 As clsImplementacaoBancoDados = New clsImplementacaoBancoDados( _
                                                                 frmPrincipal.strConexaoBancoDadosPrincipal, _
                                                                 "SELECT DISTINCT tblCarteiraBens.Matricula_Responsavel FROM tblCarteiraBens WHERE ((tblCarteiraBens.Codigo) LIKE '" & lngCodigoGerarCarteiraCautela & "') ORDER BY tblCarteiraBens.Matricula_Responsavel;", _
                                                                 clsImplementacaoBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objBDPrincipal2.mtdAbrirConexao()
                objBDPrincipal2.mtdExecutarComando()
                objBDPrincipal2.mtdDefinirLeitorDados()
                Dim numMaxRegistroDR2 As Integer = objBDPrincipal2.mtdNumeroLinhas()
                objBDPrincipal2.mtdDefinirLeitorDados()
                Dim numColunaDR2 As Integer = objBDPrincipal2.mtdNumeroColunas()
                objBDPrincipal2.mtdProximoRegistro()
                Dim objBDPrincipal21 As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objBDPrincipal21.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosPrincipal)
                Dim objBDPrincipal3 As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objBDPrincipal3.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosPrincipal)
                Dim objBDPrincipal4 As clsImplementacaoBancoDados = New clsImplementacaoBancoDados(clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb)
                objBDPrincipal4.mtdAbrirConexao(frmPrincipal.strConexaoBancoDadosPrincipal)
                objBDPrincipal4.mtdExecutarComando("SELECT tblCautelaBens.* FROM tblCautelaBens ORDER BY tblCautelaBens.Contador DESC;")
                objBDPrincipal4.mtdDefinirLeitorDados()
                Dim numMaxRegistroDR4 As Integer = objBDPrincipal4.mtdNumeroLinhas()
                objBDPrincipal4.mtdDefinirLeitorDados()
                Dim numColunaDR4 As Integer = objBDPrincipal4.mtdNumeroColunas()
                objBDPrincipal4.mtdProximoRegistro()
                Dim strSQL As String = String.Empty
                Dim maxContador As ULong = 0
                ' Procedimento vinculado ao resgate do valor do prazo de re-envio da cautela.
                Dim strPrazoEntregaCautela As String = objRegistroWindows.mtdObterDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "strPrazoEntregaCautela").ToString()
                If objRegistroWindows.getmensagemExcecao.Equals("Object reference not set to an instance of an object.") Or objRegistroWindows.getmensagemExcecao = "Não há conteúdo na variável mensagemExcecao." Then
                    objRegistroWindows.mtdSalvarDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela", frmConfiguracoes.PrazoEntregaCautela.ToString(), Microsoft.Win32.RegistryValueKind.DWord)
                    strPrazoEntregaCautela = objRegistroWindows.mtdObterDadosRegistro(Microsoft.Win32.Registry.CurrentUser, "Software", "Eletronorte", "Eletronorte - Soluções Integradas", "PrazoEntregaCautela").ToString()
                End If
                If numMaxRegistroDR2 > 1 Then
                    strNumeroCautela = "CAUTELAS - "
                End If
                Dim numInicioContador As Integer = 0
                If objBDPrincipal2.mtdObterValorRegistro(0).Equals(String.Empty) And numMaxRegistroDR2 > 1 Then
                    numInicioContador = 1
                    objBDPrincipal2.mtdProximoRegistro()
                End If

                intProgresso = 0
                strNomeProcesso = strNomeProcessoGerarCarteiraCautela
                blnSucessoGerarCarteiraCautela = True

                For contador As Integer = numInicioContador To numMaxRegistroDR2 - 1 Step 1
                    Dim strMatricula As String = String.Empty
                    If Not objBDPrincipal2.mtdObterValorRegistro(0).Equals(String.Empty) Then
                        strMatricula = objBDPrincipal2.mtdObterValorRegistro(0).ToString()
                    Else
                        strMatricula = objBDPrincipal1.mtdObterValorRegistro(2).ToString()
                    End If
                    objBDPrincipal.mtdExecutarComando("SELECT tblEmpregados.*, tblCentroCusto.CentroCusto FROM tblEmpregados LEFT JOIN tblCentroCusto ON tblEmpregados.Orgao=tblCentroCusto.Orgao WHERE tblEmpregados.Matricula LIKE '" & strMatricula & "%';")
                    objBDPrincipal.mtdDefinirLeitorDados()
                    objBDPrincipal.mtdProximoRegistro()
                    objBDPrincipal3.mtdExecutarComando("SELECT tblCautela.* FROM tblCautela ORDER BY tblCautela.Codigo DESC")
                    objBDPrincipal3.mtdDefinirLeitorDados()
                    objBDPrincipal3.mtdProximoRegistro()
                    Try
                        maxContador = Convert.ToUInt64(objBDPrincipal3.mtdObterValorRegistro(0))
                        strNumeroCautela &= maxContador + 1 & ", "
                        If Not (maxContador > DateAndTime.Year(DateAndTime.Now) * intNumeroControle And maxContador < (DateAndTime.Year(DateAndTime.Now) + 1) * intNumeroControle) Then
                            objBDPrincipal3.mtdExecutarComando("SELECT * FROM tblCautela WHERE Codigo > " & DateAndTime.Year(DateAndTime.Now) * intNumeroControle & " AND Codigo < " & (DateAndTime.Year(DateAndTime.Now) + 1) * intNumeroControle & " ORDER BY Codigo DESC;")
                            objBDPrincipal3.mtdDefinirLeitorDados()
                            objBDPrincipal3.mtdProximoRegistro()
                            If Not objBDPrincipal3.mtdObterValorRegistro(0).ToString() = "O Leitor de Dados (DataReader-dr) ainda não foi aberto." Then
                                maxContador = Convert.ToUInt64(objBDPrincipal3.mtdObterValorRegistro(0))
                            Else
                                maxContador = Convert.ToUInt64(DateAndTime.Year(DateAndTime.Now) * intNumeroControle)
                            End If
                        End If
                    Catch ex As Exception
                        maxContador = Convert.ToUInt64(DateAndTime.Year(DateAndTime.Now) * intNumeroControle)
                        strNumeroCautela &= maxContador + 1 & ", "
                    Finally
                        arrayCarteira = New String(objBDPrincipal.mtdNumeroColunas() - 1) {}
                        For contador2 As Integer = arrayCarteira.GetLowerBound(0) To arrayCarteira.GetUpperBound(0) Step 1
                            arrayCarteira(contador2) = objBDPrincipal.mtdObterValorRegistro(contador2).ToString()
                            System.Threading.Thread.Sleep(1)
                        Next
                        If arrayCarteira.Length > 0 Then
                            If arrayCarteira(1).Equals(String.Empty) Then
                                arrayCarteira(1) = "0"
                            End If
                            If arrayCarteira(9).Equals(String.Empty) Then
                                arrayCarteira(9) = "0"
                            End If
                        End If
                        strSQL = "INSERT INTO tblCautela (Codigo, Centro_Custo, Orgao, Responsavel, Matricula, Criado_Por_Usuario, Data_Criacao, Modificado_Por_Usuario, Data_Modificacao, Data_Impressao, Data_Envio, Data_Recebimento, Prazo_Entrega, Observacoes) " & _
                        "VALUES ('" & _
                        maxContador + 1 & _
                        "', '" & _
                        If(arrayCarteira.Length > 9, arrayCarteira(9), "0") & _
                        "', '" & _
                        If(arrayCarteira.Length > 2, arrayCarteira(2), String.Empty) & _
                        "', '" & _
                        If(objBDPrincipal1.mtdObterValorRegistro(1).ToString() <> String.Empty, objBDPrincipal1.mtdObterValorRegistro(1).ToString(), If(arrayCarteira.Length > 0, arrayCarteira(0), String.Empty)) & _
                        "', '" & _
                        If(objBDPrincipal1.mtdObterValorRegistro(2).ToString() <> String.Empty, objBDPrincipal1.mtdObterValorRegistro(2).ToString(), If(arrayCarteira.Length > 1, arrayCarteira(1), "0")) & _
                        "', '" & _
                        Me.barlblMostrContUser.Text & _
                        "', #" & _
                        DateAndTime.Now & _
                        "#, '" & _
                        Me.barlblMostrContUser.Text & _
                        "', #" & _
                        DateAndTime.Now & _
                        "#, #1/1/2000#, #1/1/2000#, #1/1/2000#, '" & _
                        strPrazoEntregaCautela & _
                        "', '" & _
                        "CARTEIRA - " & _
                        lngCodigoGerarCarteiraCautela.ToString() & _
                        "');"
                        objBDPrincipal3.mtdExecutarComando(strSQL)
                    End Try
                    If objBDPrincipal2.mtdObterValorRegistro(0).Equals(objBDPrincipal1.mtdObterValorRegistro(4)) Or objBDPrincipal2.mtdObterValorRegistro(0).Equals(String.Empty) Then
                        objBDPrincipal21.mtdExecutarComando("SELECT tblCarteiraBens.* FROM tblCarteiraBens WHERE (((tblCarteiraBens.Codigo) LIKE '" & lngCodigoGerarCarteiraCautela.ToString() & "') AND (((tblCarteiraBens.Matricula_Responsavel) LIKE '" & objBDPrincipal2.mtdObterValorRegistro(0).ToString() & "%') OR (tblCarteiraBens.Matricula_Responsavel) IS NULL));")
                    Else
                        objBDPrincipal21.mtdExecutarComando("SELECT tblCarteiraBens.* FROM tblCarteiraBens WHERE (((tblCarteiraBens.Codigo) LIKE '" & lngCodigoGerarCarteiraCautela.ToString() & "') AND (tblCarteiraBens.Matricula_Responsavel) LIKE '" & objBDPrincipal2.mtdObterValorRegistro(0).ToString() & "%');")
                    End If
                    objBDPrincipal21.mtdDefinirLeitorDados()
                    Dim numMaxRegistroDR21 As Integer = objBDPrincipal21.mtdNumeroLinhas() ' Define o Leitor de Dados (Data Reader).
                    objBDPrincipal21.mtdDefinirLeitorDados()
                    Dim numColunaDR21 As Integer = objBDPrincipal21.mtdNumeroColunas()
                    Dim arrayCarteiraBens() As String = New String(numColunaDR21 - 1) {}
                    Dim arrayCautelaBens() As String = New String(numColunaDR4 - 1) {}
                    For contador2 As Integer = 0 To numMaxRegistroDR21 - 1 Step 1
                        objBDPrincipal21.mtdProximoRegistro()
                        For cont As Integer = arrayCarteiraBens.GetLowerBound(0) To arrayCarteiraBens.GetUpperBound(0) Step 1
                            arrayCarteiraBens(cont) = objBDPrincipal21.mtdObterValorRegistro(cont).ToString()
                            System.Threading.Thread.Sleep(1)
                        Next
                        Dim maxContador2 As ULong = 0
                        Dim Codigo As ULong = maxContador + Convert.ToUInt64(1)
                        objBDPrincipal4.mtdExecutarComando("SELECT tblCautelaBens.* FROM tblCautelaBens ORDER BY tblCautelaBens.Contador DESC;")
                        objBDPrincipal4.mtdDefinirLeitorDados()
                        numMaxRegistroDR4 = objBDPrincipal4.mtdNumeroLinhas()
                        objBDPrincipal4.mtdDefinirLeitorDados()
                        numColunaDR4 = objBDPrincipal4.mtdNumeroColunas()
                        objBDPrincipal4.mtdProximoRegistro()
                        Try
                            maxContador2 = Convert.ToUInt64(objBDPrincipal4.mtdObterValorRegistro(0))
                            Try
                                objBDPrincipal4.mtdExecutarComando("SELECT tblCautelaBens.* FROM tblCautelaBens WHERE tblCautelaBens.Codigo LIKE " & Codigo & " ORDER BY tblCautelaBens.Contador DESC;")
                                objBDPrincipal4.mtdDefinirLeitorDados()
                                numMaxRegistroDR4 = objBDPrincipal4.mtdNumeroLinhas()
                                objBDPrincipal4.mtdDefinirLeitorDados()
                                numColunaDR4 = objBDPrincipal4.mtdNumeroColunas()
                                objBDPrincipal4.mtdProximoRegistro()
                                Dim maxItem As ULong = Convert.ToUInt64(objBDPrincipal4.mtdObterValorRegistro(2))
                                arrayCautelaBens(0) = Convert.ToString(maxContador2 + 1)
                                arrayCautelaBens(1) = Convert.ToString(Codigo)
                                arrayCautelaBens(2) = Convert.ToString(maxItem + 1)
                            Catch
                                arrayCautelaBens(0) = Convert.ToString(maxContador2 + 1)
                                arrayCautelaBens(1) = Convert.ToString(Codigo)
                                arrayCautelaBens(2) = "1"
                            Finally
                            End Try
                        Catch
                            maxContador2 = 0
                            arrayCautelaBens(0) = Convert.ToString(maxContador2)
                            arrayCautelaBens(1) = Convert.ToString(Codigo)
                            arrayCautelaBens(2) = "1"
                        Finally
                            arrayCautelaBens(3) = arrayCarteiraBens(3)
                            objBDPrincipal.mtdExecutarComando("SELECT tblBensEletronorte.* FROM tblBensEletronorte WHERE tblBensEletronorte.Patrimonio LIKE '" & arrayCautelaBens(3) & "' ORDER BY tblBensEletronorte.Imobilizado DESC;")
                            objBDPrincipal.mtdDefinirLeitorDados()
                            Dim blnDadosEncontrados As Boolean = objBDPrincipal.mtdProximoRegistro()
                            arrayCautelaBens(4) = If(blnDadosEncontrados, objBDPrincipal.mtdObterValorRegistro(0).ToString(), arrayCarteiraBens(5))
                            arrayCautelaBens(5) = arrayCarteiraBens(4)
                            arrayCautelaBens(6) = arrayCarteiraBens(6)
                            arrayCautelaBens(8) = If(blnDadosEncontrados, objBDPrincipal.mtdObterValorRegistro(5).ToString(), String.Empty)
                            arrayCautelaBens(9) = Me.barlblMostrContUser.Text
                            arrayCautelaBens(10) = DateAndTime.Now.ToString()
                            arrayCautelaBens(11) = Me.barlblMostrContUser.Text
                            arrayCautelaBens(12) = DateAndTime.Now.ToString()
                            strSQL = "INSERT INTO tblCautelaBens VALUES ("
                            For count As Integer = arrayCautelaBens.GetLowerBound(0) To arrayCautelaBens.GetUpperBound(0) Step 1
                                strSQL &= "'" & arrayCautelaBens(count)
                                If count < arrayCautelaBens.GetUpperBound(0) Then
                                    strSQL &= "', "
                                Else
                                    strSQL &= "');"
                                    objBDPrincipal4.mtdExecutarComando(strSQL)
                                End If
                                System.Threading.Thread.Sleep(1)
                            Next
                        End Try
                        System.Threading.Thread.Sleep(1)
                    Next
                    objBDPrincipal2.mtdProximoRegistro()

                    intProgresso = mtdProgresso(numInicioContador, numMaxRegistroDR2)
                    strNomeProcesso = strNomeProcessoGerarCarteiraCautela
                    blnSucessoGerarCarteiraCautela = True
                    System.Threading.Thread.Sleep(1)
                Next

                intProgresso = 100
                strNomeProcesso = strNomeProcessoGerarCarteiraCautela
                blnSucessoGerarCarteiraCautela = True

                strNumeroCautela = strNumeroCautela.Substring(0, strNumeroCautela.Length() - 2)
                objBDPrincipal.mtdExecutarComando("UPDATE tblCarteira SET tblCarteira.Observacoes = '" & strNumeroCautela & "' WHERE tblCarteira.Codigo LIKE '" & lngCodigoGerarCarteiraCautela.ToString() & "';")
                objBDPrincipal.Dispose()
                objBDPrincipal1.Dispose()
                objBDPrincipal2.Dispose()
                objBDPrincipal21.Dispose()
                objBDPrincipal3.Dispose()
                objBDPrincipal4.Dispose()
                objBancoDados.Dispose()
                'objCarteira.mtdAtualizarDtgv1()
                'MessageBox.Show("A(s) cautela(s) foi(ram) geradas.", "Aviso!", MessageBoxButtons.OK)
                mtdExibirNotificacao("A(s) cautela(s) foi(ram) geradas.")
            Catch ex As System.Exception
                blnSucessoGerarCarteiraCautela = False
                'MessageBox.Show("Não foi possível gerar a(s) cautela(s).", "Aviso!", MessageBoxButtons.OK)
                mtdExibirNotificacao("Não foi possível gerar a(s) cautela(s).")
            End Try
        End Sub
    End Class
End Namespace