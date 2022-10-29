using UnityEngine;
using Mirror;
using Cinemachine;

public class CamController : NetworkBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLook;
    void Start()
    {
        if (isLocalPlayer)
        {
            freeLook = CinemachineFreeLook.
                FindObjectOfType<CinemachineFreeLook>();
            freeLook.LookAt = this.gameObject.transform;
            freeLook.Follow = this.gameObject.transform;
        }
    }
}
