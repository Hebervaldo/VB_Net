Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.ComponentModel

Namespace Solucoes_Integradas_VB_Net_3_5
    Public Class clsFlatDateTimePicker
        Inherits DateTimePicker

#Region "ComboInfoHelper"
        Friend Class ComboInfoHelper
            <DllImport("user32")> _
            Private Shared Function GetComboBoxInfo(ByVal hwndCombo As IntPtr, ByRef info As ComboBoxInfo) As Boolean
            End Function

#Region "RECT struct"
            <StructLayout(LayoutKind.Sequential)> _
            Private Structure RECT
                Public Left As Integer
                Public Top As Integer
                Public Right As Integer
                Public Bottom As Integer
            End Structure
#End Region

#Region "ComboBoxInfo Struct"
            <StructLayout(LayoutKind.Sequential)> _
            Private Structure ComboBoxInfo
                Public cbSize As Integer
                Public rcItem As RECT
                Public rcButton As RECT
                Public stateButton As IntPtr
                Public hwndCombo As IntPtr
                Public hwndEdit As IntPtr
                Public hwndList As IntPtr
            End Structure
#End Region

            Public Shared Function GetComboDropDownWidth() As Integer
                Dim cb As New ComboBox()
                Dim width As Integer = GetComboDropDownWidth(cb.Handle)
                cb.Dispose()
                Return width
            End Function

            Public Shared Function GetComboDropDownWidth(ByVal handle As IntPtr) As Integer
                Dim cbi As New ComboBoxInfo()
                cbi.cbSize = Marshal.SizeOf(cbi)
                GetComboBoxInfo(handle, cbi)
                Dim width As Integer = cbi.rcButton.Right - cbi.rcButton.Left
                Return width
            End Function
        End Class
