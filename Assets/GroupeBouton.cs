using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Représente un groupe de boutons UI avec gestion d’une sélection unique et mise à jour visuelle de l’état
/// sélectionné.
/// </summary>
/// <remarks>Le script s'exécute -50 ms avant la boucle standard</remarks>
public class GroupeBouton : MonoBehaviour
{
    /// <summary>
    /// Evénement déclenché lorsqu’un bouton est sélectionné, transmettant le nom du bouton sélectionné.
    /// </summary>
    public event System.Action<string> OnBoutonSelectionne;

    [SerializeField]
    private Button[] boutons;

    /// <summary>
    /// Le bouton actuellement sélectionné.
    /// </summary>
    public Button BoutonSelectionne { get; private set; }

    [SerializeField]
    private Color couleurParDefaut;

    [SerializeField]
    private Color couleurSelectionne;

    private void Start()
    {
        foreach (Button bouton in boutons)
        {
            bouton.onClick.AddListener(() => SelectionnerBouton(bouton));
        }

        SelectionnerBouton(boutons[0]);
    }

    /// <summary>
    /// Met le bouton sélectionné comme actif et notifie les observateur de l'événement OnBoutonSelectionne
    /// </summary>
    /// <param name="bouton">Le bouton qui est sélectionné</param>
    public void SelectionnerBouton(Button bouton)
    {
        if(BoutonSelectionne != null)
        {
            BoutonSelectionne.GetComponent<Image>().color = couleurParDefaut;
        }

        BoutonSelectionne = bouton;
        BoutonSelectionne.GetComponent<Image>().color = couleurSelectionne;

        OnBoutonSelectionne?.Invoke(bouton.name);
    }
}
