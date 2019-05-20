namespace Vli.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 插入单条数据
        /// </summary>
        /// <param name="entity"></param>
        T Insert(T entity);

        /// <summary>
        /// 更新单条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// 通过ID删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteById(int id);

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntityById(int id);
    }
}
