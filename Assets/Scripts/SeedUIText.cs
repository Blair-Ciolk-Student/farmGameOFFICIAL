using TMPro;
using UnityEngine;


    public class SeedUIText : MonoBehaviour
    {
        public TextMeshProUGUI guiText;
        private GameManager gm;

        int tempSeedTotal = 00;
        // Start is called before the first frame update
        void Start()
        {
            guiText = FindFirstObjectByType<TextMeshProUGUI>();
            gm = FindFirstObjectByType<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {





        }

        public void UpdateText()
        {
            if (gm != null)
            {
                tempSeedTotal = gm.totalSeedAmount;

                if (guiText != null)
                {
                    guiText.text = "Seeds: " + tempSeedTotal.ToString();
                }
                else { Debug.LogError("Text null"); };
            }
            Debug.Log(tempSeedTotal);
        }
    }


