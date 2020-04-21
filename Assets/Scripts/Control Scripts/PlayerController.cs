
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]    
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 20f;
    [Tooltip("In m")] [SerializeField] float xRange = 10f;
    [Tooltip("In m")] [SerializeField] float yRange = 4f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = 3f;
    [SerializeField] float controlPitchFactor = 5f;

    [Header("Control-throw Based")]
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlRollFactor = -35f;

    float xThrow, yThrow;
    bool isControlEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }       
    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }
    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(-pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;


        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        
        transform.localPosition = new Vector3(
            clampedXPos, clampedYPos, transform.localPosition.z);
        
    }
}
