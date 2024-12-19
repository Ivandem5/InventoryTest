using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class InventoryNetworkController : MonoBehaviour
{
    private const string URL = "https://wadahub.manerai.com/api/inventory/status";
    private const string AUTH_TOKEN = "kPERnYcWAY46xaSy8CEzanosAgsWM84Nx7SKM4QBSqPq6c7StWfGxzhxPfDh8MaP";

    public enum EventType 
    {
        addItem,
        removeItem
    }
        
    public void AddItemEvent(IInventoryItem item)
    {
        SendInventoryEvent(new InventoryEventData(item.Id, EventType.addItem.ToString()));
    }
    public void RemoveItemEvent(IInventoryItem item)
    {
        SendInventoryEvent(new InventoryEventData(item.Id, EventType.removeItem.ToString()));
    }
    
    private async void SendInventoryEvent(InventoryEventData data)
    {
        string jsonData = JsonUtility.ToJson(data);

        using (UnityWebRequest request = new UnityWebRequest(URL, "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {AUTH_TOKEN}");

            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            var operation = request.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log($"Response: {request.downloadHandler.text}");
            }
            else
            {
                Debug.LogError($"Error: {request.error}");
            }
        }
    }
}

[System.Serializable]
public class InventoryEventData
{
    public string itemId;   
    public string action;  
    
    public InventoryEventData(string itemId, string action)
    {
        this.itemId = itemId;
        this.action = action;
    }
}
