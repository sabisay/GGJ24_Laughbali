using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonCOde : MonoBehaviour
{
    [SerializeField] private GameObject info;
    private bool boolean;
    // Start is called before the first frame update
    public void OnMouseDown(){
        boolean = !boolean;
        info.SetActive(boolean);
    }
}
