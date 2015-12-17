using UnityEngine;
using Qtz.Q6.PoolUtil;
namespace Qtz.Q6.PoolUtil.U3D
{
    /**
     * Copyright (c) 2015,广州擎天柱网络科技有限公司

     * All rights reserved.
     *
     * 文件名称：U3DAutoRestoreObjectPool.cs
     * 简    述：对象池组件，可以挂在U3D对象上
     * 创建标识：Zon 2015/12/15

     * 修改描述：XXX
     * 修改标识：Zon 2015/12/15	
     */
    public class U3DAutoRestoreObjectPool : MonoBehaviour, IActiveRestoreObjectPool<GameObject>
    {
        private ActiveRestoreObjectPool<GameObject> pool;

        public GameObject prefab;
        public int maxNum;
        public int initNum;

        private static int idGenerate;
        private int _id = -1;
        private int id
        {
            get
            {
                if (_id == -1)
                {
                    _id = idGenerate;
                    idGenerate++;
                }
                return _id;
            }
        }

        void Awake()
        {
            pool = new ActiveRestoreObjectPool<GameObject>(new PrefabFactory(prefab), maxNum);
            if (initNum > maxNum)
            {
                initNum = maxNum;
            }
            for (int i = 0; i < initNum; i++)
            {
                pool.AddObject();
            }
        }
#if UNITY_EDITOR
        void OnGUI()
        {
            int y = 10+40*id;
            GUI.Label(new Rect(10, y, 300, 20),  "Idle num in pools#"+gameObject.name+"  : " + pool.IdleNum());
            GUI.Label(new Rect(10, y+20, 300, 20), "Active num in pools#"+gameObject.name+" : " + pool.ActiveNum());
        }
#endif

        public void Update()
        {
            pool.CheckRestore();
        }

        public IAutoRestoreObject<GameObject> Take()
        {
            return pool.Take();
        }

        public void Restore(IAutoRestoreObject<GameObject> t)
        {
            pool.Restore(t);
        }

        public void AddObject()
        {
            pool.AddObject();
        }

        public int IdleNum()
        {
            return pool.IdleNum();
        }

        public int ActiveNum()
        {
            return pool.ActiveNum();
        }

        public void Clear()
        {
            pool.Clear();
        }

        public void CheckRestore()
        {
            pool.CheckRestore();
        }
    }
}
