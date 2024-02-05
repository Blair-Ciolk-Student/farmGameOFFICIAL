
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject pig;
    public GameObject Crop;
    [Header("Text")]
    public TextMeshProUGUI seedText;
    public TextMeshProUGUI fertilizerText;

    public int fertilizerAmount = 0;
    public int totalSeedAmount = 0;


    private void Awake()
    {
            


    }

    

    // Update is called once per frame
    void Update()
    {
        seedText.text = $"Seeds: {totalSeedAmount}";
        fertilizerText.text = $"Fertilizer: {fertilizerAmount}";


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
