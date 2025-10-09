using UnityEngine;

public class SensorScript : MonoBehaviour
{
    private BoxCollider2D col;

    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        if (col == null)
        {
            col = gameObject.AddComponent<BoxCollider2D>();
        }
        col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger entered by: {other.name} | Tag: {other.tag}");
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("✅ Player entered the trigger!");
        }
    }
}
