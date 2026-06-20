using UnityEngine;

public class WaveIntroUI : MonoBehaviour
{
    public GameObject waveInfoPanel;
    public GameObject towerBarPanel;
    public WaveManager waveManager;

    private void Start()
    {
        waveInfoPanel.SetActive(true);

        if (towerBarPanel != null)
        {
            towerBarPanel.SetActive(false);
        }
    }

    public void StartWaveButton()
    {
        waveInfoPanel.SetActive(false);

        if (towerBarPanel != null)
        {
            towerBarPanel.SetActive(true);
        }

        waveManager.StartWave();
    }
}