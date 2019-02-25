using DataAccess.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class FillData
    {
        public static void Main()
        {
            VMCustomersUserDbContextFactory dbFactory = new VMCustomersUserDbContextFactory();

            using (var db = dbFactory.CreateDbContext(null))
            {
                db.Database.EnsureCreated();

                List<DataCustomer> customers = new List<DataCustomer>()
                {
                    new DataCustomer
                    {
                        CustomerId = "1",
                        Name = "Kamil",
                        Addresses = new List<DataAddress>()
                        {
                            new DataAddress
                            {
                                AddressType = "I",
                                Street = "Polna",
                                ZIP = "26-670",
                                City = "Pionki",
                                Country = "PL"
                            },
                            new DataAddress
                            {
                                AddressType = "D",
                                Street = "Miejska",
                                ZIP = "02-670",
                                City = "Warszawa",
                                Country = "PL"
                            }
                        }
                    },
                    new DataCustomer
                    {
                        CustomerId = "2",
                        Name = "Yavhen",
                        Addresses = new List<DataAddress>()
                        {
                            new DataAddress
                            {
                                AddressType = "S",
                                Street = "Kosmos",
                                ZIP = "26-670",
                                City = "Wrocław",
                                Country = "PL"
                            },
                            new DataAddress
                            {
                                AddressType = "D",
                                Street = "Miejska",
                                ZIP = "02-670",
                                City = "Warszawa",
                                Country = "PL"
                            }
                        }

                    }

                };

                db.Customer.AddRange(customers);

                db.SaveChanges();

                
            }
        }
    }
}

