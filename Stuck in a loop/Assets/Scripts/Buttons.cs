using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Command ForwardPrefab;
    public Command LeftPrefab;
    public Command RightPrefab;
    public GameObject LoopCommandsPanel;
    public GameObject GameWinPanel;
    private int index = 0;
    private int maxCommandCount = 8;
    private void OnEnable()
    {
        RobotController.OnReset += RobotController_OnReset;
        Target.OnGameWin += Target_OnGameWin;
    }

    private void Target_OnGameWin()
    {
        GameWinPanel.SetActive(true);
    }

    private void RobotController_OnReset()
    {
        index = 0;
        for (int i = 0; i < LoopCommandsPanel.transform.childCount; i++)
        {
            Destroy(LoopCommandsPanel.transform.GetChild(i).gameObject);
        }
        
    }

    private void OnDestroy()
    {
        RobotController.OnReset -= RobotController_OnReset;
        Target.OnGameWin -= Target_OnGameWin;
    }
    public void YPressed()
    {
        if (index < maxCommandCount)
        {
            var command = Instantiate(ForwardPrefab, LoopCommandsPanel.transform);
            command.Index = index++;
        }
        else
            return;
        
    }
    public void XPressed()
    {
        if (index < maxCommandCount)
        {
            var command = Instantiate(LeftPrefab, LoopCommandsPanel.transform);
            command.Index = index++;
        }
        else
            return;
    }
    public void BPressed()
    {
        if (index < maxCommandCount)
        {
            var command = Instantiate(RightPrefab, LoopCommandsPanel.transform);
            command.Index = index++;
        }
        else
            return;
    }
    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
