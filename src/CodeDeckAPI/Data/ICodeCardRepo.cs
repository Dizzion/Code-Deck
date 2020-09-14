using System.Collections.Generic;
using CodeDeckAPI.Models;

namespace CodeDeckAPI.Data
{
    public interface ICodeCardRepo
    {
         bool SaveChanges();

         IEnumerable<CodeCard> GetAllCards();

         CodeCard GetCodeCardById(int id);

         void CreateCodeCard(CodeCard cc);
         void UpdateCodeCard(CodeCard cc);
    }
}