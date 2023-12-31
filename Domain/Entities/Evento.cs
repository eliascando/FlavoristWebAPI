﻿namespace Domain.Entities
{
    public class Evento
    {
        public Guid Id { get; set; }
        public Guid ReferenciaID { get; set; }
        public int EventoTipoID { get; set; }
        public int EntidadTipoID { get; set; }
        public Guid UsuarioID { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
