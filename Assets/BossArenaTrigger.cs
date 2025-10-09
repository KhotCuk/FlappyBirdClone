using UnityEngine;
using Cinemachine;

public class BossArenaTrigger : MonoBehaviour
{
    [Header("Assign BossCamera di Inspector")]
    public CinemachineVirtualCamera BossCamera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BossCamera.Priority = 3;
        }
    }
}
