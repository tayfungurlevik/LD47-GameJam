using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILevelText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void OnEnable()
    {
        Target.OnLevelIncreased += Target_OnLevelIncreased;
    }
    private void OnDisable()
    {
        Target.OnLevelIncreased -= Target_OnLevelIncreased;
    }
    private void Target_OnLevelIncreased(int level)
    {
        text.text = string.Format("Level: {0}", level);
    }

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = string.Format("Level: {0}", 1);
    }


}
