using UnityEngine;

public class FallOutOfBounds : MonoBehaviour
{
    private Vector2 entrancePosition;

    private void Start() => entrancePosition = GameObject.Find("Entrance").transform.position;
    private void OnTriggerExit2D(Collider2D escapeeCollider)
    {
        if (escapeeCollider.gameObject.CompareTag("Player"))
        {
            escapeeCollider.gameObject.transform.position = entrancePosition;
            escapeeCollider.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
    }
}
