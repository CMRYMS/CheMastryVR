// Decompiled with JetBrains decompiler
// Type: UIAudio
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class UIAudio : 
  MonoBehaviour,
  IPointerClickHandler,
  IEventSystemHandler,
  IPointerEnterHandler,
  IPointerExitHandler
{
  public string clickAudioName;
  public string hoverEnterAudioName;
  public string hoverExitAudioName;

  public void OnPointerClick(PointerEventData eventData)
  {
    if (!(this.clickAudioName != ""))
      return;
    AudioManager.instance.Play(this.clickAudioName);
  }

  public void OnPointerEnter(PointerEventData eventData)
  {
    if (!(this.hoverEnterAudioName != ""))
      return;
    AudioManager.instance.Play(this.hoverEnterAudioName);
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    if (!(this.hoverExitAudioName != ""))
      return;
    AudioManager.instance.Play(this.hoverExitAudioName);
  }
}
