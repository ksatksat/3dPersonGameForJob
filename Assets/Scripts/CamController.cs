using UnityEngine;
using Mirror;
using Cinemachine;

public class CamController : NetworkBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLook;
    private void Start()
    {
        if (isLocalPlayer)
        {
            freeLook = CinemachineFreeLook.
                FindObjectOfType<CinemachineFreeLook>();//here issue
            freeLook.LookAt = this.gameObject.transform;
            freeLook.Follow = this.gameObject.transform;
        }
    }
    //private void OnEnable()
    //{
    //    if (isLocalPlayer)
    //    {
    //        freeLook = CinemachineFreeLook.
    //            FindObjectOfType<CinemachineFreeLook>();
    //        freeLook.LookAt = this.gameObject.transform;
    //        freeLook.Follow = this.gameObject.transform;
    //    }
    //}
}
