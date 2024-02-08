
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void LoadScene(string sceneName)
    {
        
        SceneManager.LoadScene(sceneName);
        Debug.Log($"SceneLoaded:{sceneName}");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
