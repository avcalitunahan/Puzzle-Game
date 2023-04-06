using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameBoard : MonoBehaviour
{
    public int m_size;
    public GameObject m_puzzlePiece;
    public GameObject PlayerNameWindow;

    public PuzzleSection[,] m_puzzle;
    public PuzzleSection m_puzzleSelection;
    public int m_randomPasses = 20;
    public int m_random2 = 66;
    public Button mixButton;
    public int moves;
    public Text movesvalue;
    private string path;

    public Text obj_text;
    public InputField display;
    public Text score_text;
    public int score;
    public Text record;

    public GameObject scorepanel;


    public void Create()
    {




        GameObject temp;
        m_puzzle = new PuzzleSection[m_size, m_size];

        for (int i = 0; i < m_size; i++)
        {
            for (int j = 0; j < m_size; j++)
            {
                temp = (GameObject)Instantiate(m_puzzlePiece,
                                 new Vector2((i * 900 / m_size), j * 900 / m_size), Quaternion.identity);
                temp.transform.SetParent(transform);

                m_puzzle[i, j] = (PuzzleSection)temp.GetComponent<PuzzleSection>();
                m_puzzle[i, j].CreatePuzzlePiece(m_size);

            }
        }

        m_puzzlePiece.SetActive(false);
        PlayerNameWindow.SetActive(false);
        SetupBoard();


    }

    public void RandomizePlacement()
    {
        movesvalue.text = "MOVES:" + moves;
        score_text.text = "SCORE:" + score;
        VectorInt2[] puzzleLocation = new VectorInt2[2];
        Vector2[] puzzleOffset = new Vector2[2];
        do
        {
            for (int i = 0; i < m_randomPasses; i++)
            {
                puzzleLocation[0].x = Random.Range(0, m_size);
                puzzleLocation[0].y = Random.Range(0, m_size);
                puzzleLocation[1].x = Random.Range(0, m_size);
                puzzleLocation[1].y = Random.Range(0, m_size);

                puzzleOffset[0] = m_puzzle[puzzleLocation[0].x, puzzleLocation[0].y].GetImageOffset();
                puzzleOffset[1] = m_puzzle[puzzleLocation[1].x, puzzleLocation[1].y].GetImageOffset();

                m_puzzle[puzzleLocation[0].x, puzzleLocation[0].y].AssignImage(puzzleOffset[1]);
                m_puzzle[puzzleLocation[1].x, puzzleLocation[1].y].AssignImage(puzzleOffset[0]);
            }

        } while (CheckBoard() == true);


    }

    public void SetupBoard()
    {
        Vector2 offset;
        Vector2 m_scale = new Vector2(1f / m_size, 1f / m_size);
        for (int i = 0; i < m_size; i++)
        {
            for (int j = 0; j < m_size; j++)
            {
                offset = new Vector2(i * (1f / m_size), j * (1f / m_size));
                m_puzzle[i, j].AssignImage(m_scale, offset);
            }
        }

    }

    public PuzzleSection GetSelection()
    {

        return m_puzzleSelection;

    }

    public void SetSelection(PuzzleSection selection)
    {
        m_puzzleSelection = selection;

       




    }

    public bool CheckBoard()
    {
        for (int i = 0; i < m_size; i++)
        {
            for (int j = 0; j < m_size; j++)
            {
                if (m_puzzle[i, j].CheckGoodPlacement() == false)
                {
                    return false;

                }
                else if (m_puzzle[i, j].CheckGoodPlacement() == true)
                {

                }

            }

        }

        return true;
    }

    public void Win()
    {
        Debug.Log("YOU WIN!");


    }
    public void StoreName()
    {
        obj_text.text = "PLAYER:" + display.text;
    }
    public void ButtonPassive()
    {
        VectorInt2[] puzzleLocation = new VectorInt2[2];
        Vector2[] puzzleOffset = new Vector2[2];
        do
        {
            for (int i = 0; i < m_random2; i++)
            {
                puzzleLocation[0].x = Random.Range(0, m_size);
                puzzleLocation[0].y = Random.Range(0, m_size);
                puzzleLocation[1].x = Random.Range(0, m_size);
                puzzleLocation[1].y = Random.Range(0, m_size);

                puzzleOffset[0] = m_puzzle[puzzleLocation[0].x, puzzleLocation[0].y].GetImageOffset();
                puzzleOffset[1] = m_puzzle[puzzleLocation[1].x, puzzleLocation[1].y].GetImageOffset();

                m_puzzle[puzzleLocation[0].x, puzzleLocation[0].y].AssignImage(puzzleOffset[1]);
                m_puzzle[puzzleLocation[1].x, puzzleLocation[1].y].AssignImage(puzzleOffset[0]);
            }

        } while (CheckBoard() == true);


        for (int i = 0; i < m_size; i++)
        {
            for (int j = 0; j < m_size; j++)
            {
                if (m_puzzle[i, j].CheckGoodPlacement() == true)
                {
                    mixButton.interactable = false;
                    mixButton.GetComponent<Image>().color = Color.red;

                }
                else
                {

                }

            }

        }

    }

    public void Save()
    {
        string path = Application.dataPath + "/enyuksekscore.txt";
        StreamWriter writer = new StreamWriter(path, true);
        string metin = movesvalue.text;
        string name = obj_text.text;
        score_text.text = "SCORE:"+score.ToString();
        
        writer.Write(name);
        writer.Write("    " + metin);
        writer.WriteLine("  " + score_text.text);
        writer.Close();


    }
    public void Scores()
    {

        string path = Application.dataPath + "/enyuksekscore.txt";
        StreamReader reader = new StreamReader(path);


        string content = reader.ReadToEnd();

        record.text = content;

        reader.Close();
        scorepanel.SetActive(true);
    }
    public void ScorePanel()
    {
        scorepanel.SetActive(false);
    }

}

        
    
    







