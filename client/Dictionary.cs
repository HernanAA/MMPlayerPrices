using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MundoManager.Serializer.MapDictionary
{
    [DataContract]
    class Dictionary
    {
        [DataMember]
        internal List<Jugador> jugadores;
    }

    [DataContract]
    class Jugador
    {
        [DataMember]
        internal int mmId = 0;
        [DataMember]
        internal int dtId = 0;
        [DataMember]
        internal string mmDescripcion;
        [DataMember]
        internal string dtDescripcion;
    }
}

