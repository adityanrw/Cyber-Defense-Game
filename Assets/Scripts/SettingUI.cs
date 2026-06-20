using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingUI : MonoBehaviour
{
    [Header("Panel")]
    public GameObject settingPanel;

    public void OpenSetting()
    {
        settingPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        settingPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("HasSaveData", 1);
        PlayerPrefs.Save();

        Debug.Log("Game berhasil disimpan sementara.");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}