namespace Test3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class OgrenciListeDB : DbContext
    {
        // Your context has been configured to use a 'OgrenciListeDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Test3.Models.OgrenciListeDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'OgrenciListeDB' 
        // connection string in the application configuration file.
        public OgrenciListeDB()
            : base("name=OgrenciListeDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Ogrenci> Ogrenci { get; set; }
        public virtual DbSet<Ders> Ders { get; set; }
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
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Numara { get; set; }
        public string Ders { get; set; }
        public double Vize { get; set; }
        public double Final { get; set; }
        public double Ortalama { get; set; }
    }

}