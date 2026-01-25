using SMIS.Entities.Models;
using System.Collections.Generic;

namespace SMIS.BLL.Interface
{
    public interface IParentStudentService
    {
        List<ParentStudent> GetStudentsByParentId(int parentId);
    }
}
