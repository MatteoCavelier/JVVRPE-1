using UnityEngine;

public class OpenJailDoor : MonoBehaviour
{
    [SerializeField] private GameObject jailDoor;

    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float openSpeed = 1f;

    private bool isOpening = false;
    
    void Update()
    {
        if (isOpening)
        {
            jailDoor.transform.rotation = Quaternion.Lerp(jailDoor.transform.rotation, Quaternion.Euler(0f, openAngle, 0f), openSpeed * Time.deltaTime);
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
    }
    
}
