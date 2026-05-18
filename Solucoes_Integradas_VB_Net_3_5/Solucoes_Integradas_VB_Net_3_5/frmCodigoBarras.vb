Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class frmCodigoBarras
        Private b As BarcodeLib.Barcode = New BarcodeLib.Barcode()

        Private Sub frmCodigoBarras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.cbEncodeType.SelectedIndex = 0
            Me.cbBarcodeAlign.SelectedIndex = 0
            Me.cbLabelLocation.SelectedIndex = 0

            Me.cbRotateFlip.DataSource = System.[Enum].GetNames(GetType(RotateFlipType))

            Dim i As Integer = 0
            For Each o As Object In cbRotateFlip.Items
                If o.ToString().Trim().ToLower() = "rotatenoneflipnone" Then
                    Exit For
                End If
                i += 1
            Next
            'foreach
            Me.cbRotateFlip.SelectedIndex = i

            'Show library version
            Me.tslblLibraryVersion.Text = "Barcode Library Version: " & BarcodeLib.Barcode.Version.ToString()

            Me.btnBackColor.BackColor = Me.b.BackColor
            Me.btnForeColor.BackColor = Me.b.ForeColor
        End Sub

        Private Sub btnEncode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncode.Click
            errorProvider1.Clear()
            Dim W As Integer = Convert.ToInt32(Me.txtWidth.Text.Trim())
            Dim H As Integer = Convert.ToInt32(Me.txtHeight.Text.Trim())
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER

            'barcode alignment
            Select Case cbBarcodeAlign.SelectedItem.ToString().Trim().ToLower()
                Case "left"
                    b.Alignment = BarcodeLib.AlignmentPositions.LEFT
                    Exit Select
                Case "right"
                    b.Alignment = BarcodeLib.AlignmentPositions.RIGHT
                    Exit Select
                Case Else
                    b.Alignment = BarcodeLib.AlignmentPositions.CENTER
                    Exit Select
            End Select
            'switch
            Dim type As BarcodeLib.TYPE = BarcodeLib.TYPE.UNSPECIFIED
            Select Case cbEncodeType.SelectedItem.ToString().Trim()
                Case "UPC-A"
                    type = BarcodeLib.TYPE.UPCA
                    Exit Select
                Case "UPC-E"
                    type = BarcodeLib.TYPE.UPCE
                    Exit Select
                Case "UPC 2 Digit Ext."
                    type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT
                    Exit Select
                Case "UPC 5 Digit Ext."
                    type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT
                    Exit Select
                Case "EAN-13"
                    type = BarcodeLib.TYPE.EAN13
                    Exit Select
                Case "JAN-13"
                    type = BarcodeLib.TYPE.JAN13
                    Exit Select
                Case "EAN-8"
                    type = BarcodeLib.TYPE.EAN8
                    Exit Select
                Case "ITF-14"
                    type = BarcodeLib.TYPE.ITF14
                    Exit Select
                Case "Codabar"
                    type = BarcodeLib.TYPE.Codabar
                    Exit Select
                Case "PostNet"
                    type = BarcodeLib.TYPE.PostNet
                    Exit Select
                Case "Bookland/ISBN"
                    type = BarcodeLib.TYPE.BOOKLAND
                    Exit Select
                Case "Code 11"
                    type = BarcodeLib.TYPE.CODE11
                    Exit Select
                Case "Code 39"
                    type = BarcodeLib.TYPE.CODE39
                    Exit Select
                Case "Code 39 Extended"
                    type = BarcodeLib.TYPE.CODE39Extended
                    Exit Select
                Case "Code 39 Mod 43"
                    type = BarcodeLib.TYPE.CODE39_Mod43
                    Exit Select
                Case "Code 93"
                    type = BarcodeLib.TYPE.CODE93
                    Exit Select
                Case "LOGMARS"
                    type = BarcodeLib.TYPE.LOGMARS
                    Exit Select
                Case "MSI"
                    type = BarcodeLib.TYPE.MSI_Mod10
                    Exit Select
                Case "Interleaved 2 of 5"
                    type = BarcodeLib.TYPE.Interleaved2of5
                    Exit Select
                Case "Standard 2 of 5"
                    type = BarcodeLib.TYPE.Standard2of5
                    Exit Select
                Case "Code 128"
                    type = BarcodeLib.TYPE.CODE128
                    Exit Select
                Case "Code 128-A"
                    type = BarcodeLib.TYPE.CODE128A
                    Exit Select
                Case "Code 128-B"
                    type = BarcodeLib.TYPE.CODE128B
                    Exit Select
                Case "Code 128-C"
                    type = BarcodeLib.TYPE.CODE128C
                    Exit Select
                Case "Telepen"
                    type = BarcodeLib.TYPE.TELEPEN
                    Exit Select
                Case "FIM"
                    type = BarcodeLib.TYPE.FIM
                    Exit Select
                Case "Pharmacode"
                    type = BarcodeLib.TYPE.PHARMACODE
                    Exit Select
                Case Else
                    MessageBox.Show("Please specify the encoding type.")
                    Exit Select
            End Select
            'switch
            Try
                If type <> BarcodeLib.TYPE.UNSPECIFIED Then
                    b.IncludeLabel = Me.chkGenerateLabel.Checked

                    b.RotateFlipType = DirectCast([Enum].Parse(GetType(RotateFlipType), Me.cbRotateFlip.SelectedItem.ToString(), True), RotateFlipType)

                    'label alignment and position
                    Select Case Me.cbLabelLocation.SelectedItem.ToString().Trim().ToUpper()
                        Case "BOTTOMLEFT"
                            b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT
                            Exit Select
                        Case "BOTTOMRIGHT"
                            b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMRIGHT
                            Exit Select
                        Case "TOPCENTER"
                            b.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER
                            Exit Select
                        Case "TOPLEFT"
                            b.LabelPosition = BarcodeLib.LabelPositions.TOPLEFT
                            Exit Select
                        Case "TOPRIGHT"
                            b.LabelPosition = BarcodeLib.LabelPositions.TOPRIGHT
                            Exit Select
                        Case Else
                            b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER
                            Exit Select
                    End Select
                    'switch
                    '===== Encoding performed here =====
                    barcode.BackgroundImage = b.Encode(type, Me.txtData.Text.Trim(), Me.btnForeColor.BackColor, Me.btnBackColor.BackColor, W, H)
                    '===================================

                    'show the encoding time
                    Me.lblEncodingTime.Text = "(" & Math.Round(b.EncodingTime, 0, MidpointRounding.AwayFromZero).ToString() & "ms)"

                    txtEncoded.Text = b.EncodedValue

                    tsslEncodedType.Text = "Encoding Type: " & b.EncodedType.ToString()
                End If
                'if
                'reposition the barcode image to the middle
                barcode.Location = New Point(System.Convert.ToInt32((Me.barcode.Location.X + Me.barcode.Width / 2) - barcode.Width / 2), System.Convert.ToInt32((Me.barcode.Location.Y + Me.barcode.Height / 2) - barcode.Height / 2))
                'try
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            'catch
        End Sub

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "BMP (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|TIFF (*.tif)|*.tif"
            sfd.FilterIndex = 2
            sfd.AddExtension = True
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim savetype As BarcodeLib.SaveTypes = BarcodeLib.SaveTypes.UNSPECIFIED
                Select Case sfd.FilterIndex
                    Case 1
                        ' BMP 
                        savetype = BarcodeLib.SaveTypes.BMP
                        Exit Select
                    Case 2
                        ' GIF 
                        savetype = BarcodeLib.SaveTypes.GIF
                        Exit Select
                    Case 3
                        ' JPG 
                        savetype = BarcodeLib.SaveTypes.JPG
                        Exit Select
                    Case 4
                        ' PNG 
                        savetype = BarcodeLib.SaveTypes.PNG
                        Exit Select
                    Case 5
                        ' TIFF 
                        savetype = BarcodeLib.SaveTypes.TIFF
                        Exit Select
                    Case Else
                        Exit Select
                End Select
                'switch
                b.SaveImage(sfd.FileName, savetype)
            End If
            'if
        End Sub

        Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
            barcode.Location = New Point(System.Convert.ToInt32((Me.barcode.Location.X + Me.barcode.Width / 2) - barcode.Width / 2), System.Convert.ToInt32((Me.barcode.Location.Y + Me.barcode.Height / 2) - barcode.Height / 2))
        End Sub

        Private Sub btnForeColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForeColor.Click
            Using cdialog As New ColorDialog()
                cdialog.AnyColor = True
                If cdialog.ShowDialog() = DialogResult.OK Then
                    Me.b.ForeColor = cdialog.Color
                    Me.btnForeColor.BackColor = cdialog.Color
                    'if
                End If
            End Using
            'using
        End Sub

        Private Sub btnBackColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackColor.Click
            Using cdialog As New ColorDialog()
                cdialog.AnyColor = True
                If cdialog.ShowDialog() = DialogResult.OK Then
                    Me.b.BackColor = cdialog.Color
                    Me.btnBackColor.BackColor = cdialog.Color
                    'if
                End If
            End Using
            'using
        End Sub

        Private Sub btnSaveXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveXML.Click
            btnEncode_Click(sender, e)

            Using sfd As New SaveFileDialog()
                sfd.Filter = "XML Files|*.xml"
                If sfd.ShowDialog() = DialogResult.OK Then
                    Using sw As New System.IO.StreamWriter(sfd.FileName)
                        sw.Write(b.XML)
                        'using
                    End Using
                    'if
                End If
            End Using
            'using
        End Sub

        Private Sub btnLoadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadXML.Click
            Using ofd As New OpenFileDialog()
                ofd.Multiselect = False
                If ofd.ShowDialog() = DialogResult.OK Then
                    Using XML As New BarcodeLib.BarcodeXML()
                        XML.ReadXml(ofd.FileName)

                        'load image from xml
                        Me.barcode.Width = XML.Barcode(0).ImageWidth
                        Me.barcode.Height = XML.Barcode(0).ImageHeight
                        Me.barcode.BackgroundImage = BarcodeLib.Barcode.GetImageFromXML(XML)

                        'populate the screen
                        Me.txtData.Text = XML.Barcode(0).RawData
                        Me.chkGenerateLabel.Checked = XML.Barcode(0).IncludeLabel

                        Select Case XML.Barcode(0).Type
                            Case "UCC12", "UPCA"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("UPC-A")
                                Exit Select
                            Case "UCC13", "EAN13"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("EAN-13")
                                Exit Select
                            Case "Interleaved2of5"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Interleaved 2 of 5")
                                Exit Select
                            Case "Industrial2of5", "Standard2of5"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Standard 2 of 5")
                                Exit Select
                            Case "LOGMARS"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("LOGMARS")
                                Exit Select
                            Case "CODE39"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Code 39")
                                Exit Select
                            Case "CODE39Extended"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Code 39 Extended")
                                Exit Select
                            Case "CODE39_Mod43"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Code 39 Mod 43")
                                Exit Select
                            Case "Codabar"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Codabar")
                                Exit Select
                            Case "PostNet"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("PostNet")
                                Exit Select
                            Case "ISBN", "BOOKLAND"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Bookland/ISBN")
                                Exit Select
                            Case "JAN13"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("JAN-13")
                                Exit Select
                            Case "UPC_SUPPLEMENTAL_2DIGIT"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("UPC 2 Digit Ext.")
                                Exit Select
                            Case "MSI_Mod10", "MSI_2Mod10", "MSI_Mod11", "MSI_Mod11_Mod10", "Modified_Plessey"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("MSI")
                                Exit Select
                            Case "UPC_SUPPLEMENTAL_5DIGIT"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("UPC 5 Digit Ext.")
                                Exit Select
                            Case "UPCE"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("UPC-E")
                                Exit Select
                            Case "EAN8"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("EAN-8")
                                Exit Select
                            Case "USD8", "CODE11"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Code 11")
                                Exit Select
                            Case "CODE128"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Code 128")
                                Exit Select
                            Case "CODE128A"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Code 128-A")
                                Exit Select
                            Case "CODE128B"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Code 128-B")
                                Exit Select
                            Case "CODE128C"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Code 128-C")
                                Exit Select
                            Case "ITF14"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("ITF-14")
                                Exit Select
                            Case "CODE93"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Code 93")
                                Exit Select
                            Case "FIM"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("FIM")
                                Exit Select
                            Case "Pharmacode"
                                Me.cbEncodeType.SelectedIndex = Me.cbEncodeType.FindString("Pharmacode")
                                Exit Select
                            Case Else

                                Throw New Exception("ELOADXML-1: Unsupported encoding type in XML.")
                        End Select
                        'switch
                        Me.txtEncoded.Text = XML.Barcode(0).EncodedValue
                        Me.btnForeColor.BackColor = ColorTranslator.FromHtml(XML.Barcode(0).Forecolor)
                        Me.btnBackColor.BackColor = ColorTranslator.FromHtml(XML.Barcode(0).Backcolor)


                        Me.txtWidth.Text = XML.Barcode(0).ImageWidth.ToString()
                        Me.txtHeight.Text = XML.Barcode(0).ImageHeight.ToString()

                        'populate the local object
                        btnEncode_Click(sender, e)

                        'reposition the barcode image to the middle
                        barcode.Location = New Point(System.Convert.ToInt32((Me.barcode.Location.X + Me.barcode.Width / 2) - barcode.Width / 2), System.Convert.ToInt32((Me.barcode.Location.Y + Me.barcode.Height / 2) - barcode.Height / 2))
                        'using
                    End Using
                    'if
                End If
            End Using
            'using
        End Sub
    End Class
End Namespace