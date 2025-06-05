// Decompiled with JetBrains decompiler
// Type: AudioManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class AudioManager : MonoBehaviour
{
  public Sound[] sounds;
  public static AudioManager instance;

  private void Awake()
  {
    AudioManager.instance = this;
    foreach (Sound sound in this.sounds)
    {
      if (!(bool) (UnityEngine.Object) sound.source)
        sound.source = this.gameObject.AddComponent<AudioSource>();
      sound.source.clip = sound.clip;
      sound.source.playOnAwake = sound.playOnAwake;
      if (sound.playOnAwake)
        sound.source.Play();
      sound.source.volume = sound.volume;
      sound.source.pitch = sound.pitch;
      sound.source.loop = sound.loop;
    }
  }

  public void Play(string name)
  {
    Sound sound1 = Array.Find<Sound>(this.sounds, (Predicate<Sound>) (sound => sound.name == name));
    if (sound1 == null)
      Debug.LogWarning((object) $"Sound: {name} not found");
    else
      sound1.source.Play();
  }

  public void Stop(string name)
  {
    Array.Find<Sound>(this.sounds, (Predicate<Sound>) (sound => sound.name == name)).source.Stop();
  }
}
