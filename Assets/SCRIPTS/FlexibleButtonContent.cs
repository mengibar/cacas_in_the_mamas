using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]

public class FlexibleButtonContent : FlexibleButton {

    public enum ButtonType
    {
        Default,
        Confirm,
        Decline,
        Warning,
        Close,
    }

    Image image;
    Image icon;
    Button button;
    //Text text;

    public ButtonType buttonType;

    protected override void OnSkinUI ()
    {
        base.OnSkinUI ();

        image = GetComponent<Image> ();
        
        Transform iconTransform = transform.Find("Icon");
        if (iconTransform != null)
        {
            icon = iconTransform.GetComponent<Image>();
            if (icon != null)
            {
                icon.sprite = buttonSkinData.defaultIcon;
            }
        }
        
        button = GetComponent<Button> ();

        button.transition = Selectable.Transition.SpriteSwap;
        button.targetGraphic = image;

        image.sprite = buttonSkinData.buttonSprite;
        image.type = Image.Type.Sliced;
        button.spriteState = buttonSkinData.buttonSpriteState;

        switch (buttonType)
        {
            case ButtonType.Confirm:
                image.color = buttonSkinData.confirmColor;
                icon.sprite = buttonSkinData.confirmIcon;
                break;
            case ButtonType.Decline:
                image.color = buttonSkinData.declineColor;
                icon.sprite = buttonSkinData.declineIcon;
                break;
            case ButtonType.Default:
                image.color = buttonSkinData.defaultColor;
                icon.sprite = buttonSkinData.defaultIcon;
                break;
            case ButtonType.Warning:
                image.color = buttonSkinData.warningColor;
                icon.sprite = buttonSkinData.warningIcon;
                break;
            case ButtonType.Close:
                image.color = buttonSkinData.closeColor;
                icon.sprite = buttonSkinData.closeIcon;
                break;
        }
    }


}
