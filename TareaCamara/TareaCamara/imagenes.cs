using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace TareaCamara
{
    public class imagenes
    {
        [PrimaryKey, AutoIncrement]
        public int CodigoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Byte foto { get; set; }

    }
}
