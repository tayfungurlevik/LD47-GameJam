using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Target : MonoBehaviour
{
    private int currentLevel = 0;
    [SerializeField]
    private List<Transform> targetPositions = new List<Transform>();
    [SerializeField]
    private RobotController robot;
    public static event Action<int> OnLevelIncreased = delegate { };
    public static event Action OnGameWin = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RobotController>()!=null)
        {
            //Debug.Log("Success...");
            currentLevel++;
            if (currentLevel==10)
            {
                OnGameWin?.Invoke();
                robot.ResetCommands();
            }
            else
            {
                OnLevelIncreased?.Invoke(currentLevel + 1);
                transform.position = targetPositions[currentLevel].position;
                robot.ResetCommands();
            }
            
        }
    }
}
