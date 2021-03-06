﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    // Repository innehåller de mest grundläggande anropen mot databasen
    // ta bort, lägga till, hämta en specifik, hämta alla
    // tänk "grundstomme"
    public class GradesRepository : IGrades
    {
        // interfacet till klassen Grades kopplas hit, dvs 
        // klassen implementerar interface IGrades

        // databas-objekt 
        private readonly AppDbContext database;

        // constructor
        public GradesRepository(AppDbContext appDbContext)
        {
            database = appDbContext;
        }

        // hämta alla kommentarer
        public IEnumerable<Grades> GetGradesAll()
        {
            return database.DbGrades;
        }

        // hämta alla kommentarer för angiven produkt
        public IEnumerable<Grades> GetGradesByProduct(int inProjektId)
        {
            return database.DbGrades.
                            Where(c => c.ProductId == inProjektId);
            //Where(c => c.ProductId == inProjektId).ToList();
        }

        // lägg till ny kommentar
        public void AddGrades(Grades inGrades)
        {
            database.DbGrades.Add(inGrades);
            database.SaveChanges();
        }
    }
}

