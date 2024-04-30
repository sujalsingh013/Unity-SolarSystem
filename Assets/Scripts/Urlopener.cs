using UnityEngine;

public class Urlopener : MonoBehaviour
{
    public string hyperlinkURL;

    public void OpenHyperlink()
    {
        Application.OpenURL(hyperlinkURL);
    }
}
