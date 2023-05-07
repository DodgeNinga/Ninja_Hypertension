using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CutScene : MonoBehaviour
{

    protected CutSceneEvent thisCutScene;

    public virtual void GetCutScene(CutSceneEvent cutScene)
    {

        thisCutScene = cutScene;

    }

    public abstract void StartCutScene();
    public abstract void EndCutScene();

}
