using Microsoft.AspNetCore.Mvc;
using MyVetNuske.Web.Data.Entities;
using MyVetNuske.Web.Models;
using System.Threading.Tasks;

namespace MyVetNuske.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Pet> ToPetAsync(PetViewModel model, string path, bool b);
        PetViewModel ToPetViewModel(Pet pet);
        Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew);
        HistoryViewModel ToHistoryViewModel(History history);



    }
}