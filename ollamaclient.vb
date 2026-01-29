Imports System.Net.Http
Imports System.Runtime.Remoting.Contexts
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

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


' END OF FIRST CLASS FILE
' 


'## Key Changes for VB.NET Implementation:

'### 1. **Conversation State Management Class**

'```vb.net
'Public Class OllamaClient
'    Private conversationHistory As New List(Of
'ConversationItem)
'    Private context As New List(Of Message)

'    Public Class ConversationItem
'        Public Property Role As String
'        Public Property Content As String
'        Public Property Timestamp As DateTime
'    End Class

'    Public Class Message
'        Public Property Role As String
'        Public Property Content As String
'    End Class

'    Public Async Function AskQuestionAsync(question As
'String) As Task(Of String)
'        ' Add current question to history
'        conversationHistory.Add(New ConversationItem With
'{
'            .Role = "user",
'            .Content = question,
'            .Timestamp = DateTime.Now
'        })

'        ' Prepare context for next request
'        Dim context As List(Of Message) = BuildContext()

'        ' Make API call with context
'        Dim response As String = Await
'CallOllamaAsync(question, context)

'        ' Add response to history
'        conversationHistory.Add(New ConversationItem With
'{
'            .Role = "assistant",
'            .Content = response,
'            .Timestamp = DateTime.Now
'        })

'        Return response
'    End Function

