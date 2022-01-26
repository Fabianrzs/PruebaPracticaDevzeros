using BLL.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IGenericService<TEntiy> where TEntiy : class
    {
        Task<GenericlogResponse<TEntiy>> SaveAsync(TEntiy entity);
        Task<GenericlogResponse<TEntiy>> UpdateAsync(int codEntity, TEntiy entity);
        GenericlogResponse<TEntiy> Find(int codEntity);
        Task<string> DeleteAsync(int codEntity);
        GenericConsultResponse<TEntiy> Consult();
    }
}
