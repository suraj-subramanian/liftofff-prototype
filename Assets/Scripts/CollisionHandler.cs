using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag) {
            case "Fuel":
                Debug.Log("Fuel");
                break;
            case "Finish":
                Debug.Log("Finish");
                break;
            case "Respawn":
                Debug.Log("Respawn");
                break;
            default:
                Debug.Log("default action");
                break;
        }

    }
}
