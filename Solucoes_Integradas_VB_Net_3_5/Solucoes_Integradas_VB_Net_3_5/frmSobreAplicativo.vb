Namespace Solucoes_Integradas_VB_Net_3_5
    Public NotInheritable Class frmSobreAplicativo

        Private Sub frmSobreAplicativo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Set the title of the form.
            Dim ApplicationTitle As String
            If My.Application.Info.Title <> "" Then
                ApplicationTitle = My.Application.Info.Title
            Else
                ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If
            Me.Text = "Sobre o Aplicativo" ' String.Format("About {0}", ApplicationTitle)
            ' Initialize all of the text displayed on the About Box.
            ' TODO: Customize the application's assembly information in the "Application" pane of the project 
            '    properties dialog (under the "Project" menu).
            Me.lblProductName.Text = "Software voltado ao Patrimônio da Eletronorte" 'My.Application.Info.ProductName
            Me.lblVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
            Me.lblCopyright.Text = My.Application.Info.Copyright
            Me.lblCompanyName.Text = My.Application.Info.CompanyName
            Me.txtDescription.Text = _
            "Esse aplicativo foi voltado para o setor de patrimônio, sendo um software sem " _
            & _
            "preocupações com direito autoral, caso haja necessidade, qualquer alteração poderá ser realizada. Contudo " _
            & _
            "deve-se considerar que qualquer dano que venha ocorrer em virtude de seu uso, não será de responsabilidade " _
            & _
            "do criador deste." _
            & _
            System.Environment.NewLine _
            & _
            System.Environment.NewLine _
            & _
            "Autor: Hebervaldo de Paula Carvalhêdo" _
            & _
            System.Environment.NewLine _
            & _
            "Matrícula: 10525" _
            & _
            System.Environment.NewLine _
            & _
            "Órgao: GISB" _
            & _
            System.Environment.NewLine _
            & _
            "Empresa: Eletronorte."

            ' My.Application.Info.Description
        End Sub

        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Me.Close()
        End Sub
    End Class
End Namespace