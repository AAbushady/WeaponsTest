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
        // TODO(human): Implement prefab swapping logic
        // 1. Store current position and rotation
        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;

        // 2. Instantiate the new prefab at the same location
        GameObject newVehicle = Instantiate(targetPrefab, currentPosition, currentRotation);

        // 4. Make sure the new prefab has this script and set its currentMode
        currentMode = newMode;

        // 3. Destroy this current game object (do this LAST!)
        Destroy(gameObject);
    }
}