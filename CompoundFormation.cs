// Decompiled with JetBrains decompiler
// Type: CompoundFormation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CompoundFormation : MonoBehaviour
{
  public GameObject H2O;
  public GameObject KNO3;
  public GameObject NaHCO3;

  private void Start()
  {
    this.H2O.SetActive(false);
    this.KNO3.SetActive(false);
    this.NaHCO3.SetActive(false);
  }

  public void BestMatchCompound()
  {
    if (GameManager.bestMatch == "H2O")
    {
      this.H2O.SetActive(true);
      this.KNO3.SetActive(false);
      this.NaHCO3.SetActive(false);
    }
    if (GameManager.bestMatch == "KNO3")
    {
      this.KNO3.SetActive(true);
      this.NaHCO3.SetActive(false);
      this.H2O.SetActive(false);
    }
    if (!(GameManager.bestMatch == "NaHCO3"))
      return;
    this.NaHCO3.SetActive(true);
    this.H2O.SetActive(false);
    this.KNO3.SetActive(false);
  }

  private void Update() => this.BestMatchCompound();
}
