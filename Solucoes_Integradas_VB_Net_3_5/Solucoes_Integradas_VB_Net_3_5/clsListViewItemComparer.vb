Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class clsListViewItemComparer : Implements System.Collections.IComparer

        Public Enum enmTipo
            Data
            Inteiro
            Texto
        End Enum

        Public Tipo As enmTipo = enmTipo.Texto

        Private col As Integer
        Private order As SortOrder

        Public Sub New()
            col = 0
            order = SortOrder.Ascending
        End Sub

        Public Sub New(ByVal column As Integer, ByVal order As SortOrder)
            Me.New(column, order, enmTipo.Texto)
        End Sub

        Public Sub New(ByVal column As Integer, ByVal order As SortOrder, ByVal type As enmTipo)
            col = column
            Me.order = order
            Tipo = type
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim returnVal As Integer = -1

            Try
                Select Case Tipo
                    Case enmTipo.Data
                        returnVal = 0
                        ' Determine whether the type being compared is a date type.
                        Try
                            ' Parse the two objects passed as a parameter as a DateTime.
                            Dim firstDate As System.DateTime = DateTime.Parse(CType(x,  _
                                                    ListViewItem).SubItems(col).Text)
                            Dim secondDate As System.DateTime = DateTime.Parse(CType(y,  _
                                                      ListViewItem).SubItems(col).Text)
                            ' Compare the two dates.
                            returnVal = DateTime.Compare(firstDate, secondDate)
                            ' If neither compared object has a valid date format, 
                            ' compare as a string.
                        Catch
                            ' Compare the two items as a string.
                            returnVal = [String].Compare(CType(x,  _
                                              ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
                        End Try

                        ' Determine whether the sort order is descending.
                        If order = SortOrder.Descending Then
                            ' Invert the value returned by String.Compare.
                            returnVal *= -1
                        End If
                    Case enmTipo.Inteiro
                        If System.Convert.ToInt64(CType(x, ListViewItem).SubItems(col).Text) < System.Convert.ToInt64(CType(y, ListViewItem).SubItems(col).Text) Then
                            returnVal = -1
                        ElseIf System.Convert.ToInt64(CType(x, ListViewItem).SubItems(col).Text) = System.Convert.ToInt64(CType(y, ListViewItem).SubItems(col).Text) Then
                            returnVal = 0
                        ElseIf System.Convert.ToInt64(CType(x, ListViewItem).SubItems(col).Text) > System.Convert.ToInt64(CType(y, ListViewItem).SubItems(col).Text) Then
                            returnVal = 1
                        End If
                        ' Determine whether the sort order is descending.
                        If order = SortOrder.Descending Then
                            ' Invert the value returned by String.Compare.
                            returnVal *= -1
                        End If
                    Case enmTipo.Texto
                        returnVal = [String].Compare(CType(x,  _
                                        ListViewItem).SubItems(col).Text, _
                                        CType(y, ListViewItem).SubItems(col).Text)
                        ' Determine whether the sort order is descending.
                        If order = SortOrder.Descending Then
                            ' Invert the value returned by String.Compare.
                            returnVal *= -1
                        End If
                End Select
            Catch ex As Exception

            End Try

            Return returnVal
        End Function

        Private Shared sortColumn As Integer = -1

        Public Shared Sub mtdOrdenarListViewColuna(ByRef lsv As System.Windows.Forms.ListView, ByVal Coluna As Integer, ByVal Tipo As clsListViewItemComparer.enmTipo)
            ' Determine whether the column is the same as the last column clicked.
            If Coluna <> sortColumn Then
                ' Set the sort column to the new column.
                sortColumn = Coluna
                ' Set the sort order to ascending by default.
                lsv.Sorting = SortOrder.Ascending
            Else
                ' Determine what the last sort order was and change it.
                If lsv.Sorting = SortOrder.Ascending Then
                    lsv.Sorting = SortOrder.Descending
                Else
                    lsv.Sorting = SortOrder.Ascending
                End If
            End If
            ' Call the sort method to manually sort.
            lsv.Sort()
            ' Set the ListViewItemSorter property to a new ListViewItemComparer
            ' object.

            lsv.ListViewItemSorter = New clsListViewItemComparer(Coluna, lsv.Sorting, Tipo)
        End Sub
    End Class
End Namespace