// Decompiled with JetBrains decompiler
// Type: PlayAudioFromAudioManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PlayAudioFromAudioManager : MonoBehaviour
{
  public string target;

  public void Play() => AudioManager.instance.Play(this.target);

  public void Play(string audioName) => AudioManager.instance.Play(audioName);
}
