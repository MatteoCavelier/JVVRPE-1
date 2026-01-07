using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisappearChestTop : MonoBehaviour
{
    [SerializeField] private GameObject chestTop;
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socketInteractor;

    void Start()
    {
        socketInteractor = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();

        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnObjectPlaced);
        }
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        // Quand un objet est placé dans le socket
        if (chestTop != null)
        {
            chestTop.SetActive(false);
        }
    }

    void OnDestroy()
    {
        // Nettoyage pour éviter les erreurs
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.RemoveListener(OnObjectPlaced);
        }
    }
}