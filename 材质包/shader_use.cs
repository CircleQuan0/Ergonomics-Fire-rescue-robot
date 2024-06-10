using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderUse : MonoBehaviour
    {
        public Color mainColor = Color.white;
        public Texture2D mainTexture;
        public Texture2D bumpMap;
        public Color rimColor = new Color(0.26f, 0.19f, 0.16f, 0);
        public float rimPower = 3.0f;

        private Material material;

        void Start()
        {
            // 创建一个新的材质并应用自定义Shader
            material = new Material(Shader.Find("Custom/RimLighting"));

            // 设置材质的属性
            material.SetColor("_MainColor", mainColor);
            material.SetTexture("_MainTex", mainTexture);
            material.SetTexture("_BumpMap", bumpMap);
            material.SetColor("_RimColor", rimColor);
            material.SetFloat("_RimPower", rimPower);

            // 将材质应用到GameObject的Renderer组件
            GetComponent<Renderer>().material = material;
        }

        void Update()
        {
            // 在Update中可以动态修改材质的属性
            // 例如根据游戏状态动态调整边缘光效果
            material.SetColor("_RimColor", rimColor);
            material.SetFloat("_RimPower", rimPower);
        }
    }



