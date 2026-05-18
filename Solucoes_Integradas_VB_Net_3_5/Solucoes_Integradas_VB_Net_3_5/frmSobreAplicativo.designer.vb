Namespace Solucoes_Integradas_VB_Net_3_5
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmSobreAplicativo
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSobreAplicativo))
            Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
            Me.LogoPictureBox = New System.Windows.Forms.PictureBox
            Me.lblProductName = New System.Windows.Forms.Label
            Me.lblVersion = New System.Windows.Forms.Label
            Me.lblCopyright = New System.Windows.Forms.Label
            Me.lblCompanyName = New System.Windows.Forms.Label
            Me.txtDescription = New System.Windows.Forms.TextBox
            Me.btnOK = New System.Windows.Forms.Button
            Me.TableLayoutPanel.SuspendLayout()
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TableLayoutPanel
            '
            Me.TableLayoutPanel.ColumnCount = 2
            Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
            Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
            Me.TableLayoutPanel.Controls.Add(Me.LogoPictureBox, 0, 0)
            Me.TableLayoutPanel.Controls.Add(Me.lblProductName, 1, 0)
            Me.TableLayoutPanel.Controls.Add(Me.lblVersion, 1, 1)
            Me.TableLayoutPanel.Controls.Add(Me.lblCopyright, 1, 2)
            Me.TableLayoutPanel.Controls.Add(Me.lblCompanyName, 1, 3)
            Me.TableLayoutPanel.Controls.Add(Me.txtDescription, 1, 4)
            Me.TableLayoutPanel.Controls.Add(Me.btnOK, 1, 5)
            Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel.Location = New System.Drawing.Point(9, 9)
            Me.TableLayoutPanel.Name = "TableLayoutPanel"
            Me.TableLayoutPanel.RowCount = 6
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel.Size = New System.Drawing.Size(776, 457)
            Me.TableLayoutPanel.TabIndex = 0
            '
            'LogoPictureBox
            '
            Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
            Me.LogoPictureBox.Location = New System.Drawing.Point(3, 3)
            Me.LogoPictureBox.Name = "LogoPictureBox"
            Me.TableLayoutPanel.SetRowSpan(Me.LogoPictureBox, 6)
            Me.LogoPictureBox.Size = New System.Drawing.Size(250, 451)
            Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.LogoPictureBox.TabIndex = 0
            Me.LogoPictureBox.TabStop = False
            '
            'lblProductName
            '
            Me.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblProductName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblProductName.Location = New System.Drawing.Point(262, 0)
            Me.lblProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
            Me.lblProductName.MaximumSize = New System.Drawing.Size(0, 17)
            Me.lblProductName.Name = "lblProductName"
            Me.lblProductName.Size = New System.Drawing.Size(511, 17)
            Me.lblProductName.TabIndex = 1
            Me.lblProductName.Text = "Product Name"
            Me.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblVersion
            '
            Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblVersion.Location = New System.Drawing.Point(262, 45)
            Me.lblVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
            Me.lblVersion.MaximumSize = New System.Drawing.Size(0, 17)
            Me.lblVersion.Name = "lblVersion"
            Me.lblVersion.Size = New System.Drawing.Size(511, 17)
            Me.lblVersion.TabIndex = 2
            Me.lblVersion.Text = "Version"
            Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCopyright
            '
            Me.lblCopyright.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblCopyright.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblCopyright.Location = New System.Drawing.Point(262, 90)
            Me.lblCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
            Me.lblCopyright.MaximumSize = New System.Drawing.Size(0, 17)
            Me.lblCopyright.Name = "lblCopyright"
            Me.lblCopyright.Size = New System.Drawing.Size(511, 17)
            Me.lblCopyright.TabIndex = 3
            Me.lblCopyright.Text = "Copyright"
            Me.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCompanyName
            '
            Me.lblCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblCompanyName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.lblCompanyName.Location = New System.Drawing.Point(262, 135)
            Me.lblCompanyName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
            Me.lblCompanyName.MaximumSize = New System.Drawing.Size(0, 17)
            Me.lblCompanyName.Name = "lblCompanyName"
            Me.lblCompanyName.Size = New System.Drawing.Size(511, 17)
            Me.lblCompanyName.TabIndex = 4
            Me.lblCompanyName.Text = "Company Name"
            Me.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtDescription
            '
            Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill
            Me.txtDescription.Enabled = False
            Me.txtDescription.Location = New System.Drawing.Point(262, 183)
            Me.txtDescription.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
            Me.txtDescription.Multiline = True
            Me.txtDescription.Name = "txtDescription"
            Me.txtDescription.ReadOnly = True
            Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.txtDescription.Size = New System.Drawing.Size(511, 222)
            Me.txtDescription.TabIndex = 5
            Me.txtDescription.TabStop = False
            Me.txtDescription.Text = resources.GetString("txtDescription.Text")
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnOK.Location = New System.Drawing.Point(698, 431)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(75, 23)
            Me.btnOK.TabIndex = 6
            Me.btnOK.Text = "&OK"
            '
            'frmSobreAplicativo
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(794, 475)
            Me.Controls.Add(Me.TableLayoutPanel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmSobreAplicativo"
            Me.Padding = New System.Windows.Forms.Padding(9)
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Sobre o Aplicativo"
            Me.TableLayoutPanel.ResumeLayout(False)
            Me.TableLayoutPanel.PerformLayout()
            CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
        Friend WithEvents lblProductName As System.Windows.Forms.Label
        Friend WithEvents lblVersion As System.Windows.Forms.Label
        Friend WithEvents lblCopyright As System.Windows.Forms.Label
        Friend WithEvents lblCompanyName As System.Windows.Forms.Label
        Friend WithEvents txtDescription As System.Windows.Forms.TextBox
        Friend WithEvents btnOK As System.Windows.Forms.Button

    End Class
End Namespace