using TMPro;
using UnityEngine;

public class TowerInfoUI : MonoBehaviour
{
    [Header("Panel")]
    public GameObject towerInfoPanel;

    [Header("Text UI")]
    public TMP_Text towerTitleText;
    public TMP_Text towerDescriptionText;

    private void Start()
    {
        towerInfoPanel.SetActive(false);
    }

    public void ShowFirewallInfo()
    {
        ShowTowerInfo(
            "Firewall Tower",
            "Firewall Tower adalah pertahanan dasar untuk menahan serangan umum.\n\nCocok melawan:\nMalware dan Worm.\n\nKelemahan:\nKurang efektif melawan musuh dengan HP tebal."
        );
    }

    public void ShowAntivirusInfo()
    {
        ShowTowerInfo(
            "Antivirus Scanner",
            "Antivirus Scanner menyerang dengan cepat.\n\nCocok melawan:\nWorm dan Botnet.\n\nKelemahan:\nDamage per hit kecil, jadi kurang optimal melawan musuh tebal."
        );
    }

    public void ShowIDSInfo()
    {
        ShowTowerInfo(
            "IDS Tower",
            "IDS Tower memiliki range jauh dan dapat memperlambat musuh.\n\nCocok melawan:\nWorm dan Ransomware.\n\nKelemahan:\nDamage tidak sebesar AI Defender."
        );
    }

    public void ShowBackupInfo()
    {
        ShowTowerInfo(
            "Backup Server",
            "Backup Server tidak menyerang, tetapi membantu memulihkan HP server.\n\nCocok untuk:\nWave panjang dan serangan campuran.\n\nKelemahan:\nTidak menghasilkan damage."
        );
    }

    public void ShowAIInfo()
    {
        ShowTowerInfo(
            "AI Defender",
            "AI Defender memiliki damage besar untuk menghancurkan ancaman berat.\n\nCocok melawan:\nRansomware dan Hacker Boss.\n\nKelemahan:\nHarga mahal, jadi kurang cocok sebagai tower pertama."
        );
    }

    private void ShowTowerInfo(string title, string description)
    {
        towerInfoPanel.SetActive(true);
        towerTitleText.text = title;
        towerDescriptionText.text = description;
    }

    public void CloseTowerInfo()
    {
        towerInfoPanel.SetActive(false);
    }
}