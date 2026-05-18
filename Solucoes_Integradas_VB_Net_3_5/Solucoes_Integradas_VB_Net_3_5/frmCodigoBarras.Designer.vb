Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmCodigoBarras
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCodigoBarras))
            Me.statusStrip1 = New System.Windows.Forms.StatusStrip
            Me.tsslEncodedType = New System.Windows.Forms.ToolStripStatusLabel
            Me.tslblLibraryVersion = New System.Windows.Forms.ToolStripStatusLabel
            Me.tslblCredits = New System.Windows.Forms.ToolStripStatusLabel
            Me.errorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.groupBox4 = New System.Windows.Forms.GroupBox
            Me.txtWidth = New System.Windows.Forms.TextBox
            Me.label7 = New System.Windows.Forms.Label
            Me.label6 = New System.Windows.Forms.Label
            Me.txtHeight = New System.Windows.Forms.TextBox
            Me.label9 = New System.Windows.Forms.Label
            Me.groupBox3 = New System.Windows.Forms.GroupBox
            Me.textBox1 = New System.Windows.Forms.TextBox
            Me.chkGenerateLabel = New System.Windows.Forms.CheckBox
            Me.label11 = New System.Windows.Forms.Label
            Me.cbLabelLocation = New System.Windows.Forms.ComboBox
            Me.lblLabelLocation = New System.Windows.Forms.Label
            Me.label10 = New System.Windows.Forms.Label
            Me.cbRotateFlip = New System.Windows.Forms.ComboBox
            Me.btnSave = New System.Windows.Forms.Button
            Me.btnSaveXML = New System.Windows.Forms.Button
            Me.btnLoadXML = New System.Windows.Forms.Button
            Me.label8 = New System.Windows.Forms.Label
            Me.btnEncode = New System.Windows.Forms.Button
            Me.label4 = New System.Windows.Forms.Label
            Me.txtEncoded = New System.Windows.Forms.TextBox
            Me.label5 = New System.Windows.Forms.Label
            Me.btnBackColor = New System.Windows.Forms.Button
            Me.cbBarcodeAlign = New System.Windows.Forms.ComboBox
            Me.btnForeColor = New System.Windows.Forms.Button
            Me.label2 = New System.Windows.Forms.Label
            Me.lblEncodingTime = New System.Windows.Forms.Label
            Me.label3 = New System.Windows.Forms.Label
            Me.cbEncodeType = New System.Windows.Forms.ComboBox
            Me.txtData = New System.Windows.Forms.TextBox
            Me.label1 = New System.Windows.Forms.Label
            Me.barcode = New System.Windows.Forms.GroupBox
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
            Me.statusStrip1.SuspendLayout()
            CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.groupBox4.SuspendLayout()
            Me.groupBox3.SuspendLayout()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.SuspendLayout()
            '
            'statusStrip1
            '
            Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslEncodedType, Me.tslblLibraryVersion, Me.tslblCredits})
            Me.statusStrip1.Location = New System.Drawing.Point(0, 368)
            Me.statusStrip1.Name = "statusStrip1"
            Me.statusStrip1.Size = New System.Drawing.Size(813, 22)
            Me.statusStrip1.SizingGrip = False
            Me.statusStrip1.TabIndex = 79
            Me.statusStrip1.Text = "statusStrip1"
            '
            'tsslEncodedType
            '
            Me.tsslEncodedType.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
            Me.tsslEncodedType.Name = "tsslEncodedType"
            Me.tsslEncodedType.Size = New System.Drawing.Size(4, 17)
            '
            'tslblLibraryVersion
            '
            Me.tslblLibraryVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
            Me.tslblLibraryVersion.Name = "tslblLibraryVersion"
            Me.tslblLibraryVersion.Size = New System.Drawing.Size(670, 17)
            Me.tslblLibraryVersion.Spring = True
            Me.tslblLibraryVersion.Text = "LibVersion"
            '
            'tslblCredits
            '
            Me.tslblCredits.Name = "tslblCredits"
            Me.tslblCredits.Size = New System.Drawing.Size(124, 17)
            Me.tslblCredits.Text = "Written by: Brad Barnhill"
            Me.tslblCredits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'errorProvider1
            '
            Me.errorProvider1.ContainerControl = Me
            '
            'groupBox4
            '
            Me.groupBox4.Controls.Add(Me.txtWidth)
            Me.groupBox4.Controls.Add(Me.label7)
            Me.groupBox4.Controls.Add(Me.label6)
            Me.groupBox4.Controls.Add(Me.txtHeight)
            Me.groupBox4.Controls.Add(Me.label9)
            Me.groupBox4.Location = New System.Drawing.Point(134, 46)
            Me.groupBox4.Name = "groupBox4"
            Me.groupBox4.Size = New System.Drawing.Size(110, 49)
            Me.groupBox4.TabIndex = 100
            Me.groupBox4.TabStop = False
            '
            'txtWidth
            '
            Me.txtWidth.Location = New System.Drawing.Point(16, 25)
            Me.txtWidth.Name = "txtWidth"
            Me.txtWidth.Size = New System.Drawing.Size(35, 20)
            Me.txtWidth.TabIndex = 43
            Me.txtWidth.Text = "300"
            '
            'label7
            '
            Me.label7.AutoSize = True
            Me.label7.Location = New System.Drawing.Point(13, 12)
            Me.label7.Name = "label7"
            Me.label7.Size = New System.Drawing.Size(35, 13)
            Me.label7.TabIndex = 41
            Me.label7.Text = "Width"
            '
            'label6
            '
            Me.label6.AutoSize = True
            Me.label6.Location = New System.Drawing.Point(57, 12)
            Me.label6.Name = "label6"
            Me.label6.Size = New System.Drawing.Size(38, 13)
            Me.label6.TabIndex = 42
            Me.label6.Text = "Height"
            '
            'txtHeight
            '
            Me.txtHeight.Location = New System.Drawing.Point(59, 25)
            Me.txtHeight.Name = "txtHeight"
            Me.txtHeight.Size = New System.Drawing.Size(35, 20)
            Me.txtHeight.TabIndex = 44
            Me.txtHeight.Text = "150"
            '
            'label9
            '
            Me.label9.AutoSize = True
            Me.label9.Location = New System.Drawing.Point(50, 27)
            Me.label9.Name = "label9"
            Me.label9.Size = New System.Drawing.Size(12, 13)
            Me.label9.TabIndex = 51
            Me.label9.Text = "x"
            '
            'groupBox3
            '
            Me.groupBox3.Controls.Add(Me.textBox1)
            Me.groupBox3.Controls.Add(Me.chkGenerateLabel)
            Me.groupBox3.Controls.Add(Me.label11)
            Me.groupBox3.Controls.Add(Me.cbLabelLocation)
            Me.groupBox3.Controls.Add(Me.lblLabelLocation)
            Me.groupBox3.Location = New System.Drawing.Point(134, 101)
            Me.groupBox3.Name = "groupBox3"
            Me.groupBox3.Size = New System.Drawing.Size(110, 120)
            Me.groupBox3.TabIndex = 99
            Me.groupBox3.TabStop = False
            '
            'textBox1
            '
            Me.textBox1.Location = New System.Drawing.Point(4, 52)
            Me.textBox1.Name = "textBox1"
            Me.textBox1.Size = New System.Drawing.Size(100, 20)
            Me.textBox1.TabIndex = 54
            '
            'chkGenerateLabel
            '
            Me.chkGenerateLabel.AutoSize = True
            Me.chkGenerateLabel.Location = New System.Drawing.Point(6, 14)
            Me.chkGenerateLabel.Name = "chkGenerateLabel"
            Me.chkGenerateLabel.Size = New System.Drawing.Size(95, 17)
            Me.chkGenerateLabel.TabIndex = 40
            Me.chkGenerateLabel.Text = "Generate label"
            Me.chkGenerateLabel.UseVisualStyleBackColor = True
            '
            'label11
            '
            Me.label11.AutoSize = True
            Me.label11.Location = New System.Drawing.Point(3, 39)
            Me.label11.Name = "label11"
            Me.label11.Size = New System.Drawing.Size(102, 13)
            Me.label11.TabIndex = 55
            Me.label11.Text = "Alternate Label Text"
            '
            'cbLabelLocation
            '
            Me.cbLabelLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbLabelLocation.FormattingEnabled = True
            Me.cbLabelLocation.Items.AddRange(New Object() {"BottomCenter", "BottomLeft", "BottomRight", "TopCenter", "TopLeft", "TopRight"})
            Me.cbLabelLocation.Location = New System.Drawing.Point(6, 94)
            Me.cbLabelLocation.Name = "cbLabelLocation"
            Me.cbLabelLocation.Size = New System.Drawing.Size(90, 21)
            Me.cbLabelLocation.TabIndex = 0
            '
            'lblLabelLocation
            '
            Me.lblLabelLocation.AutoSize = True
            Me.lblLabelLocation.Location = New System.Drawing.Point(3, 78)
            Me.lblLabelLocation.Name = "lblLabelLocation"
            Me.lblLabelLocation.Size = New System.Drawing.Size(77, 13)
            Me.lblLabelLocation.TabIndex = 48
            Me.lblLabelLocation.Text = "Label Location"
            '
            'label10
            '
            Me.label10.AutoSize = True
            Me.label10.Location = New System.Drawing.Point(3, 92)
            Me.label10.Name = "label10"
            Me.label10.Size = New System.Drawing.Size(39, 13)
            Me.label10.TabIndex = 98
            Me.label10.Text = "Rotate"
            '
            'cbRotateFlip
            '
            Me.cbRotateFlip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbRotateFlip.FormattingEnabled = True
            Me.cbRotateFlip.Items.AddRange(New Object() {"Center", "Left", "Right"})
            Me.cbRotateFlip.Location = New System.Drawing.Point(5, 108)
            Me.cbRotateFlip.Name = "cbRotateFlip"
            Me.cbRotateFlip.Size = New System.Drawing.Size(108, 21)
            Me.cbRotateFlip.TabIndex = 97
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(79, 285)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(69, 46)
            Me.btnSave.TabIndex = 83
            Me.btnSave.Text = "&Save As"
            Me.btnSave.UseVisualStyleBackColor = True
            '
            'btnSaveXML
            '
            Me.btnSaveXML.Location = New System.Drawing.Point(164, 285)
            Me.btnSaveXML.Name = "btnSaveXML"
            Me.btnSaveXML.Size = New System.Drawing.Size(77, 23)
            Me.btnSaveXML.TabIndex = 93
            Me.btnSaveXML.Text = "Save &XML"
            Me.btnSaveXML.UseVisualStyleBackColor = True
            '
            'btnLoadXML
            '
            Me.btnLoadXML.Location = New System.Drawing.Point(164, 308)
            Me.btnLoadXML.Name = "btnLoadXML"
            Me.btnLoadXML.Size = New System.Drawing.Size(77, 23)
            Me.btnLoadXML.TabIndex = 94
            Me.btnLoadXML.Text = "Load XML"
            Me.btnLoadXML.UseVisualStyleBackColor = True
            '
            'label8
            '
            Me.label8.AutoSize = True
            Me.label8.Location = New System.Drawing.Point(3, 134)
            Me.label8.Name = "label8"
            Me.label8.Size = New System.Drawing.Size(53, 13)
            Me.label8.TabIndex = 96
            Me.label8.Text = "Alignment"
            '
            'btnEncode
            '
            Me.btnEncode.Location = New System.Drawing.Point(5, 285)
            Me.btnEncode.Name = "btnEncode"
            Me.btnEncode.Size = New System.Drawing.Size(69, 46)
            Me.btnEncode.TabIndex = 82
            Me.btnEncode.Text = "&Encode"
            Me.btnEncode.UseVisualStyleBackColor = True
            '
            'label4
            '
            Me.label4.AutoSize = True
            Me.label4.Location = New System.Drawing.Point(3, 178)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(61, 13)
            Me.label4.TabIndex = 90
            Me.label4.Text = "Foreground"
            '
            'txtEncoded
            '
            Me.txtEncoded.Location = New System.Drawing.Point(5, 238)
            Me.txtEncoded.Multiline = True
            Me.txtEncoded.Name = "txtEncoded"
            Me.txtEncoded.ReadOnly = True
            Me.txtEncoded.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtEncoded.Size = New System.Drawing.Size(238, 36)
            Me.txtEncoded.TabIndex = 84
            Me.txtEncoded.TabStop = False
            '
            'label5
            '
            Me.label5.AutoSize = True
            Me.label5.Location = New System.Drawing.Point(67, 178)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(65, 13)
            Me.label5.TabIndex = 91
            Me.label5.Text = "Background"
            '
            'btnBackColor
            '
            Me.btnBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBackColor.Location = New System.Drawing.Point(70, 194)
            Me.btnBackColor.Name = "btnBackColor"
            Me.btnBackColor.Size = New System.Drawing.Size(58, 23)
            Me.btnBackColor.TabIndex = 89
            Me.btnBackColor.UseVisualStyleBackColor = True
            '
            'cbBarcodeAlign
            '
            Me.cbBarcodeAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbBarcodeAlign.FormattingEnabled = True
            Me.cbBarcodeAlign.Items.AddRange(New Object() {"Center", "Left", "Right"})
            Me.cbBarcodeAlign.Location = New System.Drawing.Point(5, 150)
            Me.cbBarcodeAlign.Name = "cbBarcodeAlign"
            Me.cbBarcodeAlign.Size = New System.Drawing.Size(107, 21)
            Me.cbBarcodeAlign.TabIndex = 95
            '
            'btnForeColor
            '
            Me.btnForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnForeColor.Location = New System.Drawing.Point(5, 194)
            Me.btnForeColor.Name = "btnForeColor"
            Me.btnForeColor.Size = New System.Drawing.Size(58, 23)
            Me.btnForeColor.TabIndex = 88
            Me.btnForeColor.UseVisualStyleBackColor = True
            '
            'label2
            '
            Me.label2.AutoSize = True
            Me.label2.Location = New System.Drawing.Point(3, 224)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(80, 13)
            Me.label2.TabIndex = 86
            Me.label2.Text = "Encoded Value"
            '
            'lblEncodingTime
            '
            Me.lblEncodingTime.AutoSize = True
            Me.lblEncodingTime.Location = New System.Drawing.Point(81, 224)
            Me.lblEncodingTime.Name = "lblEncodingTime"
            Me.lblEncodingTime.Size = New System.Drawing.Size(0, 13)
            Me.lblEncodingTime.TabIndex = 92
            '
            'label3
            '
            Me.label3.AutoSize = True
            Me.label3.Location = New System.Drawing.Point(3, 50)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(52, 13)
            Me.label3.TabIndex = 87
            Me.label3.Text = "Encoding"
            '
            'cbEncodeType
            '
            Me.cbEncodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbEncodeType.FormattingEnabled = True
            Me.cbEncodeType.ItemHeight = 13
            Me.cbEncodeType.Items.AddRange(New Object() {"UPC-A", "UPC-E", "UPC 2 Digit Ext.", "UPC 5 Digit Ext.", "EAN-13", "JAN-13", "EAN-8", "ITF-14", "Interleaved 2 of 5", "Standard 2 of 5", "Codabar", "PostNet", "Bookland/ISBN", "Code 11", "Code 39", "Code 39 Extended", "Code 39 Mod 43", "Code 93", "Code 128", "Code 128-A", "Code 128-B", "Code 128-C", "LOGMARS", "MSI", "Telepen", "FIM", "Pharmacode"})
            Me.cbEncodeType.Location = New System.Drawing.Point(5, 66)
            Me.cbEncodeType.Name = "cbEncodeType"
            Me.cbEncodeType.Size = New System.Drawing.Size(108, 21)
            Me.cbEncodeType.TabIndex = 81
            '
            'txtData
            '
            Me.txtData.Location = New System.Drawing.Point(5, 26)
            Me.txtData.Name = "txtData"
            Me.txtData.Size = New System.Drawing.Size(194, 20)
            Me.txtData.TabIndex = 80
            '
            'label1
            '
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(3, 10)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(86, 13)
            Me.label1.TabIndex = 85
            Me.label1.Text = "Value to Encode"
            '
            'barcode
            '
            Me.barcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
            Me.barcode.Dock = System.Windows.Forms.DockStyle.Fill
            Me.barcode.Location = New System.Drawing.Point(0, 0)
            Me.barcode.Name = "barcode"
            Me.barcode.Size = New System.Drawing.Size(522, 342)
            Me.barcode.TabIndex = 101
            Me.barcode.TabStop = False
            Me.barcode.Text = "Barcode Image"
            '
            'SplitContainer1
            '
            Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
            Me.SplitContainer1.Location = New System.Drawing.Point(12, 12)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.label1)
            Me.SplitContainer1.Panel1.Controls.Add(Me.txtData)
            Me.SplitContainer1.Panel1.Controls.Add(Me.groupBox4)
            Me.SplitContainer1.Panel1.Controls.Add(Me.cbEncodeType)
            Me.SplitContainer1.Panel1.Controls.Add(Me.groupBox3)
            Me.SplitContainer1.Panel1.Controls.Add(Me.label3)
            Me.SplitContainer1.Panel1.Controls.Add(Me.label10)
            Me.SplitContainer1.Panel1.Controls.Add(Me.lblEncodingTime)
            Me.SplitContainer1.Panel1.Controls.Add(Me.cbRotateFlip)
            Me.SplitContainer1.Panel1.Controls.Add(Me.label2)
            Me.SplitContainer1.Panel1.Controls.Add(Me.btnSave)
            Me.SplitContainer1.Panel1.Controls.Add(Me.btnForeColor)
            Me.SplitContainer1.Panel1.Controls.Add(Me.btnSaveXML)
            Me.SplitContainer1.Panel1.Controls.Add(Me.cbBarcodeAlign)
            Me.SplitContainer1.Panel1.Controls.Add(Me.btnLoadXML)
            Me.SplitContainer1.Panel1.Controls.Add(Me.btnBackColor)
            Me.SplitContainer1.Panel1.Controls.Add(Me.label8)
            Me.SplitContainer1.Panel1.Controls.Add(Me.label5)
            Me.SplitContainer1.Panel1.Controls.Add(Me.btnEncode)
            Me.SplitContainer1.Panel1.Controls.Add(Me.txtEncoded)
            Me.SplitContainer1.Panel1.Controls.Add(Me.label4)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.barcode)
            Me.SplitContainer1.Size = New System.Drawing.Size(789, 342)
            Me.SplitContainer1.SplitterDistance = 263
            Me.SplitContainer1.TabIndex = 102
            '
            'frmCodigoBarras
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(813, 390)
            Me.Controls.Add(Me.SplitContainer1)
            Me.Controls.Add(Me.statusStrip1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "frmCodigoBarras"
            Me.Text = "Codigo de Barras"
            Me.statusStrip1.ResumeLayout(False)
            Me.statusStrip1.PerformLayout()
            CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.groupBox4.ResumeLayout(False)
            Me.groupBox4.PerformLayout()
            Me.groupBox3.ResumeLayout(False)
            Me.groupBox3.PerformLayout()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel1.PerformLayout()
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Private WithEvents statusStrip1 As System.Windows.Forms.StatusStrip
        Private WithEvents tsslEncodedType As System.Windows.Forms.ToolStripStatusLabel
        Private WithEvents tslblLibraryVersion As System.Windows.Forms.ToolStripStatusLabel
        Private WithEvents tslblCredits As System.Windows.Forms.ToolStripStatusLabel
        Private WithEvents errorProvider1 As System.Windows.Forms.ErrorProvider
        Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
        Private WithEvents txtWidth As System.Windows.Forms.TextBox
        Private WithEvents label7 As System.Windows.Forms.Label
        Private WithEvents label6 As System.Windows.Forms.Label
        Private WithEvents txtHeight As System.Windows.Forms.TextBox
        Private WithEvents label9 As System.Windows.Forms.Label
        Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
        Private WithEvents textBox1 As System.Windows.Forms.TextBox
        Private WithEvents chkGenerateLabel As System.Windows.Forms.CheckBox
        Private WithEvents label11 As System.Windows.Forms.Label
        Private WithEvents cbLabelLocation As System.Windows.Forms.ComboBox
        Private WithEvents lblLabelLocation As System.Windows.Forms.Label
        Private WithEvents label10 As System.Windows.Forms.Label
        Private WithEvents cbRotateFlip As System.Windows.Forms.ComboBox
        Private WithEvents btnSave As System.Windows.Forms.Button
        Private WithEvents btnSaveXML As System.Windows.Forms.Button
        Private WithEvents btnLoadXML As System.Windows.Forms.Button
        Private WithEvents label8 As System.Windows.Forms.Label
        Private WithEvents btnEncode As System.Windows.Forms.Button
        Private WithEvents label4 As System.Windows.Forms.Label
        Private WithEvents txtEncoded As System.Windows.Forms.TextBox
        Private WithEvents label5 As System.Windows.Forms.Label
        Private WithEvents btnBackColor As System.Windows.Forms.Button
        Private WithEvents cbBarcodeAlign As System.Windows.Forms.ComboBox
        Private WithEvents btnForeColor As System.Windows.Forms.Button
        Private WithEvents label2 As System.Windows.Forms.Label
        Private WithEvents lblEncodingTime As System.Windows.Forms.Label
        Private WithEvents label3 As System.Windows.Forms.Label
        Private WithEvents cbEncodeType As System.Windows.Forms.ComboBox
        Private WithEvents txtData As System.Windows.Forms.TextBox
        Private WithEvents label1 As System.Windows.Forms.Label
        Friend WithEvents barcode As System.Windows.Forms.GroupBox
        Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    End Class
End Namespace