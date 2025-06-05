// Decompiled with JetBrains decompiler
// Type: FadeScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public class FadeScreen : MonoBehaviour
{
  public bool fadeOnStart = true;
  public float fadeDuration = 2f;
  public Color fadeColor;
  public AnimationCurve fadeCurve;
  public string colorPropertyName = "_Color";
  private Renderer rend;

  private void Start()
  {
    this.rend = this.GetComponent<Renderer>();
    this.rend.enabled = false;
    if (!this.fadeOnStart)
      return;
    this.FadeIn();
  }

  public void FadeIn() => this.Fade(1f, 0.0f);

  public void FadeOut() => this.Fade(0.0f, 1f);

  public void Fade(float alphaIn, float alphaOut)
  {
    this.StartCoroutine(this.FadeRoutine(alphaIn, alphaOut));
  }

  public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
  {
    this.rend.enabled = true;
    float timer = 0.0f;
    while ((double) timer <= (double) this.fadeDuration)
    {
      Color newColor = this.fadeColor with
      {
        a = Mathf.Lerp(alphaIn, alphaOut, this.fadeCurve.Evaluate(timer / this.fadeDuration))
      };
      this.rend.material.SetColor(this.colorPropertyName, newColor);
      timer += Time.deltaTime;
      yield return (object) null;
      newColor = new Color();
    }
    Color newColor2 = this.fadeColor with { a = alphaOut };
    this.rend.material.SetColor(this.colorPropertyName, newColor2);
    if ((double) alphaOut == 0.0)
      this.rend.enabled = false;
  }
}
