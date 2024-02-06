
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject pig;
    public GameObject Crop;
    [Header("Text")]
    public TextMeshProUGUI seedText;
    public TextMeshProUGUI fertilizerText;

    CropScript cropScript;

    public int fertilizerAmount = 0;
    public int totalSeedAmount = 0;

    public int activeScene = 1;

    

    

    // Update is called once per frame
    void Update()
    {
        seedText.text = $"Seeds: {totalSeedAmount}";
        fertilizerText.text = $"Fertilizer: {fertilizerAmount}";

        if (cropScript.cropStageNum == 3)
        {
            SceneManager.LoadScene(activeScene);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
