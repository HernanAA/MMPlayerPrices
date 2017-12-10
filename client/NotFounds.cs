using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MundoManager.Serializer.NF
{
    [DataContract]
    class NotFounds
    {
        [DataMember]
        internal List<Jugador> jugadores;
    }

    [DataContract]
    class Jugador
    {
        [DataMember]
        internal int id;
        [DataMember]
        internal string nombre;
        [DataMember]
        internal string apellido;
        [DataMember]
        internal string sigla;
        [DataMember]
        internal int fileId;
    }
}

