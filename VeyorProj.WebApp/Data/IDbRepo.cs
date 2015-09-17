using System.Collections.Generic;
using VeyorProj.WebApp.Models.Entity;

namespace VeyorProj.WebApp.Data
{
    public interface IDbRepo
    {
        List<item> GetItems();
        item GetItem(int rowid);
        void AddItem(item input);
        void UpdateItem(item input);
        void DeleteItem(int rowid);
    }
}