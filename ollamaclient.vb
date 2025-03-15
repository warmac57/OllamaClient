Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports System.Threading.Tasks

Public Class OllamaClient
    Private ReadOnly _baseUrl As String
    Private ReadOnly _httpClient As HttpClient

    ''' <summary>
    ''' Initializes a new instance of the OllamaClient class
    ''' </summary>
    ''' <param name="baseUrl">Base URL of the Ollama API (default: http://localhost:11434)</param>
    Public Sub New(Optional baseUrl As String = "http://localhost:11434")
        _baseUrl = baseUrl
        _httpClient = New HttpClient()
    End Sub

    ''' <summary>
    ''' Sends a question to Ollama and gets the response
    ''' </summary>
    ''' <param name="model">The model name to use (e.g., "llama2", "mistral")</param>
    ''' <param name="prompt">The question or prompt to send</param>
    ''' <param name="temperature">Controls randomness (0.0 to 1.0, default: 0.7)</param>
    ''' <returns>The model's response as a string</returns>
    Public Async Function AskQuestionAsync(model As String, prompt As String, Optional temperature As Double = 0.7) As Task(Of String)
        Try
            ' Create request URL for the Ollama API
            Dim requestUrl As String = $"{_baseUrl}/api/generate"

            ' Create request body
            Dim requestBody = New With {
                .model = model,
                .prompt = prompt,
                .temperature = temperature,
                .stream = False
            }

            ' Serialize to JSON
            Dim jsonContent = JsonConvert.SerializeObject(requestBody)
            Dim content = New StringContent(jsonContent, Encoding.UTF8, "application/json")

            ' Send request
            Dim response = Await _httpClient.PostAsync(requestUrl, content)
            response.EnsureSuccessStatusCode()

            ' Parse response
            Dim jsonResponse = Await response.Content.ReadAsStringAsync()
            Dim responseObj = JsonConvert.DeserializeObject(Of OllamaResponse)(jsonResponse)

            Return responseObj.Response
        Catch ex As Exception
            Return $"Error: {ex.Message}"
        End Try
    End Function

    ''' <summary>
    ''' Lists available models on the Ollama server
    ''' </summary>
    ''' <returns>A list of available model names</returns>
    Public Async Function ListModelsAsync() As Task(Of List(Of String))
        Try
            Dim requestUrl As String = $"{_baseUrl}/api/tags"
            Dim response = Await _httpClient.GetAsync(requestUrl)
            response.EnsureSuccessStatusCode()
            
            Dim jsonResponse = Await response.Content.ReadAsStringAsync()
            Dim modelsObject = JsonConvert.DeserializeObject(Of OllamaModelsResponse)(jsonResponse)
            
            Return modelsObject.Models.Select(Function(m) m.Name).ToList()
        Catch ex As Exception
            Console.WriteLine($"Error listing models: {ex.Message}")
            Return New List(Of String)()
        End Try
    End Function

    ''' <summary>
    ''' Disposes the HTTP client
    ''' </summary>
    Public Sub Dispose()
        _httpClient.Dispose()
    End Sub
End Class

''' <summary>
''' Response object from the Ollama API
''' </summary>
Public Class OllamaResponse
    <JsonProperty("response")>
    Public Property Response As String

    <JsonProperty("model")>
    Public Property Model As String
    
    <JsonProperty("created_at")>
    Public Property CreatedAt As String
    
    <JsonProperty("done")>
    Public Property Done As Boolean
    
    <JsonProperty("total_duration")>
    Public Property TotalDuration As Long
    
    <JsonProperty("load_duration")>
    Public Property LoadDuration As Long
    
    <JsonProperty("prompt_eval_count")>
    Public Property PromptEvalCount As Integer
    
    <JsonProperty("prompt_eval_duration")>
    Public Property PromptEvalDuration As Long
    
    <JsonProperty("eval_count")>
    Public Property EvalCount As Integer
    
    <JsonProperty("eval_duration")>
    Public Property EvalDuration As Long
End Class

''' <summary>
''' Response object for model listing
''' </summary>
Public Class OllamaModelsResponse
    <JsonProperty("models")>
    Public Property Models As List(Of OllamaModel)
End Class

''' <summary>
''' Model information
''' </summary>
Public Class OllamaModel
    <JsonProperty("name")>
    Public Property Name As String
    
    <JsonProperty("modified_at")>
    Public Property ModifiedAt As String
    
    <JsonProperty("size")>
    Public Property Size As Long
End Class
