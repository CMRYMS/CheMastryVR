// Decompiled with JetBrains decompiler
// Type: WhenTilted
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.Events;

#nullable disable
public class WhenTilted : MonoBehaviour
{
  private const float BufferAngle = 0.05f;
  [SerializeField]
  private float AngleThreshold = 0.4f;
  [SerializeField]
  private Transform GameObjTarget;
  [SerializeField]
  private Transform GameObjUpSource;
  [SerializeField]
  private UnityEvent OnEventBegin = new UnityEvent();
  [SerializeField]
  private UnityEvent OnEventEnd = new UnityEvent();
  private bool IsWithinThreshold;

  private void Update() => this.CheckTilt();

  public UnityEvent e_onBegin => this.OnEventBegin;

  public UnityEvent e_onEnd => this.OnEventEnd;

  private void CheckTilt()
  {
    float num = Mathf.InverseLerp(-1f, 1f, Vector3.Dot(-((Object) this.GameObjTarget != (Object) null ? this.GameObjTarget.up : this.transform.up), (Object) this.GameObjUpSource != (Object) null ? this.GameObjUpSource.up : Vector3.up));
    bool flag = (!this.IsWithinThreshold ? (double) (num - 0.05f) : (double) (num + 0.05f)) >= (double) this.AngleThreshold;
    if (this.IsWithinThreshold == flag)
      return;
    this.IsWithinThreshold = flag;
    if (this.IsWithinThreshold)
      this.OnEventBegin.Invoke();
    else
      this.OnEventEnd.Invoke();
  }
}
