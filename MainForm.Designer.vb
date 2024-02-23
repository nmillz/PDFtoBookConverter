<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.chkAddFrontPages = New System.Windows.Forms.CheckBox()
        Me.chkMinimizeSignatures = New System.Windows.Forms.CheckBox()
        Me.lblPDFLocation = New System.Windows.Forms.Label()
        Me.txtPDFLocation = New System.Windows.Forms.TextBox()
        Me.txtPDFPageCount = New System.Windows.Forms.TextBox()
        Me.lblSheetsPerSignature = New System.Windows.Forms.Label()
        Me.lblPDFPageCount = New System.Windows.Forms.Label()
        Me.LabelSignatures = New System.Windows.Forms.Label()
        Me.LabelSheets = New System.Windows.Forms.Label()
        Me.lblSignatures = New System.Windows.Forms.Label()
        Me.lblSheets = New System.Windows.Forms.Label()
        Me.chkDoublSided = New System.Windows.Forms.CheckBox()
        Me.cboSheetsPerSignature = New System.Windows.Forms.ComboBox()
        Me.lblTotalPages = New System.Windows.Forms.Label()
        Me.LabelTotalPages = New System.Windows.Forms.Label()
        Me.lblBlankPages = New System.Windows.Forms.Label()
        Me.LabelBlankPages = New System.Windows.Forms.Label()
        Me.chkMaxSignatures = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblFrontPages = New System.Windows.Forms.Label()
        Me.cboFrontPageCount = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(330, 30)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(21, 22)
        Me.btnOpenFile.TabIndex = 0
        Me.btnOpenFile.Text = "..."
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'btnConvert
        '
        Me.btnConvert.Enabled = False
        Me.btnConvert.Location = New System.Drawing.Point(257, 274)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(94, 20)
        Me.btnConvert.TabIndex = 6
        Me.btnConvert.Text = "Convert to Book"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'chkAddFrontPages
        '
        Me.chkAddFrontPages.AutoSize = True
        Me.chkAddFrontPages.Location = New System.Drawing.Point(10, 125)
        Me.chkAddFrontPages.Name = "chkAddFrontPages"
        Me.chkAddFrontPages.Size = New System.Drawing.Size(148, 17)
        Me.chkAddFrontPages.TabIndex = 4
        Me.chkAddFrontPages.Text = "Add blank pages at front?"
        Me.chkAddFrontPages.UseVisualStyleBackColor = True
        '
        'chkMinimizeSignatures
        '
        Me.chkMinimizeSignatures.AutoSize = True
        Me.chkMinimizeSignatures.Location = New System.Drawing.Point(10, 146)
        Me.chkMinimizeSignatures.Name = "chkMinimizeSignatures"
        Me.chkMinimizeSignatures.Size = New System.Drawing.Size(199, 17)
        Me.chkMinimizeSignatures.TabIndex = 5
        Me.chkMinimizeSignatures.Text = "Minimize blank pages added to end?"
        Me.chkMinimizeSignatures.UseVisualStyleBackColor = True
        '
        'lblPDFLocation
        '
        Me.lblPDFLocation.AutoSize = True
        Me.lblPDFLocation.Location = New System.Drawing.Point(10, 16)
        Me.lblPDFLocation.Name = "lblPDFLocation"
        Me.lblPDFLocation.Size = New System.Drawing.Size(99, 13)
        Me.lblPDFLocation.TabIndex = 4
        Me.lblPDFLocation.Text = "PDF Book location:"
        '
        'txtPDFLocation
        '
        Me.txtPDFLocation.Location = New System.Drawing.Point(10, 32)
        Me.txtPDFLocation.Name = "txtPDFLocation"
        Me.txtPDFLocation.Size = New System.Drawing.Size(315, 20)
        Me.txtPDFLocation.TabIndex = 2
        Me.txtPDFLocation.TabStop = False
        '
        'txtPDFPageCount
        '
        Me.txtPDFPageCount.Enabled = False
        Me.txtPDFPageCount.Location = New System.Drawing.Point(197, 84)
        Me.txtPDFPageCount.Name = "txtPDFPageCount"
        Me.txtPDFPageCount.Size = New System.Drawing.Size(84, 20)
        Me.txtPDFPageCount.TabIndex = 7
        Me.txtPDFPageCount.TabStop = False
        '
        'lblSheetsPerSignature
        '
        Me.lblSheetsPerSignature.AutoSize = True
        Me.lblSheetsPerSignature.Location = New System.Drawing.Point(10, 68)
        Me.lblSheetsPerSignature.Name = "lblSheetsPerSignature"
        Me.lblSheetsPerSignature.Size = New System.Drawing.Size(178, 13)
        Me.lblSheetsPerSignature.TabIndex = 8
        Me.lblSheetsPerSignature.Text = "How many sheets in each signature:"
        '
        'lblPDFPageCount
        '
        Me.lblPDFPageCount.AutoSize = True
        Me.lblPDFPageCount.Location = New System.Drawing.Point(197, 68)
        Me.lblPDFPageCount.Name = "lblPDFPageCount"
        Me.lblPDFPageCount.Size = New System.Drawing.Size(145, 13)
        Me.lblPDFPageCount.TabIndex = 9
        Me.lblPDFPageCount.Text = "How many pages in the PDF:"
        '
        'LabelSignatures
        '
        Me.LabelSignatures.AutoSize = True
        Me.LabelSignatures.Location = New System.Drawing.Point(10, 196)
        Me.LabelSignatures.Name = "LabelSignatures"
        Me.LabelSignatures.Size = New System.Drawing.Size(112, 13)
        Me.LabelSignatures.TabIndex = 10
        Me.LabelSignatures.Text = "Number of Signatures:"
        '
        'LabelSheets
        '
        Me.LabelSheets.AutoSize = True
        Me.LabelSheets.Location = New System.Drawing.Point(10, 214)
        Me.LabelSheets.Name = "LabelSheets"
        Me.LabelSheets.Size = New System.Drawing.Size(135, 13)
        Me.LabelSheets.TabIndex = 11
        Me.LabelSheets.Text = "Number of sheets of paper:"
        '
        'lblSignatures
        '
        Me.lblSignatures.AutoSize = True
        Me.lblSignatures.Location = New System.Drawing.Point(163, 196)
        Me.lblSignatures.Name = "lblSignatures"
        Me.lblSignatures.Size = New System.Drawing.Size(10, 13)
        Me.lblSignatures.TabIndex = 12
        Me.lblSignatures.Text = "."
        '
        'lblSheets
        '
        Me.lblSheets.AutoSize = True
        Me.lblSheets.Location = New System.Drawing.Point(163, 214)
        Me.lblSheets.Name = "lblSheets"
        Me.lblSheets.Size = New System.Drawing.Size(10, 13)
        Me.lblSheets.TabIndex = 13
        Me.lblSheets.Text = "."
        '
        'chkDoublSided
        '
        Me.chkDoublSided.AutoSize = True
        Me.chkDoublSided.Checked = True
        Me.chkDoublSided.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDoublSided.Location = New System.Drawing.Point(10, 169)
        Me.chkDoublSided.Name = "chkDoublSided"
        Me.chkDoublSided.Size = New System.Drawing.Size(272, 17)
        Me.chkDoublSided.TabIndex = 6
        Me.chkDoublSided.Text = "Will be automatically printing on both sides of sheet?"
        Me.chkDoublSided.UseVisualStyleBackColor = True
        '
        'cboSheetsPerSignature
        '
        Me.cboSheetsPerSignature.Enabled = False
        Me.cboSheetsPerSignature.FormattingEnabled = True
        Me.cboSheetsPerSignature.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cboSheetsPerSignature.Location = New System.Drawing.Point(11, 83)
        Me.cboSheetsPerSignature.Name = "cboSheetsPerSignature"
        Me.cboSheetsPerSignature.Size = New System.Drawing.Size(104, 21)
        Me.cboSheetsPerSignature.TabIndex = 3
        '
        'lblTotalPages
        '
        Me.lblTotalPages.AutoSize = True
        Me.lblTotalPages.Location = New System.Drawing.Point(163, 233)
        Me.lblTotalPages.Name = "lblTotalPages"
        Me.lblTotalPages.Size = New System.Drawing.Size(10, 13)
        Me.lblTotalPages.TabIndex = 15
        Me.lblTotalPages.Text = "."
        '
        'LabelTotalPages
        '
        Me.LabelTotalPages.AutoSize = True
        Me.LabelTotalPages.Location = New System.Drawing.Point(10, 233)
        Me.LabelTotalPages.Name = "LabelTotalPages"
        Me.LabelTotalPages.Size = New System.Drawing.Size(116, 13)
        Me.LabelTotalPages.TabIndex = 14
        Me.LabelTotalPages.Text = "Total number of pages:"
        '
        'lblBlankPages
        '
        Me.lblBlankPages.AutoSize = True
        Me.lblBlankPages.Location = New System.Drawing.Point(296, 233)
        Me.lblBlankPages.Name = "lblBlankPages"
        Me.lblBlankPages.Size = New System.Drawing.Size(10, 13)
        Me.lblBlankPages.TabIndex = 17
        Me.lblBlankPages.Text = "."
        '
        'LabelBlankPages
        '
        Me.LabelBlankPages.AutoSize = True
        Me.LabelBlankPages.Location = New System.Drawing.Point(197, 233)
        Me.LabelBlankPages.Name = "LabelBlankPages"
        Me.LabelBlankPages.Size = New System.Drawing.Size(102, 13)
        Me.LabelBlankPages.TabIndex = 16
        Me.LabelBlankPages.Text = "Blank pages added:"
        '
        'chkMaxSignatures
        '
        Me.chkMaxSignatures.AutoSize = True
        Me.chkMaxSignatures.Enabled = False
        Me.chkMaxSignatures.Location = New System.Drawing.Point(207, 146)
        Me.chkMaxSignatures.Name = "chkMaxSignatures"
        Me.chkMaxSignatures.Size = New System.Drawing.Size(160, 17)
        Me.chkMaxSignatures.TabIndex = 18
        Me.chkMaxSignatures.Text = "Create maximum signatures?"
        Me.chkMaxSignatures.UseVisualStyleBackColor = True
        '
        'lblFrontPages
        '
        Me.lblFrontPages.AutoSize = True
        Me.lblFrontPages.Location = New System.Drawing.Point(164, 126)
        Me.lblFrontPages.Name = "lblFrontPages"
        Me.lblFrontPages.Size = New System.Drawing.Size(92, 13)
        Me.lblFrontPages.TabIndex = 20
        Me.lblFrontPages.Text = "How many pages:"
        Me.lblFrontPages.Visible = False
        '
        'cboFrontPageCount
        '
        Me.cboFrontPageCount.FormattingEnabled = True
        Me.cboFrontPageCount.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cboFrontPageCount.Location = New System.Drawing.Point(257, 123)
        Me.cboFrontPageCount.Name = "cboFrontPageCount"
        Me.cboFrontPageCount.Size = New System.Drawing.Size(104, 21)
        Me.cboFrontPageCount.TabIndex = 21
        Me.cboFrontPageCount.Text = "1"
        Me.cboFrontPageCount.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 304)
        Me.Controls.Add(Me.cboFrontPageCount)
        Me.Controls.Add(Me.lblFrontPages)
        Me.Controls.Add(Me.chkMaxSignatures)
        Me.Controls.Add(Me.lblBlankPages)
        Me.Controls.Add(Me.LabelBlankPages)
        Me.Controls.Add(Me.lblTotalPages)
        Me.Controls.Add(Me.LabelTotalPages)
        Me.Controls.Add(Me.cboSheetsPerSignature)
        Me.Controls.Add(Me.chkDoublSided)
        Me.Controls.Add(Me.lblSheets)
        Me.Controls.Add(Me.lblSignatures)
        Me.Controls.Add(Me.LabelSheets)
        Me.Controls.Add(Me.LabelSignatures)
        Me.Controls.Add(Me.lblPDFPageCount)
        Me.Controls.Add(Me.lblSheetsPerSignature)
        Me.Controls.Add(Me.txtPDFPageCount)
        Me.Controls.Add(Me.txtPDFLocation)
        Me.Controls.Add(Me.lblPDFLocation)
        Me.Controls.Add(Me.chkMinimizeSignatures)
        Me.Controls.Add(Me.chkAddFrontPages)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(378, 343)
        Me.MinimumSize = New System.Drawing.Size(378, 343)
        Me.Name = "MainForm"
        Me.Text = "PDF to Book Converter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOpenFile As Button
    Friend WithEvents btnConvert As Button
    Friend WithEvents chkAddFrontPages As CheckBox
    Friend WithEvents chkMinimizeSignatures As CheckBox
    Friend WithEvents lblPDFLocation As Label
    Friend WithEvents txtPDFLocation As TextBox
    Friend WithEvents txtPDFPageCount As TextBox
    Friend WithEvents lblSheetsPerSignature As Label
    Friend WithEvents lblPDFPageCount As Label
    Friend WithEvents LabelSignatures As Label
    Friend WithEvents LabelSheets As Label
    Friend WithEvents lblSignatures As Label
    Friend WithEvents lblSheets As Label
    Friend WithEvents chkDoublSided As CheckBox
    Friend WithEvents cboSheetsPerSignature As ComboBox
    Friend WithEvents lblTotalPages As Label
    Friend WithEvents LabelTotalPages As Label
    Friend WithEvents lblBlankPages As Label
    Friend WithEvents LabelBlankPages As Label
    Friend WithEvents chkMaxSignatures As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents lblFrontPages As Label
    Friend WithEvents cboFrontPageCount As ComboBox
End Class
