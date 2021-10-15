using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Entity;

namespace flight_manager_2021
{
    public class Program
    {
        public static bool seedDataBase = false;
        public static void Main(string[] args)
        {
#if DEBUG
            if (seedDataBase)
            {
                SeedDataBase();
            }
#endif

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        private static void SeedDataBase()
        {
            ConnectionDB connectionDB = new Data.ConnectionDB();

            if (connectionDB.Users.Count() > 0 || connectionDB.Flights.Count() > 0)
            {
                throw new Exception("Database is already seeded!");
            }

            using (connectionDB)
            {
                Random rng = new Random();

                User[] users = new User[14];
                users[0] = new User();
                users[1] = new User();
                users[2] = new User();
                users[3] = new User();
                users[4] = new User();
                users[5] = new User();
                users[6] = new User();
                users[7] = new User();
                users[8] = new User();
                users[9] = new User();
                users[10] = new User();
                users[11] = new User();
                users[12] = new User();
                users[13] = new User();

                users[0].UserName = "Theodora";
                users[1].UserName = "Angharad";
                users[2].UserName = "Eleanor";
                users[3].UserName = "Lili";
                users[4].UserName = "Brielle";
                users[5].UserName = "Tatiana";
                users[6].UserName = "Shayna";
                users[7].UserName = "Tye";
                users[8].UserName = "Lester";
                users[9].UserName = "Marta";
                users[10].UserName = "Riaz";
                users[11].UserName = "Nathanael";
                users[12].UserName = "Macy";
                users[13].UserName = "Kier";

                users[0].Address = "4106 Timberbrook Lane";
                users[1].Address = "3641 Grasselli Street";
                users[2].Address = "4601 Kinney Street";
                users[3].Address = "3308 West Virginia Avenue";
                users[4].Address = "1667 Ashton Lane";
                users[5].Address = "2427 Coulter Lane";
                users[6].Address = "4285 Gandy Street";
                users[7].Address = "650 Leisure Lane";
                users[8].Address = "4301 Edgewood Road";
                users[9].Address = "2731 Ridge Road";
                users[10].Address = "3862 Sheila Lane";
                users[11].Address = "4756 Richland Avenue";
                users[12].Address = "2533 Arrowood Drive";
                users[13].Address = "4139 Shady Pines Drive";

                users[0].EGN = "1895557326";
                users[1].EGN = "2112424757";
                users[2].EGN = "1349492426";
                users[3].EGN = "1554744446";
                users[4].EGN = "0709659934";
                users[5].EGN = "2119878402";
                users[6].EGN = "0708487983";
                users[7].EGN = "0933553419";
                users[8].EGN = "1898557326";
                users[9].EGN = "0124700418";
                users[10].EGN = "2052282553";
                users[11].EGN = "617089804";
                users[12].EGN = "986634891";
                users[13].EGN = "1459456695";


                users[0].Email = "casde.pique@lttmobile.com";
                users[1].Email = "4beeatporradaoq@goreadit.site";
                users[2].Email = "zzin@tvlagu.com";
                users[3].Email = "dhaydr188g@bookiy.site";
                users[4].Email = "tmmazinmo208@byrnewear.com";
                users[5].Email = "lsani@phongkeha.com";
                users[6].Email = "juc@modabet47.com";
                users[7].Email = "wmohamed.maiz.396@opakenak.com";
                users[8].Email = "wadil.hamdi.18z@bitsakia.com";
                users[9].Email = "qmerrily@valibri.com";
                users[10].Email = "cmnox40p@gotcertify.com";
                users[11].Email = "lali.varane.12@pianoxltd.com";
                users[12].Email = "uali.gosto.187@pickuplanet.com";
                users[13].Email = "nyousuf.faird@getmail.fun";

                users[0].FirstName = "Theodora";
                users[1].FirstName = "Angharad";
                users[2].FirstName = "Eleanor";
                users[3].FirstName = "Lili";
                users[4].FirstName = "Brielle";
                users[5].FirstName = "Tatiana";
                users[6].FirstName = "Shayna";
                users[7].FirstName = "Tye";
                users[8].FirstName = "Lester";
                users[9].FirstName = "Marta";
                users[10].FirstName = "Riaz";
                users[11].FirstName = "Nathanael";
                users[12].FirstName = "Macy";
                users[13].FirstName = "Kier";

                users[0].LastName = "Enriquez";
                users[1].LastName = "Nichols";
                users[2].LastName = "Haigh";
                users[3].LastName = "Dalton";
                users[4].LastName = "Cowan";
                users[5].LastName = "Fox";
                users[6].LastName = "Reeves";
                users[7].LastName = "Chung";
                users[8].LastName = "Ashton";
                users[9].LastName = "Morrison";
                users[10].LastName = "Lister";
                users[11].LastName = "Robin";
                users[12].LastName = "Moyer";
                users[13].LastName = "Cardenas";

                users[0].Password = "BK4TIzfXJq";
                users[1].Password = "IpXvbuw7c3";
                users[2].Password = "iCo1SauU4H";
                users[3].Password = "dOUb5WgpRL";
                users[4].Password = "qb78txlMrd";
                users[5].Password = "RMNI6CKifR";
                users[6].Password = "SrdYZpqiwr";
                users[7].Password = "L2NI2egSh9";
                users[8].Password = "1PnAOUUqUB";
                users[9].Password = "w4vDyVifof";
                users[10].Password = "qcSNfq49JV";
                users[11].Password = "WN4W29qp16";
                users[12].Password = "FpyVM00Ejk";
                users[13].Password = "XNe8vA31F1";

                users[0].Role = "User";
                users[1].Role = "User";
                users[2].Role = "User";
                users[3].Role = "User";
                users[4].Role = "User";
                users[5].Role = "Admin";
                users[6].Role = "CEO";
                users[7].Role = "User";
                users[8].Role = "User";
                users[9].Role = "User";
                users[10].Role = "User";
                users[11].Role = "User";
                users[12].Role = "User";
                users[13].Role = "User";

                users[0].Role = "user";
                users[1].Role = "user";
                users[2].Role = "user";
                users[3].Role = "user";
                users[4].Role = "user";
                users[5].Role = "user";
                users[6].Role = "user";
                users[7].Role = "user";
                users[8].Role = "user";
                users[9].Role = "user";
                users[10].Role = "user";
                users[11].Role = "user";
                users[12].Role = "user";
                users[13].Role = "user";

                users[0].Role = rng.Next().ToString();
                users[1].Role = rng.Next().ToString();
                users[2].Role = rng.Next().ToString();
                users[3].Role = rng.Next().ToString();
                users[4].Role = rng.Next().ToString();
                users[5].Role = rng.Next().ToString();
                users[6].Role = rng.Next().ToString();
                users[7].Role = rng.Next().ToString();
                users[8].Role = rng.Next().ToString();
                users[9].Role = rng.Next().ToString();
                users[10].Role = rng.Next().ToString();
                users[11].Role = rng.Next().ToString();
                users[12].Role = rng.Next().ToString();
                users[13].Role = rng.Next().ToString();

                users[0].PhoneNumber = rng.Next().ToString();
                users[1].PhoneNumber = rng.Next().ToString();
                users[2].PhoneNumber = rng.Next().ToString();
                users[3].PhoneNumber = rng.Next().ToString();
                users[4].PhoneNumber = rng.Next().ToString();
                users[5].PhoneNumber = rng.Next().ToString();
                users[6].PhoneNumber = rng.Next().ToString();
                users[7].PhoneNumber = rng.Next().ToString();
                users[8].PhoneNumber = rng.Next().ToString();
                users[9].PhoneNumber = rng.Next().ToString();
                users[10].PhoneNumber = rng.Next().ToString();
                users[11].PhoneNumber = rng.Next().ToString();
                users[12].PhoneNumber = rng.Next().ToString();
                users[13].PhoneNumber = rng.Next().ToString();

                connectionDB.Users.AddRange(users);

                Flight[] flights = new Flight[5];

                flights[0] = new Flight();
                flights[1] = new Flight();
                flights[2] = new Flight();
                flights[3] = new Flight();
                flights[4] = new Flight();

                flights[0].LocationFrom = "Iceland";
                flights[1].LocationFrom = "Bulgaria";
                flights[2].LocationFrom = "Spain";
                flights[3].LocationFrom = "Russia";
                flights[4].LocationFrom = "Japan";

                flights[0].LocationTo = "Spain";
                flights[1].LocationTo = "Iceland";
                flights[2].LocationTo = "Spain";
                flights[3].LocationTo = "Korea";
                flights[4].LocationTo = "Russia";

                /*byte[] bytes = new byte[32];
                long myLong = BitConverter.ToInt64(bytes);

                rng.NextBytes(bytes);
                flights[0].Going = new DateTime(myLong);

                rng.NextBytes(bytes);
                myLong = BitConverter.ToInt64(bytes);
                flights[1].Going = new DateTime(myLong);

                rng.NextBytes(bytes);
                myLong = BitConverter.ToInt64(bytes);
                flights[2].Going = new DateTime(myLong);

                rng.NextBytes(bytes);
                myLong = BitConverter.ToInt64(bytes);
                flights[3].Going = new DateTime(myLong);

                rng.NextBytes(bytes);
                myLong = BitConverter.ToInt64(bytes);
                flights[4].Going = new DateTime(myLong);

                rng.NextBytes(bytes);
                flights[0].Return = new DateTime(myLong);
                rng.NextBytes(bytes);
                myLong = BitConverter.ToInt64(bytes);
                flights[1].Return = new DateTime(myLong);
                rng.NextBytes(bytes);
                myLong = BitConverter.ToInt64(bytes);
                flights[2].Return = new DateTime(myLong);
                rng.NextBytes(bytes);
                myLong = BitConverter.ToInt64(bytes);
                flights[3].Return = new DateTime(myLong);
                rng.NextBytes(bytes);
                myLong = BitConverter.ToInt64(bytes);
                flights[4].Return = new DateTime(myLong);*/

                flights[0].TakeOffTime = DateTime.Now;
                flights[1].TakeOffTime = DateTime.Now;
                flights[2].TakeOffTime = DateTime.Now;
                flights[3].TakeOffTime = DateTime.Now;
                flights[4].TakeOffTime = DateTime.Now;

                flights[0].LandingTime = DateTime.Now;
                flights[1].LandingTime = DateTime.Now;
                flights[2].LandingTime = DateTime.Now;
                flights[3].LandingTime = DateTime.Now;
                flights[4].LandingTime = DateTime.Now;


                flights[0].CapacityOfBusinessClass = rng.Next();
                flights[1].CapacityOfBusinessClass = rng.Next();
                flights[2].CapacityOfBusinessClass = rng.Next();
                flights[3].CapacityOfBusinessClass = rng.Next();
                flights[4].CapacityOfBusinessClass = rng.Next();

                flights[0].CapacityOfEconomyClass = rng.Next();
                flights[1].CapacityOfEconomyClass = rng.Next();
                flights[2].CapacityOfEconomyClass = rng.Next();
                flights[3].CapacityOfEconomyClass = rng.Next();
                flights[4].CapacityOfEconomyClass = rng.Next();

                flights[0].NameOfAviator = "Theodora";
                flights[1].NameOfAviator = "Angharad";
                flights[2].NameOfAviator = "Eleanor";
                flights[3].NameOfAviator = "Shayna";
                flights[4].NameOfAviator = "Lili";

                flights[0].TypeOfPlane = "Normal";
                flights[1].TypeOfPlane = "Normal";
                flights[2].TypeOfPlane = "Abnormal";
                flights[3].TypeOfPlane = "Normal";
                flights[4].TypeOfPlane = "Normal";

                connectionDB.AddRange(flights);

                connectionDB.SaveChanges();
            }
        }
    }
}
