
namespace SmartCampus.Log
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Text;

    /// <summary>
    /// Logger序列
    /// 
    /// 备用
    /// 
    /// </summary>
    public class LoggerCollection : ICollection
    {
        #region private field
        /// <summary>
        /// 默认容量
        /// </summary>
        private static readonly int DEFAULT_CAPACITY = 16;
        /// <summary>
        /// 日志logger数组
        /// </summary>
        private ILogger[] loggerArray;
        /// <summary>
        /// 序列个数
        /// </summary>
        private int count = 0;
        /// <summary>
        /// 序列版本
        /// </summary>
        private int version = 0;
        #endregion

        /// <summary>
        /// 版本
        /// </summary>
        public int Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;
            }
        }
        /// <summary>
        /// 序列容量
        /// </summary>
        private int capacity = DEFAULT_CAPACITY;
        /// <summary>
        /// 容量
        /// </summary>
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public LoggerCollection()
            : this(DEFAULT_CAPACITY)
        {
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="capacity">容量</param>
        public LoggerCollection(int capacity)
        {
            loggerArray = new ILogger[capacity];
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="a">日志Logger数据</param>
        public LoggerCollection(ILogger[] a)
        {
            loggerArray = new ILogger[a.Length];
            if (count + a.Length >= loggerArray.Length)
            {
                EnsureCapacity(count + a.Length);
            }
            Array.Copy(a, 0, loggerArray, count, a.Length);
            count += a.Length;
            version++;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="c">日志Logger序列</param>
        public LoggerCollection(LoggerCollection c)
        {
            loggerArray = new ILogger[c.Count];
            if (count + c.count >= loggerArray.Length)
            {
                EnsureCapacity(count + c.count);
            }
            Array.Copy(c.loggerArray, 0, loggerArray, count, c.count);
            count += c.count;
            version++;
        }
        #endregion

        #region Item operate
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>日志Logger</returns>
        public virtual ILogger this[int index]
        {
            get
            {
                ValidateIndex(index); // throws
                return loggerArray[index];
            }
            set
            {
                ValidateIndex(index); // throws
                ++version;
                loggerArray[index] = value;
            }
        }
        /// <summary>
        /// 增加元素
        /// </summary>
        /// <param name="item">Logger对象</param>
        /// <returns>记录个数</returns>
        public virtual int Add(ILogger item)
        {
            if (count == loggerArray.Length)
            {
                EnsureCapacity(count + 1);
            }

            loggerArray[count] = item;
            version++;

            return count++;
        }
        /// <summary>
        /// 清除所有元素
        /// </summary>
        public virtual void Clear()
        {
            ++version;
            loggerArray = new ILogger[DEFAULT_CAPACITY];
            count = 0;
        }
        #endregion

        #region Implementation (ICollection)
        /// <summary>
        /// 记录个数
        /// </summary>
        public virtual int Count
        {
            get
            {
                return count;
            }
        }
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="array">源数组</param>
        /// <param name="start">开始位置</param>
        void ICollection.CopyTo(Array array, int start)
        {
            if (count > array.GetUpperBound(0) + 1 - start)
            {
                throw new System.ArgumentException("目标数据长度不足");
            }
            Array.Copy(loggerArray, 0, array, start, count);
        }
         /// <summary>
         /// 是否异步
         /// </summary>
        public virtual bool IsSynchronized
        {
            get
            {
                return loggerArray.IsSynchronized;
            }
        }
        /// <summary>
        /// 异步对象
        /// </summary>
        public virtual object SyncRoot
        {
            get
            {
                return loggerArray.SyncRoot;
            }
        }
        /// <summary>
        /// 获得迭代器
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerator GetEnumerator()
        {
            return new LoggerCollectionEnumerator(this);
        }
        #endregion

        #region private method
        /// <summary>
        /// 容量分配
        /// </summary>
        /// <param name="min">最小容量</param>
        private void EnsureCapacity(int min)
        {
            int newCapacity = ((loggerArray.Length == 0) ? DEFAULT_CAPACITY : loggerArray.Length * 2);
            if (newCapacity < min)
            {
                newCapacity = min;
            }

            this.capacity = newCapacity;
        }
        /// <summary>
        /// 验证索引有效性
        /// </summary>
        /// <param name="i">索引</param>
        private void ValidateIndex(int i)
        {
            ValidateIndex(i, false);
        }

        /// <summary>
        /// 验证索引有效性
        /// </summary>
        /// <param name="i">索引</param>
        /// <param name="allowEqualEnd"></param>
        private void ValidateIndex(int i, bool allowEqualEnd)
        {
            int max = (allowEqualEnd) ? (count) : (count - 1);
            if (i < 0 || i > max)
            {
                throw new ArgumentOutOfRangeException("i", (object)i, "索引越界 [" + (object)i + "] ");
            }
        }
        #endregion
    }
}