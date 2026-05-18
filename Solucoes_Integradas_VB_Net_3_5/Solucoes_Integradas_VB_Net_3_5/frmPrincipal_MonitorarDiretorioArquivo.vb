'Namespace Solucoes_Integradas_VB_Net_3_5
'    Partial Public Class frmPrincipal
'        Private m_Sb As System.Text.StringBuilder
'        Private m_bDirty As Boolean = False
'        Private WithEvents m_Watcher As System.IO.FileSystemWatcher
'        Public m_bIsWatching As Boolean = False

'        Public Function mtdMonitorarDiretorioArquivo() As Boolean
'            Try
'                If m_bIsWatching Then
'                    m_bIsWatching = False
'                    m_Watcher.EnableRaisingEvents = False
'                    m_Watcher.Dispose()
'                    frmConfiguracoes.clrMonitoramento = Color.LightSkyBlue
'                    frmConfiguracoes.strMonitoramento = "&Iniciar Monitoramento"
'                Else
'                    m_bIsWatching = True
'                    frmConfiguracoes.clrMonitoramento = Color.Red
'                    frmConfiguracoes.strMonitoramento = "&Parar Monitoramento"

'                    m_Watcher = New System.IO.FileSystemWatcher()
'                    If frmConfiguracoes.blnMonitorarDiretorio Then
'                        m_Watcher.Filter = "*.*"
'                        m_Watcher.Path = strEnderecoBancoDadosColetor
'                    Else
'                        m_Watcher.Filter = strEnderecoBancoDadosColetor.Substring(strEnderecoBancoDadosColetor.LastIndexOf("\"c) + 1)
'                        m_Watcher.Path = strEnderecoBancoDadosColetor.Substring _
'                        ( _
'                        0, _
'                        strEnderecoBancoDadosColetor.Length - m_Watcher.Filter.Length _
'                        )

'                        If frmConfiguracoes.blnSubDiretorios Then
'                            m_Watcher.IncludeSubdirectories = True
'                        End If

'                        m_Watcher.NotifyFilter = System.IO.NotifyFilters.LastPrincipal Or _
'                            System.IO.NotifyFilters.LastWrite Or _
'                            System.IO.NotifyFilters.FileName Or _
'                            System.IO.NotifyFilters.DirectoryName
'                        m_Watcher.EnableRaisingEvents = True
'                    End If
'                End If
'            Catch
'            End Try

'            Return m_bIsWatching
'        End Function

'        Private Sub OnChanged(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles m_Watcher.Changed, m_Watcher.Created, m_Watcher.Deleted
'            If Not m_bDirty Then
'                Try
'                    m_Sb.Remove(0, m_Sb.Length)
'                    m_Sb.Append(e.FullPath)
'                    m_Sb.Append(" ")
'                    m_Sb.Append(e.ChangeType.ToString())
'                    m_Sb.Append("    ")
'                    m_Sb.Append(DateTime.Now.ToString())
'                    m_bDirty = True
'                Catch
'                End Try
'            End If
'        End Sub

'        Private Sub OnRenamed(ByVal sender As Object, ByVal e As System.IO.RenamedEventArgs) Handles m_Watcher.Renamed
'            If Not m_bDirty Then
'                Try
'                    m_Sb.Append(e.OldFullPath)
'                    m_Sb.Append(" ")
'                    m_Sb.Append(e.ChangeType.ToString())
'                    m_Sb.Append(" ")
'                    m_Sb.Append("to ")
'                    m_Sb.Append(e.Name)
'                    m_Sb.Append("    ")
'                    m_Sb.Append(DateTime.Now.ToString())
'                    m_bDirty = True
'                    If frmConfiguracoes.blnMonitorarDiretorio Then
'                        m_Watcher.Filter = e.Name
'                        m_Watcher.Path = e.FullPath.Substring(0, e.FullPath.Length - m_Watcher.Filter.Length)
'                    End If
'                Catch
'                End Try
'            End If
'        End Sub
'    End Class
'End Namespace