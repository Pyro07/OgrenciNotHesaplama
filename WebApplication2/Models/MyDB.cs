namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    public class MyDB : DbContext
    {
        // Your context has been configured to use a 'MyDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApplication2.Models.MyDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyDB' 
        // connection string in the application configuration file.
        public MyDB()
            : base("name=MyDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Ders> Dersler { get; set; }
        public virtual DbSet<Ogrenci> Ogrenciler { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class Ders
    {
        public int Id { get; set; }
        public string DersAdi { get; set; }
    }

    public class Ogrenci
    {
        [Key]
        public int Id { get; set; }

        public int OgrenciNumarasi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public int DersId { get; set; }
        //[Display(Name ="Ders")]
        //public IEnumerable<SelectListItem> DersId { get; set; }
        public string DersinAdi { get; set; }
        public double Vize { get; set; }
        public double Final { get; set; }
        public double Ortalama { get; set; }

        [NotMapped]
        public List<SelectListItem> DersList { get; set; }
        //[NotMapped]
        //public List<SelectListItem> DersList { get; set; }
    }
}