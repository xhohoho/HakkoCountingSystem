Imports System.IO
Imports System.IO.Ports

Public Class Form1
    Public Filepath As String = Application.StartupPath & Format(Now, "yyyy-MM-dd")
    Public statusVR, statusPCB As Integer


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.L_TS.Text = Format(Now(), "MMMM dd, yyyy HH:mm")
        'Call Cek_InteGrity()
        'Call Cek_InteGrity()
        Call asingkan()
        Application.DoEvents()
    End Sub

    Private Sub Txt_C_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_C.KeyPress

        If Val(InStr(Me.L_Port.Text, "COM")) < 1 Then
            e.KeyChar = vbNullString
            Me.L_Port.BackColor = Color.Green
            Me.L_Port.ForeColor = Color.White
            Application.DoEvents()
            Threading.Thread.Sleep(100)
            Me.L_Port.BackColor = Color.White
            Me.L_Port.ForeColor = Color.Red
            Threading.Thread.Sleep(100)
            Application.DoEvents()
            Exit Sub
        End If

        'If AscW(e.KeyChar) = Keys.Enter Then Exit Sub

        'MsgBox(Not Char.IsNumber(e.KeyChar))

        If AscW(e.KeyChar) = Keys.Enter And Txt_C.Text = "999" Then
            Txt_C.Text = vbNullString
            L_PCBCC.Text = "0"
            L_VRCC.Text = "0"
            Using writer As New StreamWriter(Filepath, True)
                writer.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss.fff") & ", User reset counter @" & Environ("COMPUTERNAME"))
                writer.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss.fff") & ", " & "HK1 type" & ", " & "Reset" & ", " & Val(Me.Txt_C.Text) + Val(Me.L_VRCC.Text))
                writer.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss.fff") & ", " & "HK2 type" & ", " & "Reset" & ", " & Val(Me.Txt_C.Text) + Val(Me.L_PCBCC.Text))
            End Using

            Call Cek_InteGrity()

            Exit Sub
        End If

        If AscW(e.KeyChar) = Keys.Enter Then Exit Sub

        If Not Char.IsNumber(e.KeyChar) AndAlso e.KeyChar <> "-" AndAlso e.KeyChar <> vbBack And Me.L_VR.Text = "HK1 type" Then
            Me.L_VR.Text = "HK2 type"
            e.KeyChar = vbNullString
            Me.Txt_C.Text = vbNullString
        ElseIf Not Char.IsNumber(e.KeyChar) AndAlso e.KeyChar <> "-" AndAlso e.KeyChar <> vbBack And Me.L_VR.Text = "HK2 type" Then
            Me.L_VR.Text = "HK1 type"
            e.KeyChar = vbNullString
            Me.Txt_C.Text = vbNullString
        End If

    End Sub


    Private Sub Txt_C_KeyUp(sender As Object, e As KeyEventArgs) Handles Txt_C.KeyUp

        Dim serialPortSender As New SerialPortSender(Me.L_Port.Text) ' Replace with the actual COM port

        If Len(Me.Txt_C.Text) > 3 Then Me.Txt_C.Text = vbNullString
        If e.KeyCode <> Keys.Enter Then Exit Sub
        If Trim(Me.Txt_C.Text) = vbNullString Then Exit Sub
        If Val(Me.Txt_C.Text) = 0 Then Exit Sub

        Using writer As New StreamWriter(Filepath, True)
            If Me.L_VR.Text = "HK1 type" Then
                writer.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss.fff") & ", " & Trim(Me.L_VR.Text) & ", " & Me.Txt_C.Text & ", " & Val(Me.Txt_C.Text) + Val(Me.L_VRCC.Text))
                Me.L_VRCC.Text = Val(Me.Txt_C.Text) + Val(Me.L_VRCC.Text)
                If Val(Me.L_VRCC.Text) <= 8 Then Me.L_VRCC.BackColor = Me.BackColor : Me.L_VRC.BackColor = Me.BackColor
                If Val(Me.L_VRCC.Text) > 8 Then Me.L_VRCC.BackColor = Color.Yellow : Me.L_VRC.BackColor = Color.Yellow
                If Val(Me.L_VRCC.Text) > 13 Then Me.L_VRCC.BackColor = Color.Red : Me.L_VRC.BackColor = Color.Red

            ElseIf Me.L_VR.Text = "HK2 type" Then
                writer.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss.fff") & ", " & Trim(Me.L_VR.Text) & ", " & Me.Txt_C.Text & ", " & Val(Me.Txt_C.Text) + Val(Me.L_PCBCC.Text))
                Me.L_PCBCC.Text = Val(Me.Txt_C.Text) + Val(Me.L_PCBCC.Text)
                If Val(Me.L_PCBCC.Text) <= 8 Then Me.L_PCBCC.BackColor = Me.BackColor : Me.L_pcbC.BackColor = Me.BackColor
                If Val(Me.L_PCBCC.Text) > 8 Then Me.L_PCBCC.BackColor = Color.Yellow : Me.L_pcbC.BackColor = Color.Yellow
                If Val(Me.L_PCBCC.Text) > 13 Then Me.L_PCBCC.BackColor = Color.Red : Me.L_pcbC.BackColor = Color.Red
            End If
        End Using

        Me.Txt_C.Text = vbNullString
        Call Cek_InteGrity()
        Application.DoEvents()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ComboBox1.Visible = False
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1500

        statusVR = 0
        statusPCB = 0

        Me.Text = ".: Hakko CS :."

        Me.L_Port.Text = "No Port Selected"
        Me.L_Port.BackColor = Color.White
        Me.L_Port.ForeColor = Color.Red
        Call Cek_InteGrity()
        Call GetSerialPortNames()
        Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        'ReceiveSerialData("COM8", 115200, "yellow")
        Me.Txt_C.Select()
    End Sub

    Private Sub Cek_InteGrity()
        Dim serialPortSender As New SerialPortSender(Me.L_Port.Text) ' Replace with the actual COM port
        Dim timestamp = DateTime.Now.ToString("yyyy-MM-dd")
        Filepath = Application.StartupPath & "\" & "cslog.txt"
        Me.L_PCBCC.Text = 0
        Me.L_VRCC.Text = 0


        If Not System.IO.File.Exists(Filepath) Then
            File.Create(Filepath).Dispose()
            If Val(InStr(UCase(Me.L_Port.Text), "PORT")) < 1 Then send("green")

            Using writer As New StreamWriter(Filepath, True)
                writer.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss.fff") & ", HK1 type, 0, 0")
                writer.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss.fff") & ", HK2 type, 0, 0")
            End Using
        Else
            ' Create a StreamReader to read the file.
            Using reader As New StreamReader(Filepath)
                ' Read and process each line in the file.
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    If Val(InStr(line, "HK1 type", vbTextCompare)) Then
                        ' Split the string by commas
                        Dim parts() As String = line.Split(",")
                        ' Get the last value
                        Me.L_VRCC.Text = parts(parts.Length - 1).Trim()
                    ElseIf Val(InStr(line, "HK2 type", vbTextCompare)) Then
                        ' Split the string by commas
                        Dim parts() As String = line.Split(",")
                        ' Get the last value
                        Me.L_PCBCC.Text = parts(parts.Length - 1).Trim()
                    End If

                End While
            End Using
        End If

        If Val(Me.L_PCBCC.Text) <= 8 Then Me.L_PCBCC.BackColor = Me.BackColor : Me.L_pcbC.BackColor = Me.BackColor : statusPCB = 0
        If Val(Me.L_VRCC.Text) <= 8 Then Me.L_VRCC.BackColor = Me.BackColor : Me.L_VRC.BackColor = Me.BackColor : statusVR = 0
        If Val(Me.L_PCBCC.Text) > 8 And Val(Me.L_PCBCC.Text) <= 13 Then Me.L_PCBCC.BackColor = Color.Yellow : Me.L_pcbC.BackColor = Color.Yellow : statusPCB = 1
        If Val(Me.L_VRCC.Text) > 8 AndAlso Val(Me.L_VRCC.Text) <= 13 Then Me.L_VRCC.BackColor = Color.Yellow : Me.L_VRC.BackColor = Color.Yellow : statusVR = 1
        If Val(Me.L_VRCC.Text) > 13 Then Me.L_VRCC.BackColor = Color.Red : Me.L_VRC.BackColor = Color.Red : statusVR = 2
        If Val(Me.L_PCBCC.Text) > 13 Then Me.L_PCBCC.BackColor = Color.Red : Me.L_pcbC.BackColor = Color.Red : statusPCB = 2

        'If Val(InStr(UCase(Me.L_Port.Text), "PORT")) < 1 Then send("green")

    End Sub

    Sub asingkan()
        If Val(InStr(UCase(Me.L_Port.Text), "PORT")) < 1 Then
            If statusVR = 0 And statusPCB = 0 Then send("green" & vbCrLf)

            If statusVR = 0 And statusPCB = 1 Or
                statusVR = 1 And statusPCB = 0 Or
                statusVR = 1 And statusPCB = 1 Then send("yellow" & vbCrLf)

            If statusVR = 2 Or
             statusPCB = 2 Then send("red" & vbCrLf)
        End If

        Application.DoEvents()
    End Sub


    Sub GetSerialPortNames()
        ' Show all available COM ports.
        Me.ComboBox1.Items.Clear()

        For Each sp As String In SerialPort.GetPortNames()
            'ListBox1.Items.Add(sp)
            Me.ComboBox1.Items.Add(sp)
        Next
        Me.ComboBox1.Sorted = True
    End Sub




    Private Sub L_Port_Click(sender As Object, e As EventArgs) Handles L_Port.Click
        If Me.ComboBox1.Visible = True Then Me.ComboBox1.Visible = False
        If Me.ComboBox1.Visible = False Then
            Me.ComboBox1.Visible = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.L_Port.Text = Me.ComboBox1.Text

        Me.ComboBox1.Visible = False
        Me.L_Port.ForeColor = Color.Black
        Me.L_Port.BackColor = Me.BackColor
        Call Cek_InteGrity()
        Call asingkan()

    End Sub

    Private Sub L_VR_Click(sender As Object, e As EventArgs) Handles L_VR.Click

        If Val(InStr(Me.L_Port.Text, "COM")) < 1 Then

            Me.L_Port.BackColor = Color.Green
            Me.L_Port.ForeColor = Color.White
            Application.DoEvents()
            Threading.Thread.Sleep(200)
            Me.L_Port.BackColor = Color.White
            Me.L_Port.ForeColor = Color.Red
            Threading.Thread.Sleep(200)
            Application.DoEvents()
            Exit Sub
        End If


        Dim serialPortSender As New SerialPortSender(Me.L_Port.Text) ' Replace with the actual COM port
        serialPortSender.OpenPort() ' Open the serial port
        serialPortSender.SendCommand("red") ' Send your command
        Threading.Thread.Sleep(1000)
        serialPortSender.SendCommand("green") ' Send your command
        Threading.Thread.Sleep(1000)
        serialPortSender.SendCommand("yellow") ' Send your command
        Threading.Thread.Sleep(1000)
        serialPortSender.ClosePort() ' Close the serial port when done
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub send(str As String)
        Dim serialPort As New SerialPort()

        ' Specify the COM port name (e.g., COM1) and baud rate (e.g., 9600)
        serialPort.PortName = Me.L_Port.Text
        serialPort.BaudRate = 115200

        ' Optionally, you can set other serial port properties such as DataBits, Parity, StopBits, etc.
        ' serialPort.DataBits = 8
        ' serialPort.Parity = Parity.None
        ' serialPort.StopBits = StopBits.One

        ' Open the serial port
        serialPort.Open()

        ' You can now use the serial port for communication
        serialPort.Write(str)
        ' Close the serial port when done
        serialPort.Close()
    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        Call GetSerialPortNames()
    End Sub
End Class

Public Class SerialPortSender
    Private serialPort As SerialPort

    Public Sub New(portName As String)
        serialPort = New SerialPort(portName)
        ' You can set other properties like BaudRate, DataBits, Parity, StopBits, etc.
    End Sub

    Public Sub OpenPort()
        serialPort.Open()
    End Sub

    Public Sub SendCommand(command As String)
        serialPort.Write(command)
    End Sub

    Public Sub ClosePort()
        serialPort.Close()
    End Sub
End Class

