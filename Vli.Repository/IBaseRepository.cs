using System.Threading.Tasks;

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
        bool DeleteById(long id);

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetEntityById(long id);

        /// <summary>
        /// 根据实体条件查找数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        T Find(object obj);

        Task<T> UpdateAsync(T entity);
    }
}
