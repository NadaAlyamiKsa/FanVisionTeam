using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadImageFromURL : MonoBehaviour
{
    public RawImage rawImage; // Assign this in the Inspector
    public string imageUrl = "https://pbs.twimg.com/profile_images/1286660994782179328/Ehh8f9ml_400x400.jpg";

    void Start()
    {
        StartCoroutine(LoadImage());
    }

    IEnumerator LoadImage()
    {
        using (UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityEngine.Networking.UnityWebRequest.Result.ConnectionError ||
                request.result == UnityEngine.Networking.UnityWebRequest.Result.ProtocolError)
            {
                rawImage.color = Color.red;
                Debug.LogError(request.error);
            }
            else
            {
                Texture2D texture = ((UnityEngine.Networking.DownloadHandlerTexture)request.downloadHandler).texture;
                rawImage.texture = texture;
            }
        }
    }
}
