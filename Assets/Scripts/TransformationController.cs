using System;
using UnityEngine;

public enum VehicleMode
{
    Car,
    Robot
}

public class TransformationController : MonoBehaviour
{
    [Header("Prefab References")]
    public GameObject carPrefab;
    public GameObject robotPrefab;

    [Header("Settings")]
    public KeyCode transformKey = KeyCode.T;

    [Header("Current State")]
    public VehicleMode currentMode = VehicleMode.Car;

    private GameObject currentPrefab;

    void Start()
    {
        if (transform.childCount > 0)
        {
            currentPrefab = transform.GetChild(0).gameObject;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(transformKey))
        {
            Console.WriteLine("Transform key pressed");
            Transform();
        }
    }

    public void Transform()
    {
        Debug.Log($"Current mode: {currentMode}");
        if (currentMode == VehicleMode.Car)
        {
            Debug.Log("Transforming to Robot");
            TransformToRobot();
        }
        else
        {
            Debug.Log("Transforming to Car");
            TransformToCar();
        }
    }

    void TransformToRobot()
    {
        if (robotPrefab != null)
        {
            SwapToPrefab(robotPrefab, VehicleMode.Robot);
        }
        else
        {
            Debug.LogWarning("Robot prefab not assigned!");
        }
    }

    void TransformToCar()
    {
        if (carPrefab != null)
        {
            SwapToPrefab(carPrefab, VehicleMode.Car);
        }
        else
        {
            Debug.LogWarning("Car prefab not assigned!");
        }
    }

    void SwapToPrefab(GameObject targetPrefab, VehicleMode newMode)
    {
        // Step 1: If there's a current model (child), destroy it
        if (currentPrefab != null)
        {
            Destroy(currentPrefab);
        }

        // Step 2: Instantiate the new child model
        GameObject newPrefab = Instantiate(targetPrefab);

        // Step 3: Make it a child of THIS GameObject (the Player parent)
        newPrefab.transform.SetParent(transform);

        // Step 4: Reset the child's local position/rotation so it's centered on parent
        newPrefab.transform.localPosition = Vector3.zero;
        newPrefab.transform.localRotation = Quaternion.identity;

        // Step 4.5: If changing from Robot to Car, reset camera position forward
        if (currentMode == VehicleMode.Robot && newMode == VehicleMode.Car)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                Vector3 cameraForward = mainCamera.transform.forward;
                cameraForward.y = 0; // Flatten to horizontal plane
                if (cameraForward.sqrMagnitude > 0.01f)
                {
                    transform.rotation = Quaternion.LookRotation(cameraForward);
                }
            }
        }

        // Step 5: Store reference to the new model for next swap
        currentPrefab = newPrefab;

        // Step 6: Update the mode
        currentMode = newMode;
    }
}