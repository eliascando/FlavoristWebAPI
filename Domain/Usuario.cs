using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public Guid PaisID { get; set; }
        public Guid UsuarioTipoID { get; set; }
        public Boolean Estado { get; set; }
        
        ///* Objetos de Relacion */
        //public Pais Pais { get; set; }
        //public Receta Recetas { get; set; }
        //public UsuarioTipo UsuarioTipo { get; set; }
        //public UsuarioRecetaCategoriaFav UsuarioRecetaCategoriaFav { get; set; }
        //public UsuarioRecetaFav UsuarioRecetaFav { get; set; }
        //public Comentario Comentario { get; set; }

        ///* Listas de Objetos de Relacion */
        //public List<Comentario> Comentarios { get; set; }
    }
}
