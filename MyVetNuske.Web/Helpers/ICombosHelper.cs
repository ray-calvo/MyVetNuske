using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyVetNuske.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboPetTypes();
        IEnumerable<SelectListItem> GetComboRaceTypes();
        IEnumerable<SelectListItem> GetComboServiceTypes();

    }
}