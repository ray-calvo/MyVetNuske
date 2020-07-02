using Microsoft.AspNetCore.Mvc.Rendering;
using MyVetNuske.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace MyVetNuske.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IEnumerable<SelectListItem> GetComboPetTypes()
        {
            var list = _dataContext.PetTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            })
                .OrderBy(pt => pt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a pet type...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboRaceTypes()
        {
            var list = _dataContext.RaceTypes.Select(rt => new SelectListItem
            {
                Text = rt.Name,
                Value = $"{rt.Id}"
            })
                .OrderBy(rt => rt.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Select a race type...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboServiceTypes()
        {
            var list = _dataContext.ServiceTypes.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).OrderBy(p => p.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a service type...)",
                Value = "0"
            });

            return list;
        }


    }
}
