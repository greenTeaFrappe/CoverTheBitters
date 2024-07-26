using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class albumSelect : MonoBehaviour
{
    public Button EAChangeBtn;
    public Button SAChangeBtn;
    public GameObject EAScreen;
    public GameObject SAScreen;

    public RawImage[] stImageSlots; // UI images to display the collected images
    public RawImage[] edImageSlots; // UI images to display the collected images
    public Texture2D defaultImage; // Default image to display if no image is collected

    private List<Texture2D> collectedImages = new List<Texture2D>(); // List to store collected images
    private string eventKey = "EAIMG";

    public Button[] stBtns;
    public Button[] edBtns;
    public Button popUpBackBtn;
    public GameObject popUpImageObject;
    public Texture popUpTexture;

    void Start()
    {
        if (popUpImageObject == null)
        {
            Debug.LogError("popUpImageObject is not assigned in the inspector.");
            return; // Exit the Start method to prevent further errors
        }

        EAScreen.SetActive(true);
        SAScreen.SetActive(false);
        Button Eabtn = EAChangeBtn.GetComponent<Button>();
        Button SAbtn = SAChangeBtn.GetComponent<Button>();
        Button BPbtn = popUpBackBtn.GetComponent<Button>();
        popUpBackBtn.gameObject.SetActive(false); // Pop-up back button initially inactive
        LoadCollectedImages();
        DisplayCollectedImages();
        popUpImageObject.SetActive(false);

        for (int i = 0; i < stBtns.Length; i++)
        {
            int index = i; // Use a local variable to capture the correct index
            stBtns[i].gameObject.SetActive(true); // 버튼을 활성화합니다.
            stBtns[i].onClick.AddListener(() =>
            {
                STHandleMouseClick(index);
            });
        }

        for (int i = 0; i < edBtns.Length; i++)
        {
            int index = i; // Use a local variable to capture the correct index
            edBtns[i].gameObject.SetActive(true);
            edBtns[i].onClick.AddListener(() =>
            {
                EDHandleMouseClick(index);
            });
        }

        popUpBackBtn.onClick.AddListener(() =>
        {
            popUpImageObject.SetActive(false);
            popUpBackBtn.gameObject.SetActive(false); // Hide the back button
        });

        Eabtn.onClick.AddListener(() =>
        {
            SAScreen.SetActive(false);
            EAScreen.SetActive(true);
            eventKey = "EAIMG";

            LoadCollectedImages();
            DisplayCollectedImages();
        });

        SAbtn.onClick.AddListener(() =>
        {
            EAScreen.SetActive(false);
            SAScreen.SetActive(true);
            eventKey = "SAIMG";

            LoadCollectedImages();
            DisplayCollectedImages();
        });
    }

    void STHandleMouseClick(int i)
    {
        if (popUpImageObject != null)
        {
            popUpBackBtn.gameObject.SetActive(true); // Show the back button
            popUpImageObject.SetActive(true);
            RawImage rawImage = popUpImageObject.GetComponent<RawImage>();
            if (rawImage != null)
            {
                rawImage.texture = stImageSlots[i].texture;
            }
        }
    }

    void EDHandleMouseClick(int i)
    {
        if (popUpImageObject != null)
        {
            popUpBackBtn.gameObject.SetActive(true); // Show the back button
            popUpImageObject.SetActive(true);
            RawImage rawImage = popUpImageObject.GetComponent<RawImage>();
            if (rawImage != null)
            {
                rawImage.texture = edImageSlots[i].texture;
            }
        }
    }

    // Load collected images
    void LoadCollectedImages()
    {
        collectedImages.Clear(); // Clear the list before loading new images
        for (int i = 0; i < stImageSlots.Length; i++)
        {
            string imageKey = eventKey + "_" + i.ToString(); // Set image key
            UnityEngine.Debug.Log(imageKey);

            if (PlayerPrefs.HasKey(imageKey))
            {
                string base64EncodedImage = PlayerPrefs.GetString(imageKey); // Get Base64 encoded image
                byte[] imageBytes = System.Convert.FromBase64String(base64EncodedImage); // Decode Base64 to byte array
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(imageBytes); // Convert byte array to texture
                collectedImages.Add(texture); // Add loaded texture to the list
            }
        }

        for (int i = 0; i < edImageSlots.Length; i++)
        {
            string imageKey = eventKey + "_" + i.ToString(); // Set image key
            UnityEngine.Debug.Log(imageKey);

            if (PlayerPrefs.HasKey(imageKey))
            {
                string base64EncodedImage = PlayerPrefs.GetString(imageKey); // Get Base64 encoded image
                byte[] imageBytes = System.Convert.FromBase64String(base64EncodedImage); // Decode Base64 to byte array
                Texture2D texture = new Texture2D(1, 1);
                texture.LoadImage(imageBytes); // Convert byte array to texture
                collectedImages.Add(texture); // Add loaded texture to the list
            }
        }
    }

    // Display collected images on UI
    void DisplayCollectedImages()
    {
        for (int i = 0; i < stImageSlots.Length; i++)
        {
            if (collectedImages.Count > i)
            {
                stImageSlots[i].texture = collectedImages[i];
            }
            else
            {
                stImageSlots[i].texture = defaultImage;
            }
        }

        for (int i = 0; i < edImageSlots.Length; i++)
        {
            if (collectedImages.Count > i)
            {
                edImageSlots[i].texture = collectedImages[i];
            }
            else
            {
                edImageSlots[i].texture = defaultImage;
            }
        }
    }
}
