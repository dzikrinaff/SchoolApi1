using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolApi.Models;

    public class Nama
    {
        public int Id { get; set; }
        public string nama { get; set; }
        
        public int KelasId { get; set; }

        public int JurusanId { get; set; }

        [ForeignKey("KelasId")]
        public Kelas Kelas { get; set; }

        [ForeignKey("JurusanId")]
        public Jurusan jurusan { get; set; }

      
    }

