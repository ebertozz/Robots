using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhosTalking : MonoBehaviour
{
    DialogTrigger dialogTrigger;
    public GameObject dialogPanel;


    // Start is called before the first frame update
    void Start()
    {
        dialogTrigger = GetComponent<DialogTrigger>();
    }

    

    public void startTalking()
    {

        dialogPanel.SetActive(true);
        dialogTrigger.TriggerDialog();

    }
}
