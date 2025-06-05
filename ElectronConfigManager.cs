// Decompiled with JetBrains decompiler
// Type: ElectronConfigManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

#nullable disable
public class ElectronConfigManager : MonoBehaviour
{
  public XRSocketInteractor socket;
  public GameObject H_ElectConfig;
  public GameObject C_ElectConfig;
  public GameObject N_ElectConfig;
  public GameObject O_ElectConfig;
  public GameObject Na_ElectConfig;
  public GameObject Cl_ElectConfig;
  public GameObject K_ElectConfig;

  private void Update()
  {
    this.H_ElectConfig.SetActive(false);
    this.C_ElectConfig.SetActive(false);
    this.N_ElectConfig.SetActive(false);
    this.O_ElectConfig.SetActive(false);
    this.Na_ElectConfig.SetActive(false);
    this.Cl_ElectConfig.SetActive(false);
    this.K_ElectConfig.SetActive(false);
    if (this.socket.hasSelection)
    {
      GameObject gameObject = this.socket.GetOldestInteractableSelected().transform.gameObject;
      if (gameObject.tag == "H")
      {
        this.H_ElectConfig.SetActive(true);
        this.C_ElectConfig.SetActive(false);
        this.N_ElectConfig.SetActive(false);
        this.O_ElectConfig.SetActive(false);
        this.Na_ElectConfig.SetActive(false);
        this.Cl_ElectConfig.SetActive(false);
        this.K_ElectConfig.SetActive(false);
      }
      else if (gameObject.tag == "C")
      {
        this.H_ElectConfig.SetActive(false);
        this.C_ElectConfig.SetActive(true);
        this.N_ElectConfig.SetActive(false);
        this.O_ElectConfig.SetActive(false);
        this.Na_ElectConfig.SetActive(false);
        this.Cl_ElectConfig.SetActive(false);
        this.K_ElectConfig.SetActive(false);
      }
      else if (gameObject.tag == "N")
      {
        this.H_ElectConfig.SetActive(false);
        this.C_ElectConfig.SetActive(false);
        this.N_ElectConfig.SetActive(true);
        this.O_ElectConfig.SetActive(false);
        this.Na_ElectConfig.SetActive(false);
        this.Cl_ElectConfig.SetActive(false);
        this.K_ElectConfig.SetActive(false);
      }
      else if (gameObject.tag == "O")
      {
        this.H_ElectConfig.SetActive(false);
        this.C_ElectConfig.SetActive(false);
        this.N_ElectConfig.SetActive(false);
        this.O_ElectConfig.SetActive(true);
        this.Na_ElectConfig.SetActive(false);
        this.Cl_ElectConfig.SetActive(false);
        this.K_ElectConfig.SetActive(false);
      }
      else if (gameObject.tag == "Na")
      {
        this.H_ElectConfig.SetActive(false);
        this.C_ElectConfig.SetActive(false);
        this.N_ElectConfig.SetActive(false);
        this.O_ElectConfig.SetActive(false);
        this.Na_ElectConfig.SetActive(true);
        this.Cl_ElectConfig.SetActive(false);
        this.K_ElectConfig.SetActive(false);
      }
      else if (gameObject.tag == "Cl")
      {
        this.H_ElectConfig.SetActive(false);
        this.C_ElectConfig.SetActive(false);
        this.N_ElectConfig.SetActive(false);
        this.O_ElectConfig.SetActive(false);
        this.Na_ElectConfig.SetActive(false);
        this.Cl_ElectConfig.SetActive(true);
        this.K_ElectConfig.SetActive(false);
      }
      else
      {
        if (!(gameObject.tag == "K"))
          return;
        this.H_ElectConfig.SetActive(false);
        this.C_ElectConfig.SetActive(false);
        this.N_ElectConfig.SetActive(false);
        this.O_ElectConfig.SetActive(false);
        this.Na_ElectConfig.SetActive(false);
        this.Cl_ElectConfig.SetActive(false);
        this.K_ElectConfig.SetActive(true);
      }
    }
    else
    {
      this.H_ElectConfig.SetActive(false);
      this.C_ElectConfig.SetActive(false);
      this.N_ElectConfig.SetActive(false);
      this.O_ElectConfig.SetActive(false);
      this.Na_ElectConfig.SetActive(false);
      this.Cl_ElectConfig.SetActive(false);
      this.K_ElectConfig.SetActive(false);
    }
  }
}
