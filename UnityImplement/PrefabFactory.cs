using UnityEngine;

namespace Qtz.Q6.PoolUtil.U3D
{
    /**
     * Copyright (c) 2015,广州擎天柱网络科技有限公司

     * All rights reserved.
     *
     * 文件名称：PrefabFactory.cs
     * 简    述：U3D预设-对象池工厂
     * 创建标识：Zon 2015/12/15

     * 修改描述：XXX
     * 修改标识：Zon 2015/12/15	
     */
    public class PrefabFactory : IObjectFactory<GameObject>
    {
        private GameObject prefab;
        private Transform parent;

        public PrefabFactory(GameObject prefab, Transform parent)
        {
            this.prefab = prefab;
            this.parent = parent;
        }

        public PrefabFactory(GameObject prefab)
        {
            this.prefab = prefab;
        }

        public GameObject CreateObject(bool doActive)
        {
            GameObject go = GameObject.Instantiate(prefab) as GameObject;
            if (parent != null)
            {
                go.transform.parent = parent;
            }
            go.transform.localPosition = Vector3.zero;
            if (doActive)
            {
                ActivateObject(go);
            }
            else
            {
                go.SetActive(false);
            }
            return go;
        }

        public void DestroyObject(GameObject t)
        {
            GameObject.Destroy(t);
        }

        public void ActivateObject(GameObject t)
        {
            t.SetActive(true);
        }

        public void UnActivateObject(GameObject t)
        {
            t.SetActive(false);
        }
    }
}
