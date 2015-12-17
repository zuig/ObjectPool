﻿using System;
using System.Collections.Generic;

namespace Qtz.Q6.PoolUtil
{
    /**
     * Copyright (c) 2015,广州擎天柱网络科技有限公司

     * All rights reserved.
     *
     * 文件名称：BaseObjectPool.cs
     * 简    述：基础对象池实现 
     * 创建标识：Zon 2015/12/15

     * 修改描述：XXX
     * 修改标识：Zon 2015/12/15	
     */
    public class BaseObjectPool<T> : IObjectPool<T>
    {
        private readonly List<T> pools = new List<T>();
        private readonly IObjectFactory<T> factory;

        /// <summary>
        /// 最大可达到的空闲对象数目
        /// </summary>
        private readonly int maxIdleNum;

        private int activeNum = 0;

        public BaseObjectPool(IObjectFactory<T> factory, int maxIdleNum)
        {
            if (factory == null)
            {
                throw new ObjectPoolExeception("factory can not be null");
            }
            this.factory = factory;
            this.maxIdleNum = maxIdleNum;
        }

        public T Take()
        {
            T t;

            if (pools.Count == 0)
            {
                t = factory.CreateObject(true);
            }
            else
            {
                t = pools[0];
                factory.ActivateObject(t);
                pools.RemoveAt(0);
            }
            
            activeNum++;
            return t;
        }

        /// <summary>
        /// 将一个指定对象返回对象池，如果对象池已达到空闲对象上限，则指定对象直接被工厂销毁。
        /// </summary>
        /// <param name="t"></param>
        public void Restore(T t)
        {
            if (pools.Count >= maxIdleNum)
            {
                factory.DestroyObject(t);
            }
            else
            {
                factory.UnActivateObject(t);
                pools.Add(t);
            }
            activeNum--;
        }

        /// <summary>
        /// 如果池没达到空闲对象上限，则往池中增加一个对象。
        /// 如果池已经达到空闲对象上限，则不进行任何处理。
        /// </summary>
        public void AddObject()
        {
            if (pools.Count < maxIdleNum){
                T t = factory.CreateObject(false);
                pools.Add(t);
            }
        }

        public int IdleNum()
        {
            return pools.Count;
        }

        public int ActiveNum()
        {
            return activeNum;
        }

        public void Clear()
        {
            foreach (T t in pools)
            {
                factory.DestroyObject(t);
            }
            pools.Clear();
        }
    }
}
