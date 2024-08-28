
open System
open System.Net.Http
open System.Text
open System.Threading.Tasks
open Newtonsoft.Json
open Newtonsoft.Json.Linq


type Message = {
    role: string
    content: string
}

type RequestBody = {
    model: string
    messages: Message[]
    max_tokens: int
    temperature: float
}

type Choice = {
    text: string
}

type OpenAIResponse = {
    choices: {| text: string |} []
}


let rec retryAsync (func: unit -> Async<'T>) (retries: int) : Async<'T> =
    async {
        try
            return! func()
        with
        | ex when retries > 0 ->
            let delay = int (Math.Pow(2.0, float (3 - retries)) * 1000.0)
            printfn "Request failed: %s. Retrying in %d seconds..." ex.Message (delay / 1000)
            do! Async.Sleep(delay)
            return! retryAsync func (retries - 1)
        | ex ->
            printfn "Request failed after multiple attempts: %s" ex.Message
            raise ex
    }



let getChatGPTResponse (prompt: string) : Async<string> =
     async {
        let apiValue = "apivalue" 
        let uri = "url"
        use client = new HttpClient()
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiValue}")

        let requestBody = 
            {|
                model = "gpt-3.5-turbo-instruct" 
                messages = [| { role = "user"; content = prompt } |]               
                temperature = 1
                prompt=""
                max_tokens=256
                top_p=1
                frequency_penalty=0
                presence_penalty=0                
            |}

        let body = JsonConvert.SerializeObject(requestBody)
        let content = new StringContent(body, Encoding.UTF8, "application/json")

        try
            let! response = client.PostAsync(uri, content) |> Async.AwaitTask
            let! responseBody = response.Content.ReadAsStringAsync() |> Async.AwaitTask

            if response.IsSuccessStatusCode then
                let responseObject = JsonConvert.DeserializeObject<OpenAIResponse>(responseBody)
                return responseObject.choices.[0].text.Trim()
            else
                return $"API Request failed with status code: {response.StatusCode}"
        with
        | ex -> return $"Exception occurred: {ex.Message}"
    }
    
  

[<EntryPoint>]
let main argv =
    printfn "Welcome to the F# Chatbot powered by ChatGPT! Type 'bye' or 'goodbye' to exit."
    
    let rec chatLoop () =
        printf "You: "
        let input = Console.ReadLine()
        if input.ToLower() = "bye" || input.ToLower() = "goodbye" then
            printfn "Chatbot: Goodbye! Have a great day!"
        else
            async {
                let! gptResponse = getChatGPTResponse input
                printfn "ChatGPT: %s" gptResponse
            } |> Async.RunSynchronously
            chatLoop ()
    
    chatLoop ()
    0
