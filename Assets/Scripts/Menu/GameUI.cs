using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameUI : MonoBehaviour
{
    public GameObject Pause_Popup;

    [Header("Lose Settings")]
    [Tooltip("Delay time before showing lose popup")]
    public float loseDelayDuration = 0.2f;
    
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

    public void LoseGame()
    {
        StartCoroutine(DoLoseWithDelay());
    }

    private IEnumerator DoLoseWithDelay()
    {
        yield return new WaitForSeconds(loseDelayDuration);

        Pause_Popup.SetActive(true);
        Time.timeScale = 0f;
    }
}
