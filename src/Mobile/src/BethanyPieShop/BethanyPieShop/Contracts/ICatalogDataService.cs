using BethanyPieShop.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BethanyPieShop.Core.Contracts
{
    public interface ICatalogDataService
    {
        Task<IList<Pie>> GetAllPiesAsync();
    }
}