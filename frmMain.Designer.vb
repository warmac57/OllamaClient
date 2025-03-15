<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.cboModels = New System.Windows.Forms.ComboBox()
        Me.btnRefreshModels = New System.Windows.Forms.Button()
        Me.sliderTemperature = New System.Windows.Forms.TrackBar()
        Me.txtQuestion = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.lblResponse = New System.Windows.Forms.Label()
        Me.lblTempCaption = New System.Windows.Forms.Label()
        Me.txtResponse = New System.Windows.Forms.RichTextBox()
        Me.lblTemperatureValue = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblHelp = New System.Windows.Forms.Label()
        CType(Me.sliderTemperature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboModels
        '
        Me.cboModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModels.FormattingEnabled = True
        Me.cboModels.Location = New System.Drawing.Point(58, 12)
        Me.cboModels.Name = "cboModels"
        Me.cboModels.Size = New System.Drawing.Size(168, 21)
        Me.cboModels.TabIndex = 0
        Me.cboModels.TabStop = False
        '
        'btnRefreshModels
        '
        Me.btnRefreshModels.Location = New System.Drawing.Point(147, 39)
        Me.btnRefreshModels.Name = "btnRefreshModels"
        Me.btnRefreshModels.Size = New System.Drawing.Size(79, 24)
        Me.btnRefreshModels.TabIndex = 1
        Me.btnRefreshModels.TabStop = False
        Me.btnRefreshModels.Text = "Refresh"
        Me.btnRefreshModels.UseVisualStyleBackColor = True
        '
        'sliderTemperature
        '
        Me.sliderTemperature.Location = New System.Drawing.Point(123, 18)
        Me.sliderTemperature.Name = "sliderTemperature"
        Me.sliderTemperature.Size = New System.Drawing.Size(201, 45)
        Me.sliderTemperature.TabIndex = 2
        Me.sliderTemperature.TabStop = False
        Me.sliderTemperature.Value = 7
        '
        'txtQuestion
        '
        Me.txtQuestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuestion.Location = New System.Drawing.Point(15, 86)
        Me.txtQuestion.Multiline = True
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.Size = New System.Drawing.Size(508, 110)
        Me.txtQuestion.TabIndex = 3
        Me.txtQuestion.TabStop = False
        Me.txtQuestion.Text = "What's the capital of France?"
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnSend.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSend.Location = New System.Drawing.Point(529, 86)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(126, 90)
        Me.btnSend.TabIndex = 1
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'statusStrip
        '
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.statusStrip.Location = New System.Drawing.Point(0, 531)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(671, 22)
        Me.statusStrip.TabIndex = 6
        Me.statusStrip.Text = "Ready"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblStatus.Text = "Ready"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New System.Drawing.Point(16, 17)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(39, 13)
        Me.lblModel.TabIndex = 7
        Me.lblModel.Text = "Model:"
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Location = New System.Drawing.Point(15, 68)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(75, 13)
        Me.lblQuestion.TabIndex = 8
        Me.lblQuestion.Text = "Your question:"
        '
        'lblResponse
        '
        Me.lblResponse.AutoSize = True
        Me.lblResponse.Location = New System.Drawing.Point(15, 200)
        Me.lblResponse.Name = "lblResponse"
        Me.lblResponse.Size = New System.Drawing.Size(58, 13)
        Me.lblResponse.TabIndex = 9
        Me.lblResponse.Text = "Response:"
        '
        'lblTempCaption
        '
        Me.lblTempCaption.AutoSize = True
        Me.lblTempCaption.Location = New System.Drawing.Point(36, 18)
        Me.lblTempCaption.Name = "lblTempCaption"
        Me.lblTempCaption.Size = New System.Drawing.Size(70, 13)
        Me.lblTempCaption.TabIndex = 10
        Me.lblTempCaption.Text = "Temperature:"
        '
        'txtResponse
        '
        Me.txtResponse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResponse.Location = New System.Drawing.Point(15, 216)
        Me.txtResponse.Name = "txtResponse"
        Me.txtResponse.Size = New System.Drawing.Size(640, 308)
        Me.txtResponse.TabIndex = 11
        Me.txtResponse.TabStop = False
        Me.txtResponse.Text = ""
        '
        'lblTemperatureValue
        '
        Me.lblTemperatureValue.AutoSize = True
        Me.lblTemperatureValue.Location = New System.Drawing.Point(327, 21)
        Me.lblTemperatureValue.Name = "lblTemperatureValue"
        Me.lblTemperatureValue.Size = New System.Drawing.Size(22, 13)
        Me.lblTemperatureValue.TabIndex = 12
        Me.lblTemperatureValue.Text = "0.7"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(3, 49)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(415, 487)
        Me.RichTextBox1.TabIndex = 13
        Me.RichTextBox1.TabStop = False
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(529, 182)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(126, 31)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblHelp)
        Me.Panel1.Controls.Add(Me.lblTemperatureValue)
        Me.Panel1.Controls.Add(Me.RichTextBox1)
        Me.Panel1.Controls.Add(Me.lblTempCaption)
        Me.Panel1.Controls.Add(Me.sliderTemperature)
        Me.Panel1.Location = New System.Drawing.Point(232, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(423, 51)
        Me.Panel1.TabIndex = 15
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHelp.Location = New System.Drawing.Point(382, 19)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(15, 15)
        Me.lblHelp.TabIndex = 14
        Me.lblHelp.Text = "?"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(671, 553)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtResponse)
        Me.Controls.Add(Me.lblResponse)
        Me.Controls.Add(Me.lblQuestion)
        Me.Controls.Add(Me.lblModel)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtQuestion)
        Me.Controls.Add(Me.btnRefreshModels)
        Me.Controls.Add(Me.cboModels)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ollama Client"
        CType(Me.sliderTemperature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboModels As ComboBox
    Friend WithEvents btnRefreshModels As Button
    Friend WithEvents sliderTemperature As TrackBar
    Friend WithEvents txtQuestion As TextBox
    Friend WithEvents btnSend As Button
    Friend WithEvents statusStrip As StatusStrip
    Friend WithEvents lblModel As Label
    Friend WithEvents lblQuestion As Label
    Friend WithEvents lblResponse As Label
    Friend WithEvents lblTempCaption As Label
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents txtResponse As RichTextBox
    Friend WithEvents lblTemperatureValue As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblHelp As Label
End Class
