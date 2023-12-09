using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apidotnet.Entity
{
    public class Livro
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int NPaginas { get; set; }
        public DateTime DTInserted { get; set; }
        public DateTime DTUpdated { get; set; }
    }
}