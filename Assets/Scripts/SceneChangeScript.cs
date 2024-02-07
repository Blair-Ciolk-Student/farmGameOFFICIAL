using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeScript : MonoBehaviour
{
    [SerializeField]
    public Button NextStageBtn;

    private void Start()
    {
        NextStageBtn.gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}