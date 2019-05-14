using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour
{

    public int ScoreValue = 50;
    // Start is called before the first frame update
    void OnDestroy()
    {
        GameController.Score += ScoreValue;
    }

}
