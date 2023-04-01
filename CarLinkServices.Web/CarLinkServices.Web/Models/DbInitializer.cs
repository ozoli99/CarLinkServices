namespace CarLinkServices.Web.Models
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            CarLinkServicesDbContext context = serviceProvider.GetRequiredService<CarLinkServicesDbContext>();

            context.Database.EnsureCreated();

            if (context.CarServices.Any())
                return;

            var cities = new City[]
            {
                new City { Name = "Budapest" },
                new City { Name = "Sopron" },
                new City { Name = "Miskolc" },
                new City { Name = "Debrecen" },
                new City { Name = "Szolnok" },
            };
            foreach (City city in cities)
            {
                context.Cities.Add(city);
            }
            context.SaveChanges();

            var carServices = new CarService[]
            {
                new CarService
                {
                    Name = "AutóMester Szerviz",
                    CityId = 1,
                },
                new CarService
                {
                    Name = "Gépjármű Guru",
                    CityId = 1,
                },
                new CarService
                {
                    Name = "AutoDoktor",
                    CityId = 1,
                },
                new CarService
                {
                    Name = "Megbízható Motorklinika",
                    CityId = 1,
                },
                new CarService
                {
                    Name = "Szupergyors Szerelő",
                    CityId = 2,
                },
                new CarService
                {
                    Name = "AutoTündér Szerviz",
                    CityId = 3,
                },
                new CarService
                {
                    Name = "SzervizCsoda",
                    CityId = 3,
                },
                new CarService
                {
                    Name = "Gondoskodó Gépkocsiszerviz",
                    CityId = 4,
                },
                new CarService
                {
                    Name = "MotorMania Szerviz",
                    CityId = 4,
                },
                new CarService
                {
                    Name = "Robogó Remekművek",
                    CityId = 5,
                },
            };
            foreach (CarService carService in carServices)
            {
                context.CarServices.Add(carService);
            }
            context.SaveChanges();

            var services = new Service[]
            {
                new Service
                {
                    Type = ServiceType.DefectRepair,
                    Description = "A defekt javítás egy olyan eljárás, amellyel egy sérült autógumi javítható, ha a sérülés nem túl súlyos.",
                    CarServiceId = 1,
                },
                new Service
                {
                    Type = ServiceType.TireChange,
                    Description = "Az abroncs csere egy olyan folyamat, amely során a régi vagy kopott gumiabroncsokat lecserélik újakra.",
                    CarServiceId = 1,
                },
                new Service
                {
                    Type = ServiceType.ClimateCharge,
                    Description = "A klíma töltés egy olyan folyamat, amely során az autó légkondicionáló rendszerében lévő hűtőközeg mennyisége újratöltődik vagy pótolódik. Ez a folyamat azért fontos, mert az idő múlásával a hűtőközeg mennyisége csökkenhet, ami a légkondicionáló rendszer hatékonyságának csökkenéséhez vezethet.",
                    CarServiceId = 1,
                },
                new Service
                {
                    Type = ServiceType.SuspensionAdjustment,
                    Description = "A futómű állítás egy olyan folyamat, amely során a jármű kerekeinek és felfüggesztésének beállításait finomhangolják, hogy a gumiabroncsok egyenletesen kopjanak és a jármű irányíthatósága optimális legyen. Ez az eljárás általában szakembert és speciális berendezést igényel.",
                    CarServiceId = 1,
                },
                new Service
                {
                    Type = ServiceType.DefectRepair,
                    Description = "A defekt javítás egy olyan eljárás, amellyel egy sérült autógumi javítható, ha a sérülés nem túl súlyos.",
                    CarServiceId = 2,
                },
                new Service
                {
                    Type = ServiceType.TireChange,
                    Description = "Az abroncs csere egy olyan folyamat, amely során a régi vagy kopott gumiabroncsokat lecserélik újakra.",
                    CarServiceId = 2,
                },
                new Service
                {
                    Type = ServiceType.ClimateCharge,
                    Description = "A klíma töltés egy olyan folyamat, amely során az autó légkondicionáló rendszerében lévő hűtőközeg mennyisége újratöltődik vagy pótolódik. Ez a folyamat azért fontos, mert az idő múlásával a hűtőközeg mennyisége csökkenhet, ami a légkondicionáló rendszer hatékonyságának csökkenéséhez vezethet.",
                    CarServiceId = 2,
                },
                new Service
                {
                    Type = ServiceType.SuspensionAdjustment,
                    Description = "A futómű állítás egy olyan folyamat, amely során a jármű kerekeinek és felfüggesztésének beállításait finomhangolják, hogy a gumiabroncsok egyenletesen kopjanak és a jármű irányíthatósága optimális legyen. Ez az eljárás általában szakembert és speciális berendezést igényel.",
                    CarServiceId = 2,
                },
                new Service
                {
                    Type = ServiceType.DefectRepair,
                    Description = "A defekt javítás egy olyan eljárás, amellyel egy sérült autógumi javítható, ha a sérülés nem túl súlyos.",
                    CarServiceId = 3,
                },
                new Service
                {
                    Type = ServiceType.TireChange,
                    Description = "Az abroncs csere egy olyan folyamat, amely során a régi vagy kopott gumiabroncsokat lecserélik újakra.",
                    CarServiceId = 3,
                },
                new Service
                {
                    Type = ServiceType.ClimateCharge,
                    Description = "A klíma töltés egy olyan folyamat, amely során az autó légkondicionáló rendszerében lévő hűtőközeg mennyisége újratöltődik vagy pótolódik. Ez a folyamat azért fontos, mert az idő múlásával a hűtőközeg mennyisége csökkenhet, ami a légkondicionáló rendszer hatékonyságának csökkenéséhez vezethet.",
                    CarServiceId = 3,
                },
                new Service
                {
                    Type = ServiceType.SuspensionAdjustment,
                    Description = "A futómű állítás egy olyan folyamat, amely során a jármű kerekeinek és felfüggesztésének beállításait finomhangolják, hogy a gumiabroncsok egyenletesen kopjanak és a jármű irányíthatósága optimális legyen. Ez az eljárás általában szakembert és speciális berendezést igényel.",
                    CarServiceId = 3,
                },
                new Service
                {
                    Type = ServiceType.SuspensionAdjustment,
                    Description = "A futómű állítás egy olyan folyamat, amely során a jármű kerekeinek és felfüggesztésének beállításait finomhangolják, hogy a gumiabroncsok egyenletesen kopjanak és a jármű irányíthatósága optimális legyen. Ez az eljárás általában szakembert és speciális berendezést igényel.",
                    CarServiceId = 4,
                },
                new Service
                {
                    Type = ServiceType.DefectRepair,
                    Description = "A defekt javítás egy olyan eljárás, amellyel egy sérült autógumi javítható, ha a sérülés nem túl súlyos.",
                    CarServiceId = 5,
                },
                new Service
                {
                    Type = ServiceType.TireChange,
                    Description = "Az abroncs csere egy olyan folyamat, amely során a régi vagy kopott gumiabroncsokat lecserélik újakra.",
                    CarServiceId = 5,
                },
                new Service
                {
                    Type = ServiceType.ClimateCharge,
                    Description = "A klíma töltés egy olyan folyamat, amely során az autó légkondicionáló rendszerében lévő hűtőközeg mennyisége újratöltődik vagy pótolódik. Ez a folyamat azért fontos, mert az idő múlásával a hűtőközeg mennyisége csökkenhet, ami a légkondicionáló rendszer hatékonyságának csökkenéséhez vezethet.",
                    CarServiceId = 6,
                },
                new Service
                {
                    Type = ServiceType.SuspensionAdjustment,
                    Description = "A futómű állítás egy olyan folyamat, amely során a jármű kerekeinek és felfüggesztésének beállításait finomhangolják, hogy a gumiabroncsok egyenletesen kopjanak és a jármű irányíthatósága optimális legyen. Ez az eljárás általában szakembert és speciális berendezést igényel.",
                    CarServiceId = 6,
                },
                new Service
                {
                    Type = ServiceType.TireChange,
                    Description = "Az abroncs csere egy olyan folyamat, amely során a régi vagy kopott gumiabroncsokat lecserélik újakra.",
                    CarServiceId = 7,
                },
                new Service
                {
                    Type = ServiceType.ClimateCharge,
                    Description = "A klíma töltés egy olyan folyamat, amely során az autó légkondicionáló rendszerében lévő hűtőközeg mennyisége újratöltődik vagy pótolódik. Ez a folyamat azért fontos, mert az idő múlásával a hűtőközeg mennyisége csökkenhet, ami a légkondicionáló rendszer hatékonyságának csökkenéséhez vezethet.",
                    CarServiceId = 7,
                },
                new Service
                {
                    Type = ServiceType.SuspensionAdjustment,
                    Description = "A futómű állítás egy olyan folyamat, amely során a jármű kerekeinek és felfüggesztésének beállításait finomhangolják, hogy a gumiabroncsok egyenletesen kopjanak és a jármű irányíthatósága optimális legyen. Ez az eljárás általában szakembert és speciális berendezést igényel.",
                    CarServiceId = 7,
                },
                new Service
                {
                    Type = ServiceType.DefectRepair,
                    Description = "A defekt javítás egy olyan eljárás, amellyel egy sérült autógumi javítható, ha a sérülés nem túl súlyos.",
                    CarServiceId = 8,
                },
                new Service
                {
                    Type = ServiceType.TireChange,
                    Description = "Az abroncs csere egy olyan folyamat, amely során a régi vagy kopott gumiabroncsokat lecserélik újakra.",
                    CarServiceId = 8,
                },
                new Service
                {
                    Type = ServiceType.ClimateCharge,
                    Description = "A klíma töltés egy olyan folyamat, amely során az autó légkondicionáló rendszerében lévő hűtőközeg mennyisége újratöltődik vagy pótolódik. Ez a folyamat azért fontos, mert az idő múlásával a hűtőközeg mennyisége csökkenhet, ami a légkondicionáló rendszer hatékonyságának csökkenéséhez vezethet.",
                    CarServiceId = 8,
                },
                new Service
                {
                    Type = ServiceType.SuspensionAdjustment,
                    Description = "A futómű állítás egy olyan folyamat, amely során a jármű kerekeinek és felfüggesztésének beállításait finomhangolják, hogy a gumiabroncsok egyenletesen kopjanak és a jármű irányíthatósága optimális legyen. Ez az eljárás általában szakembert és speciális berendezést igényel.",
                    CarServiceId = 8,
                },
                new Service
                {
                    Type = ServiceType.ClimateCharge,
                    Description = "A klíma töltés egy olyan folyamat, amely során az autó légkondicionáló rendszerében lévő hűtőközeg mennyisége újratöltődik vagy pótolódik. Ez a folyamat azért fontos, mert az idő múlásával a hűtőközeg mennyisége csökkenhet, ami a légkondicionáló rendszer hatékonyságának csökkenéséhez vezethet.",
                    CarServiceId = 9,
                },
                new Service
                {
                    Type = ServiceType.SuspensionAdjustment,
                    Description = "A futómű állítás egy olyan folyamat, amely során a jármű kerekeinek és felfüggesztésének beállításait finomhangolják, hogy a gumiabroncsok egyenletesen kopjanak és a jármű irányíthatósága optimális legyen. Ez az eljárás általában szakembert és speciális berendezést igényel.",
                    CarServiceId = 9,
                },
                new Service
                {
                    Type = ServiceType.ClimateCharge,
                    Description = "A klíma töltés egy olyan folyamat, amely során az autó légkondicionáló rendszerében lévő hűtőközeg mennyisége újratöltődik vagy pótolódik. Ez a folyamat azért fontos, mert az idő múlásával a hűtőközeg mennyisége csökkenhet, ami a légkondicionáló rendszer hatékonyságának csökkenéséhez vezethet.",
                    CarServiceId = 10,
                },
                new Service
                {
                    Type = ServiceType.SuspensionAdjustment,
                    Description = "A futómű állítás egy olyan folyamat, amely során a jármű kerekeinek és felfüggesztésének beállításait finomhangolják, hogy a gumiabroncsok egyenletesen kopjanak és a jármű irányíthatósága optimális legyen. Ez az eljárás általában szakembert és speciális berendezést igényel.",
                    CarServiceId = 10,
                },
            };
            foreach (Service service in services)
            {
                context.Services.Add(service);
            }
            context.SaveChanges();

            var appointments = new Appointment[] 
            {
                new Appointment
                {
                    StartTime = DateTime.Now,
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 1,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(30),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 1,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(60),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 1,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(90),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 1,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(60),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 2,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(150),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 2,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(180),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 2,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(240),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 2,
                },
                new Appointment
                {
                    StartTime = DateTime.Now,
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 3,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(90),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 3,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(240),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 3,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(300),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 3,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(300),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 4,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(330),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 4,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(360),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 4,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(390),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 4,
                },
                new Appointment
                {
                    StartTime = DateTime.Now,
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 5,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(30),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 5,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(60),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 5,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(90),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 5,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(180),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 6,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(300),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 6,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(420),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 6,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(450),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 6,
                },
                new Appointment
                {
                    StartTime = DateTime.Now,
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 7,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(30),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 7,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(60),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 7,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(90),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 7,
                },
                new Appointment
                {
                    StartTime = DateTime.Now,
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 8,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(30),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 8,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(60),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 8,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(90),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 8,
                },
                new Appointment
                {
                    StartTime = DateTime.Now,
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 9,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(30),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 9,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(60),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 9,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(90),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 9,
                },
                new Appointment
                {
                    StartTime = DateTime.Now,
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 10,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(30),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 10,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(60),
                    Duration = 30,
                    IsBooked = true,
                    ServiceId = 10,
                },
                new Appointment
                {
                    StartTime = DateTime.Now.AddMinutes(90),
                    Duration = 30,
                    IsBooked = false,
                    ServiceId = 10,
                },
            };
            foreach (Appointment appointment in appointments)
            {
                context.Appointments.Add(appointment);
            }
            context.SaveChanges();
        }
    }
}
