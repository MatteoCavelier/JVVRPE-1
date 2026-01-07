using UnityEngine;

public class OpenUpDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private float openSpeed = 1f;
    [SerializeField] private float YOpenPosition = 10f;

    private bool isOpening = false;

    public void OpenDoor()
    {
        isOpening = true;
    }

    void Update()
    {
        if (isOpening)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, YOpenPosition, door.transform.position.z), openSpeed * Time.deltaTime);
        }
    }
}
