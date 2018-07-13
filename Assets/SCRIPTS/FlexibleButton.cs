using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]

public class FlexibleButton : MonoBehaviour
{

    public FlexibleButtonData buttonSkinData;


    protected virtual void OnSkinUI()
    {

    }

    public virtual void Awake()
    {
        OnSkinUI();
    }

    //Esto hay que eliminarlo cuando el juego comience a ser más grande.
    public virtual void Update()
    {
        if(Application.isEditor)
        {
            OnSkinUI();
        }
    }

}
