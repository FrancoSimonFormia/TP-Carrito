using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int IDImagen { get; set; }
        public int IDArticulo { get; set; }
        public string Url { get; set; }

        public Imagen(int iDArticulo, string url)
        {

            this.IDArticulo = iDArticulo;
            this.Url = url;
        }

        public override string ToString()
        {
            return Url;
        }

        public Imagen()
        {
        }
    }
}
