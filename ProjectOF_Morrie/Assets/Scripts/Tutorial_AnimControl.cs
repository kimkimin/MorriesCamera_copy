using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_AnimControl : MonoBehaviour
{
    public void Rewinding()
    {
        GetComponent<Animator>().SetBool("goRewind", true);
    }
}
