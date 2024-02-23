Imports PdfSharp.Pdf
Imports PdfSharp.Drawing
Imports System.IO
Imports PdfSharp
Imports PdfSharp.Pdf.IO

Public Class MainForm

    Public iSheetsPerSignature, iTotalPages, iTotalSheets, iTotalSignatures, iFrontPages As Integer
    Public fMinimizeSignatures, fAddFrontPages, fDoubleSided As Boolean
    Public dictSignatureMaxPages As New Dictionary(Of Integer, Integer)
    Public sTempFolder, sFinalBookLocation As String
    Public dPageWidth, dPageHeight As Double
    Public sDecimalCount As String

    Private Sub StartConvert()
        Try
            If Directory.Exists(sTempFolder) Then
                Directory.Delete(sTempFolder, True)
            End If

            sDecimalCount = "D" & (Math.Truncate(Math.Log10(iTotalSignatures) + 1) + 1)

            CreateTempSignatures()
            fAddFrontPages = chkAddFrontPages.Checked
            BuildSignatures()
            If fDoubleSided Then
                MergeSignatures()
                DeleteTempSignatures(True)

                MessageBox.Show("Book Creation Complete!" & vbCrLf & "You can find the created book here: " & sFinalBookLocation & vbCrLf & vbCrLf & "Please make sure your printer is set to flip each page over the short end before starting the print.")
            Else
                SplitSignatures()
                DeleteTempSignatures(False)
                MessageBox.Show("Book creation complete!" & vbCrLf & "You can find the individual signatures here: " & sTempFolder & vbCrLf & vbCrLf & "Please remember to print each signature individually, flipping the entire stack over the short end before printing the next part of the signature.")
            End If


            For Each form As Control In My.Application.OpenForms
                If (TypeOf form Is Button AndAlso form.Name IsNot "btnConvert") OrElse (TypeOf form Is CheckBox AndAlso form.Name IsNot "chkMaxSignatures") Then
                    form.Enabled = True
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & ex.StackTrace, "Something went wrong")
        End Try
    End Sub

    Private Sub CreateTempSignatures()
        Try
            Dim iSignatureCount As Integer
            Dim iDocPageCount As Integer = 0
            Dim iPagesPerSignature As Integer = iSheetsPerSignature * 4
            Dim outputDocument As PdfDocument
            Dim page As PdfPage
            Dim Form As XPdfForm
            Dim extWidth, extHeight As Double

            Form = XPdfForm.FromFile(txtPDFLocation.Text)
            extWidth = Form.PixelWidth
            extHeight = Form.PixelHeight

            ' Open the document to import pages from it.
            Dim inputDocument As PdfDocument = PdfReader.Open(txtPDFLocation.Text, PdfDocumentOpenMode.Import)
            Dim iPageMax As Integer = inputDocument.PageCount - 1

            If Not Directory.Exists(sTempFolder) Then
                Directory.CreateDirectory(sTempFolder)
            End If

            For iSignatureCount = 1 To iTotalSignatures
                outputDocument = New PdfDocument


                For iPageCount As Integer = 1 To iPagesPerSignature
                    If iSignatureCount = 1 AndAlso fAddFrontPages Then
                        For i As Integer = 1 To iFrontPages
                            'outputDocument.AddPage()

                            page = outputDocument.AddPage()
                            page.Orientation = PageOrientation.Portrait
                            page.Width = extWidth
                            page.Height = extHeight

                            'outputDocument.AddPage(page)

                            iPageCount += 1
                        Next
                        'outputDocument.AddPage()

                        fAddFrontPages = False
                    End If

                    If iDocPageCount <= iPageMax Then
                        page = inputDocument.Pages(iDocPageCount)
                        outputDocument.AddPage(page)
                        iDocPageCount += 1
                    Else
                        'outputDocument.AddPage()

                        page = outputDocument.AddPage()
                        page.Orientation = PageOrientation.Portrait
                        page.Width = extWidth
                        page.Height = extHeight

                        'outputDocument.AddPage(page)
                    End If

                Next

                outputDocument.Save(Path.Combine(sTempFolder, "Sig-" & iSignatureCount.ToString(sDecimalCount) & ".pdf"))
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub BuildSignatures()
        Try
            Dim iSignatureCount As Integer = 1
            Dim sheets As Integer = iSheetsPerSignature
            Dim outputDocument As PdfDocument
            Dim filename As String
            Dim gfx As XGraphics
            Dim Form As XPdfForm
            Dim extWidth, extHeight As Double
            Dim inputPages, allpages, vacats As Integer

            For Each sFile As String In Directory.GetFiles(sTempFolder)
                outputDocument = New PdfDocument
                outputDocument.PageLayout = PdfPageLayout.SinglePage

                Form = XPdfForm.FromFile(sFile)
                ' Determine width And height
                extWidth = Form.PixelWidth
                extHeight = Form.PixelHeight

                inputPages = Form.PageCount
                allpages = 4 * iSheetsPerSignature
                vacats = allpages - inputPages

                For idx As Integer = 1 To sheets

                    ' Front page of a sheet
                    ' Add a New page to the output document
                    Dim page As PdfPage = outputDocument.AddPage()
                    page.Orientation = PageOrientation.Landscape
                    page.Width = 2 * extWidth
                    page.Height = extHeight
                    Dim Width As Double = page.Width
                    Dim Height As Double = page.Height

                    gfx = XGraphics.FromPdfPage(page)

                    ' Skip if left side has to remain blank
                    Dim box As XRect

                    If (vacats > 0) Then
                        vacats -= 1
                    Else
                        ' Set page number (which Is one-based) for left side
                        Form.PageNumber = allpages + 2 * (1 - idx)
                        box = New XRect(0, 0, Width / 2, Height)
                        ' Draw the page identified by the page number Like an image
                        gfx.DrawImage(Form, box)
                    End If

                    ' Set page number (which Is one-based) for right side
                    Form.PageNumber = 2 * idx - 1
                    box = New XRect(Width / 2, 0, Width / 2, Height)
                    ' Draw the page identified by the page number Like an image
                    gfx.DrawImage(Form, box)

                    ' Back page of a sheet
                    page = outputDocument.AddPage()
                    page.Orientation = PageOrientation.Landscape
                    page.Width = 2 * extWidth

                    page.Height = extHeight

                    gfx = XGraphics.FromPdfPage(page)

                    ' Set page number (which Is one-based) for left side
                    Form.PageNumber = 2 * idx
                    box = New XRect(0, 0, Width / 2, Height)
                    ' Draw the page identified by the page number Like an image
                    gfx.DrawImage(Form, box)

                    ' Skip if right side has to remain blank
                    If (vacats > 0) Then
                        vacats -= 1
                    Else
                        ' Set page number (which Is one-based) for right side
                        Form.PageNumber = allpages + 1 - 2 * idx
                        box = New XRect(Width / 2, 0, Width / 2, Height)
                        ' Draw the page identified by the page number Like an image
                        gfx.DrawImage(Form, box)
                    End If
                Next

                ' Save the document...
                filename = "Signature" & iSignatureCount.ToString(sDecimalCount) & ".pdf"
                outputDocument.Save(Path.Combine(sTempFolder, filename))
                iSignatureCount += 1
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub SplitSignatures()
        Try
            Dim iSignatureCount As Integer = 1
            Dim iPagesPerSignature As Integer = iSheetsPerSignature * 4
            Dim outputDocumentP1, outputDocumentP2 As PdfDocument
            Dim page As PdfPage

            ' Open the document to import pages from it.
            Dim inputDocument As PdfDocument


            'Dim filename As String = "Portable Document Format.pdf"
            'File.Copy(Path.Combine("../../../../../PDFs/", filename),
            'Path.Combine(Directory.GetCurrentDirectory(), filename), True)

            ' Open the file
            For Each filename In Directory.GetFiles(sTempFolder)
                If Path.GetFileName(filename).Contains("Signature") Then
                    inputDocument = PdfReader.Open(filename, PdfDocumentOpenMode.Import)
                    outputDocumentP1 = New PdfDocument()
                    outputDocumentP2 = New PdfDocument()

                    Dim Name As String = Path.GetFileNameWithoutExtension(filename)
                    For idx As Integer = 0 To inputDocument.PageCount - 1
                        If idx Mod 2 = 0 Then
                            ' Create New document
                            outputDocumentP1.Version = inputDocument.Version
                            outputDocumentP1.Info.Title = String.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title)
                            outputDocumentP1.Info.Creator = inputDocument.Info.Creator

                            ' Add the page And save it
                            outputDocumentP1.AddPage(inputDocument.Pages(idx))
                        Else
                            ' Create New document
                            outputDocumentP2.Version = inputDocument.Version
                            outputDocumentP2.Info.Title = String.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title)
                            outputDocumentP2.Info.Creator = inputDocument.Info.Creator

                            ' Add the page And save it
                            outputDocumentP2.AddPage(inputDocument.Pages(idx))
                        End If

                    Next
                    outputDocumentP1.Save(Path.Combine(sTempFolder, "Signature" & iSignatureCount.ToString(sDecimalCount) & " Part1.pdf"))
                    outputDocumentP2.Save(Path.Combine(sTempFolder, "Signature" & iSignatureCount.ToString(sDecimalCount) & " Part2.pdf"))
                    iSignatureCount += 1
                End If
            Next



            'For Each file In Directory.GetFiles(sTempFolder)
            '    If Path.GetFileName(file).Contains("Signature") Then
            '        inputDocument = PdfReader.Open(txtPDFLocation.Text, PdfDocumentOpenMode.Import)
            '        outputDocumentP1 = New PdfDocument
            '        outputDocumentP2 = New PdfDocument

            '        For iPageCount As Integer = 0 To inputDocument.PageCount - 1
            '            page = inputDocument.Pages(iPageCount)
            '            page.Orientation = PageOrientation.Landscape
            '            If iPageCount Mod 2 = 0 Then
            '                outputDocumentP1.AddPage(page)
            '            Else
            '                outputDocumentP2.AddPage(page)
            '            End If
            '        Next

            '        outputDocumentP1.Save(Path.Combine(sTempFolder, "Signature" & iSignatureCount & " Part1.pdf"))
            '        outputDocumentP2.Save(Path.Combine(sTempFolder, "Signature" & iSignatureCount & " Part2.pdf"))
            '        iSignatureCount += 1
            '    End If
            'Next
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub MergeSignatures()
        Try
            ' Open the output document
            Dim outputDocument As PdfDocument = New PdfDocument()

            ' Iterate files
            For Each file In Directory.GetFiles(sTempFolder)
                ' Open the document to import pages from it.
                If Path.GetFileName(file).Contains("Signature") Then
                    Dim inputDocument As PdfDocument = PdfReader.Open(file, PdfDocumentOpenMode.Import)

                    ' Iterate pages
                    For idx As Integer = 0 To inputDocument.PageCount - 1
                        ' Get the page from the external document...
                        Dim page As PdfPage = inputDocument.Pages(idx)
                        ' ...And add it to the output document.
                        outputDocument.AddPage(page)
                    Next
                End If
            Next
            ' Save the document...
            outputDocument.Save(sFinalBookLocation)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub DeleteTempSignatures(fDeleteFolder As Boolean)
        Try
            If fDeleteFolder Then
                Directory.Delete(sTempFolder, True)
            Else
                For Each file In Directory.GetFiles(sTempFolder)
                    If Not Path.GetFileName(file).Contains("Part") Then
                        My.Computer.FileSystem.DeleteFile(file)
                    End If
                Next
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub HowManySignatures()
        If Not String.IsNullOrEmpty(txtPDFPageCount.Text) Then
            iTotalPages = txtPDFPageCount.Text

            If fAddFrontPages Then
                iTotalPages += iFrontPages
            End If

            If fMinimizeSignatures Then
                'First find if there are any signature pairs that will can be created without adding blank pages
                If chkMaxSignatures.Checked Then
                    While Not (iTotalPages Mod 4 = 0)
                        iTotalPages += 1
                    End While
                    For i As Integer = 2 To 10
                        If iTotalPages Mod dictSignatureMaxPages(i) = 0 AndAlso iTotalPages Mod 4 = 0 Then
                            iSheetsPerSignature = i
                            cboSheetsPerSignature.SelectedIndex = i - 1
                            Exit For
                        End If

                    Next
                Else
                    While Not (iTotalPages Mod 4 = 0)
                        iTotalPages += 1
                    End While
                    For i As Integer = 10 To 1 Step -1
                        If iTotalPages Mod dictSignatureMaxPages(i) = 0 AndAlso iTotalPages Mod 4 = 0 Then
                            iSheetsPerSignature = i
                            cboSheetsPerSignature.SelectedIndex = i - 1
                            Exit For
                        End If

                    Next
                End If

            End If
            While Not (iTotalPages Mod iSheetsPerSignature = 0 AndAlso iTotalPages Mod 4 = 0)
                iTotalPages += 1
            End While

            iTotalSheets = iTotalPages / 4
            If iTotalSheets < iSheetsPerSignature Then
                iTotalSheets = iSheetsPerSignature
            End If

            iTotalSignatures = Math.Ceiling(iTotalSheets / iSheetsPerSignature)
            iTotalSheets = iSheetsPerSignature * iTotalSignatures
            iTotalPages = iTotalSheets * 4

            lblSheets.Text = iTotalSheets
            lblSignatures.Text = iTotalSignatures
            lblTotalPages.Text = iTotalPages
            lblBlankPages.Text = iTotalPages - txtPDFPageCount.Text
        End If
    End Sub

    Private Sub LoadPDF(sFileLocation As String)
        Try
            Dim Form As XPdfForm = XPdfForm.FromFile(sFileLocation)
            Dim iPageCount As Integer = Form.PageCount
            sTempFolder = Path.Combine(Path.GetDirectoryName(sFileLocation), Path.GetFileName(sFileLocation).Replace(".pdf", " Signatures"))
            txtPDFPageCount.Text = iPageCount
            sFinalBookLocation = Path.Combine(Path.GetDirectoryName(sFileLocation), Path.GetFileName(sFileLocation).Replace(".pdf", " Book.pdf"))
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & ex.StackTrace, "Something went wrong loading the PDF file")
        End Try
    End Sub

    Private Sub chkDoublSided_CheckedChanged(sender As Object, e As EventArgs) Handles chkDoublSided.CheckedChanged
        fDoubleSided = chkDoublSided.Checked
    End Sub

