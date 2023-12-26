using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Comentario
    {
        public Guid Id { get; set; }
        public Guid ? ComentarioPadreID { get; set; }
        public Guid EntidadID { get; set; }
        public int EntidadTipoID { get; set; }
        public Guid UsuarioID { get; set; }
        public string Texto { get; set; }
        public DateTime FechaHora { get; set; }
        public Guid EventoID { get; set; }

        ///*Objetos de Relacion*/
        //public EntidadTipo EntidadTipo { get; set; }
        //public Usuario Usuario { get; set; }
        //public Evento Evento { get; set; }
    }
}
