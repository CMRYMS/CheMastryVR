// Decompiled with JetBrains decompiler
// Type: SceneTransitionManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class SceneTransitionManager : MonoBehaviour
{
  public FadeScreen fadeScreen;
  public static SceneTransitionManager singleton;

  private void Awake()
  {
    if ((bool) (Object) SceneTransitionManager.singleton && (Object) SceneTransitionManager.singleton != (Object) this)
      Object.Destroy((Object) SceneTransitionManager.singleton);
    SceneTransitionManager.singleton = this;
  }

  public void GoToScene(int sceneIndex) => this.StartCoroutine(this.GoToSceneRoutine(sceneIndex));

  private IEnumerator GoToSceneRoutine(int sceneIndex)
  {
    this.fadeScreen.FadeOut();
    yield return (object) new WaitForSeconds(this.fadeScreen.fadeDuration);
    SceneManager.LoadScene(sceneIndex);
  }

  public void GoToSceneAsync(int sceneIndex)
  {
    this.StartCoroutine(this.GoToSceneAsyncRoutine(sceneIndex));
  }

  private IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
  {
    this.fadeScreen.FadeOut();
    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    operation.allowSceneActivation = false;
    float timer = 0.0f;
    while ((double) timer <= (double) this.fadeScreen.fadeDuration && !operation.isDone)
    {
      timer += Time.deltaTime;
      yield return (object) null;
    }
    operation.allowSceneActivation = true;
  }
}
