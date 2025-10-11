using UnityEngine;

public class AimingController : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;

    [Header("Settings")]
    public float maxAimDistance = 100f;

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
        Vector3 targetPosition;
        RaycastHit? validHit = null;
        Vector3 mousePosition = Input.mousePosition;
        Ray aimingRay = playerCamera.ScreenPointToRay(mousePosition);

        // Debug: visualize the ray in Scene view
        Debug.DrawRay(aimingRay.origin, aimingRay.direction * maxAimDistance, Color.red);

        // Get ALL hits along the ray
        RaycastHit[] hits = Physics.RaycastAll(aimingRay, maxAimDistance);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject != gameObject && !hit.transform.IsChildOf(transform))
            {
                validHit = hit;
                break;
            }
        }

        if (validHit.HasValue)
        {
            targetPosition = new Vector3(validHit.Value.point.x, transform.position.y, validHit.Value.point.z);
        }
        else
        {
            Vector3 farPoint = aimingRay.origin + aimingRay.direction * maxAimDistance;
            targetPosition = new Vector3(farPoint.x, transform.position.y, farPoint.z);
        }

        transform.LookAt(targetPosition);
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