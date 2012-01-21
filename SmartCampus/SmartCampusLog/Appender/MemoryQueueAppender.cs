
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;

    /// <summary>
    /// 内存队列Appender
    /// </summary>
    public class MemoryQueueAppender : IAppender
    {
        /// <summary>
        /// 缓存数据队列
        /// </summary>
        private Queue queue = Queue.Synchronized(new Queue()) ;
        /// <summary>
        ///  默认最大缓存容量
        /// </summary>
        private const int MaxSize = 10000;
        /// <summary>
        /// 默认最小缓存容量
        /// </summary>
        private const int MinSize = 10;
        /// <summary>
        /// 缓存数据容量
        /// </summary>
        private int Size = MinSize;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="queueSize"></param>
        public MemoryQueueAppender(int queueSize)
        {
            Size = queueSize > MaxSize ? MaxSize : queueSize;
            Size = Size < MinSize ? MinSize : Size;        
        }
        /// <summary>
        /// 增加对象到队列尾部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void AddTail<T>(T obj)  where T : LogEventData
        {
            lock (queue.SyncRoot)
            {
                while (queue.Count >= Size)
                    queue.Dequeue();
                
                queue.Enqueue(obj);
            }
        }
        /// <summary>
        /// 获取比指定日期大的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">指定日期</param>
        /// <returns></returns>
        public ArrayList GetList<T>(DateTime dt)   where T : LogEventData
        {
            ArrayList al = new ArrayList();
            lock (queue.SyncRoot)
            {
                if (queue.Count > 0)
                {
                    al.AddRange(queue.ToArray());
                }
            }
            foreach (T o in al)
            {
                if (o.CreateDate > dt)
                    break;
                else
                    al.Remove(o);
            }
            return al ;
        }
         /// <summary>
        /// 获取比指定序号大的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sn">序号</param>
        /// <returns></returns>
        public ArrayList GetList<T>(long sn)   where T : LogEventData
        {
            ArrayList al = new ArrayList();
            lock (queue.SyncRoot)
            {
                if (queue.Count > 0)
                {
                    al.AddRange(queue.ToArray());
                }
            }
            if (sn == 0)
                return al;

            foreach (T o in al)
            {
                if (o.SN > sn)
                    break;
                else
                    al.Remove(o);
            }
            return al ;
        }   
        /// <summary>
        /// 从队列头部删除单个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ojb"></param>
        /// <returns></returns>
        public T RemoveHead<T>(T ojb) where T : LogEventData
        {
            lock (queue.SyncRoot)
            {                         
                return (T)queue.Dequeue();  
            }
        }
        /// <summary>
        /// 清除队列所有对象
        /// </summary>
        public void Clear()
        {
            lock (queue.SyncRoot)
            {
                queue.Clear();
            }
        }
    }
}