'    Private Function BuildContext() As List(Of Message)
'        ' Limit context to recent exchanges (last 5
'exchanges)
'        Dim recentHistory =
'conversationHistory.Skip(Math.Max(0,
'conversationHistory.Count - 5)).ToList()
'        Dim contextList As New List(Of Message)

'        For Each item In recentHistory
'            contextList.Add(New Message With {
'                .Role = item.Role,
'                .Content = item.Content
'            })
'        Next

'        Return contextList
'    End Function

'    Private Async Function CallOllamaAsync(question As
'String, context As List(Of Message)) As Task(Of String)
'        Dim client As New HttpClient()
'        Dim url As String =
'"http://localhost:11434/api/generate"

'        Dim requestBody As New Dictionary(Of String,
'Object) With {
'            {"model", "llama3"},
'            {"prompt", question},
'            {"context", context},
'            {"stream", False}
'        }

'        Dim jsonBody As String =
'JsonConvert.SerializeObject(requestBody)
'        Dim content As New StringContent(jsonBody,
'Encoding.UTF8, "application/json")

'        Dim response As HttpResponseMessage = Await
'client.PostAsync(url, content)
'        Dim responseString As String = Await
'response.Content.ReadAsStringAsync()

'        Dim responseObject As JObject =
'JObject.Parse(responseString)
'        Return responseObject("response").ToString()
'    End Function

'    Public Sub ClearConversation()
'        conversationHistory.Clear()
'    End Sub

'    Public Function GetConversation() As List(Of
'ConversationItem)
'        Return conversationHistory.ToList()
'    End Function
'End Class
'```

'### 2. **Enhanced Client with Conversation Features**

'```vb.net
'Public Class EnhancedOllamaClient
'    Private model As String
'    Private conversationHistory As New List(Of
'ConversationItem)
'    Private contextWindow As Integer = 10

'    Public Class ConversationItem
'        Public Property Role As String
'        Public Property Content As String
'        Public Property Timestamp As DateTime
'    End Class

'    Public Class Message
'        Public Property Role As String
'        Public Property Content As String
'    End Class

'    Public Sub New(modelName As String)
'        model = modelName
'        conversationHistory = New List(Of
'ConversationItem)
'    End Sub

'    Public Async Function AskAsync(question As String) As
'Task(Of String)
'        ' Add question to conversation
'        conversationHistory.Add(New ConversationItem With
'{
'            .Role = "user",
'            .Content = question,
'            .Timestamp = DateTime.Now
'        })

'        ' Build context from conversation history
'        Dim context As List(Of Message) =
'BuildConversationContext()

'        Try
'            Dim response As String = Await
'SendToOllamaAsync(question, context)

'            ' Add response to conversation
'            conversationHistory.Add(New ConversationItem
'With {
'                .Role = "assistant",
'                .Content = response,
'                .Timestamp = DateTime.Now
'            })

'            Return response
'        Catch ex As Exception
'            Console.WriteLine($"Error: {ex.Message}")
'            Throw
'        End Try
'    End Function

'    Private Function BuildConversationContext() As
'List(Of Message)
'        ' Take last N exchanges (user + assistant)
'        Dim recentCount As Integer =
'Math.Min(contextWindow * 2, conversationHistory.Count)
'        Dim recent =
'conversationHistory.Skip(conversationHistory.Count -
'recentCount).ToList()
'        Dim contextList As New List(Of Message)

'        For Each item In recent
'            contextList.Add(New Message With {
'                .Role = item.Role,
'                .Content = item.Content
'            })
'        Next

'        Return contextList
'    End Function

'    Private Async Function SendToOllamaAsync(question As
'String, context As List(Of Message)) As Task(Of String)
'        Dim client As New HttpClient()
'        Dim url As String =
'"http://localhost:11434/api/generate"

'        Dim requestBody As New Dictionary(Of String,
'Object) With {
'            {"model", model},
'            {"prompt", question},
'            {"context", context},
'            {"stream", False}
'        }

'        Dim jsonBody As String =
'JsonConvert.SerializeObject(requestBody)
'        Dim content As New StringContent(jsonBody,
'Encoding.UTF8, "application/json")

'        Dim response As HttpResponseMessage = Await
'client.PostAsync(url, content)
'        Dim responseString As String = Await
'response.Content.ReadAsStringAsync()

'        Dim responseObject As JObject =
'JObject.Parse(responseString)
'        Return responseObject("response").ToString()
'    End Function

'    Public Sub ClearConversation()
'        conversationHistory.Clear()
'    End Sub

'    Public Function GetConversation() As List(Of
'ConversationItem)
'        Return conversationHistory.ToList()
'    End Function

'    Public Property MaxContextLength As Integer
'        Get
'            Return contextWindow
'        End Get
'        Set(value As Integer)
'            contextWindow = value
'        End Set
'    End Property
'End Class
'```

'### 3. **Usage Example**

'```vb.net
'' Initialize client
'Dim client As New EnhancedOllamaClient("llama3")

'' First question
'Dim response1 As String = Await client.AskAsync("What is
'machine learning?")
'Console.WriteLine(response1)

'' Second question - will maintain context
'Dim response2 As String = Await client.AskAsync("Can you
'explain it more simply?")
'Console.WriteLine(response2)

'' Third question
'Dim response3 As String = Await client.AskAsync("What are
'some applications of it?")
'Console.WriteLine(response3)

'' Clear conversation if needed
'' client.ClearConversation()
'```

'### 4. **Additional Helper Methods**

'```vb.net
'Public Class EnhancedOllamaClient
'    ' ... previous code ...

'    ' Get conversation history as formatted string
'    Public Function GetFormattedConversation() As String
'        Dim sb As New StringBuilder()
'        For Each item In conversationHistory
'            sb.AppendLine($"{item.Role}: {item.Content}")
'        Next
'        Return sb.ToString()
'    End Function

'    ' Save conversation to file (optional)
'    Public Async Sub SaveConversationToFile(filePath As
'String)
'        Try
'            Dim json As String =
'JsonConvert.SerializeObject(conversationHistory)
'            Await File.WriteAllTextAsync(filePath, json)
'        Catch ex As Exception
'            Console.WriteLine($"Failed to save
'conversation: {ex.Message}")
'        End Try
'    End Sub

'    ' Load conversation from file (optional)
'    Public Async Sub LoadConversationFromFile(filePath As
'String)
'        Try
'            If File.Exists(filePath) Then
'                Dim json As String = Await
'File.ReadAllTextAsync(filePath)
'                conversationHistory =
'JsonConvert.DeserializeObject(Of List(Of
'ConversationItem))(json)
'            End If
'        Catch ex As Exception
'            Console.WriteLine($"Failed to load
'conversation: {ex.Message}")
'        End Try
'    End Sub

'    ' Get conversation statistics
'    Public Function GetConversationStats() As String
'        Dim userCount As Integer =
'conversationHistory.Count(Function(x) x.Role = "user")
'        Dim assistantCount As Integer =
'conversationHistory.Count(Function(x) x.Role =
'"assistant")
'        Return $"Total exchanges:
'{conversationHistory.Count}, User: {userCount},
'Assistant: {assistantCount}"
'    End Function
'End Class
'```

'### 5. **Error Handling with Context Management**

'```vb.net
'Public Async Function AskWithRetryAsync(question As
'String) As Task(Of String)
'    Try
'        Return Await AskAsync(question)
'    Catch ex As Exception
'        If ex.Message.Contains("context too long") Then
'            ' Trim conversation history
'            TrimContext()
'            ' Retry the question
'            Return Await AskAsync(question)
'        End If
'        Throw
'    End Try
'End Function

'Private Sub TrimContext()
'    If conversationHistory.Count > 20 Then ' Keep last 20
'items
'        conversationHistory =
'conversationHistory.Skip(conversationHistory.Count -
'20).ToList()
'    End If
'End Sub
'```

'## Key Points for VB.NET Implementation:

'1. **Use `Async Function`** for asynchronous operations
'2. **HttpClient** for making API calls to Ollama
'3. **JsonConvert** from Newtonsoft.Json for JSON
'serialization
'4. **List(Of T)** for maintaining conversation history
'5. **Context parameter** in Ollama API calls to maintain
'conversation
'6. **Error handling** with try-catch blocks
'7. **Clear conversation** method to reset context

'## Required NuGet Packages:
'- Newtonsoft.Json (for JSON serialization)
'- System.Net.Http (for HttpClient)

'The implementation maintains conversation context by:
'- Storing all user and assistant messages
'- Building context from recent exchanges
'- Passing context in Ollama API calls
'- Limiting conversation length to prevent overflow
'- Providing methods to clear or retrieve conversation
'history

