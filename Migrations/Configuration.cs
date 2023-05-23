namespace CarRentalApp.Migrations
{
    using CarRentalApp.Models.DbModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarRentalApp.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarRentalApp.Models.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var client1 = new Client("Anna", "Solak", IdentityDocument.National_Id_Card, "DS432", "567879890", "annasolak@.pl", "Konopnickiej", "3", "7", "Cracow");
            var client2 = new Client("Kamil", "Kornik", IdentityDocument.Driver_s_license, "GRF2394", "543245654", "kkornik@gmail.com", "Zaległa", "9", "23", "Warsaw");
            var client3 = new Client("Mirosław", "Kowalski", IdentityDocument.National_Id_Card, "TD56819", "654345998", "kowalmirek@.com", "Powstania Warszawskiego", "56", "2", "Warsaw");

            
           


            var worker1 = new Worker("Wiesław", "Marek");
            var worker2 = new Worker("Amelia", "Kowala");
            var worker3 = new Worker("Zuzanna", "Opola");

            
            


            var carmodel1 = new CarModel("Opel", "Astra");
            var carmodel2 = new CarModel("Mazda", "MX3");
            var carmodel3 = new CarModel("Peugeot", "208");

            


            var car1 = new Car("KWA2356", "2009", "234500", carmodel3, "300", "97", "black", "5", EnumCarBody.Sedan);
            var car2 = new Car("SB3451", "2000", "1900000", carmodel2, "50", "70", "yellow", "5", EnumCarBody.Sedan);
            var car3 = new Car("KR2389", "2019", "32400", carmodel1, "250", "100", "black", "4", EnumCarBody.Sedan);

            


            var booking1 = new Booking(new DateTime(2023, 05, 29), new DateTime(2023, 05, 30), client3, car3);
            var booking2 = new Booking(new DateTime(2023,05,17),new DateTime(2023, 05, 26), client1, car2);
            var booking3 = new Booking(new DateTime(2023,05,24), new DateTime(2023,05,26), client1, car3);

            
           


            var rental1 = new Rental(new DateTime(2023, 09, 04,00,00,00), new DateTime(2023,09,06), client1,worker3 ,car2);
            var rental2 = new Rental(new DateTime(2023, 05, 23), new DateTime(2023, 05, 27), client1, worker2, car1);
            var rental3 = new Rental(new DateTime(2023, 05, 02), new DateTime(2023, 05, 09), client3, worker1, car2);

            context.Cars.AddOrUpdate(c =>c.CarRegistrationNumber,car1, car2, car3);
            context.Workers.AddOrUpdate(c => c.WorkerId,worker1, worker2, worker3);
            context.Models.AddOrUpdate(c => c.CarModelId,carmodel1, carmodel2, carmodel3);
            context.Clients.AddOrUpdate(c => c.ClientId,client1, client2, client3);
            context.SaveChanges();
            context.Rentals.AddOrUpdate(c => c.RentalId,rental1,rental2,rental3);
            context.Bookings.AddOrUpdate(c=> c.BookingId,booking1,booking2,booking3);
            context.SaveChanges();
        }
    }
}
