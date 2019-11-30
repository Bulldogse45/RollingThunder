using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class sourceLink : MonoBehaviour
{
    // Start is called before the first frame update
    public string link;
    
    public void openLink()
    {
        Application.OpenURL(link);
    }
}
