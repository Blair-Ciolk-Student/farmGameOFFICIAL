
using UnityEngine;


public class CropScript : MonoBehaviour
{
    public GameManager gm;
    public FertilizerScript fertScript;
    [Header("Crop")]
    public GameObject Crop;
    public int cropStageNum;

    [Header("Pig")]
    public GameObject pig;
    public Collider2D pigCollider;


    [Header("Sprite")]
    public SpriteRenderer spriteRend;
    public Sprite[] spriteArr;

    private void Start()
    {

        Crop = gameObject;
        pigCollider = pig.GetComponent<Collider2D>();
        cropStageNum = 0;

    }

    void ChangeSprite(int stageNumber)
    {
        spriteRend.sprite = spriteArr[stageNumber];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pigCollider != null)
        {
            if (gm.fertilizerAmount <= 3)
            {
                if (gm.fertilizerAmount >= 1 && gm.totalSeedAmount >= 1)
                {
                    gm.totalSeedAmount--;
                    gm.fertilizerAmount--;
                    cropStageNum++;
                    ChangeSprite(cropStageNum);

                }
                else if (gm.fertilizerAmount >= 1 && cropStageNum >= 1 && cropStageNum <= 4)
                {
                    gm.fertilizerAmount--;
                    cropStageNum++;
                    ChangeSprite(cropStageNum);
                }
                else if (gm.totalSeedAmount >= 1)
                {
                    gm.totalSeedAmount--;
                    cropStageNum++;
                    ChangeSprite(cropStageNum);
                }
                else
                {
                    cropStageNum = 0;
                }

            }




        }
    }
}