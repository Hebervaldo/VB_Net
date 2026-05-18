Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmMapa
        Private objBDPrincipal As clsImplementacaoBancoDados = New clsImplementacaoBancoDados _
        ( _
        clsBancoDados.TipoSistemaGerenciadorBancoDadosRelacional.OleDb _
        )
        Private dfrmHwbMapaH As Integer
        Private dfrmVwbMapaV As Integer
        Private dwbMapaHgrpb1H As Integer
        Private grpb1W As Integer
        Private varHouveRedimensionamento As Boolean = False
        Private strFormulario As String = String.Empty
        Private strTabela As String = String.Empty
        Private strTextoFormulario As String = String.Empty

        Private Latitude As String
        Private Longitude As String
        Private RotuloMarcador As String

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

        Public Property prpTabela() As String
            Get
                Return strTabela
            End Get
            Set(ByVal value As String)
                strTabela = value
            End Set
        End Property

        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            cmbMapa.Items.Clear()
            cmbMapa.Items.Add(TipoMapa.RoadMap)
            cmbMapa.Items.Add(TipoMapa.Satellite)
            cmbMapa.Items.Add(TipoMapa.Terrain)
            cmbMapa.Items.Add(TipoMapa.Hybrid)
            cmbMapa.SelectedItem = cmbMapa.Items(0)
        End Sub

        Public Sub mtdCarregarWbMapa(ByVal Latitude As String, ByVal Longitude As String, ByVal RotuloMarcador As String)
            Me.Latitude = Latitude
            Me.Longitude = Longitude
            Me.RotuloMarcador = RotuloMarcador

            mtdRenderizarMapa()
        End Sub

        Private Enum TipoMapa
            RoadMap
            Satellite
            Terrain
            Hybrid
        End Enum

        Private Function checkInternet() As Boolean
            'Try
            'Dim oIPHostEntry As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry("www.google.com")
            Return True
            'Catch
            '    Return False
            'End Try
        End Function

        Private Sub mtdMapa(ByVal Latitude As String, ByVal Longitude As String, ByVal Zoom As String, ByVal HorizontalSize As String, ByVal VerticalSize As String, ByVal RotuloMarcador As String, _
         ByVal TipoMapa As TipoMapa, ByVal Sensor As String)
            If Not Latitude = Nothing And Not Longitude = Nothing Then
                If Not Latitude.Equals(String.Empty) And Not Longitude.Equals(String.Empty) Then
                    Zoom = If(Zoom.Equals(String.Empty), "0", Zoom)
                    HorizontalSize = If(HorizontalSize.Equals(String.Empty), "0", HorizontalSize)
                    VerticalSize = If(VerticalSize.Equals(String.Empty), "0", VerticalSize)
                    Sensor = If(Sensor.Equals(String.Empty), "false", Sensor.ToString().ToLower())

                    mtdMapa _
                    ( _
                    Latitude, _
                    Longitude, _
                    System.Convert.ToInt32(Zoom), _
                    System.Convert.ToInt32(HorizontalSize), _
                    System.Convert.ToInt32(VerticalSize), _
                    RotuloMarcador, _
                    TipoMapa, _
                    System.Convert.ToBoolean(Sensor) _
                    )
                End If
            End If
        End Sub

        Private Sub mtdMapa(ByVal Latitude As String, ByVal Longitude As String, ByVal Zoom As Integer, ByVal HorizontalSize As Integer, ByVal VerticalSize As Integer, ByVal RotuloMarcador As String, _
         ByVal TipoMapa As TipoMapa, ByVal Sensor As Boolean)
            If Zoom < 0 Then
                Zoom = 0
            End If
            If Zoom > 21 Then
                Zoom = 21
            End If

            Dim strTipoMapa As String = String.Empty

            Select Case TipoMapa
                Case TipoMapa.RoadMap
                    strTipoMapa = "roadmap"
                    Exit Select
                Case TipoMapa.Satellite
                    strTipoMapa = "satellite"
                    Exit Select
                Case TipoMapa.Terrain
                    strTipoMapa = "terrain"
                    Exit Select
                Case TipoMapa.Hybrid
                    strTipoMapa = "hybrid"
                    Exit Select
            End Select

            Dim queryAddress As String = String.Format _
            ( _
            "http://maps.google.com/maps/api/staticmap?center={0},{1}&zoom={2}&size={3}x{4}&markers=color:blue%7Clabel:{5}%7C{0},{1}&maptype={6}&sensor={7}", _
            Latitude.Replace(","c, "."c), _
            Longitude.Replace(","c, "."c), _
            Zoom, _
            HorizontalSize, _
            VerticalSize, _
            RotuloMarcador, _
            strTipoMapa, _
            Sensor.ToString().ToLower() _
            )

            'Try
            If checkInternet() Then
                wbMapa.Navigate(New System.Uri(queryAddress.ToString()))
            End If
            'MessageBox.Show(ex.Message.ToString(), "Error");
            'Catch
            'End Try
        End Sub

        Private Sub frmSugestionador_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
            If varHouveRedimensionamento = False Then
                dfrmHwbMapaH = Me.Width - wbMapa.Width
                dfrmVwbMapaV = Me.Height - wbMapa.Height
                dwbMapaHgrpb1H = grpb1.Left - (wbMapa.Left + wbMapa.Width)
                grpb1W = grpb1.Width
                varHouveRedimensionamento = True
            End If
            wbMapa.Height = Me.Height - dfrmVwbMapaV
            wbMapa.Width = Me.Width - dfrmHwbMapaH
            grpb1.Height = wbMapa.Height
            grpb1.Left = (wbMapa.Left + wbMapa.Width) + dwbMapaHgrpb1H

            Try
                mtdRenderizarMapa()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub frmSugestionador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.Text = strTextoFormulario
            tcbMapa.Value = 4
        End Sub

        Private Sub tcbMapa_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcbMapa.ValueChanged
            mtdRenderizarMapa()
        End Sub

        Private Sub mtdRenderizarMapa()
            mtdMapa _
            ( _
             Me.Latitude, _
             Me.Longitude, _
             Convert.ToString(tcbMapa.Value), _
             Convert.ToString(wbMapa.Size.Width - 50), _
             Convert.ToString(wbMapa.Size.Height - 50), _
             Me.RotuloMarcador, _
             DirectCast(cmbMapa.SelectedItem, TipoMapa), _
             Convert.ToString(False) _
             )
        End Sub

        Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
            mtdRenderizarMapa()
        End Sub

        Private Sub cmbMapa_DropDownClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMapa.DropDownClosed
            mtdRenderizarMapa()
        End Sub
    End Class
End Namespace