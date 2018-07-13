using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Pelta.UI
{




    /// MOVE ME ELSEWHERE
    public class StringEvent : UnityEvent<string> { }





  public class UIMacro: MonoBehaviour 
  {

    [System.Serializable]
    public class MacroElement
    {
      public string name;
      public UnityEvent actions;
    }

    [System.Serializable]
    public class StringMacroElement
    {
      public string name;
      public StringEvent actions;
    }

    [Tooltip("Called once when the object is created")]
    public string AwakeAction = "";
    [Tooltip("Called every time the object is enabled/activated")]
    public string EnableAction = "";
    [Tooltip("Called every time the object is disabled/deactivated")]
    public string DisableAction = "";

    //Macro list
    public List<MacroElement> Macros = new List<MacroElement>();




    void Awake()
    {
      if(!string.IsNullOrEmpty(AwakeAction))
      {
        InvokeMacro(AwakeAction);
      }
    }

    void OnEnable()
    {
      if (!string.IsNullOrEmpty(EnableAction))
      {
        InvokeMacro(EnableAction);
      }
    }

    void OnDisable()
    {
      if (!string.IsNullOrEmpty(DisableAction))
      {
        InvokeMacro(DisableAction);
      }
    }





    //Execute Macro
    public void InvokeMacro (string macroname)
    {
      foreach (MacroElement elem in Macros)
      {
        if (elem.name == macroname)
        {
          elem.actions.Invoke();
          return;
        }
      }

      Debug.Assert(false, "No UI Macro found with name " + macroname);
    }

    //Execute Macro (to be used like a switch with an integer option)
    public void SwitchMacro (int option)
    {
      string macroname = option.ToString();

      foreach (MacroElement elem in Macros)
      {
        if (elem.name == macroname)
        {
          elem.actions.Invoke();
          return;
        }
      }

      Debug.Assert(false, "No UI Macro found for option " + macroname);
    }

  }
}
