using UnityEngine;
using UnityEngine.UI; // Obligatoire pour manipuler l'UI

public class GestionMenu : MonoBehaviour
{
    public GameObject[] tousLesFonds; // Tes 3 fonds

    public void SelectionnerBouton(int index)
    {
        // UnityEngine.EventSystems permet de savoir quel objet a appelé la fonction
        GameObject boutonClique = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        // 3. Logique pour ouvrir le bon fond (comme avant)
        OuvrirLeFond(index);
    }

    private void OuvrirLeFond(int index)
    {
        // On cache tout
        foreach (GameObject f in tousLesFonds) f.SetActive(false);

        // On affiche celui qui correspond à l'index (0, 1 ou 2)
        if (index < tousLesFonds.Length) tousLesFonds[index].SetActive(true);
    }
}