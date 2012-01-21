
namespace SmartCampus.Log 
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Collections;

    /// <summary>
    /// Logger迭代器
    /// 
    /// 备用
    /// </summary>
    public class LoggerCollectionEnumerator : IEnumerator
    {
        #region private
        private readonly LoggerCollection collection;
        private int index;
        private int version;
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="lc">日志序列</param>
        internal LoggerCollectionEnumerator(LoggerCollection lc)
        {
            collection = lc;
            index = -1;
            version = lc.Version;
        }
        #endregion

        #region Implementation (IEnumerator)
        /// <summary>
        /// 当前对象
        /// </summary>
        public ILogger Current
        {
            get
            {
                return collection[index];
            }
        }
        /// <summary>
        /// 移动到下一个
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (version != collection.Version)
            {
                throw new System.InvalidOperationException("序列被修改; 枚举操作无法进行.");
            }

            ++index;
            return (index < collection.Count);
        }
        /// <summary>
        /// 复位
        /// </summary>
        public void Reset()
        {
            index = -1;
        }
        /// <summary>
        /// 当前对象
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }
        #endregion
    }
}
