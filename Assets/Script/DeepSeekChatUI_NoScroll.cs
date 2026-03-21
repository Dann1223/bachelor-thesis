using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Collections;

// // DeepSeek request/response data structures (unchanged)
[System.Serializable]
public class DeepSeekRequest
{
    public string model = "deepseek-chat";
    public List<DeepSeekMessage> messages;
    public float temperature = 0.7f;
}

[System.Serializable]
public class DeepSeekMessage
{
    public string role;
    public string content;
}

[System.Serializable]
public class DeepSeekResponse
{
    public string id;
    public string object_name;
    public long created;
    public List<DeepSeekChoice> choices;
    public DeepSeekUsage usage;
}

[System.Serializable]
public class DeepSeekChoice
{
    public int index;
    public DeepSeekMessage message;
    public string finish_reason;
}

[System.Serializable]
public class DeepSeekUsage
{
    public int prompt_tokens;
    public int completion_tokens;
    public int total_tokens;
}


public class DeepSeekChatUI_NoScroll : MonoBehaviour
{
    [Header("DeepSeek Settings")]
    [SerializeField] private string apiKey = "your_api_key";
    [SerializeField] private string apiUrl = "https://api.deepseek.com/v1/chat/completions";

    [Header("UI组件")]
    [SerializeField] private TMP_Text chatDisplay; // // Single text field, no scroll view required
    [SerializeField] private TMP_InputField messageInput;
    [SerializeField] private Button sendBtn;
    [SerializeField] private Button clearBtn;


    private List<DeepSeekMessage> chatHistory = new List<DeepSeekMessage>();


    private void Start()
    {
        sendBtn.onClick.AddListener(SendMessageToDeepSeek);
        clearBtn.onClick.AddListener(ClearChat);
        messageInput.onSubmit.AddListener((text) => SendMessageToDeepSeek());

        // Initialize chat display
        chatDisplay.text = "欢迎使用DeepSeek对话！\n\n";
    }


    public void SendMessageToDeepSeek()
    {
        string userInput = messageInput.text.Trim();
        if (string.IsNullOrEmpty(userInput)) return;

        // Append directly to the text field
        chatDisplay.text += $"<color=#FF69B4>你：</color>{userInput}\n\n";
        chatHistory.Add(new DeepSeekMessage { role = "user", content = userInput });
        messageInput.text = "";

        StartCoroutine(RequestDeepSeekReply());
    }


    private void ClearChat()
    {
        chatDisplay.text = "欢迎使用DeepSeek对话！\n\n";
        chatHistory.Clear();
    }


    private IEnumerator RequestDeepSeekReply()
    {
        // Display loading status
        chatDisplay.text += "<color=#00BFFF>AI：</color>思考中...\n\n";

        // Build request body
        DeepSeekRequest requestData = new DeepSeekRequest
        {
            messages = chatHistory
        };
        string jsonBody = JsonUtility.ToJson(requestData);
        jsonBody = jsonBody.Replace("\"object_name\"", "\"object\"");

        // Create request
        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Authorization", $"Bearer {apiKey}");
            request.SetRequestHeader("Content-Type", "application/json");

            // Send request
            yield return request.SendWebRequest();

            //  Remove loading status (replace the last line)
            string currentText = chatDisplay.text;
            int lastLineIndex = currentText.LastIndexOf("\n\n");
            if (lastLineIndex > 0)
            {
                chatDisplay.text = currentText.Substring(0, lastLineIndex) + "\n\n";
            }

            // Handle response
            if (request.result == UnityWebRequest.Result.Success)
            {
                string responseJson = request.downloadHandler.text.Replace("\"object\"", "\"object_name\"");
                DeepSeekResponse response = JsonUtility.FromJson<DeepSeekResponse>(responseJson);

                if (response.choices != null && response.choices.Count > 0)
                {
                    string aiReply = response.choices[0].message.content;
                    chatDisplay.text += $"<color=#00BFFF>AI：</color>{aiReply}\n\n";
                    chatHistory.Add(new DeepSeekMessage { role = "assistant", content = aiReply });
                }
                else
                {
                    chatDisplay.text += "<color=#00BFFF>AI：</color>未获取到回复\n\n";
                }
            }
            else
            {
                chatDisplay.text += $"<color=#00BFFF>AI：</color>请求失败：{request.error}\n\n";
                Debug.LogError($"DeepSeek错误：{request.downloadHandler.text}");
            }
        }
    }
}