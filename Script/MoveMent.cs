using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    [SerializeField] float recordTimmer;   // 记录时间间隔
    [SerializeField] Transform target_head;    // 记录头部位置和旋转的目标
    [SerializeField] Transform target_body;    // 记录身体位置和旋转的目标

    // 跨物体读取
    [SerializeField] GameObject NPC_1;    // 其他物体的引用，例如：GameObject.Find("XXX").GetComponent<脚本>().变量;

    float timmer;   // 计时器
    string targetDataAll;
    string targetDataAll_1;// 所有记录的数据


    float totalCollisionTime = 0f; // 物体发生碰撞的总时长
    int collisionCount = 0; // 物体碰撞的总次数

    private void Start()
    {
        timmer = recordTimmer;   // 初始化计时器
    }

    bool isEnd = false;
    int dataallending = 0;
    void Presstoend()
    {
        // 按下 F2 键结束记录
        if (Input.GetKey(KeyCode.F2) && !isEnd)
        {
            dataallending += 1;
            print("Getting to ending data\n");
            if (dataallending == 5)
            {
                print("END!\n");
                isEnd = true;
            }
            return;
        }
        if (isEnd)
        {
            // 保存记录到文件
            string filePath = Application.streamingAssetsPath;
            Debug.Log("filePath:" + filePath);
            string fileName = System.DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "").Trim() + System.DateTime.Now.ToString("hh:mm:ss").Replace(":", "").Trim() + ".txt";
            CreateTextToFile(filePath, fileName, targetDataAll);
            isEnd = false;
        }
    }

    // 启动标志
    int datastartstreaming = 0;
    private void Update()
    {
        // 长按 F1 键触发计时开始
        if (Input.GetKey(KeyCode.F1) && datastartstreaming < 6)
        {
            datastartstreaming += 1;
            print("Getting to streaming data\n");
            if (datastartstreaming == 5) print("start!\n");
        }


        if (datastartstreaming >= 5)
        {
            // 碰撞检测
           
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {

                totalCollisionTime += Time.deltaTime; // 累计碰撞时长
                collisionCount++; // 增加碰撞次数

                              // 记录碰撞信息，包括累计碰撞次数和碰撞时长
                        string collisionData = "碰撞物体名称：" + hit.collider.gameObject.name +
                        "，碰撞次数：" + collisionCount + "碰撞时长：" + Time.deltaTime + "秒" +
                        "，碰撞总时长：" + totalCollisionTime + "秒";
                targetDataAll_1 += collisionData + "\n";





                }
            
            // 记录目标对象的位置和旋转信息
            timmer -= Time.deltaTime;
            if (timmer < 0)
            {
                timmer = recordTimmer;
                string data = GetTargetStr(target_body.position, target_body.eulerAngles, target_head.eulerAngles) + "\n";
                targetDataAll += data;
            }
        }
        Presstoend();
    }

    /// <summary>
    /// 创建文件
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="fileName"></param>
    /// <param name="data"></param>
    public void CreateTextToFile(string filePath, string fileName, string data)
    {
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        if (!Directory.Exists(filePath + "\\All")) Directory.CreateDirectory(filePath + "\\All");

        string fileAllPath = Path.Combine(filePath + "\\All", fileName);

        StreamWriter swAll = new StreamWriter(fileAllPath, false, Encoding.UTF8);
        swAll.WriteLine(targetDataAll);
        swAll.WriteLine(targetDataAll_1);
        swAll.Close();
        swAll.Dispose();
    }

    /// <summary>
    /// 获取目标对象的位置和旋转信息字符串
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="angle_body"></param>
    /// <param name="angle_head"></param>
    /// <returns></returns>
    string GetTargetStr(Vector3 pos, Vector3 angle_body, Vector3 angle_head)
    {
        string value = "";
        value ="位置X："+ pos.x + ","+"  位置Y：" + pos.y + ","+ "  位置Z："+ pos.z + "," +"  身体角度："+ angle_body.y + ","+"  头部角度：" + angle_head.x;
        return value;

    }
}
