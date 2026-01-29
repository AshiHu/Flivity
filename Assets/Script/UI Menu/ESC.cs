using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public RectTransform settingsPanel;
    public float speed = 15f;

    // Cette variable statique permet à la caméra de savoir si elle doit bouger
    public static bool IsOpen = false;

    private Vector2 hiddenPos;
    private Vector2 visiblePos;

    void Start()
    {
        // On calcule les positions. 
        // IMPORTANT : Ton Panel doit avoir son Pivot X à 1 dans l'inspecteur.
        float width = settingsPanel.rect.width;
        hiddenPos = new Vector2(0, settingsPanel.anchoredPosition.y);
        visiblePos = new Vector2(width, settingsPanel.anchoredPosition.y);

        settingsPanel.anchoredPosition = hiddenPos;
        IsOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsOpen = !IsOpen;

            // On gère la souris
            Cursor.visible = IsOpen;
            Cursor.lockState = IsOpen ? CursorLockMode.None : CursorLockMode.Locked;

            // On gère le temps (optionnel, pour figer le jeu)
            Time.timeScale = IsOpen ? 0f : 1f;
        }

        // Animation fluide
        Vector2 target = IsOpen ? visiblePos : hiddenPos;
        settingsPanel.anchoredPosition = Vector2.Lerp(settingsPanel.anchoredPosition, target, Time.unscaledDeltaTime * speed);
    }
}