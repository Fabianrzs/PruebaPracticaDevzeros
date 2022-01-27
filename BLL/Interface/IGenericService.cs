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
        GenericlogResponse<TEntiy> Save(TEntiy entity);
        GenericlogResponse<TEntiy> Update(int codEntity, TEntiy entity);
        GenericlogResponse<TEntiy> Find(int codEntity);
        string Delete(int codEntity);
        GenericConsultResponse<TEntiy> Consult();
    }
}
