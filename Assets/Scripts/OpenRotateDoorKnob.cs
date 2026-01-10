using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class OpenRotateDoorKnob : MonoBehaviour
{
    [SerializeField] private GameObject jailDoor;
    [SerializeField] private XRKnob knob;

    [SerializeField] private float maxDoorAngle = 90f;

    private Quaternion initialDoorRotation;
    
    void Start()
    {
        // Sauvegarder la rotation initiale de la porte
        if (jailDoor != null)
        {
            initialDoorRotation = jailDoor.transform.rotation;
        }

        // S'abonner à l'événement de valeur du knob
        if (knob != null)
        {
            knob.onValueChange.AddListener(OnKnobValueChanged);
        }
    }

    void OnDestroy()
    {
        // Se désabonner pour éviter les erreurs
        if (knob != null)
        {
            knob.onValueChange.RemoveListener(OnKnobValueChanged);
        }
    }

    private void OnKnobValueChanged(float knobValue)
    {
        if (jailDoor != null)
        {
            // knobValue va de 0 à 1 (normalisé par rapport à l'amplitude du knob)
            float doorAngle = knobValue * maxDoorAngle;
            
            // Appliquer la rotation à la porte
            jailDoor.transform.rotation = initialDoorRotation * Quaternion.Euler(0f, doorAngle, 0f);
        }
    }

    // Optionnel : méthode pour réinitialiser la porte
    public void ResetDoor()
    {
        if (jailDoor != null && knob != null)
        {
            jailDoor.transform.rotation = initialDoorRotation;
            knob.value = 0f;
        }
    }
}