using TMPro;
using UnityEngine;

namespace seedCollection
{

    public class seedCollect : MonoBehaviour
    {
        public GameManager gm;

        [Header("Pig")]
        public Collider2D pigCollider;
        public GameObject pig;

        [Header("Seed")]
        public GameObject seedGameObject;
        public int seedCount;
        public TextMeshProUGUI uGUI;


        void Start()
        {
            pig = GameObject.Find("Pig");
            pigCollider = pig.GetComponent<Collider2D>();
            seedGameObject = gameObject;



        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (uGUI != null)
            {
                seedGameObject.SetActive(false);
                gm.totalSeedAmount++;
                seedCount = gm.totalSeedAmount;
                uGUI.text = $"Seeds: {gm.totalSeedAmount}";
                Debug.Log($"Collected a {gameObject}");
            }



        }

    }
}
