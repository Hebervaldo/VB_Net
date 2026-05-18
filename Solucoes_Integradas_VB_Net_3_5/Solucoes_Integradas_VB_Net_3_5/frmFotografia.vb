Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmFotografia
        Private dfrmHpct1H As Integer
        Private dfrmVpct1V As Integer
        Private varHouveRedimensionamento As Boolean = False
        Private strFormulario As String = String.Empty
        Private strTextoFormulario As String = String.Empty

        Public Property prpTextoFormulario() As String
            Get
                Return strTextoFormulario
            End Get
            Set(ByVal value As String)
                strTextoFormulario = value
            End Set
        End Property

        Public Property prpFormulario() As String
            Get
                Return strFormulario
            End Get
            Set(ByVal value As String)
                strFormulario = value
            End Set
        End Property

        Public Sub mtdCarregarPct(ByVal Imagem As Image)
            dfrmHpct1H = Me.Width - pct1.Width
            dfrmVpct1V = Me.Height - pct1.Height
            pct1.Image = Imagem
            pct1.Height = Imagem.Height
            pct1.Width = Imagem.Width
            Me.Height = Imagem.Height + dfrmVpct1V
            Me.Width = Imagem.Width + dfrmHpct1H
        End Sub

        Private Sub frmSugestionador_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
            If varHouveRedimensionamento = False Then
                dfrmVpct1V = Me.Height - pct1.Height
                dfrmHpct1H = Me.Width - pct1.Width
                varHouveRedimensionamento = True
            End If
            pct1.Height = Me.Height - dfrmVpct1V
            pct1.Width = Me.Width - dfrmHpct1H
        End Sub

        Private Sub frmSugestionador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.Text = strTextoFormulario
        End Sub

        Private Sub tsbIncluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbIncluir.Click

        End Sub

        Private Sub tsbSalvar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalvar.Click
            Dim imgFotografia As Image = pct1.Image

            FileIO.FileSystem.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            FileIO.FileSystem.CreateDirectory("Fotografias_Inventario")
            FileIO.FileSystem.CurrentDirectory = String.Concat(FileIO.FileSystem.CurrentDirectory, "\Fotografias_Inventario\")

            svfFotografia.InitialDirectory = FileIO.FileSystem.CurrentDirectory & "\"
            svfFotografia.FileName = String.Format("{0}{1}", "Imagem", System.DateTime.Now.ToString("yyyyMMddhhmmss"))
            svfFotografia.OverwritePrompt = True

            svfFotografia.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
            svfFotografia.Title = "Salvar um arquivo de imagem."
            svfFotografia.ShowDialog() ' If the file name is not an empty string open it for saving.
            If svfFotografia.FileName <> String.Empty Then

                Dim fs As System.IO.FileStream = CType(svfFotografia.OpenFile(), System.IO.FileStream)

                Select Case svfFotografia.FilterIndex
                    Case 1
                        imgFotografia.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg)
                        'Exit Select
                    Case 2
                        imgFotografia.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp)
                        'Exit Select
                    Case 3
                        imgFotografia.Save(fs, System.Drawing.Imaging.ImageFormat.Gif)
                        'Exit Select
                End Select
            End If
        End Sub
    End Class
End Namespace