#Region "Handlers"
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboSheetsPerSignature.SelectedIndex = 0
        For i As Integer = 1 To 10
            dictSignatureMaxPages(i) = i * 4
        Next
        ToolTip1.SetToolTip(txtPDFLocation, "Location of PDF file to be converted to duplex printing style.")
        ToolTip1.SetToolTip(btnOpenFile, "Load PDF file.")
        ToolTip1.SetToolTip(cboSheetsPerSignature, "Select how many sheets of paper will create one signature. One sheet equals four pages.")
        ToolTip1.SetToolTip(txtPDFPageCount, "Will automatically fill with the original page count of the PDF file loaded.")
        ToolTip1.SetToolTip(chkAddFrontPages, "Check if you would like to add a buffer page to the first signature.")
        ToolTip1.SetToolTip(chkMinimizeSignatures, "Check if you would like the program to find the most efficient sheet-to-signature ratio to create less blank pages. Uses less sheets and keeps the book thin.")
        ToolTip1.SetToolTip(chkMaxSignatures, "Changes the automatic creation to find the most efficient sheet-to-signature ratio, but will maximize the signatures created. Uses more sheets and makes the book thicker.")
        ToolTip1.SetToolTip(chkDoublSided, "Uncheck if your printer will NOT automatically flip the pages over the short end." & vbCrLf & "This will change the order of pages so you can take the signature created and manually flip the stack over the short end.")
        ToolTip1.SetToolTip(LabelSignatures, "How many signatures will be created.")
        ToolTip1.SetToolTip(LabelSheets, "How many sheets will be used when printing.")
        ToolTip1.SetToolTip(LabelTotalPages, "How many pages the printed book will have.")
        ToolTip1.SetToolTip(LabelBlankPages, "How many blank pages were added to the printed book.")
    End Sub


    Private Sub cboFrontPageCount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFrontPageCount.SelectedIndexChanged
        iFrontPages = cboFrontPageCount.SelectedItem
        HowManySignatures()
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click

        StartConvert()
    End Sub

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        Dim dlg As OpenFileDialog = New OpenFileDialog
        With dlg
            .Filter = "PDF Files(*.pdf)|*.pdf|All Files(*.*)|*.*"
            .Title = lblPDFLocation.Text
        End With
        Dim res As DialogResult = dlg.ShowDialog
        If res = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(dlg.FileName) Then
                txtPDFLocation.Text = dlg.FileName
                LoadPDF(txtPDFLocation.Text)
                HowManySignatures()
                btnConvert.Enabled = True
                cboSheetsPerSignature.Enabled = True
            End If
        End If
    End Sub

    Private Sub chkMaxSignatures_CheckedChanged(sender As Object, e As EventArgs) Handles chkMaxSignatures.CheckedChanged
        HowManySignatures()
    End Sub

    Private Sub cboSheetsPerSignature_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSheetsPerSignature.SelectedIndexChanged, cboSheetsPerSignature.LostFocus
        iSheetsPerSignature = cboSheetsPerSignature.Text
        HowManySignatures()
    End Sub

    Private Sub chkAddFrontPages_CheckedChanged(sender As Object, e As EventArgs) Handles chkAddFrontPages.CheckedChanged
        fAddFrontPages = chkAddFrontPages.Checked

        If fAddFrontPages Then
            lblFrontPages.Visible = True
            cboFrontPageCount.Visible = True
        Else
            lblFrontPages.Visible = False
            cboFrontPageCount.Visible = False
            iFrontPages = 0
        End If
        HowManySignatures()
    End Sub

    Private Sub chkMinimizeSignatures_CheckedChanged(sender As Object, e As EventArgs) Handles chkMinimizeSignatures.CheckedChanged
        If chkMinimizeSignatures.Checked Then
            fMinimizeSignatures = True
            cboSheetsPerSignature.Enabled = False
            chkMaxSignatures.Enabled = True
        Else
            fMinimizeSignatures = False
            cboSheetsPerSignature.Enabled = True
            chkMaxSignatures.Enabled = False
        End If
        HowManySignatures()
    End Sub
#End Region

End Class
