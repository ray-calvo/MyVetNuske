using MyVetNuske.Web.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyVetNuske.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRaceTypeAsync();
            await CheckPetTypesAsync();
            await CheckServiceTypesAsync();
            await CheckOwnersAsync();
            await CheckPetsAsync();
            await CheckAgendasAsync();
           
        }

        private async Task CheckRaceTypeAsync()
        {
            if (!_context.RaceTypes.Any())
            {
                _context.RaceTypes.Add(new RaceType { Name = "Affenpinscher" });
                _context.RaceTypes.Add(new RaceType { Name = "Airedale terrier" });
                _context.RaceTypes.Add(new RaceType { Name = "Boyero de Appenzell" });



                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPetsAsync()
        {
            var owner = _context.Owners.FirstOrDefault();
            var petType = _context.PetTypes.FirstOrDefault();
            var raceType = _context.RaceTypes.FirstOrDefault();
            if (!_context.Pets.Any())
            {
                AddPet("Otto", owner, petType, raceType);
                AddPet("Killer", owner, petType, raceType);
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckServiceTypesAsync()
        {
            if (!_context.ServiceTypes.Any())
            {
                _context.ServiceTypes.Add(new ServiceType { Name = "Consulta" });
                _context.ServiceTypes.Add(new ServiceType { Name = "Urgencia" });
                _context.ServiceTypes.Add(new ServiceType { Name = "Vacunación" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPetTypesAsync()
        {
            if (!_context.PetTypes.Any())
            {
                _context.PetTypes.Add(new PetType { Name = "Perro" });
                _context.PetTypes.Add(new PetType { Name = "Gato" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckOwnersAsync()
        {
            if (!_context.Owners.Any())
            {
                AddOwner("Raymundo", "Calvo", "4433246136", "4431731758", "4to retorno de los olivos #79 Los Olivos Bosque Monarca");
                AddOwner("Guillermo", "Calvo", "4433246136", "4433953397", "Retorno Juan Antonio Riaño #21");
                AddOwner("Israel", "Calderon", "4433246136", "4432205280", "Calle Luna Calle Sol");
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string firstName, string lastName, string fixedPhone, string cellPhone, string address)
        {
            _context.Owners.Add(new Owner
            {
                Address = address,
                CellPhone = cellPhone,
                FirstName = firstName,
                FixedPhone = fixedPhone,
                LastName = lastName
            });
        }

        private void AddPet(string name, Owner owner, PetType petType, RaceType race)
        {
            _context.Pets.Add(new Pet
            {
                Born = DateTime.Now.AddYears(-2),
                Name = name,
                Owner = owner,
                PetType = petType,
                RaceType = race
            });
        }

        private async Task CheckAgendasAsync()
        {
            if (!_context.Agendas.Any())
            {
                var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);
                var finalDate = initialDate.AddYears(1);
                while (initialDate < finalDate)
                {
                    if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var finalDate2 = initialDate.AddHours(10);
                        while (initialDate < finalDate2)
                        {
                            _context.Agendas.Add(new Agenda
                            {
                                Date = initialDate.ToUniversalTime(),
                                IsAvailable = true
                            });

                            initialDate = initialDate.AddMinutes(30);
                        }

                        initialDate = initialDate.AddHours(14);
                    }
                    else
                    {
                        initialDate = initialDate.AddDays(1);
                    }
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
