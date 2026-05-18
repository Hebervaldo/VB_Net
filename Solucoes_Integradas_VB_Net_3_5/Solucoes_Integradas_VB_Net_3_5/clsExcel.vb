Imports System.Collections.Generic
Imports System.Text

Namespace Solucoes_Integradas_VB_Net_3_5
    Partial Public Class clsConexaoBancoDados

        Public Const cntStringConexaoExcelOdbc As String = "Driver={Microsoft Excel Driver (*.xls)}; DriverId={0}; Dbq={1}; DefaultDir={2}; ReadOnly={3};"
        Public Const cntStringConexaoExcel2003OleDb As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties={1}"
        Public Const cntStringConexaoExcel2007OleDb As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties={1};"

        Public Const cntExemploStringConexaoExcelOdbc As String = "Driver={Microsoft Excel Driver (*.xls)}; DriverId=790; Dbq=C:\MyExcel.xls; DefaultDir=c:\mypath; ReadOnly=0;"
        Public Const cntExemploStringConexaoExcel2003OleDb As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\MyExcel.xls; Extended Properties='Excel 8.0; HDR=Yes; IMEX=1';"
        Public Const cntExemploStringConexaoExcel2007OleDb As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=c:\myFolder\myOldExcelFile.xls; Extended Properties='Excel 12.0; HDR=YES';"

        ' Variaveis somente leitura de instancia do Excel

        Private ReadOnly cntProviderExcel As String() = {"Provider", "Microsoft.Jet.OLEDB.4.0", "Microsoft.ACE.OLEDB.12.0"}
        Private ReadOnly cntDriverExcel As String() = {"Driver", "{Microsoft Excel Driver (*.xls)}"}
        Private ReadOnly cntDriverIdExcel As String() = {"DriverId", "790"}
        Private ReadOnly cntDataSourceExcel As String() = {"DataSource", String.Empty}
        Private ReadOnly cntExtendedPropertiesExcel As String() = {"ExtendedProperties", "Excel 8.0; HDR=Yes; IMEX=1", "Excel 12.0; HDR=YES"}
        Private ReadOnly cntDefaultDirExcel As String() = {"DefaultDir", String.Empty}
        Private ReadOnly cntReadOnlyExcel As String() = {"ReadOnly", "0"}

        ' Variaveis de instancia do Excel

        Private strProviderExcel As String()
        Private strDriverExcel As String()
        Private strDriverIdExcel As String()
        Private strDataSourceExcel As String()
        Private strExtendedPropertiesExcel As String()
        Private strDefaultDirExcel As String()
        Private strReadOnlyExcel As String()

        Private vetProviderExcel As String() = {"Provider"}
        Private vetDriverExcel As String() = {"Driver"}
        Private vetDriverIdExcel As String() = {"DriverId", "Driver Id"}
        Private vetDataSourceExcel As String() = {"DataSource", "Data Source", "Dbq", "Server"}
        Private vetExtendedPropertiesExcel As String() = {"ExtendedProperties", "Extended Properties"}
        Private vetDefaultDirExcel As String() = {"DefaultDir", "Default Dir"}
        Private vetReadOnlyExcel As String() = {"ReadOnly", "Read Only"}

        ' Variaveis que determinam se a conexao incorporara o workbook. Isso facilita na criacao, alteracao ou delecao do workbook.

        Private blnPermitirBancoDadosExcel As Boolean = True

        ' Propriedades de instancia do Excel

        Public Property prpProviderExcel() As String
            Get
                If strProviderExcel Is Nothing Then
                    strProviderExcel = New String(1) {cntProviderExcel(0), cntProviderExcel(1)}
                End If
                Return strProviderExcel(1)
            End Get
            Set(ByVal value As String)
                If strProviderExcel Is Nothing Then
                    strProviderExcel = New String(1) {cntProviderExcel(0), cntProviderExcel(1)}
                End If
                strProviderExcel(1) = value
                mtdReDefinirConexaoString(strProviderExcel)
            End Set
        End Property

        Public Property prpDriverExcel() As String
            Get
                If strDriverExcel Is Nothing Then
                    strDriverExcel = New String(1) {cntDriverExcel(0), cntDriverExcel(1)}
                End If
                Return strDriverExcel(1)
            End Get
            Set(ByVal value As String)
                If strDriverExcel Is Nothing Then
                    strDriverExcel = New String(1) {cntDriverExcel(0), cntDriverExcel(1)}
                End If
                strDriverExcel(1) = value
                mtdReDefinirConexaoString(strDriverExcel)
            End Set
        End Property

        Public Property prpDriverIdExcel() As String
            Get
                If strDriverIdExcel Is Nothing Then
                    strDriverIdExcel = New String(1) {cntDriverIdExcel(0), cntDriverIdExcel(1)}
                End If
                Return strDriverIdExcel(1)
            End Get
            Set(ByVal value As String)
                If strDriverIdExcel Is Nothing Then
                    strDriverIdExcel = New String(1) {cntDriverIdExcel(0), cntDriverIdExcel(1)}
                End If
                strDriverIdExcel(1) = value
                mtdReDefinirConexaoString(strDriverIdExcel)
            End Set
        End Property

        Public Property prpDataSourceExcel() As String
            Get
                If strDataSourceExcel Is Nothing Then
                    strDataSourceExcel = New String(1) {cntDataSourceExcel(0), cntDataSourceExcel(1)}
                End If
                Return strDataSourceExcel(1)
            End Get
            Set(ByVal value As String)
                If strDataSourceExcel Is Nothing Then
                    strDataSourceExcel = New String(1) {cntDataSourceExcel(0), cntDataSourceExcel(1)}
                End If
                strDataSourceExcel(1) = value
                mtdReDefinirConexaoString(strDataSourceExcel)
            End Set
        End Property

        Public Property prpExtendedPropertiesExcel() As String
            Get
                If strExtendedPropertiesExcel Is Nothing Then
                    strExtendedPropertiesExcel = New String(1) {cntExtendedPropertiesExcel(0), cntExtendedPropertiesExcel(1)}
                End If
                Return strExtendedPropertiesExcel(1)
            End Get
            Set(ByVal value As String)
                If strExtendedPropertiesExcel Is Nothing Then
                    strExtendedPropertiesExcel = New String(1) {cntExtendedPropertiesExcel(0), cntExtendedPropertiesExcel(1)}
                End If
                strExtendedPropertiesExcel(1) = value
                mtdReDefinirConexaoString(strExtendedPropertiesExcel)
            End Set
        End Property

        Public Property prpDefaultDirExcel() As String
            Get
                If strDefaultDirExcel Is Nothing Then
                    strDefaultDirExcel = New String(1) {cntDefaultDirExcel(0), cntDefaultDirExcel(1)}
                End If
                Return strDefaultDirExcel(1)
            End Get
            Set(ByVal value As String)
                If strDefaultDirExcel Is Nothing Then
                    strDefaultDirExcel = New String(1) {cntDefaultDirExcel(0), cntDefaultDirExcel(1)}
                End If
                strDefaultDirExcel(1) = value
                mtdReDefinirConexaoString(strDefaultDirExcel)
            End Set
        End Property

        Public Property prpReadOnlyExcel() As String
            Get
                If strReadOnlyExcel Is Nothing Then
                    strReadOnlyExcel = New String(1) {cntReadOnlyExcel(0), cntReadOnlyExcel(1)}
                End If
                Return strReadOnlyExcel(1)
            End Get
            Set(ByVal value As String)
                If strReadOnlyExcel Is Nothing Then
                    strReadOnlyExcel = New String(1) {cntReadOnlyExcel(0), cntReadOnlyExcel(1)}
                End If
                strReadOnlyExcel(1) = value
                mtdReDefinirConexaoString(strReadOnlyExcel)
            End Set
        End Property

        ' Metodos de instancia do Excel

        Public Function mtdValidarConexaoDispositivoExcel(ByVal Conexao As String) As String()
            strDriverExcel = mtdValidarConexao(Conexao, vetDriverExcel)
            Return strDriverExcel
        End Function

        Public Function mtdValidarConexaoDispositivoIdExcel(ByVal Conexao As String) As String()
            strDriverIdExcel = mtdValidarConexao(Conexao, vetDriverIdExcel)
            Return strDriverIdExcel
        End Function

        Public Function mtdValidarConexaoProvedorExcel(ByVal Conexao As String) As String()
            strProviderExcel = mtdValidarConexao(Conexao, vetProviderExcel)
            Return strProviderExcel
        End Function

        Public Function mtdValidarConexaoOrigemDadosExcel(ByVal Conexao As String) As String()
            strDataSourceExcel = mtdValidarConexao(Conexao, vetDataSourceExcel)
            Return strDataSourceExcel
        End Function

        Public Function mtdValidarPropriedadesExtendidasExcel(ByVal Conexao As String) As String()
            strExtendedPropertiesExcel = mtdValidarConexao(Conexao, vetExtendedPropertiesExcel)
            Return strExtendedPropertiesExcel
        End Function

        Public Function mtdValidarDiretorioPadraoExcel(ByVal Conexao As String) As String()
            strDefaultDirExcel = mtdValidarConexao(Conexao, vetDefaultDirExcel)
            Return strDefaultDirExcel
        End Function

        Public Function mtdValidarSomenteLeituraExcel(ByVal Conexao As String) As String()
            strReadOnlyExcel = mtdValidarConexao(Conexao, vetReadOnlyExcel)
            Return strReadOnlyExcel
        End Function

        Public Function mtdValidarConexaoExcel(ByVal Conexao As String) As String
            Dim saida As String = String.Empty

            prpTipoConexao = TipoConexao.Indisponivel
            'if (strDriverExcel == null || strDriverExcel[1] == cntDriverExcel[1])
            '{
            mtdValidarConexaoDispositivoExcel(Conexao)
            '}
            If strDriverExcel IsNot Nothing Then
                prpTipoConexao = TipoConexao.ConexaoExcelOdbc
            End If
            'if (strProviderExcel == null || strProviderExcel[1] == cntProviderExcel[1])
            '{
            mtdValidarConexaoProvedorExcel(Conexao)
            '}
            If strProviderExcel IsNot Nothing Then
                If strProviderExcel(strProviderExcel.GetUpperBound(0)) = cntProviderExcel(cntProviderExcel.GetUpperBound(0)) Then
                    prpTipoConexao = TipoConexao.ConexaoExcel2007OleDb
                Else
                    prpTipoConexao = TipoConexao.ConexaoExcel2003OleDb
                End If
            End If
            'if (strDataSourceExcel == null || strDataSourceExcel[1] == cntDataSourceExcel[1])
            '{
            mtdValidarConexaoOrigemDadosExcel(Conexao)
            '}
            'if (strDriverIdExcel == null || strDriverIdExcel[1] == cntDriverIdExcel[1])
            '{
            mtdValidarConexaoDispositivoIdExcel(Conexao)
            '}
            'if (strExtendedPropertiesExcel == null || strExtendedPropertiesExcel[1] == cntExtendedPropertiesExcel[1])
            '{
            mtdValidarPropriedadesExtendidasExcel(Conexao)
            '}
            'if (strDefaultDirExcel == null || strDefaultDirExcel[1] == cntDefaultDirExcel[1])
            '{
            mtdValidarDiretorioPadraoExcel(Conexao)
            '}
            'if (strReadOnlyExcel == null || strReadOnlyExcel[1] == cntReadOnlyExcel[1])
            '{
            mtdValidarSomenteLeituraExcel(Conexao)
            '}

            If strDriverExcel IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strDriverExcel(0), strDriverExcel(1))
            End If
            If strProviderExcel IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strProviderExcel(0), strProviderExcel(1))
            End If
            If strDataSourceExcel IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strDataSourceExcel(0), strDataSourceExcel(1))
            End If
            If strDriverIdExcel IsNot Nothing Then
                saida += String.Format("{0}={1}; ", strDriverIdExcel(0), strDriverIdExcel(1))
            End If
            If strExtendedPropertiesExcel IsNot Nothing Then
                saida += String.Format("{0}={1};", strExtendedPropertiesExcel(0), strExtendedPropertiesExcel(1))
            End If
            If strDefaultDirExcel IsNot Nothing Then
                saida += String.Format("{0}={1};", strDefaultDirExcel(0), strDefaultDirExcel(1))
            End If
            If strReadOnlyExcel IsNot Nothing Then
                saida += String.Format("{0}={1};", strReadOnlyExcel(0), strReadOnlyExcel(1))
            End If
            Return saida
        End Function

        Public Function mtdDefinirStringConexaoExcel() As String
            Return mtdDefinirStringConexaoExcel(prpConexao, True)
        End Function

        Public Function mtdDefinirStringConexaoExcel(ByVal Conexao As String, ByVal PermitirBancoDados As Boolean) As String
            blnPermitirBancoDadosExcel = PermitirBancoDados
            mtdValidarConexaoExcel(Conexao)
            Return mtdDefinirStringConexaoExcel(prpTipoConexao, prpDataSourceExcel)
        End Function

        Public Function mtdDefinirStringConexaoExcel(ByVal TipoConexao As TipoConexao, ByVal DataSource As String) As String
            Return mtdDefinirStringConexaoExcel(TipoConexao, DataSource, cntDriverIdExcel(1), cntExtendedPropertiesExcel(1), cntDefaultDirExcel(1), cntReadOnlyExcel(1))
        End Function

        Public Function mtdDefinirStringConexaoExcel(ByVal TipoConexao As TipoConexao, ByVal DataSource As String, ByVal DriverId As String, ByVal ExtendedProperties As String, ByVal DefaultDir As String, ByVal [ReadOnly] As String) As String
            Dim saida As String = String.Empty
            Select Case TipoConexao
                Case TipoConexao.ConexaoExcelOdbc
                    saida = String.Format(cntStringConexaoExcelOdbc.Replace(String.Format("Driver={0}; ", cntDriverExcel(1)), String.Empty), DriverId, DataSource, DefaultDir, [ReadOnly])
                    strDriverExcel = cntDriverExcel
                    saida = String.Format("{0}={1}; ", strDriverExcel(0), strDriverExcel(1)) & saida
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida)
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Odbc
                    Exit Select
                Case TipoConexao.ConexaoExcel2003OleDb
                    saida = String.Format(cntStringConexaoExcel2003OleDb.Replace(String.Format("Provider={0}; ", cntProviderExcel(1)), String.Empty), DataSource, ExtendedProperties)
                    strProviderExcel = cntProviderExcel
                    saida = String.Format("{0}={1}; ", strProviderExcel(0), strProviderExcel(1)) & saida
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida)
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                    Exit Select
                Case TipoConexao.ConexaoExcel2007OleDb
                    saida = String.Format(cntStringConexaoExcel2007OleDb.Replace(String.Format("Provider={0}; ", cntProviderExcel(1)), String.Empty), DataSource, ExtendedProperties)
                    strProviderExcel = cntProviderExcel
                    saida = String.Format("{0}={1}; ", strProviderExcel(0), strProviderExcel(1)) & saida
                    saida = mtdEliminarAtribudoIndisponivelStringConexao(saida)
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.OleDb
                    Exit Select
                Case TipoConexao.Indisponivel
                    saida = TipoConexao.Indisponivel.ToString()
                    prpTipoSistemaGerenciadorBancoDadosRelacional = TipoSistemaGerenciadorBancoDadosRelacional.Indisponivel
                    Exit Select
            End Select
            prpConexao = mtdValidarConexaoExcel(saida)
            Return prpConexao.Trim()
        End Function
    End Class

    Partial Public Class clsImplementacaoBancoDados
        ' Excel

        Public Function mtdAlterarBancoDadosExcel(ByVal NovoBancoDados As String) As Boolean
            Return mtdAlterarBancoDadosExcel(prpDataSourceExcel, NovoBancoDados)
        End Function

        Public Function mtdAlterarBancoDadosExcel(ByVal BancoDados As String, ByVal NovoBancoDados As String) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("Não há workbook (arquivo) a ser alterado.")

            Try
                prpDataSourceExcel = BancoDados
                mtdDefinirStringConexaoExcel()
                mtdFecharConexao()
                prpDataSourceExcel = NovoBancoDados
                mtdDefinirStringConexaoExcel()
                mtdFecharConexao()
                If System.IO.File.Exists(BancoDados) Then
                    If Not System.IO.File.Exists(NovoBancoDados) Then
                        System.IO.File.Move(BancoDados, NovoBancoDados)
                        saida = True
                    Else
                        ex = New System.Exception("Já existe um workbook (arquivo) com esse nome.")
                        saida = False
                    End If
                Else
                    setExcecao = ex.Message
                    saida = False
                End If
            Catch exception As Exception
                setExcecao = exception.Message
                saida = False
            End Try

            Return saida
        End Function

        Public Function mtdCriarBancoDadosExcel() As Boolean
            Return mtdCriarBancoDadosExcel(prpDataSourceExcel)
        End Function

        Public Function mtdCriarBancoDadosExcel(ByVal BancoDados As String) As Boolean
            Dim saida As Boolean = False

            Dim ex As New System.Exception("Já existe um workbook (arquivo) com esse nome.")

            Try
                prpDataSourceExcel = BancoDados
                mtdDefinirStringConexaoExcel()
                mtdFecharConexao()
                If Not System.IO.File.Exists(BancoDados) Then
                    Dim xlApp As Microsoft.Office.Interop.Excel.Application
                    Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                    Dim misValue As Object = System.Reflection.Missing.Value

                    xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass()
                    xlWorkBook = xlApp.Workbooks.Add(System.Reflection.Missing.Value)

                    xlWorkBook.SaveAs(BancoDados, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, _
                     Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
                    xlWorkBook.Close(True, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
                    xlApp.Quit()

                    mtdLiberarObjeto(xlWorkBook)
                    mtdLiberarObjeto(xlApp)

                    saida = True
                Else
                    setExcecao = ex.Message
                    saida = False
                End If
            Catch exception As Exception
                setExcecao = exception.Message
                saida = False
            End Try

            Return saida
        End Function

        Public Function mtdDeletarBancoDadosExcel() As Boolean
            Return mtdDeletarBancoDadosExcel(prpDataSourceExcel)
        End Function

        Public Function mtdDeletarBancoDadosExcel(ByVal BancoDados As String) As Boolean
            Dim saida As Boolean = True

            Dim ex As New System.Exception("Não há workbook (arquivo) a ser deletado.")

            Try
                prpDataSourceExcel = BancoDados
                mtdDefinirStringConexaoExcel()
                mtdFecharConexao()
                If System.IO.File.Exists(BancoDados) Then
                    System.IO.File.Delete(BancoDados)
                    saida = True
                Else
                    setExcecao = ex.Message
                    saida = False
                End If
            Catch exception As Exception
                setExcecao = exception.Message
                saida = False
            End Try

            Return saida
        End Function

        Private xlApp As Microsoft.Office.Interop.Excel.Application
        Private xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Private xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet

        Private misValue As Object = System.Reflection.Missing.Value

        Public Function mtdAbrirInserirPlanilhaExcel_Otimizado() As Boolean
            Return mtdAbrirInserirPlanilhaExcel_Otimizado(prpTabela)
        End Function

        Public Function mtdAbrirInserirPlanilhaExcel_Otimizado(ByVal NomeTabela As String) As Boolean
            Return mtdAbrirInserirPlanilhaExcel_Otimizado(prpDataSourceExcel, NomeTabela)
        End Function

        Public Function mtdAbrirInserirPlanilhaExcel_Otimizado(ByVal EnderecoArquivo As String, ByVal NomeTabela As String) As Boolean
            Dim blnRetorno As Boolean = False

            Try
                intLinhaPlanilha = 1

                xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass()

                If System.IO.File.Exists(EnderecoArquivo) Then
                    xlWorkBook = xlApp.Workbooks.Open(EnderecoArquivo, 0, False, 5, "", "", _
                     True, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, vbTab, False, False, 0, _
                     True, 1, 0)
                Else
                    xlWorkBook = xlApp.Workbooks.Add(misValue)
                End If

                xlWorkSheet = DirectCast(xlWorkBook.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
                xlWorkSheet.Name = NomeTabela
                'Rename the sheet
                'xlWorkSheet.Select(Type.Missing);
                blnRetorno = True
            Catch ex As System.Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Public Function mtdCabecalhoInserirPlanilhaExcel_Otimizado(ByVal dados As Object(,)) As Boolean
            Dim blnRetorno As Boolean = False

            Try
                Dim linha As Integer = 0

                If dados IsNot Nothing Then
                    For coluna As Integer = dados.GetLowerBound(1) To dados.GetUpperBound(1)
                        xlWorkSheet.Cells(linha + 1, coluna + 1) = dados(linha, coluna)
                        System.Threading.Thread.Sleep(1)
                    Next
                End If

                blnRetorno = True
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Public Function mtdCabecalhoInserirPlanilhaExcel_Otimizado(ByVal dados As Object()()) As Boolean
            Dim blnRetorno As Boolean = False

            Try
                Dim linha As Integer = 0

                If dados(linha) IsNot Nothing Then
                    For coluna As Integer = dados(linha).GetLowerBound(0) To dados(linha).GetUpperBound(0)
                        xlWorkSheet.Cells(linha + 1, coluna + 1) = dados(linha)(coluna)
                        System.Threading.Thread.Sleep(1)
                    Next

                    blnRetorno = True
                End If
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Public Function mtdCabecalhoInserirPlanilhaExcel_Otimizado(ByVal dados As List(Of List(Of Object))) As Boolean
            Dim blnRetorno As Boolean = False

            Try
                Dim linha As Integer = 0

                If dados(linha) IsNot Nothing Then
                    For coluna As Integer = 0 To dados(linha).Count - 1
                        xlWorkSheet.Cells(linha + 1, coluna + 1) = dados(linha)(coluna)
                        System.Threading.Thread.Sleep(1)
                    Next
                End If

                blnRetorno = True
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Private intLinhaPlanilha As Integer = 1

        Public Function mtdDadosInserirPlanilhaExcel_Otimizado(ByVal dados As Object(,)) As Boolean
            Return mtdDadosInserirPlanilhaExcel_Otimizado(dados, True)
        End Function

        Public Function mtdDadosInserirPlanilhaExcel_Otimizado(ByVal dados As Object(,), ByVal InsercaoLiteral As Boolean) As Boolean
            Dim blnRetorno As Boolean = False

            Try
                If InsercaoLiteral Then
                    If dados IsNot Nothing Then
                        For linha As Integer = dados.GetLowerBound(0) + 1 To dados.GetUpperBound(0)
                            For coluna As Integer = dados.GetLowerBound(1) To dados.GetUpperBound(0)
                                xlWorkSheet.Cells(linha + 1, coluna + 1) = dados(linha, coluna)
                                System.Threading.Thread.Sleep(1)
                            Next
                        Next
                    End If
                Else
                    Dim linha As Integer = 1

                    If dados IsNot Nothing Then
                        For coluna As Integer = dados.GetLowerBound(1) To dados.GetUpperBound(0)
                            xlWorkSheet.Cells(intLinhaPlanilha + 1, coluna + 1) = dados(linha, coluna)
                            System.Threading.Thread.Sleep(1)
                        Next

                        intLinhaPlanilha += 1
                    End If
                End If

                blnRetorno = True
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Public Function mtdDadosInserirPlanilhaExcel_Otimizado(ByVal dados As Object()()) As Boolean
            Return mtdDadosInserirPlanilhaExcel_Otimizado(dados, True)
        End Function

        Public Function mtdDadosInserirPlanilhaExcel_Otimizado(ByVal dados As Object()(), ByVal InsercaoLiteral As Boolean) As Boolean
            Dim blnRetorno As Boolean = False

            Try
                If InsercaoLiteral Then
                    For linha As Integer = dados.GetLowerBound(0) + 1 To dados.GetUpperBound(0)
                        If dados(linha) IsNot Nothing Then
                            For coluna As Integer = dados(linha).GetLowerBound(0) To dados(linha).GetUpperBound(0)
                                xlWorkSheet.Cells(linha + 1, coluna + 1) = dados(linha)(coluna)
                                System.Threading.Thread.Sleep(1)
                            Next
                        End If
                    Next
                Else
                    Dim linha As Integer = 1

                    If dados(linha) IsNot Nothing Then
                        For coluna As Integer = dados(linha).GetLowerBound(0) To dados(linha).GetUpperBound(0)
                            xlWorkSheet.Cells(intLinhaPlanilha + 1, coluna + 1) = dados(linha)(coluna)
                            System.Threading.Thread.Sleep(1)
                        Next

                        intLinhaPlanilha += 1
                    End If
                End If

                blnRetorno = True
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Public Function mtdDadosInserirPlanilhaExcel_Otimizado(ByVal dados As List(Of List(Of Object))) As Boolean
            Return mtdDadosInserirPlanilhaExcel_Otimizado(dados, True)
        End Function

        Public Function mtdDadosInserirPlanilhaExcel_Otimizado(ByVal dados As List(Of List(Of Object)), ByVal InsercaoLiteral As Boolean) As Boolean
            Dim blnRetorno As Boolean = False

            Try
                If InsercaoLiteral Then
                    For linha As Integer = 0 + 1 To dados.Count - 1
                        If dados(linha) IsNot Nothing Then
                            For coluna As Integer = 0 To dados(linha).Count - 1
                                xlWorkSheet.Cells(linha + 1, coluna + 1) = dados(linha)(coluna)
                                System.Threading.Thread.Sleep(1)
                            Next
                        End If
                    Next
                Else
                    Dim linha As Integer = 1

                    If dados(linha) IsNot Nothing Then
                        For coluna As Integer = 0 To dados(linha).Count - 1
                            xlWorkSheet.Cells(intLinhaPlanilha + 1, coluna + 1) = dados(linha)(coluna)
                            System.Threading.Thread.Sleep(1)
                        Next

                        intLinhaPlanilha += 1
                    End If
                End If

                blnRetorno = True
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Public Function mtdDadosInserirPlanilhaExcel_Otimizado(ByVal dados As Object(,), ByVal linhaPlanilha As Integer, ByVal linhaDados As Integer) As Boolean
            Dim blnRetorno As Boolean = False

            Try
                If linhaPlanilha < 1 Then
                    linhaPlanilha = 1
                End If

                If dados IsNot Nothing Then
                    For coluna As Integer = dados.GetLowerBound(1) To dados.GetUpperBound(1)
                        xlWorkSheet.Cells(linhaPlanilha + 1, coluna + 1) = dados(linhaDados, coluna)
                        System.Threading.Thread.Sleep(1)
                    Next
                End If

                blnRetorno = True
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Public Function mtdDadosInserirPlanilhaExcel_Otimizado(ByVal dados As Object()(), ByVal linhaPlanilha As Integer, ByVal linhaDados As Integer) As Boolean
            Dim blnRetorno As Boolean = False

            Try
                If linhaPlanilha < 1 Then
                    linhaPlanilha = 1
                End If

                If dados(linhaDados) IsNot Nothing Then
                    For coluna As Integer = dados(1).GetLowerBound(0) To dados(1).GetUpperBound(0)
                        xlWorkSheet.Cells(linhaPlanilha + 1, coluna + 1) = dados(linhaDados)(coluna)
                        System.Threading.Thread.Sleep(1)
                    Next
                End If

                blnRetorno = True
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Public Function mtdDadosInserirPlanilhaExcel_Otimizado(ByVal dados As List(Of List(Of Object)), ByVal linhaPlanilha As Integer, ByVal linhaDados As Integer) As Boolean
            Dim blnRetorno As Boolean = False

            Try
                If linhaPlanilha < 1 Then
                    linhaPlanilha = 1
                End If

                If dados(linhaDados) IsNot Nothing Then
                    For coluna As Integer = 0 To dados(1).Count - 1
                        xlWorkSheet.Cells(linhaPlanilha + 1, coluna + 1) = dados(linhaDados)(coluna)
                        System.Threading.Thread.Sleep(1)
                    Next
                End If

                blnRetorno = True
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Public Function mtdFecharInserirPlanilhaExcel_Otimizado() As Boolean
            Return mtdFecharInserirPlanilhaExcel_Otimizado(prpDataSourceExcel)
        End Function

        Public Function mtdFecharInserirPlanilhaExcel_Otimizado(ByVal EnderecoArquivo As String) As Boolean
            Dim blnRetorno As Boolean = False

            Try
                xlWorkBook.SaveAs(EnderecoArquivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, _
                 Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
                xlWorkBook.Close(True, misValue, misValue)
                xlApp.Quit()

                mtdLiberarObjeto(xlWorkSheet)
                mtdLiberarObjeto(xlWorkBook)
                mtdLiberarObjeto(xlApp)

                blnRetorno = True
            Catch ex As Exception
                blnRetorno = False
            End Try

            Return blnRetorno
        End Function

        Public Function mtdInserirDadosPlanilhaExcel(ByVal Campos_Dados As Object(,)) As Boolean
            Return mtdInserirDadosPlanilhaExcel(prpTabela, Campos_Dados, True)
        End Function

        Public Function mtdInserirDadosPlanilhaExcel(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,)) As Boolean
            Return mtdInserirDadosPlanilhaExcel(NomeTabela, Campos_Dados, True)
        End Function

        Public Function mtdInserirDadosPlanilhaExcel(ByVal NomeTabela As String, ByVal Campos_Dados As Object(,), ByVal InsercaoLiteral As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirInserirPlanilhaExcel_Otimizado(NomeTabela)
            saida = saida And mtdCabecalhoInserirPlanilhaExcel_Otimizado(Campos_Dados)
            saida = saida And mtdDadosInserirPlanilhaExcel_Otimizado(Campos_Dados, InsercaoLiteral)
            saida = saida And mtdFecharInserirPlanilhaExcel_Otimizado(prpDataSourceExcel)

            Return saida
        End Function

        Public Function mtdInserirDadosPlanilhaExcel(ByVal Campos_Dados As Object()()) As Boolean
            Return mtdInserirDadosPlanilhaExcel(prpTabela, Campos_Dados, True)
        End Function


        Public Function mtdInserirDadosPlanilhaExcel(ByVal NomeTabela As String, ByVal Campos_Dados As Object()()) As Boolean
            Return mtdInserirDadosPlanilhaExcel(NomeTabela, Campos_Dados, True)
        End Function

        Public Function mtdInserirDadosPlanilhaExcel(ByVal NomeTabela As String, ByVal Campos_Dados As Object()(), ByVal InsercaoLiteral As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirInserirPlanilhaExcel_Otimizado(NomeTabela)
            saida = saida And mtdCabecalhoInserirPlanilhaExcel_Otimizado(Campos_Dados)
            saida = saida And mtdDadosInserirPlanilhaExcel_Otimizado(Campos_Dados, InsercaoLiteral)
            saida = saida And mtdFecharInserirPlanilhaExcel_Otimizado(prpDataSourceExcel)

            Return saida
        End Function

        Public Function mtdInserirDadosPlanilhaExcel(ByVal Campos_Dados As List(Of List(Of Object))) As Boolean
            Return mtdInserirDadosPlanilhaExcel(prpTabela, Campos_Dados, True)
        End Function

        Public Function mtdInserirDadosPlanilhaExcel(ByVal NomeTabela As String, ByVal Campos_Dados As List(Of List(Of Object))) As Boolean
            Return mtdInserirDadosPlanilhaExcel(NomeTabela, Campos_Dados, True)
        End Function

        Public Function mtdInserirDadosPlanilhaExcel(ByVal NomeTabela As String, ByVal Campos_Dados As List(Of List(Of Object)), ByVal InsercaoLiteral As Boolean) As Boolean
            Dim saida As Boolean = True

            saida = saida And mtdAbrirInserirPlanilhaExcel_Otimizado(NomeTabela)
            saida = saida And mtdCabecalhoInserirPlanilhaExcel_Otimizado(Campos_Dados)
            saida = saida And mtdDadosInserirPlanilhaExcel_Otimizado(Campos_Dados, InsercaoLiteral)
            saida = saida And mtdFecharInserirPlanilhaExcel_Otimizado(prpDataSourceExcel)

            Return saida
        End Function

        Private Function mtdLiberarObjeto(ByVal objeto As Object) As Boolean
            Dim saida As Boolean = False
            setExcecao = "mtdExecutarComando: Nao houve excecao."
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objeto)
                objeto = Nothing
                saida = True
            Catch ex As Exception
                objeto = Nothing
                setExcecao = "mtdLiberarObjeto: " & ex.Message
                saida = False
            Finally
                GC.Collect()
            End Try
            Return saida
        End Function
    End Class
End Namespace