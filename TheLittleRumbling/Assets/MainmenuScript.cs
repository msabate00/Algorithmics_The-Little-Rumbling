using UnityEngine;

public class MainmenuScript : MonoBehaviour
{
    public GameObject creditsPanel;

    public void ToggleCredits(bool open)
    {
        creditsPanel.SetActive(open);
    }
}
