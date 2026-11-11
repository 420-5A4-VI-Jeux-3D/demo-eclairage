using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Gère la démonstration d’éclairage en synchronisant le type de lumière actif, le mode d’ombres et l’intensité à
/// partir des contrôles UI.
/// </summary>
public class GestionnaireDemo : MonoBehaviour
{
    [SerializeField]
    private GroupeBouton groupeBoutonType;

    [SerializeField]
    private GroupeBouton groupeBoutonOmbre;

    [SerializeField]
    private Slider intensite;

    [SerializeField]
    private Light[] lumieres;

    private void Start()
    {
        groupeBoutonType.OnBoutonSelectionne += ChangerTypeLumiere;
        groupeBoutonOmbre.OnBoutonSelectionne += ChangerOmbre;
        intensite.onValueChanged.AddListener(ChangerIntensite);

        ChangerTypeLumiere(groupeBoutonType.BoutonSelectionne.name);
        ChangerOmbre(groupeBoutonOmbre.BoutonSelectionne.name);
        ChangerIntensite(intensite.value);
    }

    /// <summary>
    /// Active uniquement la lumière dont le nom correspond au type spécifié et désactive toutes les autres.
    /// </summary>
    /// <remarks>La comparaison de chaînes est sensible à la casse.</remarks>
    /// <param name="type">Nom du type de lumière à activer, comparé au nom de chaque lumière de la collection.</param>
    private void ChangerTypeLumiere(string type)
    {
        foreach (Light lumiere in lumieres)
        {
            lumiere.gameObject.SetActive(lumiere.name == type);
        }
    }

    /// <summary>
    /// Changes le mode d’ombre de toutes les lumières en fonction du nom du bouton sélectionné. 
    /// Les options sont "No Shadow", "Soft Shadows" et "Hard Shadows".
    /// </summary>
    /// <param name="ombre">Le nom de l'option d'ombre</param>
    private void ChangerOmbre(string ombre)
    {
        foreach (Light lumiere in lumieres)
        {
            if (ombre == "No Shadow")
            {
                lumiere.shadows = LightShadows.None;
            }
            else if (ombre == "Soft Shadows")
            {
                lumiere.shadows = LightShadows.Soft;
            }
            else if (ombre == "Hard Shadows")
            {
                lumiere.shadows = LightShadows.Hard;
            }
        }
    }

    /// <summary>
    /// Applique la même intensité à toutes les lumières de la collection.
    /// </summary>
    /// <param name="valeur">Intensité à appliquer à chaque lumière.</param>
    private void ChangerIntensite(float valeur)
    {
        foreach (Light lumiere in lumieres)
        {
            lumiere.intensity = valeur;
        }
    }
}
