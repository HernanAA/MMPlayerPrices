using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MundoManager.Serializer.MM
{
    [XmlRoot("plantelEquipo")]
    public class MMList
    {
        [XmlElement("deporte")]
        public Deporte deporte { get; set; }
        [XmlElement("equipo")]
        public Equipo equipo { get; set; }
    }

    public class Deporte
    {
        [XmlAttribute("id")]
        public int id { get; set; }
        [XmlText]
        public string deporteText{ get; set; }
    }

    public class Equipo
    {
        [XmlAttribute("id")]
        public int id { get; set; }
        [XmlAttribute("nombre")]
        public string nombre { get; set; }
        [XmlAttribute("sigla")] // == nombreCorto
        public string sigla { get; set; }
        [XmlElement("jugadores")]
        public Jugadores jugadores { get; set; }
    }

    public class Jugadores
    {
        //[XmlAttribute("cant")]
        //public int cant { get; set; }
        [XmlElement("jugador")]
        public List<Jugador> jugadorList { get; set; }
    }

    public class Jugador
    {
        [XmlAttribute("id")]
        public int id { get; set; }
        [XmlElement("pais")]
        public string pais { get; set; }
        [XmlElement("nombre")]
        public string nombre { get; set; }
        [XmlElement("apellido")]
        public string apellido { get; set; }

    }
}
