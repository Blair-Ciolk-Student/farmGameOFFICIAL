
using UnityEngine;

public class CursorLockHide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;

    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