#End Region

        <DllImport("user32.dll", EntryPoint:="SendMessageA")> _
        Private Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As Object) As Integer
        End Function

        <DllImport("user32")> _
        Private Shared Function GetWindowDC(ByVal hWnd As IntPtr) As IntPtr
        End Function

        <DllImport("user32")> _
        Private Shared Function ReleaseDC(ByVal hWnd As IntPtr, ByVal hDC As IntPtr) As Integer
        End Function

        Const WM_ERASEBKGND As Integer = &H14
        Const WM_PAINT As Integer = &HF
        Const WM_NC_HITTEST As Integer = &H84
        Const WM_NC_PAINT As Integer = &H85
        Const WM_PRINTCLIENT As Integer = &H318
        Const WM_SETCURSOR As Integer = &H20

        'Private BorderPen As New Pen(Color.Black, 4)
        'Private BorderPenControl As New Pen(SystemColors.ControlDark, 4)
        Private DroppedDown As Boolean = False
        Private InvalidateSince As Integer = 0
        Private Shared DropDownButtonWidth As Integer = 17

        ' COR FUNDO
        Private m_BackBrush As SolidBrush

        <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
        Public Overrides Property BackColor() As Color
            Get
                Return MyBase.BackColor
            End Get
            Set(ByVal Value As Color)
                If Not m_BackBrush Is Nothing Then
                    m_BackBrush.Dispose()
                End If
                MyBase.BackColor = Value
                m_BackBrush = New SolidBrush(Me.BackColor)
                Me.Invalidate()
            End Set
        End Property
        ' COR FUNDO

        Shared Sub New()
            DropDownButtonWidth = ComboInfoHelper.GetComboDropDownWidth() + 1
        End Sub

        Public Sub New()
            MyBase.New()
            Me.SetStyle(ControlStyles.DoubleBuffer, True)
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        End Sub

        Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)
            MyBase.OnValueChanged(eventargs)
            Me.Invalidate()
        End Sub

        Protected Overrides Sub WndProc(ByRef m As Message)
            Dim hDC As IntPtr = IntPtr.Zero
            Dim gdc As Graphics = Nothing
            Select Case m.Msg
                Case WM_NC_PAINT
                    hDC = GetWindowDC(m.HWnd)
                    gdc = Graphics.FromHdc(hDC)
                    SendMessage(Me.Handle, WM_ERASEBKGND, hDC, 0)
                    SendPrintClientMsg()
                    SendMessage(Me.Handle, WM_PAINT, IntPtr.Zero, 0)
                    OverrideControlBorder(gdc)
                    m.Result = New IntPtr(1)
                    ReleaseDC(m.HWnd, hDC)
                    gdc.Dispose()
                    Exit Select
                Case WM_PAINT
                    MyBase.WndProc(m)
                    hDC = GetWindowDC(m.HWnd)
                    gdc = Graphics.FromHdc(hDC)
                    OverrideDropDown(gdc)
                    OverrideControlBorder(gdc)
                    ReleaseDC(m.HWnd, hDC)
                    gdc.Dispose()
                    Exit Select
                Case WM_SETCURSOR
                    MyBase.WndProc(m)
                    If DroppedDown AndAlso InvalidateSince < 3 Then
                        Invalidate()
                        InvalidateSince += 1
                    End If
                    Exit Select

                    ' APLICA BKGCOLOR
                Case WM_ERASEBKGND
                    MyBase.WndProc(m)
                    Dim g As Graphics = Graphics.FromHdc(m.WParam)
                    If m_BackBrush Is Nothing Then
                        m_BackBrush = New SolidBrush(Me.BackColor)
                    End If
                    g.FillRectangle(m_BackBrush, Me.ClientRectangle)
                    g.Dispose()
                    Exit Select
                    ' APLICA BKGCOLOR

                Case Else
                    MyBase.WndProc(m)
                    Exit Select
            End Select
        End Sub

        Private Sub SendPrintClientMsg()
            Dim gClient As Graphics = Me.CreateGraphics()
            Dim ptrClientDC As IntPtr = gClient.GetHdc()
            SendMessage(Me.Handle, WM_PRINTCLIENT, ptrClientDC, 0)
            gClient.ReleaseHdc(ptrClientDC)
            gClient.Dispose()
        End Sub

        Private Sub OverrideDropDown(ByVal g As Graphics)
            If Not Me.ShowUpDown Then
                ' SETA
                Dim rect As New Rectangle(Me.Width - DropDownButtonWidth, 0, DropDownButtonWidth, Me.Height)
                ControlPaint.DrawComboButton(g, rect, ButtonState.Flat)
            End If
        End Sub

        Private p As Pen

        Private Sub OverrideControlBorder(ByVal g As Graphics)
            If p Is Nothing Then
                ' COR CANETA
                p = New Pen(Color.White, 1)
            End If
            If Me.Focused = False OrElse Me.Enabled = False Then
                ' SEM FOCO
                g.DrawRectangle(p, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                g.DrawRectangle(p, New Rectangle(1, 1, Me.Width - DropDownButtonWidth - 1, Me.Height - 1))
                g.DrawRectangle(p, New Rectangle(2, Me.Height - 2, Me.Width - DropDownButtonWidth - 2, 2))
                g.DrawRectangle(p, New Rectangle(Me.Width - DropDownButtonWidth - 1, 0, Me.Width - DropDownButtonWidth - 3, Me.Height))
            Else
                ' COM FOCO
                g.DrawRectangle(p, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                g.DrawRectangle(p, New Rectangle(1, 1, Me.Width - DropDownButtonWidth - 1, Me.Height - 1))
                g.DrawRectangle(p, New Rectangle(2, Me.Height - 2, Me.Width - DropDownButtonWidth - 2, 2))

                ' apaga a linha vertical
                g.DrawRectangle(p, New Rectangle(Me.Width - DropDownButtonWidth - 1, 0, Me.Width - DropDownButtonWidth - 3, Me.Height))
            End If
        End Sub

        Protected Overrides Sub OnDropDown(ByVal eventargs As EventArgs)
            InvalidateSince = 0
            DroppedDown = True
            MyBase.OnDropDown(eventargs)
        End Sub

        Protected Overrides Sub OnCloseUp(ByVal eventargs As EventArgs)
            DroppedDown = False
            MyBase.OnCloseUp(eventargs)
        End Sub

        Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
            MyBase.OnLostFocus(e)
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
            MyBase.OnGotFocus(e)
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)
            Me.Invalidate()
        End Sub
    End Class
End Namespace