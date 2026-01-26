using UnityEngine;

public class SimpleSpeedFOV : MonoBehaviour
{
    [Header("Références")]
    public PlayerMovementCustomKeys playerScript;
    private Camera cam;

    [Header("Paramètres FOV")]
    public float baseFOV = 60f;
    public float maxFOV = 90f;

    [Header("Vitesse de transition")]
    [Tooltip("Plus la valeur est petite, plus c'est lent")]
    public float smoothSpeed = 2f;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (playerScript == null)
            playerScript = FindFirstObjectByType<PlayerMovementCustomKeys>();
    }

    void Update()
    {
        if (playerScript == null) return;

        // On crée une cible de FOV par défaut
        float targetFOV = baseFOV;

        // On vérifie si le joueur bouge (Z ou X) ou s'il glisse
        // On utilise GetAxisRaw pour savoir si une touche est enfoncée
        bool isMoving = Input.GetAxisRaw(playerScript.horizontalAxis) != 0 ||
                        Input.GetAxisRaw(playerScript.verticalAxis) != 0;

        if (isMoving)
        {
            // Si on bouge normalement, on augmente un peu
            targetFOV = baseFOV + 10f;
        }

        // On vérifie directement dans ton script si isSliding est vrai
        // Note : Il faut que 'isSliding' soit en 'public' dans ton script Player
        // OU on vérifie simplement si la touche de slide est pressée
        if (Input.GetKey(playerScript.slideKey))
        {
            // Si on glisse, on va au max
            targetFOV = maxFOV;
        }

        // Application très lente et fluide du FOV
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, Time.deltaTime * smoothSpeed);
    }
}