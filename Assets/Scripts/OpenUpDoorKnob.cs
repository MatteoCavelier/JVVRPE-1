using UnityEngine;
using UnityEngine.XR.Content.Interaction;


public class OpenUpDoorKnob : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private XRKnob knob;

    [SerializeField] private float maxYOffset = 10f;

    private Vector3 initialDoorPosition;
    
    void Start()
    {
        // Sauvegarder la position initiale de la porte
        if (door != null)
        {
            initialDoorPosition = door.transform.position;
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
        if (door != null)
        {
            // knobValue va de 0 à 1 (normalisé par rapport à l'amplitude du knob)
            float yOffset = knobValue * maxYOffset;
            
            // Appliquer le déplacement vertical à la porte
            door.transform.position = new Vector3(
                initialDoorPosition.x, 
                initialDoorPosition.y + yOffset, 
                initialDoorPosition.z
            );
        }
    }

    // Optionnel : méthode pour réinitialiser la porte
    public void ResetDoor()
    {
        if (door != null && knob != null)
        {
            door.transform.position = initialDoorPosition;
            knob.value = 0f;
        }
    }
}