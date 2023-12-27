﻿using Domain.Entities.Catalog;

namespace Domain.Entities
{
    public class Publicacion
    {
        public Guid Id { get; set; }
        public Guid ReferenciaID { get; set; }
        public int EventoTipoID { get; set; }
        public Guid EventoID { get; set; }
    }
}
