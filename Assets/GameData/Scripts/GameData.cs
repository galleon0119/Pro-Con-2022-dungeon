using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    // Start is called before the first frame update
    private void InitGame()
    {

        Debug.Log("Init Game");
    }
    /// <summary>
    /// ���݂̃Q�[���V�[�����ēǂݍ���
    /// </summary>
    /// <returns></returns>
    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1.0f);

        // ���݂̃Q�[���V�[�����擾���A�V�[���̖��O���g����LoadScene�������s��(�ēx�A�����Q�[���V�[�����Ăяo��)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // ������ GameData�Q�[���I�u�W�F�N�g�̓V�[���J�ڂ��Ă��j������Ȃ��ݒ�ɂȂ��Ă��܂��̂ŁA�����ōēx�A�������̏������s���K�v������܂��B
        InitGame();
    }
}
