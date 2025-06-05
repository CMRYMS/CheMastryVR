// Decompiled with JetBrains decompiler
// Type: SameTagParticleCollisionEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.Events;

#nullable disable
public class SameTagParticleCollisionEvent : MonoBehaviour
{
  public UnityEvent MatchParticleCollisionTag;
  public float InitiateCollisionDelay = 0.25f;
  private bool IsDetectable = false;

  private void Start() => this.Invoke("AllowDetectable", this.InitiateCollisionDelay);

  private void AllowDetectable() => this.IsDetectable = true;

  private void OnParticleCollision(GameObject other)
  {
    if (!this.IsDetectable || !other.CompareTag(this.gameObject.tag))
      return;
    Debug.Log((object) ("[Particle Collision] Hit object with same tag: " + other.name));
    this.MatchParticleCollisionTag?.Invoke();
  }
}
