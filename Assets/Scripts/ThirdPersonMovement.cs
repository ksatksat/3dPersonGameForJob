using UnityEngine;
using Mirror;

public class ThirdPersonMovement : NetworkBehaviour
{
    public CharacterController controller;//
    public Transform camTrans;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 7f;
    private void Awake()
    {
        gameObject.transform.position = new Vector3(0f, 25f, 0f);
        camTrans = Camera.FindObjectOfType<Camera>().transform;
    }
    void Update()
    {
        if (isLocalPlayer)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position,
            groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3
                (horizontal, 0f, vertical).normalized;
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2
                    (direction.x, direction.z) * Mathf.Rad2Deg
                    + camTrans.eulerAngles.y;//
                float angle = Mathf.SmoothDampAngle
                    (transform.eulerAngles.y, targetAngle,
                    ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);//
                Vector3 moveDir = Quaternion.Euler
                    (0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);//
            }
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
