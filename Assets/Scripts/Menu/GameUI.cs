using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject Pause_Popup;
    public static GameUI instance;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else Destroy(gameObject);
    }
    public void Pause()
    {
        Pause_Popup.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Continue()
    {
        if (PlayerMove.Instance != null)
        {
            Pause_Popup.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
