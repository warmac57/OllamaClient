Public Class frmMain

    Private client As OllamaClient

    Private Async Sub RefreshModelsAsync()

        Try
            lblStatus.Text = "Loading models..."
            cboModels.Items.Clear()
            btnRefreshModels.Enabled = False
            btnSend.Enabled = False

            Dim models = Await client.ListModelsAsync()

            For Each model In models
                cboModels.Items.Add(model)
            Next

            If cboModels.Items.Count > 0 Then
                cboModels.SelectedIndex = 0
                btnSend.Enabled = True
                lblStatus.Text = $"{models.Count} models found."
            Else
                lblStatus.Text = "No models found. Make sure Ollama is running with at least one model."
            End If
        Catch ex As Exception
            lblStatus.Text = $"Error: {ex.Message}"
            MessageBox.Show($"Error loading models: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnRefreshModels.Enabled = True
        End Try
    End Sub

    Private Async Sub SendQuestion()
        If cboModels.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a model first.", "No model selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtQuestion.Text) Then
            MessageBox.Show("Please enter a question.", "No question", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim modelName As String = cboModels.SelectedItem.ToString()
            Dim temperature As Double = sliderTemperature.Value / 10.0

            lblStatus.Text = "Sending request..."
            btnSend.Enabled = False
            btnRefreshModels.Enabled = False
            Application.DoEvents()

            Dim response = Await client.AskQuestionAsync(modelName, txtQuestion.Text, temperature)

            txtResponse.Text = response
            lblStatus.Text = "Response received."
        Catch ex As Exception
            lblStatus.Text = $"Error: {ex.Message}"
            MessageBox.Show($"Error sending question: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnSend.Enabled = True
            btnRefreshModels.Enabled = True
        End Try
    End Sub

    Private Sub btnRefreshModels_Click(sender As Object, e As EventArgs) Handles btnRefreshModels.Click

        If MsgBox("This will refresh the list of models. Any unsaved response will be lost. Continue?", MsgBoxStyle.YesNo, "Refresh Models") = MsgBoxResult.No Then
            Return
        Else
            RefreshModelsAsync()
            txtQuestion.Clear()
            txtResponse.Clear()

        End If

    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

        SendQuestion()

        btnSave.Enabled = True

    End Sub

    Private Sub txtQuestion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuestion.KeyDown
        ' Send on Ctrl+Enter
        If e.Control AndAlso e.KeyCode = Keys.Enter Then
            SendQuestion()
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub sliderTemperature_ValueChanged(sender As Object, e As EventArgs) Handles sliderTemperature.ValueChanged
        lblTemperatureValue.Text = (sliderTemperature.Value / 10.0).ToString("0.0")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Initialize client
        client = New OllamaClient()

        ' Load models
        RefreshModelsAsync()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtResponse.Text) Then
            MessageBox.Show("There is no response to save.", "No Content", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' Prepare a default filename with timestamp
            Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
            SaveFileDialog1.FileName = $"Ollama_Response_{timestamp}.txt"

            ' Show save dialog
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                ' Get selected file path
                Dim filePath As String = SaveFileDialog1.FileName

                ' Get model and question for metadata
                Dim modelName As String = If(cboModels.SelectedItem IsNot Nothing, cboModels.SelectedItem.ToString(), "Unknown")
                Dim metadata As String = $"Model: {modelName}{Environment.NewLine}" &
                                        $"Temperature: {lblTemperatureValue.Text}{Environment.NewLine}" &
                                        $"Question: {txtQuestion.Text}{Environment.NewLine}" &
                                        $"Date: {DateTime.Now.ToString()}{Environment.NewLine}" &
                                        $"----------------------------------------{Environment.NewLine}{Environment.NewLine}"

                ' Write to file
                Using writer As New System.IO.StreamWriter(filePath)
                    writer.Write(metadata)
                    writer.Write(txtResponse.Text)
                End Using

                lblStatus.Text = $"Response saved to {System.IO.Path.GetFileName(filePath)}"
            End If
        Catch ex As Exception
            MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = "Error saving file."
        End Try
    End Sub

    Private Sub lblHelp_Click(sender As Object, e As EventArgs) Handles lblHelp.Click

        If Panel1.Height > 500 Then
            Panel1.Height = 51
        Else
            Panel1.Height = 541
        End If

    End Sub
End Class