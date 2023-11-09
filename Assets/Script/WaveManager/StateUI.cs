using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI state;
    [SerializeField] TextMeshProUGUI WaveNumber;
    [SerializeField] TextMeshProUGUI TimeBeforeNextWave;
    [SerializeField] WaveManager manager;
    // Start is called before the first frame update
    void Start()
    {
        state.text = "";
        WaveNumber.text = "";
        TimeBeforeNextWave.text = " ";
    }

    // Update is called once per frame
    void Update()
    { // chua tao event 
        state.text = "State " + manager.GetState().ToString();
        WaveNumber.text = "Wave " + manager.waveNumber.ToString();
        float index = Mathf.Round(manager.WaitBeforeNextWave * 10f) * 0.1f;
        if(index != 20f)
        {
            TimeBeforeNextWave.text = "Wave " + (manager.waveNumber + 1 ).ToString() + " Coming soon in " + index.ToString();
        }
        else
        {
            TimeBeforeNextWave.text = " ";
        }
        
    }
}
