using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MundoManager.Serializer.Dt
{
    [DataContract]
    class DtList
    {
        [DataMember]
        internal List<dtItem> jugadores;
    }

    [DataContract]
    class dtItem
    {
        [DataMember]
        internal int id;
        [DataMember]
        internal string codigo;
        [DataMember]
        internal Jugador jugador;
        [DataMember]
        internal ClubActual clubActual;
        [DataMember]
        internal int cotizacion;
    }

    [DataContract]
    internal class Jugador
    {
        [DataMember]
        internal int id;
        [DataMember]
        internal string nombres;
        [DataMember]
        internal string apellido;
        [DataMember]
        internal PosicionSugerida posicionSugerida;
    }
   
    [DataContract]
    internal class PosicionSugerida
    {
        [DataMember]
        internal int id;
        [DataMember]
        internal string nombre;
        [DataMember]
        internal string nombreCorto;
        [DataMember]
        internal int orden;
    }

    [DataContract]
    internal class ClubActual
    {
        [DataMember]
        internal int id;
        [DataMember]
        internal string nombre;
        [DataMember]
        internal string nombreCorto;
        [DataMember]
        internal bool extranjero;
    }
}
