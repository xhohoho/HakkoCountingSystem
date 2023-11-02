<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.L_TS = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txt_C = New System.Windows.Forms.TextBox()
        Me.L_VR = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.L_PCBCC = New System.Windows.Forms.Label()
        Me.L_pcbC = New System.Windows.Forms.Label()
        Me.L_VRC = New System.Windows.Forms.Label()
        Me.L_VRCC = New System.Windows.Forms.Label()
        Me.L_Port = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1500
        '
        'L_TS
        '
        Me.L_TS.AutoSize = True
        Me.L_TS.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.L_TS.Location = New System.Drawing.Point(10, 8)
        Me.L_TS.Name = "L_TS"
        Me.L_TS.Size = New System.Drawing.Size(64, 19)
        Me.L_TS.TabIndex = 2
        Me.L_TS.Text = "VR type"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Txt_C)
        Me.GroupBox1.Controls.Add(Me.L_VR)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(201, 74)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "WorkBench"
        '
        'Txt_C
        '
        Me.Txt_C.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Txt_C.Font = New System.Drawing.Font("Tahoma", 20.0!)
        Me.Txt_C.Location = New System.Drawing.Point(145, 26)
        Me.Txt_C.Name = "Txt_C"
        Me.Txt_C.Size = New System.Drawing.Size(51, 33)
        Me.Txt_C.TabIndex = 5
        Me.Txt_C.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'L_VR
        '
        Me.L_VR.AutoSize = True
        Me.L_VR.Font = New System.Drawing.Font("Tahoma", 20.0!)
        Me.L_VR.Location = New System.Drawing.Point(5, 26)
        Me.L_VR.Name = "L_VR"
        Me.L_VR.Size = New System.Drawing.Size(123, 33)
        Me.L_VR.TabIndex = 4
        Me.L_VR.Text = "HK1 type"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.L_PCBCC)
        Me.GroupBox2.Controls.Add(Me.L_pcbC)
        Me.GroupBox2.Controls.Add(Me.L_VRC)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(201, 125)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Summary"
        '
        'L_PCBCC
        '
        Me.L_PCBCC.AutoSize = True
        Me.L_PCBCC.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_PCBCC.Location = New System.Drawing.Point(149, 75)
        Me.L_PCBCC.Name = "L_PCBCC"
        Me.L_PCBCC.Size = New System.Drawing.Size(45, 33)
        Me.L_PCBCC.TabIndex = 7
        Me.L_PCBCC.Text = "88"
        Me.L_PCBCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L_pcbC
        '
        Me.L_pcbC.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_pcbC.Location = New System.Drawing.Point(5, 75)
        Me.L_pcbC.Name = "L_pcbC"
        Me.L_pcbC.Size = New System.Drawing.Size(190, 36)
        Me.L_pcbC.TabIndex = 6
        Me.L_pcbC.Text = "HK2 Count"
        '
        'L_VRC
        '
        Me.L_VRC.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_VRC.Location = New System.Drawing.Point(5, 26)
        Me.L_VRC.Name = "L_VRC"
        Me.L_VRC.Size = New System.Drawing.Size(190, 36)
        Me.L_VRC.TabIndex = 4
        Me.L_VRC.Text = "HK1 Count"
        '
        'L_VRCC
        '
        Me.L_VRCC.AutoSize = True
        Me.L_VRCC.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_VRCC.Location = New System.Drawing.Point(159, 144)
        Me.L_VRCC.Name = "L_VRCC"
        Me.L_VRCC.Size = New System.Drawing.Size(45, 33)
        Me.L_VRCC.TabIndex = 7
        Me.L_VRCC.Text = "88"
        Me.L_VRCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'L_Port
        '
        Me.L_Port.AutoSize = True
        Me.L_Port.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.L_Port.Location = New System.Drawing.Point(0, 253)
        Me.L_Port.Name = "L_Port"
        Me.L_Port.Size = New System.Drawing.Size(64, 23)
        Me.L_Port.TabIndex = 8
        Me.L_Port.Text = "Label1"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(60, 253)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(104, 21)
        Me.ComboBox1.TabIndex = 9
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(221, 276)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.L_Port)
        Me.Controls.Add(Me.L_VRCC)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.L_TS)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents L_TS As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Txt_C As TextBox
    Friend WithEvents L_VR As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents L_VRC As Label
    Friend WithEvents L_pcbC As Label
    Friend WithEvents L_VRCC As Label
    Friend WithEvents L_PCBCC As Label
    Friend WithEvents L_Port As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
