using UnityEngine;

public class AimingController : MonoBehaviour
{
    [Header("Aiming Settings")]
    public float mouseSensitivity = 2f;
    public LayerMask groundLayerMask = 1; // What layer is the ground on?

    [Header("References")]
    public Camera playerCamera;

    private TransformationController transformController;
    private bool isAiming = false;

    void Start()
    {
        transformController = GetComponent<TransformationController>();

        // Find camera if not assigned
        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    void Update()
    {
        // Only allow aiming in robot mode
        if (transformController != null && transformController.currentMode == VehicleMode.Robot)
        {
            if (!isAiming)
            {
                EnableAiming();
            }
            HandleMouseLook();
        }
        else
        {
            if (isAiming)
            {
                DisableAiming();
            }
        }
    }

    void EnableAiming()
    {
        isAiming = true;
        // Show cursor, enable crosshair, etc.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Aiming enabled - Robot mode");
    }

    void DisableAiming()
    {
        isAiming = false;
        // Hide aiming UI, lock cursor, etc.
        Debug.Log("Aiming disabled - Car mode");
    }

    void HandleMouseLook()
    {
        // TODO(human): Implement mouse look aiming for robot mode
        // 1. Get mouse position on screen
        
        // 2. Convert to world position (raycast to ground or use camera)
        // 3. Make robot look at that world position
        // 4. Consider only rotating on Y axis to keep robot upright

    }

    // This will be useful later for weapons
    public Vector3 GetAimDirection()
    {
        if (isAiming)
        {
            return transform.forward;
        }
        return Vector3.forward; // Default forward if not aiming
    }
}