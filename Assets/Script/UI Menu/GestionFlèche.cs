using UnityEngine;

public class GestionFlèche : MonoBehaviour
{
    // Glisse tes 3 images de flèches ici dans l'inspecteur
    public GameObject[] mesFleches;

    // Cette fonction sera appelée au survol (PointerEnter)
    public void ActiverFleche(int index)
    {
        // 1. On commence par cacher TOUTES les flèches
        foreach (GameObject f in mesFleches)
        {
            f.SetActive(false);
        }

        // 2. On affiche seulement celle qui correspond au bouton survolé
        if (index >= 0 && index < mesFleches.Length)
        {
            mesFleches[index].SetActive(true);
        }
    }

    // Cette fonction peut être appelée quand la souris quitte tout le menu (PointerExit)
    public void CacherToutesLesFleches()
    {
        foreach (GameObject f in mesFleches)
        {
            f.SetActive(false);
        }
    }
}