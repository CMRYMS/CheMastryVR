// Decompiled with JetBrains decompiler
// Type: Elements
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Elements : MonoBehaviour
{
  public string ElementID;
  public GameObject ElectronConfig;

  private void Start() => Debug.Log((object) ("Generated " + this.ElementID));

  public void OnEnable()
  {
    if (this.ElementID == null || !((Object) GameManager.Instance != (Object) null))
      return;
    GameManager.Instance.AddElementToDictionary(this.ElementID);
  }

  public void ClearElements()
  {
    if (this.ElementID == null || !((Object) GameManager.Instance != (Object) null))
      return;
    GameManager.Instance.RemoveElementFromDictionary(this.ElementID);
  }

  private void OnDestroy() => this.ClearElements();
}
