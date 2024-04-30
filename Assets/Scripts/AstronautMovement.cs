using UnityEngine;

public class AstronautMovement : MonoBehaviour
{
    public float rSpeed;
    public float mSpeed;
    public float X = 0.0f;
    public float Y = 0.0f;

    public AudioClip moveAudioClip;
    private AudioSource audioSource;
    private bool isMoving = false;

    void Start()
    {
        Debug.Log("cursor locked");
        LockCursor(true);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            LockCursor(false);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LockCursor(true);
        }

        bool isWKeyPressed = Input.GetKey(KeyCode.W);

        if (isWKeyPressed && !isMoving)
        {
            PlayMoveAudio();
            isMoving = true;
        }
        else if (!isWKeyPressed && isMoving)
        {
            StopMoveAudio();
            isMoving = false;
        }

        X += Input.GetAxis("Mouse X") * rSpeed;
        Y += Input.GetAxis("Mouse Y") * rSpeed;
        Y = Mathf.Clamp(Y, -90.0f, 90.0f);

        transform.localRotation = Quaternion.AngleAxis(X, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(Y, Vector3.left);
    }

    void FixedUpdate()
    {
        float verticalInput = -Input.GetAxis("Vertical");
        float horizontalInput = -Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;
        transform.Translate(moveDirection * mSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, 30.0f), transform.position.z);
    }

    void LockCursor(bool isLocked)
    {
        Cursor.visible = !isLocked;
        Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }

    void PlayMoveAudio()
    {
        if (moveAudioClip != null)
        {
            audioSource.clip = moveAudioClip;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Move audio clip is not assigned!");
        }
    }

    void StopMoveAudio()
    {
        audioSource.Stop();
    }
}
