using TMPro;
using UnityEngine;

public class FertilizerScript : MonoBehaviour
{

    public TextMeshProUGUI guiText;
    public GameManager gm;


    [Header("Fertilizer")]
    int fertilizerAmount = 0;
    public GameObject activeFert;
    public GameObject[] fertilizers;
    public GameObject fertilizerPrefab;
    public Collider2D fertcollider;



    [Header("Float")]
    public float floatSpeed = 1f;
    public float floatHeight = 0.2f;
    private Vector3 initialPosition;

    private int i = 0;
    void Start()
    {
        initialPosition = transform.position;
        gm = FindAnyObjectByType<GameManager>();

        if (gm != null)
        {
            fertilizerAmount = gm.fertilizerAmount;
        }

        if (fertilizers.Length > 0)
        {
            activeFert = fertilizers[0];
        }

        guiText = GameObject.Find("FertilizerText").GetComponent<TextMeshProUGUI>();

        //SpawnNewFertilizers();
    }

    // Update is called once per frame
    void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);

        if (gm != null)
        {
            gm.fertilizerAmount++;
            fertilizerAmount = gm.fertilizerAmount;
        }

        ChangeFertStage();

        if (guiText != null)
        {
            guiText.text = "Fertilizer: " + fertilizerAmount.ToString();
            Debug.Log("Collected a fertilizer");
        }
        else
        {
            Debug.Log("GUI Text is null");
        }

        Debug.ClearDeveloperConsole();

    }

    public void ChangeFertStage()
    {

        if (i < fertilizers.Length - 1)
        {
            i++;
            activeFert = fertilizers[i];
        }
        else
        {
            Debug.Log("All fertilizers collected.");
        }
    }
}
