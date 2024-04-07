using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image imageComponent; // Using UnityEngine.UI.Image for displaying images
    public string[] lines;
    public Sprite[] lineImages; // Array of images corresponding to each line of dialogue
    public float textSpeed;
    private int index;

    private Dictionary<string, Sprite> lineImageMap; // Dictionary to map lines to images

    void Awake()
    {
        gameObject.SetActive(false); // Deactivate the dialogue panel initially
    }

    public void StartDialogue()
    {
        textComponent.text = string.Empty;
        index = 0;
        CreateLineImageMap(); // Initialize the lineImageMap dictionary
        DisplayImageForLine(lines[index]); // Display image for the first line
        gameObject.SetActive(true); // Activate the dialogue panel
        StartCoroutine(TypeLine()); // Start coroutine after activating the GameObject
    }

    void CreateLineImageMap()
    {
        lineImageMap = new Dictionary<string, Sprite>();
        for (int i = 0; i < lines.Length; i++)
        {
            if (i < lineImages.Length) // Ensure there's a corresponding image for each line
            {
                lineImageMap.Add(lines[i], lineImages[i]);
            }
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            DisplayImageForLine(lines[index]); // Display image for the next line
            StartCoroutine(TypeLine()); // Start coroutine for the next line
        }
        else
        {
            gameObject.SetActive(false); // Deactivate the dialogue panel when dialogue ends
        }
    }

    void DisplayImageForLine(string line)
    {
        if (lineImageMap != null && lineImageMap.ContainsKey(line)) // Check for null before accessing the dictionary
        {
            imageComponent.sprite = lineImageMap[line];
        }
        else
        {
            imageComponent.sprite = null; // If no image is available for the line
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
}
