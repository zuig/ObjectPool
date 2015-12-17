
namespace Qtz.Q6.PoolUtil
{
    /**
     * Copyright (c) 2015,广州擎天柱网络科技有限公司
 
     * All rights reserved.
     *
     * 文件名称：AutoRestoreObject.cs
     * 简    述：可主动回收的对象。
     * 创建标识：Zon 2015/12/15

     * 修改描述：XXX
     * 修改标识：Zon 2015/12/15	
     */

    public class AutoRestoreObject<T> : IAutoRestoreObject<T>
    {
        
        private T t;

        public AutoRestoreObject(T t)
        {
            this.t = t;
        }

        public IAutoRestoreChecker Restore { get; set; }

        public T Get()
        {
            return t;
        }
    }
}
