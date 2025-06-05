// Decompiled with JetBrains decompiler
// Type: AnimateOnInput
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
public class AnimateOnInput : MonoBehaviour
{
  public InputActionProperty pinchAnimate;
  public InputActionProperty gripAnimate;
  public Animator AnimateHand;

  private void Start()
  {
  }

  private void Update()
  {
    this.AnimateHand.SetFloat("Trigger", this.pinchAnimate.action.ReadValue<float>());
    this.AnimateHand.SetFloat("Grip", this.gripAnimate.action.ReadValue<float>());
  }
}
