using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Outfit")]
public class Albert_Outfits : ScriptableObject
{
    public int outfitID;
    public RuntimeAnimatorController outfitRuntimeAnimator;
    public Sprite outfitSprite;
    
    public float movementSpeed;
    public float jumpForce;

    public float tirednessIncreaseSize;
    public float tirednessDecreaseSize;
    public float tirednessAddSize;
    public float tirednessSubtractSize;
}
